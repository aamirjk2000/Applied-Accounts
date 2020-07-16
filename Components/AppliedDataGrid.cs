using System;
using System.Data;
using System.Windows.Forms;
using Applied_Accounts.Classes;

namespace Applied_Accounts
{
    public partial class AppliedDataGrid : UserControl
    {
        public AppliedDataGrid()                            // Initialize the object.
        {
            InitializeComponent();
            IsBrowseWin = false;

        }

        //public event EventHandler RecordLeaved;
        
        public DataView MyDataView { get; set; }                // Data View in Grid
        public DataRow MyDataRow { get; set; }                  // Store current row of DataGrid
        public DataGridViewRow MyViewRow { get; set; }          // Store current row of DataView
        public string[] ColumnsName { get; set; }               // Names of Data table Columbns
        public int[] ColumnsWidth { get; set; }                 // Width of Grid columns
        public string[] ColumnsVisiable { get; set; }           // Visiable Columns of Table
        public int[] ColumnsFormat { get; set; }                // Grid Columns format
        public long RecordID { get; set; }                      // Record ID of Data Table.
        public bool IsBrowseWin { get; set; }                   // This object called by Browse Window
        public bool IsPressEnter { get; set; }                  // Leave this object by user press enter.
        public bool Active { get; set; }                        // this object is active when table has row(s).

        public void Load_Data(DataTable _DataTable)
        {
            if (_DataTable.Rows.Count > 0)
            {
                Active = true;
                MyDataView = new DataView(_DataTable);
                MyDataRow = _DataTable.Rows[0];
                _DataGrid.DataSource = MyDataView;
            }
            else
            {
                Active = false;
                MyDataView = new DataView();
                MyDataRow = _DataTable.NewRow();
            }

            #region Active
            if (Active)
            {
                _DataGrid.Enabled = true;
                txtCode.Enabled = true;
                txtTag.Enabled = true;
                txtTitle.Enabled = true;
            }
            else
            {
                _DataGrid.Enabled = false;
                txtCode.Enabled = false;
                txtTag.Enabled = false;
                txtTitle.Enabled = false;
            }
            #endregion

        }
        public void Set_Columns()
        {

            IsPressEnter = false;

            _DataGrid.DataSource = MyDataView;
            _DataGrid.ReadOnly = true;
            _DataGrid.AllowUserToAddRows = false;
            _DataGrid.AllowUserToDeleteRows = false;

            _DataGrid.AutoGenerateColumns = false;
            _DataGrid.Columns.Clear();
            for (int i = 0; i < ColumnsVisiable.Length; i++)
            {
                _DataGrid.Columns.Add(ColumnsVisiable[i], ColumnsName[i]);
                _DataGrid.Columns[ColumnsVisiable[i]].Width = ColumnsWidth[i];
                _DataGrid.Columns[ColumnsVisiable[i]].DataPropertyName = ColumnsVisiable[i];
                _DataGrid.Columns[ColumnsVisiable[i]].DefaultCellStyle.Format = AppliedClass.Get_Format(ColumnsFormat[i]);
            }
            
        }
        
        // Text Box (Filters) Codes
        #region Text Box Codes

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            Data_Filter();
        }
        private void txtCode_Leave(object sender, EventArgs e)
        {
            _DataGrid.Focus();
        }
        private void txtTag_TextChanged(object sender, EventArgs e)
        {
            Data_Filter();
        }
        private void txtTag_Leave(object sender, EventArgs e)
        {
            _DataGrid.Focus();
            
        }
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            Data_Filter();
        }
        private void txtTitle_Leave(object sender, EventArgs e)
        {
            _DataGrid.Focus();
        }

        #endregion

        private void Data_Filter()
        {
            string Filter1 = string.Concat("Code like '", txtCode.Text, "%'");
            string Filter2 = string.Concat("SCode like '%", txtTag.Text, "%'");
            string Filter3 = string.Concat("Title like '%", txtTitle.Text, "%'");
            MyDataView.RowFilter = string.Concat(Filter1, " AND ", Filter2, " AND ", Filter3);
        }
        private void lblMessage_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtTag.Text = "";
            txtTitle.Text = "";
            Data_Filter();

        }

        private void _DataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(_DataGrid.SelectedRows.Count>0)
            { 
                MyViewRow = _DataGrid.SelectedRows[0];
                MyDataRow = (DataRow)((DataRowView)MyViewRow.DataBoundItem).Row;
            }
        }

        private void _DataGrid_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if(((DataView)_DataGrid.DataSource).Table.Rows.Count==0)                // If Table does not have any record (Empty Table)
            {
                MyViewRow = null;
                MyDataRow = ((DataView)_DataGrid.DataSource).Table.NewRow();
            }

            if (_DataGrid.CurrentRow!=null)                                   // Grid View has not selected any row.
            {
                MyViewRow = _DataGrid.CurrentRow;
                MyDataRow = ((DataRowView)MyViewRow.DataBoundItem).Row;
            }
            else                                                                    // Grod View has select a row.
            {
                MyViewRow = _DataGrid.Rows[0];                                      // Select first Row of DataGrid
                MyDataRow = ((DataRowView)MyViewRow.DataBoundItem).Row;
            }

        }
    }           // Main 
}               // Namespace
