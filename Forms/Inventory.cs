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
        public InventoryClass Inventory_Class = new InventoryClass();
        public long Transaction_ID { get; set; }
        public string Vou_No { get; set; }

        public frmInventory()
        {
            InitializeComponent();
        }

        public frmInventory(string _VouNo)
        {
            InitializeComponent();
            Vou_No = _VouNo;
            Inventory_Class = new InventoryClass(_VouNo);
            Set_Grid();
        }


        private void Set_Grid()
        {
            Grid_Inventory.DataSource = Inventory_Class.dv_Inventory;

            string[] Headings = { "1", "2", "Vou #", "Stock #", "Stock Title", "Qty", "Rate", "Amount", "Description", "Comments", "Total Rs." };

            List<string> _Headings = new List<string>(Headings);
            int i = 0;

            Grid_Inventory.Columns[0].Visible = false;
            Grid_Inventory.Columns[1].Width = 60;
            Grid_Inventory.Columns[2].Width = 60;
            Grid_Inventory.Columns[3].Width = 60;
            Grid_Inventory.Columns[4].Width = 120;
            Grid_Inventory.Columns[5].Width = 60;
            Grid_Inventory.Columns[6].Width = 60;
            Grid_Inventory.Columns[7].Width = 60;
            Grid_Inventory.Columns[8].Width = 120;
            Grid_Inventory.Columns[9].Width = 60;
            Grid_Inventory.Columns[10].Width = 60;

            Grid_Inventory.Columns[1].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[2].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[3].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[4].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[5].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[6].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[7].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[8].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[9].HeaderText = _Headings[i + 1]; i += 1;
            Grid_Inventory.Columns[10].HeaderText = _Headings[i + 1]; i += 1;

        }

        private void Grid_Inventory_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

            Grid_Inventory.Rows[0].Cells["ID"].Value = -1;
            Grid_Inventory.Rows[0].Cells["Vou_ID"].Value = Transaction_ID;
            Grid_Inventory.Rows[0].Cells["Vou_No"].Value = Inventory_Class.Vou_No;
            Grid_Inventory.Rows[0].Cells["Stock"].Value = 0;
            Grid_Inventory.Rows[0].Cells["Title"].Value = "title";
            Grid_Inventory.Rows[0].Cells["Qty"].Value = 0;
            Grid_Inventory.Rows[0].Cells["Rate"].Value = 0;
            Grid_Inventory.Rows[0].Cells["Amount"].Value = 0;
            Grid_Inventory.Rows[0].Cells["Description"].Value = "desc";
            Grid_Inventory.Rows[0].Cells["Comments"].Value = "Comm";
            Grid_Inventory.Rows[0].Cells["Amount"].Value = Inventory_Class.Vou_Amount;

            MessageBox.Show("User Row Added");

        }

        private void Grid_Inventory_Enter(object sender, EventArgs e)
        {
            //if (Grid_Inventory.Rows.Count == 0)
            //{
            //    Grid_Inventory.Rows.Add();
            //}


        }

        private void Grid_Inventory_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }
    }
}
