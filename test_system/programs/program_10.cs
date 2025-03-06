using System;
using System.Collections.Generic;
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

        public static string program10_current_selected_program = "";


        public const string program10_01 ="Supply KA3305P part 1 NO load : Owon multimeters ";
        public const string program10_02="Supply KA3305P part 2 NO load : Owon multimeters ";
        public const string program10_03 = "Supply KA3305P serial NO load : Owon multimeters ";
        public const string program10_04 = "Supply HCS_3300 NO load : Owon multimeters ";
        public const string program10_05 = "Supply RD6006 NO load : Owon multimeters ";
        public const string program10_06 ="Supply RD6024 NO load : Owon multimeters ";




        public static string strLogFiles_program10 = "";


        public static Dictionary<String, String> program10_value = new Dictionary<String, String>();








    }
}
