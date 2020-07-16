namespace Applied_Accounts
{
    partial class frmAccNotes
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtSCode = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.TitleType = new System.Windows.Forms.TextBox();
            this.Pages = new System.Windows.Forms.TabControl();
            this.P1 = new System.Windows.Forms.TabPage();
            this.P2 = new System.Windows.Forms.TabPage();
            this.DataGrid_Notes = new Applied_Accounts.AppliedDataGrid();
            this.MyNavigator = new Applied_Accounts.Navigator();
            this.Pages.SuspendLayout();
            this.P1.SuspendLayout();
            this.P2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tag";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Acc Type";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(83, 26);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 6;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(83, 64);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 7;
            this.txtCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCode_Validating);
            // 
            // txtSCode
            // 
            this.txtSCode.Location = new System.Drawing.Point(232, 61);
            this.txtSCode.Name = "txtSCode";
            this.txtSCode.Size = new System.Drawing.Size(100, 20);
            this.txtSCode.TabIndex = 8;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(83, 96);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(421, 20);
            this.txtTitle.TabIndex = 9;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(83, 131);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(100, 20);
            this.txtType.TabIndex = 10;
            this.txtType.Validating += new System.ComponentModel.CancelEventHandler(this.txtType_Validating);
            // 
            // TitleType
            // 
            this.TitleType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleType.Location = new System.Drawing.Point(192, 131);
            this.TitleType.Name = "TitleType";
            this.TitleType.ReadOnly = true;
            this.TitleType.Size = new System.Drawing.Size(312, 20);
            this.TitleType.TabIndex = 11;
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
            this.Pages.Size = new System.Drawing.Size(533, 383);
            this.Pages.TabIndex = 12;
            // 
            // P1
            // 
            this.P1.Controls.Add(this.TitleType);
            this.P1.Controls.Add(this.MyNavigator);
            this.P1.Controls.Add(this.label1);
            this.P1.Controls.Add(this.txtType);
            this.P1.Controls.Add(this.label2);
            this.P1.Controls.Add(this.txtTitle);
            this.P1.Controls.Add(this.label3);
            this.P1.Controls.Add(this.txtSCode);
            this.P1.Controls.Add(this.label4);
            this.P1.Controls.Add(this.txtCode);
            this.P1.Controls.Add(this.label5);
            this.P1.Controls.Add(this.txtID);
            this.P1.Location = new System.Drawing.Point(4, 22);
            this.P1.Name = "P1";
            this.P1.Padding = new System.Windows.Forms.Padding(3);
            this.P1.Size = new System.Drawing.Size(525, 357);
            this.P1.TabIndex = 0;
            this.P1.Text = "Record";
            this.P1.UseVisualStyleBackColor = true;
            // 
            // P2
            // 
            this.P2.Controls.Add(this.DataGrid_Notes);
            this.P2.Location = new System.Drawing.Point(4, 22);
            this.P2.Name = "P2";
            this.P2.Padding = new System.Windows.Forms.Padding(3);
            this.P2.Size = new System.Drawing.Size(525, 357);
            this.P2.TabIndex = 1;
            this.P2.Text = "List";
            this.P2.UseVisualStyleBackColor = true;
            // 
            // DataGrid_Notes
            // 
            this.DataGrid_Notes.Active = false;
            this.DataGrid_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid_Notes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataGrid_Notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataGrid_Notes.ColumnsFormat = null;
            this.DataGrid_Notes.ColumnsName = null;
            this.DataGrid_Notes.ColumnsVisiable = null;
            this.DataGrid_Notes.ColumnsWidth = null;
            this.DataGrid_Notes.IsBrowseWin = false;
            this.DataGrid_Notes.IsPressEnter = false;
            this.DataGrid_Notes.Location = new System.Drawing.Point(3, 3);
            this.DataGrid_Notes.MyDataRow = null;
            this.DataGrid_Notes.MyDataView = null;
            this.DataGrid_Notes.Name = "DataGrid_Notes";
            this.DataGrid_Notes.RecordID = ((long)(0));
            this.DataGrid_Notes.Size = new System.Drawing.Size(516, 351);
            this.DataGrid_Notes.TabIndex = 0;
            this.DataGrid_Notes.Load += new System.EventHandler(this.DataGrid_Notes_Load);
            this.DataGrid_Notes.Leave += new System.EventHandler(this.DataGrid_Notes_Leave);
            // 
            // MyNavigator
            // 
            this.MyNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MyNavigator.Location = new System.Drawing.Point(42, 320);
            this.MyNavigator.Name = "MyNavigator";
            this.MyNavigator.Size = new System.Drawing.Size(453, 31);
            this.MyNavigator.TabIndex = 5;
            this.MyNavigator.Get_Values += new System.EventHandler(this.Navigator_Get_Values);
            this.MyNavigator.Set_Values += new System.EventHandler(this.Navigator_Set_Vakues);
            this.MyNavigator.New_Record += new System.EventHandler(this.Navigator_New_Record);
            //this.MyNavigator.Before_Save += new System.EventHandler(this.Navigator_Before_Save);
            this.MyNavigator.After_Save += new System.EventHandler(this.Navigator_After_Save);
            this.MyNavigator.After_Delete += new System.EventHandler(this.Navigator_After_Delete);
            this.MyNavigator.Load += new System.EventHandler(this.MyNavigator_Load);
            // 
            // frmAccNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 407);
            this.Controls.Add(this.Pages);
            this.Name = "frmAccNotes";
            this.Text = "Accounts_Notes";
            this.Pages.ResumeLayout(false);
            this.P1.ResumeLayout(false);
            this.P1.PerformLayout();
            this.P2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Navigator MyNavigator;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtSCode;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox TitleType;
        private System.Windows.Forms.TabControl Pages;
        private System.Windows.Forms.TabPage P1;
        private System.Windows.Forms.TabPage P2;
        private AppliedDataGrid DataGrid_Notes;
    }
}