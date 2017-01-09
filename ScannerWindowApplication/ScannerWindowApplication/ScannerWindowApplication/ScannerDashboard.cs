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

        public ScannerDashboard()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
            connectionString = @"Data Source=VPS104139\SQLEXPRESS;Initial Catalog=LPIntraDay;Persist Security Info=True;User ID=sa;Password=sa123";

            MySqlHelper.Initialize(connectionString);

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
