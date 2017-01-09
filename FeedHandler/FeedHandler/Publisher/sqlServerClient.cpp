#include "stdafx.h"

#include <iostream>
#include <Windows.h>
#include <sql.h>
#include <sqltypes.h>
#include <sqlext.h>
#include <algorithm>
#include <functional> 
#include <cctype>
#include <locale>
#include <chrono>
#include "Publisher.h"
#include "logger.h"

void show_error(unsigned int handletype, const SQLHANDLE& handle) {
	SQLWCHAR sqlstate[1024];
	SQLWCHAR message[1024];
	if (SQL_SUCCESS == SQLGetDiagRec(handletype, handle, 1, sqlstate, NULL, message, 1024, NULL)) {
		std::wcout << "Message: " << message << " nSQLSTATE: " << sqlstate << std::endl;
		std::string msg((char *)message);
		zmqLog(ERR, "SQL-ERROR", msg);
	}		
}

void getCurrentTime1(std::string &currTime) {
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

void closeAll(SQLHANDLE sqlconnectionhandle, SQLHANDLE sqlstatementhandle, SQLHANDLE sqlenvhandle) {
	SQLFreeHandle(SQL_HANDLE_STMT, sqlstatementhandle);
	SQLDisconnect(sqlconnectionhandle);
	SQLFreeHandle(SQL_HANDLE_DBC, sqlconnectionhandle);
	SQLFreeHandle(SQL_HANDLE_ENV, sqlenvhandle);
}

inline std::string shorttrim(char *instr, int len)
{
	std::string str(instr);
	str.erase(0, str.find_first_not_of(' '));       //prefixing spaces
	str.erase(str.find_last_not_of(' ') + 1);         //surfixing spaces
	strncpy_s(instr, len, (char *)str.c_str(), len);
	return str;
}

int fetchFeeds(void * publisher) {

	SQLHANDLE sqlenvhandle;
	SQLHANDLE sqlconnectionhandle;
	SQLHANDLE sqlstatementhandle;
	SQLRETURN retcode;

	if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, &sqlenvhandle)) {
		return -1;
	}

	if (SQL_SUCCESS != SQLSetEnvAttr(sqlenvhandle, SQL_ATTR_ODBC_VERSION, (SQLPOINTER)SQL_OV_ODBC3, 0)) {
		return -1;
	}
	if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_DBC, sqlenvhandle, &sqlconnectionhandle)) {
		SQLFreeHandle(SQL_HANDLE_ENV, sqlenvhandle);
		return -1;
	}
	SQLWCHAR retconstring[1024];
	
	//retcode = SQLDriverConnectW(sqlconnectionhandle, NULL, L"DSN=db1; SERVER=SONY-VAIO;DATABASE=LPIntraDay;UID=zmq1;PWD=test123;", SQL_NTS, retconstring, 1024, NULL, SQL_DRIVER_COMPLETE);
	//local
	//retcode = SQLDriverConnectW(sqlconnectionhandle, NULL, L"DSN=db1;DATABASE=LPINTRADAY;UID=sa;PWD=sa123;", SQL_NTS, retconstring, 1024, NULL, SQL_DRIVER_COMPLETE);
	//server
	retcode = SQLDriverConnectW(sqlconnectionhandle, NULL, L"DSN=db2;DATABASE=LPINTRADAY;UID=sa;PWD=sa123;", SQL_NTS, retconstring, 1024, NULL, SQL_DRIVER_COMPLETE);
	
	switch (retcode) {
	case SQL_SUCCESS_WITH_INFO:
		show_error(SQL_HANDLE_DBC, sqlconnectionhandle);
		break;
	case SQL_INVALID_HANDLE:
	case SQL_ERROR:
		show_error(SQL_HANDLE_DBC, sqlconnectionhandle);
		SQLDisconnect(sqlconnectionhandle);
		SQLFreeHandle(SQL_HANDLE_DBC, sqlconnectionhandle);
		SQLFreeHandle(SQL_HANDLE_ENV, sqlenvhandle);
		return -1;
	default:
		break;
	}
	
	while (1) {
		if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_STMT, sqlconnectionhandle, &sqlstatementhandle)) {
			closeAll(sqlconnectionhandle, sqlstatementhandle, sqlenvhandle);
			return -1;
		}
		std::string st;
		getCurrentTime1(st);
		std::cout << "Time [" <<st <<"] "<< std::endl;
		//int iRet = SQLExecDirectW(sqlstatementhandle, L"SELECT Symbol, UpdateTime, CONVERT(VARCHAR(10),ExpiryDate,105), OptType, StrikePrice, Exch, PCloseRate, LastRate, TotalQty, Series, MLot, ScripNo FROM LPReliableMap.dbo.vwFeed where symbol in ('NIFTY','ANDHRABANK')", SQL_NTS);		
		//int iRet = SQLExecDirectW(sqlstatementhandle, L"SELECT Symbol, UpdateTime, CONVERT(VARCHAR(10),ExpiryDate,105), OptType, StrikePrice, Exch, PCloseRate, LastRate, TotalQty, Series, MLot, ScripNo FROM LPReliableMap.dbo.vwFeed where UpdateTime >= DATEADD(second,-5,GETDATE())", SQL_NTS);

		//now we use
		int iRet = SQLExecDirectW(sqlstatementhandle, L"SELECT Symbol, UpdateTime, CONVERT(VARCHAR(10),ExpiryDate,105), OptType, StrikePrice, Exch, PCloseRate, LastRate, TotalQty, Series, MLot, ScripNo, OpenRate, HighRate, LowRate, AvgRate FROM LPReliableMap.dbo.vwFeedV1", SQL_NTS);
		//int iRet = SQLExecDirectW(sqlstatementhandle, L"SELECT Symbol, UpdateTime, CONVERT(VARCHAR(10),ExpiryDate,105), OptType, StrikePrice, Exch, PCloseRate, LastRate, TotalQty, Series, MLot, ScripNo, OpenRate, HighRate, LowRate, AvgRate FROM LPReliableMap.dbo.vwFeedV1 where UpdateTime >= DATEADD(second,-5,GETDATE())", SQL_NTS);

		if (iRet != SQL_SUCCESS) {
			show_error(SQL_HANDLE_STMT, sqlstatementhandle);
			closeAll(sqlconnectionhandle, sqlstatementhandle, sqlenvhandle);
			return -1;
		}
		else {
			int counter = 1, columns = 16;
			//std::cout << __LINE__ << "[" << __func__ << "] DBG:" << std::endl;
			std::string outString;
			while (SQLFetch(sqlstatementhandle) == SQL_SUCCESS) {
				outString = "";
				for (int i = 1; i <= columns; i++) {
					//std::cout << __LINE__ << "[" << __func__ << "] DBG: " << i << std::endl;
					SQLLEN indicator;
					char buf[512] = {'\0'};
					/*if (i == 2) {
						getCurrentTime1(st);
						strncpy_s(buf,512,st.c_str(),25);
					}
					else {
						SQLGetData(sqlstatementhandle, i, SQL_C_CHAR, buf, sizeof(buf), &indicator);
					}*/
					SQLGetData(sqlstatementhandle, i, SQL_C_CHAR, buf, sizeof(buf), &indicator);
					outString = outString + shorttrim(buf, sizeof(buf)) + ",";
					//std::cout << shorttrim(buf, sizeof(buf)) << ",";				
				}
				outString.erase(outString.end() - 1);
				//std::cout << outString << std::endl;				
				s_send(publisher, (char *)outString.c_str());
				//std::cout << __LINE__ << "[" << __func__ << "] DBG:" << std::endl;
				//zmqLog(DEBUG, "SQL-FETCH", outString);
				//std::cout << __LINE__ << "["<<__func__ << "] DBG:" << std::endl;
				//Sleep(50);
				//std::cout << std::endl;
			}
		}
		SQLFreeHandle(SQL_HANDLE_STMT, sqlstatementhandle);
		Sleep(500);
	}
	closeAll(sqlconnectionhandle, sqlstatementhandle, sqlenvhandle);
	return 0;
}
