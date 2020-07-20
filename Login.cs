using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Applied_Accounts
{
    public partial class frmLogin : Form
    {

        DataView _Users;
        string MyCode { get => txtCode.Text.Trim(); }
        string MyPW { get => txtPW.Text.Trim(); }
        int Attempt;
        bool Sucessful;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, System.EventArgs e)
        {
            _Users = AppliedTable.GetDataTable(Tables.Users).AsDataView();
            Attempt = 0;
            Sucessful = false;
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            if(Attempt>5) { Close(); }

            Attempt += 1;
            string _Message = "User ID or Password is not correct.";
            Sucessful = false;

            _Users.RowFilter = string.Concat("CODE='", MyCode, "'");

            if (_Users.Count == 1)
            {
                if(_Users[0].Row["PW"].ToString()==MyPW)
                {
                    Sucessful = true;
                }
            }

            if(Sucessful)
            {
                Program.MySession = Guid.NewGuid();
                Close();
            }
            else
            {
                MessageBox.Show(_Message);
                txtCode.Focus();
            }

        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if(txtCode.Text.Trim()=="-")
            {
                Program.MySession = Guid.NewGuid();
                Close();
            }
        }
    }
}
