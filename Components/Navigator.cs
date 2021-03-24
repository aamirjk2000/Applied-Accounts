using System;
using System.Data;
using System.Windows.Forms;
using Applied_Accounts.Classes;
namespace Applied_Accounts
{
    public partial class Navigator : UserControl
    {

        public event EventHandler New_Record;                   // Invoke when new button press.
        public event EventHandler Before_Save;                  // Invoke before save the record.
        public event EventHandler After_Save;                   // Invoke when Record has been saved after Validation is true.
        public event EventHandler After_Delete;                 // Invoke after delete the record.
        public BindingManagerBase TableBinding;                                     // Binding Manager for navigation of records.
        public BindingSource MyBindingSource = new BindingSource();                // DataSource of Binding source;
        public DataRow OriginalRow;
        public DataRow NewRow;
        //private Code_Validation Code_Validate;


        public int Current_Mode { get; set; }
        public long MyID;
        public string MyMessage;
        public bool IsValided;
        public int MyTableID;
        public int NewRecordPosition = 0;
        public int Cancel_Position = 0;
        public bool NewRow_Valid = true;


        //======================================== Do not Delete these two lines.

        internal ThisTable TableClass;
        public DataTable MyDataTable { get => TableClass.MyDataTable; }
        public DataView MyDataView { get => TableClass.MyDataView; }
        public DataRow MyDataRow { get => TableClass.MyDataRow; }


        //======================================== Do not Delete these two lines.

        #region Initialize Class

        public Navigator()
        {
            InitializeComponent();
        }

        public void InitializeClass(int _TableID)
        {
            MyTableID = _TableID;
            DataTable _DataTable = AppliedTable.GetDataTable(MyTableID);
            InitializeClass(_DataTable);
        }

        public void InitializeClass(DataTable _DataTable)
        {
            TableClass = new ThisTable(_DataTable);
            MyBindingSource.DataSource = TableClass.MyDataView;
            TableBinding = BindingContext[MyBindingSource];


            if (TableClass.Count() > 0)                   // If Data Table has some records.
            {

                txtPointer.Text = (TableBinding.Position + 1).ToString();
                OriginalRow = ((DataRowView)TableBinding.Current).Row;

                TableClass.MyDataRow = TableClass.MyDataTable.Rows[0];
                TableClass.MyMessage = "Initialized the Table Class";
                TableClass.MyPrimaryKeyName = "ID";
                TableClass.MyPrimaryKeyValue = (long)TableClass.MyDataTable.Rows[0][TableClass.MyPrimaryKeyName];
                if (!TableClass.Active)
                {
                    btnTop.Enabled = false;                 // Disable butons if table has not row.
                    btnNext.Enabled = false;
                    btnPrior.Enabled = false;
                    btnLast.Enabled = false;
                    btnSave.Enabled = false;
                    btnDel.Enabled = false;
                    txtPointer.Enabled = false;
                }
            }
            else
            {
                TableClass.MyDataRow = TableClass.MyDataTable.NewRow();
                TableClass.MyMessage = "Initialized the Table Class";
                TableClass.MyPrimaryKeyName = "ID";
                TableClass.MyPrimaryKeyValue = -1;
                txtPointer.Text = "Zero";
                OriginalRow = TableClass.MyDataRow;
                MyMessage = "No Record found.";
                Buttons_Display((int)NavButtons.First);             // Enable or Disable buttons for table is empty
            }

        }

        public void InitializeClass(DataSet _DataSet)
        {
            TableClass = new ThisTable(_DataSet);
            MyBindingSource.DataSource = TableClass.MyDataView;
            TableBinding = BindingContext[MyBindingSource];

        }

        #endregion

        #region Buttons Codes
        //================================================================ buttons codes
        private void btnTop_Click(object sender, EventArgs e)
        {
            if (MyDataTable.Rows.Count == 0) { return; }
            TableBinding.Position = 0;
            txtPointer.Text = (TableBinding.Position + 1).ToString();
            OriginalRow = ((DataRowView)TableBinding.Current).Row;
        }
        private void btnPrior_Click(object sender, EventArgs e)
        {
            if (MyDataTable.Rows.Count == 0) { return; }
            TableBinding.Position -= 1;
            txtPointer.Text = (TableBinding.Position + 1).ToString();
            OriginalRow = ((DataRowView)TableBinding.Current).Row;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (MyDataTable.Rows.Count == 0) { return; }
            TableBinding.Position += 1;
            txtPointer.Text = (TableBinding.Position + 1).ToString();
            OriginalRow = ((DataRowView)TableBinding.Current).Row;
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            if (MyDataTable.Rows.Count == 0) { return; }
            TableBinding.Position = TableBinding.Count - 1;
            txtPointer.Text = (TableBinding.Position + 1).ToString();
            OriginalRow = ((DataRowView)TableBinding.Current).Row;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {

            New_Record(sender, e);
            Cancel_Position = TableBinding.Position;                                    // Save current posision for Jump on event of cancled.
            MyBindingSource.AddNew();

            NewRecordPosition = ((DataView)MyBindingSource.DataSource).Count -1;
            TableBinding.Position = NewRecordPosition;

            TableClass.MyDataView[NewRecordPosition]["ID"] = -1;

            if (TableClass.MyDataTable.Columns.Contains("Active"))
            {
                if (TableClass.MyDataView[NewRecordPosition]["Active"] == DBNull.Value)
                {
                    TableClass.MyDataView[NewRecordPosition]["Active"] = true;              // Assign true value is DB is null;
                }
            }

            OriginalRow = ((DataRowView)TableBinding.Current).Row;
            Buttons_Display(2);                                  // Enable or Disable buttons for New voucher profile
            Current_Mode = (int)Applied.Modes.New;               // Row is new

        }
        private void BtnSave_Click(object sender, EventArgs e)              // Save Record
        {
            TableClass.MyDataRow = OriginalRow;

            if (MyDataTable.Rows.Count==0) { Current_Mode = (int)Applied.Modes.Empty; }   // DataTable has no report

            Before_Save(sender, e);

            if (!NewRow_Valid)                              // Validation check from Before_Save Event
            {
                MessageBox.Show(MyMessage, "ERROR");
                return;
            }

            // New Record Added
            if (Current_Mode == (int)Applied.Modes.New)
            {
                TableClass.MyDataRow = TableClass.MyDataView[NewRecordPosition].Row;
            }

            // Edit Mode
            if (Current_Mode == (int)Applied.Modes.Edit)
            {
                TableClass.MyDataRow = ((DataRowView)TableBinding.Current).Row;
            }

            /// Get ID number if value is -1
            if ((Conversion.ToLong(TableClass.MyDataRow[TableClass.MyPrimaryKeyName])) == -1)
            {
                TableClass.MyDataRow[TableClass.MyPrimaryKeyName] = TableClass.GetMaxID() + 1;              // Get Maximum ID
                TableClass.MyPrimaryKeyValue = (long)TableClass.MyDataRow[TableClass.MyPrimaryKeyName];
            }

            /// Save Record.
            MyMessage = TableClass.Save();

            if (TableClass.IsSaved)
            {
                Current_Mode = (int)Applied.Modes.Edit;
                MyMessage = TableClass.MyMessage;
                MessageBox.Show(MyMessage, "RECORD SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TableClass.OriginalRow = TableClass.MyDataRow;
                After_Save.Invoke(sender, e);

                if (TableClass.Count() > 1) { Buttons_Display(3); }
                else { Buttons_Display(4); }
                TableClass.Update(TableClass.MyTableID);           // Update Datatable from DB after save row
                TableClass.Row_Index = TableClass.MyDataTable.Rows.IndexOf(TableClass.MyDataRow);
            }
            else
            {
                MyMessage = TableClass.MyMessage;
                MessageBox.Show(MyMessage, "RECORD NOT SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Buttons_Display((int)NavButtons.Records);

        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            //Set_Values.Invoke(sender, e);
            MyMessage = TableClass.Delete(Convert.ToInt32(TableClass.MyDataRow[TableClass.MyPrimaryKeyName]));

            if (TableClass.IsDeleted)
            {
                MessageBox.Show(TableClass.MyMessage, "RECORD DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                After_Delete.Invoke(sender, e);
            }
            else
            {
                MessageBox.Show(TableClass.MyMessage, "RECORD NOT DELETE ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Restore Original Value of Row and Display on form (TextBox)
            TableClass.MyDataRow = TableClass.OriginalRow;
            TableBinding.Position = Cancel_Position;
            //Get_Values.Invoke(sender, e);
        }
        private void txtPointer_Validated(object sender, EventArgs e)
        {
            int _Pointer = Conversion.ToInteger(((TextBox)sender).Text);

            if (_Pointer < 0) { _Pointer = 0; }
            if (_Pointer > TableBinding.Count - 1) { _Pointer = TableBinding.Count - 1; }
            TableBinding.Position = _Pointer - 1;

        }

        //===============================================================================================
        #endregion

        #region Events

        enum NavButtons
        {
            First = 1,
            Edit = 2,
            Records = 3,
            OneRow = 4,
            SaveRow = 5,
            Add
        }


        public void Buttons_Display(int _Value)
        {
            switch (_Value)
            {
                case (int)NavButtons.First:                                     // Disable butons if table has not row.
                    btnTop.Enabled = false;
                    btnNext.Enabled = false;
                    btnPrior.Enabled = false;
                    btnLast.Enabled = false;
                    btnNew.Enabled = true;
                    btnSave.Enabled = true;
                    btnDel.Enabled = false;
                    btnCancel.Enabled = false;
                    txtPointer.Enabled = false;
                    break;

                case (int)NavButtons.Edit:                                    // New Record is in edit mode
                    btnTop.Enabled = false;
                    btnNext.Enabled = false;
                    btnPrior.Enabled = false;
                    btnLast.Enabled = false;
                    btnNew.Enabled = false;
                    btnSave.Enabled = true;
                    btnDel.Enabled = false;
                    btnCancel.Enabled = true;
                    txtPointer.Enabled = false;
                    break;

                case (int)NavButtons.Records:                                    // Table has records more than 1
                    btnTop.Enabled = true;
                    btnNext.Enabled = true;
                    btnPrior.Enabled = true;
                    btnLast.Enabled = true;
                    btnNew.Enabled = true;
                    btnSave.Enabled = true;
                    btnDel.Enabled = false;
                    btnCancel.Enabled = true;
                    txtPointer.Enabled = true;
                    break;

                case (int)NavButtons.OneRow:                                    // Table has 1 record.
                    btnTop.Enabled = false;
                    btnNext.Enabled = false;
                    btnPrior.Enabled = false;
                    btnLast.Enabled = false;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;
                    btnDel.Enabled = true;
                    btnCancel.Enabled = true;
                    txtPointer.Enabled = false;
                    break;

                case (int)NavButtons.SaveRow:                                    // Table has 1 record.
                    btnTop.Enabled = false;
                    btnNext.Enabled = false;
                    btnPrior.Enabled = false;
                    btnLast.Enabled = false;
                    btnNew.Enabled = false;
                    btnSave.Enabled = true;
                    btnDel.Enabled = false;
                    btnCancel.Enabled = true;
                    txtPointer.Enabled = false;
                    break;

                default:
                    btnTop.Enabled = true;
                    btnNext.Enabled = true;
                    btnPrior.Enabled = true;
                    btnLast.Enabled = true;
                    btnNew.Enabled = true;
                    btnSave.Enabled = true;
                    btnDel.Enabled = true;
                    btnCancel.Enabled = true;
                    txtPointer.Enabled = true;
                    break;
            }
        }

        #endregion

        private void txtPointer_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox _TextBox = (TextBox)sender;

            if (!Applied.IsChar(_TextBox.Text, "0123456789"))
            {
                int _Position = Conversion.ToInteger(_TextBox.Text);
                if (_Position < TableBinding.Count)
                {
                    TableBinding.Position = _Position;              // Get Point.
                    return;                                         // return if position found in List.
                }
            }

            //====================

            DataView _DataView = MyDataTable.AsDataView();
            DataRowView _RowView;

            _DataView.RowFilter = "Code='" + txtPointer.Text.Trim() + "'";
            if (_DataView.Count == 1)
            {
                _RowView = _DataView[0];
                TableBinding.Position = MyDataTable.Rows.IndexOf(_RowView.Row);         // Get Point
                txtPointer.Text = (TableBinding.Position + 1).ToString();
                MyMessage = "Code found in List";
                _DataView.RowFilter = string.Empty;
            }
            else
            {
                TableBinding.Position = TableBinding.Count - 1;
                MyMessage = "Validated: Record not point.";

                return;
            }

        }
    }       // Main
}           // Namespace
