using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;

namespace test_system
{
    internal class multimeter_XDM2041
    {
        functions functions = new functions();
        owon_multimeter_common owon_multimeter_common = new owon_multimeter_common();
        //=======================================================================================================================
        //=======================================================================================================================
        public void fun_XDM2041_measure()
        {
            var (returnState, returnValue) = owon_multimeter_common.fun_owon_measure(COMport_SELECT_MULTIMETER_XDM2041);
            device_XDM2041_measure_ok = returnState;
            if (returnState == funReturnCodeCOMport.OK) device_XDM2041_measure = returnValue;
       }


        //--    OWON,XDM2041,24470254,V3.3.0,3
        public void fun_XDM2041_identifaction()
        {
            owon_multimeter_common.fun_owon_multimeter_identification(COMport_SELECT_MULTIMETER_XDM2041, "XDM2041,24470254");
        }





    }
}
