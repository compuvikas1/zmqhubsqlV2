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

namespace ScannerWindowApplication
{
    public partial class OrderBlotter : Form
    {
        public Boolean flagRefresh = false;
        ScannerDashboard parentSD;

        public OrderBlotter(ScannerDashboard sd)
        {
            InitializeComponent();
            parentSD = sd;

            Thread th = new Thread(new ThreadStart(refreshGridData));
            flagRefresh = true;
            Console.WriteLine("Threads started :");
            th.Start();
        }

        public void refreshGridData()
        {
            while (flagRefresh)
            {
                try
                {
                    //var query = "select OrderId , LinkedOrderID,OrderStatus,symbol,price,quantity,direction,[version], machineID,userID from [THOM].[dbo].[orders]";
                    var query = "select s1.OrderNo , LinkedOrderID,OrderStatus,symbol,price,quantity,direction,[version], machineID,userID from [THOM].[dbo].[orders] s1 inner join(SELECT orderNo, max(insertTS) as mts FROM [THOM].[dbo].[orders] GROUP BY orderNo) s2 on s2.orderNo = s1.orderNo and s1.insertts = s2.mts";

                    var ohlcdt = MySqlHelper.Instance.GetDataTable(query);
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        dataGridView1.DataSource = ohlcdt;
                    });

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Thread.Sleep(5000);
            }            
        }

        private void OrderBlotter_FormClosing(object sender, FormClosingEventArgs e)
        {
            flagRefresh = false;
        }

        OrderViewer orderViewer = null;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                String val = row.Cells["OrderNo"].Value.ToString();
                if (orderViewer == null)
                {
                    orderViewer = new OrderViewer();                    
                }
                orderViewer.setGridData(val);
                orderViewer.Show();
                
            }
        }
    }
}
    