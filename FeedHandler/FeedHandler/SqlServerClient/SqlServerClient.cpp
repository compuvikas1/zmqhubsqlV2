// SqlServerClient.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <iostream>
#include <windows.h>
#include <sql.h>
#include <sqltypes.h>
#include <sqlext.h>
#include <algorithm>
#include <functional> 
#include <cctype>
#include <locale>

using namespace std;

void show_error(unsigned int handletype, const SQLHANDLE& handle) {
	SQLWCHAR sqlstate[1024];
	SQLWCHAR message[1024];
	if (SQL_SUCCESS == SQLGetDiagRec(handletype, handle, 1, sqlstate, NULL, message, 1024, NULL))
		wcout << "Message: " << message << " nSQLSTATE: " << sqlstate << endl;
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
	strncpy_s(instr,len,(char *)str.c_str(),len);
	return str;
}

int main() {

	SQLHANDLE sqlenvhandle;
	SQLHANDLE sqlconnectionhandle;
	SQLHANDLE sqlstatementhandle;
	SQLRETURN retcode;

	if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, &sqlenvhandle)) {
		exit(0);
	}

	if (SQL_SUCCESS != SQLSetEnvAttr(sqlenvhandle, SQL_ATTR_ODBC_VERSION, (SQLPOINTER)SQL_OV_ODBC3, 0)) {
		exit(0);
	}
	if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_DBC, sqlenvhandle, &sqlconnectionhandle)) {
		SQLFreeHandle(SQL_HANDLE_ENV, sqlenvhandle);
		exit(0);
	}
	SQLWCHAR retconstring[1024];
	retcode = SQLDriverConnectW( sqlconnectionhandle,NULL,L"DSN=db1; SERVER=SONY-VAIO;DATABASE=LPIntraDay;UID=zmq1;PWD=test123;", SQL_NTS, retconstring, 1024, NULL, SQL_DRIVER_COMPLETE);
	//retcode = SQLDriverConnect(sqlconnectionhandle, NULL, (SQLWCHAR*)"DRIVER={ODBC Driver 11 for SQL Server};SERVER=SONY-VAIO,1433;DATABASE=test;Trusted_Connection=Yes;UID=zmq1;PWD=test123;", SQL_NTS, retconstring, 1024, NULL, SQL_DRIVER_PROMPT);
	//retcode = SQLDriverConnect(sqlconnectionhandle, NULL, (SQLWCHAR*)"DRIVER={SQL Server Native Client 10.0};SERVER=SONY-VAIO\\SQLEXPRESS,1433;DATABASE=LPIntraDay;UID=zmq1;PWD=test123;", SQL_NTS, retconstring, 1024, NULL, SQL_DRIVER_NOPROMPT);
	
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
		exit(0);
	default:
		break;
	}
	if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_STMT, sqlconnectionhandle, &sqlstatementhandle)) {
		closeAll(sqlconnectionhandle, sqlstatementhandle, sqlenvhandle);
		exit(0);
	}
	
	//std::cout << __LINE__ << " come here " << std::endl;
	//std::string stmt = "SELECT ScripNo , UpdateTime	, LastTime, PCloseRate	, OpenRate	, HighRate FROM LPIntraDay.dbo.TouchLine";
	
	int iRet = SQLExecDirectW(sqlstatementhandle, L"SELECT Symbol, Exch, Series, OptType, StrikePrice, ExpiryDate, MLot, ScripNo, UpdateTime, PCloseRate, LastRate, TotalQty FROM LPReliableMap.dbo.vwFeed", SQL_NTS);
	//std::cout << __LINE__ << " come here "<<iRet << std::endl;

	if (iRet != SQL_SUCCESS ) {
		show_error(SQL_HANDLE_STMT, sqlstatementhandle);
		//std::cout << __LINE__ << " come here " << std::endl;
		closeAll(sqlconnectionhandle, sqlstatementhandle, sqlenvhandle);
		exit(0);
	}
	else {
		//std::cout << __LINE__ <<" result found " << std::endl;
		//char Exch[3], Series[10], Symbol[10], OptType[2], ExpiryDate[20], UpdateTime[20];
		//float StrikePrice,PcloseRate, LastRate;
		//int MLot,ScriptNo, TotalQty;
		int counter = 1, columns = 12;
		while (SQLFetch(sqlstatementhandle) == SQL_SUCCESS) {
			for (int i = 1; i <= columns; i++) {
				SQLLEN indicator;
				char buf[512];
				SQLGetData(sqlstatementhandle, i, SQL_C_CHAR,buf, sizeof(buf), &indicator);
				std::cout << shorttrim(buf,sizeof(buf)) << ",";
				//printf("  Column %u : %s\n", i, buf);
			}
			std::cout << std::endl;
			/*
			SQLGetData(sqlstatementhandle, 1, SQL_C_CHAR, Exch, sizeof(Exch), NULL);
			SQLGetData(sqlstatementhandle, 2, SQL_C_CHAR, Series, sizeof(Series), NULL);
			SQLGetData(sqlstatementhandle, 3, SQL_C_CHAR, Symbol, sizeof(Symbol), NULL);
			SQLGetData(sqlstatementhandle, 4, SQL_C_CHAR, OptType, sizeof(OptType), NULL);
			SQLGetData(sqlstatementhandle, 5, SQL_C_FLOAT, &StrikePrice,10, NULL);
			SQLGetData(sqlstatementhandle, 6, SQL_C_DATE, ExpiryDate, sizeof(ExpiryDate), NULL);
			SQLGetData(sqlstatementhandle, 7, SQL_C_NUMERIC, &MLot, 10, NULL);
			SQLGetData(sqlstatementhandle, 8, SQL_C_NUMERIC, &ScriptNo, 10, NULL);
			SQLGetData(sqlstatementhandle, 9, SQL_C_DATE, UpdateTime, sizeof(UpdateTime), NULL);
			SQLGetData(sqlstatementhandle, 10, SQL_C_FLOAT, &PcloseRate, 10, NULL);
			SQLGetData(sqlstatementhandle, 11, SQL_C_FLOAT, &LastRate, 10, NULL);
			SQLGetData(sqlstatementhandle, 12, SQL_C_NUMERIC, &TotalQty, 10, NULL);
			//std::cout << "Values : " << std::endl;
			std::cout << "["<< counter++ << "]"<< shorttrim(Symbol,strlen(Symbol)) << "," << Exch << "," << shorttrim(Series, strlen(Series)) << "," << OptType << "," << StrikePrice << ",[" << ExpiryDate << "]," << MLot << "," << ScriptNo << "," << UpdateTime << "," << PcloseRate << "," << LastRate << "," << TotalQty << std::endl;
			*/
		}
		closeAll(sqlconnectionhandle, sqlstatementhandle, sqlenvhandle);
	}
}
