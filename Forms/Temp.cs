using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applied_Accounts.Forms
{
    public partial class frmTemp : Form
    {
        DataTable _DataTable = AppliedTable.GetDataTable(Tables.Suppliers,true);
        bool _Sorted { get; set; }

        public frmTemp()
        {
            InitializeComponent();
            _Sorted = false;
            SetCBox();
           
        }

        private void cBoxTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if(cBoxTest.SelectedValue==null) { return; }
            if(cBoxTest.SelectedItem==null) { return; }

            txtText.Text = cBoxTest.Text;
            txtValue.Text = cBoxTest.SelectedValue.ToString();
            txtItem.Text = ((DataRowView)cBoxTest.SelectedItem)["ID"].ToString();
            txtIndex.Text = cBoxTest.SelectedIndex.ToString();
                       
        }

        private void SetCBox()
        {
            cBoxTest.DataSource = _DataTable;
            cBoxTest.DisplayMember = "Title";
            cBoxTest.ValueMember = "ID";
            //cBoxTest.Sorted = _Sorted;


            lBox.DataSource = _DataTable;
            lBox.DisplayMember = "Title";
            lBox.ValueMember = "ID";



        }

        private void btnSorted_Click(object sender, EventArgs e)
        {
            if(_Sorted)
            {
                _Sorted = false;
            }
            else
            {
                _Sorted = true;
            }
        }
    }
}
