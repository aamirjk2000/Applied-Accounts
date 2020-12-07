
namespace Applied_Accounts.Forms
{
    partial class frmVoucher_Delete
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
            this.cBoxVouNo = new System.Windows.Forms.ComboBox();
            this.Grid_Voucher = new System.Windows.Forms.DataGridView();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Voucher)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voucher No.";
            // 
            // cBoxVouNo
            // 
            this.cBoxVouNo.FormattingEnabled = true;
            this.cBoxVouNo.Location = new System.Drawing.Point(98, 28);
            this.cBoxVouNo.Name = "cBoxVouNo";
            this.cBoxVouNo.Size = new System.Drawing.Size(121, 21);
            this.cBoxVouNo.TabIndex = 1;
            this.cBoxVouNo.DropDownClosed += new System.EventHandler(this.cBoxVouNo_DropDownClosed);
            // 
            // Grid_Voucher
            // 
            this.Grid_Voucher.AllowUserToAddRows = false;
            this.Grid_Voucher.AllowUserToDeleteRows = false;
            this.Grid_Voucher.AllowUserToResizeRows = false;
            this.Grid_Voucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Voucher.Location = new System.Drawing.Point(28, 57);
            this.Grid_Voucher.Name = "Grid_Voucher";
            this.Grid_Voucher.ReadOnly = true;
            this.Grid_Voucher.Size = new System.Drawing.Size(760, 332);
            this.Grid_Voucher.TabIndex = 2;
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(16, 7);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 3;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Image = global::Applied_Accounts.Properties.Resources.Exit2;
            this.btnExit.Location = new System.Drawing.Point(760, 403);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(28, 35);
            this.btnExit.TabIndex = 5;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Applied_Accounts.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(239, 28);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnRename);
            this.panel1.Location = new System.Drawing.Point(28, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 38);
            this.panel1.TabIndex = 7;
            // 
            // frmVoucher_Delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.Grid_Voucher);
            this.Controls.Add(this.cBoxVouNo);
            this.Controls.Add(this.label1);
            this.Name = "frmVoucher_Delete";
            this.Text = "Voucher_Delete";
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Voucher)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxVouNo;
        private System.Windows.Forms.DataGridView Grid_Voucher;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
    }
}