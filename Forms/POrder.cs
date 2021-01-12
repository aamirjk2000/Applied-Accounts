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
    public partial class frmPOrder : Form
    {
        private DataTable dt_POrder = AppliedTable.GetDataTable(Tables.POrder);
        private DataTable dt_Suppliers = AppliedTable.GetComboData(Tables.Suppliers);

        private DataTable MyDataTable { get => dt_POrder; }
        
        private bool InitializingNow = true;

        

        #region Initializing

        public frmPOrder()
        {
            InitializeComponent();
            cBoxSuppliers.DataSource = dt_Suppliers;
            cBoxSuppliers.DisplayMember = "Title";
            cBoxSuppliers.ValueMember = "ID";

            MyNavigator.InitializeClass(MyDataTable);
            DataBinding();                      // Data Binding with form objects
            Load_Grid();                        // Load Data in Data Grid.

            InitializingNow = false;             // Objects has been initialized 
        }

        private void frmPOrder_Load(object sender, EventArgs e)
        {
            

        }

        private void DataBinding()
        {
            dtPODate.Value = DateTime.Now;
            txtID.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "ID", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCode.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Code", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTag.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "SCode", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTitle.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Title", true, DataSourceUpdateMode.OnPropertyChanged));
            txtRemarks.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Remarks", true, DataSourceUpdateMode.OnPropertyChanged));
            txtAmount.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Amount", true, DataSourceUpdateMode.OnPropertyChanged));
            chkActive.DataBindings.Add(new Binding("Checked", MyNavigator.MyBindingSource, "Active", true, DataSourceUpdateMode.OnValidation));
            dtPODate.DataBindings.Add(new Binding("Value", MyNavigator.MyBindingSource, "PODate", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTest.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Supplier", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void Load_Grid()
        {
            string[] ColumnsVisiable = { "Code", "SCode", "Title", "Supplier", "Amount", "Active" };
            string[] ColumnsName = { "Code", "Tag", "Title", "Supplier", "Amount", "Active" };
            int[] ColumnsFormat = { (int)TextFormat.Codes,0,0,0,
                                    (int)TextFormat.Currency,0};
            int[] ColumnWidth = { 60, 75, 200, 200, 80, 40 };

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
            MyDataGrid.BrowseGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        #endregion

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            cBoxSuppliers.SelectedValue = Applied.ShowBrowseWin(dt_Suppliers, cBoxSuppliers.SelectedValue);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Buttons

        private void MyNavigator_New_Record(object sender, EventArgs e)
        {
            txtCode.Focus();
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

            if (txtTitle.Text.Length == 0)                                                  // Check title must be some 
            {
                MyNavigator.NewRow_Valid = false;
                MyNavigator.MyMessage = "Null value in Title is not allowed. Enter some text.";
                txtTitle.Focus();
                return;
            }

            // Date if Empty
            if(string.IsNullOrEmpty(_Row["PODate"].ToString())) 
            {
                MyNavigator.MyDataView[MyNavigator.NewRecordPosition]["PODate"] = DateTime.Now;
            }

            // Active if empty
            if (_Row["Active"] == DBNull.Value) 
            { MyNavigator.MyDataView[MyNavigator.NewRecordPosition]["Active"] = true; }

        }
        private void MyNavigator_After_Save(object sender, EventArgs e)
        {
            dt_POrder = AppliedTable.GetDataTable(Tables.POrder);
            //MyDataGrid.MyDataView = dt_POrder.AsDataView();
            //MyDataGrid.Refresh();
        }

        private void MyNavigator_After_Delete(object sender, EventArgs e)
        {
           
        }

        #endregion

        #region Supplier

        private void cBoxSuppliers_TextChanged(object sender, EventArgs e)
        {
            if (InitializingNow) { return; }
            if (cBoxSuppliers.Text.Length == 0) { return; }
            if (cBoxSuppliers.SelectedValue == null) { return; }
            txtSupplier.Text = Applied.Code((long)cBoxSuppliers.SelectedValue, dt_Suppliers.AsDataView());
            //txtSupplier.Tag = cBoxSuppliers.SelectedValue.ToString();
            txtTest.Text = cBoxSuppliers.SelectedValue.ToString();

        }

        private void txtTest_TextChanged(object sender, EventArgs e)
        {
            
            txtSupplier.Text = Applied.Code(Conversion.ToLong(txtTest.Text.ToString()), dt_Suppliers.AsDataView());
            cBoxSuppliers.SelectedValue = Conversion.ToLong(txtTest.Text);
        }


        #endregion


    }
}
