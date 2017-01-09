// Logger.cpp : Defines the entry point for the console application.
// This application is going to listen on port and will receive the messages.
// It will log the infomration coming into respective component files. Files should be auto rotation.

#include "stdafx.h"
#include "zmq.hpp"

#include <iostream>
#include <fstream>
#include <sstream>
#include <chrono>
#include <fcntl.h>

#define HUNDREDMB 104857600;

std::string LogPath;
unsigned long MAXFILESIZE;

int getLogFileTime(std::string &out) {
	time_t tmx = time(NULL);
	struct tm tm;
	localtime_s(&tm, &tmx);
	char date[20];
	strftime(date, sizeof(date), "%Y%m%d%H", &tm);
	out = date;
	return 0;
}

int getLogFileTimMine(std::string &out) {
	time_t tmx = time(NULL);
	struct tm tm;
	localtime_s(&tm, &tmx);
	char date[20];
	strftime(date, sizeof(date), "%Y%m%d%H%M", &tm);
	out = date;
	return 0;
}

void getCurrentTime(std::string &currTime) {
	char time1[24] = { '\0' };
	std::chrono::system_clock::time_point now = std::chrono::system_clock::now();
	std::chrono::system_clock::duration tp = now.time_since_epoch();
	tp -= std::chrono::duration_cast<std::chrono::seconds>(tp);
	time_t tt = std::chrono::system_clock::to_time_t(now);
	struct tm tm;
	localtime_s(&tm, &tt);
	std::snprintf(time1, 24, "[%04u-%02u-%02u %02u:%02u:%02u.%03u]", tm.tm_year + 1900, tm.tm_mon + 1, tm.tm_mday, tm.tm_hour, tm.tm_min, tm.tm_sec,
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

void readConfig(std::string configFile) {
	size_t prev = 0, pos = 0;
	std::string confdata;
	std::string delim("\n");
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
			if (token.substr(0, 7) == "LOGPATH") {
				p1 = token.find("=", 0); p1 += 2;
				LogPath = token.substr(p1, token.length()-1);
				if (LogPath[LogPath.length() - 1] == '"') {
					LogPath = LogPath.substr(0, LogPath.length() - 1);
				}
				std::cout << "logPath : " <<LogPath << std::endl;
			}
			else if (token.substr(0,11) == "MAXFILESIZE") {
				p1 = token.find("=", 0); p1++;
				std::cout << token.substr(p1, token.length() - 1) << std::endl;
				MAXFILESIZE = atoi((const char *)token.substr(p1, token.length() - 1).c_str());
			}
		}
		prev = pos + delim.length();
	} while (pos < confdata.length() && prev < confdata.length());
}

int writeLog(std::string logString){
	std::string logFileName;
	std::string logFileTime;
	std::ofstream logFile;
	struct _stat buf;
	int result = -1;
	try {
		getLogFileTime(logFileTime);
		logFileName = LogPath + "\\" + logFileTime + "-Logger.log";
		//std::cout << "Log Path : " << logFileName << std::endl;

		result = _stat(logFileName.c_str(), &buf);
		if (result == 0) {
			if (buf.st_size > MAXFILESIZE) {
				getLogFileTimMine(logFileTime);
				logFileName = LogPath + "\\" + logFileTime + "-Logger.log";
			}
		}
		logFile.open(logFileName, std::ios::out | std::ios::app | std::ios::binary);
		logFile << logString;
		logFile.close();
		//std::cout << "written " << logString.length() << " bytes." << std::endl;
	}
	catch (std::system_error e) {
		std::cerr << "Unable to open " + logFileName + " due to " + e.code().message() << std::endl;
		return -1;
	}
	return 0;
}

int main(int argc, char **argv)
{
	if (argc < 2) {
		std::cerr << "Usage ./" << argv[0] << " <config path>" << std::endl;
		exit(0);
	}
	MAXFILESIZE = 0;
	readConfig(argv[1]);
	if (MAXFILESIZE == 0) {
		MAXFILESIZE = HUNDREDMB;
	}
	std::cout << "Starting logger" << std::endl;
	std::string bindString("tcp://127.0.0.1:5558");
	std::string stringbuf="";
	int bufSize = 0;

	zmq::context_t context(1);
	zmq::socket_t log_socket(context, ZMQ_PULL);
	log_socket.bind(bindString);

	std::cout << "Going to listen on : " << bindString << std::endl;
	bool to_kill = false;
	while (!to_kill) {
		//std::cout << "Going to read msg..." << std::endl;
		zmq::message_t message;
		log_socket.recv(&message);
		if (bufSize >= 4000) {
			writeLog(stringbuf);
			char st[4000] = { '\0' };
			strncpy_s(st, 4000, (char *)message.data(), message.size());
			stringbuf = stringbuf + "\n" + st;
			//stringbuf = (char *)message.data();
			bufSize = stringbuf.length();
		}
		else {
			int msgSize = 4000;
			char st[4000] = { '\0' };
			strncpy_s(st, 4000, (char *)message.data(), message.size());
			stringbuf = stringbuf + "\n" + st;
			//stringbuf = stringbuf + "\n" +(char *)message.data();
			bufSize = stringbuf.length();
		}
		std::cout << "Received : " << message.size() << " Bytes."<< std::endl;
	}	
	return 0;
}