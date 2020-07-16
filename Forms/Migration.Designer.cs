namespace Applied_Accounts.Forms
{
    partial class frmMigration
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
            this.tpApplied = new System.Windows.Forms.TabPage();
            this.Grid_Applied = new System.Windows.Forms.DataGridView();
            this.tbNotes = new System.Windows.Forms.TabPage();
            this.Grid_Notes = new System.Windows.Forms.DataGridView();
            this.tpAccounts = new System.Windows.Forms.TabPage();
            this.Grid_Accounts = new System.Windows.Forms.DataGridView();
            this.tpAccType = new System.Windows.Forms.TabPage();
            this.Grid_AccType = new System.Windows.Forms.DataGridView();
            this.tpSuppliers = new System.Windows.Forms.TabPage();
            this.Grid_Suppliers = new System.Windows.Forms.DataGridView();
            this.tpProjects = new System.Windows.Forms.TabPage();
            this.Grid_Projects = new System.Windows.Forms.DataGridView();
            this.tpUnits = new System.Windows.Forms.TabPage();
            this.Grid_Units = new System.Windows.Forms.DataGridView();
            this.tpStocks = new System.Windows.Forms.TabPage();
            this.Grid_Stocks = new System.Windows.Forms.DataGridView();
            this.tpEmployees = new System.Windows.Forms.TabPage();
            this.Grid_Employees = new System.Windows.Forms.DataGridView();
            this.BarMigration = new System.Windows.Forms.ProgressBar();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnMigration = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblMessages = new System.Windows.Forms.Label();
            this.tpLedger = new System.Windows.Forms.TabPage();
            this.Grid_Ledger = new System.Windows.Forms.DataGridView();
            this.Pages.SuspendLayout();
            this.tpApplied.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Applied)).BeginInit();
            this.tbNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Notes)).BeginInit();
            this.tpAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Accounts)).BeginInit();
            this.tpAccType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_AccType)).BeginInit();
            this.tpSuppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Suppliers)).BeginInit();
            this.tpProjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Projects)).BeginInit();
            this.tpUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Units)).BeginInit();
            this.tpStocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Stocks)).BeginInit();
            this.tpEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Employees)).BeginInit();
            this.tpLedger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Ledger)).BeginInit();
            this.SuspendLayout();
            // 
            // Pages
            // 
            this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pages.Controls.Add(this.tpApplied);
            this.Pages.Controls.Add(this.tbNotes);
            this.Pages.Controls.Add(this.tpAccounts);
            this.Pages.Controls.Add(this.tpAccType);
            this.Pages.Controls.Add(this.tpSuppliers);
            this.Pages.Controls.Add(this.tpProjects);
            this.Pages.Controls.Add(this.tpUnits);
            this.Pages.Controls.Add(this.tpStocks);
            this.Pages.Controls.Add(this.tpEmployees);
            this.Pages.Controls.Add(this.tpLedger);
            this.Pages.Location = new System.Drawing.Point(12, 12);
            this.Pages.Name = "Pages";
            this.Pages.SelectedIndex = 0;
            this.Pages.Size = new System.Drawing.Size(776, 403);
            this.Pages.TabIndex = 0;
            // 
            // tpApplied
            // 
            this.tpApplied.Controls.Add(this.Grid_Applied);
            this.tpApplied.Location = new System.Drawing.Point(4, 22);
            this.tpApplied.Name = "tpApplied";
            this.tpApplied.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplied.Size = new System.Drawing.Size(768, 377);
            this.tpApplied.TabIndex = 0;
            this.tpApplied.Text = "Applied";
            this.tpApplied.UseVisualStyleBackColor = true;
            // 
            // Grid_Applied
            // 
            this.Grid_Applied.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Applied.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Applied.Location = new System.Drawing.Point(6, 6);
            this.Grid_Applied.Name = "Grid_Applied";
            this.Grid_Applied.Size = new System.Drawing.Size(756, 365);
            this.Grid_Applied.TabIndex = 0;
            // 
            // tbNotes
            // 
            this.tbNotes.Controls.Add(this.Grid_Notes);
            this.tbNotes.Location = new System.Drawing.Point(4, 22);
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Padding = new System.Windows.Forms.Padding(3);
            this.tbNotes.Size = new System.Drawing.Size(768, 377);
            this.tbNotes.TabIndex = 1;
            this.tbNotes.Text = "Notes";
            this.tbNotes.UseVisualStyleBackColor = true;
            // 
            // Grid_Notes
            // 
            this.Grid_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Notes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Notes.Location = new System.Drawing.Point(6, 6);
            this.Grid_Notes.Name = "Grid_Notes";
            this.Grid_Notes.Size = new System.Drawing.Size(756, 358);
            this.Grid_Notes.TabIndex = 0;
            // 
            // tpAccounts
            // 
            this.tpAccounts.Controls.Add(this.Grid_Accounts);
            this.tpAccounts.Location = new System.Drawing.Point(4, 22);
            this.tpAccounts.Name = "tpAccounts";
            this.tpAccounts.Size = new System.Drawing.Size(768, 377);
            this.tpAccounts.TabIndex = 2;
            this.tpAccounts.Text = "COA";
            this.tpAccounts.UseVisualStyleBackColor = true;
            // 
            // Grid_Accounts
            // 
            this.Grid_Accounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Accounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Accounts.Location = new System.Drawing.Point(6, 6);
            this.Grid_Accounts.Name = "Grid_Accounts";
            this.Grid_Accounts.Size = new System.Drawing.Size(756, 358);
            this.Grid_Accounts.TabIndex = 0;
            // 
            // tpAccType
            // 
            this.tpAccType.Controls.Add(this.Grid_AccType);
            this.tpAccType.Location = new System.Drawing.Point(4, 22);
            this.tpAccType.Name = "tpAccType";
            this.tpAccType.Size = new System.Drawing.Size(768, 377);
            this.tpAccType.TabIndex = 3;
            this.tpAccType.Text = "COA_Type";
            this.tpAccType.UseVisualStyleBackColor = true;
            // 
            // Grid_AccType
            // 
            this.Grid_AccType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_AccType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_AccType.Location = new System.Drawing.Point(6, 6);
            this.Grid_AccType.Name = "Grid_AccType";
            this.Grid_AccType.Size = new System.Drawing.Size(756, 358);
            this.Grid_AccType.TabIndex = 0;
            // 
            // tpSuppliers
            // 
            this.tpSuppliers.Controls.Add(this.Grid_Suppliers);
            this.tpSuppliers.Location = new System.Drawing.Point(4, 22);
            this.tpSuppliers.Name = "tpSuppliers";
            this.tpSuppliers.Size = new System.Drawing.Size(768, 377);
            this.tpSuppliers.TabIndex = 4;
            this.tpSuppliers.Text = "Suppliers";
            this.tpSuppliers.UseVisualStyleBackColor = true;
            // 
            // Grid_Suppliers
            // 
            this.Grid_Suppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Suppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Suppliers.Location = new System.Drawing.Point(6, 6);
            this.Grid_Suppliers.Name = "Grid_Suppliers";
            this.Grid_Suppliers.Size = new System.Drawing.Size(756, 358);
            this.Grid_Suppliers.TabIndex = 0;
            // 
            // tpProjects
            // 
            this.tpProjects.Controls.Add(this.Grid_Projects);
            this.tpProjects.Location = new System.Drawing.Point(4, 22);
            this.tpProjects.Name = "tpProjects";
            this.tpProjects.Size = new System.Drawing.Size(768, 377);
            this.tpProjects.TabIndex = 5;
            this.tpProjects.Text = "Projects";
            this.tpProjects.UseVisualStyleBackColor = true;
            // 
            // Grid_Projects
            // 
            this.Grid_Projects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Projects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Projects.Location = new System.Drawing.Point(6, 6);
            this.Grid_Projects.Name = "Grid_Projects";
            this.Grid_Projects.Size = new System.Drawing.Size(756, 358);
            this.Grid_Projects.TabIndex = 0;
            // 
            // tpUnits
            // 
            this.tpUnits.Controls.Add(this.Grid_Units);
            this.tpUnits.Location = new System.Drawing.Point(4, 22);
            this.tpUnits.Name = "tpUnits";
            this.tpUnits.Size = new System.Drawing.Size(768, 377);
            this.tpUnits.TabIndex = 6;
            this.tpUnits.Text = "Units";
            this.tpUnits.UseVisualStyleBackColor = true;
            // 
            // Grid_Units
            // 
            this.Grid_Units.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Units.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Units.Location = new System.Drawing.Point(6, 6);
            this.Grid_Units.Name = "Grid_Units";
            this.Grid_Units.Size = new System.Drawing.Size(756, 358);
            this.Grid_Units.TabIndex = 0;
            // 
            // tpStocks
            // 
            this.tpStocks.Controls.Add(this.Grid_Stocks);
            this.tpStocks.Location = new System.Drawing.Point(4, 22);
            this.tpStocks.Name = "tpStocks";
            this.tpStocks.Size = new System.Drawing.Size(768, 377);
            this.tpStocks.TabIndex = 7;
            this.tpStocks.Text = "Stock";
            this.tpStocks.UseVisualStyleBackColor = true;
            // 
            // Grid_Stocks
            // 
            this.Grid_Stocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Stocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Stocks.Location = new System.Drawing.Point(6, 6);
            this.Grid_Stocks.Name = "Grid_Stocks";
            this.Grid_Stocks.Size = new System.Drawing.Size(756, 358);
            this.Grid_Stocks.TabIndex = 0;
            // 
            // tpEmployees
            // 
            this.tpEmployees.Controls.Add(this.Grid_Employees);
            this.tpEmployees.Location = new System.Drawing.Point(4, 22);
            this.tpEmployees.Name = "tpEmployees";
            this.tpEmployees.Size = new System.Drawing.Size(768, 377);
            this.tpEmployees.TabIndex = 8;
            this.tpEmployees.Text = "Employees";
            this.tpEmployees.UseVisualStyleBackColor = true;
            // 
            // Grid_Employees
            // 
            this.Grid_Employees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Employees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Employees.Location = new System.Drawing.Point(6, 6);
            this.Grid_Employees.Name = "Grid_Employees";
            this.Grid_Employees.Size = new System.Drawing.Size(756, 358);
            this.Grid_Employees.TabIndex = 0;
            // 
            // BarMigration
            // 
            this.BarMigration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BarMigration.Location = new System.Drawing.Point(22, 460);
            this.BarMigration.Name = "BarMigration";
            this.BarMigration.Size = new System.Drawing.Size(414, 23);
            this.BarMigration.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(525, 460);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnMigration
            // 
            this.btnMigration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMigration.Location = new System.Drawing.Point(606, 460);
            this.btnMigration.Name = "btnMigration";
            this.btnMigration.Size = new System.Drawing.Size(97, 23);
            this.btnMigration.TabIndex = 3;
            this.btnMigration.Text = "MIGRATION";
            this.btnMigration.UseVisualStyleBackColor = true;
            this.btnMigration.Click += new System.EventHandler(this.btnMigration_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(709, 460);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "E X I T";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(442, 465);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(55, 13);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Messages";
            // 
            // lblMessages
            // 
            this.lblMessages.AutoSize = true;
            this.lblMessages.Location = new System.Drawing.Point(25, 429);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(35, 13);
            this.lblMessages.TabIndex = 6;
            this.lblMessages.Text = "label1";
            // 
            // tpLedger
            // 
            this.tpLedger.Controls.Add(this.Grid_Ledger);
            this.tpLedger.Location = new System.Drawing.Point(4, 22);
            this.tpLedger.Name = "tpLedger";
            this.tpLedger.Size = new System.Drawing.Size(768, 377);
            this.tpLedger.TabIndex = 9;
            this.tpLedger.Text = "Ledger";
            this.tpLedger.UseVisualStyleBackColor = true;
            // 
            // Grid_Ledger
            // 
            this.Grid_Ledger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Ledger.Location = new System.Drawing.Point(3, 3);
            this.Grid_Ledger.Name = "Grid_Ledger";
            this.Grid_Ledger.Size = new System.Drawing.Size(762, 371);
            this.Grid_Ledger.TabIndex = 0;
            // 
            // frmMigration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.lblMessages);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.BarMigration);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMigration);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.Pages);
            this.Name = "frmMigration";
            this.Text = "Migration";
            this.Pages.ResumeLayout(false);
            this.tpApplied.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Applied)).EndInit();
            this.tbNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Notes)).EndInit();
            this.tpAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Accounts)).EndInit();
            this.tpAccType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_AccType)).EndInit();
            this.tpSuppliers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Suppliers)).EndInit();
            this.tpProjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Projects)).EndInit();
            this.tpUnits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Units)).EndInit();
            this.tpStocks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Stocks)).EndInit();
            this.tpEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Employees)).EndInit();
            this.tpLedger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Ledger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Pages;
        private System.Windows.Forms.TabPage tpApplied;
        private System.Windows.Forms.TabPage tbNotes;
        private System.Windows.Forms.ProgressBar BarMigration;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnMigration;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabPage tpAccounts;
        private System.Windows.Forms.TabPage tpAccType;
        private System.Windows.Forms.TabPage tpSuppliers;
        private System.Windows.Forms.TabPage tpProjects;
        private System.Windows.Forms.TabPage tpUnits;
        private System.Windows.Forms.TabPage tpStocks;
        private System.Windows.Forms.TabPage tpEmployees;
        private System.Windows.Forms.DataGridView Grid_Applied;
        private System.Windows.Forms.DataGridView Grid_Notes;
        private System.Windows.Forms.DataGridView Grid_Accounts;
        private System.Windows.Forms.DataGridView Grid_AccType;
        private System.Windows.Forms.DataGridView Grid_Suppliers;
        private System.Windows.Forms.DataGridView Grid_Projects;
        private System.Windows.Forms.DataGridView Grid_Units;
        private System.Windows.Forms.DataGridView Grid_Stocks;
        private System.Windows.Forms.DataGridView Grid_Employees;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblMessages;
        private System.Windows.Forms.TabPage tpLedger;
        private System.Windows.Forms.DataGridView Grid_Ledger;
    }
}