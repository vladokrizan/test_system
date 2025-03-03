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
    public partial class all_devices : Form
    {

        ac_meter_MPM_1010B ac_meter_MPM_1010B = new ac_meter_MPM_1010B();
        temperature_ET3916 temperature_ET3916 = new temperature_ET3916();
        power_supply_KA3305P power_supply_KA3305P = new power_supply_KA3305P(); 
        power_supply_hcs_3300 power_supply_hcs_3300 = new power_supply_hcs_3300();
        power_supply_RD6006 power_supply_RD6006 = new power_supply_RD6006();
        multimeter_XDM3051 multimeter_XDM3051 = new multimeter_XDM3051();
        multimeter_XDM1041 multimeter_XDM1041 = new multimeter_XDM1041();

        dc_load_KEL103 dc_load_KEL103 = new dc_load_KEL103();

        modbus_functions modbus_functions = new modbus_functions();
        write_log_files write_log_files = new write_log_files();


        #region "nalaganje okna  "
        public all_devices()
        {
            InitializeComponent();
        }
        private void all_devices_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region "Timer "

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (device_ET3916_serial_number_show)
            {
                if (device_ET3916_serial_number.Length > 5)
                {
                    device_ET3916_serial_number_show = false;
                    txtBox_ET3916_1.Text = device_ET3916_serial_number;
                }
            }

        }

        #endregion
        #region " Power supply "
        #region " Power supply  - Manson  1-16V 30A   HCS - 3300"


        //-- IDENT 
        private void btnPowerSupply_1_1_Click(object sender, EventArgs e)
        {

            power_supply_hcs_3300.fun_HCS_330_identifaction();
            txtBosPowerSupply_1_1.Text = COMport_device_ident[COMport_SELECT_SUPPLY_HCS_330];
        }


        /*


                private void button11_Click(object sender, EventArgs e)
        {
            power_supply_hcs_3300.fun_HCS_330_off();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            power_supply_hcs_3300.fun_HCS_330_on();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            power_supply_hcs_3300.fun_HCS_330_get_measure();
            label9.Text = strGeneralString;
            textBox1.Text = strGeneralString;

        }


        */



        #endregion


        #region " Power supply  ---- KORAD  ---  KA3305P    "

        private void btnPowerSupply_KA3305P_ident1_Click(object sender, EventArgs e)
        {
            power_supply_KA3305P.fun_KA3305P_identifaction();
            txtBosPowerSupply_KA3305P_ident.Text = COMport_device_ident[COMport_SELECT_SUPPLY_KA3305A];

        }




        #endregion

        #region " Power supply  ---- RD6006     ------     "


        private void btnPowerSupply_RD6006_ON_Click(object sender, EventArgs e)
        {
            power_supply_RD6006.funRD6006_on();
            //modbus_functions.funModbusRTU_send_set_single_register_function_6(1, 18, 1, COMport_SELECT_SUPPLY_RD6006);
        }

        private void btnPowerSupply_RD6006_OFF_Click(object sender, EventArgs e)
        {
            power_supply_RD6006.funRD6006_off();
            //modbus_functions.funModbusRTU_send_set_single_register_function_6(1, 18, 0, COMport_SELECT_SUPPLY_RD6006);
        }


        #endregion


        #endregion

        #region "MULTIMETER "
        #region " Multimeter --- East Tester --- ET916-8 ---- temperature meter "

        private void btnET3916_ident_Click(object sender, EventArgs e)
        {
            temperature_ET3916.fun_ET3916_read_serial_number();
            device_ET3916_serial_number_show = true;
            
            //txtBox_ET3916_1.Text = device_ET3916_serial_number;

        }


        /*
                private void button3_Click(object sender, EventArgs e)
                {
                    temperature_ET3916.fun_ET3916_read_model_nuber();
                    label3.Text = strGeneralString;
                }

                private void button4_Click(object sender, EventArgs e)
                {
                    temperature_ET3916.fun_ET3916_read_model_nuber();
                    label7.Text = device_ET3916_dataArraySend[0].ToString("x") + "    " + device_ET3916_dataArraySend[1].ToString("x") + "    " + device_ET3916_dataArraySend[2].ToString("x") + "    " + device_ET3916_dataArraySend[3].ToString("x") + "    " + device_ET3916_dataArraySend[4].ToString("x") + "    " + device_ET3916_dataArraySend[5].ToString("x") + "    ";
                }

                private void button5_Click(object sender, EventArgs e)
                {
                    temperature_ET3916.fun_ET3916_read_serial_number();
                    label7.Text = device_ET3916_dataArraySend[0].ToString("x") + "    " + device_ET3916_dataArraySend[1].ToString("x") + "    " + device_ET3916_dataArraySend[2].ToString("x") + "    " + device_ET3916_dataArraySend[3].ToString("x") + "    " + device_ET3916_dataArraySend[4].ToString("x") + "    " + device_ET3916_dataArraySend[5].ToString("x") + "    ";
                }

                private void button6_Click(object sender, EventArgs e)
                {
                    temperature_ET3916.fun_ET3916_read_all_temperature();
                    label7.Text = device_ET3916_dataArraySend[0].ToString("x") + "    " + device_ET3916_dataArraySend[1].ToString("x") + "    " + device_ET3916_dataArraySend[2].ToString("x") + "    " + device_ET3916_dataArraySend[3].ToString("x") + "    " + device_ET3916_dataArraySend[4].ToString("x") + "    " + device_ET3916_dataArraySend[5].ToString("x") + "    " + device_ET3916_dataArraySend[6].ToString("x") + "    ";
                }

                private void button7_Click(object sender, EventArgs e)
                {
                    // temperature_ET3916.fun_ET3916_read_command_all_temperature();
                    label8.Text = device_ET3916_temperature[1].ToString("0.00") + "   " + device_ET3916_temperature[2].ToString("0.00");
                }

                */
        #endregion

        #region " Multimeter --- OWON  --- XDM3051 ----  "



        //--    OWON,XDM3051,2303195,V3.7.2,2
        private void btnXDM3051_ident_Click(object sender, EventArgs e)
        {
            multimeter_XDM3051.fun_XDM3051_identifaction();
            txtBox_XDM3051_ident.Text = COMport_device_ident[COMport_SELECT_MULTIMETER_XDM3051];
        }

        #endregion

        #region " Multimeter --- OWON  --- XDM1041 ----  "

        private void btnXDM1041_ident_Click(object sender, EventArgs e)
        {
            multimeter_XDM1041.fun_XDM1041_identifaction();
            txtBox_XDM1041_ident.Text = COMport_device_ident[COMport_SELECT_MULTIMETER_XDM1041];

        }


        #endregion



        #endregion

        #region "LOADS  "
        #region " Loads --- Korad  ---  KEL103 ---- DC LOAD  "
        private void btnLoad_KEL103_ident_Click(object sender, EventArgs e)
        {
            dc_load_KEL103.fun_KEL103_identifaction();
            txtBoxLoad_KEL103_ident.Text = COMport_device_ident[COMport_SELECT_LOAD_KEL103];

        }


        #endregion
        #endregion




        private void tabMultimeter_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            write_log_files.funWriteLogFile_Devices_idents();
        }

    }
}
