using System;
using System.Data;
using System.Windows.Forms;
using Applied_Accounts.Classes;

namespace Applied_Accounts.Classes
{
    interface IVoucherClass1
    {
        void Save();
        void Save(DataRow _Row);
        void Load_Tables();
        void Load_Voucher(string _Vou_No);
        DataTable Create_GridTable();
        void New();
    }


    public class VoucherClass1 : IVoucherClass1
    {
        public DataSet ds_Voucher;
        public DataTable tb_Voucher { get => ds_Voucher.Tables["Ledger"]; }
        public DataTable tb_Voucher_Delete;
        public DataTable tb_GridData;

        public string Vou_No;
        public DateTime Vou_Date;
        public string Vou_Type;
        public string Vou_Status;

        public int Count { get => tb_Voucher.Rows.Count; }
        public DataRow MyRow { get; set; }

        public Array Vou_Types = Enum.GetValues(typeof(Applied.VoucherType));
        public bool Voucher_Loaded = false;
        public bool Voucher_Saved = true;
        public bool New_Record = false;
        
        //===============================================================================================


        #region Initialization

        public VoucherClass1()
        {

            Load_Tables();

            Vou_No = "J0319-0007";
            Vou_Date = DateTime.Now;
            Vou_Type = string.Empty;
            Vou_Status = "New";

            //MyRow = tb_Voucher.NewRow();

        }

        public VoucherClass1(string _VouNo)
        {
            Load_Tables();
            Get_Voucher(_VouNo);
            tb_GridData = Create_GridTable();
        }

        public void Load_Tables()
        {

            ds_Voucher = new DataSet();
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.Ledger).Clone());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.COA).Copy());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.Suppliers).Copy());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.Projects).Copy());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.Units).Copy());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.Stock).Copy());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.Employees).Copy());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.POrder).Copy());

            ds_Voucher.Relations.Add("rlt_COA", ds_Voucher.Tables["COA"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["COA"]);
            ds_Voucher.Relations.Add("rlt_PRJ", ds_Voucher.Tables["Projects"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Project"]);
            ds_Voucher.Relations.Add("rlt_SUP", ds_Voucher.Tables["Suppliers"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Supplier"]);
            ds_Voucher.Relations.Add("rlt_UNI", ds_Voucher.Tables["Units"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Unit"]);
            ds_Voucher.Relations.Add("rlt_STK", ds_Voucher.Tables["Stock"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Stock"]);
            ds_Voucher.Relations.Add("rlt_EMP", ds_Voucher.Tables["Employees"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Employee"]);

            tb_Voucher_Delete = ds_Voucher.Tables["Ledger"].Clone();
            tb_GridData = Create_GridTable();

        }


        #endregion

        #region Voucher Load

        public void Load_Voucher(string _Vou_No)
        {
            Get_Voucher(_Vou_No);

            if (tb_Voucher.Rows.Count > 0)
            {
                Vou_No = tb_Voucher.Rows[0]["Vou_No"].ToString();
                Vou_Date = (DateTime)tb_Voucher.Rows[0]["Vou_Date"];
                Vou_Type = tb_Voucher.Rows[0]["Vou_Type"].ToString();
                Voucher_Loaded = true;
                Load_GridData();

            }
            else
            {
                Voucher_Loaded = false;
            }
        }

        public void Load_GridData()
        {
            tb_GridData.Clear();

            DataRow _GridRow = tb_GridData.NewRow();

            foreach (DataRow _Row in tb_Voucher.Rows)
            {
                _GridRow = tb_GridData.NewRow();
                _GridRow["SrNo"] = _Row["SRNO"];
                _GridRow["Vou_no"] = _Row["Vou_No"];
                _GridRow["Vou_Date"] = _Row["Vou_Date"];
                _GridRow["Cheque"] = _Row["Chq_No"];
                _GridRow["Remarks"] = _Row["Description"];
                _GridRow["Debit"] = _Row["DR"];
                _GridRow["Credit"] = _Row["CR"];
                tb_GridData.Rows.Add(_GridRow);
            }
        }


        #endregion

        #region Save

        public void Save()
        {
            Save(MyRow);
        }

        private void Save(object myRow)
        {
            throw new NotImplementedException();
        }

        public void Save(DataRow _Row)
        {

        }

        #endregion

        #region New

        public void New()
        {
            long MaxNo = (long)tb_Voucher.Compute("Max(SRNO)", string.Empty) + 1; 

            DataRow _NewRow = tb_Voucher.NewRow();
            _NewRow.BeginEdit();

            _NewRow["ID"] = -1;
            _NewRow["Vou_No"] = Vou_No;
            _NewRow["Vou_Date"] = Vou_Date;
            _NewRow["Vou_Type"] = Vou_Type;
            _NewRow["SrNO"] = MaxNo;
            tb_Voucher.Rows.Add(_NewRow);

            //ds_Voucher.Tables.Remove(tb_Voucher);           // Remove out of Date Table
            //ds_Voucher.Tables.Add(tb_Voucher.Copy());              // Add Updated Table.

            Load_GridData();
            New_Record = true;
        }


        #endregion

        #region Set VoucherTable
        private DataTable Get_Voucher(string _VouNo)
        {
            DataTable _Result;
            
            _Result = AppliedTable.GetDataTable(Tables.Ledger, "Vou_No='" + _VouNo + "'");

            ds_Voucher.Tables["Ledger"].Clear();
            foreach (DataRow _Row in _Result.Rows)
            {
                ds_Voucher.Tables["Ledger"].Rows.Add(_Row.ItemArray);
            }
            return _Result;
        }

        #endregion

        public DataTable Create_GridTable()
        {
            DataTable GridTable = new DataTable();

            GridTable.Columns.Add("SrNo", typeof(string));
            GridTable.Columns.Add("Vou_No", typeof(string));
            GridTable.Columns.Add("Vou_Date", typeof(DateTime));
            GridTable.Columns.Add("Cheque", typeof(string));
            GridTable.Columns.Add("Remarks", typeof(string));
            GridTable.Columns.Add("Debit", typeof(decimal));
            GridTable.Columns.Add("Credit", typeof(decimal));

            return GridTable;
        }

        #region Print Voucher

        public void Preview_Voucher()
        {
            Preview_Voucher(string.Concat("Vou_No='", Vou_No, "'"));
        }

        public void Preview_Voucher(string _DataFilter)
        {

            if (_DataFilter.Length == 0)
            {
                _DataFilter = "Vou_Date ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            }

            ReportClass PreviewClass = new ReportClass();                                       // Initialize Report Class
            PreviewClass.DataSet_Name = "ds_Voucher";                                           // Dataset for the report
            PreviewClass.Vou_No = Vou_No;                                                       // Print Voucher No in report
            PreviewClass.Vou_Date = Vou_Date;                                                   // DAte of Voucher
            PreviewClass.Report_Location = Program.ReportsPath + "Report_Voucher.rdlc";         // Report Name 
            PreviewClass.DataSource_Filter = _DataFilter;                                       // Filter for the Data Source
            PreviewClass.DataSource = AppliedTable.GetDataTable(Tables.View_Voucher, PreviewClass.DataSource_Filter);
            PreviewClass.Report_Data = PreviewClass.DataSource.AsDataView();                    // Data for the report.
            if (PreviewClass.Report_Data.Count > 0)                                             // Voucher class has voucher record.
            {
                string MinDate = PreviewClass.Min("Vou_Date");
                string MaxDate = PreviewClass.Max("Vou_Date");

                string MinVou = PreviewClass.Min("Vou_No");
                string MaxVou = PreviewClass.Max("Vou_No");

                PreviewClass.Report_From = Conversion.ToDate(MinDate);
                PreviewClass.Report_To = Conversion.ToDate(MaxDate);

                if (MinVou.Trim() == MaxVou.Trim())
                {
                    PreviewClass.Heading1 = Vou_Type + " Voucher";
                    PreviewClass.Heading2 = Vou_Type + " Voucher";
                }
                else
                {
                    PreviewClass.Heading1 = "Vouchers from " + Conversion.ToPrintDate(MinDate) + " to " + Conversion.ToPrintDate(MaxDate);
                    PreviewClass.Heading2 = Vou_Type + " Voucher";

                }

                PreviewClass.Report_From = PreviewClass.Vou_Date;

                Preview.frmPreview_Reports PreviewVoucher = new Preview.frmPreview_Reports(PreviewClass);           // Window form for the report.
                PreviewVoucher.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Record found.");
            }
        }

        #endregion

    }       // END Class
}           // END NameSpace
