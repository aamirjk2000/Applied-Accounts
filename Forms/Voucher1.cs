using Applied_Accounts.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
//using TextBox = System.Windows.Forms.TextBox;
//using ToolTip = System.Windows.Forms.ToolTip;

namespace Applied_Accounts.Forms
{
    public partial class frmVouchers1 : Form
    {

        private string NumberFormat = Applied.GetString("CurrencyFormat");
        private string DateFormat = Applied.GetString("DataFormat");
        private string ComboDateFormat = Applied.GetString("DateFormat_Combo");

        public static TextBox_Validation MyValidation = new TextBox_Validation();
        public static VoucherClass1 MyVoucherClass = new VoucherClass1();

        private string Voucher_NO { get => txtVou_No.Text.Trim(); } // Voucher No.
        private string Copy_Cheque_No;                                 // For copy and past
        private DateTime Copy_Cheque_Date;                             // For copy and past
        private string Copy_RefNo;                                     // For copy and past
        private string Copy_POrder;                                    // For copy and past
        private string Copy_Description;                               // For copy and past
        private string Copy_Remarks;                                   // for Copy and past.
        private bool Is_Copied = false;

        private DataTable tb_Accounts { get => MyVoucherClass.ds_Voucher.Tables["COA"]; }
        private DataTable tb_Suppliers { get => MyVoucherClass.ds_Voucher.Tables["Suppliers"]; }
        private DataTable tb_Projects { get => MyVoucherClass.ds_Voucher.Tables["Projects"]; }
        private DataTable tb_Units { get => MyVoucherClass.ds_Voucher.Tables["Units"]; }
        private DataTable tb_Stock { get => MyVoucherClass.ds_Voucher.Tables["Stock"]; }
        private DataTable tb_Employees { get => MyVoucherClass.ds_Voucher.Tables["Employees"]; }
        private DataTable tb_POrder { get => MyVoucherClass.ds_Voucher.Tables["POrder"]; }
        private DataTable tb_Voucher { get => MyVoucherClass.tb_Voucher; }
        //private DataTable tb_voucher_Delete { get => MyVoucherClass.tb_Voucher_Delete; }
        private DataTable tb_GridData { get => MyVoucherClass.tb_GridData; }

        private BindingManagerBase TableBinding;
        private BindingManagerBase POrderBinding;
        private System.Data.DataSet MyDataSource;

        private ToolTip MyToolTip;

        private bool Vou_Found;
        private bool Initializaion = true;
        private int IsShowAll = 1;                            // Show Active or Non-Active records in Combo Box 


        DataView dv_Accounts;
        DataView dv_Supplier;
        DataView dv_Project;
        DataView dv_Unit;
        DataView dv_Stock;
        DataView dv_Employee;
        DataView dv_POrder;

        #region Initialization

        public frmVouchers1()
        {
            InitializeComponent();
            MyVoucherClass.Load_Tables();                   // Load Table in vocuehr Class

            grp_Transactions.Visible = false;
            grp_Action.Visible = false;

            txtVou_No.Focus();
            Vou_Found = false;

            MyToolTip = new ToolTip();
            MyToolTip.AutoPopDelay = 5000;
            MyToolTip.InitialDelay = 100;
            MyToolTip.ReshowDelay = 500;

            MyToolTip.SetToolTip(txtDR, MyVoucherClass.Difference().ToString());
            MyToolTip.SetToolTip(txtCR, MyVoucherClass.Difference().ToString());
            MyToolTip.SetToolTip(btnSave, "Save Voucher");
            MyToolTip.SetToolTip(btnNext, "Next Record");
            MyToolTip.SetToolTip(btnPrevious, "Previous Record");
            MyToolTip.SetToolTip(btnTop, "First Record");
            MyToolTip.SetToolTip(btnBottom, "Last Record");

            // Binding Setup

            MyDataSource = MyVoucherClass.ds_Voucher;
            TableBinding = BindingContext[MyVoucherClass.tb_Voucher];
            POrderBinding = BindingContext[tb_POrder];

            TableBinding.PositionChanged += new EventHandler(TableBinding_PositionChange);
            TableBinding.CurrentChanged += new EventHandler(TableBinding_CurrentChange);
            TableBinding.BindingComplete += new BindingCompleteEventHandler(TableBiding_Completed);

            // ======================= END

            Set_ComboBox();                                 // Combo box setting DisplayMemebr, ValueMembers & DataSource
            Set_DataBinding();
            Set_DataGrid();
            Initializaion = false;                              // All Objects have been initialized.

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


        #region Combo Boxs
        private void Set_ComboBox()
        {
            dv_Accounts = MyDataSource.Tables["COA"].AsDataView();
            dv_Supplier = MyDataSource.Tables["Suppliers"].AsDataView();
            dv_Project = MyDataSource.Tables["Projects"].AsDataView();
            dv_Unit = MyDataSource.Tables["Units"].AsDataView();
            dv_Stock = MyDataSource.Tables["Stock"].AsDataView();
            dv_Employee = MyDataSource.Tables["Employees"].AsDataView();
            dv_POrder = MyDataSource.Tables["POrder"].AsDataView();

            dv_Accounts.RowFilter = ShowAll();
            dv_Supplier.RowFilter = ShowAll();
            dv_Project.RowFilter = ShowAll();
            dv_Unit.RowFilter = ShowAll();
            dv_Stock.RowFilter = ShowAll();
            dv_Employee.RowFilter = ShowAll();
            dv_POrder.RowFilter = ShowAll();

            cBoxAccount.DataSource = dv_Accounts;
            cBoxSupplier.DataSource = MyDataSource;
            cBoxProject.DataSource = MyDataSource;
            cBoxUnit.DataSource = MyDataSource;
            cBoxStock.DataSource = MyDataSource;
            cBoxEmployee.DataSource = MyDataSource;
            cBoxPOrder.DataSource = MyDataSource;

            cBoxAccount.DisplayMember = "Title";
            cBoxSupplier.DisplayMember = "Suppliers.Title";
            cBoxProject.DisplayMember = "Projects.Title";
            cBoxUnit.DisplayMember = "Units.Title";
            cBoxStock.DisplayMember = "Stock.Title";
            cBoxEmployee.DisplayMember = "Employees.Title";
            cBoxPOrder.DisplayMember = "POrder.Title";

            cBoxAccount.ValueMember = "ID";
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

        private string ShowAll()
        {
            if (IsShowAll == 1) { return "Active=1"; } else { return ""; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsShowAll == 1)
            {
                IsShowAll = 0;
                lblMessage.Text = "Show All Records";
                btnActive.Image = Properties.Resources.Active_Rows;

            }
            else
            {
                IsShowAll = 1;
                lblMessage.Text = "Show Active Records";
                btnActive.Image = Properties.Resources.All_Rows;
            }


            // Store BomboBox Value 
            long ID_COA = Conversion.ToLong(cBoxAccount.SelectedValue);
            long ID_Supplier = Conversion.ToLong(cBoxSupplier.SelectedValue);
            long ID_Project = Conversion.ToLong(cBoxProject.SelectedValue);
            long ID_Unit = Conversion.ToLong(cBoxUnit.SelectedValue);
            long ID_Stock = Conversion.ToLong(cBoxStock.SelectedValue);
            long ID_Employee = Conversion.ToLong(cBoxEmployee.SelectedValue);
            long ID_POrder = Conversion.ToLong(cBoxPOrder.SelectedValue);

            Set_ComboBox();

            // Restore ComboBox Value after refresh / reset.
            cBoxAccount.SelectedValue = ID_COA;
            cBoxSupplier.SelectedValue = ID_Supplier;
            cBoxProject.SelectedValue = ID_Project;
            cBoxUnit.SelectedValue = ID_Unit;
            cBoxStock.SelectedValue = ID_Stock;
            cBoxEmployee.SelectedValue = ID_Employee;
            cBoxPOrder.SelectedValue = ID_POrder;
        }

        #endregion


        #region Data Binding

        private void Set_DataBinding()
        {
            txtSRNO.DataBindings.Add(new Binding("Text", MyVoucherClass.tb_Voucher, "SRNO", true, DataSourceUpdateMode.OnPropertyChanged));
            cBoxAccount.DataBindings.Add(new Binding("SelectedValue", MyVoucherClass.tb_Voucher, "COA", false, DataSourceUpdateMode.OnPropertyChanged));
            cBoxSupplier.DataBindings.Add(new Binding("SelectedValue", MyVoucherClass.tb_Voucher, "Supplier", false, DataSourceUpdateMode.OnPropertyChanged));
            cBoxProject.DataBindings.Add(new Binding("SelectedValue", MyVoucherClass.tb_Voucher, "Project", false, DataSourceUpdateMode.OnPropertyChanged));
            cBoxUnit.DataBindings.Add(new Binding("SelectedValue", MyVoucherClass.tb_Voucher, "Unit", false, DataSourceUpdateMode.OnPropertyChanged));
            cBoxStock.DataBindings.Add(new Binding("SelectedValue", MyVoucherClass.tb_Voucher, "Stock", false, DataSourceUpdateMode.OnPropertyChanged));
            cBoxEmployee.DataBindings.Add(new Binding("SelectedValue", MyVoucherClass.tb_Voucher, "Employee", false, DataSourceUpdateMode.OnPropertyChanged));
            cBoxPOrder.DataBindings.Add(new Binding("SelectedValue", MyVoucherClass.tb_Voucher, "POrder", false, DataSourceUpdateMode.OnPropertyChanged));

            txtAccountID.Text = cBoxAccount.SelectedValue.ToString();
            txtSupplierID.Text = cBoxSupplier.SelectedValue.ToString();
            txtProject.Text = cBoxProject.SelectedValue.ToString();
            txtUnit.Text = cBoxUnit.SelectedValue.ToString();
            txtStock.Text = cBoxStock.SelectedValue.ToString();
            txtEmployee.Text = cBoxEmployee.SelectedValue.ToString();

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
            lblMessage.Text = "";
            lblMessage.Text = TableBinding.Position.ToString() + " | ";
        }

        private void TableBinding_CurrentChange(object sender, EventArgs e)
        {
            cBoxAccount.SelectedValue = Applied.Code2ID(txtCOA.Text, tb_Accounts.AsDataView());
            cBoxSupplier.SelectedValue = Applied.Code2ID(txtSupplier.Text, tb_Suppliers.AsDataView());
            cBoxProject.SelectedValue = Applied.Code2ID(txtProject.Text, tb_Projects.AsDataView());
            cBoxUnit.SelectedValue = Applied.Code2ID(txtUnit.Text, tb_Units.AsDataView());
            cBoxStock.SelectedValue = Applied.Code2ID(txtStock.Text, tb_Stock.AsDataView());
            cBoxEmployee.SelectedValue = Applied.Code2ID(txtEmployee.Text, tb_Employees.AsDataView());

            txtDR.Text = Conversion.ToMoney(txtDR.Text).ToString(NumberFormat);
            txtCR.Text = Conversion.ToMoney(txtCR.Text).ToString(NumberFormat);
        }

        private void TableBiding_Completed(object sender, EventArgs e)
        {

        }

        #endregion

        #region Voucher No Validation 

        private void txtVou_No_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_DoubleClick(object sender, EventArgs e)
        {
            txtVou_No.Text = Applied.GetString("LastVoucher");
        }
        private void txtVou_No_Validating(object sender, CancelEventArgs e)
        {
            TextBox _TextBox = (TextBox)sender;


            bool IsClose = false;

            if (string.IsNullOrWhiteSpace(_TextBox.Text)) { IsClose = true; }
            if (_TextBox.Text == "0") { IsClose = true; }
            if (_TextBox.Text.ToUpper().Trim() == "END") { IsClose = true; }
            if (_TextBox.Text.ToUpper().Trim() == "CLOSE") { IsClose = true; }
            if (_TextBox.Text.ToUpper().Trim() == "NEW") { IsClose = false; }
            if (_TextBox.Text.ToUpper().Trim() == "-1") { IsClose = false; _TextBox.Text = "NEW"; }             // New Voucher
            if (IsClose) { e.Cancel = !IsClose; }
            else
            {
                if (_TextBox.Text.ToUpper().Trim() == "NEW")
                {
                    MyVoucherClass.Vou_Status = "NEW";
                }

                else
                {
                    DataView _TableView = AppliedTable.GetDataTable(Tables.View_Vou_Nos).AsDataView();
                    _TableView.RowFilter = "Voucher_No='" + _TextBox.Text.Trim() + "'";
                    if (_TableView.Count == 0) { e.Cancel = true; Vou_Found = false; }
                    else { e.Cancel = IsClose; Vou_Found = true; }
                    _TableView.Dispose();
                }
            }
        }
        private void txtVou_No_Validated(object sender, EventArgs e)
        {
            if (Vou_Found)
            {
                MyVoucherClass.Load_Voucher(Voucher_NO);
                if (MyVoucherClass.Voucher_Loaded)                      // Voucher has been sucessfully loaded.
                {
                    txtVou_No.Text = MyVoucherClass.Vou_No;
                    dt_VoucherDate.Value = MyVoucherClass.Vou_Date;
                    cBoxVouType.Text = MyVoucherClass.Vou_Type;
                    cBoxVouType.Enabled = false;

                    MyVoucherClass.Vou_Status = "Edit";
                    MyVoucherClass.Load_GridData();                                     // Load Table for Data Grid.
                    Set_DataGrid();                                                     // Design Data Grid.
                    grp_Transactions.Visible = true;
                    MyValidation.Voucher_Type = MyVoucherClass.Vou_Type;

                    //txtCOA.Text = Applied.ID2Code((long)tb_Voucher.Rows[0]["ID"], tb_Accounts.AsDataView());

                }
                else
                {
                    grp_Transactions.Visible = false;
                    if (txtVou_No.Text.Trim().ToUpper() == "NEW")
                    {
                        cBoxVouType.Enabled = true;                                         // Voucher Type Enable is voucher is new    
                        cBoxVouType.Focus();
                    }
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

            Applied.SetValue("LastVoucher", txtVou_No.Text.Trim(), Applied.KeyType.String);

        }

        #endregion

        #region Voucher Type

        private void cBoxVouType_Leave(object sender, EventArgs e)
        {

        }

        private void cBoxVouType_Validating(object sender, CancelEventArgs e)
        {
            if (cBoxVouType.Text.Length == 0)
            {
                e.Cancel = true;
                return;
            }

            e.Cancel = true;

            foreach (object _VType in cBoxVouType.Items)
            {
                if (_VType.ToString() == cBoxVouType.Text.Trim())
                {
                    e.Cancel = false;
                    break;
                }
            }

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

            if (txtVou_No.Text.ToUpper().Trim() == "NEW")
            {
                MyVoucherClass.Vou_No = "NEW";
                MyVoucherClass.Vou_Type = cBoxVouType.Text;
                MyVoucherClass.Vou_Date = dt_VoucherDate.Value;

                tb_Voucher.Rows[0]["Vou_No"] = MyVoucherClass.Vou_No;
                tb_Voucher.Rows[0]["Vou_Type"] = MyVoucherClass.Vou_Type;
                tb_Voucher.Rows[0]["Vou_Date"] = MyVoucherClass.Vou_Date;

            }
        }

        #endregion


        /// <summary>
        /// POSITION CHANGED.
        /// </summary>
        #region Position Changed

        private void PositionChange()
        {
            //lblMessage.Text = string.Empty;

            txtCOA.Text = Applied.ID2Code(Conversion.ToLong(txtAccountID.Text), tb_Accounts.AsDataView());
            txtSupplier.Text = Applied.ID2Code(Conversion.ToLong(txtSupplierID.Text), tb_Suppliers.AsDataView());
            txtProject.Text = Applied.ID2Code(Conversion.ToLong(txtProjectID.Text), tb_Projects.AsDataView());
            txtUnit.Text = Applied.ID2Code(Conversion.ToLong(txtUnitID.Text), tb_Units.AsDataView());
            txtStock.Text = Applied.ID2Code(Conversion.ToLong(txtStockID.Text), tb_Stock.AsDataView());
            txtEmployee.Text = Applied.ID2Code(Conversion.ToLong(txtEmployeeID.Text), tb_Employees.AsDataView());


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
                    MyEnabled(true);
                }
                else
                {
                    //lblMessage.Text = "Record has been marked 'Delete'.";
                    //btnDelete.Text = "Recover";
                    MyEnabled(false);
                }

            }

            grp_Action.Visible = MyVoucherClass.Is_Balanced();
            Set_DataGrid();

            //lblMessage.Text += TableBinding.Position.ToString();
        }

        #endregion

        #region Object Enable / Disable

        private void MyEnabled(bool _Value)
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
            Copy_Cheque_No = txtChqNo.Text;
            Copy_Cheque_Date = dt_ChqDate.Value;
            Copy_RefNo = txtRefNo.Text;
            Copy_POrder = cBoxPOrder.Text;
            Copy_Description = txtDescription.Text;
            Copy_Remarks = txtRemarks.Text;
            Is_Copied = true;
        }

        #endregion

        #region DataGrid

        private void Set_DataGrid()
        {
            Grid_Voucher.DataSource = tb_GridData;
            Grid_Voucher.ReadOnly = true;
            Grid_Voucher.AllowUserToAddRows = false;
            Grid_Voucher.AllowUserToDeleteRows = false;
            Grid_Voucher.AllowUserToOrderColumns = true;
            Grid_Voucher.AllowUserToResizeColumns = true;
            Grid_Voucher.AllowUserToResizeRows = false;
            Grid_Voucher.AutoGenerateColumns = false;

            Grid_Voucher.MultiSelect = false;
            Grid_Voucher.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_Voucher.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            Grid_Voucher.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            Grid_Voucher.Columns[0].Width = 40;
            Grid_Voucher.Columns[1].Width = 80;
            Grid_Voucher.Columns[2].Width = 80;
            Grid_Voucher.Columns[3].Width = 180;
            Grid_Voucher.Columns[4].Width = 80;
            Grid_Voucher.Columns[5].Width = 180;
            Grid_Voucher.Columns[6].Width = 80;
            Grid_Voucher.Columns[7].Width = 80;
            Grid_Voucher.Columns[8].Width = 80;


            Grid_Voucher.Columns[6].DefaultCellStyle.Format = NumberFormat;
            Grid_Voucher.Columns[7].DefaultCellStyle.Format = NumberFormat;

            Grid_Voucher.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid_Voucher.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            #region Fill Color
            if (Grid_Voucher.Rows.Count > 0)
            {
                foreach (DataGridViewRow _Row in Grid_Voucher.Rows)
                {
                    if (_Row.Cells["Status"].Value != null)
                    {
                        if (_Row.Cells["Status"].Value.ToString() == "Delete")
                        {
                            Grid_Voucher.Rows[_Row.Index].DefaultCellStyle.BackColor = Color.Yellow;
                            Grid_Voucher.Rows[_Row.Index].DefaultCellStyle.ForeColor = Color.Red;
                        }
                        if (MyVoucherClass.Is_Balanced())
                        {
                            if (_Row.Cells["Status"].Value.ToString() == "Total")
                            {
                                Grid_Voucher.Rows[_Row.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                                Grid_Voucher.Rows[_Row.Index].DefaultCellStyle.ForeColor = Color.Navy;
                            }
                        }
                        else
                        {
                            if (_Row.Cells["Status"].Value.ToString() == "Total")
                            {
                                Grid_Voucher.Rows[_Row.Index].DefaultCellStyle.BackColor = Color.Linen;
                                Grid_Voucher.Rows[_Row.Index].DefaultCellStyle.ForeColor = Color.DarkRed;
                            }
                        }
                    }
                }
            }
            #endregion

            //int i = TableBinding.Position;
            //TableBinding.Position = 0;
            //TableBinding.Position = i;              // Move pointer to Objest reset
        }

        #endregion

        #region Serial No Text box / Voucher Date

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

        private void dt_VoucherDate_Leave(object sender, EventArgs e)
        {
            if (txtVou_No.Text.Trim().ToUpper() == "NEW")
            {
                grp_Transactions.Visible = true;

                if (tb_Voucher.Rows.Count == 0)
                {
                    MyVoucherClass.New();
                    PositionChange();
                    txtSRNO.Focus();
                }
            }
        }

        #endregion

        #region DEBIT & CREDIT


        private void txtDR_TextChanged(object sender, EventArgs e)
        {
            decimal _DR = Conversion.ToMoney(txtDR.Text);
            txtDR.Text = _DR.ToString(NumberFormat);
        }

        private void txtCR_TextChanged(object sender, EventArgs e)
        {
            decimal _CR = Conversion.ToMoney(txtCR.Text);
            txtCR.Text = _CR.ToString(NumberFormat);
        }

        private void txtDR_Leave(object sender, EventArgs e)
        {
            decimal _Amount = Conversion.ToMoney(txtDR.Text);
            if (_Amount > 0)
            {
                txtCR.Text = "0";
                PositionChange();
            }
            else if (_Amount.ToString().Length == 0)
            {
                txtDR.Text = "0";
            }
        }

        private void txtCR_Leave(object sender, EventArgs e)
        {
            decimal _Amount = Conversion.ToMoney(txtCR.Text);
            if (_Amount > 0)
            {
                txtDR.Text = "0";
                PositionChange();
            }
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

            if (!string.IsNullOrEmpty(txtEmployee.Text))                                                // Exeute if text box has some value
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
                txtCOA.Focus();

                cBoxAccount.SelectedValue = 0;
                cBoxSupplier.SelectedValue = 0;
                cBoxProject.SelectedValue = 0;
                cBoxUnit.SelectedValue = 0;
                cBoxStock.SelectedValue = 0;
                cBoxEmployee.SelectedValue = 0;
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
            lblMessage.Text = string.Concat("Voucher No ", MyVoucherClass.Vou_No, " Created.");
        }
        #endregion

        #region DELETE Record

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRowView _Row = (DataRowView)TableBinding.Current;

            if (Conversion.ToLong(_Row["ID"].ToString()) == 0)
            {
                tb_Voucher.Rows.Remove(_Row.Row);
            }
            else
            {
                txtSRNO.Text = (Conversion.ToLong(txtSRNO.Text) * -1).ToString();
            }

            PositionChange();


        }

        #endregion

        #region Page 2 Active
        private void P2_Enter(object sender, EventArgs e)
        {
            MyVoucherClass.Load_GridData();
            Set_DataGrid();
            Grid_Voucher.Refresh();
            P2.Refresh();

        }

        #endregion

        #region Combox Change.

        private void cBoxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxEmployee.SelectedValue == null) { return; }
            txtEmployeeID.Text = cBoxEmployee.SelectedValue.ToString();
            txtEmployee.Text = Applied.ID2Code(Conversion.ToLong(txtEmployeeID.Text), tb_Employees.AsDataView());
        }

        private void cBoxStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxStock.SelectedValue == null) { return; }
            txtStockID.Text = cBoxStock.SelectedValue.ToString();
            txtStock.Text = Applied.ID2Code(Conversion.ToLong(txtStockID.Text), tb_Stock.AsDataView());
        }

        private void cBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxUnit.SelectedValue == null) { return; }
            txtUnitID.Text = cBoxUnit.SelectedValue.ToString();
            txtUnit.Text = Applied.ID2Code(Conversion.ToLong(txtUnitID.Text), tb_Units.AsDataView());
        }

        private void cBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxProject.SelectedValue == null) { return; }
            txtProjectID.Text = cBoxProject.SelectedValue.ToString();
            txtProject.Text = Applied.ID2Code(Conversion.ToLong(txtProjectID.Text), tb_Projects.AsDataView());
        }

        private void cBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxSupplier.SelectedValue == null) { return; }
            txtSupplierID.Text = cBoxSupplier.SelectedValue.ToString();
            txtSupplier.Text = Applied.ID2Code(Conversion.ToLong(txtSupplierID.Text), tb_Suppliers.AsDataView());
        }

        private void cBoxAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Initializaion) { return; }
            if (cBoxAccount.SelectedValue == null) { return; }
            txtAccountID.Text = cBoxAccount.SelectedValue.ToString();
            txtCOA.Text = Applied.ID2Code(Conversion.ToLong(txtAccountID.Text), tb_Accounts.AsDataView());
        }


        #endregion

        #region REFRESH 

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MessageBoxResult _Result;
            _Result = System.Windows.MessageBox.Show("Are you sure to Refresh Voucher", "Refresh Voucher", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (MessageBoxResult.Yes == _Result)
            {

                MyVoucherClass = new VoucherClass1();

                grp_Transactions.Visible = false;
                grp_Action.Visible = false;
                grp_Voucher.Enabled = true;
                txtVou_No.Focus();
                txtVou_No.Text = MyVoucherClass.Vou_No;
                cBoxVouType.Text = MyVoucherClass.Vou_Type;
                dt_ChqDate.Value = MyVoucherClass.Vou_Date;

                MyDataSource = MyVoucherClass.ds_Voucher;
                TableBinding = BindingContext[MyVoucherClass.tb_Voucher];

            }
        }


        #endregion

        #region Form Closing

        private void frmVouchers1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("are you sure to close?");


        }

        #endregion

        #region Undo

        private void btnUndo_Click(object sender, EventArgs e)
        {
            string _ID = txtSRNO.Text.Trim(); ;
            DataView _View1 = MyVoucherClass.tb_Voucher_Original.AsDataView();
            DataRow _BoundedRow = ((DataRowView)TableBinding.Current).Row;
            DataRow _OriginalRow = MyVoucherClass.tb_Voucher_Original.NewRow();
            int _BoundedID = Conversion.ToInteger(_BoundedRow["ID"]);

            if (_BoundedID > 0)
            {
                _View1.RowFilter = string.Concat("ID=", _BoundedID.ToString());
                if (_View1.Count == 1)
                {
                    _OriginalRow = _View1.ToTable().Rows[0];
                }

                TableBinding.SuspendBinding();

                foreach (DataRow _Row in tb_Voucher.Rows)
                {
                    if (_Row["ID"].ToString().Trim() == _OriginalRow["ID"].ToString().Trim())
                    {
                        int _indexRow = tb_Voucher.Rows.IndexOf(_Row);
                        tb_Voucher.Rows[_indexRow].ItemArray = _OriginalRow.ItemArray;
                        lblMessage.Text = "Revert Row";
                        txtCOA.Focus();
                    }
                }

                TableBinding.ResumeBinding();
            }
        }


        #endregion

        #region Browse Window

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            cBoxAccount.SelectedValue = Applied.ShowBrowseWin(tb_Accounts, cBoxAccount.SelectedValue);
            txtCOA.Focus();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            cBoxSupplier.SelectedValue = Applied.ShowBrowseWin(tb_Suppliers, cBoxSupplier.SelectedValue);
            txtSupplier.Focus();
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            cBoxProject.SelectedValue = Applied.ShowBrowseWin(tb_Projects, cBoxProject.SelectedValue);
            txtProject.Focus();
        }

        private void btnUnits_Click(object sender, EventArgs e)
        {
            cBoxUnit.SelectedValue = Applied.ShowBrowseWin(tb_Units, cBoxUnit.SelectedValue);
            txtUnit.Focus();
        }

        private void btnStocks_Click(object sender, EventArgs e)
        {
            cBoxStock.SelectedValue = Applied.ShowBrowseWin(tb_Stock, cBoxStock.SelectedValue);
            txtStock.Focus();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            cBoxEmployee.SelectedValue = Applied.ShowBrowseWin(tb_Employees, cBoxEmployee.SelectedValue);
            txtEmployee.Focus();
        }

        #endregion

        #region Copy

        private void btnCopy_Click(object sender, EventArgs e)
        {

            if (!Is_Copied) { return; }
            txtRefNo.Text = Copy_RefNo;
            txtChqNo.Text = Copy_Cheque_No;
            dt_ChqDate.Value = Copy_Cheque_Date;
            txtRemarks.Text = Copy_Remarks;
            txtDescription.Text = Copy_Description;
            cBoxPOrder.Text = Copy_POrder;
        }

        #endregion

        #region Print

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MyVoucherClass.Preview_Voucher();
        }


        #endregion


    }   //============================== END
}