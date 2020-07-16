using System;
using System.Data;
using System.Windows.Forms;

namespace Applied_Accounts.Classes
{
    public class Validation
    {


        public DataRow MyDataRow { get; set; }
        public string TextValue { get; set; }
        public string TextTitle { get; set; }
        public string ColumnID_Name { get; set; }
        public string ColumnCode_Name { get; set; }
        public string ColumnTitle_Name { get; set; }
        public string Message { get; set; }
        public int TextLength { get; set; }
        public string Charactors { get; set; }
        
        
        private DataTable MyDataTable;
        private DataView MyDataView;
        private TextBox MyTextBox;

        string Message_Length = "Length of Value is not valid.";
        string Message_Validated = "Value validated.";
        string Message_NotValidated = "Value NOT validated.";


        public Validation(TextBox _TextBox,int _TableID)
        {

            ColumnID_Name = "ID";
            ColumnCode_Name = "Code";
            ColumnTitle_Name = "Title";
            Message = "Valildation Class for TextBox";
            TextLength = -1;                                    // Length of Text Value
            Charactors = "0123456789-";                         // Charactors allowed to enter;

            MyTextBox = _TextBox;
            MyDataTable = AppliedTable.GetDataTable(_TableID);
            MyDataView = new DataView(MyDataTable);
            
            MyDataRow = GetDataRow(MyTextBox.Text);

            TextValue = _TextBox.Text.Trim();
            TextTitle = MyDataRow[ColumnTitle_Name].ToString();
            Browseing();
        }

        public void Browseing()
        {
            if (TextValue=="0")
            {
                Browse BrowseWin = new Browse(MyDataView);
                BrowseWin.ShowDialog();
                MyDataRow = BrowseWin.MyDataRow;
                MyTextBox.Text = MyDataRow[ColumnCode_Name].ToString();
                TextValue = MyTextBox.Text;
                TextTitle = MyDataRow[ColumnTitle_Name].ToString();
            }
        }

        public bool TextValidation()
        {
            bool _Result = false;                                            // Boolean value to return
            if (MyDataRow[ColumnCode_Name].ToString().Trim()!=TextValue) { _Result = true; }
            if (ChkLength(TextValue)) { _Result = true; }                   // check Length of Text
            if (IsChars(TextValue)) { _Result = true; }                     // Chars are present in
            if (_Result) { Message = Message_NotValidated; } else { Message = Message_Validated; }
            return _Result;                           // Return value for Text box Validation.
        }

        // Get a DAta Row from table filtered by TextBox's Value.
        public DataRow GetDataRow(string _TextValue)
        {
            DataRow _DataRow;

            MyDataView.RowFilter = string.Concat(ColumnCode_Name, "='", _TextValue.Trim(), "'");
            if(MyDataView.Count==1)
            {
                _DataRow = MyDataView.ToTable().Rows[0];
            }    
            else
            {
                _DataRow = MyDataTable.NewRow();
            }

            return _DataRow;
        }
        private bool ChkLength(string _Text)                    // Check Length of Text box
        {
            if (TextLength == -1)
            {
                return false;
            }
            else if (TextLength == 0)
            {
                return false;
            }
            else if (TextLength > 0)
            {
                if (_Text.Length == TextLength)
                {
                    return false;
                }
                else
                {
                    Message = Message_Length;
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        private bool IsChars(string _Text)
        {
            bool _Result = false;
            foreach (char _Char in _Text)
            {
                if (!Charactors.Contains(_Char.ToString()))
                {
                    _Result = true;                             // Other than Allowed Charactor Found in Text
                }
            }
            return _Result;
        }                   // check the input box has charactors?

    }                   // Main
}                       // Namespace
