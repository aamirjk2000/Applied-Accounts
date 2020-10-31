using System;
using System.Data;
using System.Windows.Forms;
using Applied_Accounts.Classes;
namespace Applied_Accounts
{
    public partial class Navigator : UserControl
    {

        public event EventHandler Get_Values;                   // Get Values from Row to Text Box 
        public event EventHandler Set_Values;                   // Set Values from Text Box to Data Row
        public event EventHandler New_Record;                   // Invoke when new button press.
        public event EventHandler Before_Save;                  // Invoke before save the record.
        public event EventHandler After_Save;                   // Invoke when Record has been saved after Validation is true.
        public event EventHandler After_Delete;                 // Invoke after delete the record.
        public BindingManagerBase TableBinding;                 // Binding Manager for navigation of records.
        public BindingSource MyBindingSource = new BindingSource();                // DataSource of Binding source;
        public DataRow OriginalRow;
        public DataRow NewRow;
        private Code_Validation Code_Validate;
        

        public long MyID;
        public string MyMessage;
        public bool IsValided;
        public int MyTableID;
        public int NewRecordPosition = 0;
        public int Cancel_Position = 0;
        public int Current_Mode {get; set;;
        public bool NewRow_Valid = true;


        //======================================== Do not Delete these two lines.

        internal ThisTable TableClass;
        public DataTable MyDataTable { get => TableClass.MyDataTable; }
        public DataView MyDataView { get => TableClass.MyDataView; }

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
            txtPointer.Text = (TableBinding.Position + 1).ToString();
            OriginalRow = ((DataRowView)TableBinding.Current).Row;

            if (TableClass.Count > 0)                   // If Data Table has some records.
            {
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
                Buttons_Display(1);             // Enable or Disable buttons for table is empty
            }

        }

        #endregion

        #region Buttons Codes
        //================================================================ buttons codes
        private void btnTop_Click(object sender, EventArgs e)
        {
            TableBinding.Position = 0;
            txtPointer.Text = (TableBinding.Position + 1).ToString();
            OriginalRow = ((DataRowView)TableBinding.Current).Row;
        }
        private void btnPrior_Click(object sender, EventArgs e)
        {
            TableBinding.Position -= 1;
            txtPointer.Text = (TableBinding.Position + 1).ToString();
            OriginalRow = ((DataRowView)TableBinding.Current).Row;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            TableBinding.Position += 1;
            txtPointer.Text = (TableBinding.Position + 1).ToString();
            OriginalRow = ((DataRowView)TableBinding.Current).Row;
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            TableBinding.Position = TableBinding.Count - 1;
            txtPointer.Text = (TableBinding.Position + 1).ToString();
            OriginalRow = ((DataRowView)TableBinding.Current).Row;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {

            New_Record(sender, e);
            Cancel_Position = TableBinding.Position;                                    // Save current posision for Jump on event of cancled.
            MyBindingSource.AddNew();

            NewRecordPosition = TableBinding.Count - 1;
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

            //Set_Values.Invoke(sender, e);
            Before_Save(sender, e);


            if (!NewRow_Valid)
            {
                MessageBox.Show(MyMessage, "ERROR");
                return;
            }

            DataRow NewRow = ((DataRowView)TableClass.MyDataView[NewRecordPosition]).Row;
            TableClass.MyDataRow = NewRow;


            if ((long)TableClass.MyDataRow[TableClass.MyPrimaryKeyName] == -1)
            {
                TableClass.MyDataRow[TableClass.MyPrimaryKeyName] = TableClass.GetMaxID() + 1;              // Get Maximum ID
                TableClass.MyPrimaryKeyValue = (long)TableClass.MyDataRow[TableClass.MyPrimaryKeyName];
            }

            MyMessage = TableClass.Save();

            if (TableClass.IsSaved)
            {
                MyMessage = TableClass.MyMessage;
                MessageBox.Show(MyMessage, "RECORD SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TableClass.OriginalRow = TableClass.MyDataRow;
                After_Save.Invoke(sender, e);

                if (TableClass.Count > 1) { Buttons_Display(3); }
                else { Buttons_Display(4); }
                //Get_Values.Invoke(sender, e);                      // Invoke Get Value Prcedure
                TableClass.Update(TableClass.MyTableID);           // Update Datatable from DB after save row

                TableClass.Row_Index = TableClass.MyDataTable.Rows.IndexOf(TableClass.MyDataRow);

            }
            else
            {
                MyMessage = TableClass.MyMessage;
                MessageBox.Show(MyMessage, "RECORD NOT SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Buttons_Display(-1);

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


        public void Buttons_Display(int _Value)
        {
            switch (_Value)
            {
                case 1:                                     // Disable butons if table has not row.
                    btnTop.Enabled = false;
                    btnNext.Enabled = false;
                    btnPrior.Enabled = false;
                    btnLast.Enabled = false;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;
                    btnDel.Enabled = false;
                    btnCancel.Enabled = false;
                    txtPointer.Enabled = false;
                    break;

                case 2:                                    // New Record is in edit mode
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

                case 3:                                    // Table has records more than 1
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

                case 4:                                    // Table has 1 record.
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
            //Code_Validate = new Code_Validation((TextBox)sender, MyDataTable);
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

            //Code_Validate.Current_Mode = (int)Applied.Modes.Edit;
            //Code_Validate.Input_char = "0123456789";
            //Code_Validate.chkLength = true;
            //Code_Validate.Length = 6;
            //if (Code_Validate.Validating())
            //{

            //if (Current_Mode == (int)Applied.Modes.Edit)
            //{
            DataView _DataView = MyDataTable.AsDataView();
            DataRowView _RowView;

            _DataView.RowFilter = "Code='" + Code_Validate.GetText() + "'";
            if (_DataView.Count == 1)
            {
                _RowView = _DataView[0];
                TableBinding.Position = MyDataTable.Rows.IndexOf(_RowView.Row);         // Get Point
                txtPointer.Text = TableBinding.Position.ToString();
                MyMessage = "Code found in List";
                _DataView.RowFilter = string.Empty;
            }
            else
            {
                TableBinding.Position = TableBinding.Count - 1;
                MyMessage = "Validated: Record not point.";

                return;
            }
            //}
        }
    }       // Main
}           // Namespace
