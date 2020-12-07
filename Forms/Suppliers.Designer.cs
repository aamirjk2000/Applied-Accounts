namespace Applied_Accounts.Forms
{
    partial class frmSuppliers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuppliers));
            this.Pages = new System.Windows.Forms.TabControl();
            this.P1 = new System.Windows.Forms.TabPage();
            this.txtCNIC = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSTN = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtNTN = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtPerson = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBusiness = new System.Windows.Forms.TextBox();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MyNavigator = new Applied_Accounts.Navigator();
            this.P2 = new System.Windows.Forms.TabPage();
            this.MyDataGrid = new Applied_Accounts.AppliedDataGrid();
            this.btnExit = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
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
            this.Pages.Size = new System.Drawing.Size(584, 386);
            this.Pages.TabIndex = 0;
            // 
            // P1
            // 
            this.P1.Controls.Add(this.txtCNIC);
            this.P1.Controls.Add(this.label13);
            this.P1.Controls.Add(this.txtSTN);
            this.P1.Controls.Add(this.label12);
            this.P1.Controls.Add(this.txtCity);
            this.P1.Controls.Add(this.txtCountry);
            this.P1.Controls.Add(this.txtNTN);
            this.P1.Controls.Add(this.txtAddress);
            this.P1.Controls.Add(this.txtContact);
            this.P1.Controls.Add(this.txtPerson);
            this.P1.Controls.Add(this.label11);
            this.P1.Controls.Add(this.label10);
            this.P1.Controls.Add(this.label9);
            this.P1.Controls.Add(this.label8);
            this.P1.Controls.Add(this.label7);
            this.P1.Controls.Add(this.label6);
            this.P1.Controls.Add(this.label5);
            this.P1.Controls.Add(this.txtBusiness);
            this.P1.Controls.Add(this.txtTag);
            this.P1.Controls.Add(this.txtTitle);
            this.P1.Controls.Add(this.txtCode);
            this.P1.Controls.Add(this.txtID);
            this.P1.Controls.Add(this.chkActive);
            this.P1.Controls.Add(this.label4);
            this.P1.Controls.Add(this.label3);
            this.P1.Controls.Add(this.label2);
            this.P1.Controls.Add(this.label1);
            this.P1.Controls.Add(this.MyNavigator);
            this.P1.Location = new System.Drawing.Point(4, 22);
            this.P1.Name = "P1";
            this.P1.Padding = new System.Windows.Forms.Padding(3);
            this.P1.Size = new System.Drawing.Size(576, 360);
            this.P1.TabIndex = 0;
            this.P1.Text = "Record";
            this.P1.UseVisualStyleBackColor = true;
            // 
            // txtCNIC
            // 
            this.txtCNIC.Location = new System.Drawing.Point(161, 267);
            this.txtCNIC.Name = "txtCNIC";
            this.txtCNIC.Size = new System.Drawing.Size(100, 20);
            this.txtCNIC.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 267);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "National ID (CNIC)";
            // 
            // txtSTN
            // 
            this.txtSTN.Location = new System.Drawing.Point(161, 238);
            this.txtSTN.Name = "txtSTN";
            this.txtSTN.Size = new System.Drawing.Size(100, 20);
            this.txtSTN.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 241);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Sales Tax Number";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(441, 147);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 24;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(441, 174);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(100, 20);
            this.txtCountry.TabIndex = 23;
            // 
            // txtNTN
            // 
            this.txtNTN.Location = new System.Drawing.Point(161, 212);
            this.txtNTN.Name = "txtNTN";
            this.txtNTN.Size = new System.Drawing.Size(100, 20);
            this.txtNTN.TabIndex = 22;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(74, 145);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(313, 49);
            this.txtAddress.TabIndex = 21;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(287, 110);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(100, 20);
            this.txtContact.TabIndex = 20;
            // 
            // txtPerson
            // 
            this.txtPerson.Location = new System.Drawing.Point(74, 110);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(100, 20);
            this.txtPerson.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Income Tax No. (NTN)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(393, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Country";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(393, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "City";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Contact No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Person";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Business";
            // 
            // txtBusiness
            // 
            this.txtBusiness.Location = new System.Drawing.Point(74, 80);
            this.txtBusiness.Name = "txtBusiness";
            this.txtBusiness.Size = new System.Drawing.Size(467, 20);
            this.txtBusiness.TabIndex = 10;
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(441, 25);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(100, 20);
            this.txtTag.TabIndex = 9;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(74, 53);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(467, 20);
            this.txtTitle.TabIndex = 8;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(254, 26);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 7;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(74, 25);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 6;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(396, 263);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 5;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tag";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // MyNavigator
            // 
            this.MyNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MyNavigator.Current_Mode = 0;
            this.MyNavigator.Location = new System.Drawing.Point(22, 318);
            this.MyNavigator.Name = "MyNavigator";
            this.MyNavigator.Size = new System.Drawing.Size(534, 36);
            this.MyNavigator.TabIndex = 0;
            this.MyNavigator.New_Record += new System.EventHandler(this.MyNavigator_New_Record);
            this.MyNavigator.Before_Save += new System.EventHandler(this.MyNavigator_Before_Save);
            this.MyNavigator.After_Save += new System.EventHandler(this.MyNavigator_After_Save);
            this.MyNavigator.After_Delete += new System.EventHandler(this.MyNavigator_After_Delete);
            // 
            // P2
            // 
            this.P2.Controls.Add(this.MyDataGrid);
            this.P2.Location = new System.Drawing.Point(4, 22);
            this.P2.Name = "P2";
            this.P2.Size = new System.Drawing.Size(576, 360);
            this.P2.TabIndex = 2;
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
            this.MyDataGrid.Location = new System.Drawing.Point(3, 3);
            this.MyDataGrid.MyDataRow = null;
            this.MyDataGrid.MyDataView = null;
            this.MyDataGrid.MyViewRow = null;
            this.MyDataGrid.Name = "MyDataGrid";
            this.MyDataGrid.RecordID = ((long)(0));
            this.MyDataGrid.Size = new System.Drawing.Size(563, 394);
            this.MyDataGrid.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(563, 400);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(33, 30);
            this.btnExit.TabIndex = 12;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 409);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Message";
            // 
            // frmSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 438);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Pages);
            this.Controls.Add(this.btnExit);
            this.Name = "frmSuppliers";
            this.Text = "Suppliers";
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
        private Navigator MyNavigator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBusiness;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabPage P2;
        private AppliedDataGrid MyDataGrid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCNIC;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSTN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtNTN;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtPerson;
        private System.Windows.Forms.Label label14;
    }
}