using Applied_Accounts.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Applied_Accounts.Forms
{
    public partial class frmInventory : Form
    {

        #region Variables

        public InventoryClass MyInventoryClass = new InventoryClass();
        private long Transaction_ID { get => MyInventoryClass.Transaction_ID; }
        private string Vou_No { get => MyInventoryClass.Vou_No; }
        private decimal MyQty { get => Conversion.ToMoney(txtQty.Text); }
        private decimal MyRate {  get=> Conversion.ToMoney(txtRate.Text);}
        private decimal MyAmount { get => MyQty * MyRate; }

        #endregion

        #region Initialize

        public frmInventory()
        {
            InitializeComponent();
        }
          

        public frmInventory(DataRow _VouRow)
        {
            InitializeComponent();
            MyInventoryClass = new InventoryClass(_VouRow);
            Set_Grid();
            Set_Textbox();
        }

        #endregion

        private void Set_Textbox()
        {
            txtVouID.Text = MyInventoryClass.Transaction_ID.ToString();
            txtVouNo.Text = MyInventoryClass.Vou_No.ToString();
            txtStock.Text = MyInventoryClass.Stock_Title;
            txtTotalAmount.Text = MyInventoryClass.Vou_Amount.ToString("###,###,###.##");
        }
        


        #region Grid Setting
        private void Set_Grid()
        {
            Grid_Inventory.DataSource = MyInventoryClass.dv_Inventory;

            string[] Headings = { "ID", "Vou ID", "Vou #", "Stock #", "Stock Title", "Qty", "UOM", "Size", "Rate", "Amount", "Description", "Comments", "Total Rs." };

            List<string> _Headings = new List<string>(Headings);
            int i = 0;

            Grid_Inventory.Columns[0].Visible = false;
            Grid_Inventory.Columns[1].Width = 50;
            Grid_Inventory.Columns[2].Width = 60;
            Grid_Inventory.Columns[3].Width = 100;
            Grid_Inventory.Columns[4].Width = 200;
            Grid_Inventory.Columns[5].Width = 70;
            Grid_Inventory.Columns[6].Width = 70;
            Grid_Inventory.Columns[7].Width = 70;
            Grid_Inventory.Columns[8].Width = 70;
            Grid_Inventory.Columns[9].Width = 90;
            Grid_Inventory.Columns[10].Width = 120;
            Grid_Inventory.Columns[11].Width = 150;
            Grid_Inventory.Columns[12].Width = 60;

            Grid_Inventory.Columns[1].HeaderText = _Headings[i + 1]; i += 1;            // Set Header title of Data Grid.
            Grid_Inventory.Columns[2].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[3].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[4].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[5].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[6].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[7].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[8].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[9].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[10].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[11].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[12].HeaderText = _Headings[i + 1]; i += 1;


            Grid_Inventory.Columns[7].DefaultCellStyle.Format = "###,###,###,###.##";

            Grid_Inventory.Columns[0].Visible = false;              // Disable ID
            Grid_Inventory.Columns[1].Visible = false;              // Disable Vou ID
            Grid_Inventory.Columns[2].Visible = false;              // Disable Vou No
            Grid_Inventory.Columns[11].Visible = false;            // Disable Comments
            Grid_Inventory.Columns[12].Visible = false;             // Disable Vou Total Amount
        }



        private void Grid_Inventory_Enter(object sender, EventArgs e)
        {
        }

        #endregion

        #region Stock Row
        private void Grid_Inventory_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

            Grid_Inventory.Rows[0].Cells["ID"].Value = -1;
            Grid_Inventory.Rows[0].Cells["Vou_ID"].Value = Transaction_ID;
            Grid_Inventory.Rows[0].Cells["Vou_No"].Value = MyInventoryClass.Vou_No;
            Grid_Inventory.Rows[0].Cells["Stock"].Value = 0;
            Grid_Inventory.Rows[0].Cells["Title"].Value = "title";
            Grid_Inventory.Rows[0].Cells["Qty"].Value = 0;
            Grid_Inventory.Rows[0].Cells["UOM"].Value = "";
            Grid_Inventory.Rows[0].Cells["Size"].Value = "";
            Grid_Inventory.Rows[0].Cells["Rate"].Value = 0;
            Grid_Inventory.Rows[0].Cells["Amount"].Value = 0;
            Grid_Inventory.Rows[0].Cells["Description"].Value = "desc";
            Grid_Inventory.Rows[0].Cells["Comments"].Value = "Comm";
            Grid_Inventory.Rows[0].Cells["Amount"].Value = MyInventoryClass.Vou_Amount;
            MessageBox.Show("User Row Added");
        }

        private void Grid_Inventory_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }
        #endregion

        #region Form close
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region TextBox QTY

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Applied.IsNumeric(sender, e);
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            txtAmount.Text = (MyQty * MyRate).ToString("###,###,###.##");
            txtQty.Text = (Conversion.ToLong(txtQty.Text).ToString("###,###,###.##"));
        }

        #endregion

        #region TextBox Rate

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Applied.IsNumeric(sender, e);
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            txtAmount.Text = (MyQty * MyRate).ToString("###,###,###.##");
            txtRate.Text = (Conversion.ToLong(txtRate.Text).ToString("###,###,###.##"));
        }


        #endregion

        
    }       // END -- Class
}           // END -- Namespace
