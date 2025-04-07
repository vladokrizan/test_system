using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;


namespace test_system
{
    class applicatiuon_function
    {
        write_log_files write_log_files = new write_log_files();


        #region "POWER CONSUMPTION FUNCTIONS "

        //=======================================================================================================================
        /// <summary>
        ///     zapis v datoteko ob začetku aplikavije, se prvič dobijo podatki od SDM220
        /// </summary>
        //=======================================================================================================================
        public void fun_start_consumption_measurement()
        {
            startTime_app = DateTime.Now;
            power_consumption["Date"] = DateTime.Now.ToString("dd.MM.yyyy");
            power_consumption["Time"] = DateTime.Now.ToString("HH:mm:ss");
            power_consumption["State"] = "Start";
            power_consumption["Start total active energy (kwh)"] = SDM220["Total active energy (kwh)"];
            write_log_files.funWriteLogFile_power_consumption();
        }

        //=======================================================================================================================
        /// <summary>
        ///     zapis porabe energije ob koncu aplikacije 
        ///     izračuna se poraba energije za čas delovanja aplikacije 
        ///     izračuna se čas trajanja aplikacije 
        /// </summary>
        //=======================================================================================================================
        public void fun_end_consumption_measurement()
        {
            power_consumption["Date"] = DateTime.Now.ToString("dd.MM.yyyy");
            power_consumption["Time"] = DateTime.Now.ToString("HH:mm:ss");
            power_consumption["State"] = "End";
            //-------------------------------------------------------------------------------------------------------------------
            //-- energija ob začetku aplikacije 
            start_active_energy = Convert.ToDouble(power_consumption["Start total active energy (kwh)"]);
            //-- energija ob koncu aplikacije 
            power_consumption["End total active energy (kwh)"] = SDM220["Total active energy (kwh)"];
            end_active_energy = Convert.ToDouble(power_consumption["End total active energy (kwh)"]);
            //-- poraba energije za čas delovanja aplikacije 
            power_consumption["Duration total active energy (kwh)"] = (end_active_energy - start_active_energy).ToString("0.000");
            //-------------------------------------------------------------------------------------------------------------------
            //-- trajanje aplikacije 
            endTime_app = DateTime.Now;
            duration_app = endTime_app - startTime_app;
            strDuration_app = duration_app.Hours.ToString() + " : " + duration_app.Minutes.ToString() + " : " + (duration_app.Seconds + (float)(duration_app.Milliseconds) / 1000).ToString("0.0");
            power_consumption["App Duration (hour:min:sec)"] = strDuration_app;
            //-------------------------------------------------------------------------------------------------------------------
            write_log_files.funWriteLogFile_power_consumption();
        }

        #endregion




    }
}
