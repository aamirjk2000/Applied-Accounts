using Applied_Accounts.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applied_Accounts.Forms
{
    public partial class frmUnits : Form
    {

        private int[] MyTablesID = { (int)Tables.Units, (int)Tables.Projects };
        private DataTable tb_Units;
        private DataTable tb_Projects; 
        private DataSet MyDataSet = new DataSet();

        DataColumn Col_Child;
        DataColumn Col_Parent; 



        #region Initialize

        public frmUnits()
        {
            InitializeComponent();

            MyDataSet = AppliedTable.GetDataSet("MyDataSet", MyTablesID);

            tb_Units = MyDataSet.Tables["Units"];
            tb_Projects = MyDataSet.Tables["Projects"];

            Col_Parent = MyDataSet.Tables["Projects"].Columns["ID"];
            Col_Child = MyDataSet.Tables["Units"].Columns["Project"];
            MyDataSet.Relations.Add("Relation_Project", Col_Parent , Col_Child, true);
            MyDataSet.AcceptChanges();

            MyNavigator.InitializeClass(MyDataSet);
            DataBinding();                      // Data Binding with form objects
            Load_Grid();                        // Load Data in Data Grid.

        }


        private void DataBinding()
        {
            txtID.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "ID", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCode.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Code", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTag.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "SCode", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTitle.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Title", true, DataSourceUpdateMode.OnPropertyChanged));
            txtBlock.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Block", true, DataSourceUpdateMode.OnPropertyChanged));
            txtFloor.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Floor", true, DataSourceUpdateMode.OnPropertyChanged));
            txtType.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Utype", true, DataSourceUpdateMode.OnPropertyChanged));
            txtLocation.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "ULocation", true, DataSourceUpdateMode.OnPropertyChanged));
            txtSize.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "USize", true, DataSourceUpdateMode.OnPropertyChanged));
            txtRemarks.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Remarks", true, DataSourceUpdateMode.OnPropertyChanged));
            cBoxProject.DataBindings.Add(new Binding("ValueMember", MyNavigator.MyBindingSource, "Project", true, DataSourceUpdateMode.OnPropertyChanged,"Select..."));
            chkActive.DataBindings.Add(new Binding("Checked", MyNavigator.MyBindingSource, "Active", true, DataSourceUpdateMode.OnValidation));

            cBoxProject.DataSource = MyDataSet;
            //cBoxProject.DisplayMember = "[Projects].[Title]";
            //cBoxProject.ValueMember = "[Projects].[ID]";

        }

        private void Load_Grid()
        {
            string[] ColumnsVisiable = { "[Units].[Code]", "[Units].[SCode]", "[Units].[Title]", "[Units].[UType]", "[Units].[Active]", "[Projects].[Title]" };
            string[] ColumnsName = { "Code", "Tag", "Title", "Type", "Active", "Project" };
            int[] ColumnsFormat = { (int)TextFormat.Codes, 0, 0, 0, 0,0 };

            int[] ColumnWidth = { 60, 60, 260, 75, 40, 60 };

            MyDataGrid.ColumnsName = ColumnsName;
            MyDataGrid.ColumnsWidth = ColumnWidth;
            MyDataGrid.ColumnsVisiable = ColumnsVisiable;
            MyDataGrid.ColumnsFormat = ColumnsFormat;
            MyDataGrid.Load_Data(tb_Units);
            MyDataGrid.Set_Columns();

            MyDataGrid.BrowseGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Navigation Codes

        private void MyNavigator_After_Delete(object sender, EventArgs e)
        {
        }

        private void MyNavigator_Before_Save(object sender, EventArgs e)
        {
            DataRow _Row = ((DataRowView)MyNavigator.TableBinding.Current).Row;

            if (MyNavigator.Current_Mode == (int)Applied.Modes.New)
            {

                if (string.Equals(Applied.Code(txtCode.Text, tb_Units.AsDataView()).Trim(), txtCode.Text.Trim()))
                {
                    MyNavigator.NewRow_Valid = false;
                    MyNavigator.MyMessage = "Code is already exist.";
                    txtCode.Text = "";
                    txtCode.Focus();
                    return;
                }

            }

            if (txtTitle.Text.Length == 0)
            {
                MyNavigator.NewRow_Valid = false;
                MyNavigator.MyMessage = "Supplier Name must be enter.";
                txtTitle.Focus();
                return;
            }

            if (_Row["Active"] == DBNull.Value) { MyNavigator.MyDataView[MyNavigator.NewRecordPosition]["Active"] = true; }
            

        }

        private void MyNavigator_After_Save(object sender, EventArgs e)
        {



        }



        private void MyNavigator_New_Record(object sender, EventArgs e)
        {
            txtCode.Focus();
        }


        #endregion

        
        private void ShowData()
        {
            foreach (DataRow _Row in MyDataSet.Tables["Units"].Rows)
            {
                string _Message = _Row["Title"].ToString();
                MessageBox.Show(_Message);
            }


            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
