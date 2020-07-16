using Applied_Accounts.Classes;
using Applied_Accounts.Reports;
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
    public partial class frmGL_Supplier : Form
    {

        private DataTable dt_Suppliers;
        private DataTable dt_COA;
        private DataTable dt_Projects;
        private DataTable dt_Units;
        private ReportClass MyReportClass = new ReportClass();


        public frmGL_Supplier()
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

        }

        private void frmGL_Supplier_Load(object sender, EventArgs e)
        {
            cBoxSuppliers.SelectedValue = Applied.GetInteger("rptGLSup_Supplier");
            cBoxCOA.SelectedValue = Applied.GetInteger("rptGLSup_COA");
            cBoxProjects.SelectedValue = Applied.GetInteger("rptGLSup_Project");
            cBoxUnits.SelectedValue = Applied.GetInteger("rptGLSup_Unit");

            dt_From.Value = Applied.GetDate("rptGLSup_From");
            dt_To.Value = Applied.GetDate("rptGLSup_To");

            chkCOA.Checked = Applied.GetBoolean("rptGLSup_chkCOA");
            chkProject.Checked = Applied.GetBoolean("rptGLSup_chkProject");
            chkUnit.Checked = Applied.GetBoolean("rptGLSup_chkUnit");
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            MyReportClass.ID_Supplier = Conversion.ToInteger(cBoxSuppliers.SelectedValue);
            MyReportClass.ID_COA = Conversion.ToInteger(cBoxCOA.SelectedValue);
            MyReportClass.ID_Project = Conversion.ToInteger(cBoxProjects.SelectedValue);
            MyReportClass.ID_Unit = Conversion.ToInteger(cBoxUnits.SelectedValue);
            MyReportClass.Report_From = dt_From.Value;
            MyReportClass.Report_To = dt_To.Value;
            MyReportClass.PreviewForm = Applied.PreviewReports.Supplier_Ledger;
            MyReportClass.DataTableID = Tables.View_Supplier_Ledger;
            MyReportClass.DataSet_Name = "ds_GL_Supplier";                
            MyReportClass.Heading1 = "Supplier Ledger | " + cBoxSuppliers.Text;
            MyReportClass.Heading2 = string.Concat("Report from ",MyReportClass.FilterDate_From(), " to ",MyReportClass.FilterDate_To());

            #region Load Source Data

            string SourceFilter = string.Concat("Supplier=", MyReportClass.ID_Supplier);
            SourceFilter += string.Concat(" AND [Vou_Date] BETWEEN '",MyReportClass.FilterDate_From(), "' AND '",MyReportClass.FilterDate_To() + "'");
            MyReportClass.DataSource_Filter = SourceFilter;                 // Filter for Data Source Table
            MyReportClass.Update_SourceData();                              // Load Source Data
            AddOpeningBalances();                                           // Add records for openign Balcnes

            #endregion

            string ReportFilter = "";
            if (chkCOA.Checked) { ReportFilter += string.Concat("COA=", MyReportClass.ID_COA); }
            if (chkProject.Checked) { ReportFilter += string.Concat(" AND Project=", MyReportClass.ID_COA); }
            if (chkUnit.Checked) { ReportFilter += string.Concat(" AND Unit=", MyReportClass.ID_COA); }
            MyReportClass.ReportView_Filter = ReportFilter;
            MyReportClass.ReportView_Sort = "[Supplier],[COA],[Vou_Date],[Project],[Unit]";
            MyReportClass.Update_ReportData();
            MyReportClass.Preview();                                    // Preview Report
        }


        private void AddOpeningBalances()
        {
            //=================================== CALCULATE OPENING BALANCE

            string _OBalCommand = string.Concat(
                "SELECT [Supplier],[COA],[Project],[Unit],SUM([DR]-[CR]) AS [AMOUNT] FROM [View_Supplier_Ledger] ",
                "WHERE [Supplier]=", MyReportClass.ID_Supplier.ToString(), " AND [Vou_Date] < '",
                 Conversion.ToReportDate(MyReportClass.Report_From), "' GROUP BY [Supplier],[COA],[Project],[Unit]");
            DataTable _OBalTable = AppliedTable.GetDataTable(_OBalCommand);

            if (_OBalTable.Rows.Count > 0)
            {
                foreach(DataRow _Row in _OBalTable.Rows)
                {

                    DataRow _TargetRow = MyReportClass.DataSource.NewRow();

                    _TargetRow["Vou_No"] = "Opening";
                    _TargetRow["Vou_Date"] = MyReportClass.Report_From.AddDays(-1);
                    

                    _TargetRow["COA"] = _Row["COA"];
                    _TargetRow["COA_Title"] = AppliedTable.GetTitle(Conversion.ToInteger(_Row["COA"]), dt_Suppliers);

                    _TargetRow["Supplier"] = _Row["Supplier"];
                    _TargetRow["Supplier_Title"] = AppliedTable.GetTitle(Conversion.ToInteger(_Row["Supplier"]),dt_Suppliers);

                    _TargetRow["Project"] = _Row["Project"];
                    _TargetRow["Project_Title"] = AppliedTable.GetTitle(Conversion.ToInteger(_Row["Project"]), dt_Suppliers);

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

            //return MyReportClass.Report_Data.ToTable().AsDataView();
        }


        private void frmGL_Supplier_FormClosed(object sender, FormClosedEventArgs e)
        {
            Applied.SetValue("rptGLSup_Supplier", cBoxSuppliers.SelectedValue, Applied.KeyType.Integer);
            Applied.SetValue("rptGLSup_COA", cBoxCOA.SelectedValue, Applied.KeyType.Integer);
            Applied.SetValue("rptGLSup_Project", cBoxProjects.SelectedValue, Applied.KeyType.Integer);
            Applied.SetValue("rptGLSup_Unit", cBoxUnits.SelectedValue, Applied.KeyType.Integer);
            Applied.SetValue("rptGLSup_From", dt_From.Value, Applied.KeyType.DateTime);
            Applied.SetValue("rptGLSup_To", dt_To.Value, Applied.KeyType.DateTime);
            Applied.SetValue("rptGLSup_chkCOA", chkCOA.Checked, Applied.KeyType.Boolean);
            Applied.SetValue("rptGLSup_chkProject", chkProject.Checked, Applied.KeyType.Boolean);
            Applied.SetValue("rptGLSup_chkUnit", chkUnit.Checked, Applied.KeyType.Boolean);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
