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

        private DataRow thisRow { get => MyNavigator.TableClass.MyDataRow; set => MyNavigator.TableClass.MyDataRow= value; }
        private bool IsDataLoad = false;

        #region initialize

        public frmSuppliers()
        {
            InitializeComponent();
        }

        public frmSuppliers(int _DataTableID)
        {
            InitializeComponent();
            Load_Data(_DataTableID);
        }

        #endregion

        #region Load


        private void Load_Data(int _TableID)
        {
            DataTable _DataTable = AppliedTable.GetDataTable(_TableID);
            Grid_Supplier.MyDataView = new DataView(_DataTable);
            MyNavigator.InitializeClass(_DataTable);
            IsDataLoad = true;                                      // prevent again loading data.
        }


        private void Grid_Supplier_Load(object sender, EventArgs e)
        {
            if(!IsDataLoad) { Load_Data((int)Tables.Suppliers); }   // Load Table if not loaded.
            Grid_Supplier.Load_Data(MyNavigator.TableClass.MyDataTable);
            string[] ColumnsVisiable = { "Code", "SCode", "Title", "Contact", "Active", "City","Email" };
            string[] ColumnsName = { "Code", "Tag", "Title", "Contact", "Active", "City", "Email" };
            int[] ColumnsFormat = { (int)TextFormat.Codes, 0, 0, 0, (int)TextFormat.Boolean, 0,0 };
            int[] ColumnWidth = { 60, 75, 260, 80, 50, 50,150 };

            Grid_Supplier.ColumnsName = ColumnsName;
            Grid_Supplier.ColumnsVisiable = ColumnsVisiable;
            Grid_Supplier.ColumnsFormat = ColumnsFormat;
            Grid_Supplier.ColumnsWidth = ColumnWidth;
            Grid_Supplier.Set_Columns();
        }


        private void MyNavigator_Load(object sender, EventArgs e)
        {
            if (!IsDataLoad) { Load_Data((int)Tables.Suppliers); }  // Load Table if not loaded.
            MyNavigator_Get_Values(sender, e);
        }
        #endregion

        #region Navigators buttons

        private void MyNavigator_After_Delete(object sender, EventArgs e) {}
        private void MyNavigator_After_Save(object sender, EventArgs e) {}
        private void MyNavigator_Before_Save(object sender, EventArgs e) {}
        private void MyNavigator_New_Record(object sender, EventArgs e) {}
        private void btnExit_Click(object sender, EventArgs e) { Close(); }
        #endregion

        #region  Text Box Values Get and Set

        private void MyNavigator_Set_Values(object sender, EventArgs e)
        {
            thisRow["ID"] = Conversion.ToInteger(txtID.Text);
            thisRow["Code"] = txtCode.Text.ToString();
            thisRow["SCode"] = txtTag.Text.ToString();
            thisRow["title"] = txtTitle.Text.ToString();
            thisRow["BusinessTitle"] = txtBusiness.Text.ToString();
            thisRow["Active"] = AppliedClass.ConvertDigit(chkActive.Checked);
        }

        private void MyNavigator_Get_Values(object sender, EventArgs e)
        {
            txtID.Text = thisRow["ID"].ToString();
            txtCode.Text = thisRow["Code"].ToString();
            txtTag.Text = thisRow["Scode"].ToString();
            txtTitle.Text = thisRow["Title"].ToString();
            txtBusiness.Text = thisRow["BusinessTitle"].ToString();
            chkActive.Checked = AppliedClass.Convertbool(thisRow["ID"].ToString());
        }



        #endregion

    
    }       // END Main Class
}           // END Namespace
