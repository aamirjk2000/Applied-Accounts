using Applied_Accounts.Classes;
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
        private Boolean Vou_Found;
        private BindingSource MyBindingSource = new BindingSource();                // DataSource of Binding source;
        private BindingManagerBase TableBinding;                                    // Binding Manager for navigation of records.

        #region Initialization

        public frmVouchers1()
        {
            InitializeComponent();
            MyVoucherClass.Load_Tables();
            Set_ComboBox();

            grp_Transactions.Visible = false;
            grp_Action.Visible = false;

            txtVou_No.Focus();
            Vou_Found = false;

            MyBindingSource.DataSource = MyVoucherClass.tb_Voucher;
            TableBinding = BindingContext[MyBindingSource];
            Set_DataBinding();

        }

        private void Set_ComboBox()
        {
            cBoxAccount.DisplayMember = "Title";
            cBoxSupplier.DisplayMember = "Title";
            cBoxProject.DisplayMember = "Title";
            cBoxUnit.DisplayMember = "Title";
            cBoxStock.DisplayMember = "Title";
            cBoxEmployee.DisplayMember = "Title";
            cBoxPOrder.DisplayMember = "Title";

            cBoxAccount.ValueMember = "ID";
            cBoxSupplier.ValueMember = "ID";
            cBoxProject.ValueMember = "ID";
            cBoxUnit.ValueMember = "ID";
            cBoxStock.ValueMember = "ID";
            cBoxStock.ValueMember = "ID";
            cBoxEmployee.ValueMember = "ID";
            cBoxPOrder.ValueMember = "ID";

            cBoxAccount.DataSource = tb_Accounts.AsDataView();
            cBoxSupplier.DataSource = tb_Suppliers.AsDataView();
            cBoxProject.DataSource = tb_Projects.AsDataView();
            cBoxUnit.DataSource = tb_Units.AsDataView();
            cBoxStock.DataSource = tb_Stock.AsDataView();
            cBoxEmployee.DataSource = tb_Employees.AsDataView();
            cBoxPOrder.DataSource = tb_POrder.AsDataView();

            cBoxVouType.DataSource = MyVoucherClass.Vou_Types;

        }

        private void frmVouchers1_Load(object sender, EventArgs e)
        {
            txtVou_No.Text = "New";
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
            txtSRNO.DataBindings.Add(new Binding("Text", MyBindingSource, "SRNO", true, DataSourceUpdateMode.OnPropertyChanged));
            txtAccountID.DataBindings.Add(new Binding("Text", MyBindingSource, "COA", true, DataSourceUpdateMode.OnPropertyChanged));
            txtSupplierID.DataBindings.Add(new Binding("Text", MyBindingSource, "Supplier", true, DataSourceUpdateMode.OnPropertyChanged));
            txtProjectID.DataBindings.Add(new Binding("Text", MyBindingSource, "Project", true, DataSourceUpdateMode.OnPropertyChanged));
            txtUnitID.DataBindings.Add(new Binding("Text", MyBindingSource, "Unit", true, DataSourceUpdateMode.OnPropertyChanged));
            txtStockID.DataBindings.Add(new Binding("Text", MyBindingSource, "Stock", true, DataSourceUpdateMode.OnPropertyChanged));
            //txtEmployeeID.DataBindings.Add(new Binding("Text", MyBindingSource, "Employee", true, DataSourceUpdateMode.OnPropertyChanged));
            
            txtRefNo.DataBindings.Add(new Binding("Text", MyBindingSource, "RefNo", true, DataSourceUpdateMode.OnPropertyChanged));
            txtChqNo.DataBindings.Add(new Binding("Text", MyBindingSource, "Chq_No", true, DataSourceUpdateMode.OnPropertyChanged));
            dt_ChqDate.DataBindings.Add(new Binding("Value", MyBindingSource, "Chq_Date", true, DataSourceUpdateMode.OnPropertyChanged));
            //txtDR.DataBindings.Add(new Binding("Text", MyBindingSource, "DR", true, DataSourceUpdateMode.OnPropertyChanged));
            //txtCR.DataBindings.Add(new Binding("Text", MyBindingSource, "CR", true, DataSourceUpdateMode.OnPropertyChanged));
            txtDescription.DataBindings.Add(new Binding("Text", MyBindingSource, "Description", true, DataSourceUpdateMode.OnPropertyChanged));
            txtRemarks.DataBindings.Add(new Binding("Text", MyBindingSource, "Remarks", true, DataSourceUpdateMode.OnPropertyChanged));



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
                DataView _TableView = AppliedTable.GetDataTable(Tables.vIEW_Vou_Nos).AsDataView();
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
    }
}
