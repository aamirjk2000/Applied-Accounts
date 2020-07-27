using Microsoft.ReportingServices.Interfaces;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Forms;
//using System.Windows.Forms;
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


        public static DateTime ToDate(string _DateTime)
        {
            DateTime _Result;

            bool IsDate = DateTime.TryParse(_DateTime, Applied.MyCulture, 0, out _Result); ;
            
            if (!IsDate)
            {
                _Result = DateTime.Now;
                MessageBox.Show(_DateTime + " can not conver into DateTime");
            }

            return _Result;
        }

        public static DateTime ToMyDate(object _DateTime, object _Style)
        {
            return ToMyDate(_DateTime.ToString(), _Style);
        }



        public static DateTime ToMyDate(string _DateTime, object _Style)
        {
            DateTime _Result = DateTime.Now; ;

            try
            {
                switch (_Style)
                {
                    case Applied.DateTimeStyle.DataColumn:
                        _Result = DateTime.ParseExact(_DateTime, "yyyy-MM-dd", Applied.MyCulture);
                        break;

                    case Applied.DateTimeStyle.DD_MM_YYYY:
                        _Result = DateTime.ParseExact(_DateTime, "dd-MM-yyyy", Applied.MyCulture);
                        break;

                    case Applied.DateTimeStyle.MM_DD_YYYY:
                        _Result = DateTime.ParseExact(_DateTime, "MM-dd-yyyy", Applied.MyCulture);
                        break;

                    case Applied.DateTimeStyle.YYYY_MMM_DD:
                        _Result = DateTime.ParseExact(_DateTime, "yyyy-MMM-dd", Applied.MyCulture);
                        break;

                    case Applied.DateTimeStyle.YYYY_MM_DD:
                        _Result = DateTime.ParseExact(_DateTime, "yyyy-MM-dd", Applied.MyCulture);
                        break;
                }

            }

            catch (Exception e)
            {
                try
                {
                    _Result = DateTime.Parse(_DateTime, Applied.MyCulture);
                }
                catch (Exception)
                {

                    Console.Beep(800, 200);
                    MessageBox.Show(e.Message,_DateTime,MessageBoxButton.OK,MessageBoxImage.Error);
                }

            }
            

            
            return _Result;
        }



        public static DateTime Today() 
        { 
            return DateTime.Now; 
        }

        public static string ToReportDate(DateTime _DateTime)
        {
            return _DateTime.ToString("yyyy-MM-dd") ;
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
