using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace ScannerWindowApplication
{
    public partial class ScannerDashboard : Form
    {
        //string connectionString = @"Data Source=HSTBHSVAMDS\SQLEXPRESS;Initial Catalog=LPIntraDay;Persist Security Info=True;User ID=sa;Password=sa@123";
        //string testString = @"Data Source=.\SQLServerr2;Initial Catalog=LPIntraDay;Persist Security Info=True;User ID=sa;Password=sa123";    
        string connectionString = "";

        public string topics { get; set; }
        //public Dictionary<string, SymbolFilter> dictFilters = new Dictionary<string, SymbolFilter>();
        public Dictionary<string, List<SymbolFilter>> dictFilters = new Dictionary<string, List<SymbolFilter>>();
        public static Dictionary<string, SecurityMaster> dictSecurityMaster = new Dictionary<string, SecurityMaster>();
        
        public void loadSecurityMaster()
        {
            string []lines = File.ReadAllLines(@"C:\s2trading\zmqhubresource\SecurityMaster.csv");
            foreach(string line in lines)
            {
                if (line.Contains("ScripNo")) continue;
                //ScripNo,Exch,series,symbol,opttype,StrikePrice,ExpiryDate,MLot               

                string[] arr = line.Split(',');
                string ScripNo = arr[0];
                string Exch = arr[1];
                string series = arr[2];
                string symbol = arr[3];
                string opttype = arr[4];
                string StrikePrice = arr[5];
                string ExpiryDate = arr[6];
                string MLot = arr[7];

                SecurityMaster data = new SecurityMaster(ScripNo, Exch, series, symbol, opttype, StrikePrice, ExpiryDate, MLot);
                dictSecurityMaster[ScripNo] = data;

                // ScripNo -> Symbol -> Exch -> Series -> Expiry -> OptType -> Strike
                
            }
        }

        public ScannerDashboard()
        {
            //removeing the dependency from the db, so we can run Scanner from any machine
            //connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
            //connectionString = @"Data Source=VPS104139\SQLEXPRESS;Initial Catalog=LPIntraDay;Persist Security Info=True;User ID=sa;Password=sa123";           
            //MySqlHelper.Initialize(connectionString);

            loadSecurityMaster();
                        
            InitializeComponent();
        }

        ScannerConfig config = null;
        ScannerBox scannerBox = null;
        OrderBlotter orderBlotter = null;
        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (config == null || config.Text == "")
            {
                config = new ScannerConfig(this);
                config.MdiParent = this;
                config.Dock = DockStyle.Fill;
                config.Show();
            }
            else if (CheckOpened(config.Text))
            {
                config.WindowState = FormWindowState.Normal;
                config.Dock = DockStyle.Fill;
                config.Show();
                config.Focus();
            }
        }

        private void scannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scannerBox == null || scannerBox.Text == "")
            {
                scannerBox = new ScannerBox(this);                
                scannerBox.MdiParent = this;
                scannerBox.Dock = DockStyle.Fill;
                scannerBox.Show();
            }
            else if (CheckOpened(scannerBox.Text))
            {
                scannerBox.WindowState = FormWindowState.Normal;
                scannerBox.Dock = DockStyle.Fill;
                scannerBox.Show();
                scannerBox.Focus();
            }
        }

        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void orderBlotterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (orderBlotter == null || orderBlotter.Text == "")
            {
                orderBlotter = new OrderBlotter(this);
                orderBlotter.MdiParent = this;
                orderBlotter.Dock = DockStyle.Fill;
                orderBlotter.Show();
            }
            else if (CheckOpened(orderBlotter.Text))
            {
                orderBlotter.WindowState = FormWindowState.Normal;
                orderBlotter.Dock = DockStyle.Fill;
                orderBlotter.Show();
                orderBlotter.Focus();
            }
        }

        private void ScannerDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
