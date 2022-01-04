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

        public string Vou_No { get; set; }
        public DateTime Vou_Date { get; set; }
        public decimal Vou_Amount { get; set; }
        public long Transaction_ID { get; set; }


        public DataTable tb_Inventory;
        public DataView dv_Inventory;
        public DataTable Original_Inventory;
        public DataRow MyRow;


        public int Count() { return tb_Inventory.Rows.Count; }
        public DataRow Row() {return MyRow; }

        #region Initialize

        public InventoryClass()
        {
            tb_Inventory = new DataTable();
        }

        public InventoryClass(DataRow _VouRow)
        {
            Vou_No = _VouRow["Vou_No"].ToString();
            Vou_Date = Conversion.ToDate(_VouRow["Vou_Date"].ToString());
            Vou_Amount = Conversion.ToMoney(_VouRow["DR"].ToString());

            tb_Inventory = AppliedTable.GetDataTable("SELECT * FROM Inventory WHERE Vou_No=' " + Vou_No + " ' ", "Inventory");
            dv_Inventory = AppliedTable.GetDataTable("SELECT * FROM View_Inventory WHERE Vou_No='" + Vou_No + " ' ", "Grid_Inventory").AsDataView();
            Original_Inventory = tb_Inventory.Copy();

            if(tb_Inventory.Rows.Count > 0)
            {
                MyRow = tb_Inventory.Rows[0];                   // Get First row of the table
            }
            else
            {
                MyRow = tb_Inventory.NewRow();              // Get New Row if table is empty.
            }
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

    }



}
