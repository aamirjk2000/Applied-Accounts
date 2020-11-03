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
    public partial class frmEmployees : Form
    {

        private DataTable MyDataTable = AppliedTable.GetDataTable((int)Tables.Employees);

        

        #region Initialize

        public frmEmployees()
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
            txtDesignation.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Designation", true, DataSourceUpdateMode.OnPropertyChanged));
            txtGrade.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Grade", true, DataSourceUpdateMode.OnPropertyChanged));
            txtDepartment.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Department", true, DataSourceUpdateMode.OnPropertyChanged));
            txtAddress.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Address", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCity.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "City", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCNIC.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "CNIC", true, DataSourceUpdateMode.OnPropertyChanged));
            txtRemarks.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Remarks", true, DataSourceUpdateMode.OnPropertyChanged));
            chkActive.DataBindings.Add(new Binding("Checked", MyNavigator.MyBindingSource, "Active", true, DataSourceUpdateMode.OnValidation));
        }

        private void Load_Grid()
        {
            string[] ColumnsVisiable = { "Code", "SCode", "Title", "Designation", "Active" };
            string[] ColumnsName = { "Code", "Tag", "Name of Employee", "Designation", "Active" };
            int[] ColumnsFormat = { (int)TextFormat.Codes, 0, 0, 0, 0 };

            int[] ColumnWidth = { 60, 60, 260, 75, 40 };

            MyDataGrid.ColumnsName = ColumnsName;
            MyDataGrid.ColumnsWidth = ColumnWidth;
            MyDataGrid.ColumnsVisiable = ColumnsVisiable;
            MyDataGrid.ColumnsFormat = ColumnsFormat;
            MyDataGrid.Load_Data(MyDataTable);
            MyDataGrid.Set_Columns();

            MyDataGrid.BrowseGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        #endregion


        #region LOAD

       

        #endregion

        #region Text box Value GET & SET

        
        #endregion


        #region Navigators Buttons


        private void MyNavigator_After_Delete(object sender, EventArgs e)
        {
            lblMessage.Text = "Record Deleted.";
        }

        private void MyNavigator_Before_Save(object sender, EventArgs e)
        {
            DataRow _Row = ((DataRowView)MyNavigator.TableBinding.Current).Row;

            if (MyNavigator.Current_Mode == (int)Applied.Modes.New)
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

            if (txtTitle.Text.Length == 0)
            {
                MyNavigator.NewRow_Valid = false;
                MyNavigator.MyMessage = "Project Title Name must be enter.";
                txtTitle.Focus();
                return;
            }

            lblMessage.Text = MyNavigator.MyMessage;

        }
        private void MyNavigator_After_Save(object sender, EventArgs e)
        {
            MyDataGrid.MyDataView = MyNavigator.TableClass.MyDataView;
        }

        
        private void MyNavigator_New_Record(object sender, EventArgs e)
        {
            txtCode.Focus();
        }



        #endregion

        private void btnExit_Click(object sender, EventArgs e) { Close(); }

        
    }           // END Main Class
}               // END Namespace
