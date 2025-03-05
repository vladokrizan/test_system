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


        //--    OWON,XDM2041,24470254,V3.3.0,3
        public void fun_XDM2041_identifaction()
        {

            //strGeneralString = "najden tukaj    "+ COMport_connected[COMport_SELECT_MULTIMETER_XDM2041].ToString();


            if (COMport_connected[COMport_SELECT_MULTIMETER_XDM2041])
            {
                mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM2041].WriteLine("*IDN?");
                string ident_readRaw = mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM2041].ReadLine();
                COMport_device_ident[COMport_SELECT_MULTIMETER_XDM2041] = functions.fun_ascii_only(ident_readRaw);

             
                if (ident_readRaw.Contains("XDM2041,24470254")) { COMport_active[COMport_SELECT_MULTIMETER_XDM2041] = true; }
                else COMport_active[COMport_SELECT_MULTIMETER_XDM2041] = false;
            }
        }






        }
    }
