namespace ScannerWindowApplication
{
    partial class TradingBox
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
            this.Symbol = new System.Windows.Forms.Label();
            this.cmbSymbol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbExpiration = new System.Windows.Forms.ComboBox();
            this.cmbStrike = new System.Windows.Forms.ComboBox();
            this.cmbCallPut = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLimitPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCancel = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Symbol
            // 
            this.Symbol.AutoSize = true;
            this.Symbol.Location = new System.Drawing.Point(32, 25);
            this.Symbol.Name = "Symbol";
            this.Symbol.Size = new System.Drawing.Size(27, 13);
            this.Symbol.TabIndex = 0;
            this.Symbol.Text = "Sym";
            // 
            // cmbSymbol
            // 
            this.cmbSymbol.FormattingEnabled = true;
            this.cmbSymbol.Location = new System.Drawing.Point(28, 49);
            this.cmbSymbol.Name = "cmbSymbol";
            this.cmbSymbol.Size = new System.Drawing.Size(57, 21);
            this.cmbSymbol.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(108, 49);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(57, 21);
            this.cmbType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Expiration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Strike";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Call / Put";
            // 
            // cmbExpiration
            // 
            this.cmbExpiration.FormattingEnabled = true;
            this.cmbExpiration.Location = new System.Drawing.Point(206, 49);
            this.cmbExpiration.Name = "cmbExpiration";
            this.cmbExpiration.Size = new System.Drawing.Size(79, 21);
            this.cmbExpiration.TabIndex = 7;
            // 
            // cmbStrike
            // 
            this.cmbStrike.FormattingEnabled = true;
            this.cmbStrike.Location = new System.Drawing.Point(313, 49);
            this.cmbStrike.Name = "cmbStrike";
            this.cmbStrike.Size = new System.Drawing.Size(57, 21);
            this.cmbStrike.TabIndex = 8;
            // 
            // cmbCallPut
            // 
            this.cmbCallPut.FormattingEnabled = true;
            this.cmbCallPut.Location = new System.Drawing.Point(393, 49);
            this.cmbCallPut.Name = "cmbCallPut";
            this.cmbCallPut.Size = new System.Drawing.Size(57, 21);
            this.cmbCallPut.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Price";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(81, 102);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(22, 13);
            this.lblPrice.TabIndex = 11;
            this.lblPrice.Text = "0.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(129, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Qty";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(167, 102);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(13, 13);
            this.lblQty.TabIndex = 13;
            this.lblQty.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Limit Price";
            // 
            // txtLimitPrice
            // 
            this.txtLimitPrice.Location = new System.Drawing.Point(28, 166);
            this.txtLimitPrice.Name = "txtLimitPrice";
            this.txtLimitPrice.Size = new System.Drawing.Size(59, 20);
            this.txtLimitPrice.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(124, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(123, 166);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(60, 20);
            this.txtQuantity.TabIndex = 17;
            // 
            // btnBuy
            // 
            this.btnBuy.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuy.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuy.Location = new System.Drawing.Point(217, 166);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 18;
            this.btnBuy.Text = "BUY";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnSell
            // 
            this.btnSell.BackColor = System.Drawing.Color.Red;
            this.btnSell.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSell.Location = new System.Drawing.Point(316, 166);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(75, 23);
            this.btnSell.TabIndex = 19;
            this.btnSell.Text = "SELL";
            this.btnSell.UseVisualStyleBackColor = false;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(36, 221);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(437, 116);
            this.richTextBox1.TabIndex = 20;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Cancel Order ID";
            // 
            // txtCancel
            // 
            this.txtCancel.Location = new System.Drawing.Point(432, 146);
            this.txtCancel.Name = "txtCancel";
            this.txtCancel.Size = new System.Drawing.Size(100, 20);
            this.txtCancel.TabIndex = 22;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(435, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TradingBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 353);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtLimitPrice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbCallPut);
            this.Controls.Add(this.cmbStrike);
            this.Controls.Add(this.cmbExpiration);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSymbol);
            this.Controls.Add(this.Symbol);
            this.Name = "TradingBox";
            this.Text = "TradingBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TradingBox_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Symbol;
        private System.Windows.Forms.ComboBox cmbSymbol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbExpiration;
        private System.Windows.Forms.ComboBox cmbStrike;
        private System.Windows.Forms.ComboBox cmbCallPut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLimitPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCancel;
        private System.Windows.Forms.Button btnCancel;
    }
}