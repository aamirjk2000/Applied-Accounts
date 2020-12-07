
namespace Applied_Accounts.Forms
{
    partial class frmUnits
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
            this.cBoxProject = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFloor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBlock = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.MyNavigator = new Applied_Accounts.Navigator();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.P2 = new System.Windows.Forms.TabPage();
            this.MyDataGrid = new Applied_Accounts.AppliedDataGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
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
            this.Pages.Size = new System.Drawing.Size(672, 384);
            this.Pages.TabIndex = 0;
            // 
            // P1
            // 
            this.P1.Controls.Add(this.cBoxProject);
            this.P1.Controls.Add(this.label11);
            this.P1.Controls.Add(this.txtFloor);
            this.P1.Controls.Add(this.label10);
            this.P1.Controls.Add(this.txtBlock);
            this.P1.Controls.Add(this.label9);
            this.P1.Controls.Add(this.chkActive);
            this.P1.Controls.Add(this.MyNavigator);
            this.P1.Controls.Add(this.label8);
            this.P1.Controls.Add(this.txtRemarks);
            this.P1.Controls.Add(this.txtSize);
            this.P1.Controls.Add(this.txtLocation);
            this.P1.Controls.Add(this.txtType);
            this.P1.Controls.Add(this.txtTitle);
            this.P1.Controls.Add(this.txtTag);
            this.P1.Controls.Add(this.txtCode);
            this.P1.Controls.Add(this.txtID);
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
            this.P1.Size = new System.Drawing.Size(664, 358);
            this.P1.TabIndex = 0;
            this.P1.Text = "Record";
            this.P1.UseVisualStyleBackColor = true;
            // 
            // cBoxProject
            // 
            this.cBoxProject.FormattingEnabled = true;
            this.cBoxProject.Location = new System.Drawing.Point(127, 144);
            this.cBoxProject.Name = "cBoxProject";
            this.cBoxProject.Size = new System.Drawing.Size(390, 21);
            this.cBoxProject.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Project";
            // 
            // txtFloor
            // 
            this.txtFloor.Location = new System.Drawing.Point(274, 206);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.Size = new System.Drawing.Size(100, 20);
            this.txtFloor.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(234, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Floor";
            // 
            // txtBlock
            // 
            this.txtBlock.Location = new System.Drawing.Point(274, 177);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(100, 20);
            this.txtBlock.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(234, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Block";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(547, 261);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 18;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // MyNavigator
            // 
            this.MyNavigator.Current_Mode = 0;
            this.MyNavigator.Location = new System.Drawing.Point(42, 315);
            this.MyNavigator.Name = "MyNavigator";
            this.MyNavigator.Size = new System.Drawing.Size(561, 24);
            this.MyNavigator.TabIndex = 18;
            this.MyNavigator.New_Record += new System.EventHandler(this.MyNavigator_New_Record);
            this.MyNavigator.Before_Save += new System.EventHandler(this.MyNavigator_Before_Save);
            this.MyNavigator.After_Save += new System.EventHandler(this.MyNavigator_After_Save);
            this.MyNavigator.After_Delete += new System.EventHandler(this.MyNavigator_After_Delete);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(127, 258);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(390, 20);
            this.txtRemarks.TabIndex = 17;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(127, 230);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(100, 20);
            this.txtSize.TabIndex = 16;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(127, 203);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(100, 20);
            this.txtLocation.TabIndex = 14;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(127, 177);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(100, 20);
            this.txtType.TabIndex = 12;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(127, 114);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(390, 20);
            this.txtTitle.TabIndex = 10;
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(127, 88);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(73, 20);
            this.txtTag.TabIndex = 9;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(127, 62);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(73, 20);
            this.txtCode.TabIndex = 8;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(127, 36);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(73, 20);
            this.txtID.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Unit Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Unit Location";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Unit Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tag";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Record ID";
            // 
            // P2
            // 
            this.P2.Controls.Add(this.MyDataGrid);
            this.P2.Location = new System.Drawing.Point(4, 22);
            this.P2.Name = "P2";
            this.P2.Padding = new System.Windows.Forms.Padding(3);
            this.P2.Size = new System.Drawing.Size(664, 358);
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
            this.MyDataGrid.Location = new System.Drawing.Point(6, 6);
            this.MyDataGrid.MyDataRow = null;
            this.MyDataGrid.MyDataView = null;
            this.MyDataGrid.MyViewRow = null;
            this.MyDataGrid.Name = "MyDataGrid";
            this.MyDataGrid.RecordID = ((long)(0));
            this.MyDataGrid.Size = new System.Drawing.Size(652, 301);
            this.MyDataGrid.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::Applied_Accounts.Properties.Resources.Exit2;
            this.button1.Location = new System.Drawing.Point(644, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 32);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(13, 408);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 19;
            this.lblMessage.Text = "Message";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(563, 402);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 430);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.Pages);
            this.Controls.Add(this.button1);
            this.Name = "frmUnits";
            this.Text = "Units";
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
        private AppliedDataGrid MyDataGrid;
        private System.Windows.Forms.Button button1;
        private Navigator MyNavigator;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtBlock;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cBoxProject;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
    }
}