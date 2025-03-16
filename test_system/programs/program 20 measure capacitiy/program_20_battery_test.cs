using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static test_system.global_variable;
using static test_system.program_20;

namespace test_system
{
    public partial class program_20_battery_test : Form
    {


        //     ac_meter_MPM_1010B ac_meter_MPM_1010B = new ac_meter_MPM_1010B();
        //   temperature_ET3916 temperature_ET3916 = new temperature_ET3916();
        // power_supply_KA3305P power_supply_KA3305P = new power_supply_KA3305P();
        // power_supply_hcs_3300 power_supply_hcs_3300 = new power_supply_hcs_3300();

        // owon_multimeter owon_multimeter = new owon_multimeter();
        // dc_load_KEL103 dc_load_KEL103 = new dc_load_KEL103();
        // write_log_files write_log_files = new write_log_files();

        // program_common program_common = new program_common();
        // program_20 program_20 = new program_20();

        program_20_batery_pack program_20_batery_pack = new program_20_batery_pack();

        #region "window load"

        //=========================================================================================================
        //=========================================================================================================
        public program_20_battery_test()
        {
            InitializeComponent();
        }
        //=========================================================================================================
        //=========================================================================================================

        private void program_20_battery_test_Load(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------------------------------
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(intMainWindow_x_MDI_window, intMainWindow_y_MDI_window);
            this.ControlBox = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(intMDIwindow_x_size, intMDIwindow_y_size);
            //-------------------------------------------------------------------------------------------------------------------

            program20_name_current = program20_01;

            fun_select_program_log_file_name(program20_name_current);

            labResult_01.Text = "";
            labResult_02.Text = "";
            labResult_03.Text = "";

            radioButton_discharge.Checked = true;



        }

        #endregion
        #region "SELECT TEST --- izbira programa "



        public void fun_select_program_log_file_name(string select_program)
        {
            program_select_current = 0;

            //--    public const string program20_01 = "USB battery pack";
            if (select_program.Equals(program20_01, StringComparison.Ordinal))
            {
                program_select_current = program20_USB_PACK;
            }

            //-------------------------------------------------------------------------------------------------------------------   
            //-- ime log datoteke   
            //string[] comboBoxParts = program10_current_selected_program.Split(':');
            //if (radioButton_charge.Checked) strLogFiles_program = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_20_" + select_program + "_charge_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
            //if (radioButton_discharge.Checked) strLogFiles_program = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_20_" + select_program + "_discharge_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
        }



        #endregion
        #region "TIMER -- časovno izvajanje programa "
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (blnChangeWindow_program_20_USB_battery_pack_labCurrentState)
            {
                blnChangeWindow_program_20_USB_battery_pack_labCurrentState = false;
                labCurrentState.Text = USB_battery_pack_labCurrentState;
            }
            if (blnChangeWindow_program_20_USB_battery_pack_measure_label)
            {
                blnChangeWindow_program_20_USB_battery_pack_measure_label = false;
                labResult_01.Text = USB_battery_pack_measure_label_1;
                labResult_02.Text = USB_battery_pack_measure_label_2;
                labResult_03.Text = USB_battery_pack_measure_label_3;
            }


            if (program_select_current == program20_USB_PACK) program_20_batery_pack.fun_program20_01_usb_pack();

        }

        #endregion


        // public static bool program20_01_charge = false;
        // public static bool program20_01_discharge = false;


        private void button1_Click(object sender, EventArgs e)
        {
            program20_01_charge = false;
            program20_01_discharge = false;
            if (radioButton_charge.Checked) { blnCharge_start = true; program20_01_charge = true; }
            if (radioButton_discharge.Checked) { blnDischarge_start = true; program20_01_discharge = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (radioButton_charge.Checked) blnCharge_run_stop = true;
            if (radioButton_discharge.Checked) blnDischarge_run_stop = true;
        }





    }
}




/*
 * 
 * 
 * 
 *       public static double floatDuration_part_program_run;
public static double floatDuration_part_program_complete;

        endTime = DateTime.Now;
duration = endTime - startTime;
floatDuration = duration.Seconds + (float)(duration.Milliseconds) / 1000;

 * 
       public static DateTime startTime_part_program;
public static DateTime endTime_part_program;
public static TimeSpan duration_part_program;
public static double floatDuration_part_program;
public static string strDuration_part_program;



   public static DateTime startTime_complete_program;
public static DateTime endTime_complete_program;
public static TimeSpan duration_complete_program;
public static double floatDuration_complete_program;
public static string strDuration_complete_program;


 * 
public static bool blnDischarge_start_wait = false;
public static int intDischarge_start_wait_time = 0;
//--     cas preden začne z praznjenjem
public static int intDischarge_start_wait_time_set = 0;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static measure_system.global_variable;
using static measure_system.SCPI_variable;
using static measure_system.device_variable;
using static measure_system.modbus_variable;
using System.IO;

namespace measure_system
{
    public partial class LiIon_cell : Form
    {

        #region "variable  "

        //------------------------------------------------------------------------------------------
        //--charge -- cutoff current ( A )  -- konec charge  
        double chargeOff_cuttOFF_current = 0.1;
        //------------------------------------------------------------------------------------------
        //-- discharge cutoff voltage -- konec discharge   2,5V
        double dischargeOff_cuttOFF_voltage = 2.5;
        //------------------------------------------------------------------------------------------
        //-- RELAX 1 čas ( sekunde )
        //UInt32 relax_1_time = 2 * 60 * 60;
        UInt32 relax_1_time = 1 * 30 * 60;
        //------------------------------------------------------------------------------------------
        //-- RELAX 2 čas ( sekunde )
        UInt32 relax_2_time = 1 * 30 * 60;

        //------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------
        //-- charge / discharge 
        //------------------------------------------------------------------------------------------
        bool blnCharge = false;
        bool blnCharge_supply_on = false;
        //------------------------------------------------------------------------------------------
        bool blnDischarge = false;
        //------------------------------------------------------------------------------------------
        //-- TRUE, ko je breme vklopljeno 
        bool load_on = false;



        //------------------------------------------------------------------------------------------
        //-- števec pogojev za izklop usmernika ( tok pakde pod CUT OFF  )
        byte byteChargeOff_counter = 0;

        //------------------------------------------------------------------------------------------
        //-- števec pogojev za izklop bremena ( napetost manjša kot 2,5V )
        byte byteLoadOff_counter = 0;

        //-----------------------------------------------------------------------------------------------------
        UInt32 test_all_time;
        int cycle_time_1;
        int cycle_time_2;
        int timer_time;
        //-----------------------------------------------------------------------------------------------------
        byte timer_new_second;
        byte timer_old_second;
        //-----------------------------------------------------------------------------------------------------
        DateTime loc_run_startTime;
        DateTime loc_run_endTime;
        TimeSpan loc_run_duration;
        string loc_run_duration_h_min_sec;
        UInt32 loc_run_duration_seconds;
        //-----------------------------------------------------------------------------------------------------
        //-- cas relaxa po koncu praznjenja 
        bool blnRelax2_run = false;
        UInt32 loc_run_duration_seconds_relax_2;


        //-----------------------------------------------------------------------------------------------------
        //-- ime datoteke z rezultati 
        string strFileName_gauge_5sec;
        string strFileName_gauge_1min;
        //-----------------------------------------------------------------------------------------------------
        bool measureTemperature_first = true;
        //-----------------------------------------------------------------------------------------------------
        //--- trenutna temperatura 
        double temperature_now;
        double temperature_sum;
        UInt16 average_number = 20;
        double average_value;

        //double temperature_last;
        //double temperature_change = 0.2;
        //-----------------------------------------------------------------------------------------------------
        double double_value;
        //-----------------------------------------------------------------------------------------------------
        double charge_discharge_current;
        //-----------------------------------------------------------------------------------------------------
        multimeter_XDM1041 multimeter_XDM1041 = new multimeter_XDM1041();
        multimeter_XDM3051 multimeter_XDM3051 = new multimeter_XDM3051();
        DCload_ET5410A DCload_ET5410A = new DCload_ET5410A();
        power_supply_SPE6103 power_supply_SPE6103 = new power_supply_SPE6103();
        //-----------------------------------------------------------------------------------------------------
        #endregion
        #region "window load "
        public LiIon_cell()
        {
            InitializeComponent();
        }
        //=============================================================================================================
        /// <summary>
        /// zagon okna 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=============================================================================================================
        private void LiIon_cell_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(intMainWindow_x_MDI_main_window, intMainWindow_y_MDI_window);
            this.ControlBox = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.None;
            //-----------------------------------------------------------------------------------------------------
            loc_run_startTime = DateTime.Now;
            cycle_time_1 = 3;
            cycle_time_2 = 58;
            //-----------------------------------------------------------------------------------------------------
            floatBatteryCurve_AmperSecond = 0;
            floatBatteryCurve_AmperHour = 0;
            floatBatteryCurve_WSecond = 0;
            floatBatteryCurve_WHour = 0;
            //-----------------------------------------------------------------------------------------------------
            strFileName_gauge_5sec = setting_strFilePath_measure + "\\" + "INR21700M58_gauge_5sec_" + DateTime.Now.ToString("yyyy_MM_dd___HH_mm_ss") + ".csv";
            strFileName_gauge_1min = setting_strFilePath_measure + "\\" + "INR21700M58_gauge_1min_" + DateTime.Now.ToString("yyyy_MM_dd___HH_mm_ss") + ".csv";


            blnCharge = true;
            //load_on = true;
            //blnDischarge = true;
            //load_on = true;

            if (blnCharge) labMode_1.Text = "CHARGE MODE ";
            if (blnDischarge) labMode_1.Text = "DISCHARGE MODE ";



        }
        #endregion
        #region " Timer "
        //=============================================================================================================
        /// <summary>
        ///     timer -- zgodi se vsakih 100 milisekund 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=============================================================================================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_time++;
            labMainWindow_01.Text = " timer  Cycle time : " + timer_time.ToString();
            //-----------------------------------------------------------------------------------------------------
            //-- izvajanje vsako sekundo             
            timer_new_second = (byte)(DateTime.Now.Second);
            //if (timer_new_second != timer_old_second)
            if (10 == 10)
            {
                timer_old_second = timer_new_second;
                loc_run_endTime = DateTime.Now;
                loc_run_duration = loc_run_endTime - loc_run_startTime;
                loc_run_duration_h_min_sec = loc_run_duration.Hours.ToString() + ":" + loc_run_duration.Minutes.ToString() + ":" + loc_run_duration.Seconds.ToString();
                loc_run_duration_seconds = (UInt32)(loc_run_duration.Seconds + loc_run_duration.Minutes * 60 + loc_run_duration.Hours * 3600 + loc_run_duration.Days * 3600 * 24);

                //-----------------------------------------------------------------------------------------------------
                //-- relax 2 run time 
                if (blnDischarge)
                {
                    if (blnRelax2_run) loc_run_duration_seconds_relax_2++;
                    //-----------------------------------------------------------------------------------------------------
                    //-- 5 ur po koncu praznjenja se aplikacija konca  
                    if (loc_run_duration_seconds_relax_2 > (UInt32)relax_2_time) { this.Close(); }
                }
                //-----------------------------------------------------------------------------------------------------
                if (multimeter_XDM3051_active) multimeter_XDM3051.fun_multimeter_XDM3051_measure();
                if (multimeter_XDM1041_1_active) multimeter_XDM1041.fun_scpi_multimeter_XDM1041_measure(1);
                charge_discharge_current = Multimeter_XDM1041_measureValue[1];
                //-----------------------------------------------------------------------------------------------------
                //-- meritev temperature 
                //--    temperatura se vzame, ce se ne razlikuje za več kot 0.2 stopinje od prejsnje temperature
                if (multimeter_XDM1041_2_active) multimeter_XDM1041.fun_scpi_multimeter_XDM1041_measure(2);
                double_value = Multimeter_XDM1041_measureValue[2];

                if (measureTemperature_first)
                {
                    measureTemperature_first = false;
                    temperature_now = double_value;
                    temperature_sum = double_value * average_number;
                }
                else
                {
                    average_value = temperature_sum / average_number;
                    temperature_sum = temperature_sum - average_value;
                    temperature_sum = temperature_sum + double_value;
                    temperature_now = Math.Round(temperature_sum / average_number, 1);
                }

                //UInt16 average_number = 100;
                //double average_value;



                //-----------------------------------------------------------------------------------------------------------
                //-- meritev bremena 
                if (load_ET5410A_active) DCload_ET5410A.funLoadET5410A_measure_all();
                //-----------------------------------------------------------------------------------------------------------
                if (supply_SPE6103_active) power_supply_SPE6103.fun_supply_SPE6103_measure_value();
                //-----------------------------------------------------------------------------------------------------------
                //-- ce je napetost večja od 1V je usmernik vklopljen 
                if (powerSupply_voltage[1] > 1) blnCharge_supply_on = true;


                //-----------------------------------------------------------------------------------------------------------
                //-- CHARGE MODE             
                //-----------------------------------------------------------------------------------------------------------
                //--   izklop usmernika, ko tok pade pod nastavljeno vrednost 

                if (blnCharge)
                {
                    if (blnCharge_supply_on)
                    {
                        if (charge_discharge_current < chargeOff_cuttOFF_current)
                        {
                            byteChargeOff_counter++;

                            if (byteChargeOff_counter > 10)
                            {
                                labMode_1.Text = "CHARGE FINISH ";
                                blnCharge_supply_on = false;
                                power_supply_SPE6103.fun_powerSupply_SPE6103_off();


                                strFileName_gauge_5sec = setting_strFilePath_measure + "\\" + "INR21700M58_gauge_5sec_" + DateTime.Now.ToString("yyyy_MM_dd___HH_mm_ss") + ".csv";
                                strFileName_gauge_1min = setting_strFilePath_measure + "\\" + "INR21700M58_gauge_1min_" + DateTime.Now.ToString("yyyy_MM_dd___HH_mm_ss") + ".csv";

                                blnCharge = false;
                                blnDischarge = true;
                                if (blnDischarge) labMode_1.Text = "DISCHARGE MODE ";
                                //loc_run_startTime = DateTime.Now;

                                floatBatteryCurve_AmperSecond = 0;
                                floatBatteryCurve_WSecond = 0;
                                loc_run_duration_seconds = 0;
                                cycle_time_1 = 2;
                                cycle_time_2 = 57;


                            }
                        }
                        else
                        {
                            byteChargeOff_counter = 0;
                        }
                    }
                    // byte byteChargeOff_counter = 0;
                    // double chargeOff_cuttOFF_current = 0.5;  //-- 500 mA 
                }
                //-----------------------------------------------------------------------------------------------------------
                //--    DISCHARGE MODE 
                //-----------------------------------------------------------------------------------------------------------
                if (blnDischarge)
                {
                    //-----------------------------------------------------------------------------------------------------
                    //--- vklop bremena po koncu RELAX 1
                    if (!load_on)
                    {
                        //------------------------------------------------------------------------------------------------
                        //-- po dveh urah se breme vklopi 
                        if (loc_run_duration_seconds > (UInt32)relax_1_time)
                        {
                            load_on = true;
                            DCload_ET5410A.funLoadET5410A_ON();
                        }
                    }
                    //-----------------------------------------------------------------------------------------------------
                    //-- ko pade napetost pod 2,5V se breme izklopi 
                    //-- informacije o bremenu ne osveži, da ne bi vklopil nazaj breme 
                    else
                    {
                        if (measureValue_multimeter_XDM3051 < dischargeOff_cuttOFF_voltage)
                        {
                            byteLoadOff_counter++;
                            //load_on = true;
                            if (byteLoadOff_counter > 10) { DCload_ET5410A.funLoadET5410A_OFF(); blnRelax2_run = true; }
                        }
                        else { byteLoadOff_counter = 0; }
                    }
                }

                //---------------------------------------------------------------------------------------------------------
                //-- izračun kapacitete 
                double tmpLocalDoubleValue;
                //-------------------------------------------------------------------------------------
                //-- izracun kapacitete vsako sekundo 
                floatBatteryCurve_AmperSecond = floatBatteryCurve_AmperSecond + Math.Abs(charge_discharge_current);
                floatBatteryCurve_AmperHour = floatBatteryCurve_AmperSecond / 3600;
                tmpLocalDoubleValue = measureValue_multimeter_XDM3051 * Math.Abs(charge_discharge_current);
                floatBatteryCurve_WSecond = floatBatteryCurve_WSecond + tmpLocalDoubleValue;
                floatBatteryCurve_WHour = floatBatteryCurve_WSecond / 3600;
                //---------------------------------------------------------------------------------------------------------
                //-- datoteka za TI ( gauge )
                //-- snema se vsakih 5 sekund in 1 minute 
                if (++cycle_time_1 > 4) { cycle_time_1 = 0; funWriteFile_INR21700M58_gauge(strFileName_gauge_5sec); }
                if (++cycle_time_2 > 59) { cycle_time_2 = 0; funWriteFile_INR21700M58_gauge(strFileName_gauge_1min); }
                //---------------------------------------------------------------------------------------------------------
                //-- zapis datoteke z vsemi merilnimi podatki 
                funWriteFile_INR21700M58_all();

                //-----------------------------------------------------------------------------------------------------
                labMainWindow_02.Text = "Run time : " + loc_run_duration_seconds.ToString() + " sec     " + loc_run_duration_h_min_sec + "      Relax  2 Time: " + loc_run_duration_seconds_relax_2.ToString();
                labMainWindow_03.Text = measureValue_multimeter_XDM3051.ToString("0.0000000") + " V";
                labMainWindow_04.Text = charge_discharge_current.ToString("0.0000") + " A";
                labMainWindow_05.Text = temperature_now.ToString("0.0") + " °C";
                //-----------------------------------------------------------------------------------------------------
                labMainWindow_06.Text = "Load   " + load_OutputVoltage[constLOAD_ET5410A].ToString() + " V     " + load_OutputCurrent[constLOAD_ET5410A].ToString() + " A     " + loads_OutputPower[constLOAD_ET5410A].ToString() + " W     " + loads_OutputResistance[constLOAD_ET5410A].ToString() + " Ohm";
                labMainWindow_07.Text = "Power supply  " + powerSupply_voltage[1].ToString() + " V    " + powerSupply_current[1].ToString() + " A     " + powerSupply_power[1].ToString() + " W";
                //-----------------------------------------------------------------------------------------------------
                labMainWindow_08.Text = "Capacity: " + floatBatteryCurve_AmperSecond.ToString("0.0") + " Asec   " + floatBatteryCurve_AmperHour.ToString("0.00") + " Ah      " + floatBatteryCurve_WSecond.ToString("0.0") + " Wsec   " + floatBatteryCurve_WHour.ToString("0.00") + " Wh";
                //-----------------------------------------------------------------------------------------------------
                labMainWindow_09.Text = "Charge OFF counter " + byteChargeOff_counter.ToString() + "     Discharge OFF counter " + byteLoadOff_counter.ToString();
                //-----------------------------------------------------------------------------------------------------
                //labMainWindow_10.Text = "Temperature  " + temperature_now.ToString() + "    " + double_value.ToString() + "    " + temperature_last.ToString();
                labMainWindow_10.Text = "Temperature  " + temperature_sum.ToString("0.0") + "    " + double_value.ToString("0.0") + "    " + temperature_now.ToString();

            }//-- nova sekunda  ----  if (timer_new_second != timer_old_second)
        }

        #endregion
        #region "Write to file "
        //=============================================================================================================
        /// <summary>
        /// zapis podatkov vsakih 5 sekund 
        /// </summary>
        /// <returns></returns>
        //=============================================================================================================
        private funErrorCode funWriteFile_INR21700M58_gauge(string filename)
        {
            string fileDataLine = "";
            try
            {
                //-----------------------------------------------------------------------------
                //-- preveri se, ce datoteka se ne obstaja, da se zapise naslovna vrstica 
                if (!File.Exists(filename))
                {
                    using (StreamWriter sw = File.AppendText(filename))
                    {
                        fileDataLine = "Time(sec) ";
                        fileDataLine = fileDataLine + "Voltage(mV) ";
                        fileDataLine = fileDataLine + "Current(mA) ";
                        fileDataLine = fileDataLine + "Temperature(degC) ";
                        //---------------------------------------------------------------------------------------------
                        sw.WriteLine(fileDataLine);
                    }
                }
                //-----------------------------------------------------------------------------------------------------
                //-- zapis merilnih podatkov 
                using (StreamWriter sw = File.AppendText(filename))
                {
                    fileDataLine = loc_run_duration_seconds.ToString() + " ";
                    fileDataLine = fileDataLine + (measureValue_multimeter_XDM3051 * 1000).ToString("0.0") + " ";
                    fileDataLine = fileDataLine + (charge_discharge_current * 1000).ToString("0.0") + " ";
                    fileDataLine = fileDataLine + temperature_now.ToString("0.0") + " ";
                    //-----------------------------------------------------------------------------
                    sw.WriteLine(fileDataLine);
                }
            }
            catch (Exception ex)
            {
                strFunctionErrorString = ex.ToString();
            }
            return (funErrorCode.OK);
        }
        //=============================================================================================================
        /// <summary>
        /// datoteka z vsemi podatki
        /// zapise se vsako sekundo 
        /// </summary>
        /// <returns></returns>
        //=============================================================================================================
        private funErrorCode funWriteFile_INR21700M58_all()
        {
            string fileDataLine = "";
            try
            {
                //-----------------------------------------------------------------------------
                //-- preveri se, ce datoteka se ne obstaja, da se zapise naslovna vrstica 
                if (!File.Exists(strFileName_measure_all))
                {
                    using (StreamWriter sw = File.AppendText(strFileName_measure_all))
                    {
                        fileDataLine = "Date" + strExcelSeparator;
                        fileDataLine = fileDataLine + "Time" + strExcelSeparator;
                        //-------------------------------------------------------------------------------------------------
                        fileDataLine = fileDataLine + "Time (h:min:sec) " + strExcelSeparator;
                        fileDataLine = fileDataLine + "Time (sec) " + strExcelSeparator;
                        //-------------------------------------------------------------------------------------------------
                        fileDataLine = fileDataLine + "Voltage (V) " + strExcelSeparator;
                        fileDataLine = fileDataLine + "Current (A) " + strExcelSeparator;
                        fileDataLine = fileDataLine + "Temperature (degC) " + strExcelSeparator;
                        fileDataLine = fileDataLine + "Temperature (degC) " + strExcelSeparator;
                        //-------------------------------------------------------------------------------------------------
                        fileDataLine = fileDataLine + "Supply curent (A) " + strExcelSeparator;
                        fileDataLine = fileDataLine + "Supply voltage (V) " + strExcelSeparator;
                        fileDataLine = fileDataLine + "Supply power (W) " + strExcelSeparator;
                        //-------------------------------------------------------------------------------------------------
                        fileDataLine = fileDataLine + "Load curent (A) " + strExcelSeparator;
                        fileDataLine = fileDataLine + "Load voltage (V) " + strExcelSeparator;
                        fileDataLine = fileDataLine + "Load power (W) " + strExcelSeparator;
                        fileDataLine = fileDataLine + "Load resistance (Ohm) " + strExcelSeparator;
                        //-------------------------------------------------------------------------------------------------
                        fileDataLine = fileDataLine + "AmperSecond (Asec) " + strExcelSeparator;
                        fileDataLine = fileDataLine + "AmperHour (Ah) " + strExcelSeparator;
                        fileDataLine = fileDataLine + "WattSecond  (Wsec) " + strExcelSeparator;
                        fileDataLine = fileDataLine + "WattHour (Wh) " + strExcelSeparator;
                        //-----------------------------------------------------------------------------
                        sw.WriteLine(fileDataLine);
                    }
                }
                //-----------------------------------------------------------------------------
                //-- zapis merilnih podatkov 
                using (StreamWriter sw = File.AppendText(strFileName_measure_all))
                {
                    fileDataLine = DateTime.Now.ToString("dd.MM.yyyy") + strExcelSeparator;
                    fileDataLine = fileDataLine + DateTime.Now.ToString("HH:mm:ss:fff") + strExcelSeparator;
                    //-------------------------------------------------------------------------------------------------
                    fileDataLine = fileDataLine + loc_run_duration_h_min_sec + strExcelSeparator;
                    fileDataLine = fileDataLine + loc_run_duration_seconds.ToString() + strExcelSeparator;
                    //-------------------------------------------------------------------------------------------------
                    fileDataLine = fileDataLine + measureValue_multimeter_XDM3051.ToString("0.0000000") + strExcelSeparator;
                    fileDataLine = fileDataLine + charge_discharge_current.ToString("0.0000") + strExcelSeparator;
                    fileDataLine = fileDataLine + temperature_now.ToString("0.0") + strExcelSeparator;
                    fileDataLine = fileDataLine + double_value.ToString("0.0") + strExcelSeparator;

                    //-------------------------------------------------------------------------------------------------
                    fileDataLine = fileDataLine + powerSupply_voltage[1].ToString() + strExcelSeparator;
                    fileDataLine = fileDataLine + powerSupply_current[1].ToString() + strExcelSeparator;
                    fileDataLine = fileDataLine + powerSupply_power[1].ToString() + strExcelSeparator;
                    //-------------------------------------------------------------------------------------------------
                    fileDataLine = fileDataLine + load_OutputCurrent[constLOAD_ET5410A].ToString() + strExcelSeparator;
                    fileDataLine = fileDataLine + load_OutputVoltage[constLOAD_ET5410A].ToString() + strExcelSeparator;
                    fileDataLine = fileDataLine + loads_OutputPower[constLOAD_ET5410A].ToString() + strExcelSeparator;
                    fileDataLine = fileDataLine + loads_OutputResistance[constLOAD_ET5410A].ToString() + strExcelSeparator;
                    //-------------------------------------------------------------------------------------------------
                    fileDataLine = fileDataLine + floatBatteryCurve_AmperSecond.ToString("0.0") + strExcelSeparator;
                    fileDataLine = fileDataLine + floatBatteryCurve_AmperHour.ToString("0.000") + strExcelSeparator;
                    fileDataLine = fileDataLine + floatBatteryCurve_WSecond.ToString("0.0") + strExcelSeparator;
                    fileDataLine = fileDataLine + floatBatteryCurve_WHour.ToString("0.000") + strExcelSeparator;
                    //-------------------------------------------------------------------------------------------------
                    sw.WriteLine(fileDataLine);
                }
            }
            catch (Exception ex)
            {
                strFunctionErrorString = ex.ToString();

            }
            return (funErrorCode.OK);
        }

        #endregion





        private void button1_Click(object sender, EventArgs e)
        {
            DCload_ET5410A.funLoadET5410A_ON();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DCload_ET5410A.funLoadET5410A_OFF();
        }

        private void btnSupplyON_Click(object sender, EventArgs e)
        {
            blnCharge_supply_on = true;
            power_supply_SPE6103.fun_powerSupply_SPE6103_on();
        }

        private void btnSupplyOFF_Click(object sender, EventArgs e)
        {
            blnCharge_supply_on = false;
            power_supply_SPE6103.fun_powerSupply_SPE6103_off();
        }



    }
}


*/

