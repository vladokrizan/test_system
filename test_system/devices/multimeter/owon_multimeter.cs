using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static test_system.global_variable;


namespace test_system
{

    class owon_multimeter
    {
        functions functions = new functions();


        //-- XDM2041
        //--    CONF:CURR:DC
        //--    CONF:VOLT:DC
        //--    CONF:VOLT:DC 500


        //-- SET RANGE                   write_string = (f'CONF:VOLT:DC {str(set_range)}')  
        //-- GET VOTAGE in RANGE         write_string = (f'VOLT:DC:RANG?')  
        public (funReturnCodeCOMport, double returnValue) fun_owon_get_range_volt_dc(int selectCOMport)
        {
            double returnValue = 0;
            if (dev_connected[selectCOMport])
            {
                if (dev_active[selectCOMport])
                {

                    if (selectCOMport == COMport_XDM3051)
                    {
                        mainWindow.COMportSerial[selectCOMport].WriteLine("VOLT:DC:RANG?");
                    }
                    if (selectCOMport == COMport_XDM2041 || selectCOMport == COMport_XDM1041)
                    {
                        mainWindow.COMportSerial[selectCOMport].WriteLine("VOLT:DC:RANG?");
                    }
                    // CONF: SCAL: VOLT: DC 50
                    string measureValue = mainWindow.COMportSerial[selectCOMport].ReadLine();
                    returnValue = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(measureValue));
                    //strGeneralString = returnValue.ToString();
                    return (funReturnCodeCOMport.OK, returnValue);
                }
                else return (funReturnCodeCOMport.NOT_ACTIVE, returnValue);
            }
            else return (funReturnCodeCOMport.NOT_CONNECTED, returnValue);
        }

        public funReturnCodeCOMport fun_owon_set_range_volt_dc(int selectCOMport, double set_range)
        {
            if (dev_connected[selectCOMport])
            {
                if (dev_active[selectCOMport])
                {
                    string send_value = set_range.ToString();
                    send_value = send_value.Replace(",", ".");
                    mainWindow.COMportSerial[selectCOMport].WriteLine("CONF:VOLT:DC " + send_value);
                    return (funReturnCodeCOMport.OK);
                }
                else return (funReturnCodeCOMport.NOT_ACTIVE);
            }
            else return (funReturnCodeCOMport.NOT_CONNECTED);
        }



        //--owon_multimeter_common.fun_owon_set_range_current_dc(COMport_SELECT_MULTIMETER_XDM2041, 0.0005);        500 uA
        //--owon_multimeter_common.fun_owon_set_range_current_dc(COMport_SELECT_MULTIMETER_XDM2041, 0.005);         5 mA
        //--owon_multimeter_common.fun_owon_set_range_current_dc(COMport_SELECT_MULTIMETER_XDM2041, 0.05);          50 mA
        //--owon_multimeter_common.fun_owon_set_range_current_dc(COMport_SELECT_MULTIMETER_XDM2041, 0.5);           500 mA
        //--owon_multimeter_common.fun_owon_set_range_current_dc(COMport_SELECT_MULTIMETER_XDM2041, 5);             5 A
        //--owon_multimeter_common.fun_owon_set_range_current_dc(COMport_SELECT_MULTIMETER_XDM2041, 10);            10 A
        //-----------------------------------------------------------------------------------------------------------------------
        //--owon_multimeter_common.fun_owon_set_range_current_dc(COMport_SELECT_MULTIMETER_XDM1041, 10);            10 A
        //--owon_multimeter_common.fun_owon_set_range_current_dc(COMport_SELECT_MULTIMETER_XDM1041, 5);             5 A
        //--owon_multimeter_common.fun_owon_set_range_current_dc(COMport_SELECT_MULTIMETER_XDM1041, 0.5);           500 mA
        //--owon_multimeter_common.fun_owon_set_range_current_dc(COMport_SELECT_MULTIMETER_XDM1041, 0.0005);        500 uA




        public funReturnCodeCOMport fun_owon_set_range_current_dc(int selectCOMport, double set_range)
        {
            if (dev_connected[selectCOMport])
            {
                if (dev_active[selectCOMport])
                {
                    string send_value = set_range.ToString();
                    send_value = send_value.Replace(",", ".");
                    mainWindow.COMportSerial[selectCOMport].WriteLine("CONF:CURR:DC " + send_value);
                    return (funReturnCodeCOMport.OK);
                }
                else return (funReturnCodeCOMport.NOT_ACTIVE);
            }
            else return (funReturnCodeCOMport.NOT_CONNECTED);
        }
        //=======================================================================================================================
        //=======================================================================================================================

        public void fun_owon_measure(int selectCOMport)
        {

            if (dev_connected[selectCOMport])
            {
                if (dev_active[selectCOMport])
                {
                    try
                    {
                        //mainWindow.COMportSerial[selectCOMport].DiscardInBuffer();
                        mainWindow.COMportSerial[selectCOMport].WriteLine("MEAS?");
                        //if (selectCOMport == COMport_SELECT_MULTIMETER_XDM1041) mainWindow.COMportSerial[selectCOMport].WriteLine("MEAS?");
                        string measureValue = mainWindow.COMportSerial[selectCOMport].ReadLine();
                        dev_meas[selectCOMport] = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(measureValue));
                        dev_meas_state[selectCOMport] = funReturnCodeCOMport.OK;
                    }


                    
                    catch
                    {
                        try
                        {
                            Thread.Sleep(20);
                            //mainWindow.COMportSerial[selectCOMport].DiscardInBuffer();
                            mainWindow.COMportSerial[selectCOMport].WriteLine("MEAS?");
                            string measureValue = mainWindow.COMportSerial[selectCOMport].ReadLine();
                            dev_meas[selectCOMport] = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(measureValue));
                            dev_meas_state[selectCOMport] = funReturnCodeCOMport.OK;
                        }
                        catch
                        {
                            try
                            {
                                Thread.Sleep(20);
                                //mainWindow.COMportSerial[selectCOMport].DiscardInBuffer();
                                mainWindow.COMportSerial[selectCOMport].WriteLine("MEAS?");
                                string measureValue = mainWindow.COMportSerial[selectCOMport].ReadLine();
                                dev_meas[selectCOMport] = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(measureValue));
                                dev_meas_state[selectCOMport] = funReturnCodeCOMport.OK;
                            }
                            catch { dev_meas_state[selectCOMport] = funReturnCodeCOMport.ERROR; }

                        }
                   

                    }
                    

                }
                else dev_meas_state[selectCOMport] = funReturnCodeCOMport.NOT_ACTIVE;
            }
            else dev_meas_state[selectCOMport] = funReturnCodeCOMport.NOT_CONNECTED;
        }
        // public static funReturnCodeCOMport[] device_measure_ok = new funReturnCodeCOMport[COMport_SELECT_MAXnumber];
        // public static double[] device_measure = new double[COMport_SELECT_MAXnumber];
        //public static funReturnCodeCOMport device_XDM3051_measure_ok;
        //public static double device_XDM3051_measure;
        //public static funReturnCodeCOMport device_XDM2041_measure_ok;
        //public static double device_XDM2041_measure;
        //public static funReturnCodeCOMport device_XDM1041_measure_ok;
        //public static double device_XDM1041_measure;





        public (funReturnCodeCOMport, double returnValue) fun_owon_measure_old(int selectCOMport)
        {
            double returnValue = 0;
            if (dev_connected[selectCOMport])
            {
                if (dev_active[selectCOMport])
                {
                    try
                    {
                        mainWindow.COMportSerial[selectCOMport].WriteLine("MEAS?");
                        string measureValue = mainWindow.COMportSerial[selectCOMport].ReadLine();
                        returnValue = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(measureValue));
                        return (funReturnCodeCOMport.OK, returnValue);
                    }
                    catch { return (funReturnCodeCOMport.ERROR, returnValue); }
                }
                else return (funReturnCodeCOMport.NOT_ACTIVE, returnValue);
            }
            else return (funReturnCodeCOMport.NOT_CONNECTED, returnValue);
        }


        //=======================================================================================================================
        //=======================================================================================================================
        public funReturnCodeCOMport fun_owon_multimeter_identification(int selectCOMport, string ident_string)
        {
            if (dev_connected[selectCOMport])
            {
                try
                {
                    mainWindow.COMportSerial[selectCOMport].WriteLine("*IDN?");
                    string ident_readRaw = mainWindow.COMportSerial[selectCOMport].ReadLine();
                    COMport_device_ident[selectCOMport] = functions.fun_ascii_only(ident_readRaw);
                    if (ident_readRaw.Contains(ident_string)) { dev_active[selectCOMport] = true; }
                    else dev_active[selectCOMport] = false;
                    return (funReturnCodeCOMport.OK);
                }
                catch { return funReturnCodeCOMport.ERROR; }
            }
            else return (funReturnCodeCOMport.NOT_CONNECTED);
        }










    }
}
