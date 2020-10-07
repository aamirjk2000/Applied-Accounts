using Applied_Accounts.Classes;
using Applied_Accounts.Data;
using Applied_Accounts.Preview;
using Applied_Accounts.Reports;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Controls;
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
        public DataTable MyGridTable { get => MyVoucherClass.GetGridTable(); }

        private DataTable tbAccounts;
        private DataTable tbSuppliers;
        private DataTable tbProjects;
        private DataTable tbUnits;
        private DataTable tbStocks;
        private DataTable tbEmployees;

        private string MyDescription;                            // For copy and past
        private string MyRemarks;                                // for Copy and past.

        private readonly Color _Color1 = Color.Black;
        private readonly Color _Color2 = Color.Blue;

        private string Search_Title = "";                           // Search Title for all search ID in Table
        private int Search_ComboID = 0;                             // Search Value for Combo Box in All seach 

        #region Initialize

        public frmVouchers()
        {
            InitializeComponent();
            MyRefresh();
        }

        public frmVouchers(int _VoucherType)
        {
            MyVoucherType = _VoucherType;
            InitializeComponent();

            MyVoucherClass.Vou_Type = Enum.GetName(typeof(Applied.VoucherType), MyVoucherType);
            MyVoucherClass.Vou_No = MyVoucherClass.GetVoucherTag(MyVoucherType);
            txtVouNo.Text = MyVoucherClass.Vou_No;

            MyRefresh();
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
            tbAccounts = AppliedTable.GetDataTable((int)Tables.COA);
            tbSuppliers = AppliedTable.GetDataTable((int)Tables.Suppliers);
            tbProjects = AppliedTable.GetDataTable((int)Tables.Projects);
            tbUnits = AppliedTable.GetDataTable((int)Tables.Units);
            tbStocks = AppliedTable.GetDataTable((int)Tables.Stock);
            tbEmployees = AppliedTable.GetDataTable((int)Tables.Employees);
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

                    System.Windows.Forms.ComboBox _CBox = (System.Windows.Forms.ComboBox)_Object2;

                    //if (cboxVouType.Enabled) { _CBox.Enabled = false; return; }      // Disable if voucher Type is enable

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

                    System.Windows.Forms.TextBox _TextBox = (System.Windows.Forms.TextBox)_Object2;

                    _TextBox.Enabled = true;

                    if (_RowValue == null | _RowValue == DBNull.Value) { break; }

                    //if (((string)_RowValue).Trim() == _TextBox.Text.Trim())
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
        private void cBoxAccounts_DropDownClosed(object sender, EventArgs e)
        {
            txtAccount.Text = Applied.Code((long)cBoxAccounts.SelectedValue, tbAccounts.AsDataView());
        }
        private void cBoxSuppliers_DropDownClosed(object sender, EventArgs e)
        {
            txtVandor.Text = Applied.Code((long)cBoxSuppliers.SelectedValue, tbSuppliers.AsDataView());
        }
        private void cBoxProjects_DropDownClosed(object sender, EventArgs e)
        {
            txtProject.Text = Applied.Code((long)cBoxProjects.SelectedValue, tbProjects.AsDataView());
        }
        private void cBoxUnits_DropDownClosed(object sender, EventArgs e)
        {
            txtUnit.Text = Applied.Code((long)cBoxUnits.SelectedValue, tbUnits.AsDataView());
        }
        private void cBoxStocks_DropDownClosed(object sender, EventArgs e)
        {
            txtStock.Text = Applied.Code((long)cBoxStocks.SelectedValue, tbStocks.AsDataView());
        }
        private void cBoxEmployees_DropDownClosed(object sender, EventArgs e)
        {
            txtEmployee.Text = Applied.Code((long)cBoxEmployees.SelectedValue, tbEmployees.AsDataView());
        }

        #endregion

        #region Data Grid
        private void SetGrid()
        {

            if(((DataTable)Grid.DataSource).Rows.Count==0) { return; }

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
        }
        #endregion

        #region Browse Widnows

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            cBoxAccounts.SelectedValue = Applied.ShowBrowseWin(tbAccounts, cBoxAccounts.SelectedValue);

            //Browse _Browse = new Browse(new DataView(tbAccounts));
            //_Browse.ShowDialog();
            //cBoxAccounts.SelectedValue = _Browse.MyID;
        }
        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            cBoxSuppliers.SelectedValue = Applied.ShowBrowseWin(tbSuppliers, cBoxSuppliers.SelectedValue);

            //Browse _Browse = new Browse(new DataView(tbSuppliers));
            //_Browse.ShowDialog();
            //cBoxSuppliers.SelectedValue = _Browse.MyID;
        }
        private void btnProjects_Click(object sender, EventArgs e)
        {
            cBoxProjects.SelectedValue = Applied.ShowBrowseWin(tbProjects, cBoxProjects.SelectedValue);

            //Browse _Browse = new Browse(new DataView(tbProjects));
            //_Browse.ShowDialog();
            //cBoxProjects.SelectedValue = _Browse.MyID;
        }
        private void btnUnits_Click(object sender, EventArgs e)
        {
            cBoxUnits.SelectedValue = Applied.ShowBrowseWin(tbUnits, cBoxUnits.SelectedValue);

            //Browse _Browse = new Browse(new DataView(tbUnits));
            //_Browse.ShowDialog();
            //cBoxUnits.SelectedValue = _Browse.MyID;
        }
        private void btnStocks_Click(object sender, EventArgs e)
        {
            cBoxStocks.SelectedValue = Applied.ShowBrowseWin(tbStocks, cBoxStocks.SelectedValue);

            //Browse _Browse = new Browse(new DataView(tbStocks));
            //_Browse.ShowDialog();
            //cBoxStocks.SelectedValue = _Browse.MyID;
        }
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            cBoxEmployees.SelectedValue = Applied.ShowBrowseWin(tbEmployees, cBoxEmployees.SelectedValue);

            //Browse _Browse = new Browse(new DataView(tbEmployees));
            //_Browse.ShowDialog();
            //cBoxEmployees.SelectedValue = _Browse.MyID;
        }

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
            // Validte the Voucher before Save

            if (!Validate_Voucher())
            {
                MessageBox.Show("Voucher is not being validated to Save.");
                return;
            }

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
            MyRow["Supplier"] = Conversion.ToInteger(cBoxSuppliers.SelectedValue);
            MyRow["Project"] = Conversion.ToInteger(cBoxProjects.SelectedValue);
            MyRow["Stock"] = Conversion.ToInteger(cBoxStocks.SelectedValue);
            MyRow["Unit"] = Conversion.ToInteger(cBoxUnits.SelectedValue);
            MyRow["Employee"] = Conversion.ToInteger(cBoxEmployees.SelectedValue);
            MyRow["RefNo"] = txtRefNo.Text;
            MyRow["Chq_No"] = txtChqNo.Text;
            MyRow["Chq_Date"] = dtChqDate.Value.ToString();
            MyRow["DR"] = Conversion.ToMoney(txtDebit.Text);
            MyRow["CR"] = Conversion.ToMoney(txtCredit.Text);
            MyRow["Description"] = txtDescription.Text.Trim();
            MyRow["Remarks"] = txtRemarks.Text.Trim();

            foreach (DataRow _Row in MyDataTable.Rows)
            {
                int RowIndex = 1;

                if (Conversion.ToInteger(_Row["ID"]) == Conversion.ToInteger(MyRow["ID"]))
                {
                    RowIndex = MyDataTable.Rows.IndexOf(_Row);                          // Get Row Index 
                    MyDataTable.Rows[RowIndex].ItemArray = MyRow.ItemArray;             // Copy Text boxs into Row Columns
                    break;
                }
            }


            MyDescription = MyRow["Description"].ToString();                            // Copy Description
            MyRemarks = MyRow["Remarks"].ToString();                                    // Copy Remarks

            if (MyRow["SRNO"].ToString().Trim() == "1")
            {
                btnNext_Click(sender, e);
            }

            
            Repaint();

            string _Message = string.Concat("Transaction No ", MyRow["SRNO"], " has been saved.");
            MessageBox.Show(_Message, "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private bool Validate_Voucher()
        {
            // write codes for validation of the voucher and return true if validated perfect.
            //string _NewVouNo = MyVoucherClass
            // Validate Voucher before save into Database.
            return true;
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

        #region Voucher No Textbox

        private void txtVouNo_Enter(object sender, EventArgs e)
        {
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
            if (cBoxProjects.SelectedValue != null)
            { txtProject.Text = Applied.Code((long)cBoxProjects.SelectedValue, tbProjects.AsDataView()); }
            if (cBoxSuppliers.SelectedValue != null)
            { txtVandor.Text = Applied.Code((long)cBoxSuppliers.SelectedValue, tbSuppliers.AsDataView()); }
            if (cBoxStocks.SelectedValue != null)
            { txtStock.Text = Applied.Code((long)cBoxStocks.SelectedValue, tbStocks.AsDataView()); }
            if (cBoxUnits.SelectedValue != null)
            { txtUnit.Text = Applied.Code((long)cBoxUnits.SelectedValue, tbUnits.AsDataView()); }
            if (cBoxEmployees.SelectedValue != null)
            { txtEmployee.Text = Applied.Code((long)cBoxEmployees.SelectedValue, tbEmployees.AsDataView()); }

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

        private void cboxVouType_Validated(object sender, EventArgs e)
        {
            txtSRNO.Focus();
        }



        #endregion

        #region SR No


        private void txtSRNO_Enter(object sender, EventArgs e)
        {

        }

        private void txtSRNO_Validated(object sender, EventArgs e)
        {
            DisplayRow(MyRow);
            //Repaint();
        }

        private void txtSRNO_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox _TextBox = (System.Windows.Forms.TextBox)sender;

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
            ReportClass PreviewClass = new ReportClass();                                       // Initialize Report Class
            PreviewClass.DataSet_Name = "ds_Voucher";                                    // Dataset for the report
            PreviewClass.Vou_No = MyVoucherClass.Vou_No;                                        // Print Voucher No in report
            PreviewClass.Vou_Date = MyVoucherClass.Vou_Date;                                    // DAte of Voucher
            PreviewClass.Report_Location = Program.ReportsPath + "Report_Voucher.rdlc";         // Report Name 
            PreviewClass.DataSource_Filter = "Vou_No='" + MyVoucherClass.Vou_No + "'";          // Filter for the Data Source
            PreviewClass.DataSource = AppliedTable.GetDataTable(Tables.View_Voucher, PreviewClass.DataSource_Filter);
            PreviewClass.Report_Data = PreviewClass.DataSource.AsDataView();                    // Data for the report.
            PreviewClass.Heading1 = MyVoucherClass.Vou_Type + " Voucher";
            PreviewClass.Heading2 = MyVoucherClass.Vou_No + " | " + MyVoucherClass.Vou_Date.ToString(PreviewClass.Report_Heading_Format);


            //================================================================================== PREVIEW REPORT.
            frmPreview_Reports PreviewVoucher = new frmPreview_Reports(PreviewClass);           // Window form for the report.
            PreviewVoucher.ShowDialog();                                                        // Show Window form.

        }

        #endregion

        #region Voucher No

        private void txtVouNo_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox _TextBox = (System.Windows.Forms.TextBox)sender;
            string Voucher_No = _TextBox.Text.Trim();

            if (_TextBox.Text.Length == 0) { e.Cancel = false; return; }                 // Close this form in Leave event
            if (_TextBox.Text.ToUpper() == "NEW") { e.Cancel = false; MyVoucherClass = new VoucherClass(); return; }         // Create new Voucher in Leave Event
            if (_TextBox.Text.ToUpper() == "END") { e.Cancel = false; return; }         // Create new Voucher in Leave Event

            MyVoucherClass = new VoucherClass(Voucher_No);                               // Load Voucher into Class (Memory)

            if (Voucher_No.Trim().Length == 0) { return; }

            if (MyVoucherClass.Count_Table() > 0)                                       // If Exist Load Voucher Class
            {
                dtVouDate.Value = MyVoucherClass.Vou_Date;
                MessageBox.Show(string.Concat(MyDataTable.Rows.Count, " Transactions."), Voucher_No, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #endregion

        //================================== VALIDATION
        #region Validating

        #region Accounts

        private void cBoxAccounts_Enter(object sender, EventArgs e)
        {
            if (cBoxAccounts.DataSource == null) { return; }                               // Return is Datasource are not available;
            if (cboxVouType.SelectedValue == null) { return; }

            System.Windows.Forms.ComboBox _cBox = (System.Windows.Forms.ComboBox)cBoxAccounts;
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
            e.Cancel = SearchID(((System.Windows.Forms.TextBox)sender).Text, tbAccounts);
            e.Cancel = SearchCode(((System.Windows.Forms.TextBox)sender).Text, tbAccounts);
            e.Cancel = SearchTag(((System.Windows.Forms.TextBox)sender).Text, tbAccounts);
        }

        private void txtAccount_Validated(object sender, EventArgs e)
        {
            cBoxAccounts.SelectedValue = Search_ComboID;
        }



        #endregion

        #endregion

        #region Search ID / Code / Tag

        private bool SearchID(string _Value, DataTable _DataTable)
        {
            // Return value for e.Cancel of Text Boox Validating

            bool _Result = true;
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
            _DataView.RowFilter = "ID=" + _nValue.ToString();
            if (_DataView.Count == 1)
            {
                Search_ComboID = Conversion.ToInteger(_DataView[0]["ID"]);
                Search_Title = _DataView[0]["Title"].ToString();
                _Result = false;
            }
            return _Result;
        }

        private bool SearchCode(string _Value, DataTable _DataTable)
        {
            // Return value for e.Cancel of Text Boox Validating

            bool _Result = true;
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
            _DataView.RowFilter = "Code=" + _nValue.ToString();
            if (_DataView.Count == 1)
            {
                Search_ComboID = Conversion.ToInteger(_DataView[0]["ID"]);
                Search_Title = _DataView[0]["Title"].ToString();
                _Result = false;
            }
            return _Result;
        }

        private bool SearchTag(string _Value, DataTable _DataTable)
        {
            // Return value for e.Cancel of Text Boox Validating

            bool _Result = true;
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
            _DataView.RowFilter = "SCode=" + _nValue.ToString();
            if (_DataView.Count == 1)
            {
                Search_ComboID = Conversion.ToInteger(_DataView[0]["ID"]);
                Search_Title = _DataView[0]["Title"].ToString();
                _Result = false;
            }
            return _Result;
        }




        #endregion

        
    }       // END Main Class
}           // END NameSpace
