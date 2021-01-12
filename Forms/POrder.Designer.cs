
namespace Applied_Accounts.Forms
{
    partial class frmPOrder
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
            this.components = new System.ComponentModel.Container();
            this.Pages = new System.Windows.Forms.TabControl();
            this.P1 = new System.Windows.Forms.TabPage();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.MyNavigator = new Applied_Accounts.Navigator();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cBoxSuppliers = new System.Windows.Forms.ComboBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.dtPODate = new System.Windows.Forms.DateTimePicker();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.P2 = new System.Windows.Forms.TabPage();
            this.MyDataGrid = new Applied_Accounts.AppliedDataGrid();
            this.btnExit = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textNum1 = new Applied_Accounts.Components.TextNum(this.components);
            this.txtAmount2 = new Applied_Accounts.MyTextBox();
            this.Pages.SuspendLayout();
            this.P1.SuspendLayout();
            this.P2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pages
            // 
            this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pages.Controls.Add(this.P1);
            this.Pages.Controls.Add(this.P2);
            this.Pages.Location = new System.Drawing.Point(12, 12);
            this.Pages.Name = "Pages";
            this.Pages.SelectedIndex = 0;
            this.Pages.Size = new System.Drawing.Size(641, 335);
            this.Pages.TabIndex = 0;
            // 
            // P1
            // 
            this.P1.Controls.Add(this.txtAmount2);
            this.P1.Controls.Add(this.chkActive);
            this.P1.Controls.Add(this.MyNavigator);
            this.P1.Controls.Add(this.txtRemarks);
            this.P1.Controls.Add(this.txtAmount);
            this.P1.Controls.Add(this.btnBrowse);
            this.P1.Controls.Add(this.cBoxSuppliers);
            this.P1.Controls.Add(this.txtSupplier);
            this.P1.Controls.Add(this.txtTitle);
            this.P1.Controls.Add(this.dtPODate);
            this.P1.Controls.Add(this.txtTag);
            this.P1.Controls.Add(this.txtCode);
            this.P1.Controls.Add(this.txtID);
            this.P1.Controls.Add(this.label8);
            this.P1.Controls.Add(this.label7);
            this.P1.Controls.Add(this.label6);
            this.P1.Controls.Add(this.label5);
            this.P1.Controls.Add(this.label4);
            this.P1.Controls.Add(this.label3);
            this.P1.Controls.Add(this.label2);
            this.P1.Controls.Add(this.label1);
            this.P1.Location = new System.Drawing.Point(4, 22);
            this.P1.Name = "P1";
            this.P1.Padding = new System.Windows.Forms.Padding(3);
            this.P1.Size = new System.Drawing.Size(633, 309);
            this.P1.TabIndex = 0;
            this.P1.Text = "Record";
            this.P1.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(92, 188);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 19;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // MyNavigator
            // 
            this.MyNavigator.Current_Mode = 0;
            this.MyNavigator.Location = new System.Drawing.Point(34, 267);
            this.MyNavigator.Name = "MyNavigator";
            this.MyNavigator.Size = new System.Drawing.Size(569, 24);
            this.MyNavigator.TabIndex = 18;
            this.MyNavigator.New_Record += new System.EventHandler(this.MyNavigator_New_Record);
            this.MyNavigator.Before_Save += new System.EventHandler(this.MyNavigator_Before_Save);
            this.MyNavigator.After_Save += new System.EventHandler(this.MyNavigator_After_Save);
            this.MyNavigator.After_Delete += new System.EventHandler(this.MyNavigator_After_Delete);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(92, 129);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(524, 52);
            this.txtRemarks.TabIndex = 18;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(92, 103);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 16;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(593, 74);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(23, 23);
            this.btnBrowse.TabIndex = 15;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cBoxSuppliers
            // 
            this.cBoxSuppliers.FormattingEnabled = true;
            this.cBoxSuppliers.Location = new System.Drawing.Point(198, 76);
            this.cBoxSuppliers.Name = "cBoxSuppliers";
            this.cBoxSuppliers.Size = new System.Drawing.Size(389, 21);
            this.cBoxSuppliers.TabIndex = 14;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(92, 77);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(100, 20);
            this.txtSupplier.TabIndex = 13;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(92, 51);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(495, 20);
            this.txtTitle.TabIndex = 12;
            // 
            // dtPODate
            // 
            this.dtPODate.CustomFormat = "dd MMM yyyy";
            this.dtPODate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPODate.Location = new System.Drawing.Point(516, 25);
            this.dtPODate.Name = "dtPODate";
            this.dtPODate.Size = new System.Drawing.Size(100, 20);
            this.dtPODate.TabIndex = 11;
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(374, 25);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(100, 20);
            this.txtTag.TabIndex = 10;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(236, 25);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 9;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(92, 25);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Remarks";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Supplier";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Title";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tag";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // P2
            // 
            this.P2.Controls.Add(this.MyDataGrid);
            this.P2.Location = new System.Drawing.Point(4, 22);
            this.P2.Name = "P2";
            this.P2.Padding = new System.Windows.Forms.Padding(3);
            this.P2.Size = new System.Drawing.Size(633, 309);
            this.P2.TabIndex = 1;
            this.P2.Text = "List";
            this.P2.UseVisualStyleBackColor = true;
            // 
            // MyDataGrid
            // 
            this.MyDataGrid.Active = false;
            this.MyDataGrid.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MyDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MyDataGrid.ColumnsFormat = null;
            this.MyDataGrid.ColumnsName = null;
            this.MyDataGrid.ColumnsVisiable = null;
            this.MyDataGrid.ColumnsWidth = null;
            this.MyDataGrid.IsBrowseWin = false;
            this.MyDataGrid.IsPressEnter = false;
            this.MyDataGrid.Location = new System.Drawing.Point(6, 7);
            this.MyDataGrid.MyDataRow = null;
            this.MyDataGrid.MyDataView = null;
            this.MyDataGrid.MyViewRow = null;
            this.MyDataGrid.Name = "MyDataGrid";
            this.MyDataGrid.RecordID = ((long)(0));
            this.MyDataGrid.Size = new System.Drawing.Size(621, 293);
            this.MyDataGrid.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = global::Applied_Accounts.Properties.Resources.Exit2;
            this.btnExit.Location = new System.Drawing.Point(619, 353);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 1;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "label9";
            // 
            // txtAmount2
            // 
            this.txtAmount2.Allowe_Duplicate = false;
            this.txtAmount2.Allowed_Chars = "0123456789-";
            this.txtAmount2.ColumnName = "Code";
            this.txtAmount2.Location = new System.Drawing.Point(198, 103);
            this.txtAmount2.MaxDigit = 0;
            this.txtAmount2.Mode_Add = false;
            this.txtAmount2.Mode_Delete = false;
            this.txtAmount2.Mode_Edit = false;
            this.txtAmount2.MyDataView = null;
            this.txtAmount2.MyMessage = null;
            this.txtAmount2.MyRow = null;
            this.txtAmount2.Name = "txtAmount2";
            this.txtAmount2.PrimaryKey = "ID";
            this.txtAmount2.Size = new System.Drawing.Size(100, 20);
            this.txtAmount2.TabIndex = 17;
            this.txtAmount2.Text_Mode = 0;
            this.txtAmount2.thisColor = System.Drawing.SystemColors.WindowText;
            // 
            // frmPOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 387);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.Pages);
            this.Name = "frmPOrder";
            this.Text = "POrder";
            this.Pages.ResumeLayout(false);
            this.P1.ResumeLayout(false);
            this.P1.PerformLayout();
            this.P2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Pages;
        private System.Windows.Forms.TabPage P1;
        private System.Windows.Forms.TabPage P2;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cBoxSuppliers;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.DateTimePicker dtPODate;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label9;
        private Navigator MyNavigator;
        private AppliedDataGrid MyDataGrid;
        private System.Windows.Forms.CheckBox chkActive;
        private Components.TextNum textNum1;
        private MyTextBox txtAmount2;
    }
}