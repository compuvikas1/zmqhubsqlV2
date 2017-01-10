using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

//TODO: check if conn is not valid, again open teh connection.
namespace OrderManagementV2
{
    class OrderDAO
    {
        public string orderSeq = "getNextOrder";
        public string orderIDSeq = "getNextOrderID";
        public string FillSeq = "getNextFillID";
        private SqlConnection conn;

        public OrderDAO()
        {            
            string DataSource = ConfigurationManager.AppSettings.Get("OMDBServer");
            string Database = ConfigurationManager.AppSettings.Get("OMDatabase");
            string user = ConfigurationManager.AppSettings.Get("OMDBUser");
            string pass = ConfigurationManager.AppSettings.Get("OMDBPass");

            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataSource;
            builder.InitialCatalog = Database;
            builder.UserID = user;
            builder.Password = pass;
            conn = new SqlConnection(builder.ToString());
            conn.Open();
        }

        private void refreshConnection()
        {
            if(conn.State != ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
        }

        private int getNextSeq(string seqName)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = seqName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("value", ""));

                    var returnParameter = cmd.Parameters.Add("@value", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    var tnp = returnParameter.Value;
                    return Convert.ToInt32(tnp);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Some exception : " + ex.Message);
            }
            return -1;
        }

        private int getNextSeq()
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "getNextVal";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("value", ""));

                    var returnParameter = cmd.Parameters.Add("@value", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    var tnp = returnParameter.Value;
                    return Convert.ToInt32(tnp);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Some exception : " + ex.Message);
            }
            return -1;
        }

        private int getLastVersion(int orderNo, ref int ver, ref int id)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    string query = "select id, version from orders where version = (select max(version) from orders where orderNo = "+orderNo+") and orderNo = "+orderNo+";";
                    cmd.CommandText = query;
                    Console.WriteLine("query : {0}", query);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tmp = reader["version"];
                            if (tmp != DBNull.Value) { ver = Convert.ToInt32(tmp); } else { ver = 0; }
                            tmp = reader["id"];
                            if (tmp != DBNull.Value) { id = Convert.ToInt32(tmp); } else { id = 0; }
                        }
                    }
                }
                Console.WriteLine("OrderNo : "+orderNo+" ver : "+ver+ " id : "+id);
                return 0;
            }
            catch (Exception ex)
            {
                Console.Write("Exception(getLatestVersion) : " + ex.Message);
            }
            return -1;
        }

        private int getOrderNoFromOrderID(int orderNo)
        {
            int orderID = -1;
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    string query = "select OrderNo from orders where ID = "+orderNo;
                    
                    cmd.CommandText = query;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tmp = reader["OrderNo"];
                            if (tmp != DBNull.Value) { orderID = Convert.ToInt32(tmp); } else { orderID = -1; }                            
                        }
                    }
                }
                return orderID;
            }
            catch (Exception ex)
            {
                Console.Write("Exception(getLatestVersion) : " + ex.Message);
            }
            return -1;
        }
        private int fillStatus(int orderNo)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    string query1 = "select quantity qty from orders where version = (select max(version) from orders where orderNo = " + orderNo + ") and orderNo = " + orderNo + ";";
                    string query2 = "select sum(Quantity) qty from fills where orderNo = " + orderNo + " group by orderNo;";
                    cmd.CommandText = query1;
                    int OrdQty = 0;
                    int FillQty = 0;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tmp = reader["qty"];
                            if (tmp != DBNull.Value) { OrdQty = Convert.ToInt32(tmp); } else { OrdQty = 0; }
                        }
                    }
                    cmd.CommandText = query2;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tmp = reader["qty"];
                            if (tmp != DBNull.Value) { FillQty = Convert.ToInt32(tmp); } else { FillQty = 0; }
                        }
                    }
                    if (OrdQty == FillQty && OrdQty > 0) // Order is competed;
                    {
                        return 0; // 100 means comleted
                    }
                    return OrdQty - FillQty;
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception(fillstatus) : " + ex.Message);
            }
            return -1;
        }

        private string sanitiseField(char []field)
        {
            string data = new string(field);
            if (data.Contains("#"))
            {                
                return new string (data.Substring(0, data.IndexOf('#')).ToCharArray());
            }
            return data;
        }

        public int insertOrderWithOrdeNO(int orderNo)
        {
            try
            {
                int id = 0;
                string OrderStatus = "";
                string symbol = "";
                float price = 0;
                float quantity =0;
                char direction = 'N';
                int version = 0;
                string machineID = "";
                string userID = "";

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    string query = "select ID,OrderStatus,symbol,price,quantity,direction,version,machineID,userID from orders where version = (select max(version) from orders where orderNo = " + orderNo+") and orderNo = "+orderNo+";";
                    cmd.CommandText = query;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tmp = reader["id"]; if (tmp != DBNull.Value) { id = Convert.ToInt32(tmp); } else { id = 0; }
                            tmp = reader["OrderStatus"]; if (tmp != DBNull.Value) { OrderStatus = Convert.ToString(tmp); } else { OrderStatus = ""; }
                            tmp = reader["symbol"]; if (tmp != DBNull.Value) { symbol = Convert.ToString(tmp); } else { symbol = ""; }
                            tmp = reader["price"]; if (tmp != DBNull.Value) { price = (float)Convert.ToDouble(tmp); } else { price = 0; }
                            tmp = reader["quantity"]; if (tmp != DBNull.Value) { quantity = (float)Convert.ToDouble(tmp); } else { quantity = 0; }
                            tmp = reader["direction"]; if (tmp != DBNull.Value) { direction = Convert.ToChar(tmp); } else { direction = 'N'; }
                            tmp = reader["version"]; if (tmp != DBNull.Value) { version = Convert.ToInt32(tmp); } else { version = 0; }
                            tmp = reader["machineID"]; if (tmp != DBNull.Value) { machineID = Convert.ToString(tmp); } else { machineID = ""; }
                            tmp = reader["userID"]; if (tmp != DBNull.Value) { userID = Convert.ToString(tmp); } else { userID = ""; }
                        }
                    }
                }

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    int orderID = getNextSeq(orderIDSeq);
                    //int orderNo = getNextSeq(orderSeq);
                    Console.WriteLine("Next Seq : {0}", orderNo);
                    string query = "INSERT INTO ORDERS (ID, OrderNo, OrderStatus,symbol,price, quantity,direction,version,machineID,userID,insertTS) VALUES ("
                        + orderID + "," + orderNo + "," + "'COMPLETED'" + "," + "'" + symbol + "'" + "," + price + "," + quantity + ",'" + direction + "',"+ version +",'"
                        + machineID + "','" + userID + "',SYSDATETIME());";
                    cmd.CommandText = query;
                    Console.WriteLine("query : {0}", query);
                    cmd.ExecuteNonQuery();
                    return orderID;
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception (insertOrderWithOrdeNO) : " + ex.Message);
            }
            return -1;
        }

        public int insertOrder(OrderStruct os)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    int orderID = getNextSeq(orderIDSeq);
                    int orderNo = getNextSeq(orderSeq);
                    Console.WriteLine("Next Seq : {0}", orderNo);
                    string symbol = sanitiseField(os.symbol);
                    string query = "INSERT INTO ORDERS (ID, OrderNo, OrderStatus,symbol,price, quantity,direction,version,machineID,userID,insertTS) VALUES ("
                        + orderID + "," + orderNo + "," + "'NEW'" + "," + "'"+ symbol +"'" + "," + os.price + "," + os.quantity + ",'" + os.direction + "',1,'"
                        + new string (os.machineID) + "','" + new string (os.userID) + "',SYSDATETIME());";
                    cmd.CommandText = query;
                    Console.WriteLine("query : {0}", query);
                    cmd.ExecuteNonQuery();
                    return orderNo;
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception (Insert) : " + ex.Message);
            }
            return -1;
        }
        
        public int amendOrder(ref OrderStruct os)//Update the previouss and add new
        {
            try
            {
                int orderID = getNextSeq(orderIDSeq);
                int orderNo = os.OrderNo;
                int ver = -1;
                int id = -1;
                getLastVersion(orderNo, ref ver, ref id);
                Console.WriteLine("DBG: "+orderNo+" : "+ver+" : "+id);
                if(ver == 0) { ver = 1; } else { ver++; }
                Console.WriteLine("DBG: "+orderNo + " : " + ver + " : " + id);
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    string symbol = sanitiseField(os.symbol);
                    string query = "INSERT INTO ORDERS (ID,OrderNo,LinkedOrderID,OrderStatus,symbol,price, quantity,direction,version,machineID,userID,insertTS) VALUES ("
                        + orderID + "," + orderNo +"," + id + "," + "'AMEND'" + ",'" + symbol + "'," + os.price + "," + os.quantity + ",'" + os.direction + "',"
                        + ver + ",'" + new string(os.machineID) + "','" + new string(os.userID) + "',SYSDATETIME());";
                    cmd.CommandText = query;
                    Console.WriteLine("query : {0}", query);
                    cmd.ExecuteNonQuery();
                }
                return orderID;
            }
            catch (Exception ex)
            {
                Console.Write("Exception(Amend) : " + ex.Message);
            }
            return -1;
        }

        public int cancelOrder(OrderStruct os)//Update the previouss and add new
        {
            try
            {
                int ver = -1;
                //int id = -1;
                int orderID = getNextSeq(orderIDSeq);
                //getLastVersion(os.OrderNo, ref ver, ref id);
                if (ver == 0) { ver = 1; } else { ver++; }
                //Console.WriteLine("DBG: " + os.OrderNo + " : " + ver + " : " + id);
                //os.display();
                //return -1;
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    string symbol = sanitiseField(os.symbol);
                    string query = "INSERT INTO ORDERS (ID,OrderNo,LinkedOrderID,OrderStatus,symbol,price, quantity,direction,version,machineID,userID,insertTS) VALUES ("
                        + orderID + "," + os.OrderNo + "," + os.ID +  "," + "'CANCELED'" + ",'" + symbol + "'," + os.price + "," + os.quantity + ",'" + os.direction + "',"
                        + os.version + ",'" + new string(os.machineID) + "','" + new string(os.userID) + "',SYSDATETIME());";
                    cmd.CommandText = query;
                    Console.WriteLine("query : {0}", query);
                    cmd.ExecuteNonQuery();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception (Cancel) : " + ex.Message);
            }
            return -1;
        }

        
        public int addOrderFills(OrderFillStruct ofs)
        {
            int orderNo = -1;
            int ordStatus = -1;
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    int nextSeq = getNextSeq(FillSeq);
                    orderNo = getOrderNoFromOrderID(ofs.OrderNo);
                    string query = "INSERT INTO FILLS (ID,OrderNo,FillID,Quantity,Price, FilledQuantity, insertTS) VALUES ("
                    + ofs.ID + "," + orderNo + "," + ofs.FillID + "," + ofs.Quantity + "," + ofs.Price + "," + ofs.FilledQuantity + ",SYSDATETIME());";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                if((ordStatus = fillStatus(orderNo)) == 0) // Order completed. Make Insert.
                {
                    insertOrderWithOrdeNO(orderNo);
                }
                return ordStatus;
            }
            catch (Exception ex)
            {
                Console.Write("Exception(addOrderFills) : " + ex.Message);
            }
            return -1;
        }

        private void getOrderStatusFromDB(int OrderID, ref char[] OrderStatus)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select OrderStatus from orders where version = (select max(version) from orders where orderNo = " + OrderID + ") and orderNo = " + OrderID + "; ";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tmp = reader["OrderStatus"];
                            if (tmp != DBNull.Value)
                            {
                                OrderStatus = ((string)tmp).ToCharArray();
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.Write("Exception(getOrderStatusFromDB) : " + ex.Message);
            }
        }

        public int getOrderFromDB(int OrderNo, ref OrderStruct os)
        {
            try
            {
                //TODO: Add the fills from fills tble to struct;
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT ID,OrderNo,OrderStatus,symbol,price, quantity,direction,version,machineID,userID,insertTS FROM ORDERS where version = (select max(version) from orders where orderNo = " + OrderNo + ") and orderNo = " + OrderNo + ";";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tmp = reader["ID"];
                            if (tmp != DBNull.Value) { os.ID = Convert.ToInt32((Int64)tmp); }
                            tmp = reader["OrderNo"];
                            if (tmp != DBNull.Value) { os.OrderNo = Convert.ToInt32((Int64)tmp); }
                            tmp = reader["OrderStatus"];
                            if (tmp != DBNull.Value) { os.OrderStatus = ((string)tmp).ToCharArray(); }
                            tmp = reader["symbol"];
                            if (tmp != DBNull.Value) { os.symbol = ((string)tmp).ToCharArray(); }
                            tmp = reader["price"];
                            if (tmp != DBNull.Value) { os.price = (float)((Decimal)tmp); }
                            tmp = reader["quantity"];
                            if (tmp != DBNull.Value) { os.quantity = (float)((Decimal)tmp); }
                            tmp = reader["direction"];
                            if (tmp != DBNull.Value) { os.direction = ((string)tmp).ToCharArray()[0]; }
                            tmp = reader["version"];
                            if (tmp != DBNull.Value) { os.version = (int)Convert.ToInt32((Int32)tmp); }
                            tmp = reader["machineID"];
                            if (tmp != DBNull.Value) { os.machineID = ((string)tmp).ToCharArray(); }
                            tmp = reader["userID"];
                            if (tmp != DBNull.Value) { os.userID = ((string)tmp).ToCharArray(); }
                        }
                    }
                }
                return 0;
            }catch(Exception e)
            {
                Console.WriteLine("Exception(getOrderStatusFromDB) : " + e.Message +"\n"+ e.StackTrace);
                return -1;
            }
        }
    }
}
