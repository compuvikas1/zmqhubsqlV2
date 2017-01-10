using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScannerWindowApplication
{
    public partial class OrderViewer : Form
    {
        public OrderViewer()
        {
            InitializeComponent();
        }

        public void setGridData(string orderNo)
        {
            try
            {
                var query = "select OrderNo , LinkedOrderID,OrderStatus,symbol,price,quantity,direction,[version], machineID,userID from [THOM].[dbo].[orders] where OrderNo = " + orderNo;

                var ohlcdt = MySqlHelper.Instance.GetDataTable(query);
                dataGridView1.DataSource = ohlcdt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
