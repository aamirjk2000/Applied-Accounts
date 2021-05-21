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
        void Filter();
        void Filter(long TrancsctionID);
    }
    

    public class InventoryClass : IInventoryClass
    {

        public string Vou_No { get; set; }
        public DateTime Vou_Date { get; set; }
        public decimal Vou_Amount { get; set; }
        public long Transaction_ID { get; set; }


        public DataTable tb_Inventory;
        public DataView dv_Inventory;
        public DataTable Original_Inventory;
        


        public int Count() { return tb_Inventory.Rows.Count; }


        #region Initialize

        public InventoryClass()
        {
            tb_Inventory = new DataTable();
        }

        public InventoryClass(string _VouNo)
        {
            Vou_No = _VouNo;
            tb_Inventory = AppliedTable.GetDataTable("SELECT * FROM Inventory WHERE Vou_No='" + _VouNo + "'", "Inventory");
            dv_Inventory = AppliedTable.GetDataTable("SELECT * FROM View_Inventory WHERE Vou_No='" + _VouNo + "'", "Grid_Inventory").AsDataView(); ;
            Original_Inventory = tb_Inventory.Copy();
        }

        #endregion

        #region Save

        public void Save()
        {
            // Save Inventory 


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


        #region Filter
        public void Filter(long _TransactionID)
        {
            Transaction_ID = _TransactionID;
            dv_Inventory.RowFilter = "Vou_ID=" + Transaction_ID.ToString();               // Invoke Filter in Grid View.
        }

        public void Filter()
        {
            dv_Inventory.RowFilter = "Vou_ID=" + Transaction_ID.ToString();               // Invoke Filter in Grid View.
        }

        #endregion

    }



}
