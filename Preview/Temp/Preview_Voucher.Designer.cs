namespace Applied_Accounts.Preview.Temp
{
    partial class Preview_Voucher
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
            this.SuspendLayout();
            // 
            // rpt_Voucher
            // 
            this.rpt_Voucher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpt_Voucher.LocalReport.ReportEmbeddedResource = "Applied_Accounts.Reports.Preview_Voucher.rdlc";
            this.rpt_Voucher.Location = new System.Drawing.Point(0, 0);
            this.rpt_Voucher.Name = "rpt_Voucher";
            this.rpt_Voucher.ServerReport.BearerToken = null;
            this.rpt_Voucher.Size = new System.Drawing.Size(800, 450);
            this.rpt_Voucher.TabIndex = 0;
            // 
            // Preview_Voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpt_Voucher);
            this.Name = "Preview_Voucher";
            this.Text = "Preview_Voucher";
            this.Load += new System.EventHandler(this.Preview_Voucher_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpt_Voucher;
    }
}