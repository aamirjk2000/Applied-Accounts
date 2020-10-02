using System;
using System.Data;
using System.Security.Policy;
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
        public DataRow MyDataRow { get; set; }                  // Store current row of DataTable
        public DataGridViewRow MyViewRow { get; set; }          // Store current row of Data Grid View
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
                txtFilter.Enabled = true;
            }
            else
            {
                _DataGrid.Enabled = false;
                txtFilter.Enabled = false;
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

                if (ColumnsName[i] == "Active")
                {
                    DataGridViewCheckBoxColumn _Column = new DataGridViewCheckBoxColumn();
                    _Column.Name = ColumnsName[i];
                    _Column.HeaderText = ColumnsName[i];
                    _DataGrid.Columns.Add(_Column);

                }
                else
                {
                    _DataGrid.Columns.Add(ColumnsVisiable[i], ColumnsName[i]);
                }

                _DataGrid.Columns[ColumnsVisiable[i]].Width = ColumnsWidth[i];
                _DataGrid.Columns[ColumnsVisiable[i]].DataPropertyName = ColumnsVisiable[i];
                _DataGrid.Columns[ColumnsVisiable[i]].DefaultCellStyle.Format = AppliedClass.Get_Format(ColumnsFormat[i]);
            }
        }

        private void Data_Filter()                                          // Filter for Data Table.
        {
            string _Filter;
            _Filter = string.Concat("Title like '%", txtFilter.Text, "%'" + " OR ");
            _Filter += string.Concat("Code like '%", txtFilter.Text, "%'" + " OR ");
            _Filter += string.Concat("SCode like '%", txtFilter.Text, "%'");
            ((DataView)_DataGrid.DataSource).RowFilter = _Filter;
        }

        private void _DataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_DataGrid.SelectedRows.Count > 0)
            {
                MyViewRow = _DataGrid.SelectedRows[0];
                MyDataRow = ((DataRowView)MyViewRow.DataBoundItem).Row;
            }
        }

        #region Object Load and Leave

        private void AppliedDataGrid_Leave(object sender, EventArgs e)
        {
            if (((DataView)_DataGrid.DataSource).Table.Rows.Count == 0)                 // If Table does not have any record (Empty Table)
            {
                MyViewRow = null;
                MyDataRow = ((DataView)_DataGrid.DataSource).Table.NewRow();
            }
            if (_DataGrid.CurrentRow != null)                                           // Grid View has not selected any row.
            {
                MyViewRow = _DataGrid.CurrentRow;
                MyDataRow = ((DataRowView)MyViewRow.DataBoundItem).Row;
            }
            else                                                                        // Grod View has select a row.
            {
                MyViewRow = _DataGrid.Rows[0];                                          // Select first Row of DataGrid
                MyDataRow = ((DataRowView)MyViewRow.DataBoundItem).Row;
            }
        }

        #endregion

        private void AppliedDataGrid_Enter(object sender, EventArgs e)
        {
            int _TableID = (int)Enum.Parse(typeof(Tables), MyDataView.Table.TableName);
            MyDataView = AppliedTable.GetDataTable(_TableID).AsDataView();
            _DataGrid.DataSource = MyDataView;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            txtFilter.Refresh();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            Data_Filter();
            _DataGrid.Refresh();
        }

        private void _DataGrid_Enter(object sender, EventArgs e)
        {
            // Select a record from record edit
            AppliedDataGrid_Leave(sender, e);
        }

        private void _DataGrid_Leave(object sender, EventArgs e)
        {
            // select a record for record edit 
            AppliedDataGrid_Leave(sender, e);
        }

        private void _DataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int _TableID = AppliedTable.GetTable_ID(MyDataRow.Table);           // Get Enum ID of Row Table
            ThisTable _DataTable = new ThisTable(AppliedTable.GetDataTable(_TableID));

            if (_DataGrid.CurrentRow != null)                                  // Grid View has not selected any row.
            {
                MyViewRow = _DataGrid.CurrentRow;
                MyDataRow = ((DataRowView)MyViewRow.DataBoundItem).Row;

                if ((bool)MyDataRow["Active"])
                {
                    MyDataRow["Active"] = false;
                }
                else
                {
                    MyDataRow["Active"] = true;
                }

                _DataTable.Save(MyDataRow,false);                     // Save record Active true if false or false if true.
            }
        }


    }           // Main 
}               // Namespace
