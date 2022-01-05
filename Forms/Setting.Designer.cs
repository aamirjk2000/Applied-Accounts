namespace Applied_Accounts.Forms
{
    partial class frmSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.dtAccountingFrom = new System.Windows.Forms.DateTimePicker();
            this.dtAccountingTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReportDateFormat = new System.Windows.Forms.TextBox();
            this.txtDatePickerFormat = new System.Windows.Forms.TextBox();
            this.txtDefaultDateFormat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComboDateFormat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReportHeadingFormat = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCurrencyFormat = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pDates = new System.Windows.Forms.TabPage();
            this.pAccount = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cBoxPayable = new System.Windows.Forms.ComboBox();
            this.cBoxReceivable = new System.Windows.Forms.ComboBox();
            this.cBoxPayroll = new System.Windows.Forms.ComboBox();
            this.cBoxStock = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.pDates.SuspendLayout();
            this.pAccount.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(100, 22);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(510, 20);
            this.txtCompanyName.TabIndex = 1;
            this.txtCompanyName.Leave += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(713, 415);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 99;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dtAccountingFrom
            // 
            this.dtAccountingFrom.Location = new System.Drawing.Point(172, 59);
            this.dtAccountingFrom.Name = "dtAccountingFrom";
            this.dtAccountingFrom.Size = new System.Drawing.Size(200, 20);
            this.dtAccountingFrom.TabIndex = 3;
            this.dtAccountingFrom.Leave += new System.EventHandler(this.dtAccountingFrom_Leave);
            // 
            // dtAccountingTo
            // 
            this.dtAccountingTo.Location = new System.Drawing.Point(172, 96);
            this.dtAccountingTo.Name = "dtAccountingTo";
            this.dtAccountingTo.Size = new System.Drawing.Size(200, 20);
            this.dtAccountingTo.TabIndex = 4;
            this.dtAccountingTo.Leave += new System.EventHandler(this.dtAccountingTo_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fiscal Year Start from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fiscal Year End on";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 100;
            this.label4.Text = "Report Date Format";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 101;
            this.label5.Text = "Date Picker Format";
            // 
            // txtReportDateFormat
            // 
            this.txtReportDateFormat.Location = new System.Drawing.Point(172, 122);
            this.txtReportDateFormat.Name = "txtReportDateFormat";
            this.txtReportDateFormat.Size = new System.Drawing.Size(200, 20);
            this.txtReportDateFormat.TabIndex = 102;
            this.txtReportDateFormat.Leave += new System.EventHandler(this.txtReportDateFormat_Leave);
            // 
            // txtDatePickerFormat
            // 
            this.txtDatePickerFormat.Location = new System.Drawing.Point(172, 148);
            this.txtDatePickerFormat.Name = "txtDatePickerFormat";
            this.txtDatePickerFormat.Size = new System.Drawing.Size(200, 20);
            this.txtDatePickerFormat.TabIndex = 103;
            this.txtDatePickerFormat.Leave += new System.EventHandler(this.txtDatePickerFormat_Leave);
            // 
            // txtDefaultDateFormat
            // 
            this.txtDefaultDateFormat.Location = new System.Drawing.Point(172, 174);
            this.txtDefaultDateFormat.Name = "txtDefaultDateFormat";
            this.txtDefaultDateFormat.Size = new System.Drawing.Size(200, 20);
            this.txtDefaultDateFormat.TabIndex = 105;
            this.txtDefaultDateFormat.Leave += new System.EventHandler(this.txtDefaultDateFormat_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 104;
            this.label6.Text = "Default Date Format";
            // 
            // txtComboDateFormat
            // 
            this.txtComboDateFormat.Location = new System.Drawing.Point(172, 200);
            this.txtComboDateFormat.Name = "txtComboDateFormat";
            this.txtComboDateFormat.Size = new System.Drawing.Size(200, 20);
            this.txtComboDateFormat.TabIndex = 107;
            this.txtComboDateFormat.Leave += new System.EventHandler(this.txtComboDateFormat_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 106;
            this.label7.Text = "Combo Date Format";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 108;
            this.label8.Text = "Date Heading Format";
            // 
            // txtReportHeadingFormat
            // 
            this.txtReportHeadingFormat.Location = new System.Drawing.Point(172, 226);
            this.txtReportHeadingFormat.Name = "txtReportHeadingFormat";
            this.txtReportHeadingFormat.Size = new System.Drawing.Size(200, 20);
            this.txtReportHeadingFormat.TabIndex = 109;
            this.txtReportHeadingFormat.Leave += new System.EventHandler(this.txtReportHeadingFormat_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 110;
            this.label9.Text = "Currency Format";
            // 
            // txtCurrencyFormat
            // 
            this.txtCurrencyFormat.Location = new System.Drawing.Point(172, 252);
            this.txtCurrencyFormat.Name = "txtCurrencyFormat";
            this.txtCurrencyFormat.Size = new System.Drawing.Size(200, 20);
            this.txtCurrencyFormat.TabIndex = 111;
            this.txtCurrencyFormat.Leave += new System.EventHandler(this.txtCurrencyFormat_Leave);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pDates);
            this.tabControl1.Controls.Add(this.pAccount);
            this.tabControl1.Location = new System.Drawing.Point(12, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 346);
            this.tabControl1.TabIndex = 112;
            // 
            // pDates
            // 
            this.pDates.Controls.Add(this.txtCurrencyFormat);
            this.pDates.Controls.Add(this.label3);
            this.pDates.Controls.Add(this.label4);
            this.pDates.Controls.Add(this.label2);
            this.pDates.Controls.Add(this.label9);
            this.pDates.Controls.Add(this.dtAccountingTo);
            this.pDates.Controls.Add(this.dtAccountingFrom);
            this.pDates.Controls.Add(this.label5);
            this.pDates.Controls.Add(this.txtReportHeadingFormat);
            this.pDates.Controls.Add(this.txtReportDateFormat);
            this.pDates.Controls.Add(this.label8);
            this.pDates.Controls.Add(this.txtDatePickerFormat);
            this.pDates.Controls.Add(this.txtComboDateFormat);
            this.pDates.Controls.Add(this.label6);
            this.pDates.Controls.Add(this.label7);
            this.pDates.Controls.Add(this.txtDefaultDateFormat);
            this.pDates.Location = new System.Drawing.Point(4, 22);
            this.pDates.Name = "pDates";
            this.pDates.Padding = new System.Windows.Forms.Padding(3);
            this.pDates.Size = new System.Drawing.Size(768, 320);
            this.pDates.TabIndex = 0;
            this.pDates.Text = "Dates";
            this.pDates.UseVisualStyleBackColor = true;
            // 
            // pAccount
            // 
            this.pAccount.Controls.Add(this.groupBox1);
            this.pAccount.Location = new System.Drawing.Point(4, 22);
            this.pAccount.Name = "pAccount";
            this.pAccount.Padding = new System.Windows.Forms.Padding(3);
            this.pAccount.Size = new System.Drawing.Size(768, 320);
            this.pAccount.TabIndex = 1;
            this.pAccount.Text = "Accounts";
            this.pAccount.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Payable";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Receivable";
            // 
            // cBoxPayable
            // 
            this.cBoxPayable.FormattingEnabled = true;
            this.cBoxPayable.Location = new System.Drawing.Point(75, 107);
            this.cBoxPayable.Name = "cBoxPayable";
            this.cBoxPayable.Size = new System.Drawing.Size(179, 21);
            this.cBoxPayable.TabIndex = 5;
            this.cBoxPayable.Leave += new System.EventHandler(this.cBoxPayable_Leave);
            // 
            // cBoxReceivable
            // 
            this.cBoxReceivable.FormattingEnabled = true;
            this.cBoxReceivable.Location = new System.Drawing.Point(75, 80);
            this.cBoxReceivable.Name = "cBoxReceivable";
            this.cBoxReceivable.Size = new System.Drawing.Size(179, 21);
            this.cBoxReceivable.TabIndex = 4;
            this.cBoxReceivable.Leave += new System.EventHandler(this.cBoxReceivable_Leave);
            // 
            // cBoxPayroll
            // 
            this.cBoxPayroll.FormattingEnabled = true;
            this.cBoxPayroll.Location = new System.Drawing.Point(75, 53);
            this.cBoxPayroll.Name = "cBoxPayroll";
            this.cBoxPayroll.Size = new System.Drawing.Size(179, 21);
            this.cBoxPayroll.TabIndex = 3;
            this.cBoxPayroll.Leave += new System.EventHandler(this.cBoxPayroll_Leave);
            // 
            // cBoxStock
            // 
            this.cBoxStock.FormattingEnabled = true;
            this.cBoxStock.Location = new System.Drawing.Point(75, 26);
            this.cBoxStock.Name = "cBoxStock";
            this.cBoxStock.Size = new System.Drawing.Size(179, 21);
            this.cBoxStock.TabIndex = 2;
            this.cBoxStock.Leave += new System.EventHandler(this.cBoxStock_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Payroll";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Stock ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBoxPayable);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cBoxStock);
            this.groupBox1.Controls.Add(this.cBoxReceivable);
            this.groupBox1.Controls.Add(this.cBoxPayroll);
            this.groupBox1.Location = new System.Drawing.Point(15, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 146);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accounts Nature";
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label1);
            this.Name = "frmSetting";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.pDates.ResumeLayout(false);
            this.pDates.PerformLayout();
            this.pAccount.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtAccountingFrom;
        private System.Windows.Forms.DateTimePicker dtAccountingTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReportDateFormat;
        private System.Windows.Forms.TextBox txtDatePickerFormat;
        private System.Windows.Forms.TextBox txtDefaultDateFormat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtComboDateFormat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtReportHeadingFormat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCurrencyFormat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pDates;
        private System.Windows.Forms.TabPage pAccount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cBoxPayable;
        private System.Windows.Forms.ComboBox cBoxReceivable;
        private System.Windows.Forms.ComboBox cBoxPayroll;
        private System.Windows.Forms.ComboBox cBoxStock;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}