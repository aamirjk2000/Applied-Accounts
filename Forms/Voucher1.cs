using Applied_Accounts.Classes;
using Applied_Accounts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applied_Accounts.Forms
{
    public partial class frmVouchers1 : Form
    {
        private const string NumberFormat = "{0:###,###,###,##0.00}";
        private string DateFormat = Applied.GetString("DataFormat");
        private string ComboDateFormat = Applied.GetString("DateFormat_Combo");
        private TextBox_Validation MyValidation = new TextBox_Validation();

        private string MyCheque_No;                                 // For copy and past
        private string MyCheque_Date;                               // For copy and past
        private string MyRefNo;                                     // For copy and past
        private string MyPOrder;                                    // For copy and past
        private string MyDescription;                               // For copy and past
        private string MyRemarks;                                   // for Copy and past.

        public static VoucherClass1 MyVoucherClass = new VoucherClass1();

        private DataTable tb_Accounts { get => MyVoucherClass.tb_Accounts; }
        private DataTable tb_Suppliers { get => MyVoucherClass.tb_Suppliers; }
        private DataTable tb_Projects { get => MyVoucherClass.tb_Projects; }
        private DataTable tb_Units { get => MyVoucherClass.tb_Units; }
        private DataTable tb_Stock { get => MyVoucherClass.tb_Stocks; }
        private DataTable tb_Employees { get => MyVoucherClass.tb_Employees; }
        private DataTable tb_POrder { get => MyVoucherClass.tb_POrder; }
        private DataTable tb_Voucher { get => MyVoucherClass.tb_Voucher; }
        private DataTable tb_voucher_Delete { get => MyVoucherClass.tb_Voucher_Delete; }
        private DataTable tb_GridData { get => MyVoucherClass.tb_GridData; }

        private BindingManagerBase TableBinding;
        private DataViewManager MyDataSource;
        
        private decimal Total_DR, Total_CR;                     // Store Total Amount of DE & CR 

        private bool Vou_Found;
        private bool Intializaion = true;
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

            MyDataSource = MyVoucherClass.ds_Voucher.DefaultViewManager;
            TableBinding = BindingContext[MyDataSource, "Ledger"];
            // ======================= END

            Set_ComboBox();                                 // Combo box setting DisplayMemebr, ValueMembers & DataSource
            Set_DataBinding();
            Set_DataGrid();
            Intializaion = false;                              // All Objects have been initialized.

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
            cBoxPOrder.DataSource = tb_POrder.AsDataView();

            cBoxAccount.DisplayMember = "COA.Title";
            cBoxSupplier.DisplayMember = "Suppliers.Title";
            cBoxProject.DisplayMember = "Projects.Title";
            cBoxUnit.DisplayMember = "Units.Title";
            cBoxStock.DisplayMember = "Stock.Title";
            cBoxEmployee.DisplayMember = "Employees.Title";
            cBoxPOrder.DisplayMember = "Title";

            cBoxAccount.ValueMember = "COA.ID";
            cBoxSupplier.ValueMember = "Suppliers.ID";
            cBoxProject.ValueMember = "Projects.ID";
            cBoxUnit.ValueMember = "Units.ID";
            cBoxStock.ValueMember = "Stock.ID";
            cBoxEmployee.ValueMember = "Employees.ID";
            cBoxPOrder.ValueMember = "ID";

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
            txtSRNO.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.SRNO", true, DataSourceUpdateMode.OnPropertyChanged));
            txtAccountID.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.COA", true, DataSourceUpdateMode.OnPropertyChanged));
            txtSupplierID.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.Supplier", true, DataSourceUpdateMode.OnPropertyChanged));
            txtProjectID.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.Project", true, DataSourceUpdateMode.OnPropertyChanged));
            txtUnitID.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.Unit", true, DataSourceUpdateMode.OnPropertyChanged));
            txtStockID.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.Stock", true, DataSourceUpdateMode.OnPropertyChanged));
            txtEmployeeID.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.Employee", true, DataSourceUpdateMode.OnPropertyChanged));

            txtRefNo.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.RefNo", true, DataSourceUpdateMode.OnPropertyChanged));
            txtChqNo.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.Chq_No", true, DataSourceUpdateMode.OnPropertyChanged));
            dt_ChqDate.DataBindings.Add(new Binding("Value", MyDataSource, "Ledger.Chq_Date", true, DataSourceUpdateMode.OnPropertyChanged));
            txtDR.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.DR", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCR.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.CR", true, DataSourceUpdateMode.OnPropertyChanged));
            txtDescription.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.Description", true, DataSourceUpdateMode.OnPropertyChanged));
            txtRemarks.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.Remarks", true, DataSourceUpdateMode.OnPropertyChanged));

            txtEmployee.DataBindings.Add("Text", txtEmployeeID, "Text");

        }


        #endregion

        #region Voucher Validation 

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

        #region Navigation Buttons

        private void btnTop_Click(object sender, EventArgs e)
        {
            TableBinding.Position = 0;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (TableBinding.Position - 1 >= 0) { TableBinding.Position -= 1; }
            else { TableBinding.Position = 0; }
            this.Invalidate();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (TableBinding.Position + 1 < TableBinding.Count) { TableBinding.Position += 1; }
            else { TableBinding.Position = TableBinding.Count; }
            this.Invalidate();
        }

        private void btnBottom_Click(object sender, EventArgs e)
        {
            TableBinding.Position = TableBinding.Count - 1;

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

            Total_DR = (decimal)MyDataSource.DataSet.Tables["Ledger"].Compute("SUM(DR)", string.Empty);
            Total_CR = (decimal)MyDataSource.DataSet.Tables["Ledger"].Compute("SUM(CR)", string.Empty);

            if (Total_DR == Total_CR) { _Result = true; }

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
            txtSRNO.DataBindings.Add(new Binding("Text", MyDataSource, "Ledger.SRNO", true, DataSourceUpdateMode.OnPropertyChanged));
            grp_Action.Visible = IsBalance();


        }

        private void txtSRNO_Validating(object sender, CancelEventArgs e)
        {
            DataView _DataView = MyDataSource.DataSet.Tables["Ledger"].AsDataView();
            _DataView.RowFilter = "SrNo=" + Conversion.ToInteger(txtSRNO.Text.Trim());
            if (_DataView.Count == 1) { TableBinding.Position = _DataView.Table.Rows.IndexOf(_DataView.Table.Rows[0]); }
            else { e.Cancel = true; }
        }


        #endregion

        #region Textbox_ID Text Change

        private void txtAccountID_TextChanged(object sender, EventArgs e)
        {
            cBoxAccount.SelectedValue = Conversion.ToLong(txtAccountID.Text);
        }

        private void txtProjectID_TextChanged(object sender, EventArgs e)
        {
            cBoxProject.SelectedValue = Conversion.ToLong(txtProjectID.Text);
        }
        private void txtSupplierID_TextChanged(object sender, EventArgs e)
        {
            cBoxSupplier.SelectedValue = Conversion.ToLong(txtSupplierID.Text);
        }

        private void txtUnitID_TextChanged(object sender, EventArgs e)
        {
            cBoxUnit.SelectedValue = Conversion.ToLong(txtUnitID.Text);
        }

        private void txtStockID_TextChanged(object sender, EventArgs e)
        {
            cBoxStock.SelectedValue = Conversion.ToLong(txtStockID.Text);
        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {
            cBoxEmployee.SelectedValue = Conversion.ToLong(txtEmployeeID.Text);
        }


        #endregion

        #region Combo Box Index Change
        private void cBoxAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Intializaion) { return; }
            if (cBoxAccount.SelectedValue != null) { txtAccountID.Text = cBoxAccount.SelectedValue.ToString(); }
            if (cBoxProject.SelectedValue != null) { txtProjectID.Text = cBoxProject.SelectedValue.ToString(); }
            if (cBoxSupplier.SelectedValue != null) { txtSupplierID.Text = cBoxSupplier.SelectedValue.ToString(); }
            if (cBoxUnit.SelectedValue != null) { txtUnitID.Text = cBoxUnit.SelectedValue.ToString(); }
            if (cBoxStock.SelectedValue != null) { txtStockID.Text = cBoxStock.SelectedValue.ToString(); }
            if (cBoxEmployee.SelectedValue != null) { txtEmployeeID.Text = cBoxEmployee.SelectedValue.ToString(); }
        }


        private void cBoxPOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

            //cBoxEmployee.SelectedValue = Conversion.ToLong(txtEmployeeID.Text);
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
            decimal _Amount = Conversion.ToMoney(txtDR.Text);
            if (_Amount > 0)
            {
                txtCR.Text = "";
                txtDR.Text = string.Format(NumberFormat, decimal.Parse(txtDR.Text));
            }
            else
            {
                txtDR.Text = string.Empty;
            }

            grp_Action.Visible = IsBalance();
        }

        private void txtCR_Leave(object sender, EventArgs e)
        {
            decimal _Amount = Conversion.ToMoney(txtCR.Text);
            if (_Amount > 0)
            {
                txtDR.Text = "";
                txtCR.Text = string.Format(NumberFormat, decimal.Parse(txtCR.Text));
            }
            else
            {
                txtCR.Text = string.Empty;
            }

            grp_Action.Visible = IsBalance();
        }

        #endregion

        
        #region Text Box Validation

        private void txtCOA_Validating(object sender, CancelEventArgs e)
        {
            if (Intializaion) { return; }                           // return if objects initializing.
            if (MyValidation.IsNullAllowed()) { return; }           // Not Validate if Null is allowed.
            e.Cancel = MyValidation.Validating((TextBox)sender, tb_Accounts);
        }
        private void txtCOA_Validated(object sender, EventArgs e)
        {
            txtAccountID.Text = MyValidation.Search_ComboID.ToString();
        }

        private void txtSupplier_Validating(object sender, CancelEventArgs e)
        {
            if (Intializaion) { return; }                           // return if objects initializing.
            if (MyValidation.IsNullAllowed()) { return; }           // Not Validate if Null is allowed.
            e.Cancel = MyValidation.Validating((TextBox)sender, tb_Suppliers);
        }
        private void txtSupplier_Validated(object sender, EventArgs e)
        {
            txtSupplierID.Text = MyValidation.Search_ComboID.ToString();
        }

        private void txtProject_Validating(object sender, CancelEventArgs e)
        {
            if (Intializaion) { return; }                           // return if objects initializing.
            if (MyValidation.IsNullAllowed()) { return; }           // Not Validate if Null is allowed.
            e.Cancel = MyValidation.Validating((TextBox)sender, tb_Projects);
        }
        private void txtProject_Validated(object sender, EventArgs e)
        {
            txtProjectID.Text = MyValidation.Search_ComboID.ToString();
        }

        private void txtUnit_Validating(object sender, CancelEventArgs e)
        {
            if (Intializaion) { return; }                           // return if objects initializing.
            if (MyValidation.IsNullAllowed()) { return; }           // Not Validate if Null is allowed.
            e.Cancel = MyValidation.Validating((TextBox)sender, tb_Units);
        }
        private void txtUnit_Validated(object sender, EventArgs e)
        {
            txtUnitID.Text = MyValidation.Search_ComboID.ToString();
        }

        private void txtStock_Validating(object sender, CancelEventArgs e)
        {
            if (Intializaion) { return; }                           // return if objects initializing.
            if (MyValidation.IsNullAllowed()) { return; }           // Not Validate if Null is allowed.
            e.Cancel = MyValidation.Validating((TextBox)sender, tb_Stock);
        }
        private void txtStock_Validated(object sender, EventArgs e)
        {
            txtStockID.Text = MyValidation.Search_ComboID.ToString();
        }

        private void txtEmployee_Validating(object sender, CancelEventArgs e)
        {
            if (Intializaion) { return; }                           // return if objects initializing.
            if (MyValidation.IsNullAllowed()) { return; }           // Not Validate if Null is allowed.
            e.Cancel = MyValidation.Validating((TextBox)sender, tb_Employees);
        }
        private void txtEmployee_Validated(object sender, EventArgs e)
        {
            txtEmployeeID.Text = MyValidation.Search_ComboID.ToString();
        }

        #endregion

    }
}
