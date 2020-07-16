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

        private DataTable MyDataTable;
        private DataTable TableEmployees;
        private bool IsDataLoad = false;

        private DataRow thisRow { get => MyNavigator.TableClass.MyDataRow; set => MyNavigator.TableClass.MyDataRow = value; }
        private void btnExit_Click(object sender, EventArgs e) { Close(); }


        #region Initialize

        public frmEmployees()
        {
            InitializeComponent();
        }

        public void Load_Data(int _DataTableID)
        {
            DataTable _DataTable = AppliedTable.GetDataTable(_DataTableID);
            Grid_Employees.MyDataView = new DataView(_DataTable);
            MyNavigator.InitializeClass(_DataTable);

            MyDataTable = _DataTable;
            TableEmployees = AppliedTable.GetDataTable((int)Tables.Employees);
            IsDataLoad = true;
        }

        #endregion


        #region LOAD

        private void Grid_Units_Load(object sender, EventArgs e)
        {
            if (!IsDataLoad) { Load_Data((int)Tables.Employees); }
            Grid_Employees.MyDataView = new DataView(MyDataTable);

            if (!IsDataLoad) { Load_Data((int)Tables.Projects); }   // Load Table if not loaded.
            Grid_Employees.Load_Data(MyNavigator.TableClass.MyDataTable);
            string[] ColumnsVisiable = { "Code", "SCode", "Title", "Designation", "Grade", "City" };
            string[] ColumnsName = { "Code", "Tag", "Title", "Designation", "Grade", "City" };
            int[] ColumnsFormat = { (int)TextFormat.Codes, 0, 0, 0, (int)TextFormat.Boolean, 0 };
            int[] ColumnWidth = { 60, 75, 260, 80, 50, 50};

            Grid_Employees.ColumnsName = ColumnsName;
            Grid_Employees.ColumnsVisiable = ColumnsVisiable;
            Grid_Employees.ColumnsFormat = ColumnsFormat;
            Grid_Employees.ColumnsWidth = ColumnWidth;
            Grid_Employees.Set_Columns();
        }

        private void MyNavigator_Load(object sender, EventArgs e)
        {
            if (!IsDataLoad) { Load_Data((int)Tables.Employees); }
            MyNavigator.InitializeClass((int)Tables.Employees);              // Set Navigator Class 
            MyNavigator_Get_Values(sender, e);

        }

        #endregion

        #region Text box Value GET & SET

        private void MyNavigator_Get_Values(object sender, EventArgs e)
        {

            if(thisRow==null) { thisRow = MyDataTable.NewRow(); }

            txtID.Text = thisRow["ID"].ToString();
            txtCode.Text = thisRow["Code"].ToString();
            txtTag.Text = thisRow["SCode"].ToString();
            txtTitle.Text = thisRow["Title"].ToString();
            txtDesignation.Text = thisRow["Designation"].ToString() ;
            txtGrade.Text = thisRow["Grade"].ToString();
            txtDepartment.Text = thisRow["Department"].ToString();
            txtAddress.Text = thisRow["Address"].ToString();
            txtCity.Text = thisRow["City"].ToString();
            txtCNIC.Text = thisRow["CNIC"].ToString();
            txtRemarks.Text = thisRow["Remarks"].ToString();
            chkActive.Checked = Conversion.ToBoolean(thisRow["Active"].ToString());

        }

        private void MyNavigator_Set_Values(object sender, EventArgs e)
        {
            thisRow["ID"] = Conversion.ToLong(txtID.Text);
            thisRow["Code"] = txtCode.Text;
            thisRow["SCode"] = txtTag.Text;
            thisRow["Title"] = txtTitle.Text;
            thisRow["Designation"] = txtDesignation.Text;
            thisRow["Grade"] = txtGrade.Text;
            thisRow["Department"] = txtDepartment.Text;
            thisRow["Address"] = txtAddress.Text;
            thisRow["City"] = txtCity.Text;
            thisRow["CNIC"] = txtCNIC.Text;
            thisRow["Remarks"] = txtRemarks.Text;
            thisRow["Active"] = Conversion.ToInteger(chkActive.Checked);
            
        }

        #endregion


        #region Navigators Buttons


        private void MyNavigator_After_Delete(object sender, EventArgs e)
        {

        }

        private void MyNavigator_After_Save(object sender, EventArgs e)
        {
            Grid_Employees.MyDataView = MyNavigator.TableClass.MyDataView;
        }

        private void MyNavigator_Get_Values_1(object sender, EventArgs e)
        {

        }

        private void MyNavigator_New_Record(object sender, EventArgs e)
        {

            thisRow["ID"] = -1;
            thisRow["Code"] = "";
            thisRow["SCode"] = "";
            thisRow["Title"] = "";
            thisRow["Designation"] = "";
            thisRow["Grade"] = "";
            thisRow["Department"] = "";
            thisRow["Address"] = "";
            thisRow["City"] = "";
            thisRow["CNIC"] = "";
            thisRow["Remarks"] = "";
            thisRow["Active"] = 1;
            MyNavigator_Get_Values(sender, e);
            txtCode.Focus();


            MyNavigator.btnSave.Enabled = true;
            MyNavigator.btnNew.Enabled = false;



        }
             


        #endregion

        


        
    }           // END Main Class
}               // END Namespace
