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
        public string CompanyName { get; set; }
        public string Heading1 { get; set; }
        public string Heading2 { get; set; }
        public DateTime Report_From { get; set; }
        public DateTime Report_To { get; set; }
        public DataView Report_Data { get; set; }
        public string Report_Path { get; set; }
        public string Report_Filter { get; set; }
        public string DataSet_Name { get; set; }
        public string Vou_No { get; set; }
        public DateTime Vou_Date { get; set; }
        public int ID_COA { get; set; }
        public int ID_Supplier { get; set; }
        public int ID_Project { get; set; }
        public int ID_Unit { get; set; }
        public int ID_Employee { get; set; }
        public object PreviewForm { get; set; }
        public object DataTableID { get; set; }
        public DataTable DataSource { get; set; }
        public string DataSource_Filter { get; set; }
        public string ReportView_Filter { get; set; }
        public string ReportView_Sort { get; set; }
        public string Report_Location { get; set; }

        //======================================
        public ReportClass()
        {
            CompanyName = Applied.GetString("Company");
        }
        //=====================================

        public void Preview()
        {

            Form _PreviewForm =  new Preview.frmPreview_Reports(this);

            Report_Data.Sort = ReportView_Sort;

            if (_PreviewForm == null) { MessageBox.Show("Report Name is not valid.", "ERROR"); return; }          // Return if report object not load poperly.

            if (Report_Data.Count>0)
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
            if(DataSource!=null)
            {
                if(DataSource.Rows.Count>0)
                {
                    Report_Data = DataSource.AsDataView();
                    Report_Data.RowFilter = ReportView_Filter;
                    Report_Data.Sort = ReportView_Sort;
                }
            }
            
        }
        public int Count()                               // Count Table Row
        {
            if(DataSource==null)
            {
                return Report_Data.Count;
            }
            return 0;
        }
    }
}
