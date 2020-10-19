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
        string GetDate_DB();
    }
    class SQLite_Date : iSQLite_Date
    {
        private string MyDateTime { get; set; }
        private DateTime thisDateTime;
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

                    if (MyDateTime.Substring(4, 1) == "-" && MyDateTime.Substring(7, 1) == "-")
                    {
                        _Year = Convert.ToInt32(MyDateTime.Substring(0, 4));
                        _Month = Convert.ToInt32(MyDateTime.Substring(5, 2));
                        _Day = Convert.ToInt32(MyDateTime.Substring(8, 2));

                        thisDateTime = new DateTime(_Year, _Month, _Day);
                    }

                    if (MyDateTime.Substring(2, 1) == "-" && MyDateTime.Substring(5, 1) == "-")
                    {
                        _Year = Convert.ToInt32(MyDateTime.Substring(0, 2));
                        _Month = Convert.ToInt32(MyDateTime.Substring(3, 2));
                        _Day = Convert.ToInt32(MyDateTime.Substring(5, 4));

                        thisDateTime = new DateTime(_Year, _Month, _Day);
                    }

                    break;

                case 19:  // 2017-01-01 00:00:00

                    try
                    {
                        thisDateTime = DateTime.Parse(MyDateTime);

                        if(thisDateTime==null)
                        {
                            _Year = Convert.ToInt32(MyDateTime.Substring(1, 4));
                            _Month = Convert.ToInt32(MyDateTime.Substring(6, 2));
                            _Day = Convert.ToInt32(MyDateTime.Substring(9, 2));

                            thisDateTime = new DateTime(_Year, _Month, _Day);
                        }
                        break;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        break;
                        //throw;
                    }

                default:

                    thisDateTime = Convert.ToDateTime(MyDateTime);
                    break;

            }

            return thisDateTime;
        }

        public string GetDate_DB()
        {
            DateTime _DateTime = GetDate();

            return _DateTime.ToString("yyyy-MM-dd");
        }




    }
}
