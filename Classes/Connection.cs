using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.OleDb;
using System.IO;

namespace Applied_Accounts
{
    public class Connection
    {
        public static SQLiteConnection AppliedConnection()
        {
            SQLiteConnection sqlite_conn;
            string sqlite_text;
            sqlite_text = Properties.Settings.Default.DBFile;
            sqlite_conn = new SQLiteConnection("Data Source=" + Properties.Settings.Default.DBFile);  //+ " Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DataBase Connection is not being established \r" + ex.Message, "ERROR");
            }
            return sqlite_conn;
        }
        
        public static OleDbConnection ExcelConnection(string _ExcelFileName)
        {
#pragma warning disable CS0219 // The variable 'ExcelVersion' is assigned but its value is never used
            string ExcelVersion = "Excel 12.0;HDR=YES;IMEX=1;";
#pragma warning restore CS0219 // The variable 'ExcelVersion' is assigned but its value is never used
            OleDbConnection oledbConn;
            oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _ExcelFileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
            return oledbConn;

        }


    }
}
