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

namespace Applied_Accounts.Classes
{

    interface IInventoryClass
    {
        int Count();
        void Save();
        DataRow Row();
    }


    public class InventoryClass : IInventoryClass
    {
        #region Variables
       
        private DataTable tb_Stock = AppliedTable.GetDataTable(Tables.Stock);
        public DataTable tb_Inventory;
        public DataView dv_Inventory;
        public DataTable Original_Inventory;
        public DataRow MyRow;

        public long Transaction_ID { get => Conversion.ToLong(MyRow["ID"].ToString()); }
        public long Vou_ID { get => Conversion.ToLong(MyRow["Vou_ID"].ToString()); }
        public string Vou_No { get => MyRow["Vou_No"].ToString(); }
        public string Vou_Type { get => MyRow["Vou_Type"].ToString(); }
        public DateTime Vou_Date { get => Conversion.ToDate(MyRow["Vou_Date"].ToString()); }
        public decimal Vou_Amount { get => Conversion.ToMoney(MyRow["DR"].ToString()); }
        
        public string Stock_Title { get => Applied.Title(Conversion.ToLong(MyRow["Stock"].ToString()), tb_Stock.AsDataView()); }
            
            


        public int Count() { return tb_Inventory.Rows.Count; }
        public DataRow Row() {return MyRow; }

        #endregion

        #region Initialize

        public InventoryClass()                                 // Construct a class empty.
        {
            tb_Inventory = new DataTable();
            dv_Inventory = new DataView();
            tb_Stock = new DataTable();
        }

        public InventoryClass(DataRow _VouRow)      // Construct a class empty.
        {
            MyRow = _VouRow;
            tb_Inventory = AppliedTable.GetDataTable("SELECT * FROM Inventory WHERE Vou_No=' " + Vou_No + " ' ", "Inventory");
            dv_Inventory = AppliedTable.GetDataTable("SELECT * FROM View_Inventory WHERE Vou_No='" + Vou_No + " ' ", "Grid_Inventory").AsDataView();
            Original_Inventory = tb_Inventory.Copy();

            // Create a new Row for Stock Inventory records.  //
            if (tb_Inventory.Rows.Count > 0) { Create(); }
        }

        #endregion

        #region Save / Create / Update / Insert / Delete

        public void Save()
        {
            // Save Inventory 


        }

        public void Create()
        {
            DataRow _NewRow = tb_Inventory.NewRow();

            _NewRow["ID"] = -1;
            _NewRow["Vou_ID"] = MyRow["ID"];
            _NewRow["Vou_No"] = MyRow["Vou_No"]; 
            _NewRow["Vou_Amount"] = Conversion.ToMoney(MyRow["DR"]) - Conversion.ToMoney(MyRow["CR"]);
            _NewRow["Stock"] = MyRow["Stock"]; ;
            _NewRow["Qty"] = 0;
            _NewRow["OUM"] = "";
            _NewRow["Size"] = "";
            _NewRow["Rate"] = 0;
            _NewRow["Amount"] = 0; ;
            _NewRow["Description"] = "";
            _NewRow["Comments"] = "";
            _NewRow["Batch"] = 1;

            tb_Inventory.Rows.Add(_NewRow);

        }


        public bool Update()
        {


            return true;
        }

        public bool Insert()
        {

            return true;
        }

        public bool Delete()
        {
            return true;
        }

        #endregion

        #region Validate

        public bool Valiedate()
        {
            // Validate the Inventory by Voucher Transaction Amount.
            // Voucher Transactionamount is equal with inventory Amount.

            return true;
        }




        #endregion

    }



}
