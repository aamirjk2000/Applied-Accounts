using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applied_Accounts
{
    public partial class frmAccNotes : Form
    {
        DataTable Table_Notes;
#pragma warning disable CS0169 // The field 'frmAccNotes.View_Notes' is never used
        DataView View_Notes;
#pragma warning restore CS0169 // The field 'frmAccNotes.View_Notes' is never used
        Boolean Has_Error { get; set; }
        private DataRow thisDataRow { get => MyNavigator.TableClass.MyDataRow; set { MyNavigator.TableClass.MyDataRow = value; } }
        private DataView thisDataView { get => MyNavigator.TableClass.MyDataView; }

        public frmAccNotes()
        {
            InitializeComponent();

        }
        //private void frmAccNotes_Load(object sender, EventArgs e)
        //{
        //    MyRefresh();
        //}
        //private void MyRefresh()
        //{
        //    Table_Load();

        //    if (MyNavigator.TableClass != null)
        //    {
                
        //    }
        //}
        private void Table_Load()
        {
            Table_Notes = AppliedTable.GetDataTable((int)Tables.Notes);
            MyNavigator.InitializeClass(Table_Notes);
            DataGrid_Notes.Load_Data(MyNavigator.TableClass.MyDataTable);

        }
        private void Defaults()
        {
            if (txtID.Text.Length == 0) { txtID.Text = "0"; }
        }



        // ==================================================================== Navigator's Events
        #region Navigator's region

        private void Navigator_Get_Values(object sender, EventArgs e)
        {
            txtID.Text = thisDataRow["ID"].ToString();
            txtCode.Text = thisDataRow["Code"].ToString();
            txtSCode.Text = thisDataRow["SCode"].ToString();
            txtTitle.Text = thisDataRow["Title"].ToString();
            txtType.Text = thisDataRow["COA_Type"].ToString();

            TitleType.Text = AppliedTable.GetTitle(txtType.Text, (int)Tables.COA_Type);

        }

        private void Navigator_Set_Vakues(object sender, EventArgs e)
        {
            Defaults();
            thisDataRow["ID"] = Convert.ToInt32(txtID.Text).ToString();
            thisDataRow["Code"] = txtCode.Text;                 // User Control Text
            thisDataRow["SCode"] = txtSCode.Text;
            thisDataRow["Title"] = txtTitle.Text;
            thisDataRow["COA_Type"] = txtType.Text;
        }
       
        private void Navigator_After_Delete(object sender, EventArgs e)
        {
            Table_Load();
        }

        private void Navigator_After_Save(object sender, EventArgs e)
        {
            Table_Load();
            ////Navigator_Get_Values(sender, e);
            //MyNavigator.InitializeClass((int)Tables.Notes);
            //DataGrid_Notes.Load_Data(MyNavigator.TableClass.MyDataTable);
            Navigator_Get_Values(sender, e);
        }

        private void Navigator_Before_Save(object sender, EventArgs e)
        {

        }

        private void Navigator_New_Record(object sender, EventArgs e)
        {
            thisDataRow["ID"] = -1;
            thisDataRow["SCode"] = "";
            thisDataRow["Code"] = "";
            thisDataRow["Title"] = "";
            thisDataRow["COA_Type"] = 0;

            MessageBox.Show("New Record.");
            Defaults();
            txtCode.Focus();
        }
        #endregion
        //===================================================================================

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            thisDataRow = AppliedTable.SearchID((TextBox)sender, thisDataView.Table);
            Navigator_Get_Values(sender, e);
        }

        private void txtType_Validating(object sender, CancelEventArgs e)
        {
            Classes.Validation thisValidation = new Classes.Validation((TextBox)sender, (int)Tables.COA_Type);
            TitleType.Text = thisValidation.TextTitle;
            e.Cancel = thisValidation.TextValidation();
            //lblMessage.Text = thisValidation.Message;

        }

        private void DataGrid_Notes_Load(object sender, EventArgs e)
        {
            AppliedDataGrid _AppliedGrid = (AppliedDataGrid)sender;

            string[] ColumnsVisiable = { "Code", "SCode", "Title", "COA_Type" };
            string[] ColumnsName = { "Code", "Tag", "Title", "Acc Type", };
            int[] ColumnsFormat = {(int)TextFormat.Codes ,0 , 0, (int)TextFormat.Codes};
            int[] ColumnWidth = { 60, 75, 260, 50 };

            _AppliedGrid.ColumnsName = ColumnsName;
            _AppliedGrid.ColumnsVisiable = ColumnsVisiable;
            _AppliedGrid.ColumnsFormat = ColumnsFormat;
            _AppliedGrid.ColumnsWidth = ColumnWidth;

            _AppliedGrid.Load_Data(MyNavigator.TableClass.MyDataTable);
            _AppliedGrid.Set_Columns();


        }

        private void DataGrid_Notes_Leave(object sender, EventArgs e)
        {
            DataGrid_Notes.Load_Data(MyNavigator.TableClass.MyDataTable);

            thisDataRow = DataGrid_Notes.MyDataRow;
            Navigator_Set_Vakues(null,null);
        }

        private void MyNavigator_Load(object sender, EventArgs e)
        {
            MyNavigator.TableClass = new ThisTable((int)Tables.Notes);   // Set Data Environment
            MyNavigator.InitializeClass((int)Tables.Notes);              // Set Navigator Class 
            Navigator_Get_Values(null, null);                            // Show Nagigator's Row to Text Box.
        }
    }
}
