using System;
using System.Data;
using System.Windows.Forms;
using Applied_Accounts.Classes;
using Microsoft.Reporting.WinForms;

namespace Applied_Accounts.Reports
{
    public partial class frmReport_Vouchers : Form
    {

        DataTable MyDataTable { get; set; }
        DataView MyDataView { get; set; }
        ReportClass MyReportClass = new ReportClass();



        public frmReport_Vouchers()
        {
            InitializeComponent();

            txtVouNo.Text = Applied.GetString("rptVou_VouNo");
            dt_From.Value = Applied.GetVouDate("rptVou_DateFrom");
            dt_To.Value = Applied.GetVouDate("rptVou_DateTo");
        }


        private void Report_View_Load(object sender, EventArgs e)
        {

            // Load default values from Applied.


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox _Textbox = (TextBox)sender;

           
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            btnView_Click(sender, e);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            VoucherClass MyVoucherClass = new VoucherClass(txtVouNo.Text.Trim());
            MyVoucherClass.Preview_Voucher();

        }

        private void frmReport_Vouchers_FormClosed(object sender, FormClosedEventArgs e)
        {
            Applied.SetValue("rptVou_VouNo", txtVouNo.Text.Trim(), Applied.KeyType.String);
            Applied.SetValue("rptVou_DateFrom", dt_From.Value, Applied.KeyType.DateTime);
            Applied.SetValue("rptVou_DateTo", dt_To.Value, Applied.KeyType.DateTime);
        }

        private void btnVouchers_Click(object sender, EventArgs e)
        {
            MyReportClass.Report_From = dt_From.Value;
            MyReportClass.Report_To = dt_To.Value;

            string _DataFilter = string.Concat("[Vou_Date]  BETWEEN '", MyReportClass.FilterDate_From(),
                                                             "' AND '", MyReportClass.FilterDate_To(),
                                                             "'");

            VoucherClass MyVoucherClass = new VoucherClass();
            MyVoucherClass.Preview_Voucher(_DataFilter);



        }
    }               // END Main Class
}                   // END Namespace