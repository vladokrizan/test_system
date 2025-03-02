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

        //--    OWON,XDM1041,23120418,V4.1.0,3
        public void fun_XDM1041_identifaction()
        {
            try
            {
                mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM1041].WriteLine("*IDN?");
                COMport_device_ident[COMport_SELECT_MULTIMETER_XDM1041] = mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM1041].ReadLine();
            }
            catch {
                mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM1041].WriteLine("*IDN?");
                COMport_device_ident[COMport_SELECT_MULTIMETER_XDM1041] = mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM1041].ReadLine();

            }
        }



    }
}
