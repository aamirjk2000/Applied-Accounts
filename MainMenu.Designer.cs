namespace Applied_Accounts
{
    partial class frmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCOA = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProjects = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUnits = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMigration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJV = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPV = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRV = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalesVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalaryVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStockVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStockPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalesInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSalary = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVouchers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGeneralLedger = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSupplierLedger = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProjectLedger = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUnitLedger = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTrialBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBalanceSheet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProfitAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTabularReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.companyProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataBaseSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.vouchersValidationCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.lbl_DevelopedBy = new System.Windows.Forms.Label();
            this.lbl_Author = new System.Windows.Forms.Label();
            this.lbl_GUID = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetup,
            this.mnuTransactions,
            this.mnuReport,
            this.mnuSettings,
            this.mnuExit,
            this.toolStripTextBox1});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(800, 27);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "Main Menu Applied";
            // 
            // mnuSetup
            // 
            this.mnuSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCOA,
            this.mnuAccNotes,
            this.toolStripSeparator4,
            this.mnuSupplier,
            this.mnuProjects,
            this.mnuUnits,
            this.mnuEmployees,
            this.toolStripSeparator5,
            this.mnuMigration,
            this.mnuSetting});
            this.mnuSetup.Name = "mnuSetup";
            this.mnuSetup.Size = new System.Drawing.Size(49, 23);
            this.mnuSetup.Text = "Setup";
            // 
            // mnuCOA
            // 
            this.mnuCOA.Name = "mnuCOA";
            this.mnuCOA.Size = new System.Drawing.Size(170, 22);
            this.mnuCOA.Text = "Chart of Accounts";
            this.mnuCOA.Click += new System.EventHandler(this.mnuCOA_Click);
            // 
            // mnuAccNotes
            // 
            this.mnuAccNotes.Name = "mnuAccNotes";
            this.mnuAccNotes.Size = new System.Drawing.Size(170, 22);
            this.mnuAccNotes.Text = "Accounts Notes";
            this.mnuAccNotes.Click += new System.EventHandler(this.mnuAccNotes_Click_1);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(167, 6);
            // 
            // mnuSupplier
            // 
            this.mnuSupplier.Name = "mnuSupplier";
            this.mnuSupplier.Size = new System.Drawing.Size(170, 22);
            this.mnuSupplier.Text = "Clients / Suppliers";
            this.mnuSupplier.Click += new System.EventHandler(this.mnuSupplier_Click);
            // 
            // mnuProjects
            // 
            this.mnuProjects.Name = "mnuProjects";
            this.mnuProjects.Size = new System.Drawing.Size(170, 22);
            this.mnuProjects.Text = "Projects";
            this.mnuProjects.Click += new System.EventHandler(this.mnuProjects_Click);
            // 
            // mnuUnits
            // 
            this.mnuUnits.Name = "mnuUnits";
            this.mnuUnits.Size = new System.Drawing.Size(170, 22);
            this.mnuUnits.Text = "Units";
            this.mnuUnits.Click += new System.EventHandler(this.mnuUnits_Click);
            // 
            // mnuEmployees
            // 
            this.mnuEmployees.Name = "mnuEmployees";
            this.mnuEmployees.Size = new System.Drawing.Size(170, 22);
            this.mnuEmployees.Text = "Employees";
            this.mnuEmployees.Click += new System.EventHandler(this.mnuEmployees_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(167, 6);
            // 
            // mnuMigration
            // 
            this.mnuMigration.Name = "mnuMigration";
            this.mnuMigration.Size = new System.Drawing.Size(170, 22);
            this.mnuMigration.Text = "Migration of Data";
            this.mnuMigration.Click += new System.EventHandler(this.mnuMigration_Click);
            // 
            // mnuSetting
            // 
            this.mnuSetting.Name = "mnuSetting";
            this.mnuSetting.Size = new System.Drawing.Size(170, 22);
            this.mnuSetting.Text = "Setting";
            this.mnuSetting.Click += new System.EventHandler(this.mnuSetting_Click);
            // 
            // mnuTransactions
            // 
            this.mnuTransactions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuJV,
            this.mnuPV,
            this.mnuRV,
            this.mnuSalesVoucher,
            this.mnuSalaryVoucher,
            this.mnuStockVoucher,
            this.toolStripSeparator6,
            this.mnuStockPurchase,
            this.mnuSalesInvoice,
            this.toolStripSeparator7,
            this.mnuSalary});
            this.mnuTransactions.Name = "mnuTransactions";
            this.mnuTransactions.Size = new System.Drawing.Size(84, 23);
            this.mnuTransactions.Text = "Transactions";
            // 
            // mnuJV
            // 
            this.mnuJV.Name = "mnuJV";
            this.mnuJV.Size = new System.Drawing.Size(170, 22);
            this.mnuJV.Text = "Journal Voucher";
            this.mnuJV.Click += new System.EventHandler(this.mnuJV_Click);
            // 
            // mnuPV
            // 
            this.mnuPV.Name = "mnuPV";
            this.mnuPV.Size = new System.Drawing.Size(170, 22);
            this.mnuPV.Text = "Payment Voucher";
            this.mnuPV.Click += new System.EventHandler(this.mnuPV_Click);
            // 
            // mnuRV
            // 
            this.mnuRV.Name = "mnuRV";
            this.mnuRV.Size = new System.Drawing.Size(170, 22);
            this.mnuRV.Text = "Receipt Voucher";
            this.mnuRV.Click += new System.EventHandler(this.mnuRV_Click);
            // 
            // mnuSalesVoucher
            // 
            this.mnuSalesVoucher.Name = "mnuSalesVoucher";
            this.mnuSalesVoucher.Size = new System.Drawing.Size(170, 22);
            this.mnuSalesVoucher.Text = "Sales Voucher";
            // 
            // mnuSalaryVoucher
            // 
            this.mnuSalaryVoucher.Name = "mnuSalaryVoucher";
            this.mnuSalaryVoucher.Size = new System.Drawing.Size(170, 22);
            this.mnuSalaryVoucher.Text = "Salary voucher";
            // 
            // mnuStockVoucher
            // 
            this.mnuStockVoucher.Name = "mnuStockVoucher";
            this.mnuStockVoucher.Size = new System.Drawing.Size(170, 22);
            this.mnuStockVoucher.Text = "Inventory Voucher";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(167, 6);
            // 
            // mnuStockPurchase
            // 
            this.mnuStockPurchase.Name = "mnuStockPurchase";
            this.mnuStockPurchase.Size = new System.Drawing.Size(170, 22);
            this.mnuStockPurchase.Text = "Stock Purchased";
            // 
            // mnuSalesInvoice
            // 
            this.mnuSalesInvoice.Name = "mnuSalesInvoice";
            this.mnuSalesInvoice.Size = new System.Drawing.Size(170, 22);
            this.mnuSalesInvoice.Text = "Sales Invoice";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(167, 6);
            // 
            // mnuSalary
            // 
            this.mnuSalary.Name = "mnuSalary";
            this.mnuSalary.Size = new System.Drawing.Size(170, 22);
            this.mnuSalary.Text = "Monthly Salary";
            // 
            // mnuReport
            // 
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVouchers,
            this.mnuGeneralLedger,
            this.mnuSupplierLedger,
            this.mnuProjectLedger,
            this.mnuUnitLedger,
            this.toolStripSeparator1,
            this.mnuTrialBalance,
            this.mnuBalanceSheet,
            this.mnuProfitAccount,
            this.mnuTabularReport});
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(59, 23);
            this.mnuReport.Text = "Reports";
            // 
            // mnuVouchers
            // 
            this.mnuVouchers.Name = "mnuVouchers";
            this.mnuVouchers.Size = new System.Drawing.Size(200, 22);
            this.mnuVouchers.Text = "Vouchers";
            this.mnuVouchers.Click += new System.EventHandler(this.mnuVouchers_Click);
            // 
            // mnuGeneralLedger
            // 
            this.mnuGeneralLedger.Name = "mnuGeneralLedger";
            this.mnuGeneralLedger.Size = new System.Drawing.Size(200, 22);
            this.mnuGeneralLedger.Text = "General Ledger";
            this.mnuGeneralLedger.Click += new System.EventHandler(this.mnuRptGL_Click);
            // 
            // mnuSupplierLedger
            // 
            this.mnuSupplierLedger.Name = "mnuSupplierLedger";
            this.mnuSupplierLedger.Size = new System.Drawing.Size(200, 22);
            this.mnuSupplierLedger.Text = "Supplier Ledger";
            this.mnuSupplierLedger.Click += new System.EventHandler(this.mnuSupplierLedger_Click);
            // 
            // mnuProjectLedger
            // 
            this.mnuProjectLedger.Name = "mnuProjectLedger";
            this.mnuProjectLedger.Size = new System.Drawing.Size(200, 22);
            this.mnuProjectLedger.Text = "Project Ledger";
            this.mnuProjectLedger.Click += new System.EventHandler(this.mnuProjectLedger_Click);
            // 
            // mnuUnitLedger
            // 
            this.mnuUnitLedger.Name = "mnuUnitLedger";
            this.mnuUnitLedger.Size = new System.Drawing.Size(200, 22);
            this.mnuUnitLedger.Text = "Unit Ledger";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // mnuTrialBalance
            // 
            this.mnuTrialBalance.Name = "mnuTrialBalance";
            this.mnuTrialBalance.Size = new System.Drawing.Size(200, 22);
            this.mnuTrialBalance.Text = "Trial Balance";
            // 
            // mnuBalanceSheet
            // 
            this.mnuBalanceSheet.Name = "mnuBalanceSheet";
            this.mnuBalanceSheet.Size = new System.Drawing.Size(200, 22);
            this.mnuBalanceSheet.Text = "Balance Sheet";
            // 
            // mnuProfitAccount
            // 
            this.mnuProfitAccount.Name = "mnuProfitAccount";
            this.mnuProfitAccount.Size = new System.Drawing.Size(200, 22);
            this.mnuProfitAccount.Text = "Profit and Loss Account";
            // 
            // mnuTabularReport
            // 
            this.mnuTabularReport.Name = "mnuTabularReport";
            this.mnuTabularReport.Size = new System.Drawing.Size(200, 22);
            this.mnuTabularReport.Text = "Tabular Report";
            // 
            // mnuSettings
            // 
            this.mnuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyProfileToolStripMenuItem,
            this.toolStripSeparator2,
            this.dataBaseSettingToolStripMenuItem,
            this.backupDataToolStripMenuItem,
            this.restoreDataToolStripMenuItem,
            this.toolStripSeparator3,
            this.vouchersValidationCheckToolStripMenuItem});
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(61, 23);
            this.mnuSettings.Text = "Settings";
            // 
            // companyProfileToolStripMenuItem
            // 
            this.companyProfileToolStripMenuItem.Name = "companyProfileToolStripMenuItem";
            this.companyProfileToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.companyProfileToolStripMenuItem.Text = "Company Profile";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(210, 6);
            // 
            // dataBaseSettingToolStripMenuItem
            // 
            this.dataBaseSettingToolStripMenuItem.Name = "dataBaseSettingToolStripMenuItem";
            this.dataBaseSettingToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.dataBaseSettingToolStripMenuItem.Text = "Data Base Setting";
            this.dataBaseSettingToolStripMenuItem.Click += new System.EventHandler(this.dataBaseSettingToolStripMenuItem_Click);
            // 
            // backupDataToolStripMenuItem
            // 
            this.backupDataToolStripMenuItem.Name = "backupDataToolStripMenuItem";
            this.backupDataToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.backupDataToolStripMenuItem.Text = "Backup Data";
            // 
            // restoreDataToolStripMenuItem
            // 
            this.restoreDataToolStripMenuItem.Name = "restoreDataToolStripMenuItem";
            this.restoreDataToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.restoreDataToolStripMenuItem.Text = "Restore Data";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(210, 6);
            // 
            // vouchersValidationCheckToolStripMenuItem
            // 
            this.vouchersValidationCheckToolStripMenuItem.Name = "vouchersValidationCheckToolStripMenuItem";
            this.vouchersValidationCheckToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.vouchersValidationCheckToolStripMenuItem.Text = "Vouchers Validation Check";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(38, 23);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // lbl_DevelopedBy
            // 
            this.lbl_DevelopedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_DevelopedBy.AutoSize = true;
            this.lbl_DevelopedBy.Location = new System.Drawing.Point(12, 406);
            this.lbl_DevelopedBy.Name = "lbl_DevelopedBy";
            this.lbl_DevelopedBy.Size = new System.Drawing.Size(71, 13);
            this.lbl_DevelopedBy.TabIndex = 1;
            this.lbl_DevelopedBy.Text = "DevelopedBy";
            this.lbl_DevelopedBy.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lbl_Author
            // 
            this.lbl_Author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Author.AutoSize = true;
            this.lbl_Author.Location = new System.Drawing.Point(12, 428);
            this.lbl_Author.Name = "lbl_Author";
            this.lbl_Author.Size = new System.Drawing.Size(38, 13);
            this.lbl_Author.TabIndex = 2;
            this.lbl_Author.Text = "Author";
            this.lbl_Author.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_GUID
            // 
            this.lbl_GUID.AutoSize = true;
            this.lbl_GUID.Location = new System.Drawing.Point(545, 425);
            this.lbl_GUID.Name = "lbl_GUID";
            this.lbl_GUID.Size = new System.Drawing.Size(44, 13);
            this.lbl_GUID.TabIndex = 3;
            this.lbl_GUID.Text = "Session";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblCompanyName.Location = new System.Drawing.Point(15, 345);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(115, 17);
            this.lblCompanyName.TabIndex = 4;
            this.lblCompanyName.Text = "CompanyName";
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.lbl_GUID);
            this.Controls.Add(this.lbl_Author);
            this.Controls.Add(this.lbl_DevelopedBy);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Applied Accounts";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuSetup;
        private System.Windows.Forms.ToolStripMenuItem mnuTransactions;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem mnuCOA;
        private System.Windows.Forms.ToolStripMenuItem mnuSupplier;
        private System.Windows.Forms.ToolStripMenuItem mnuProjects;
        private System.Windows.Forms.ToolStripMenuItem mnuJV;
        private System.Windows.Forms.ToolStripMenuItem mnuPV;
        private System.Windows.Forms.ToolStripMenuItem mnuRV;
        private System.Windows.Forms.ToolStripMenuItem mnuUnits;
        private System.Windows.Forms.ToolStripMenuItem mnuGeneralLedger;
        private System.Windows.Forms.ToolStripMenuItem mnuSupplierLedger;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectLedger;
        private System.Windows.Forms.ToolStripMenuItem mnuUnitLedger;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuTrialBalance;
        private System.Windows.Forms.ToolStripMenuItem mnuBalanceSheet;
        private System.Windows.Forms.ToolStripMenuItem mnuProfitAccount;
        private System.Windows.Forms.ToolStripMenuItem mnuTabularReport;
        private System.Windows.Forms.ToolStripMenuItem companyProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem dataBaseSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem vouchersValidationCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAccNotes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuEmployees;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuMigration;
        private System.Windows.Forms.ToolStripMenuItem mnuSalesVoucher;
        private System.Windows.Forms.ToolStripMenuItem mnuSalaryVoucher;
        private System.Windows.Forms.ToolStripMenuItem mnuStockVoucher;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuStockPurchase;
        private System.Windows.Forms.ToolStripMenuItem mnuSalesInvoice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem mnuSalary;
        private System.Windows.Forms.Label lbl_DevelopedBy;
        private System.Windows.Forms.Label lbl_Author;
        private System.Windows.Forms.ToolStripMenuItem mnuSetting;
        private System.Windows.Forms.Label lbl_GUID;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.ToolStripMenuItem mnuVouchers;
    }
}

