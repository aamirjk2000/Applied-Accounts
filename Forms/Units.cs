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
        private DataTable thisTable { get => MyNavigator.TableClass.MyDataTable; set => MyNavigator.TableClass.MyDataTable = value; }
        private DataRow thisRow { get => ((DataRowView)MyNavigator.TableBinding.Current).Row;}
        private DataView MyTableView { get => MyNavigator.MyDataView; }
        private DataTable MyDataTable { get => MyNavigator.MyDataTable; }
        private bool IsDataLoad = false;
        //private BindingManagerBase MyBinding;

        public frmUnits()
        {
            InitializeComponent();
        }

        public frmUnits(int _DataTableID)
        {
            InitializeComponent();
            Load_Data(_DataTableID);
        }

        private void Load_Data(int _TableID)
        {
            DataTable _DataTable = AppliedTable.GetDataTable(_TableID);
            MyDataGrid.MyDataView = new DataView(_DataTable);
            MyNavigator.InitializeClass(_DataTable);
            IsDataLoad = true;
        }


        private void MyNavigator_Load(object sender, EventArgs e)
        {
            if (!IsDataLoad) { Load_Data((int)Tables.Units); }  // Load Table if not loaded.

            txtID.DataBindings.Add(new Binding("Text", MyTableView, "ID", false, DataSourceUpdateMode.OnPropertyChanged));
            txtCode.DataBindings.Add(new Binding("Text", MyTableView, "Code", false, DataSourceUpdateMode.OnPropertyChanged));
            txtTag.DataBindings.Add(new Binding("Text", MyTableView, "SCode", false, DataSourceUpdateMode.OnPropertyChanged));
            txtTitle.DataBindings.Add(new Binding("Text", MyTableView, "Title", false, DataSourceUpdateMode.OnPropertyChanged));
            txtType.DataBindings.Add(new Binding("Text", MyTableView, "UType", false, DataSourceUpdateMode.OnPropertyChanged));
            txtLocation.DataBindings.Add(new Binding("Text", MyTableView, "ULocation", false, DataSourceUpdateMode.OnPropertyChanged));
            txtSize.DataBindings.Add(new Binding("Text", MyTableView, "USize", false, DataSourceUpdateMode.OnPropertyChanged));
            chkActive.DataBindings.Add(new Binding("Checked", MyTableView, "Active", false, DataSourceUpdateMode.OnValidation));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Navigation Codes

        private void MyNavigator_After_Delete(object sender, EventArgs e)
        {
        }

        private void MyNavigator_After_Save(object sender, EventArgs e)
        {
        }

        private void MyNavigator_New_Record(object sender, EventArgs e)
        {
            txtCode.Focus();
        }

        #region Get and Set Values

        private void MyNavigator_Set_Values(object sender, EventArgs e)
        {
        }

        private void MyNavigator_Get_Values(object sender, EventArgs e)
        {
        }
        #endregion

        #endregion

    }
}
