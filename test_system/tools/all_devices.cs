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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
        power_supply_RD6024 power_supply_RD6024 = new power_supply_RD6024();

        owon_multimeter owon_multimeter = new owon_multimeter();
        dc_load_KEL103 dc_load_KEL103 = new dc_load_KEL103();

        modbus_functions modbus_functions = new modbus_functions();
        write_log_files write_log_files = new write_log_files();

        functions functions = new functions();


        int timer_2_counter = 0;


        #region "nalaganje okna  "
        public all_devices()
        {
            InitializeComponent();
        }
        private void all_devices_Load(object sender, EventArgs e)
        {



            comboBox_XDM1041_voltage_range.Items.Add("5");
            comboBox_XDM1041_voltage_range.Items.Add("50");
            comboBox_XDM1041_voltage_range.Items.Add("500");
            comboBox_XDM1041_voltage_range.Items.Add("1000");
            comboBox_XDM1041_voltage_range.SelectedIndex = comboBox_XDM1041_voltage_range.Items.Count - 1;

            comboBox_XDM2041_voltage_range.Items.Add("0.05");
            comboBox_XDM2041_voltage_range.Items.Add("0.5");
            comboBox_XDM2041_voltage_range.Items.Add("5");
            comboBox_XDM2041_voltage_range.Items.Add("50");
            comboBox_XDM2041_voltage_range.Items.Add("500");
            comboBox_XDM2041_voltage_range.Items.Add("1000");
            comboBox_XDM2041_voltage_range.SelectedIndex = comboBox_XDM2041_voltage_range.Items.Count - 1;

            comboBox_XDM3051_voltage_range.Items.Add("0.2");
            comboBox_XDM3051_voltage_range.Items.Add("2");
            comboBox_XDM3051_voltage_range.Items.Add("20");
            comboBox_XDM3051_voltage_range.Items.Add("200");
            comboBox_XDM3051_voltage_range.Items.Add("1000");
            comboBox_XDM3051_voltage_range.SelectedIndex = comboBox_XDM3051_voltage_range.Items.Count - 1;


            comboBox_XDM3051_dc_current_range.Items.Add("0.0002");
            comboBox_XDM3051_dc_current_range.Items.Add("0.002");
            comboBox_XDM3051_dc_current_range.Items.Add("0.02");
            comboBox_XDM3051_dc_current_range.Items.Add("0.2");
            comboBox_XDM3051_dc_current_range.Items.Add("2");
            comboBox_XDM3051_dc_current_range.Items.Add("10");
            comboBox_XDM3051_dc_current_range.SelectedIndex = comboBox_XDM3051_dc_current_range.Items.Count - 1;



            comboBox_XDM2041_dc_current_range.Items.Add("0.0005");
            comboBox_XDM2041_dc_current_range.Items.Add("0.005");
            comboBox_XDM2041_dc_current_range.Items.Add("0.05");
            comboBox_XDM2041_dc_current_range.Items.Add("0.5");
            comboBox_XDM2041_dc_current_range.Items.Add("5");
            comboBox_XDM2041_dc_current_range.Items.Add("10");
            comboBox_XDM2041_dc_current_range.SelectedIndex = comboBox_XDM2041_dc_current_range.Items.Count - 1;

            comboBox_XDM1041_dc_current_range.Items.Add("0.0005");
            comboBox_XDM1041_dc_current_range.Items.Add("0.005");
            comboBox_XDM1041_dc_current_range.Items.Add("0.05");
            comboBox_XDM1041_dc_current_range.Items.Add("0.5");
            comboBox_XDM1041_dc_current_range.Items.Add("5");
            comboBox_XDM1041_dc_current_range.Items.Add("10");
            comboBox_XDM1041_dc_current_range.SelectedIndex = comboBox_XDM1041_dc_current_range.Items.Count - 1;



            labXDM3051_measure_ok.Text = "";
            labXDM2041_measure_ok.Text = "";
            labXDM1041_measure_ok.Text = "";


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
        #endregion

        #region "Timer "

        private void timer1_Tick(object sender, EventArgs e)
        {
            label18.Text = "select TAB    " + tabControl1.SelectedIndex.ToString() + "   " + tabControl1.SelectedIndex.ToString();

            label19.Text = timer_2_counter.ToString();
            //-------------------------------------------------------------------------------------------------------------------

            if (tabControl1.SelectedTab == tabControl1.TabPages["tabAllDevices"]) { timer2_all_devices.Enabled = true; }
            else timer2_all_devices.Enabled = false;


            if (device_ET3916_serial_number_show)
            {
                if (device_ET3916_serial_number.Length > 5)
                {
                    device_ET3916_serial_number_show = false;
                    txtBox_ET3916_1.Text = device_ET3916_serial_number;
                }
            }
            //-------------------------------------------------------------------------------------------------------------------
            //-- prikaaz temperature na zahtevo 
            if (complete_device_ET391_read_all_temperature)
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

            if (device_RD6006_all_device_ident)
            {
                device_RD6006_all_device_ident = false;
                txtRD6006_ident.Text = rd6006_Signature.ToString("X") + "   " + rd6006_Serial_number.ToString("X") + "   " + rd6006_Firmware_version.ToString("X");
            }
       


            if (device_RD6006_show_all_measure)
            {
                device_RD6006_show_all_measure = false;
                labRD6006_set_volt.Text = "Set Voltage      " + rd6006_setVoltage.ToString("0.00") + " V";
                labRD6006_set_curr.Text = "Set Current      " + rd6006_setCurrent.ToString("0.00") + " A";
                labRD6006_inp_volt.Text = "Input Voltage    " + rd6006_InputVoltage.ToString("0.00") + " V";
                labRD6006_out_volt.Text = "Output Voltage   " + rd6006_OutputVoltag.ToString("0.00") + " V";
                labRD6006_out_curr.Text = "Output Current   " + rd6006_OutputCurrent.ToString("0.00") + " A";
                labRD6006_out_power.Text = "Output Power     " + rd6006_OutputPower.ToString("0.00") + " W";
            }
            if (device_RD6024_show_all_measure)
            {
                device_RD6024_show_all_measure = false;
                labRD6024_set_volt.Text = "Set Voltage      " + rd6024_setVoltage.ToString("0.00") + " V";
                labRD6024_set_curr.Text = "Set Current      " + rd6024_setCurrent.ToString("0.00") + " A";
                labRD6024_inp_volt.Text = "Input Voltage    " + rd6024_InputVoltage.ToString("0.00") + " V";
                labRD6024_out_volt.Text = "Output Voltage   " + rd6024_OutputVoltag.ToString("0.00") + " V";
                labRD6024_out_curr.Text = "Output Current   " + rd6024_OutputCurrent.ToString("0.00") + " A";
                labRD6024_out_power.Text = "Output Power     " + rd6024_OutputPower.ToString("0.00") + " W";
            }

            if (device_RD6024_all_device_ident)
            {
                device_RD6024_all_device_ident = false;
                txtRD6024_ident.Text = rd6024_Signature.ToString("X") + "   " + rd6024_Serial_number.ToString("X") + "   " + rd6024_Firmware_version.ToString("X");
            }



            if (device_MPM1010B_show_data)
            {
                device_MPM1010B_show_data = false;
                labMPM1010B_voltage.Text = device_MPM1010B_voltage.ToString();
            }
        }




        private void timer2_all_devices_Tick(object sender, EventArgs e)
        {
            timer_2_counter++;

            //-------------------------------------------------------------------------------------------------------------------
            labXDM3051_read_result.Text = dev_connected[COMport_XDM3051].ToString() +"   "+ dev_meas_state[COMport_XDM3051].ToString();
            labXDM3051_status.Text = dev_range[COMport_XDM3051];
            labXDM3051_measure.Text = dev_meas[COMport_XDM3051].ToString("0.0000");
            //-------------------------------------------------------------------------------------------------------------------
            labXDM2041_status.Text = dev_range[COMport_XDM2041];
            labXDM2041_read_result.Text = dev_connected[COMport_XDM2041].ToString() + "   " + dev_meas_state[COMport_XDM2041].ToString();
            labXDM2041_measure.Text = dev_meas[COMport_XDM2041].ToString("0.0000");
            //-------------------------------------------------------------------------------------------------------------------
            labXDM1041_status.Text = dev_range[COMport_XDM1041];
            labXDM1041_read_result.Text = dev_connected[COMport_XDM1041].ToString() + "   " + dev_meas_state[COMport_XDM1041].ToString();
            labXDM1041_measure.Text = dev_meas[COMport_XDM1041].ToString("0.0000");

      
            labET3916_0.Text = dev_connected[COMport_ET3916].ToString()+ "   " + dev_meas_state[COMport_ET3916].ToString();
            labET3916_1.Text = "Temp 1    " + device_ET3916_temperature[1].ToString("0.0") + " degC";
            labET3916_2.Text = "Temp 2    " + device_ET3916_temperature[2].ToString("0.0") + " degC";
            labET3916_3.Text = "Temp 3    " + device_ET3916_temperature[3].ToString("0.0") + " degC";
            labET3916_4.Text = "Temp 4    " + device_ET3916_temperature[4].ToString("0.0") + " degC";
            labET3916_5.Text = "Temp 5    " + device_ET3916_temperature[5].ToString("0.0") + " degC";
            labET3916_6.Text = "Temp 6    " + device_ET3916_temperature[6].ToString("0.0") + " degC";
            labET3916_7.Text = "Temp 7    " + device_ET3916_temperature[7].ToString("0.0") + " degC";
            labET3916_8.Text = "Temp 8    " + device_ET3916_temperature[8].ToString("0.0") + " degC";


            labMPM1010B_0.Text = dev_connected[COMport_ET3916].ToString() +"     " + dev_meas_state[COMport_MPM_1010B].ToString();
            labMPM1010B_1.Text = "Voltage      " + device_MPM1010B_voltage.ToString("0.00") + " V";
            labMPM1010B_2.Text = "Current      " + device_MPM1010B_current.ToString("0.00") + " A";
            labMPM1010B_3.Text = "Power        " + device_MPM1010B_power.ToString("0.00") + " W";
            labMPM1010B_4.Text = "Pow. fact.   " + device_MPM1010B_power_factor.ToString("0.00") ;
            labMPM1010B_5.Text = "Frequency    " + device_MPM1010B_freguency.ToString("0.00") + " Hz";

        }
   


        #endregion
        #region " Power supply "
        #region " Power supply  - Manson  1-16V 30A   HCS - 3300"

        //=======================================================================================================================

        //-- IDENT 
        //=======================================================================================================================
        private void btnPowerSupply_1_1_Click(object sender, EventArgs e)
        {
            power_supply_hcs_3300.fun_HCS_330_identifaction();
            txtBosPowerSupply_1_1.Text = COMport_device_ident[COMport_HCS_3300];
        }

        //=======================================================================================================================
        //=======================================================================================================================
        private void btnHCS_3300_on_Click(object sender, EventArgs e)
        {
            power_supply_hcs_3300.fun_HCS_3300_on();
        }
        //=======================================================================================================================
        //=======================================================================================================================
        private void btnHCS_3300_off_Click(object sender, EventArgs e)
        {
            power_supply_hcs_3300.fun_HCS_3300_off();
        }
        //=======================================================================================================================
        //=======================================================================================================================
        private void btnHCS_3300_measure_Click(object sender, EventArgs e)
        {
            power_supply_hcs_3300.fun_HCS_330_get_measure();

            labHCS3300_voltage.Text = "Out Voltage: " + HCS_3300_out_voltage.ToString("0.00") + " V";
            labHCS3300_current.Text = "Out Current: " + HCS_3300_out_current.ToString("0.00") + " A";
            labHCS3300_status.Text = HCS_3300_out_status;
            // textBox3.Text = COMport_receive_string[COMport_SELECT_SUPPLY_HCS_3300];
            //  public static double HSC3300_out_voltage = 0;
            //public static double HSC3300_out_current = 0;
        }
        //=======================================================================================================================
        //=======================================================================================================================
        private void btnHCS_3300_get_set_value_Click(object sender, EventArgs e)
        {
            power_supply_hcs_3300.fun_HCS_3300_get_limit();
            txtCS3300_set_voltage.Text = HCS_3300_get_set_voltage.ToString();
            txtCS3300_set_current.Text = HCS_3300_get_set_current.ToString();
            //strGeneralString = "receeive  " + COMport_receive_lenght[COMport_SELECT_SUPPLY_HCS_3300].ToString() + "   <" + ">   Voltage =      " + HSC3300_get_set_voltage.ToString()+ "    " + HSC3300_get_set_current.ToString();
        }


        private void txtCS3300_set_voltage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string set_value = txtCS3300_set_voltage.Text;
                double set_value_correct = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(set_value));
                //strGeneralString = "Set Voltage: " + set_value_correct.ToString("0.00") + " V";
                power_supply_hcs_3300.fun_HCS_330_set_voltage(set_value_correct);

            }
        }
        private void txtCS3300_set_current_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string set_value = txtCS3300_set_current.Text;
                double set_value_correct = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(set_value));
                //strGeneralString = "Set Voltage: " + set_value_correct.ToString("0.00") + " V";
                power_supply_hcs_3300.fun_HCS_330_set_current(set_value_correct);
            }
        }


        #endregion


        #region " Power supply  ---- KORAD  ---  KA3305P    "

        //=======================================================================================================================
        //=======================================================================================================================
        private void btnPowerSupply_KA3305P_ident1_Click(object sender, EventArgs e)
        {
            power_supply_KA3305P.fun_KA3305P_identifaction();
            txtBosPowerSupply_KA3305P_ident.Text = COMport_device_ident[COMport_KA3305A];
        }

        private void btnKA3305P_measure_1_Click(object sender, EventArgs e)
        {
            power_supply_KA3305P.fun_KA3305P_get_voltage_current();
            labKA3305P_volt_1.Text = "Voltage: " + KA3305P_out_voltage_1.ToString("0.00") + " V";
            labKA3305P_current_1.Text = "Current: " + KA3305P_out_current_1.ToString("0.00") + " A";
        }
        private void btnKA3305P_measure_2_Click(object sender, EventArgs e)
        {
            power_supply_KA3305P.fun_KA3305P_get_voltage_current(2);
            labKA3305P_volt_2.Text = "Voltage: " + KA3305P_out_voltage_2.ToString("0.00") + " V";
            labKA3305P_current_2.Text = "Current: " + KA3305P_out_current_2.ToString("0.00") + " A";
        }


        private void btnKA3305P_get_set_1_Click(object sender, EventArgs e)
        {
            power_supply_KA3305P.fun_KA3305P_get_set_voltage_current();
            txtKA3305P_set_voltage_1.Text = KA3305P_get_set_voltage_1.ToString();
            txtKA3305P_set_current_1.Text = KA3305P_get_set_current_1.ToString();
        }

        private void btnKA3305P_get_set_2_Click(object sender, EventArgs e)
        {
            power_supply_KA3305P.fun_KA3305P_get_set_voltage_current(2);
            txtKA3305P_set_voltage_2.Text = KA3305P_get_set_voltage_2.ToString();
            txtKA3305P_set_current_2.Text = KA3305P_get_set_current_2.ToString();
        }

        //        public static double KA3305P_get_set_voltage_1;
        //      public static double KA3305P_get_set_current_1;
        //    public static double KA3305P_get_set_voltage_2;
        //  public static double KA3305P_get_set_current_2;


        private void txtKA3305P_set_voltage_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string valueSetting = txtKA3305P_set_voltage_1.Text;
                double set_value = Convert.ToDouble(valueSetting);
                power_supply_KA3305P.fun_KA3305P_set_voltage(set_value, 1);
            }
        }
        private void txtKA3305P_set_voltage_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string valueSetting = txtKA3305P_set_voltage_2.Text;
                double set_value = Convert.ToDouble(valueSetting);
                power_supply_KA3305P.fun_KA3305P_set_voltage(set_value, 2);
            }
        }

        private void txtKA3305P_set_current_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string valueSetting = txtKA3305P_set_current_1.Text;
                double set_value = Convert.ToDouble(valueSetting);
                power_supply_KA3305P.fun_KA3305P_set_current(set_value, 1);
            }

        }

        private void txtKA3305P_set_current_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string valueSetting = txtKA3305P_set_current_2.Text;
                double set_value = Convert.ToDouble(valueSetting);
                power_supply_KA3305P.fun_KA3305P_set_current(set_value, 2);
            }

        }


        private void btnKA3305P_on_1_Click(object sender, EventArgs e)
        {
            power_supply_KA3305P.fun_KA3305P_on();
        }

        private void btnKA3305P_off_1_Click(object sender, EventArgs e)
        {
            power_supply_KA3305P.fun_KA3305P_off();
        }

        private void btnKA3305P_status_Click(object sender, EventArgs e)
        {
            string strShowString = "";
            power_supply_KA3305P.fun_KA3305P_status();
            strShowString = KA3305P_status_bit0_CH1_mode + "\n\r";
            strShowString = strShowString + KA3305P_status_bit0_CH2_mode + "\n\r";
            strShowString = strShowString + KA3305P_status_bit23_tracking + "\n\r";
            strShowString = strShowString + KA3305P_status_bit4_beep + "\n\r";
            strShowString = strShowString + KA3305P_status_bit5_lock + "\n\r";
            strShowString = strShowString + KA3305P_status_bit6_on_offk + "\n\r";





            labKA3305P_status.Text = strShowString;
            labKA3305P_status_1.Text = KA3305P_status.ToString("X");


        }

        #endregion;

        #region " Power supply  ---- RD6006     ------     "

        private void btnRD6006_ident_Click(object sender, EventArgs e)
        {
            power_supply_RD6006.funRD6006_ident();
        }


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


        private void btnPowerSupply_RD6006_measure_Click(object sender, EventArgs e)
        {
            //power_supply_RD6006.funRD6006_measure();
            mainWindow.COMportSerial[COMport_RD6006].DiscardInBuffer();
            modbus_functions.funModbusRTU_send_request_read_function_3(1, 8, 10, COMport_RD6006);

            //mainWindow.COMportSerial[COMport_SELECT_SUPPLY_RD6006].DiscardInBuffer();
            //modbus_functions.funModbusRTU_send_request_read_function_3(1, 0, 20, COMport_SELECT_SUPPLY_RD6006);
        }


        #endregion
        #region " Power supply  ---- RD6024     ------     "


        private void btnRD6024_ident_Click(object sender, EventArgs e)
        {
            power_supply_RD6024.funRD6024_ident();
        }

        private void btnPowerSupply_RD6024_ON_Click(object sender, EventArgs e)
        {
            modbus_functions.funModbusRTU_send_set_single_register_function_6(1, 18, 1, COMport_RD6024);

        }

        private void btnPowerSupply_RD6024_OFF_Click(object sender, EventArgs e)
        {
            modbus_functions.funModbusRTU_send_set_single_register_function_6(1, 18, 0, COMport_RD6024);

        }

        private void btnPowerSupply_RD6024_measure_Click(object sender, EventArgs e)
        {
            mainWindow.COMportSerial[COMport_RD6024].DiscardInBuffer();
            modbus_functions.funModbusRTU_send_request_read_function_3(1, 10, 2, COMport_RD6024);
            //modbus_functions.funModbusRTU_send_request_read_function_3(1, 14, 6, COMport_RD6024);
            // mainWindow.COMportSerial[COMport_SELECT_SUPPLY_RD6024].DiscardInBuffer();
            // modbus_functions.funModbusRTU_send_request_read_function_3(1, 0, 10, COMport_SELECT_SUPPLY_RD6024);
        }

        #endregion


        #endregion

        #region "MULTIMETER "

        #region " AC POWER METRER  --- MATRIX  --- MPM-1010B ----  "

        //=======================================================================================================================
        //=======================================================================================================================
        private void btnMPM1010B_measure_Click(object sender, EventArgs e)
        {
            if (dev_connected[COMport_MPM_1010B])
            {
                device_MPM1010B_read_all_write = true;
                device_MPM1010B_read_all_read = true;
            }
        }

        #endregion
        #region " Multimeter --- East Tester --- ET916-8 ---- temperature meter "

        //=======================================================================================================================
        //=======================================================================================================================
        private void btnET3916_ident_Click(object sender, EventArgs e)
        {
            temperature_ET3916.fun_ET3916_read_serial_number();
            device_ET3916_serial_number_show = true;
        }

        private void btnET3916_measure_Click(object sender, EventArgs e)
        {
            complete_device_ET391_read_all_temperature = true;
            temperature_ET3916.fun_ET3916_read_all_temperature();

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


        //=======================================================================================================================
        //--    OWON,XDM3051,2303195,V3.7.2,2
        //=======================================================================================================================
        private void btnXDM3051_ident_Click(object sender, EventArgs e)
        {
            //if ( fun_owon_multimeter_identification(COMport_SELECT_MULTIMETER_XDM3051 , string ident_string)
            //owon_multimeter_common.fun_owon_multimeter_identification(COMport_SELECT_MULTIMETER_XDM3051, "XDM3051,2303195");
            // OK            multimeter_XDM3051.fun_XDM3051_identifaction();
            // OKtxtBox_XDM3051_ident.Text = COMport_device_ident[COMport_SELECT_MULTIMETER_XDM3051];
            funReturnCodeCOMport returnState = owon_multimeter.fun_owon_multimeter_identification(COMport_XDM3051, "XDM3051,2303195");
            if (returnState == funReturnCodeCOMport.OK) txtBox_XDM3051_ident.Text = COMport_device_ident[COMport_XDM3051];
            else txtBox_XDM3051_ident.Text = returnState.ToString();
        }

        //=======================================================================================================================
        //=======================================================================================================================
        private void btnXDM3051_measure_Click(object sender, EventArgs e)
        {
            owon_multimeter.fun_owon_measure(COMport_XDM3051);
            txtBox_XDM3051_measure.Text = dev_meas[COMport_XDM3051].ToString();
            labXDM3051_measure_ok.Text = dev_meas_state[COMport_XDM3051].ToString();
        }

        private void btnXDM3051_get_range_dc_volt_Click(object sender, EventArgs e)
        {
            var (returnState, returnValue) = owon_multimeter.fun_owon_get_range_volt_dc(COMport_XDM3051);
            device_XDM3051_range_dc_volt = Convert.ToUInt16(returnValue);
            labXDM3051_DC_range.Text = device_XDM3051_range_dc_volt.ToString();
        }

        private void btnXDM3051_set_range_dc_volt_Click(object sender, EventArgs e)
        {
            string str_voltage_range = comboBox_XDM3051_voltage_range.SelectedItem.ToString();
            string str_voltage_dc_range_correct = functions.fun_convert_string_to_current_decimal_separator(str_voltage_range);
            double voltage_range = Convert.ToDouble(str_voltage_dc_range_correct);
            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM3051, voltage_range);
        }

        private void btnXDM3051_set_range_dc_current_Click(object sender, EventArgs e)
        {
            string str_voltage_range = comboBox_XDM3051_dc_current_range.SelectedItem.ToString();
            string str_voltage_dc_range_correct = functions.fun_convert_string_to_current_decimal_separator(str_voltage_range);
            double voltage_range = Convert.ToDouble(str_voltage_dc_range_correct);
            owon_multimeter.fun_owon_set_range_current_dc(COMport_XDM3051, voltage_range);
        }

        #endregion
        #region " Multimeter --- OWON  --- XDM2041 ----  "

        //=======================================================================================================================
        /// <summary>
        ///      //--    OWON,XDM2041,24470254,V3.3.0,3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        private void btnXDM2041_ident_Click(object sender, EventArgs e)
        {
            funReturnCodeCOMport returnState = owon_multimeter.fun_owon_multimeter_identification(COMport_XDM2041, "OWON,XDM2041,24470254");
            if (returnState == funReturnCodeCOMport.OK) txtBox_XDM2041_ident.Text = COMport_device_ident[COMport_XDM2041];
            else txtBox_XDM2041_ident.Text = returnState.ToString();
        }
        //=======================================================================================================================
        //=======================================================================================================================
        private void btnXDM2041_measure_Click(object sender, EventArgs e)
        {
            owon_multimeter.fun_owon_measure(COMport_XDM2041);
            txtBox_XDM2041_measure.Text = dev_meas[COMport_XDM2041].ToString();
            labXDM2041_measure_ok.Text = dev_meas_state[COMport_XDM2041].ToString();
        }

        private void btnXDM2041_get_range_dc_volt_Click(object sender, EventArgs e)
        {
            var (returnState, returnValue) = owon_multimeter.fun_owon_get_range_volt_dc(COMport_XDM2041);
            labXDM2041_DC_range.Text = returnValue.ToString();

        }
        private void btnXDM2041_set_range_dc_volt_Click(object sender, EventArgs e)
        {
            string str_voltage_range = comboBox_XDM2041_voltage_range.SelectedItem.ToString();
            string str_voltage_dc_range_correct = functions.fun_convert_string_to_current_decimal_separator(str_voltage_range);
            double voltage_range = Convert.ToDouble(str_voltage_dc_range_correct);
            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM2041, voltage_range);
        }

        private void btnXDM2041_set_range_dc_current_Click(object sender, EventArgs e)
        {
            string str_voltage_range = comboBox_XDM2041_dc_current_range.SelectedItem.ToString();
            string str_voltage_dc_range_correct = functions.fun_convert_string_to_current_decimal_separator(str_voltage_range);
            double voltage_range = Convert.ToDouble(str_voltage_dc_range_correct);
            owon_multimeter.fun_owon_set_range_current_dc(COMport_XDM2041, voltage_range);
        }

        #endregion
        #region " Multimeter --- OWON  --- XDM1041 ----  "
        //=======================================================================================================================
        //=======================================================================================================================
        private void btnXDM1041_measure_Click(object sender, EventArgs e)
        {
            owon_multimeter.fun_owon_measure(COMport_XDM1041);
            txtBox_XDM1041_measure.Text = dev_meas[COMport_XDM1041].ToString();
            labXDM1041_measure_ok.Text = dev_meas_state[COMport_XDM1041].ToString();
        }
        //=======================================================================================================================
        //=======================================================================================================================
        private void btnXDM1041_ident_Click(object sender, EventArgs e)
        {
            if (owon_multimeter.fun_owon_multimeter_identification(COMport_XDM1041, "XDM1041,23120418") != funReturnCodeCOMport.OK)
            {
                if (owon_multimeter.fun_owon_multimeter_identification(COMport_XDM1041, "XDM1041,23120418") != funReturnCodeCOMport.OK)
                {
                    owon_multimeter.fun_owon_multimeter_identification(COMport_XDM1041, "XDM1041,23120418");
                }
            }
            txtBox_XDM1041_ident.Text = COMport_device_ident[COMport_XDM1041];
        }

        private void btnXDM1041_get_range_dc_volt_Click(object sender, EventArgs e)
        {
            var (returnState, returnValue) = owon_multimeter.fun_owon_get_range_volt_dc(COMport_XDM1041);
            labXDM1041_DC_range.Text = returnValue.ToString();
        }


        private void btnXDM1041_set_range_dc_volt_Click(object sender, EventArgs e)
        {
            string str_voltage_range = comboBox_XDM1041_voltage_range.SelectedItem.ToString();
            string str_voltage_dc_range_correct = functions.fun_convert_string_to_current_decimal_separator(str_voltage_range);
            double voltage_range = Convert.ToDouble(str_voltage_dc_range_correct);
            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM1041, voltage_range);
        }


        private void btnXDM1041_set_range_dc_current_Click(object sender, EventArgs e)
        {
            string str_voltage_range = comboBox_XDM1041_dc_current_range.SelectedItem.ToString();
            string str_voltage_dc_range_correct = functions.fun_convert_string_to_current_decimal_separator(str_voltage_range);
            double voltage_range = Convert.ToDouble(str_voltage_dc_range_correct);
            owon_multimeter.fun_owon_set_range_current_dc(COMport_XDM1041, voltage_range);

        }
        #endregion


        #endregion

        #region "LOADS  "
        #region " Loads --- Korad  ---  KEL103 ---- DC LOAD  "
        private void btnLoad_KEL103_ident_Click(object sender, EventArgs e)
        {
            if (dev_connected[COMport_MPM_1010B])
            {
                dc_load_KEL103.fun_KEL103_identifaction();
                txtBoxLoad_KEL103_ident.Text = COMport_device_ident[COMport_KEL103];
            }
        }

        private void btnKEL103_on_Click(object sender, EventArgs e)
        {
            dc_load_KEL103.fun_KEL103_on();
        }

        private void btnKEL103_off_Click(object sender, EventArgs e)
        {
            dc_load_KEL103.fun_KEL103_off();
        }

        private void btnKEL103_measure_Click(object sender, EventArgs e)
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    dc_load_KEL103.fun_KEL103_get_voltage();
                    dc_load_KEL103.fun_KEL103_get_current();
                    dc_load_KEL103.fun_KEL103_get_power();
                    //dc_load_KEL103.fun_KEL103_get_resistance();

                    labKEL103_voltaage.Text = KEL103_voltage.ToString();
                    labKEL103_current.Text = KEL103_current.ToString();
                    labKEL103_power.Text = KEL103_power.ToString();
                    //labKEL103_resistance.Text = KEL103_resistance.ToString();
                }
            }
        }

        private void btnKEL103_get_set_value_Click(object sender, EventArgs e)
        {
            dc_load_KEL103.fun_KEL103_get_set_voltage();
            dc_load_KEL103.fun_KEL103_get_set_curernt();
            dc_load_KEL103.fun_KEL103_get_set_power();
            txtKEL103_voltage.Text = KEL103_get_set_voltage.ToString();
            txtKEL103_curr.Text = KEL103_get_set_current.ToString();
            txtKEL103_power.Text = KEL103_get_set_power.ToString();
        }

        private void btnKEL103_set_set_value_Click(object sender, EventArgs e)
        {

        }


        private void radioFunction_1_CheckedChanged(object sender, EventArgs e)
        {
            dc_load_KEL103.fun_KEL103_set_function(KEL103_SET_FUN_VOLTAGE);
        }

        private void radioFunction_2_CheckedChanged(object sender, EventArgs e)
        {
            dc_load_KEL103.fun_KEL103_set_function(KEL103_SET_FUN_CURRENT);
        }

        private void radioFunction_3_CheckedChanged(object sender, EventArgs e)
        {
            dc_load_KEL103.fun_KEL103_set_function(KEL103_SET_FUN_POWER);
        }

        private void radioFunction_4_CheckedChanged(object sender, EventArgs e)
        {
            dc_load_KEL103.fun_KEL103_set_function(KEL103_SET_FUN_RESISTANCE);
        }


        //--    :CURRent 2ASet the CC voltage as 2A :CURRent?>2AThe CC current is 2A
        private void txtKEL103_curr_KeyDown(object sender, KeyEventArgs e)
        {
            //if ( e=System.ke)
            if (e.KeyCode == Keys.Enter)
            {
                string valueSetting = txtKEL103_curr.Text;
                //string valueSetting_pika = valueSetting.Replace(",", ".");
                KEL103_set_set_current = Convert.ToDouble(valueSetting);
                dc_load_KEL103.fun_KEL103_set_current(KEL103_set_set_current);
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (COMport_device_ident[COMport_XDM3051] != null) listBox1.Items.Add(COMport_device_ident[COMport_XDM3051]);
            if (COMport_device_ident[COMport_XDM2041] != null) listBox1.Items.Add(COMport_device_ident[COMport_XDM2041]);
            if (COMport_device_ident[COMport_XDM1041] != null) listBox1.Items.Add(COMport_device_ident[COMport_XDM1041]);
            if (COMport_device_ident[COMport_ET3916] != null) listBox1.Items.Add(COMport_device_ident[COMport_ET3916]);
            if (COMport_device_ident[COMport_MPM_1010B] != null) listBox1.Items.Add(COMport_device_ident[COMport_MPM_1010B]);

            if (COMport_device_ident[COMport_KA3305A] != null) listBox1.Items.Add(COMport_device_ident[COMport_KA3305A]);
            if (COMport_device_ident[COMport_RD6006] != null) listBox1.Items.Add(COMport_device_ident[COMport_RD6006]);
            if (COMport_device_ident[COMport_RD6024] != null) listBox1.Items.Add(COMport_device_ident[COMport_RD6024]);
            if (COMport_device_ident[COMport_HCS_3300] != null) listBox1.Items.Add(COMport_device_ident[COMport_HCS_3300]);

            if (COMport_device_ident[COMport_KEL103] != null) listBox1.Items.Add(COMport_device_ident[COMport_KEL103]);



        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtKEL103_curr_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_XDM1041_voltage_range_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void groupBox_multimeter_XDM_3051_Enter(object sender, EventArgs e)
        {

        }

        private void txtCS3300_set_voltage_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
