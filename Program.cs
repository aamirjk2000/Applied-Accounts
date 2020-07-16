using Applied_Accounts.Classes;
using System;
using System.Collections.Generic;
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
        
        [STAThread]
        static void Main()
        {
            if (System.IO.File.Exists(Applied_Accounts.Properties.Settings.Default.DBFile))
            {
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
