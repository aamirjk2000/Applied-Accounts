using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;

namespace Applied_Accounts.Classes
{

    interface ICode_Validation
    {
        bool Validating();
        bool Validated();
        string GetText();
    }

    class Code_Validation : ICode_Validation
    {
        private TextBox MyTextBox;
        private DataTable MyDataTable;

        public int Current_Mode { get; set; }
        public string Input_char { get; set; }
        public int Length { get; set; }
        public bool NillAllow { get; set; }
        public bool chkLength { get; set; }
        public int Position { get; set; }
        public string Message { get; set; }

        #region Initialzation

        public Code_Validation()
        { }

        public Code_Validation(TextBox _TextBox, DataTable _DataTable)
        {
            MyTextBox = _TextBox;
            MyDataTable = _DataTable;
            Current_Mode = 0;
            NillAllow = false;
            chkLength = false;
        }

        #endregion

        public bool Validating()
        {
            bool _Result = false;

            if (MyTextBox == null)
            {
                Message = "Messagebox do not defined.";
                MessageBox.Show(Message);
                return true;
            }

            if (NillAllow) { return true; }
            if (IsChars(MyTextBox.Text)) { Message = "a Char is not valid"; return false; }

            #region Length
            if (chkLength)
            {
                if (MyTextBox.Text.Length != Length) { Message = "Text Lenght is not valid"; return false; }
            }
            #endregion

            #region Text Exist

            if (Current_Mode == (int)Applied.Modes.Edit)
            {

                _Result = string.Equals(Applied.Code(MyTextBox.Text, MyDataTable.AsDataView()).Trim(), MyTextBox.Text.Trim());
                if (_Result) { Message = "Text found in list"; }
                else
                {
                    Message = "Text NOT found in list";
                }

            }

            if (Current_Mode == (int)Applied.Modes.New)
            {
                _Result = !string.Equals(Applied.Code(MyTextBox.Text, MyDataTable.AsDataView()).Trim(), MyTextBox.Text.Trim());
                if (_Result) { Message = "Text found in list"; } else { Message = "Text NOT found in list"; }
            }

            #endregion

            if (_Result)
            { Validated(); }



            return _Result;
        }

        public bool Validated()
        {
            return true;
        }

        public bool IsChars(string _Text)
        {
            bool _Result = false;
            //string Allowed_Char = "01234567890-";
            char[] _Chars = _Text.ToCharArray();

            foreach (char _Char in _Text)
            {
                if (!Input_char.Contains(_Char.ToString()))
                {
                    _Result = true;
                }
            }
            return _Result;
        }

        public string GetText()
        {
            if (MyTextBox != null)
            {
                return MyTextBox.Text.Trim();
            }
            return "";
        }

    }               // END Main Class
}                   // End Namespace
