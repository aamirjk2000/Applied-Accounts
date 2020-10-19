using Applied_Accounts.Preview;
using System;
using System.ComponentModel.DataAnnotations;
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
        void Save();
        string ToWords();
        DataTable GetGridTable();
        void Preview_Voucher();
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
        public DataTable GridTable = new DataTable();
        public DataView VoucherView = new DataView();
        private DataTable tbLedger;

        public DataRow CurrentRow { get; set; }
        public int CurrentYear { get; set; }
        public string Status { get; set; }
        public long NewID { get; set; }
        public int Count_Table() { return VoucherTable.Rows.Count; }
        public int Count_View() { return VoucherView.Count; }
        public bool Voucher_Saved { get; set; }


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
                Vou_Date = Conversion.ToDate(VoucherTable.Rows[0]["Vou_Date"].ToString());
                Vou_Type = Vou_No.Substring(0, 1);
                Vou_Type = GetVoucherTypeText(Vou_Type);
                Status = "EDIT";

                Total_DR = Conversion.ToMoney(VoucherTable.Compute("SUM(DR)", string.Empty).ToString());
                Total_CR = Conversion.ToMoney(VoucherTable.Compute("SUM(CR)", string.Empty).ToString());
                //MaxSRNO = (long)VoucherTable.Compute("Max(SRNO)", string.Empty);
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
            if (Vou_No == null || Vou_No.Length == 0)
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

        public long MaxSRNO()
        {
            long MaxSRNO = (long)VoucherTable.Compute("Max(SRNO)", string.Empty);
            return MaxSRNO + 1;
        }


        public string ToWords()
        {
            InWords Words = new InWords(Total_DR);
            return Words.ToWords();
        }

        #endregion

        #region SAVE

        public void Save()
        {
            Voucher_Saved = false;

            SQLiteCommand _CmdInsert = new SQLiteCommand();
            SQLiteCommand _CmdUpdate = new SQLiteCommand();
            SQLiteCommand _CmdDelete = new SQLiteCommand();

            DataRow _TargetRow;

            string _PrimaryKeyName = "ID";
            int _RecordID = 0;
            long _RecordIDMax = 0;
            decimal _DR, _CR;

            int Insert_Record = 0;
            int Update_Record = 0;

            if (Vou_No.ToUpper() == "NEW")
            {
                CreateNewVoucherNo();                                           // Create a new Voucher Number.

                for (int i = 0; i < VoucherTable.Rows.Count; i++)                // update vou No. Date and Type in Vocuehr Table
                {
                    VoucherTable.Rows[i]["Vou_No"] = Vou_No;
                    VoucherTable.Rows[i]["Vou_Date"] = Conversion.ToDate_DB(Vou_Date);
                    VoucherTable.Rows[i]["Vou_Type"] = Vou_Type;
                }

            }

            foreach (DataRow _Row in VoucherTable.Rows)
            {
                _TargetRow = VoucherTable.NewRow();
                _TargetRow.ItemArray = _Row.ItemArray;

                if (_TargetRow.Table.TableName == string.Empty)
                {
                    MessageBox.Show("Table Name is not Defined.", "_TargetRow.Table.TableName");
                    return;
                }

                _CmdInsert = Connection_Class.SQLite.SQLiteInsert(_TargetRow, Connection.AppliedConnection());
                _CmdUpdate = Connection_Class.SQLite.SQLiteUpdate(_TargetRow, _PrimaryKeyName, Connection.AppliedConnection());
                //_CmdDelete = Connection_Class.SQLite.SQLiteDelete(_Row, _PrimaryKeyName, RecordID);

                _RecordID = Conversion.ToInteger(_TargetRow["ID"]);
                _DR = Convert.ToDecimal(_TargetRow["DR"]);            //Conversion.ToInteger(_Row["DR"]);
                _CR = Convert.ToDecimal(_TargetRow["CR"]);            //Conversion.ToInteger(_Row["DR"]);

                // Cheque Date should be null if cheque no is empty.
                if (_TargetRow["Chq_No"].ToString().Trim() == string.Empty) { _TargetRow["Chq_Date"] = DBNull.Value; }

                if (_RecordID < 0)                                                              // Record Id if -1 (for new)
                {
                    // Add a new record in DataBase.
                    if ((_DR + _CR) == 0) { return; }                                           // Return if Transaction Amount is Zero
                    _RecordIDMax = (long)tbLedger.Compute("MAX(ID)", string.Empty);             // Get Maximum ID of Promary Key Value.
                    _TargetRow["ID"] = _RecordIDMax + 1;                                        // Set Row ID as Maximum Value 


                    if ((long)_TargetRow["ID"] > 0)
                    {
                        _CmdInsert.Parameters["@ID"].Value = (long)_TargetRow["ID"];            // Set SQL Command Paramters Value of PK.
                        Insert_Record = Insert_Record + _CmdInsert.ExecuteNonQuery();           // Execute SQL Command.
                        tbLedger = AppliedTable.GetDataTable((int)Tables.Ledger);               // Reload Target Datable due to new record insert.

                    }
                    else
                    {
                        MessageBox.Show("Primary Key value is not valid." + Keys.Return + "Record not saved.", "(long)_TargetRow['ID']>0");
                    }

                }

                if (_RecordID > 0)
                {
                    if ((_DR + _CR) == 0)                                                       // if Debit and Credit both are zero
                    {
                        // Delete Record if Exist
                    }

                    VoucherView.RowFilter = string.Concat("ID=", _RecordID.ToString());         // Select a record in table view 

                    if (VoucherView.Count == 1)                                                 // Record exist
                    {
                        // Update record in DataBase.
                        Update_Record = Update_Record + _CmdUpdate.ExecuteNonQuery();           // update record in Database Table.
                    }

                    if (VoucherView.Count > 1)                                                  // if records found more than 1 is error
                    {
                        // Declare Error if Target Rows found more than one.
                        MessageBox.Show(VoucherView.Count.ToString() + " Records found.", "ERROR");
                    }
                }
            }

            if (Insert_Record + Update_Record > 0)                                              // show Message for save the record.
            {
                string _SaveMessage = "";
                if (Insert_Record > 0) {_SaveMessage += string.Concat(Insert_Record, " Record(s) INSERTED.", "\n Voucher | ",Vou_No ); }
                if (_SaveMessage.Length > 0) { _SaveMessage += Environment.NewLine; }
                if (Update_Record > 0) { _SaveMessage += string.Concat(Update_Record, " Record(s) UPDATED.", "\n Voucher | ", Vou_No); }

                MessageBox.Show(_SaveMessage, "VOUCHER | " + Vou_No, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Voucher_Saved = true;
            }
        }


        //------------------------------------------------------------ GET NEW VOUCHER NUMBER
        private void CreateNewVoucherNo()                           // Create New Voucher Number.
        {

            if (Vou_No.ToUpper() != "NEW") { return; }            // Return If Voucher is not new

            Vou_No = "";
            CurrentYear = Applied.GetInteger("CurrentYear");

            string _VouType = "";

            switch (Vou_Type)
            {

                case "Journal":
                    _VouType = "J";
                    break;

                case "Payment":
                    _VouType = "P";
                    break;

                case "Receipt":
                    _VouType = "R";
                    break;

                case "Revenue":
                    _VouType = "S";
                    break;

                case "Salary":
                    _VouType = "P";
                    break;

                case "Stock":
                    _VouType = "I";
                    break;

                default:
                    _VouType = "";
                    break;
            }

            string _Year = CurrentYear.ToString().Substring(2, 2);           // Get Year
            string _Month = Vou_Date.Month.ToString("D2");                   // Get Month

            Vou_No = string.Concat(_VouType, _Year, _Month);                 // Set Gross Voucher No.

            DataTable _DataTable = AppliedTable.GetDataTable((int)Tables.View_VouNo);
            DataView _DataView = new DataView(_DataTable);
            _DataView.RowFilter = "Voucher='" + Vou_No.Trim() + "'";
            int _MaxID = 0;

            if (_DataView.Count == 0) { _MaxID = 1; }
            else
            {
                _MaxID = Conversion.ToInteger(_DataView[0]["MaxNo"]);
                _MaxID = _MaxID + 1;


                // final Set Voucehr Number for New voucehr;

            }

            Vou_No = string.Concat(_VouType, _Year, _Month, "-", _MaxID.ToString("D4"));

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

        #region Grid Table

        public DataTable GetGridTable()
        {
            if (Vou_No == null) { return new DataTable(); }             // Return Empty if null
            if (Vou_No.Length == 0) { return new DataTable(); }         // Return Empty if empty.

            DataTable _Result;

            string _Command = "SELECT [Ledger].[SRNO], [COA].[Title] AS [Account], " +
                              "[Suppliers].[Title] AS [Vandor],DR AS [Debit],CR AS [Credit], " +
                              "[Description] FROM [Ledger] " +
                              "LEFT JOIN[COA]       ON [COA].[ID]       = [Ledger].[COA]" +
                              "LEFT JOIN[Suppliers] ON [Suppliers].[ID] = [Ledger].[Supplier]" +
                              "WHERE Vou_No='" + Vou_No + "'";

            _Result = AppliedTable.GetDataTable(_Command);

            if (_Result.Rows.Count == 0) { return new DataTable(); }           // Return Empty id rows are zero


            DataRow _GridRow = _Result.NewRow();
            int RowCount = _Result.Rows.Count;
            decimal Tot_DR = (decimal)_Result.Compute("Sum(Debit)", string.Empty);
            decimal Tot_CR = (decimal)_Result.Compute("Sum(Credit)", string.Empty);
            long MaxSrNo = (long)_Result.Compute("Max(SRNO)", string.Empty);

            _GridRow["SRNO"] = MaxSrNo + 1;
            _GridRow["Account"] = "Transactions = " + _Result.Rows.Count.ToString();
            _GridRow["Vandor"] = "TOTAL";
            _GridRow["Debit"] = Tot_DR;
            _GridRow["Credit"] = Tot_CR;
            _GridRow["Description"] = "";

            _Result.Rows.Add(_GridRow.ItemArray);
            return _Result;
        }


        #endregion

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
                    //PreviewClass.Heading1 = Vou_No + " | " + Conversion.ToPrintDate(MinDate);
                    PreviewClass.Heading1 = Vou_Type + " Voucher";
                    PreviewClass.Heading2 = Vou_Type + " Voucher";
                }
                else
                {
                    PreviewClass.Heading1 = "Vouchers from " + Conversion.ToPrintDate(MinDate) + " to " + Conversion.ToPrintDate(MaxDate);
                    PreviewClass.Heading2 = Vou_Type + " Voucher";

                }

                PreviewClass.Report_From = PreviewClass.Vou_Date;
                

                frmPreview_Reports PreviewVoucher = new frmPreview_Reports(PreviewClass);           // Window form for the report.
                PreviewVoucher.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Record found.");
            }
        }


      


    }       // END Main Class
}           // END NameSpace
