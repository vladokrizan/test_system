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
            labXDM3051_status.Text = "";
            labXDM3051_read_result.Text = "";
            labXDM3051_measure.Text = "";
            labXDM2041_status.Text = "";
            labXDM2041_read_result.Text = "";
            labXDM2041_measure.Text = "";
            labXDM1041_status.Text = "";
            labXDM1041_read_result.Text = "";
            labXDM1041_measure.Text = "";

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            labXDM3051_status.Text = "DC voltage  " + device_XDM3051_range_dc_volt.ToString();
            //txtBox_XDM3051_measure.Text = device_measure[COMport_SELECT_MULTIMETER_XDM3051].ToString();
            //labXDM3051_measure_ok.Text = device_measure_state[COMport_SELECT_MULTIMETER_XDM3051].ToString();


            labXDM3051_read_result.Text = dev_meas_state[COMport_XDM3051].ToString();
            labXDM3051_measure.Text = dev_meas[COMport_XDM3051].ToString("0.0000");
            //labXDM2041_status.Text = "DC voltage  " + device_XDM2041_range_dc_volt.ToString();
            
            
            //labXDM2041_read_result.Text = device_XDM2041_measure_ok.ToString();
            //labXDM2041_measure.Text = device_XDM2041_measure.ToString("0.0000");
            //labXDM1041_status.Text = "DC voltage  " + device_XDM2041_range_dc_volt.ToString();
            
            
            
            //labXDM1041_read_result.Text = device_XDM1041_measure_ok.ToString();
            //labXDM1041_measure.Text = device_XDM1041_measure.ToString("0.0000");


        }





    }
}
