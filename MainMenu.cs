using Applied_Accounts.Forms;
using System;
using System.Windows.Forms;
using Applied_Accounts.Classes;
using Applied_Accounts.Reports;

namespace Applied_Accounts
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
                InitializeComponent();
        }


        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            lbl_DevelopedBy.Text = Program.Developedby;
            lbl_Author.Text = Program.Author;
            lbl_GUID.Text = Program.MySession.ToString();
            lblCompanyName.Text = Applied.GetString("Company");

            Text = lblCompanyName.Text.Trim();

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataBaseSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDBSetting ThisForm = new frmDBSetting();
            ThisForm.Show();
        }

        private void mnuCOA_Click(object sender, EventArgs e)
        {
            frmCOA ThisForm = new frmCOA();
            ThisForm.Show();
        }

       
        private void mnuAccNotes_Click_1(object sender, EventArgs e)
        {
            frmAccNotes ThisForm = new frmAccNotes();
            ThisForm.Show();
        }

        private void mnuSupplier_Click(object sender, EventArgs e)
        {
            frmSuppliers ThisForm = new frmSuppliers((int)Tables.Suppliers);
            ThisForm.Show();
        }

        private void mnuProjects_Click(object sender, EventArgs e)
        {
            frmProject ThisForm = new frmProject();
            ThisForm.Show();
        }

        private void mnuUnits_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuEmployees_Click(object sender, EventArgs e)
        {
            frmEmployees ThisForm = new frmEmployees();
            ThisForm.Show();
        }

        private void mnuJV_Click(object sender, EventArgs e)
        {
            frmVouchers ThisForm = new frmVouchers((int)Applied.VoucherType.Journal);
            ThisForm.Show();
        }

        private void mnuPV_Click(object sender, EventArgs e)
        {
            frmVouchers ThisForm = new frmVouchers((int)Applied.VoucherType.Payment);
            ThisForm.Show();
        }

        private void mnuRV_Click(object sender, EventArgs e)
        {
            frmVouchers ThisForm = new frmVouchers((int)Applied.VoucherType.Receipt);
            ThisForm.Show();
        }

        private void mnuMigration_Click(object sender, EventArgs e)
        {
            frmMigration ThisForm = new frmMigration();
            ThisForm.Show();
        }

        private void mnuRptGL_Click(object sender, EventArgs e)
        {
            frmGeneral_Ledger ThisForm = new frmGeneral_Ledger();
            ThisForm.Show();
        }

        private void mnuSetting_Click(object sender, EventArgs e)
        {
            frmSetting ThisForm = new frmSetting();
            ThisForm.Show();
        }

        private void mnuVouchers_Click(object sender, EventArgs e)
        {
            frmReport_Vouchers ThisForm = new frmReport_Vouchers();
            ThisForm.Show();
        }

        private void mnuSupplierLedger_Click(object sender, EventArgs e)
        {
            frmGL_Supplier ThisForm = new frmGL_Supplier();
            ThisForm.Show();
        }

        private void mnuProjectLedger_Click(object sender, EventArgs e)
        {
            frmGL_Project ThisForm = new frmGL_Project();
            ThisForm.Show();
        }
    }
}
