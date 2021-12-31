using System;
using System.Data;
using System.Windows.Forms;
using Applied_Accounts.Classes;

namespace Applied_Accounts
{
    public partial class Browse : Form
    {

        public DataView MyDataView { get => DataGrid_Browse.MyDataView; }
        public DataRow MyDataRow { get => DataGrid_Browse.MyDataRow; }
        public string MyTitle { get; set; }
        public bool IsSelect { get; set; }
        public long MyID { get => Conversion.ToLong(DataGrid_Browse.MyDataRow["ID"]); }
        public string MyCode { get => DataGrid_Browse.MyDataRow["Code"].ToString(); }
        public string OldCode { get; set; }                     // Current / Old Code of the row

        public Browse(DataView _DataView)
        {
            InitializeComponent();
            DataGrid_Browse.MyDataView = _DataView;
            //MyDataView = _DataView;
            MyDataView.RowFilter = "";
            MyRefresh();
        }

        public Browse(DataView _DataView, string _CurrentValue)   // _CurrentValue -> focus on this code / row when browse shows.
        {
            InitializeComponent();
            MyDataView.RowFilter = "";
            OldCode = _CurrentValue;
            MyRefresh();
        }

        public void MyRefresh()
        {
            if (MyTitle == null)
            {
                MyTitle = MyDataView.Table.TableName;
            }

            this.Text = MyTitle;
            IsSelect = false;

            if (MyDataView != null)
            {

                string[] ColumnsVisiable = { "Code", "SCode", "Title" };
                string[] ColumnsName = { "Code", "Tag", "Title" };
                int[] ColumnsFormat = { (int)TextFormat.Codes, 0, 0 };
                int[] ColumnsWidth = { 75, 75, 350 };

                DataGrid_Browse.ColumnsName = ColumnsName;
                DataGrid_Browse.ColumnsWidth = ColumnsWidth;
                DataGrid_Browse.ColumnsVisiable = ColumnsVisiable;
                DataGrid_Browse.ColumnsFormat = ColumnsFormat;
                DataGrid_Browse.MyDataView = MyDataView;
                DataGrid_Browse.BrowseGrid.DataSource = DataGrid_Browse.MyDataView;
                DataGrid_Browse.Set_Columns();

                DataGrid_Browse.BrowseGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DataGrid_Browse.BrowseGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DataGrid_Browse.BrowseGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataGrid_Browse.IsSelected = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsSelect = false;
            Close();
        }

        private void Browse_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void DataGrid_Browse_Enter(object sender, EventArgs e)
        {
            DataGrid_Browse.IsSelected = false;                 // User enter for select
        }

        private void DataGrid_Browse_Leave(object sender, EventArgs e)
        {
            IsSelect = DataGrid_Browse.IsSelected;              // Is Selected the row by user by DataGrid enter Button.
        }
    }           // Main
}               // NameSpace
