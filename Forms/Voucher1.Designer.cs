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
            this.Grid_Voucher = new System.Windows.Forms.DataGridView();
            this.P1 = new System.Windows.Forms.TabPage();
            this.grp_Action = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.grp_Transactions = new System.Windows.Forms.GroupBox();
            this.Imp_Employees = new System.Windows.Forms.PictureBox();
            this.Img_Stock = new System.Windows.Forms.PictureBox();
            this.brws_Employees = new System.Windows.Forms.PictureBox();
            this.brws_Stock = new System.Windows.Forms.PictureBox();
            this.brws_Units = new System.Windows.Forms.PictureBox();
            this.brws_Projects = new System.Windows.Forms.PictureBox();
            this.brws_Suppliers = new System.Windows.Forms.PictureBox();
            this.brws_Accounts = new System.Windows.Forms.PictureBox();
            this.btnActive = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
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
            this.cBoxEmployee = new System.Windows.Forms.ComboBox();
            this.cBoxStock = new System.Windows.Forms.ComboBox();
            this.cBoxUnit = new System.Windows.Forms.ComboBox();
            this.cBoxProject = new System.Windows.Forms.ComboBox();
            this.cBoxSupplier = new System.Windows.Forms.ComboBox();
            this.cBoxAccount = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.Imp_Employees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img_Stock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brws_Employees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brws_Stock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brws_Units)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brws_Projects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brws_Suppliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brws_Accounts)).BeginInit();
            this.grp_Voucher.SuspendLayout();
            this.Pages.SuspendLayout();
            this.SuspendLayout();
            // 
            // P2
            // 
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
            // Grid_Voucher
            // 
            this.Grid_Voucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Voucher.Location = new System.Drawing.Point(6, 6);
            this.Grid_Voucher.Name = "Grid_Voucher";
            this.Grid_Voucher.Size = new System.Drawing.Size(689, 549);
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
            this.P1.Size = new System.Drawing.Size(707, 561);
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
            this.btnSave.Image = global::Applied_Accounts.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(606, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(35, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::Applied_Accounts.Properties.Resources.Exit2;
            this.btnRefresh.Location = new System.Drawing.Point(11, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(35, 35);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Applied_Accounts.Properties.Resources.PRINT;
            this.btnPrint.Location = new System.Drawing.Point(565, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(35, 35);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // grp_Transactions
            // 
            this.grp_Transactions.Controls.Add(this.Imp_Employees);
            this.grp_Transactions.Controls.Add(this.Img_Stock);
            this.grp_Transactions.Controls.Add(this.brws_Employees);
            this.grp_Transactions.Controls.Add(this.brws_Stock);
            this.grp_Transactions.Controls.Add(this.brws_Units);
            this.grp_Transactions.Controls.Add(this.brws_Projects);
            this.grp_Transactions.Controls.Add(this.brws_Suppliers);
            this.grp_Transactions.Controls.Add(this.brws_Accounts);
            this.grp_Transactions.Controls.Add(this.btnActive);
            this.grp_Transactions.Controls.Add(this.btnCopy);
            this.grp_Transactions.Controls.Add(this.btnUndo);
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
            this.grp_Transactions.Controls.Add(this.cBoxEmployee);
            this.grp_Transactions.Controls.Add(this.cBoxStock);
            this.grp_Transactions.Controls.Add(this.cBoxUnit);
            this.grp_Transactions.Controls.Add(this.cBoxProject);
            this.grp_Transactions.Controls.Add(this.cBoxSupplier);
            this.grp_Transactions.Controls.Add(this.cBoxAccount);
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
            // Imp_Employees
            // 
            this.Imp_Employees.Image = global::Applied_Accounts.Properties.Resources.Employee;
            this.Imp_Employees.Location = new System.Drawing.Point(644, 193);
            this.Imp_Employees.Name = "Imp_Employees";
            this.Imp_Employees.Size = new System.Drawing.Size(20, 20);
            this.Imp_Employees.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Imp_Employees.TabIndex = 160;
            this.Imp_Employees.TabStop = false;
            this.Imp_Employees.Click += new System.EventHandler(this.Imp_Employees_Click);
            // 
            // Img_Stock
            // 
            this.Img_Stock.Image = global::Applied_Accounts.Properties.Resources.Stock;
            this.Img_Stock.Location = new System.Drawing.Point(644, 166);
            this.Img_Stock.Name = "Img_Stock";
            this.Img_Stock.Size = new System.Drawing.Size(20, 20);
            this.Img_Stock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Img_Stock.TabIndex = 159;
            this.Img_Stock.TabStop = false;
            this.Img_Stock.Click += new System.EventHandler(this.Img_Stock_Click);
            // 
            // brws_Employees
            // 
            this.brws_Employees.Image = global::Applied_Accounts.Properties.Resources.search;
            this.brws_Employees.Location = new System.Drawing.Point(621, 192);
            this.brws_Employees.Name = "brws_Employees";
            this.brws_Employees.Size = new System.Drawing.Size(17, 20);
            this.brws_Employees.TabIndex = 158;
            this.brws_Employees.TabStop = false;
            this.brws_Employees.Click += new System.EventHandler(this.brws_Employees_Click);
            // 
            // brws_Stock
            // 
            this.brws_Stock.Image = global::Applied_Accounts.Properties.Resources.search;
            this.brws_Stock.Location = new System.Drawing.Point(621, 165);
            this.brws_Stock.Name = "brws_Stock";
            this.brws_Stock.Size = new System.Drawing.Size(17, 20);
            this.brws_Stock.TabIndex = 157;
            this.brws_Stock.TabStop = false;
            this.brws_Stock.Click += new System.EventHandler(this.brws_Stock_Click);
            // 
            // brws_Units
            // 
            this.brws_Units.Image = global::Applied_Accounts.Properties.Resources.search;
            this.brws_Units.Location = new System.Drawing.Point(621, 139);
            this.brws_Units.Name = "brws_Units";
            this.brws_Units.Size = new System.Drawing.Size(17, 20);
            this.brws_Units.TabIndex = 156;
            this.brws_Units.TabStop = false;
            this.brws_Units.Click += new System.EventHandler(this.brws_Units_Click);
            // 
            // brws_Projects
            // 
            this.brws_Projects.Image = global::Applied_Accounts.Properties.Resources.search;
            this.brws_Projects.Location = new System.Drawing.Point(622, 112);
            this.brws_Projects.Name = "brws_Projects";
            this.brws_Projects.Size = new System.Drawing.Size(17, 20);
            this.brws_Projects.TabIndex = 155;
            this.brws_Projects.TabStop = false;
            this.brws_Projects.Click += new System.EventHandler(this.brws_Projects_Click);
            // 
            // brws_Suppliers
            // 
            this.brws_Suppliers.Image = global::Applied_Accounts.Properties.Resources.search;
            this.brws_Suppliers.Location = new System.Drawing.Point(623, 83);
            this.brws_Suppliers.Name = "brws_Suppliers";
            this.brws_Suppliers.Size = new System.Drawing.Size(17, 20);
            this.brws_Suppliers.TabIndex = 154;
            this.brws_Suppliers.TabStop = false;
            this.brws_Suppliers.Click += new System.EventHandler(this.brws_Suppliers_Click);
            // 
            // brws_Accounts
            // 
            this.brws_Accounts.Image = global::Applied_Accounts.Properties.Resources.search;
            this.brws_Accounts.Location = new System.Drawing.Point(623, 56);
            this.brws_Accounts.Name = "brws_Accounts";
            this.brws_Accounts.Size = new System.Drawing.Size(17, 20);
            this.brws_Accounts.TabIndex = 153;
            this.brws_Accounts.TabStop = false;
            this.brws_Accounts.Click += new System.EventHandler(this.brws_Accounts_Click);
            // 
            // btnActive
            // 
            this.btnActive.Image = global::Applied_Accounts.Properties.Resources.Active_Rows;
            this.btnActive.Location = new System.Drawing.Point(347, 26);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(29, 23);
            this.btnActive.TabIndex = 55;
            this.btnActive.TabStop = false;
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::Applied_Accounts.Properties.Resources.Copy;
            this.btnCopy.Location = new System.Drawing.Point(312, 26);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(29, 23);
            this.btnCopy.TabIndex = 54;
            this.btnCopy.TabStop = false;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Image = global::Applied_Accounts.Properties.Resources.UNDO;
            this.btnUndo.Location = new System.Drawing.Point(277, 28);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(29, 21);
            this.btnUndo.TabIndex = 53;
            this.btnUndo.TabStop = false;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.Image = global::Applied_Accounts.Properties.Resources.delete1;
            this.btnDelete.Location = new System.Drawing.Point(242, 28);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 21);
            this.btnDelete.TabIndex = 52;
            this.btnDelete.TabStop = false;
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
            this.btnBottom.Image = global::Applied_Accounts.Properties.Resources.BOTTOM;
            this.btnBottom.Location = new System.Drawing.Point(566, 28);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(45, 21);
            this.btnBottom.TabIndex = 59;
            this.btnBottom.TabStop = false;
            this.btnBottom.UseVisualStyleBackColor = true;
            this.btnBottom.Click += new System.EventHandler(this.btnBottom_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = global::Applied_Accounts.Properties.Resources.NEXT;
            this.btnNext.Location = new System.Drawing.Point(516, 28);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(45, 21);
            this.btnNext.TabIndex = 58;
            this.btnNext.TabStop = false;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Image = global::Applied_Accounts.Properties.Resources.BACK;
            this.btnPrevious.Location = new System.Drawing.Point(466, 28);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(45, 21);
            this.btnPrevious.TabIndex = 57;
            this.btnPrevious.TabStop = false;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnTop
            // 
            this.btnTop.Image = global::Applied_Accounts.Properties.Resources.TOP;
            this.btnTop.Location = new System.Drawing.Point(416, 28);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(45, 21);
            this.btnTop.TabIndex = 56;
            this.btnTop.TabStop = false;
            this.btnTop.UseVisualStyleBackColor = true;
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::Applied_Accounts.Properties.Resources.add;
            this.btnNew.Location = new System.Drawing.Point(207, 28);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(29, 21);
            this.btnNew.TabIndex = 51;
            this.btnNew.TabStop = false;
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
            this.txtCR.Enter += new System.EventHandler(this.txtCR_Enter);
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
            this.txtDR.Enter += new System.EventHandler(this.txtDR_Enter);
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
            // cBoxEmployee
            // 
            this.cBoxEmployee.FormattingEnabled = true;
            this.cBoxEmployee.Location = new System.Drawing.Point(204, 190);
            this.cBoxEmployee.Name = "cBoxEmployee";
            this.cBoxEmployee.Size = new System.Drawing.Size(407, 21);
            this.cBoxEmployee.TabIndex = 135;
            this.cBoxEmployee.TabStop = false;
            this.cBoxEmployee.SelectedIndexChanged += new System.EventHandler(this.cBoxEmployee_SelectedIndexChanged);
            // 
            // cBoxStock
            // 
            this.cBoxStock.FormattingEnabled = true;
            this.cBoxStock.Location = new System.Drawing.Point(205, 163);
            this.cBoxStock.Name = "cBoxStock";
            this.cBoxStock.Size = new System.Drawing.Size(407, 21);
            this.cBoxStock.TabIndex = 134;
            this.cBoxStock.TabStop = false;
            this.cBoxStock.SelectedIndexChanged += new System.EventHandler(this.cBoxStock_SelectedIndexChanged);
            // 
            // cBoxUnit
            // 
            this.cBoxUnit.FormattingEnabled = true;
            this.cBoxUnit.Location = new System.Drawing.Point(204, 136);
            this.cBoxUnit.Name = "cBoxUnit";
            this.cBoxUnit.Size = new System.Drawing.Size(407, 21);
            this.cBoxUnit.TabIndex = 133;
            this.cBoxUnit.TabStop = false;
            this.cBoxUnit.SelectedIndexChanged += new System.EventHandler(this.cBoxUnit_SelectedIndexChanged);
            // 
            // cBoxProject
            // 
            this.cBoxProject.FormattingEnabled = true;
            this.cBoxProject.Location = new System.Drawing.Point(205, 109);
            this.cBoxProject.Name = "cBoxProject";
            this.cBoxProject.Size = new System.Drawing.Size(407, 21);
            this.cBoxProject.TabIndex = 132;
            this.cBoxProject.TabStop = false;
            this.cBoxProject.SelectedIndexChanged += new System.EventHandler(this.cBoxProject_SelectedIndexChanged);
            // 
            // cBoxSupplier
            // 
            this.cBoxSupplier.FormattingEnabled = true;
            this.cBoxSupplier.Location = new System.Drawing.Point(204, 82);
            this.cBoxSupplier.Name = "cBoxSupplier";
            this.cBoxSupplier.Size = new System.Drawing.Size(407, 21);
            this.cBoxSupplier.TabIndex = 131;
            this.cBoxSupplier.TabStop = false;
            this.cBoxSupplier.SelectedIndexChanged += new System.EventHandler(this.cBoxSupplier_SelectedIndexChanged);
            // 
            // cBoxAccount
            // 
            this.cBoxAccount.FormattingEnabled = true;
            this.cBoxAccount.Location = new System.Drawing.Point(205, 55);
            this.cBoxAccount.Name = "cBoxAccount";
            this.cBoxAccount.Size = new System.Drawing.Size(407, 21);
            this.cBoxAccount.TabIndex = 130;
            this.cBoxAccount.TabStop = false;
            this.cBoxAccount.SelectedIndexChanged += new System.EventHandler(this.cBoxAccount_SelectedIndexChanged);
            this.cBoxAccount.Enter += new System.EventHandler(this.cBoxAccount_Enter);
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
            this.dt_ChqDate.CustomFormat = "dd-MMM-yyyy";
            this.dt_ChqDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
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
            this.txtEmployee.Size = new System.Drawing.Size(74, 20);
            this.txtEmployee.TabIndex = 7;
            this.txtEmployee.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmployee_Validating);
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(125, 164);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(74, 20);
            this.txtStock.TabIndex = 6;
            this.txtStock.Validating += new System.ComponentModel.CancelEventHandler(this.txtStock_Validating);
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(125, 137);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(74, 20);
            this.txtUnit.TabIndex = 5;
            this.txtUnit.Validating += new System.ComponentModel.CancelEventHandler(this.txtUnit_Validating);
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(125, 110);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(74, 20);
            this.txtProject.TabIndex = 4;
            this.txtProject.Validating += new System.ComponentModel.CancelEventHandler(this.txtProject_Validating);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(125, 83);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(74, 20);
            this.txtSupplier.TabIndex = 3;
            this.txtSupplier.Validating += new System.ComponentModel.CancelEventHandler(this.txtSupplier_Validating);
            // 
            // txtCOA
            // 
            this.txtCOA.Location = new System.Drawing.Point(125, 56);
            this.txtCOA.Name = "txtCOA";
            this.txtCOA.Size = new System.Drawing.Size(74, 20);
            this.txtCOA.TabIndex = 2;
            this.txtCOA.Validating += new System.ComponentModel.CancelEventHandler(this.txtCOA_Validating);
            // 
            // txtSRNO
            // 
            this.txtSRNO.HideSelection = false;
            this.txtSRNO.Location = new System.Drawing.Point(125, 29);
            this.txtSRNO.Name = "txtSRNO";
            this.txtSRNO.Size = new System.Drawing.Size(74, 20);
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
            this.cBoxVouType.Validating += new System.ComponentModel.CancelEventHandler(this.cBoxVouType_Validating);
            // 
            // dt_VoucherDate
            // 
            this.dt_VoucherDate.CustomFormat = "dd-MMM-yyyy";
            this.dt_VoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_VoucherDate.Location = new System.Drawing.Point(535, 26);
            this.dt_VoucherDate.Name = "dt_VoucherDate";
            this.dt_VoucherDate.Size = new System.Drawing.Size(115, 20);
            this.dt_VoucherDate.TabIndex = 3;
            this.dt_VoucherDate.Leave += new System.EventHandler(this.dt_VoucherDate_Leave);
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
            this.txtVou_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
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
            this.label2.DoubleClick += new System.EventHandler(this.label2_DoubleClick);
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
            this.Pages.Size = new System.Drawing.Size(715, 587);
            this.Pages.TabIndex = 0;
            // 
            // frmVouchers1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 611);
            this.Controls.Add(this.Pages);
            this.Name = "frmVouchers1";
            this.Text = "Voucher1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVouchers1_FormClosing);
            this.Load += new System.EventHandler(this.frmVouchers1_Load);
            this.P2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Voucher)).EndInit();
            this.P1.ResumeLayout(false);
            this.P1.PerformLayout();
            this.grp_Action.ResumeLayout(false);
            this.grp_Transactions.ResumeLayout(false);
            this.grp_Transactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Imp_Employees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img_Stock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brws_Employees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brws_Stock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brws_Units)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brws_Projects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brws_Suppliers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brws_Accounts)).EndInit();
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
        private System.Windows.Forms.ComboBox cBoxEmployee;
        private System.Windows.Forms.ComboBox cBoxStock;
        private System.Windows.Forms.ComboBox cBoxUnit;
        private System.Windows.Forms.ComboBox cBoxProject;
        private System.Windows.Forms.ComboBox cBoxSupplier;
        private System.Windows.Forms.ComboBox cBoxAccount;
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
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.PictureBox brws_Employees;
        private System.Windows.Forms.PictureBox brws_Stock;
        private System.Windows.Forms.PictureBox brws_Units;
        private System.Windows.Forms.PictureBox brws_Projects;
        private System.Windows.Forms.PictureBox brws_Suppliers;
        private System.Windows.Forms.PictureBox brws_Accounts;
        private System.Windows.Forms.PictureBox Img_Stock;
        private System.Windows.Forms.PictureBox Imp_Employees;
    }
}