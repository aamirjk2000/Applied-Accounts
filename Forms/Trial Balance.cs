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
        int Get = 1; int Set = 2;                       // Get or Set default values.

        private ReportClass MyReportClass = new ReportClass();
        private DataTable dt_Supplier = AppliedTable.GetDataTable(Tables.Projects);


        #region

        public frmTrial_Balance()
        {
            InitializeComponent();

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
                cBoxProject.SelectedIndex = Applied.GetInteger("tbal_ProjectID");
            }

            if (_Switch == 2)             // SET
            {
                Applied.SetValue("tbal_From", dt_From.Value, Applied.KeyType.DateTime);
                Applied.SetValue("tbal_To", dt_To.Value, Applied.KeyType.DateTime);
                Applied.SetValue("tbal_ReportFormat", cBoxReportFormat.SelectedIndex, Applied.KeyType.Integer);
                Applied.SetValue("tbal_ProjectID", cBoxProject.SelectedIndex, Applied.KeyType.Integer);
            }
        }

        #endregion

        private void Trial_Balance_Load(object sender, EventArgs e)
        {
            cBoxProject.DataSource = dt_Supplier.AsDataView();
            cBoxProject.ValueMember = "ID";
            cBoxProject.DisplayMember = "Title";

            SetDefault(Get);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            MyReportClass.Report_From = dt_From.Value;
            MyReportClass.Report_To = dt_To.Value;
            MyReportClass.ID_Project = Conversion.ToInteger(cBoxProject.SelectedValue);
            MyReportClass.Title_Project = cBoxProject.Text;


            MyReportClass.DataSource = GetTable_TB(cBoxReportFormat.SelectedIndex);
            MyReportClass.Report_Data = MyReportClass.DataSource.AsDataView();

            MyReportClass.Update_ReportData();
            MyReportClass.Preview();
        }


        #region Generate Reports

        private DataTable GetTable_TB(object _ReportID)
        {
            DataTable _DataTable = new DataTable();
            SQLiteCommand _SQLiteCommand = new SQLiteCommand("", Connection.AppliedConnection());

            switch (_ReportID)
            {
                case (int)ReportID.TrialBalance:

                    _DataTable = AppliedTable.GetDataTable(Tables.View_Trial_Balance);
                    MyReportClass.PreviewForm = Applied.PreviewReports.Trial_Balance;
                    MyReportClass.DataTableID = Tables.View_Trial_Balance;
                    MyReportClass.Report_Location = Program.ReportsPath + "Report_Trial_Balance.rdlc";
                    MyReportClass.DataSet_Name = "ds_Trial_Balance";
                    MyReportClass.ReportView_Filter = "Balance <> 0";
                    MyReportClass.Heading1 = "TRIAL BALANCE (ALL)";
                    MyReportClass.Heading2 = string.Concat("Position as on ", MyReportClass.Report_To.ToString(Program.DateTimeFormat));

                    break;

                case (int)ReportID.TB_Projects:
                    _DataTable = AppliedTable.GetDataTable(Tables.View_TB_Projects);
                    MyReportClass.PreviewForm = Applied.PreviewReports.Trial_Balance;
                    MyReportClass.DataTableID = Tables.View_TB_Projects;
                    MyReportClass.Report_Location = Program.ReportsPath + "Report_TB_Project.rdlc";
                    MyReportClass.DataSet_Name = "ds_TB_Project";
                    MyReportClass.ReportView_Filter = "Balance <> 0 AND Project=" + MyReportClass.ID_Project;
                    MyReportClass.Heading1 = "TRIAL BALANCE | " + MyReportClass.Title_Project;
                    //MyReportClass.Heading2 = string.Concat("Position as on ", MyReportClass.Report_To.ToString(Program.DateTimeFormat));

                    MyReportClass.Heading2 = string.Concat("Position as on ", MyReportClass.Report_To.ToString(MyReportClass.Report_Heading_Format));

                    break;

                case (int)ReportID.TB_Suppliers:
                    _DataTable = AppliedTable.GetDataTable(Tables.View_TB_Project_Supplier);

                    MyReportClass.PreviewForm = Applied.PreviewReports.Trial_Balance;
                    MyReportClass.DataTableID = Tables.View_TB_Project_Supplier;
                    MyReportClass.Report_Location = Program.ReportsPath + "Report_TB_Project_Supplier.rdlc";
                    MyReportClass.DataSet_Name = "ds_TB_Project_Supplier";
                    MyReportClass.ReportView_Filter = "Balance <> 0 AND Project=" + MyReportClass.ID_Project;
                    MyReportClass.Heading1 = "TRIAL BALANCE | " + MyReportClass.Title_Project;
                    MyReportClass.Heading2 = string.Concat("Position as on ", MyReportClass.Report_To.ToString(Program.DateTimeFormat));
                    MyReportClass.ReportView_Sort = "[PROJECT_TITLE],[TITLE],[SUPPLIER_TITLE]";

                    break;

                case (int)ReportID.TB_Periods:

                    _DataTable = AppliedTable.GetTable_TB_period(MyReportClass.Report_From, MyReportClass.Report_To);       // Load Data

                    MyReportClass.PreviewForm = Applied.PreviewReports.Trial_Balance;
                    MyReportClass.DataTableID = Tables.View_TB_Period;
                    MyReportClass.Report_Location = Program.ReportsPath + "Report_Trial_Balance_Period.rdlc";
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
            TrialBalance = 0,
            TB_Periods = 1,
            TB_Suppliers = 2,
            TB_Projects = 3,
            TB_Units = 4,
            TB_Stocks = 5,
            TB_Employees = 6
        }


        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cBoxReportFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxReportFormat.SelectedIndex == (int)ReportID.TB_Projects ||
               cBoxReportFormat.SelectedIndex == (int)ReportID.TB_Suppliers)
            {
                lblProject.Visible = true;
                cBoxProject.Visible = true;
            }
            else
            {
                lblProject.Visible = false;
                cBoxProject.Visible = false;
            }

        }
    }       // END main Class
}           // END Namespace
