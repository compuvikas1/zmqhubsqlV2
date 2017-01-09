namespace ScannerWindowApplication
{
    partial class ScannerConfig
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbExch = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbStrike = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbOptType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbExpiry = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSymbolType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveFilter = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkApply = new System.Windows.Forms.CheckBox();
            this.txtLtp = new System.Windows.Forms.TextBox();
            this.txtClosePrice = new System.Windows.Forms.TextBox();
            this.cmbSymbol = new System.Windows.Forms.ComboBox();
            this.chkVolume = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.filterGridView = new System.Windows.Forms.DataGridView();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Series = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Strike = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apply = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmbExch);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.cmbStrike);
            this.splitContainer1.Panel1.Controls.Add(this.txtQuantity);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.cmbOptType);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.cmbExpiry);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSymbolType);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.btnSaveFilter);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer1.Panel1.Controls.Add(this.chkApply);
            this.splitContainer1.Panel1.Controls.Add(this.txtLtp);
            this.splitContainer1.Panel1.Controls.Add(this.txtClosePrice);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSymbol);
            this.splitContainer1.Panel1.Controls.Add(this.chkVolume);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.filterGridView);
            this.splitContainer1.Size = new System.Drawing.Size(996, 433);
            this.splitContainer1.SplitterDistance = 110;
            this.splitContainer1.TabIndex = 0;
            // 
            // cmbExch
            // 
            this.cmbExch.FormattingEnabled = true;
            this.cmbExch.Items.AddRange(new object[] {
            "NFO",
            "NOP"});
            this.cmbExch.Location = new System.Drawing.Point(283, 8);
            this.cmbExch.Name = "cmbExch";
            this.cmbExch.Size = new System.Drawing.Size(65, 21);
            this.cmbExch.TabIndex = 22;
            this.cmbExch.SelectedIndexChanged += new System.EventHandler(this.cmbExch_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(240, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Exch";
            // 
            // cmbStrike
            // 
            this.cmbStrike.FormattingEnabled = true;
            this.cmbStrike.Location = new System.Drawing.Point(850, 6);
            this.cmbStrike.Name = "cmbStrike";
            this.cmbStrike.Size = new System.Drawing.Size(121, 21);
            this.cmbStrike.TabIndex = 20;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(338, 58);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(95, 20);
            this.txtQuantity.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(794, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Strike";
            // 
            // cmbOptType
            // 
            this.cmbOptType.FormattingEnabled = true;
            this.cmbOptType.Location = new System.Drawing.Point(702, 4);
            this.cmbOptType.Name = "cmbOptType";
            this.cmbOptType.Size = new System.Drawing.Size(68, 21);
            this.cmbOptType.TabIndex = 15;
            this.cmbOptType.SelectedIndexChanged += new System.EventHandler(this.cmbOptType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(648, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "OptType";
            // 
            // cmbExpiry
            // 
            this.cmbExpiry.FormattingEnabled = true;
            this.cmbExpiry.Location = new System.Drawing.Point(547, 6);
            this.cmbExpiry.Name = "cmbExpiry";
            this.cmbExpiry.Size = new System.Drawing.Size(95, 21);
            this.cmbExpiry.TabIndex = 13;
            this.cmbExpiry.SelectedIndexChanged += new System.EventHandler(this.cmbExpiry_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(493, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Expiry";
            // 
            // cmbSymbolType
            // 
            this.cmbSymbolType.FormattingEnabled = true;
            this.cmbSymbolType.Location = new System.Drawing.Point(417, 6);
            this.cmbSymbolType.Name = "cmbSymbolType";
            this.cmbSymbolType.Size = new System.Drawing.Size(68, 21);
            this.cmbSymbolType.TabIndex = 11;
            this.cmbSymbolType.SelectedIndexChanged += new System.EventHandler(this.cmbSymbolType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Series";
            // 
            // btnSaveFilter
            // 
            this.btnSaveFilter.Location = new System.Drawing.Point(896, 56);
            this.btnSaveFilter.Name = "btnSaveFilter";
            this.btnSaveFilter.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFilter.TabIndex = 9;
            this.btnSaveFilter.Text = "Save Filters";
            this.btnSaveFilter.UseVisualStyleBackColor = true;
            this.btnSaveFilter.Click += new System.EventHandler(this.btnSaveFilter_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(787, 56);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkApply
            // 
            this.chkApply.AutoSize = true;
            this.chkApply.Location = new System.Drawing.Point(622, 56);
            this.chkApply.Name = "chkApply";
            this.chkApply.Size = new System.Drawing.Size(52, 17);
            this.chkApply.TabIndex = 7;
            this.chkApply.Text = "Apply";
            this.chkApply.UseVisualStyleBackColor = true;
            // 
            // txtLtp
            // 
            this.txtLtp.Location = new System.Drawing.Point(210, 60);
            this.txtLtp.Name = "txtLtp";
            this.txtLtp.Size = new System.Drawing.Size(68, 20);
            this.txtLtp.TabIndex = 6;
            // 
            // txtClosePrice
            // 
            this.txtClosePrice.Location = new System.Drawing.Point(85, 63);
            this.txtClosePrice.Name = "txtClosePrice";
            this.txtClosePrice.Size = new System.Drawing.Size(74, 20);
            this.txtClosePrice.TabIndex = 5;
            // 
            // cmbSymbol
            // 
            this.cmbSymbol.FormattingEnabled = true;
            this.cmbSymbol.Location = new System.Drawing.Point(59, 6);
            this.cmbSymbol.Name = "cmbSymbol";
            this.cmbSymbol.Size = new System.Drawing.Size(157, 21);
            this.cmbSymbol.TabIndex = 4;
            // 
            // chkVolume
            // 
            this.chkVolume.AutoSize = true;
            this.chkVolume.Location = new System.Drawing.Point(165, 65);
            this.chkVolume.Name = "chkVolume";
            this.chkVolume.Size = new System.Drawing.Size(27, 13);
            this.chkVolume.TabIndex = 2;
            this.chkVolume.Text = "LTP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ClosePrice";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Symbol";
            // 
            // filterGridView
            // 
            this.filterGridView.AllowUserToAddRows = false;
            this.filterGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filterGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Symbol,
            this.Exch,
            this.Series,
            this.OptType,
            this.Expiry,
            this.Strike,
            this.ClosePrice,
            this.LTP,
            this.Quantity,
            this.Apply});
            this.filterGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterGridView.Location = new System.Drawing.Point(0, 0);
            this.filterGridView.Name = "filterGridView";
            this.filterGridView.Size = new System.Drawing.Size(996, 319);
            this.filterGridView.TabIndex = 0;
            // 
            // Symbol
            // 
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            // 
            // Exch
            // 
            this.Exch.HeaderText = "Exch";
            this.Exch.Name = "Exch";
            this.Exch.ReadOnly = true;
            // 
            // Series
            // 
            this.Series.HeaderText = "Series";
            this.Series.Name = "Series";
            this.Series.ReadOnly = true;
            // 
            // OptType
            // 
            this.OptType.HeaderText = "OptType";
            this.OptType.Name = "OptType";
            this.OptType.ReadOnly = true;
            // 
            // Expiry
            // 
            this.Expiry.HeaderText = "Expiry";
            this.Expiry.Name = "Expiry";
            this.Expiry.ReadOnly = true;
            // 
            // Strike
            // 
            this.Strike.HeaderText = "Strike";
            this.Strike.Name = "Strike";
            this.Strike.ReadOnly = true;
            // 
            // ClosePrice
            // 
            this.ClosePrice.HeaderText = "Close Price";
            this.ClosePrice.Name = "ClosePrice";
            // 
            // LTP
            // 
            this.LTP.HeaderText = "LTP";
            this.LTP.Name = "LTP";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // Apply
            // 
            this.Apply.HeaderText = "Apply";
            this.Apply.Name = "Apply";
            // 
            // ScannerConfig
            // 
            this.ClientSize = new System.Drawing.Size(996, 433);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ScannerConfig";
            this.Text = "Scanner Filter\'s";
            this.Load += new System.EventHandler(this.ScannerConfig_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filterGridView)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSaveFilter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chkApply;
        private System.Windows.Forms.TextBox txtLtp;
        private System.Windows.Forms.TextBox txtClosePrice;
        private System.Windows.Forms.ComboBox cmbSymbol;
        private System.Windows.Forms.Label chkVolume;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView filterGridView;
        private System.Windows.Forms.ComboBox cmbExpiry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSymbolType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbOptType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStrike;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbExch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Series;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn Strike;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn LTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Apply;
    }
}