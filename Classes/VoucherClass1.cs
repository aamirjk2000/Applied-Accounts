using Applied_Accounts.Preview;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Applied_Accounts.Classes
{
    interface IVoucherClass1
    {
        void Save();
        void Save(DataRow _Row);
        void Load_Tables();
        void Load_Voucher(string _Vou_No);
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
        

        public int Count { get => tb_Voucher.Rows.Count; }
        public Array Vou_Types = Enum.GetValues(typeof(Applied.VoucherType));
        public Boolean Voucher_Loaded = false;


        //===============================================================================================


        #region Initialization

        public VoucherClass1()
        {

            Load_Tables();

            Vou_No = "NEW";
            Vou_Date = DateTime.Now;
            Vou_Type = string.Empty;
            Vou_Status = "New";

            tb_Voucher = new DataTable();
            tb_GridData = new DataTable();
            tb_Voucher_Delete = new DataTable();
            MyRow = tb_Voucher.NewRow();

        }

        public VoucherClass1(string _VouNo)
        {
            Load_Tables();
            tb_Voucher = Get_Voucher(_VouNo);
        }

        public void Load_Tables()
        {
            tb_Accounts = AppliedTable.GetDataTable(Tables.COA);
            tb_Suppliers = AppliedTable.GetDataTable(Tables.Suppliers);
            tb_Projects = AppliedTable.GetDataTable(Tables.Projects);
            tb_Units = AppliedTable.GetDataTable(Tables.Units);
            tb_POrder = AppliedTable.GetDataTable(Tables.POrder);
            tb_Stocks = AppliedTable.GetDataTable(Tables.Stock);
            tb_Employees = AppliedTable.GetDataTable(Tables.Employees);
        }

        #endregion

        #region Voucher Load

        public void Load_Voucher(string _Vou_No)
        {
            tb_Voucher = AppliedTable.GetDataTable(Tables.Ledger,"Vou_No='" + _Vou_No + "'");

            if (tb_Voucher.Rows.Count > 0)
            {
                Vou_No = tb_Voucher.Rows[0]["Vou_No"].ToString();
                Vou_Date = (DateTime)tb_Voucher.Rows[0]["Vou_Date"];
                Vou_Type = tb_Voucher.Rows[0]["Vou_Type"].ToString();
                Voucher_Loaded = true;
            }
            else
            {
                Voucher_Loaded = false;
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
            DataTable _Result = new DataTable();
            _Result = AppliedTable.GetDataTable(Tables.Ledger, "Vou_No=" + _VouNo);
            return _Result;
        }

        #endregion

    }       // END Class
}           // END NameSpace
