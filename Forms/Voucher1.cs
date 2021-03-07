using Applied_Accounts.Classes;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Applied_Accounts.Forms
{
    public partial class frmVouchers1 : Form
    {

        private string NumberFormat = Applied.GetString("CurrencyFormat");
        private string DateFormat = Applied.GetString("DataFormat");
        private string ComboDateFormat = Applied.GetString("DateFormat_Combo");

        public static TextBox_Validation MyValidation = new TextBox_Validation();
        public static VoucherClass1 MyVoucherClass = new VoucherClass1();

        private string MyCheque_No;                                 // For copy and past
        private string MyCheque_Date;                               // For copy and past
        private string MyRefNo;                                     // For copy and past
        private string MyPOrder;                                    // For copy and past
        private string MyDescription;                               // For copy and past
        private string MyRemarks;                                   // for Copy and past.

        private DataTable tb_Accounts { get => MyVoucherClass.ds_Voucher.Tables["COA"]; }
        private DataTable tb_Suppliers { get => MyVoucherClass.ds_Voucher.Tables["Suppliers"]; }
        private DataTable tb_Projects { get => MyVoucherClass.ds_Voucher.Tables["Projects"]; }
        private DataTable tb_Units { get => MyVoucherClass.ds_Voucher.Tables["Units"]; }
        private DataTable tb_Stock { get => MyVoucherClass.ds_Voucher.Tables["Stock"]; }
        private DataTable tb_Employees { get => MyVoucherClass.ds_Voucher.Tables["Employees"]; }
        private DataTable tb_POrder { get => MyVoucherClass.ds_Voucher.Tables["POrder"]; }
        private DataTable tb_Voucher { get => MyVoucherClass.tb_Voucher; }
        private DataTable tb_voucher_Delete { get => MyVoucherClass.tb_Voucher_Delete; }
        private DataTable tb_GridData { get => MyVoucherClass.tb_GridData; }

        private BindingManagerBase TableBinding;
        private BindingManagerBase POrderBinding;
        private System.Data.DataSet MyDataSource;


        private decimal Total_DR, Total_CR;                     // Store Total Amount of DE & CR 

        private bool Vou_Found;
        private bool Initializaion = true;
        private bool IsNullAllowed = false;


        #region Initialization

        public frmVouchers1()
        {
            InitializeComponent();
            MyVoucherClass.Load_Tables();                   // Load Table in vocuehr Class

            grp_Transactions.Visible = false;
            grp_Action.Visible = false;

            txtVou_No.Focus();
            Vou_Found = false;


            // Binding Setup

            MyDataSource = MyVoucherClass.ds_Voucher;
            TableBinding = BindingContext[MyVoucherClass.tb_Voucher];
            POrderBinding = BindingContext[tb_POrder];

            TableBinding.PositionChanged += new EventHandler(TableBinding_PositionChange);
            TableBinding.CurrentChanged += new EventHandler(TableBinding_CurrentChange);

            // ======================= END

            Set_ComboBox();                                 // Combo box setting DisplayMemebr, ValueMembers & DataSource
            Set_DataBinding();
            Set_DataGrid();
            Initializaion = false;                              // All Objects have been initialized.

        }

        private void Set_ComboBox()
        {
            //if(MyDataSource==null) { return; }

            cBoxAccount.DataSource = MyDataSource;
            cBoxSupplier.DataSource = MyDataSource;
            cBoxProject.DataSource = MyDataSource;
            cBoxUnit.DataSource = MyDataSource;
            cBoxStock.DataSource = MyDataSource;
            cBoxEmployee.DataSource = MyDataSource;
            cBoxPOrder.DataSource = MyDataSource;

            cBoxAccount.DisplayMember = "COA.Title";
            cBoxSupplier.DisplayMember = "Suppliers.Title";
            cBoxProject.DisplayMember = "Projects.Title";
            cBoxUnit.DisplayMember = "Units.Title";
            cBoxStock.DisplayMember = "Stock.Title";
            cBoxEmployee.DisplayMember = "Employees.Title";
            cBoxPOrder.DisplayMember = "POrder.Title";

            cBoxAccount.ValueMember = "COA.ID";
            cBoxSupplier.ValueMember = "Suppliers.ID";
            cBoxProject.ValueMember = "Projects.ID";
            cBoxUnit.ValueMember = "Units.ID";
            cBoxStock.ValueMember = "Stock.ID";
            cBoxEmployee.ValueMember = "Employees.ID";
            cBoxPOrder.ValueMember = "POrder.ID";

            cBoxVouType.DataSource = MyVoucherClass.Vou_Types;

            dt_VoucherDate.Format = DateTimePickerFormat.Custom;
            dt_ChqDate.Format = DateTimePickerFormat.Custom;

            dt_VoucherDate.CustomFormat = ComboDateFormat;
            dt_ChqDate.CustomFormat = ComboDateFormat;

        }

        private void frmVouchers1_Load(object sender, EventArgs e)
        {
            txtVou_No.Text = MyVoucherClass.Vou_No;
            dt_VoucherDate.Value = MyVoucherClass.Vou_Date;
            cBoxVouType.Text = MyVoucherClass.Vou_Type;

            txtVou_No.Focus();

        }

        private void dt_ChqDate_Layout(object sender, LayoutEventArgs e)
        {
            dt_ChqDate.Format = DateTimePickerFormat.Custom;
            dt_VoucherDate.CustomFormat = Program.DateTimeFormat;
        }

        private void dt_VoucherDate_Layout(object sender, LayoutEventArgs e)
        {
            dt_VoucherDate.Format = DateTimePickerFormat.Custom;
            dt_VoucherDate.CustomFormat = Program.DateTimeFormat;
        }

        #endregion

        #region Data Binding

        private void Set_DataBinding()
        {
            txtSRNO.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "SRNO", true, DataSourceUpdateMode.OnPropertyChanged));
            txtAccountID.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "COA", true, DataSourceUpdateMode.OnPropertyChanged));
            txtSupplierID.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "Supplier", true, DataSourceUpdateMode.OnPropertyChanged));
            txtProjectID.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "Project", true, DataSourceUpdateMode.OnPropertyChanged));
            txtUnitID.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "Unit", true, DataSourceUpdateMode.OnPropertyChanged));
            txtStockID.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "Stock", true, DataSourceUpdateMode.OnPropertyChanged));
            txtEmployeeID.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "Employee", true, DataSourceUpdateMode.OnPropertyChanged));

            txtRefNo.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "RefNo", true, DataSourceUpdateMode.OnPropertyChanged));
            txtChqNo.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "Chq_No", true, DataSourceUpdateMode.OnPropertyChanged));
            dt_ChqDate.DataBindings.Add(new Binding("Value", MyVoucherClass.tb_Voucher, "Chq_Date", true, DataSourceUpdateMode.OnPropertyChanged));
            txtDR.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "DR", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCR.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "CR", true, DataSourceUpdateMode.OnPropertyChanged));
            txtDescription.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "Description", true, DataSourceUpdateMode.OnPropertyChanged));
            txtRemarks.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "Remarks", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void TableBinding_PositionChange(object sender, EventArgs e)
        {

        }

        private void TableBinding_CurrentChange(object sender, EventArgs e)
        {

        }

        #endregion

        #region Form Paint


        private void frmVouchers1_Paint(object sender, PaintEventArgs e)
        {
            PositionChange();
        }

        #endregion

        #region Voucher No Validation 

        private void txtVou_No_Validating(object sender, CancelEventArgs e)
        {
            TextBox _TextBox = (TextBox)sender;

            Boolean IsClose = false;

            if (string.IsNullOrWhiteSpace(_TextBox.Text)) { IsClose = true; }
            if (_TextBox.Text == "0") { IsClose = true; }
            if (_TextBox.Text.ToUpper().Trim() == "END") { IsClose = true; }
            if (_TextBox.Text.ToUpper().Trim() == "CLOSE") { IsClose = true; }
            if (IsClose) { e.Cancel = !IsClose; }
            else
            {
                DataView _TableView = AppliedTable.GetDataTable(Tables.View_Vou_Nos).AsDataView();
                _TableView.RowFilter = "Voucher_No='" + _TextBox.Text.Trim() + "'";
                if (_TableView.Count == 0) { e.Cancel = true; Vou_Found = false; }
                else { e.Cancel = IsClose; Vou_Found = true; }
                _TableView.Dispose();
            }
        }






        private void txtVou_No_Validated(object sender, EventArgs e)
        {
            if (Vou_Found)
            {
                MyVoucherClass.Load_Voucher(txtVou_No.Text.Trim().ToUpper());
                if (MyVoucherClass.Voucher_Loaded)
                {
                    txtVou_No.Text = MyVoucherClass.Vou_No;
                    dt_VoucherDate.Value = MyVoucherClass.Vou_Date;
                    cBoxVouType.Text = MyVoucherClass.Vou_Type;

                    MyVoucherClass.Vou_Status = "Edit";
                    MyVoucherClass.Load_GridData();
                    grp_Transactions.Visible = true;
                    MyValidation.Voucher_Type = MyVoucherClass.Vou_Type;

                    txtCOA.Text = Applied.ID2Code((long)tb_Voucher.Rows[0]["ID"], tb_Accounts.AsDataView());


                }
                else
                {
                    grp_Transactions.Visible = false;
                }
            }
        }

        private void txtVou_No_Leave(object sender, EventArgs e)
        {
            TextBox _TextBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(_TextBox.Text)) { Close(); }
            if (_TextBox.Text == "0") { Close(); }
            if (_TextBox.Text.ToUpper().Trim() == "END") { Close(); }
            if (_TextBox.Text.ToUpper().Trim() == "CLOSE") { Close(); }

        }

        #endregion

        #region Codes Other

        private void lblVoucherDate_DoubleClick(object sender, EventArgs e)
        {
            dt_VoucherDate.Value = DateTime.Now;
        }

        private void grp_Transactions_Enter(object sender, EventArgs e)
        {
            grp_Voucher.Enabled = false;
        }

        #endregion

        #region Position Changed

        private void PositionChange()
        {
            lblMessage.Text = string.Empty;
            decimal _DR = Conversion.ToMoney(txtDR.Text);
            decimal _CR = Conversion.ToMoney(txtCR.Text);
            txtDR.Text = _DR.ToString(NumberFormat);
            txtCR.Text = _CR.ToString(NumberFormat);

            txtCOA.Text = Applied.ID2Code(Conversion.ToLong(txtAccountID.Text), tb_Accounts.AsDataView());
            txtSupplier.Text = Applied.ID2Code(Conversion.ToLong(txtSupplierID.Text), tb_Suppliers.AsDataView());
            txtProject.Text = Applied.ID2Code(Conversion.ToLong(txtProjectID.Text), tb_Projects.AsDataView());
            txtUnit.Text = Applied.ID2Code(Conversion.ToLong(txtUnitID.Text), tb_Units.AsDataView());
            txtStock.Text = Applied.ID2Code(Conversion.ToLong(txtStockID.Text), tb_Stock.AsDataView());
            txtEmployee.Text = Applied.ID2Code(Conversion.ToLong(txtAccountID.Text), tb_Employees.AsDataView());

            cBoxAccount.SelectedValue = Applied.Code2ID(txtCOA.Text, tb_Accounts.AsDataView());
            cBoxSupplier.SelectedValue = Applied.Code2ID(txtSupplier.Text, tb_Suppliers.AsDataView());
            cBoxProject.SelectedValue = Applied.Code2ID(txtProject.Text, tb_Projects.AsDataView());
            cBoxUnit.SelectedValue = Applied.Code2ID(txtUnit.Text, tb_Units.AsDataView());
            cBoxStock.SelectedValue = Applied.Code2ID(txtStock.Text, tb_Stock.AsDataView());
            cBoxEmployee.SelectedValue = Applied.Code2ID(txtEmployee.Text, tb_Employees.AsDataView());

            // IF SRNO is focused then not binding else biding this object.
            if (txtSRNO.Focused)
            {
                txtSRNO.DataBindings.Clear();
            }
            else
            {
                txtSRNO.DataBindings.Clear();
                txtSRNO.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "SRNO", true, DataSourceUpdateMode.OnPropertyChanged));
                if (Conversion.ToLong(txtSRNO.Text) > 0)
                {
                    btnDelete.Text = "Delete";
                    Enabled(true);
                }
                else
                {
                    lblMessage.Text = "Record has been marked 'Delete'.";
                    btnDelete.Text = "Recover";
                    Enabled(false);
                }

            }

            grp_Action.Visible = IsBalance();
        }

        #endregion

        #region Object Enable / Disable

        private void Enabled(bool _Value)
        {
            txtCOA.Enabled = _Value;
            txtSupplier.Enabled = _Value;
            txtProject.Enabled = _Value;
            txtUnit.Enabled = _Value;
            txtStock.Enabled = _Value;
            txtEmployee.Enabled = _Value;

            cBoxAccount.Enabled = _Value;
            cBoxSupplier.Enabled = _Value;
            cBoxProject.Enabled = _Value;
            cBoxUnit.Enabled = _Value;
            cBoxStock.Enabled = _Value;
            cBoxEmployee.Enabled = _Value;

            txtRefNo.Enabled = _Value;
            txtChqNo.Enabled = _Value;
            dt_ChqDate.Enabled = _Value;
            txtDR.Enabled = _Value;
            txtCR.Enabled = _Value;
            txtRemarks.Enabled = _Value;
            txtDescription.Enabled = _Value;

        }

        #endregion

        #region Navigation Buttons
        private void btnTop_Click(object sender, EventArgs e)
        {
            Save_Values();
            TableBinding.Position = 0;
            PositionChange();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            Save_Values();
            if (TableBinding.Position - 1 >= 0) { TableBinding.Position -= 1; }
            else { TableBinding.Position = 0; }
            PositionChange();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Save_Values();
            if (TableBinding.Position + 1 < TableBinding.Count) { TableBinding.Position += 1; }
            else { TableBinding.Position = TableBinding.Count; }
            PositionChange();
        }

        private void btnBottom_Click(object sender, EventArgs e)
        {
            Save_Values();
            TableBinding.Position = TableBinding.Count - 1;
            PositionChange();
        }

        private void Save_Values()
        {
            int i = TableBinding.Position;
            MyCheque_No = tb_Voucher.Rows[i]["Chq_no"].ToString();
            MyCheque_Date = tb_Voucher.Rows[i]["Chq_Date"].ToString();
            MyRefNo = tb_Voucher.Rows[i]["RefNo"].ToString();
            MyPOrder = tb_Voucher.Rows[i]["POrder"].ToString();
            MyDescription = tb_Voucher.Rows[i]["Description"].ToString();
            MyRemarks = tb_Voucher.Rows[i]["Remarks"].ToString();
        }

        #endregion

        #region DataGrid

        private void Set_DataGrid()
        {
            Grid_Voucher.DataSource = tb_GridData;
            Grid_Voucher.Columns[0].Width = 40;
            Grid_Voucher.Columns[1].Width = 80;
            Grid_Voucher.Columns[2].Width = 80;
            Grid_Voucher.Columns[3].Width = 80;
            Grid_Voucher.Columns[4].Width = 180;
            Grid_Voucher.Columns[5].Width = 80;
            Grid_Voucher.Columns[6].Width = 80;
        }

        private bool IsBalance()
        {
            bool _Result = false;

            if (tb_Voucher.Rows.Count >= 2)
            {
                Total_DR = (decimal)tb_Voucher.Compute("SUM(DR)", string.Empty);
                Total_CR = (decimal)tb_Voucher.Compute("SUM(CR)", string.Empty);

                if (Total_DR == Total_CR) { _Result = true; }
            }
            else { _Result = false; }

            return _Result;
        }



        #endregion

        #region Serial No Text box

        private void txtSRNO_Enter(object sender, EventArgs e)
        {
            txtSRNO.DataBindings.Clear();
        }

        private void txtSRNO_Leave(object sender, EventArgs e)
        {
            long SelectedPosition = Conversion.ToLong(txtSRNO.Text);
            DataView _Voucher = tb_Voucher.AsDataView();
            _Voucher.RowFilter = "SRNO=" + SelectedPosition.ToString();
            foreach (DataRow _Row in tb_Voucher.Rows)
            {
                if (_Row["SRNO"].ToString() == SelectedPosition.ToString())
                {
                    TableBinding.Position = tb_Voucher.Rows.IndexOf(_Row);
                }
            }
            PositionChange();
        }

        private void txtSRNO_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSRNO.Text))
            {
                e.Cancel = true;
            }

            if (Conversion.ToLong(txtSRNO.Text) > TableBinding.Count)
            {
                txtSRNO.Text = TableBinding.Count.ToString();
                e.Cancel = true;
            }

            if (Conversion.ToLong(txtSRNO.Text) == 0)
            {
                txtSRNO.Text = "1";
                e.Cancel = true;
            }
        }

        private void txtSRNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Applied.IsDigit(sender, e);
        }

        #endregion

        #region DEBIT & CREDIT


        private void txtDR_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCR_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDR_Leave(object sender, EventArgs e)
        {
            //decimal _Amount = Conversion.ToMoney(txtDR.Text);
            //if (_Amount > 0)
            //{
            //    txtCR.Text = "0";
            //    decimal _DR = Conversion.ToMoney(txtDR.Text);
            //    decimal _CR = Conversion.ToMoney(txtCR.Text);
            //    txtDR.Text = _DR.ToString(NumberFormat);
            //    txtCR.Text = _CR.ToString(NumberFormat);

            //}
            //else
            //{
            //    txtDR.Text = string.Empty;
            //}

            //grp_Action.Visible = IsBalance();
        }

        private void txtCR_Leave(object sender, EventArgs e)
        {
            //decimal _Amount = Conversion.ToMoney(txtCR.Text);
            //if (_Amount > 0)
            //{
            //    txtDR.Text = "0";
            //    decimal _DR = Conversion.ToMoney(txtDR.Text);
            //    decimal _CR = Conversion.ToMoney(txtCR.Text);
            //    txtDR.Text = _DR.ToString(NumberFormat);
            //    txtCR.Text = _CR.ToString(NumberFormat);
            //}
            //else
            //{
            //    txtCR.Text = string.Empty;
            //}

            //grp_Action.Visible = IsBalance();
        }

        #endregion

        #region Text Box Validation

        private void txtCOA_Validating(object sender, CancelEventArgs e)
        {
            if (Initializaion) { return; }                           // return if objects initializing.
            if (MyValidation.IsNullAllowed(sender)) { return; }           // Not Validate if Null is allowed.
            e.Cancel = MyValidation.Validating((TextBox)sender, tb_Accounts);
        }
        private void txtCOA_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCOA.Text))
            {
                cBoxAccount.SelectedValue = MyValidation.Search_ComboID.ToString();
                if (string.IsNullOrWhiteSpace(txtAccountID.Text) || txtAccountID.Text == "0")
                {
                    txtAccountID.Text = MyValidation.ObjectID(sender, tb_Accounts);
                }
            }
        }



        private void txtSupplier_Validating(object sender, CancelEventArgs e)
        {
            if (Initializaion) { return; }                           // return if objects initializing.

            if (string.IsNullOrWhiteSpace(txtSupplier.Text))
            {
                if (MyValidation.IsNullAllowed(sender)) { return; }           // Not Validate if Null is allowed.
            }
            else
            {
                e.Cancel = MyValidation.Validating((TextBox)sender, tb_Suppliers);
            }
        }
        private void txtSupplier_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSupplier.Text))
            {
                cBoxSupplier.SelectedValue = MyValidation.Search_ComboID.ToString();
                if (string.IsNullOrWhiteSpace(txtSupplierID.Text) || txtSupplierID.Text == "0")
                {
                    txtSupplierID.Text = MyValidation.ObjectID(sender, tb_Suppliers);
                }
            }
        }

        private void txtProject_Validating(object sender, CancelEventArgs e)
        {
            if (Initializaion) { return; }                           // return if objects initializing.
            if (string.IsNullOrWhiteSpace(txtProject.Text))
            {
                if (MyValidation.IsNullAllowed(sender)) { return; }           // Not Validate if Null is allowed.
            }
            else
            { e.Cancel = MyValidation.Validating((TextBox)sender, tb_Projects); }

        }
        private void txtProject_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProject.Text))
            {
                cBoxProject.SelectedValue = MyValidation.Search_ComboID.ToString();

                if (string.IsNullOrWhiteSpace(txtProjectID.Text) || txtProjectID.Text == "0")
                {
                    txtProjectID.Text = MyValidation.ObjectID(sender, tb_Projects);
                }
            }

        }

        private void txtUnit_Validating(object sender, CancelEventArgs e)
        {
            if (Initializaion) { return; }                           // return if objects initializing.
            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                if (MyValidation.IsNullAllowed(sender)) { return; }           // Not Validate if Null is allowed.
            }
            else
            { e.Cancel = MyValidation.Validating((TextBox)sender, tb_Units); }

        }
        private void txtUnit_Validated(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtUnit.Text))
            {
                cBoxUnit.SelectedValue = MyValidation.Search_ComboID.ToString();
                if (string.IsNullOrWhiteSpace(txtUnitID.Text) || txtUnitID.Text == "0")
                {
                    txtUnitID.Text = MyValidation.ObjectID(sender, tb_Units);
                }
            }
        }

        private void txtStock_Validating(object sender, CancelEventArgs e)
        {
            if (Initializaion) { return; }                           // return if objects initializing.
            if (string.IsNullOrWhiteSpace(txtStock.Text))
            {
                if (MyValidation.IsNullAllowed(sender)) { return; }            // Not Validate if Null is allowed.
            }
            else
            {
                e.Cancel = MyValidation.Validating((TextBox)sender, tb_Stock);
            }

        }
        private void txtStock_Validated(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtStock.Text))
            {
                cBoxStock.SelectedValue = MyValidation.Search_ComboID.ToString();
                if (string.IsNullOrWhiteSpace(txtStockID.Text) || txtStockID.Text == "0")
                {
                    txtStockID.Text = MyValidation.ObjectID(sender, tb_Stock);
                }
            }
        }

        private void txtEmployee_Validating(object sender, CancelEventArgs e)
        {
            if (Initializaion) { return; }                           // return if objects initializing.
            if (string.IsNullOrWhiteSpace(txtEmployee.Text))
            {
                if (MyValidation.IsNullAllowed(sender)) { return; }           // Not Validate if Null is allowed.
            }
            else
            {
                e.Cancel = MyValidation.Validating((TextBox)sender, tb_Employees);
            }

        }
        private void txtEmployee_Validated(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtEmployee.Text))
            {
                cBoxEmployee.SelectedValue = MyValidation.Search_ComboID.ToString();
                if (string.IsNullOrWhiteSpace(txtEmployeeID.Text) || txtEmployeeID.Text == "0")
                {
                    txtEmployeeID.Text = MyValidation.ObjectID(sender, tb_Employees);
                }
            }
        }

        #endregion

        #region New Record

        private void btnNew_Click(object sender, EventArgs e)
        {
            MyVoucherClass.New();
            if (MyVoucherClass.New_Record)
            {
                btnBottom_Click(sender, e);
                lblMessage.Text = " New Transaction Created.";
                txtSRNO.Focus();
            }
        }

        private void Grid_Voucher_Enter(object sender, EventArgs e)
        {

        }

        private void Grid_Voucher_Leave(object sender, EventArgs e)
        {
            TableBinding.Position = Grid_Voucher.CurrentRow.Index;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyVoucherClass.Save(tb_Voucher);
        }

        #region DELETE Record

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (Conversion.ToLong(txtSRNO.Text) > 0)
            {
                txtSRNO.Text = (Conversion.ToLong(txtSRNO.Text) * -1).ToString();
                PositionChange();
            }
            else
            {
                if (Conversion.ToLong(txtSRNO.Text) < 0)
                {
                    txtSRNO.Text = (Conversion.ToLong(txtSRNO.Text) * -1).ToString();
                    PositionChange();
                }
            }
            #endregion

        }





        #endregion

        #region form Closing

        private void frmVouchers1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MyVoucherClass.Voucher_Saved)         // Skip it when Voucher is saved.
            {
                e.Cancel = false;
                return;
            }

            MessageBoxResult _Result;
            _Result = MessageBox.Show("Are you sure to close", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (_Result == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                lblMessage.Text = "Form Not Closed";
                e.Cancel = true;
            }
        }


        #endregion

    }   //============================== END
}
