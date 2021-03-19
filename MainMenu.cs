using Applied_Accounts.Forms;
using System;
using System.Windows.Forms;
using Applied_Accounts.Classes;
using Applied_Accounts.Reports;
using System.Windows;
using System.IO;
using System.Drawing;
using Applied_Accounts.Forms.Booking;
//using System.Windows;

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


        }
        private void frmMainMenu_Activated(object sender, EventArgs e)
        {
            Text = lblCompanyName.Text.Trim();
            lbl_DevelopedBy.Text = Program.Developedby;
            lbl_Author.Text = Program.Author;
            lbl_GUID.Text = Program.MySession.ToString();
            lblCompanyName.Text = Applied.GetString("Company");
            lblDBPath.Text = Properties.Settings.Default.DBFile;
            lblAppPath.Text = Program.ExecutablePath;
            lblStartPath.Text = Program.StartupPath;
            lblversion.Text = System.Windows.Forms.Application.ProductVersion;


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
            frmSuppliers ThisForm = new frmSuppliers();
            ThisForm.Show();
        }
        private void mnuProjects_Click(object sender, EventArgs e)
        {
            frmProject ThisForm = new frmProject();
            ThisForm.Show();
        }
        private void mnuUnits_Click(object sender, EventArgs e)
        {
            frmUnits ThisForm = new frmUnits();
            ThisForm.Show();
        }
        private void mnuCOAB_Click(object sender, EventArgs e)
        {
            frmCOAB ThisForm = new frmCOAB();
            ThisForm.Show();
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
        private void mnuTrialBalance_Click(object sender, EventArgs e)
        {

            frmTrial_Balance ThisForm = new frmTrial_Balance();
            ThisForm.Show();
        }
        private void mnuPWChange_Click(object sender, EventArgs e)
        {
            frmUsers ThisForm = new frmUsers(Program.User);
            ThisForm.Show();
        }
        private void btnWallpaper_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.DefaultExt = "*.*";
            fd.FileName = Properties.Settings.Default.WallPaper;

            if (File.Exists(fd.FileName))
            {
                Path.GetDirectoryName(fd.FileName);
                fd.InitialDirectory = Path.GetDirectoryName(fd.FileName);
            }
            else
            { 
                fd.InitialDirectory = "C:\\";
                fd.FileName = "";
            }

            fd.ShowDialog();
            Properties.Settings.Default.WallPaper = fd.FileName;
            Properties.Settings.Default.Save();

            BackgroundImage = Image.FromFile(Properties.Settings.Default.WallPaper);
        }
        private void mnuBooking_Click(object sender, EventArgs e)
        {
            frmBooking ThisForm = new frmBooking();
            ThisForm.Show();
        }
        private void mnuInstalments_Click(object sender, EventArgs e)
        {
            frmInstalments Thisform = new frmInstalments();
            Thisform.Show();
        }

        private void mnuDELVoucher_Click(object sender, EventArgs e)
        {
            frmVoucher_Delete Thisform = new frmVoucher_Delete();
            Thisform.Show();
        }

        private void mnuPOrder_Click(object sender, EventArgs e)
        {
            frmPOrder Thisform = new frmPOrder();
            Thisform.Show();
        }

        private void mnuStockVoucher_Click(object sender, EventArgs e)
        {
            frmVouchers1 Thisform = new frmVouchers1();
            Thisform.Show();
            //Thisform = null;

        }
    }
}
