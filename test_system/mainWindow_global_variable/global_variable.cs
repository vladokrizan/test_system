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

        #region "POWER SUPPLY ---- MANSON  ---- HS - 3300  -----  1-16V 30A  "
       // public static string device_HCS_3300_ident = "";



        #endregion
        #region "East Tester   --- TEMPERATURE METER ET3916-8 "
 
        public static byte device_ET3916_bytes_to_send = 0;

        public static bool device_ET3916_bytes_command_write= false;
        public static bool device_ET3916_read_model_number = false;
        public static bool device_ET3916_read_all_temperature = false;

        public static byte [] device_ET3916_dataArraySend = new byte[10];
        public static string device_ET3916_model_number = "";
        public static double[] device_ET3916_temperature = new double[10];


        public static bool device_ET3916_read_serial_number = false;
        public static string device_ET3916_serial_number = "";
        public static bool device_ET3916_serial_number_show =false;




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


        //voltage = get_one_measure_value(1)
        //  current = get_one_measure_value(5)
        //power = get_one_measure_value(9)
        //power_factor = get_one_measure_value(13)
        //      freguency = get_one_measure_value(17)
        #endregion

        #region "OWON  --- multimeter   -----      XDM3051    "
        //public static string device_XDM3051_ident = "";


        #endregion

        #region "OWON  --- multimeter   -----      XDM1041    "
        //public static string device_XDM1041_ident = "";


        #endregion


        #endregion
        #region "COMport variable in konstante"
        //-----------------------------------------------------------------------------------------------------------------------
        //-- COMport variable
        //-----------------------------------------------------------------------------------------------------------------------

        public static bool[] COMport_connected = new bool[COMport_SELECT_MAXnumber];

        //----------------------------------------------------------------------------------------
        // --- COM port - COMXX
        public static string[] COMport_name = new string[COMport_SELECT_MAXnumber];
        //----------------------------------------------------------------------------------------
        // --- COM port  Baudrate
        public static UInt32[] COMport_baudRate = new UInt32[COMport_SELECT_MAXnumber];


        //----------------------------------------------------------------------------------------
        // --- COMport - ident string 
        public static string[] COMport_device_ident= new string[COMport_SELECT_MAXnumber];




        //-----------------------------------------------------------------------------------------------------------------------
        //-- izbira posameznih instrumentov 
        public const byte COMport_SELECT_MAXnumber = 20;
        public const byte COMport_SELECT_MULTIMETER_XDM3051 = 1;
        public const byte COMport_SELECT_MULTIMETER_XDM2041 = 2;
        public const byte COMport_SELECT_MULTIMETER_XDM1041 = 3;
        public const byte COMport_SELECT_SUPPLY_KA3305A = 4;
        //-----------------------------------------------------------------------------------------------------------------------
        //-- NE SME SE SPREMENITI ZARADI RX INTERRUPT FUNKCIJE 
        public const byte COMport_SELECT_SUPPLY_RD6006 = 5;
        public const byte COMport_SELECT_SUPPLY_RD6024 = 6;
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_SELECT_SUPPLY_HCS_330 = 7;
        public const byte COMport_SELECT_LOAD_KEL103 = 8;
        public const byte COMport_SELECT_TEMPERATURE_ET3916 = 9;
        public const byte COMport_SELECT_AC_METER_MPM_1010B = 10;

        //-----------------------------------------------------------------------------------------------------------------------
        //-- DC multimetrer  
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_multimeter_name_XDM3051 = "OWON XDM 3051";
        public const string strCOMport_multimeter_VID_XDM3051 = "0403";
        public const string strCOMport_multimeter_PID_XDM3051 = "6015";
        public const string strCOMport_multimeter_serial_XDM3051 = "D30F6JOX";
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_multimeter_name_XDM1041 = "OWON XDM 1041";
        public const string strCOMport_multimeter_VID_XDM1041 = "1A86";
        public const string strCOMport_multimeter_PID_XDM1041 = "7523";
       public const string strCOMport_multimeter_serial_XDM1041 = "334BB3D1";
        //public const string strCOMport_multimeter_serial_XDM1041 = "334BB3D";
        //-----------------------------------------------------------------------------------------------------------------------
        //public const string strCOMport_multimeter_name_XDM1241 = "OWON XDM 1241";
        //public const string strCOMport_multimeter_VID_XDM1241 = "1A86";
        //public const string strCOMport_multimeter_PID_XDM1241 = "7523";
        //public const string strCOMport_multimeter_serial_XDM1241 = "7&334BB3D1&0&4";



        //-----------------------------------------------------------------------------------------------------------------------
        //-- POWER SUPPLY 
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_supply_name_KA3305A = "KORAD KA3305A";
        public const string strCOMport_supply_VID_KA3305A = "0416";
        public const string strCOMport_supply_PID_KA3305A = "5011";
        public const string strCOMport_supply_serial_KA3305A = "003204450454";
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_supply_name_RD6024 = "RIDEN RD6024";
        public const string strCOMport_supply_VID_RD6024 = "10C4";
        public const string strCOMport_supply_PID_RD6024 = "EA60";
        public const string strCOMport_supply_serial_RD6024 = "123456";
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_supply_name_RD6006 = "RIDEN RD6006";
        public const string strCOMport_supply_VID_RD6006 = "0403";
        public const string strCOMport_supply_PID_RD6006 = "6001";
        public const string strCOMport_supply_serial_RD6006 = "AI03U0UW";
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_supply_name_HCS_330 = "MANSON: HCS-330";
        public const string strCOMport_supply_VID_HCS_330 = "10C4";
        public const string strCOMport_supply_PID_HCS_330 = "EA60";
        public const string strCOMport_supply_serial_HCS_330 = "0001";
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        //-- DC POWER LOAD 
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_load_name_KEL103 = "KORAD  KEL103";
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
        //public const string strCOMport_load_serial_ET6916 = " 7&25495295&0&1";
        //public const string strCOMport_load_serial_ET6916 = " 7&25495295&0&1";
        //public const string strCOMport_serial_ET6916 = "7&25495295&0";
        //public const string strCOMport_serial_ET6916 = "25495295";
        //public const string strCOMport_serial_ET6916 = "54";

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
        public static string strExcelSeparator = ";";


        public static string strLogFiles_COMports = "";
        public static string strLogFiles_Devices_ident = "";



        #endregion


        public static byte[] receiveByte_RD6006 = new byte[100];
        public static byte[] receiveByte_RD6024 = new byte[100];


        public static byte[] bCOMport_sendLen = new byte[COMport_SELECT_MAXnumber];
        public static byte[] bCOMport_recLen = new byte[COMport_SELECT_MAXnumber];
        public static byte[,] COMport_sendByte = new byte[COMport_SELECT_MAXnumber, 100];
        public static byte[,] COMport_recByte = new byte[COMport_SELECT_MAXnumber, 100];




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





    }
}
