using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using test_system.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static test_system.global_variable;


namespace test_system
{
    internal class power_supply_KA3305P
    {

        functions functions = new functions();
        //=======================================================================================================================
        /// <summary>
        ///     branje idetifikacijskega stringa      
        /// </summary>
        //--    KORAD KA3305P V7.0 SN:30057214
        //=======================================================================================================================
        public void fun_KA3305P_identifaction()
        {
            if (dev_connected[COMport_KA3305A])
            {
                mainWindow.COMportSerial[COMport_KA3305A].WriteLine("*IDN?");
                string ident_readRaw = mainWindow.COMportSerial[COMport_KA3305A].ReadLine();
                COMport_device_ident[COMport_KA3305A] = functions.fun_ascii_only(ident_readRaw);

                if (ident_readRaw.Contains("KORAD KA3305P V7.0 SN:30057214")) { dev_active[COMport_KA3305A] = true; }
                else dev_active[COMport_KA3305A] = false;
            }
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        ///--   6. VOUT<X>?     Description：Returns the actual output voltage.Example VOUT1?
        ///    5. IOUT<X>?      Description：Returns the actual output current.  Example IOUT1?  Returns the CH1 output current
        /// 
        /// </summary>
        //=======================================================================================================================
        public funReturnCodeCOMport fun_KA3305P_get_voltage_current(int select_channel = 1)
        {
            string send_command;
            string read_answer;
            if (dev_connected[COMport_KA3305A])
            {
                if (dev_active[COMport_KA3305A])
                {
                    send_command = "VOUT" + select_channel.ToString() + "?";
                    mainWindow.COMportSerial[COMport_KA3305A].WriteLine(send_command);
                    read_answer = mainWindow.COMportSerial[COMport_KA3305A].ReadLine();
                    //strGeneralString = read_answer;

                    switch (select_channel)
                    {
                        case 1: KA3305P_out_voltage_1 = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(read_answer)); break;
                        case 2: KA3305P_out_voltage_2 = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(read_answer)); break;
                    }
                    send_command = "IOUT" + select_channel.ToString() + "?";
                    mainWindow.COMportSerial[COMport_KA3305A].WriteLine(send_command);
                    read_answer = mainWindow.COMportSerial[COMport_KA3305A].ReadLine();
                    //strGeneralString = strGeneralString +"     " +read_answer;
                    switch (select_channel)
                    {
                        case 1: KA3305P_out_current_1 = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(read_answer)); break;
                        case 2: KA3305P_out_current_2 = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(read_answer)); break;
                    }
                    return (funReturnCodeCOMport.OK);
                }
                return (funReturnCodeCOMport.NOT_ACTIVE);
            }
            return (funReturnCodeCOMport.NOT_CONNECTED);
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="select_channel"></param>
        /// <param name="set_voltage"></param>
        /// 
        ///     1. ISET<X>:<NR2>    Description： Sets the output current.   Example:ISET1:2.225 Response time 50ms      Sets the CH1 output current to 2.225A
        ///     2. ISET<X>? Description： Returns the output current setting.Example: ISET1? Returns the CH1 output current setting.
        ///     3. VSET<X>:<NR2>    Description：Sets the output voltage.Example VSET1:20.50     Sets the CH1 voltage to 20.50V
        ///     4. VSET<X>? Description：Returns the output voltage setting.Example VSET1?      Returns the CH1 voltage setting
        /// 
        /// <returns></returns>
        //=======================================================================================================================
        public funReturnCodeCOMport fun_KA3305P_get_set_voltage_current(int select_channel = 1)
        {
            string send_command;
            string read_answer;
            if (dev_connected[COMport_KA3305A])
            {
                if (dev_active[COMport_KA3305A])
                {
                    mainWindow.COMportSerial[COMport_KA3305A].DiscardInBuffer();
                    send_command = "VSET" + select_channel.ToString() + "?";
                    mainWindow.COMportSerial[COMport_KA3305A].WriteLine(send_command);
                    read_answer = mainWindow.COMportSerial[COMport_KA3305A].ReadLine();
                    //strGeneralString = read_answer;
                    switch (select_channel)
                    {
                        case 1: KA3305P_get_set_voltage_1 = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(read_answer)); break;
                        case 2: KA3305P_get_set_voltage_2 = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(read_answer)); break;
                    }
                    mainWindow.COMportSerial[COMport_KA3305A].DiscardInBuffer();
                    send_command = "ISET" + select_channel.ToString() + "?";
                    mainWindow.COMportSerial[COMport_KA3305A].WriteLine(send_command);
                    read_answer = mainWindow.COMportSerial[COMport_KA3305A].ReadLine();
                    //strGeneralString = strGeneralString+ "   "+  read_answer;
                    switch (select_channel)
                    {
                        case 1: KA3305P_get_set_current_1 = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(read_answer)); break;
                        case 2: KA3305P_get_set_current_2 = Convert.ToDouble(functions.fun_convert_string_to_current_decimal_separator(read_answer)); break;
                    }
                    return (funReturnCodeCOMport.OK);
                }
                return (funReturnCodeCOMport.NOT_ACTIVE);
            }
            return (funReturnCodeCOMport.NOT_CONNECTED);
        }


        //--     3. VSET<X>:<NR2>    Description：Sets the output voltage.Example VSET1:20.50     Sets the CH1 voltage to 20.50V
        public funReturnCodeCOMport fun_KA3305P_set_voltage(double set_value, int select_channel = 1)
        {
            if (dev_connected[COMport_KA3305A])
            {
                if (dev_active[COMport_KA3305A])
                {
                    mainWindow.COMportSerial[COMport_KA3305A].DiscardInBuffer();
                    string setValueString = set_value.ToString("");
                    string setValueString_pika = setValueString.Replace(",", ".");
                    mainWindow.COMportSerial[COMport_KA3305A].WriteLine("VSET" + select_channel.ToString() + ":" + setValueString_pika);
                    //strGeneralString = "VSET" + select_channel.ToString() + ":" + setValueString_pika;
                    return (funReturnCodeCOMport.OK);
                }
                return (funReturnCodeCOMport.NOT_ACTIVE);
            }
            return (funReturnCodeCOMport.NOT_CONNECTED);
        }
        public funReturnCodeCOMport fun_KA3305P_set_current(double set_value, int select_channel = 1)
        {
            if (dev_connected[COMport_KA3305A])
            {
                if (dev_active[COMport_KA3305A])
                {
                    mainWindow.COMportSerial[COMport_KA3305A].DiscardInBuffer();
                    string setValueString = set_value.ToString("");
                    string setValueString_pika = setValueString.Replace(",", ".");
                    mainWindow.COMportSerial[COMport_KA3305A].WriteLine("ISET" + select_channel.ToString() + ":" + setValueString_pika);
                    //strGeneralString = "VSET" + select_channel.ToString() + ":" + setValueString_pika;
                    return (funReturnCodeCOMport.OK);
                }
                return (funReturnCodeCOMport.NOT_ACTIVE);
            }
            return (funReturnCodeCOMport.NOT_CONNECTED);
        }

        //=======================================================================================================================
        //=======================================================================================================================
        //=======================================================================================================================
        //=======================================================================================================================
        //=======================================================================================================================
        //=======================================================================================================================
        //=======================================================================================================================


        //--   7. OUT<Boolean> Description：Turns on or off the output.Boolean：0 OFF,1 ON Example: OUT1 Turns on the output

        public funReturnCodeCOMport fun_KA3305P_on(int select_channel = 1)
        {
            if (dev_connected[COMport_KA3305A])
            {
                if (dev_active[COMport_KA3305A])
                {

                    string send_command;
                    mainWindow.COMportSerial[COMport_KA3305A].DiscardInBuffer();
                    //send_command = "OUT" + select_channel.ToString() + "1";
                    send_command = "OUT1";
                    mainWindow.COMportSerial[COMport_KA3305A].WriteLine(send_command);
                    return (funReturnCodeCOMport.OK);
                }
                return (funReturnCodeCOMport.NOT_ACTIVE);
            }
            return (funReturnCodeCOMport.NOT_CONNECTED);

        }
        public funReturnCodeCOMport fun_KA3305P_off(int select_channel = 1)
        {
            if (dev_connected[COMport_KA3305A])
            {
                if (dev_active[COMport_KA3305A])
                {

                    string send_command;
                    mainWindow.COMportSerial[COMport_KA3305A].DiscardInBuffer();
                    send_command = "OUT0";
                    mainWindow.COMportSerial[COMport_KA3305A].WriteLine(send_command);
                    return (funReturnCodeCOMport.OK);
                }
                return (funReturnCodeCOMport.NOT_ACTIVE);
            }
            return (funReturnCodeCOMport.NOT_CONNECTED);

        }


        /// <summary>
        /// 
        ///     8. STATUS? Description：Returns the POWER SUPPLY status.
        ///     Contents 8 bits in the following format
        ///     Bit Item Description
        ///         0       CH1 0=CC mode, 1=CV mode
        ///         1       CH2 0=CC mode, 1=CV mode
        ///         2,3,    Tracking  00=Independent, 01=Tracking series, 11=Tracking parallel
        ///         4,      Beep      0=Off, 1=On
        ///         5       Lock      0=Lock, 1=Unlock
        ///         6       Output 0=Off, 1=On
        ///         7       N/AN/A
        /// 
        /// 
        /// </summary>

        public funReturnCodeCOMport fun_KA3305P_status()
        {
            string read_answer;
            byte[] dataArray = new byte[5];

            if (dev_connected[COMport_KA3305A])
            {
                if (dev_active[COMport_KA3305A])
                {

                    mainWindow.COMportSerial[COMport_KA3305A].WriteLine("STATUS?");
                    read_answer = mainWindow.COMportSerial[COMport_KA3305A].ReadLine();
                    dataArray = Encoding.ASCII.GetBytes(read_answer);
                    KA3305P_status = dataArray[0];
                    //strGeneralString = read_answer +"   "+ dataArray[0].ToString()+ "   " + "   " + dataArray[0].ToString("X"); 
                    BitArray bits = new BitArray(BitConverter.GetBytes(KA3305P_status).ToArray());
                    if (bits[0]) KA3305P_status_bit0_CH1_mode = "CH 1- CV"; else KA3305P_status_bit0_CH1_mode = "CH 1- CC";
                    if (bits[1]) KA3305P_status_bit0_CH2_mode = "CH 2- CV"; else KA3305P_status_bit0_CH2_mode = "CH 2- CC";
                    if (bits[2] && bits[3]) KA3305P_status_bit23_tracking = "Parallel";
                    if (!bits[2] && !bits[3]) KA3305P_status_bit23_tracking = "Independent";
                    if (bits[2] && !bits[3]) KA3305P_status_bit23_tracking = "Series";
                    if (bits[4]) KA3305P_status_bit4_beep = "BEEP ON"; else KA3305P_status_bit4_beep = "BEEP OFF";
                    if (bits[5]) KA3305P_status_bit5_lock = "Lock ON"; else KA3305P_status_bit5_lock = "LockP OFF";
                    if (bits[6]) KA3305P_status_bit6_on_offk = "Output ON"; else KA3305P_status_bit6_on_offk = "Output OFF";
                    //strGeneralString = KA3305P_status.ToString("X") + "    " + bits[7].ToString() + " " + bits[6].ToString() + " " + bits[5].ToString() + " " + bits[4].ToString() + " " + bits[3].ToString() + " " + bits[2].ToString() + " " + bits[1].ToString() + " " + bits[0].ToString();
                    return (funReturnCodeCOMport.OK);
                }
                return (funReturnCodeCOMport.NOT_ACTIVE);
            }
            return (funReturnCodeCOMport.NOT_CONNECTED);
        }
    }
}




/*
    1. ISET<X>:<NR2>    Description： Sets the output current.   Example:ISET1:2.225 Response time 50ms      Sets the CH1 output current to 2.225A
    2. ISET<X>?         Description： Returns the output current setting.    Example: ISET1?         Returns the CH1 output current setting.
    3. VSET<X>:<NR2>    Description：Sets the output voltage.    Example VSET1:20.50     Sets the CH1 voltage to 20.50V
    4. VSET<X>?         Description：Returns the output voltage setting.     Example VSET1?      Returns the CH1 voltage setting
    5. IOUT<X>?         Description：Returns the actual output current.  Example IOUT1?  Returns the CH1 output current
    6. VOUT<X>?         Description：Returns the actual output voltage.  Example VOUT1?
    7. OUT<Boolean>     Description：Turns on or off the output.     Boolean：0 OFF,1 ON      Example: OUT1 Turns on the output
    8. STATUS?          Description：Returns the POWER SUPPLY status.
                        Contents 8 bits in the following format
                        Bit Item Description
                        0 CH1 0=CC mode, 1=CV mode
                        1 CH2 0=CC mode, 1=CV mode
                        2,3,4,5 N/A
                        6 Output 0=Off, 1=On
                        7 N/AN/A
    9. *IDN?            Description：Returns the KA3305P identification. Example *IDN?   Contents KORAD KA3305P V2.0 (Manufacturer, modelname,).
    10. RCL<NR1>        Description：Recalls a panel setting.    NR1 1 5: Memory number 1 to 5   Example RCL1 Recalls the panel setting stored in    memory number 1
    11. SAV<NR1>        Description：Stores the panel setting.   NR1 1 5: Memory number 1 to 5   Example ： SAV1 Stores the panel setting in memorynumber 1
    12. OCP<NR1>        Description：Over current    Example ：OCP1 OCP OPEN


*/
