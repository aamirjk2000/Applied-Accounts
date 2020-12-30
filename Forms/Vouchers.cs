using Applied_Accounts.Classes;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Applied_Accounts.Forms
{
    public partial class frmVouchers : Form
    {
        private const string NumberFormat = "{0:###,###,###,##0.00}";
        private string DateFormat = Applied.GetString("DataFormat");
        private string ComboDateFormat = Applied.GetString("Combo_DateFormat");

        public static VoucherClass MyVoucherClass = new VoucherClass();
        public static int MyVoucherType { get; set; }
        public DataRow MyRow { get => MyVoucherClass.CurrentRow; set => MyVoucherClass.CurrentRow = value; }
        public DataTable MyDataTable { get => MyVoucherClass.VoucherTable; set => MyVoucherClass.VoucherTable = value; }
        public DataTable MyDeleteTable { get => MyVoucherClass.DeleteTable; set => MyVoucherClass.DeleteTable = value; }
        public DataTable MyGridTable { get => MyVoucherClass.GetGridTable(); }

        private DataTable tbAccounts;
        private DataTable tbSuppliers;
        private DataTable tbProjects;
        private DataTable tbUnits;
        private DataTable tbStocks;
        private DataTable tbEmployees;

        private string MyCheque_No;                                 // For copy and past
        private string MyCheque_Date;                               // For copy and past
        private string MyDescription;                               // For copy and past
        private string MyRemarks;                                   // for Copy and past.

        private readonly Color _Color1 = Color.Black;
        private readonly Color _Color2 = Color.Blue;

        private string Search_Title = "";                           // Search Title for all search ID in Table
        private int Search_ComboID = 0;                             // Search Value for Combo Box in All seach 
        private bool InitializingNow = true;

        #region Initialize

        public frmVouchers()
        {
            InitializeComponent();
            MyRefresh();
            InitializingNow = false;
        }

        public frmVouchers(int _VoucherType)
        {
            MyVoucherType = _VoucherType;
            InitializeComponent();

            MyVoucherClass.Vou_Type = Enum.GetName(typeof(Applied.VoucherType), MyVoucherType);
            MyVoucherClass.Vou_No = "NEW";
            txtVouNo.Text = MyVoucherClass.Vou_No;
            MyRefresh();
            InitializingNow = false;                            // Object has completed the initialized process.
        }

        private void Voucher_Load(object sender, EventArgs e)
        {
            cboxVouType.DataSource = Enum.GetValues(typeof(Applied.VoucherType));
            cboxVouType.SelectedIndex = MyVoucherType;
        }

        #endregion

        #region Refresh

        private void MyRefresh()
        {

            //LOAD DATATABLE FROM DATABASE.
            //
            tbAccounts = AppliedTable.GetComboData((int)Tables.COA);
            tbSuppliers = AppliedTable.GetComboData((int)Tables.Suppliers);
            tbProjects = AppliedTable.GetComboData((int)Tables.Projects);
            tbUnits = AppliedTable.GetComboData((int)Tables.Units);
            tbStocks = AppliedTable.GetComboData((int)Tables.Stock);
            tbEmployees = AppliedTable.GetComboData((int)Tables.Employees);
            // DATABASE 

            dtVouDate.Format = DateTimePickerFormat.Custom;
            dtVouDate.CustomFormat = ComboDateFormat;
            dtVouDate.Value = DateTime.Now;

            dtChqDate.Format = DateTimePickerFormat.Custom;
            dtChqDate.CustomFormat = ComboDateFormat;
            dtChqDate.Value = DateTime.Now;

            MyVoucherClass.CurrentYear = Applied.GetInteger("CurrentYear");

            SetComboBox(true);

        }

        private void SetTitle()
        {

            switch (cboxVouType.SelectedValue)

            {
                case Applied.VoucherType.Journal:
                    Text = "Journal Voucher";
                    BackColor = Color.LightGoldenrodYellow;
                    break;

                case Applied.VoucherType.Payment:
                    Text = "Payment Voucher";
                    BackColor = Color.LightPink;
                    break;

                case Applied.VoucherType.Receipt:
                    Text = "Receipt Voucher";
                    BackColor = Color.LightSkyBlue;
                    break;

                case Applied.VoucherType.Revenue:
                    Text = "Revenue Voucher";
                    BackColor = Color.LightSalmon;
                    break;

                case Applied.VoucherType.Stock:
                    Text = "Stock Voucher";
                    BackColor = Color.LightSteelBlue;
                    break;

                case Applied.VoucherType.Salary:
                    Text = "Salary (Payroll) Voucher";
                    BackColor = Color.LightSlateGray;
                    break;

                default:
                    break;
            }
        }

        private void Repaint()
        {
            bool IsEqual = Total_Equal();                   // Check Voucher DR & CR Balance are equal and Show Save and prinmt button

            Repaint(MyRow["COA"], cBoxAccounts);
            Repaint(MyRow["Supplier"], cBoxSuppliers);
            Repaint(MyRow["Project"], cBoxProjects);
            Repaint(MyRow["Unit"], cBoxUnits);
            Repaint(MyRow["Stock"], cBoxStocks);
            Repaint(MyRow["Employee"], cBoxEmployees);

            Repaint(MyRow["RefNo"], txtRefNo);
            Repaint(MyRow["Chq_No"], txtChqNo);
            Repaint(MyRow["Chq_Date"], dtChqDate);

            Repaint(MyRow["DR"], txtDebit);
            Repaint(MyRow["CR"], txtCredit);

            Repaint(MyRow["Description"], txtDescription);
            Repaint(MyRow["Remarks"], txtRemarks);

            btnSave.Enabled = true;
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnUndo.Enabled = true;




        }

        private void Repaint(object _RowValue, object _Object2)
        {
            switch (_Object2.GetType().Name)
            {
                case "ComboBox":

                    ComboBox _CBox = (ComboBox)_Object2;

                    _CBox.Enabled = true;

                    if (Conversion.ToInteger(_RowValue) == Conversion.ToInteger(_CBox.SelectedValue))
                    {
                        _CBox.ForeColor = _Color1;
                    }

                    else
                    {
                        _CBox.ForeColor = _Color2;
                    }

                    break;

                case "TextBox":

                    TextBox _TextBox = (TextBox)_Object2;

                    _TextBox.Enabled = true;

                    if (_RowValue == null | _RowValue == DBNull.Value) { break; }

                    if (_RowValue.ToString().Trim() == _TextBox.Text.Trim())
                    {
                        _TextBox.ForeColor = _Color1;
                    }

                    else
                    {
                        _TextBox.ForeColor = _Color2;
                    }
                    break;

                default:
                    break;
            }
        }

        private void cboxVouType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxVouType.Text = MyVoucherClass.Vou_Type;

            SetTitle();                     // Display window title as per voucher type.
        }

        #endregion

        #region Combo Box Setup

        private void SetComboBox(bool _Value)
        {
            if (_Value)
            {
                if (tbAccounts.Rows.Count > 0)
                {
                    cBoxAccounts.DataSource = tbAccounts.AsDataView();
                    cBoxAccounts.DisplayMember = "Title";
                    cBoxAccounts.ValueMember = "ID";
                }
                else { cBoxAccounts.Enabled = false; }

                if (tbSuppliers.Rows.Count > 0)
                {
                    cBoxSuppliers.DataSource = tbSuppliers.AsDataView();
                    cBoxSuppliers.DisplayMember = "Title";
                    cBoxSuppliers.ValueMember = "ID";
                }
                else { cBoxSuppliers.Enabled = false; }

                if (tbProjects.Rows.Count > 0)
                {
                    cBoxProjects.DataSource = tbProjects.AsDataView();
                    cBoxProjects.DisplayMember = "Title";
                    cBoxProjects.ValueMember = "ID";
                }
                else { cBoxProjects.Enabled = false; }

                if (tbUnits.Rows.Count > 0)
                {
                    cBoxUnits.DataSource = tbUnits.AsDataView();
                    cBoxUnits.DisplayMember = "Title";
                    cBoxUnits.ValueMember = "ID";
                }
                else { cBoxUnits.Enabled = false; }

                if (tbStocks.Rows.Count > 0)
                {
                    cBoxStocks.DataSource = tbStocks.AsDataView();
                    cBoxStocks.DisplayMember = "Title";
                    cBoxStocks.ValueMember = "ID";
                }
                else { cBoxStocks.Enabled = false; }

                if (tbEmployees.Rows.Count > 0)
                {
                    cBoxEmployees.DataSource = tbEmployees.AsDataView();
                    cBoxEmployees.DisplayMember = "Title";
                    cBoxEmployees.ValueMember = "ID";
                }
                else { cBoxEmployees.Enabled = false; }
            }
            else
            {
                if (tbAccounts.Rows.Count > 0)
                {
                    cBoxAccounts.DataSource = null;
                    cBoxAccounts.DisplayMember = "";
                    cBoxAccounts.ValueMember = "";
                }
                else { cBoxAccounts.Enabled = false; }

                if (tbSuppliers.Rows.Count > 0)
                {
                    cBoxSuppliers.DataSource = null;
                    cBoxSuppliers.DisplayMember = "";
                    cBoxSuppliers.ValueMember = "";
                }
                else { cBoxSuppliers.Enabled = false; }

                if (tbProjects.Rows.Count > 0)
                {
                    cBoxProjects.DataSource = null;
                    cBoxProjects.DisplayMember = "";
                    cBoxProjects.ValueMember = "";
                }
                else { cBoxProjects.Enabled = false; }

                if (tbUnits.Rows.Count > 0)
                {
                    cBoxUnits.DataSource = null;
                    cBoxUnits.DisplayMember = "";
                    cBoxUnits.ValueMember = "";
                }
                else { cBoxUnits.Enabled = false; }

                if (tbStocks.Rows.Count > 0)
                {
                    cBoxStocks.DataSource = null;
                    cBoxStocks.DisplayMember = "";
                    cBoxStocks.ValueMember = "";
                }
                else { cBoxStocks.Enabled = false; }

                if (tbEmployees.Rows.Count > 0)
                {
                    cBoxEmployees.DataSource = null;
                    cBoxEmployees.DisplayMember = "";
                    cBoxEmployees.ValueMember = "";
                }
                else { cBoxEmployees.Enabled = false; }

            }


        }

        private void cBoxAccounts_TextChanged(object sender, EventArgs e)
        {
            if (cBoxAccounts.Text.Length == 0) { return; }
            if (cBoxAccounts.SelectedValue == null) { return; }
            txtAccount.Text = Applied.Code((long)cBoxAccounts.SelectedValue, tbAccounts.AsDataView());
        }

        private void cBoxSuppliers_TextChanged(object sender, EventArgs e)
        {
            if (cBoxSuppliers.Text.Length == 0) { return; }
            if (cBoxSuppliers.SelectedValue == null) { return; }
            txtVandor.Text = Applied.Code((long)cBoxSuppliers.SelectedValue, tbSuppliers.AsDataView());
        }

        private void cBoxProjects_TextChanged(object sender, EventArgs e)
        {
            if (cBoxProjects.Text.Length == 0) { return; }
            if (cBoxProjects.SelectedValue == null) { return; }
            txtProject.Text = Applied.Code((long)cBoxProjects.SelectedValue, tbProjects.AsDataView());
        }

        private void cBoxUnits_TextChanged(object sender, EventArgs e)
        {
            if (cBoxUnits.Text.Length == 0) { return; }
            if (cBoxUnits.SelectedValue == null) { return; }
            txtUnit.Text = Applied.Code((long)cBoxUnits.SelectedValue, tbUnits.AsDataView());

        }

        private void cBoxStocks_TextChanged(object sender, EventArgs e)
        {
            if (cBoxStocks.Text.Length == 0) { return; }
            if (cBoxStocks.SelectedValue == null) { return; }
            txtStock.Text = Applied.Code((long)cBoxStocks.SelectedValue, tbStocks.AsDataView());

        }

        private void cBoxEmployees_TextChanged(object sender, EventArgs e)
        {
            if (cBoxEmployees.Text.Length == 0) { return; }
            if (cBoxEmployees.SelectedValue == null) { return; }
            txtEmployee.Text = Applied.Code((long)cBoxEmployees.SelectedValue, tbEmployees.AsDataView());

        }

        //==================================================================




        #endregion

        #region Data Grid
        private void SetGrid()
        {

            if (((DataTable)Grid.DataSource).Rows.Count == 0) { return; }

            Grid.AllowUserToAddRows = false;
            Grid.AllowUserToDeleteRows = false;

            //Grid.ColumnCount = 6;
            Grid.Columns[0].HeaderText = "SNo.";
            Grid.Columns[1].HeaderText = "Account";
            Grid.Columns[2].HeaderText = "Vendor";
            Grid.Columns[3].HeaderText = "Debit";
            Grid.Columns[4].HeaderText = "Credit";
            Grid.Columns[5].HeaderText = "Description";

            Grid.Columns[0].DefaultCellStyle.Format = "###";
            Grid.Columns[1].DefaultCellStyle.Format = "@!";
            Grid.Columns[2].DefaultCellStyle.Format = "@!";
            Grid.Columns[3].DefaultCellStyle.Format = "#,###,###,###.##";
            Grid.Columns[4].DefaultCellStyle.Format = "#,###,###,###.##";
            Grid.Columns[5].DefaultCellStyle.Format = "";

            Grid.Columns[0].Width = 30;
            Grid.Columns[1].Width = 170;
            Grid.Columns[2].Width = 170;
            Grid.Columns[3].Width = 80;
            Grid.Columns[4].Width = 80;
            Grid.Columns[5].Width = 200;

            Grid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Grid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void P2_Enter(object sender, EventArgs e)
        {
            MyVoucherClass.GetGridTable();
            Grid.DataSource = MyGridTable;
            SetGrid();

            Grid_Enter(sender, e);              // Assign Total Row color
        }

        private void Grid_Enter(object sender, EventArgs e)
        {
            MyVoucherClass.Total_RowID = Grid.Rows.Count - 1;

            decimal TOT_DR = (decimal)Grid.Rows[MyVoucherClass.Total_RowID].Cells["Debit"].Value;
            decimal TOT_CR = (decimal)Grid.Rows[MyVoucherClass.Total_RowID].Cells["Credit"].Value;


            if (TOT_DR.Equals(TOT_CR))
            {
                Grid.Rows[MyVoucherClass.Total_RowID].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                Grid.Rows[MyVoucherClass.Total_RowID].DefaultCellStyle.ForeColor = Color.MidnightBlue;
            }
            else
            {
                Grid.Rows[MyVoucherClass.Total_RowID].DefaultCellStyle.BackColor = Color.Red;
                Grid.Rows[MyVoucherClass.Total_RowID].DefaultCellStyle.ForeColor = Color.Gold;
            }
        }

        #endregion

        #region Browse Widnows

        #region Button Click
        private void btnAccounts_Click(object sender, EventArgs e)
        {
            cBoxAccounts.SelectedValue = Applied.ShowBrowseWin(tbAccounts, cBoxAccounts.SelectedValue);
        }
        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            cBoxSuppliers.SelectedValue = Applied.ShowBrowseWin(tbSuppliers, cBoxSuppliers.SelectedValue);
        }
        private void btnProjects_Click(object sender, EventArgs e)
        {
            cBoxProjects.SelectedValue = Applied.ShowBrowseWin(tbProjects, cBoxProjects.SelectedValue);
        }
        private void btnUnits_Click(object sender, EventArgs e)
        {
            cBoxUnits.SelectedValue = Applied.ShowBrowseWin(tbUnits, cBoxUnits.SelectedValue);
        }
        private void btnStocks_Click(object sender, EventArgs e)
        {
            cBoxStocks.SelectedValue = Applied.ShowBrowseWin(tbStocks, cBoxStocks.SelectedValue);
        }
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            cBoxEmployees.SelectedValue = Applied.ShowBrowseWin(tbEmployees, cBoxEmployees.SelectedValue);
        }
        #endregion


        #endregion

        #region Buttons
        private void btnTop_Click(object sender, EventArgs e)
        {
            if (MyDataTable.Rows.Count > 0)
            {
                MyRow = MyDataTable.Rows[0];
                DisplayRow(MyRow);
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (MyDataTable.Rows.Count > 0)
            {
                int RowNo = MyDataTable.Rows.IndexOf(MyRow) + 1;

                if (RowNo == MyDataTable.Rows.Count)
                {
                    MyRow = MyDataTable.Rows[MyDataTable.Rows.Count - 1];
                }
                else
                {
                    MyRow = MyDataTable.Rows[RowNo];
                }

                DisplayRow(MyRow);
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (MyDataTable.Rows.Count > 0)
            {
                int RowNo = MyDataTable.Rows.IndexOf(MyRow) - 1;

                if (RowNo == -1)
                {
                    MyRow = MyDataTable.Rows[0];
                }
                else
                {
                    MyRow = MyDataTable.Rows[RowNo];
                }

                DisplayRow(MyRow);
            }
        }
        private void btnBottom_Click(object sender, EventArgs e)
        {
            if (MyDataTable.Rows.Count > 0)
            {
                MyRow = MyDataTable.Rows[MyDataTable.Rows.Count - 1];
                DisplayRow(MyRow);
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            MyVoucherClass.AddRow();                    // Create (Add) a new Row
            DisplayRow(MyRow);
        }

        #endregion

        #region Save Button
        private void btnSaveVoucher_Click(object sender, EventArgs e)
        {
            // Validte the Voucher before Save                              // future plan
            // Type Codes here.................

            //  SAVE    SAVE    SAVE    SAVE    SAVE    SAVE    SAVE    

            MyVoucherClass.Save();                                          // Save voucher (All Transactions) into Database Table.

            if (MyVoucherClass.Voucher_Saved)
            {
                MyVoucherClass = new VoucherClass(MyVoucherClass.Vou_No);   // Load Voucher again for Edit Mode.
                MyVoucherClass.CurrentRow = MyDataTable.Rows[0];            // Select 1sr row as current row.
                DisplayRow(MyVoucherClass.CurrentRow);                      // display current row into Text Boxes.
                Repaint();                                                  // Re-Paint Voucher form
                MyVoucherClass.Voucher_Saved = false;                       // Reset voucher Saved default value.
                Grid.DataSource = MyVoucherClass.GetGridTable();            // Load Voucher into Grid Data source
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            MyRow["ID"] = Conversion.ToLong(txtID.Text);
            MyRow["Vou_no"] = MyVoucherClass.Vou_No;
            MyRow["Vou_Date"] = MyVoucherClass.Vou_Date;
            MyRow["Vou_Type"] = MyVoucherClass.Vou_Type;
            MyRow["SRNO"] = Conversion.ToInteger(txtSRNO.Text);
            MyRow["COA"] = Conversion.ToInteger(cBoxAccounts.SelectedValue);
            MyRow["Supplier"] = Conversion.ToDBInteger(cBoxSuppliers.SelectedValue);
            MyRow["Project"] = Conversion.ToDBInteger(cBoxProjects.SelectedValue);
            MyRow["Stock"] = Conversion.ToDBInteger(cBoxStocks.SelectedValue);
            MyRow["Unit"] = Conversion.ToDBInteger(cBoxUnits.SelectedValue);
            MyRow["Employee"] = Conversion.ToDBInteger(cBoxEmployees.SelectedValue);
            MyRow["RefNo"] = txtRefNo.Text;
            MyRow["Chq_No"] = Conversion.ToDBInteger(txtChqNo.Text); ;
            MyRow["Chq_Date"] = dtChqDate.Value.ToString();
            MyRow["DR"] = Conversion.ToMoney(txtDebit.Text);
            MyRow["CR"] = Conversion.ToMoney(txtCredit.Text);
            MyRow["Description"] = txtDescription.Text.Trim();
            MyRow["Remarks"] = txtRemarks.Text.Trim();

            if (MyRow["Chq_No"] == DBNull.Value) { MyRow["Chq_Date"] = DBNull.Value; }   // Date Null value if cheque no is null;

            if (!Validate_Voucher())
            {
                lblMessage.Text = "Transaction No. " + MyRow["SRNO"].ToString() + " not saved.";
                return;
            }

            foreach (DataRow _Row in MyDataTable.Rows)
            {
                int RowIndex = 1;

                if (Conversion.ToInteger(_Row["ID"]) == Conversion.ToInteger(MyRow["ID"]))
                {
                    RowIndex = MyDataTable.Rows.IndexOf(_Row);                          // Get Row Index 
                    MyDataTable.Rows[RowIndex].ItemArray = MyRow.ItemArray;             // Copy Text boxs into Data Row Columns (Save)
                    break;
                }
            }


            MyCheque_No = MyRow["Chq_No"].ToString();                                   // Copy Description F9 for past 
            MyCheque_Date = MyRow["Chq_Date"].ToString();                               // Copy Description F9 for past 
            MyDescription = MyRow["Description"].ToString();                            // Copy Description F9 for past 
            MyRemarks = MyRow["Remarks"].ToString();                                    // Copy Remarks     F9 for past

            string _Message = string.Concat("Transaction No ", MyRow["SRNO"], " has been saved.");
            MessageBox.Show(_Message, "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Codes after save the row and finish message

            if (MyRow["SRNO"].ToString().Trim() == "1")
            {
                btnNext_Click(sender, e);
            }

            Grid.DataSource = MyVoucherClass.GetGridTable();
            Repaint();

        }
        private bool Validate_Voucher()
        {
            bool _Result = false;
            bool _Seek_COA = false;
            bool _Seek_Project = false;
            bool _Seek_Supplier = false;
            bool _Seek_Unit = false;
            bool _Seek_Stock = false;
            bool _Seek_Employee = false;

            if (Applied.Code((long)MyRow["COA"], tbAccounts.AsDataView()) == "")
            { _Seek_COA = false; }
            else { _Seek_COA = true; }


            if (MyRow["Project"] != DBNull.Value)
            {
                if ((long)MyRow["Project"] > 0)
                {
                    if (Applied.Code((long)MyRow["Project"], tbProjects.AsDataView()) == "")
                    { _Seek_Project = false; }
                    else { _Seek_Project = true; }
                }
                else { _Seek_Project = true; }
            }
            else { _Seek_Project = true; }

            if (MyRow["Supplier"] != DBNull.Value)
            {
                if ((long)MyRow["Supplier"] > 0)
                {
                    if (Applied.Code((long)MyRow["Supplier"], tbSuppliers.AsDataView()) == "")
                    { _Seek_Supplier = false; }
                    else { _Seek_Supplier = true; }
                }
                else { _Seek_Supplier = true; }
            }
            else { _Seek_Supplier = true; }

            if (MyRow["Unit"] != DBNull.Value)
            {
                if ((long)MyRow["Unit"] > 0)
                {
                    if (Applied.Code((long)MyRow["Unit"], tbUnits.AsDataView()) == "")
                    { _Seek_Unit = false; }
                    else { _Seek_Unit = true; }
                }
                else { _Seek_Unit = true; }
            }
            else { _Seek_Unit = true; }

            if (MyRow["Stock"] != DBNull.Value)
            {
                if ((long)MyRow["Stock"] > 0)
                {
                    if (Applied.Code((long)MyRow["Stock"], tbStocks.AsDataView()) == "")
                    { _Seek_Stock = false; }
                    else { _Seek_Stock = true; }
                }
                else { _Seek_Stock = true; }
            }
            else { _Seek_Stock = true; }

            if (MyRow["Employee"] != DBNull.Value)
            {
                if ((long)MyRow["Employee"] > 0)
                {
                    if (Applied.Code((long)MyRow["Employee"], tbEmployees.AsDataView()) == "")
                    { _Seek_Employee = false; }
                    else { _Seek_Employee = true; }
                }
                else { _Seek_Employee = true; }
            }
            else { _Seek_Employee = true; }


            if (_Seek_COA && _Seek_Project && _Seek_Supplier && _Seek_Unit && _Seek_Stock && _Seek_Employee)
            { _Result = true; }

            if (!_Result)
            {
                System.Text.StringBuilder _Message = new System.Text.StringBuilder();
                if (!_Seek_COA) { _Message.Append("Accounts is not valid. "); txtAccount.Focus(); }
                if (!_Seek_Project) { _Message.Append("Project is not valid. "); txtProject.Focus(); }
                if (!_Seek_Supplier) { _Message.Append("Supplier is not valid. "); txtVandor.Focus(); }
                if (!_Seek_Unit) { _Message.Append("Unit is not valid. "); txtUnit.Focus(); }
                if (!_Seek_Stock) { _Message.Append("Stock is not valid. "); txtStock.Focus(); }
                if (!_Seek_Employee) { _Message.Append("Employee is not valid. "); txtEmployee.Focus(); }

                MessageBox.Show(_Message.ToString(), MyVoucherClass.Vou_No.ToString() + " Validation");

            }



            return _Result;
        }

        #endregion

        #region Numaric Value


        private void txtDebit_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox _TextBox = (System.Windows.Forms.TextBox)sender;
            decimal _Value = Conversion.ToMoney(_TextBox.Text);

            if (_Value > 0) { txtCredit.Text = "0"; }
            _TextBox.Text = string.Format(NumberFormat, decimal.Parse(_TextBox.Text));
        }

        private void txtCredit_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox _TextBox = (System.Windows.Forms.TextBox)sender;
            decimal _Value = Conversion.ToMoney(_TextBox.Text);

            if (_Value > 0) { txtDebit.Text = "0"; }
            _TextBox.Text = string.Format(NumberFormat, decimal.Parse(_TextBox.Text));
        }

        private void txtDebit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Applied.IsNumeric(sender, e);
        }

        private void txtCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Applied.IsNumeric(sender, e);
        }

        #endregion

        #region Codes


        private void DisplayRow(DataRow _DataRow)
        {

            if (_DataRow == null) { return; }

            DateTime _Date_Chq = Conversion.ToDate(_DataRow["Chq_Date"].ToString());

            txtID.Text = _DataRow["ID"].ToString();
            txtVouNo.Text = _DataRow["Vou_NO"].ToString();
            dtChqDate.Value = Conversion.ToDate(_DataRow["Chq_Date"].ToString());
            txtSRNO.Text = _DataRow["SRNO"].ToString();
            txtDebit.Text = string.Format("{0:#,##0.00}", double.Parse(_DataRow["DR"].ToString()));
            txtCredit.Text = string.Format("{0:#,##0.00}", double.Parse(_DataRow["CR"].ToString()));
            txtChqNo.Text = _DataRow["Chq_No"].ToString();
            txtRefNo.Text = _DataRow["RefNo"].ToString();
            txtRemarks.Text = _DataRow["Remarks"].ToString();
            txtDescription.Text = _DataRow["Description"].ToString();

            cBoxAccounts.SelectedValue = _DataRow["COA"];
            cBoxProjects.SelectedValue = _DataRow["Project"];
            cBoxSuppliers.SelectedValue = _DataRow["Supplier"];
            cBoxStocks.SelectedValue = _DataRow["Stock"];
            cBoxUnits.SelectedValue = _DataRow["Unit"];
            cBoxEmployees.SelectedValue = _DataRow["Employee"];

            MyVoucherClass.Vou_No = _DataRow["Vou_NO"].ToString();
            MyVoucherClass.Vou_Type = cboxVouType.Text;

            btnSaveVoucher.Enabled = Total_Equal();

            if (txtChqNo.Text.Length == 0) { dtChqDate.Enabled = false; } else { dtChqDate.Enabled = true; }

            if (cBoxAccounts.SelectedValue != null)
            { txtAccount.Text = Applied.Code((long)cBoxAccounts.SelectedValue, tbAccounts.AsDataView()); }
            else { txtAccount.Text = ""; }

            if (cBoxProjects.SelectedValue != null)
            { txtProject.Text = Applied.Code((long)cBoxProjects.SelectedValue, tbProjects.AsDataView()); }
            else { txtProject.Text = ""; }

            if (cBoxSuppliers.SelectedValue != null)
            { txtVandor.Text = Applied.Code((long)cBoxSuppliers.SelectedValue, tbSuppliers.AsDataView()); }
            else { txtVandor.Text = ""; }

            if (cBoxStocks.SelectedValue != null)
            { txtStock.Text = Applied.Code((long)cBoxStocks.SelectedValue, tbStocks.AsDataView()); }
            else { txtStock.Text = ""; }

            if (cBoxUnits.SelectedValue != null)
            { txtUnit.Text = Applied.Code((long)cBoxUnits.SelectedValue, tbUnits.AsDataView()); }
            else { txtUnit.Text = ""; }

            if (cBoxEmployees.SelectedValue != null)
            { txtEmployee.Text = Applied.Code((long)cBoxEmployees.SelectedValue, tbEmployees.AsDataView()); }
            else { txtEmployee.Text = ""; }


        }
        private bool Total_Equal()
        {
            object Total_DR = MyDataTable.Compute("Sum(DR)", "");
            object Total_CR = MyDataTable.Compute("Sum(CR)", "");

            MyVoucherClass.Total_DR = (decimal)Total_DR;
            MyVoucherClass.Total_CR = (decimal)Total_CR;

            if (MyVoucherClass.Difference == 0)
            {

                btnSaveVoucher.ForeColor = Color.Black;
                btnSaveVoucher.BackColor = Color.LightGreen;
                btnSaveVoucher.Enabled = true;

                return true;
            }
            else
            {
                btnSaveVoucher.ForeColor = Color.Red;
                btnSaveVoucher.BackColor = Color.LightCoral;
                btnSaveVoucher.Enabled = false;
                return false;
            }

        }
        private void btnUndo_Click(object sender, EventArgs e)
        {
            SetTitle();

        }
        private void btnNewVoucher_Click(object sender, EventArgs e)
        {
            MyVoucherClass = new VoucherClass();

            txtVouNo.Text = "NEW";
            txtVouNo.Enabled = true;
            dtVouDate.Enabled = true;
            cboxVouType.Enabled = true;

            cBoxAccounts.Enabled = false;
            cBoxSuppliers.Enabled = false;
            cBoxProjects.Enabled = false;
            cBoxUnits.Enabled = false;
            cBoxEmployees.Enabled = false;
            cBoxStocks.Enabled = false;
            txtChqNo.Enabled = false;
            dtChqDate.Enabled = false;
            txtRefNo.Enabled = false;
            txtDebit.Enabled = false;
            txtCredit.Enabled = false;
            txtDescription.Enabled = false;
            txtRemarks.Enabled = false;

            btnNew.Enabled = false;
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            btnDelete.Enabled = false;

            //Repaint();
            dtVouDate.Focus();
        }
        private void dtVouDate_Validating(object sender, CancelEventArgs e)
        {
            MyVoucherClass.Vou_Date = dtVouDate.Value;
        }
        private void frmVouchers_BackColorChanged(object sender, EventArgs e)
        {
            //Pages.TabPages[0].BackColor = this.BackColor;
        }

        #endregion

        #region Leave 

        private void cBoxAccounts_Leave(object sender, EventArgs e)
        {
            ((DataView)cBoxAccounts.DataSource).RowFilter = string.Empty;
            Repaint(MyRow["COA"], cBoxAccounts);
        }

        private void cBoxSuppliers_Leave(object sender, EventArgs e)
        {
            Repaint(MyRow["Supplier"], cBoxSuppliers);
        }

        private void cBoxProjects_Leave(object sender, EventArgs e)
        {
            Repaint(MyRow["Project"], cBoxProjects);
        }

        private void cBoxUnits_Leave(object sender, EventArgs e)
        {
            Repaint(MyRow["Unit"], cBoxUnits);
        }

        private void cBoxStocks_Leave(object sender, EventArgs e)
        {
            Repaint(MyRow["Stock"], cBoxStocks);
        }

        private void cBoxEmployees_Leave(object sender, EventArgs e)
        {
            Repaint(MyRow["Employee"], cBoxEmployees);
        }

        private void txtChqNo_Leave(object sender, EventArgs e)
        {
            if (txtChqNo.Text.Length == 0) { dtChqDate.Enabled = false; } else { dtChqDate.Enabled = true; }
            Repaint(MyRow["Chq_No"], txtChqNo);
        }

        private void txtRefNo_Leave(object sender, EventArgs e)
        {
            Repaint(MyRow["RefNo"], txtRefNo);
        }

        #endregion

        #region Voucher Type

        private void cboxVouType_Leave(object sender, EventArgs e)
        {
            MyVoucherClass.Vou_TypeID = cboxVouType.SelectedIndex;
            MyVoucherClass.Vou_Type = MyVoucherClass.GetVoucherTypeName(MyVoucherClass.Vou_TypeID);

            if (MyDataTable.Rows.Count == 0) { return; }

            MyRow = MyDataTable.Rows[0];
            DisplayRow(MyRow);

        }

        #endregion

        #region SR No

        private void txtSRNO_Validated(object sender, EventArgs e)
        {
            DisplayRow(MyRow);
            //Repaint();
        }

        private void txtSRNO_Validating(object sender, CancelEventArgs e)
        {
            TextBox _TextBox = (TextBox)sender;

            if (_TextBox.Text.Length == 0) { return; }

            DataView _DataView = new DataView(MyDataTable);
            _DataView.RowFilter = string.Concat("SRNO=", _TextBox.Text);
            if (_DataView.Count == 1)
            {
                MyRow = _DataView.ToTable().Rows[0];
                e.Cancel = false;
            }
            else { e.Cancel = true; }
        }

        private void txtSRNO_Leave(object sender, EventArgs e)
        {
            txtVouNo.Enabled = false;
            dtVouDate.Enabled = false;
            cboxVouType.Enabled = false;
            Repaint();
        }

        #endregion

        #region Preview Voucher

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MyVoucherClass.Preview_Voucher();
        }

        #endregion

        #region New Voucher

        private void GetVoucher(string _VouNo)
        {

            string Voucher_No = _VouNo.ToUpper().Trim();

            if (Voucher_No.Length == 0) { return; }                                             // Close this form in Leave event
            if (Voucher_No == "-1") { Voucher_No = "NEW"; }
            if (Voucher_No == "NEW") { MyVoucherClass = new VoucherClass(); return; }           // Create new Voucher in Leave Event
            if (Voucher_No == "END") { return; }                                                // Create new Voucher in Leave Event


            MyVoucherClass = new VoucherClass(Voucher_No);                                      // Load Voucher into Class (Memory)

        }


        #endregion

        #region Voucher No

        private void txtVouNo_Validating(object sender, CancelEventArgs e)
        {
            TextBox _TextBox = (TextBox)sender;
            GetVoucher(_TextBox.Text);                                                  // Initialize the Voucher ********
            MyVoucherClass.Vou_Type = cboxVouType.Text;

            if (MyVoucherClass.Count_Table() > 0)                                       // If Exist Load Voucher Class
            {
                dtVouDate.Value = MyVoucherClass.Vou_Date;

                if (MyVoucherClass.Vou_No != "NEW")
                {
                    MessageBox.Show(string.Concat(MyDataTable.Rows.Count, " Transactions."), MyVoucherClass.Vou_No, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;                                        // Cancel true is Voucher not foud.
            }
        }

        private void txtVouNo_Validated(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox _TextBox = (System.Windows.Forms.TextBox)sender;


            switch (_TextBox.Text.Trim().ToUpper())
            {
                case "":
                    break;

                case "END":
                    break;

                default:
                    SetComboBox(true);                                              // Enable Combo Box
                    DisplayRow(MyDataTable.Rows[0]);                                // Display First Row of voucher into Text Boox
                    char[] VoucherTag = MyVoucherClass.Vou_No.ToCharArray();        // Get Voucher Type Tag 

                    if (VoucherTag.Length > 0)                                      // If Tax existing
                    {
                        cboxVouType.SelectedIndex = MyVoucherClass.GetVoucherTypeID(VoucherTag[0]);     // show Vocher Type in Voucher Combo
                    }
                    break;
            }
            cboxVouType.Focus();
        }

        private void txtVouNo_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox _TextBox = (System.Windows.Forms.TextBox)sender;
            if (_TextBox.Text.Length == 0) { Close(); }
            if (_TextBox.Text.ToUpper() == "END") { Close(); }
        }

        #endregion

        #region Copy Remarks

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                txtDescription.Text = MyDescription;
            }
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                txtRemarks.Text = MyRemarks;
            }
        }

        private void txtChqNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                txtChqNo.Text = MyCheque_No;
                dtChqDate.Value = Conversion.ToDate(MyCheque_Date);
                txtDescription.Text = MyDescription;
                txtRemarks.Text = MyRemarks;
            }
        }


        #endregion

        //================================== VALIDATION
        #region Validating

        #region Accounts

        private void cBoxAccounts_Enter(object sender, EventArgs e)
        {
            if (InitializingNow) { return; }
            if (cBoxAccounts.DataSource == null) { return; }                               // Return is Datasource are not available;
            if (cboxVouType.SelectedValue == null) { return; }

            ComboBox _cBox = (ComboBox)cBoxAccounts;
            DataView _DataView = (DataView)_cBox.DataSource;
            int _Vou_Type = (int)cboxVouType.SelectedValue;

            if (Conversion.ToInteger(txtSRNO.Text) == 1)
            {
                if (_Vou_Type == (int)Applied.VoucherType.Payment)
                {
                    _DataView.RowFilter = "IsCashBook=1 OR IsBankbook=1";      // Show only Bank and Cash books
                }
                else
                {
                    _DataView.RowFilter = string.Empty;
                }
            }
            else
            {
                _DataView.RowFilter = string.Empty;
            }

        }

        private void txtAccount_Validating(object sender, CancelEventArgs e)
        {
            if (InitializingNow) { return; }
            e.Cancel = MyValidating(sender, tbAccounts);
        }

        private void txtAccount_Validated(object sender, EventArgs e)
        {
            if (InitializingNow) { return; }
            if (((TextBox)sender).Text.Length > 0)
            {
                cBoxAccounts.SelectedValue = Search_ComboID;
            }
        }


        #endregion

        #region Supplier

        private void txtVandor_Validating(object sender, CancelEventArgs e)
        {
            if (txtVandor.Text.Length == 0)
            {
                cBoxSuppliers.SelectedValue = 0;
                cBoxSuppliers.Text = "";
                return;
            }

            if (Conversion.ToInteger(txtVandor.Text) == 0)
            {
                cBoxSuppliers.SelectedValue = 0;
                cBoxSuppliers.Text = "";
                e.Cancel = false;
                return;
            }

            e.Cancel = MyValidating(sender, tbSuppliers);
        }

        private void txtVandor_Validated(object sender, EventArgs e)
        {


            if (((TextBox)sender).Text.Length > 0)
            {
                cBoxSuppliers.SelectedValue = Search_ComboID;
            }
        }

        #endregion

        #region project

        private void txtProject_Validating(object sender, CancelEventArgs e)
        {
            if (Conversion.ToInteger(txtProject.Text) == 0)
            {
                cBoxProjects.SelectedValue = 0;
                cBoxProjects.Text = "";
                e.Cancel = false;
                return;
            }
            e.Cancel = MyValidating(sender, tbProjects);
        }

        private void txtProject_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length > 0)
            {
                cBoxProjects.SelectedValue = Search_ComboID;
            }
        }

        #endregion

        #region Unit

        private void txtUnit_Validating(object sender, CancelEventArgs e)
        {
            if (Conversion.ToInteger(txtUnit.Text) == 0)
            {
                cBoxUnits.SelectedValue = 0;
                cBoxUnits.Text = "";
                e.Cancel = false;
                return;
            }

            e.Cancel = MyValidating(sender, tbUnits);
        }

        private void txtUnit_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length > 0)
            {
                cBoxUnits.SelectedValue = Search_ComboID;
            }
        }

        #endregion

        #region Stock

        private void txtStock_Validating(object sender, CancelEventArgs e)
        {
            if (Conversion.ToInteger(txtStock.Text) == 0)
            {
                cBoxStocks.SelectedValue = 0;
                cBoxStocks.Text = "";
                e.Cancel = false;
                return;
            }


            e.Cancel = MyValidating(sender, tbStocks);
        }

        private void txtStock_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length > 0)
            {
                cBoxStocks.SelectedValue = Search_ComboID;
            }
        }

        #endregion

        #region Employee
        private void txtEmployee_Validating(object sender, CancelEventArgs e)
        {
            if (Conversion.ToInteger(txtEmployee.Text) == 0)
            {
                cBoxEmployees.SelectedValue = 0;
                cBoxEmployees.Text = "";
                e.Cancel = false;
                return;
            }
        }
        private void txtEmployee_Validated(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length > 0)
            {
                cBoxEmployees.SelectedValue = Search_ComboID;
            }
        }

        #endregion

        private bool MyValidating(object sender, DataTable _DataTable)
        {
            if (((TextBox)sender).Text.Length == 0) { return false; }      // Text Box is empty, do not validate


            bool IsSearch1 = SearchID(((TextBox)sender).Text, _DataTable);              // Seek Id in Table
            bool IsSearch2 = SearchCode(((TextBox)sender).Text, _DataTable);            // Seek Code in Table
            bool IsSearch3 = SearchTag(((TextBox)sender).Text, _DataTable);             // Seek SCode in table
            if (IsSearch1 || IsSearch2 || IsSearch3) { return false; } else { return true; }
        }

        #endregion

        //=================================== END VALIDATING


        #region Search ID / Code / Tag

        private bool SearchID(string _Value, DataTable _DataTable)
        {
            // Return value for e.Cancel of Text Boox Validating

            bool _Result = false;
            long _nValue = 0;

            DataView _DataView = _DataTable.AsDataView();

            if (_Value == null || _Value.Trim() == string.Empty)
            {
                _nValue = 0;
            }
            else
            {
                try
                {
                    _nValue = long.Parse(_Value);
                }
                catch
                {
                    _nValue = 0;
                }
            }
            _DataView.RowFilter = "ID=" + _nValue.ToString().Trim();
            if (_DataView.Count == 1)
            {
                Search_ComboID = Conversion.ToInteger(_DataView[0]["ID"]);
                Search_Title = _DataView[0]["Title"].ToString();
                _Result = true;
            }
            return _Result;
        }
        private bool SearchCode(string _Value, DataTable _DataTable)
        {
            // Return value for e.Cancel of Text Boox Validating

            bool _Result = false;

            DataView _DataView = _DataTable.AsDataView();

            _DataView.RowFilter = "Code='" + _Value.ToString().Trim() + "'";
            if (_DataView.Count == 1)
            {
                Search_ComboID = Conversion.ToInteger(_DataView[0]["ID"]);
                Search_Title = _DataView[0]["Title"].ToString();
                _Result = true;
            }
            return _Result;
        }
        private bool SearchTag(string _Value, DataTable _DataTable)
        {
            // Return value for e.Cancel of Text Boox Validating

            bool _Result = false;

            DataView _DataView = _DataTable.AsDataView();

            _DataView.RowFilter = "SCode='" + _Value.ToString().Trim() + "'";
            if (_DataView.Count == 1)
            {
                Search_ComboID = Conversion.ToInteger(_DataView[0]["ID"]);
                Search_Title = _DataView[0]["Title"].ToString();
                _Result = true;
            }
            return _Result;
        }

        #endregion

        #region ROW Select Buttons

        private void btn1_Click(object sender, EventArgs e)
        {
            DataView _Temp = new DataView(MyDataTable);
            _Temp.RowFilter = "SRNO=1";

            if (_Temp.Count == 1) { MyRow = ((DataRowView)_Temp[0]).Row; DisplayRow(MyRow); }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            DataView _Temp = new DataView(MyDataTable);
            _Temp.RowFilter = "SRNO=2";

            if (_Temp.Count == 1) { MyRow = ((DataRowView)_Temp[0]).Row; DisplayRow(MyRow); }
        }

        #endregion

        #region DELETE Button
        private void btnDelete_Click(object sender, EventArgs e)
        {


            MyRow["ID"] = Conversion.ToLong(txtID.Text);
            MyRow["Vou_no"] = MyVoucherClass.Vou_No;
            MyRow["Vou_Date"] = MyVoucherClass.Vou_Date;
            MyRow["Vou_Type"] = MyVoucherClass.Vou_Type;
            MyRow["SRNO"] = Conversion.ToInteger(txtSRNO.Text);
            MyRow["COA"] = Conversion.ToInteger(cBoxAccounts.SelectedValue);
            MyRow["Supplier"] = Conversion.ToDBInteger(cBoxSuppliers.SelectedValue);
            MyRow["Project"] = Conversion.ToDBInteger(cBoxProjects.SelectedValue);
            MyRow["Stock"] = Conversion.ToDBInteger(cBoxStocks.SelectedValue);
            MyRow["Unit"] = Conversion.ToDBInteger(cBoxUnits.SelectedValue);
            MyRow["Employee"] = Conversion.ToDBInteger(cBoxEmployees.SelectedValue);
            MyRow["RefNo"] = txtRefNo.Text;
            MyRow["Chq_No"] = Conversion.ToDBInteger(txtChqNo.Text); ;
            MyRow["Chq_Date"] = dtChqDate.Value.ToString();
            MyRow["DR"] = Conversion.ToMoney(txtDebit.Text);
            MyRow["CR"] = Conversion.ToMoney(txtCredit.Text);
            MyRow["Description"] = txtDescription.Text.Trim();
            MyRow["Remarks"] = txtRemarks.Text.Trim();

            long _ID = Conversion.ToLong(MyRow["ID"]);

            object[] RowValues = MyRow.ItemArray;

            DialogResult _YesNo;
            string _Message = "Are you sure to DELETE \n Voucher Serial No. " + MyRow["SRNO"].ToString();
            _YesNo = MessageBox.Show(_Message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (_YesNo == DialogResult.Yes)
            {
                int RowIndex = 0;

                if (MyDeleteTable.Rows.Count == 0)
                {
                    MyDeleteTable.Rows.Add(MyRow.ItemArray);
                }
                else
                {
                    foreach (DataRow _Row in MyDeleteTable.Rows)
                    {
                        RowIndex = 1;

                        if (Conversion.ToInteger(_Row["ID"]) == _ID)
                        {
                            RowIndex = MyDeleteTable.Rows.IndexOf(_Row);               // Get Row Index 
                            MyDeleteTable.Rows[RowIndex].ItemArray = MyRow.ItemArray;
                            break;
                        }
                    }
                }


                foreach (DataRow _Row in MyDataTable.Rows)                          // Delete Row in Data Table
                {
                    RowIndex = 1;


                    if (Conversion.ToInteger(_Row["ID"]) == _ID)
                    {

                        RowIndex = MyDataTable.Rows.IndexOf(_Row);               // Get Row Index 
                        if (RowIndex == -1)
                        {
                            MessageBox.Show("Data Table does not have the deleted row");
                            break;
                        }
                        else
                        {
                            MyDataTable.Rows[RowIndex].ItemArray = MyRow.ItemArray;
                            RowIndex = MyDataTable.Rows.IndexOf(_Row);               // Get Row Index 
                            MyDataTable.Rows[RowIndex].Delete();                     // Copy Text boxs into Data Row Columns (Save)
                            break;
                        }

                    }

                }

                long SRNO_Reset = 1;
                foreach (DataRow _Row in MyDataTable.Rows)                          // Reset Serial No. of Voucher
                {
                    if ((long)_Row["SRNO"] != SRNO_Reset)                        // Reset Serial Number of Voucher in ROW DELETE Process.
                    {
                        _Row["SRNO"] = SRNO_Reset;
                    }

                    SRNO_Reset += 1;
                }

                _Message = string.Concat("Transaction No ", RowValues[5].ToString(), " has been marked Deleted.");
                MessageBox.Show(_Message, "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            Grid.DataSource = MyVoucherClass.GetGridTable();
            btnNext_Click(sender, e);
            Repaint();
        }


        #endregion

        #region Reset Serial No.

        private void label5_DoubleClick(object sender, EventArgs e)
        {
            DialogResult _YesNo =
            MessageBox.Show("Reset Serail Numbers", "SERIAL NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_YesNo == DialogResult.Yes)
            {
                int SRNO_Reset = 1;

                foreach (DataRow _Row in MyVoucherClass.VoucherTable.Rows)
                {
                    _Row["SRNO"] = SRNO_Reset;
                    SRNO_Reset += 1;
                }
            }
        }

        #endregion


    }       // END Main Class
}           // END NameSpace
