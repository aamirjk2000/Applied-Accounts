using System;
using System.Data;
using System.Windows.Forms;
using Applied_Accounts.Classes;
using Microsoft.Reporting.WinForms;

namespace Applied_Accounts.Preview
{
    public partial class frmPreview_General_Ledger : Form
    {

        
        public ReportClass MyReportClass = new ReportClass();
        public bool ReportStatus = true;

        #region Initialize

        public frmPreview_General_Ledger()
        {
            InitializeComponent();
        }

        public frmPreview_General_Ledger(ReportClass _ReportClass)
        {
            InitializeComponent();
            MyReportClass = _ReportClass;
        }

        #endregion

        private void Preview_General_Ledger_Load(object sender, EventArgs e)
        {
           PreviewReport();
        }
        private void PreviewReport()
        {

            if (MyReportClass.Report_Data.Count==0)
            {
                MessageBox.Show("No Record Found...");
                return;
            }

            ReportDataSource _DataSource = new ReportDataSource(MyReportClass.DataSet_Name, MyReportClass.Report_Data);
            ReportParameter rpt_Parameter1 = new ReportParameter("CompanyName", MyReportClass.CompanyName);
            ReportParameter rpt_Parameter2 = new ReportParameter("ReportHeading", MyReportClass.Heading1);
            ReportParameter rpt_Parameter3 = new ReportParameter("PeriodHeading", MyReportClass.Heading2);

            rpt_View.LocalReport.DataSources.Clear();                    
            rpt_View.LocalReport.DataSources.Add(_DataSource);          // Insert Data into Report.
            rpt_View.LocalReport.SetParameters(rpt_Parameter1);         // Insert Company Name into Repoer
            rpt_View.LocalReport.SetParameters(rpt_Parameter2);         // Insert Heading into Report.
            rpt_View.LocalReport.SetParameters(rpt_Parameter3);         // Insert Heading into Report.
            rpt_View.RefreshReport();
        }

        private void rpt_View_Load(object sender, EventArgs e)
        {

        }
    }
}
