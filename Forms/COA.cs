using Applied_Accounts.Classes;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;



namespace Applied_Accounts
{
    public partial class frmCOA : Form
    {
        DataTable Table_COA;
        DataView View_COA;
        
        Boolean Has_Error { get; set; }
        private DataRow thisDataRow { get => MyNavigator.TableClass.MyDataRow; }
        private DataView thisDataView { get => MyNavigator.TableClass.MyDataView; }

        
        public frmCOA()
        {
            InitializeComponent();
        }


        #region Load 

        private void COA_Load(object sender, EventArgs e)
        {
            MyRefresh();
        }

        private void Table_Load()
        {
            Table_COA = AppliedTable.GetDataTable((int)Tables.COA);
            View_COA = new DataView(Table_COA);
            MyNavigator.TableClass = new ThisTable(Table_COA);              // Set Table for Navigator 
        }

        #endregion

        #region DataGrid    
        private void DataGridRefresh()
        {
            
            string[] ColumnsVisiable = { "Code", "SCode", "Title", "IsCashBook", "IsBankBook", "Notes", "OBal" };
            string[] ColumnsName = { "Code", "Tag", "Title", "Cash", "Bank", "Notes", "Opening Balance" };
            int[] ColumnsFormat = { (int)TextFormat.Codes,0,0,
                                    (int)TextFormat.Boolean,
                                    (int)TextFormat.Boolean,
                                    (int)TextFormat.Numbers,
                                    (int)TextFormat.Currency};
            int[] ColumnWidth = { 60, 75, 260, 50, 50, 50, 80 };

            DataGrid_COA.ColumnsName = ColumnsName;
            DataGrid_COA.ColumnsWidth = ColumnWidth;
            DataGrid_COA.ColumnsVisiable = ColumnsVisiable;
            DataGrid_COA.ColumnsFormat = ColumnsFormat;
            DataGrid_COA._DataGrid.DataSource = View_COA;
            DataGrid_COA.Set_Columns();

            DataGrid_COA._DataGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGrid_COA._DataGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGrid_COA._DataGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGrid_COA._DataGrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGrid_COA._DataGrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGrid_COA._DataGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGrid_COA._DataGrid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        #endregion
        
        private void MyRefresh()
        {
            Table_Load();

            if (MyNavigator.TableClass != null)
            {
                DataGridRefresh();
                MyNavigator_Get_Values(null, null);
            }
        }

        



        private void DataRow_Validate()
        {
            // Validate the Datarow before save in Databas.Data Table

            Has_Error = false;
            string[] _Messages = new string[10];
            _Messages[0] = "Error | Record Id is not define properly.";
            _Messages[1] = "Error | Account note is not degine properly.";
            _Messages[2] = "Error | Chart of Account Code is not define properly.";
            _Messages[3] = "Error | Chart of Account Tag is not define properly.";
            _Messages[4] = "Error | Chart of Account's Title is not define properly.";
            
            _Messages[5] = "Error | ";
            _Messages[6] = "Error | ";

            lblMessage.ForeColor = System.Drawing.Color.Red;

            if (Convert.ToInt32(thisDataRow["ID"]) == 0) { Has_Error = true; txtCode.Focus(); lblMessage.Text = _Messages[0]; }
            if (Convert.ToInt32(thisDataRow["Notes"]) == 0) { Has_Error = true; txtNote.Focus(); lblMessage.Text = _Messages[1]; }
            if (thisDataRow["Code"].ToString().Length == 0) { Has_Error = true; txtCode.Focus(); lblMessage.Text = _Messages[2]; }
            if (thisDataRow["SCode"].ToString().Length == 0) { Has_Error = true; txtCode.Focus(); lblMessage.Text = _Messages[3]; }
            if (thisDataRow["Title"].ToString().Length == 0) { Has_Error = true; txtTitle.Focus(); lblMessage.Text = _Messages[4]; }

        }

        private void Defaults()
        {

            if (txtID.Text.Length == 0) { txtID.Text = "0"; }
            if (txtNote.Text.Length == 0) { txtNote.Text = "0"; }
            if (txtOBal.Text.Length == 0) { txtOBal.Text = "0"; }
            
        }


        #region Data Get and Set


        //======================================================================== Procedures of Navigator
        private void MyNavigator_Get_Values(object sender, EventArgs e)
        {
            txtID.Text = thisDataRow["ID"].ToString();
            txtCode.Text = thisDataRow["Code"].ToString();
            txtSCode.Text = thisDataRow["SCode"].ToString();
            txtTitle.Text = thisDataRow["Title"].ToString();
            txtNote.Text = thisDataRow["Notes"].ToString();
            txtOBal.Text = thisDataRow["OBal"].ToString();

            TitleNotes.Text = AppliedTable.GetTitle(txtNote.Text, (int)Tables.Notes);

            decimal IsBank = (decimal)thisDataRow["IsBankBook"];
            decimal IsCash = (decimal)thisDataRow["IsCashBook"];
            chkBank.Checked = Conversion.ToBoolean(IsBank.ToString());
            chkCash.Checked = Conversion.ToBoolean(IsCash.ToString());

        }
        private void MyNavigator_Set_Values(object sender, EventArgs e)
        {
            Defaults();
            thisDataRow["ID"] =  Conversion.ToInteger(txtID.Text);
            thisDataRow["Code"] = txtCode.Text;                 // User Control Text
            thisDataRow["SCode"] = txtSCode.Text;
            thisDataRow["Title"] = txtTitle.Text;
            thisDataRow["Notes"] = txtNote.Text;
            thisDataRow["IsBankBook"] = Conversion.ToBoolean(chkBank.Checked);
            thisDataRow["IsCashBook"] = Conversion.ToBoolean(chkCash.Checked);
            thisDataRow["OBal"] = Conversion.ToInteger(txtOBal.Text);

        }

        #endregion

        #region  Navigation Buttons

        private void MyNavigator_New_Record(object sender, EventArgs e)
        {
            thisDataRow["ID"] = -1;
            thisDataRow["SCode"] = "";
            thisDataRow["Code"] = "";
            thisDataRow["Title"] = "";
            thisDataRow["IsCashBook"] = 0;
            thisDataRow["IsBankBook"] = 0;
            thisDataRow["Notes"] = 0;
            thisDataRow["OBal"] = 0;

            MessageBox.Show("New Record.");
            Defaults();
            txtCode.Focus();
        }
        private void MyNavigator_Before_Save(object sender, EventArgs e)
        {
        }
        private void MyNavigator_After_Save(object sender, EventArgs e)
        {
            MyNavigator_Get_Values(sender, e);
            int _PKey = Convert.ToInt32(MyNavigator.TableClass.MyPrimaryKeyValue);
            MyRefresh();
            MyNavigator.TableClass.MyDataRow = MyNavigator.TableClass.GetRow(_PKey);
            MyNavigator_Get_Values(sender, e);
        }
        private void MyNavigator_After_Delete(object sender, EventArgs e)
        {
            Table_Load();
        }
        private void MyCode_Get_Row(object sender, EventArgs e)
        {
            txtCode.MyRow = thisDataRow;
            txtCode.MyDataView = thisDataView;
        }
        private void txtNote_Validating(object sender, CancelEventArgs e)
        {
            Classes.Validation thisValidation = new Classes.Validation((TextBox)sender, (int)Tables.Notes);
            e.Cancel = thisValidation.TextValidation();
            lblMessage.Text = thisValidation.Message;
        }
        private void DataGrid_COA_Load(object sender, EventArgs e)
        {
            DataGrid_COA.Load_Data(MyNavigator.TableClass.MyDataTable);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            DataRow_Validate();                                                     // Validate the Data Row.

            if (!Has_Error)                                                         // If Data Row Validated true then save.
            {
                string _Message = MyNavigator.TableClass.Save();                   // Save DataRow to Database 
                MessageBox.Show(_Message);
                lblMessage.Text = _Message;
                lblMessage.ForeColor = System.Drawing.Color.Black;
            }
        }

        #endregion

        //=======================================
    }                   // Main Codes
}                       // NameSpave
