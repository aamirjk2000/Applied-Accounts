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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUnit = new System.Windows.Forms.CheckBox();
            this.chkProject = new System.Windows.Forms.CheckBox();
            this.chkCOA = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBoxSuppliers
            // 
            this.cBoxSuppliers.FormattingEnabled = true;
            this.cBoxSuppliers.Location = new System.Drawing.Point(128, 27);
            this.cBoxSuppliers.Name = "cBoxSuppliers";
            this.cBoxSuppliers.Size = new System.Drawing.Size(373, 21);
            this.cBoxSuppliers.TabIndex = 0;
            // 
            // cBoxCOA
            // 
            this.cBoxCOA.FormattingEnabled = true;
            this.cBoxCOA.Location = new System.Drawing.Point(128, 54);
            this.cBoxCOA.Name = "cBoxCOA";
            this.cBoxCOA.Size = new System.Drawing.Size(373, 21);
            this.cBoxCOA.TabIndex = 1;
            // 
            // cBoxProjects
            // 
            this.cBoxProjects.FormattingEnabled = true;
            this.cBoxProjects.Location = new System.Drawing.Point(128, 84);
            this.cBoxProjects.Name = "cBoxProjects";
            this.cBoxProjects.Size = new System.Drawing.Size(373, 21);
            this.cBoxProjects.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Supplier / Vendor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ledger Account";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Project";
            // 
            // cBoxUnits
            // 
            this.cBoxUnits.FormattingEnabled = true;
            this.cBoxUnits.Location = new System.Drawing.Point(128, 115);
            this.cBoxUnits.Name = "cBoxUnits";
            this.cBoxUnits.Size = new System.Drawing.Size(373, 21);
            this.cBoxUnits.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Unit in Project";
            // 
            // dt_From
            // 
            this.dt_From.CustomFormat = "dd-MMM-yyyy";
            this.dt_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_From.Location = new System.Drawing.Point(130, 150);
            this.dt_From.Name = "dt_From";
            this.dt_From.Size = new System.Drawing.Size(105, 20);
            this.dt_From.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Report From";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "To";
            // 
            // dt_To
            // 
            this.dt_To.CustomFormat = "dd-MMM-yyyy";
            this.dt_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_To.Location = new System.Drawing.Point(291, 150);
            this.dt_To.Name = "dt_To";
            this.dt_To.Size = new System.Drawing.Size(105, 20);
            this.dt_To.TabIndex = 11;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(130, 242);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 12;
            this.btnPreview.Text = "PREVIEW";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(464, 242);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(507, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(507, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(507, 84);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(507, 115);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUnit);
            this.groupBox1.Controls.Add(this.chkProject);
            this.groupBox1.Controls.Add(this.chkCOA);
            this.groupBox1.Location = new System.Drawing.Point(130, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 45);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Include in Report";
            // 
            // chkUnit
            // 
            this.chkUnit.AutoSize = true;
            this.chkUnit.Location = new System.Drawing.Point(258, 19);
            this.chkUnit.Name = "chkUnit";
            this.chkUnit.Size = new System.Drawing.Size(86, 17);
            this.chkUnit.TabIndex = 2;
            this.chkUnit.Text = "Project Units";
            this.chkUnit.UseVisualStyleBackColor = true;
            // 
            // chkProject
            // 
            this.chkProject.AutoSize = true;
            this.chkProject.Location = new System.Drawing.Point(161, 19);
            this.chkProject.Name = "chkProject";
            this.chkProject.Size = new System.Drawing.Size(59, 17);
            this.chkProject.TabIndex = 1;
            this.chkProject.Text = "Project";
            this.chkProject.UseVisualStyleBackColor = true;
            // 
            // chkCOA
            // 
            this.chkCOA.AutoSize = true;
            this.chkCOA.Location = new System.Drawing.Point(39, 19);
            this.chkCOA.Name = "chkCOA";
            this.chkCOA.Size = new System.Drawing.Size(102, 17);
            this.chkCOA.TabIndex = 0;
            this.chkCOA.Text = "Ledger Account";
            this.chkCOA.UseVisualStyleBackColor = true;
            // 
            // frmGL_Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 281);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkUnit;
        private System.Windows.Forms.CheckBox chkProject;
        private System.Windows.Forms.CheckBox chkCOA;
    }
}