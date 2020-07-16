using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

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

        #endregion

        #region Money (decimal)

        public static decimal ToMoney(string _Value)
        {
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

        //public static decimal ToMoney(object _Value)
        //{
        //    return Convert.ToDecimal(_Value);
        //}


        public static decimal ToMoney(TextBox _TextBox)
        {
            string _Value = _TextBox.Text.Trim();
            return Convert.ToDecimal(_Value);
        }


        #endregion

        #region Integer

        public static int ToInteger(string _Value)
        {
            if (_Value == "") { return 0; }
            if (_Value == string.Empty) { return 0; }
            //else { return Convert.ToInt32(_Value); }

            return Convert.ToInt32(_Value);
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
            if (_Value == null) { return 0; }
            //if ((string)_Value == string.Empty) { return 0; }

            return int.Parse(_Value.ToString());
        }


        #endregion

        #region Date


        public static DateTime ToDate(string _Value)
        {
            CultureInfo _Culture = Applied.MyCulture;
            if (_Culture == null) { new CultureInfo("en-GB"); }         // Set Culture if not specifiy.


            if (_Value == "") { return Today(); } // Set Today Date if value is null.

            if (_Value.Length == 10)
            {
                return DateTime.ParseExact(_Value, "yyyy-mm-dd", null);
            }

            else { return Convert.ToDateTime(_Value, _Culture); }

        }

        public static DateTime ToDate(string _Value, CultureInfo _Culture)
        {
            if (_Culture == null) { new CultureInfo("en-GB"); }         // Set Culture if not specifiy.

            if (_Value == "") { return Today(); } // Set Today Date if value is null.
            else { return Convert.ToDateTime(_Value, _Culture); }

        }

        public static DateTime Today() { return DateTime.Now; }

        public static string ToReportDate(DateTime _DateTime)
        {
            return _DateTime.ToString("yyyy-MM-dd");
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

        public static decimal ToDecimal(bool _Bool)                   // convert Boolean to Number (Digit)
        {
            if (_Bool) { return 1; } else { return 0; }
        }

        #endregion

        #region Table Enum values

        public static string GetTableName(int _Value)
        {
            return Enum.GetName(typeof(Tables), _Value);
        }

    
        #endregion

    }   // Main Class End
}       // NameSpace Class End
