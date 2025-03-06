using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;


namespace test_system
{

    class owon_multimeter_common
    {
        functions functions = new functions();

        //-- SET RANGE                   write_string = (f'CONF:VOLT:DC {str(set_range)}')  
        //-- GET VOTAGE in RANGE         write_string = (f'VOLT:DC:RANG?')  



        //=======================================================================================================================
        //=======================================================================================================================
        public (funErrorCode, double returnValue) fun_owon_measure(int selectCOMport)
        {
            double returnValue = 0;
            if (COMport_connected[selectCOMport])
            {
                if (COMport_active[selectCOMport])
                {
                    mainWindow.COMportSerial[selectCOMport].WriteLine("MEAS?");
                    string measureValue = mainWindow.COMportSerial[selectCOMport].ReadLine();
                    return (funErrorCode.OK, returnValue);
                }
                return (funErrorCode.COM_PORT_ACTIVE, returnValue);
            }
            return (funErrorCode.COM_PORT_NOT_CONNECTED, returnValue);
        }
        //=======================================================================================================================
        //=======================================================================================================================
        public funErrorCode fun_owon_multimeter_identification(int selectCOMport, string ident_string)
        {
            if (COMport_connected[selectCOMport])
            {
                try
                {
                    mainWindow.COMportSerial[selectCOMport].WriteLine("*IDN?");
                    string ident_readRaw = mainWindow.COMportSerial[selectCOMport].ReadLine();
                    COMport_device_ident[selectCOMport] = functions.fun_ascii_only(ident_readRaw);
                    if (ident_readRaw.Contains(ident_string)) { COMport_active[selectCOMport] = true; }
                    else COMport_active[selectCOMport] = false;
                    return (funErrorCode.OK);
                }
                catch { return funErrorCode.ERROR; }
            }
            return (funErrorCode.ERROR);
        }


        /*
        if (COMport_connected[COMport_SELECT_MULTIMETER_XDM3051])
        {
            mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM3051].WriteLine("*IDN?");
            string ident_readRaw = mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM3051].ReadLine();
            COMport_device_ident[COMport_SELECT_MULTIMETER_XDM3051] = functions.fun_ascii_only(ident_readRaw);
            if (ident_readRaw.Contains("XDM3051,2303195")) { COMport_active[COMport_SELECT_MULTIMETER_XDM3051] = true; }
            else COMport_active[COMport_SELECT_MULTIMETER_XDM3051] = false;
        }
        */








    }
}
