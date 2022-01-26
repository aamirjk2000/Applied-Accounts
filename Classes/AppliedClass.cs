using Applied_Accounts.Classes;
using System.Windows;

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
