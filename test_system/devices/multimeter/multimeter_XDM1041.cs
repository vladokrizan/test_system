﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;

namespace test_system
{
    internal class multimeter_XDM1041
    {
        functions functions = new functions();
        owon_multimeter_common owon_multimeter_common = new owon_multimeter_common();



        //=======================================================================================================================
        //=======================================================================================================================
        public void fun_XDM1041_measure()
        {
            var (returnState, returnValue) = owon_multimeter_common.fun_owon_measure(COMport_SELECT_MULTIMETER_XDM1041);
            device_XDM1041_measure_ok = returnState;
            if (returnState == funReturnCodeCOMport.OK) device_XDM1041_measure = returnValue;
            else
            {
                (returnState, returnValue) = owon_multimeter_common.fun_owon_measure(COMport_SELECT_MULTIMETER_XDM1041);

                if (returnState == funReturnCodeCOMport.OK) device_XDM1041_measure = returnValue;
                else
                {
                    (returnState, returnValue) = owon_multimeter_common.fun_owon_measure(COMport_SELECT_MULTIMETER_XDM1041);
                }
            }
            device_XDM1041_measure_ok = returnState;
        }


        //--    OWON,XDM1041,23120418,V4.1.0,3
        public void fun_XDM1041_identifaction()
        {
            if (owon_multimeter_common.fun_owon_multimeter_identification(COMport_SELECT_MULTIMETER_XDM1041, "XDM1041,23120418") != funReturnCodeCOMport.OK)
            {
                if (owon_multimeter_common.fun_owon_multimeter_identification(COMport_SELECT_MULTIMETER_XDM1041, "XDM1041,23120418") != funReturnCodeCOMport.OK)
                {
                    owon_multimeter_common.fun_owon_multimeter_identification(COMport_SELECT_MULTIMETER_XDM1041, "XDM1041,23120418");
                }
            }
        }





    }
}
