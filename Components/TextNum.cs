using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applied_Accounts.Components
{
    public partial class TextNum : Component
    {
        public TextNum()
        {
            InitializeComponent();
        }

        public TextNum(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }
}
