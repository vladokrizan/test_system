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



        #region "Device  variable in konstante"

        #region "AC METER MAXRIX MPM-1010B"

        public static double device_MPM1010B_voltage = 0;
        public static double device_MPM1010B_current = 0;
        public static double device_MPM1010B_power = 0;
        public static double device_MPM1010B_power_factor = 0;
        public static double device_MPM1010B_freguency = 0;

        //voltage = get_one_measure_value(1)
        //  current = get_one_measure_value(5)
        //power = get_one_measure_value(9)
        //power_factor = get_one_measure_value(13)
        //      freguency = get_one_measure_value(17)



        #endregion
        #endregion
        #region "COMport variable in konstante"
        //-----------------------------------------------------------------------------------------------------------------------
        //-- COMport variable
        //-----------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        // --- COM port - COMXX
        public static string[] COMport_name = new string[COMport_SELECT_MAXnumber];
        //----------------------------------------------------------------------------------------
        // --- COM port  Baudrate
        public static UInt32[] COMport_baudRate = new UInt32[COMport_SELECT_MAXnumber];





        //-----------------------------------------------------------------------------------------------------------------------
        //-- izbira posameznih instrumentov 
        public const byte COMport_SELECT_MAXnumber = 20;
        public const byte COMport_SELECT_SUPPLY_KA3305A = 1;
        public const byte COMport_SELECT_SUPPLY_RD6024 = 2;
        public const byte COMport_SELECT_SUPPLY_RD6006 = 3;
        public const byte COMport_SELECT_SUPPLY_HCS_330 = 4;
        public const byte COMport_SELECT_LOAD_KEL103 = 5;
        public const byte COMport_SELECT_TEMPERATURE_ET3916 = 6;
        public const byte COMport_SELECT_AC_METER_MPM_1010B = 7;

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
        public const string strCOMport_supply_VID_RD6006 = "0403";
        public const string strCOMport_supply_VID_RD6006 = "0403";
        public const string strCOMport_supply_VID_RD6006 = "0403";
        public const string strCOMport_supply_VID_RD6006 = "0403";
        public const string strCOMport_supply_VID_RD6006 = "0403";
        public const string strCOMport_supply_VID_RD6006 = "0403";
        public const string strCOMport_supply_VID_RD6006 = "0403";
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
        public const string strCOMport_load_name_ET6916 = "East Tester  ET3916-8";
        public const string strCOMport_load_VID_ET6916 = "1A86";
        public const string strCOMport_load_PID_ET6916 = "7523";
        public const string strCOMport_load_serial_ET6916 = "25D67E33";
        //-----------------------------------------------------------------------------------------------------------------------
        //-- AC POWER METER 
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        public const string strCOMport_load_name_MPM_1010B = "MATRIX  MPM-1010B";
        public const string strCOMport_load_VID_MPM_1010B = "0403";
        public const string strCOMport_load_PID_MPM_1010B = "6001";
        public const string strCOMport_load_serial_MPM_1010B = "A10191L7";

        #endregion


    }
}
