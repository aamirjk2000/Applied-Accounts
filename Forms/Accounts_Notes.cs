using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Applied_Accounts.Classes;

namespace Applied_Accounts
{
    public partial class frmAccNotes : Form
    {
        Boolean Has_Error { get; set; }
        private DataRow thisDataRow { get => MyNavigator.TableClass.MyDataRow; }
        private DataView thisDataView { get => MyNavigator.TableClass.MyDataView; }
        private ThisTable thisTableClas { get => MyNavigator.TableClass; }
        private DataTable Table_Notes { get => MyNavigator.TableClass.MyDataTable; }
        private DataView View_Notes { get => MyNavigator.TableClass.MyDataView; }


        public frmAccNotes()
        {
            InitializeComponent();
            MyNavigator.TableClass = new ThisTable(Tables.Notes);
            MyNavigator.InitializeClass(Table_Notes);
        }
       
        private void Table_Load()
        {
            //Table_Notes = AppliedTable.GetDataTable((int)Tables.Notes);
            //MyNavigator.InitializeClass(Table_Notes);
            //DataGrid_Notes.Load_Data(MyNavigator.TableClass.MyDataTable);

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
            MyNavigator.TableClass.Update(MyNavigator.MyTableID);
            //Table_Load();
        }

        private void Navigator_After_Save(object sender, EventArgs e)
        {

            MyNavigator.TableClass.Update(MyNavigator.MyTableID);
            //Table_Load();
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
            

            //thisDataRow = AppliedTable.SearchID((TextBox)sender, thisDataView.Table);
            Navigator_Get_Values(sender, e);
        }

        private void txtType_Validating(object sender, CancelEventArgs e)
        {
            Classes.Validation thisValidation = new Classes.Validation((TextBox)sender, (int)Tables.COA_Type);
            TitleType.Text = thisValidation.TextTitle;
            e.Cancel = thisValidation.TextValidation();
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
            MyNavigator.TableClass.MyDataRow = DataGrid_Notes.MyDataRow;
            Navigator_Get_Values(sender, e);
        }

        private void MyNavigator_Load(object sender, EventArgs e)
        {
            //MyNavigator.TableClass = new ThisTable((int)Tables.Notes);   // Set Data Environment
            //MyNavigator.InitializeClass((int)Tables.Notes);              // Set Navigator Class 
            //Navigator_Get_Values(null, null);                            // Show Nagigator's Row to Text Box.
        }
    }
}
