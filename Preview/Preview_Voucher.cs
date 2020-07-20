using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Applied_Accounts.Classes;
using Microsoft.Reporting.WinForms;

namespace Applied_Accounts.Reports
{
    public partial class Preview_Voucher : Form
    {

        ReportClass MyReportClass = new ReportClass();

        public Preview_Voucher()
        {
            InitializeComponent();
        }

        public Preview_Voucher(ReportClass _ReportClass)
        {
            InitializeComponent();
            MyReportClass = _ReportClass;
        }


        private void Preview_Voucher_Load(object sender, EventArgs e)
        {

            string _Filter = string.Concat("Vou_No='", MyReportClass.Vou_No, "'");
            DataTable _DataTable = AppliedTable.GetDBView((int)Tables.View_Voucher, _Filter);

            MyReportClass.Heading1 = string.Concat("Voucher: ", MyReportClass.Vou_No, " | Date: ", MyReportClass.Vou_Date.ToString("dd MMM yyyy"));
            MyReportClass.Heading2 = string.Concat("Date: ", MyReportClass.Vou_Date.ToString("dd MMM yyyy"));

            ReportDataSource _DataSource = new ReportDataSource(MyReportClass.DataSet_Name, _DataTable);
            ReportParameter rpt_Parameter1 = new ReportParameter("CompanyName", MyReportClass.CompanyName);
            ReportParameter rpt_Parameter2 = new ReportParameter("ReportHeading", MyReportClass.Heading1);
            ReportParameter rpt_Parameter3 = new ReportParameter("PeriodHeading", MyReportClass.Heading2);

            rpt_Voucher.LocalReport.DataSources.Clear();
            rpt_Voucher.LocalReport.DataSources.Add(_DataSource);
            rpt_Voucher.LocalReport.SetParameters(rpt_Parameter1);
            rpt_Voucher.LocalReport.SetParameters(rpt_Parameter2);
            rpt_Voucher.LocalReport.SetParameters(rpt_Parameter3);
            rpt_Voucher.RefreshReport();
            
        }
    }
}
