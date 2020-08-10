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
        //public event EventHandler Before_Save;                // Invoke before save the record.
        public event EventHandler After_Save;                   // Invoke when Record has been saved after Validation is true.
        public event EventHandler After_Delete;                 // Invoke after delete the record.
        

        public long MyID;
        public string MyMessage;
        public bool IsValided;
        public int MyTableID;


        //======================================== Do not Delete these two lines.
        private ThisTable tableClass;
        internal ThisTable TableClass { get => tableClass; set => tableClass = value; }
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
            //if (TableClass==null) { TableClass = new ThisTable(_DataTable); } 
            //else { TableClass.MyDataTable = _DataTable; }

            TableClass = new ThisTable(_DataTable);

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
            if (TableClass.MyDataTable.Rows.Count>0)
            { 
                TableClass.MyDataRow = TableClass.MyDataTable.Rows[0];
                TableClass.OriginalRow = TableClass.MyDataRow;
            }
            else
            { 
                TableClass.MyDataRow = TableClass.GetNewRow();
                TableClass.OriginalRow = TableClass.MyDataRow;
            }
            Get_Values.Invoke(sender,e);
        }
        private void btnPrior_Click(object sender, EventArgs e)
        {
            //if (TableClass.MyDataTable.Rows.Count > 0)
            //{
            //    TableClass.Row_Index -= 1;
            //    if (TableClass.Row_Index < 0) { TableClass.Row_Index = 0; }
            //    TableClass.MyDataRow = TableClass.MyDataTable.Rows[TableClass.Row_Index];
            //    TableClass.OriginalRow = TableClass.MyDataRow;
            //}
            //else
            //{ 
            //    TableClass.MyDataRow = TableClass.GetNewRow();
            //    TableClass.OriginalRow = TableClass.MyDataRow;
            //}

            TableClass.Previous();
            Get_Values.Invoke(sender, e);
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            TableClass.MoveNext();

            //if ((TableClass.MyDataTable.Rows.Count -1) >= 0)
            //{
                

            //    //TableClass.Row_Index += 1; 
            //    //if(TableClass.Row_Index > TableClass.Count-1) { TableClass.Row_Index = TableClass.Count-1; }
            //    //TableClass.MyDataRow = TableClass.MyDataTable.Rows[TableClass.Row_Index];
            //    //TableClass.OriginalRow = TableClass.MyDataRow;
            //}
            //else
            //{ 
            //    TableClass.MyDataRow = TableClass.GetNewRow();
            //    TableClass.OriginalRow = TableClass.MyDataRow;
            //}

            Get_Values.Invoke(sender, e);

        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            if (TableClass.MyDataTable.Rows.Count > 0)
            { 
                TableClass.MyDataRow = TableClass.MyDataTable.Rows[TableClass.MyDataTable.Rows.Count-1];
                TableClass.OriginalRow = TableClass.MyDataRow;
            }
            else
            { 
                TableClass.MyDataRow = TableClass.GetNewRow();
                TableClass.OriginalRow = TableClass.MyDataRow;
            }
            Get_Values.Invoke(sender, e);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            TableClass.MyDataRow = TableClass.GetNewRow();
            TableClass.OriginalRow = TableClass.MyDataRow;

            New_Record.Invoke(sender, e);
            Get_Values.Invoke(sender, e);
            
        }
        private void BtnSave_Click(object sender, EventArgs e)              // Save Record
        {
           
            Set_Values.Invoke(sender, e);
            Before_Save(sender, e);

            if ((long)TableClass.MyDataRow[TableClass.MyPrimaryKeyName]==-1)
            {
                TableClass.MyDataRow[TableClass.MyPrimaryKeyName] = TableClass.GetMaxID() + 1;              // Get Maximum ID
                TableClass.MyPrimaryKeyValue = (long)TableClass.MyDataRow[TableClass.MyPrimaryKeyName];
            }

            MyMessage = TableClass.Save();

            if(TableClass.IsSaved)
            {
                MyMessage = TableClass.MyMessage;
                MessageBox.Show(MyMessage, "RECORD SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TableClass.OriginalRow = TableClass.MyDataRow;
                After_Save.Invoke(sender, e);

                if(TableClass.Count>1) { Buttons_Display(3); }
                else { Buttons_Display(4); }
                Get_Values.Invoke(sender, e);           // Invoke Get Value Prcedure
                TableClass.Update(MyTableID);          // Update Datatable from DB after save row

                TableClass.Row_Index = tableClass.MyDataTable.Rows.IndexOf(TableClass.MyDataRow);

            }
            else
            {
                MyMessage = TableClass.MyMessage;
                MessageBox.Show(MyMessage, "RECORD NOT SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            Set_Values.Invoke(sender, e);
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
            Get_Values.Invoke(sender, e);
        }

        //===============================================================================================
        #endregion

        #region Events

        private void Before_Save(object sender, EventArgs e)
        {
        }

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
                    break;
            }
        }

        #endregion

        
    }       // Main
}           // Namespace
