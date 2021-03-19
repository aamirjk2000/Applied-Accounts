using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Applied_Accounts.Classes;

namespace Applied_Accounts.Classes
{
    interface IVoucherClass1
    {

        void Insert(DataRow _Row);
        void Update(DataRow _Row);
        void Delete(DataRow _Row);
        void Load_Tables();
        void Load_Voucher(string _Vou_No);
        DataTable Create_GridTable();
        void New();
        bool Is_Balanced();
        bool Is_Edited();

    }


    public class VoucherClass1 : IVoucherClass1
    {
        public DataSet ds_Voucher;
        public DataTable tb_Voucher { get => ds_Voucher.Tables["Ledger"]; }
        public DataTable tb_Voucher_Delete;
        public DataTable tb_Voucher_Original;
        public DataTable tb_GridData;

        public string Vou_No;
        public DateTime Vou_Date;
        public string Vou_Type;
        public string Vou_Status;

        public int Count { get => tb_Voucher.Rows.Count; }
        public object DR_Amount { get => tb_Voucher.Compute("Sum(DR)", "SRNO>-1"); }
        public object CR_Amount { get => tb_Voucher.Compute("Sum(CR)", "SRNO>-1"); }

        public DataRow MyRow { get; set; }

        public Array Vou_Types = Enum.GetValues(typeof(Applied.VoucherType));
        public bool Voucher_Loaded = false;                             //  True if, Voucher has been loaded sucessfully
        public bool Voucher_Saved = true;                               //
        public bool New_Record = false;                                 //
        public bool Save_Sucessfull = false;                            //  True if, Voucher has been saved sucessfull
        public bool Record_is_Saved = false;
        public int Effected_Records = 0;
        public string MyMessage = "";
        public long Max_ID;

        public enum Voucher_Status
        {
            Insert = 1,
            Update = 2,
            Delete = 3,
            Posted = 4
        }

        //===============================================================================================

        #region Initialization

        public VoucherClass1()
        {

            Load_Tables();

            //Vou_No = "J0319-0007";
            Vou_No = "";
            Vou_Date = DateTime.Now;
            Vou_Type = string.Empty;
            Vou_Status = "New";

            //MyRow = tb_Voucher.NewRow();

        }

        public VoucherClass1(string _VouNo)
        {
            Load_Tables();
            Get_Voucher(_VouNo);
            tb_GridData = Create_GridTable();
        }

        public void Load_Tables()
        {
            ds_Voucher = null;                                                                  // Reset the Data Set for initialize
            ds_Voucher = new DataSet();
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.Ledger).Clone());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.COA).Copy());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.Suppliers).Copy());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.Projects).Copy());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.Units).Copy());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.Stock).Copy());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.Employees).Copy());
            ds_Voucher.Tables.Add(AppliedTable.GetDataTable(Tables.POrder).Copy());

            ds_Voucher.Relations.Add("rlt_COA", ds_Voucher.Tables["COA"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["COA"]);
            ds_Voucher.Relations.Add("rlt_PRJ", ds_Voucher.Tables["Projects"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Project"]);
            ds_Voucher.Relations.Add("rlt_SUP", ds_Voucher.Tables["Suppliers"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Supplier"]);
            ds_Voucher.Relations.Add("rlt_UNI", ds_Voucher.Tables["Units"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Unit"]);
            ds_Voucher.Relations.Add("rlt_STK", ds_Voucher.Tables["Stock"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Stock"]);
            ds_Voucher.Relations.Add("rlt_EMP", ds_Voucher.Tables["Employees"].Columns["ID"], ds_Voucher.Tables["Ledger"].Columns["Employee"]);

            tb_Voucher_Delete = ds_Voucher.Tables["Ledger"].Clone();
            tb_GridData = Create_GridTable();

        }


        #endregion

        #region Voucher Load

        public void Load_Voucher(string _Vou_No)
        {
            Get_Voucher(_Vou_No);

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

        #endregion

        #region Insert / Update / Delete 

        public void Save(DataTable _Voucher)
        {
            if (!Is_Balanced())
            {
                string _Message = string.Format("Voucher Debit and Credirt is not equal. \n {1,15:N0} Debit & {1,15:N0} Credit ", (decimal)DR_Amount, (decimal)CR_Amount);
                MessageBox.Show(_Message, "Voucher", MessageBoxButtons.OK);
                return;
            }
            //=========================================================================================== RETURN 

            DataView View_Ledger = AppliedTable.GetDataTable(Tables.Ledger).AsDataView();
            long _ID = 0;
            string Action = "";
            int _SRNO_NEW = 1;
            Effected_Records = 0;
            Max_ID = Conversion.ToLong(View_Ledger.Table.Compute("MAX(ID)", string.Empty).ToString());

            foreach (DataRow _Row in _Voucher.Rows)
            {
                _ID = Conversion.ToLong(_Row["ID"].ToString());
                int _SRNO = Conversion.ToInteger(_Row["SRNO"].ToString());

                if (_ID == 0)
                {
                    Action = "Insert";
                }
                else if (_ID > 0)
                {
                    Action = "Update";
                }

                //===================================== DELETE IF SERIAL IS IN NEGATIVE.
                if (_SRNO < 0)
                {
                    Action = "Delete";
                }

                #region Set Null Values if applicable.
                _Row["Vou_No"] = Vou_No;
                _Row["Vou_Date"] = Vou_Date;
                _Row["Vou_Type"] = Vou_Type;
                _Row["SRNO"] = _SRNO_NEW; _SRNO_NEW += 1;
                if (Conversion.ToLong(_Row["Project"].ToString()) == 0) { _Row["Project"] = 0; }
                if (Conversion.ToLong(_Row["Supplier"].ToString()) == 0) { _Row["Supplier"] = 0; }
                if (Conversion.ToLong(_Row["Unit"].ToString()) == 0) { _Row["Unit"] = 0; }
                if (Conversion.ToLong(_Row["Stock"].ToString()) == 0) { _Row["Stock"] = 0; }
                if (Conversion.ToLong(_Row["Employee"].ToString()) == 0) { _Row["Employee"] = 0; }
                if (Conversion.ToLong(_Row["POrder"].ToString()) == 0) { _Row["POrder"] = 0; }
                if (string.IsNullOrWhiteSpace(_Row["RefNo"].ToString())) { _Row["RefNo"] = DBNull.Value; }
                if (string.IsNullOrWhiteSpace(_Row["Remarks"].ToString())) { _Row["Remarks"] = DBNull.Value; }
                if (string.IsNullOrWhiteSpace(_Row["Chq_No"].ToString())) { _Row["Chq_No"] = DBNull.Value; _Row["Chq_Date"] = DBNull.Value; };
                #endregion
                //}

                switch (Action)
                {
                    case "Insert":
                        Insert(_Row);
                        break;

                    case "Update":
                        Update(_Row);
                        break;

                    case "Delete":
                        Delete(_Row);
                        break;
                }
            }

            MyMessage = "Total record effected " + Effected_Records.ToString();
            MessageBox.Show(MyMessage, "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tb_Voucher_Original = ds_Voucher.Tables["Ledger"].Copy();

        }

        public void Insert(DataRow _Row)
        {
            SQLiteCommand _CmdInsert = new SQLiteCommand();
            try
            {
                _Row["ID"] = Max_ID + 1;
                _CmdInsert = Connection_Class.SQLite.SQLiteInsert(_Row, Connection.AppliedConnection());
                Effected_Records += _CmdInsert.ExecuteNonQuery();
                if (Effected_Records > 0) { Record_is_Saved = true; } else { Record_is_Saved = false; }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        public void Update(DataRow _Row)
        {
            SQLiteCommand _CmdUpdate = new SQLiteCommand();
            try
            {
                _CmdUpdate = Connection_Class.SQLite.SQLiteUpdate(_Row, "ID", Connection.AppliedConnection());
                Effected_Records += _CmdUpdate.ExecuteNonQuery();
                if (Effected_Records > 0) { Record_is_Saved = true; } else { Record_is_Saved = false; }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        public void Delete(DataRow _Row)
        {

            SQLiteCommand _CmdDelete = new SQLiteCommand();
            try
            {
                _CmdDelete = Connection_Class.SQLite.SQLiteDelete(_Row, Connection.AppliedConnection());
                Effected_Records = _CmdDelete.ExecuteNonQuery();
                if (Effected_Records > 0) { Record_is_Saved = true; } else { Record_is_Saved = false; }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }

        #endregion

        #region New

        public void New()                                                               // New Voucher Transaction [SR No]
        {
            long MaxNo;
            DataRow _NewRow = tb_Voucher.NewRow();
            _NewRow.BeginEdit();


            if (tb_Voucher.Rows.Count==0)
            {
                MaxNo = 1;
            }
            else
            {
                MaxNo = (long)tb_Voucher.Compute("Max(SRNO)", string.Empty) + 1;
            }
            
            _NewRow["ID"] = 0;
            _NewRow["Vou_No"] = Vou_No;
            _NewRow["Vou_Date"] = Vou_Date;
            _NewRow["Vou_Type"] = Vou_Type;
            _NewRow["SrNO"] = MaxNo;
            tb_Voucher.Rows.Add(_NewRow);

            Load_GridData();
            New_Record = true;


        }


        #endregion

        #region Set VoucherTable
        private DataTable Get_Voucher(string _VouNo)
        {
            DataTable _DataTable;

            if (_VouNo.ToUpper().Trim() == "NEW")
            {
                Vou_No = "New";
                Vou_Status = "Insert";
                Vou_Date = DateTime.Now;
                Vou_Type = "";
                tb_Voucher_Original = null;
                Load_Tables();
            }

            //====================================================== New Voucher END

            _DataTable = AppliedTable.GetDataTable(Tables.Ledger, "Vou_No='" + _VouNo + "'");

            if (_DataTable.Rows.Count > 0)
            {
                Vou_Status = Voucher_Status.Update.ToString();
                ds_Voucher.Tables["Ledger"].Clear();
                foreach (DataRow _Row in _DataTable.Rows)
                {
                    ds_Voucher.Tables["Ledger"].Rows.Add(_Row.ItemArray);
                }

                tb_Voucher_Original = ds_Voucher.Tables["Ledger"].Copy();                      // Store Voucher Original Data in saperate Table.
            }

            return _DataTable;
        }

        #endregion

        #region Grid Table
        public DataTable Create_GridTable()
        {
            DataTable GridTable = new DataTable();

            GridTable.Columns.Add("SrNo", typeof(string));
            GridTable.Columns.Add("Vou_No", typeof(string));
            GridTable.Columns.Add("Vou_Date", typeof(DateTime));
            GridTable.Columns.Add("Account", typeof(string));
            GridTable.Columns.Add("Cheque", typeof(string));
            GridTable.Columns.Add("Remarks", typeof(string));
            GridTable.Columns.Add("Debit", typeof(decimal));
            GridTable.Columns.Add("Credit", typeof(decimal));
            GridTable.Columns.Add("Status", typeof(string));

            return GridTable;
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
                _GridRow["Account"] = Applied.Title(Conversion.ToLong(_Row["COA"]), ds_Voucher.Tables["COA"].AsDataView());
                _GridRow["Cheque"] = _Row["Chq_No"];
                _GridRow["Remarks"] = _Row["Description"];
                _GridRow["Debit"] = _Row["DR"];
                _GridRow["Credit"] = _Row["CR"];

                if (Conversion.ToInteger(_Row["SRNO"].ToString()) < 0)
                { _GridRow["Status"] = "Delete"; }
                else if (Conversion.ToInteger(_Row["SRNO"].ToString()) == 0)
                { _GridRow["Status"] = "Insert"; }
                else { _GridRow["Status"] = "Update"; }

                tb_GridData.Rows.Add(_GridRow);
            }

            #region ADD ROW FOR TOTAL
            _GridRow = tb_GridData.NewRow();
            _GridRow["SrNo"] = "0";
            _GridRow["Vou_no"] = "";
            _GridRow["Vou_Date"] = DBNull.Value;
            _GridRow["Account"] = "";
            _GridRow["Cheque"] = "";
            _GridRow["Remarks"] = "TOTAL";
            _GridRow["Debit"] = DR_Amount;
            _GridRow["Credit"] = CR_Amount;
            _GridRow["Status"] = "Total";
            tb_GridData.Rows.Add(_GridRow);
            #endregion

        }


        #endregion

        #region Other Codes
        public bool Is_Balanced()
        {

            if(DR_Amount==DBNull.Value  || CR_Amount==DBNull.Value)
            {
                return false;
            }


            if ((decimal)DR_Amount + (decimal)CR_Amount == 0)
            {
                return false;
            }

            if (tb_Voucher.Rows.Count > 0)
            {
                return DR_Amount.Equals(CR_Amount);
            }
            else
            { 
                return false; 
            }
        }

        public bool Is_Edited()
        {
            if(tb_Voucher_Original == null) { return false; }
            return tb_Voucher_Original.Equals(ds_Voucher.Tables["Ledger"]);
        }

        #endregion

        #region Print Voucher

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
                    PreviewClass.Heading1 = Vou_Type + " Voucher";
                    PreviewClass.Heading2 = Vou_Type + " Voucher";
                }
                else
                {
                    PreviewClass.Heading1 = "Vouchers from " + Conversion.ToPrintDate(MinDate) + " to " + Conversion.ToPrintDate(MaxDate);
                    PreviewClass.Heading2 = Vou_Type + " Voucher";

                }

                PreviewClass.Report_From = PreviewClass.Vou_Date;

                Preview.frmPreview_Reports PreviewVoucher = new Preview.frmPreview_Reports(PreviewClass);           // Window form for the report.
                PreviewVoucher.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Record found.");
            }
        }

        #endregion

    }       // END Class
}           // END NameSpace
