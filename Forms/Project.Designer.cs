namespace Applied_Accounts.Forms
{
    partial class frmProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProject));
            this.Pages = new System.Windows.Forms.TabControl();
            this.P1 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Cost = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.cboxSupplier = new System.Windows.Forms.ComboBox();
            this.txtNature = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.P2 = new System.Windows.Forms.TabPage();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.MyNavigator = new Applied_Accounts.Navigator();
            this.Grid_Projects = new Applied_Accounts.AppliedDataGrid();
            this.Pages.SuspendLayout();
            this.P1.SuspendLayout();
            this.P2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pages
            // 
            this.Pages.Controls.Add(this.P1);
            this.Pages.Controls.Add(this.P2);
            this.Pages.Location = new System.Drawing.Point(12, 12);
            this.Pages.Name = "Pages";
            this.Pages.SelectedIndex = 0;
            this.Pages.Size = new System.Drawing.Size(583, 426);
            this.Pages.TabIndex = 1;
            // 
            // P1
            // 
            this.P1.Controls.Add(this.label10);
            this.P1.Controls.Add(this.MyNavigator);
            this.P1.Controls.Add(this.label9);
            this.P1.Controls.Add(this.Cost);
            this.P1.Controls.Add(this.label7);
            this.P1.Controls.Add(this.label6);
            this.P1.Controls.Add(this.label5);
            this.P1.Controls.Add(this.txtRemarks);
            this.P1.Controls.Add(this.cboxSupplier);
            this.P1.Controls.Add(this.txtNature);
            this.P1.Controls.Add(this.txtCost);
            this.P1.Controls.Add(this.txtCity);
            this.P1.Controls.Add(this.txtLocation);
            this.P1.Controls.Add(this.txtTitle);
            this.P1.Controls.Add(this.txtTag);
            this.P1.Controls.Add(this.txtCode);
            this.P1.Controls.Add(this.txtID);
            this.P1.Controls.Add(this.label4);
            this.P1.Controls.Add(this.label3);
            this.P1.Controls.Add(this.label2);
            this.P1.Controls.Add(this.label1);
            this.P1.Location = new System.Drawing.Point(4, 22);
            this.P1.Name = "P1";
            this.P1.Padding = new System.Windows.Forms.Padding(3);
            this.P1.Size = new System.Drawing.Size(575, 400);
            this.P1.TabIndex = 0;
            this.P1.Text = "Record";
            this.P1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Remarks";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(207, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Project\'s Nature";
            // 
            // Cost
            // 
            this.Cost.AutoSize = true;
            this.Cost.Location = new System.Drawing.Point(13, 216);
            this.Cost.Name = "Cost";
            this.Cost.Size = new System.Drawing.Size(28, 13);
            this.Cost.TabIndex = 17;
            this.Cost.Text = "Cost";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "City";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Location";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Client";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(79, 240);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(457, 115);
            this.txtRemarks.TabIndex = 13;
            // 
            // cboxSupplier
            // 
            this.cboxSupplier.FormattingEnabled = true;
            this.cboxSupplier.Location = new System.Drawing.Point(79, 101);
            this.cboxSupplier.Name = "cboxSupplier";
            this.cboxSupplier.Size = new System.Drawing.Size(457, 21);
            this.cboxSupplier.TabIndex = 12;
            // 
            // txtNature
            // 
            this.txtNature.Location = new System.Drawing.Point(294, 213);
            this.txtNature.Name = "txtNature";
            this.txtNature.Size = new System.Drawing.Size(242, 20);
            this.txtNature.TabIndex = 11;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(79, 213);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(100, 20);
            this.txtCost.TabIndex = 10;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(79, 187);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 9;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(79, 128);
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(457, 53);
            this.txtLocation.TabIndex = 8;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(79, 74);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(457, 20);
            this.txtTitle.TabIndex = 7;
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(227, 46);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(100, 20);
            this.txtTag.TabIndex = 6;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(79, 47);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 5;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(79, 21);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tag";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // P2
            // 
            this.P2.Controls.Add(this.Grid_Projects);
            this.P2.Location = new System.Drawing.Point(4, 22);
            this.P2.Name = "P2";
            this.P2.Padding = new System.Windows.Forms.Padding(3);
            this.P2.Size = new System.Drawing.Size(575, 400);
            this.P2.TabIndex = 1;
            this.P2.Text = "List";
            this.P2.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(16, 449);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Message";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(565, 444);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(26, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MyNavigator
            // 
            this.MyNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyNavigator.Location = new System.Drawing.Point(79, 361);
            this.MyNavigator.Name = "MyNavigator";
            this.MyNavigator.Size = new System.Drawing.Size(457, 24);
            this.MyNavigator.TabIndex = 0;
            this.MyNavigator.Get_Values += new System.EventHandler(this.MyNavigator_Get_Values);
            this.MyNavigator.Set_Values += new System.EventHandler(this.MyNavigator_Set_Values);
            this.MyNavigator.New_Record += new System.EventHandler(this.MyNavigator_New_Record);
            this.MyNavigator.After_Save += new System.EventHandler(this.MyNavigator_After_Save);
            this.MyNavigator.After_Delete += new System.EventHandler(this.MyNavigator_After_Delete);
            this.MyNavigator.Load += new System.EventHandler(this.MyNavigator_Load);
            // 
            // Grid_Projects
            // 
            this.Grid_Projects.Active = false;
            this.Grid_Projects.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Grid_Projects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Grid_Projects.ColumnsFormat = null;
            this.Grid_Projects.ColumnsName = null;
            this.Grid_Projects.ColumnsVisiable = null;
            this.Grid_Projects.ColumnsWidth = null;
            this.Grid_Projects.IsBrowseWin = false;
            this.Grid_Projects.IsPressEnter = false;
            this.Grid_Projects.Location = new System.Drawing.Point(6, 6);
            this.Grid_Projects.MyDataRow = null;
            this.Grid_Projects.MyDataView = null;
            this.Grid_Projects.Name = "Grid_Projects";
            this.Grid_Projects.RecordID = ((long)(0));
            this.Grid_Projects.Size = new System.Drawing.Size(563, 384);
            this.Grid_Projects.TabIndex = 0;
            this.Grid_Projects.Load += new System.EventHandler(this.Grid_Load);
            // 
            // frmProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 474);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.Pages);
            this.Name = "frmProject";
            this.Text = "Project";
            this.Load += new System.EventHandler(this.frmProject_Load);
            this.Pages.ResumeLayout(false);
            this.P1.ResumeLayout(false);
            this.P1.PerformLayout();
            this.P2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Navigator MyNavigator;
        private System.Windows.Forms.TabControl Pages;
        private System.Windows.Forms.TabPage P1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Cost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.ComboBox cboxSupplier;
        private System.Windows.Forms.TextBox txtNature;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage P2;
        private AppliedDataGrid Grid_Projects;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnExit;
    }
}