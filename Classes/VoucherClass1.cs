using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applied_Accounts.Classes
{
    interface IVoucherClass1
    {
        void Save();
        void Save(DataRow _Row);
    }


    class VoucherClass1 : IVoucherClass1
    {
        private DataTable tb_Voucher;
        private DataTable tb_Voucher_Delete;
        private DataTable tb_GridData;
        private DataRow MyRow;
        private Dictionary<string, string> MyVoucher = new Dictionary<string, string>();

        //===============================================================================================



        VoucherClass1()
        {
            

        }

        VoucherClass1(string _VouNo)
        {


        }


        #region Save

        public void Save()
        {
            Save(MyRow);
        }

        public void Save(DataRow _Row)
        {

        }

        #endregion
  


    
    
    }       // END Class
}           // END NameSpace
