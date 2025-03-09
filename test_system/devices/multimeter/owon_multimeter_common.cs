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
        public (funErrorCode, double returnValue) fun_owon_get_range_volt_dc(int selectCOMport)
        {
            double returnValue = 0;
            if (COMport_connected[selectCOMport])
            {
                if (COMport_active[selectCOMport])
                {

                    if (selectCOMport == COMport_SELECT_MULTIMETER_XDM3051)
                    {
                        mainWindow.COMportSerial[selectCOMport].WriteLine("VOLT:DC:RANG?");
                    }
                    // CONF: SCAL: VOLT: DC 50

                    string measureValue = mainWindow.COMportSerial[selectCOMport].ReadLine();
                    returnValue = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(measureValue));

                    strGeneralString = returnValue.ToString();

                    return (funErrorCode.OK, returnValue);

                }
                return (funErrorCode.COM_PORT_ACTIVE, returnValue);
            }
            return (funErrorCode.COM_PORT_NOT_CONNECTED, returnValue);
        }

        public funErrorCode fun_owon_set_range_volt_dc(int selectCOMport, double set_range)
        {
            if (COMport_connected[selectCOMport])
            {
                if (COMport_active[selectCOMport])
                {
                    string send_value = set_range.ToString();
                    send_value = send_value.Replace(",", ".");
                     mainWindow.COMportSerial[selectCOMport].WriteLine("CONF:VOLT:DC "+ send_value);
                     return (funErrorCode.OK);
                }
                return (funErrorCode.COM_PORT_ACTIVE);
            }
            return (funErrorCode.COM_PORT_NOT_CONNECTED);
        }



        //=======================================================================================================================
        //=======================================================================================================================
        public (funErrorCode, double returnValue) fun_owon_measure(int selectCOMport)
        {
            double returnValue = 0;
            if (COMport_connected[selectCOMport])
            {
                if (COMport_active[selectCOMport])
                {
                    try
                    {
                        mainWindow.COMportSerial[selectCOMport].WriteLine("MEAS?");
                        string measureValue = mainWindow.COMportSerial[selectCOMport].ReadLine();
                        returnValue = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(measureValue));
                        return (funErrorCode.OK, returnValue);
                    }
                    catch { return (funErrorCode.ERROR, returnValue); }
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










    }
}
