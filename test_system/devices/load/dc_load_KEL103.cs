using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;


namespace test_system
{
    internal class dc_load_KEL103
    {
        functions functions = new functions();


        //--    KORAD-KEL103 V3.30 SN:00022116
        public void fun_KEL103_identifaction()
        {
            mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine("*IDN?");
            string ident_readRaw = mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].ReadLine();
            COMport_device_ident[COMport_SELECT_LOAD_KEL103] = functions.fun_ascii_only(ident_readRaw);
            //COMport_device_ident[COMport_SELECT_LOAD_KEL103] = mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].ReadLine();
        }

    }
}
