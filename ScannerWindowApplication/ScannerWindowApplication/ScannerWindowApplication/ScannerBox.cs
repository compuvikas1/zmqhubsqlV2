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
using System.Globalization;

namespace ScannerWindowApplication
{
    public partial class ScannerBox : Form
    {
        public static Queue<Feed> qfeed = new Queue<Feed>();
        public delegate void AddListItem();
        public AddListItem myDelegate;
        private Thread myThread;
        public static Boolean openedMainForm = true;
        ScannerDashboard parentSD;

        public static DataTable dtFeed = new DataTable();        

        public ScannerBox(ScannerDashboard sd)
        {
            InitializeComponent();
            if (dtFeed.Columns.Contains("Time") == false)
            {
                var colTime = dtFeed.Columns.Add("Time");
                var colSymbol = dtFeed.Columns.Add("Symbol");
                var colExpiry = dtFeed.Columns.Add("Expiry");
                var colStrike = dtFeed.Columns.Add("Strike", typeof(int));
                var colPC = dtFeed.Columns.Add("PC");
                var colExch = dtFeed.Columns.Add("Exch");
                var colClosePrice = dtFeed.Columns.Add("ClosePrice", typeof(double));
                var colLTP = dtFeed.Columns.Add("LTP", typeof(double));
                var colQuantity = dtFeed.Columns.Add("Quantity", typeof(int));

                // set primary key constain so we can search for specific rows
                dtFeed.PrimaryKey = new[] { colSymbol, colExpiry, colStrike, colPC, colExch };
            }

            dataGridView1.DataSource = dtFeed;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            parentSD = sd;            
            ScannerBox.openedMainForm = true;
            myDelegate = new AddListItem(AddListItemMethod);

            myThread = new Thread(new ThreadStart(ThreadFunction));
            myThread.Start();
        }

        private void ThreadFunction()
        {
            MyThreadClass myThreadClassObject = new MyThreadClass(this);
            myThreadClassObject.Run();
        }

        public void AddListItemMethod()
        {
            //String myItem;
            if (ScannerBox.qfeed.Count > 0)
            {
                Feed feed = ScannerBox.qfeed.Dequeue();
                try
                {
                    var exisiting = dtFeed.Rows.Find(new Object[] { feed.symbol, feed.expiry, feed.strike, feed.callput, feed.exch });
                    if (exisiting != null)
                        exisiting.ItemArray = new object[] { feed.feedtime, feed.symbol, feed.expiry, feed.strike, feed.callput, feed.exch, feed.closePrice, feed.ltp, feed.quantity };
                    else
                        dtFeed.Rows.Add(new Object[] { feed.feedtime, feed.symbol, feed.expiry, feed.strike, feed.callput, feed.exch, feed.closePrice, feed.ltp, feed.quantity });
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                //int rowIndex = 0;
                //Boolean foundRow = false;

                ////place condition for feedPrice                
                
                //foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
                //{
                //    if (string.Compare(dgvRow.Cells[1].FormattedValue.ToString(),feed.symbol)== 0 &&
                //        string.Compare(dgvRow.Cells[2].Value.ToString(),feed.expiry.Substring(0,10))== 0 &&
                //        string.Compare(dgvRow.Cells[3].Value.ToString(),feed.strike) == 0 &&
                //        string.Compare(dgvRow.Cells[4].Value.ToString(),feed.callput)==0)
                //    {
                //        dgvRow.Cells[0].Value = feed.feedtime.Substring(11, 9);
                //        dgvRow.Cells[2].Value = feed.expiry.Substring(0,10);
                //        dgvRow.Cells[3].Value = feed.strike;
                //        dgvRow.Cells[4].Value = feed.callput;
                //        dgvRow.Cells[5].Value = feed.exch;
                //        dgvRow.Cells[6].Value = round(feed.closePrice, 2);
                //        dgvRow.Cells[7].Value = round(feed.ltp, 2);
                //        dgvRow.Cells[8].Value = feed.quantity;                            
                        
                //        //Console.WriteLine("Existed Row is updated");
                //        foundRow = true;
                //        break;
                //    }
                //    rowIndex++;
                //}
                //if (foundRow == false)
                //{
                //    {
                //        //Console.WriteLine("new Row Added");                        
                //        dataGridView1.Rows.Insert(0, feed.feedtime.Substring(11, 9), feed.symbol, feed.expiry.Substring(0,10),
                //            feed.strike, feed.callput, feed.exch, 
                //             round(feed.closePrice, 2), round(feed.ltp, 2), feed.quantity);
                //    }
                //}
                //dataGridView1.Update();
            }
        }

        private double round(string value, int decNumber)
        {
            double val = Convert.ToDouble(value);
            val = Math.Round(val, decNumber);
            return val;
        }

        private void ScannerBox_Load(object sender, EventArgs e)
        {
            Subscriber sc = new Subscriber(parentSD);
            Thread th = new Thread(new ThreadStart(sc.ThreadB));
            Console.WriteLine("Threads started :");
            // Start thread B
            th.Start();
        }

        private void ScannerBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            openedMainForm = false;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                //do you staff.
                DataGridViewRow row = dgv.CurrentRow;

                DataGridViewCell dgvCell1 = row.Cells[1];
                string symbol = dgvCell1.Value.ToString();

                DataGridViewCell dgvCell2 = row.Cells[2];
                string expiry = dgvCell2.Value.ToString();

                DataGridViewCell dgvCell3 = row.Cells[3];
                string strike = dgvCell3.Value.ToString();

                DataGridViewCell dgvCell4 = row.Cells[4];
                string callput = dgvCell4.Value.ToString();

                DataGridViewCell dgvCell5 = row.Cells[5];
                string exch = dgvCell5.Value.ToString();

                DataGridViewCell dgvCell7 = row.Cells[7];
                string LTP = dgvCell7.Value.ToString();

                DataGridViewCell dgvCell8 = row.Cells[8];
                string quantity = dgvCell8.Value.ToString();

                string feedKey = symbol + "," + expiry + "," + strike + "," + callput + "," + exch;
                TradingBoxV2 box1 = new TradingBoxV2(feedKey);
                box1.Show();
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dataGridView1.HitTest(e.X, e.Y);
                if (info.RowIndex >= 0)
                {
                    DataRowView view = (DataRowView)
                           dataGridView1.Rows[info.RowIndex].DataBoundItem;
                    if (view != null)
                        dataGridView1.DoDragDrop(view, DragDropEffects.Copy);
                }
            }
        }
    }

    public class MyThreadClass
    {
        ScannerBox myFormControl1;

        public MyThreadClass(ScannerBox myForm)
        {
            myFormControl1 = myForm;
        }

        public void Run()
        {
            // Execute the specified delegate on the thread that owns
            // 'myFormControl1' control's underlying window handle.

            while (ScannerBox.openedMainForm)
            {
                try
                {
                    myFormControl1.Invoke(myFormControl1.myDelegate);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
