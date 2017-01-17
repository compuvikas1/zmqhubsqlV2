using System;
using System.Runtime.InteropServices;

namespace OrderManagementV2
{
    [StructLayout(LayoutKind.Sequential)]
    public struct OrderFillStruct
    {
        public int ID;
        public int OrderNo;
        public int FillID;
        public float Quantity;
        public float Price;
        public float FilledQuantity;

        public void display()
        {
            Console.WriteLine("FillID : {0}", ID);
            Console.WriteLine("OrderNo : {0}", OrderNo);
            Console.WriteLine("FillID : {0}", FillID);
            Console.WriteLine("price : {0}", Price);
            Console.WriteLine("quantity : {0}", Quantity);
            Console.WriteLine("FilledQuantity : {0}", FilledQuantity);
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct OrderStruct
    {
        public int ID;
        public int OrderNo;
        public int methodID;
        public float price;
        public int strike;
        public float quantity;
        public char direction;
        public int version;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] OrderStatus;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] symbol;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] expiry;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2)]
        public char[] callput;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] exch;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 36)]
        public char[] machineID;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 36)]
        public char[] userID;

        public OrderStruct(int isym, int ios)
        {
            OrderStatus = new char[ios];
            symbol = new char[isym];
            methodID = 0;
            ID = 0;
            OrderNo = 0;
            price = 0;
            strike = 0;
            quantity = 0;
            direction = '\0';
            version = 0;
            expiry = new char[8];
            callput = new char[2];
            exch = new char[3];
            machineID = new char[36];
            userID = new char[36];
        }

        public void display()
        {
            Console.WriteLine("OrderStatus : {0}", new string(OrderStatus));
            Console.WriteLine("symbol : {0}", new string(symbol));
            Console.WriteLine("methodID : {0}", methodID);
            Console.WriteLine("OrderID : {0}", ID);
            Console.WriteLine("OrderNo : {0}", OrderNo);
            Console.WriteLine("version : {0}", version);
            Console.WriteLine("price : {0}", price);
            Console.WriteLine("strike : {0}", strike);
            Console.WriteLine("quantity : {0}", quantity);
            Console.WriteLine("direction : {0}", direction);
            Console.WriteLine("callput : {0}", new string(callput));
            Console.WriteLine("exch : {0}", new string(exch));
            Console.WriteLine("machineID : {0}", new string(machineID));
            Console.WriteLine("userID : {0}", new string(userID));
        }
    };

    public enum RequestType
    {
        INS, AMD, CAN, UNK
    };
}
