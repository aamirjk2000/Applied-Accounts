using Applied_Accounts.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applied_Accounts.Forms
{
    public partial class frmVoucher_Delete : Form
    {
        DataTable tb_Ledger;
        DataTable Voucher_list;
        //DataView Grid_ViewData;

        private string CommandText0 = "SELECT DISTINCT(Vou_No) AS[Vou_No] FROM[Ledger];";
        private string CommandText1 = "SELECT SRNO,ACCOUNT,PROJECT,DR,CR,DESCRIPTION FROM [View_Voucher]";

        private string MyVoucher { get => cBoxVouNo.Text.Trim(); }


        public frmVoucher_Delete()
        {
            InitializeComponent();
            Load_Data();
            
        }

        public void Load_Data()
        {
            Voucher_list = AppliedTable.GetDataTable(CommandText0, "Vou_List");
            cBoxVouNo.DataSource = Voucher_list;
            cBoxVouNo.DisplayMember = "Vou_No";
            cBoxVouNo.ValueMember = "Vou_No";
            cBoxVouNo.Refresh();

            if(MyVoucher.Length>0)
            {
                string _Command = CommandText1 + " WHERE Vou_No='" + MyVoucher + "'";
                tb_Ledger = AppliedTable.GetDataTable(_Command, "Ledger_View");

                if (tb_Ledger.Rows.Count > 0)
                {
                    Grid_Voucher.DataSource = tb_Ledger;
                }
                else
                {
                    Grid_Voucher.DataSource = new DataTable();
                }

            }
        }

        private void cBoxVouNo_DropDownClosed(object sender, EventArgs e)
        {
            string _Vou_No = cBoxVouNo.Text.Trim();
            if(_Vou_No.Length==0) { return; }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            VoucherClass Vou_Class = new VoucherClass();
            Vou_Class.Delete(MyVoucher);
            Load_Data();


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }               // END Main Class
}                   // END Namespace
