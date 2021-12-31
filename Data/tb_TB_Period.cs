using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applied_Accounts.Data
{
    public partial class tb_TB_Period : Component
    {
        public tb_TB_Period()
        {
            InitializeComponent();
        }

        public tb_TB_Period(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
