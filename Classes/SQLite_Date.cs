using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applied_Accounts.Classes
{
    interface iSQLite_Date
    {
        DateTime GetDate();
        DateTime SetDate();
    }
    class SQLite_Date : iSQLite_Date
    {
        private string MyDateTime { get; set; }
        private DateTime MyResult;
        private int _Year, _Month, _Day;

        public SQLite_Date(object _DateTime)
        {
            MyDateTime = _DateTime.ToString();
        }

        public DateTime GetDate()
        {
            switch (MyDateTime.Trim().Length)
            {
                case 0:
                    return DateTime.Now;


                case 10:   // 2017-01-01     01-01-2017

                    

                    if(MyDateTime.Substring(4,1)=="-" && MyDateTime.Substring(7, 1) == "-")
                    {
                        _Year = Convert.ToInt32(MyDateTime.Substring(0, 4));
                        _Month = Convert.ToInt32(MyDateTime.Substring(5, 2));
                        _Day = Convert.ToInt32(MyDateTime.Substring(8, 2));

                        MyResult = new DateTime(_Year, _Month, _Day);
                    }

                    if (MyDateTime.Substring(2, 1) == "-" && MyDateTime.Substring(5, 1) == "-")
                    {
                        _Year = Convert.ToInt32(MyDateTime.Substring(0, 2));
                        _Month = Convert.ToInt32(MyDateTime.Substring(3, 2));
                        _Day = Convert.ToInt32(MyDateTime.Substring(5, 4));

                        MyResult = new DateTime(_Year, _Month, _Day);
                    }

                    break;

                case 19:  // 2017-01-01 00:00:00

                    _Year = Convert.ToInt32(MyDateTime.Substring(1, 4));
                    _Month = Convert.ToInt32(MyDateTime.Substring(6, 2));
                    _Day = Convert.ToInt32(MyDateTime.Substring(9, 2));

                    MyResult = new DateTime(_Year, _Month, _Day);
                    break;


                default:

                    MyResult = Convert.ToDateTime(MyDateTime);
                    break;
            }

            return MyResult;
        }
        public DateTime SetDate()
        {


            return new DateTime();
        }



    }
}
