using System;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SQLite.Linq;

namespace Applied_Accounts.Classes
{
    interface IReportClass
    {
        void Preview();
        string FilterDate_From();
        string FilterDate_To();
        void Update_SourceData();
        void Update_ReportData();
        int Count();
    }

    public class ReportClass : IReportClass
    {
        public string CompanyName { get; set; }                                                     // Company Name for report heading
        public string Heading1 { get; set; }                                                        // Main Heading / Report Heading
        public string Heading2 { get; set; }                                                        // Sub Heading for Period
        public DateTime Report_From { get; set; }                                                   // Report start from this date
        public DateTime Report_To { get; set; }                                                     // Report end on this date
        public DataView Report_Data { get; set; }                                                   // Report printed on this date 
        public string Report_Date_Format { get => Applied.GetString("DateFormat_Report"); }         // Date format for the report date column
        public string Report_Heading_Format { get => Applied.GetString("DateFormat_Heading"); }     // Date print in this format for sub Heading
        public string Report_Filter { get; set; }                                                   // filter for the report data
        public string DataSet_Name { get; set; }                                                    // Name of the Database
        public string Vou_No { get; set; }                                                          // Voucher no 
        public DateTime Vou_Date { get; set; }                                                      // voucher Date
        public int ID_COA { get; set; }                                                             // ID for chart of accounts
        public int ID_Supplier { get; set; }                                                        // ID for Supplier
        public int ID_Project { get; set; }                                                         // ID for Project
        public int ID_Unit { get; set; }                                                            // ID for unit
        public int ID_Employee { get; set; }                                                        // ID for Employee
        public object PreviewForm { get; set; }                                                     // Report Name (.rdl File with Path)
        public object DataTableID { get; set; }                                                     // Database (Table) ID
        public DataTable DataSource { get; set; }                                                   // Date source in DataTable
        public string DataSource_Filter { get; set; }                                               // Filter for DataSource
        public string ReportView_Filter { get; set; }                                               // Report View Filter
        public string ReportView_Sort { get; set; }                                                 // sort Order for report.
        public string Report_Location { get; set; }                                                 // Report Location 

        public string Title_COA { get; set; }                                                      // Title of Chart of Accounts
        public string Title_Supplier { get; set; }                                                  // Title of Supplier
        public string Title_Project { get; set; }                                                   // Title of Project
        public string Title_Unit { get; set; }                                                      // Title of unit
        public string Title_Employee { get; set; }                                                  // Title of Employee



        //======================================
        public ReportClass()
        {
            CompanyName = Applied.GetString("Company");
        }
        //=====================================

        public void Preview()
        {

            Form _PreviewForm = new Preview.frmPreview_Reports(this);

            if (Report_Data == null)
            {
                MessageBox.Show("Report data is null", "Report_Data==null");
                return;
            }


            Report_Data.Sort = ReportView_Sort;

            if (_PreviewForm == null) { MessageBox.Show("Report Name is not valid.", "_PreviewForm"); return; }          // Return if report object not load poperly.

            if (Report_Data.Count > 0)
            {

                _PreviewForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No records to preview.", _PreviewForm.Text);
            }
        }
        public string FilterDate_From()
        {
            return Conversion.ToReportDate(Report_From);
        }
        public string FilterDate_To()
        {
            return Conversion.ToReportDate(Report_To);
        }
        public void Update_SourceData()
        {
            if (DataSource_Filter == string.Empty)
            { DataSource = AppliedTable.GetDataTable(DataTableID); }
            else
            { DataSource = AppliedTable.GetDataTable(DataTableID, DataSource_Filter); }
        }
        public void Update_ReportData()
        {
            if (DataSource != null)
            {
                if (DataSource.Rows.Count > 0)
                {
                    Report_Data = DataSource.AsDataView();
                    Report_Data.RowFilter = ReportView_Filter;
                    Report_Data.Sort = ReportView_Sort;
                }
            }

        }
        public int Count()                               // Count Table Row
        {
            if (DataSource == null)
            {
                return Report_Data.Count;
            }
            return 0;
        }

        public string Min(string _Column)
        {
            if (Report_Data.Count > 0)
            { return Report_Data.ToTable().Compute("Min(" + _Column + ")", string.Empty).ToString(); }
            return "";

        }

        public string Max(string _Column)
        {
            if (Report_Data.Count > 0)
            { return Report_Data.ToTable().Compute("Max(" + _Column + ")", string.Empty).ToString(); }
            return "";

        }
        
    }
}
