using Applied_Accounts.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applied_Accounts
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public const string Developedby = "Applied Software House";
        public const string Author = "Muhammad Aamir Jahangir Khan";
        public static object MySession = null;
        public static string StartupPath = Application.StartupPath;
        public static string ExecutablePath = Application.ExecutablePath;
        public static string DateTimeFormat = "";
        public static string ReportsPath = "Applied_Accounts.Reports.";
        public static string CompanyName = "";
        public static string User = "";
        public static DateTime MinDate;
        public static DateTime MaxDate;
        public static CultureInfo Culture;

        [STAThread]
        static void Main()
        {
            

            if (System.IO.File.Exists(Applied_Accounts.Properties.Settings.Default.DBFile))
            {
                DateTimeFormat = Applied.GetString("DateFormat");
                MinDate = Applied.GetDate("MinDate");
                MaxDate = Applied.GetDate("MaxDate");
                Culture = new CultureInfo((string)Applied.GetValue("Culture", (int)Applied.KeyType.String));
                CompanyName = Applied.GetString("Company");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (MySession==null)
                {
                    MySession = "";
                    Application.Run(new frmLogin());
                }

                if (MySession.ToString().Length>0)
                {
                    Application.Run(new frmMainMenu());
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmDBSetting());
            }

        }
    }
}
