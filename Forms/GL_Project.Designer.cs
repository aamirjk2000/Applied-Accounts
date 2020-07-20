namespace Applied_Accounts.Forms
{
    partial class frmGL_Project
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cBoxProjects = new System.Windows.Forms.ComboBox();
            this.cBoxSuppliers = new System.Windows.Forms.ComboBox();
            this.cBoxCOA = new System.Windows.Forms.ComboBox();
            this.cBoxUnits = new System.Windows.Forms.ComboBox();
            this.chkSuppliers = new System.Windows.Forms.CheckBox();
            this.chkCOA = new System.Windows.Forms.CheckBox();
            this.chkUnits = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cBoxReportFormat = new System.Windows.Forms.ComboBox();
            this.dt_From = new System.Windows.Forms.DateTimePicker();
            this.dt_To = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Supplier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Account";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Unit";
            // 
            // cBoxProjects
            // 
            this.cBoxProjects.FormattingEnabled = true;
            this.cBoxProjects.Location = new System.Drawing.Point(112, 30);
            this.cBoxProjects.Name = "cBoxProjects";
            this.cBoxProjects.Size = new System.Drawing.Size(421, 21);
            this.cBoxProjects.TabIndex = 4;
            // 
            // cBoxSuppliers
            // 
            this.cBoxSuppliers.FormattingEnabled = true;
            this.cBoxSuppliers.Location = new System.Drawing.Point(112, 58);
            this.cBoxSuppliers.Name = "cBoxSuppliers";
            this.cBoxSuppliers.Size = new System.Drawing.Size(421, 21);
            this.cBoxSuppliers.TabIndex = 5;
            // 
            // cBoxCOA
            // 
            this.cBoxCOA.FormattingEnabled = true;
            this.cBoxCOA.Location = new System.Drawing.Point(112, 86);
            this.cBoxCOA.Name = "cBoxCOA";
            this.cBoxCOA.Size = new System.Drawing.Size(421, 21);
            this.cBoxCOA.TabIndex = 6;
            // 
            // cBoxUnits
            // 
            this.cBoxUnits.FormattingEnabled = true;
            this.cBoxUnits.Location = new System.Drawing.Point(112, 114);
            this.cBoxUnits.Name = "cBoxUnits";
            this.cBoxUnits.Size = new System.Drawing.Size(421, 21);
            this.cBoxUnits.TabIndex = 7;
            // 
            // chkSuppliers
            // 
            this.chkSuppliers.AutoSize = true;
            this.chkSuppliers.Location = new System.Drawing.Point(548, 59);
            this.chkSuppliers.Name = "chkSuppliers";
            this.chkSuppliers.Size = new System.Drawing.Size(83, 17);
            this.chkSuppliers.TabIndex = 8;
            this.chkSuppliers.Text = "All Suppliers";
            this.chkSuppliers.UseVisualStyleBackColor = true;
            // 
            // chkCOA
            // 
            this.chkCOA.AutoSize = true;
            this.chkCOA.Location = new System.Drawing.Point(548, 86);
            this.chkCOA.Name = "chkCOA";
            this.chkCOA.Size = new System.Drawing.Size(85, 17);
            this.chkCOA.TabIndex = 9;
            this.chkCOA.Text = "All Accounts";
            this.chkCOA.UseVisualStyleBackColor = true;
            // 
            // chkUnits
            // 
            this.chkUnits.AutoSize = true;
            this.chkUnits.Location = new System.Drawing.Point(548, 114);
            this.chkUnits.Name = "chkUnits";
            this.chkUnits.Size = new System.Drawing.Size(64, 17);
            this.chkUnits.TabIndex = 10;
            this.chkUnits.Text = "All Units";
            this.chkUnits.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Report Format";
            // 
            // cBoxReportFormat
            // 
            this.cBoxReportFormat.FormattingEnabled = true;
            this.cBoxReportFormat.Items.AddRange(new object[] {
            "Project Ledger",
            "Group by Supplier",
            "Group by Accounts",
            "Group by Units"});
            this.cBoxReportFormat.Location = new System.Drawing.Point(112, 141);
            this.cBoxReportFormat.Name = "cBoxReportFormat";
            this.cBoxReportFormat.Size = new System.Drawing.Size(421, 21);
            this.cBoxReportFormat.TabIndex = 12;
            // 
            // dt_From
            // 
            this.dt_From.CustomFormat = "dd-MMM-yyyy";
            this.dt_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_From.Location = new System.Drawing.Point(112, 182);
            this.dt_From.Name = "dt_From";
            this.dt_From.Size = new System.Drawing.Size(107, 20);
            this.dt_From.TabIndex = 13;
            // 
            // dt_To
            // 
            this.dt_To.CustomFormat = "dd-MMM-yyyy";
            this.dt_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_To.Location = new System.Drawing.Point(333, 182);
            this.dt_To.Name = "dt_To";
            this.dt_To.Size = new System.Drawing.Size(107, 20);
            this.dt_To.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Report From";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(253, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "to Date";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(112, 243);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 17;
            this.btnPreview.Text = "PREVIEW";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(458, 234);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmGL_Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 293);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dt_To);
            this.Controls.Add(this.dt_From);
            this.Controls.Add(this.cBoxReportFormat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkUnits);
            this.Controls.Add(this.chkCOA);
            this.Controls.Add(this.chkSuppliers);
            this.Controls.Add(this.cBoxUnits);
            this.Controls.Add(this.cBoxCOA);
            this.Controls.Add(this.cBoxSuppliers);
            this.Controls.Add(this.cBoxProjects);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmGL_Project";
            this.Text = "General Ledger - Project";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGL_Project_FormClosed);
            this.Load += new System.EventHandler(this.GL_Project_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBoxProjects;
        private System.Windows.Forms.ComboBox cBoxSuppliers;
        private System.Windows.Forms.ComboBox cBoxCOA;
        private System.Windows.Forms.ComboBox cBoxUnits;
        private System.Windows.Forms.CheckBox chkSuppliers;
        private System.Windows.Forms.CheckBox chkCOA;
        private System.Windows.Forms.CheckBox chkUnits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBoxReportFormat;
        private System.Windows.Forms.DateTimePicker dt_From;
        private System.Windows.Forms.DateTimePicker dt_To;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnExit;
    }
}