
namespace Applied_Accounts.Forms
{
    partial class frmInventory
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
            this.Grid_Inventory = new System.Windows.Forms.DataGridView();
            this.panelRecord = new System.Windows.Forms.Panel();
            this.panelBotton = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUOM = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtVouNo = new System.Windows.Forms.TextBox();
            this.txtVouID = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDifference = new System.Windows.Forms.TextBox();
            this.txtGridAmount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panalBalance = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Inventory)).BeginInit();
            this.panelRecord.SuspendLayout();
            this.panelBotton.SuspendLayout();
            this.panalBalance.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid_Inventory
            // 
            this.Grid_Inventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Inventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Inventory.Location = new System.Drawing.Point(12, 12);
            this.Grid_Inventory.Name = "Grid_Inventory";
            this.Grid_Inventory.Size = new System.Drawing.Size(776, 224);
            this.Grid_Inventory.TabIndex = 3;
            this.Grid_Inventory.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Grid_Inventory_RowsAdded);
            this.Grid_Inventory.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.Grid_Inventory_UserAddedRow);
            this.Grid_Inventory.Enter += new System.EventHandler(this.Grid_Inventory_Enter);
            // 
            // panelRecord
            // 
            this.panelRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRecord.Controls.Add(this.panalBalance);
            this.panelRecord.Controls.Add(this.txtVouNo);
            this.panelRecord.Controls.Add(this.panelBotton);
            this.panelRecord.Controls.Add(this.label14);
            this.panelRecord.Controls.Add(this.txtUOM);
            this.panelRecord.Controls.Add(this.txtSize);
            this.panelRecord.Controls.Add(this.label13);
            this.panelRecord.Controls.Add(this.txtStock);
            this.panelRecord.Controls.Add(this.label2);
            this.panelRecord.Controls.Add(this.txtComments);
            this.panelRecord.Controls.Add(this.txtDescription);
            this.panelRecord.Controls.Add(this.txtAmount);
            this.panelRecord.Controls.Add(this.txtRate);
            this.panelRecord.Controls.Add(this.txtQty);
            this.panelRecord.Controls.Add(this.txtVouID);
            this.panelRecord.Controls.Add(this.txtID);
            this.panelRecord.Controls.Add(this.label9);
            this.panelRecord.Controls.Add(this.label8);
            this.panelRecord.Controls.Add(this.label7);
            this.panelRecord.Controls.Add(this.label6);
            this.panelRecord.Controls.Add(this.label5);
            this.panelRecord.Controls.Add(this.label4);
            this.panelRecord.Controls.Add(this.label3);
            this.panelRecord.Controls.Add(this.label1);
            this.panelRecord.Location = new System.Drawing.Point(12, 242);
            this.panelRecord.Name = "panelRecord";
            this.panelRecord.Size = new System.Drawing.Size(776, 183);
            this.panelRecord.TabIndex = 0;
            // 
            // panelBotton
            // 
            this.panelBotton.Controls.Add(this.btnNew);
            this.panelBotton.Controls.Add(this.btnLast);
            this.panelBotton.Controls.Add(this.btnNext);
            this.panelBotton.Controls.Add(this.btnSave);
            this.panelBotton.Controls.Add(this.btnCancel);
            this.panelBotton.Location = new System.Drawing.Point(511, 138);
            this.panelBotton.Name = "panelBotton";
            this.panelBotton.Size = new System.Drawing.Size(262, 32);
            this.panelBotton.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(82, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(60, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(5, 5);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(34, 23);
            this.btnLast.TabIndex = 1;
            this.btnLast.Text = "<";
            this.btnLast.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(42, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(49, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(205, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(132, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 53;
            this.label14.Text = "UOM";
            // 
            // txtUOM
            // 
            this.txtUOM.Location = new System.Drawing.Point(170, 69);
            this.txtUOM.Name = "txtUOM";
            this.txtUOM.Size = new System.Drawing.Size(47, 20);
            this.txtUOM.TabIndex = 7;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(395, 39);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(107, 20);
            this.txtSize.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(343, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = "Size";
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.White;
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtStock.Location = new System.Drawing.Point(69, 39);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(263, 20);
            this.txtStock.TabIndex = 4;
            this.txtStock.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Voucher Record ID";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(68, 130);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(434, 40);
            this.txtComments.TabIndex = 11;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(69, 102);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(433, 20);
            this.txtDescription.TabIndex = 10;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtAmount.Location = new System.Drawing.Point(387, 69);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(115, 20);
            this.txtAmount.TabIndex = 9;
            this.txtAmount.TabStop = false;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRate
            // 
            this.txtRate.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtRate.Location = new System.Drawing.Point(256, 69);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(76, 20);
            this.txtRate.TabIndex = 8;
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            this.txtRate.Leave += new System.EventHandler(this.txtRate_Leave);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(69, 69);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(57, 20);
            this.txtQty.TabIndex = 6;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            // 
            // txtVouNo
            // 
            this.txtVouNo.BackColor = System.Drawing.Color.White;
            this.txtVouNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVouNo.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtVouNo.Location = new System.Drawing.Point(395, 11);
            this.txtVouNo.Name = "txtVouNo";
            this.txtVouNo.ReadOnly = true;
            this.txtVouNo.Size = new System.Drawing.Size(107, 20);
            this.txtVouNo.TabIndex = 3;
            this.txtVouNo.TabStop = false;
            // 
            // txtVouID
            // 
            this.txtVouID.BackColor = System.Drawing.Color.White;
            this.txtVouID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVouID.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtVouID.Location = new System.Drawing.Point(256, 11);
            this.txtVouID.Name = "txtVouID";
            this.txtVouID.ReadOnly = true;
            this.txtVouID.Size = new System.Drawing.Size(76, 20);
            this.txtVouID.TabIndex = 2;
            this.txtVouID.TabStop = false;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtID.Location = new System.Drawing.Point(69, 11);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(76, 20);
            this.txtID.TabIndex = 1;
            this.txtID.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Comments";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Description";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Rate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Qty";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Vou No.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Record ID";
            // 
            // txtDifference
            // 
            this.txtDifference.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtDifference.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtDifference.Location = new System.Drawing.Point(123, 69);
            this.txtDifference.Name = "txtDifference";
            this.txtDifference.ReadOnly = true;
            this.txtDifference.Size = new System.Drawing.Size(134, 20);
            this.txtDifference.TabIndex = 3;
            // 
            // txtGridAmount
            // 
            this.txtGridAmount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtGridAmount.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtGridAmount.Location = new System.Drawing.Point(123, 39);
            this.txtGridAmount.Name = "txtGridAmount";
            this.txtGridAmount.ReadOnly = true;
            this.txtGridAmount.Size = new System.Drawing.Size(134, 20);
            this.txtGridAmount.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Difference";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Grid Total Amount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTotalAmount.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtTotalAmount.Location = new System.Drawing.Point(123, 11);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(134, 20);
            this.txtTotalAmount.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "Voucher Total Amount";
            // 
            // panalBalance
            // 
            this.panalBalance.Controls.Add(this.txtTotalAmount);
            this.panalBalance.Controls.Add(this.label10);
            this.panalBalance.Controls.Add(this.label11);
            this.panalBalance.Controls.Add(this.label12);
            this.panalBalance.Controls.Add(this.txtGridAmount);
            this.panalBalance.Controls.Add(this.txtDifference);
            this.panalBalance.Location = new System.Drawing.Point(511, 4);
            this.panalBalance.Name = "panalBalance";
            this.panalBalance.Size = new System.Drawing.Size(262, 129);
            this.panalBalance.TabIndex = 2;
            this.panalBalance.TabStop = true;
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 437);
            this.Controls.Add(this.Grid_Inventory);
            this.Controls.Add(this.panelRecord);
            this.Name = "frmInventory";
            this.Text = "Inventory";
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Inventory)).EndInit();
            this.panelRecord.ResumeLayout(false);
            this.panelRecord.PerformLayout();
            this.panelBotton.ResumeLayout(false);
            this.panalBalance.ResumeLayout(false);
            this.panalBalance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid_Inventory;
        private System.Windows.Forms.Panel panelRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.TextBox txtDifference;
        private System.Windows.Forms.TextBox txtGridAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtVouNo;
        private System.Windows.Forms.TextBox txtVouID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panelBotton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtUOM;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panalBalance;
    }
}