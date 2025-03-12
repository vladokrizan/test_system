using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;


namespace test_system
{
    class program_20
    {

        //-----------------------------------------------------------------------------------------------------------------------
        //--  Test USB battery pack, BMS je že vgrajen in ne moremo vplivati na njegovo delovanje
        //--    pack sam izklopi charge in discharge
        public const string program20_01 = "USB battery pack";

        //-----------------------------------------------------------------------------------------------------------------------
        //-- trenutno izvajan program
        public static string program20_name_current = "";

        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        //---- števvilka trenutno izvajanega programa    
        //public static int program20_select_current = 0;
        //-----------------------------------------------------------------------------------------------------------------------
        public const int program20_USB_PACK = 1;

        //-----------------------------------------------------------------------------------------------------------------------
        //-- ime log datoteke   
        public static string strLogFiles_program20 = "";



        //-----------------------------------------------------------------------------------------------------------------------
        //-- charge / discharge 
        //-----------------------------------------------------------------------------------------------------------------------
        //-- teče charge cikel
        public static bool blnCharge = false;
        public static bool blnCharge_start = false;
        //-----------------------------------------------------------------------------------------------------------------------
        //-- TRUE, ko je napajalnik vklopljen   
        //public static bool blnCharge_supply_on = false;
        //public static bool blnCharge_supply_on_start = false;

        //------------------------------------------------------------------------------------------
        //--charge -- cutoff current ( A )  -- konec charge  
        public static double chargeOff_cuttOFF_current = 0.1;
        //public static int  chargeOff_cuttOFF_current_counter ;
          
        //------------------------------------------------------------------------------------------
        //-- Čas po charge, preden gre v discharge cikel ( sekunde )
        public static UInt32 chargeOff_to_discharge_time =  5 * 60;

        //-----------------------------------------------------------------------------------------------------------------------
        public static bool blnDischarge = false;
        public static bool blnDischarge_start = false;
        public static bool blnDischarge_run = false;
        public static bool blnDischarge_run_start = false;
        public static bool blnDischarge_start_wait = false;
        public static int intDischarge_start_wait_time = 0;
        //--     cas preden začne z praznjenjem
        public static int intDischarge_start_wait_time_set = 0;
        //-----------------------------------------------------------------------------------------------------------------------
        public static bool blnDischarge_run_stop = false;

        //-- TRUE, ko je breme vklopljeno 
        //public static bool load_on = false;
        //public static bool load_on_start = false;

        //-----------------------------------------------------------------------------------------------------------------------
        //-- discharge cutoff voltage -- konec discharge   2,5V
        public static double dischargeOff_cuttOFF_voltage = 3.0;
       public static int  dischargeOff_cuttOFF_voltage_counter = 0;
        //-----------------------------------------------------------------------------------------------------------------------
        //--  discharge LOAD current ( A )
        public static double discharge_load_current = 2.0;




        //-----------------------------------------------------------------------------------------------------------------------

        public static double floatBatteryCurve_AmperSecond;
        public static double floatBatteryCurve_AmperHour;

        public static double floatBatteryCurve_WSecond;
        public static double floatBatteryCurve_WHour;



        /*

                #region "variable  "


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

                */




    }
}
