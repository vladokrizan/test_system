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

    #region "upobne funkcije "

    /*


         only 3051    public (funReturnCode, double returnValue) fun_owon_get_range_volt_dc(int selectCOMport)
         public funReturnCode fun_owon_set_range_volt_dc(int selectCOMport, string set_range_name)
         public funReturnCode fun_owon_set_range_current_dc(int selectCOMport, string set_range_name)
         public void fun_owon_measure(int selectCOMport)
                dev_meas[selectCOMport] = measure result -- double 
                dev_meas_state[selectCOMport] = funReturnCode.OK;
    
        public funReturnCodeCOMport fun_owon_multimeter_identification(int selectCOMport, string ident_string)
    


    //-- XDM2041
    //--    CONF:CURR:DC
    //--    CONF:VOLT:DC
    //--    CONF:VOLT:DC 500

    //-- SET RANGE                   write_string = (f'CONF:VOLT:DC {str(set_range)}')  
    //-- GET VOTAGE in RANGE         write_string = (f'VOLT:DC:RANG?')  

    */
    #endregion
    #region "OWON multimeters RANGE "
    //---------------------------------------------------------------------------------------------------------------------------
    //--  
    //---------------------------------------------------------------------------------------------------------------------------
    public class XDM_3051_RANGE
    {
        public const string DCV___200mV = "DC 200 mV";
        public const string DCV___2V = "DC 2 V";
        public const string DCV___20V = "DC 20 V";
        public const string DCV___200V = "DC 200 V";
        public const string DCV___1000V = "DC 1000 V";
        //-----------------------------------------------------------------------------------------------------------------------
        public const string DCA___200uA = "DC 200 uA";
        public const string DCA___2mA = "DC 2 mA";
        public const string DCA___20mA = "DC 20 mA";
        public const string DCA___200mA = "DC 200 mA";
        public const string DCA___2A = "DC 2 A";
        public const string DCA___10A = "DC 10 A";
    }
    //---------------------------------------------------------------------------------------------------------------------------
    //--
    //---------------------------------------------------------------------------------------------------------------------------
    public class XDM_2041_RANGE
    {
        public const string DCV___50mV = "DC 50 mV";
        public const string DCV___500mV = "DC 500 mV";
        public const string DCV___5V = "DC 5 V";
        public const string DCV___50V = "DC 50 V";
        public const string DCV___500V = "DC 500 V";
        public const string DCV___1000V = "DC 100 V";
        //---------------------------------------------------------------------------------------------------------------------------
        public const string DCA___500uA = "DC 500 uA";
        public const string DCA___5mA = "DC 5 mA";
        public const string DCA___50mA = "DC 50 mA";
        public const string DCA___500mA = "DC 500 mA";
        public const string DCA___5A = "DC 5 A";
        public const string DCA___10A = "DC 10 A";
    }
    //---------------------------------------------------------------------------------------------------------------------------
    //--    
    //---------------------------------------------------------------------------------------------------------------------------
    public class XDM_1041_RANGE
    {
        public const string DCV___5V = "DC 5 V";
        public const string DCV___50V = "DC 50 V";
        public const string DCV___500V = "DC 500 V";
        public const string DCV___1000V = "DC 100 V";
        //-----------------------------------------------------------------------------------------------------------------------    
        public const string DCA___500uA = "DC 500 uA";
        public const string DCA___5mA = "DC 5 mA";
        public const string DCA___50mA = "DC 50 mA";
        public const string DCA___500mA = "DC 500 mA";
        public const string DCA___5A = "DC 5 A";
        public const string DCA___10A = "DC 10 A";
    }
    #endregion

    class owon_multimeter
    {
        functions functions = new functions();
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectCOMport"></param>
        /// <returns></returns>
        //=======================================================================================================================
        public (funReturnCode, double returnValue) fun_owon_get_range_volt_dc(int selectCOMport)
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
                    string measureValue = mainWindow.COMportSerial[selectCOMport].ReadLine();
                    returnValue = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(measureValue));
                    return (funReturnCode.OK, returnValue);
                }
                else return (funReturnCode.NOT_ACTIVE, returnValue);
            }
            else return (funReturnCode.NOT_CONNECTED, returnValue);
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectCOMport"></param>
        /// <param name="set_range"></param>
        /// <returns></returns>
        //=======================================================================================================================
        //public funReturnCode fun_owon_set_range_volt_dc(int selectCOMport, double set_range)
        public funReturnCode fun_owon_set_range_volt_dc(int selectCOMport, string set_range_name)
        {
            double set_range = 1000;

            if (dev_connected[selectCOMport])
            {
                if (dev_active[selectCOMport])
                {
                    if (selectCOMport == COMport_XDM3051)
                    {
                        switch (set_range_name)
                        {
                            case string x when x.StartsWith("DC 200 mV"): set_range = 0.2; break;
                            case string x when x.StartsWith("DC 2 V"): set_range = 2; break;
                            case string x when x.StartsWith("DC 20 V"): set_range = 20; break;
                            case string x when x.StartsWith("DC 200 V"): set_range = 200; break;
                            case string x when x.StartsWith("DC 1000 V"): set_range = 1000; break;
                        }
                    }
                    else if (selectCOMport == COMport_XDM2041)
                    {
                        switch (set_range_name)
                        {
                            case string x when x.StartsWith("DC 50 mV"): set_range = 0.05; break;
                            case string x when x.StartsWith("DC 500 mV"): set_range = 0.5; break;
                            case string x when x.StartsWith("DC 5 V"): set_range = 5; break;
                            case string x when x.StartsWith("DC 50 V"): set_range = 50; break;
                            case string x when x.StartsWith("DC 500 V"): set_range = 500; break;
                            case string x when x.StartsWith("DC 1000 V"): set_range = 1000; break;
                        }
                    }
                    else if (selectCOMport == COMport_XDM1041)
                    {
                        switch (set_range_name)
                        {
                            case string x when x.StartsWith("DC 5 V"): set_range = 5; break;
                            case string x when x.StartsWith("DC 50 V"): set_range = 50; break;
                            case string x when x.StartsWith("DC 500 V"): set_range = 500; break;
                            case string x when x.StartsWith("DC 1000 V"): set_range = 1000; break;
                        }
                    }
                    string send_value = set_range.ToString();
                    send_value = send_value.Replace(",", ".");
                    mainWindow.COMportSerial[selectCOMport].WriteLine("CONF:VOLT:DC " + send_value);
                    dev_range[selectCOMport] = "VDC " + set_range.ToString();
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectCOMport"></param>
        /// <param name="set_range"></param>
        /// <returns></returns>
        //=======================================================================================================================
        //public funReturnCode fun_owon_set_range_current_dc(int selectCOMport, double set_range)
        public funReturnCode fun_owon_set_range_current_dc(int selectCOMport, string set_range_name)
        {
            double set_range = 10;

            if (dev_connected[selectCOMport])
            {
                if (dev_active[selectCOMport])
                {
                    if (selectCOMport == COMport_XDM3051)
                    {
                        switch (set_range_name)
                        {
                            case string x when x.StartsWith("DC 200 uA"): set_range = 0.0002; break;
                            case string x when x.StartsWith("DC 2 mA"): set_range = 0.002; break;
                            case string x when x.StartsWith("DC 20 mA"): set_range = 0.02; break;
                            case string x when x.StartsWith("DC 200 mA"): set_range = 0.2; break;
                            case string x when x.StartsWith("DC 2 A"): set_range = 2; break;
                            case string x when x.StartsWith("DC 10 A"): set_range = 10; break;
                        }
                    }
                    else if (selectCOMport == COMport_XDM2041 || selectCOMport == COMport_XDM1041)
                    {
                        switch (set_range_name)
                        {
                            case string x when x.StartsWith("DC 500 uA"): set_range = 0.0005; break;
                            case string x when x.StartsWith("DC 5 mA"): set_range = 0.005; break;
                            case string x when x.StartsWith("DC 50 mA"): set_range = 0.05; break;
                            case string x when x.StartsWith("DC 500 mA"): set_range = 0.5; break;
                            case string x when x.StartsWith("DC 5 A"): set_range = 5; break;
                            case string x when x.StartsWith("DC 10 A"): set_range = 10; break;
                        }
                    }
                    string send_value = set_range.ToString();
                    send_value = send_value.Replace(",", ".");
                    mainWindow.COMportSerial[selectCOMport].WriteLine("CONF:CURR:DC " + send_value);
                    dev_range[selectCOMport] = "ADC " + set_range.ToString();
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectCOMport"></param>
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
                        string measureValue = mainWindow.COMportSerial[selectCOMport].ReadLine();
                        dev_meas[selectCOMport] = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(measureValue));
                        dev_meas_state[selectCOMport] = funReturnCode.OK;
                    }
                    catch
                    {
                        try
                        {
                            Thread.Sleep(20);
                            mainWindow.COMportSerial[selectCOMport].WriteLine("MEAS?");
                            string measureValue = mainWindow.COMportSerial[selectCOMport].ReadLine();
                            dev_meas[selectCOMport] = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(measureValue));
                            dev_meas_state[selectCOMport] = funReturnCode.OK;
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
                                dev_meas_state[selectCOMport] = funReturnCode.OK;
                            }
                            catch { dev_meas_state[selectCOMport] = funReturnCode.ERROR; }
                        }
                    }
                }
                else dev_meas_state[selectCOMport] = funReturnCode.NOT_ACTIVE;
            }
            else dev_meas_state[selectCOMport] = funReturnCode.NOT_CONNECTED;
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectCOMport"></param>
        /// <param name="ident_string">
        ///     identifikacijski string 
        ///             COMport_XDM3051, "XDM3051,2303195"
        ///             COMport_XDM2041, "XDM2041,24470254"
        ///             COMport_XDM1041, "XDM1041,23120418"
        /// </param>
        /// <returns></returns>
        //=======================================================================================================================
        public funReturnCode fun_owon_multimeter_identification(int selectCOMport, string ident_string)
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
                    return (funReturnCode.OK);
                }
                catch { return funReturnCode.ERROR; }
            }
            else return (funReturnCode.NOT_CONNECTED);
        }



    }
}
