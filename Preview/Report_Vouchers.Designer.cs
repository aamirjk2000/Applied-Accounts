namespace Applied_Accounts.Reports
{
    partial class frmReport_Vouchers
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
            this.rpt_Voucher = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVouNo = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.dt_From = new System.Windows.Forms.DateTimePicker();
            this.dt_To = new System.Windows.Forms.DateTimePicker();
            this.btnVouchers = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rpt_Voucher
            // 
            this.rpt_Voucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rpt_Voucher.LocalReport.ReportEmbeddedResource = "Applied_Accounts.Reports.Report_Voucher.rdlc";
            this.rpt_Voucher.Location = new System.Drawing.Point(0, 61);
            this.rpt_Voucher.Name = "rpt_Voucher";
            this.rpt_Voucher.ServerReport.BearerToken = null;
            this.rpt_Voucher.Size = new System.Drawing.Size(800, 389);
            this.rpt_Voucher.TabIndex = 0;
            this.rpt_Voucher.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Voucher No.";
            // 
            // txtVouNo
            // 
            this.txtVouNo.Location = new System.Drawing.Point(86, 21);
            this.txtVouNo.Name = "txtVouNo";
            this.txtVouNo.Size = new System.Drawing.Size(100, 20);
            this.txtVouNo.TabIndex = 2;
            this.txtVouNo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtVouNo.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(207, 20);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "PREVIEW";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dt_From
            // 
            this.dt_From.CustomFormat = "dd-MMM-yyyy";
            this.dt_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_From.Location = new System.Drawing.Point(444, 21);
            this.dt_From.Name = "dt_From";
            this.dt_From.Size = new System.Drawing.Size(107, 20);
            this.dt_From.TabIndex = 4;
            // 
            // dt_To
            // 
            this.dt_To.CustomFormat = "dd-MMM-yyyy";
            this.dt_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_To.Location = new System.Drawing.Point(579, 21);
            this.dt_To.Name = "dt_To";
            this.dt_To.Size = new System.Drawing.Size(107, 20);
            this.dt_To.TabIndex = 5;
            // 
            // btnVouchers
            // 
            this.btnVouchers.Location = new System.Drawing.Point(713, 20);
            this.btnVouchers.Name = "btnVouchers";
            this.btnVouchers.Size = new System.Drawing.Size(75, 23);
            this.btnVouchers.TabIndex = 6;
            this.btnVouchers.Text = "PREVIEW";
            this.btnVouchers.UseVisualStyleBackColor = true;
            this.btnVouchers.Click += new System.EventHandler(this.btnVouchers_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Vouchers from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(553, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "To";
            // 
            // frmReport_Vouchers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVouchers);
            this.Controls.Add(this.dt_To);
            this.Controls.Add(this.dt_From);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtVouNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rpt_Voucher);
            this.Name = "frmReport_Vouchers";
            this.Text = "Report_View";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReport_Vouchers_FormClosed);
            this.Load += new System.EventHandler(this.Report_View_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpt_Voucher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVouNo;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DateTimePicker dt_From;
        private System.Windows.Forms.DateTimePicker dt_To;
        private System.Windows.Forms.Button btnVouchers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}