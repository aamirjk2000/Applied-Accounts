namespace Applied_Accounts.Forms
{
    partial class frmGeneral_Ledger
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.dt_To = new System.Windows.Forms.DateTimePicker();
            this.dt_From = new System.Windows.Forms.DateTimePicker();
            this.btnBrowseSupplier = new System.Windows.Forms.Button();
            this.cBoxCOA = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "To";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(530, 102);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(530, 68);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 16;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click_1);
            // 
            // dt_To
            // 
            this.dt_To.CustomFormat = "dd-MMM-yyyy";
            this.dt_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_To.Location = new System.Drawing.Point(275, 71);
            this.dt_To.Name = "dt_To";
            this.dt_To.Size = new System.Drawing.Size(100, 20);
            this.dt_To.TabIndex = 15;
            // 
            // dt_From
            // 
            this.dt_From.CustomFormat = "dd-MMM-yyyy";
            this.dt_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_From.Location = new System.Drawing.Point(115, 71);
            this.dt_From.Name = "dt_From";
            this.dt_From.Size = new System.Drawing.Size(100, 20);
            this.dt_From.TabIndex = 14;
            // 
            // btnBrowseSupplier
            // 
            this.btnBrowseSupplier.Location = new System.Drawing.Point(611, 26);
            this.btnBrowseSupplier.Name = "btnBrowseSupplier";
            this.btnBrowseSupplier.Size = new System.Drawing.Size(25, 23);
            this.btnBrowseSupplier.TabIndex = 13;
            this.btnBrowseSupplier.Text = "...";
            this.btnBrowseSupplier.UseVisualStyleBackColor = true;
            // 
            // cBoxCOA
            // 
            this.cBoxCOA.FormattingEnabled = true;
            this.cBoxCOA.Location = new System.Drawing.Point(115, 28);
            this.cBoxCOA.Name = "cBoxCOA";
            this.cBoxCOA.Size = new System.Drawing.Size(490, 21);
            this.cBoxCOA.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Report From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ledger Account";
            // 
            // frmGeneral_Ledger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 137);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.dt_To);
            this.Controls.Add(this.dt_From);
            this.Controls.Add(this.btnBrowseSupplier);
            this.Controls.Add(this.cBoxCOA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmGeneral_Ledger";
            this.Text = "General Ledger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGeneral_Ledger_FormClosed);
            this.Load += new System.EventHandler(this.frmGeneral_Ledger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.DateTimePicker dt_To;
        private System.Windows.Forms.DateTimePicker dt_From;
        private System.Windows.Forms.Button btnBrowseSupplier;
        private System.Windows.Forms.ComboBox cBoxCOA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}