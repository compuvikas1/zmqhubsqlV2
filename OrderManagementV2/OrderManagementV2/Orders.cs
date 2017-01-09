using QuickFix;
using QuickFix.Fields;
using System;

namespace OrderManagementV2
{
    enum state
    {
        NEW,
        SCRATCH,
        AMEND,
        CANCEL,
        REJECT,
        WORKING,
        COMPLETED
    }

    enum action
    {
        SAVE,
        CANCEL,
        PUBLISH
    }

    class Orders 
    {
        private bool isOrderAmendPossible(char [] orderStatus)
        {
            return true;
        }
        
        public Orders() { }
                
        public int addAck() {
            return 0;
        }

        public int addReject()
        {
            return 0;
        }
        private string sanitiseField(char[] field)
        {
            string data = new string(field);
            if (data.Contains("#"))
            {
                return new string(data.Substring(0, data.IndexOf('#')).ToCharArray());
            }
            return data;
        }
        public int addOrder(OrderStruct os)
        {
            OrderDAO odao = new OrderDAO();
            Console.WriteLine("Going to call DB");
            int ordNo = odao.insertOrder(os);

            ClOrdID OrdId = new ClOrdID(Convert.ToString(os.ID));
            string symbol = sanitiseField(os.symbol);
            var order = new QuickFix.FIX42.NewOrderSingle(OrdId, new HandlInst('1'), new Symbol(symbol), new Side(Side.BUY),
                new TransactTime(DateTime.Now.ToUniversalTime()), new OrdType(OrdType.LIMIT));

            order.Price = new Price((decimal)os.price);
            order.SetField(new OrderQty(1));

            Session.SendToTarget(order, FixClient.MySess);
            return ordNo;
        }

        public int amendOrder(ref OrderStruct os)
        {
            if (!isOrderAmendPossible(os.OrderStatus))
            {
                return -1;
            }
            OrderDAO ord = new OrderDAO();
            int ordNo = ord.amendOrder(ref os);
            Console.WriteLine("TODO: Send FIX - cancel for os.LinkedOrderID ; Send FIX - New for os.ID");
            //Send FIX - cancel for os.LinkedOrderID
            //Send FIX - New for os.ID
            return ordNo;            
        }
        
        public int cancelOrder(OrderStruct os) {//will add check in case of already filled, no cancel.
            OrderDAO ord = new OrderDAO();
            OrderStruct dbos = new OrderStruct(8,8); 
            if(ord.getOrderFromDB(os.OrderNo,ref dbos) < 0)
            {
                Console.WriteLine("Error : Unable to get order details from DB");
                return -1;
            }
            Console.WriteLine("DBG: truct val");
            dbos.display();
            string ordStatus = new string(dbos.OrderStatus);
            if(ordStatus.Equals("CANCELED") || ordStatus.Equals("COMPLETED"))
            {
                Console.WriteLine("Order is already "+ordStatus);
                return -1;
            }
            Console.WriteLine("Order No ["+dbos.OrderNo+"] : Status ["+ordStatus+"]");
            //return -1;
            if (ord.cancelOrder(dbos) < 0) { return -1; }
            Console.WriteLine("TODO: Send FIX - cancel for os.ID");
            //Send FIX - cancel for os.ID
            return 0;
        }

        public int addFills(OrderFillStruct ofs)
        {
            OrderDAO ord = new OrderDAO();
            int ordStatus = ord.addOrderFills(ofs);
            if (ordStatus == 0) {
                Console.WriteLine("This Order is completed now [Order ID] = "+ofs.OrderNo);
            } else
            {
                Console.WriteLine("Order qty diff : " + ordStatus);
            }
            //this will calculate the qty and mark order as complete and all.
            return 0;
        }

        private int isPartillyFilled()
        {
            return 0;
        }

        private int isFullyFilled()
        {
            return 0;
        }

        private bool canCancelOrder()
        {
            return false;
        }
    }
}
