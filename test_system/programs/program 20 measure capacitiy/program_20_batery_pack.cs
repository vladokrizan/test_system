using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static test_system.global_variable;
using static test_system.program_20;

namespace test_system
{
    class program_20_batery_pack
    {

        const double PROGRAM20___USB_PACK___DISCHARGE_CURRENT = 1;
        const double PROGRAM20___USB_PACK___AMPERMETER_RANGE = 5;

        ac_meter_MPM_1010B ac_meter_MPM_1010B = new ac_meter_MPM_1010B();
        temperature_ET3916 temperature_ET3916 = new temperature_ET3916();
        power_supply_KA3305P power_supply_KA3305P = new power_supply_KA3305P();
        power_supply_hcs_3300 power_supply_hcs_3300 = new power_supply_hcs_3300();

        owon_multimeter owon_multimeter = new owon_multimeter();
        dc_load_KEL103 dc_load_KEL103 = new dc_load_KEL103();
        write_log_files write_log_files = new write_log_files();

        program_common program_common = new program_common();
        program_20 program_20 = new program_20();


        #region "PROGRAM 20  ---   public const string program20_01 = "USB battery pack";

        public void fun_change_labCurrentState(string window_label)
        {
            blnChangeWindow_program_20_USB_battery_pack_labCurrentState = true;
            USB_battery_pack_labCurrentState = window_label;
        }


        #region " main program   ---   public const string program20_01 = "USB battery pack";

        public int fun_program20_01_usb_pack()
        {
            

            if (blnCharge_start) fun_program20_01_usb_pack___start_charge();
            if (blnCharge_run_wait) fun_program20_01_usb_pack___wait_to_charge();
            if (blnCharge_run_start) fun_program20_01_usb_pack___charge_run_start();
            if (blnCharge_run) fun_program20_01_usb_pack___charge_run();
            if (blnCharge_run_stop) fun_program20_01_usb_pack___charge_stop();

            
            //-------------------------------------------------------------------------------------------------------------------
            //-- discharge cikel -- praznjenje packa
            if (blnDischarge_start) fun_program20_01_usb_pack___discharge_start();
            if (blnDischarge_start_wait) fun_program20_01_usb_pack___wait_to_discgarge();
            if (blnDischarge_run_start) fun_program20_01_usb_pack___discharge_run_start();
            if (blnDischarge_run) fun_program20_01_usb_pack___discharge_run();
            if (blnDischarge_run_stop) fun_program20_01_usb_pack___discharge_stop();

            

            return 0;
        }
        #endregion
        #region "CHARGE cikel   ---   public const string program20_01 = "USB battery pack";

        private int fun_program20_01_usb_pack___charge_run()
        {
            program_common.fun_program___function___part_time_calulate();

            // labCurrentState.Text = "DISCHARGE RUN    " + floatDuration_part_program_run.ToString("0.0") + " sec";
            //labCurrentState.Text = "CHARGE RUN    " + strDuration_part_program;
            fun_change_labCurrentState("CHARGE RUN    " + strDuration_part_program);
            //-----------------------------------------------------------------------------------------------------
            //-- izvajanje vsako sekundo             
            timer_new_second = (byte)(DateTime.Now.Second);
            if (timer_new_second != timer_old_second)
            {
                timer_old_second = timer_new_second;
                program_result_value.Clear();

                program_common.fun_program___power_supply___measure();
                program_common.fun_program___add_log_file___power_supply();
                //-------------------------------------------------------------------------------------------------------------------
                program_common.fun_program___multimeter___measure();
                program_common.fun_program___add_log_file___owon_multimeters("PACK voltage (V) ", "PACK current (V) ", "Multimeter XDM1041 (V) ");
                //---------------------------------------------------------------------------------------------------------------
                //-- izracun kapacitete vsako sekundo 
                program_20.fun_program20___function___calculate_capacitiy(dev_meas[COMport_XDM3051], dev_meas[COMport_XDM2041]);
                //---------------------------------------------------------------------------------------------------------------

                //---------------------------------------------------------------------------------------------------------------
                //-- izklop praznjenja, ko je tok load manjši od 0.1A in tok packa manjši od 0.1A
                //if (KEL103_current < 0.1 && dev_meas[COMport_XDM2041] < 0.1)
                //{
                //    discharge_end_counter++;
                //    if (discharge_end_counter > 10) blnDischarge_run_stop = true;
                //    labCurrentState.Text = "DISCHARGE RUN STOP    " + strDuration_part_program;
                //     }        else discharge_end_counter = 0;

                //labHCS3300_voltage.Text = "Out Voltage: " + HSC3300_out_voltage.ToString("0.00") + " V";
                //labHCS3300_current.Text = "Out Current: " + HSC3300_out_current.ToString("0.00") + " A";
                //labHCS3300_status.Text = HSC3300_out_status;
                temperature_ET3916.fun_ET3916_read_all_temperature_by_test();
                program_common.fun_program___add_log_file___temperature(2);
                //---------------------------------------------------------------------------------------------------------------

                blnChangeWindow_program_20_USB_battery_pack_measure_label = true;
                USB_battery_pack_measure_label_1 = "Voltage   " + dev_meas[COMport_XDM3051].ToString("0.000") + " V    (" + HCS_3300_out_voltage.ToString("0.00") + " V)";
                USB_battery_pack_measure_label_2 = "Current   " + dev_meas[COMport_XDM2041].ToString("0.000") + " A    (" + HCS_3300_out_current.ToString("0.00") + " A  " + HCS_3300_out_status + " )";
                USB_battery_pack_measure_label_3 = "Capacity  " + floatBatteryCurve_AmperHour.ToString("0.0000") + " Ah    " + floatBatteryCurve_WHour.ToString("0.0000") + " Wh";
                // labResult_01.Text = "Voltage   " + dev_meas[COMport_XDM3051].ToString("0.000") + " V    (" + HCS_3300_out_voltage.ToString("0.00") + " V)";
                //labResult_02.Text = "Current   " + dev_meas[COMport_XDM2041].ToString("0.000") + " A    (" + HCS_3300_out_current.ToString("0.00") + " A  " + HCS_3300_out_status + " )";
                //labResult_03.Text = "Capacity  " + floatBatteryCurve_AmperHour.ToString("0.0000") + " Ah    " + floatBatteryCurve_WHour.ToString("0.0000") + " Wh";


                //---------------------------------------------------------------------------------------------------------------
                write_log_files.funWriteLogFile_program10();
            }
            return 0;
        }





        //=======================================================================================================================
        /// <summary>
        ///    start charge 
        ///         nastavitev in vklop napajalnika
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        private int fun_program20_01_usb_pack___start_charge()
        {
            blnCharge_start = false;
            program_select_supply = DEVICE_SELECT_SUPPLY_HCS_3300;
            program_select_load = DEVICE_SELECT_LOAD_KEL103;
            //fun_select_program_log_file_name(program20_name_current);
            program_select_current = program20_USB_PACK;
            //-------------------------------------------------------------------------------------------------------------------   
            //-- ime log datoteke   
            //string[] comboBoxParts = program10_current_selected_program.Split(':');
            if (program20_01_charge) strLogFiles_program = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_20_" + program20_01 + "_charge_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
            if (program20_01_discharge) strLogFiles_program = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_20_" + program20_01 + "_discharge_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";


            //-------------------------------------------------------------------------------------------------------------------
            blnCharge_run_wait = true;
            intCharge_run_wait_time_set = 5;
            //-------------------------------------------------------------------------------------------------------------------
            program_common.fun_program___power_supply___set_voltage_current(5, 1);
            //-------------------------------------------------------------------------------------------------------------------
            startTime_part_program = DateTime.Now;
            startTime_complete_program = DateTime.Now;
            //-------------------------------------------------------------------------------------------------------------------
            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM3051, 20);
            owon_multimeter.fun_owon_set_range_current_dc(COMport_XDM2041, 5);
            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM1041, 50);
            //-------------------------------------------------------------------------------------------------------------------
            blnCharge = true;
            return 0;
        }

        private int fun_program20_01_usb_pack___wait_to_charge()
        {
            program_common.fun_program___function___part_time_calulate();
            //labCurrentState.Text = "CHARGE WAIT   " + floatDuration_part_program_run.ToString("0.0") + " sec" + "     of " + intCharge_run_wait_time_set.ToString() + " sec";
            fun_change_labCurrentState("CHARGE WAIT   " + floatDuration_part_program_run.ToString("0.0") + " sec" + "     of " + intCharge_run_wait_time_set.ToString() + " sec");


            if (floatDuration_part_program_run > intCharge_run_wait_time_set)
            {
                blnCharge_run_wait = false;
                fun_change_labCurrentState("CHARGE WAIT END  ");
                blnCharge_run_start = true;
                floatDuration_part_program_complete = floatDuration_part_program_run;
                startTime_part_program = DateTime.Now;
            }
            return 0;
        }
        private int fun_program20_01_usb_pack___charge_run_start()
        {
            blnCharge_run_start = false;
            program_common.fun_program___function___part_time_calulate();
            //labCurrentState.Text = "CHARGE START   " + floatDuration_part_program_run.ToString("0.0") + " sec";
            fun_change_labCurrentState("CHARGE START   " + floatDuration_part_program_run.ToString("0.0") + " sec");
            program_common.fun_program___power_supply___on();
            startTime_part_program = DateTime.Now;
            floatBatteryCurve_AmperSecond = 0;
            floatBatteryCurve_AmperHour = 0;
            floatBatteryCurve_WSecond = 0;
            floatBatteryCurve_WHour = 0;
            blnCharge_run = true;
            return 0;
        }

        private int fun_program20_01_usb_pack___charge_stop()
        {
            blnCharge_run_stop = false;
            blnCharge_run = false;
            blnCharge = false;
            //labCurrentState.Text = "CHARGE STOP    " + floatDuration_part_program_run.ToString("0.0") + " sec";
            fun_change_labCurrentState("CHARGE STOP    " + floatDuration_part_program_run.ToString("0.0") + " sec");
            program_common.fun_program___power_supply___off();

            blnChangeWindow_program_20_USB_battery_pack_measure_label = true;
            USB_battery_pack_measure_label_1 = "";
            USB_battery_pack_measure_label_2 = "";
            USB_battery_pack_measure_label_3 = "Capacity  " + floatBatteryCurve_AmperHour.ToString("0.0000") + " Ah    " + floatBatteryCurve_WHour.ToString("0.0000") + " Wh";

            //labResult_01.Text = "";
            //labResult_02.Text = "";
            //labResult_03.Text = "Capacity  " + floatBatteryCurve_AmperHour.ToString("0.00") + " Ah       " + floatBatteryCurve_WHour.ToString("0.00") + " Wh";



            return 0;
        }
        #endregion

        #region "DISCHARGE cikel   ---   public const string program20_01 = "USB battery pack";
        //=======================================================================================================================
        /// <summary>
        ///     DISCHARGE TEČE
        ///     - meri se tok v breme
        ///     - ko tok pade, je PACK izklopil praznjenje, se discharge cikel konča
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        private int fun_program20_01_usb_pack___discharge_run()
        {
            program_common.fun_program___function___part_time_calulate();
            fun_change_labCurrentState("DISCHARGE RUN    " + strDuration_part_program);
            //-------------------------------------------------------------------------------------------------------------------
            //-- izvajanje vsako sekundo             
            timer_new_second = (byte)(DateTime.Now.Second);
            if (timer_new_second != timer_old_second)
            {
                timer_old_second = timer_new_second;
                program_result_value.Clear();
                //---------------------------------------------------------------------------------------------------------------
                program_common.fun_program___load___get_measure();
                program_common.fun_program___add_log_file___load_KEL103();
                //---------------------------------------------------------------------------------------------------------------
                program_common.fun_program___multimeter___measure();
                program_common.fun_program___add_log_file___owon_multimeters("PACK voltage (V) ", "PACK current (V) ", "Multimeter XDM1041 (V) ");
                //---------------------------------------------------------------------------------------------------------------
                //-- izracun kapacitete vsako sekundo 
                program_20.fun_program20___function___calculate_capacitiy(dev_meas[COMport_XDM3051], dev_meas[COMport_XDM2041]);
                //---------------------------------------------------------------------------------------------------------------
                //-- izklop praznjenja, ko je tok load manjši od 0.1A in tok packa manjši od 0.1A
                if (KEL103_current < 0.1 && dev_meas[COMport_XDM2041] < 0.1)
                {
                    discharge_end_counter++;
                    if (discharge_end_counter > 10) blnDischarge_run_stop = true;
                    fun_change_labCurrentState("DISCHARGE RUN STOP    " + strDuration_part_program);
                }
                else discharge_end_counter = 0;
                //---------------------------------------------------------------------------------------------------------------
                temperature_ET3916.fun_ET3916_read_all_temperature_by_test();
                program_common.fun_program___add_log_file___temperature(2);
                //---------------------------------------------------------------------------------------------------------------
                blnChangeWindow_program_20_USB_battery_pack_measure_label = true;
                USB_battery_pack_measure_label_1 = "Voltage   " + dev_meas[COMport_XDM3051].ToString("0.000") + " V       (" + KEL103_voltage.ToString("0.00") + " V)";
                USB_battery_pack_measure_label_2 = "Current   " + dev_meas[COMport_XDM2041].ToString("0.000") + " A       (" + KEL103_current.ToString("0.00") + " A)";
                USB_battery_pack_measure_label_3 = "Capacity  " + floatBatteryCurve_AmperHour.ToString("0.0000") + " Ah     " + floatBatteryCurve_WHour.ToString("0.0000") + " Wh";

                //labResult_01.Text = "Voltage   " + dev_meas[COMport_XDM3051].ToString("0.000") + " V       (" + KEL103_voltage.ToString("0.00") + " V)";
                //labResult_02.Text = "Current   " + dev_meas[COMport_XDM2041].ToString("0.000") + " A       (" + KEL103_current.ToString("0.00") + " A)";
                //labResult_03.Text = "Capacity  " + floatBatteryCurve_AmperHour.ToString("0.0000") + " Ah     " + floatBatteryCurve_WHour.ToString("0.0000") + " Wh";
                //---------------------------------------------------------------------------------------------------------------
                write_log_files.funWriteLogFile_program10();
            }
            return 0;
        }

        private int fun_program20_01_usb_pack___discharge_stop()
        {
            blnDischarge_run_stop = false;
            blnDischarge_run = false;
            fun_change_labCurrentState( "DISCHARGE STOP    " + floatDuration_part_program_run.ToString("0.0") + " sec");
            program_common.fun_program___load___off();
            program_common.fun_program___load___get_measure();

            blnChangeWindow_program_20_USB_battery_pack_measure_label = true;
            USB_battery_pack_measure_label_1 = "";
            USB_battery_pack_measure_label_2 = "";
            USB_battery_pack_measure_label_3 = "Capacity  " + floatBatteryCurve_AmperHour.ToString("0.00") + " Ah       " + floatBatteryCurve_WHour.ToString("0.00") + " Wh";

            //labResult_01.Text = "";
            //labResult_02.Text = "";
            //labResult_03.Text = "Capacity  " + floatBatteryCurve_AmperHour.ToString("0.00") + " Ah       " + floatBatteryCurve_WHour.ToString("0.00") + " Wh";
            return 0;
        }

        private int fun_program20_01_usb_pack___wait_to_discgarge()
        {
            program_common.fun_program___function___part_time_calulate();
            fun_change_labCurrentState( "DISCHARGE WAIT   " + floatDuration_part_program_run.ToString("0.0") + " sec" + "     of " + intDischarge_start_wait_time_set.ToString() + " sec");
            if (floatDuration_part_program_run > intDischarge_start_wait_time_set)
            {
                blnDischarge_start_wait = false;
                fun_change_labCurrentState( "DISCHARGE WAIT END  ");
                blnDischarge_run_start = true;
                floatDuration_part_program_complete = floatDuration_part_program_run;
                startTime_part_program = DateTime.Now;
            }
            return 0;
        }
        private int fun_program20_01_usb_pack___discharge_run_start()
        {
            program_common.fun_program___function___part_time_calulate();
            fun_change_labCurrentState( "DISCHARGE START   " + floatDuration_part_program_run.ToString("0.0") + " sec");
            program_common.fun_program___load___set_current(discharge_load_current);
            program_common.fun_program___load___on();

            blnDischarge_run = true;
            blnDischarge_run_start = false;
            startTime_part_program = DateTime.Now;

            floatBatteryCurve_AmperSecond = 0;
            floatBatteryCurve_AmperHour = 0;
            floatBatteryCurve_WSecond = 0;
            floatBatteryCurve_WHour = 0;
            return 0;
        }

        private int fun_program20_01_usb_pack___discharge_start()
        {
            blnDischarge_start = false;
            //fun_select_program_log_file_name(program20_name_current);
            program_select_current = program20_USB_PACK;
            //-------------------------------------------------------------------------------------------------------------------   
            //-- ime log datoteke   
            //string[] comboBoxParts = program10_current_selected_program.Split(':');
            //if (radioButton_charge.Checked) strLogFiles_program = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_20_" + select_program + "_charge_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
            //if (radioButton_discharge.Checked) strLogFiles_program = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_20_" + select_program + "_discharge_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
            if (program20_01_charge) strLogFiles_program = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_20_" + program20_01 + "_charge_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
            if (program20_01_discharge) strLogFiles_program = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_20_" + program20_01 + "_discharge_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";

            blnDischarge = true;
            blnDischarge_run_start = false;
            blnDischarge_start_wait = true;
            intDischarge_start_wait_time_set = 5;
            startTime_part_program = DateTime.Now;
            startTime_complete_program = DateTime.Now;

            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM3051, 20);
            owon_multimeter.fun_owon_set_range_current_dc(COMport_XDM2041, PROGRAM20___USB_PACK___AMPERMETER_RANGE);
            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM1041, 50);

            program_select_supply = DEVICE_SELECT_SUPPLY_HCS_3300;
            program_select_load = DEVICE_SELECT_LOAD_KEL103;
            discharge_load_current = PROGRAM20___USB_PACK___DISCHARGE_CURRENT;
            //-------------------------------------------------------------------------------------------------------------------
            return 0;
        }

        #endregion

        #endregion    //--     #region "PROGRAM 20  ---   public const string program20_01 = "USB battery pack";










    }
}
