﻿namespace Applied_Accounts.Preview
{
    partial class frmPreview_Reports
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
            this.rpt_View.BackColor = System.Drawing.Color.FloralWhite;
            this.rpt_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpt_View.LocalReport.DisplayName = "PREVIEW";
            this.rpt_View.Location = new System.Drawing.Point(0, 0);
            this.rpt_View.Name = "rpt_View";
            this.rpt_View.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.rpt_View.ServerReport.BearerToken = null;
            this.rpt_View.Size = new System.Drawing.Size(800, 450);
            this.rpt_View.TabIndex = 0;
            // 
            // frmPreview_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpt_View);
            this.Name = "frmPreview_Reports";
            this.Text = "Preview_Reports";
            this.Load += new System.EventHandler(this.Preview_Reports_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpt_View;
    }
}