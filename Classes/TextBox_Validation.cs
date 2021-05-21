using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
using System.Windows.Forms;

namespace Applied_Accounts.Classes
{
    public interface ITextBox_Validation
    {
        bool Validating(object sender, DataTable _DataTable);
        string ObjectID(object sender, DataTable _DataTable);

    }

    public class TextBox_Validation : ITextBox_Validation
    {
        public TextBox_Validation()
        {
            Zero_Allowed = false;
            Validation_Allowed = false;
        }


        public int Search_ComboID { get; set; }
        public string Search_Title { get; set; }
        public string Search_Tag { get; set; }
        public string Search_Code { get; set; }
        public string Voucher_Type { get; set; }
        public bool Validation_Allowed { get; set; }
        public bool Zero_Allowed { get; set; }

        public bool Validating(object sender, DataTable _DataTable)
        {
            Search_ComboID = Conversion.ToInteger(((TextBox)sender).Text.Trim());
            bool IsSearch1 = SearchID(((TextBox)sender).Text, _DataTable);              // Seek Id in Table
            bool IsSearch2 = SearchCode(((TextBox)sender).Text, _DataTable);            // Seek Code in Table
            bool IsSearch3 = SearchTag(((TextBox)sender).Text, _DataTable);             // Seek SCode in table
            if (IsSearch1 || IsSearch2 || IsSearch3) { return false; } else { return true; }
        }


        public string ObjectID(object sender, DataTable _DataTable)
        {
            TextBox _TextBox = (TextBox)sender;
            DataView _DataView = _DataTable.AsDataView();
            long _Value = Conversion.ToLong(_TextBox.Text.Trim());

            _DataView.RowFilter = "ID=" + _Value;
            if (_DataView.Count == 1) { return _DataView[0]["ID"].ToString(); }

            _DataView.RowFilter = "Code='" + _Value.ToString() + "'";
            if (_DataView.Count == 1) { return _DataView[0]["ID"].ToString(); }

            _DataView.RowFilter = "SCode='" + _Value.ToString() + "'";
            if (_DataView.Count == 1) { return _DataView[0]["ID"].ToString(); }

            return "";
        }

        //=================================== END VALIDATING


        private bool SearchID(string _Value, DataTable _DataTable)
        {
            // Return value for e.Cancel of Text Boox Validating

            bool _Result = false;
            long _nValue = 0;

            DataView _DataView = _DataTable.AsDataView();

            if (_Value == null || _Value.Trim() == string.Empty)
            {
                _nValue = 0;
            }
            else
            {
                try
                {
                    _nValue = long.Parse(_Value);
                }
                catch
                {
                    _nValue = 0;
                }
            }
            _DataView.RowFilter = "ID=" + _nValue.ToString().Trim();
            if (_DataView.Count == 1)
            {
                Search_ComboID = Conversion.ToInteger(_DataView[0]["ID"]);
                Search_Code = _DataView[0]["Code"].ToString();
                Search_Tag = _DataView[0]["SCode"].ToString();
                Search_Title = _DataView[0]["Title"].ToString();
                _Result = true;
            }
            return _Result;
        }
        private bool SearchCode(string _Value, DataTable _DataTable)
        {
            // Return value for e.Cancel of Text Boox Validating

            bool _Result = false;

            DataView _DataView = _DataTable.AsDataView();

            _DataView.RowFilter = "Code='" + _Value.ToString().Trim() + "'";
            if (_DataView.Count == 1)
            {
                Search_ComboID = Conversion.ToInteger(_DataView[0]["ID"]);
                Search_Code = _DataView[0]["Code"].ToString();
                Search_Tag = _DataView[0]["SCode"].ToString();
                Search_Title = _DataView[0]["Title"].ToString();
                _Result = true;
            }
            return _Result;
        }
        private bool SearchTag(string _Value, DataTable _DataTable)
        {
            // Return value for e.Cancel of Text Boox Validating

            bool _Result = false;

            DataView _DataView = _DataTable.AsDataView();

            _DataView.RowFilter = "SCode='" + _Value.ToString().Trim() + "'";
            if (_DataView.Count == 1)
            {
                Search_ComboID = Conversion.ToInteger(_DataView[0]["ID"]);
                Search_Code = _DataView[0]["Code"].ToString();
                Search_Tag = _DataView[0]["SCode"].ToString();
                Search_Title = _DataView[0]["Title"].ToString();
                _Result = true;
            }
            return _Result;
        }

        public bool IsNullAllowed(TextBox _Textbox)
        {
            // return a bool value for Textbox Validation
            bool _Result = false;
            switch (Voucher_Type)
            {
                case null:
                    break;

                case "":
                    break;

                case "Journal":

                    if (_Textbox.Name == "txtCOA") { _Result = false; }
                    if (_Textbox.Name == "txtSupplier") { _Result = true; }
                    if (_Textbox.Name == "txtProject") { _Result = true; }
                    if (_Textbox.Name == "txtUnit") { _Result = true; }
                    if (_Textbox.Name == "txtStock") { _Result = true; }
                    if (_Textbox.Name == "txtEmployee") { _Result = true; }

                    break;

                case "Payment":

                    if (_Textbox.Name == "txtCOA") { _Result = false; }
                    if (_Textbox.Name == "txtSupplier") { _Result = false; }
                    if (_Textbox.Name == "txtProject") { _Result = false; }
                    if (_Textbox.Name == "txtUnit") { _Result = true; }
                    if (_Textbox.Name == "txtStock") { _Result = true; }
                    if (_Textbox.Name == "txtEmployee") { _Result = true; }


                    break;

                case "Receipt":
                    if (_Textbox.Name == "txtCOA") { _Result = false; }
                    if (_Textbox.Name == "txtSupplier") { _Result = false; }
                    if (_Textbox.Name == "txtProject") { _Result = false; }
                    if (_Textbox.Name == "txtUnit") { _Result = false; }
                    if (_Textbox.Name == "txtStock") { _Result = true; }
                    if (_Textbox.Name == "txtEmployee") { _Result = true; }


                    break;

                case "Stock":
                    if (_Textbox.Name == "txtCOA") { _Result = false; }
                    if (_Textbox.Name == "txtSupplier") { _Result = false; }
                    if (_Textbox.Name == "txtProject") { _Result = false; }
                    if (_Textbox.Name == "txtUnit") { _Result = true; }
                    if (_Textbox.Name == "txtStock") { _Result = false; }
                    if (_Textbox.Name == "txtEmployee") { _Result = true; }

                    break;

                case "Payroll":
                    if (_Textbox.Name == "txtCOA") { _Result = false; }
                    if (_Textbox.Name == "txtSupplier") { _Result = true; }
                    if (_Textbox.Name == "txtProject") { _Result = false; }
                    if (_Textbox.Name == "txtUnit") { _Result = true; }
                    if (_Textbox.Name == "txtStock") { _Result = true; }
                    if (_Textbox.Name == "txtEmployee") { _Result = false; }

                    break;

                default:
                    break;
            }



            return _Result;                        // Temporary allowed true.
        }

    }
}
