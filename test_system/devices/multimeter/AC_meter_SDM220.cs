using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using test_system;
using static test_system.global_variable;

namespace test_system
{
    class AC_meter_SDM220
    {

        //-----------------------------------------------------------------------------------------------------------------------
        write_log_files write_log_files = new write_log_files();
        applicatiuon_function applicatiuon_function = new applicatiuon_function();
        modbus modbus_functions = new modbus();
        //-----------------------------------------------------------------------------------------------------------------------
        //--    0	  Voltage V  single
        //--    6	  Current Amps  single
        //--    12	Active power   Watts single
        //--    18	Apparent power VoltAmps single
        //--    24	Reactive power VAr single
        //--    30	Power factor   None single
        //--    36	Phase angle Degree single
        //--    70	Frequency Hz single
        //--    72	Import active energy kwh   single
        //--    74	Export active energy kwh   single
        //--    76	Import reactive energy kvarh single
        //--    78	Export reactive energy kvarh single
        //--    342	Total active energy kwh   single
        //--    344	Total reactive energy kvarh single
        public const int SDM220_REGISTER_VOLTAGE = 0;
        public const int SDM220_REGISTER_CURRENT = 6;
        public const int SDM220_REGISTER_ACTIVE_POWER = 12;
        public const int SDM220_REGISTER_APPARENT_POWER = 18;
        public const int SDM220_REGISTER_Reactive_POWER = 24;
        public const int SDM220_REGISTER_Power_factor = 30;
        public const int SDM220_REGISTER_Phase_angle = 36;
        public const int SDM220_REGISTER_Frequency = 70;
        public const int SDM220_REGISTER_Import_active_energy = 72;
        public const int SDM220_REGISTER_Export_active_energy = 74;
        public const int SDM220_REGISTER_Import_reactive_energy = 76;
        public const int SDM220_REGISTER_Export_reactive_energy = 78;
        public const int SDM220_REGISTER_Total_active_energy = 342;
        public const int SDM220_REGISTER_Total_reactive_energy = 344;

        //=======================================================================================================================
        /// <summary>
        ///   pošiljanje MODBUS paketa za naslednji podatek  
        /// </summary>
        /// <param name="get_data"> </param>
        /// <param name="dictionary_name"></param>
        ///     double vrednost, samo vrne
        ///     in zapiše v log dictionary
        /// <param name="next_modus_reguest">
        ///     pošlje se modbus paket za naslednji podatek 
        /// </param>
        /// <returns></returns>
        //=======================================================================================================================
        private double get_one_data(double get_data, string dictionary_name, UInt16 next_modus_reguest)
        {
            double returnValue = get_data;
            SDM220[dictionary_name] = get_data.ToString("0.000");
            modbus_functions.funModbusRTU_send_request_read_function_4(5, next_modus_reguest, 2, COMport_SDM220);
            return returnValue;
        }
        //=======================================================================================================================
        /// <summary>
        ///  en podatek iz SDM220 -- 4 byti se pretvorijo v en float     
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        public funReturnCode funModbusRTU_SDM220_receive_one_data()
        {
            //-------------------------------------------------------------------------------------------------------------------
            //-- modbus sprejeti byti, iz štirih bytov se izračuna en float 
            byte[] read_buffer = new byte[10];
            read_buffer[3] = receiveByte_modbus[COMport_SDM220, 3];
            read_buffer[2] = receiveByte_modbus[COMport_SDM220, 4];
            read_buffer[1] = receiveByte_modbus[COMport_SDM220, 5];
            read_buffer[0] = receiveByte_modbus[COMport_SDM220, 6];
            Double float_number = System.BitConverter.ToSingle(read_buffer, 0);
            //-------------------------------------------------------------------------------------------------------------------
            //-- float podatek se postavi v ustrezen log podatek 
            switch (modbus_start_register_send)
            {
                case SDM220_REGISTER_VOLTAGE: { SDM220_voltage = get_one_data(float_number, "Voltage (V)", SDM220_REGISTER_CURRENT); } break;
                case SDM220_REGISTER_CURRENT: { SDM220_current = get_one_data(float_number, "Current (A)", SDM220_REGISTER_ACTIVE_POWER); } break;
                case SDM220_REGISTER_ACTIVE_POWER: { SDM220_active_power = get_one_data(float_number, "Active power (W)", SDM220_REGISTER_APPARENT_POWER); } break;
                case SDM220_REGISTER_APPARENT_POWER: { SDM220_apparent_power = get_one_data(float_number, "Apparent power (VA)", SDM220_REGISTER_Reactive_POWER); } break;
                case SDM220_REGISTER_Reactive_POWER: { SDM220_reactive_power = get_one_data(float_number, "Reactive power (VAR)", SDM220_REGISTER_Power_factor); } break;
                case SDM220_REGISTER_Power_factor: { SDM220_power_factor = get_one_data(float_number, "Power factor", SDM220_REGISTER_Phase_angle); } break;
                case SDM220_REGISTER_Phase_angle: { SDM220_phase_angle = get_one_data(float_number, "Phase angle (Degree)", SDM220_REGISTER_Frequency); } break;
                case SDM220_REGISTER_Frequency: { SDM220_frequency = get_one_data(float_number, "Frequency (Hz)", SDM220_REGISTER_Import_active_energy); } break;
                case SDM220_REGISTER_Import_active_energy: { SDM220_import_active_energy = get_one_data(float_number, "Import active energy (kwh)", SDM220_REGISTER_Export_active_energy); } break;
                case SDM220_REGISTER_Export_active_energy: { SDM220_export_active_energy = get_one_data(float_number, "Export active energy (kwh)", SDM220_REGISTER_Import_reactive_energy); } break;
                case SDM220_REGISTER_Import_reactive_energy: { SDM220_import_reactive_energy = get_one_data(float_number, "Import reactive energy (kvarh)", SDM220_REGISTER_Export_reactive_energy); } break;
                case SDM220_REGISTER_Export_reactive_energy: { SDM220_export_reactive_energy = get_one_data(float_number, "Export reactive energy (kvarh)", SDM220_REGISTER_Total_active_energy); } break;
                case SDM220_REGISTER_Total_active_energy: { SDM220_total_active_energy = get_one_data(float_number, "Total active energy (kwh)", SDM220_REGISTER_Total_reactive_energy); } break;
                case SDM220_REGISTER_Total_reactive_energy:
                    {
                        dev_active[COMport_SDM220] = true;
                        SDM220["Total reactive energy (kvarh)"] = float_number.ToString("0.000");
                        SDM220_total_reactive_energy = float_number;
                        //-------------------------------------------------------------------------------------------------------
                        //-- preverijo se MIN MAX vrednoasti in vrednost se lahko prikažejo 
                        fun_SDM220_calculatee_search_min_max();
                        SDM220_data_show = true;
                        //-------------------------------------------------------------------------------------------------------
                        //-- začetni podatki merilnika energije 
                        if (SDM220_data_start)
                        {
                            SDM220_data_start = false;
                            applicatiuon_function.fun_start_consumption_measurement();
                            SDM220_data_continue_read = true;
                            SDM220_data_continue_read_time_set = 5;
                        }
                        //-------------------------------------------------------------------------------------------------------
                        //-- končni podatki za datoteko  porabe enegije
                        //-- potem main timer konča aplikacijo 
                        if (SDM220_data_stop)
                        {
                            SDM220_data_stop = false;
                            applicatiuon_function.fun_end_consumption_measurement();
                            write_log_files.funWriteFile_application_info("Application stop. Duration: " + strDuration_app);
                            SDM220_application_stop = true;
                        }
                        //-------------------------------------------------------------------------------------------------------
                        write_log_files.funWriteLogFile_SDM220();
                    }
                    break;
                default: break;
            }
            return (funReturnCode.OK);
        }
        //=======================================================================================================================
        /// <summary>
        ///     preverjanaje MIN MAX vrednosti 
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        public funReturnCode fun_SDM220_calculatee_search_min_max()
        {
            if (SDM220_voltage > SDM220_voltage_maximal) { SDM220_voltage_maximal = SDM220_voltage; }
            if (SDM220_voltage < SDM220_voltage_minimal) { SDM220_voltage_minimal = SDM220_voltage; }
            if (SDM220_current > SDM220_current_maximal) { SDM220_current_maximal = SDM220_current; }
            if (SDM220_active_power > SDM220_active_power_maximal) { SDM220_active_power_maximal = SDM220_active_power; }
            if (SDM220_apparent_power > SDM220_apparent_power_maximal) { SDM220_apparent_power_maximal = SDM220_apparent_power; }
            if (SDM220_reactive_power > SDM220_reactive_power_maximal) { SDM220_reactive_power_maximal = SDM220_reactive_power; }
            return (funReturnCode.OK);
        }



    }
}
