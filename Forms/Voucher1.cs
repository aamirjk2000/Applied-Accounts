﻿using Applied_Accounts.Classes;
using Applied_Accounts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        private DataTable tb_Voucher { get => MyVoucherClass.tb_Voucher; }
        private DataTable tb_voucher_Delete { get => MyVoucherClass.tb_Voucher_Delete; }
        private DataTable tb_GridData { get => MyVoucherClass.tb_GridData; }

        //private BindingSource MyBindingSource { get => MyVoucherClass.MyBindingSource; }

        private BindingManagerBase TableBinding;
        //private BindingSource MyDataSource = new BindingSource();
        private DataViewManager MyDataSource;


        private Boolean Vou_Found;

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
            TableBinding = BindingContext[MyDataSource,"Ledger"];
            // ======================= END

            Set_ComboBox();                                 // Combo box setting DisplayMemebr, ValueMembers & DataSource
            Set_DataBinding();
            Set_DataGrid();

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

            cBoxAccount.DisplayMember = "COA.Title";
            cBoxSupplier.DisplayMember = "Suppliers.Title";
            cBoxProject.DisplayMember = "Projects.Title";
            cBoxUnit.DisplayMember = "Units.Title";
            cBoxStock.DisplayMember = "Stock.Title";
            cBoxEmployee.DisplayMember = "Employees.Title";
            cBoxPOrder.DisplayMember = "Porder.Title";

            cBoxAccount.ValueMember = "COA.ID";
            cBoxSupplier.ValueMember = "Suppliers.ID";
            cBoxProject.ValueMember = "Projects.ID";
            cBoxUnit.ValueMember = "Units.ID";
            cBoxStock.ValueMember = "Stock.ID";
            cBoxEmployee.ValueMember = "Employees.ID";
            cBoxPOrder.ValueMember = "POrder.ID";

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
            // If you are not at the end of the list, move to the next item
            // in the BindingSource.
            if (TableBinding.Position - 1 < 0)
                TableBinding.Position -= 1;

            // Otherwise, move back to the first item.
            else
                TableBinding.Position = 0;

            // Force the form to repaint.
            this.Invalidate();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // If you are not at the end of the list, move to the next item
            // in the BindingSource.
            if (TableBinding.Position + 1 < TableBinding.Count)
                TableBinding.Position += 1;

            // Otherwise, move back to the first item.
            else
                TableBinding.Position = 0;

            // Force the form to repaint.
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



        #endregion

        private void txtSRNO_Enter(object sender, EventArgs e)
        {
            //MessageBox.Show(MyBindingSource.DataSource.ToString());            
        }


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
            if(cBoxAccount.SelectedValue!=null)
            {
                txtAccountID.Text = cBoxAccount.SelectedValue.ToString();
            }
            
        }



        private void cBoxPOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cBoxEmployee.SelectedValue = Conversion.ToLong(txtEmployeeID.Text);
        }

        #endregion

    }
}
