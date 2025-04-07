using System;
using static test_system.global_variable;
using static test_system.program_20;

namespace test_system
{
    class program_20_batery_USB_pack
    {

        //-----------------------------------------------------------------------------------------------------------------------
        //-- charge / discharge 
        //-----------------------------------------------------------------------------------------------------------------------
        //--    integer številka trenutno izvajanja posameznega dela  programa 
        //--public static int program_state = 0;
        public const int PRG20_USB_PACK_CHARGE_DISABLE = 1;
        public const int PRG20_USB_PACK_CHARGE_INIT = 2;
        public const int PRG20_USB_PACK_CHARGE_WAIT = 3;
        public const int PRG20_USB_PACK_CHARGE_START = 4;
        public const int PRG20_USB_PACK_CHARGE_RUN = 5;
        public const int PRG20_USB_PACK_CHARGE_STOP = 6;

        //-----------------------------------------------------------------------------------------------------------------------
        //--    integer številka trenutno izvajanja posameznega dela  programa 
        //public static int program_state = 0;
        public const int PRG20_USB_PACK_DISCHARGE_DISABLE = 1;
        public const int PRG20_USB_PACK_DISCHARGE_INIT = 2;
        public const int PRG20_USB_PACK_DISCHARGE_WAIT = 3;
        public const int PRG20_USB_PACK_DISCHARGE_START = 4;
        public const int PRG20_USB_PACK_DISCHARGE_RUN = 5;
        public const int PRG20_USB_PACK_DISCHARGE_STOP = 6;

        const int PROGRAM20___USB_PACK___SELECT_SUPPLY = DEVICE_SELECT_SUPPLY_HCS_3300;
        const int PROGRAM20___USB_PACK___SELECT_LOAD = DEVICE_SELECT_LOAD_KEL103;

        const double PROGRAM20___USB_PACK___DISCHARGE___CURRENT = 1;
        const string PROGRAM20___USB_PACK___DISCHARGE___AMPERMETER_RANGE = XDM_2041_RANGE.DCA___5A;
        const string PROGRAM20___USB_PACK___DISCHARGE___VOLT_RANGE_XDM3051 = XDM_3051_RANGE.DCV___20V;
        const string PROGRAM20___USB_PACK___DISCHARGE___VOLT_RANGE_XDM1051 = XDM_1041_RANGE.DCV___50V;
        const int    PROGRAM20___USB_PACK___DISCHARGE___WAIT_TIME = 5;

        const double PROGRAM20___USB_PACK___CHARGE___VOLTAGE = 5;
        const double PROGRAM20___USB_PACK___CHARGE___CURRENT = 1;
        const string PROGRAM20___USB_PACK___CHARGE___AMPERMETER_RANGE = XDM_2041_RANGE.DCA___5A;
        const string PROGRAM20___USB_PACK___CHARGE___VOLT_RANGE_XDM3051 = XDM_3051_RANGE.DCV___20V;
        const string PROGRAM20___USB_PACK___CHARGE___VOLT_RANGE_XDM1051 = XDM_1041_RANGE.DCV___50V;
        const int    PROGRAM20___USB_PACK___CHARGE___WAIT_TIME = 5;

        temperature_ET3916 temperature_ET3916 = new temperature_ET3916();
        power_supply_KA3305P power_supply_KA3305P = new power_supply_KA3305P();
        power_supply_hcs_3300 power_supply_hcs_3300 = new power_supply_hcs_3300();

        owon_multimeter owon_multimeter = new owon_multimeter();
        dc_load_KEL103 dc_load_KEL103 = new dc_load_KEL103();
        write_log_files write_log_files = new write_log_files();

        program_common program_common = new program_common();
        program_20 program_20 = new program_20();

        #region "PROGRAM 20  ---   public const string program20_01 = "USB battery pack";

        #region " main program   ---   public const string program20_01 = "USB battery pack";
        //=======================================================================================================================
        /// <summary>
        ///    program 20 - USB battery pack
        ///         kliče se iz timerja programa 20
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        public funReturnCode fun_program20_01_usb_pack()
        {
            if (blnCharge)
            {
                switch (program_state)
                {
                    case PRG20_USB_PACK_CHARGE_INIT: { fun_program20_01_usb_pack___charge_init(); break; }
                    case PRG20_USB_PACK_CHARGE_WAIT: { fun_program20_01_usb_pack___wait_to_charge(); break; }
                    case PRG20_USB_PACK_CHARGE_START: { fun_program20_01_usb_pack___charge_run_start(); break; }
                    case PRG20_USB_PACK_CHARGE_RUN: { fun_program20_01_usb_pack___charge_run(); break; }
                    case PRG20_USB_PACK_CHARGE_STOP: { fun_program20_01_usb_pack___charge_stop(); break; }
                }
            }
            //-------------------------------------------------------------------------------------------------------------------
            //-- discharge cikel -- praznjenje packa
            if (blnDischarge)
            {
                switch (program_state)
                {
                    case PRG20_USB_PACK_DISCHARGE_INIT: { fun_program20_01_usb_pack___discharge_init(); break; }
                    case PRG20_USB_PACK_DISCHARGE_WAIT: { fun_program20_01_usb_pack___wait_to_discgarge(); break; }
                    case PRG20_USB_PACK_DISCHARGE_START: { fun_program20_01_usb_pack___discharge_run_start(); break; }
                    case PRG20_USB_PACK_DISCHARGE_RUN: { fun_program20_01_usb_pack___discharge_run(); break; }
                    case PRG20_USB_PACK_DISCHARGE_STOP: { fun_program20_01_usb_pack___discharge_stop(); break; }
                }
            }
            return funReturnCode.OK;
        }
        #endregion
        #region "CHARGE cikel   ---   public const string program20_01 = "USB battery pack";
        //=======================================================================================================================
        /// <summary>
        ///     izvaja se vsako sekundo
        ///         izmeri se napajalnik in se doda v log datoteko
        ///         izmerijo se multimetri in se doda v log datoteko
        ///         izračuna se kapaciteta in se doda v log datoteko
        ///         imerijo se temperature in se doda v log datoteko
        ///         preveri se če sta tok napajalnika in multimetra padla pod 0.1A --- USB pack se je napolnil in izklopil 
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        private funReturnCode fun_program20_01_usb_pack___charge_run()
        {
            program_common.fun_program___function___part_time_calulate();
            program_20_battery_test.write_label[PROG20_LABEL_STATUS].Text = ("CHARGE RUN    " + strDuration_part_program);
            //-------------------------------------------------------------------------------------------------------------------
            //-- izvajanje vsako sekundo             
            timer_new_second = (byte)(DateTime.Now.Second);
            if (timer_new_second != timer_old_second)
            {
                timer_old_second = timer_new_second;
                program_result_value.Clear();
                //---------------------------------------------------------------------------------------------------------------
                //-- meritev in dodajanje v log datoteko napajalnika 
                program_common.fun_program___power_supply___measure();
                program_common.fun_program___add_log_file___power_supply();
                //---------------------------------------------------------------------------------------------------------------
                //-- meritev in dodajanje v log datoteko 
                program_common.fun_program___multimeter___measure();
                program_common.fun_program___add_log_file___owon_multimeters("PACK voltage (V) ", "PACK current (V) ", "Multimeter XDM1041 (V) ");
                //---------------------------------------------------------------------------------------------------------------
                //-- izracun kapacitete vsako sekundo 
                program_20.fun_program20___function___calculate_capacitiy(dev_meas[COMport_XDM3051], dev_meas[COMport_XDM2041]);
                //---------------------------------------------------------------------------------------------------------------
                //-- izklop praznjenja, ko je tok load manjši od 0.1A in tok packa manjši od 0.1A
                if (HCS_3300_out_current < 0.1 && dev_meas[COMport_XDM2041] < 0.1)
                {
                    charge_end_counter++;
                    if (charge_end_counter > 10) program_state = PRG20_USB_PACK_CHARGE_STOP;
                    program_20_battery_test.write_label[PROG20_LABEL_STATUS].Text = "DISCHARGE RUN STOP    " + strDuration_part_program;
                }
                else charge_end_counter = 0;
                temperature_ET3916.fun_ET3916_read_all_temperature_by_test();
                program_common.fun_program___add_log_file___temperature(2);
                //---------------------------------------------------------------------------------------------------------------
                program_20_battery_test.write_label[PROG20_LABEL_1].Text = "Voltage   " + dev_meas[COMport_XDM3051].ToString("0.000") + " V    (" + HCS_3300_out_voltage.ToString("0.00") + " V)";
                program_20_battery_test.write_label[PROG20_LABEL_2].Text = "Current   " + dev_meas[COMport_XDM2041].ToString("0.000") + " A    (" + HCS_3300_out_current.ToString("0.00") + " A  " + HCS_3300_out_status + " )";
                program_20_battery_test.write_label[PROG20_LABEL_3].Text = "Capacity  " + floatBatteryCurve_AmperHour.ToString("0.0000") + " Ah    " + floatBatteryCurve_WHour.ToString("0.0000") + " Wh";
                //---------------------------------------------------------------------------------------------------------------
                write_log_files.funWriteLogFile_program();
            }
            return funReturnCode.OK;
        }
        //=======================================================================================================================
        /// <summary>
        ///    start charge 
        ///         nastavitev in vklop napajalnika
        ///             const double PROGRAM20___USB_PACK___CHARGE___VOLTAGE = 5;
        ///             const double PROGRAM20___USB_PACK___CHARGE___CURRENT = 1;
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        private funReturnCode fun_program20_01_usb_pack___charge_init()
        {
            program_select_supply = PROGRAM20___USB_PACK___SELECT_SUPPLY;
            program_select = program20_USB_PACK;
            //-------------------------------------------------------------------------------------------------------------------   
            //-- ime log datoteke   
            strLogFiles_program = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_20_" + program20_01 + "_charge_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
            //-------------------------------------------------------------------------------------------------------------------
            intCharge_run_wait_time_set = PROGRAM20___USB_PACK___CHARGE___WAIT_TIME;
            //-------------------------------------------------------------------------------------------------------------------
            program_common.fun_program___power_supply___set_voltage_current(PROGRAM20___USB_PACK___CHARGE___VOLTAGE, PROGRAM20___USB_PACK___CHARGE___CURRENT);
            //-------------------------------------------------------------------------------------------------------------------
            startTime_part_program = DateTime.Now;
            startTime_complete_program = DateTime.Now;
            //-------------------------------------------------------------------------------------------------------------------
            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM3051, PROGRAM20___USB_PACK___CHARGE___VOLT_RANGE_XDM3051);
            owon_multimeter.fun_owon_set_range_current_dc(COMport_XDM2041, PROGRAM20___USB_PACK___CHARGE___AMPERMETER_RANGE);
            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM1041, PROGRAM20___USB_PACK___CHARGE___VOLT_RANGE_XDM1051);
            //-------------------------------------------------------------------------------------------------------------------
            program_state = PRG20_USB_PACK_CHARGE_WAIT;
            return funReturnCode.OK;
        }
        //=======================================================================================================================
        /// <summary>
        ///    čaka se nek čas preden se začne z polnjenjem 
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        private funReturnCode fun_program20_01_usb_pack___wait_to_charge()
        {
            program_common.fun_program___function___part_time_calulate();
            program_20_battery_test.write_label[PROG20_LABEL_STATUS].Text = ("CHARGE WAIT   " + floatDuration_part_program_run.ToString("0.0") + " sec" + "     of " + intCharge_run_wait_time_set.ToString() + " sec");
            //-------------------------------------------------------------------------------------------------------------------
            if (floatDuration_part_program_run > intCharge_run_wait_time_set)
            {
                program_20_battery_test.write_label[PROG20_LABEL_STATUS].Text = ("CHARGE WAIT END  ");
                floatDuration_part_program_complete = floatDuration_part_program_run;
                startTime_part_program = DateTime.Now;
                program_state = PRG20_USB_PACK_CHARGE_START;
            }
            return funReturnCode.OK;
        }
        //=======================================================================================================================
        /// <summary>
        ///     start charge cikla
        ///         vklop chargerja ( napajalnika ) 
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        private funReturnCode fun_program20_01_usb_pack___charge_run_start()
        {
            program_state = PRG20_USB_PACK_CHARGE_RUN;
            program_common.fun_program___function___part_time_calulate();
            //-------------------------------------------------------------------------------------------------------------------
            program_20_battery_test.write_label[PROG20_LABEL_STATUS].Text = ("CHARGE START   " + floatDuration_part_program_run.ToString("0.0") + " sec");
            program_common.fun_program___power_supply___on();
            startTime_part_program = DateTime.Now;
            //-------------------------------------------------------------------------------------------------------------------
              //-------------------------------------------------------------------------------------------------------------------
            floatBatteryCurve_AmperSecond = 0; floatBatteryCurve_AmperHour = 0;
            floatBatteryCurve_WSecond = 0; floatBatteryCurve_WHour = 0;
            return funReturnCode.OK;
        }
        //=======================================================================================================================
        /// <summary>
        /// konec charge cikla
        ///     izklop chargerja
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        private funReturnCode fun_program20_01_usb_pack___charge_stop()
        {
            program_state = PRG20_USB_PACK_CHARGE_DISABLE;
            blnCharge = false;
            //-------------------------------------------------------------------------------------------------------------------
            program_20_battery_test.write_label[PROG20_LABEL_STATUS].Text = ("CHARGE STOP    " + floatDuration_part_program_run.ToString("0.0") + " sec");
            program_common.fun_program___power_supply___off();
            //-------------------------------------------------------------------------------------------------------------------
            program_20_battery_test.write_label[PROG20_LABEL_1].Text = "";
            program_20_battery_test.write_label[PROG20_LABEL_2].Text = "";
            program_20_battery_test.write_label[PROG20_LABEL_3].Text = "Capacity  " + floatBatteryCurve_AmperHour.ToString("0.0000") + " Ah    " + floatBatteryCurve_WHour.ToString("0.0000") + " Wh";
            return funReturnCode.OK;
        }
        #endregion

        #region "DISCHARGE cikel   ---   public const string program20_01 = "USB battery pack";
        //=======================================================================================================================
        /// <summary>
        ///     DISCHARGE TEČE
        ///         meri se tok v breme
        ///         ko tok pade, je PACK izklopil praznjenje, se discharge cikel konča
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        private funReturnCode fun_program20_01_usb_pack___discharge_run()
        {
            program_common.fun_program___function___part_time_calulate();
            program_20_battery_test.write_label[PROG20_LABEL_STATUS].Text = ("DISCHARGE RUN    " + strDuration_part_program);
            //-------------------------------------------------------------------------------------------------------------------
            //-- izvajanje vsako sekundo             
            timer_new_second = (byte)(DateTime.Now.Second);
            if (timer_new_second != timer_old_second)
            {
                timer_old_second = timer_new_second;
                program_result_value.Clear();
                //---------------------------------------------------------------------------------------------------------------
                program_common.fun_program___load___get_measure();
                if (program_select_load == DEVICE_SELECT_LOAD_KEL103) program_common.fun_program___add_log_file___load_KEL103();
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
                    program_20_battery_test.write_label[PROG20_LABEL_STATUS].Text = ("DISCHARGE RUN STOP    " + strDuration_part_program);
                    discharge_end_counter++;
                    if (discharge_end_counter > 10) program_state = PRG20_USB_PACK_DISCHARGE_STOP;
                }
                else discharge_end_counter = 0;
                //---------------------------------------------------------------------------------------------------------------
                temperature_ET3916.fun_ET3916_read_all_temperature_by_test();
                program_common.fun_program___add_log_file___temperature(2);
                //---------------------------------------------------------------------------------------------------------------
                program_20_battery_test.write_label[PROG20_LABEL_1].Text = "Voltage   " + dev_meas[COMport_XDM3051].ToString("0.000") + " V       (" + KEL103_voltage.ToString("0.00") + " V)";
                program_20_battery_test.write_label[PROG20_LABEL_2].Text = "Current   " + dev_meas[COMport_XDM2041].ToString("0.000") + " A       (" + KEL103_current.ToString("0.00") + " A)";
                program_20_battery_test.write_label[PROG20_LABEL_3].Text = "Capacity  " + floatBatteryCurve_AmperHour.ToString("0.0000") + " Ah     " + floatBatteryCurve_WHour.ToString("0.0000") + " Wh";
                //---------------------------------------------------------------------------------------------------------------
                write_log_files.funWriteLogFile_program();
            }
            return funReturnCode.OK;
        }
        //=======================================================================================================================
        /// <summary>
        ///     konec praznjenja
        ///         izklopi se breme 
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        private funReturnCode fun_program20_01_usb_pack___discharge_stop()
        {
            program_state = PRG20_USB_PACK_DISCHARGE_DISABLE;
            program_20_battery_test.write_label[PROG20_LABEL_STATUS].Text = ("DISCHARGE STOP    " + floatDuration_part_program_run.ToString("0.0") + " sec");
            program_common.fun_program___load___off();
            program_common.fun_program___load___get_measure();
            program_20_battery_test.write_label[PROG20_LABEL_1].Text = "";
            program_20_battery_test.write_label[PROG20_LABEL_2].Text = "";
            program_20_battery_test.write_label[PROG20_LABEL_3].Text = "Capacity  " + floatBatteryCurve_AmperHour.ToString("0.00") + " Ah       " + floatBatteryCurve_WHour.ToString("0.00") + " Wh";
            blnDischarge = false;

            return funReturnCode.OK;
        }
        //=======================================================================================================================
        /// <summary>
        ///    začetek praznjenja
        ///         vklopi se breme in nastavi tok praznjenja
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        private funReturnCode fun_program20_01_usb_pack___discharge_run_start()
        {
            program_common.fun_program___function___part_time_calulate();
            program_20_battery_test.write_label[PROG20_LABEL_STATUS].Text = ("DISCHARGE START   " + floatDuration_part_program_run.ToString("0.0") + " sec");
            //-------------------------------------------------------------------------------------------------------------------   
            program_common.fun_program___load___set_current(PROGRAM20___USB_PACK___DISCHARGE___CURRENT);
            program_common.fun_program___load___on();
            //-------------------------------------------------------------------------------------------------------------------   
            program_state = PRG20_USB_PACK_DISCHARGE_RUN;
            startTime_part_program = DateTime.Now;
            //-------------------------------------------------------------------------------------------------------------------   
            floatBatteryCurve_AmperSecond = 0; floatBatteryCurve_AmperHour = 0;
            floatBatteryCurve_WSecond = 0; floatBatteryCurve_WHour = 0;
            //-------------------------------------------------------------------------------------------------------------------   
            return funReturnCode.OK;
        }
        //=======================================================================================================================
        /// <summary>
        /// čaka se nek čas, preden se začne z praznjenjem
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        private funReturnCode fun_program20_01_usb_pack___wait_to_discgarge()
        {
            program_common.fun_program___function___part_time_calulate();
            program_20_battery_test.write_label[PROG20_LABEL_STATUS].Text = "DISCHARGE WAIT   " + floatDuration_part_program_run.ToString("0.0") + " sec" + "     of " + intDischarge_start_wait_time_set.ToString() + " sec";
            //-------------------------------------------------------------------------------------------------------------------   
            if (floatDuration_part_program_run > intDischarge_start_wait_time_set)
            {
                program_state = PRG20_USB_PACK_DISCHARGE_START;
                program_20_battery_test.write_label[PROG20_LABEL_STATUS].Text = ("DISCHARGE WAIT END  ");
                floatDuration_part_program_complete = floatDuration_part_program_run;
                startTime_part_program = DateTime.Now;
            }
            return funReturnCode.OK;
        }
        //=======================================================================================================================
        /// <summary>
        ///     začetni pogogi za praznjennje
        ///         nastavijo me merilna območja na instrumentih
        ///         določi se ime log datoteke
        ///         začne se čakanje pred začetkom praznjenja
        /// 
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        private funReturnCode fun_program20_01_usb_pack___discharge_init()
        {
            floatDuration_part_program_run = 0;
            program_select = program20_USB_PACK;
            program_select_load = PROGRAM20___USB_PACK___SELECT_LOAD;
            //-------------------------------------------------------------------------------------------------------------------   
            //-- ime log datoteke   
            strLogFiles_program = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_20_" + program20_01 + "_discharge_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
            intDischarge_start_wait_time_set = PROGRAM20___USB_PACK___DISCHARGE___WAIT_TIME;
            startTime_part_program = DateTime.Now;
            startTime_complete_program = DateTime.Now;
            endTime_part_program = startTime_part_program;
            //-------------------------------------------------------------------------------------------------------------------
            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM3051, PROGRAM20___USB_PACK___DISCHARGE___VOLT_RANGE_XDM3051);
            owon_multimeter.fun_owon_set_range_current_dc(COMport_XDM2041, PROGRAM20___USB_PACK___DISCHARGE___AMPERMETER_RANGE);
            owon_multimeter.fun_owon_set_range_volt_dc(COMport_XDM1041, PROGRAM20___USB_PACK___DISCHARGE___VOLT_RANGE_XDM1051);
            //-------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------
            program_state = PRG20_USB_PACK_DISCHARGE_WAIT;
            //-------------------------------------------------------------------------------------------------------------------
            return funReturnCode.OK;
        }

        #endregion

        #endregion    //--     #region "PROGRAM 20  ---   public const string program20_01 = "USB battery pack";










    }
}
