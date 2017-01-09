using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace ScannerWindowApplication
{
    public partial class TradingBox : Form
    {
        string feedkey = null;
        Boolean flag = true;
        Thread th = null;

        public TradingBox(string feedkey)
        {
            InitializeComponent();
            this.feedkey = feedkey;

            //string key = feed.symbol + "," + feed.expiry + "," + feed.strike + "," + feed.callput + "," + feed.exch;

            string[] keyarr = feedkey.Split(',');
            cmbSymbol.Text = keyarr[0];
            cmbExpiration.Text = keyarr[1];
            cmbStrike.Text = keyarr[2];
            cmbCallPut.Text = keyarr[3];
            cmbType.Text = keyarr[4];

            th = new Thread(new ThreadStart(ThreadTrading));
            Console.WriteLine("Threads started :");            
            th.Start();           
        }
        
        public void ThreadTrading()
        {
            while(flag)
            {
                try
                {
                    if (Subscriber.dictFeedDetails.ContainsKey(feedkey))
                    {
                        string value = Subscriber.dictFeedDetails[feedkey];
                        string[] feedvalue = value.Split(',');
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            lblPrice.Text = feedvalue[2];
                            lblQty.Text = feedvalue[3];
                        });

                        Thread.Sleep(100);
                    }
                }
                catch(Exception e)
                {

                }
            }
            Console.WriteLine("Thread Stopped");
        }

        private void TradingBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            flag = false;
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {            
            string symbol = cmbSymbol.Text;
            double price = Convert.ToDouble(txtLimitPrice.Text);
            int qty = Convert.ToInt32(txtQuantity.Text);
            char action = 'B';

            //int length = symbol.Length;
            //for(int ctr = length; ctr <8; ctr++)
            //    symbol = symbol + "#";

            //OrderClient.insertOrder(symbol, price, qty, action, this);
        }

        public void displayTextArea(string data)
        {
            richTextBox1.AppendText(data + "\n");            
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            string symbol = cmbSymbol.Text;
            double price = Convert.ToDouble(txtLimitPrice.Text);
            int qty = Convert.ToInt32(txtQuantity.Text);
            char action = 'S';

            //int length = symbol.Length;
            //for (int ctr = length; ctr < 8; ctr++)
            //    symbol = symbol + "#";

            //OrderClient.insertOrder(symbol, price, qty, action, this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string symbol = cmbSymbol.Text;
            string ordid = txtCancel.Text;

            int length = symbol.Length;
            for (int ctr = length; ctr < 8; ctr++)
                symbol = symbol + "#";

            //OrderClient.cancelOrder(symbol, ordid);
        }
    }
}
