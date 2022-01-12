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
        private decimal MyRate { get => Conversion.ToMoney(txtRate.Text); }
        //private decimal MyAmount { get => MyQty * MyRate; }
        private string CurrencyFormat { get => Applied.GetString("CurrencyFormat"); }
        #endregion

        #region Initialize

        public frmInventory()
        {
            InitializeComponent();
        }

        public frmInventory(InventoryClass _InventoryClass)
        {
            InitializeComponent();
            MyInventoryClass = _InventoryClass;
            Set_Grid();
            Set_Textbox();
        }

        #endregion

        #region Set TextBox

        private void Set_Textbox()
        {
            txtID.Text = MyInventoryClass.StockRow["SRNO"].ToString();
            txtVouID.Text = MyInventoryClass.StockRow["Vou_ID"].ToString();
            txtVouNo.Text = MyInventoryClass.StockRow["Vou_No"].ToString();
            txtStock.Text = MyInventoryClass.Stock_Title;
            txtSize.Text = MyInventoryClass.StockRow["Size"].ToString();
            txtQty.Text = MyInventoryClass.StockRow["Qty"].ToString();
            txtUOM.Text = MyInventoryClass.StockRow["UOM"].ToString();
            txtRate.Text = MyInventoryClass.StockRow["Rate"].ToString();
            txtAmount.Text = MyInventoryClass.StockRow["Amount"].ToString();
            txtDescription.Text = MyInventoryClass.StockRow["Description"].ToString();
            txtComments.Text = MyInventoryClass.StockRow["comments"].ToString();
            txtTotalAmount.Text = Conversion.ToMoney(MyInventoryClass.StockRow["Vou_Amount"]).ToString(CurrencyFormat);
            txtGridAmount.Text = MyInventoryClass.GridTotal().ToString(CurrencyFormat);
            decimal Amount1 = Conversion.ToMoney(txtTotalAmount.Text), Amount2 = Conversion.ToMoney(txtGridAmount.Text);
            txtDifference.Text = (Amount2 - Amount2).ToString(CurrencyFormat);

            #region Enable & Disbale TextBox
            if (Conversion.ToLong(txtID.Text) < 0)
            {
                txtID.Enabled = false;                                              // Deletion Marked Record
                txtVouID.Enabled = false;
                txtVouNo.Enabled = false;
                txtStock.Enabled = false;
                txtSize.Enabled = false;
                txtQty.Enabled = false;
                txtUOM.Enabled = false;
                txtRate.Enabled = false;
                txtAmount.Enabled = false;
                txtDescription.Enabled = false;
                txtComments.Enabled = false;
            }
            else
            {
                txtID.Enabled = true;                                               // not deleted record.
                txtVouID.Enabled = true;
                txtVouNo.Enabled = true;
                txtStock.Enabled = true;
                txtSize.Enabled = true;
                txtQty.Enabled = true;
                txtUOM.Enabled = true;
                txtRate.Enabled = true;
                txtAmount.Enabled = true;
                txtDescription.Enabled = true;
                txtComments.Enabled = true;
            }
            #endregion

        }

        private void Set_Textbox(int _RowIndex)
        {
            MyInventoryClass.UpdateStockRow(_RowIndex);                 // Update Stock Row by Table Index Row
            Set_Textbox();
        }


        #endregion

        #region Grid Setting
        private void Set_Grid()
        {
            Grid_Inventory.DataSource = MyInventoryClass.UpdateGridView();

            Grid_Inventory.Columns[0].HeaderText = "SRNO";
            Grid_Inventory.Columns[1].HeaderText = "Stock Title";
            Grid_Inventory.Columns[2].HeaderText = "Size";
            Grid_Inventory.Columns[3].HeaderText = "Measuer";
            Grid_Inventory.Columns[4].HeaderText = "Quantity";
            Grid_Inventory.Columns[5].HeaderText = "Rate";
            Grid_Inventory.Columns[6].HeaderText = "Amount";
            Grid_Inventory.Columns[7].HeaderText = "Status";

            Grid_Inventory.Columns[0].Width = 30;
            Grid_Inventory.Columns[1].Width = 240;
            Grid_Inventory.Columns[2].Width = 80;
            Grid_Inventory.Columns[3].Width = 80;
            Grid_Inventory.Columns[4].Width = 90;
            Grid_Inventory.Columns[5].Width = 90;
            Grid_Inventory.Columns[6].Width = 120;
            Grid_Inventory.Columns[7].Width = 80;

            Grid_Inventory.Columns[3].DefaultCellStyle.Format = CurrencyFormat;
            Grid_Inventory.Columns[4].DefaultCellStyle.Format = CurrencyFormat;
            Grid_Inventory.Columns[5].DefaultCellStyle.Format = CurrencyFormat;
            Grid_Inventory.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        #endregion

        #region Stock Row

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
            txtAmount.Text = (MyQty * MyRate).ToString(CurrencyFormat);
            txtQty.Text = (Conversion.ToLong(txtQty.Text).ToString(CurrencyFormat));
        }

        #endregion

        #region TextBox Rate

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Applied.IsNumeric(sender, e);
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            txtAmount.Text = (MyQty * MyRate).ToString(CurrencyFormat);
            txtRate.Text = Conversion.ToLong(txtRate.Text).ToString(CurrencyFormat);
        }

        #endregion

        #region Add / Save / delete Button
        private void btnAdd_Click(object sender, EventArgs e)
        {


            MyInventoryClass.StockRow["SRNO"] = MyInventoryClass.MaxSRNO() + 1;
            MyInventoryClass.StockRow["Vou_ID"] = MyInventoryClass.Vou_ID;
            MyInventoryClass.StockRow["Vou_No"] = MyInventoryClass.Vou_No;
            MyInventoryClass.StockRow["Vou_Amount"] = MyInventoryClass.Vou_Amount;
            MyInventoryClass.StockRow["Stock"] = MyInventoryClass.Stock_COA;
            MyInventoryClass.StockRow["Qty"] = 0.00;
            MyInventoryClass.StockRow["UOM"] = "";
            MyInventoryClass.StockRow["Size"] = "";
            MyInventoryClass.StockRow["Rate"] = 0.00;
            MyInventoryClass.StockRow["Amount"] = 0.00;
            MyInventoryClass.StockRow["Description"] = "";
            MyInventoryClass.StockRow["Comments"] = "";
            MyInventoryClass.StockRow["Batch"] = 0;

            Set_Textbox();            // Refresh Text box

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyInventoryClass.StockRow["SRNO"] = Conversion.ToLong(txtID.Text);
            MyInventoryClass.StockRow["Vou_ID"] = Conversion.ToLong(txtVouID.Text);
            MyInventoryClass.StockRow["Vou_No"] = txtVouNo.Text.Trim();
            MyInventoryClass.StockRow["Vou_Amount"] = Conversion.ToMoney(txtTotalAmount.Text);
            MyInventoryClass.StockRow["Stock"] = MyInventoryClass.Stock_COA;
            MyInventoryClass.StockRow["Qty"] = Conversion.ToMoney(txtQty.Text);
            MyInventoryClass.StockRow["UOM"] = txtUOM.Text.Trim();
            MyInventoryClass.StockRow["Size"] = txtSize.Text.Trim();
            MyInventoryClass.StockRow["Rate"] = Conversion.ToMoney(txtRate.Text);
            MyInventoryClass.StockRow["Amount"] = Conversion.ToMoney(txtAmount.Text);
            MyInventoryClass.StockRow["Description"] = txtDescription.Text.Trim();
            MyInventoryClass.StockRow["Comments"] = txtComments.Text.Trim();
            MyInventoryClass.StockRow["Batch"] = 0;
            

            MyInventoryClass.Save();                                                                                            // Save a record in Table and Grid View 
            Grid_Inventory.DataSource = MyInventoryClass.UpdateGridView();
            txtGridAmount.Text = MyInventoryClass.Grid_Amount.ToString(CurrencyFormat);
            Set_Textbox(MyInventoryClass.Row_Index);                                                              // Refresh Text box

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataRow _Row in MyInventoryClass.tb_Inventory.Rows)
            {
                if (Conversion.ToLong(_Row["ID"]) == Conversion.ToLong(txtID.Text))
                {
                    MyInventoryClass.StockRow["ID"] = Conversion.ToLong(_Row["ID"]) * -1;
                    MyInventoryClass.Row_Index = MyInventoryClass.tb_Inventory.Rows.IndexOf(_Row);   // SaveFileDialog Table Index
                }

                MyInventoryClass.Save();                                                                                               // Update Table Record
                Grid_Inventory.DataSource = MyInventoryClass.UpdateGridView();                             // Update Grid Source
                txtGridAmount.Text = MyInventoryClass.Grid_Amount.ToString(CurrencyFormat);       // Update Grid total Amount Textbox
                Set_Textbox(MyInventoryClass.Row_Index);                                                                 // Update Textbox 
            }
        }
      

        #endregion

        #region Totals

        private void txtGridAmount_TextChanged(object sender, EventArgs e)
        {
            decimal Amount1 = Conversion.ToMoney(txtTotalAmount.Text), Amount2 = Conversion.ToMoney(MyInventoryClass.GridTotal());
            txtGridAmount.Text = Amount2.ToString(CurrencyFormat);
            txtDifference.Text = (Amount1 - Amount2).ToString(CurrencyFormat);
        }




        #endregion

        #region Grid Events


       

        private void Grid_Inventory_CurrentCellChanged(object sender, EventArgs e)
        {
            if (Controls["Grid_Inventory"].Focused)         // Execute this event if grid is focused.
            {
                long GridSRNO = Conversion.ToLong(Grid_Inventory.CurrentRow.Cells["SRNO"].Value);
                foreach (DataRow _Row in MyInventoryClass.tb_Inventory.Rows)
                {
                    if (GridSRNO == Conversion.ToLong(_Row["SRNO"]))
                    {
                        MyInventoryClass.Row_Index = MyInventoryClass.tb_Inventory.Rows.IndexOf(_Row);
                        Set_Textbox(MyInventoryClass.Row_Index);
                    }
                }
            }
        }


        #endregion

        private void frmInventory_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }       // END -- Class
}           // END -- Namespace
