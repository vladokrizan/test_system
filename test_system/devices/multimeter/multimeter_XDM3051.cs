using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static test_system.global_variable;


namespace test_system
{
    internal class multimeter_XDM3051
    {

        public void fun_XDM3051_identifaction()
        {
            mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM3051].WriteLine("*IDN?");
            COMport_device_ident[COMport_SELECT_MULTIMETER_XDM3051] = mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM3051].ReadLine();


              //  COMport_device_idnet[COMport_SELECT_MULTIMETER_XDM3051] = new string[COMport_SELECT_MAXnumber];


        //dataArray = Encoding.ASCII.GetBytes("GMAX\r");
        //mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_330].DiscardInBuffer();
        //mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_330].Write(dataArray, 0, dataArray.Length);
        //Thread.Sleep(20);
        //mainWindow.COMportSerial[COMport_SELECT_SUPPLY_HCS_330].Read(read_buffer, 0, 7);
        //device_HCS_3300_ident = Convert.ToChar(read_buffer[0]).ToString() + Convert.ToChar(read_buffer[1]).ToString() + Convert.ToChar(read_buffer[2]).ToString() + Convert.ToChar(read_buffer[3]).ToString() + Convert.ToChar(read_buffer[4]).ToString() + Convert.ToChar(read_buffer[5]).ToString();
        //device_ET3916_read_all_temperature = true;
    }




}
}


/*












rom dataclasses import dataclass
from openhtf.util import conf
from serial.tools.list_ports import comports
from openhtf.plugs.visa_tools import VisaSerial, VisaComError
from openhtf.core.base_plugs import DevicePlug
from openhtf.core.base_plugs import DevicePlug
from re import compile


#  __identity_regex = compile((r'^(?P<model>(TENMA \d+-\d+|KORAD-KEL\d+)) '
#                              r'(?P<version>V\d+.\w+) '
#                              r'(?P<serial>SN:\d+)'))
#KORAD-KEL103 V1.10 SN:07740976
#
# __identity_regex = re.compile((r'^(?P<company>TENMA)[\s,](?P<model>72-\d+)'  # required parameters
#                                 r'([\s,](?P<version>\w+.\w+))?'                   # optional
#                                 r'([\s,]SN:(?P<serial>\d+))?'))                   # optional
#  TENMA 72-2550 V5.8 SN:03424425



@dataclass
class Identification:
  model: str = ''
  version: str = ''
  serial: str = ''

class OWON_XDM3051_RS232(VisaSerial):
  #-- OWON,XDM3051,2303195,V3.7.2,2
  #__identity_regex = compile((r'^(?P<model>(XDM3051)) '
  #                            r'(?P<version>V\d+.\w+) '
  #                            r'(?P<serial>,\d+)'))
  #__units = {'CURR': 'A', 'VOLT': 'V', 'RES': 'OHM', 'POW': 'W'}

  def __init__(self,serial):
    self.serial_device = None

    ports = comports()
    #print ("FIND  OWON XDM 3051. COM port serial number =  ", serial)
    for port in ports:
      try:
        #print ("COM port ", port, "    Serial number = ", port.serial_number, "  Description= ", port.description)
        if port.serial_number == serial:
          self.serial_device = port.device
          #print ( "Correct COM port XDM3051 = ", self.serial_device )
          super().__init__(self.serial_device,
                     baud=115200,
                     read_termination='\n',
                     write_termination='\n\r',
                     timeout=100)
          break
      except Exception:
        print ("ERROR  ", self.serial_device )
        pass
       

  @property
  def is_available(self) -> bool:
    try:
      idn_string = self.idn()
      #print ('IDN string for OWON XDM3051 = ',self.serial_device,"    " ,idn_string)  
      #print ('COM port ',self.serial_device, "     IDN string ", idn_string)  
      x = idn_string.find("XDM3051")
      #print ('Search string ', x )
      if (x>-1):
        return True
      else:
        return False
    except Exception:
      print ("ERROR  ", self.serial_device )
      return False
  
 
  def device_com_port(self) ->str:
    try:
      return self.serial_device
    except Exception:
      pass 
 


  #@property
  def measure_voltage(self):
    try:
      return self.query('MEAS?')
    except Exception:
      pass 
   
    #return self.query(':MEAS?')

  def set_voltage_dc_range(self,set_range:int):
    #write_string = (f'CONF:FUNCVOLT:DC:{str(set_range)}')  
    #print ("set range string  "+write_string )
    #self.write(write_string)
    write_string = (f'CONF:VOLT:DC {str(set_range)}')  
    print ("set range string  "+write_string )
    self.write(write_string)
    #return self.query(write_string)
 
  def get_voltage_dc_range(self):
    write_string = (f'VOLT:DC:RANG?')  
    return self.query(write_string)
 

class OWON_XDM3051_RS232_plug(DevicePlug):
  #@ conf.inject_positional_args
  def __init__(self, xdm3051_config):
    super(OWON_XDM3051_RS232_plug, self).__init__(OWON_XDM3051_RS232, xdm3051_config)











from dataclasses import dataclass
from openhtf.core.base_plugs import DevicePlug
from openhtf.util import conf
from openhtf.plugs.visa_tools import VisaTCPIP
from re import compile, match
import socket
import pyvisa as  visa
#from openhtf.util import conf


class OWON_XDM3051_ETH(VisaTCPIP) :
#==================================================================================================================
#==================================================================================================================
    def __init__(self, address):
        self.visa = None
        #print (f'IP Address   {address}')
        self.visa = VisaTCPIP(address,
                              port = 3000,
                              read_termination = '\n',
                              write_termination = '\r\n',
                              timeout = 100)
    #==================================================================================================================
    #--   OWON,XDM3051,2303195,V3.7.2,2
    #==================================================================================================================
    @property
    def is_available(self) -> bool:
        try:
            idn_string = self.visa.idn()
            x = idn_string.find("XDM3051")
            if (x > -1):
                return True
            else:
                return False
        except Exception:
           return False

    #==================================================================================================================
#==================================================================================================================
    def measure_voltage(self):
        self.visa.timeout = 2500
        try:
            return self.visa.query('MEAS?')
        except Exception:
            pass

#==================================================================================================================
#==================================================================================================================
    def set_voltage_dc_range(self, set_range: int):
        write_string = (f'CONF:VOLT:DC {str(set_range)}')  
        print("set range string  " + write_string)
        self.visa.write(write_string)

    #==================================================================================================================
#==================================================================================================================
    def get_voltage_dc_range(self):
        write_string = (f'VOLT:DC:RANG?')  
        return self.visa.query(write_string)

class OWON_XDM3051_ETH_plug(DevicePlug) :
#@ conf.inject_positional_args
    def __init__(self, xdm3051_config):
        super(OWON_XDM3051_ETH_plug, self).__init__(OWON_XDM3051_ETH, xdm3051_config)


*/