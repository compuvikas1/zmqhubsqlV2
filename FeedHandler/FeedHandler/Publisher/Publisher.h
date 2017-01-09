#include "stdafx.h"
#include "logger.h"
int s_send(void *socket, char *string);
int zmqLog(LOGLEVEL loglevel, std::string comp, std::string data);