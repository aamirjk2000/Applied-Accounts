using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Applied_Accounts.Classes;
using Applied_Accounts.Data;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

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
        }

        public frmReport_Vouchers(ReportClass _ReportClass)
        {
            InitializeComponent();
            MyReportClass = _ReportClass;
        }


        private void Report_View_Load(object sender, EventArgs e)
        {

            MyDataTable = AppliedTable.GetDataTable((int)Tables.View_Voucher);
            MyDataView = new DataView(MyDataTable);
            MyDataView.RowFilter = string.Concat("Vou_No='Jxx-xxx'");

            MyReportClass.Heading1 = "V O U C H E R   ";
            MyReportClass.Report_Path = rpt_Voucher.LocalReport.ReportPath;
            MyReportClass.DataSet_Name = "ds_Voucher_Report";
            MyReportClass.Report_Data = MyDataView;


            // Load default values from Applied.
            txtVouNo.Text = Applied.GetString("rptVou_VouNo");
            dt_From.Value = Applied.GetDate("rptVou_DateFrom");
            dt_To.Value = Applied.GetDate("rptVou_DateTo");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox _Textbox = (TextBox)sender;

            MyDataView.RowFilter = string.Concat("Vou_No='Jxx-xxx'");

            if (_Textbox.TextLength > 0) 
            {
                MyDataView.RowFilter = string.Concat("Vou_No='", _Textbox.Text.Trim(), "'");

                if(MyDataView.Count>0)
                { MyReportClass.Report_From = Conversion.ToDate(MyDataView[0].Row["Vou_Date"].ToString()); }
                
            }
            else
            {
                MyDataView.RowFilter = string.Concat("Vou_No='Jxx-xxx'");
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            btnView_Click(sender,e);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            MyReportClass.Heading1 = string.Concat("Voucher: ", txtVouNo.Text," | ", "Date: ", MyReportClass.  Report_From.ToString("dd MMM yyyy"));
            MyReportClass.Heading2 = string.Empty;

            ReportDataSource _DataSource = new ReportDataSource(MyReportClass.DataSet_Name, MyReportClass.Report_Data);
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

        private void frmReport_Vouchers_FormClosed(object sender, FormClosedEventArgs e)
        {
            Applied.SetValue("rptVou_VouNo", txtVouNo.Text.Trim(), Applied.KeyType.String);
            Applied.SetValue("rptVou_DateFrom", dt_From.Value, Applied.KeyType.DateTime);
            Applied.SetValue("rptVou_DateTo", dt_To.Value, Applied.KeyType.DateTime);
        }

        private void btnVouchers_Click(object sender, EventArgs e)
        {
            MyReportClass.Heading1 = string.Concat("Vouchers From ",MyReportClass.Report_From.ToString("dd MMM yyyy"),
                                                   " to ", MyReportClass.Report_To.ToString("dd MMM yyyy"));
            MyReportClass.Heading2 = string.Empty;
            MyReportClass.Report_From = dt_From.Value;
            MyReportClass.Report_To = dt_To.Value;
            MyReportClass.DataTableID = Tables.View_Voucher;

            MyReportClass.DataSource_Filter = string.Concat("[Vou_Date]  BETWEEN '", MyReportClass.FilterDate_From(),
                                                            "' AND '", MyReportClass.FilterDate_To(), "'");
            

            MyReportClass.Update_SourceData();
            


            ReportDataSource _DataSource = new ReportDataSource(MyReportClass.DataSet_Name, MyReportClass.DataSource);
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
    }               // END Main Class
}                   // END Namespace