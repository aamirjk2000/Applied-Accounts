using System;
using System.Data;
using System.Windows.Forms;
using Applied_Accounts.Classes;

namespace Applied_Accounts
{
    public partial class Browse : Form
    {

        public DataView MyDataView { get; set; }
        public DataRow MyDataRow { get; set; }
        public string MyTitle { get; set; } 
        public bool IsSelect { get; set; }
        public long MyID { get; set; }

        public Browse(DataView _DataView)
        {
            InitializeComponent();
            MyDataView = _DataView;
            MyDataView.RowFilter = "";
            MyRefresh();
        }

        public Browse(DataView _DataView, string _CurrentValue)
        {
            InitializeComponent();
            MyDataView = _DataView;
            MyDataView.RowFilter = "";
            MyRefresh();
        }

        public void MyRefresh()
        {
            if(MyTitle==null)
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
            IsSelect = true;
            if (MyDataView.Count == 0)
            {
                MyDataRow = MyDataView.Table.NewRow();                                              // Select a row from browse grid record.
                MyID = -1;
            }
            else
            {
                MyDataRow = DataGrid_Browse.MyDataRow;                                              // Select a row from browse grid record.
                string _Value = DataGrid_Browse.BrowseGrid.CurrentRow.Cells[0].Value.ToString();
                //   Conversion.ToLong(MyDataRow["ID"]
                MyID =  Applied.Code2ID(_Value, MyDataView);
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsSelect = false;
            MyID = 0;
            Close();
        }

        
    }           // Main
}               // NameSpace
