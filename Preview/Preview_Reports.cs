using Applied_Accounts.Classes;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace Applied_Accounts.Preview
{
    public partial class frmPreview_Reports : Form
    {
        public ReportClass MyReportClass = new ReportClass();
        public bool ReportStatus = true;


        public frmPreview_Reports()
        {
            InitializeComponent();
        }

        public frmPreview_Reports(ReportClass _ReportClass)
        {
            InitializeComponent();
            MyReportClass = _ReportClass;
            rpt_View.LocalReport.ReportEmbeddedResource = MyReportClass.Report_Location;

            if(MyReportClass.Report_Location.Length==0)
            {
                MessageBox.Show("Report is not specifying here", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }


        private void Preview_Reports_Load(object sender, EventArgs e)
        {
            PreviewReport();
        }

        private void PreviewReport()
        {

            if (MyReportClass.Report_Data.Count == 0)
            {
                MessageBox.Show("No Record Found...");
                return;
            }

            ReportDataSource _DataSource = new ReportDataSource(MyReportClass.DataSet_Name, MyReportClass.Report_Data);
            rpt_View.LocalReport.DataSources.Clear();
            rpt_View.LocalReport.DataSources.Add(_DataSource);          // Insert Data into Report.

            ReportParameter rpt_Parameter1 = new ReportParameter("CompanyName", MyReportClass.CompanyName);
            ReportParameter rpt_Parameter2 = new ReportParameter("ReportHeading", MyReportClass.Heading1);
            ReportParameter rpt_Parameter3 = new ReportParameter("PeriodHeading", MyReportClass.Heading2);
            ReportParameter rpt_Parameter4 = new ReportParameter("DevelopedBy", Program.Developedby);
            ReportParameter rpt_Parameter5 = new ReportParameter("DateFormat", Program.DateTimeFormat);

            rpt_View.LocalReport.SetParameters(rpt_Parameter1);         // Insert Company Name into Repoer
            rpt_View.LocalReport.SetParameters(rpt_Parameter2);         // Insert Heading 1 into Report.
            rpt_View.LocalReport.SetParameters(rpt_Parameter3);         // Insert Heading 2 into Report.
            rpt_View.LocalReport.SetParameters(rpt_Parameter4);         // Insert Developedby.
            rpt_View.LocalReport.SetParameters(rpt_Parameter5);         // Insert Date Time Foramt.

            rpt_View.RefreshReport();
        }
    }           // END main Class
}               // END NameSpace
