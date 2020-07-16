﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//namespace Applied_Accounts.Classes
namespace Applied_Accounts
{
    public class AppliedClass
    {
        public static string Get_Format(int FormatID)
        {
            string _Result = "";
            switch(FormatID)
            {
                case (int)TextFormat.AccountCode:
                    _Result = "00-00-000";
                    break;

                case (int)TextFormat.Codes:
                    _Result = "000000";
                    break;

                case (int)TextFormat.Numbers:
                    _Result = "###,###,###";
                    break;

                case (int)TextFormat.NumbersPoint:
                    _Result = "###,###,###.##";
                    break;

                case (int)TextFormat.Currency:
                    _Result = "#,##0;(#,##0);-";
                    break;

                case (int)TextFormat.Date:
                    _Result = "dd-MMM-yyyy";
                    break;

                case (int)TextFormat.Boolean:
                    _Result = "Yes;0;.";
                    break;

                default:
                    _Result = "";
                    break;
            }


            return _Result;
        }

        #region conversations.

        // convert string value into long
        public static long ConvertInt(string _Value)
        {
            if (_Value.Length == 0) { return 0; }
            else { return Convert.ToInt64(_Value); }
        }

        // convert boolena value to digit 0 or 1
        public static int ConvertDigit(bool _Value)
        {
            if(_Value) { return 1; } else { return 0; }
        }

        // Convert digit 1 and 0 to boolean true or false.
        public static bool Convertbool(string _Value)
        {
            if (_Value.Trim()=="1") { return true; } else { return false; }
        }

        #endregion

    }

    public enum TextFormat
    {
        AccountCode = 1,
        Codes = 2,
        Numbers = 3,
        NumbersPoint = 4,
        Currency = 5,
        Boolean = 6,
        Date = 7

    };



}
