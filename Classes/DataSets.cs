using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applied_Accounts.Classes
{
    interface IDataSets
    {
        DataSet ds_General_Ledger();
    }

    public class DataSets : IDataSets
    {

        public DataSet ds_General_Ledger()
        {
            return new DataSet();
        }
    }
}
