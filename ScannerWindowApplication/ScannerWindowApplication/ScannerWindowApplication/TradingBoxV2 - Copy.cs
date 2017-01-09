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
    public partial class TradingBoxV2 : Form
    {
        public TradingBoxV2()
        {
            InitializeComponent();
        }

        private void TradingBoxV2_Load(object sender, EventArgs e)
        {
            var query = "select distinct symbol from LPINTRADAY.dbo.vwFeed where symbol in ('NIFTY','BANKNIFTY','RELIANCE','SBIN','RCOM','AXISBANK','LT','INFY','DLF','SUNPHARMA') order by symbol asc";
            var ohlcdt = MySqlHelper.Instance.GetDataTable(query);

            DataRow curRow;

            for (var i = 0; i < ohlcdt.Rows.Count; i++)
            {
                curRow = ohlcdt.Rows[i];
                cmbStocksSymbol.Items.Add(curRow[0].ToString().Trim());
                cmbFuturesSymbol.Items.Add(curRow[0].ToString().Trim());
                cmbOptionsSymbol.Items.Add(curRow[0].ToString().Trim());
            }

        }

        private void btnStocksBuy_Click(object sender, EventArgs e)
        {

        }
    }
}
