using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;



namespace Applied_Accounts
{
    public partial class SearchID : TextBox
    {
        public int TargetTableID { get; set; }          // ID of Target Table. See Tables. See AppliedTables Table Enum
        public DataTable MyDataTable { get; set; }
        public DataView MyDataView { get; set; }
        public DataRow MyDataRow { get; set; }
        public string Allowed_Chars { get; set; }
        public string MyMessage { get; set; }
        public int Length { get; set; }                 // Length of the value matched.
        public string ColumnID { get; set; }            // Column Name in DataTable of ID
        public string ColumnCode { get; set; }          // Column Name in DataTable of Code
        public string ColumnTitle { get; set; }         // Column Name in DataTable of Title
        public int ColumnID_Value { get; set; }         // 
        public string ColumnCode_Value { get; set; }
        public string ColumnTitle_Value { get; set; }

        string Message_NotinList = "Code is not listed.";
        string Message_Length = "Code length is not matched.";

        public event EventHandler ShowMessage;

        public SearchID()
        {

            InitializeComponent();

            // Defaul value of this object

            MyMessage = "Search Text Box";                      // Messahes of this object.
            Allowed_Chars = "0123456789-";                      // Default value of Allowed Chars.
            ColumnID = "ID";                                    // Set Name of Table Column of Promary Key ID
            ColumnCode = "Code";                                // Set name of Table Column for Code
            ColumnTitle = "Title";                              // Set Name of table Column for Title of code

            ColumnID_Value = 0;
            ColumnCode_Value = "";
            ColumnTitle_Value = "";

            TargetTableID = 0;
            MyDataTable = new DataTable();
            MyDataView = new DataView();
            MyDataRow = MyDataTable.NewRow();
            Length = 0;


        }



        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    base.OnPaint(pe);
        //}

        private void SearchBox_Enter(object sender, EventArgs e)
        {
            if (MyDataTable == null)                      // Load a Datatable for validation
            {
                if (TargetTableID != 0)
                {
                    MyDataTable = AppliedTable.GetDataTable(TargetTableID);
                    MyDataView = new DataView(MyDataTable);
                }
                else
                {
                    MyDataTable = new DataTable();
                    MyDataView = new DataView();
                }
            }

        }       // Load Target Table 


        private void SearchBox_Validation(object sender, CancelEventArgs e)
        {
            TextBox thisbox = (TextBox)sender;
            e.Cancel = false;
            long _Value = Convert.ToInt64(thisbox.Text);

            if (ChkLength(thisbox.Text)) { e.Cancel = true; }            // check Length of Text
            if (NotExist(thisbox.Text)) { e.Cancel = true; }             // Value is exist in Table (Seek)
            if (IsChars(thisbox.Text)) { e.Cancel = true; }              // Chars are present in Text value.

            if (!e.Cancel)
            {
                MyDataView.RowFilter = string.Concat(ColumnCode, "='", thisbox.Text.ToString(), "'");
                MyDataRow = MyDataView[0].Row;
            }
            else
            {
                MyDataRow = MyDataTable.NewRow();
                ColumnTitle_Value = "";
                ShowMessage(sender, e);
            }
        }

        private void SearchBox_Validated(object sender, EventArgs e)
        {
            ColumnTitle_Value = MyDataRow[ColumnTitle].ToString();
            ShowMessage(sender, e);

        }
        private bool ChkLength(string _Text)                    // Check Length of Text box
        {
            if (Length == 0)
            {
                return false;
            }
            else if (Length > 0)
            {
                if (_Text.Length == Length)
                {
                    return false;
                }
                else
                {
                    MyMessage = Message_Length;
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private bool NotExist(string _Text)
        {
            MyDataView.RowFilter = string.Concat(ColumnCode, "='", _Text.ToString(), "'");
            if (MyDataView.Count == 0)
            {
                MyMessage = Message_NotinList;
                return true;
            }
            else
            {
                return false;
            }
        }                   // Check Id is exist in the Table?

        private bool IsChars(string _Text)
        {
            bool _Result = false;
            foreach (char _Char in _Text)
            {
                if (!Allowed_Chars.Contains(_Char.ToString()))
                {
                    _Result = true;                             // Other than Allowed Charactor Found in Text
                }
            }
            return _Result;
        }                   // check the input box has charactors?

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            TextBox thisbox = (TextBox)sender;

            if (thisbox != null)
            {

                DataView thisView = new DataView(MyDataTable);

                // show Browse Window if lenght is zero.
                if (thisbox.Text.Length == 0)
                {
                    DataRow thisRow = MyDataRow;
                    Browse WinBrowse = new Browse(MyDataTable.AsDataView());
                    MyDataView.RowFilter = "";
                    WinBrowse.DataGrid_Browse.IsBrowseWin = true;
                    WinBrowse.MyDataRow = MyDataRow;
                    WinBrowse.MyDataView = MyDataView;
                    WinBrowse.MyRefresh();
                    WinBrowse.ShowDialog();
                    if (WinBrowse.IsSelect) { MyDataRow = WinBrowse.MyDataRow; } else { MyDataRow = thisRow; }
                    thisbox.Text = MyDataRow["Code"].ToString();

                }          // Assign Zero if text box is null.


                // Search ID in Data Table.
                if (thisbox.Text.Length == 0) { thisbox.Text = "0"; }
                if (ColumnCode == null) { ColumnCode = "Code"; }
                if (ColumnTitle == null) { ColumnTitle = "Title"; }

                thisView.RowFilter = string.Concat(ColumnCode, "=", thisbox.Text.Trim());
                if (thisView.Count == 1)
                {
                    MyDataRow = thisView[0].Row;
                    MyMessage = "";
                    ColumnTitle_Value = MyDataRow[ColumnTitle].ToString();
                }

                else
                {
                    MyDataRow = MyDataTable.NewRow();
                    MyMessage = "";
                    ColumnTitle_Value = "ERROR: ID is not listed in Table.";
                }

                thisbox = null;
                thisView = null;

            }

        }

    }                   // Main
}                       // Namespace
