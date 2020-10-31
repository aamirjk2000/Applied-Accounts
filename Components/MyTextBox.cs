using Applied_Accounts.Classes;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Applied_Accounts
{
    public partial class MyTextBox : System.Windows.Forms.TextBox
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
        public bool Mode_Edit { get; set; }
        public bool Mode_Add { get; set; }
        public bool Mode_Delete { get; set; }
        public int Text_Mode { get; set; }

        string Message_Required = "Code is required.";
        string Message_Length = "Code must be 6 Digits. (Like 101001)";
        string Message_Charts = "Only digits are allowed. [0 ~ 9]";
        string Message_Validated = "Code value has been validated.";

        public event EventHandler Get_Row;
        //public event EventHandler Text_Validated;

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
            if (Mode_Edit) { e.Cancel = Mode_Edit_Event(sender); return; }
            if (Mode_Add) { e.Cancel = Mode_Add_Event(sender); return; }
            if (Mode_Delete) { e.Cancel = Mode_Delete_Event(sender); return; }
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
                if (!Allowed_Chars.Contains(_Char.ToString()))
                {
                    _Result = true;
                }
            }
            return _Result;
        }


        #region Validation Edit Add Delete

        private bool Mode_Edit_Event(object sender)
        {
            TextBox thisbox = ((MyTextBox)sender).ThisBox;
            bool IsCancel = false;

            if (string.IsNullOrEmpty(thisbox.Text.Trim()))                          // Text Box value is null or empty
            {
                thisbox.Text = MyRow[ColumnName].ToString();
                thisbox.ForeColor = Color.PaleVioletRed;
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
            else if (string.Equals(Applied.Code(thisbox.Text.Trim(), MyDataView).Trim(), thisbox.Text.Trim()))                                             // code Seek in the Data table.
            {
                thisbox.Text = MyRow[ColumnName].ToString();
                thisbox.ForeColor = Color.Green;
                IsCancel = false;
                MyMessage = Message_Charts;
            }

            //else                                                                    // Valation is true 
            //{
            //    thisbox.ForeColor = thisColor;
            //    MyMessage = Message_Validated;
            //    IsCancel = false;
            //}
            return IsCancel;
        }

        private bool Mode_Add_Event(object sender)
        {
            TextBox thisbox = ((MyTextBox)sender).ThisBox;
            bool IsCancel = false;

            if (string.IsNullOrEmpty(thisbox.Text.Trim()))                          // Text Box value is null or empty
            {
                thisbox.Text = MyRow[ColumnName].ToString();
                thisbox.ForeColor = Color.PaleVioletRed;
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
            else if (string.Equals(Applied.Code(thisbox.Text.Trim(), MyDataView).Trim(), thisbox.Text.Trim()))                                             // code Seek in the Data table.
            {
                thisbox.Text = MyRow[ColumnName].ToString();
                thisbox.ForeColor = Color.Purple;
                IsCancel = true;
                MyMessage = Message_Charts;
            }

            else                                                                    // Valation is true 
            {
                thisbox.ForeColor = Color.Green;
                MyMessage = Message_Validated;
                IsCancel = false;
            }
            return IsCancel;
        }

        private bool Mode_Delete_Event(object sender)
        {
            return Mode_Edit_Event(sender);
        }

        public void Set_Modes(object _Modes)
        {
            switch (_Modes)
            {
                case 1:
                    Mode_Add = false;
                    Mode_Edit = true;
                    Mode_Delete = false;
                    break;

                case 2:
                    Mode_Add = true;
                    Mode_Edit = false;
                    Mode_Delete = false;
                    break;

                case 3:
                    Mode_Add = false;
                    Mode_Edit = false;
                    Mode_Delete = true;
                    break;

                default:
                    break;
            }
        }

      

        #endregion

        private void MyTextBox_Validated(object sender, EventArgs e)
        {
            //this.Text_Validated(sender,e);
        }
    }               // Main 
}                   // Namespace
