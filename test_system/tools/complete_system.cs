using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static test_system.global_variable;

namespace test_system
{
    public partial class complete_system : Form
    {

        ac_meter_MPM_1010B ac_meter_MPM_1010B = new ac_meter_MPM_1010B();
        temperature_ET3916 temperature_ET3916 = new temperature_ET3916();


        public complete_system()
        {
            InitializeComponent();
        }

        private void complete_system_Load(object sender, EventArgs e)
        {
              }


        private void timer1_Tick(object sender, EventArgs e)
        {
    
        }





    }
}
