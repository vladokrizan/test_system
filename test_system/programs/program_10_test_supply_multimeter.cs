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
        multimeter_XDM3051 multimeter_XDM3051 = new multimeter_XDM3051();
        multimeter_XDM2041 multimeter_XDM2041 = new multimeter_XDM2041();
        multimeter_XDM1041 multimeter_XDM1041 = new multimeter_XDM1041();

        owon_multimeter_common owon_multimeter_common = new owon_multimeter_common();
        dc_load_KEL103 dc_load_KEL103 = new dc_load_KEL103();



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

            //-------------------------------------------------------------------------------------------------------------------
            //-- prikaz prve izbire v comboBoxu 
            int comboNumber = comboBox_select_program.Items.Count;
            //comboBox_select_program.SelectedIndex = comboBox_select_program.Items.Count - comboNumber;
            comboBox_select_program.SelectedIndex = 0;

            fun_set_log_file_name();

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

            multimeter_XDM3051.fun_XDM3051_set_range_dc_volt(20);

            power_supply_hcs_3300.fun_HCS_330_set_voltage(set_voltage);
            Thread.Sleep(5000);

            dc_load_KEL103.fun_KEL103_set_cureent(1);
            dc_load_KEL103.fun_KEL103_on();

            temperature_ET3916.fun_ET3916_read_all_temperature();



        }
        private void fun_program10_stop()
        {
            program_bool_run_stop = false;
         
            power_supply_hcs_3300.fun_HCS_330_set_voltage(1);
            dc_load_KEL103.fun_KEL103_off();

            program_bool_run = false;

            button1.Enabled = true;


        }

        private void fun_program10_step()
        {

            power_supply_hcs_3300.fun_HCS_330_set_voltage(set_voltage);

            program10_value.Clear();
            power_supply_hcs_3300.fun_HCS_330_get_measure();
            program10_value.Add("HCS-3300 Voltage (V) ", HSC3300_out_voltage.ToString("0.00"));
            program10_value.Add("HCS-3300 Current (A) ", HSC3300_out_current.ToString("0.00"));

            multimeter_XDM3051.fun_XDM3051_measure();
            if (device_XDM3051_measure_ok == funReturnCodeCOMport.OK) program10_value.Add("Multimeter XDM3051 (V) ", device_XDM3051_measure.ToString("0.000"));
            else
            {
                multimeter_XDM3051.fun_XDM3051_measure();
                if (device_XDM3051_measure_ok == funReturnCodeCOMport.OK) program10_value.Add("Multimeter XDM3051 (V) ", device_XDM3051_measure.ToString("0.000"));
            }
            multimeter_XDM2041.fun_XDM2041_measure();
            if (device_XDM2041_measure_ok == funReturnCodeCOMport.OK) program10_value.Add("Multimeter XDM2041 (V) ", device_XDM2041_measure.ToString());
            multimeter_XDM1041.fun_XDM1041_measure();
            if (device_XDM1041_measure_ok == funReturnCodeCOMport.OK) program10_value.Add("Multimeter XDM1041 (V) ", device_XDM1041_measure.ToString());

            dc_load_KEL103.fun_KEL103_get_voltage();
            dc_load_KEL103.fun_KEL103_get_current();
            dc_load_KEL103.fun_KEL103_get_power();
            program10_value.Add("DC LOAD KEL103 Voltage (V) ", KEL103_voltage.ToString());
            program10_value.Add("DC LOAD KEL103 Current (V) ", KEL103_current.ToString());
            program10_value.Add("DC LOAD KEL103 Power (V) ", KEL103_power.ToString());

            program10_value.Add("ET3916: temperature 1 (degC) ", device_ET3916_temperature[1].ToString());
            program10_value.Add("ET3916: temperature 2 (degC) ", device_ET3916_temperature[2].ToString());

            temperature_ET3916.fun_ET3916_read_all_temperature();

            funWriteLogFile_program10();
            set_voltage = set_voltage + 0.1;

            if (set_voltage > 16 )      {         program_bool_run_stop = true;           }


        }




        #endregion
        #region "izbira programa  "

        //=======================================================================================================================
        //=======================================================================================================================

        private void comboBox_select_program_SelectedIndexChanged(object sender, EventArgs e)
        {
            fun_set_log_file_name();
        }

        private void comboBox_select_program_Click(object sender, EventArgs e)
        {

        }
        #endregion


        #region "zapis v log datoteko "

        //=======================================================================================================================
        //=======================================================================================================================
        private void fun_set_log_file_name()
        {
            program10_current_selected_program = comboBox_select_program.Text;
            string[] comboBoxParts = program10_current_selected_program.Split(':');
            strLogFiles_program10 = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_10_" + comboBoxParts[0] + "_delay_" + program10_delay_after_set_supply.ToString() + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";

        }


        //=======================================================================================================================
        //=======================================================================================================================
        public void funWriteLogFile_program10()
        {
            string fileDataLine = "";
            try
            {
                //------   if file exist then don't write anything 
                if (!File.Exists(strLogFiles_program10))
                {
                    using (StreamWriter sw = File.AppendText(strLogFiles_program10))
                    {
                        fileDataLine = "Date" + strExcelSeparator;
                        fileDataLine = fileDataLine + "Time" + strExcelSeparator;
                        foreach (KeyValuePair<string, string> diagnosisNameLocal in program10_value)
                            fileDataLine = fileDataLine + diagnosisNameLocal.Key + strExcelSeparator;
                        sw.WriteLine(fileDataLine);
                    }
                }
                using (StreamWriter sw = File.AppendText(strLogFiles_program10))
                {
                    fileDataLine = DateTime.Now.ToString("dd.MM.yyyy") + strExcelSeparator;
                    fileDataLine = fileDataLine + DateTime.Now.ToString("HH:mm:ss") + strExcelSeparator;
                    foreach (KeyValuePair<string, string> diagnosisValueLocal in program10_value)
                        fileDataLine = fileDataLine + diagnosisValueLocal.Value + strExcelSeparator;
                    sw.WriteLine(fileDataLine);
                }
            }
            catch (Exception ex) { }
        }





        #endregion


    }
}
