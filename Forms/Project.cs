using System;
using System.Data;
using System.Windows.Forms;
using Applied_Accounts.Classes;

namespace Applied_Accounts.Forms
{
    public partial class frmProject : Form
    {
        private DataTable MyDataTable;
        private DataTable TableSupplier;
        private bool IsDataLoad = false;

        private DataRow thisRow { get => MyNavigator.TableClass.MyDataRow; set => MyNavigator.TableClass.MyDataRow = value; }

        #region Initialize

        public frmProject()
        {
            InitializeComponent();
        }

        //public frmProject(int _DataTableID)
        //{
        //    InitializeComponent();
        //    Load_Data(_DataTableID);
        //}

        #endregion

        #region Load Data and Objects.
        public void Load_Data(int _DataTableID)
        {
            DataTable _DataTable = AppliedTable.GetDataTable(_DataTableID);
            Grid_Projects.MyDataView = new DataView(_DataTable);
            MyNavigator.InitializeClass(_DataTable);

            MyDataTable = _DataTable;
            TableSupplier = AppliedTable.GetDataTable((int)Tables.Suppliers);
            IsDataLoad = true;

            cboxSupplier.DataSource = TableSupplier;
            cboxSupplier.DisplayMember = "Title";
            cboxSupplier.ValueMember = "ID";

        }
        private void Grid_Load(object sender, EventArgs e)              // Load List of Project in Data Grid
        {
            if(!IsDataLoad) { Load_Data((int)Tables.Projects);}
            Grid_Projects.MyDataView = new DataView(MyDataTable);

            if (!IsDataLoad) { Load_Data((int)Tables.Projects); }   // Load Table if not loaded.
            Grid_Projects.Load_Data(MyNavigator.TableClass.MyDataTable);
            string[] ColumnsVisiable = { "Code", "SCode", "Title", "City", "Cost","Active"};
            string[] ColumnsName = { "Code", "Tag", "Title", "City", "Cost","Active"};
            int[] ColumnsFormat = { (int)TextFormat.Codes, 0, 0, 0, (int)TextFormat.Boolean, 0, 0, 0 };
            int[] ColumnWidth = { 60, 75, 260, 80, 50, 50, 150, 30 };

            Grid_Projects.ColumnsName = ColumnsName;
            Grid_Projects.ColumnsVisiable = ColumnsVisiable;
            Grid_Projects.ColumnsFormat = ColumnsFormat;
            Grid_Projects.ColumnsWidth = ColumnWidth;
            Grid_Projects.Set_Columns();

        }
        private void MyNavigator_Load(object sender, EventArgs e)
        {
            if (!IsDataLoad) { Load_Data((int)Tables.Projects); }
            MyNavigator_Get_Values(sender, e);
            
        }


        #endregion

        #region Text box Value GET & SET
        private void MyNavigator_Get_Values(object sender, EventArgs e)
        {
            txtID.Text = thisRow["ID"].ToString();
            txtCode.Text = thisRow["Code"].ToString();
            txtTag.Text = thisRow["SCode"].ToString();
            txtTitle.Text = thisRow["Title"].ToString();
            txtLocation.Text = thisRow["Location"].ToString();
            txtCity.Text = thisRow["City"].ToString();
            cboxSupplier.SelectedValue = Conversion.ToInteger(thisRow["Client"].ToString()) ;
            txtCost.Text = thisRow["Cost"].ToString();
            txtNature.Text = thisRow["Nature"].ToString();
            txtRemarks.Text = thisRow["Remarks"].ToString();
        }
      
        private void MyNavigator_Set_Values(object sender, EventArgs e)
        {
            thisRow["ID"] = Conversion.ToLong(txtID.Text);
            thisRow["Code"] = txtCode.Text;
            thisRow["SCode"] = txtTag.Text;
            thisRow["Title"] = txtTitle.Text;
            thisRow["Location"] = txtLocation.Text;
            thisRow["City"] = txtCity.Text;
            thisRow["Client"] = cboxSupplier.SelectedValue;
            thisRow["Cost"] = Conversion.ToInteger(txtCost.Text);
            thisRow["Nature"] = txtNature.Text;
            thisRow["Remarks"] = txtRemarks.Text;
        }

        #endregion

        #region Navigators Buttons

        private void MyNavigator_Before_Save(object sender, EventArgs e)
        {

        }
        private void MyNavigator_After_Save(object sender, EventArgs e)
        {

        }
        private void MyNavigator_After_Delete(object sender, EventArgs e)
        {

        }
        private void MyNavigator_New_Record(object sender, EventArgs e)
        {
            thisRow["ID"] = -1;
            thisRow["Code"] = "";
            thisRow["SCode"] = "";
            thisRow["Title"] = "";
            thisRow["Location"] = "";
            thisRow["City"] = "";
            thisRow["Client"] = 1;
            thisRow["Cost"] =  1;
            thisRow["Nature"] = "";
            thisRow["Remarks"] = "";
            MyNavigator_Set_Values(sender, e);
            txtCode.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private void frmProject_Load(object sender, EventArgs e)
        {

        }

        private void P2_Leave(object sender, EventArgs e)
        {
            thisRow = Grid_Projects.MyDataRow;
            MyNavigator_Get_Values(sender, e);
            
        }
    }                       // Main
}                           // Name space
