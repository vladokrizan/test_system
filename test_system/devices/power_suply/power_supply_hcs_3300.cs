﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace test_system
{
    internal class power_supply_hcs_3300
    {




    }
}


/*


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
