using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Applied_Accounts.Classes;
using Connection_Class;

namespace Applied_Accounts
{
    public class AppliedTable
    {

        #region  Get DataTable

        public static DataTable GetDataTable(int TableID)
        {
            if(TableID>0)               // ID is zero
            { 
                DataTable _DataTable = new DataTable();
                
                string _TableName = Conversion.GetTableName(TableID);
                string _Text = "SELECT * FROM " + _TableName;
                

                SQLiteCommand _SQLCommand = new SQLiteCommand(_Text, Connection.AppliedConnection());
                SQLiteDataAdapter _Adapter = new SQLiteDataAdapter(_SQLCommand);
                DataSet _DataSet = new DataSet();

                bool try_OK = true;

                try
                {
                    _Adapter.Fill(_DataSet, _TableName);
                    _DataTable = _DataSet.Tables[_TableName];
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, e.Source);
                    try_OK = false;
                    //throw;
                }
                finally
                {
                    if(try_OK==false)
                    {
                        frmDBSetting ThisForm = new frmDBSetting();
                        ThisForm.Show();
                    }
                }


                return _DataTable;
            }
            else                                            // Error found.
            {
                MessageBox.Show("Data Table not found", "ERROR");
                return new DataTable();
            }
        }
        public static DataTable GetDataTable(object TableID)
        {
            int _TableID = (int)TableID;

            if (_TableID > 0)               // ID is zero
            {
                DataTable _DataTable; //= new DataTable();
                string _TableName = Conversion.GetTableName(_TableID);
                string _Text = "Select * from " + _TableName;
                SQLiteCommand _SQLCommand = new SQLiteCommand(_Text, Connection.AppliedConnection());
                SQLiteDataAdapter _Adapter = new SQLiteDataAdapter(_SQLCommand);
                DataSet _DataSet = new DataSet();
                _Adapter.Fill(_DataSet, _TableName);
                _DataTable = _DataSet.Tables[_TableName];
                return _DataTable;
            }
            else                                            // Error found.
            {
                MessageBox.Show("Data Table not found", "ERROR");
                return new DataTable();
            }
        }
        public static DataTable GetDataTable(object TableID, int ID)
        {
            int _TableID = (int)TableID;


            if (_TableID > 0)               // ID is zero
            {
                DataTable _DataTable;  // = new DataTable();
                string _TableName = Conversion.GetTableName(_TableID);
                string _Text = "Select * from " + _TableName + " WHERE ID=" + ID.ToString();
                SQLiteCommand _SQLCommand = new SQLiteCommand(_Text, Connection.AppliedConnection());
                SQLiteDataAdapter _Adapter = new SQLiteDataAdapter(_SQLCommand);
                DataSet _DataSet = new DataSet();
                _Adapter.Fill(_DataSet, _TableName);
                _DataTable = _DataSet.Tables[_TableName];

                return _DataTable;
            }
            else                                            // Error found.
            {
                MessageBox.Show("Data Table not found", "ERROR");
                return new DataTable();
            }
        }
        public static DataTable GetDataTable(object TableID, string Filter)
        {
            int _TableID = (int)TableID;


            if (_TableID > 0)               // ID is zero
            {
                DataTable _DataTable;  // = new DataTable();
                string _TableName = Conversion.GetTableName(_TableID);
                string _Text = "Select * from " + _TableName + " WHERE " + Filter.ToString();
                SQLiteCommand _SQLCommand = new SQLiteCommand(_Text, Connection.AppliedConnection());
                SQLiteDataAdapter _Adapter = new SQLiteDataAdapter(_SQLCommand);
                DataSet _DataSet = new DataSet();

                _Adapter.Fill(_DataSet, _TableName);
                _DataTable = _DataSet.Tables[_TableName];

                return _DataTable;
            }
            else                                            // Error found.
            {
                MessageBox.Show("Data Table not found", "ERROR");
                return new DataTable();
            }
        }

        public static DataTable GetDataTable(string CommandText)
        {
            if (CommandText.Length > 0)               // ID is zero
            {
                string _TableName = "TEMP_Table";
                DataTable _DataTable; //= new DataTable();
                SQLiteCommand _SQLCommand = new SQLiteCommand(CommandText, Connection.AppliedConnection());
                SQLiteDataAdapter _Adapter = new SQLiteDataAdapter(_SQLCommand);
                DataSet _DataSet = new DataSet();
                _Adapter.Fill(_DataSet, _TableName);
                _DataTable = _DataSet.Tables[_TableName];

                return _DataTable;
            }
            else                                            // Error found.
            {
                MessageBox.Show("Command Text is nothing", "ERROR");
                return new DataTable();
            }
        }

        #endregion

        #region Get Title

        public static string GetTitle(string _Code, int _DataTableID)
        {
            string _Title = "";
            //DataTable _DataTable = ;
            //DataView _DataView = new DataView(_DataTable);
            DataView _DataView = GetDataTable(_DataTableID).AsDataView();
            _DataView.RowFilter = string.Concat("Code='", _Code, "'");
            if (_DataView.Count == 1)
            {
                _Title = (_DataView.ToTable().Rows[0])["Title"].ToString();

            }
            return _Title;
        }
        public static string GetTitle(int _ID, int _DataTableID)
        {
            string _Title = "";
            DataView _DataView = GetDataTable(_DataTableID).AsDataView();
            _DataView.RowFilter = string.Concat("ID=", _ID);
            if (_DataView.Count == 1)
            {
                _Title = (_DataView.ToTable().Rows[0])["Title"].ToString();

            }
            return _Title;
        }
        public static string GetTitle(int _ID, DataTable _DataTable)
        {
            string _Title = "";
            DataView _DataView = _DataTable.AsDataView();
            _DataView.RowFilter = string.Concat("ID=", _ID);
            if (_DataView.Count == 1)
            {
                _Title = ((DataRow)_DataView.ToTable().Rows[0])["Title"].ToString();

            }
            return _Title;
        }

        #endregion  

        public static DataSet GetDataSet(int TableID)
        {
            if (TableID > 0)               // ID is zero
            {
                string _TableName = Conversion.GetTableName(TableID);
                string _Text = "Select * from " + _TableName;

                SQLiteCommand _SQLCommand = new SQLiteCommand(_Text, Connection.AppliedConnection());
                SQLiteDataAdapter _Adapter = new SQLiteDataAdapter(_SQLCommand);
                DataSet _DataSet = new DataSet();
                _Adapter.Fill(_DataSet, _TableName);
                return _DataSet;
            }
            else                                            // Error found.
            {
                MessageBox.Show("Data Set not found", "ERROR");
                return new DataSet();
            }
        }
        public static DataTable GetDBView(int TableID, string _Filter)
        {
            string _TableName = Conversion.GetTableName(TableID);
            DataTable _DataTable; //= new DataTable();
            string _Text = "Select * from [" + _TableName + "] WHERE " + _Filter;
            SQLiteCommand _SQLCommand = new SQLiteCommand(_Text, Connection.AppliedConnection());
            SQLiteDataAdapter _Adapter = new SQLiteDataAdapter(_SQLCommand);
            DataSet _DataSet = new DataSet();
            _Adapter.Fill(_DataSet, _TableName);
            _DataTable = _DataSet.Tables[_TableName];
            return _DataTable;
        }
        public static DataRow SearchID(TextBox _TextBox, DataTable _DataTable)
        {
            DataRow _DataRow = _DataTable.NewRow();
            DataView _DataView = new DataView(_DataTable);
            string _Code = _TextBox.Text.Trim();
            _DataView.RowFilter = string.Concat("Code='", _Code, "'");
            if(_DataView.Count==1)
            {
                _DataRow = _DataView.ToTable().Rows[0];
            }
            else
            {
                _DataRow["ID"] = -1;
                _DataRow["Code"] = _Code;
                _DataRow["Title"] = "Add a new record.";

            }
            return _DataRow;
        }
    }                             // Main


    public enum Tables
    {
        COA = 1,
        Notes = 2,
        COA_Type = 3,
        Suppliers = 4,
        Projects = 5,
        Units = 6,
        Employees = 7,
        Stock = 8,
        Applied = 9,
        Ledger = 10,
        Users = 11,

        View_Voucher = 101,
        View_VouNo = 102,
        View_General_Ledger = 103,
        View_Supplier_Ledger = 104,
        View_Project_Ledger = 105
           

    };
        
}                               // Namespace
