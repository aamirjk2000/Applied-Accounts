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
            MyDataView = _DataTable.AsDataView();
            MyDataView.RowFilter = "ID > 0";

            BrowseGrid.DataSource = MyDataView;    //_DataTable.AsDataView();


            if (MyDataView.Count > 0)
            {
                Active = true;
                MyDataRow = _DataTable.Rows[0];
            }
            else
            {
                Active = false;
                MyDataRow = _DataTable.NewRow();
            }

            #region Active
            if (Active)
            {
                BrowseGrid.Enabled = true;
                txtFilter.Enabled = true;
            }
            else
            {
                BrowseGrid.Enabled = false;
                txtFilter.Enabled = false;
            }
            #endregion

        }
        public void Set_Columns()
        {

            IsPressEnter = false;

            //BrowseGrid.DataSource = MyDataView;
            BrowseGrid.ReadOnly = true;
            BrowseGrid.AllowUserToAddRows = false;
            BrowseGrid.AllowUserToDeleteRows = false;

            BrowseGrid.AutoGenerateColumns = false;
            BrowseGrid.Columns.Clear();

            for (int i = 0; i < ColumnsVisiable.Length; i++)
            {

                if (ColumnsName[i] == "Active")                     // Set Active Column 
                {
                    DataGridViewCheckBoxColumn _Column = new DataGridViewCheckBoxColumn();
                    _Column.Name = ColumnsName[i];
                    _Column.HeaderText = ColumnsName[i];
                    BrowseGrid.Columns.Add(_Column);

                }
                else
                {
                    BrowseGrid.Columns.Add(ColumnsVisiable[i], ColumnsName[i]);
                }

                string _Format = AppliedClass.Get_Format(ColumnsFormat[i]);


                BrowseGrid.Columns[ColumnsVisiable[i]].Width = ColumnsWidth[i];
                BrowseGrid.Columns[ColumnsVisiable[i]].DataPropertyName = ColumnsVisiable[i];
                BrowseGrid.Columns[ColumnsVisiable[i]].DefaultCellStyle.Format = _Format;
            }
        }

        private void Data_Filter()                                          // Filter for Data Table.
        {
            string _Filter;
            _Filter = string.Concat("Title like '%", txtFilter.Text, "%'" + " OR ");
            _Filter += string.Concat("Code like '%", txtFilter.Text, "%'" + " OR ");
            _Filter += string.Concat("SCode like '%", txtFilter.Text, "%'");

            if (MyDataView != null)
            {
                MyDataView.RowFilter = _Filter;
            }

            //((DataView)BrowseGrid.DataSource).RowFilter = _Filter;
        }

        #region Object Load and Leave

        private void AppliedDataGrid_Leave(object sender, EventArgs e)
        {
            if (BrowseGrid == null) { return; }
            if (BrowseGrid.DataSource == null) { return; }

            if (((DataView)BrowseGrid.DataSource).Table.Rows.Count == 0)                 // If Table does not have any record (Empty Table)
            {
                MyViewRow = null;
                MyDataRow = ((DataView)BrowseGrid.DataSource).Table.NewRow();
            }
            if (BrowseGrid.CurrentRow != null)                                           // Grid View has not selected any row.
            {
                MyViewRow = BrowseGrid.CurrentRow;
                MyDataRow = ((DataRowView)MyViewRow.DataBoundItem).Row;
            }
            else                                                                        // Grod View has select a row.
            {
                MyViewRow = BrowseGrid.Rows[0];                                          // Select first Row of DataGrid
                MyDataRow = ((DataRowView)MyViewRow.DataBoundItem).Row;
            }
        }

        #endregion

        private void AppliedDataGrid_Enter(object sender, EventArgs e)
        {
            int _TableID = (int)Enum.Parse(typeof(Tables), MyDataView.Table.TableName);
            MyDataView = AppliedTable.GetDataTable(_TableID).AsDataView();
            BrowseGrid.DataSource = MyDataView;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            txtFilter.Refresh();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            Data_Filter();
            BrowseGrid.Refresh();
        }

        private void AppliedDataGrid_Leave_1(object sender, EventArgs e)
        {
            if (MyDataRow == null) { return; }
            DataGridViewRow _DataRow = BrowseGrid.CurrentRow;

            if (_DataRow != null)
            {
                MyDataRow = ((DataRowView)_DataRow.DataBoundItem).Row;
            }
        }

        private void _DataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (BrowseGrid.Columns[e.ColumnIndex].Name == "Active")                     // Only Work of Active Column clock
            {
                int _TableID = AppliedTable.GetTable_ID(MyDataRow.Table);           // Get Enum ID of Row Table
                ThisTable _DataTable = new ThisTable(AppliedTable.GetDataTable(_TableID));

                if (BrowseGrid.CurrentRow != null)                                  // Grid View has not selected any row.
                {
                    MyViewRow = BrowseGrid.CurrentRow;
                    MyDataRow = ((DataRowView)MyViewRow.DataBoundItem).Row;

                    if ((bool)MyDataRow["Active"])
                    {
                        MyDataRow["Active"] = false;
                    }
                    else
                    {
                        MyDataRow["Active"] = true;
                    }

                    _DataTable.Save(MyDataRow, false);                     // Save record Active true if false or false if true.
                }
            }
        }
    }           // Main 
}               // Namespace
