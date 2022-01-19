using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Applied_Accounts.Classes;

namespace Applied_Accounts.Classes
{

    interface IInventoryClass
    {
        int Count();
        void Save();
        decimal GridTotal();
        DataRow Row();
        DataTable Table_Inventory();
    }

    public class InventoryClass : IInventoryClass
    {
        #region Variables

        public DataTable tb_Stock = AppliedTable.GetDataTable(Tables.Stock);

        public DataView dv_GridView = new DataView();
        public DataTable tb_GridView;
        public DataView dv_Inventory;
        public DataView dv_Inventory_Stock;
        public DataTable Original_Inventory;
        public DataRow TransactionRow;
        public DataRow StockRow;

        public DataTable tb_Inventory { get; set; }                                                         // Get Transaction (Stock) related entries
        public long Transaction_ID { get => Conversion.ToLong(TransactionRow["ID"].ToString()); }
        public long Vou_ID { get => Conversion.ToLong(TransactionRow["ID"].ToString()); }
        public string Vou_No { get => TransactionRow["Vou_No"].ToString(); }
        public string Vou_Type { get => TransactionRow["Vou_Type"].ToString(); }
        public DateTime Vou_Date { get => Conversion.ToDate(TransactionRow["Vou_Date"].ToString()); }
        public decimal Vou_Amount { get => Conversion.ToMoney(TransactionRow["DR"].ToString()); }
        public decimal Grid_Amount { get; set; }
        public long Stock_COA { get => Conversion.ToLong(TransactionRow["Stock"]); }
        public int Row_Index { get; set; }
        private string Filter_Inventory { get; set; }
        public decimal GridTotal()
        {
            return Conversion.ToMoney(tb_Inventory.Compute("SUM(Amount)", ""));
        }

        public int Count() { return tb_Inventory.Rows.Count; }
        public DataRow Row() { return TransactionRow; }
        #endregion

        #region Initialize

        public InventoryClass()                                 // Construct a class empty.
        {
            tb_Inventory = new DataTable();
            tb_GridView = new DataTable();
            dv_GridView = new DataView();
            dv_Inventory = new DataView();
            dv_Inventory_Stock = new DataView();
            Original_Inventory = tb_Inventory;
            TransactionRow = tb_Inventory.NewRow();
            StockRow = tb_Inventory.NewRow();
        }

        public InventoryClass(DataRow _TransactionRow)                                                  // Construct a class empty.
        {
            TransactionRow = _TransactionRow;
            tb_Inventory = AppliedTable.GetDataTable(Tables.Inventory, FilterVoucher(Vou_No));
            Original_Inventory = tb_Inventory.Copy();                                             // Save Table for Cancel data

            dv_Inventory = tb_Inventory.AsDataView();
            dv_Inventory_Stock = tb_Inventory.AsDataView();
            StockFilter(TransactionRow);
            StockRow = GetStockRow(0);

            UpdateGridView();                                                                                     // Create a Grid Table and fill Data from Inventory.
        }

        private DataRow GetStockRow(int _Index)
        {
            if (_Index == -1 || tb_Inventory.Rows.Count == 0 )
            {
                StockRow = tb_Inventory.NewRow();
                StockRow["ID"] = 0;
                StockRow["Vou_ID"] = Vou_ID;
                StockRow["Vou_No"] = Vou_No;
                StockRow["Vou_Amount"] = Vou_Amount;
                StockRow["SRNO"] = 1;
                StockRow["Stock"] = Stock_COA;
                StockRow["Qty"] = 0.00;
                StockRow["UOM"] = "";
                StockRow["Size"] = "";
                StockRow["Rate"] = 0.00;
                StockRow["Amount"] = 0.00;
                StockRow["Description"] = "";
                StockRow["Comments"] = "";
                StockRow["Batch"] = "";
                StockRow["Status"] = "New";
            }
            else
            {
                StockRow = tb_Inventory.Rows[_Index];
            }

            return StockRow;

        }

        public DataTable Table_Inventory() { return tb_Inventory; }
        public string Stock_Title() { return Applied.Title(Stock_COA, tb_Stock.AsDataView()); }

        #endregion

        #region Save / Create / Update / Insert / Delete

        public void Save()
        {
            int RowCount1 = tb_Inventory.Rows.Count;
            int RowCount2 = dv_Inventory.Count;
            int RowCount3 = dv_Inventory_Stock.Count;

            if(StockRow.RowState == DataRowState.Detached)
            {
                StockRow["ID"] = "0";
                StockRow["Status"] = "New";

                tb_Inventory.Rows.Add(StockRow);
            }
        }

        public void Create()
        {
            DataRow _NewRow = tb_Inventory.NewRow();
            _NewRow["SRNO"] = MaxSRNO() + 1;
            _NewRow["Vou_ID"] = Vou_ID;
            _NewRow["Vou_No"] = Vou_No;
            _NewRow["Vou_Amount"] = Vou_Amount;
            _NewRow["Stock"] = Stock_COA;
            _NewRow["Qty"] = 0.00;
            _NewRow["UOM"] = "";
            _NewRow["Size"] = "";
            _NewRow["Rate"] = 0.00;
            _NewRow["Amount"] = 0.00;
            _NewRow["Description"] = "";
            _NewRow["Comments"] = "";
            _NewRow["Batch"] = 0;
            StockRow = _NewRow;
           
        }

       

        public long MaxSRNO()
        {
            long Max_SRNO = 0;
            DataTable _DataTable = dv_Inventory_Stock.Table.Copy();
            Max_SRNO = Conversion.ToLong(_DataTable.Compute("MAX(SRNO)", ""));
            return Max_SRNO;
        }

        #endregion

        #region Update Grid Source (TableView)

        public DataTable UpdateGridView()
        {
            DataTable _DataTable = CreateGridViewTable();
            DataTable _StockTable = dv_Inventory_Stock.Table.Copy();
            if (dv_Inventory_Stock.Count > 0)
            {
                foreach (DataRow _Row in _StockTable.Rows)
                {
                    DataRow _GridRow = _DataTable.NewRow();
                    _GridRow["SRNO"] = _Row["SRNO"];
                    _GridRow["Title"] = Stock_Title();
                    _GridRow["Qty"] = _Row["Qty"];
                    _GridRow["UOM"] = _Row["UOM"];
                    _GridRow["Size"] = _Row["Size"];
                    _GridRow["Rate"] = _Row["Rate"];
                    _GridRow["Amount"] = _Row["Amount"];
                    _GridRow["Status"] = _Row["Status"];
                    _DataTable.Rows.Add(_GridRow);
                }
            }
            return _DataTable;
        }
        public DataTable CreateGridViewTable()
        {
            DataTable ViewTable = new DataTable();
            ViewTable.Columns.Add("SRNO", typeof(long));
            ViewTable.Columns.Add("Title", typeof(string));
            ViewTable.Columns.Add("Size", typeof(string));
            ViewTable.Columns.Add("UOM", typeof(string));
            ViewTable.Columns.Add("Qty", typeof(decimal));
            ViewTable.Columns.Add("Rate", typeof(decimal));
            ViewTable.Columns.Add("Amount", typeof(decimal));
            ViewTable.Columns.Add("Status", typeof(string));
            return ViewTable;
        }

        #endregion

        #region Filter

        public string FilterVoucher(string _Vou_No)
        {
            return "Vou_No='" + _Vou_No + "';";           // filter all Inventory of Voucher
        }

        public string FilterTransaction(DataRow _Row)
        {
            // Filter Records as per Voucher Transaction.
            return "Vou_No='" + TransactionRow["Vou_No"].ToString().Trim() + "' AND Vou_ID=" + TransactionRow["ID"].ToString().Trim();
        }

        public void StockFilter(DataRow _Row)
        {
            string _Filter = FilterTransaction(_Row);
            dv_Inventory_Stock.RowFilter = _Filter;
        }



        #endregion

    }   // END Class
}   // END Namespace
