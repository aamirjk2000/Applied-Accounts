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
        public int MyID { get; set; }

        ////private DataRow Enter_DataRow;
        public Browse()
        {
            InitializeComponent();
        }

        public Browse(DataView _DataView)
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
                DataGrid_Browse._DataGrid.DataSource = DataGrid_Browse.MyDataView;
                DataGrid_Browse.Set_Columns();

                DataGrid_Browse._DataGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DataGrid_Browse._DataGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DataGrid_Browse._DataGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            IsSelect = true;
            if(MyDataView.Count==0)
            {
                MyDataRow = MyDataView.Table.NewRow();
                MyID = -1;
            }
            else
            {
                Select_Row();
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsSelect = false;
            MyID = 0;
            Close();
        }

        private void Select_Row()
        {
            MyDataRow = DataGrid_Browse.MyDataRow;
            MyID =  Conversion.ToInteger(MyDataRow["ID"].ToString());
        }
    }           // Main
}               // NameSpace
