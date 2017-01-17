using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Globalization;

namespace ScannerWindowApplication
{
    public partial class TradingBoxV2 : Form
    {
        string feedkey = null;
        Boolean flag = true;
        Thread th = null;
        Boolean displayFuture = false;
        int futopt = 0;

        public TradingBoxV2(string feedkey)
        {
            InitializeComponent();
            this.feedkey = feedkey;
            
        }

        private void TradingBoxV2_Load(object sender, EventArgs e)
        {
            //var query = "select distinct symbol from LPINTRADAY.dbo.vwFeed where symbol in ('NIFTY','BANKNIFTY','RELIANCE','SBIN','RCOM','AXISBANK','LT','INFY','DLF','SUNPHARMA') order by symbol asc";
            //var ohlcdt = MySqlHelper.Instance.GetDataTable(query);

            //DataRow curRow;

            //for (var i = 0; i < ohlcdt.Rows.Count; i++)
            //{
            //    curRow = ohlcdt.Rows[i];
            //    cmbStocksSymbol.Items.Add(curRow[0].ToString().Trim());
            //    cmbFuturesSymbol.Items.Add(curRow[0].ToString().Trim());
            //    cmbOptionsSymbol.Items.Add(curRow[0].ToString().Trim());
            //}

            var symbolList = ScannerDashboard.dictSecurityMaster.Select(x => x.Value.symbol).Distinct().ToList();
            cmbStocksSymbol.Items.AddRange(symbolList.ToArray());
            cmbFuturesSymbol.Items.AddRange(symbolList.ToArray());
            cmbOptionsSymbol.Items.AddRange(symbolList.ToArray());

            string[] keyarr = feedkey.Split(',');

            // if expiration is null display the Stock tab
            if(keyarr[4] == "NFO")
            {
                futopt = 1;

                String symbol = keyarr[0];
                loadExpiry(symbol, keyarr[4]);

                cmbFuturesSymbol.SelectedItem = symbol;                
                cmbFuturesExpiry.SelectedItem = keyarr[1];
                cmbFuturesType.Text = keyarr[4];                
                cmbFuturesTif.SelectedIndex = 0;
                cmbFuturesVenue.SelectedIndex = 0;
                
                displayFuture = true;
                tabControl1.SelectedIndex = 1;
            }
            else if(keyarr[4] == "NOP")
            {
                futopt = 2;

                String symbol = keyarr[0];
                loadExpiry(symbol, keyarr[4]);

                cmbOptionsSymbol.SelectedItem = symbol;
                cmbOptionsExpiry.SelectedItem = keyarr[1];
                cmbOptionsCallPut.SelectedItem = keyarr[3];

                loadStrike(symbol, keyarr[1], keyarr[3]);
                cmbOptionsStrike.SelectedItem = keyarr[2];                
                cmbOptionsTif.SelectedIndex = 0;
                cmbOptionsDest.SelectedIndex = 0;
                
                displayFuture = true;
                tabControl1.SelectedIndex = 2;
            }

            
            th = new Thread(new ThreadStart(ThreadTrading));
            Console.WriteLine("Threads started :");
            th.Start();
        }

        public void ThreadTrading()
        {
            while (flag)
            {
                try
                {
                    if (displayFuture)
                    {
                        if (Subscriber.dictFeedDetails.ContainsKey(feedkey))
                        {
                            string value = Subscriber.dictFeedDetails[feedkey];
                            string[] feedvalue = value.Split(',');
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                if(futopt == 1)
                                {
                                    double closePrice = Convert.ToDouble(feedvalue[1]);
                                    txtFuturesLast.Text = feedvalue[2];
                                    txtFuturesVolume.Text = feedvalue[3];
                                    txtFuturesOpen.Text = feedvalue[4];
                                    txtFuturesHigh.Text = feedvalue[5];
                                    txtFuturesLow.Text = feedvalue[6];
                                    txtFuturesClose.Text = feedvalue[2];

                                    double change = closePrice - Convert.ToDouble(feedvalue[2]);
                                    txtFuturesChange.Text = Convert.ToString(change);

                                    double ltp = Convert.ToDouble(feedvalue[2]);
                                    double percChange = Math.Round(((ltp - closePrice) / closePrice) * 100, 2);
                                    txtFuturesPercentChange.Text = Convert.ToString(percChange);
                                }
                                else if(futopt == 2)
                                {
                                    double closePrice = Convert.ToDouble(feedvalue[1]);

                                    txtOptionsBidSize.Text = feedvalue[4]; //openRate
                                    txtOptionsBidPrice.Text = feedvalue[5]; //highRate
                                    txtOptionsAskPrice.Text = feedvalue[6]; //lowRate
                                    txtOptionsAskSize.Text = feedvalue[2]; //ltpRate

                                    double change = closePrice - Convert.ToDouble(feedvalue[2]);
                                    txtOptionsChange.Text = Convert.ToString(change);

                                    double ltp = Convert.ToDouble(feedvalue[2]);
                                    double percChange = Math.Round(((ltp - closePrice) / closePrice) * 100, 2);
                                    txtOptionsPercentChange.Text = Convert.ToString(percChange);
                                }
                            });

                            Thread.Sleep(100);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Thread Stopped");
        }

        private void btnStocksBuy_Click(object sender, EventArgs e)
        {
           
        }

        public void displayTextArea(string data)
        {
            richTextBox1.AppendText(data + "\n");
        }


        private void cmbFuturesSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            var symbol = cmbFuturesSymbol.SelectedItem.ToString();

            loadExpiry(symbol, "NFO");
        }

        public void loadExpiry(String symbol, String exch)
        {

            if (exch == "NFO")
            {
                cmbFuturesExpiry.Items.Clear();
                var expiryList = ScannerDashboard.dictSecurityMaster.Where(x => x.Value.symbol == symbol && x.Value.exch == exch).Select(x => x.Value.expiry).Distinct().ToList();
                cmbFuturesExpiry.Items.AddRange(expiryList.ToArray());
            }
            else
            {
                cmbOptionsExpiry.Items.Clear();
                var expiryList = ScannerDashboard.dictSecurityMaster.Where(x => x.Value.symbol == symbol && x.Value.exch == exch).Select(x => x.Value.expiry).Distinct().ToList();
                cmbOptionsExpiry.Items.AddRange(expiryList.ToArray());
            }
            /*
            //var symbol = cmbFuturesSymbol.SelectedItem.ToString();

            var query = "select distinct CONVERT(VARCHAR(10),ExpiryDate,105) expDate from LPINTRADAY.dbo.vwFeed where symbol = '" + symbol + "' and exch = '" + exch  + "'";
            //for NFO no OptType & Strike
            query = query + " order by expDate";

            if(exch == "NFO")
                cmbFuturesExpiry.Items.Clear();
            else if (exch == "NOP")
                cmbOptionsExpiry.Items.Clear();

            var ohlcdt = MySqlHelper.Instance.GetDataTable(query);

            DataRow curRow;

            for (var i = 0; i < ohlcdt.Rows.Count; i++)
            {
                curRow = ohlcdt.Rows[i];
                //MessageBox.Show(curRow[0].ToString().Substring(0, 10));
                //DateTime dt1 = DateTime.ParseExact(curRow[0].ToString().Substring(0, 10), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime dt1 = DateTime.ParseExact(curRow[0].ToString().Substring(0, 10), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (exch == "NFO")
                    cmbFuturesExpiry.Items.Add(dt1.ToString("yyyy-MM-dd"));
                else if (exch == "NOP")
                    cmbOptionsExpiry.Items.Add(dt1.ToString("yyyy-MM-dd"));
            }
            */
        }

        public void loadStrike(String symbol, String Expiry, String opttype)
        {
            cmbOptionsStrike.Items.Clear();
            var strikeList = ScannerDashboard.dictSecurityMaster.Where(x => x.Value.symbol == symbol && x.Value.expiry == Expiry && x.Value.opttype == opttype).Select(x => x.Value.strike).Distinct().ToList();
            cmbOptionsStrike.Items.AddRange(strikeList.ToArray());
            

            /*
            DateTime dt1 = DateTime.ParseExact(Expiry, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var query = "select distinct strikePrice from LPINTRADAY.dbo.vwFeed where symbol = '"
                + symbol + "' and exch = 'NOP'"
                 + " and Series = 'OPTIDX'"
                  + " and ExpiryDate = '" + dt1.ToString("yyyy-MM-dd") + " 00:00:00'"
                   + " and OptType = '" + opttype + "'";

            cmbOptionsStrike.Items.Clear();
            cmbOptionsStrike.Text = "";

            var ohlcdt = MySqlHelper.Instance.GetDataTable(query);

            DataRow curRow;

            for (var i = 0; i < ohlcdt.Rows.Count; i++)
            {
                curRow = ohlcdt.Rows[i];
                cmbOptionsStrike.Items.Add(curRow[0].ToString());
            }
            */
        }

        private void btnFuturesBuy_Click(object sender, EventArgs e)
        {
            string symbol = cmbFuturesSymbol.SelectedItem.ToString();
            
            DateTime oExpiryDate = DateTime.ParseExact(cmbFuturesExpiry.SelectedItem.ToString(), "yyyy-MM-dd", null);
            string expiry = oExpiryDate.ToString("yyyyMMdd");
            
            double price = Convert.ToDouble(txtFuturesLimit.Text);

            int qty = Convert.ToInt32(txtFuturesQty.Text);
            char action = 'B';
            
            OrderClient.insertOrder(symbol,expiry, "","NFO", "0", price, qty, action, this);
        }

        
        private void btnFuturesSell_Click(object sender, EventArgs e)
        {
            string symbol = cmbFuturesSymbol.SelectedItem.ToString();

            DateTime oExpiryDate = DateTime.ParseExact(cmbFuturesExpiry.SelectedItem.ToString(), "yyyy-MM-dd", null);
            string expiry = oExpiryDate.ToString("yyyyMMdd");

            double price = Convert.ToDouble(txtFuturesLimit.Text);
            int qty = Convert.ToInt32(txtFuturesQty.Text);
            char action = 'S';

            OrderClient.insertOrder(symbol, expiry, "", "NFO", "0", price, qty, action, this);
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            string symbol = cmbOptionsSymbol.SelectedItem.ToString();

            DateTime oExpiryDate = DateTime.ParseExact(cmbFuturesExpiry.SelectedItem.ToString(), "dd-MM-yyyy", null);
            string expiry = oExpiryDate.ToString("yyyyMMdd");
            string callput = cmbOptionsCallPut.SelectedItem.ToString();
            string strike = cmbOptionsStrike.SelectedItem.ToString();

            double price = Convert.ToDouble(txtOptionsPrice.Text);
            int qty = Convert.ToInt32(txtOptionsQty.Text);
            char action = 'B';

            OrderClient.insertOrder(symbol, expiry, callput, "NOP", strike, price, qty, action, this);
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            string symbol = cmbOptionsSymbol.SelectedItem.ToString();

            DateTime oExpiryDate = DateTime.ParseExact(cmbFuturesExpiry.SelectedItem.ToString(), "dd-MM-yyyy", null);
            string expiry = oExpiryDate.ToString("yyyyMMdd");
            string callput = cmbOptionsCallPut.SelectedItem.ToString();
            string strike = cmbOptionsStrike.SelectedItem.ToString();

            double price = Convert.ToDouble(txtOptionsPrice.Text);
            int qty = Convert.ToInt32(txtOptionsQty.Text);
            char action = 'S';

            OrderClient.insertOrder(symbol, expiry, callput, "NOP", strike, price, qty, action, this);
        }

        private void cmbFuturesExpiry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string symbol = cmbFuturesSymbol.SelectedItem.ToString();
            string expiry = cmbFuturesExpiry.SelectedItem.ToString();
            string strike = "0";
            string callput = "";
            string exch = "NFO";
            this.feedkey = symbol + "," + expiry + "," + strike + "," + callput + "," + exch;

            futopt = 1;
        }

        private void cmbOptionsCallPut_SelectedIndexChanged(object sender, EventArgs e)
        {
            string symbol = cmbOptionsSymbol.SelectedItem.ToString();
            string expiry = cmbOptionsExpiry.SelectedItem.ToString();            
            string callput = cmbOptionsCallPut.SelectedItem.ToString();

            loadStrike(symbol, expiry, callput);
        }

        private void cmbOptionsStrike_SelectedIndexChanged(object sender, EventArgs e)
        {
            string symbol = cmbOptionsSymbol.SelectedItem.ToString();
            string expiry = cmbOptionsExpiry.SelectedItem.ToString();
            string callput = cmbOptionsCallPut.SelectedItem.ToString();

            if (cmbOptionsStrike.Items.Count > 0)
            {
                string strike = cmbOptionsStrike.SelectedItem.ToString();
                string exch = "NOP";
                this.feedkey = symbol + "," + expiry + "," + strike + "," + callput + "," + exch;
                futopt = 2;
            }
        }

        private void cmbOptionsSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            string symbol = cmbOptionsSymbol.SelectedItem.ToString();
            loadExpiry(symbol, "NOP");
        }

        private void cmbOptionsExpiry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string symbol = cmbOptionsSymbol.SelectedItem.ToString();
            string expiry = cmbOptionsExpiry.SelectedItem.ToString();
            if (cmbOptionsCallPut.SelectedItem != null)
            {
                string callput = cmbOptionsCallPut.SelectedItem.ToString();
                loadStrike(symbol, expiry, callput);
            }
        }

        private void splitContainer1_Panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void splitContainer1_Panel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRowView)) || e.Data.GetDataPresent(typeof(string)))
            {
                // Determine which category the item was draged to                
                {
                    // Get references to the category and campaign
                    string symbol = "";
                    string expiry = "";
                    string strike = "";
                    string callput = "";
                    string exch = "";

                    if (e.Data.GetDataPresent(typeof(DataRowView)))
                    {
                        DataRowView dataRow = (DataRowView)e.Data.GetData(typeof(DataRowView));
                        symbol = (string)dataRow[1];
                        expiry = (string)dataRow[2];
                        strike = (string)dataRow[3];
                        callput = (string)dataRow[4];
                        exch = (string)dataRow[5];
                    }
                    else if(e.Data.GetDataPresent(typeof(string)))
                    {
                        string rowString = (string)e.Data.GetData(typeof(string));
                        string[] dataRow = rowString.Split(',');
                        
                        symbol = (string)dataRow[0];
                        expiry = (string)dataRow[1];
                        strike = (string)dataRow[2];
                        callput = (string)dataRow[3];
                        exch = (string)dataRow[4];
                    }

                    if (exch == "NFO")
                    {
                        cmbFuturesSymbol.SelectedItem = symbol;
                        loadExpiry(symbol, "NFO");
                        cmbFuturesExpiry.SelectedItem = expiry;

                        cmbOptionsStrike.Items.Clear();
                        cmbOptionsCallPut.Items.Clear();
                        cmbOptionsExpiry.Items.Clear();
                        cmbOptionsSymbol.Items.Clear();

                        cmbOptionsStrike.Text = "";
                        cmbOptionsCallPut.Text = "";
                        cmbOptionsExpiry.Text = "";
                        cmbOptionsSymbol.Text = "";

                        txtOptionsChange.Text = "";
                        txtOptionsPercentChange.Text = "";
                        txtOptionsAskSize.Text = "";
                        txtOptionsAskPrice.Text = "";
                        txtOptionsBidPrice.Text = "";
                        txtOptionsBidSize.Text = "";

                        strike = "0";
                        callput = "";
                        exch = "NFO";
                        this.feedkey = symbol + "," + expiry + "," + strike + "," + callput + "," + exch;
                        
                        futopt = 1;
                        tabControl1.SelectedIndex = 1;
                    }
                    else if (exch == "NOP")
                    {
                        cmbFuturesExpiry.Items.Clear();
                        cmbFuturesSymbol.Items.Clear();
                        cmbFuturesExpiry.Text = "";
                        cmbFuturesSymbol.Text = "";

                        txtFuturesChange.Text = "";
                        txtFuturesClose.Text = "";
                        txtFuturesHigh.Text = "";
                        txtFuturesLast.Text = "";
                        txtFuturesLimit.Text = "";
                        txtFuturesLow.Text = "";
                        txtFuturesOpen.Text = "";
                        txtFuturesPercentChange.Text = "";
                        txtFuturesVolume.Text = "";

                        this.feedkey = symbol + "," + expiry + "," + strike + "," + callput + "," + exch;
                        
                        cmbOptionsSymbol.SelectedItem = symbol;
                        cmbOptionsExpiry.SelectedItem = expiry;
                        cmbOptionsCallPut.SelectedItem = callput;

                        if (cmbOptionsStrike.Items.Count > 0)
                        {
                            cmbOptionsStrike.SelectedItem = strike;                            
                            this.feedkey = symbol + "," + expiry + "," + strike + "," + callput + "," + exch;
                            futopt = 2;
                            tabControl1.SelectedIndex = 2;
                        }                        
                    }
                }
            }
        }
             

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            tabControl1.DoDragDrop(feedkey, DragDropEffects.Copy);
        }
    }
}
