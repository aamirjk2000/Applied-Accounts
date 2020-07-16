using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Applied_Accounts.Classes;

namespace Applied_Accounts.Forms
{
    public partial class frmMigration : Form
    {

        private MigrationClass MyMigrationClass;
        private ThisTable _TargetTable;
        private DataRow _TargetRow;
#pragma warning disable CS0414 // The field 'frmMigration.MyExcelFileName' is assigned but its value is never used
        private string MyExcelFileName = "";
#pragma warning restore CS0414 // The field 'frmMigration.MyExcelFileName' is assigned but its value is never used


        #region Initialize

        public frmMigration()
        {
            InitializeComponent();
            //MyRefresh();
        }

        #endregion

        private void MyRefresh()
        {
            MyMigrationClass = new Classes.MigrationClass();

            if(MyMigrationClass.ExcelTables != null)
            { 
                Grid_Applied.DataSource = MyMigrationClass.ExcelTables.Tables["Applied"];
                Grid_Notes.DataSource = MyMigrationClass.ExcelTables.Tables["Notes"];
                Grid_Accounts.DataSource = MyMigrationClass.ExcelTables.Tables["COA"];
                Grid_AccType.DataSource = MyMigrationClass.ExcelTables.Tables["COA_Type"];
                Grid_Suppliers.DataSource = MyMigrationClass.ExcelTables.Tables["Suppliers"];
                Grid_Projects.DataSource = MyMigrationClass.ExcelTables.Tables["Projects"];
                Grid_Units.DataSource = MyMigrationClass.ExcelTables.Tables["Units"];
                Grid_Employees.DataSource = MyMigrationClass.ExcelTables.Tables["Employees"];
                Grid_Stocks.DataSource = MyMigrationClass.ExcelTables.Tables["Stock"];
                Grid_Ledger.DataSource = MyMigrationClass.ExcelTables.Tables["Ledger"];
            }
            else
            {
                MessageBox.Show("Data tables does not load.");
                //Close();
            }



        }

        #region Buttons

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {

            Pages.Visible = false;

            MyExcelFileName = "";
            MyRefresh();

            

            Grid_Applied.Refresh();
            Grid_Notes.Refresh();
            Grid_Accounts.Refresh();
            Grid_AccType.Refresh();
            Grid_Suppliers.Refresh();
            Grid_Projects.Refresh();
            Grid_Units.Refresh();
            Grid_Employees.Refresh();
            Grid_Stocks.Refresh();
            Grid_Ledger.Refresh();

            Pages.Visible = true;
            

        }

        private void btnMigration_Click(object sender, EventArgs e)
        {
            if(MyMigrationClass==null)
            {
                MessageBox.Show("Migration Class is null.", "ERROR");
                return;
            }
            else
            { 

                string TabTitle = Pages.TabPages[Pages.SelectedIndex].Text;


                switch (TabTitle)
                {
                    case "Notes":
                        Migrate_Table((int)Tables.Notes);                            // Migrate Data to Table Notes
                        break;

                    case "COA":
                        Migrate_Table((int)Tables.COA);                            // Migrate Data to Table Notes
                        break;

                    case "COA_Type":
                        Migrate_Table((int)Tables.COA_Type);                            // Migrate Data to Table Notes
                        break;

                    case "Suppliers":
                        Migrate_Table((int)Tables.Suppliers);                            // Migrate Data to Table Notes
                        break;

                    case "Projects":
                        Migrate_Table((int)Tables.Projects);                            // Migrate Data to Table Notes
                        break;

                    case "Units":
                        Migrate_Table((int)Tables.Units);                            // Migrate Data to Table Notes
                        break;

                    case "Stock":
                        Migrate_Table((int)Tables.Stock);                            // Migrate Data to Table Notes
                        break;

                    case "Employees":
                        Migrate_Table((int)Tables.Employees);                            // Migrate Data to Table Notes
                        break;

                    case "Ledger":
                        Migrate_Table((int)Tables.Ledger);                            // Migrate Data to Table Notes
                        break;


                    default:
                        MessageBox.Show("Selection is defined.", "ERROR");
                        break;
                }
            }

        }
        #endregion


        #region Migration Code
        private void Migrate_Table(int _TableID)
        {
            //migrate Data to Tab;enotes.

            btnExit.Enabled = false;
            btnLoad.Enabled = false;
            btnMigration.Enabled = false;

            string _TableName = Enum.GetName(typeof(Tables), _TableID);
            DataTable _SourceTable = MyMigrationClass.ExcelTables.Tables[_TableName];

            if(_SourceTable==null)
            {
                MessageBox.Show("Source Table is null", "ERROR");
                return;
            }

            _TargetTable = new ThisTable(_TableID);
            _TargetRow = _TargetTable.MyDataTable.NewRow();
            BarMigration.Maximum = _SourceTable.Rows.Count;

            if (_SourceTable.Columns.Count != _TargetTable.MyDataTable.Columns.Count)
            {
                MessageBox.Show("Columns are not equal of Source and Target Tables.", "ERROR");
                return;
            }

            
            int i = 0;
            foreach (DataRow _Row in _SourceTable.Rows)
            {

                foreach (DataColumn _Column in _Row.Table.Columns)
                {
                    if(_Column.ColumnName=="Chq_Date")
                    {
                        if (_Row["Chq_Date"].ToString() == "")
                        {
                            _Row["Chq_Date"] = DBNull.Value;
                        }
                        
                    }

                    _TargetRow[_Column.ColumnName] = _Row[_Column.ColumnName];
                }

                i += 1;
                BarMigration.Value = i;
                BarMigration.Refresh();
                lblMessage.Text = string.Concat(i.ToString(), " / ", BarMigration.Maximum);
                lblMessage.Refresh();

                lblMessages.Text =  _TargetTable.Save(_TargetRow, false);

            }

            System.Threading.Thread.Sleep(2000);
            lblMessage.Text = "Done";

            btnExit.Enabled = true;
            btnLoad.Enabled = true;
            btnMigration.Enabled = true;

        }

        #endregion

    }       // END Main Class
}           // 
