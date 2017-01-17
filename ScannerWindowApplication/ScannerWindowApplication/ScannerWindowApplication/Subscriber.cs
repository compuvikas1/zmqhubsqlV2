using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ScannerWindowApplication
{
    class Subscriber
    {
        public static Dictionary<string, string> dictFeedDetails = new Dictionary<string, string>();
        String publisherIP = "";
        String publisherPort = "";
        ScannerDashboard parentSD;
        public Subscriber(ScannerDashboard sd) { parentSD = sd; }
        public void ThreadB()
        {
            try
            {
                //string topic = args[0] == "All" ? "" : args[0];
                //string topic = "";
                //Console.WriteLine("Subscriber started for Topic : {0}", _topic);

                using (var subSocket = new SubscriberSocket())
                {
                    subSocket.Options.ReceiveHighWatermark = 1000;
                    publisherIP = ConfigurationManager.AppSettings["publisherIP"];
                    publisherPort = ConfigurationManager.AppSettings["publisherPort"];
                    subSocket.Connect("tcp://"+ publisherIP+":" + publisherPort);
                    //subSocket.SubscribeToAnyTopic();
                    if (parentSD.dictFilters.Count == 0)
                    {
                        subSocket.SubscribeToAnyTopic();
                    }
                    else
                    {
                        foreach(var filters in parentSD.dictFilters)
                        {                            
                            //Console.WriteLine("Subscribing Socket for Symbol : " + filters.Key);
                            subSocket.Subscribe(filters.Key);
                        }
                    }

                    //Console.WriteLine("Subscriber socket connecting...");
                    while (true)
                    {
                        try
                        {
                            if (ScannerBox.openedMainForm == false)
                                break;
                            string messageReceived;
                            if (subSocket.TryReceiveFrameString(out messageReceived))
                            {
                                //string messageReceived = subSocket.ReceiveFrameString();
                                string[] arr = messageReceived.Split(',');
                                //SELECT Symbol, feedtime, expiry, OptType, StrikePrice, Exch, PCloseRate, LastRate, TotalQty, Series, MLot, ScripNo, OpenRate, HighRate, LowRate, AvgRate

                                Feed feed = new Feed(arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7], arr[8], arr[9], arr[12], arr[13], arr[14], arr[15]);
                                bool flagSymbolCondition = true;
                                bool flagExpiryCondition = true;
                                bool flagExchCondition = true;
                                bool flagStrikeCondition = true;

                                bool flagClosePriceCondition = true;
                                bool flagLtpCondition = true;
                                bool flagQuantityCondition = true;

                                bool foundKey = false;

                                List<SymbolFilter> listSymbolFilter;
                                if (parentSD.dictFilters.TryGetValue(feed.symbol.Trim(), out listSymbolFilter))
                                {
                                    foreach (var symbolfilter in listSymbolFilter)
                                    {
                                        if (symbolfilter.symbol != null && string.Compare(feed.symbol, symbolfilter.symbol) != 0)
                                            flagSymbolCondition = false;
                                        else
                                            flagSymbolCondition = true;

                                        if (symbolfilter.expiry != null && symbolfilter.expiry != "")
                                        {
                                            // MessageBox.Show(feed.expiry + " not equal " + symbolfilter.expiry);
                                            //Console.WriteLine(feed.expiry + " and " + symbolfilter.expiry);
                                            //DateTime dt1 = DateTime.ParseExact(symbolfilter.expiry, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                                            if (string.Compare(feed.expiry, symbolfilter.expiry) != 0)
                                                flagExpiryCondition = false;
                                            else
                                                flagExpiryCondition = true;
                                        }

                                        if (symbolfilter.exch != null && symbolfilter.exch != "" && string.Compare(feed.exch, symbolfilter.exch) != 0)
                                            flagExchCondition = false;
                                        else
                                            flagExchCondition = true;

                                        if (flagExchCondition == true)
                                        {
                                            if (symbolfilter.strike != null && symbolfilter.strike != "" && string.Compare(feed.strike, symbolfilter.strike) != 0)
                                                flagStrikeCondition = false;
                                            else
                                                flagStrikeCondition = true;
                                        }

                                        double closePrice = Convert.ToDouble(feed.closePrice);
                                        double ltp = Convert.ToDouble(feed.ltp);
                                        int quantity = Convert.ToInt32(feed.quantity);

                                        if (symbolfilter.closePrice != 0 && closePrice < symbolfilter.closePrice)
                                            flagClosePriceCondition = false;
                                        else
                                            flagClosePriceCondition = true;

                                        if (symbolfilter.ltp != 0 && ltp < symbolfilter.ltp)
                                            flagLtpCondition = false;
                                        else
                                            flagLtpCondition = true;

                                        if (symbolfilter.quantity != 0 && quantity < symbolfilter.quantity)
                                            flagQuantityCondition = false;
                                        else
                                            flagQuantityCondition = true;

                                        if (flagSymbolCondition && flagExpiryCondition && flagExchCondition &&
                                            flagStrikeCondition && flagClosePriceCondition &&
                                            flagLtpCondition && flagQuantityCondition)
                                        {
                                            ScannerBox.qfeed.Enqueue(feed);
                                            
                                            string key = feed.symbol + "," + feed.expiry + "," + feed.strike + "," + feed.callput + "," + feed.exch;
                                            string value = feed.feedtime + "," + feed.closePrice + "," + feed.ltp + "," + feed.quantity + "," + feed.openRate + "," + feed.highRate + "," + feed.lowRate;

                                            foundKey = true;
                                            dictFeedDetails[key] = value;
                                        }
                                    }
                                }

                                //check if it needs to be removed from the hashmap and the data table
                                if (foundKey == false)
                                {
                                    var exisiting = ScannerBox.dtFeed.Rows.Find(new Object[] { feed.symbol, feed.expiry, feed.strike, feed.callput, feed.exch });
                                    if (exisiting != null)
                                    {
                                        exisiting.Delete();
                                    }
                                }
                                //Console.WriteLine(messageReceived);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
            finally
            {
                NetMQConfig.Cleanup();
            }
        }
    }
}
