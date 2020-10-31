using Applied_Accounts.Classes;
using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Runtime.Remoting;
using System.Windows.Forms;
using static Applied_Accounts.Classes.Applied;

namespace Applied_Accounts
{
    public partial class frmCOA : Form
    {

        private DataTable MyDataTable = AppliedTable.GetDataTable(Tables.COA);
        private DataView MyTableView { get => MyNavigator.MyDataView; }

        private Code_Validation Code_Validate = new Code_Validation();
        private DataTable tb_Notes = AppliedTable.GetDataTable(Tables.Notes);


        public frmCOA()
        {
            InitializeComponent();
            MyNavigator.InitializeClass(MyDataTable);

            DataBinding();                      // Data Binding with form objects
            Load_Grid();                        // Load Data in Data Grid.

        }

        private void DataBinding()
        {
            txtID.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "ID", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCode.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Code", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTag.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "SCode", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTitle.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Title", true, DataSourceUpdateMode.OnPropertyChanged));
            txtNote.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Notes", true, DataSourceUpdateMode.OnPropertyChanged));
            txtOBal.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "OBal", true, DataSourceUpdateMode.OnPropertyChanged));
            chkCash.DataBindings.Add(new Binding("Checked", MyNavigator.MyBindingSource, "IsCashBook", true, DataSourceUpdateMode.OnValidation));
            chkBank.DataBindings.Add(new Binding("Checked", MyNavigator.MyBindingSource, "IsBankBook", true, DataSourceUpdateMode.OnValidation));
            chkActive.DataBindings.Add(new Binding("Checked", MyNavigator.MyBindingSource, "Active", true, DataSourceUpdateMode.OnValidation));



        }

        private void Load_Grid()
        {
            string[] ColumnsVisiable = { "Code", "SCode", "Title", "IsCashBook", "IsBankBook", "Notes", "OBal", "Active" };
            string[] ColumnsName = { "Code", "Tag", "Title", "Cash", "Bank", "Notes", "Opening Balance", "Active" };
            int[] ColumnsFormat = { (int)TextFormat.Codes,0,0,
                                    (int)TextFormat.Boolean,
                                    (int)TextFormat.Boolean,
                                    (int)TextFormat.Numbers,
                                    (int)TextFormat.Currency,0};
            int[] ColumnWidth = { 60, 75, 260, 50, 50, 50, 80, 40 };

            MyDataGrid.ColumnsName = ColumnsName;
            MyDataGrid.ColumnsWidth = ColumnWidth;
            MyDataGrid.ColumnsVisiable = ColumnsVisiable;
            MyDataGrid.ColumnsFormat = ColumnsFormat;
            MyDataGrid.BrowseGrid.DataSource = MyDataTable;
            MyDataGrid.Set_Columns();

            MyDataGrid.BrowseGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MyDataGrid.BrowseGrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MyDataGrid.BrowseGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            MyDataGrid.BrowseGrid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        #region Load 

        private void COA_Load(object sender, EventArgs e)
        {
        }

        #endregion
        private void txtNote_Validating(object sender, CancelEventArgs e)
        {
            //Classes.Validation thisValidation = new Classes.Validation((TextBox)sender, (int)Tables.Notes);
            //e.Cancel = thisValidation.TextValidation();
            //lblMessage.Text = thisValidation.Message;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Navigator Codes

        private void MyNavigator_After_Delete(object sender, EventArgs e)
        {

        }

        #region SAVE Before and After

        private void MyNavigator_Before_Save(object sender, EventArgs e)
        {
            DataRow _Row = ((DataRowView)MyNavigator.TableBinding.Current).Row;

            if (MyNavigator.Current_Mode == Applied.Modes.New)
            {

                if (string.Equals(Applied.Code(txtCode.Text, MyDataTable.AsDataView()).Trim(), txtCode.Text.Trim()))
                {
                    MyNavigator.NewRow_Valid = false;
                    MyNavigator.MyMessage = "Code is already exist.";
                    txtCode.Text = "";
                    txtCode.Focus();
                    return;
                }

            }


            if (!string.Equals(Applied.Code(txtNote.Text, tb_Notes.AsDataView()), txtNote.Text.Trim()))
            {
                MyNavigator.NewRow_Valid = false;
                MyNavigator.MyMessage = "Account Note is not exist.";
                txtNote.Text = "";
                return;
            }
            else
            {
                MyNavigator.MyDataView[MyNavigator.NewRecordPosition]["Notes"] = Applied.Code2ID(txtNote.Text, tb_Notes.AsDataView());
            }

            if (txtTitle.Text.Length == 0)                                                  // Check title must be some 
            {
                MyNavigator.NewRow_Valid = false;
                MyNavigator.MyMessage = "Null value in Title is not allowed. Enter some text.";
                txtTitle.Focus();
                return;

            }




            // Set DEfault values is Data Columns value is null
            if (_Row["IsBankbook"] == DBNull.Value) { MyNavigator.MyDataView[MyNavigator.NewRecordPosition]["IsBankBook"] = false; }
            if (_Row["IsCashbook"] == DBNull.Value) { MyNavigator.MyDataView[MyNavigator.NewRecordPosition]["IsCashBook"] = false; }
            if (_Row["OBal"] == DBNull.Value) { MyNavigator.MyDataView[MyNavigator.NewRecordPosition]["OBal"] = 0; }
            if (_Row["Active"] == DBNull.Value) { MyNavigator.MyDataView[MyNavigator.NewRecordPosition]["Active"] = true; }


        }

        private void MyNavigator_After_Save(object sender, EventArgs e)
        {
        }

        #endregion

        private void MyNavigator_New_Record(object sender, EventArgs e)
        {
            txtCode.Focus();
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {


        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtCode.DataBindings.Clear();
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            txtCode.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Code", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            int _NoteID = Conversion.ToInteger(((TextBox)sender).Text);
            txtNotesTitle.Text = Applied.Title(((TextBox)sender).Text, tb_Notes.AsDataView());
        }




        #endregion

        //=======================================
    }                   // Main Codes
}                       // NameSpave
