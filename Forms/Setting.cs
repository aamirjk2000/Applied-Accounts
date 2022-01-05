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
    public partial class frmSetting : Form
    {

        DataTable tb_Nature = AppliedTable.GetDataTable(Tables.Nature);          // Load Account - Nature Table

        public frmSetting()
        {
            InitializeComponent();

            cBoxStock.DataSource = tb_Nature.Copy();
            cBoxPayroll.DataSource = tb_Nature.Copy();
            cBoxPayable.DataSource = tb_Nature.Copy();
            cBoxReceivable.DataSource = tb_Nature.Copy();

            cBoxStock.DisplayMember = "Title";
            cBoxPayroll.DisplayMember = "Title";
            cBoxPayable.DisplayMember = "Title";
            cBoxReceivable.DisplayMember = "Title";

            cBoxStock.ValueMember = "ID";
            cBoxPayroll.ValueMember = "ID";
            cBoxPayable.ValueMember = "ID";
            cBoxReceivable.ValueMember = "ID";

            

        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            txtCompanyName.Text = Applied.GetString("Company");
            dtAccountingFrom.Value = Applied.GetDate("VouDate1");
            dtAccountingTo.Value = Applied.GetDate("Vou_Date2");
            txtReportDateFormat.Text = Applied.GetString("DateFormat_Report");
            txtDatePickerFormat.Text = Applied.GetString("DateFormat_Picker");
            txtComboDateFormat.Text = Applied.GetString("DateFormat_Combo");
            txtDefaultDateFormat.Text = Applied.GetString("DateFormat_Default");
            txtReportDateFormat.Text = Applied.GetString("DateFormat_Heading");
            txtReportHeadingFormat.Text = Applied.GetString("DateFormat_Heading");
            txtCurrencyFormat.Text = Applied.GetString("CurrencyFormat");

            cBoxStock.SelectedValue = Applied.GetInteger("NatureStock");
            cBoxPayroll.SelectedValue = Applied.GetInteger("NaturePayroll");
            cBoxPayable.SelectedValue = Applied.GetInteger("NaturePayable");
            cBoxReceivable.SelectedValue = Applied.GetInteger("NatureReceivable");
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
             
        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            Applied.SetValue("Company", txtCompanyName.Text.Trim(), Applied.KeyType.String);
        }

        #region Dates

        private void dtAccountingFrom_Leave(object sender, EventArgs e)
        {
            Applied.SetValue("VouDate1", dtAccountingFrom.Value, Applied.KeyType.DateTime);
        }

        private void dtAccountingTo_Leave(object sender, EventArgs e)
        {
            if(dtAccountingTo.Value <= dtAccountingFrom.Value)
            {
                dtAccountingTo.Value = dtAccountingFrom.Value.AddDays(1);
            }

            Applied.SetValue("VouDate2", dtAccountingFrom.Value, Applied.KeyType.DateTime);
        }

        private void txtReportDateFormat_Leave(object sender, EventArgs e)
        {
            Applied.SetValue("DateFormat_Report", txtReportDateFormat.Text.Trim(), Applied.KeyType.String);
        }

        private void txtDatePickerFormat_Leave(object sender, EventArgs e)
        {
            Applied.SetValue("DateFormat_Picker", txtDatePickerFormat.Text.Trim(), Applied.KeyType.String);
        }

        private void txtDefaultDateFormat_Leave(object sender, EventArgs e)
        {
            Applied.SetValue("DateFormat_Default", txtDefaultDateFormat.Text.Trim(), Applied.KeyType.String);
        }

        private void txtComboDateFormat_Leave(object sender, EventArgs e)
        {
            Applied.SetValue("DateFormat_Combo", txtComboDateFormat.Text.Trim(), Applied.KeyType.String);
        }

        private void txtReportHeadingFormat_Leave(object sender, EventArgs e)
        {
            Applied.SetValue("DateFormat_Heading", txtReportHeadingFormat.Text.Trim(), Applied.KeyType.String);
        }

        private void txtCurrencyFormat_Leave(object sender, EventArgs e)
        {
            Applied.SetValue("CurrencyFormat", txtCurrencyFormat.Text.Trim(), Applied.KeyType.String);
        }

        #endregion

        #region Accounts Nature

        private void cBoxStock_Leave(object sender, EventArgs e)
        {
            Applied.SetValue("NatureStock", cBoxStock.SelectedValue, Applied.KeyType.Integer);
        }

        private void cBoxPayroll_Leave(object sender, EventArgs e)
        {
            Applied.SetValue("NaturePayroll", cBoxPayroll.SelectedValue, Applied.KeyType.Integer);
        }

        private void cBoxReceivable_Leave(object sender, EventArgs e)
        {
            Applied.SetValue("NatureReceivable", cBoxReceivable.SelectedValue, Applied.KeyType.Integer);
        }

        private void cBoxPayable_Leave(object sender, EventArgs e)
        {
            Applied.SetValue("NaturePayable", cBoxPayable.SelectedValue, Applied.KeyType.Integer);
        }
        #endregion

    }   //  END Main Class
}       // END Namespace
