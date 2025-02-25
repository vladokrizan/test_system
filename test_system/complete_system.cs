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


            labComplete_temperature_1.Text = "Temp 1  " + device_ET3916_temperature[1].ToString("0.00");
            labComplete_temperature_2.Text = "Temp 2  " + device_ET3916_temperature[2].ToString("0.00");
            labComplete_temperature_3.Text = "Temp 3  " + device_ET3916_temperature[3].ToString("0.00");
            labComplete_temperature_4.Text = "Temp 4  " + device_ET3916_temperature[4].ToString("0.00");
            labComplete_temperature_5.Text = "Temp 5  " + device_ET3916_temperature[5].ToString("0.00");
            labComplete_temperature_6.Text = "Temp 6  " + device_ET3916_temperature[6].ToString("0.00");
            labComplete_temperature_7.Text = "Temp 7  " + device_ET3916_temperature[7].ToString("0.00");
            labComplete_temperature_8.Text = "Temp 8  " + device_ET3916_temperature[8].ToString("0.00");
  
        }


        private void labComplete_temperature_1_Click(object sender, EventArgs e)
        {

            complete_device_ET391_read_all_temperature = true;
            temperature_ET3916.fun_ET3916_read_all_temperature();

        }



        private void groupBox_temperature_ET3916_Enter(object sender, EventArgs e)
        {

        }

      
    }
}
