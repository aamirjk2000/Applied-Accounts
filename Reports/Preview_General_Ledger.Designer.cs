namespace Applied_Accounts.Reports
{
    partial class frmPreview_General_Ledger
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
            this.rpt_View = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpt_View
            // 
            this.rpt_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpt_View.LocalReport.ReportEmbeddedResource = "Applied_Accounts.Reports.Report_General_Ledger.rdlc";
            this.rpt_View.Location = new System.Drawing.Point(0, 0);
            this.rpt_View.Name = "rpt_View";
            this.rpt_View.ServerReport.BearerToken = null;
            this.rpt_View.Size = new System.Drawing.Size(800, 450);
            this.rpt_View.TabIndex = 0;
            this.rpt_View.Load += new System.EventHandler(this.rpt_View_Load);
            // 
            // frmPreview_General_Ledger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpt_View);
            this.Name = "frmPreview_General_Ledger";
            this.Text = "Preview General Ledger";
            this.Load += new System.EventHandler(this.Preview_General_Ledger_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpt_View;
    }
}