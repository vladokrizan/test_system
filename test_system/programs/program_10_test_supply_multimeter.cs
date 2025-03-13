using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static test_system.global_variable;
using static test_system.program_10;



namespace test_system
{
    public partial class program_10_test_supply_multimeter : Form
    {
        ac_meter_MPM_1010B ac_meter_MPM_1010B = new ac_meter_MPM_1010B();
        temperature_ET3916 temperature_ET3916 = new temperature_ET3916();
        power_supply_KA3305P power_supply_KA3305P = new power_supply_KA3305P();
        power_supply_hcs_3300 power_supply_hcs_3300 = new power_supply_hcs_3300();
        power_supply_RD6006 power_supply_RD6006 = new power_supply_RD6006();
 
        owon_multimeter owon_multimeter = new owon_multimeter();
        dc_load_KEL103 dc_load_KEL103 = new dc_load_KEL103();

        program_10 program_10 = new program_10();
        write_log_files write_log_files = new write_log_files();    

        public program_10_test_supply_multimeter()
        {
            InitializeComponent();
        }

        #region "window load "

        //=======================================================================================================================
        //=======================================================================================================================
        private void program_10_test_supply_multimeeter_Load(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------------------------------
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(intMainWindow_x_MDI_window, intMainWindow_y_MDI_window);
            this.ControlBox = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(intMDIwindow_x_size, intMDIwindow_y_size);
            //-------------------------------------------------------------------------------------------------------------------


            comboBox_select_program.Items.Add(program10_01);
            comboBox_select_program.Items.Add(program10_02);
            comboBox_select_program.Items.Add(program10_03);
            comboBox_select_program.Items.Add(program10_04);
            comboBox_select_program.Items.Add(program10_05);
            comboBox_select_program.Items.Add(program10_06);
            comboBox_select_program.Items.Add(program10_07);
            comboBox_select_program.Items.Add(program10_08);
            comboBox_select_program.Items.Add(program10_09);
            comboBox_select_program.Items.Add(program10_10);
            comboBox_select_program.Items.Add(program10_11);
            comboBox_select_program.Items.Add(program10_12);

            //-------------------------------------------------------------------------------------------------------------------
            //-- prikaz prve izbire v comboBoxu 
            int comboNumber = comboBox_select_program.Items.Count;
            //comboBox_select_program.SelectedIndex = comboBox_select_program.Items.Count - comboNumber;
            comboBox_select_program.SelectedIndex = 0;

            //fun_select_program_log_file_name();
            program_10.fun_select_program_log_file_name(comboBox_select_program.Text);

        }




        #endregion
        //=======================================================================================================================
        //=======================================================================================================================

        private void button1_Click(object sender, EventArgs e)
        {

            button1.Enabled = false;
            program_bool_run = true;
            program_bool_run_start = true;
            program_int_step_time_set = 5;

        }

        #region "TIMER  .. izvajanje programa  "

        double set_voltage = 1.0;


        private void timer1_Tick(object sender, EventArgs e)
        {
            labCurrentProgram.Text = program10_current_selected_program;

            if (program_bool_run)
            {
                if (program_bool_run_start) fun_program10_start();
                if (program_bool_run_stop) fun_program10_stop();
                if (++program_int_step_time_run > program_int_step_time_set) { program_int_step_time_run = 0; fun_program10_step(); }
         
            }
        }



        #endregion
        #region "program funkcije   "

        private void fun_program10_start()
        {
            program_bool_run_start = false;
            button1.Visible = false;

            //multimeter_XDM3051.fun_XDM3051_set_range_dc_volt(1000);
            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM3051, 20);
            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM2041, 50);
            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM1041, 50);
 
            //program10_select_supply = DEVICE_SELECT_SUPPLY_HCS_3300;
            //program10_load_current = program10_LOAD_CURRENT;

            //-------------------------------------------------------------------------------------------------------------------
            if (program_select_supply == DEVICE_SELECT_SUPPLY_HCS_3300)
            {
                power_supply_hcs_3300.fun_HCS_330_set_voltage(set_voltage);
                Thread.Sleep(5000);
             }
            //-------------------------------------------------------------------------------------------------------------------
            if (program10_load_current > 0)
            {
                dc_load_KEL103.fun_KEL103_set_current(program10_LOAD_CURRENT);
                dc_load_KEL103.fun_KEL103_on();
            }
            //-------------------------------------------------------------------------------------------------------------------
            temperature_ET3916.fun_ET3916_read_all_temperature();

            button1.Visible = true;
        }

        private void fun_program10_stop()
        {
            program_bool_run_stop = false;

            if (program_select_supply == DEVICE_SELECT_SUPPLY_HCS_3300)
            {
                power_supply_hcs_3300.fun_HCS_330_set_voltage(1);
            }
            if (program10_load_current > 0)
            {
                dc_load_KEL103.fun_KEL103_off();
            }
           program_bool_run = false;
            button1.Enabled = true;


        }

        private void fun_program10_step()
        {


            program_result_value.Clear();
            //-------------------------------------------------------------------------------------------------------------------
            //-- izbira napajanika  
            if (program_select_supply == DEVICE_SELECT_SUPPLY_HCS_3300)
            {
                if (!program10_set_power_supply)
                {
                    power_supply_hcs_3300.fun_HCS_330_set_voltage(set_voltage);
                    program10_set_power_supply = true;
                    program_result_value.Add("HCS-3300 SET Voltage (V) ", set_voltage.ToString("0.0"));
                    power_supply_hcs_3300.fun_HCS_330_get_measure();
                    program_result_value.Add("HCS-3300 Voltage (V) ", HCS_3300_out_voltage.ToString("0.00"));
                    program_result_value.Add("HCS-3300 Current (A) ", HCS_3300_out_current.ToString("0.00"));
                }
                else
                {
                    program_result_value.Add("HCS-3300 SET Voltage (V) ", set_voltage.ToString("0.0"));
                    power_supply_hcs_3300.fun_HCS_330_get_measure();
                    program_result_value.Add("HCS-3300 Voltage (V) ", HCS_3300_out_voltage.ToString("0.00"));
                    program_result_value.Add("HCS-3300 Current (A) ", HCS_3300_out_current.ToString("0.00"));
                    program10_set_power_supply = false;
                }
            }
            //-------------------------------------------------------------------------------------------------------------------
            //-- nastavitev merilnih območij na multimetrih 



            //if (radioXDM1041_dc_range_1.Checked) owon_multimeter_common.fun_owon_set_range_volt_dc(COMport_SELECT_MULTIMETER_XDM1041, 5);
            //if (radioXDM1041_dc_range_2.Checked) owon_multimeter_common.fun_owon_set_range_volt_dc(COMport_SELECT_MULTIMETER_XDM1041, 50);
            //if (radioXDM1041_dc_range_3.Checked) owon_multimeter_common.fun_owon_set_range_volt_dc(COMport_SELECT_MULTIMETER_XDM1041, 500);
            //if (radioXDM2041_dc_range_2.Checked) owon_multimeter_common.fun_owon_set_range_volt_dc(COMport_SELECT_MULTIMETER_XDM2041, 0.5);
            //if (radioXDM2041_dc_range_3.Checked) owon_multimeter_common.fun_owon_set_range_volt_dc(COMport_SELECT_MULTIMETER_XDM2041, 5);
            //if (radioXDM2041_dc_range_4.Checked) owon_multimeter_common.fun_owon_set_range_volt_dc(COMport_SELECT_MULTIMETER_XDM2041, 50);
            //if (radioXDM2041_dc_range_5.Checked) owon_multimeter_common.fun_owon_set_range_volt_dc(COMport_SELECT_MULTIMETER_XDM2041, 500);

            //-------------------------------------------------------------------------------------------------------------------
            //multimeter_XDM3051.fun_XDM3051_measure();
            owon_multimeter.fun_owon_measure(COMport_XDM3051);
            //txtBox_XDM3051_measure.Text = device_measure[COMport_SELECT_MULTIMETER_XDM3051].ToString();
            //labXDM3051_measure_ok.Text = device_measure_state[COMport_SELECT_MULTIMETER_XDM3051].ToString();
            if (dev_meas_state[COMport_XDM3051] == funReturnCodeCOMport.OK) program_result_value.Add("Multimeter XDM3051 (V) ", dev_meas[COMport_XDM3051].ToString("0.000"));
            else
            {
                //multimeter_XDM3051.fun_XDM3051_measure();
                //if (device_XDM3051_measure_ok == funReturnCodeCOMport.OK) program10_value.Add("Multimeter XDM3051 (V) ", device_XDM3051_measure.ToString("0.000"));
                //else program10_value.Add("Multimeter XDM3051 (V) ", device_XDM3051_measure_ok.ToString());
            }
            //-------------------------------------------------------------------------------------------------------------------
            //multimeter_XDM2041.fun_XDM2041_measure();
            //owon_multimeter.fun_owon_multimeter_identification(COMport_SELECT_MULTIMETER_XDM2041, "XDM2041,24470254");
            owon_multimeter.fun_owon_measure(COMport_XDM2041);
            if (dev_meas_state[COMport_XDM2041] == funReturnCodeCOMport.OK) program_result_value.Add("Multimeter XDM2041 (V) ", dev_meas[COMport_XDM2041].ToString());
            else          {
               // multimeter_XDM2041.fun_XDM2041_measure();
                //if (device_XDM2041_measure_ok == funReturnCodeCOMport.OK) program10_value.Add("Multimeter XDM2041 (V) ", device_XDM2041_measure.ToString());
                //else program10_value.Add("Multimeter XDM2041 (V) ", device_XDM2041_measure_ok.ToString());
            }
            //-------------------------------------------------------------------------------------------------------------------
            //multimeter_XDM1041.fun_XDM1041_measure();
            owon_multimeter.fun_owon_measure(COMport_XDM1041);

            if (dev_meas_state[COMport_XDM1041] == funReturnCodeCOMport.OK) program_result_value.Add("Multimeter XDM1041 (V) ", dev_meas[COMport_XDM1041].ToString());
            else
            {
                //multimeter_XDM1041.fun_XDM1041_measure();
                //if (device_XDM1041_measure_ok == funReturnCodeCOMport.OK) program10_value.Add("Multimeter XDM1041 (V) ", device_XDM1041_measure.ToString());
                //else program10_value.Add("Multimeter XDM1041 (V) ", device_XDM1041_measure_ok.ToString());
            }
            //-------------------------------------------------------------------------------------------------------------------
            if (program10_load_current > 0)
            {
                dc_load_KEL103.fun_KEL103_get_voltage();
                dc_load_KEL103.fun_KEL103_get_current();
                dc_load_KEL103.fun_KEL103_get_power();
                program_result_value.Add("DC LOAD KEL103 Voltage (V) ", KEL103_voltage.ToString());
                program_result_value.Add("DC LOAD KEL103 Current (V) ", KEL103_current.ToString());
                program_result_value.Add("DC LOAD KEL103 Power (V) ", KEL103_power.ToString());
            }
            //-------------------------------------------------------------------------------------------------------------------
            program_result_value.Add("ET3916: temperature 1 (degC) ", device_ET3916_temperature[1].ToString());
            program_result_value.Add("ET3916: temperature 2 (degC) ", device_ET3916_temperature[2].ToString());
            temperature_ET3916.fun_ET3916_read_all_temperature();
            //-------------------------------------------------------------------------------------------------------------------
            write_log_files.funWriteLogFile_program10();
            //-------------------------------------------------------------------------------------------------------------------
            if (!program10_set_power_supply)
            {
                set_voltage = set_voltage + 0.1;
            }

            //-------------------------------------------------------------------------------------------------------------------
            if (program_select_supply == DEVICE_SELECT_SUPPLY_HCS_3300)
            {
                if (set_voltage > 16) { program_bool_run_stop = true; }
            }

        }




        #endregion
        #region "izbira programa  "

        //=======================================================================================================================
        //=======================================================================================================================
               private void comboBox_select_program_SelectedIndexChanged(object sender, EventArgs e)
        {
            program_10.fun_select_program_log_file_name(comboBox_select_program.Text);
        }
                private void comboBox_select_program_Click(object sender, EventArgs e)
        {
                    }
        #endregion


    }
}
