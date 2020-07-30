using Applied_Accounts.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Applied_Accounts.Forms
{
    public partial class frmUsers : Form
    {

        DataTable MyDataTable;
        DataView MyDataView;
        string MyUser;

        public frmUsers(string _UserName)
        {
            InitializeComponent();
            MyUser = _UserName;

            MyDataTable = AppliedTable.GetDataTable(Tables.Users);
            MyDataView = MyDataTable.AsDataView();
            MyDataView.RowFilter = "Code='" + _UserName + "'";
            

        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            if(MyDataView.Count==0)
            {
                MessageBox.Show("User not found.");
                txtUser.Enabled = false;
                txtPW1.Enabled = false;
                txtPW2.Enabled = false;
            }
            else
            {
                txtUser.Text = MyDataView[0]["Title"].ToString();
                Text = MyDataView[0]["Code"].ToString();

            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(txtPW1.Text.Trim() == txtPW2.Text.Trim())
            {
                if(MyDataView.Count==1)
                {
                    SQLiteCommand _Command = new SQLiteCommand("", Connection.AppliedConnection()); ;
                    _Command.CommandText = "UPDATE Users Set PW=@PW WHERE ID=@ID";
                    _Command.Parameters.AddWithValue("@ID", MyDataView[0].Row["ID"]);
                    _Command.Parameters.AddWithValue("@PW", GetPW(txtPW1.Text.Trim()));
                    int _RecNo = _Command.ExecuteNonQuery();

                    if (_RecNo == 1)
                    {
                        MessageBox.Show("Password has been saved.");
                    }
                    if (_RecNo == 0)
                    {
                        MessageBox.Show("Password not saved.");
                    }

                    Close();
                }
            }
            else
            {
                MessageBox.Show("Password is not matched.");
                txtPW1.Focus();
            }
        }

        private string GetPW(string _PW)
        {
            // Encrypt Password here.

            return _PW;
        }

        private void txtPW2_Leave(object sender, EventArgs e)
        {
            if(txtPW2.Text.Length==0) { btnChange.Enabled = false;  return; }
            if (txtPW1.Text.Trim() == txtPW2.Text.Trim()) {btnChange.Enabled = true; }


        }
    }               // END Main Class
}                   // END Namespace
