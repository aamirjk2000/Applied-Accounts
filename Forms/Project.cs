using System;
using System.Data;
using System.Windows.Forms;
using Applied_Accounts.Classes;

namespace Applied_Accounts.Forms
{
    public partial class frmProject : Form
    {
        private DataTable MyDataTable = AppliedTable.GetDataTable(Tables.Projects);

        #region Initialize

        public frmProject()
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
            txtLocation.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Location", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCity.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "City", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCost.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Cost", true, DataSourceUpdateMode.OnPropertyChanged));
            txtNature.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Nature", true, DataSourceUpdateMode.OnPropertyChanged));
            txtRemarks.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Remarks", true, DataSourceUpdateMode.OnPropertyChanged));
            chkActive.DataBindings.Add(new Binding("Checked", MyNavigator.MyBindingSource, "Active", true, DataSourceUpdateMode.OnValidation));
        }

        private void Load_Grid()
        {
            string[] ColumnsVisiable = { "Code", "SCode", "Title", "Location", "Active" };
            string[] ColumnsName = { "Code", "Tag", "Title", "Location", "Active" };
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

      

        #region Navigators Buttons

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
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

        private void MyNavigator_After_Delete(object sender, EventArgs e)
        {

        }

        private void MyNavigator_After_Save(object sender, EventArgs e)
        {

        }

        private void MyNavigator_New_Record(object sender, EventArgs e)
        {

        }
        
        #endregion
    }                       // Main
}                           // Name space
