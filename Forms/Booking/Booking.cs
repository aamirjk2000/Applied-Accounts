using Applied_Accounts.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace Applied_Accounts.Forms.Booking
{
    public partial class frmBooking : Form
    {
        private DataTable tb_Booking = AppliedTable.GetDataTable(Tables.Booking);
        private DataTable tb_Suppliers = AppliedTable.GetDataTable(Tables.Suppliers);
        private DataTable tb_Units = AppliedTable.GetDataTable(Tables.Units);
        private DataTable tb_Projects = AppliedTable.GetDataTable(Tables.Projects);
        private DataTable tb_ScheduleTitle = AppliedTable.GetDataTable(Tables.View_Schedule_Title);
        private DataTable tb_bookingTitle = AppliedTable.GetDataTable(Tables.View_Booking_Title);

        #region Intitialize

        public frmBooking()
        {
            InitializeComponent();
            MyNavigator.InitializeClass(tb_Booking);
            DataBinding();
            Load_Grid();

            dtBooking.Value = DateTime.Now;
            dtBooking.Format = DateTimePickerFormat.Custom;
            dtBooking.CustomFormat = Applied.GetString("DateFormat");

            cBoxUnit.DataSource = tb_Units;
            cBoxClient.DataSource = tb_Suppliers;
            cBoxProject.DataSource = tb_Projects;
            cBoxSchedule.DataSource = tb_ScheduleTitle;
            cBoxBooking.DataSource = tb_bookingTitle;

            cBoxUnit.DisplayMember = "Title";
            cBoxClient.DisplayMember = "Title";
            cBoxProject.DisplayMember = "Title";
            cBoxSchedule.DisplayMember = "Title";
            cBoxBooking.DisplayMember = "Title";

            cBoxUnit.ValueMember = "ID";
            cBoxClient.ValueMember = "ID";
            cBoxProject.ValueMember = "ID";
            cBoxBooking.ValueMember = "ID";

        }

        private void DataBinding()
        {
            txtID.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "ID", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCode.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Code", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTag.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "SCode", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTitle.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Title", true, DataSourceUpdateMode.OnPropertyChanged));
            txtUnit.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Unit", true, DataSourceUpdateMode.OnPropertyChanged));
            txtClient.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Client", true, DataSourceUpdateMode.OnPropertyChanged));
            txtProject.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Project", true, DataSourceUpdateMode.OnPropertyChanged));
            dtBooking.DataBindings.Add(new Binding("Value", MyNavigator.MyBindingSource, "Book_Date", true, DataSourceUpdateMode.OnPropertyChanged));
            txtSale.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Sale_Price", true, DataSourceUpdateMode.OnPropertyChanged));
            txtDiscount.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Discount", true, DataSourceUpdateMode.OnPropertyChanged));
            txtRemarks.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Remarks", true, DataSourceUpdateMode.OnPropertyChanged));
            chkActive.DataBindings.Add(new Binding("Checked", MyNavigator.MyBindingSource, "Active", true, DataSourceUpdateMode.OnValidation));
        }

        private void Load_Grid()
        {
            string[] ColumnsVisiable = { "Code", "SCode", "Title", "Booking_Date", "Active" };
            string[] ColumnsName = { "Code", "Tag", "Title", "Booking On", "Active" };
            int[] ColumnsFormat = { (int)TextFormat.Codes, 0, 0, (int)TextFormat.Date, 0 };

            int[] ColumnWidth = { 60, 60, 260, 75, 40 };

            MyDataGrid.ColumnsName = ColumnsName;
            MyDataGrid.ColumnsWidth = ColumnWidth;
            MyDataGrid.ColumnsVisiable = ColumnsVisiable;
            MyDataGrid.ColumnsFormat = ColumnsFormat;
            MyDataGrid.Load_Data(tb_Booking);
            MyDataGrid.Set_Columns();

            MyDataGrid.BrowseGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private void Load_Tables()
        {
            tb_Booking = AppliedTable.GetDataTable(Tables.Booking);
            tb_Suppliers = AppliedTable.GetDataTable(Tables.Suppliers);
            tb_Units = AppliedTable.GetDataTable(Tables.Units);
            tb_Projects = AppliedTable.GetDataTable(Tables.Projects);
            tb_ScheduleTitle = AppliedTable.GetDataTable(Tables.View_Schedule_Title);
            tb_bookingTitle = AppliedTable.GetDataTable(Tables.View_Booking_Title);
        }


        #endregion

        #region Navigator Codes

        private void MyNavigator_After_Delete(object sender, EventArgs e)
        {

        }

        private void MyNavigator_After_Save(object sender, EventArgs e)
        {
            Load_Tables();
            Refresh();
        }

        private void MyNavigator_Before_Save(object sender, EventArgs e)
        {
            if (dtBooking.Value == null)
            {
                MessageBox.Show("Booking Date is not mentioned.");
                dtBooking.Focus();
            }
        }

        private void MyNavigator_New_Record(object sender, EventArgs e)
        {
            txtCode.Focus();
        }

        #endregion

        #region TextBox Text Changed

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {
            object[] _SearchValue = { (long)0, "", "", "", false };
            _SearchValue = AppliedTable.SearchText((TextBox)sender, tb_Units);

            long _ID = Conversion.ToLong(_SearchValue[0]);
            string _Code = _SearchValue[1].ToString();
            string _SCode = _SearchValue[2].ToString();
            string _Title = _SearchValue[3].ToString();
            bool _Istrue = (bool)_SearchValue[4];

            if (_Istrue)
            {
                cBoxUnit.Text = _Title;
                cBoxUnit.SelectedValue = _ID;
            }
        }

        private void txtClient_TextChanged(object sender, EventArgs e)
        {
            object[] _SearchValue = { (long)0, "", "", "", false };
            _SearchValue = AppliedTable.SearchText((TextBox)sender, tb_Units);

            long _ID = Conversion.ToLong(_SearchValue[0]);
            string _Code = _SearchValue[1].ToString();
            string _SCode = _SearchValue[2].ToString();
            string _Title = _SearchValue[3].ToString();
            bool _Istrue = (bool)_SearchValue[4];

            if (_Istrue)
            {
                cBoxClient.Text = _Title;
                cBoxClient.SelectedValue = _ID;
            }
        }

        private void txtProject_TextChanged(object sender, EventArgs e)
        {
            object[] _SearchValue = { (long)0, "", "", "", false };
            _SearchValue = AppliedTable.SearchText((TextBox)sender, tb_Units);

            long _ID = (long)_SearchValue[0];
            string _Code = _SearchValue[1].ToString();
            string _SCode = _SearchValue[2].ToString();
            string _Title = _SearchValue[3].ToString();
            bool _Istrue = (bool)_SearchValue[4];

            if (_Istrue)
            {
                cBoxProject.Text = _Title;
                cBoxProject.SelectedValue = _ID;
            }
        }

        #endregion

        #region Drop Down

        private void cBoxUnit_DropDownClosed(object sender, EventArgs e)
        {
            txtUnit.Text = cBoxUnit.SelectedValue.ToString();
        }

        private void cBoxClient_DropDownClosed(object sender, EventArgs e)
        {
            txtClient.Text = cBoxClient.SelectedValue.ToString();
        }

        private void cBoxProject_DropDownClosed(object sender, EventArgs e)
        {
            txtProject.Text = cBoxClient.SelectedValue.ToString();
        }

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void P3_Enter(object sender, EventArgs e)
        {
            cBoxBooking.SelectedValue = Conversion.ToLong(txtID.Text);
        }
    }           // End Class
}               // END 
