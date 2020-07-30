using Applied_Accounts.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applied_Accounts.Forms
{
    public partial class frmTrial_Balance : Form
    {
        int Get = 1; int Set = 2;

        ReportClass MyReportClass = new ReportClass();


        #region

        public frmTrial_Balance()
        {
            InitializeComponent();
            SetDefault(Get);
        }

        #endregion

        #region Default Values

        private void frmTrial_Balance_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetDefault(Set);
        }

        private void SetDefault(int _Switch)
        {
            if (_Switch == 1)              // GET
            {
                dt_From.Value = Applied.GetDate("tbal_From");
                dt_To.Value = Applied.GetDate("tbal_To");
                cBoxReportFormat.SelectedIndex = Applied.GetInteger("tbal_ReportFormat");
            }

            if (_Switch == 2)             // SET
            {
                Applied.SetValue("tbal_From", dt_From.Value, Applied.KeyType.DateTime);
                Applied.SetValue("tbal_To", dt_To.Value, Applied.KeyType.DateTime);
                Applied.SetValue("tbal_ReportFormat", cBoxReportFormat.SelectedIndex, Applied.KeyType.Integer);
            }
        }

        #endregion

        private void Trial_Balance_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            MyReportClass.Report_From = dt_From.Value;
            MyReportClass.Report_To = dt_To.Value;

            MyReportClass.DataSource = GetTable_TB(cBoxReportFormat.SelectedIndex);
            MyReportClass.Report_Data = MyReportClass.DataSource.AsDataView();

            MyReportClass.Heading1 = "TRIAL BALANCE";
            
            
            MyReportClass.Update_ReportData();
            MyReportClass.Preview();
        }


        #region SQLite Command

        private DataTable GetTable_TB(object _ReportID)
        {
            DataTable _DataTable = new DataTable();
            SQLiteCommand _SQLiteCommand = new SQLiteCommand("",Connection.AppliedConnection());

            switch (_ReportID)
            {
                case (int)ReportID.TrialBalance:

                    _SQLiteCommand.CommandText
                    = "SELECT [COA], [Code], [COA].[TITLE], " +
                      "ROUND(SUM(DR), 0) AS[Debit], " +
                      "ROUND(SUM(CR), 0) AS[Credit], " +
                      "ROUND(SUM(DR - CR), 0) AS[Balance] " +
                      "FROM Ledger " +
                      "LEFT JOIN COA ON [COA].[ID] = [Ledger].[COA] "+
                      "WHERE [Vou_Date] <= '@To' " +
                      "GROUP BY [COA];";

                    _SQLiteCommand.Parameters.AddWithValue("@To", MyReportClass.FilterDate_To());

                    _DataTable = AppliedTable.GetDataTable(_SQLiteCommand);
                    MyReportClass.PreviewForm = Applied.PreviewReports.Trial_Balance;
                    MyReportClass.DataTableID = Tables.View_Trial_Balance;
                    MyReportClass.Report_Location = Program.ReportFolder + "Report_Trial_Balance.rdlc";
                    MyReportClass.DataSet_Name = "ds_Trial_Balance";
                    MyReportClass.ReportView_Filter = "Balance <> 0";
                    MyReportClass.Heading2 = string.Concat("Position as on ", MyReportClass.Report_To.ToString(Program.DateTimeFormat));

                    break;

                case (int)ReportID.TB_Periods:

                    _DataTable = AppliedTable.GetTable_TB_period(MyReportClass.Report_From, MyReportClass.Report_To);       // Load Data
 
                    MyReportClass.PreviewForm = Applied.PreviewReports.Trial_Balance;
                    MyReportClass.DataTableID = Tables.View_TB_Period;
                    MyReportClass.Report_Location = Program.ReportFolder + "Report_Trial_Balance_Period.rdlc";
                    MyReportClass.DataSet_Name = "ds_Trial_Balance_Period";
                    MyReportClass.ReportView_Filter = string.Empty;
                    MyReportClass.Heading2 = string.Concat("Position " +
                                  "From ", Conversion.ToPrintDate(MyReportClass.Report_From),
                                  " To ", Conversion.ToPrintDate(MyReportClass.Report_To));

                    break;

                default:
                    break;
            }



            return _DataTable;
        }

        enum ReportID
        {
            TrialBalance =0,
            TB_Periods=1,
            TB_Suppliers=2,
            TB_Projects=3,
            TB_Units=4,
            TB_Stocks=5,
            TB_Employees=6
        }


        #endregion



        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }       // END main Class
}           // END Namespace
