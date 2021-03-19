namespace Applied_Accounts.Forms
{
    partial class frmGL_Supplier
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
            this.cBoxSuppliers = new System.Windows.Forms.ComboBox();
            this.cBoxCOA = new System.Windows.Forms.ComboBox();
            this.cBoxProjects = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cBoxUnits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dt_From = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dt_To = new System.Windows.Forms.DateTimePicker();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnProject = new System.Windows.Forms.Button();
            this.btnUnit = new System.Windows.Forms.Button();
            this.chkUnit = new System.Windows.Forms.CheckBox();
            this.chkProject = new System.Windows.Forms.CheckBox();
            this.chkCOA = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cBoxSuppliers
            // 
            this.cBoxSuppliers.FormattingEnabled = true;
            this.cBoxSuppliers.Location = new System.Drawing.Point(128, 51);
            this.cBoxSuppliers.Name = "cBoxSuppliers";
            this.cBoxSuppliers.Size = new System.Drawing.Size(373, 21);
            this.cBoxSuppliers.TabIndex = 3;
            // 
            // cBoxCOA
            // 
            this.cBoxCOA.FormattingEnabled = true;
            this.cBoxCOA.Location = new System.Drawing.Point(128, 78);
            this.cBoxCOA.Name = "cBoxCOA";
            this.cBoxCOA.Size = new System.Drawing.Size(373, 21);
            this.cBoxCOA.TabIndex = 4;
            // 
            // cBoxProjects
            // 
            this.cBoxProjects.FormattingEnabled = true;
            this.cBoxProjects.Location = new System.Drawing.Point(128, 108);
            this.cBoxProjects.Name = "cBoxProjects";
            this.cBoxProjects.Size = new System.Drawing.Size(373, 21);
            this.cBoxProjects.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Supplier / Vendor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ledger Account";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Project";
            // 
            // cBoxUnits
            // 
            this.cBoxUnits.FormattingEnabled = true;
            this.cBoxUnits.Location = new System.Drawing.Point(128, 139);
            this.cBoxUnits.Name = "cBoxUnits";
            this.cBoxUnits.Size = new System.Drawing.Size(373, 21);
            this.cBoxUnits.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Unit in Project";
            // 
            // dt_From
            // 
            this.dt_From.CustomFormat = "dd-MMM-yyyy";
            this.dt_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_From.Location = new System.Drawing.Point(129, 18);
            this.dt_From.Name = "dt_From";
            this.dt_From.Size = new System.Drawing.Size(105, 20);
            this.dt_From.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Report From";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "To";
            // 
            // dt_To
            // 
            this.dt_To.CustomFormat = "dd-MMM-yyyy";
            this.dt_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_To.Location = new System.Drawing.Point(291, 18);
            this.dt_To.Name = "dt_To";
            this.dt_To.Size = new System.Drawing.Size(105, 20);
            this.dt_To.TabIndex = 2;
            // 
            // btnPreview
            // 
            this.btnPreview.Image = global::Applied_Accounts.Properties.Resources.PRINT;
            this.btnPreview.Location = new System.Drawing.Point(471, 179);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(30, 30);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::Applied_Accounts.Properties.Resources.Exit2;
            this.btnExit.Location = new System.Drawing.Point(509, 179);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 8;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Location = new System.Drawing.Point(507, 51);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(32, 23);
            this.btnSupplier.TabIndex = 14;
            this.btnSupplier.Text = "...";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(507, 78);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(32, 23);
            this.btnAccount.TabIndex = 15;
            this.btnAccount.Text = "...";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnProject
            // 
            this.btnProject.Location = new System.Drawing.Point(507, 108);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(32, 23);
            this.btnProject.TabIndex = 16;
            this.btnProject.Text = "...";
            this.btnProject.UseVisualStyleBackColor = true;
            this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
            // 
            // btnUnit
            // 
            this.btnUnit.Location = new System.Drawing.Point(507, 139);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.Size = new System.Drawing.Size(32, 23);
            this.btnUnit.TabIndex = 17;
            this.btnUnit.Text = "...";
            this.btnUnit.UseVisualStyleBackColor = true;
            this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // chkUnit
            // 
            this.chkUnit.AutoSize = true;
            this.chkUnit.Location = new System.Drawing.Point(545, 141);
            this.chkUnit.Name = "chkUnit";
            this.chkUnit.Size = new System.Drawing.Size(45, 17);
            this.chkUnit.TabIndex = 11;
            this.chkUnit.TabStop = false;
            this.chkUnit.Text = "ALL";
            this.chkUnit.UseVisualStyleBackColor = true;
            // 
            // chkProject
            // 
            this.chkProject.AutoSize = true;
            this.chkProject.Location = new System.Drawing.Point(545, 110);
            this.chkProject.Name = "chkProject";
            this.chkProject.Size = new System.Drawing.Size(45, 17);
            this.chkProject.TabIndex = 10;
            this.chkProject.TabStop = false;
            this.chkProject.Text = "ALL";
            this.chkProject.UseVisualStyleBackColor = true;
            // 
            // chkCOA
            // 
            this.chkCOA.AutoSize = true;
            this.chkCOA.Location = new System.Drawing.Point(545, 82);
            this.chkCOA.Name = "chkCOA";
            this.chkCOA.Size = new System.Drawing.Size(45, 17);
            this.chkCOA.TabIndex = 9;
            this.chkCOA.TabStop = false;
            this.chkCOA.Text = "ALL";
            this.chkCOA.UseVisualStyleBackColor = true;
            // 
            // frmGL_Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 225);
            this.Controls.Add(this.chkCOA);
            this.Controls.Add(this.chkProject);
            this.Controls.Add(this.chkUnit);
            this.Controls.Add(this.btnUnit);
            this.Controls.Add(this.btnProject);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.dt_To);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dt_From);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cBoxUnits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cBoxProjects);
            this.Controls.Add(this.cBoxCOA);
            this.Controls.Add(this.cBoxSuppliers);
            this.Name = "frmGL_Supplier";
            this.Text = "General Ledger (Supplier)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGL_Supplier_FormClosed);
            this.Load += new System.EventHandler(this.frmGL_Supplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxSuppliers;
        private System.Windows.Forms.ComboBox cBoxCOA;
        private System.Windows.Forms.ComboBox cBoxProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxUnits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dt_From;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dt_To;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnProject;
        private System.Windows.Forms.Button btnUnit;
        private System.Windows.Forms.CheckBox chkUnit;
        private System.Windows.Forms.CheckBox chkProject;
        private System.Windows.Forms.CheckBox chkCOA;
    }
}