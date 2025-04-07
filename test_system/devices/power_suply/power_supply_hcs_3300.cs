using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static test_system.global_variable;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace test_system
{

    #region "decription "
    /*

    Two decimal places for current value: HCS-3102, 3014, 3204
    Command code & return value

    GMAX[CR]    Return value:   <voltage><current>[CR] OK[CR] Get PS maximum Voltage & Current value
            <voltage>=???   <current>=???   Input command:  GMAX[CR] Return value:   180200[CR]  OK[CR]
            Meaning:    Maximum Voltage is 18.0V Maximum Current is 20.0A
    SOUT<status>[CR] Return value:   OK[CR] Switch on/off the output of PS<status>=0/1 (0=ON, 1=OFF)
    SOUT0[CR] Return value:   OK[CR] Meaning:    Switch on the output of PS
    VOLT<voltage>[CR] Return value:   OK[CR] Preset Voltage value<voltage>=010<???<Max-Volt  *Max-Volt value refer to product specification
    VOLT127[CR] Return value:   OK[CR] Meaning:    Set Voltage value as 12.7V
    CURR<current>[CR] Return value:   OK[CR] Preset Current value    <current>=000<???<Max-Curr* Max-Curr value refer to product specification
    CURR120[CR] Return value:   OK[CR] Meaning:    Set Current value as 12.0A
    GETS[CR] Return value:   <voltage><current>[CR] OK[CR] Get PS preset Voltage & Current value   <voltage>=???   <current>=???
    GETS[CR] Return value:   150180[CR] OK[CR] Meaning:    The Voltage value set at 15V and Current value set at 18A
    GETD[CR] Return value:   <voltage><current><status>[CR] OK[CR] Get PS Display values of Voltage, Current and   Status of CC/CV
            <voltage>=????  <current>=????  <status>=0/1 (0=CV, 1=CC)
    GETD[CR] Return value:   150016001[CR] OK[CR] Meaning:    The PS Display value is 15V and 16A.It is in CC mode.
    PROM<voltage0><current0>    <voltage1><current1>    <voltage2><current2>[CR] Return value:   OK[CR]
            Save Voltage and Current value into 3 PS memory locations<voltageX>=???  <currentX>=???  (X is memory location number start from 0 to 2)
    PROM111111022122033133[CR] Return value:   OK[CR] Meaning:
            Preset Memory 0 as 11.1V and 11.1A Preset Memory 1 as 2.2V and 12.2A Preset Memory 2 as 3.3V and 13.3A
    GETM[CR]    Return value:
            <voltage0><current0>[CR]
            <voltage1><current1>[CR]
            <voltage2><current2>[CR]
        OK[CR] Get saved Voltage and Current value from 3 PS memory loctions
        <voltageX>=???  <currentX>=???  (X is memory location number start from 0 to 2)
    GETM[CR] Return value:   111111[CR]  122122[CR]  133133[CR]
        OK[CR]
        Meaning:    PS return following preset value from 3 memory locations; Memory 0 is 11.1V and 11.1A Memory 1 is 12.2V and 12.2A Memory 2 is 13.3V and 13.3A
    RUNM<memory>[CR] Return value:   OK[CR] Set Voltage and Current using values saved in memory locations<memory>=0/1/2
    RUNM1[CR] Return value:   OK[CR] Meaning:    Set Voltage and Current using values saved in memory location 1


    //-- ni implemenentirano 
            PROM<voltage0><current0>    <voltage1><current1>    <voltage2><current2>[CR] Return value:   OK[CR]
                Save Voltage and Current value into 3 PS memory locations<voltageX>=???  <currentX>=???  (X is memory location number start from 0 to 2)

            PROM111111022122033133[CR] Return value:   OK[CR] Meaning:
                Preset Memory 0 as 11.1V and 11.1A Preset Memory 1 as 2.2V and 12.2A Preset Memory 2 as 3.3V and 13.3A
                GETM[CR]    Return value:
                <voltage0><current0>[CR]
                <voltage1><current1>[CR]
                <voltage2><current2>[CR]
                OK[CR] Get saved Voltage and Current value from 3 PS memory loctions
                <voltageX>=???  <currentX>=???  (X is memory location number start from 0 to 2)
        GETM[CR] Return value:   111111[CR]  122122[CR]  133133[CR]
            OK[CR]
                Meaning:    PS return following preset value from 3 memory locations; Memory 0 is 11.1V and 11.1A Memory 1 is 12.2V and 12.2A Memory 2 is 13.3V and 13.3A
        RUNM<memory>[CR] Return value:   OK[CR] Set Voltage and Current using values saved in memory locations<memory>=0/1/2
        RUNM1[CR] Return value:   OK[CR] Meaning:    Set Voltage and Current using values saved in memory location 1



        */


    #endregion
    internal class power_supply_hcs_3300
    {
        functions functions = new functions();
        byte[] read_buffer = new byte[100];
        byte[] dataArray = new byte[50];
        //=======================================================================================================================
        //--
        //=======================================================================================================================
        private void fun_send_command(string sendString)
        {
            dataArray = Encoding.ASCII.GetBytes(sendString);

            mainWindow.COMportSerial[COMport_HCS_3300].DiscardInBuffer();
            mainWindow.COMportSerial[COMport_HCS_3300].Write(dataArray, 0, dataArray.Length);
            // if (dataArray.Length==8)   strGeneralString = dataArray.Length +"  "+ dataArray[0].ToString () + " " + dataArray[1].ToString() + " " + dataArray[2].ToString() + " " + dataArray[3].ToString() + " " + dataArray[4].ToString() + " " + dataArray[5].ToString() + " " + dataArray[6].ToString() + " " + dataArray[7].ToString();
        }
        //=======================================================================================================================
        //--    GMAX[CR] Return value:   <voltage><current>[CR] OK[CR]   Get PS maximum Voltage & Current value    <voltage>=???   <current>=???
        //--    GMAX[CR] Return value:   180200[CR]             OK[CR]   Meaning:    Maximum Voltage is 18.0V Maximum Current is 20.0A
        //--    ("GMAX");
        //--    162330
        //=======================================================================================================================
        public funReturnCode fun_HCS_330_identifaction()
        {
            if (dev_connected[COMport_HCS_3300])
            {
                mainWindow.COMportSerial[COMport_HCS_3300].DiscardInBuffer();
                fun_send_command("GMAX\r");
                Thread.Sleep(20);
                int number_bytes_to_read = mainWindow.COMportSerial[COMport_HCS_3300].BytesToRead;
                mainWindow.COMportSerial[COMport_HCS_3300].Read(read_buffer, 0, number_bytes_to_read);
                string ident_readRaw = Convert.ToChar(read_buffer[0]).ToString() + Convert.ToChar(read_buffer[1]).ToString() + Convert.ToChar(read_buffer[2]).ToString() + Convert.ToChar(read_buffer[3]).ToString() + Convert.ToChar(read_buffer[4]).ToString() + Convert.ToChar(read_buffer[5]).ToString();
                COMport_device_ident[COMport_HCS_3300] = functions.fun_ascii_only(ident_readRaw);

                if (ident_readRaw.Contains("162330")) { dev_active[COMport_HCS_3300] = true; }
                else dev_active[COMport_HCS_3300] = false;
                return (funReturnCode.OK);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }

        //=======================================================================================================================
        //--    SOUT<status>[CR] Return value:   OK[CR] Switch on/off the output of PS<status>=0/1 (0=ON, 1=OFF)
        //--    SOUT0[CR] Return value:   OK[CR] Meaning:    Switch on the output of PS
        //=======================================================================================================================
        public funReturnCode fun_HCS_3300_off()
        {
            if (dev_connected[COMport_HCS_3300])
            {
                if (dev_active[COMport_HCS_3300])
                {
                    fun_send_command("SOUT1\r");
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }


        //=======================================================================================================================
        //=======================================================================================================================
        public funReturnCode fun_HCS_3300_on()
        {
            if (dev_connected[COMport_HCS_3300])
            {
                if (dev_active[COMport_HCS_3300])
                {
                    fun_send_command("SOUT0\r");
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }


        //=======================================================================================================================
        //--  GETD[CR] Return value:   <voltage><current><status>[CR] OK[CR]
        //--      Get PS Display values of Voltage, Current and   Status of CC/CV
        //--            <voltage>=????  <current>=????  <status>=0/1 (0=CV, 1=CC)
        //--    GETD[CR] Return value:
        //--        150016001[CR] OK[CR] Meaning:    The PS Display value is 15V and 16A.It is in CC mode.
        //--    000300040 OK
        //-- 046000040
        //-- OK

        //=======================================================================================================================
        public funReturnCode fun_HCS_330_get_measure()
        {

            if (dev_connected[COMport_HCS_3300])
            {
                if (dev_active[COMport_HCS_3300])
                {
                    try
                    {
                        mainWindow.COMportSerial[COMport_HCS_3300].DiscardInBuffer();
                        fun_send_command("GETD\r");
                        Thread.Sleep(20);
                        COMport_receive_lenght[COMport_HCS_3300] = mainWindow.COMportSerial[COMport_HCS_3300].BytesToRead;
                        mainWindow.COMportSerial[COMport_HCS_3300].Read(read_buffer, 0, COMport_receive_lenght[COMport_HCS_3300]);
                        COMport_receive_string[COMport_HCS_3300] = Encoding.UTF8.GetString(read_buffer);
                        string voltage = COMport_receive_string[COMport_HCS_3300].Substring(0, 4);
                        int voltage_value = Convert.ToInt16(voltage);
                        HCS_3300_out_voltage = ((double)voltage_value) / 100;
                        string current = COMport_receive_string[COMport_HCS_3300].Substring(4, 4);
                        int current_value = Convert.ToInt16(current);
                        HCS_3300_out_current = ((double)current_value) / 100;
                        string status = COMport_receive_string[COMport_HCS_3300].Substring(8, 1);
                        if (status == "0") HCS_3300_out_status = "constant Voltage";
                        if (status == "1") HCS_3300_out_status = "constant Current";
                        return (funReturnCode.OK);

                    }
                    catch { return (funReturnCode.ERROR); }
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
            // strGeneralString = Convert.ToChar(read_buffer[0]).ToString() + Convert.ToChar(read_buffer[1]).ToString() + Convert.ToChar(read_buffer[2]).ToString() + Convert.ToChar(read_buffer[3]).ToString() + Convert.ToChar(read_buffer[4]).ToString() + Convert.ToChar(read_buffer[5]).ToString() + Convert.ToChar(read_buffer[6]).ToString() + Convert.ToChar(read_buffer[7]).ToString() + Convert.ToChar(read_buffer[8]).ToString() + Convert.ToChar(read_buffer[9]).ToString() + Convert.ToChar(read_buffer[10]).ToString() + Convert.ToChar(read_buffer[11]).ToString();
        }
        //=======================================================================================================================
        //--    GETS[CR] Return value:   <voltage><current>[CR] OK[CR]
        //--              Get PS preset Voltage & Current value<voltage>=???   <current>=???
        //--    GETS[CR]
        //--    Return value:   150180[CR] OK[CR]
        //--          Meaning:    The Voltage value set at 15V and Current value set at 18A
        //--    
        //=======================================================================================================================
        public funReturnCode fun_HCS_3300_get_limit()
        {
            if (dev_connected[COMport_HCS_3300])
            {
                if (dev_active[COMport_HCS_3300])
                {
                    mainWindow.COMportSerial[COMport_HCS_3300].DiscardInBuffer();
                    fun_send_command("GETS\r");
                    Thread.Sleep(20);
                    COMport_receive_lenght[COMport_HCS_3300] = mainWindow.COMportSerial[COMport_HCS_3300].BytesToRead;
                    mainWindow.COMportSerial[COMport_HCS_3300].Read(read_buffer, 0, COMport_receive_lenght[COMport_HCS_3300] - 4);
                    COMport_receive_string[COMport_HCS_3300] = Encoding.UTF8.GetString(read_buffer);
                    string correct_string = functions.fun_ascii_only(COMport_receive_string[COMport_HCS_3300]);
                    string voltage = correct_string.Substring(0, 3);
                    int voltage_value = Convert.ToInt16(voltage);
                    HCS_3300_get_set_voltage = ((double)voltage_value) / 10;
                    string current = correct_string.Substring(3, 3);
                    int current_value = Convert.ToInt16(current);
                    HCS_3300_get_set_current = ((double)current_value) / 10;
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }

        //=======================================================================================================================
        //--    VOLT<voltage>[CR] Return value:   OK[CR]
        //--          Preset Voltage value<voltage>=010<???<Max-Volt* Max-Volt value refer to product specification
        //--    VOLT127[CR]             Set Voltage value as 12.7V
        //--      Return value:   OK[CR] Meaning:    
        //=======================================================================================================================
        public funReturnCode fun_HCS_330_set_voltage(double set_voltage)
        {
            string setValueString;
            if (dev_connected[COMport_HCS_3300])
            {
                if (dev_active[COMport_HCS_3300])
                {
                    mainWindow.COMportSerial[COMport_HCS_3300].DiscardInBuffer();
                    set_voltage = set_voltage * 10;
                    if (set_voltage > 160) set_voltage = 160;
                    setValueString = set_voltage.ToString();
                    if (set_voltage < 10) setValueString = "00" + setValueString;
                    else if (set_voltage < 100) setValueString = "0" + setValueString;
                    if (setValueString.Length > 3) setValueString = setValueString.Substring(0, 3);
                    fun_send_command("VOLT" + setValueString + "\r");
                    // strGeneralString = setValueString.ToString();
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);

        }


        //=======================================================================================================================
        //--     CURR<current>[CR]      Preset Current value<current>=000<???<Max-Curr* Max-Curr value refer to product specification
        //--     Return value:   OK[CR] 
        //--    CURR120[CR]         Set Current value as 12.0A
        //--    Return value:   OK[CR] Meaning:    
        //=======================================================================================================================
        public funReturnCode fun_HCS_330_set_current(double set_current)
        {
            double setValue;
            string setValueString;

            if (dev_connected[COMport_HCS_3300])
            {
                if (dev_active[COMport_HCS_3300])
                {
                    //setValue = Convert.ToDouble(HSC3300_set_set_current);
                    mainWindow.COMportSerial[COMport_HCS_3300].DiscardInBuffer();
                    setValue = set_current * 10;
                    if (setValue > 300) setValue = 300;
                    setValueString = setValue.ToString();
                    if (setValue < 10) setValueString = "00" + setValueString;
                    else if (setValue < 100) setValueString = "0" + setValueString;
                    if (setValueString.Length > 3) setValueString = setValueString.Substring(0, 3);
                    fun_send_command("CURR" + setValueString + "\r");
                    //strGeneralString = "    " + setValueString.ToString();
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }



    }
}
















