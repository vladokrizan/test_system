using System;
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
        public static double KA3305P_out_voltage_1;
        public static double KA3305P_out_current_1;
        public static double KA3305P_out_voltage_2;
        public static double KA3305P_out_current_2;
        // public static double KA3305P_out_voltage_serial;
        // public static double KA3305P_out_current_serial;
        // public static double KA3305P_out_voltage_parallel;
        // public static double KA3305P_out_current_parallel;


        public static double KA3305P_get_set_voltage_1;
        public static double KA3305P_get_set_current_1;
        public static double KA3305P_get_set_voltage_2;
        public static double KA3305P_get_set_current_2;

        public static byte KA3305P_status;
        public static string KA3305P_status_bit0_CH1_mode;
        public static string KA3305P_status_bit0_CH2_mode;
        public static string KA3305P_status_bit23_tracking;
        public static string KA3305P_status_bit4_beep;
        public static string KA3305P_status_bit5_lock;
        public static string KA3305P_status_bit6_on_offk;

        ///         0       CH1 0=CC mode, 1=CV mode
        ///         1       CH2 0=CC mode, 1=CV mode
        ///         2,3,    Tracking  00=Independent, 01=Tracking series, 11=Tracking parallel
        ///         4,      Beep      0=Off, 1=On
        ///         5       Lock      0=Lock, 1=Unlock
        ///         6       Output 0=Off, 1=On
        ///         7       N/AN/A


        #endregion


        #region "POWER SUPPLY ---- MANSON  ---- HCS - 3300  -----  1-16V 30A  "
        public static double HCS_3300_out_voltage = 0;
        public static double HCS_3300_out_current = 0;
        public static string HCS_3300_out_status = "";
        public static double HCS_3300_get_set_voltage = 0;
        public static double HCS_3300_get_set_current = 0;
        //public static string HSC3300_set_set_voltage = "";
        //public static string HSC3300_set_set_current = "";
        #endregion
        #region "POWER SUPPLY ---- RD6006  / RD6024  "

        //public static byte intModbusRTUreceiveCRC_numberBytes;
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


        public static bool device_RD6006_all_device_ident = false;
        public static UInt16 rd6006_Signature;
        public static UInt16 rd6006_Serial_number;
        public static UInt16 rd6006_Firmware_version;

        public static bool device_RD6024_all_device_ident = false;
        public static UInt16 rd6024_Signature;
        public static UInt16 rd6024_Serial_number;
        public static UInt16 rd6024_Firmware_version;


        //--#0000 0xEA 0x9E RO Signature = 60062
        //--#0001 0 RO
        //--#0002 0x19 0x40 RO Serial number (6464)
        //--#0003 0x00 0x80 RO Firmware version (1.28) x 100



        #endregion

        #region "East Tester   --- TEMPERATURE METER ET3916-8 "
        //-----------------------------------------------------------------------------------------------------------------------
        //-- število bytov, ki se bo poslalo na napravo ET3916
        public static byte device_ET3916_bytes_to_send = 0;
        //-----------------------------------------------------------------------------------------------------------------------
        //-- paket, ki pošlje na napravo ET3916 
        public static byte[] device_ET3916_dataArraySend = new byte[10];
        //-----------------------------------------------------------------------------------------------------------------------
        //-- pripravljene je paketke za pošiljanje na napravo
        //--  timer pošlje paket na napravo 
        //--  Čez 100ms se preveri če je prišel odgovor
        public static bool device_ET3916_bytes_command_write = false;
        //-----------------------------------------------------------------------------------------------------------------------
        public static string device_ET3916_serial_number = "";
        //-- po poslanem paketu se preveri če je prišel odgovor za serial number
        public static bool device_ET3916_read_serial_number = false;
        //-- prikaže se serial number v ALL_DEVICE oknu
        public static bool device_ET3916_serial_number_show = false;
        //-----------------------------------------------------------------------------------------------------------------------
        public static bool device_ET3916_read_model_number = false;
        public static string device_ET3916_model_number = "";
        //-----------------------------------------------------------------------------------------------------------------------
        public static bool device_ET3916_read_all_temperature = false;
        public static bool device_ET3916_read_all_temperature_by_test = false;

        public static double[] device_ET3916_temperature = new double[10];




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


        #endregion

        #region "OWON  --- multimeter   -----      owon XDM 3051, 2041, 1041    "
  
        public static int device_XDM3051_range_dc_volt;

        #endregion
    
        #region "DC LOAD KORAD KEL 103"

        //-----------------------------------------------------------------------------------------------------------------------
        //--    VOLT|CURR|RES|POW|SHORTDefine the functions:voltage, current,resistor and power
        public const string KEL103_SET_FUN_VOLTAGE = "VOLT";
        public const string KEL103_SET_FUN_CURRENT = "CURR";
        public const string KEL103_SET_FUN_POWER = "POW";
        public const string KEL103_SET_FUN_RESISTANCE = "RES";


        public static double KEL103_voltage = 0;
        public static double KEL103_current = 0;
        public static double KEL103_power = 0;
        public static double KEL103_resistance = 0;

        public static double KEL103_get_set_voltage = 0;
        public static double KEL103_get_set_current = 0;
        public static double KEL103_get_set_power = 0;
        public static double KEL103_get_set_resistance = 0;

        public static double KEL103_set_set_voltage = 0;
        public static double KEL103_set_set_current = 0;
        public static double KEL103_set_set_power = 0;
        public static double KEL103_set_set_resistance = 0;



        #endregion
        #endregion
        #region "COMport variable in konstante"
        //-----------------------------------------------------------------------------------------------------------------------
        //-- COMport variable
        //-----------------------------------------------------------------------------------------------------------------------
        //-- COM port je priključen
        public static bool[] dev_connected = new bool[COMport_SELECT_MAXnumber];
        //-----------------------------------------------------------------------------------------------------------------------
        //-- COM port je priključen in instrument je prižgan, dobi se ident informacija 
        public static bool[] dev_active = new bool[COMport_SELECT_MAXnumber];
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
        public static funReturnCodeCOMport[] dev_meas_state = new funReturnCodeCOMport[COMport_SELECT_MAXnumber];
        public static double[] dev_meas = new double[COMport_SELECT_MAXnumber];
        public static string[] dev_range = new string[COMport_SELECT_MAXnumber];




        //----------------------------------------------------------------------------------------
        // --- COMport - velikost sprejetega paketa 
        public static int[] COMport_receive_lenght = new int[COMport_SELECT_MAXnumber];
        public static string[] COMport_receive_string = new string[COMport_SELECT_MAXnumber];

        //-----------------------------------------------------------------------------------------------------------------------
        //-- izbira posameznih instrumentov 
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_SELECT_MAXnumber = 20;
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_XDM3051 = 1;
        public const byte COMport_XDM2041 = 2;
        public const byte COMport_XDM1041 = 3;
        public const byte COMport_ET3916 = 4;
        public const byte COMport_MPM_1010B = 5;
        public const byte COMport_SELECT_METER_FREE = 6;
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_KA3305A = 7;
        public const byte COMport_HCS_3300 = 8;
        //-----------------------------------------------------------------------------------------------------------------------
        //-- NE SME SE SPREMENITI ZARADI RX INTERRUPT FUNKCIJE 
        public const byte COMport_RD6006 = 9;
        public const byte COMport_RD6024 = 10;
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_SELECT_SUPPLY_FREE = 11;
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_KEL103 = 12;
        //-----------------------------------------------------------------------------------------------------------------------

        public const byte COMport_SDM220 = 15;



        //-----------------------------------------------------------------------------------------------------------------------
        //-- izbira POWER SUPPLY
        public const byte DEVICE_SELECT_SUPPLY_KA3305P = 1;
        public const byte DEVICE_SELECT_SUPPLY_HCS_3300 = 2;
        public const byte DEVICE_SELECT_SUPPLY_RD6006 = 3;
        public const byte DEVICE_SELECT_SUPPLY_RD6024 = 4;
        //-----------------------------------------------------------------------------------------------------------------------
        //-- izbira POWER DC LOAD 
        public const byte DEVICE_SELECT_LOAD_KEL103 = 1;




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


        //--COM27 FTDIBUS\VID_0403+PID_6001+B002DL62A\0000
        public const string strCOMport_name_SDM220 = "EASTRON SDM220";
        public const string strCOMport_VID_SDM220 = "0403";
        public const string strCOMport_PID_SDM220 = "6001";
        public const string strCOMport_serial_SDM220 = "B002DL62";



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
        public enum funReturnCodeCOMport
        {
            OK,                         //--  0: functions runs correct 
            NOK,                        //--  1: functions runs uncorect 
            ERROR,                      //--  2: in functions happen ERROR  
            NOT_CONNECTED,
            NOT_ACTIVE,
            NOT_MEAS,
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
        public const int intMainWindow_x_MDI_window = 150;
        public const int intMainWindow_y_MDI_window = 0;
        //-----------------------------------------------------------------------------------------
        //-- velikost MDI okna 
        public const int intMDIwindow_x_size = 1085;
        public const int intMDIwindow_y_size = 630;


        #endregion


        #region "RUN program variable"

        public static string strLogFiles_program = "";
        public static Dictionary<String, String> program_result_value = new Dictionary<String, String>();

        //-----------------------------------------------------------------------------------------------------------------------
        //-- integer številka trenutno izvaajanega programa 
        public static int program_select_current = 0;
        //-----------------------------------------------------------------------------------------------------------------------
        //-- nova sekunda, program se izvaja vsako sekundo
        public static byte timer_new_second;
        public static byte timer_old_second;
        //-----------------------------------------------------------------------------------------------------------------------
        //-- izbira napajalnika in bremena 
        public static int program_select_supply = 0;
        public static int program_select_load = 0;



        public static bool program_bool_run = false;
        public static bool program_bool_run_start = false;
        public static bool program_bool_run_stop = false;

        //public static int program_int_counter_run = 0;
        //public static int program_int_counter_set = 0;

        public static int program_int_step_time_run = 0;
        public static int program_int_step_time_set = 0;

        //-----------------------------------------------------------------------------------------------------------------------
        public static DateTime startTime_complete_program;
        //public static DateTime endTime_complete_program;
        //public static TimeSpan duration_complete_program;
        //public static double floatDuration_complete_program;
        //public static string strDuration_complete_program;
        //-----------------------------------------------------------------------------------------------------------------------
        public static DateTime startTime_part_program;
        public static DateTime endTime_part_program;
        public static TimeSpan duration_part_program;
        public static double floatDuration_part_program_run;
        public static double floatDuration_part_program_complete;
        public static string strDuration_part_program;


        #endregion




    }
}
