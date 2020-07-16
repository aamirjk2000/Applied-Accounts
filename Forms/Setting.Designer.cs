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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(113, 25);
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
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fiscal Year Start from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fiscal Year End on";
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}