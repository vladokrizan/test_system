using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;


namespace test_system
{
    class program_common
    {
        ac_meter_MPM_1010B ac_meter_MPM_1010B = new ac_meter_MPM_1010B();
        temperature_ET3916 temperature_ET3916 = new temperature_ET3916();
        power_supply_KA3305P power_supply_KA3305P = new power_supply_KA3305P();
        power_supply_hcs_3300 power_supply_hcs_3300 = new power_supply_hcs_3300();

        owon_multimeter owon_multimeter = new owon_multimeter();
        dc_load_KEL103 dc_load_KEL103 = new dc_load_KEL103();
        //write_log_files write_log_files = new write_log_files();


        #region "PROGRAM COMMON -- LOAD "
        //=======================================================================================================================
        /// <summary>
        ///   branje napetosti, toka in moči iz bremena
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        public int fun_program___load___get_measure()
        {
            if (program_select_load == DEVICE_SELECT_LOAD_KEL103)
            {
                dc_load_KEL103.fun_KEL103_get_voltage();
                dc_load_KEL103.fun_KEL103_get_current();
                dc_load_KEL103.fun_KEL103_get_power();
            }
            return 0;
        }

        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        public int fun_program___add_log_file___load_KEL103()
        {
            program_result_value.Add("LOAD KEL103 Voltage (V) ", KEL103_voltage.ToString("0.00"));
            program_result_value.Add("LOAD KEL103 Current (A) ", KEL103_current.ToString("0.00"));
            program_result_value.Add("LOAD KEL103 Power (W) ", KEL103_power.ToString("0.00"));
            return 0;
        }

        //=======================================================================================================================
        //=======================================================================================================================
        public int fun_program___load___on()
        {
            if (program_select_load == DEVICE_SELECT_LOAD_KEL103)
            {
                dc_load_KEL103.fun_KEL103_on();
            }
            return 0;
        }
        //=======================================================================================================================
        //=======================================================================================================================
        public int fun_program___load___off()
        {
            if (program_select_load == DEVICE_SELECT_LOAD_KEL103)
            {
                dc_load_KEL103.fun_KEL103_off();
            }
            return 0;
        }
        //=======================================================================================================================
        //=======================================================================================================================
        public int fun_program___load___set_current(double load_set_current)
        {
            if (program_select_load == DEVICE_SELECT_LOAD_KEL103)
            {
                dc_load_KEL103.fun_KEL103_set_current(load_set_current);
            }
            return 0;
        }



        #endregion
        #region "PROGRAM COMMON -- MULTIMETERS "


        //=======================================================================================================================
        /// <summary>
        ///    meritev napetosti in toka z multimetri
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        public int fun_program___multimeter___measure()
        {
            owon_multimeter.fun_owon_measure(COMport_XDM3051);
            owon_multimeter.fun_owon_measure(COMport_XDM2041);
            owon_multimeter.fun_owon_measure(COMport_XDM1041);
            return 0;
        }

        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="XDM3051_name"></param>
        /// <param name="XDM2041_name"></param>
        /// <param name="XDM1041_name"></param>
        /// <returns></returns>
        //=======================================================================================================================
        public int fun_program___add_log_file___owon_multimeters(string XDM3051_name, string XDM2041_name, string XDM1041_name)
        {
            if (dev_meas_state[COMport_XDM3051] == funReturnCodeCOMport.OK) program_result_value.Add(XDM3051_name, dev_meas[COMport_XDM3051].ToString("0.000"));
            if (dev_meas_state[COMport_XDM2041] == funReturnCodeCOMport.OK) program_result_value.Add(XDM2041_name, dev_meas[COMport_XDM2041].ToString("0.000"));
            if (dev_meas_state[COMport_XDM1041] == funReturnCodeCOMport.OK) program_result_value.Add(XDM1041_name, dev_meas[COMport_XDM1041].ToString("0.000"));
            return 0;
        }

        #endregion

        #region "PROGRAM COMMON -- POWER SUPPLY "



        //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        ///         HCS_3300_out_voltage.ToString("0.00") + " V";
        ///         HCS_3300_out_current.ToString("0.00") + " A";
        ///         HCS_3300_out_status;
        /// </summary>
        /// <param name="set_channel"></param>
        /// <returns></returns>
        //=======================================================================================================================
        public int fun_program___power_supply___measure(int set_channel = 1)
        {
            if (program_select_supply == DEVICE_SELECT_SUPPLY_HCS_3300)
            {
                power_supply_hcs_3300.fun_HCS_330_get_measure();

                //labHCS3300_voltage.Text = "Out Voltage: " + HSC3300_out_voltage.ToString("0.00") + " V";
                //labHCS3300_current.Text = "Out Current: " + 
                //labHCS3300_status.Text = 

                //power_supply_hcs_3300.fun_HCS_330_set_voltage(set_voltage);
                //power_supply_hcs_3300.fun_HCS_330_set_current(set_current);
            }
            return 0;
        }


        public int fun_program___power_supply___set_voltage_current ( double set_voltage, double set_current, int set_channel = 1)
        {
            if (program_select_supply == DEVICE_SELECT_SUPPLY_HCS_3300)
            {
                power_supply_hcs_3300.fun_HCS_330_set_voltage(set_voltage);
                power_supply_hcs_3300.fun_HCS_330_set_current(set_current);
            }
            return 0;
        }

        public int fun_program___power_supply___on(int set_channel = 1)
        {
            if (program_select_supply == DEVICE_SELECT_SUPPLY_HCS_3300)
            {
                 power_supply_hcs_3300.fun_HCS_3300_on();
            }
            return 0;
        }




        #endregion
        #region "PROGRAM COMMON -- TIME  "

        public int fun_program___function___part_time_calulate()
        {
            endTime_part_program = DateTime.Now;
            duration_part_program = endTime_part_program - startTime_part_program;
            floatDuration_part_program_run = duration_part_program.Seconds + (float)(duration_part_program.Milliseconds) / 1000;
            strDuration_part_program = duration_part_program.Hours.ToString() + " : " + duration_part_program.Minutes.ToString() + " : " + (duration_part_program.Seconds + (float)(duration_part_program.Milliseconds) / 1000).ToString("0.0");

            return 0;
        }
        #endregion


    }
}
