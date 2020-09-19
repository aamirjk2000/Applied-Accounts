using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applied_Accounts.Classes
{

    interface iTable_Voucher
    {
        void Load_Data();
        bool Seek_Voucher(string Voucher_No);
    }


    



    class Table_Voucher 
    {

        public Table_Voucher()
        {
            Load_Data();

        }


        public void Load_Data()
        {


        }

        public bool Seek_Voucher(string Voucher_No)
        {

            return true;
        }
        




    }
}
