namespace Applied_Accounts.Forms
{
    partial class frmVouchers1
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
            this.P2 = new System.Windows.Forms.TabPage();
            this.Stop = new System.Windows.Forms.Button();
            this.Grid_Voucher = new System.Windows.Forms.DataGridView();
            this.P1 = new System.Windows.Forms.TabPage();
            this.grp_Action = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.grp_Transactions = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnBottom = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnTop = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCR = new System.Windows.Forms.TextBox();
            this.txtDR = new System.Windows.Forms.TextBox();
            this.cBoxPOrder = new System.Windows.Forms.ComboBox();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnStocks = new System.Windows.Forms.Button();
            this.btnUnits = new System.Windows.Forms.Button();
            this.btnProjects = new System.Windows.Forms.Button();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.cBoxEmployee = new System.Windows.Forms.ComboBox();
            this.cBoxStock = new System.Windows.Forms.ComboBox();
            this.cBoxUnit = new System.Windows.Forms.ComboBox();
            this.cBoxProject = new System.Windows.Forms.ComboBox();
            this.cBoxSupplier = new System.Windows.Forms.ComboBox();
            this.cBoxAccount = new System.Windows.Forms.ComboBox();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.txtStockID = new System.Windows.Forms.TextBox();
            this.txtUnitID = new System.Windows.Forms.TextBox();
            this.txtProjectID = new System.Windows.Forms.TextBox();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dt_ChqDate = new System.Windows.Forms.DateTimePicker();
            this.txtChqNo = new System.Windows.Forms.TextBox();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.txtCOA = new System.Windows.Forms.TextBox();
            this.txtSRNO = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grp_Voucher = new System.Windows.Forms.GroupBox();
            this.cBoxVouType = new System.Windows.Forms.ComboBox();
            this.dt_VoucherDate = new System.Windows.Forms.DateTimePicker();
            this.lblVoucherDate = new System.Windows.Forms.Label();
            this.txtVou_No = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.Pages = new System.Windows.Forms.TabControl();
            this.P2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Voucher)).BeginInit();
            this.P1.SuspendLayout();
            this.grp_Action.SuspendLayout();
            this.grp_Transactions.SuspendLayout();
            this.grp_Voucher.SuspendLayout();
            this.Pages.SuspendLayout();
            this.SuspendLayout();
            // 
            // P2
            // 
            this.P2.Controls.Add(this.Stop);
            this.P2.Controls.Add(this.Grid_Voucher);
            this.P2.Location = new System.Drawing.Point(4, 22);
            this.P2.Name = "P2";
            this.P2.Padding = new System.Windows.Forms.Padding(3);
            this.P2.Size = new System.Drawing.Size(701, 561);
            this.P2.TabIndex = 1;
            this.P2.Text = "TRANSACTIONS";
            this.P2.UseVisualStyleBackColor = true;
            this.P2.Enter += new System.EventHandler(this.P2_Enter);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(616, 522);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 23);
            this.Stop.TabIndex = 1;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            // 
            // Grid_Voucher
            // 
            this.Grid_Voucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Voucher.Location = new System.Drawing.Point(6, 6);
            this.Grid_Voucher.Name = "Grid_Voucher";
            this.Grid_Voucher.Size = new System.Drawing.Size(692, 510);
            this.Grid_Voucher.TabIndex = 0;
            this.Grid_Voucher.Enter += new System.EventHandler(this.Grid_Voucher_Enter);
            this.Grid_Voucher.Leave += new System.EventHandler(this.Grid_Voucher_Leave);
            // 
            // P1
            // 
            this.P1.Controls.Add(this.grp_Action);
            this.P1.Controls.Add(this.grp_Transactions);
            this.P1.Controls.Add(this.grp_Voucher);
            this.P1.Controls.Add(this.lblMessage);
            this.P1.Location = new System.Drawing.Point(4, 22);
            this.P1.Name = "P1";
            this.P1.Padding = new System.Windows.Forms.Padding(3);
            this.P1.Size = new System.Drawing.Size(701, 561);
            this.P1.TabIndex = 0;
            this.P1.Text = "VOUCHER";
            this.P1.UseVisualStyleBackColor = true;
            // 
            // grp_Action
            // 
            this.grp_Action.Controls.Add(this.btnSave);
            this.grp_Action.Controls.Add(this.btnRefresh);
            this.grp_Action.Controls.Add(this.btnPrint);
            this.grp_Action.Location = new System.Drawing.Point(6, 465);
            this.grp_Action.Name = "grp_Action";
            this.grp_Action.Size = new System.Drawing.Size(684, 60);
            this.grp_Action.TabIndex = 3;
            this.grp_Action.TabStop = false;
            this.grp_Action.Text = "ACTION";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(594, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(513, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // grp_Transactions
            // 
            this.grp_Transactions.Controls.Add(this.btnDelete);
            this.grp_Transactions.Controls.Add(this.label12);
            this.grp_Transactions.Controls.Add(this.btnBottom);
            this.grp_Transactions.Controls.Add(this.btnNext);
            this.grp_Transactions.Controls.Add(this.btnPrevious);
            this.grp_Transactions.Controls.Add(this.btnTop);
            this.grp_Transactions.Controls.Add(this.btnNew);
            this.grp_Transactions.Controls.Add(this.label5);
            this.grp_Transactions.Controls.Add(this.label4);
            this.grp_Transactions.Controls.Add(this.txtCR);
            this.grp_Transactions.Controls.Add(this.txtDR);
            this.grp_Transactions.Controls.Add(this.cBoxPOrder);
            this.grp_Transactions.Controls.Add(this.btnEmployees);
            this.grp_Transactions.Controls.Add(this.btnStocks);
            this.grp_Transactions.Controls.Add(this.btnUnits);
            this.grp_Transactions.Controls.Add(this.btnProjects);
            this.grp_Transactions.Controls.Add(this.btnSuppliers);
            this.grp_Transactions.Controls.Add(this.btnAccounts);
            this.grp_Transactions.Controls.Add(this.cBoxEmployee);
            this.grp_Transactions.Controls.Add(this.cBoxStock);
            this.grp_Transactions.Controls.Add(this.cBoxUnit);
            this.grp_Transactions.Controls.Add(this.cBoxProject);
            this.grp_Transactions.Controls.Add(this.cBoxSupplier);
            this.grp_Transactions.Controls.Add(this.cBoxAccount);
            this.grp_Transactions.Controls.Add(this.txtEmployeeID);
            this.grp_Transactions.Controls.Add(this.txtStockID);
            this.grp_Transactions.Controls.Add(this.txtUnitID);
            this.grp_Transactions.Controls.Add(this.txtProjectID);
            this.grp_Transactions.Controls.Add(this.txtSupplierID);
            this.grp_Transactions.Controls.Add(this.txtAccountID);
            this.grp_Transactions.Controls.Add(this.txtRemarks);
            this.grp_Transactions.Controls.Add(this.txtDescription);
            this.grp_Transactions.Controls.Add(this.dt_ChqDate);
            this.grp_Transactions.Controls.Add(this.txtChqNo);
            this.grp_Transactions.Controls.Add(this.txtRefNo);
            this.grp_Transactions.Controls.Add(this.txtEmployee);
            this.grp_Transactions.Controls.Add(this.txtStock);
            this.grp_Transactions.Controls.Add(this.txtUnit);
            this.grp_Transactions.Controls.Add(this.txtProject);
            this.grp_Transactions.Controls.Add(this.txtSupplier);
            this.grp_Transactions.Controls.Add(this.txtCOA);
            this.grp_Transactions.Controls.Add(this.txtSRNO);
            this.grp_Transactions.Controls.Add(this.label18);
            this.grp_Transactions.Controls.Add(this.label17);
            this.grp_Transactions.Controls.Add(this.label16);
            this.grp_Transactions.Controls.Add(this.label15);
            this.grp_Transactions.Controls.Add(this.label14);
            this.grp_Transactions.Controls.Add(this.label11);
            this.grp_Transactions.Controls.Add(this.label10);
            this.grp_Transactions.Controls.Add(this.label9);
            this.grp_Transactions.Controls.Add(this.label8);
            this.grp_Transactions.Controls.Add(this.label7);
            this.grp_Transactions.Controls.Add(this.label6);
            this.grp_Transactions.Controls.Add(this.label3);
            this.grp_Transactions.Location = new System.Drawing.Point(6, 73);
            this.grp_Transactions.Name = "grp_Transactions";
            this.grp_Transactions.Size = new System.Drawing.Size(684, 386);
            this.grp_Transactions.TabIndex = 2;
            this.grp_Transactions.TabStop = false;
            this.grp_Transactions.Text = "TRANSACTIONS";
            this.grp_Transactions.Enter += new System.EventHandler(this.grp_Transactions_Enter);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkRed;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.Location = new System.Drawing.Point(282, 28);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 21);
            this.btnDelete.TabIndex = 153;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(271, 223);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 152;
            this.label12.Text = "Purchase Order";
            // 
            // btnBottom
            // 
            this.btnBottom.Location = new System.Drawing.Point(566, 28);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(45, 21);
            this.btnBottom.TabIndex = 151;
            this.btnBottom.TabStop = false;
            this.btnBottom.Text = ">>";
            this.btnBottom.UseVisualStyleBackColor = true;
            this.btnBottom.Click += new System.EventHandler(this.btnBottom_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(515, 28);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(45, 21);
            this.btnNext.TabIndex = 150;
            this.btnNext.TabStop = false;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(466, 28);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(45, 21);
            this.btnPrevious.TabIndex = 149;
            this.btnPrevious.TabStop = false;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnTop
            // 
            this.btnTop.Location = new System.Drawing.Point(415, 28);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(45, 21);
            this.btnTop.TabIndex = 148;
            this.btnTop.TabStop = false;
            this.btnTop.Text = "<<";
            this.btnTop.UseVisualStyleBackColor = true;
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(231, 28);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(45, 21);
            this.btnNew.TabIndex = 147;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(402, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 146;
            this.label5.Text = "Credit (CR)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(405, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 145;
            this.label4.Text = "Debit (DR)";
            // 
            // txtCR
            // 
            this.txtCR.BackColor = System.Drawing.SystemColors.Info;
            this.txtCR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCR.Location = new System.Drawing.Point(500, 255);
            this.txtCR.Name = "txtCR";
            this.txtCR.Size = new System.Drawing.Size(140, 26);
            this.txtCR.TabIndex = 13;
            this.txtCR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCR.TextChanged += new System.EventHandler(this.txtCR_TextChanged);
            this.txtCR.Leave += new System.EventHandler(this.txtCR_Leave);
            // 
            // txtDR
            // 
            this.txtDR.BackColor = System.Drawing.SystemColors.Info;
            this.txtDR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDR.Location = new System.Drawing.Point(500, 223);
            this.txtDR.Name = "txtDR";
            this.txtDR.Size = new System.Drawing.Size(140, 26);
            this.txtDR.TabIndex = 12;
            this.txtDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDR.TextChanged += new System.EventHandler(this.txtDR_TextChanged);
            this.txtDR.Leave += new System.EventHandler(this.txtDR_Leave);
            // 
            // cBoxPOrder
            // 
            this.cBoxPOrder.FormattingEnabled = true;
            this.cBoxPOrder.ItemHeight = 13;
            this.cBoxPOrder.Location = new System.Drawing.Point(231, 244);
            this.cBoxPOrder.Name = "cBoxPOrder";
            this.cBoxPOrder.Size = new System.Drawing.Size(121, 21);
            this.cBoxPOrder.TabIndex = 11;
            // 
            // btnEmployees
            // 
            this.btnEmployees.Location = new System.Drawing.Point(619, 190);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(21, 21);
            this.btnEmployees.TabIndex = 141;
            this.btnEmployees.TabStop = false;
            this.btnEmployees.Text = "...";
            this.btnEmployees.UseVisualStyleBackColor = true;
            // 
            // btnStocks
            // 
            this.btnStocks.Location = new System.Drawing.Point(619, 163);
            this.btnStocks.Name = "btnStocks";
            this.btnStocks.Size = new System.Drawing.Size(21, 21);
            this.btnStocks.TabIndex = 140;
            this.btnStocks.TabStop = false;
            this.btnStocks.Text = "...";
            this.btnStocks.UseVisualStyleBackColor = true;
            // 
            // btnUnits
            // 
            this.btnUnits.Location = new System.Drawing.Point(619, 136);
            this.btnUnits.Name = "btnUnits";
            this.btnUnits.Size = new System.Drawing.Size(21, 21);
            this.btnUnits.TabIndex = 139;
            this.btnUnits.TabStop = false;
            this.btnUnits.Text = "...";
            this.btnUnits.UseVisualStyleBackColor = true;
            // 
            // btnProjects
            // 
            this.btnProjects.Location = new System.Drawing.Point(620, 109);
            this.btnProjects.Name = "btnProjects";
            this.btnProjects.Size = new System.Drawing.Size(21, 21);
            this.btnProjects.TabIndex = 138;
            this.btnProjects.TabStop = false;
            this.btnProjects.Text = "...";
            this.btnProjects.UseVisualStyleBackColor = true;
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Location = new System.Drawing.Point(620, 82);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(21, 21);
            this.btnSuppliers.TabIndex = 137;
            this.btnSuppliers.TabStop = false;
            this.btnSuppliers.Text = "...";
            this.btnSuppliers.UseVisualStyleBackColor = true;
            // 
            // btnAccounts
            // 
            this.btnAccounts.Location = new System.Drawing.Point(620, 55);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(21, 21);
            this.btnAccounts.TabIndex = 136;
            this.btnAccounts.TabStop = false;
            this.btnAccounts.Text = "...";
            this.btnAccounts.UseVisualStyleBackColor = true;
            // 
            // cBoxEmployee
            // 
            this.cBoxEmployee.FormattingEnabled = true;
            this.cBoxEmployee.Location = new System.Drawing.Point(231, 190);
            this.cBoxEmployee.Name = "cBoxEmployee";
            this.cBoxEmployee.Size = new System.Drawing.Size(380, 21);
            this.cBoxEmployee.TabIndex = 135;
            this.cBoxEmployee.TabStop = false;
            this.cBoxEmployee.SelectedIndexChanged += new System.EventHandler(this.cBoxEmployee_SelectedIndexChanged);
            // 
            // cBoxStock
            // 
            this.cBoxStock.FormattingEnabled = true;
            this.cBoxStock.Location = new System.Drawing.Point(232, 163);
            this.cBoxStock.Name = "cBoxStock";
            this.cBoxStock.Size = new System.Drawing.Size(380, 21);
            this.cBoxStock.TabIndex = 134;
            this.cBoxStock.TabStop = false;
            this.cBoxStock.SelectedIndexChanged += new System.EventHandler(this.cBoxStock_SelectedIndexChanged);
            // 
            // cBoxUnit
            // 
            this.cBoxUnit.FormattingEnabled = true;
            this.cBoxUnit.Location = new System.Drawing.Point(231, 136);
            this.cBoxUnit.Name = "cBoxUnit";
            this.cBoxUnit.Size = new System.Drawing.Size(380, 21);
            this.cBoxUnit.TabIndex = 133;
            this.cBoxUnit.TabStop = false;
            this.cBoxUnit.SelectedIndexChanged += new System.EventHandler(this.cBoxUnit_SelectedIndexChanged);
            // 
            // cBoxProject
            // 
            this.cBoxProject.FormattingEnabled = true;
            this.cBoxProject.Location = new System.Drawing.Point(232, 109);
            this.cBoxProject.Name = "cBoxProject";
            this.cBoxProject.Size = new System.Drawing.Size(380, 21);
            this.cBoxProject.TabIndex = 132;
            this.cBoxProject.TabStop = false;
            this.cBoxProject.SelectedIndexChanged += new System.EventHandler(this.cBoxProject_SelectedIndexChanged);
            // 
            // cBoxSupplier
            // 
            this.cBoxSupplier.FormattingEnabled = true;
            this.cBoxSupplier.Location = new System.Drawing.Point(231, 82);
            this.cBoxSupplier.Name = "cBoxSupplier";
            this.cBoxSupplier.Size = new System.Drawing.Size(380, 21);
            this.cBoxSupplier.TabIndex = 131;
            this.cBoxSupplier.TabStop = false;
            this.cBoxSupplier.SelectedIndexChanged += new System.EventHandler(this.cBoxSupplier_SelectedIndexChanged);
            // 
            // cBoxAccount
            // 
            this.cBoxAccount.FormattingEnabled = true;
            this.cBoxAccount.Location = new System.Drawing.Point(232, 55);
            this.cBoxAccount.Name = "cBoxAccount";
            this.cBoxAccount.Size = new System.Drawing.Size(380, 21);
            this.cBoxAccount.TabIndex = 130;
            this.cBoxAccount.TabStop = false;
            this.cBoxAccount.SelectedIndexChanged += new System.EventHandler(this.cBoxAccount_SelectedIndexChanged);
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Enabled = false;
            this.txtEmployeeID.Location = new System.Drawing.Point(185, 191);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(40, 20);
            this.txtEmployeeID.TabIndex = 129;
            this.txtEmployeeID.TabStop = false;
            // 
            // txtStockID
            // 
            this.txtStockID.Enabled = false;
            this.txtStockID.Location = new System.Drawing.Point(185, 164);
            this.txtStockID.Name = "txtStockID";
            this.txtStockID.Size = new System.Drawing.Size(40, 20);
            this.txtStockID.TabIndex = 128;
            this.txtStockID.TabStop = false;
            // 
            // txtUnitID
            // 
            this.txtUnitID.Enabled = false;
            this.txtUnitID.Location = new System.Drawing.Point(185, 137);
            this.txtUnitID.Name = "txtUnitID";
            this.txtUnitID.Size = new System.Drawing.Size(40, 20);
            this.txtUnitID.TabIndex = 127;
            this.txtUnitID.TabStop = false;
            // 
            // txtProjectID
            // 
            this.txtProjectID.Enabled = false;
            this.txtProjectID.Location = new System.Drawing.Point(185, 110);
            this.txtProjectID.Name = "txtProjectID";
            this.txtProjectID.Size = new System.Drawing.Size(40, 20);
            this.txtProjectID.TabIndex = 126;
            this.txtProjectID.TabStop = false;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Enabled = false;
            this.txtSupplierID.Location = new System.Drawing.Point(185, 83);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.Size = new System.Drawing.Size(40, 20);
            this.txtSupplierID.TabIndex = 125;
            this.txtSupplierID.TabStop = false;
            // 
            // txtAccountID
            // 
            this.txtAccountID.Enabled = false;
            this.txtAccountID.Location = new System.Drawing.Point(185, 56);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.Size = new System.Drawing.Size(40, 20);
            this.txtAccountID.TabIndex = 124;
            this.txtAccountID.TabStop = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(125, 323);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(515, 50);
            this.txtRemarks.TabIndex = 15;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(125, 297);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(515, 20);
            this.txtDescription.TabIndex = 14;
            // 
            // dt_ChqDate
            // 
            this.dt_ChqDate.Location = new System.Drawing.Point(125, 271);
            this.dt_ChqDate.Name = "dt_ChqDate";
            this.dt_ChqDate.Size = new System.Drawing.Size(100, 20);
            this.dt_ChqDate.TabIndex = 10;
            // 
            // txtChqNo
            // 
            this.txtChqNo.Location = new System.Drawing.Point(125, 245);
            this.txtChqNo.Name = "txtChqNo";
            this.txtChqNo.Size = new System.Drawing.Size(100, 20);
            this.txtChqNo.TabIndex = 9;
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(125, 219);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(100, 20);
            this.txtRefNo.TabIndex = 8;
            // 
            // txtEmployee
            // 
            this.txtEmployee.Location = new System.Drawing.Point(125, 191);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.Size = new System.Drawing.Size(55, 20);
            this.txtEmployee.TabIndex = 7;
            this.txtEmployee.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmployee_Validating);
            this.txtEmployee.Validated += new System.EventHandler(this.txtEmployee_Validated);
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(125, 164);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(55, 20);
            this.txtStock.TabIndex = 6;
            this.txtStock.Validating += new System.ComponentModel.CancelEventHandler(this.txtStock_Validating);
            this.txtStock.Validated += new System.EventHandler(this.txtStock_Validated);
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(125, 137);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(55, 20);
            this.txtUnit.TabIndex = 5;
            this.txtUnit.Validating += new System.ComponentModel.CancelEventHandler(this.txtUnit_Validating);
            this.txtUnit.Validated += new System.EventHandler(this.txtUnit_Validated);
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(125, 110);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(55, 20);
            this.txtProject.TabIndex = 4;
            this.txtProject.Validating += new System.ComponentModel.CancelEventHandler(this.txtProject_Validating);
            this.txtProject.Validated += new System.EventHandler(this.txtProject_Validated);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(125, 83);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(55, 20);
            this.txtSupplier.TabIndex = 3;
            this.txtSupplier.Validating += new System.ComponentModel.CancelEventHandler(this.txtSupplier_Validating);
            this.txtSupplier.Validated += new System.EventHandler(this.txtSupplier_Validated);
            // 
            // txtCOA
            // 
            this.txtCOA.Location = new System.Drawing.Point(125, 56);
            this.txtCOA.Name = "txtCOA";
            this.txtCOA.Size = new System.Drawing.Size(55, 20);
            this.txtCOA.TabIndex = 2;
            this.txtCOA.Validating += new System.ComponentModel.CancelEventHandler(this.txtCOA_Validating);
            this.txtCOA.Validated += new System.EventHandler(this.txtCOA_Validated);
            // 
            // txtSRNO
            // 
            this.txtSRNO.Location = new System.Drawing.Point(125, 29);
            this.txtSRNO.Name = "txtSRNO";
            this.txtSRNO.Size = new System.Drawing.Size(100, 20);
            this.txtSRNO.TabIndex = 1;
            this.txtSRNO.Enter += new System.EventHandler(this.txtSRNO_Enter);
            this.txtSRNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSRNO_KeyPress);
            this.txtSRNO.Leave += new System.EventHandler(this.txtSRNO_Leave);
            this.txtSRNO.Validating += new System.ComponentModel.CancelEventHandler(this.txtSRNO_Validating);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(34, 223);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 13);
            this.label18.TabIndex = 111;
            this.label18.Text = "Ref. No";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(34, 328);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 110;
            this.label17.Text = "Comments";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(34, 301);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 109;
            this.label16.Text = "Description";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(34, 275);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 108;
            this.label15.Text = "Cheque Date";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(34, 250);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 107;
            this.label14.Text = "Cheque No.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 193);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 106;
            this.label11.Text = "Employee";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 105;
            this.label10.Text = "Stock";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 104;
            this.label9.Text = "Units";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 103;
            this.label8.Text = "Project";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 102;
            this.label7.Text = "Vendor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 101;
            this.label6.Text = "Account";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 100;
            this.label3.Text = "Sr No.";
            // 
            // grp_Voucher
            // 
            this.grp_Voucher.Controls.Add(this.cBoxVouType);
            this.grp_Voucher.Controls.Add(this.dt_VoucherDate);
            this.grp_Voucher.Controls.Add(this.lblVoucherDate);
            this.grp_Voucher.Controls.Add(this.txtVou_No);
            this.grp_Voucher.Controls.Add(this.label2);
            this.grp_Voucher.Controls.Add(this.label1);
            this.grp_Voucher.Location = new System.Drawing.Point(6, 6);
            this.grp_Voucher.Name = "grp_Voucher";
            this.grp_Voucher.Size = new System.Drawing.Size(684, 60);
            this.grp_Voucher.TabIndex = 1;
            this.grp_Voucher.TabStop = false;
            this.grp_Voucher.Text = "VOUCHER";
            // 
            // cBoxVouType
            // 
            this.cBoxVouType.FormattingEnabled = true;
            this.cBoxVouType.Location = new System.Drawing.Point(327, 26);
            this.cBoxVouType.Name = "cBoxVouType";
            this.cBoxVouType.Size = new System.Drawing.Size(100, 21);
            this.cBoxVouType.TabIndex = 2;
            // 
            // dt_VoucherDate
            // 
            this.dt_VoucherDate.CustomFormat = "dd-MMM-yyyy";
            this.dt_VoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_VoucherDate.Location = new System.Drawing.Point(535, 26);
            this.dt_VoucherDate.Name = "dt_VoucherDate";
            this.dt_VoucherDate.Size = new System.Drawing.Size(115, 20);
            this.dt_VoucherDate.TabIndex = 3;
            // 
            // lblVoucherDate
            // 
            this.lblVoucherDate.AutoSize = true;
            this.lblVoucherDate.Location = new System.Drawing.Point(455, 32);
            this.lblVoucherDate.Name = "lblVoucherDate";
            this.lblVoucherDate.Size = new System.Drawing.Size(73, 13);
            this.lblVoucherDate.TabIndex = 10;
            this.lblVoucherDate.Text = "Voucher Date";
            // 
            // txtVou_No
            // 
            this.txtVou_No.Location = new System.Drawing.Point(125, 26);
            this.txtVou_No.Name = "txtVou_No";
            this.txtVou_No.Size = new System.Drawing.Size(100, 20);
            this.txtVou_No.TabIndex = 1;
            this.txtVou_No.Leave += new System.EventHandler(this.txtVou_No_Leave);
            this.txtVou_No.Validating += new System.ComponentModel.CancelEventHandler(this.txtVou_No_Validating);
            this.txtVou_No.Validated += new System.EventHandler(this.txtVou_No_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Voucher No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Voucher Type";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(7, 532);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(45, 13);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Mesage";
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
            this.Pages.Size = new System.Drawing.Size(709, 587);
            this.Pages.TabIndex = 0;
            // 
            // frmVouchers2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 611);
            this.Controls.Add(this.Pages);
            this.Name = "frmVouchers2";
            this.Text = "Voucher1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVouchers1_FormClosing);
            this.Load += new System.EventHandler(this.frmVouchers1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmVouchers1_Paint);
            this.P2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Voucher)).EndInit();
            this.P1.ResumeLayout(false);
            this.P1.PerformLayout();
            this.grp_Action.ResumeLayout(false);
            this.grp_Transactions.ResumeLayout(false);
            this.grp_Transactions.PerformLayout();
            this.grp_Voucher.ResumeLayout(false);
            this.grp_Voucher.PerformLayout();
            this.Pages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage P2;
        private System.Windows.Forms.DataGridView Grid_Voucher;
        private System.Windows.Forms.TabPage P1;
        private System.Windows.Forms.GroupBox grp_Action;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox grp_Transactions;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnBottom;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnTop;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCR;
        private System.Windows.Forms.TextBox txtDR;
        private System.Windows.Forms.ComboBox cBoxPOrder;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnStocks;
        private System.Windows.Forms.Button btnUnits;
        private System.Windows.Forms.Button btnProjects;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.ComboBox cBoxEmployee;
        private System.Windows.Forms.ComboBox cBoxStock;
        private System.Windows.Forms.ComboBox cBoxUnit;
        private System.Windows.Forms.ComboBox cBoxProject;
        private System.Windows.Forms.ComboBox cBoxSupplier;
        private System.Windows.Forms.ComboBox cBoxAccount;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.TextBox txtStockID;
        private System.Windows.Forms.TextBox txtUnitID;
        private System.Windows.Forms.TextBox txtProjectID;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dt_ChqDate;
        private System.Windows.Forms.TextBox txtChqNo;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.TextBox txtCOA;
        private System.Windows.Forms.TextBox txtSRNO;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grp_Voucher;
        private System.Windows.Forms.ComboBox cBoxVouType;
        private System.Windows.Forms.DateTimePicker dt_VoucherDate;
        private System.Windows.Forms.Label lblVoucherDate;
        private System.Windows.Forms.TextBox txtVou_No;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TabControl Pages;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button Stop;
    }
}