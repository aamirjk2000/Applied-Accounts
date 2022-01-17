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
        public DataRow MyRow;
        public DataRow StockRow;

        public DataTable tb_Inventory { get; set; }                                                         // Get Transaction (Stock) related entries
        public long Transaction_ID { get => Conversion.ToLong(MyRow["ID"].ToString()); }
        public long Vou_ID { get => Conversion.ToLong(MyRow["ID"].ToString()); }
        public string Vou_No { get => MyRow["Vou_No"].ToString(); }
        public string Vou_Type { get => MyRow["Vou_Type"].ToString(); }
        public DateTime Vou_Date { get => Conversion.ToDate(MyRow["Vou_Date"].ToString()); }
        public decimal Vou_Amount { get => Conversion.ToMoney(MyRow["DR"].ToString()); }
        public decimal Grid_Amount { get; set; }
        public long Stock_COA { get => Conversion.ToLong(MyRow["Stock"]); }
        public int Row_Index { get; set; }
        private string Filter_Inventory { get; set; }
        public decimal GridTotal()
        {
            return Conversion.ToMoney(tb_Inventory.Compute("SUM(Amount)", ""));
        }

        public int Count() { return tb_Inventory.Rows.Count; }
        public DataRow Row() { return MyRow; }
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
            MyRow = tb_Inventory.NewRow();
            StockRow = tb_Inventory.NewRow();
        }


        public InventoryClass(string _Vou_No)
        {
            tb_Inventory = AppliedTable.GetDataTable(Tables.Inventory, SetFilter(_Vou_No));
            dv_Inventory = tb_Inventory.AsDataView();
            dv_Inventory_Stock = tb_Inventory.AsDataView();
            Original_Inventory = tb_Inventory.Copy();
            //MyRow = tb_Inventory.NewRow();
            StockRow = tb_Inventory.NewRow();
            UpdateGridView();
            UpdateStockRow(0);

        }


        public InventoryClass(DataRow _VouRow)                                                  // Construct a class empty.
        {
            MyRow = _VouRow;
            tb_Inventory = AppliedTable.GetDataTable(Tables.Inventory, SetFilter(Vou_No));
            Original_Inventory = tb_Inventory.Copy();                                             // Save Table for Cancel data

            dv_Inventory = tb_Inventory.AsDataView();
            dv_Inventory_Stock = tb_Inventory.AsDataView();
            StockFilter(MyRow);

            if (tb_Inventory.Rows.Count > 0)                        // Fill a Data Row if empty
            {
                if (MyRow == null) { MyRow = tb_Inventory.Rows[0]; } else { MyRow = tb_Inventory.NewRow(); }
            }

            UpdateGridView();                                                                                     // Create a Grid Table and fill Data from Inventory.


        }

        #region Generate Stock Row

        public DataRow GetStockRow(int _Index)
        {
            DataRow _StockRow = tb_Inventory.NewRow();

            if (tb_Inventory.Rows.Count > 0)
            {
                _StockRow = tb_Inventory.Rows[_Index];
            }
            else
            {
                decimal _Amount = Conversion.ToMoney(MyRow["DR"]) - Conversion.ToMoney(MyRow["CR"]);        // Transaction Amount
                _StockRow = tb_Inventory.NewRow();
                _StockRow["ID"] = 0;
                _StockRow["Vou_ID"] = MyRow["ID"];
                _StockRow["Vou_No"] = MyRow["Vou_No"];
                _StockRow["Vou_Amount"] = _Amount;                       // Transaction Amount 
                _StockRow["SRNO"] = MaxSRNO() + 1;
                _StockRow["Stock"] = Stock_COA;
                _StockRow["Qty"] = 0;
                _StockRow["UOM"] = "";
                _StockRow["Size"] = "";
                _StockRow["Rate"] = 0;
                _StockRow["Amount"] = 0.00;
                _StockRow["Description"] = "";
                _StockRow["comments"] = "";
            }
            return _StockRow;
        }


        #endregion
        public DataTable Table_Inventory() { return tb_Inventory; }
        public string Stock_Title() { return Applied.Title(Stock_COA, tb_Stock.AsDataView()); }

        #endregion

        #region Save / Create / Update / Insert / Delete


        public void Save()
        {
            // Save Inventory 
            //if (RecordFound(Conversion.ToLong(StockRow["SRNO"])))
            //{
            //    foreach (DataRow _Row in tb_Inventory.Rows)
            //    {
            //        if (_Row["SRNO"].Equals(StockRow["SRNO"]))
            //        {
            //            Row_Index = tb_Inventory.Rows.IndexOf(_Row);            // Get a Row Index

            //            tb_Inventory.Rows[Row_Index]["ID"] = StockRow["ID"];
            //            tb_Inventory.Rows[Row_Index]["Vou_ID"] = Vou_ID;
            //            tb_Inventory.Rows[Row_Index]["vou_No"] = Vou_No;
            //            tb_Inventory.Rows[Row_Index]["Vou_Amount"] = Vou_Amount;
            //            tb_Inventory.Rows[Row_Index]["SRNO"] = StockRow["SRNO"];
            //            tb_Inventory.Rows[Row_Index]["Stock"] = Stock_COA;
            //            tb_Inventory.Rows[Row_Index]["Size"] = StockRow["Size"];
            //            tb_Inventory.Rows[Row_Index]["UOM"] = StockRow["UOM"];
            //            tb_Inventory.Rows[Row_Index]["Qty"] = StockRow["Qty"];
            //            tb_Inventory.Rows[Row_Index]["Rate"] = StockRow["Rate"];
            //            tb_Inventory.Rows[Row_Index]["Amount"] = StockRow["Amount"];
            //            tb_Inventory.Rows[Row_Index]["Description"] = StockRow["Description"];
            //            tb_Inventory.Rows[Row_Index]["Comments"] = StockRow["Comments"];
            //            tb_Inventory.Rows[Row_Index]["Status"] = "Edit";
            //        }
            //    }
            //}
            //else
            //{
            //    DataRow _NewRow = tb_Inventory.NewRow();
            //    _NewRow["ID"] = 0;
            //    _NewRow["SRNO"] = MaxSRNO() + 1;
            //    _NewRow["Vou_ID"] = Vou_ID;
            //    _NewRow["vou_No"] = Vou_No;
            //    _NewRow["Vou_Amount"] = Vou_Amount;
            //    _NewRow["Stock"] = StockRow["Stock"];
            //    _NewRow["Size"] = StockRow["Size"];
            //    _NewRow["UOM"] = StockRow["UOM"];
            //    _NewRow["Qty"] = StockRow["Qty"];
            //    _NewRow["Rate"] = StockRow["Rate"];
            //    _NewRow["Amount"] = StockRow["Amount"];
            //    _NewRow["Description"] = StockRow["Description"];
            //    _NewRow["Comments"] = StockRow["Comments"];
            //    _NewRow["Status"] = "New";
            //    tb_Inventory.Rows.Add(_NewRow);
            //    Row_Index = tb_Inventory.Rows.IndexOf(_NewRow);         // Save a Row Index.
            //    return;
            //}
        }

        public void UpdateStockRow(int _Index)
        {
            if (dv_Inventory_Stock.ToTable().Rows.Count> 0)
            {
                StockRow["ID"] = tb_Inventory.Rows[Row_Index]["ID"];
                StockRow["Vou_ID"] = tb_Inventory.Rows[Row_Index]["Vou_ID"];
                StockRow["Vou_No"] = tb_Inventory.Rows[Row_Index]["Vou_No"];
                StockRow["Vou_Amount"] = tb_Inventory.Rows[Row_Index]["Vou_Amount"];
                StockRow["SRNO"] = tb_Inventory.Rows[Row_Index]["SRNO"];
                StockRow["Stock"] = tb_Inventory.Rows[Row_Index]["Stock"];
                StockRow["Qty"] = tb_Inventory.Rows[Row_Index]["Qty"];
                StockRow["UOM"] = tb_Inventory.Rows[Row_Index]["UOM"];
                StockRow["Size"] = tb_Inventory.Rows[Row_Index]["Size"];
                StockRow["Rate"] = tb_Inventory.Rows[Row_Index]["Rate"];
                StockRow["Amount"] = tb_Inventory.Rows[Row_Index]["Amount"];
                StockRow["Description"] = tb_Inventory.Rows[Row_Index]["Description"];
                StockRow["Comments"] = tb_Inventory.Rows[Row_Index]["Comments"];
            }
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

        public string SetFilter(string _Vou_No)
        {
            return "Vou_No='" + _Vou_No + "';";           // filter all Inventory of Voucher
        }

        public string FilterTransaction(DataRow _Row)
        {
            // Filter Records as per Voucher Transaction.
            return "Vou_No='" + MyRow["Vou_No"].ToString().Trim() + "' AND Vou_ID=" + MyRow["ID"].ToString().Trim();
        }

        public void StockFilter(DataRow _Row)
        {
            string _Filter = FilterTransaction(_Row);
            dv_Inventory_Stock.RowFilter = _Filter;
        }



        #endregion

    }   // END Class
}   // END Namespace
