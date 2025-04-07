using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;


namespace test_system
{
    class program_10
    {

        #region "Opis programa "
        /*
            napajalnik se nastavi na SET napetost 
            čaka se XX čas 
            izmerijo se vse napetosti ( napajalnik in multimetri )
            napetosti se napišejo v distionary  in dictionars se zapiše v log datoteko 
        */
        #endregion

        public const int program10_delay_after_set_supply = 1;
        public const int program10_LOAD_CURRENT  = 1;


        //public static int program10_load_current = 0;

       // public static int program10_select_supply = 0;


        public static string program10_current_selected_program = "";








        public const string program10_01 = "Supply KA3305P part 1 NO load : Owon multimeters ";
        public const string program10_02 = "Supply KA3305P part 2 NO load : Owon multimeters ";
        public const string program10_03 = "Supply KA3305P serial NO load : Owon multimeters ";
        public const string program10_04 = "Supply KA3305P part 1 Load KEL 103 : Owon multimeters ";
        public const string program10_05 = "Supply KA3305P part 2 Load KEL 103 : Owon multimeters ";
        public const string program10_06 = "Supply KA3305P serial Load KEL 103 : Owon multimeters ";
        public const string program10_07 = "Supply HCS_3300 NO load : Owon multimeters ";
        public const string program10_08 = "Supply HCS_3300 Load KEL 103 : Owon multimeters ";
        public const string program10_09 = "Supply RD6006 NO load : Owon multimeters ";
        public const string program10_10 = "Supply RD6006 Load KEL 103 : Owon multimeters ";
        public const string program10_11 = "Supply RD6024 NO load : Owon multimeters ";
        public const string program10_12 = "Supply RD6024 Load KEL 103 : Owon multimeters ";




     
        //-----------------------------------------------------------------------------------------------------------------------
        //-- v enem koraku se nastavi napajalnik, v naslednjem koraku se preveri stanje napajalnika 
        public static bool program10_set_power_supply = false;




    



        #region "izbira programa, ime log datoteke  "

        //=======================================================================================================================
        //=======================================================================================================================
        public void fun_select_program_log_file_name(string select_progra)
        {

            program_select_supply = 0;
            program_select_load = 0;
            //program10_load_current = 0;
            //program10_current_selected_program = comboBox_select_program.Text;
            program10_current_selected_program = select_progra;

            //--public const string program10_01 = "Supply KA3305P part 1 NO load : Owon multimeters ";
            if (program10_current_selected_program.Equals(program10_01, StringComparison.Ordinal))
            {
                program_select_supply = DEVICE_SELECT_SUPPLY_KA3305P;
            }
            //--public const string program10_02 = "Supply KA3305P part 2 NO load : Owon multimeters ";
            else if (program10_current_selected_program.Equals(program10_02, StringComparison.Ordinal))
            {
                program_select_supply = DEVICE_SELECT_SUPPLY_KA3305P;
            }
            //--public const string program10_03 = "Supply KA3305P serial NO load : Owon multimeters ";
            else if (program10_current_selected_program.Equals(program10_03, StringComparison.Ordinal))
            {
                program_select_supply = DEVICE_SELECT_SUPPLY_KA3305P;
            }
            //--public const string program10_04 = "Supply KA3305P part 1 Load KEL 103 : Owon multimeters ";
            else if (program10_current_selected_program.Equals(program10_04, StringComparison.Ordinal))
            {
                program_select_supply = DEVICE_SELECT_SUPPLY_KA3305P;
                program_select_load = program10_LOAD_CURRENT;

            }
            //--public const string program10_05 = "Supply KA3305P part 2 Load KEL 103 : Owon multimeters ";
            else if (program10_current_selected_program.Equals(program10_05, StringComparison.Ordinal))
            {
                program_select_supply = DEVICE_SELECT_SUPPLY_KA3305P;
            }
            //--public const string program10_06 = "Supply KA3305P serial Load KEL 103 : Owon multimeters ";
            else if (program10_current_selected_program.Equals(program10_06, StringComparison.Ordinal))
            {
                program_select_supply = DEVICE_SELECT_SUPPLY_KA3305P;
            }
            //--public const string program10_07 = "Supply HCS_3300 NO load : Owon multimeters ";
            else if (program10_current_selected_program.Equals(program10_07, StringComparison.Ordinal))
            {
                program_select_supply = DEVICE_SELECT_SUPPLY_HCS_3300;
            }
            //--public const string program10_08 = "Supply HCS_3300 Load KEL 103 : Owon multimeters ";
            else if (program10_current_selected_program.Equals(program10_08, StringComparison.Ordinal))
            {
                program_select_supply = DEVICE_SELECT_SUPPLY_HCS_3300;
                program_select_load = program10_LOAD_CURRENT;
            }
            //--public const string program10_09 = "Supply RD6006 NO load : Owon multimeters ";
            else if (program10_current_selected_program.Equals(program10_09, StringComparison.Ordinal))
            {
                program_select_supply = DEVICE_SELECT_SUPPLY_KA3305P;
            }
            //--public const string program10_10 = "Supply RD6006 Load KEL 103 : Owon multimeters ";
            else if (program10_current_selected_program.Equals(program10_10, StringComparison.Ordinal))
            {
                program_select_supply = DEVICE_SELECT_SUPPLY_KA3305P;
            }
            //--public const string program10_11 = "Supply RD6024 NO load : Owon multimeters ";
            else if (program10_current_selected_program.Equals(program10_11, StringComparison.Ordinal))
            {
                program_select_supply = DEVICE_SELECT_SUPPLY_KA3305P;
            }
            //--public const string program10_12 = "Supply RD6024 Load KEL 103 : Owon multimeters ";
            else if (program10_current_selected_program.Equals(program10_12, StringComparison.Ordinal))
            {
                program_select_supply = DEVICE_SELECT_SUPPLY_KA3305P;
            }
            //-------------------------------------------------------------------------------------------------------------------   
            //-- ime log datoteke   
            string[] comboBoxParts = program10_current_selected_program.Split(':');
            strLogFiles_program = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_10_" + program10_current_selected_program + "_delay_" + program10_delay_after_set_supply.ToString() + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";

        }

        #endregion











    }
}
