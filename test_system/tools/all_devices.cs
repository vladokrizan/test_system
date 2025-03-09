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
        multimeter_XDM2041 multimeter_XDM2041 = new multimeter_XDM2041();
        multimeter_XDM1041 multimeter_XDM1041 = new multimeter_XDM1041();

        owon_multimeter_common owon_multimeter_common = new owon_multimeter_common();
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

            radioXDM3051_dc_range_5.Checked = true;
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

            if ( complete_device_ET391_read_all_temperature )
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


            if (device_MPM1010B_show_data)
            {
                device_MPM1010B_show_data = false;
                labMPM1010B_voltage.Text = device_MPM1010B_voltage.ToString();
            }


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
            txtBosPowerSupply_1_1.Text = COMport_device_ident[COMport_SELECT_SUPPLY_HCS_3300];
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

            labHCS3300_voltage.Text = "Out Voltage: " + HSC3300_out_voltage.ToString("0.00") + " V";
            labHCS3300_current.Text = "Out Current: " + HSC3300_out_current.ToString("0.00") + " A";
            labHCS3300_status.Text = HSC3300_out_status;

            // textBox3.Text = COMport_receive_string[COMport_SELECT_SUPPLY_HCS_3300];
            //  public static double HSC3300_out_voltage = 0;
            //public static double HSC3300_out_current = 0;
        }
        //=======================================================================================================================
        //=======================================================================================================================
        private void btnHCS_3300_set_Click(object sender, EventArgs e)
        {
            HSC3300_set_set_voltage = txtCS3300_set_voltage.Text;
            HSC3300_set_set_current = txtCS3300_set_current.Text;
            power_supply_hcs_3300.fun_HCS_330_set_voltage(1);
            power_supply_hcs_3300.fun_HCS_330_set_current();
        }

        //=======================================================================================================================
        //=======================================================================================================================
        private void btnHCS_3300_get_set_value_Click(object sender, EventArgs e)
        {
            power_supply_hcs_3300.fun_HCS_3300_get_limit();
            txtCS3300_set_voltage.Text = HSC3300_get_set_voltage.ToString();
            txtCS3300_set_current.Text = HSC3300_get_set_current.ToString();

            //strGeneralString = "receeive  " + COMport_receive_lenght[COMport_SELECT_SUPPLY_HCS_3300].ToString() + "   <" + ">   Voltage =      " + HSC3300_get_set_voltage.ToString()+ "    " + HSC3300_get_set_current.ToString();



        }


        #endregion


        #region " Power supply  ---- KORAD  ---  KA3305P    "

        //=======================================================================================================================
        //=======================================================================================================================
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


        private void btnPowerSupply_RD6006_measure_Click(object sender, EventArgs e)
        {
            power_supply_RD6006.funRD6006_measure();
            //mainWindow.COMportSerial[COMport_SELECT_SUPPLY_RD6006].DiscardInBuffer();
            //modbus_functions.funModbusRTU_send_request_read_function_3(1, 0, 20, COMport_SELECT_SUPPLY_RD6006);
        }


        #endregion
        #region " Power supply  ---- RD6024     ------     "

        private void btnPowerSupply_RD6024_ON_Click(object sender, EventArgs e)
        {
            modbus_functions.funModbusRTU_send_set_single_register_function_6(1, 18, 1, COMport_SELECT_SUPPLY_RD6024);

        }

        private void btnPowerSupply_RD6024_OFF_Click(object sender, EventArgs e)
        {
            modbus_functions.funModbusRTU_send_set_single_register_function_6(1, 18, 0, COMport_SELECT_SUPPLY_RD6024);

        }

        private void btnPowerSupply_RD6024_measure_Click(object sender, EventArgs e)
        {
            mainWindow.COMportSerial[COMport_SELECT_SUPPLY_RD6024].DiscardInBuffer();
            modbus_functions.funModbusRTU_send_request_read_function_3(1, 8, 10, COMport_SELECT_SUPPLY_RD6024);


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
            if (COMport_connected[COMport_SELECT_AC_METER_MPM_1010B])
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

            //txtBox_ET3916_1.Text = device_ET3916_serial_number;

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
            multimeter_XDM3051.fun_XDM3051_identifaction();
            txtBox_XDM3051_ident.Text = COMport_device_ident[COMport_SELECT_MULTIMETER_XDM3051];
        }
        //=======================================================================================================================
        //=======================================================================================================================

        private void btnXDM3051_measure_Click(object sender, EventArgs e)
        {
            multimeter_XDM3051.fun_XDM3051_measure();
            txtBox_XDM3051_measure.Text = device_XDM3051_measure.ToString();
            labXDM3051_measure_ok.Text = device_XDM3051_measure_ok.ToString();
        }

        private void btnXDM3051_get_range_dc_volt_Click(object sender, EventArgs e)
        {
            multimeter_XDM3051.fun_XDM3051_get_range_dc_volt();
            labXDM3051_DC_range.Text = device_XDM3051_range_dc_volt.ToString();
        }


        private void btnXDM3051_set_range_dc_volt_Click(object sender, EventArgs e)
        {
            if (radioXDM3051_dc_range_1.Checked) multimeter_XDM3051.fun_XDM3051_set_range_dc_volt(0.2);
            if (radioXDM3051_dc_range_2.Checked) multimeter_XDM3051.fun_XDM3051_set_range_dc_volt(2);
            if (radioXDM3051_dc_range_3.Checked) multimeter_XDM3051.fun_XDM3051_set_range_dc_volt(20);
            if (radioXDM3051_dc_range_4.Checked) multimeter_XDM3051.fun_XDM3051_set_range_dc_volt(200);
            if (radioXDM3051_dc_range_5.Checked) multimeter_XDM3051.fun_XDM3051_set_range_dc_volt(1000);
        }



        #endregion

        #region " Multimeter --- OWON  --- XDM2041 ----  "

        //=======================================================================================================================
        //=======================================================================================================================
        private void btnXDM2041_ident_Click(object sender, EventArgs e)
        {
            multimeter_XDM2041.fun_XDM2041_identifaction();
            txtBox_XDM2041_ident.Text = COMport_device_ident[COMport_SELECT_MULTIMETER_XDM2041];
        }
        //=======================================================================================================================
        //=======================================================================================================================
        private void btnXDM2041_measure_Click(object sender, EventArgs e)
        {
            multimeter_XDM2041.fun_XDM2041_measure();
            txtBox_XDM2041_measure.Text = device_XDM2041_measure.ToString();
            labXDM2041_measure_ok.Text = device_XDM2041_measure_ok.ToString();
        }

        private void btnXDM2041_get_range_dc_volt_Click(object sender, EventArgs e)
        {
            var (returnState, returnValue) = owon_multimeter_common.fun_owon_get_range_volt_dc(COMport_SELECT_MULTIMETER_XDM2041);
            labXDM2041_DC_range.Text = returnValue.ToString();

        }

        #endregion
        #region " Multimeter --- OWON  --- XDM1041 ----  "
        //=======================================================================================================================
        //=======================================================================================================================
        private void btnXDM1041_measure_Click(object sender, EventArgs e)
        {
            multimeter_XDM1041.fun_XDM1041_measure();
            if (device_XDM1041_measure_ok == funErrorCode.OK)
            {
                txtBox_XDM1041_measure.Text = device_XDM1041_measure.ToString();
                labXDM1041_measure_ok.Text = device_XDM1041_measure_ok.ToString();
            }
            else
            {
                multimeter_XDM1041.fun_XDM1041_measure();
                txtBox_XDM1041_measure.Text = device_XDM1041_measure.ToString();
                labXDM1041_measure_ok.Text = device_XDM1041_measure_ok.ToString();
            }
        }
        //=======================================================================================================================
        //=======================================================================================================================
        private void btnXDM1041_ident_Click(object sender, EventArgs e)
        {
            multimeter_XDM1041.fun_XDM1041_identifaction();
            txtBox_XDM1041_ident.Text = COMport_device_ident[COMport_SELECT_MULTIMETER_XDM1041];
        }

        private void btnXDM1041_get_range_dc_volt_Click(object sender, EventArgs e)
        {
            var (returnState, returnValue) = owon_multimeter_common.fun_owon_get_range_volt_dc(COMport_SELECT_MULTIMETER_XDM1041);
            labXDM1041_DC_range.Text = returnValue.ToString();

        }


        #endregion







        #endregion

        #region "LOADS  "
        #region " Loads --- Korad  ---  KEL103 ---- DC LOAD  "
        private void btnLoad_KEL103_ident_Click(object sender, EventArgs e)
        {
            if (COMport_connected[COMport_SELECT_AC_METER_MPM_1010B])
            {
                dc_load_KEL103.fun_KEL103_identifaction();
                txtBoxLoad_KEL103_ident.Text = COMport_device_ident[COMport_SELECT_LOAD_KEL103];
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
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
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
            dc_load_KEL103.fun_KEL103_get_set_cureent();
            dc_load_KEL103.fun_KEL103_get_set_power();
            
            txtKEL103_voltage.Text = KEL103_get_set_voltage.ToString();
            txtKEL103_curr.Text = KEL103_get_set_current.ToString();
            txtKEL103_power.Text = KEL103_get_set_power.ToString();


            /*
                             public static double KEL103_get_set_voltage = 0;
                    public static double KEL103_get_set_current = 0;
                    public static double KEL103_get_set_power = 0;
            */

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

                string valueSetting= txtKEL103_curr.Text;
                //string valueSetting_pika = valueSetting.Replace(",", ".");
                KEL103_set_set_current = Convert.ToDouble(valueSetting);

                dc_load_KEL103.fun_KEL103_set_cureent (KEL103_set_set_current);

 
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

            // COMport_device_ident[selectSerialNumber]
            if (COMport_device_ident[COMport_SELECT_MULTIMETER_XDM3051] != null) listBox1.Items.Add(COMport_device_ident[COMport_SELECT_MULTIMETER_XDM3051]);
            if (COMport_device_ident[COMport_SELECT_MULTIMETER_XDM2041] != null) listBox1.Items.Add(COMport_device_ident[COMport_SELECT_MULTIMETER_XDM2041]);
            if (COMport_device_ident[COMport_SELECT_MULTIMETER_XDM1041] != null) listBox1.Items.Add(COMport_device_ident[COMport_SELECT_MULTIMETER_XDM1041]);
            if (COMport_device_ident[COMport_SELECT_SUPPLY_KA3305A] != null) listBox1.Items.Add(COMport_device_ident[COMport_SELECT_SUPPLY_KA3305A]);

            if (COMport_device_ident[COMport_SELECT_SUPPLY_RD6006] != null) listBox1.Items.Add(COMport_device_ident[COMport_SELECT_SUPPLY_RD6006]);
            if (COMport_device_ident[COMport_SELECT_SUPPLY_RD6024] != null) listBox1.Items.Add(COMport_device_ident[COMport_SELECT_SUPPLY_RD6024]);

            if (COMport_device_ident[COMport_SELECT_SUPPLY_HCS_3300] != null) listBox1.Items.Add(COMport_device_ident[COMport_SELECT_SUPPLY_HCS_3300]);
            if (COMport_device_ident[COMport_SELECT_LOAD_KEL103] != null) listBox1.Items.Add(COMport_device_ident[COMport_SELECT_LOAD_KEL103]);
            if (COMport_device_ident[COMport_SELECT_TEMPERATURE_ET3916] != null) listBox1.Items.Add(COMport_device_ident[COMport_SELECT_TEMPERATURE_ET3916]);
            if (COMport_device_ident[COMport_SELECT_AC_METER_MPM_1010B] != null) listBox1.Items.Add(COMport_device_ident[COMport_SELECT_AC_METER_MPM_1010B]);


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtKEL103_curr_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
