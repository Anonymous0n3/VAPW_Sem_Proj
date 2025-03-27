using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAPW_Sem_Proj
{
    public partial class DriveDraw: System.Windows.Forms.Panel
    {    
        public DriveDraw()
        {
            InitializeComponent();
        }

        public DriveDraw(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
