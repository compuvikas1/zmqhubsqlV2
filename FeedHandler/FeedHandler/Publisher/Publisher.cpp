// Publisher.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <assert.h>
#include <signal.h>
#include <stdarg.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include <iostream>
#include <fstream>
#include <sstream> 
#include <chrono>
#include "zmq.hpp"

#define _CRTDBG_MAP_ALLOC
#include <crtdbg.h>
#include "Publisher.h"
#include "JSONValue.h"
#include "logger.h"
#include "sqlServerClient.h"

#define srandom srand
#define random rand

std::string component;
LOGLEVEL level;
std::string logServerStr;
std::string feedSource;

//typedef void(*sig_t)(int);

//  Provide random number from 0..(num-1)
#define randof(num)  (int) ((float) (num) * random () / (RAND_MAX + 1.0))

int gotSignalToStop;

//  Receive 0MQ string from socket and convert into C string
//  Caller must free returned string. Returns NULL if the context
//  is being terminated.
static char * s_recv(void *socket) {
	char buffer[256];
	int size = zmq_recv(socket, buffer, 255, 0);
	if (size == -1)
		return NULL;
	//return strndup(buffer, sizeof(buffer) - 1);
	return _strdup(buffer);
	// remember that the strdup family of functions use malloc/alloc for space for the new string.  It must be manually
	// freed when you are done with it.  Failure to do so will allow a heap attack.
}

//  Convert C string to 0MQ string and send to socket
int s_send(void *socket, char *string) {
	int size = zmq_send(socket, string, strlen(string), 0);
	////std::cout << "ZMQ ["<< size <<"]";
	return size;
}

//  Sends string as 0MQ string, as multipart non-terminal
static int s_sendmore(void *socket, char *string) {
	int size = zmq_send(socket, string, strlen(string), ZMQ_SNDMORE);
	return size;
}

//  Receives all message parts from socket, prints neatly
//
static void s_dump(void *socket)
{
	int rc;

	zmq_msg_t message;
	rc = zmq_msg_init(&message);
	assert(rc == 0);

	puts("----------------------------------------");
	//  Process all parts of the message
	do {
		int size = zmq_msg_recv(&message, socket, 0);
		assert(size >= 0);

		//  Dump the message as text or binary
		char *data = (char*)zmq_msg_data(&message);
		assert(data != 0);
		int is_text = 1;
		int char_nbr;
		for (char_nbr = 0; char_nbr < size; char_nbr++) {
			if ((unsigned char)data[char_nbr] < 32
				|| (unsigned char)data[char_nbr] > 126) {
				is_text = 0;
			}
		}

		printf("[%03d] ", size);
		for (char_nbr = 0; char_nbr < size; char_nbr++) {
			if (is_text) {
				printf("%c", data[char_nbr]);
			}
			else {
				printf("%02X", (unsigned char)data[char_nbr]);
			}
		}
		printf("\n");
	} while (zmq_msg_more(&message));

	rc = zmq_msg_close(&message);
	assert(rc == 0);
}

static void s_set_id(void *socket, intptr_t id)
{
	char identity[10];
	sprintf_s(identity, "%04X", (int)id);
	zmq_setsockopt(socket, ZMQ_IDENTITY, identity, strlen(identity));
}

//  Sleep for a number of milliseconds
static void s_sleep(int msecs)
{
	Sleep(msecs);
}

//  Return current system clock as milliseconds
static int64_t s_clock(void)
{
	SYSTEMTIME st;
	GetSystemTime(&st);
	return (int64_t)st.wSecond * 1000 + st.wMilliseconds;
}

void my_handler(int s) {
	gotSignalToStop = 1;
	printf("Caught signal %d\n", s);
}

int OSIParser(std::string input, std::string &symbol, std::string &date, std::string &calllPut , std::string &strike) {
	symbol = input.substr(0, 6);
	date = input.substr(7,12);
	calllPut = input.substr(12, 13);
	strike = input.substr(13, 21);
	return 0;
}

int getLocalTime(long input, std::string &out) {
	time_t tmx = input;
	struct tm tm;
	localtime_s(&tm,&tmx);
	//std::cout << "Coming here ["<<error_local<<"] ["<<input<<"] ["<<tmx<<"]" << std::endl;
	char date[20];
	strftime(date, sizeof(date), "%Y-%m-%d %H:%M:%S", &tm);
	out = date;
	return 0;
}

void getCurrentTime(std::string &currTime) {
	char time1[26] = { '\0' };
	std::chrono::system_clock::time_point now = std::chrono::system_clock::now();
	std::chrono::system_clock::duration tp = now.time_since_epoch();
	tp -= std::chrono::duration_cast<std::chrono::seconds>(tp);
	time_t tt = std::chrono::system_clock::to_time_t(now);
	struct tm tm;
	localtime_s(&tm, &tt);
	std::snprintf(time1, 26, "[%04u-%02u-%02u %02u:%02u:%02u.%04u]", tm.tm_year + 1900, tm.tm_mon + 1, tm.tm_mday, tm.tm_hour, tm.tm_min, tm.tm_sec,
		static_cast<unsigned>(tp / std::chrono::milliseconds(1)));
	currTime = time1;
}

int readFile(std::string fileName, std::string &out) {
	std::ifstream inFile;
	try {
		std::cout << "Going to read " << fileName << std::endl;
		inFile.open(fileName);//open the input file
		std::stringstream oss;
		oss << inFile.rdbuf();//read the file
		out = oss.str();
		return 0;
	}
	catch (std::system_error e) {
		std::cerr << "Unable to open " + fileName + " due to " + e.code().message() << std::endl;
		return -1;
	}
}

LOGLEVEL getLogLevel(std::string ll) {
	if (ll == "INFO") return INFO;
	if (ll == "ERR") return ERR;
	if (ll == "WAR") return WAR;
	if (ll == "DEBUG") return DEBUG;
	return INFO;
}

void readConfig(std::string configFile) {
	size_t prev = 0, pos = 0;
	std::string confdata;
	std::string delim("\n");
	TCHAR pwd[MAX_PATH];
	GetCurrentDirectory(MAX_PATH, pwd);
	std::cout << "Going to read local config " << configFile << std::endl;
	if (readFile(configFile, confdata) != 0) {
		std::cerr << "Unable to read the config. going with default settings" << std::endl;
		return;
	}
	std::cout << "Able to read local config : " << configFile << "with size " << confdata.size() << std::endl;
	if (confdata.size() < 10) {
		std::cerr << "Very less bytes in config, So ignoring it" << std::endl;
		return;
	}
	do
	{
		pos = confdata.find(delim, prev);
		if (pos == std::string::npos) pos = confdata.length();
		std::string token = confdata.substr(prev, pos - prev);
		if (!token.empty()) {
			if (token[0] == '#') {
				prev = pos + delim.length();
				continue;
			}
			size_t p1;
			if (token.substr(0, 8) == "LOGLEVEL") {
				p1 = token.find("=", 0); p1++;
				level = getLogLevel(token.substr(p1, token.length()));
			}
			if (token.substr(0, 9) == "LOGSERVER") {
				p1 = token.find("=", 0); p1++;
				logServerStr = token.substr(p1, token.length());
			}
			if (token.substr(0, 9) == "COMPONENT") {
				p1 = token.find("=", 0); p1++;
				component = token.substr(p1, token.length());
			}
			if (token.substr(0, 12) == "COMPONENTLOG") {
				p1 = token.find("=", 0); p1++;
				component = (LOGLEVEL)std::stoi(token.substr(p1, token.length()));
			}
			if (token.substr(0, 10) == "FEEDSOURCE") {
				p1 = token.find("=", 0); p1++;
				feedSource = token.substr(p1, token.length());
			}
		}
		prev = pos + delim.length();
	} while (pos < confdata.length() && prev < confdata.length());
}

int zmqLog(LOGLEVEL loglevel, std::string comp, std::string data) {
	//std::cout << __LINE__ << " " << logServerStr << " " << loglevel << " : Living : " << comp << " : " << data << std::endl;
	if (loglevel >= level) {
		//std::cout << __LINE__ << " " << logServerStr << " " << loglevel << " : Living : " << comp << " : " << data << std::endl;
		std::string  timestamp; //YYYY-MM-DD HH:MM:SS.xxxx
		getCurrentTime(timestamp);
		std::string logStatement = timestamp + " " + std::to_string(loglevel) + " " + component + " : " + data;
		zmq::context_t context(1);
		zmq::socket_t socket(context, ZMQ_PUSH);
		socket.connect(logServerStr);
		zmq::message_t request(logStatement.length());
		memcpy((void *)request.data(), logStatement.c_str(), logStatement.length());
		socket.send(request);
		return 0;
	}
	else {
		//std::cout << "["<< loglevel << "] ["<<level << "] Do have line but in false!!!" << std::endl;
		return 1;
	}
}


int processSymbol(std::string sym, std::string value, int localcnt, std::string &outString) {
	//std::cout << "Data for sym [" << sym << "]" << std::endl;
	JSONValue *jsonValue = JSON::Parse(value.c_str());
	double iterator = 0;
	std::string symbol = "";
	if (!jsonValue) {
		std::cout << "No content from json" << std::endl;
		return -1;
	}
	else {
		JSONObject root;
		std::string OSI;
		std::string strike;
		std::string callPut;
		std::string date;
		std::string symbol;

		if (jsonValue->IsObject() == false)
		{
			std::cout << "The root element is not an object, did you change the example?" << std::endl;
			return -1;
		}
		else
		{
			//std::cout << "Symbol, TimeStamp, Expiry, Call/Put, strike, BidSize, BidPrice, AskPrice, AskSize, Volume" << std::endl;
			root = jsonValue->AsObject();
			if (root.find(L"OSI") != root.end() && root[L"OSI"]->IsString())
			{
				std::wstring OSIstr(root[L"OSI"]->AsString());
				std::string input(OSIstr.begin(), OSIstr.end());
				symbol = input.substr(0, 5);
				date = input.substr(6, 11);
				callPut = input.substr(12, 13);
				strike = input.substr(13, 20); //TODO: divide by 1000					
			}
			if (root.find(L"dim") != root.end() && root[L"dim"]->IsNumber())
			{
				iterator = root[L"dim"]->AsNumber();
			}
			for (int i = 0; i < iterator; i++) {
				std::string s = "quote" + std::to_string(i);
				std::wstring quote(s.begin(), s.end());
				std::string ltime;
				JSONObject quot = root[quote]->AsObject();
				if (quot[L"isNBBO"]->AsNumber() == 1) {
					getLocalTime((long)quot[L"time"]->AsNumber(), ltime);
					double lstrike = std::stod(strike);
					std::string data = symbol;
					data += "," + ltime; // std::to_string(quot[L"time"]->AsNumber());
					data += ",2016-09-30, " + callPut + " , " + std::to_string(lstrike / 1000) + " , " + std::to_string(quot[L"Bsz"]->AsNumber());
					data += ", " + std::to_string(quot[L"Bpx"]->AsNumber());
					data += ", " + std::to_string(quot[L"Asz"]->AsNumber());
					data += ", " + std::to_string(quot[L"Apx"]->AsNumber());
					data += ", " + std::to_string(localcnt);
					std::cout << data << std::endl;
					outString = data;
					return 0;
				}
			}
		}
	}
	return -1;
}

int main(int argc, char *argv[])
{
	signal(SIGINT, my_handler);
	char errorStr[1000] = { '\0' };
	int localcnt = 1001;
	std::string lfilePath = "c:\\s2trading\\zmqhubresource\\";
	std::string lfiles = "1";
	std::string configFile = "c:\\s2trading\\zmqhubresource\\publisher.config";
	/*
	if (argc > 3) {
		lfilePath = argv[1];
		lfiles = argv[2];
		configFile = argv[3];
	}
	else if (argc > 2) {
		lfilePath = argv[1];
		lfiles = argv[2];
	}
	else {
		lfiles = "SPY,GLD,DLD,CET";
	}*/

	component = "Feed Publisher";
	readConfig(configFile);

	void *context = zmq_ctx_new();
	void *publisher = zmq_socket(context, ZMQ_PUB);
	//int rc = zmq_bind(publisher, "tcp://127.0.0.1:5551");
	int rc = zmq_bind(publisher, "tcp://158.69.193.253:5551");
	if (rc != 0) {
		strerror_s(errorStr, errno);
		std::cout << errno << " [" << errorStr << "] " << std::endl;
		exit(0);
	}
	//assert(rc == 0);
	gotSignalToStop = 0;
	srandom((unsigned)time(NULL));

	int ierror = -1;
	std::string value;
	std::string delim = ",";
	std::vector<std::string> tokens;
	std::vector<std::string> contents;
	size_t prev = 0, pos = 0;
	do
	{
		pos = lfiles.find(delim, prev);
		if (pos == std::string::npos) pos = lfiles.length();
		std::string token = lfiles.substr(prev, pos - prev);
		if (!token.empty()) tokens.push_back(token);
		prev = pos + delim.length();
	} while (pos < lfiles.length() && prev < lfiles.length());

	std::cout << "Vector size : " << tokens.size() << " FS : " << feedSource << std::endl;
	//std::string ltime1, ltime2;
	if (feedSource == "SQL") {
		while (1) {
			//getCurrentTime(ltime1);
			fetchFeeds(publisher);
			std::cout << __LINE__ << " DBG:" << std::endl;
			//getCurrentTime(ltime2);
			//std::cout << "ltime1 = " << ltime1 << std::endl;
			//std::cout << "ltime2 = " << ltime2 << std::endl;
			Sleep(2000);
		}
	}
	else {
		for (std::vector<std::string>::iterator it = tokens.begin(); it != tokens.end(); ++it) {
			std::string lfileName = lfilePath + "\\" + *it + ".json";
			std::cout << "Read the file [" << lfileName << "]" << std::endl;
			ierror = readFile(lfileName, value);
			if (ierror != 0) {
				std::cerr << "Unable to read the file [" << lfileName << "]" << std::endl;
				zmqLog(ERR, component, "Unable to read the file [" + lfileName + "]");
				continue;
			}
			else {
				contents.push_back(value);
			}
		}	
		while (1) {
			std::string outString;
			int i = 0;
			for (std::vector<std::string>::iterator it = contents.begin(); it != contents.end(); ++it) {
				std::cout << "Processing [" << tokens.at(i) << "]" << std::endl;
				processSymbol(tokens.at(i++), *it, localcnt++, outString);
				s_send(publisher, (char *)outString.c_str());
				zmqLog(DEBUG, component, outString);
			}
			Sleep(5000);
		}
	}
	zmq_close(publisher);
	zmq_ctx_destroy(context);
	_CrtDumpMemoryLeaks();
	Sleep(10000);
    return 0;
}