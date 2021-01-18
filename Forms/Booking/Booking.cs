using Applied_Accounts.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace Applied_Accounts.Forms.Booking
{
    public partial class frmBooking : Form
    {
        private DataTable tb_Booking;
        private DataTable tb_Suppliers;
        private DataTable tb_Units;
        private DataTable tb_Projects;
        private DataTable tb_ScheduleTitle;
        private DataTable tb_bookingTitle;
        private DataTable tb_GridBooking;

        private bool InitializingNow = true;

        #region Intitialize

        public frmBooking()
        {
            Load_Tables();                                  // Load Data Tables into Form
            InitializeComponent();                          // Setup of form Objects
            MyNavigator.InitializeClass(tb_Booking);        // Setup of Navigation Buttons
            DataBinding();                                  // Setup of Data Binding with Objects
            Load_Grid();                                    // Setup of Data Grid in the form P2.

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
            cBoxSchedule.ValueMember = "Code";
            cBoxBooking.ValueMember = "ID";

            InitializingNow = false;                        // Form Objects initialization END

        }

        private void DataBinding()
        {
            txtID.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "ID", true, DataSourceUpdateMode.OnPropertyChanged));
            txtCode.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Code", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTag.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "SCode", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTitle.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Title", true, DataSourceUpdateMode.OnPropertyChanged));
            txtUnit.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Unit", true, DataSourceUpdateMode.OnPropertyChanged));

            txtProject.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Project", true, DataSourceUpdateMode.OnPropertyChanged));
            dtBooking.DataBindings.Add(new Binding("Value", MyNavigator.MyBindingSource, "Book_Date", true, DataSourceUpdateMode.OnPropertyChanged));
            txtSale.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Sale_Price", true, DataSourceUpdateMode.OnPropertyChanged));
            txtDiscount.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Discount", true, DataSourceUpdateMode.OnPropertyChanged));
            txtRemarks.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Remarks", true, DataSourceUpdateMode.OnPropertyChanged));
            chkActive.DataBindings.Add(new Binding("Checked", MyNavigator.MyBindingSource, "Active", true, DataSourceUpdateMode.OnValidation));

            //txtClient.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Client", true, DataSourceUpdateMode.OnPropertyChanged));
            ID_Client.DataBindings.Add(new Binding("Text", MyNavigator.MyBindingSource, "Client", true, DataSourceUpdateMode.OnPropertyChanged));

        }

        private void Load_Grid()
        {
            string[] ColumnsVisiable = { "Code", "Supplier", "Project", "Unit", "Book_Date", "Active" };
            string[] ColumnsName = { "Code", "Client", "Project", "Unit", "Booking On", "Active" };
            int[] ColumnsFormat = { (int)TextFormat.Codes, 0, 0,0, (int)TextFormat.Date, 0 };

            int[] ColumnWidth = { 50, 160, 160, 160, 80, 40 };

            MyDataGrid.ColumnsName = ColumnsName;
            MyDataGrid.ColumnsWidth = ColumnWidth;
            MyDataGrid.ColumnsVisiable = ColumnsVisiable;
            MyDataGrid.ColumnsFormat = ColumnsFormat;
            MyDataGrid.Load_Data(tb_GridBooking);
            MyDataGrid.Set_Columns();

            MyDataGrid.BrowseGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MyDataGrid.BrowseGrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MyDataGrid.BrowseGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //MyDataGrid.BrowseGrid.Columns[4].DefaultCellStyle.Format = null;

        }


        private void Load_Tables()
        {
            tb_Booking = AppliedTable.GetDataTable(Tables.Booking);
            tb_GridBooking = AppliedTable.GetDataTable(Tables.Grid_Booking);
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
            tb_Booking = AppliedTable.GetDataTable(Tables.Booking);
            tb_GridBooking = AppliedTable.GetDataTable(Tables.Grid_Booking);
            Refresh();
        }

        private void MyNavigator_After_Save(object sender, EventArgs e)
        {
            tb_Booking = AppliedTable.GetDataTable(Tables.Booking);
            tb_GridBooking = AppliedTable.GetDataTable(Tables.Grid_Booking);
            Refresh();
        }

        private void MyNavigator_Before_Save(object sender, EventArgs e)
        {
            DataRow _Row = MyNavigator.MyDataRow;

            if (dtBooking.Value == null)
            {
                MessageBox.Show("Booking Date is not mentioned.");
                dtBooking.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(_Row["Client"].ToString()))
            {
                MyNavigator.NewRow_Valid = false;
                MyNavigator.MyMessage = "Client is not assigned.";
                txtClient.Text = "";
                txtClient.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(_Row["Project"].ToString()))
            {
                MyNavigator.NewRow_Valid = false;
                MyNavigator.MyMessage = "Supplier is not assigned.";
                txtProject.Text = "";
                txtProject.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(_Row["Unit"].ToString()))
            {
                MyNavigator.NewRow_Valid = false;
                MyNavigator.MyMessage = "Unit is not assigned.";
                txtUnit.Text = "";
                txtUnit.Focus();
                return;
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

        #region Codes

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void P3_Enter(object sender, EventArgs e)
        {
            cBoxBooking.SelectedValue = Conversion.ToLong(txtID.Text);
        }

        #endregion

        #region Browse Windows

        private void btnUnit_Click(object sender, EventArgs e)
        {
            cBoxUnit.SelectedValue = Applied.ShowBrowseWin(tb_Units, cBoxUnit.SelectedValue);
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            cBoxClient.SelectedValue = Applied.ShowBrowseWin(tb_Suppliers, cBoxClient.SelectedValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cBoxProject.SelectedValue = Applied.ShowBrowseWin(tb_Projects, cBoxProject.SelectedValue);
        }

        #endregion

        #region Schedule Add 

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string _Code = cBoxSchedule.SelectedValue.ToString();
            int _Booking = 0;
            int _Schedule = 0;

            DataTable tb_Schedule = AppliedTable.GetDataTable(Tables.Schedule, "Code='" + _Code + "'");
            MessageBox.Show(tb_Schedule.Rows.Count.ToString());
            DataView _Dataview = tb_Booking.AsDataView();
            DataRow _DataRow = tb_Booking.NewRow();

            if (tb_Schedule.Rows.Count > 0)
            {
                foreach (var _Row in tb_Schedule.Rows)
                {
                    // filter booking ID and Schedule ID
                    _Dataview.RowFilter = "Booking=" + _Booking.ToString() + " AND Schedule=" + _Schedule.ToString();


                    if (_Dataview.Count > 0)
                    {



                    }

                    else
                    {

                    }



                }
            }
        }


        #endregion

        #region Text buttons Codes

        private void cBoxClient_TextChanged(object sender, EventArgs e)
        {
            if (InitializingNow) { return; }
            if (cBoxClient.Text.Length == 0) { return; }
            if (cBoxClient.SelectedValue == null) { return; }
            txtClient.Text = Applied.Code((long)cBoxClient.SelectedValue, tb_Suppliers.AsDataView());
            ID_Client.Text = cBoxClient.SelectedValue.ToString();
        }





        private void cBoxProject_TextChanged(object sender, EventArgs e)
        {

            if (InitializingNow) { return; }
            if (cBoxProject.Text.Length == 0) { return; }
            if (cBoxProject.SelectedValue == null) { return; }
            txtProject.Text = Applied.Code((long)cBoxProject.SelectedValue, tb_Projects.AsDataView());
            ID_Project.Text = cBoxProject.SelectedValue.ToString();

        }


        private void cBoxUnit_TextChanged(object sender, EventArgs e)
        {
            if (InitializingNow) { return; }
            if (cBoxUnit.Text.Length == 0) { return; }
            if (cBoxUnit.SelectedValue == null) { return; }
            txtUnit.Text = Applied.Code((long)cBoxUnit.SelectedValue, tb_Units.AsDataView());
            ID_Unit.Text = cBoxUnit.SelectedValue.ToString();

        }

        // ID Text Button Codes


        private void ID_Client_TextChanged(object sender, EventArgs e)
        {
            txtClient.Text = Applied.Code(Conversion.ToLong(ID_Client.Text.ToString()), tb_Suppliers.AsDataView());
            cBoxClient.SelectedValue = Conversion.ToLong(ID_Client.Text);
        }
        private void ID_Project_TextChanged(object sender, EventArgs e)
        {
            txtProject.Text = Applied.Code(Conversion.ToLong(ID_Project.Text.ToString()), tb_Projects.AsDataView());
            cBoxProject.SelectedValue = Conversion.ToLong(ID_Project.Text);
        }
        private void ID_Unit_TextChanged(object sender, EventArgs e)
        {
            txtUnit.Text = Applied.Code(Conversion.ToLong(ID_Unit.Text.ToString()), tb_Units.AsDataView());
            cBoxUnit.SelectedValue = Conversion.ToLong(ID_Unit.Text);

        }


        #endregion

        private void MyDataGrid_Enter(object sender, EventArgs e)
        {
            Load_Tables();
        }
    }           // End Class
}               // END 
