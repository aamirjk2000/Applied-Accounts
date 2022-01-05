using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applied_Accounts.Classes
{
    internal interface IApplied
    {
        DateTime MinVouDate();
        DateTime MaxVouDate();
    }

}
