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
        long MaxID();
        //DataView UpdateGridView();                          // Update Data View from Table
    }

    public class InventoryClass : IInventoryClass
    {
        #region Variables

        public DataTable tb_Stock = AppliedTable.GetDataTable(Tables.Stock);

        public DataView dv_GridView = new DataView();
        public DataTable tb_GridView;
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
        public string Stock_Title { get => Applied.Title(Conversion.ToLong(MyRow["Stock"].ToString()), tb_Stock.AsDataView()); }
        public int Row_Index { get; set; }
        private string Filter_Inventory { get; set; }

        public int Count() { return tb_Inventory.Rows.Count; }
        public DataRow Row() { return MyRow; }
        #endregion

        #region Initialize

        public InventoryClass()                                 // Construct a class empty.
        {
            tb_Inventory = new DataTable();
            tb_GridView = new DataTable();
            dv_GridView = new DataView();
        }

        public InventoryClass(DataRow _VouRow)      // Construct a class empty.
        {
            MyRow = _VouRow;
            SetFilter(MyRow);

            tb_Inventory = CreateTableInventory();
            tb_GridView = CreateDataViewTable();
            Original_Inventory = tb_Inventory.Clone();                                              // Save Table for cancell data

            #region Generate Stock Row

            if (tb_Inventory.Rows.Count > 0)
            {
                StockRow = tb_Inventory.Rows[0];
            }
            else
            {
                decimal _Amount = Conversion.ToMoney(MyRow["DR"]) - Conversion.ToMoney(MyRow["CR"]);        // Transaction Amount
                StockRow = tb_Inventory.NewRow();
                StockRow["ID"] = 0;
                StockRow["Vou_ID"] = MyRow["ID"];
                StockRow["Vou_No"] = MyRow["Vou_No"];
                StockRow["Vou_Amount"] = _Amount;                       // Transaction Amount 
                StockRow["SRNO"] = MaxSRNO() + 1;
                StockRow["Stock"] = Stock_COA;
                StockRow["Qty"] = 0;
                StockRow["UOM"] = "";
                StockRow["Size"] = "";
                StockRow["Rate"] = 0;
                StockRow["Amount"] = 0.00;
                StockRow["Description"] = "";
                StockRow["comments"] = "";
            }

            #endregion

        }

        #endregion

        #region Create Inventory Table

        private DataTable CreateTableInventory()
        {
            tb_Inventory = AppliedTable.GetDataTable(Tables.Inventory, Filter_Inventory);
            return tb_Inventory;
        }


        #endregion

        #region Save / Create / Update / Insert / Delete

        public void Save()
        {
            // Save Inventory 
            if (Conversion.ToLong(StockRow["SRNO"]) == 0)
            {
                DataRow _NewRow = tb_Inventory.NewRow();
                _NewRow["ID"] = 0;
                _NewRow["SRNO"] = MaxSRNO() + 1;
                _NewRow["Vou_ID"] = Vou_ID;
                _NewRow["vou_No"] = Vou_No;
                _NewRow["Vou_Amount"] = Vou_Amount;
                _NewRow["Stock"] = StockRow["Stock"];
                _NewRow["Size"] = StockRow["Size"];
                _NewRow["UOM"] = StockRow["UOM"];
                _NewRow["Qty"] = StockRow["Qty"];
                _NewRow["Rate"] = StockRow["Rate"];
                _NewRow["Amount"] = StockRow["Amount"];
                _NewRow["Description"] = StockRow["Description"];
                _NewRow["Comments"] = StockRow["Comments"];
                _NewRow["Status"] = "New";
                tb_Inventory.Rows.Add(_NewRow);
                Row_Index = tb_Inventory.Rows.IndexOf(_NewRow);         // Save a Row Index.
                return;
            }

            foreach (DataRow _Row in tb_Inventory.Rows)
            {
                //if (_Row["ID"] == StockRow["ID"])
                if (_Row["SRNO"].Equals(StockRow["SRNO"]))
                {
                    Row_Index = tb_Inventory.Rows.IndexOf(_Row);            // Get a Row Index

                    tb_Inventory.Rows[Row_Index]["ID"] = StockRow["ID"];
                    tb_Inventory.Rows[Row_Index]["Vou_ID"] = Vou_ID;
                    tb_Inventory.Rows[Row_Index]["vou_No"] = Vou_No;
                    tb_Inventory.Rows[Row_Index]["Vou_Amount"] = Vou_Amount;
                    tb_Inventory.Rows[Row_Index]["SRNO"] = StockRow["SRNO"];
                    tb_Inventory.Rows[Row_Index]["Stock"] = Stock_COA;
                    tb_Inventory.Rows[Row_Index]["Size"] = StockRow["Size"];
                    tb_Inventory.Rows[Row_Index]["UOM"] = StockRow["UOM"];
                    tb_Inventory.Rows[Row_Index]["Qty"] = StockRow["Qty"];
                    tb_Inventory.Rows[Row_Index]["Rate"] = StockRow["Rate"];
                    tb_Inventory.Rows[Row_Index]["Amount"] = StockRow["Amount"];
                    tb_Inventory.Rows[Row_Index]["Description"] = StockRow["Description"];
                    tb_Inventory.Rows[Row_Index]["Comments"] = StockRow["Comments"];
                    tb_Inventory.Rows[Row_Index]["Status"] = "Edit";


                }
            }
            

        }

        public void UpdateStockRow(int _Index)
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

        public long MaxSRNO()
        {
            long Max_SRNO = 0;
            Max_SRNO = Conversion.ToLong(tb_Inventory.Compute("MAX(SRNO)", ""));
            return Max_SRNO;

        }

        #endregion

        #region Table's Function
        public decimal GridTotal()
        {
            return Conversion.ToMoney(tb_Inventory.Compute("SUM(Amount)", ""));
        }

        public long MaxID()
        {
            long _Max_ID = 0;
            DataTable _DataTable = AppliedTable.GetDataTable("SELECT MAX(ID) FROM  " + Tables.Inventory.ToString() + ";");
            if (_DataTable.Rows[0][0] == null) { _Max_ID = 0; }
            else { _Max_ID = Conversion.ToLong(_DataTable.Rows[0][0]); }
            return _Max_ID;
        }

        #endregion

        #region Update Grid Source (TableView)

        public DataTable UpdateGridView()
        {
            DataTable _DataTable = CreateDataViewTable();

            foreach (DataRow _Row in tb_Inventory.Rows)
            {

                DataRow _GridRow = _DataTable.NewRow();

                _GridRow["SRNO"] = _Row["SRNO"];
                _GridRow["Title"] = Stock_Title;
                _GridRow["Qty"] = _Row["Qty"];
                _GridRow["UOM"] = _Row["UOM"];
                _GridRow["Size"] = _Row["Size"];
                _GridRow["Rate"] = _Row["Rate"];
                _GridRow["Amount"] = _Row["Amount"];
                _GridRow["Status"] = _Row["Status"];
                _DataTable.Rows.Add(_GridRow);
            }
            return _DataTable;
        }
        public DataTable CreateDataViewTable()
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

        public void SetFilter(DataRow _Row)
        {
            if (_Row != null)
            {
                Filter_Inventory = " Vou_No='" + MyRow["Vou_No"].ToString().Trim() + "' AND Stock=" + MyRow["Stock"].ToString().Trim() + ";";

            }
            else
            {
                Filter_Inventory = "";
            }
        }

        #endregion

    }   // END Class
}   // END Namespace
