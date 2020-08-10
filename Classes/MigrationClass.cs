using System.Data;
using System.Data.OleDb;
using System.Windows;
using Microsoft.Win32;

namespace Applied_Accounts.Classes
{
    class MigrationClass
    {
        public string ExcelFileName { get; set; }
        public bool ExcelfileExist { get; set; }
        public DataSet ExcelTables { get; set; }

        public MigrationClass()
        {
            OpenFileBox();
        }


        public void OpenFileBox()
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            FileDialog.Title = "SELECT EXCEL FILE FOR DATA MIGRATION";
            FileDialog.InitialDirectory = "";
            FileDialog.RestoreDirectory = true;
            FileDialog.ShowDialog();

            ExcelFileName = FileDialog.FileName;
            ExcelfileExist = Applied.IsFileExist(ExcelFileName);

            if (ExcelfileExist)
            {
                GetExcelFileData();
            }

        }


        private void GetExcelFileData()
        {
            DataSet _DataSet = GetExcelFileData(ExcelFileName);

            if(_DataSet!=null)
            {
                ExcelTables = _DataSet;
                
            }
        }

        private DataSet GetExcelFileData(string _ExcelFileName)
        {
            //MessageBox.Show(MigrationClass.ExcelFileName); 
            OleDbConnection Excel_Connection = Connection.ExcelConnection(_ExcelFileName);

            OleDbCommand Excel_Command = new OleDbCommand("", Excel_Connection);

            Excel_Connection.Open();

            OleDbDataAdapter _Adapter = new OleDbDataAdapter();
            DataSet _Dataset = new DataSet();
            DataTable dtExcelSchema;

            dtExcelSchema = Excel_Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            string Table = "TABLE";
            int i = 0;

            foreach (DataRow _Row in dtExcelSchema.Rows)
            {
                i += 1;
                Excel_Command.CommandText = "SELECT * From [" + _Row["TABLE_NAME"] + "]";
                _Adapter.SelectCommand = Excel_Command;

                Table = _Row["TABLE_NAME"].ToString();
                Table = Table.Replace("$", "");

                _Adapter.Fill(_Dataset, Table);
            }

            Excel_Connection.Close();

            return _Dataset;

        }

    }           // END Main Class
}               // END NameSpace
