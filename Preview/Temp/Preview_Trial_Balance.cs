using Applied_Accounts.Classes;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applied_Accounts.Preview
{
    public partial class frmPreview_Trial_Balance : Form
    {

        public ReportClass MyReportClass = new ReportClass();
        public bool ReportStatus = true;


        public frmPreview_Trial_Balance()
        {
            InitializeComponent();
        }

        public frmPreview_Trial_Balance(ReportClass _ReportClass)
        {
            InitializeComponent();
            MyReportClass = _ReportClass;
            rpt_View.LocalReport.ReportEmbeddedResource = MyReportClass.Report_Location;

            if(MyReportClass.Report_Location==string.Empty)
            {
                MessageBox.Show("No report name specify", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Preview_Trial_Balance_Load(object sender, EventArgs e)
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
            ReportParameter rpt_Parameter1 = new ReportParameter("CompanyName", MyReportClass.CompanyName);
            ReportParameter rpt_Parameter2 = new ReportParameter("ReportHeading", MyReportClass.Heading1);
            ReportParameter rpt_Parameter3 = new ReportParameter("PeriodHeading", MyReportClass.Heading2);
            ReportParameter rpt_Parameter4 = new ReportParameter("DevelopedBy", Program.Developedby);
            


            rpt_View.LocalReport.DataSources.Clear();
            
            rpt_View.LocalReport.DataSources.Add(_DataSource);          // Insert Data into Report.
            rpt_View.LocalReport.SetParameters(rpt_Parameter1);         // Insert Company Name into Repoer
            rpt_View.LocalReport.SetParameters(rpt_Parameter2);         // Insert Heading into Report.
            rpt_View.LocalReport.SetParameters(rpt_Parameter3);         
            rpt_View.LocalReport.SetParameters(rpt_Parameter4);
            rpt_View.RefreshReport();
        }



    }
}
