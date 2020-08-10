using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Applied_Accounts
{
    interface IThisTable
    {
        void Next();
        void Previous();
        void Top();
        void Bottom();
        DataRow GetNewRow();
        void Update(int _TableID);
    }


    public class ThisTable : IThisTable    // Main Class | Class start from here.
    {
        #region Variables


        public DataTable MyDataTable = new DataTable();
        public DataView MyDataView = new DataView();
        public int MyTableID  { get; set; }
        public string MyPrimaryKeyName { get; set; }
        public long MyPrimaryKeyValue = 0;
        public bool IsSaved;
        public bool IsDeleted;
        public string MyMessage;
        public bool ShowSaveMessage = true;

        public bool Active { get; set; }
        public DataRow MyDataRow { get; set; }                      // current DataRow
        public DataRow OriginalRow { get; set; }                    // Original Data of the row
        public int Count { get => MyDataTable.Rows.Count; }         // Numbers of total records
        public int Row_Index { get; set; }                          // Current Row Index of Data Table
        public string Filter { get => MyDataView.RowFilter; set => MyDataView.RowFilter = value; }

        private SQLiteCommand _Command = new SQLiteCommand("", Connection.AppliedConnection());

        #endregion

        #region Initialize


        public ThisTable(object _DataTableID)
        {
            Update((int)_DataTableID);

            if (MyDataTable != null)
            {
                //MessageBox.Show("Table name is not assigned", "ERROR");
                initialize(MyDataTable);
            }
        }

        public ThisTable(int _DataTableID)
        {
            Update(_DataTableID);

            if (MyDataTable != null)
            {
                //MessageBox.Show("Table name is not assigned", "ERROR");
                initialize(MyDataTable);
            }
        }
        public ThisTable(DataTable _DataTable)
        {
            if(_DataTable!=null)
            {
                //MessageBox.Show("Table name is not assigned", "ERROR");
                initialize(_DataTable);
            }
        }
        
           // initialize the class.
        private void initialize(DataTable _DataTable)
        {
            if (_DataTable != null)
            {
                // Original row has data as stored in DataTable. it wwould be used as restore the original data
                // into Text Field if user cancelled the edited field (TextBox.text).

                
                Active = true;
                MyTableID = (int)Enum.Parse(typeof(Tables), _DataTable.TableName);
                MyDataTable = _DataTable;

                MyDataView = MyDataTable.AsDataView();      // Assign Table into Table view
                OriginalRow = _DataTable.NewRow();          // Row with Original Data of the current row   
                MyDataRow = OriginalRow;                    // Row is allowed to edit 

                MyPrimaryKeyName = "ID";

                if (_DataTable.Rows.Count > 0)              // Initialize the first record PK value
                        { MyPrimaryKeyValue = (long)_DataTable.Rows[0][MyPrimaryKeyName]; }
                else    { MyPrimaryKeyValue = -1; }


                MoveTop();                                  // Table row point at first record.

            }
            else
            {
                Active = false;                 // Class is not active to perform table's actions.
            }
        }

        #endregion

        //Get Row
        #region Row
        public DataRow GetNewRow()                              // Get New Row
        {
            return MyDataTable.NewRow();
        }
        
        public DataRow GetRow(int _ID)                          // New Data Row from Table
        {
            if (_ID == -1)                                    // Get New Row if Table is empty.
            {
                return GetNewRow();

                //if (Count == 0) {return GetNewRow(); }      // retuern new row if table is empty
                //else {return MyDataView.ToTable().Rows[0];}         // return row
            }
            else
            { 
                if(MyPrimaryKeyName.Length==0) { MyPrimaryKeyName = "ID"; }                        // Assign ID Column as PK if not exist.
                MyDataView.RowFilter = string.Concat(MyPrimaryKeyName,"=", _ID.ToString());        // Get DataRow after filter condition appled.
                if (MyDataView.Count == 1) { return MyDataView.ToTable().Rows[0];}                 // Get a row from Table is exist.
                else { return GetNewRow(); }                                               // Get New Row if Filter count zero rows.
            }
        }
        public DataRow GetRow(string _Filter)                   // Get Row after filter applied (string condition).
        {
            MyDataView.RowFilter = _Filter;

            if (MyDataView.Count == 1) { return MyDataView.ToTable().Rows[0]; }                     // Get row if exist
            else { return MyDataTable.NewRow(); }                                                   // GEt new row if not exist.
        }

        #endregion

        // Record Save / DElete
        #region Save & Delete

        public long GetMaxID()                                  // Get Table Primery Kay Maximum Value for add new record.
        {

            long _Result = 0;

            if(MyDataTable.Rows.Count==0)
            {
                _Result = 0;
            }

            if (MyDataTable.Rows.Count > 0)
            {
                _Result = (long)MyDataTable.Compute("MAX(ID)", string.Empty);
            }

            return _Result;
        }
        public string Save()                                    // Save the record with Current Data Row
        {
            return Save(MyDataRow);
        }
        public string Save(bool _MessageShow)                   // Save the record with Current Data Row
        {
            ShowSaveMessage = _MessageShow;                     // Do not Show Message Box to ask "Save record".
            return Save(MyDataRow);
        }
        public string Save(DataRow _DataRow, bool _MessageShow) // Save the record with Current Data Row
        {
            ShowSaveMessage = _MessageShow;                     // Do not Show Message Box to ask "Save record".
            return Save(_DataRow);
        }
        public string Save(DataRow _DataRow)                    // Save the record with specific Data Row.
        {
            if(ShowSaveMessage)                     // Show Message Box ans Ask to save the record?
            { 
                DialogResult Ask = MessageBox.Show("Are you Sure to Save","SAVE RECORD",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(Ask==DialogResult.No) { return "Cancelled.";}
            }

            string _Message;                                                // Return value of this procedure.
            bool _IsError;                                                  // If error found = true otherwsie false.
            IsSaved = false;                                                // If Data Row saved then true else false. Default is false.
            MyPrimaryKeyValue = (long)_DataRow[MyPrimaryKeyName];           // Set Primary Key Value

            _IsError = false;

            if(MyPrimaryKeyValue<=0)                                        // return if Table PK not exist.
            {
                MessageBox.Show("Primary Key not found.", "ERROR");
                return "Primary Key not found."; 
            } 


            //MyDataView.RowFilter = string.Concat(MyPrimaryKeyName, "=", MyPrimaryKeyValue);  OLD
            Filter = MyPrimaryKeyName + "=" + MyPrimaryKeyValue.ToString();      // NEW  Applied Filter in View

            switch (MyDataView.Count)
            {
                case 0:
                    {
                        _Command = Connection_Class.SQLite.SQLiteInsert(_DataRow, Connection.AppliedConnection());
                        _Message = " Recorda(s) Inserted.";
                        _IsError = false;
                        IsSaved = true;
                        break;
                    }

                case 1:
                    {
                        _Command = Connection_Class.SQLite.SQLiteUpdate(_DataRow, MyPrimaryKeyName, Connection.AppliedConnection());
                        _Message = " Recorda(s) Updated.";
                        _IsError = false;
                        IsSaved = true;
                        break;
                    }

                default:
                    {
                        _IsError = true;
                        IsSaved = false;
                        _Message = string.Concat("ERROR : ", MyDataView.Count.ToString().Trim(), " record found to save.") ;
                        break;
                    }
            }

            if (!_IsError)
            {
                if (_Command.Connection.State == ConnectionState.Closed)
                {
                    _Command.Connection.Open();
                }
                
                try
                {
                    _Message = _Command.ExecuteNonQuery().ToString() + _Message;
                    _Command.Connection.Close();
                    IsSaved = true;
                }
                catch (Exception ex)
                {
                    IsSaved = false;
                    _Message = ex.Message;
                }
            }

            if(IsSaved)
            {
                Update(MyTableID);               // update Data Table After Save row in DB
            }

            
            MyMessage = _Message;                       // Save the message to Class Message 
            return MyMessage;
        }
        public string Delete(int ID)
        {
            string _Message = "Deleted.";
            IsDeleted = false;                   // if Data Row deleted when true else false. Default is false.

            if (Seek(ID))                       // Seek a record in Datatable, if found is true otherwise false.
            {
                DialogResult Ask = MessageBox.Show("Are you Sure to DELETE current record.", "DELETE RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Ask == DialogResult.Yes)
                {
                    _Command.CommandText = string.Concat("DELETE FROM [", MyDataTable.TableName.Trim(), "] WHERE ", MyPrimaryKeyName, "=", ID.ToString());

                    if (_Command.Connection.State == ConnectionState.Closed)
                    {
                        _Command.Connection.Open();
                    }

                    try
                    {
                        _Message = _Command.ExecuteNonQuery().ToString() + _Message;
                        _Command.Connection.Close();
                        IsDeleted = true;
                    }
                    catch (Exception ex)
                    {
                        IsDeleted = false;
                        _Message = ex.Message;
                    }
                }
                else
                { 
                    MessageBox.Show("Deletion Canceled", "DELETE RECORD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


            MyMessage = _Message;
            return MyMessage;
        }

        #endregion

        // Seek
        #region Seek 

        public bool Seek(int _ID)
        {
            MyDataView.RowFilter = string.Concat(MyPrimaryKeyName,"=", _ID.ToString());
            if (MyDataView.Count == 1) 
                { return true;} 
            else 
                { return false;}
        }

        public bool Seek(string _Filter)
        {
            MyDataView.RowFilter = _Filter;
            if (MyDataView.Count == 1)
            { return true; }
            else
            { return false; }
        }


        #endregion

        // Navigator Codes
        #region Navigator Codes

        #region Interface Action

        public void Next() { MoveNext(); }

        public void Previous() { MovePrevious(); } 

        public void Top() { MoveTop(); }

        public void Bottom() { MoveLast(); }

        #endregion

        public void MoveNext()
        {
            Row_Index = MyDataTable.Rows.IndexOf(MyDataRow) + 1;
            if (Row_Index > (Count-1)) { Row_Index = (Count-1); }       // if index is more than total record. get last record
            MyDataRow = MyDataTable.Rows[Row_Index];
        }

        public void MovePrevious()
        {
            Row_Index = MyDataTable.Rows.IndexOf(MyDataRow) - 1;
            if (Row_Index < 0) { Row_Index = 0; }                       // if index less than zero get first record.
            MyDataRow = MyDataTable.Rows[Row_Index];
        }

        public void MoveTop()
        {
            Row_Index = 0;
            
            if (MyDataTable.Rows.Count > 0)     
                    { MyDataRow = MyDataTable.Rows[Row_Index];}
            else
            
            { MyDataRow = GetNewRow(); }
        }

        public void MoveLast()
        {
            if (MyDataTable.Rows.Count > 0)
            {
                Row_Index = MyDataTable.Rows.Count - 1;
                MyDataRow = MyDataTable.Rows[Row_Index]; 
            }
            else
            {
                Row_Index = 0 ;
                MyDataRow = GetNewRow();
            }
        }

        #endregion

        public void Update(int _TableID)                                           // Update MyTable from DB
        {
            MyDataTable = AppliedTable.GetDataTable(_TableID);         // Refill Data Table from Data Server.
            MyDataView = MyDataTable.AsDataView();
            Row_Index = MyDataTable.Rows.IndexOf(MyDataRow);                        // Set current Row
            MyDataRow = GetRow(Row_Index);   //MyDataTable.Rows[Row_Index];                                // Get current Row
        }
        // Data Conversion
       
    }                                   // Main Class End
}                                       // Name Space End.
