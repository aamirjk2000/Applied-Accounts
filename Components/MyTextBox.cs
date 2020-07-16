using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Applied_Accounts
{
    public partial class MyTextBox : TextBox
    {
        public DataRow MyRow { get; set; }                  // Text Box value is Part of this Row.
        public DataView MyDataView { get; set; }            // Teax Box value seach in DataView
        public string MyMessage { get; set; }               // Message of the Text box 
        public int MaxDigit { get; set; }                   // Fixed Digit Length of the Text Box Value
        public Color thisColor { get; set; }
        public string Allowed_Chars { get; set; }
        public bool Allowe_Duplicate { get; set; }
        public string PrimaryKey { get; set; }
        public string ColumnName { get; set; }


        string Message_Required = "Code is required.";
        string Message_Length = "Code must be 6 Digits. (Like 101001)";
        string Message_Charts = "Only digits are allowed. [0 ~ 9]";
        string Message_Validated = "Code value has been validated.";

        public event EventHandler Get_Row;

        public MyTextBox()
        {
            InitializeComponent();
            thisColor = ThisBox.ForeColor;                      // Get Colot Text Box as default color
            Allowed_Chars = "0123456789-";                      // Default value of Allowed Chars.
            PrimaryKey = "ID";                                  // Table's Primary Key
            ColumnName = "Code";
        }

        private void Validation(object sender, CancelEventArgs e)
        //private bool DoValidation(object sender, CancelEventArgs e)
        {
            TextBox thisbox = (TextBox)sender;
            bool IsCancel = false;

            if (string.IsNullOrEmpty(thisbox.Text.Trim()))                          // Text Box value is null or empty
            {
                thisbox.Text = MyRow[ColumnName].ToString();
                thisbox.ForeColor = System.Drawing.Color.PaleVioletRed;
                IsCancel = true;
                MyMessage = Message_Required;
            }
            else if (thisbox.Text.Length != MaxDigit)                               // Text box Length is fixed for 6 Digit
            {
                thisbox.Text = MyRow[ColumnName].ToString();                            
                thisbox.ForeColor = Color.MediumVioletRed;
                IsCancel = true;
                MyMessage = Message_Length;
            }
            else if (IsChars(thisbox.Text))                                         // If any Charactors Found.
            {
                thisbox.Text = MyRow[ColumnName].ToString();
                thisbox.ForeColor = Color.Blue;
                IsCancel = true;
                MyMessage = Message_Charts;
            }
            else if(Seek(thisbox.Text))
            {
                    thisbox.Text = MyRow[ColumnName].ToString();
                    thisbox.ForeColor = Color.Green;
                    IsCancel = true;
                    MyMessage = Message_Charts;
            }

            else                                                                    // Valation is true 
            {
                thisbox.ForeColor = thisColor;
                MyMessage = Message_Validated;
                IsCancel = false;
            }


            e.Cancel = IsCancel;
        }

        public void GetRow(object sender, System.EventArgs e)
        {
            this.Get_Row(sender, e);
        }

        private bool IsChars(string _Text)
        {
            bool _Result = false;
            //string Allowed_Char = "01234567890-";
            char[] _Chars = _Text.ToCharArray();

            foreach (char _Char in _Text)
            {
                if(!Allowed_Chars.Contains(_Char.ToString()))
                {
                    _Result = true;
                }
            }
            return _Result;
        }

        private bool Seek(string _Code)
        {
            bool _Result = false;

            MyDataView.RowFilter = string.Concat(ColumnName,"='", _Code.Trim(), "'");       // Table View filter
            if (MyDataView.Count != 0)
            {
                long _ViewID = (long)(MyDataView[0].Row[PrimaryKey]);
                long _RowID = (long)MyRow[PrimaryKey];
                _Result = true;                                             // Code foud in Table view

                if(_ViewID==_RowID)
                {
                    _Result = false;                                        // Code found in same row.
                }
            }   
            else
            {
                _Result = false;                                            // Code not found in table view
            }
            return _Result;                                                 // return result.
        }

    }               // Main 
}                   // Namespace
