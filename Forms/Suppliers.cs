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
    public partial class frmSuppliers : Form
    {

        private DataTable MyDataTable = AppliedTable.GetDataTable(Tables.Suppliers);
        

        #region initialize

        public frmSuppliers()
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
            txtPerson.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Person", true, DataSourceUpdateMode.OnPropertyChanged));
            txtContact.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Contact", true, DataSourceUpdateMode.OnPropertyChanged));
            txtAddress.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Address", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCity.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "City", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCountry.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Country", true, DataSourceUpdateMode.OnPropertyChanged));
            txtNTN.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "NTN", true, DataSourceUpdateMode.OnPropertyChanged));
            txtSTN.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "STN", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCNIC.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "CNIC", true, DataSourceUpdateMode.OnPropertyChanged));
            chkActive.DataBindings.Add(new Binding("Checked", MyNavigator.MyBindingSource, "Active", true, DataSourceUpdateMode.OnValidation));
        }

        private void Load_Grid()
        {
            string[] ColumnsVisiable = { "Code", "SCode", "Title", "Contact", "Active" };
            string[] ColumnsName = { "Code", "Tag", "Title", "Contact", "Active" };
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

        #region Navigators buttons

        private void MyNavigator_After_Delete(object sender, EventArgs e) {}
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

            if(txtTitle.Text.Length==0)
            {
                MyNavigator.NewRow_Valid = false;
                MyNavigator.MyMessage = "Supplier Name must be enter.";
                txtTitle.Focus();
                return;
            }

            if (_Row["Active"] == DBNull.Value) { MyNavigator.MyDataView[MyNavigator.NewRecordPosition]["Active"] = true; }
            if (_Row["Nature"] == DBNull.Value) { MyNavigator.MyDataView[MyNavigator.NewRecordPosition]["Nature"] = 1; }

        }
        
        private void MyNavigator_After_Save(object sender, EventArgs e) {}
        private void MyNavigator_New_Record(object sender, EventArgs e) {}
        private void btnExit_Click(object sender, EventArgs e) { Close(); }
        #endregion

       

        
    }       // END Main Class
}           // END Namespace
