using System;
using System.Windows.Forms;

namespace ScannerWindowApplication
{
    partial class TradingBoxV2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageStock = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnStocksCancel = new System.Windows.Forms.Button();
            this.btnStocksShort = new System.Windows.Forms.Button();
            this.btnStocksSell = new System.Windows.Forms.Button();
            this.btnStocksBuy = new System.Windows.Forms.Button();
            this.cmbStocksTif = new System.Windows.Forms.ComboBox();
            this.cmbStocksType = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbStocksVenue = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtStocksLimit = new System.Windows.Forms.TextBox();
            this.txtStocksQty = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtStocksSpread = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtStocksLow = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStocksClose = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStocksVolume = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStocksRatio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStocksHigh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStocksOpen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStocksLast = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStocksPercentChange = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStocksChange = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStocksSymbol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvStocksPrices = new System.Windows.Forms.DataGridView();
            this.BidExchange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BidSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BidPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AskExch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AskSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AskPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStocksTrades = new System.Windows.Forms.DataGridView();
            this.OrderPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageFuture = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cmbFuturesExpiry = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.btnFuturesCancel = new System.Windows.Forms.Button();
            this.btnFuturesShort = new System.Windows.Forms.Button();
            this.btnFuturesSell = new System.Windows.Forms.Button();
            this.btnFuturesBuy = new System.Windows.Forms.Button();
            this.cmbFuturesTif = new System.Windows.Forms.ComboBox();
            this.cmbFuturesType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFuturesVenue = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtFuturesLimit = new System.Windows.Forms.TextBox();
            this.txtFuturesQty = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtFuturesSpread = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtFuturesLow = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtFuturesClose = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtFuturesVolume = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtFuturesRatio = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtFuturesHigh = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtFuturesOpen = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtFuturesLast = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtFuturesPercentChange = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtFuturesChange = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbFuturesSymbol = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dgvFuturesPrices = new System.Windows.Forms.DataGridView();
            this.BidExch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FutureBidPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FutureBidSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FutureAskExch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FutureAskPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FutureAskSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFuturesTrade = new System.Windows.Forms.DataGridView();
            this.FutureOrdPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FutureOrdSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FutureOrdTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageOption = new System.Windows.Forms.TabPage();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.txtOptionsDisplayQty = new System.Windows.Forms.TextBox();
            this.btnOptionsSell = new System.Windows.Forms.Button();
            this.txtOptionsPrice = new System.Windows.Forms.TextBox();
            this.txtOptionsQty = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.btnOptionsBuy = new System.Windows.Forms.Button();
            this.cmbOptionsDest = new System.Windows.Forms.ComboBox();
            this.cmbOptionsAccount = new System.Windows.Forms.ComboBox();
            this.cmbOptionsTif = new System.Windows.Forms.ComboBox();
            this.cmbOptionsOC = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtOptionsAskSize = new System.Windows.Forms.TextBox();
            this.txtOptionsAskPrice = new System.Windows.Forms.TextBox();
            this.txtOptionsBidPrice = new System.Windows.Forms.TextBox();
            this.txtOptionsBidSize = new System.Windows.Forms.TextBox();
            this.txtOptionsPercentChange = new System.Windows.Forms.TextBox();
            this.txtOptionsChange = new System.Windows.Forms.TextBox();
            this.cmbOptionsCallPut = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.cmbOptionsStrike = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.cmbOptionsExpiry = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.cmbOptionsSymbol = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPageStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocksPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocksTrades)).BeginInit();
            this.tabPageFuture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuturesPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuturesTrade)).BeginInit();
            this.tabPageOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Controls.Add(this.tabPageStock);
            this.tabControl1.Controls.Add(this.tabPageFuture);
            this.tabControl1.Controls.Add(this.tabPageOption);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(778, 508);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            // 
            // tabPageStock
            // 
            this.tabPageStock.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageStock.Controls.Add(this.splitContainer1);
            this.tabPageStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageStock.Location = new System.Drawing.Point(4, 24);
            this.tabPageStock.Name = "tabPageStock";
            this.tabPageStock.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStock.Size = new System.Drawing.Size(770, 480);
            this.tabPageStock.TabIndex = 0;
            this.tabPageStock.Text = "Stocks";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AllowDrop = true;
            this.splitContainer1.Panel1.Controls.Add(this.btnStocksCancel);
            this.splitContainer1.Panel1.Controls.Add(this.btnStocksShort);
            this.splitContainer1.Panel1.Controls.Add(this.btnStocksSell);
            this.splitContainer1.Panel1.Controls.Add(this.btnStocksBuy);
            this.splitContainer1.Panel1.Controls.Add(this.cmbStocksTif);
            this.splitContainer1.Panel1.Controls.Add(this.cmbStocksType);
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.cmbStocksVenue);
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.txtStocksLimit);
            this.splitContainer1.Panel1.Controls.Add(this.txtStocksQty);
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.txtStocksSpread);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.txtStocksLow);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.txtStocksClose);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.txtStocksVolume);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.txtStocksRatio);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.txtStocksHigh);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.txtStocksOpen);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtStocksLast);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txtStocksPercentChange);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtStocksChange);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.cmbStocksSymbol);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel1_DragDrop);
            this.splitContainer1.Panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel1_DragEnter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(764, 474);
            this.splitContainer1.SplitterDistance = 254;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnStocksCancel
            // 
            this.btnStocksCancel.Location = new System.Drawing.Point(452, 133);
            this.btnStocksCancel.Name = "btnStocksCancel";
            this.btnStocksCancel.Size = new System.Drawing.Size(63, 23);
            this.btnStocksCancel.TabIndex = 69;
            this.btnStocksCancel.Text = "Cancel";
            this.btnStocksCancel.UseVisualStyleBackColor = true;
            // 
            // btnStocksShort
            // 
            this.btnStocksShort.Location = new System.Drawing.Point(383, 134);
            this.btnStocksShort.Name = "btnStocksShort";
            this.btnStocksShort.Size = new System.Drawing.Size(63, 23);
            this.btnStocksShort.TabIndex = 68;
            this.btnStocksShort.Text = "Short";
            this.btnStocksShort.UseVisualStyleBackColor = true;
            // 
            // btnStocksSell
            // 
            this.btnStocksSell.Location = new System.Drawing.Point(452, 101);
            this.btnStocksSell.Name = "btnStocksSell";
            this.btnStocksSell.Size = new System.Drawing.Size(63, 23);
            this.btnStocksSell.TabIndex = 67;
            this.btnStocksSell.Text = "Sell";
            this.btnStocksSell.UseVisualStyleBackColor = true;
            // 
            // btnStocksBuy
            // 
            this.btnStocksBuy.Location = new System.Drawing.Point(383, 101);
            this.btnStocksBuy.Name = "btnStocksBuy";
            this.btnStocksBuy.Size = new System.Drawing.Size(63, 23);
            this.btnStocksBuy.TabIndex = 66;
            this.btnStocksBuy.Text = "Buy";
            this.btnStocksBuy.UseVisualStyleBackColor = true;
            this.btnStocksBuy.Click += new System.EventHandler(this.btnStocksBuy_Click);
            // 
            // cmbStocksTif
            // 
            this.cmbStocksTif.FormattingEnabled = true;
            this.cmbStocksTif.Items.AddRange(new object[] {
            "DAY",
            "GTC",
            "OPG",
            "IOC",
            "GTD",
            "DTC"});
            this.cmbStocksTif.Location = new System.Drawing.Point(306, 134);
            this.cmbStocksTif.Name = "cmbStocksTif";
            this.cmbStocksTif.Size = new System.Drawing.Size(47, 21);
            this.cmbStocksTif.TabIndex = 65;
            // 
            // cmbStocksType
            // 
            this.cmbStocksType.FormattingEnabled = true;
            this.cmbStocksType.Location = new System.Drawing.Point(232, 132);
            this.cmbStocksType.Name = "cmbStocksType";
            this.cmbStocksType.Size = new System.Drawing.Size(61, 21);
            this.cmbStocksType.TabIndex = 64;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(177, 133);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 63;
            this.label16.Text = "Type";
            // 
            // cmbStocksVenue
            // 
            this.cmbStocksVenue.FormattingEnabled = true;
            this.cmbStocksVenue.Items.AddRange(new object[] {
            "NSE"});
            this.cmbStocksVenue.Location = new System.Drawing.Point(232, 101);
            this.cmbStocksVenue.Name = "cmbStocksVenue";
            this.cmbStocksVenue.Size = new System.Drawing.Size(121, 21);
            this.cmbStocksVenue.TabIndex = 62;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(177, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 61;
            this.label15.Text = "Venue";
            // 
            // txtStocksLimit
            // 
            this.txtStocksLimit.Location = new System.Drawing.Point(52, 125);
            this.txtStocksLimit.Name = "txtStocksLimit";
            this.txtStocksLimit.Size = new System.Drawing.Size(100, 20);
            this.txtStocksLimit.TabIndex = 60;
            // 
            // txtStocksQty
            // 
            this.txtStocksQty.Location = new System.Drawing.Point(51, 92);
            this.txtStocksQty.Name = "txtStocksQty";
            this.txtStocksQty.Size = new System.Drawing.Size(100, 20);
            this.txtStocksQty.TabIndex = 59;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 58;
            this.label14.Text = "Limit";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "Qty";
            // 
            // txtStocksSpread
            // 
            this.txtStocksSpread.Location = new System.Drawing.Point(475, 70);
            this.txtStocksSpread.Name = "txtStocksSpread";
            this.txtStocksSpread.Size = new System.Drawing.Size(56, 20);
            this.txtStocksSpread.TabIndex = 56;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(419, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 55;
            this.label12.Text = "Spread";
            // 
            // txtStocksLow
            // 
            this.txtStocksLow.Location = new System.Drawing.Point(345, 66);
            this.txtStocksLow.Name = "txtStocksLow";
            this.txtStocksLow.Size = new System.Drawing.Size(56, 20);
            this.txtStocksLow.TabIndex = 54;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(305, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 53;
            this.label11.Text = "Low";
            // 
            // txtStocksClose
            // 
            this.txtStocksClose.Location = new System.Drawing.Point(229, 66);
            this.txtStocksClose.Name = "txtStocksClose";
            this.txtStocksClose.Size = new System.Drawing.Size(56, 20);
            this.txtStocksClose.TabIndex = 52;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(177, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Close";
            // 
            // txtStocksVolume
            // 
            this.txtStocksVolume.Location = new System.Drawing.Point(51, 66);
            this.txtStocksVolume.Name = "txtStocksVolume";
            this.txtStocksVolume.Size = new System.Drawing.Size(111, 20);
            this.txtStocksVolume.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Vol";
            // 
            // txtStocksRatio
            // 
            this.txtStocksRatio.Location = new System.Drawing.Point(475, 44);
            this.txtStocksRatio.Name = "txtStocksRatio";
            this.txtStocksRatio.Size = new System.Drawing.Size(56, 20);
            this.txtStocksRatio.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(419, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Ratio";
            // 
            // txtStocksHigh
            // 
            this.txtStocksHigh.Location = new System.Drawing.Point(345, 43);
            this.txtStocksHigh.Name = "txtStocksHigh";
            this.txtStocksHigh.Size = new System.Drawing.Size(56, 20);
            this.txtStocksHigh.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(305, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Hi";
            // 
            // txtStocksOpen
            // 
            this.txtStocksOpen.Location = new System.Drawing.Point(229, 43);
            this.txtStocksOpen.Name = "txtStocksOpen";
            this.txtStocksOpen.Size = new System.Drawing.Size(56, 20);
            this.txtStocksOpen.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Open";
            // 
            // txtStocksLast
            // 
            this.txtStocksLast.Location = new System.Drawing.Point(51, 40);
            this.txtStocksLast.Name = "txtStocksLast";
            this.txtStocksLast.Size = new System.Drawing.Size(56, 20);
            this.txtStocksLast.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Last";
            // 
            // txtStocksPercentChange
            // 
            this.txtStocksPercentChange.Location = new System.Drawing.Point(462, 14);
            this.txtStocksPercentChange.Name = "txtStocksPercentChange";
            this.txtStocksPercentChange.Size = new System.Drawing.Size(56, 20);
            this.txtStocksPercentChange.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "% Chg";
            // 
            // txtStocksChange
            // 
            this.txtStocksChange.Location = new System.Drawing.Point(283, 14);
            this.txtStocksChange.Name = "txtStocksChange";
            this.txtStocksChange.Size = new System.Drawing.Size(56, 20);
            this.txtStocksChange.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Chg";
            // 
            // cmbStocksSymbol
            // 
            this.cmbStocksSymbol.DropDownHeight = 110;
            this.cmbStocksSymbol.FormattingEnabled = true;
            this.cmbStocksSymbol.IntegralHeight = false;
            this.cmbStocksSymbol.ItemHeight = 13;
            this.cmbStocksSymbol.Location = new System.Drawing.Point(51, 13);
            this.cmbStocksSymbol.Name = "cmbStocksSymbol";
            this.cmbStocksSymbol.Size = new System.Drawing.Size(111, 21);
            this.cmbStocksSymbol.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Sym";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvStocksPrices);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvStocksTrades);
            this.splitContainer2.Size = new System.Drawing.Size(764, 216);
            this.splitContainer2.SplitterDistance = 443;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvStocksPrices
            // 
            this.dgvStocksPrices.AllowUserToAddRows = false;
            this.dgvStocksPrices.AllowUserToDeleteRows = false;
            this.dgvStocksPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStocksPrices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BidExchange,
            this.BidSize,
            this.BidPrice,
            this.AskExch,
            this.AskSize,
            this.AskPrice});
            this.dgvStocksPrices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStocksPrices.Location = new System.Drawing.Point(0, 0);
            this.dgvStocksPrices.Name = "dgvStocksPrices";
            this.dgvStocksPrices.ReadOnly = true;
            this.dgvStocksPrices.Size = new System.Drawing.Size(443, 216);
            this.dgvStocksPrices.TabIndex = 0;
            // 
            // BidExchange
            // 
            this.BidExchange.HeaderText = "Exch";
            this.BidExchange.Name = "BidExchange";
            this.BidExchange.ReadOnly = true;
            this.BidExchange.Width = 50;
            // 
            // BidSize
            // 
            this.BidSize.HeaderText = "Size";
            this.BidSize.Name = "BidSize";
            this.BidSize.ReadOnly = true;
            this.BidSize.Width = 75;
            // 
            // BidPrice
            // 
            this.BidPrice.HeaderText = "Price";
            this.BidPrice.Name = "BidPrice";
            this.BidPrice.ReadOnly = true;
            this.BidPrice.Width = 75;
            // 
            // AskExch
            // 
            this.AskExch.HeaderText = "Exch";
            this.AskExch.Name = "AskExch";
            this.AskExch.ReadOnly = true;
            this.AskExch.Width = 50;
            // 
            // AskSize
            // 
            this.AskSize.HeaderText = "Size";
            this.AskSize.Name = "AskSize";
            this.AskSize.ReadOnly = true;
            this.AskSize.Width = 75;
            // 
            // AskPrice
            // 
            this.AskPrice.HeaderText = "Price";
            this.AskPrice.Name = "AskPrice";
            this.AskPrice.ReadOnly = true;
            this.AskPrice.Width = 75;
            // 
            // dgvStocksTrades
            // 
            this.dgvStocksTrades.AllowUserToAddRows = false;
            this.dgvStocksTrades.AllowUserToDeleteRows = false;
            this.dgvStocksTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStocksTrades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderPrice,
            this.OrderSize,
            this.OrderTime});
            this.dgvStocksTrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStocksTrades.Location = new System.Drawing.Point(0, 0);
            this.dgvStocksTrades.Name = "dgvStocksTrades";
            this.dgvStocksTrades.Size = new System.Drawing.Size(317, 216);
            this.dgvStocksTrades.TabIndex = 0;
            // 
            // OrderPrice
            // 
            this.OrderPrice.HeaderText = "Ord Price";
            this.OrderPrice.Name = "OrderPrice";
            // 
            // OrderSize
            // 
            this.OrderSize.HeaderText = "Ord Size";
            this.OrderSize.Name = "OrderSize";
            // 
            // OrderTime
            // 
            this.OrderTime.HeaderText = "Ord Time";
            this.OrderTime.Name = "OrderTime";
            // 
            // tabPageFuture
            // 
            this.tabPageFuture.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageFuture.Controls.Add(this.splitContainer3);
            this.tabPageFuture.Location = new System.Drawing.Point(4, 24);
            this.tabPageFuture.Name = "tabPageFuture";
            this.tabPageFuture.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFuture.Size = new System.Drawing.Size(770, 480);
            this.tabPageFuture.TabIndex = 1;
            this.tabPageFuture.Text = "Futures";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.AllowDrop = true;
            this.splitContainer3.Panel1.Controls.Add(this.richTextBox1);
            this.splitContainer3.Panel1.Controls.Add(this.cmbFuturesExpiry);
            this.splitContainer3.Panel1.Controls.Add(this.label31);
            this.splitContainer3.Panel1.Controls.Add(this.btnFuturesCancel);
            this.splitContainer3.Panel1.Controls.Add(this.btnFuturesShort);
            this.splitContainer3.Panel1.Controls.Add(this.btnFuturesSell);
            this.splitContainer3.Panel1.Controls.Add(this.btnFuturesBuy);
            this.splitContainer3.Panel1.Controls.Add(this.cmbFuturesTif);
            this.splitContainer3.Panel1.Controls.Add(this.cmbFuturesType);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.cmbFuturesVenue);
            this.splitContainer3.Panel1.Controls.Add(this.label17);
            this.splitContainer3.Panel1.Controls.Add(this.txtFuturesLimit);
            this.splitContainer3.Panel1.Controls.Add(this.txtFuturesQty);
            this.splitContainer3.Panel1.Controls.Add(this.label18);
            this.splitContainer3.Panel1.Controls.Add(this.label19);
            this.splitContainer3.Panel1.Controls.Add(this.txtFuturesSpread);
            this.splitContainer3.Panel1.Controls.Add(this.label20);
            this.splitContainer3.Panel1.Controls.Add(this.txtFuturesLow);
            this.splitContainer3.Panel1.Controls.Add(this.label21);
            this.splitContainer3.Panel1.Controls.Add(this.txtFuturesClose);
            this.splitContainer3.Panel1.Controls.Add(this.label22);
            this.splitContainer3.Panel1.Controls.Add(this.txtFuturesVolume);
            this.splitContainer3.Panel1.Controls.Add(this.label23);
            this.splitContainer3.Panel1.Controls.Add(this.txtFuturesRatio);
            this.splitContainer3.Panel1.Controls.Add(this.label24);
            this.splitContainer3.Panel1.Controls.Add(this.txtFuturesHigh);
            this.splitContainer3.Panel1.Controls.Add(this.label25);
            this.splitContainer3.Panel1.Controls.Add(this.txtFuturesOpen);
            this.splitContainer3.Panel1.Controls.Add(this.label26);
            this.splitContainer3.Panel1.Controls.Add(this.txtFuturesLast);
            this.splitContainer3.Panel1.Controls.Add(this.label27);
            this.splitContainer3.Panel1.Controls.Add(this.txtFuturesPercentChange);
            this.splitContainer3.Panel1.Controls.Add(this.label28);
            this.splitContainer3.Panel1.Controls.Add(this.txtFuturesChange);
            this.splitContainer3.Panel1.Controls.Add(this.label29);
            this.splitContainer3.Panel1.Controls.Add(this.cmbFuturesSymbol);
            this.splitContainer3.Panel1.Controls.Add(this.label30);
            this.splitContainer3.Panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel1_DragDrop);
            this.splitContainer3.Panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel1_DragEnter);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(764, 474);
            this.splitContainer3.SplitterDistance = 184;
            this.splitContainer3.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(153, 205);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(511, 96);
            this.richTextBox1.TabIndex = 107;
            this.richTextBox1.Text = "";
            // 
            // cmbFuturesExpiry
            // 
            this.cmbFuturesExpiry.FormattingEnabled = true;
            this.cmbFuturesExpiry.Location = new System.Drawing.Point(241, 13);
            this.cmbFuturesExpiry.Name = "cmbFuturesExpiry";
            this.cmbFuturesExpiry.Size = new System.Drawing.Size(124, 23);
            this.cmbFuturesExpiry.TabIndex = 106;
            this.cmbFuturesExpiry.SelectedIndexChanged += new System.EventHandler(this.cmbFuturesExpiry_SelectedIndexChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(188, 14);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(31, 15);
            this.label31.TabIndex = 105;
            this.label31.Text = "Exp";
            // 
            // btnFuturesCancel
            // 
            this.btnFuturesCancel.Location = new System.Drawing.Point(500, 137);
            this.btnFuturesCancel.Name = "btnFuturesCancel";
            this.btnFuturesCancel.Size = new System.Drawing.Size(63, 23);
            this.btnFuturesCancel.TabIndex = 104;
            this.btnFuturesCancel.Text = "Cancel";
            this.btnFuturesCancel.UseVisualStyleBackColor = true;
            // 
            // btnFuturesShort
            // 
            this.btnFuturesShort.Location = new System.Drawing.Point(431, 138);
            this.btnFuturesShort.Name = "btnFuturesShort";
            this.btnFuturesShort.Size = new System.Drawing.Size(63, 23);
            this.btnFuturesShort.TabIndex = 103;
            this.btnFuturesShort.Text = "Short";
            this.btnFuturesShort.UseVisualStyleBackColor = true;
            // 
            // btnFuturesSell
            // 
            this.btnFuturesSell.Location = new System.Drawing.Point(500, 105);
            this.btnFuturesSell.Name = "btnFuturesSell";
            this.btnFuturesSell.Size = new System.Drawing.Size(63, 23);
            this.btnFuturesSell.TabIndex = 102;
            this.btnFuturesSell.Text = "Sell";
            this.btnFuturesSell.UseVisualStyleBackColor = true;
            this.btnFuturesSell.Click += new System.EventHandler(this.btnFuturesSell_Click);
            // 
            // btnFuturesBuy
            // 
            this.btnFuturesBuy.Location = new System.Drawing.Point(431, 105);
            this.btnFuturesBuy.Name = "btnFuturesBuy";
            this.btnFuturesBuy.Size = new System.Drawing.Size(63, 23);
            this.btnFuturesBuy.TabIndex = 101;
            this.btnFuturesBuy.Text = "Buy";
            this.btnFuturesBuy.UseVisualStyleBackColor = true;
            this.btnFuturesBuy.Click += new System.EventHandler(this.btnFuturesBuy_Click);
            // 
            // cmbFuturesTif
            // 
            this.cmbFuturesTif.FormattingEnabled = true;
            this.cmbFuturesTif.Items.AddRange(new object[] {
            "DAY",
            "GTC",
            "OPG",
            "IOC",
            "GTD",
            "DTC"});
            this.cmbFuturesTif.Location = new System.Drawing.Point(308, 132);
            this.cmbFuturesTif.Name = "cmbFuturesTif";
            this.cmbFuturesTif.Size = new System.Drawing.Size(57, 23);
            this.cmbFuturesTif.TabIndex = 100;
            // 
            // cmbFuturesType
            // 
            this.cmbFuturesType.BackColor = System.Drawing.SystemColors.Control;
            this.cmbFuturesType.Enabled = false;
            this.cmbFuturesType.FormattingEnabled = true;
            this.cmbFuturesType.Location = new System.Drawing.Point(241, 132);
            this.cmbFuturesType.Name = "cmbFuturesType";
            this.cmbFuturesType.Size = new System.Drawing.Size(61, 23);
            this.cmbFuturesType.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 98;
            this.label2.Text = "Type";
            // 
            // cmbFuturesVenue
            // 
            this.cmbFuturesVenue.FormattingEnabled = true;
            this.cmbFuturesVenue.Items.AddRange(new object[] {
            "NSE"});
            this.cmbFuturesVenue.Location = new System.Drawing.Point(241, 102);
            this.cmbFuturesVenue.Name = "cmbFuturesVenue";
            this.cmbFuturesVenue.Size = new System.Drawing.Size(124, 23);
            this.cmbFuturesVenue.TabIndex = 97;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(180, 102);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 15);
            this.label17.TabIndex = 96;
            this.label17.Text = "Venue";
            // 
            // txtFuturesLimit
            // 
            this.txtFuturesLimit.Location = new System.Drawing.Point(65, 132);
            this.txtFuturesLimit.Name = "txtFuturesLimit";
            this.txtFuturesLimit.Size = new System.Drawing.Size(111, 21);
            this.txtFuturesLimit.TabIndex = 95;
            // 
            // txtFuturesQty
            // 
            this.txtFuturesQty.Location = new System.Drawing.Point(65, 102);
            this.txtFuturesQty.Name = "txtFuturesQty";
            this.txtFuturesQty.Size = new System.Drawing.Size(111, 21);
            this.txtFuturesQty.TabIndex = 94;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 132);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 15);
            this.label18.TabIndex = 93;
            this.label18.Text = "Limit";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 102);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 15);
            this.label19.TabIndex = 92;
            this.label19.Text = "Qty";
            // 
            // txtFuturesSpread
            // 
            this.txtFuturesSpread.BackColor = System.Drawing.SystemColors.Control;
            this.txtFuturesSpread.Enabled = false;
            this.txtFuturesSpread.Location = new System.Drawing.Point(569, 71);
            this.txtFuturesSpread.Name = "txtFuturesSpread";
            this.txtFuturesSpread.Size = new System.Drawing.Size(81, 21);
            this.txtFuturesSpread.TabIndex = 91;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(502, 75);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 15);
            this.label20.TabIndex = 90;
            this.label20.Text = "Spread";
            // 
            // txtFuturesLow
            // 
            this.txtFuturesLow.BackColor = System.Drawing.SystemColors.Control;
            this.txtFuturesLow.Enabled = false;
            this.txtFuturesLow.Location = new System.Drawing.Point(431, 71);
            this.txtFuturesLow.Name = "txtFuturesLow";
            this.txtFuturesLow.Size = new System.Drawing.Size(67, 21);
            this.txtFuturesLow.TabIndex = 89;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(382, 75);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 15);
            this.label21.TabIndex = 88;
            this.label21.Text = "Low";
            // 
            // txtFuturesClose
            // 
            this.txtFuturesClose.BackColor = System.Drawing.SystemColors.Control;
            this.txtFuturesClose.Enabled = false;
            this.txtFuturesClose.Location = new System.Drawing.Point(241, 71);
            this.txtFuturesClose.Name = "txtFuturesClose";
            this.txtFuturesClose.Size = new System.Drawing.Size(124, 21);
            this.txtFuturesClose.TabIndex = 87;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(182, 75);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(43, 15);
            this.label22.TabIndex = 86;
            this.label22.Text = "Close";
            // 
            // txtFuturesVolume
            // 
            this.txtFuturesVolume.BackColor = System.Drawing.SystemColors.Control;
            this.txtFuturesVolume.Enabled = false;
            this.txtFuturesVolume.Location = new System.Drawing.Point(65, 71);
            this.txtFuturesVolume.Name = "txtFuturesVolume";
            this.txtFuturesVolume.Size = new System.Drawing.Size(111, 21);
            this.txtFuturesVolume.TabIndex = 85;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(18, 75);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(27, 15);
            this.label23.TabIndex = 84;
            this.label23.Text = "Vol";
            // 
            // txtFuturesRatio
            // 
            this.txtFuturesRatio.BackColor = System.Drawing.SystemColors.Control;
            this.txtFuturesRatio.Enabled = false;
            this.txtFuturesRatio.Location = new System.Drawing.Point(569, 43);
            this.txtFuturesRatio.Name = "txtFuturesRatio";
            this.txtFuturesRatio.Size = new System.Drawing.Size(81, 21);
            this.txtFuturesRatio.TabIndex = 83;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(508, 43);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 15);
            this.label24.TabIndex = 82;
            this.label24.Text = "Ratio";
            // 
            // txtFuturesHigh
            // 
            this.txtFuturesHigh.BackColor = System.Drawing.SystemColors.Control;
            this.txtFuturesHigh.Enabled = false;
            this.txtFuturesHigh.Location = new System.Drawing.Point(431, 43);
            this.txtFuturesHigh.Name = "txtFuturesHigh";
            this.txtFuturesHigh.Size = new System.Drawing.Size(68, 21);
            this.txtFuturesHigh.TabIndex = 81;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(388, 43);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(21, 15);
            this.label25.TabIndex = 80;
            this.label25.Text = "Hi";
            // 
            // txtFuturesOpen
            // 
            this.txtFuturesOpen.BackColor = System.Drawing.SystemColors.Control;
            this.txtFuturesOpen.Enabled = false;
            this.txtFuturesOpen.Location = new System.Drawing.Point(241, 43);
            this.txtFuturesOpen.Name = "txtFuturesOpen";
            this.txtFuturesOpen.Size = new System.Drawing.Size(124, 21);
            this.txtFuturesOpen.TabIndex = 79;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(183, 43);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 15);
            this.label26.TabIndex = 78;
            this.label26.Text = "Open";
            // 
            // txtFuturesLast
            // 
            this.txtFuturesLast.BackColor = System.Drawing.SystemColors.Control;
            this.txtFuturesLast.Enabled = false;
            this.txtFuturesLast.Location = new System.Drawing.Point(65, 43);
            this.txtFuturesLast.Name = "txtFuturesLast";
            this.txtFuturesLast.Size = new System.Drawing.Size(111, 21);
            this.txtFuturesLast.TabIndex = 77;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(14, 43);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(34, 15);
            this.label27.TabIndex = 76;
            this.label27.Text = "Last";
            // 
            // txtFuturesPercentChange
            // 
            this.txtFuturesPercentChange.BackColor = System.Drawing.SystemColors.Control;
            this.txtFuturesPercentChange.Enabled = false;
            this.txtFuturesPercentChange.Location = new System.Drawing.Point(569, 13);
            this.txtFuturesPercentChange.Name = "txtFuturesPercentChange";
            this.txtFuturesPercentChange.Size = new System.Drawing.Size(81, 21);
            this.txtFuturesPercentChange.TabIndex = 75;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(504, 14);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 15);
            this.label28.TabIndex = 74;
            this.label28.Text = "% Chg";
            // 
            // txtFuturesChange
            // 
            this.txtFuturesChange.BackColor = System.Drawing.SystemColors.Control;
            this.txtFuturesChange.Enabled = false;
            this.txtFuturesChange.Location = new System.Drawing.Point(431, 13);
            this.txtFuturesChange.Name = "txtFuturesChange";
            this.txtFuturesChange.Size = new System.Drawing.Size(68, 21);
            this.txtFuturesChange.TabIndex = 73;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(382, 14);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(32, 15);
            this.label29.TabIndex = 72;
            this.label29.Text = "Chg";
            // 
            // cmbFuturesSymbol
            // 
            this.cmbFuturesSymbol.DropDownHeight = 110;
            this.cmbFuturesSymbol.FormattingEnabled = true;
            this.cmbFuturesSymbol.IntegralHeight = false;
            this.cmbFuturesSymbol.ItemHeight = 15;
            this.cmbFuturesSymbol.Location = new System.Drawing.Point(65, 13);
            this.cmbFuturesSymbol.Name = "cmbFuturesSymbol";
            this.cmbFuturesSymbol.Size = new System.Drawing.Size(111, 23);
            this.cmbFuturesSymbol.TabIndex = 71;
            this.cmbFuturesSymbol.SelectedIndexChanged += new System.EventHandler(this.cmbFuturesSymbol_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(14, 14);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(34, 15);
            this.label30.TabIndex = 70;
            this.label30.Text = "Sym";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dgvFuturesPrices);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dgvFuturesTrade);
            this.splitContainer4.Size = new System.Drawing.Size(764, 286);
            this.splitContainer4.SplitterDistance = 443;
            this.splitContainer4.TabIndex = 0;
            // 
            // dgvFuturesPrices
            // 
            this.dgvFuturesPrices.AllowUserToAddRows = false;
            this.dgvFuturesPrices.AllowUserToDeleteRows = false;
            this.dgvFuturesPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFuturesPrices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BidExch,
            this.FutureBidPrice,
            this.FutureBidSize,
            this.FutureAskExch,
            this.FutureAskPrice,
            this.FutureAskSize});
            this.dgvFuturesPrices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFuturesPrices.Location = new System.Drawing.Point(0, 0);
            this.dgvFuturesPrices.Name = "dgvFuturesPrices";
            this.dgvFuturesPrices.ReadOnly = true;
            this.dgvFuturesPrices.Size = new System.Drawing.Size(443, 286);
            this.dgvFuturesPrices.TabIndex = 0;
            // 
            // BidExch
            // 
            this.BidExch.HeaderText = "Exch";
            this.BidExch.Name = "BidExch";
            this.BidExch.ReadOnly = true;
            this.BidExch.Width = 50;
            // 
            // FutureBidPrice
            // 
            this.FutureBidPrice.HeaderText = "Price";
            this.FutureBidPrice.Name = "FutureBidPrice";
            this.FutureBidPrice.ReadOnly = true;
            this.FutureBidPrice.Width = 75;
            // 
            // FutureBidSize
            // 
            this.FutureBidSize.HeaderText = "Size";
            this.FutureBidSize.Name = "FutureBidSize";
            this.FutureBidSize.ReadOnly = true;
            this.FutureBidSize.Width = 75;
            // 
            // FutureAskExch
            // 
            this.FutureAskExch.HeaderText = "Exch";
            this.FutureAskExch.Name = "FutureAskExch";
            this.FutureAskExch.ReadOnly = true;
            this.FutureAskExch.Width = 50;
            // 
            // FutureAskPrice
            // 
            this.FutureAskPrice.HeaderText = "Price";
            this.FutureAskPrice.Name = "FutureAskPrice";
            this.FutureAskPrice.ReadOnly = true;
            this.FutureAskPrice.Width = 75;
            // 
            // FutureAskSize
            // 
            this.FutureAskSize.HeaderText = "Size";
            this.FutureAskSize.Name = "FutureAskSize";
            this.FutureAskSize.ReadOnly = true;
            this.FutureAskSize.Width = 75;
            // 
            // dgvFuturesTrade
            // 
            this.dgvFuturesTrade.AllowUserToAddRows = false;
            this.dgvFuturesTrade.AllowUserToDeleteRows = false;
            this.dgvFuturesTrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFuturesTrade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FutureOrdPrice,
            this.FutureOrdSize,
            this.FutureOrdTime});
            this.dgvFuturesTrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFuturesTrade.Location = new System.Drawing.Point(0, 0);
            this.dgvFuturesTrade.Name = "dgvFuturesTrade";
            this.dgvFuturesTrade.ReadOnly = true;
            this.dgvFuturesTrade.Size = new System.Drawing.Size(317, 286);
            this.dgvFuturesTrade.TabIndex = 0;
            // 
            // FutureOrdPrice
            // 
            this.FutureOrdPrice.HeaderText = "OrdPrice";
            this.FutureOrdPrice.Name = "FutureOrdPrice";
            this.FutureOrdPrice.ReadOnly = true;
            // 
            // FutureOrdSize
            // 
            this.FutureOrdSize.HeaderText = "Ord Size";
            this.FutureOrdSize.Name = "FutureOrdSize";
            this.FutureOrdSize.ReadOnly = true;
            // 
            // FutureOrdTime
            // 
            this.FutureOrdTime.HeaderText = "OrdTime";
            this.FutureOrdTime.Name = "FutureOrdTime";
            this.FutureOrdTime.ReadOnly = true;
            // 
            // tabPageOption
            // 
            this.tabPageOption.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageOption.Controls.Add(this.splitContainer5);
            this.tabPageOption.Location = new System.Drawing.Point(4, 24);
            this.tabPageOption.Name = "tabPageOption";
            this.tabPageOption.Size = new System.Drawing.Size(770, 480);
            this.tabPageOption.TabIndex = 2;
            this.tabPageOption.Text = "Options";
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.AllowDrop = true;
            this.splitContainer5.Panel1.Controls.Add(this.txtOptionsDisplayQty);
            this.splitContainer5.Panel1.Controls.Add(this.btnOptionsSell);
            this.splitContainer5.Panel1.Controls.Add(this.txtOptionsPrice);
            this.splitContainer5.Panel1.Controls.Add(this.txtOptionsQty);
            this.splitContainer5.Panel1.Controls.Add(this.label42);
            this.splitContainer5.Panel1.Controls.Add(this.label41);
            this.splitContainer5.Panel1.Controls.Add(this.btnOptionsBuy);
            this.splitContainer5.Panel1.Controls.Add(this.cmbOptionsDest);
            this.splitContainer5.Panel1.Controls.Add(this.cmbOptionsAccount);
            this.splitContainer5.Panel1.Controls.Add(this.cmbOptionsTif);
            this.splitContainer5.Panel1.Controls.Add(this.cmbOptionsOC);
            this.splitContainer5.Panel1.Controls.Add(this.label40);
            this.splitContainer5.Panel1.Controls.Add(this.label39);
            this.splitContainer5.Panel1.Controls.Add(this.label38);
            this.splitContainer5.Panel1.Controls.Add(this.label37);
            this.splitContainer5.Panel1.Controls.Add(this.label36);
            this.splitContainer5.Panel1.Controls.Add(this.txtOptionsAskSize);
            this.splitContainer5.Panel1.Controls.Add(this.txtOptionsAskPrice);
            this.splitContainer5.Panel1.Controls.Add(this.txtOptionsBidPrice);
            this.splitContainer5.Panel1.Controls.Add(this.txtOptionsBidSize);
            this.splitContainer5.Panel1.Controls.Add(this.txtOptionsPercentChange);
            this.splitContainer5.Panel1.Controls.Add(this.txtOptionsChange);
            this.splitContainer5.Panel1.Controls.Add(this.cmbOptionsCallPut);
            this.splitContainer5.Panel1.Controls.Add(this.label35);
            this.splitContainer5.Panel1.Controls.Add(this.cmbOptionsStrike);
            this.splitContainer5.Panel1.Controls.Add(this.label34);
            this.splitContainer5.Panel1.Controls.Add(this.cmbOptionsExpiry);
            this.splitContainer5.Panel1.Controls.Add(this.label33);
            this.splitContainer5.Panel1.Controls.Add(this.cmbOptionsSymbol);
            this.splitContainer5.Panel1.Controls.Add(this.label32);
            this.splitContainer5.Panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel1_DragDrop);
            this.splitContainer5.Panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel1_DragEnter);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer5.Size = new System.Drawing.Size(770, 480);
            this.splitContainer5.SplitterDistance = 265;
            this.splitContainer5.TabIndex = 30;
            // 
            // txtOptionsDisplayQty
            // 
            this.txtOptionsDisplayQty.Location = new System.Drawing.Point(341, 141);
            this.txtOptionsDisplayQty.Name = "txtOptionsDisplayQty";
            this.txtOptionsDisplayQty.Size = new System.Drawing.Size(94, 21);
            this.txtOptionsDisplayQty.TabIndex = 60;
            // 
            // btnOptionsSell
            // 
            this.btnOptionsSell.Location = new System.Drawing.Point(363, 192);
            this.btnOptionsSell.Name = "btnOptionsSell";
            this.btnOptionsSell.Size = new System.Drawing.Size(75, 23);
            this.btnOptionsSell.TabIndex = 59;
            this.btnOptionsSell.Text = "Sell";
            this.btnOptionsSell.UseVisualStyleBackColor = true;
            this.btnOptionsSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // txtOptionsPrice
            // 
            this.txtOptionsPrice.Location = new System.Drawing.Point(234, 194);
            this.txtOptionsPrice.Name = "txtOptionsPrice";
            this.txtOptionsPrice.Size = new System.Drawing.Size(96, 21);
            this.txtOptionsPrice.TabIndex = 58;
            // 
            // txtOptionsQty
            // 
            this.txtOptionsQty.Location = new System.Drawing.Point(128, 194);
            this.txtOptionsQty.Name = "txtOptionsQty";
            this.txtOptionsQty.Size = new System.Drawing.Size(94, 21);
            this.txtOptionsQty.TabIndex = 57;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(252, 176);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(44, 15);
            this.label42.TabIndex = 56;
            this.label42.Text = "Price:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(132, 176);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(31, 15);
            this.label41.TabIndex = 55;
            this.label41.Text = "Qty:";
            // 
            // btnOptionsBuy
            // 
            this.btnOptionsBuy.Location = new System.Drawing.Point(35, 192);
            this.btnOptionsBuy.Name = "btnOptionsBuy";
            this.btnOptionsBuy.Size = new System.Drawing.Size(75, 23);
            this.btnOptionsBuy.TabIndex = 54;
            this.btnOptionsBuy.Text = "Buy";
            this.btnOptionsBuy.UseVisualStyleBackColor = true;
            this.btnOptionsBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // cmbOptionsDest
            // 
            this.cmbOptionsDest.FormattingEnabled = true;
            this.cmbOptionsDest.Items.AddRange(new object[] {
            "NSE"});
            this.cmbOptionsDest.Location = new System.Drawing.Point(267, 140);
            this.cmbOptionsDest.Name = "cmbOptionsDest";
            this.cmbOptionsDest.Size = new System.Drawing.Size(61, 23);
            this.cmbOptionsDest.TabIndex = 52;
            // 
            // cmbOptionsAccount
            // 
            this.cmbOptionsAccount.FormattingEnabled = true;
            this.cmbOptionsAccount.Location = new System.Drawing.Point(192, 139);
            this.cmbOptionsAccount.Name = "cmbOptionsAccount";
            this.cmbOptionsAccount.Size = new System.Drawing.Size(62, 23);
            this.cmbOptionsAccount.TabIndex = 51;
            // 
            // cmbOptionsTif
            // 
            this.cmbOptionsTif.FormattingEnabled = true;
            this.cmbOptionsTif.Items.AddRange(new object[] {
            "DAY",
            "GTC",
            "OPG",
            "IOC",
            "GTD",
            "DTC"});
            this.cmbOptionsTif.Location = new System.Drawing.Point(112, 139);
            this.cmbOptionsTif.Name = "cmbOptionsTif";
            this.cmbOptionsTif.Size = new System.Drawing.Size(67, 23);
            this.cmbOptionsTif.TabIndex = 50;
            // 
            // cmbOptionsOC
            // 
            this.cmbOptionsOC.FormattingEnabled = true;
            this.cmbOptionsOC.Location = new System.Drawing.Point(35, 140);
            this.cmbOptionsOC.Name = "cmbOptionsOC";
            this.cmbOptionsOC.Size = new System.Drawing.Size(64, 23);
            this.cmbOptionsOC.TabIndex = 49;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(341, 118);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(78, 15);
            this.label40.TabIndex = 48;
            this.label40.Text = "Display Qty";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(267, 118);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(36, 15);
            this.label39.TabIndex = 47;
            this.label39.Text = "Dest";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(192, 118);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(57, 15);
            this.label38.TabIndex = 46;
            this.label38.Text = "Account";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(113, 118);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(19, 15);
            this.label37.TabIndex = 45;
            this.label37.Text = "tif";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(36, 118);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(30, 15);
            this.label36.TabIndex = 44;
            this.label36.Text = "O/C";
            // 
            // txtOptionsAskSize
            // 
            this.txtOptionsAskSize.Location = new System.Drawing.Point(344, 83);
            this.txtOptionsAskSize.Name = "txtOptionsAskSize";
            this.txtOptionsAskSize.Size = new System.Drawing.Size(94, 21);
            this.txtOptionsAskSize.TabIndex = 43;
            // 
            // txtOptionsAskPrice
            // 
            this.txtOptionsAskPrice.Location = new System.Drawing.Point(233, 83);
            this.txtOptionsAskPrice.Name = "txtOptionsAskPrice";
            this.txtOptionsAskPrice.Size = new System.Drawing.Size(97, 21);
            this.txtOptionsAskPrice.TabIndex = 42;
            // 
            // txtOptionsBidPrice
            // 
            this.txtOptionsBidPrice.Location = new System.Drawing.Point(128, 83);
            this.txtOptionsBidPrice.Name = "txtOptionsBidPrice";
            this.txtOptionsBidPrice.Size = new System.Drawing.Size(94, 21);
            this.txtOptionsBidPrice.TabIndex = 41;
            // 
            // txtOptionsBidSize
            // 
            this.txtOptionsBidSize.Location = new System.Drawing.Point(35, 83);
            this.txtOptionsBidSize.Name = "txtOptionsBidSize";
            this.txtOptionsBidSize.Size = new System.Drawing.Size(87, 21);
            this.txtOptionsBidSize.TabIndex = 40;
            // 
            // txtOptionsPercentChange
            // 
            this.txtOptionsPercentChange.Location = new System.Drawing.Point(128, 56);
            this.txtOptionsPercentChange.Name = "txtOptionsPercentChange";
            this.txtOptionsPercentChange.Size = new System.Drawing.Size(94, 21);
            this.txtOptionsPercentChange.TabIndex = 39;
            // 
            // txtOptionsChange
            // 
            this.txtOptionsChange.Location = new System.Drawing.Point(35, 56);
            this.txtOptionsChange.Name = "txtOptionsChange";
            this.txtOptionsChange.Size = new System.Drawing.Size(87, 21);
            this.txtOptionsChange.TabIndex = 38;
            // 
            // cmbOptionsCallPut
            // 
            this.cmbOptionsCallPut.FormattingEnabled = true;
            this.cmbOptionsCallPut.Items.AddRange(new object[] {
            "CE",
            "PE"});
            this.cmbOptionsCallPut.Location = new System.Drawing.Point(233, 27);
            this.cmbOptionsCallPut.Name = "cmbOptionsCallPut";
            this.cmbOptionsCallPut.Size = new System.Drawing.Size(97, 23);
            this.cmbOptionsCallPut.TabIndex = 37;
            this.cmbOptionsCallPut.SelectedIndexChanged += new System.EventHandler(this.cmbOptionsCallPut_SelectedIndexChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(230, 9);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(29, 15);
            this.label35.TabIndex = 36;
            this.label35.Text = "C/P";
            // 
            // cmbOptionsStrike
            // 
            this.cmbOptionsStrike.FormattingEnabled = true;
            this.cmbOptionsStrike.Location = new System.Drawing.Point(344, 27);
            this.cmbOptionsStrike.Name = "cmbOptionsStrike";
            this.cmbOptionsStrike.Size = new System.Drawing.Size(97, 23);
            this.cmbOptionsStrike.TabIndex = 35;
            this.cmbOptionsStrike.SelectedIndexChanged += new System.EventHandler(this.cmbOptionsStrike_SelectedIndexChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(341, 9);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(44, 15);
            this.label34.TabIndex = 34;
            this.label34.Text = "Strike";
            // 
            // cmbOptionsExpiry
            // 
            this.cmbOptionsExpiry.FormattingEnabled = true;
            this.cmbOptionsExpiry.Location = new System.Drawing.Point(128, 27);
            this.cmbOptionsExpiry.Name = "cmbOptionsExpiry";
            this.cmbOptionsExpiry.Size = new System.Drawing.Size(94, 23);
            this.cmbOptionsExpiry.TabIndex = 33;
            this.cmbOptionsExpiry.SelectedIndexChanged += new System.EventHandler(this.cmbOptionsExpiry_SelectedIndexChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(125, 9);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(76, 15);
            this.label33.TabIndex = 32;
            this.label33.Text = "Expiration:";
            // 
            // cmbOptionsSymbol
            // 
            this.cmbOptionsSymbol.FormattingEnabled = true;
            this.cmbOptionsSymbol.Location = new System.Drawing.Point(35, 27);
            this.cmbOptionsSymbol.Name = "cmbOptionsSymbol";
            this.cmbOptionsSymbol.Size = new System.Drawing.Size(87, 23);
            this.cmbOptionsSymbol.TabIndex = 31;
            this.cmbOptionsSymbol.SelectedIndexChanged += new System.EventHandler(this.cmbOptionsSymbol_SelectedIndexChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(32, 9);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(34, 15);
            this.label32.TabIndex = 30;
            this.label32.Text = "Sym";
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer6.Size = new System.Drawing.Size(770, 211);
            this.splitContainer6.SplitterDistance = 435;
            this.splitContainer6.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(435, 211);
            this.dataGridView1.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Exch";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Price";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Size";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 75;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Exch";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Price";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 75;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Size";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 75;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(331, 211);
            this.dataGridView2.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "OrdPrice";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Ord Size";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "OrdTime";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // TradingBoxV2
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 508);
            this.Controls.Add(this.tabControl1);
            this.Name = "TradingBoxV2";
            this.Text = "TradingBoxV2";
            this.Load += new System.EventHandler(this.TradingBoxV2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageStock.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocksPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocksTrades)).EndInit();
            this.tabPageFuture.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuturesPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuturesTrade)).EndInit();
            this.tabPageOption.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        private void splitContainer1_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageStock;
        private System.Windows.Forms.TabPage tabPageFuture;
        private System.Windows.Forms.TabPage tabPageOption;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnStocksCancel;
        private System.Windows.Forms.Button btnStocksShort;
        private System.Windows.Forms.Button btnStocksSell;
        private System.Windows.Forms.Button btnStocksBuy;
        private System.Windows.Forms.ComboBox cmbStocksTif;
        private System.Windows.Forms.ComboBox cmbStocksType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbStocksVenue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtStocksLimit;
        private System.Windows.Forms.TextBox txtStocksQty;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtStocksSpread;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtStocksLow;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtStocksClose;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStocksVolume;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStocksRatio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStocksHigh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStocksOpen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStocksLast;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStocksPercentChange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStocksChange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStocksSymbol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvStocksPrices;
        private System.Windows.Forms.DataGridView dgvStocksTrades;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnFuturesCancel;
        private System.Windows.Forms.Button btnFuturesShort;
        private System.Windows.Forms.Button btnFuturesSell;
        private System.Windows.Forms.Button btnFuturesBuy;
        private System.Windows.Forms.ComboBox cmbFuturesTif;
        private System.Windows.Forms.ComboBox cmbFuturesType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFuturesVenue;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtFuturesLimit;
        private System.Windows.Forms.TextBox txtFuturesQty;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtFuturesSpread;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtFuturesLow;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtFuturesClose;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtFuturesVolume;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtFuturesRatio;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtFuturesHigh;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtFuturesOpen;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtFuturesLast;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtFuturesPercentChange;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtFuturesChange;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cmbFuturesSymbol;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DataGridViewTextBoxColumn BidExchange;
        private System.Windows.Forms.DataGridViewTextBoxColumn BidSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn BidPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn AskExch;
        private System.Windows.Forms.DataGridViewTextBoxColumn AskSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn AskPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderTime;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView dgvFuturesPrices;
        private System.Windows.Forms.DataGridViewTextBoxColumn BidExch;
        private System.Windows.Forms.DataGridViewTextBoxColumn FutureBidPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn FutureBidSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn FutureAskExch;
        private System.Windows.Forms.DataGridViewTextBoxColumn FutureAskPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn FutureAskSize;
        private System.Windows.Forms.DataGridView dgvFuturesTrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn FutureOrdPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn FutureOrdSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn FutureOrdTime;
        private System.Windows.Forms.ComboBox cmbFuturesExpiry;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button btnOptionsSell;
        private System.Windows.Forms.TextBox txtOptionsPrice;
        private System.Windows.Forms.TextBox txtOptionsQty;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button btnOptionsBuy;
        private System.Windows.Forms.ComboBox cmbOptionsDest;
        private System.Windows.Forms.ComboBox cmbOptionsAccount;
        private System.Windows.Forms.ComboBox cmbOptionsTif;
        private System.Windows.Forms.ComboBox cmbOptionsOC;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtOptionsAskSize;
        private System.Windows.Forms.TextBox txtOptionsAskPrice;
        private System.Windows.Forms.TextBox txtOptionsBidPrice;
        private System.Windows.Forms.TextBox txtOptionsBidSize;
        private System.Windows.Forms.TextBox txtOptionsPercentChange;
        private System.Windows.Forms.TextBox txtOptionsChange;
        private System.Windows.Forms.ComboBox cmbOptionsCallPut;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cmbOptionsStrike;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ComboBox cmbOptionsExpiry;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox cmbOptionsSymbol;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtOptionsDisplayQty;
    }
}