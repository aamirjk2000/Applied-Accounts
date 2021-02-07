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
    public partial class frmVouchers1 : Form
    {
        private DataTable tbAccounts;                               // Data Table
        private DataTable tbSuppliers;
        private DataTable tbProjects;
        private DataTable tbUnits;
        private DataTable tbStocks;
        private DataTable tbEmployees;
        private DataTable tbPOrder;

        private string MyCheque_No;                                 // For copy and past
        private string MyCheque_Date;                               // For copy and past
        private string MyRefNo;                                     // For copy and past
        private string MyPOrder;                                    // For copy and past
        private string MyDescription;                               // For copy and past
        private string MyRemarks;                                   // for Copy and past.

        public static VoucherClass MyVoucherClass = new VoucherClass();


        public frmVouchers1()
        {
            InitializeComponent();
        }

        private void dt_VoucherDate_Layout(object sender, LayoutEventArgs e)
        {
            dt_VoucherDate.Format = DateTimePickerFormat.Custom;
            dt_VoucherDate.CustomFormat = Program.DateTimeFormat;
        }

        private void lblVoucherDate_DoubleClick(object sender, EventArgs e)
        {
            dt_VoucherDate.Value = DateTime.Now;
        }

        private void dt_ChqDate_Layout(object sender, LayoutEventArgs e)
        {
            dt_ChqDate.Format = DateTimePickerFormat.Custom;
            dt_VoucherDate.CustomFormat = Program.DateTimeFormat;
        }
    }
}
