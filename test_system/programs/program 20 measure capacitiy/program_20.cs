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
        //--izpis na label iz drugih classov
        //--    public static System.Windows.Forms.Label[] write_label = new System.Windows.Forms.Label[20];
        public const int PROG20_LABEL_STATUS = 0;
        public const int PROG20_LABEL_1 = 1;
        public const int PROG20_LABEL_2 = 2;
        public const int PROG20_LABEL_3 = 3;
        //-----------------------------------------------------------------------------------------------------------------------
        //--  Test USB battery pack, BMS je že vgrajen in ne moremo vplivati na njegovo delovanje
        //--    pack sam izklopi charge in discharge
        public const string program20_01 = "USB battery pack";
        //-----------------------------------------------------------------------------------------------------------------------
        //-- trenutno izvajan program
        public static string program20_name_current = "";
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        public const int program20_USB_PACK = 1;
        //-----------------------------------------------------------------------------------------------------------------------
        //-- teče charge cikel
        public static bool blnCharge = false;
        public static int intCharge_run_wait_time_set = 0;
        //-----------------------------------------------------------------------------------------------------------------------
        //-- TRUE, ko je napajalnik vklopljen   
        //public static bool blnCharge_supply_on = false;
        //public static bool blnCharge_supply_on_start = false;
        //-----------------------------------------------------------------------------------------------------------------------
        //--charge -- cutoff current ( A )  -- konec charge  
        //public static double chargeOff_cuttOFF_current = 0.1;
        //public static int  chargeOff_cuttOFF_current_counter ;
        //-----------------------------------------------------------------------------------------------------------------------
        //-- Čas po charge, preden gre v discharge cikel ( sekunde )
        //public static UInt32 chargeOff_to_discharge_time = 5 * 60;
        //-----------------------------------------------------------------------------------------------------------------------
        public static bool blnDischarge = false;
        //-----------------------------------------------------------------------------------------------------------------------
        //--     cas preden začne z praznjenjem
        public static int intDischarge_start_wait_time_set = 0;
        //-----------------------------------------------------------------------------------------------------------------------
        public static int charge_end_counter = 0;
        //-- TRUE, ko je breme vklopljeno 
        //public static bool load_on = false;
        //public static bool load_on_start = false;
        //-----------------------------------------------------------------------------------------------------------------------
        //-- discharge cutoff voltage -- konec discharge   2,5V
        //public static double dischargeOff_cuttOFF_voltage = 3.0;
        //public static int dischargeOff_cuttOFF_voltage_counter = 0;
        //-----------------------------------------------------------------------------------------------------------------------
        //--  discharge LOAD current ( A )
        //public static double discharge_load_current = 2.0;
        public static int discharge_end_counter = 0;

        //-----------------------------------------------------------------------------------------------------------------------
        public static double floatBatteryCurve_AmperSecond;
        public static double floatBatteryCurve_AmperHour;

        public static double floatBatteryCurve_WSecond;
        public static double floatBatteryCurve_WHour;

        //=======================================================================================================================
        //=======================================================================================================================
        public int fun_program20___function___calculate_capacitiy(double Voltage, double Current)
        {
            //-------------------------------------------------------------------------------------------------------------------
            //-- izracun kapacitete vsako sekundo 
            double tmpLocalDoubleValue;
            floatBatteryCurve_AmperSecond = floatBatteryCurve_AmperSecond + Math.Abs(Current);
            floatBatteryCurve_AmperHour = floatBatteryCurve_AmperSecond / 3600;
            tmpLocalDoubleValue = Voltage * Math.Abs(Current);
            floatBatteryCurve_WSecond = floatBatteryCurve_WSecond + tmpLocalDoubleValue;
            floatBatteryCurve_WHour = floatBatteryCurve_WSecond / 3600;

            program_result_value.Add("AmperSecond (As) ", floatBatteryCurve_AmperSecond.ToString());
            program_result_value.Add("AmperHour (Ah) ", floatBatteryCurve_AmperHour.ToString());
            program_result_value.Add("WatSecond (Ws) ", floatBatteryCurve_WSecond.ToString());
            program_result_value.Add("WatHour (Wh) ", floatBatteryCurve_WHour.ToString());
            return 0;
        }




    }
}
