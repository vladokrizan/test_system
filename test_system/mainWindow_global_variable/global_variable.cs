﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_system
{
    internal class global_variable
    {

        public static string strGeneralString = "";



        public static bool complete_device_ET391_read_all_temperature = false;


        #region "Device  variable in konstante"




        #region "POWER SUPPLY ---- KORAD   ---- KA3305P  -----  0-30V 5A  "
        // public static string device_HCS_3300_ident = "";
        public static double KA3305P_out_voltage_1;
        public static double KA3305P_out_current_1;
        public static double KA3305P_out_voltage_2;
        public static double KA3305P_out_current_2;
        public static double KA3305P_out_voltage_serial;
        public static double KA3305P_out_current_serial;
        public static double KA3305P_out_voltage_parallel;
        public static double KA3305P_out_current_parallel;




        #endregion


        #region "POWER SUPPLY ---- MANSON  ---- HS - 3300  -----  1-16V 30A  "
        // public static string device_HCS_3300_ident = "";
        //int receive_lengt
        public static double HSC3300_out_voltage = 0;
        public static double HSC3300_out_current = 0;
        public static string HSC3300_out_status= "";



        #endregion
        #region "POWER SUPPLY ---- RD6006  / RD6024  "

        public static byte intModbusRTUreceiveCRC_numberBytes;
        public static UInt16 intModbusRTUreceiveCRC_calculate;
        public static UInt16 intModbusRTUreceiveCRC_receive;

        //public static UInt16 intModbusRTUreceiveCRC_calculate;
        //public static UInt16 intModbusRTUreceiveCRC_receive;

        public static byte[] receiveByte_modbus = new byte[100];
        public static byte receiveByte_modbus_lenght;

        public static byte modbus_number_register;
        public static byte modbus_register_type;

        public static UInt16[] modbus_register = new UInt16[100];

        public static UInt16 modbus_start_register;
        public static UInt16 modbus_register_number;

        public static byte[] bCOMport_sendLen = new byte[COMport_SELECT_MAXnumber];
        //public static byte[] bCOMport_recLen = new byte[COMport_SELECT_MAXnumber];
        public static byte[,] COMport_sendByte = new byte[COMport_SELECT_MAXnumber, 100];
        //  public static byte[,] COMport_recByte = new byte[COMport_SELECT_MAXnumber, 100];


        public static bool device_RD6006_show_all_measure = false;


        public static double rd6006_setVoltage;
        public static double rd6006_setCurrent;
        public static double rd6006_OutputVoltag;
        public static double rd6006_OutputCurrent;
        public static double rd6006_OutputPower;
        public static double rd6006_InputVoltage;


        public static bool device_RD6024_show_all_measure = false;
        public static double rd6024_setVoltage;
        public static double rd6024_setCurrent;
        public static double rd6024_OutputVoltag;
        public static double rd6024_OutputCurrent;
        public static double rd6024_OutputPower;
        public static double rd6024_InputVoltage;


        #endregion

        #region "East Tester   --- TEMPERATURE METER ET3916-8 "

        public static byte device_ET3916_bytes_to_send = 0;

        public static bool device_ET3916_bytes_command_write = false;
        public static bool device_ET3916_read_model_number = false;
        public static bool device_ET3916_read_all_temperature = false;

        public static byte[] device_ET3916_dataArraySend = new byte[10];
        public static string device_ET3916_model_number = "";
        public static double[] device_ET3916_temperature = new double[10];


        public static bool device_ET3916_read_serial_number = false;
        public static string device_ET3916_serial_number = "";
        public static bool device_ET3916_serial_number_show = false;




        #endregion
        #region "AC METER MAXRIX MPM-1010B"
        //public static bool device_MPM1010B_connected = false;



        public static double device_MPM1010B_voltage = 0;
        public static double device_MPM1010B_current = 0;
        public static double device_MPM1010B_power = 0;
        public static double device_MPM1010B_power_factor = 0;
        public static double device_MPM1010B_freguency = 0;



        public static bool device_MPM1010B_read_all_write = false;
        public static bool device_MPM1010B_read_all_read = false;
        public static bool device_MPM1010B_show_data = false;


        //voltage = get_one_measure_value(1)
        //  current = get_one_measure_value(5)
        //power = get_one_measure_value(9)
        //power_factor = get_one_measure_value(13)
        //      freguency = get_one_measure_value(17)
        #endregion

        #region "OWON  --- multimeter   -----      XDM3051    "
        //public static string device_XDM3051_ident = "";
        public static funErrorCode device_XDM3051_measure_ok;
        public static double device_XDM3051_measure;


        #endregion
        #region "OWON  --- multimeter   -----      XDM2041    "
        //public static string device_XDM1041_ident = "";
        public static funErrorCode device_XDM2041_measure_ok;
        public static double device_XDM2041_measure;



        #endregion
        #region "OWON  --- multimeter   -----      XDM1041    "
        //public static string device_XDM1041_ident = "";
        public static funErrorCode device_XDM1041_measure_ok;
        public static double device_XDM1041_measure;


        #endregion


        #endregion
        #region "COMport variable in konstante"
        //-----------------------------------------------------------------------------------------------------------------------
        //-- COMport variable
        //-----------------------------------------------------------------------------------------------------------------------
        //-- COM port je priključen
        public static bool[] COMport_connected = new bool[COMport_SELECT_MAXnumber];
        //-----------------------------------------------------------------------------------------------------------------------
        //-- COM port je priključen in instrument je prižgan, dobi se ident informacija 
        public static bool[] COMport_active = new bool[COMport_SELECT_MAXnumber];
        //----------------------------------------------------------------------------------------
        // --- COM port - "OWON XDM 3051 - Multimeter"
        public static string[] COMport_name = new string[COMport_SELECT_MAXnumber];
        //----------------------------------------------------------------------------------------
        // --- COM port - COMXX
        public static string[] COMport_port = new string[COMport_SELECT_MAXnumber];
        //----------------------------------------------------------------------------------------
        // --- COM port  Baudrate
        public static UInt32[] COMport_baudRate = new UInt32[COMport_SELECT_MAXnumber];
        //----------------------------------------------------------------------------------------
        // --- COMport - ident string 
        public static string[] COMport_device_ident = new string[COMport_SELECT_MAXnumber];

        //----------------------------------------------------------------------------------------
        // --- COMport - velikost sprejetega paketa 
        public static int[] COMport_receive_lenght = new int[COMport_SELECT_MAXnumber];
        public static string[] COMport_receive_string = new string[COMport_SELECT_MAXnumber];

        //-----------------------------------------------------------------------------------------------------------------------
        //-- izbira posameznih instrumentov 
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_SELECT_MAXnumber = 20;
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_SELECT_MULTIMETER_XDM3051 = 1;
        public const byte COMport_SELECT_MULTIMETER_XDM2041 = 2;
        public const byte COMport_SELECT_MULTIMETER_XDM1041 = 3;
        public const byte COMport_SELECT_TEMPERATURE_ET3916 = 4;
        public const byte COMport_SELECT_AC_METER_MPM_1010B = 5;
        public const byte COMport_SELECT_METER_FREE = 6;
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_SELECT_SUPPLY_KA3305A = 7;
        public const byte COMport_SELECT_SUPPLY_HCS_3300 = 8;
        //-----------------------------------------------------------------------------------------------------------------------
        //-- NE SME SE SPREMENITI ZARADI RX INTERRUPT FUNKCIJE 
        public const byte COMport_SELECT_SUPPLY_RD6006 = 9;
        public const byte COMport_SELECT_SUPPLY_RD6024 = 10;
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_SELECT_SUPPLY_FREE = 11;
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_SELECT_LOAD_KEL103 = 12;

        //-----------------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------------
        //-- DC multimetrer  
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_multimeter_name_XDM3051 = "OWON XDM 3051 - Multimeter";
        public const string strCOMport_multimeter_VID_XDM3051 = "0403";
        public const string strCOMport_multimeter_PID_XDM3051 = "6015";
        public const string strCOMport_multimeter_serial_XDM3051 = "D30F6JOX";
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_multimeter_name_XDM2041 = "OWON XDM 2041 - Multimeter";
        public const string strCOMport_multimeter_VID_XDM2041 = "0403";
        public const string strCOMport_multimeter_PID_XDM2041 = "6015";
        public const string strCOMport_multimeter_serial_XDM2041 = "D30F6HTE";


        //COM26 FTDIBUS\VID_0403+PID_6015+D30F6HTEA\0000

        //\VID_1A86&PID_7523\7&25495295&0&2
        //COM22 USB\VID_1A86&PID_7523\7&25495295&0&2
        //COM22 USB\VID_1A86&PID_7523\7&25495295&0&2

        //COM24 USB\VID_1A86&PID_7523\7&25D67E33&0&2
        
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_multimeter_name_XDM1041 = "OWON XDM 1041 - Multimeter";
        public const string strCOMport_multimeter_VID_XDM1041 = "1A86";
        public const string strCOMport_multimeter_PID_XDM1041 = "7523";
        public const string strCOMport_multimeter_serial_XDM1041 = "334BB3D1";
        //-----------------------------------------------------------------------------------------------------------------------
        //-- POWER SUPPLY 
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_supply_name_KA3305A = "KORAD KA3305A - Power supply";
        public const string strCOMport_supply_VID_KA3305A = "0416";
        public const string strCOMport_supply_PID_KA3305A = "5011";
        public const string strCOMport_supply_serial_KA3305A = "003204450454";
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_supply_name_RD6024 = "RIDEN RD6024 - Power Supply";
        public const string strCOMport_supply_VID_RD6024 = "10C4";
        public const string strCOMport_supply_PID_RD6024 = "EA60";
        public const string strCOMport_supply_serial_RD6024 = "123456";
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_supply_name_RD6006 = "RIDEN RD6006 - Power Supply";
        public const string strCOMport_supply_VID_RD6006 = "0403";
        public const string strCOMport_supply_PID_RD6006 = "6001";
        public const string strCOMport_supply_serial_RD6006 = "AI03U0UW";
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_supply_name_HCS_330 = "MANSON: HCS-3300 - Power supply";
        public const string strCOMport_supply_VID_HCS_330 = "10C4";
        public const string strCOMport_supply_PID_HCS_330 = "EA60";
        public const string strCOMport_supply_serial_HCS_330 = "0001";
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        //-- DC POWER LOAD 
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_load_name_KEL103 = "KORAD  KEL103 - DC Load";
        public const string strCOMport_load_VID_KEL103 = "0416";
        public const string strCOMport_load_PID_KEL103 = "5011";
        public const string strCOMport_load_serial_KEL103 = "00006E8D0000";
        //-----------------------------------------------------------------------------------------------------------------------
        //-- TEMPERATURE  METER 
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_name_ET3916 = "East Tester  ET3916-8";
        public const string strCOMport_VID_ET3916 = "1A86";
        public const string strCOMport_PID_ET3916 = "7523";
        public const string strCOMport_serial_ET3916 = "25D67E33";
       //-----------------------------------------------------------------------------------------------------------------------
        //-- AC POWER METER 
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_name_MPM_1010B = "MATRIX  MPM-1010B";
        public const string strCOMport_VID_MPM_1010B = "0403";
        public const string strCOMport_PID_MPM_1010B = "6001";
        public const string strCOMport_serial_MPM_1010B = "A10191L7";





        #endregion



        #region "LOG FILES "

        public static string strSubFolderLog = "log";
        public static string strSubFolderLogApplication = "log_app";


        public static string strExcelSeparator = ";";
        public static string strNewLineSeparator = "\r\n";


        public static string strLogFiles_COMports = "";
        public static string strLogFiles_Devices_ident = "";



        #endregion


        #region "application variable "  



        //-----------------------------------------------------------------------------------------
        //--  function return code   
        //-----------------------------------------------------------------------------------------
        public enum funErrorCode
        {
            OK,                         //--  0: functions runs correct 
            NOK,                        //--  1: functions runs uncorect 
            ERROR,                      //--  2: in functions happen ERROR  
            COM_PORT_NOT_SELECTED,
            COM_PORT_NOT_CONNECTED,
            COM_PORT_ACTIVE,
            UNKNOW                       //--   in unknow state of function   
        }


        //===========================================================================================================================================
        //--  Main window  
        //===========================================================================================================================================
        //-- X and Y position of main window  
        public static int intMainWindow_x;
        public static int intMainWindow_y;

        //-----------------------------------------------------------------------------------------
        //-- začetni točki MDI okna ( baterija, master, update ..... )
        public const int intMainWindow_x_MDI_window = 220;
        public const int intMainWindow_y_MDI_window = 10;
        //-----------------------------------------------------------------------------------------
        //-- velikost MDI okna 
        public const int intMDIwindow_x_size = 1000;
        public const int intMDIwindow_y_size = 600;


        #endregion






    }
}
