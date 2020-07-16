using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Applied_Accounts
{
    public partial class frmDBSetting : Form
    {
        public frmDBSetting()
        {
            InitializeComponent();
        }

        private void DBSetting_Load(object sender, EventArgs e)
        {
            txtLocation.Text = Properties.Settings.Default.DBFile;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFDB.Filter = "Data Base files (*.db)|*.db|All files (*.*)|*.*";
            openFDB.ShowDialog();
            txtLocation.Text = openFDB.FileName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DBFile = txtLocation.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Database file (Path) has been saved. \r" + Properties.Settings.Default.DBFile, "SAVED");
            Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            string sqlite_text;
            sqlite_text = txtLocation.Text.Trim();

            if (File.Exists(sqlite_text))
            {
                sqlite_conn = new SQLiteConnection("Data Source=" + sqlite_text);  //+ " Version = 3; New = True; Compress = True; ");
                // Open the connection:
                try
                {
                    sqlite_conn.Open();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("DataBase Connection is not being established \r" + ex.Message, "ERROR");
                }

                MessageBox.Show(string.Concat(sqlite_conn.State.ToString(), "\r", txtLocation.Text.Trim()));
            }
            else
            {
                MessageBox.Show("File is not exist..... \r" + txtLocation.Text);

            }
        
            
        }
    }
}
