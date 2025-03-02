using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;


namespace test_system
{
    internal class power_supply_KA3305P
    {

        //--    KORAD KA3305P V7.0 SN:30057214
        public void fun_KA3305P_identifaction()
        {
            mainWindow.COMportSerial[COMport_SELECT_SUPPLY_KA3305A].WriteLine("*IDN?");
            COMport_device_ident[COMport_SELECT_SUPPLY_KA3305A] = mainWindow.COMportSerial[COMport_SELECT_SUPPLY_KA3305A].ReadLine();
       }





    }
}




/*
  
  









  
  from dataclasses import dataclass
from openhtf.util import conf
from serial.tools.list_ports import comports
from openhtf.plugs.visa_tools import VisaSerial, VisaComError
from openhtf.core.base_plugs import DevicePlug
from openhtf.core.base_plugs import DevicePlug
from re import compile


class PowerSupply_KORAD_PA3305P_SERIAL(VisaSerial):
    def __init__(self, device_config):

        if device_config[0:5] == '/dev/':
            self.serial_device = device_config
            self.search_type_port =  True
            super().__init__(self.serial_device, baud=115200, read_termination='\n', write_termination='\n',  timeout=50)
        else:
            pass


    @property
    #-- KORAD KA3305P   IDN   KORAD KA3305P V7.0 SN:30057214     Serial number =  003204450454
    def is_available(self) -> bool:
        try:
            #idn_string = self.idn()
            x = self.idn().find("KORAD KA3305P")
            if (x>-1):
                return True
            else:
                return False
        except Exception:
            #print ("ERROR  ", self.serial_device )
            return False
    
    def query_value(self, request: str) -> float:
        reading = super().query(request)
        try:
            return float(str(reading).strip('\n').strip())
        except Exception:
            return reading

    
    #============================================================================================================================
    #============================================================================================================================
    def set_output_on(self): 
        return self.write(f'OUT1')
        #return self.query('SOUT0')
    #============================================================================================================================
    #============================================================================================================================
    def set_output_off(self): 
        return self.write(f'OUT0')


    def set_voltage(self, voltage: float, channel: int = 1):
        #-- Sets the output voltage.
        return self.write(f'VSET{channel}:{round(voltage,2)}')

    def get_output_voltage(self, channel: int = 1) -> float:
        #Returns the output voltage setting.
        return self.query_value(f'VSET{channel}?')



class PowerSupply_KORAD_PA3305P_SERIAL_plug(DevicePlug):
    def __init__(self, device_config):
        super(PowerSupply_KORAD_PA3305P_SERIAL_plug, self).__init__(PowerSupply_KORAD_PA3305P_SERIAL, device_config)







'''
 __identity_regex = re.compile((r'^(?P<company>TENMA)[\s,](?P<model>72-\d+)'  # required parameters
                                 r'([\s,](?P<version>\w+.\w+))?'                   # optional
                                 r'([\s,]SN:(?P<serial>\d+))?'))                   # optional

  def __init__(self, serial):
    try:
      super().__init__(SerailInfo(serial).device,
                       baud=9600,
                       read_termination='\n',
                       write_termination='\n',
                       timeout=2000)
    except SerailInfoDeviceNotFound:
      pass

  def __identify(self) -> Identification:
    'Extracts Instrument information and returns info packet in dataclass'
    try:
      if res := self.__identity_regex.search(self.idn()):
        return Identification(company=res.group('company'),
                              model=res.group('model'),
                              version=res.group('version') if res.group(
            'version') else Identification.version,
            serial=res.group('serial') if res.group(
            'serial') else Identification.serial
        )
      return Identification()
    except Exception:
      return Identification()

  @ property
  def serial_number(self):
    # Provides the serial number of the instrument.
    return self.__identify().serial

  @ property
  def model(self):
    #Provides the model number of the instrument.
    return self.__identify().model

  @ property
  def version(self):
    #Provides the version number of the instrument.
    return self.__identify().version

  @property
  def is_available(self):
    #Provides the True if basic communication (reading serail num) is possible with the device.
    return True if self.serial_number else False

  def __str__(self) -> str:
    return f'{self.model} {self.serial_number}' if self.is_available else type(self).__name__

  
  def set_voltage(self, voltage: float, channel: int = 1):
    #Sets the output voltage.
    return self.write(f'VSET{channel}:{round(voltage,2)}V')

  def get_output_voltage(self, channel: int = 1) -> float:
    #Returns the output voltage setting.
    return self.query_value(f'VSET{channel}?')

  def set_current(self, current: float, channel: int = 1):
    #Sets the output current.
    return self.write(f'ISET{channel}:{round(current,4)}V')

  def get_output_current(self, channel: int = 1) -> float:
    #Returns the output current setting.
    return self.query_value(f'ISET{channel}?')

  def measure_voltage(self, channel: int = 1) -> float:
    #Returns the actual output voltage.
    return self.query_value(f'VOUT{channel}?')

  def measure_current(self, channel: int = 1) -> float:
    #Returns the actual output current.
    return self.query_value(f'IOUT{channel}?')

  def set_beeper(self, enable: bool):
    #Turns on or off the beep.
    return self.write(f'BEEP{1 if enable else 0}')

  def set_output(self, enable: bool):
    #Turns on or off the output.
    return self.write(f'OUT{1 if enable else 0}')

  def output_on(self):
    #Turns on the output.
    return self.set_output(True)

  def output_off(self):
    #Turns ff the output.
    return self.set_output(False)

  def status(self) -> int:
    #Returns the POWER SUPPLY status.
      Contents 8 bits in the following format
      Bit   Item  Description
      0     CH1       0=CC mode, 1=CV mode
      1     CH2       0=CC mode, 1=CV mode
      2,3   Tracking  00=Independent, 01=Tracking series, 11=Tracking parallel
      4     Beep      0=Off, 1=On
      5     Lock      0=Lock, 1=Unlock
      6     Output    0=Off, 1=On
      7     N/A       N/A
    
    resp = self.query('STATUS?').encode('utf8')
    return int.from_bytes(resp, byteorder='little') if resp else None

    












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

class DC_LOAD_KEL_103_SERIAL(VisaSerial):
    #-- OWON,XDM3051,2303195,V3.7.2,2
    #__identity_regex = compile((r'^(?P<model>(XDM3051)) '
    #                            r'(?P<version>V\d+.\w+) '
    #                            r'(?P<serial>,\d+)'))
    #__units = {'CURR': 'A', 'VOLT': 'V', 'RES': 'OHM', 'POW': 'W'}

    def __init__(self,serial):
        self.serial_device = None

        ports = comports()
        #print ("FIND  KEL 103. COM port serial number =  ", serial)
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
    #-- KORAD-KEL103 V1.10 SN:07740976
    def is_available(self) -> bool:
        try:
            idn_string = self.idn()
            #print ('IDN string for KEL 103 = ',self.serial_device,"    " ,idn_string)  
            #print ('COM port ',self.serial_device, "     IDN string ", idn_string)  
            x = idn_string.find("KORAD-KEL103")
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
 

    #============================================================================================================================            
    #============================================================================================================================            
    def KEL103_input_ON(self):
        self.write(f':INP 1')
    #============================================================================================================================            
    #============================================================================================================================            
    def KEL103_input_OFF(self):
        self.write(f':INP 0')


    #============================================================================================================================            
    #============================================================================================================================            
    def KEL103_measure_voltage(self) -> float:
        return  float(self.query(f':MEAS:VOLT?')[:-1])
  



    #============================================================================================================================            
    #============================================================================================================================            
    def KEL103_set_current(self, set_current:float):
        write_string = (f':CURR {str(set_current)}A')  
        self.write(write_string)
        
        #set_current_value = int (set_current * 1000)
        #packet_crc= modbus_class.modbus_rtu_fun_6(self,1,KP184_config_value.set_address_current,set_current_value)
        #self.serialPort.write(packet_crc)
        #receive =  self.serialPort.read(8)
 



  #@property
  #def measure_voltage(self):
  #  try:
  #    return self.query('MEAS?')
  #  except Exception:
  #    pass 
   
    #return self.query(':MEAS?')

  #def set_voltage_dc_range(self,set_range:int):
    #write_string = (f'CONF:FUNCVOLT:DC:{str(set_range)}')  
    #print ("set range string  "+write_string )
    #self.write(write_string)
  #  write_string = (f'CONF:VOLT:DC {str(set_range)}')  
  #  print ("set range string  "+write_string )
  #  self.write(write_string)
    #return self.query(write_string)
 
  #def get_voltage_dc_range(self):
  #  write_string = (f'VOLT:DC:RANG?')  
  #  return self.query(write_string)
 

    class DC_LOAD_KEL_103_SERIAL_plug(DevicePlug):
  #@ conf.inject_positional_args
  def __init__(self, device_config):
    super(DC_LOAD_KEL_103_SERIAL_plug, self).__init__(DC_LOAD_KEL_103_SERIAL, device_config)
    '''
 



*/
