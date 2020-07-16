namespace Applied_Accounts
{
    partial class frmCOA
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
            this.Pages = new System.Windows.Forms.TabControl();
            this.P1 = new System.Windows.Forms.TabPage();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.TitleNotes = new System.Windows.Forms.TextBox();
            this.txtCode = new Applied_Accounts.MyTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSCode = new System.Windows.Forms.TextBox();
            this.chkCash = new System.Windows.Forms.CheckBox();
            this.chkBank = new System.Windows.Forms.CheckBox();
            this.MyNavigator = new Applied_Accounts.Navigator();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOBal = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.P2 = new System.Windows.Forms.TabPage();
            this.DataGrid_COA = new Applied_Accounts.AppliedDataGrid();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
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
            this.Pages.Size = new System.Drawing.Size(714, 429);
            this.Pages.TabIndex = 0;
            // 
            // P1
            // 
            this.P1.Controls.Add(this.txtNote);
            this.P1.Controls.Add(this.TitleNotes);
            this.P1.Controls.Add(this.txtCode);
            this.P1.Controls.Add(this.label5);
            this.P1.Controls.Add(this.txtSCode);
            this.P1.Controls.Add(this.chkCash);
            this.P1.Controls.Add(this.chkBank);
            this.P1.Controls.Add(this.MyNavigator);
            this.P1.Controls.Add(this.label4);
            this.P1.Controls.Add(this.txtOBal);
            this.P1.Controls.Add(this.txtTitle);
            this.P1.Controls.Add(this.txtID);
            this.P1.Controls.Add(this.label3);
            this.P1.Controls.Add(this.label2);
            this.P1.Controls.Add(this.lblTitle);
            this.P1.Controls.Add(this.label1);
            this.P1.Location = new System.Drawing.Point(4, 22);
            this.P1.Name = "P1";
            this.P1.Padding = new System.Windows.Forms.Padding(3);
            this.P1.Size = new System.Drawing.Size(706, 403);
            this.P1.TabIndex = 0;
            this.P1.Text = "Record";
            this.P1.UseVisualStyleBackColor = true;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(122, 107);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(100, 20);
            this.txtNote.TabIndex = 8;
            this.txtNote.Validating += new System.ComponentModel.CancelEventHandler(this.txtNote_Validating);
            // 
            // TitleNotes
            // 
            this.TitleNotes.Location = new System.Drawing.Point(231, 107);
            this.TitleNotes.Name = "TitleNotes";
            this.TitleNotes.ReadOnly = true;
            this.TitleNotes.Size = new System.Drawing.Size(241, 20);
            this.TitleNotes.TabIndex = 18;
            // 
            // txtCode
            // 
            this.txtCode.Allowe_Duplicate = false;
            this.txtCode.Allowed_Chars = "0123456789-";
            this.txtCode.ColumnName = "Code";
            this.txtCode.Location = new System.Drawing.Point(122, 55);
            this.txtCode.MaxDigit = 6;
            this.txtCode.MyDataView = null;
            this.txtCode.MyMessage = null;
            this.txtCode.MyRow = null;
            this.txtCode.Name = "txtCode";
            this.txtCode.PrimaryKey = "ID";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 5;
            this.txtCode.thisColor = System.Drawing.SystemColors.WindowText;
            this.txtCode.Get_Row += new System.EventHandler(this.MyCode_Get_Row);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tag";
            // 
            // txtSCode
            // 
            this.txtSCode.Location = new System.Drawing.Point(260, 55);
            this.txtSCode.Name = "txtSCode";
            this.txtSCode.Size = new System.Drawing.Size(100, 20);
            this.txtSCode.TabIndex = 6;
            // 
            // chkCash
            // 
            this.chkCash.AutoSize = true;
            this.chkCash.Location = new System.Drawing.Point(122, 191);
            this.chkCash.Name = "chkCash";
            this.chkCash.Size = new System.Drawing.Size(122, 17);
            this.chkCash.TabIndex = 11;
            this.chkCash.Text = "Is It Cash Account ?";
            this.chkCash.UseVisualStyleBackColor = true;
            // 
            // chkBank
            // 
            this.chkBank.AutoSize = true;
            this.chkBank.Location = new System.Drawing.Point(122, 168);
            this.chkBank.Name = "chkBank";
            this.chkBank.Size = new System.Drawing.Size(122, 17);
            this.chkBank.TabIndex = 10;
            this.chkBank.Text = "Is it Bank Account ?";
            this.chkBank.UseVisualStyleBackColor = true;
            // 
            // MyNavigator
            // 
            this.MyNavigator.Location = new System.Drawing.Point(106, 363);
            this.MyNavigator.Name = "MyNavigator";
            this.MyNavigator.Size = new System.Drawing.Size(454, 25);
            this.MyNavigator.TabIndex = 12;
            this.MyNavigator.Get_Values += new System.EventHandler(this.MyNavigator_Get_Values);
            this.MyNavigator.Set_Values += new System.EventHandler(this.MyNavigator_Set_Values);
            this.MyNavigator.New_Record += new System.EventHandler(this.MyNavigator_New_Record);
            //this.MyNavigator.Before_Save += new System.EventHandler(this.MyNavigator_Before_Save);
            this.MyNavigator.After_Save += new System.EventHandler(this.MyNavigator_After_Save);
            this.MyNavigator.After_Delete += new System.EventHandler(this.MyNavigator_After_Delete);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Record ID";
            // 
            // txtOBal
            // 
            this.txtOBal.Location = new System.Drawing.Point(122, 133);
            this.txtOBal.Name = "txtOBal";
            this.txtOBal.Size = new System.Drawing.Size(100, 20);
            this.txtOBal.TabIndex = 9;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(122, 81);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(350, 20);
            this.txtTitle.TabIndex = 7;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(122, 27);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Opening Balance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Notes";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 84);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code";
            // 
            // P2
            // 
            this.P2.Controls.Add(this.DataGrid_COA);
            this.P2.Location = new System.Drawing.Point(4, 22);
            this.P2.Name = "P2";
            this.P2.Padding = new System.Windows.Forms.Padding(3);
            this.P2.Size = new System.Drawing.Size(706, 403);
            this.P2.TabIndex = 1;
            this.P2.Text = "List";
            this.P2.UseVisualStyleBackColor = true;
            // 
            // DataGrid_COA
            // 
            this.DataGrid_COA.Active = false;
            this.DataGrid_COA.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataGrid_COA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataGrid_COA.ColumnsFormat = null;
            this.DataGrid_COA.ColumnsName = null;
            this.DataGrid_COA.ColumnsVisiable = null;
            this.DataGrid_COA.ColumnsWidth = null;
            this.DataGrid_COA.IsBrowseWin = false;
            this.DataGrid_COA.IsPressEnter = false;
            this.DataGrid_COA.Location = new System.Drawing.Point(6, 6);
            this.DataGrid_COA.MyDataRow = null;
            this.DataGrid_COA.MyDataView = null;
            this.DataGrid_COA.Name = "DataGrid_COA";
            this.DataGrid_COA.RecordID = ((long)(0));
            this.DataGrid_COA.Size = new System.Drawing.Size(694, 391);
            this.DataGrid_COA.TabIndex = 1;
            this.DataGrid_COA.Load += new System.EventHandler(this.DataGrid_COA_Load);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(641, 453);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(13, 463);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 13;
            this.lblMessage.Text = "Message";
            // 
            // frmCOA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 488);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.Pages);
            this.Name = "frmCOA";
            this.Text = "COA";
            this.Load += new System.EventHandler(this.COA_Load);
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
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtOBal;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMessage;
        private Navigator MyNavigator;
        private System.Windows.Forms.CheckBox chkCash;
        private System.Windows.Forms.CheckBox chkBank;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSCode;
        private AppliedDataGrid DataGrid_COA;
        private MyTextBox txtCode;
        private System.Windows.Forms.TextBox TitleNotes;
        private System.Windows.Forms.TextBox txtNote;
    }
}