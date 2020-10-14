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
                string _Text = "SELECT * FROM " + _TableName;
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
            return GetDataTable(CommandText, "MyTable");
        }
        public static DataTable GetDataTable(string CommandText, string _TableName)
        {
            if (CommandText.Length > 0)               // ID is zero
            {
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
        public static DataTable GetDataTable(SQLiteCommand _SQLCommand)
        {

            DataTable _DataTable = new DataTable();

            if (_SQLCommand == null) { return _DataTable; }     // Return empty Table when command is null;
            if(_SQLCommand.CommandText.Length>0)                // Get Data in Table when Command Text is present
            {
                SQLiteDataAdapter _Adapter = new SQLiteDataAdapter(_SQLCommand);
                DataSet _DataSet = new DataSet();
                _Adapter.Fill(_DataSet, "MyTable");
                _DataTable = _DataSet.Tables["MyTable"];
            }


            return _DataTable;

        }
        public static DataTable GetComboData(object TableID)                       // Get Table for Combo box object.
        {
            DataTable _DataTable = new DataTable();
            string _TableName = Conversion.GetTableName((int)TableID);
            string _Text = "SELECT ID,Title,Code,SCode FROM " + _TableName + " WHERE Active ORDER BY Title ";
            _DataTable =  GetDataTable(_Text, _TableName);
            return _DataTable;
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
        public static DataTable GetTable_TB_period(DateTime _From, DateTime _To)
        {
            DataTable _DataTable = GetDataTable(Tables.View_TB_Period);
            DataView _DataView = _DataTable.AsDataView();
            DataTable _Ledger = GetDataTable(Tables.Ledger);
            DataTable _COA = GetDataTable(Tables.COA);
            DataRow _AddRow; 
            //decimal _DR, _CR, _Balance;
            int _Index;

            if (_Ledger.Rows.Count == 0) { return new DataTable(); }   // return empty if ledger is empty.

            _DataTable.Clear();
            
            foreach(DataRow _Row in _Ledger.Rows)
            {
                _DataView.RowFilter = string.Concat("[COA]=", (long)_Row["COA"]);
                if(_DataView.Count==0)
                {
                    _AddRow = _DataTable.NewRow();
                    _AddRow["COA"] = _Row["COA"];
                    _AddRow["Code"] = "";
                    _AddRow["Title"] = GetTitle(Conversion.ToInteger(_Row["COA"]),_COA);

                    if ((DateTime)_Row["Vou_Date"] < _From)
                    {
                        _AddRow["OBAL"] = (decimal)_Row["DR"] - (decimal)_Row["CR"];
                        _AddRow["Debit"] = 0;
                        _AddRow["Credit"] = 0;
                    }
                    if ((DateTime)_Row["Vou_Date"] >= _From && (DateTime)_Row["Vou_Date"]<= _To)
                    {
                        _AddRow["OBAL"] = 0;
                        _AddRow["Debit"] = (decimal)_Row["DR"];
                        _AddRow["Credit"] = (decimal)_Row["CR"];
                    }

                    _AddRow["BALANCE"] = Conversion.ToMoney(_AddRow["OBAL"])
                                        + Conversion.ToMoney(_AddRow["Debit"]) 
                                        - Conversion.ToMoney(_AddRow["Credit"]);

                    _DataTable.Rows.Add(_AddRow);
                    continue;
                }

                if(_DataView.Count>0)
                {
                    _Index = _DataTable.Rows.IndexOf(_DataView[0].Row);
                    //_DR = Conversion.ToMoney(_DataView[0].Row["Debit"]);
                    //_CR = Conversion.ToMoney(_DataView[0].Row["Credit"]);
                    //_Balance =  Conversion.ToMoney(_DataView[0].Row["Balance"]);

                    _AddRow = _DataTable.NewRow();

                    if ((DateTime)_Row["Vou_Date"] < _From)
                    {
                        _DataTable.Rows[_Index]["OBAL"] =+ (Conversion.ToMoney(_Row["DR"])
                                                         -  Conversion.ToMoney(_Row["CR"]));
                    }
                    if ((DateTime)_Row["Vou_Date"] >= _From && 
                        (DateTime)_Row["Vou_Date"] <= _To)
                    {


                        _DataTable.Rows[_Index]["Debit"] =+Conversion.ToMoney(_Row["DR"]);
                        _DataTable.Rows[_Index]["Credit"] =+Conversion.ToMoney(_Row["CR"]);
                    }
                        _DataTable.Rows[_Index]["Balance"]
                                        = Conversion.ToMoney(_DataTable.Rows[_Index]["OBAL"])
                                        + Conversion.ToMoney(_DataTable.Rows[_Index]["DEBIT"])
                                        - Conversion.ToMoney(_DataTable.Rows[_Index]["CREDIT"]);
                }

            }
            return _DataTable;
        }
        public static int GetTable_ID(DataTable _DataTable)
        {
            return (int)((Tables)Enum.Parse(typeof(Tables), _DataTable.TableName));
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
        View_Project_Ledger = 105,
        View_Trial_Balance = 106,
        View_TB_Period = 107,
        View_VoucherGrid = 108
    };
        
}                               // Namespace
