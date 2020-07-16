using System;
using System.Globalization;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
//using Microsoft.ReportingServices.Diagnostics.Internal;
//using Microsoft.Extensions.DependencyInjection;

namespace Applied_Accounts.Classes
{
        public class Applied
        {
        public CultureInfo Culture { get; set; }
        public DateTime Voucher_MinDate { get; set; } 
        public DateTime Voucher_MaxDate { get; set; }
        public static CultureInfo MyCulture { get => new CultureInfo((string)GetValue("Culture", (int)KeyType.String)); }

        public Applied()
        {
            Voucher_MinDate = (DateTime)GetValue("VouDate1", (int)KeyType.Date);
            Voucher_MaxDate = (DateTime)GetValue("VouDate2", (int)KeyType.Date);
            Culture = new CultureInfo((string)GetValue("Culture", (int)KeyType.String));
            //Culture = 
        }


        #region Get Values;

        public static object GetValue(string _Key, int _KeyType)
        {
            
            DataTable _DataTable = AppliedTable.GetDataTable((int)Tables.Applied);
            DataView _DataView = new DataView(_DataTable);

            if(_DataView.Count==0) { return null; }

            _DataView.RowFilter = string.Concat("Key='", _Key, "'");


            if (_DataView.Count == 1)
            {
                switch (_KeyType)
                {
                    case (int)KeyType.String:
                        return _DataView[0].Row["sValue"].ToString();

                    case (int)KeyType.Integer:
                        return Conversion.ToInteger(_DataView[0].Row["nValue"].ToString());

                    case (int)KeyType.Boolean:
                        return Conversion.ToBoolean(_DataView[0].Row["bValue"].ToString());

                    default:
                        return null;
                }
            }

            if (_DataView.Count == 0)
            {
                switch (_KeyType)
                {
                    case (int)KeyType.String:
                        return "";

                    case (int)KeyType.Integer:
                        return 0;

                    case (int)KeyType.Boolean:
                        return false;

                    default:
                        return null;
                }
            }

                return null;
        }

        public static string GetString(string _Key)
        {
            return (string)GetValue(_Key, (int)KeyType.String);
        }

        public static int GetInteger(string _Key)
        {
            return (int)GetValue(_Key, (int)KeyType.Integer);
        }

        public static DateTime GetDate(string _Key)
        {
            DataTable _DataTable = AppliedTable.GetDataTable((int)Tables.Applied);
            DataView _DataView = new DataView(_DataTable);
            string _DateString = "";
            string _CultureString = "";
#pragma warning disable CS0168 // The variable '_Culture' is declared but never used
            CultureInfo _Culture ;
#pragma warning restore CS0168 // The variable '_Culture' is declared but never used

            _DataView.RowFilter = string.Concat("Key='", _Key, "'");

            if (_DataView.Count == 1) 
            {
                _DateString = _DataView[0].Row["sValue"].ToString();
            }

            if (_DateString != null)
                { _DataView.RowFilter = "Key='Culture'"; }
            if (_DataView.Count == 1)
            {
                _CultureString = _DataView[0].Row["sValue"].ToString();
            }

            return Conversion.ToDate(_DateString, new CultureInfo(_CultureString));
        }

        public static bool GetBoolean(string _Key)
        {
            return (bool)GetValue(_Key, (int)KeyType.Boolean);
        }


        #endregion

        #region  SET Value

        public static string SetValue(string _Key, object _Value, object _KeyType)
        {
            if(_Value==null) { return "null value found"; }

            SQLiteCommand _CommandInsert = new SQLiteCommand("", Connection.AppliedConnection());
            SQLiteCommand _CommandUpdate = new SQLiteCommand("", Connection.AppliedConnection());

            bool _Record_Exist;
            string _Message = "";
            long RecID;

            _CommandUpdate.CommandText = "UPDATE Applied Set nValue=@nValue, sValue=@sValue, bValue=@bvalue WHERE ID=@ID";
            _CommandInsert.CommandText = "INSERT INTO Applied VALUES (@ID,@Key,@nValue,@sValue,@bValue)";


            DataView _DataView = AppliedTable.GetDataTable((int)Tables.Applied).AsDataView();
            _DataView.RowFilter = string.Concat("Key='", _Key.Trim(), "'");
            if(_DataView.Count==0) 
            {
                _Record_Exist = false;
                _DataView.RowFilter = string.Empty;
                RecID = (long)_DataView.Table.Compute("MAx(ID)", string.Empty) + 1;
                _CommandInsert.Parameters.AddWithValue("@ID", RecID);
            } 
            else 
            {
                _Record_Exist = true;
                RecID = Conversion.ToLong(_DataView[0]["ID"].ToString());
                _CommandUpdate.Parameters.AddWithValue("@ID", RecID);
            }

            
            _CommandInsert.Parameters.AddWithValue("@Key", _Key);
            _CommandInsert.Parameters.AddWithValue("@nValue", 0);
            _CommandInsert.Parameters.AddWithValue("@sValue", "");
            _CommandInsert.Parameters.AddWithValue("@bValue", false);

            
            _CommandUpdate.Parameters.AddWithValue("@Key", _Key);
            _CommandUpdate.Parameters.AddWithValue("@nValue", 0);
            _CommandUpdate.Parameters.AddWithValue("@sValue", "");
            _CommandUpdate.Parameters.AddWithValue("@bValue", false);
            

            switch (_KeyType)
            {
                case KeyType.String:
                    _CommandInsert.Parameters["@sValue"].Value = (string)_Value;
                    _CommandUpdate.Parameters["@sValue"].Value = (string)_Value;
                    break;

                case KeyType.Integer:
                    if(_Value.GetType()==Type.GetType("System.Int64"))
                    {
                        _CommandInsert.Parameters["@nValue"].Value = (long)_Value;
                        _CommandUpdate.Parameters["@nValue"].Value = (long)_Value;
                    }
                    if (_Value.GetType() == Type.GetType("System.Int32"))
                    { 
                        _CommandInsert.Parameters["@nValue"].Value = (int)_Value;
                        _CommandUpdate.Parameters["@nValue"].Value = (int)_Value;
                    }

                    break;

                case KeyType.Boolean:
                    _CommandInsert.Parameters["@bValue"].Value = (bool)_Value;
                    _CommandUpdate.Parameters["@bValue"].Value = (bool)_Value;
                    break;

                case KeyType.Date:
                    _CommandInsert.Parameters["@sValue"].Value = (DateTime)_Value;
                    _CommandUpdate.Parameters["@sValue"].Value = (DateTime)_Value;
                    break;

                case KeyType.DateTime:
                    _CommandInsert.Parameters["@sValue"].Value = (DateTime)_Value;
                    _CommandUpdate.Parameters["@sValue"].Value = (DateTime)_Value;
                    break;

                default:
                    break;
            }

            if(_Record_Exist)
            {
                _CommandUpdate.ExecuteNonQuery();
                //_Message = _CommandUpdate.ExecuteNonQuery().ToString() + " Updated";
            }
            else 
            {
                _Message = _CommandInsert.ExecuteNonQuery().ToString() + "Inserted";
            }

            //MessageBox.Show(_Message);

            return _Message;

        }




        #endregion



        #region Enums

        public enum KeyType
        {
            String = 1,
            Integer = 2,
            Boolean = 3,
            Date = 4,
            DateTime =5
        }

        public enum VoucherType                 // Type of Voucehrs.
        {
            Journal,
            Payment,
            Receipt,
            Revenue,
            Salary,
            Stock

        }


        public enum PreviewReports
        {
            General_Ledger,
            Supplier_Ledger,
            General_Voucher
        }

        #endregion





        public static bool IsFileExist(string _FileName)
        {
            if (File.Exists(_FileName))
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        public static bool IsNumeric(object sender, KeyPressEventArgs e)
        {
            //Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //If you want, you can allow decimal(float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            return e.Handled;
        }

        public static int ShowBrowseWin(DataView _DataView, object _CurrentValue )
        {
            Browse BrowseWindow = new Browse(_DataView);
            BrowseWindow.ShowDialog();
            int _Result = Conversion.ToInteger(_CurrentValue);
            if (BrowseWindow.IsSelect) { _Result = BrowseWindow.MyID;}
            return _Result;
        }

        public static int ShowBrowseWin(DataTable _DataTable, object _CurrentValue)
        {
            return ShowBrowseWin(new DataView(_DataTable), _CurrentValue);
        }

    }       // END Main Class
}           // END NameSpace
