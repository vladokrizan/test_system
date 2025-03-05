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
            mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_3300].DiscardInBuffer();
            mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_3300].Write(dataArray, 0, dataArray.Length);
        }
        //=======================================================================================================================
        //--    GMAX[CR] Return value:   <voltage><current>[CR] OK[CR]   Get PS maximum Voltage & Current value    <voltage>=???   <current>=???
        //--    GMAX[CR] Return value:   180200[CR]             OK[CR]   Meaning:    Maximum Voltage is 18.0V Maximum Current is 20.0A
        //--    ("GMAX");
        //--    162330
        //=======================================================================================================================
        public void fun_HCS_330_identifaction()
        {
            if (COMport_connected[COMport_SELECT_SUPPLY_HCS_3300])
            {

                fun_send_command("GMAX\r");
                Thread.Sleep(20);
                int number_bytes_to_read = mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_3300].BytesToRead;
                mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_3300].Read(read_buffer, 0, number_bytes_to_read);
                string ident_readRaw = Convert.ToChar(read_buffer[0]).ToString() + Convert.ToChar(read_buffer[1]).ToString() + Convert.ToChar(read_buffer[2]).ToString() + Convert.ToChar(read_buffer[3]).ToString() + Convert.ToChar(read_buffer[4]).ToString() + Convert.ToChar(read_buffer[5]).ToString();
                COMport_device_ident[COMport_SELECT_SUPPLY_HCS_3300] = functions.fun_ascii_only(ident_readRaw);

                if (ident_readRaw.Contains("162330")) { COMport_active[COMport_SELECT_SUPPLY_HCS_3300] = true; }
                else COMport_active[COMport_SELECT_SUPPLY_HCS_3300] = false;
            }
         }

        //=======================================================================================================================
        //--    SOUT<status>[CR] Return value:   OK[CR] Switch on/off the output of PS<status>=0/1 (0=ON, 1=OFF)
        //--    SOUT0[CR] Return value:   OK[CR] Meaning:    Switch on the output of PS
        //=======================================================================================================================
        public void fun_HCS_330_off()
        {
            fun_send_command("SOUT0\r");
            //dataArray = Encoding.ASCII.GetBytes("SOUT0\r");
            //mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_330].DiscardInBuffer();
            //mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_330].Write(dataArray, 0, dataArray.Length);
        }
        //=======================================================================================================================
        //=======================================================================================================================
        public void fun_HCS_330_on()
        {
            fun_send_command("SOUT1\r");
            //dataArray = Encoding.ASCII.GetBytes("SOUT1\r");
            //mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_330].DiscardInBuffer();
            //mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_330].Write(dataArray, 0, dataArray.Length);
        }


        //=======================================================================================================================
        //--  GETD[CR] Return value:   <voltage><current><status>[CR] OK[CR]
        //--      Get PS Display values of Voltage, Current and   Status of CC/CV
        //--            <voltage>=????  <current>=????  <status>=0/1 (0=CV, 1=CC)
        //--    GETD[CR] Return value:
        //--        150016001[CR] OK[CR] Meaning:    The PS Display value is 15V and 16A.It is in CC mode.
        //--    000300040 OK
        //=======================================================================================================================
        public void fun_HCS_330_get_measure()
        {
            fun_send_command("GETD\r");
            //dataArray = Encoding.ASCII.GetBytes("GETD\r");
            //mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_330].DiscardInBuffer();
            //mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_330].Write(dataArray, 0, dataArray.Length);
            Thread.Sleep(20);
            mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_3300].Read(read_buffer, 0, 12);
            strGeneralString = Convert.ToChar(read_buffer[0]).ToString() + Convert.ToChar(read_buffer[1]).ToString() + Convert.ToChar(read_buffer[2]).ToString() + Convert.ToChar(read_buffer[3]).ToString() + Convert.ToChar(read_buffer[4]).ToString() + Convert.ToChar(read_buffer[5]).ToString() + Convert.ToChar(read_buffer[6]).ToString() + Convert.ToChar(read_buffer[7]).ToString() + Convert.ToChar(read_buffer[8]).ToString() + Convert.ToChar(read_buffer[9]).ToString() + Convert.ToChar(read_buffer[10]).ToString() + Convert.ToChar(read_buffer[11]).ToString();
            //device_ET3916_read_all_temperature = true;
        }


        //--    GETS[CR] Return value:   <voltage><current>[CR] OK[CR]
        //--              Get PS preset Voltage & Current value<voltage>=???   <current>=???
        //--    GETS[CR]
        //--    Return value:   150180[CR] OK[CR]
        //--          Meaning:    The Voltage value set at 15V and Current value set at 18A
        public void fun_HCS_330_get_limit()
        {
        }


        //--    VOLT<voltage>[CR] Return value:   OK[CR]
        //--          Preset Voltage value<voltage>=010<???<Max-Volt* Max-Volt value refer to product specification
        //--    VOLT127[CR]             Set Voltage value as 12.7V
        //--      Return value:   OK[CR] Meaning:    
        public void fun_HCS_330_set_voltage()
        {
        }


        //--     CURR<current>[CR]      Preset Current value<current>=000<???<Max-Curr* Max-Curr value refer to product specification
        //--     Return value:   OK[CR] 
        //--    CURR120[CR]         Set Current value as 12.0A
        //--    Return value:   OK[CR] Meaning:    

        public void fun_HCS_330_set_current()
        {
        }






    }
}







/*


PROM<voltage0><current0>    <voltage1><current1>    <voltage2><current2>[CR]    Return value:   OK[CR]
    Save Voltage and Current value into 3 PS memory locations   <voltageX>=???  <currentX>=???  (X is memory location number start from 0 to 2)

PROM111111022122033133[CR]  Return value:   OK[CR]  Meaning:
    Preset Memory 0 as 11.1V and 11.1A  Preset Memory 1 as 2.2V and 12.2A   Preset Memory 2 as 3.3V and 13.3A
GETM[CR]    Return value:
        <voltage0><current0>[CR]
        <voltage1><current1>[CR]
        <voltage2><current2>[CR]
    OK[CR]  Get saved Voltage and Current value from 3 PS memory loctions
    <voltageX>=???  <currentX>=???  (X is memory location number start from 0 to 2)
GETM[CR]    Return value:   111111[CR]  122122[CR]  133133[CR]  OK[CR]
    Meaning:    PS return following preset value from 3 memory locations;   Memory 0 is 11.1V and 11.1A Memory 1 is 12.2V and 12.2A Memory 2 is 13.3V and 13.3A
RUNM<memory>[CR]    Return value:   OK[CR]  Set Voltage and Current using values saved in memory locations  <memory>=0/1/2
RUNM1[CR]   Return value:   OK[CR]  Meaning:    Set Voltage and Current using values saved in memory location 1













Two decimal places for current value: HCS-3102, 3014, 3204
Command code & return value

GMAX[CR]    Return value:   <voltage><current>[CR]OK[CR]    Get PS maximum Voltage & Current value
    <voltage>=???   <current>=???   Input command:  GMAX[CR]    Return value:   180200[CR]  OK[CR]
    Meaning:    Maximum Voltage is 18.0V    Maximum Current is 20.0A


SOUT<status>[CR]    Return value:   OK[CR]  Switch on/off the output of PS  <status>=0/1 (0=ON, 1=OFF)
SOUT0[CR]   Return value:   OK[CR]  Meaning:    Switch on the output of PS  
VOLT<voltage>[CR]   Return value:   OK[CR]  Preset Voltage value    <voltage>=010<???<Max-Volt  *Max-Volt value refer to product specification
VOLT127[CR] Return value:   OK[CR]  Meaning:    Set Voltage value as 12.7V
CURR<current>[CR]   Return value:   OK[CR]  Preset Current value    <current>=000<???<Max-Curr  *Max-Curr value refer to product specification
CURR120[CR] Return value:   OK[CR]  Meaning:    Set Current value as 12.0A
GETS[CR]    Return value:   <voltage><current>[CR]  OK[CR]  Get PS preset Voltage & Current value   <voltage>=???   <current>=???
GETS[CR]    Return value:   150180[CR]  OK[CR]  Meaning:    The Voltage value set at 15V    and Current value set at 18A
GETD[CR]    Return value:   <voltage><current><status>[CR]  OK[CR]  Get PS Display values of Voltage, Current and   Status of CC/CV
    <voltage>=????  <current>=????  <status>=0/1 (0=CV, 1=CC)
GETD[CR]    Return value:   150016001[CR]   OK[CR]  Meaning:    The PS Display value is 15V and 16A.    It is in CC mode.
PROM<voltage0><current0>    <voltage1><current1>    <voltage2><current2>[CR]    Return value:   OK[CR]
    Save Voltage and Current value into 3 PS memory locations   <voltageX>=???  <currentX>=???  (X is memory location number start from 0 to 2)

PROM111111022122033133[CR]  Return value:   OK[CR]  Meaning:
    Preset Memory 0 as 11.1V and 11.1A  Preset Memory 1 as 2.2V and 12.2A   Preset Memory 2 as 3.3V and 13.3A
GETM[CR]    Return value:
        <voltage0><current0>[CR]
        <voltage1><current1>[CR]
        <voltage2><current2>[CR]
    OK[CR]  Get saved Voltage and Current value from 3 PS memory loctions
    <voltageX>=???  <currentX>=???  (X is memory location number start from 0 to 2)
GETM[CR]    Return value:   111111[CR]  122122[CR]  133133[CR]  OK[CR]
    Meaning:    PS return following preset value from 3 memory locations;   Memory 0 is 11.1V and 11.1A Memory 1 is 12.2V and 12.2A Memory 2 is 13.3V and 13.3A
RUNM<memory>[CR]    Return value:   OK[CR]  Set Voltage and Current using values saved in memory locations  <memory>=0/1/2
RUNM1[CR]   Return value:   OK[CR]  Meaning:    Set Voltage and Current using values saved in memory location 1










class SUPPLY_HCS_3300(VisaSerial) :
    def __init__(self, serial):
        self.serial_device = None
        if serial[0:5] == '/dev/':
            self.serial_device = serial
            self.search_type_port = True
            super().__init__(self.serial_device, baud = 9600, read_termination = '\r', write_termination = '\r', timeout = 500)
        else:
            ports = comports()
            #print ("FIND  HCS-3300  COM port serial number =  ", serial)
            for port in ports:
                #print ("COM port ", port, "    Serial number = ", port.serial_number, "  Description= ", port.description)
                if port.serial_number == serial:
                    self.serial_device = port.device
                    #print ( "Correct COM port HSC-3300 = ", self.serial_device )
                    break
            super().__init__(self.serial_device, baud = 9600, read_termination = '\r', write_termination = '\r', timeout = 500)

        # idn_string = self.query('GMAX')
# print ('init function IDN string for HSC-3300 = ',self.serial_device,"    " ,idn_string)  

    @property
    def is_available(self) -> bool:
        try:
            idn_string = self.query('GMAX')
            #print ('IDN string for HSC-3300 = ',self.serial_device,"    " ,idn_string)  
            #print ('COM port ',self.serial_device, "     IDN string ", idn_string)  
            x = idn_string.find("162330")
            #print ('Search string ', x )
            if (x > -1):
                return True
            else:
                return False
        except Exception:
            return False

    def device_com_port(self) ->str:
try:
            return self.serial_device
        except Exception:
            pass


#------------------------------------------------------------------------------------------------
#-- dobi se maximalna napetost in maximalni tok   
    def get_maximal_value(self): 
        read_string = self.query('GMAX')
        maximal_voltage = float(read_string[0:3]) / 10
        maximal_current = float(read_string[3:6]) / 10
        return [maximal_voltage, maximal_current]

    #==============================================================================================
#--Input command:   GETS[CR]      Return value: 150180[CR]  OK[CR]
#-- Meaning:
#--   The Voltage value set at 15V
#--   Current value set at 18A
#==============================================================================================
    def get_setting_value(self): 
        read_string = self.query('GETS')
        #print ('HCS-3300   get Settings value  ',read_string)  
        voltage = float(read_string[0:3]) / 10
        current = float(read_string[3:6]) / 10
        return [voltage, current]

    #==============================================================================================
#-- Returns the output voltage setting.
#==============================================================================================
    def get_set_voltage(self) -> float:
        read_string = self.query('GETS')
        voltage = float(read_string[0:3]) / 10
        return voltage
    #==============================================================================================
    #-- Returns the output Current setting.
    #==============================================================================================
    def get_set_current(self) -> float:
        read_string = self.query('GETS')
        current = float(read_string[3:6]) / 10
        return current


    #==============================================================================================
#--Input command:   GETD[CR]      Return value: 150180[CR]  OK[CR]
#-- Get PS Display values of Voltage, Current and  Status of CC/CV
#--   <voltage>=????    <current>=????    <status>=0/1 (0=CV, 1=CC)
#-- Meaning:
#-- Return value:   150016001[CR] OK[CR]
#--   Meaning:
#--     The PS Display value is 15V and 16A.  It is in CC mode.
#==============================================================================================
    def get_display_value(self): 
        try:
            read_string = self.query('GETD')
            voltage = float(read_string[0:4]) / 100
            current = float(read_string[4:8]) / 100
            status = read_string[8:9]
            if status == '0': 
                status = 'CV'
            if status == 'a': 
                status = 'CC'
            return [voltage, current, status]
        except Exception:
            print("ERROR  HCS-3300   get_display_value ")
            pass

#==============================================================================================
#-- Returns the output voltage 
#==============================================================================================
    def get_voltage(self)-> float:
        read_string = self.query('GETD')
        voltage = float(read_string[0:4]) / 100
        return voltage
    #==============================================================================================
    #-- Returns the output Current 
    #==============================================================================================
    def get_current(self) -> float:
        read_string = self.query('GETD')
        current = float(read_string[4:8]) / 100
        return current


    #==============================================================================================
#-- Input Command:  SOUT<status>[CR]    Return value: OK[CR]  
#-- Switch on/off the output of PS  <status>=0/1 (0=ON, 1=OFF)
#-- Input command:  SOUT0[CR] Return value: OK[CR]
#-- Meaning:
#--   Switch on the output of PS
#==============================================================================================
    def set_output_on(self): 
        return self.query('SOUT0')


    def set_output_off(self): 
        return self.query('SOUT1')



    #==============================================================================================
#-- Input Command:  VOLT<voltage>[CR]     Return value: OK[CR]
#--   Preset Voltage value  <voltage>=010<???<Max-Volt
#--   *Max-Volt value refer to product specification
#-- Input command:  VOLT127[CR]   Return value: OK[CR]
#-- Meaning:
#-- Set Voltage value as 12.7V
#==============================================================================================
    def set_voltage(self, setValue:float): 
        if setValue > 0.7:
            settings_string = str((int)(setValue * 10))
            if  len(settings_string) == 1:
                settings_string = "00" + settings_string
            if  len(settings_string) == 2:
                settings_string = "0" + settings_string
            settings_string = 'VOLT' + settings_string
            return self.query(settings_string)
        else:
            return "to low voltage"

    #==============================================================================================
#-- Input Command:  CURR<current>[CR]   Return value: OK[CR]
#-- Preset Current value    <current>=000<???<Max-Curr    *Max-Curr value refer to product specification
#-- Input command:    CURR120[CR]   Return value:   OK[CR]
#-- Meaning:
#--Set Current value as 12.0A
#==============================================================================================
    def set_current(self, setValue:float): 
        settings_string = str((int)(setValue * 10))
        if  len(settings_string) == 1:
            settings_string = "00" + settings_string
        if  len(settings_string) == 2:
            settings_string = "0" + settings_string
        settings_string = 'CURR' + settings_string
        return self.query(settings_string)



class SUPPLY_HCS_3300_plug(DevicePlug) :
#@ conf.inject_positional_args
  def __init__(self, powerSupply_HCS3300_config_port):
    super(SUPPLY_HCS_3300_plug, self).__init__(SUPPLY_HCS_3300, powerSupply_HCS3300_config_port)


















class SUPPLY_HCS_3300(VisaSerial) :
    def __init__(self, serial):
        self.serial_device = None
        if serial[0:5] == '/dev/':
            self.serial_device = serial
            self.search_type_port = True
            super().__init__(self.serial_device, baud = 9600, read_termination = '\r', write_termination = '\r', timeout = 500)
        else:
            ports = comports()
            #print ("FIND  HCS-3300  COM port serial number =  ", serial)
            for port in ports:
                #print ("COM port ", port, "    Serial number = ", port.serial_number, "  Description= ", port.description)
                if port.serial_number == serial:
                    self.serial_device = port.device
                    #print ( "Correct COM port HSC-3300 = ", self.serial_device )
                    break
            super().__init__(self.serial_device, baud = 9600, read_termination = '\r', write_termination = '\r', timeout = 500)

        # idn_string = self.query('GMAX')
# print ('init function IDN string for HSC-3300 = ',self.serial_device,"    " ,idn_string)  

    @property
    def is_available(self) -> bool:
        try:
            idn_string = self.query('GMAX')
            #print ('IDN string for HSC-3300 = ',self.serial_device,"    " ,idn_string)  
            #print ('COM port ',self.serial_device, "     IDN string ", idn_string)  
            x = idn_string.find("162330")
            #print ('Search string ', x )
            if (x > -1):
                return True
            else:
                return False
        except Exception:
            return False

    def device_com_port(self) ->str:
try:
            return self.serial_device
        except Exception:
            pass


#------------------------------------------------------------------------------------------------
#-- dobi se maximalna napetost in maximalni tok   
    def get_maximal_value(self): 
        read_string = self.query('GMAX')
        maximal_voltage = float(read_string[0:3]) / 10
        maximal_current = float(read_string[3:6]) / 10
        return [maximal_voltage, maximal_current]

    #==============================================================================================
#--Input command:   GETS[CR]      Return value: 150180[CR]  OK[CR]
#-- Meaning:
#--   The Voltage value set at 15V
#--   Current value set at 18A
#==============================================================================================
    def get_setting_value(self): 
        read_string = self.query('GETS')
        #print ('HCS-3300   get Settings value  ',read_string)  
        voltage = float(read_string[0:3]) / 10
        current = float(read_string[3:6]) / 10
        return [voltage, current]

    #==============================================================================================
#-- Returns the output voltage setting.
#==============================================================================================
    def get_set_voltage(self) -> float:
        read_string = self.query('GETS')
        voltage = float(read_string[0:3]) / 10
        return voltage
    #==============================================================================================
    #-- Returns the output Current setting.
    #==============================================================================================
    def get_set_current(self) -> float:
        read_string = self.query('GETS')
        current = float(read_string[3:6]) / 10
        return current


    #==============================================================================================
#--Input command:   GETD[CR]      Return value: 150180[CR]  OK[CR]
#-- Get PS Display values of Voltage, Current and  Status of CC/CV
#--   <voltage>=????    <current>=????    <status>=0/1 (0=CV, 1=CC)
#-- Meaning:
#-- Return value:   150016001[CR] OK[CR]
#--   Meaning:
#--     The PS Display value is 15V and 16A.  It is in CC mode.
#==============================================================================================
    def get_display_value(self): 
        try:
            read_string = self.query('GETD')
            voltage = float(read_string[0:4]) / 100
            current = float(read_string[4:8]) / 100
            status = read_string[8:9]
            if status == '0': 
                status = 'CV'
            if status == 'a': 
                status = 'CC'
            return [voltage, current, status]
        except Exception:
            print("ERROR  HCS-3300   get_display_value ")
            pass

#==============================================================================================
#-- Returns the output voltage 
#==============================================================================================
    def get_voltage(self)-> float:
        read_string = self.query('GETD')
        voltage = float(read_string[0:4]) / 100
        return voltage
    #==============================================================================================
    #-- Returns the output Current 
    #==============================================================================================
    def get_current(self) -> float:
        read_string = self.query('GETD')
        current = float(read_string[4:8]) / 100
        return current


    #==============================================================================================
#-- Input Command:  SOUT<status>[CR]    Return value: OK[CR]  
#-- Switch on/off the output of PS  <status>=0/1 (0=ON, 1=OFF)
#-- Input command:  SOUT0[CR] Return value: OK[CR]
#-- Meaning:
#--   Switch on the output of PS
#==============================================================================================
    def set_output_on(self): 
        return self.query('SOUT0')


    def set_output_off(self): 
        return self.query('SOUT1')



    #==============================================================================================
#-- Input Command:  VOLT<voltage>[CR]     Return value: OK[CR]
#--   Preset Voltage value  <voltage>=010<???<Max-Volt
#--   *Max-Volt value refer to product specification
#-- Input command:  VOLT127[CR]   Return value: OK[CR]
#-- Meaning:
#-- Set Voltage value as 12.7V
#==============================================================================================
    def set_voltage(self, setValue:float): 
        if setValue > 0.7:
            settings_string = str((int)(setValue * 10))
            if  len(settings_string) == 1:
                settings_string = "00" + settings_string
            if  len(settings_string) == 2:
                settings_string = "0" + settings_string
            settings_string = 'VOLT' + settings_string
            return self.query(settings_string)
        else:
            return "to low voltage"

    #==============================================================================================
#-- Input Command:  CURR<current>[CR]   Return value: OK[CR]
#-- Preset Current value    <current>=000<???<Max-Curr    *Max-Curr value refer to product specification
#-- Input command:    CURR120[CR]   Return value:   OK[CR]
#-- Meaning:
#--Set Current value as 12.0A
#==============================================================================================
    def set_current(self, setValue:float): 
        settings_string = str((int)(setValue * 10))
        if  len(settings_string) == 1:
            settings_string = "00" + settings_string
        if  len(settings_string) == 2:
            settings_string = "0" + settings_string
        settings_string = 'CURR' + settings_string
        return self.query(settings_string)



class SUPPLY_HCS_3300_plug(DevicePlug) :
#@ conf.inject_positional_args
  def __init__(self, powerSupply_HCS3300_config_port):
    super(SUPPLY_HCS_3300_plug, self).__init__(SUPPLY_HCS_3300, powerSupply_HCS3300_config_port)



'''
Input Command:    PROM<voltage0> < current0 >    < voltage1 >< current1 >  < voltage2 >< current2 > [CR]
Return value:     OK[CR]
Save Voltage and Current value into 3 PS memory locations
<voltageX>=???
<currentX>=???
(X is memory location number start from 0 to 2)
Input command:    PROM111111022122033133[CR]
Return value:     OK[CR]
Meaning:
Preset Memory 0 as 11.1V and 11.1A
Preset Memory 1 as 2.2V and 12.2A
Preset Memory 2 as 3.3V and 13.3A

 



Input Command:    GETM[CR]
Return value:   < voltage0 >< current0 > [CR] < voltage1 >< current1 > [CR] < voltage2 >< current2 > [CR]  OK[CR]
Get saved Voltage and Current value from 3 PS memory loctions
<voltageX>=???
<currentX>=???
(X is memory location number start from 0 to 2)
Input command:    GETM[CR]
Return value:     111111[CR]    122122[CR]    133133[CR]    OK[CR]
Meaning:
PS return following preset value from 3 memory locations;
Memory 0 is 11.1V and 11.1A
Memory 1 is 12.2V and 12.2A
Memory 2 is 13.3V and 13.3A


Input Command:
RUNM<memory>[CR]    Return value: OK[CR]
Set Voltage and Current using values saved in memory locations
<memory>=0/1/2
Input command:    RUNM1[CR]   Return value: OK[CR]
Meaning:
Set Voltage and Current using values saved in memory location 1

'''

*/
