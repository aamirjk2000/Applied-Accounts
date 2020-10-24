
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
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.Pages.Size = new System.Drawing.Size(672, 339);
            this.Pages.TabIndex = 0;
            // 
            // P1
            // 
            this.P1.Controls.Add(this.chkActive);
            this.P1.Controls.Add(this.button1);
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
            this.P1.Size = new System.Drawing.Size(664, 313);
            this.P1.TabIndex = 0;
            this.P1.Text = "Record";
            this.P1.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(524, 224);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 19;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(556, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MyNavigator
            // 
            this.MyNavigator.Location = new System.Drawing.Point(42, 274);
            this.MyNavigator.Name = "MyNavigator";
            this.MyNavigator.Size = new System.Drawing.Size(475, 24);
            this.MyNavigator.TabIndex = 17;
            this.MyNavigator.Get_Values += new System.EventHandler(this.MyNavigator_Get_Values);
            this.MyNavigator.Set_Values += new System.EventHandler(this.MyNavigator_Set_Values);
            this.MyNavigator.New_Record += new System.EventHandler(this.MyNavigator_New_Record);
            this.MyNavigator.After_Save += new System.EventHandler(this.MyNavigator_After_Save);
            this.MyNavigator.After_Delete += new System.EventHandler(this.MyNavigator_After_Delete);
            this.MyNavigator.Load += new System.EventHandler(this.MyNavigator_Load);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(127, 221);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(390, 20);
            this.txtRemarks.TabIndex = 14;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(127, 193);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(100, 20);
            this.txtSize.TabIndex = 13;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(127, 166);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(100, 20);
            this.txtLocation.TabIndex = 12;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(127, 140);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(100, 20);
            this.txtType.TabIndex = 11;
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
            this.label7.Location = new System.Drawing.Point(39, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Unit Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Unit Location";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 143);
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
            this.P2.Size = new System.Drawing.Size(664, 313);
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
            this.MyDataGrid.Location = new System.Drawing.Point(6, 60);
            this.MyDataGrid.MyDataRow = null;
            this.MyDataGrid.MyDataView = null;
            this.MyDataGrid.MyViewRow = null;
            this.MyDataGrid.Name = "MyDataGrid";
            this.MyDataGrid.RecordID = ((long)(0));
            this.MyDataGrid.Size = new System.Drawing.Size(652, 334);
            this.MyDataGrid.TabIndex = 0;
            // 
            // frmUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 363);
            this.Controls.Add(this.Pages);
            this.Name = "frmUnits";
            this.Text = "Units";
            this.Pages.ResumeLayout(false);
            this.P1.ResumeLayout(false);
            this.P1.PerformLayout();
            this.P2.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}