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
    }


    public class VoucherClass1 : IVoucherClass1
    {
        public DataTable tb_Voucher;
        public DataTable tb_Voucher_Delete;
        public DataTable tb_GridData;
        public DataRow MyRow;

        public string Vou_No;
        public DateTime Vou_Date;
        public string Vou_Type;
        public string Vou_Status;

        public DataTable tb_Accounts;                               // Data Table
        public DataTable tb_Suppliers;
        public DataTable tb_Projects;
        public DataTable tb_Units;
        public DataTable tb_Stocks;
        public DataTable tb_Employees;
        public DataTable tb_POrder;

        public DataSet ds_Voucher;


        public int Count { get => tb_Voucher.Rows.Count; }

        public Array Vou_Types = Enum.GetValues(typeof(Applied.VoucherType));
        public Boolean Voucher_Loaded = false;


        // DATA BINDING >>>>
        //internal DataView ViewBinding;
        //public BindingManagerBase TableBinding;                                // Binding Manager for navigation of records.
        //Data.ds_Voucher1 MyDataSet_Voucher; 
        //public BindingSource MyBindingSource = new BindingSource();                // DataSource of Binding source;
        // DATA BINDING <<<<


        //===============================================================================================


        #region Initialization

        public VoucherClass1()
        {

            Load_Tables();

            Vou_No = "NEW";
            Vou_Date = DateTime.Now;
            Vou_Type = string.Empty;
            Vou_Status = "New";

            MyRow = tb_Voucher.NewRow();

        }

        public VoucherClass1(string _VouNo)
        {
            Load_Tables();
            tb_Voucher = Get_Voucher(_VouNo);
            tb_GridData = Create_GridTable();
        }

        public void Load_Tables()
        {
            tb_Accounts = AppliedTable.GetDataTable(Tables.COA);
            tb_Suppliers = AppliedTable.GetDataTable(Tables.Suppliers);
            tb_Projects = AppliedTable.GetDataTable(Tables.Projects);
            tb_Units = AppliedTable.GetDataTable(Tables.Units);
            tb_POrder = AppliedTable.GetDataTable(Tables.POrder);
            tb_Stocks = AppliedTable.GetDataTable(Tables.Stock);
            tb_Employees = AppliedTable.GetComboData(Tables.Employees);

            tb_Voucher = AppliedTable.GetDataTable(Tables.Ledger).Clone();
            tb_Voucher_Delete = tb_Voucher.Clone();
            tb_GridData = Create_GridTable();

            ds_Voucher = new DataSet();
            ds_Voucher.Tables.Add(tb_Accounts.Copy());
            ds_Voucher.Tables.Add(tb_Suppliers.Copy());
            ds_Voucher.Tables.Add(tb_Projects.Copy());
            ds_Voucher.Tables.Add(tb_Units.Copy());
            ds_Voucher.Tables.Add(tb_Stocks.Copy());
            ds_Voucher.Tables.Add(tb_Employees.Copy());
            ds_Voucher.Tables.Add(tb_Voucher.Copy());

            ds_Voucher.Relations.Add("rlt_COA", ds_Voucher.Tables["COA"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["COA"]);
            ds_Voucher.Relations.Add("rlt_PRJ", ds_Voucher.Tables["Projects"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Project"]);
            ds_Voucher.Relations.Add("rlt_SUP", ds_Voucher.Tables["Suppliers"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Supplier"]);
            ds_Voucher.Relations.Add("rlt_UNI", ds_Voucher.Tables["Units"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Unit"]);
            ds_Voucher.Relations.Add("rlt_STK", ds_Voucher.Tables["Stock"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Stock"]);
            ds_Voucher.Relations.Add("rlt_EMP", ds_Voucher.Tables["Employees"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Employee"]);
        }


        #endregion

        #region Voucher Load

        public void Load_Voucher(string _Vou_No)
        {
            tb_Voucher = Get_Voucher(_Vou_No);

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

        public void Save(DataRow _Row)
        {

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




    }       // END Class
}           // END NameSpace
