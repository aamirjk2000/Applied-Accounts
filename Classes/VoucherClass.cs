using System;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;

namespace Applied_Accounts.Classes
{
    interface iVoucherclass
    {
        int Count_Table();
        int Count_View();

    }


    public class VoucherClass : iVoucherclass
    {



        #region Variables


        public string Vou_No { get; set; }
        public DateTime Vou_Date { get; set; }
        public string Vou_Type { get; set; }
        public int Vou_TypeID { get; set; }
        public decimal Total_DR { get; set; }
        public decimal Total_CR { get; set; }
        public decimal Difference { get => (Total_DR - Total_CR); }
        public int Total_Transactions { get; set; }

        public DataTable VoucherTable = new DataTable();
        public DataView VoucherView = new DataView();
        private DataTable tbLedger;

        public DataRow CurrentRow { get; set; }
        public int CurrentYear { get; set; }
        public string Status { get; set; }
        public long NewID { get; set; }
        public int Count_Table() { return VoucherTable.Rows.Count; }
        public int Count_View() { return VoucherView.Count; }


        #endregion

        #region Initialize

        public VoucherClass()                // Initialize the Class
        {
            NewVoucher();
        }



        public VoucherClass(string Voucher_No)
        {
            NewID = -1;
            Vou_No = Voucher_No;

            if (Voucher_No.Length == 0) { return; }
            if (Voucher_No.ToUpper() == "NEW") { NewVoucher(); return; }

            tbLedger = AppliedTable.GetDataTable((int)Tables.Ledger);
            CreateTable();

            if (VoucherView.Count > 0)
            {
                CurrentRow = VoucherTable.Rows[0];
                Vou_No = VoucherTable.Rows[0]["Vou_No"].ToString();
                Vou_Date = Applied.GetDate(VoucherTable.Rows[0]["Vou_Date"].ToString());
                Vou_Type = Vou_No.Substring(1, 1);
                Vou_Type = GetVoucherTypeText(Vou_Type);
                Status = "EDIT";

                Total_DR = Conversion.ToMoney(VoucherTable.Compute("SUM(DR)", string.Empty).ToString());
                Total_CR = Conversion.ToMoney(VoucherTable.Compute("SUM(CR)", string.Empty).ToString());

            }
            else
            {
                MessageBox.Show("No Voucher Found", "VoucherClass");
                return;
            }

        }

        #endregion

        #region New Voucher

        public void NewVoucher()
        {

            // Initialize the new Vouchers
            Vou_No = "NEW";
            Vou_Date = DateTime.Now;
            Vou_Type = "";
            Vou_TypeID = 0;
            Total_DR = 0;
            Total_CR = 0;
            Total_Transactions = 0;
            Status = "NEW";
            CurrentRow = null;
            CurrentYear = Applied.GetInteger("CurrentYear");
            NewID = -1;

            tbLedger = AppliedTable.GetDataTable((int)Tables.Ledger);   // Load Ledger Table
            CreateTable();                                              // Create Voucher Table and voucher view
            VoucherTable.Rows.Add(CreateRow(1));                        // DR Site.  Create two transaction.
            VoucherTable.Rows.Add(CreateRow(2));                        // CR Site.
            CurrentRow = VoucherTable.Rows[0];

        }

        #endregion

        #region Codes
        private string GetVoucherTypeText(string vou_Type)
        {
            switch (vou_Type.ToUpper())
            {
                case "J":
                    return "Journal";

                case "P":
                    return "Payment";

                case "R":
                    return "Receipt";

                case "S":
                    return "Revenue";

                case "E":
                    return "Salary";

                case "I":
                    return "Stock";

                default:

                    return "";
            }
        }

        public void CreateTable()
        {
            if (Vou_No==null || Vou_No.Length == 0)
            {
                VoucherTable = new DataView(tbLedger.Clone()).ToTable();
                VoucherView.Table = VoucherTable;
            }
            else
            {
                VoucherTable = new DataView(tbLedger, "Vou_No='" + Vou_No + "'", "SRNO", DataViewRowState.OriginalRows).ToTable().Copy();
                VoucherView.Table = VoucherTable;
            }
                
        }

            public void AddRow()
        {
            CurrentRow = CreateRow(MaxSRNO());
            VoucherTable.Rows.Add(CurrentRow);
            //NewID -= 1;

        }
        
        public DataRow CreateRow(long _SRNO)
        {
            DataRow _DataRow = VoucherTable.NewRow();

            _DataRow["ID"] = NewID;
            _DataRow["Vou_no"] = Vou_No;
            _DataRow["Vou_Date"] = Vou_Date;
            _DataRow["Vou_Type"] = Vou_Type;
            _DataRow["SRNO"] = _SRNO;
            _DataRow["COA"] = 0;
            _DataRow["Supplier"] = 0;
            _DataRow["Project"] = 0;
            _DataRow["Stock"] = 0;
            _DataRow["Unit"] = 0;
            _DataRow["Employee"] = 0;
            _DataRow["RefNo"] = "";
            _DataRow["Chq_No"] = "";
            _DataRow["Chq_Date"] = DBNull.Value;
            _DataRow["DR"] = 0;
            _DataRow["CR"] = 0;
            _DataRow["Description"] = "";
            _DataRow["Remarks"] = "";

            NewID -= 1;

            return _DataRow;

        }

        private long MaxSRNO()
        {
            long MaxSRNO = (long)VoucherTable.Compute("Max(SRNO)", string.Empty);
            return MaxSRNO + 1;
        }

        #endregion

        #region Voucher Type

        public string GetVoucherTag(int _VoucherType)
        {
            switch (_VoucherType)
            {
                case (int)Applied.VoucherType.Journal:
                    return "J";

                case (int)Applied.VoucherType.Payment:
                    return "P";

                case (int)Applied.VoucherType.Receipt:
                    return "R";

                case (int)Applied.VoucherType.Revenue:
                    return "S";

                case (int)Applied.VoucherType.Salary:
                    return "E";

                case (int)Applied.VoucherType.Stock:
                    return "I";

                default:
                    return "";
                    
            }

         
        }

        public string GetVoucherTypeName(int VoucherTypeID)
        {

            string VoucherTypeName = Enum.GetName(typeof(Applied.VoucherType), VoucherTypeID);
            return VoucherTypeName;
        }

        public string GetVoucherTypeName(char VoucherTypeChar)
        {
            switch (VoucherTypeChar)
            {
                case 'J':
                    return GetVoucherTypeName((int)Applied.VoucherType.Journal);

                case 'P':
                    return GetVoucherTypeName((int)Applied.VoucherType.Payment);

                case 'R':
                    return GetVoucherTypeName((int)Applied.VoucherType.Receipt);

                case 'S':
                    return GetVoucherTypeName((int)Applied.VoucherType.Revenue);

                case 'E':
                    return GetVoucherTypeName((int)Applied.VoucherType.Salary);

                case 'I':
                    return GetVoucherTypeName((int)Applied.VoucherType.Stock);

                default:
                    return "";
            }



        }

        public int GetVoucherTypeID(char VoucherTypeChar)
        {
            switch (VoucherTypeChar)
            {
                case 'J':
                    return (int)Applied.VoucherType.Journal;

                case 'P':
                    return (int)Applied.VoucherType.Payment;

                case 'R':
                    return (int)Applied.VoucherType.Receipt;

                case 'S':
                    return (int)Applied.VoucherType.Revenue;

                case 'E':
                    return (int)Applied.VoucherType.Salary;

                case 'I':
                    return (int)Applied.VoucherType.Stock;

                default:
                    return 0;
            }



        }


        #endregion

    }       // END Main Class
}           // END NameSpace
