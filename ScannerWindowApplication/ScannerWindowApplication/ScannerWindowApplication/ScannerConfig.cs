using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace ScannerWindowApplication
{
    public partial class ScannerConfig : Form
    {
        ScannerDashboard parentSD;

        public ScannerConfig(ScannerDashboard sd)
        {
            InitializeComponent();
            parentSD = sd;
        }

        private void ScannerConfig_Load(object sender, EventArgs e)
        {
            try
            {
                //string fileName = "symbols1.txt";

                //var fileLines = File.ReadAllLines(fileName);
                //Array.Sort(fileLines); // alphabetically sorting the symbols

                //foreach (var singleLine in fileLines)
                //{
                //    cmbSymbol.Items.Add(singleLine);
                //}

                //var query = "select distinct symbol from LPINTRADAY.dbo.vwFeed  order by symbol asc";
                var query = "select distinct symbol from LPINTRADAY.dbo.vwFeed where symbol in ('NIFTY','BANKNIFTY','RELIANCE','SBIN','RCOM','AXISBANK','LT','INFY','DLF','SUNPHARMA') order by symbol asc";
                var ohlcdt = MySqlHelper.Instance.GetDataTable(query);

                DataRow curRow;

                for (var i = 0; i < ohlcdt.Rows.Count; i++)
                {
                    curRow = ohlcdt.Rows[i];
                    cmbSymbol.Items.Add(curRow[0].ToString().Trim());
                }

                var filterLines = File.ReadAllLines("filterconfig.txt");

                foreach (var singleLine in filterLines)
                {
                    string[] filterArray = singleLine.Split(',');
                    DataGridViewRow row = new DataGridViewRow();

                    // new symbol, add it in the gridview
                    DataGridViewTextBoxCell cellSymbol = new DataGridViewTextBoxCell();
                    cellSymbol.Value = filterArray[0];
                    row.Cells.Add(cellSymbol);

                    DataGridViewTextBoxCell cellExch = new DataGridViewTextBoxCell();
                    cellExch.Value = filterArray[1];
                    row.Cells.Add(cellExch);

                    DataGridViewTextBoxCell cellSeries = new DataGridViewTextBoxCell();
                    cellSeries.Value = filterArray[2];
                    row.Cells.Add(cellSeries);

                    DataGridViewTextBoxCell cellOptType = new DataGridViewTextBoxCell();
                    cellOptType.Value = filterArray[3];
                    row.Cells.Add(cellOptType);

                    DataGridViewTextBoxCell cellExpiry = new DataGridViewTextBoxCell();
                    cellExpiry.Value = filterArray[4];
                    row.Cells.Add(cellExpiry);

                    DataGridViewTextBoxCell cellStrike = new DataGridViewTextBoxCell();
                    cellStrike.Value = filterArray[5];
                    row.Cells.Add(cellStrike);

                    DataGridViewTextBoxCell cellClosePrice = new DataGridViewTextBoxCell();
                    cellClosePrice.Value = filterArray[6];
                    row.Cells.Add(cellClosePrice);

                    DataGridViewTextBoxCell cellLTP = new DataGridViewTextBoxCell();
                    cellLTP.Value = filterArray[7];
                    row.Cells.Add(cellLTP);

                    DataGridViewTextBoxCell cellQuantity = new DataGridViewTextBoxCell();
                    cellQuantity.Value = filterArray[8];
                    row.Cells.Add(cellQuantity);

                    DataGridViewCheckBoxCell cellApply = new DataGridViewCheckBoxCell();
                    cellApply.Value = filterArray[9];
                    row.Cells.Add(cellApply);

                    filterGridView.Rows.Add(row);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbSymbol.SelectedItem != null)
            {
                var symbol = cmbSymbol.SelectedItem;
                var exch = cmbExch.SelectedItem;
                var series = cmbSymbolType.SelectedItem;
                var opttype = cmbOptType.SelectedItem;
                var expiry = cmbExpiry.SelectedItem;
                var strike = cmbStrike.SelectedItem;

                Boolean symbolExists = false;
                foreach (DataGridViewRow row in filterGridView.Rows)
                {
                    //((DataGridViewCheckBoxCell)row.Cells[0]).Value = true;
                    var symbolCell = ((DataGridViewTextBoxCell)row.Cells[0]).Value;
                    var exchCell = ((DataGridViewTextBoxCell)row.Cells[1]).Value;
                    var seriesCell = ((DataGridViewTextBoxCell)row.Cells[2]).Value;
                    var opttypeCell = ((DataGridViewTextBoxCell)row.Cells[3]).Value;
                    var expiryCell = ((DataGridViewTextBoxCell)row.Cells[4]).Value;
                    var strikeCell = ((DataGridViewTextBoxCell)row.Cells[5]).Value;

                    if (symbol == symbolCell && exch == exchCell && series == seriesCell
                        && opttype == opttypeCell && expiry == expiryCell && strike == strikeCell)
                    {
                        symbolExists = true;
                        break;
                    }
                }

                if (symbolExists)
                {
                    // symbol already exists in the gridview, cannot add twice
                    MessageBox.Show("Symbol Already exists in Table");
                }
                else
                {
                    DataGridViewRow row = new DataGridViewRow();

                    //validate SpreadPrice and volume to be integer and non negative number's
                    double closePrice;
                    try
                    {
                        // if spreadprice is left blank then we assign zero to it
                        if (txtClosePrice.Text.Trim().Length == 0)
                            closePrice = 0;
                        else
                            closePrice = Convert.ToDouble(txtClosePrice.Text.Trim());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please enter valid ClosePrice (decimal numbers) ");
                        return;
                    }

                    double ltp;
                    try
                    {
                        // if volume is left blank then we assign zero to it
                        if (txtLtp.Text.Trim().Length == 0)
                            ltp = 0;
                        else
                            ltp = Convert.ToDouble(txtLtp.Text.Trim());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please enter valid LTP (numbers) ");
                        return;
                    }

                    int Quantity;
                    try
                    {
                        // if bidsize is left blank then we assign zero to it
                        if (txtQuantity.Text.Trim().Length == 0)
                            Quantity = 0;
                        else
                            Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Please enter valid Quantity (numbers) ");
                        return;
                    }

                    // new symbol, add it in the gridview

                    DataGridViewTextBoxCell cellSymbol = new DataGridViewTextBoxCell();
                    row.Cells.Add(cellSymbol);
                    cellSymbol.Value = symbol;

                    DataGridViewTextBoxCell cellExch = new DataGridViewTextBoxCell();
                    row.Cells.Add(cellExch);
                    cellExch.Value = cmbExch.SelectedItem;

                    DataGridViewTextBoxCell cellSeries = new DataGridViewTextBoxCell();
                    row.Cells.Add(cellSeries);
                    cellSeries.Value = cmbSymbolType.SelectedItem;

                    DataGridViewTextBoxCell cellOptType = new DataGridViewTextBoxCell();
                    row.Cells.Add(cellOptType);
                    cellOptType.Value = cmbOptType.SelectedItem;

                    DataGridViewTextBoxCell cellExpiry = new DataGridViewTextBoxCell();
                    row.Cells.Add(cellExpiry);
                    cellExpiry.Value = cmbExpiry.SelectedItem;
                                        
                    DataGridViewTextBoxCell cellStrike = new DataGridViewTextBoxCell();
                    row.Cells.Add(cellStrike);
                    cellStrike.Value = cmbStrike.SelectedItem;

                    DataGridViewTextBoxCell cellClosePrice = new DataGridViewTextBoxCell();
                    cellClosePrice.Value = closePrice;
                    row.Cells.Add(cellClosePrice);

                    DataGridViewTextBoxCell cellLtp = new DataGridViewTextBoxCell();
                    cellLtp.Value = ltp;
                    row.Cells.Add(cellLtp);

                    DataGridViewTextBoxCell cellQuantity = new DataGridViewTextBoxCell();
                    cellQuantity.Value = Quantity;
                    row.Cells.Add(cellQuantity);

                    DataGridViewCheckBoxCell cellApply = new DataGridViewCheckBoxCell();
                    cellApply.Value = chkApply.Checked;
                    row.Cells.Add(cellApply);

                    filterGridView.Rows.Add(row);

                    MessageBox.Show(symbol + " - Added Successfully");
                }
            }
        }

        private void btnSaveFilter_Click(object sender, EventArgs e)
        {
            // save all the setting in filterconfig.txt

            File.Delete("filterconfig.txt");
            parentSD.dictFilters.Clear();
            ScannerBox.qfeed.Clear();
            ScannerBox.dtFeed.Clear();

            foreach (DataGridViewRow row in filterGridView.Rows)
            {
                //((DataGridViewCheckBoxCell)row.Cells[0]).Value = true;
                string symbol = ((DataGridViewTextBoxCell)row.Cells[0]).Value.ToString();
                var exch = ((DataGridViewTextBoxCell)row.Cells[1]).Value;
                var series = ((DataGridViewTextBoxCell)row.Cells[2]).Value;                
                var opttype = ((DataGridViewTextBoxCell)row.Cells[3]).Value;
                var expiry = ((DataGridViewTextBoxCell)row.Cells[4]).Value;
                var strike = ((DataGridViewTextBoxCell)row.Cells[5]).Value;

                string closePrice = ((DataGridViewTextBoxCell)row.Cells[6]).Value.ToString();
                string ltp = ((DataGridViewTextBoxCell)row.Cells[7]).Value.ToString();
                string quantity = ((DataGridViewTextBoxCell)row.Cells[8]).Value.ToString();
                string apply = ((DataGridViewCheckBoxCell)row.Cells[9]).Value.ToString();

                string line = symbol + "," + exch + "," + series + "," + opttype + "," 
                    + expiry  + "," + strike + "," + closePrice + "," + ltp + "," + quantity + "," + apply + "\n";

                File.AppendAllText("filterconfig.txt", line);

                //Add this filter in the dictionary
                bool applyFlag = Convert.ToBoolean(apply);
                if (applyFlag == true)
                {
                    SymbolFilter symFilter = new SymbolFilter();

                    symFilter.symbol = symbol == null ? null : symbol.ToString();
                    symFilter.exch = exch == null ? null : exch.ToString();
                    symFilter.series = series == null ? null : series.ToString();
                    symFilter.expiry = expiry == null ? null : expiry.ToString();
                    symFilter.opttype = opttype == null ? null : opttype.ToString();
                    symFilter.strike = strike == null ? null : strike.ToString();

                    symFilter.closePrice = Convert.ToDouble(closePrice);
                    symFilter.ltp = Convert.ToDouble(ltp);
                    symFilter.quantity = Convert.ToInt32(quantity);

                    if(parentSD.dictFilters.ContainsKey(symbol) == false)
                        parentSD.dictFilters.Add(symbol, new List<SymbolFilter>());

                    parentSD.dictFilters[symbol].Add(symFilter);                    
                }
                //else
                //{
                //    if (parentSD.dictFilters.ContainsKey(symbol))
                //        parentSD.dictFilters.Remove(symbol);
                //}
            }


            MessageBox.Show("Filter's Saved");


        }

        private void cmbExch_SelectedIndexChanged(object sender, EventArgs e)
        {
            var symbol = cmbSymbol.SelectedItem.ToString();
            var exch = cmbExch.SelectedItem.ToString();            

            var query = "select distinct series from LPINTRADAY.dbo.vwFeed where symbol = '" + symbol + "' and exch = '" + cmbExch.SelectedItem + "'";

            cmbSymbolType.Items.Clear();
            cmbExpiry.Items.Clear();
            cmbOptType.Items.Clear();
            cmbStrike.Items.Clear();

            cmbSymbolType.Text = "";
            cmbExpiry.Text = "";
            cmbOptType.Text = "";
            cmbStrike.Text = "";

            var ohlcdt = MySqlHelper.Instance.GetDataTable(query);

            DataRow curRow;

            for (var i = 0; i < ohlcdt.Rows.Count; i++)
            {
                curRow = ohlcdt.Rows[i];
                cmbSymbolType.Items.Add(curRow[0].ToString().Trim());
            }
        }

        private void cmbSymbolType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var symbol = cmbSymbol.SelectedItem.ToString();
            var query = "select distinct CONVERT(VARCHAR(10),ExpiryDate,105) expDate from LPINTRADAY.dbo.vwFeed where symbol = '" + symbol + "' and exch = '" + cmbExch.SelectedItem +"'";
            //for NFO no OptType & Strike
            if (cmbExch.SelectedItem.ToString() == "NOP")
            {                
                if(cmbSymbolType.SelectedItem != null)
                    query = query + " and series = '" + cmbSymbolType.SelectedItem + "'";
            }

            query = query + " order by expDate";

            cmbExpiry.Items.Clear();

            var ohlcdt = MySqlHelper.Instance.GetDataTable(query);

            DataRow curRow;

            for (var i = 0; i < ohlcdt.Rows.Count; i++)
            {
                curRow = ohlcdt.Rows[i];
                //MessageBox.Show(curRow[0].ToString().Substring(0, 10));
                //DateTime dt1 = DateTime.ParseExact(curRow[0].ToString().Substring(0, 10), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime dt1 = DateTime.ParseExact(curRow[0].ToString().Substring(0, 10), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                cmbExpiry.Items.Add(dt1.ToString("yyyy-MM-dd"));
            }
        }

        private void cmbExpiry_SelectedIndexChanged(object sender, EventArgs e)
        {
            var symbol = cmbSymbol.SelectedItem.ToString();
            var exch = cmbExch.SelectedItem.ToString();
            if (exch != "NFO")
            {
                var series = cmbSymbolType.SelectedItem.ToString();
                var expiry = cmbExpiry.SelectedItem.ToString();

                DateTime dt1 = DateTime.ParseExact(expiry, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                var query = "select distinct OptType from LPINTRADAY.dbo.vwFeed where symbol = '"
                    + symbol + "' and exch = '" + cmbExch.SelectedItem + "'"
                     + " and Series = '" + series.Trim() + "'"
                      + " and ExpiryDate = '" + dt1.ToString("yyyy-MM-dd") + " 00:00:00'";

                cmbOptType.Items.Clear();

                var ohlcdt = MySqlHelper.Instance.GetDataTable(query);

                DataRow curRow;

                for (var i = 0; i < ohlcdt.Rows.Count; i++)
                {
                    curRow = ohlcdt.Rows[i];
                    cmbOptType.Items.Add(curRow[0].ToString());
                }
            }
        }

        private void cmbOptType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var symbol = cmbSymbol.SelectedItem.ToString();
            var exch = cmbExch.SelectedItem.ToString();
            var series = cmbSymbolType.SelectedItem.ToString();
            var expiry = cmbExpiry.SelectedItem.ToString();
            var opttype = cmbOptType.SelectedItem.ToString();

            DateTime dt1 = DateTime.ParseExact(expiry, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var query = "select distinct strikePrice from LPINTRADAY.dbo.vwFeed where symbol = '" 
                + symbol + "' and exch = '" + cmbExch.SelectedItem + "'"
                 + " and Series = '" + series + "'"
                  + " and ExpiryDate = '" + dt1.ToString("yyyy-MM-dd") + " 00:00:00'"
                   + " and OptType = '" + opttype + "'";

            cmbStrike.Items.Clear();
            cmbStrike.Text = "";

            var ohlcdt = MySqlHelper.Instance.GetDataTable(query);

            DataRow curRow;

            for (var i = 0; i < ohlcdt.Rows.Count; i++)
            {
                curRow = ohlcdt.Rows[i];
                cmbStrike.Items.Add(curRow[0].ToString());
            }
        }

        
    }
}
