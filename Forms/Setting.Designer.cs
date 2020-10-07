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
            this.txtCompanyName.Location = new System.Drawing.Point(143, 25);
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
            this.dtAccountingFrom.Location = new System.Drawing.Point(143, 63);
            this.dtAccountingFrom.Name = "dtAccountingFrom";
            this.dtAccountingFrom.Size = new System.Drawing.Size(200, 20);
            this.dtAccountingFrom.TabIndex = 3;
            this.dtAccountingFrom.Leave += new System.EventHandler(this.dtAccountingFrom_Leave);
            // 
            // dtAccountingTo
            // 
            this.dtAccountingTo.Location = new System.Drawing.Point(143, 100);
            this.dtAccountingTo.Name = "dtAccountingTo";
            this.dtAccountingTo.Size = new System.Drawing.Size(200, 20);
            this.dtAccountingTo.TabIndex = 4;
            this.dtAccountingTo.Leave += new System.EventHandler(this.dtAccountingTo_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fiscal Year Start from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fiscal Year End on";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 100;
            this.label4.Text = "Report Date Format";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 101;
            this.label5.Text = "Date Picker Format";
            // 
            // txtReportDateFormat
            // 
            this.txtReportDateFormat.Location = new System.Drawing.Point(143, 147);
            this.txtReportDateFormat.Name = "txtReportDateFormat";
            this.txtReportDateFormat.Size = new System.Drawing.Size(200, 20);
            this.txtReportDateFormat.TabIndex = 102;
            this.txtReportDateFormat.Leave += new System.EventHandler(this.txtReportDateFormat_Leave);
            // 
            // txtDatePickerFormat
            // 
            this.txtDatePickerFormat.Location = new System.Drawing.Point(143, 173);
            this.txtDatePickerFormat.Name = "txtDatePickerFormat";
            this.txtDatePickerFormat.Size = new System.Drawing.Size(200, 20);
            this.txtDatePickerFormat.TabIndex = 103;
            this.txtDatePickerFormat.Leave += new System.EventHandler(this.txtDatePickerFormat_Leave);
            // 
            // txtDefaultDateFormat
            // 
            this.txtDefaultDateFormat.Location = new System.Drawing.Point(143, 199);
            this.txtDefaultDateFormat.Name = "txtDefaultDateFormat";
            this.txtDefaultDateFormat.Size = new System.Drawing.Size(200, 20);
            this.txtDefaultDateFormat.TabIndex = 105;
            this.txtDefaultDateFormat.Leave += new System.EventHandler(this.txtDefaultDateFormat_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 104;
            this.label6.Text = "Default Date Format";
            // 
            // txtComboDateFormat
            // 
            this.txtComboDateFormat.Location = new System.Drawing.Point(143, 225);
            this.txtComboDateFormat.Name = "txtComboDateFormat";
            this.txtComboDateFormat.Size = new System.Drawing.Size(200, 20);
            this.txtComboDateFormat.TabIndex = 107;
            this.txtComboDateFormat.Leave += new System.EventHandler(this.txtComboDateFormat_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 106;
            this.label7.Text = "Combo Date Format";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 108;
            this.label8.Text = "Date Heading Format";
            // 
            // txtReportHeadingFormat
            // 
            this.txtReportHeadingFormat.Location = new System.Drawing.Point(143, 255);
            this.txtReportHeadingFormat.Name = "txtReportHeadingFormat";
            this.txtReportHeadingFormat.Size = new System.Drawing.Size(200, 20);
            this.txtReportHeadingFormat.TabIndex = 109;
            this.txtReportHeadingFormat.Leave += new System.EventHandler(this.txtReportHeadingFormat_Leave);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtReportHeadingFormat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtComboDateFormat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDefaultDateFormat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDatePickerFormat);
            this.Controls.Add(this.txtReportDateFormat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtAccountingTo);
            this.Controls.Add(this.dtAccountingFrom);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label1);
            this.Name = "frmSetting";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
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
    }
}