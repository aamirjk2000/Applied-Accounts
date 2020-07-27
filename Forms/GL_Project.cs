using Applied_Accounts.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applied_Accounts.Forms
{
    public partial class frmGL_Project : Form
    {
        private DataTable dt_Suppliers;
        private DataTable dt_COA;
        private DataTable dt_Projects;
        private DataTable dt_Units;
        private ReportClass MyReportClass = new ReportClass();

        private string ReportLocation;
        private string ReportLocation_Supplier;
        private string ReportLocation_Account;
        private string ReportLocation_Unit;


        public frmGL_Project()
        {
            InitializeComponent();

            dt_Suppliers = AppliedTable.GetDataTable(Tables.Suppliers);
            dt_COA = AppliedTable.GetDataTable(Tables.COA);
            dt_Projects = AppliedTable.GetDataTable(Tables.Projects);
            dt_Units = AppliedTable.GetDataTable(Tables.Units);

            cBoxSuppliers.DataSource = dt_Suppliers;
            cBoxSuppliers.DisplayMember = "Title";
            cBoxSuppliers.ValueMember = "ID";

            cBoxProjects.DataSource = dt_Projects;
            cBoxProjects.DisplayMember = "Title";
            cBoxProjects.ValueMember = "ID";

            cBoxCOA.DataSource = dt_COA;
            cBoxCOA.DisplayMember = "Title";
            cBoxCOA.ValueMember = "ID";

            cBoxUnits.DataSource = dt_Units;
            cBoxUnits.DisplayMember = "Title";
            cBoxUnits.ValueMember = "ID";

            cBoxReportFormat.SelectedIndex = 0;

            ReportLocation = "Applied_Accounts.Reports.Report_GL_Projects.rdlc";
            ReportLocation_Supplier = "Applied_Accounts.Reports.Report_GL_Projects_Supplier.rdlc";
            ReportLocation_Account = "Applied_Accounts.Reports.Report_GL_Projects_Account.rdlc"; ;
            ReportLocation_Unit = "Applied_Accounts.Reports.Report_GL_Projects_Unit.rdlc"; ;

            MyReportClass.Report_Location = ReportLocation;                 // Default reprot Location

        }

        private void GL_Project_Load(object sender, EventArgs e)
        {
            cBoxProjects.SelectedValue = Applied.GetInteger("rptGLPro_Project");
            cBoxSuppliers.SelectedValue = Applied.GetInteger("rptGLPro_Supplier");
            cBoxCOA.SelectedValue = Applied.GetInteger("rptGLPro_COA");
            cBoxUnits.SelectedValue = Applied.GetInteger("rptGLPro_Unit");
            cBoxReportFormat.SelectedIndex = Applied.GetInteger("rptGLPro_Format");

            dt_From.Value = Applied.GetDate("rptGLPro_From");
            dt_To.Value = Applied.GetDate("rptGLPro_To");


            chkCOA.Checked = Applied.GetBoolean("rptGLPro_chkCOA");
            chkSuppliers.Checked = Applied.GetBoolean("rptGLPro_chkSupplier");
            chkUnits.Checked = Applied.GetBoolean("rptGLPro_chkUnit");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            MyReportClass.ID_Supplier = Conversion.ToInteger(cBoxSuppliers.SelectedValue);
            MyReportClass.ID_COA = Conversion.ToInteger(cBoxCOA.SelectedValue);
            MyReportClass.ID_Project = Conversion.ToInteger(cBoxProjects.SelectedValue);
            MyReportClass.ID_Unit = Conversion.ToInteger(cBoxUnits.SelectedValue);
            MyReportClass.Report_From = dt_From.Value;
            MyReportClass.Report_To = dt_To.Value;
            MyReportClass.PreviewForm = Applied.PreviewReports.Project_Ledger;
            MyReportClass.DataTableID = Tables.View_Project_Ledger;
            MyReportClass.DataSet_Name = "ds_Project_Ledger";
            MyReportClass.Heading1 = "Project Ledger | " + cBoxProjects.Text;
            MyReportClass.Heading2 = string.Concat("Report from ", MyReportClass.FilterDate_From(), " to ", MyReportClass.FilterDate_To());

            #region Load Source Data

            string SourceFilter = string.Concat("Project=", MyReportClass.ID_Project);
            SourceFilter += string.Concat(" AND [Vou_Date] BETWEEN '", MyReportClass.FilterDate_From(), "' AND '", MyReportClass.FilterDate_To() + "'");
            MyReportClass.DataSource_Filter = SourceFilter;                 // Filter for Data Source Table
            MyReportClass.Update_SourceData();                              // Load Source Data
            AddOpeningBalances();                                           // Add records for openign Balcnes

            #endregion

            string ReportFilter = string.Concat("[Project]=",cBoxProjects.SelectedValue.ToString()) ;
            if (chkCOA.Checked) { ReportFilter += string.Concat(" AND COA=", MyReportClass.ID_COA); }
            if (chkSuppliers.Checked) { ReportFilter += string.Concat(" AND Supplier=", MyReportClass.ID_Supplier); }
            if (chkUnits.Checked) { ReportFilter += string.Concat(" AND Unit=", MyReportClass.ID_Unit); }
            MyReportClass.ReportView_Filter = ReportFilter;
            MyReportClass.ReportView_Sort = "[Project],[Supplier],[COA],[Vou_Date],[Unit]";
            MyReportClass.Update_ReportData();
            MyReportClass.Preview();                                    // Preview Report
        }

        private void AddOpeningBalances()
        {
            //=================================== CALCULATE OPENING BALANCE

            string _OBalCommand = string.Concat(
                "SELECT [Project],[Supplier],[COA],[Unit],SUM([DR]-[CR]) AS [AMOUNT] FROM [View_Project_Ledger] ",
                "WHERE [Supplier]=", MyReportClass.ID_Supplier.ToString(), " AND [Vou_Date] < '",
                 Conversion.ToReportDate(MyReportClass.Report_From), "' GROUP BY [Project],[Supplier],[COA],[Unit]");
            DataTable _OBalTable = AppliedTable.GetDataTable(_OBalCommand);

            if (_OBalTable.Rows.Count > 0)
            {
                foreach (DataRow _Row in _OBalTable.Rows)
                {

                    DataRow _TargetRow = MyReportClass.DataSource.NewRow();

                    _TargetRow["Vou_No"] = "Opening";
                    _TargetRow["Vou_Date"] = MyReportClass.Report_From.AddDays(-1);


                    _TargetRow["Project"] = _Row["Project"];
                    _TargetRow["Project_Title"] = AppliedTable.GetTitle(Conversion.ToInteger(_Row["Project"]), dt_Suppliers);

                    _TargetRow["Supplier"] = _Row["Supplier"];
                    _TargetRow["Supplier_Title"] = AppliedTable.GetTitle(Conversion.ToInteger(_Row["Supplier"]), dt_Suppliers);

                    _TargetRow["COA"] = _Row["COA"];
                    _TargetRow["COA_Title"] = AppliedTable.GetTitle(Conversion.ToInteger(_Row["COA"]), dt_Suppliers);

                    _TargetRow["Unit"] = _Row["Unit"];
                    _TargetRow["Unit_title"] = AppliedTable.GetTitle(Conversion.ToInteger(_Row["Unit"]), dt_Suppliers);

                    if ((long)_Row["Amount"] > 0)
                    {
                        _TargetRow["DR"] = (long)_Row["Amount"];
                        _TargetRow["CR"] = 0;
                    }
                    else
                    {
                        _TargetRow["DR"] = 0;
                        _TargetRow["CR"] = (long)_Row["Amount"] * -1;
                    }

                    _TargetRow["Description"] = "B/F " + _TargetRow["Project_Title"];

                    MyReportClass.DataSource.Rows.InsertAt(_TargetRow, 0);
                }

                MyReportClass.Report_Data = MyReportClass.DataSource.AsDataView();
            }
        }

        private void frmGL_Project_FormClosed(object sender, FormClosedEventArgs e)
        {
            Applied.SetValue("rptGLPro_Supplier", cBoxSuppliers.SelectedValue, Applied.KeyType.Integer);
            Applied.SetValue("rptGLPro_COA", cBoxCOA.SelectedValue, Applied.KeyType.Integer);
            Applied.SetValue("rptGLPro_Project", cBoxProjects.SelectedValue, Applied.KeyType.Integer);
            Applied.SetValue("rptGLPro_Unit", cBoxUnits.SelectedValue, Applied.KeyType.Integer);
            Applied.SetValue("rptGLPro_Format", cBoxReportFormat.SelectedIndex, Applied.KeyType.Integer);
            
            Applied.SetValue("rptGLPro_From", dt_From.Value, Applied.KeyType.DateTime);
            Applied.SetValue("rptGLPro_To", dt_To.Value, Applied.KeyType.DateTime);
            
            Applied.SetValue("rptGLPro_chkSupplier", chkSuppliers.Checked, Applied.KeyType.Boolean);
            Applied.SetValue("rptGLPro_chkCOA", chkCOA.Checked, Applied.KeyType.Boolean);
            Applied.SetValue("rptGLPro_chkUnit", chkUnits.Checked, Applied.KeyType.Boolean);
        }

        private void cBoxReportFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ReportID = cBoxReportFormat.SelectedIndex;


            switch (ReportID)
            {
                case 0:
                    MyReportClass.Report_Location = ReportLocation;
                    break;

                case 1:
                    MyReportClass.Report_Location = ReportLocation_Supplier;
                    break;

                case 2:
                    MyReportClass.Report_Location = ReportLocation_Account;
                    break;

                case 3:
                    MyReportClass.Report_Location = ReportLocation_Unit;
                    break;

                default:
                    MyReportClass.Report_Location = ReportLocation;
                    break;
            }
        }

        //END
    }           
}
