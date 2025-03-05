using System;
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

        //--    OWON,XDM1041,23120418,V4.1.0,3
        public void fun_XDM1041_identifaction()
        {

            if (COMport_connected[COMport_SELECT_MULTIMETER_XDM1041])
            {
                try
                {
                    mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM1041].WriteLine("*IDN?");
                    string ident_readRaw = mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM1041].ReadLine();
                    COMport_device_ident[COMport_SELECT_MULTIMETER_XDM1041] = functions.fun_ascii_only(ident_readRaw);
                    if (ident_readRaw.Contains("XDM1041,23120418")) { COMport_active[COMport_SELECT_MULTIMETER_XDM1041] = true; }
                    else COMport_active[COMport_SELECT_MULTIMETER_XDM1041] = false;
                }
                catch
                {
                    mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM1041].WriteLine("*IDN?");
                    string ident_readRaw = mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM1041].ReadLine();
                    COMport_device_ident[COMport_SELECT_MULTIMETER_XDM1041] = functions.fun_ascii_only(ident_readRaw);
                    if (ident_readRaw.Contains("XDM1041,23120418")) { COMport_active[COMport_SELECT_MULTIMETER_XDM1041] = true; }
                    else COMport_active[COMport_SELECT_MULTIMETER_XDM1041] = false;
                }
            }
        }




    }
}
