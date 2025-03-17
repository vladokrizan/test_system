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


        modbus_functions modbus_functions = new modbus_functions();

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



        private double get_one_data(double get_data, UInt16 next_modus_reguest)
        {
            double returnValue = get_data;
            modbus_functions.funModbusRTU_send_request_read_function_4(5, next_modus_reguest, 2, COMport_SDM220);
            return returnValue;
        }





        public funReturnCodeCOMport funModbusRTU_SDM220_receive_one_data()
        {
            byte[] read_buffer = new byte[100];
            read_buffer[3] = receiveByte_modbus[COMport_SDM220, 3];
            read_buffer[2] = receiveByte_modbus[COMport_SDM220, 4];
            read_buffer[1] = receiveByte_modbus[COMport_SDM220, 5];
            read_buffer[0] = receiveByte_modbus[COMport_SDM220, 6];
            Double float_number = System.BitConverter.ToSingle(read_buffer, 0);

            strGeneralString = "SDM2200  " + receiveByte_modbus_lenght.ToString() + "   start " + modbus_start_register.ToString() + "    Reg " + modbus_register_number.ToString() + "   Type " + modbus_register_type.ToString() + "    " + modbus_register[0].ToString("X") + " " + modbus_register[0].ToString() + " " + modbus_register[1].ToString("X") + "    " + float_number.ToString();

            switch (modbus_start_register)
            {
                //case SDM220_REGISTER_VOLTAGE: { SDM220_voltage = float_number; modbus_functions.funModbusRTU_send_request_read_function_4(5, SDM220_REGISTER_CURRENT, 2, COMport_SDM220); } break;
                //case SDM220_REGISTER_CURRENT: { SDM220_Current = float_number; modbus_functions.funModbusRTU_send_request_read_function_4(5, SDM220_REGISTER_ACTIVE_POWER, 2, COMport_SDM220); } break;
                //case SDM220_REGISTER_ACTIVE_POWER: { SDM220_Active_power = float_number; modbus_functions.funModbusRTU_send_request_read_function_4(5, SDM220_REGISTER_APPARENT_POWER, 2, COMport_SDM220); } break;
                //case SDM220_REGISTER_APPARENT_POWER: { SDM220_Apparent_power = float_number; modbus_functions.funModbusRTU_send_request_read_function_4(5, SDM220_REGISTER_Reactive_POWER, 2, COMport_SDM220); } break;
                //case SDM220_REGISTER_Reactive_POWER: { SDM220_Reactive_power = float_number; modbus_functions.funModbusRTU_send_request_read_function_4(5, SDM220_REGISTER_Power_factor, 2, COMport_SDM220); } break;
                //case SDM220_REGISTER_Power_factor: { SDM220_Power_factor = float_number; modbus_functions.funModbusRTU_send_request_read_function_4(5, SDM220_REGISTER_Phase_angle, 2, COMport_SDM220); } break;
                //case SDM220_REGISTER_Phase_angle: { SDM220_Phase_angle = float_number; modbus_functions.funModbusRTU_send_request_read_function_4(5, SDM220_REGISTER_Frequency, 2, COMport_SDM220); } break;
                //case SDM220_REGISTER_Frequency: { SDM220_Frequency = float_number; modbus_functions.funModbusRTU_send_request_read_function_4(5, SDM220_REGISTER_Import_active_energy, 2, COMport_SDM220); } break;
                //case SDM220_REGISTER_Import_active_energy: { SDM220_Import_active_energy = float_number; modbus_functions.funModbusRTU_send_request_read_function_4(5, SDM220_REGISTER_Export_active_energy, 2, COMport_SDM220); } break;
                //case SDM220_REGISTER_Export_active_energy: { SDM220_Export_active_energy = float_number; modbus_functions.funModbusRTU_send_request_read_function_4(5, SDM220_REGISTER_Import_reactive_energy, 2, COMport_SDM220); } break;
                //case SDM220_REGISTER_Import_reactive_energy: { SDM220_Import_reactive_energy = float_number; modbus_functions.funModbusRTU_send_request_read_function_4(5, SDM220_REGISTER_Export_reactive_energy, 2, COMport_SDM220); } break;
                //case SDM220_REGISTER_Export_reactive_energy: { SDM220_Export_reactive_energy = float_number; modbus_functions.funModbusRTU_send_request_read_function_4(5, SDM220_REGISTER_Total_active_energy, 2, COMport_SDM220); } break;
                //case SDM220_REGISTER_Total_active_energy: { SDM220_Total_active_energy = float_number; modbus_functions.funModbusRTU_send_request_read_function_4(5, SDM220_REGISTER_Total_reactive_energy, 2, COMport_SDM220); } break;
                //case SDM220_REGISTER_Total_reactive_energy: { SDM220_Total_reactive_energy = float_number; } break;

                case SDM220_REGISTER_VOLTAGE: { SDM220_voltage = get_one_data(float_number, SDM220_REGISTER_CURRENT); } break;
                case SDM220_REGISTER_CURRENT: { SDM220_Current = get_one_data(float_number, SDM220_REGISTER_ACTIVE_POWER); } break;
                case SDM220_REGISTER_ACTIVE_POWER: { SDM220_Active_power = get_one_data(float_number, SDM220_REGISTER_APPARENT_POWER); } break;
                case SDM220_REGISTER_APPARENT_POWER: { SDM220_Apparent_power = get_one_data(float_number, SDM220_REGISTER_Reactive_POWER); } break;
                case SDM220_REGISTER_Reactive_POWER: { SDM220_Reactive_power = get_one_data(float_number, SDM220_REGISTER_Power_factor); } break;
                case SDM220_REGISTER_Power_factor: { SDM220_Power_factor = get_one_data(float_number, SDM220_REGISTER_Phase_angle); } break;
                case SDM220_REGISTER_Phase_angle: { SDM220_Phase_angle = get_one_data(float_number, SDM220_REGISTER_Frequency); } break;
                case SDM220_REGISTER_Frequency: { SDM220_Frequency = get_one_data(float_number, SDM220_REGISTER_Import_active_energy); } break;
                case SDM220_REGISTER_Import_active_energy: { SDM220_Import_active_energy = get_one_data(float_number, SDM220_REGISTER_Export_active_energy); } break;
                case SDM220_REGISTER_Export_active_energy: { SDM220_Export_active_energy = get_one_data(float_number, SDM220_REGISTER_Import_reactive_energy); } break;
                case SDM220_REGISTER_Import_reactive_energy: { SDM220_Import_reactive_energy = get_one_data(float_number, SDM220_REGISTER_Export_reactive_energy); } break;
                case SDM220_REGISTER_Export_reactive_energy: { SDM220_Export_reactive_energy = get_one_data(float_number, SDM220_REGISTER_Total_active_energy); } break;
                case SDM220_REGISTER_Total_active_energy: { SDM220_Total_active_energy = get_one_data(float_number, SDM220_REGISTER_Total_reactive_energy); } break;
                case SDM220_REGISTER_Total_reactive_energy: { SDM220_Total_reactive_energy = float_number; ; } break;
               default: break;
            }
            return (funReturnCodeCOMport.OK);
        }
    }
}

