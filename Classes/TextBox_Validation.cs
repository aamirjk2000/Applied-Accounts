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

    }

    public class TextBox_Validation : ITextBox_Validation
    {
        public TextBox_Validation()
        {
        }
            
        
        public int Search_ComboID { get; set; }
        public string Search_Title { get; set; }
        public string Search_Tag { get; set; }
        public string Search_Code { get; set; }
        public string Voucher_Type { get; set; }
            

        public bool Validating(object sender, DataTable _DataTable)
        {
            if (((TextBox)sender).Text.Length == 0) { return false; }      // Text Box is empty, do not validate


            bool IsSearch1 = SearchID(((TextBox)sender).Text, _DataTable);              // Seek Id in Table
            bool IsSearch2 = SearchCode(((TextBox)sender).Text, _DataTable);            // Seek Code in Table
            bool IsSearch3 = SearchTag(((TextBox)sender).Text, _DataTable);             // Seek SCode in table
            if (IsSearch1 || IsSearch2 || IsSearch3) { return false; } else { return true; }
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

        public bool IsNullAllowed()
        {
            return false;                        // Temporary allowed true.
        }

    }
}
