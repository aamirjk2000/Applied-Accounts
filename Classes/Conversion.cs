using Microsoft.ReportingServices.Interfaces;
using Microsoft.SqlServer.Server;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Applied_Accounts.Classes
{
    public class Conversion
    {

        #region Long
        public static long ToLong(int _Value)                        // Convert Interger to Long
        {

            return Convert.ToInt64(_Value);
        }

        public static long ToLong(string _Value)
        {
            if (_Value == "") { return 0; }
            if (_Value == string.Empty) { return 0; }
            else { return Convert.ToInt64(_Value); }
        }


        public static long ToLong(object _Value)
        {
            long _Result;
            string _value = _Value.ToString();


            if (_value == null || _value.Trim() == string.Empty)
            {
                _Result = 0;
            }
            else
            {
                try
                {
                    _Result = long.Parse(_value);
                }
                catch
                {
                    _Result = 0;
                }
            }
            return _Result;
        }



        #endregion

        #region Money (decimal)

        public static decimal ToMoney(string _Value)
        {
            if (_Value.Length == 0) { return 0; }
            return Convert.ToDecimal(_Value);
        }

        public static decimal ToMoney(int _Value)
        {
            return Convert.ToDecimal(_Value);
        }

        public static decimal ToMoney(long _Value)
        {
            return Convert.ToDecimal(_Value);
        }

        public static decimal ToMoney(object _Value)
        {
            decimal _Result;
            if(_Value == DBNull.Value) { _Result = 0; }
            else { _Result = Convert.ToDecimal(_Value); }
            return _Result;
        }

        public static decimal ToMoney(System.Windows.Forms.TextBox _TextBox)
        {
            string _Value = _TextBox.Text.Trim();
            if (_Value.Length==0) { return 0; }
            return Convert.ToDecimal(_Value);
        }


        #endregion

        #region Integer

        public static int ToInteger(string _Value)
        {
            if (_Value == "") { return 0; }
            if (_Value == string.Empty) { return 0; }

            if (!Applied.IsChar(_Value,"0123456789"))
            {
                return Convert.ToInt32(_Value);
            }
            return 0;
        }
        public static int ToInteger(long _Value)
        {
            return Convert.ToInt32(_Value);
        }
        public static int ToInteger(int _Value) { return _Value; }
        public static int ToInteger(bool _Value)
        {
            if (_Value == true) { return 1; }
            else { return 0; }
        }
        public static int ToInteger(object _Value)
        {
            if (_Value == DBNull.Value) { return 0; }
            if (_Value == null) { return 0; }
            if(_Value.ToString().Length==0) { return 0; }
            if (!Applied.IsChar(_Value.ToString(), "-0123456789"))
            {
                return Convert.ToInt32(_Value);
            }
            return 0; 
        }

        public static object ToDBInteger(object _Value)
        {
            if (_Value == DBNull.Value) { return DBNull.Value; }
            if (_Value == null) { return DBNull.Value; }
            if (_Value.ToString().Length == 0) { return DBNull.Value; }
            if(_Value.ToString()=="0") { return DBNull.Value; }
            if (!Applied.IsChar(_Value.ToString(), "0123456789"))
            {
                return Convert.ToInt32(_Value);
            }
            return DBNull.Value;
        }

        #endregion

        #region Date


        public static DateTime ToDate(string _DateTime)
        {
            SQLite_Date DateClass = new SQLite_Date(_DateTime);
            return DateClass.GetDate();                                 // Get Date in Datetime format standard
        }

        public static string ToDate_DB(DateTime _DateTime)
        {
            SQLite_Date DateClass = new SQLite_Date(_DateTime);
            return DateClass.GetDate_DB();                              // return date in string format yyyy-MM-dd
        }


        public static string ToDate_DB(object _DateTime)
        {
            SQLite_Date DateClass = new SQLite_Date(_DateTime);
            return DateClass.GetDate_DB();                              // return date in string format yyyy-MM-dd
        }

        //public static DateTime ToMyDate(object _DateTime, object _Style)
        //{
        //    SQLite_Date DateClass = new SQLite_Date(_DateTime);
        //    return DateClass.GetDate();

        //}

        //public static DateTime ToMyDate(string _DateTime, object _Style)
        //{
        //     SQLite_Date DateClass = new SQLite_Date(_DateTime);
        //    return DateClass.GetDate();
        //}

        public static DateTime Today() 
        { 
            return DateTime.Now; 
        }

        public static string ToReportDate(DateTime _DateTime)
        {
            return _DateTime.ToString("yyyy-MM-dd") ;
        }

        public static string ToPrintDate(DateTime _DateTime)
        {
            return _DateTime.ToString(Program.DateTimeFormat);
        }

        public static string ToPrintDate(string _Value)
        {
            if (_Value.Length == 0) { return ""; }
            DateTime _DateTime = ToDate(_Value);
            return _DateTime.ToString(Program.DateTimeFormat);
        }


        #endregion

        #region Boolean


        public static bool ToBoolean(string _Value)
        {
            switch (_Value.ToUpper())
            {
                case "TRUE":
                    return true;
                case "YES":
                    return true;

                case "FALSE":
                    return false;
                case "NO":
                    return false;

                default:
                    return false;
            }
        }

        public static bool ToBoolean(int _Value)
        {
            switch (_Value)
            {
                case 0:
                    return false;

                case 1:
                    return true;

                default:
                    return false;
            }
        }

        public static decimal ToBoolean(bool _Bool)                   // convert Boolean to Number (Digit)
        {
            if (_Bool) { return 1; } else { return 0; }
        }

        #endregion

        #region Double
        public static double ToDouble(object _Value)                        // Convert Interger to Long
        {
            double _Result;
            _Result = Convert.ToDouble(_Value);
            return _Result;
        }


        #endregion



        #region Convert into Words



        #endregion


        #region Table Enum values

        public static string GetTableName(int _Value)
        {
            return Enum.GetName(typeof(Tables), _Value);
        }

    
        #endregion

    }   // Main Class End
}       // NameSpace Class End
