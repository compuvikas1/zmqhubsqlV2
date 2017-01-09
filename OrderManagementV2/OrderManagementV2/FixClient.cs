using System;
using QuickFix;
using QuickFix.Fields;
using System.Data;

namespace OrderManagementV2
{
    class FixClient : QuickFix.IApplication
    {
        public void logMe(string data)
        {
            Console.WriteLine(data);
        }

        public static SessionID MySess;

        DataTable dtStocks = new DataTable();

        public FixClient()
        {
            //this.frm1 = form1;
        }
        public void FromApp(QuickFix.Message msg, SessionID sessionID)
        {
            logMe("\r\n \r\n" + "FromApp :" + msg.ToString());

            if (msg is QuickFix.FIX42.ExecutionReport)
            {
                QuickFix.FIX42.ExecutionReport er = (QuickFix.FIX42.ExecutionReport)msg;

                logMe("\r\n \r\n" + "Got execution Report - ExecType = " + er.ExecType.getValue());

                if (er.ExecType.getValue() == ExecType.FILL)
                {
                    logMe("\r\n \r\n" + "FromApp : order Filled");
                }
            }
        }
        public void OnCreate(SessionID sessionID)
        {
            logMe("\r\n \r\n" + "Session created : " + sessionID.ToString());
            MySess = sessionID;

        }
        public void OnLogout(SessionID sessionID)
        {
            logMe("\r\n \r\n" + "Logged out : " + sessionID.ToString());

        }
        public void OnLogon(SessionID sessionID)
        {
            logMe("\r\n \r\n" + "Logged In : " + sessionID.ToString());
        }
        public void FromAdmin(Message msg, SessionID sessionID)
        {
            logMe("\r\n \r\n" + "FromAdmin :" + msg.ToString() + "SessionID : " + sessionID.ToString());

        }
        public void ToAdmin(Message msg, SessionID sessionID)
        {
            logMe("\r\n \r\n" + "ToAdmin :" + msg.ToString() + "SessionID : " + sessionID.ToString());

        }
        public void ToApp(Message msg, SessionID sessionID)
        {
            logMe("\r\n \r\n" + "ToApp :" + msg.ToString());

        }
    }
}
 
