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
using Applied_Accounts.Reports;

namespace Applied_Accounts.Forms
{
    public partial class frmGeneral_Ledger : Form
    {
        public frmGeneral_Ledger()
        {
            InitializeComponent();

            cBoxCOA.DataSource = dt_COA;
            cBoxCOA.DisplayMember = "Title";
            cBoxCOA.ValueMember = "ID";

        }

        ReportClass MyReportClass = new ReportClass();
        DataTable dt_COA = AppliedTable.GetDataTable((int)Tables.COA);



        private void frmGeneral_Ledger_Load(object sender, EventArgs e)
        {

            cBoxCOA.SelectedValue = Applied.GetInteger("rptGL_COA");
            dt_From.Value = Applied.GetDate("rptGL_dtFrom");
            dt_To.Value = Applied.GetDate("rptGL_dtTo");

        }
       

        private void btnBrowseSupplier_Click(object sender, EventArgs e)
        {
            cBoxCOA.SelectedValue = Applied.ShowBrowseWin(dt_COA, cBoxCOA.SelectedValue);
        }


        private DataView LoadData()
        {
            //=================================== CALCULATE OPENING BALANCE

            string _OBalCommand = string.Concat(
                "SELECT SUM([DR]-[CR]) AS [AMOUNT] FROM [View_General_Ledger] ",
                "WHERE [COA]=", MyReportClass.ID_COA.ToString(), " AND DATE([Vou_Date]) < '",
                 Conversion.ToReportDate(MyReportClass.Report_From), "' GROUP BY [COA]");
            DataTable _OBalTable = AppliedTable.GetDataTable(_OBalCommand);

            //========================= LOAD PREVIEW DATE

            MyReportClass.DataSource_Filter = string.Concat("COA=", MyReportClass.ID_COA.ToString(), " AND DATE([Vou_Date]) BETWEEN '",
                                                                  Conversion.ToReportDate(MyReportClass.Report_From), "' AND '",
                                                                  Conversion.ToReportDate(MyReportClass.Report_To)) + "'";

            DataTable _DataTable = AppliedTable.GetDataTable(Tables.View_General_Ledger, MyReportClass.DataSource_Filter);

            if (_OBalTable.Rows.Count > 0)
            {
                DataRow _Row = _DataTable.NewRow();
                _Row["Vou_No"] = 0;
                _Row["Vou_Date"] = MyReportClass.Report_From.AddDays(-1).ToString(Program.DateTimeFormat);
                _Row["Description"] = "Opening Balacne ";
                _Row["COA"] = cBoxCOA.SelectedValue;   //_DataTable.Rows[0]["COA"];
                _Row["COA_Title"] = cBoxCOA.Text;      //_DataTable.Rows[0]["COA_Title"];

                if ((double)_OBalTable.Rows[0]["Amount"] > 0)
                {
                    _Row["DR"] = (double)_OBalTable.Rows[0]["Amount"];
                    _Row["CR"] = 0;
                }
                else
                {
                    _Row["DR"] = 0;
                    _Row["CR"] = (double)_OBalTable.Rows[0]["Amount"] * -1;
                }

                _DataTable.Rows.InsertAt(_Row, 0);

            }

            return _DataTable.AsDataView();
        }


        private void frmGeneral_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            Applied.SetValue("rptGL_dtFrom", dt_From.Value, Applied.KeyType.DateTime);
            Applied.SetValue("rptGL_dtTo", dt_To.Value, Applied.KeyType.DateTime);
            Applied.SetValue("rptGL_COA", cBoxCOA.SelectedValue, Applied.KeyType.Integer);

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPreview_Click_1(object sender, EventArgs e)
        {
            MyReportClass.ID_COA = Conversion.ToInteger(cBoxCOA.SelectedValue);
            MyReportClass.Report_From = dt_From.Value;
            MyReportClass.Report_To = dt_To.Value;
            MyReportClass.PreviewForm = Applied.PreviewReports.Preview_Report;


            MyReportClass.Report_Data = LoadData();                     // Gather Data for report preview from Database Tables.
            string COA_Title = "";

            if (MyReportClass.Report_Data.Count > 0)
            {

                COA_Title = MyReportClass.Report_Data[0]["COA_Title"].ToString();
                MyReportClass.Heading1 = string.Concat("General Ledger | ", COA_Title, " (", MyReportClass.ID_COA, ")");
                MyReportClass.Heading2 = string.Concat("Period from ", dt_From.Value.ToString("d"), " to ", dt_To.Value.ToString("d"));
                MyReportClass.DataSet_Name = "ds_General_Ledger";
                MyReportClass.Report_Location = "Applied_Accounts.Reports.Report_General_Ledger.rdlc";
                MyReportClass.ReportView_Sort = "[Vou_Date],[Vou_No]";
                MyReportClass.Preview();
              
            }
        }
    }
}
