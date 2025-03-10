using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static test_system.global_variable;


namespace test_system
{
    internal class dc_load_KEL103
    {
        functions functions = new functions();

        //=======================================================================================================================
        /// <summary>
        ///   
        /// </summary>
        //--    KORAD-KEL103 V3.30 SN:00022116
        //--#-- KORAD-KEL103 V1.10 SN:07740976
        //=======================================================================================================================
        public void fun_KEL103_identifaction()
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine("*IDN?");
                string ident_readRaw = mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].ReadLine();
                COMport_device_ident[COMport_SELECT_LOAD_KEL103] = functions.fun_ascii_only(ident_readRaw);
                //-------------------------------------------------------------------------------------------------------------------
                if (ident_readRaw.Contains("KORAD-KEL103 V3.30 SN:00022116")) { COMport_active[COMport_SELECT_LOAD_KEL103] = true; }
                else COMport_active[COMport_SELECT_LOAD_KEL103] = false;
            }
        }

        //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        /// def KEL103_input_ON(self):     self.write(f':INP 1')    def set_input_on(self):    self.write(f':INP 1')
        /// </summary>
        //=======================================================================================================================
        public void fun_KEL103_on()
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {
                    mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":INP 1");
                }
            }
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        /// 
        /// 
        ///            def KEL103_input_OFF(self):    self.write(f':INP 0')  def set_input_off(self):         self.write(f':INP 0')
        ///            
        /// 
        /// </summary>
        //=======================================================================================================================
        public void fun_KEL103_off()
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {
                    mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":INP 0");
                }
            }
        }

        //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        /// def KEL103_measure_voltage(self) -> float:  return  float (self.query(f':MEAS:VOLT?')[:-1])
        /// def get_voltage(self) -> float:       return  float (self.query(f':MEAS:VOLT?')[:-1])
        /// </summary>
        //=======================================================================================================================
        public double fun_KEL103_get_voltage()
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {
                    mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":MEAS:VOLT?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].ReadLine();
                    string read_raw_value = read_raw_value_raw.Replace("V", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_voltage = Convert.ToDouble(read_raw_value_float);    
                }
            }
            return 0;
        }

        //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        /// 
        ///      def KEL103_measure_current(self) -> float:       return  float (self.query(f':MEAS:CURR?')[:-1])
        ///       def get_current(self) -> float:      return  float (self.query(f':MEAS:CURR?')[:-1])
        /// 
        /// </summary>
        //=======================================================================================================================
        public double fun_KEL103_get_current()
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {
                    mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":MEAS:CURR?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].ReadLine();
                    string read_raw_value = read_raw_value_raw.Replace("A", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_current = Convert.ToDouble(read_raw_value_float);
                }
            }
            return 0;
        }
      //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        ///            def get_power(self) -> float:  return float (self.query(':MEAS:POW?')[:-1])
        /// 
        /// </summary>
        //=======================================================================================================================
        public double fun_KEL103_get_power()
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {
                    mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":MEAS:POW?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].ReadLine();
                   // strGeneralString = read_raw_value_raw;
                    string read_raw_value = read_raw_value_raw.Replace("W", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_power = Convert.ToDouble(read_raw_value_float);
                }
            }
            return 0;
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        ///      #    return float(self.query(':MEAS:RES?')[:-3])
        /// </summary>
        //=======================================================================================================================
        public double fun_KEL103_get_resistance()
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {
                    mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":MEAS:RES?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].ReadLine();
                     strGeneralString = read_raw_value_raw;
                     string read_raw_value = read_raw_value_raw.Replace("A", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_current = Convert.ToDouble(read_raw_value_float);

                    /*
                    string read_raw_value = read_raw_value_raw.Replace("W", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_power = Convert.ToDouble(read_raw_value_float);
                    KEL103_resistance = 0;
                    */
                }
            }
            return 0;
        }









        //=======================================================================================================================
        //=======================================================================================================================
        //--    :CURRent:CURR   <NR2>MAX|MIN    Set the CC current and query it 
        //--    :CURRent 2ASet the CC voltage as 2A :CURRent?>2AThe CC current is 2A
        public funReturnCodeCOMport fun_KEL103_get_set_cureent()
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {
                    mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":CURR?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].ReadLine();
                    string read_raw_value = read_raw_value_raw.Replace("A", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_get_set_current = Convert.ToDouble(read_raw_value_float);

                }
            }
            return (funReturnCodeCOMport.OK);
        }
        public funReturnCodeCOMport fun_KEL103_set_cureent(double setValue)
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {
                    string setValueString = setValue.ToString("");
                    string setValueString_pika = setValueString.Replace(",", ".");
                    mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":CURR " + setValueString_pika+"A");
                  }
            }
            return (funReturnCodeCOMport.OK);
        }
   
        //=======================================================================================================================
        //=======================================================================================================================
        //--    :VOLTage:VOLT   <NR2>MAX|MIN    Set CV voltage and query CV voltage
        //--    :VOLTage 20VSet the CV voltage as 20V   :VOLTage?>20VThe CV voltage is 20V
        public funReturnCodeCOMport fun_KEL103_get_set_voltage()
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {
                    mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":VOLT?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].ReadLine();
                    string read_raw_value = read_raw_value_raw.Replace("V", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_get_set_voltage = Convert.ToDouble(read_raw_value_float);
                }
            }
            return (funReturnCodeCOMport.OK);
        }
        public funReturnCodeCOMport fun_KEL103_set_voltage(double setValue)
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {
                  //  mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":INP 0");
                }
            }
            return (funReturnCodeCOMport.OK);
        }


        //=======================================================================================================================
        //=======================================================================================================================
        //--    :RESistance:    RES <NR2>MAX|MIN    Set the CR resistor and query it
        //--    :RESistance 20OHMSet the CR resistor as 20Ω     :RESistance?>20OOHMThe CR resistor is 20Ω
        public funReturnCodeCOMport fun_KEL103_set_resistance(double setValue)
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {
                   // mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":INP 0");
                }
            }
            return (funReturnCodeCOMport.OK);
        }


        //=======================================================================================================================
        //=======================================================================================================================
        //--    :POWer:POW  <NR2>MAX|MIN    Set the CW power and query it
        //--    :POWer 20WSet the CW power as 20W   :POWer?>20WThe CW power is 20W
        public funReturnCodeCOMport fun_KEL103_get_set_power()
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {
                    mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":POW?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].ReadLine();
                    // strGeneralString = read_raw_value_raw;
                    string read_raw_value = read_raw_value_raw.Replace("W", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_get_set_power = Convert.ToDouble(read_raw_value_float);
                }
            }
            return (funReturnCodeCOMport.OK);
        }
        public funReturnCodeCOMport fun_KEL103_set_power(double setValue)
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {
                    //mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":INP 0");
                }
            }
            return (funReturnCodeCOMport.OK);
        }


      

        //=======================================================================================================================
        //=======================================================================================================================
        //--    FUNCtion:FUNC
        //--    VOLT|CURR|RES|POW|SHORTDefine the functions:voltage, current,resistor and power
        //--    Only can switch CV, CC, CR, CWCan query CV, CC, CR, CW, that incontinuous mode, pulse, flip, battery andall the other modes.
        //--    :FUNCtion VOLT      Set the constant voltage mode
        //--    :FUNCtion？>VOLTThe current mode isconstant voltage

        //=======================================================================================================================
        //=======================================================================================================================
        public funReturnCodeCOMport fun_KEL103_set_function(string set_function)
        {
            if (COMport_connected[COMport_SELECT_LOAD_KEL103])
            {
                if (COMport_active[COMport_SELECT_LOAD_KEL103])
                {

                    string send_string = ":FUN " + set_function; 

                    mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(send_string);
                }
            }
            return (funReturnCodeCOMport.OK);
        }

        //=======================================================================================================================
        //=======================================================================================================================



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


@dataclass
class Identification:
    model: str = ''
    version: str = ''
    serial: str = ''

class DC_LOAD_KEL_103_SERIAL(VisaSerial):

    def __init__(self,serial):
        self.serial_device = None

        self.serial_device = None
        if serial[0:5] == '/dev/':
            #print ("FIND  KEL 103. AA COM port serial number =  ", serial)
            self.serial_device = serial
            #self.search_type_port =  True
            super().__init__(self.serial_device, baud=115200, read_termination='\n', write_termination='\r\n', timeout=100)
            #print ("FIND  KEL 103. BB COM port serial number =  ", serial)

        else:
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
            #print ('IDN string for KEL 103 = ',self.serial_device)  
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


    #============================================================================================================================            
#============================================================================================================================            
    def device_com_port(self) ->str:
        try:
            return self.serial_device
        except Exception:
            pass 
 

    #============================================================================================================================            
    #============================================================================================================================            
    def KEL103_input_ON(self):
        self.write(f':INP 1')
    def set_input_on(self):
        self.write(f':INP 1')
  
    #============================================================================================================================            
    #============================================================================================================================            
    def KEL103_input_OFF(self):
        self.write(f':INP 0')
    def set_input_off(self):
        self.write(f':INP 0')
    #============================================================================================================================            
    #============================================================================================================================            
    def KEL103_measure_voltage(self) -> float:
        return  float(self.query(f':MEAS:VOLT?')[:-1])
    def get_voltage(self) -> float:
        return  float(self.query(f':MEAS:VOLT?')[:-1])
    #def measure_voltage(self):
    #return self.query(':MEAS:VOLT?')[:-1]
    #============================================================================================================================            
    #============================================================================================================================            
    def KEL103_measure_current(self) -> float:
        return  float(self.query(f':MEAS:CURR?')[:-1])
    def get_current(self) -> float:
        return  float(self.query(f':MEAS:CURR?')[:-1])

    #def measure_current(self):
    #return self.query(':MEAS:CURR?')[:-1]
    #============================================================================================================================            
    #============================================================================================================================            
    def get_power(self) -> float:
        return float(self.query(':MEAS:POW?')[:-1])
        #voltage:float = float(self.query(f':MEAS:VOLT?')[:-1])
        #current:float=  float(self.query(f':MEAS:CURR?')[:-1])
        #return  float(voltage*current)
    #============================================================================================================================            
    #============================================================================================================================            
    #def get_resistence(self) -> float:
    #    print (self.query(':MEAS:RES?'))
    #    return float(self.query(':MEAS:RES?')[:-3])
        #voltage:float = float(self.query(f':MEAS:VOLT?')[:-1])
        #current:float=  float(self.query(f':MEAS:CURR?')[:-1])
        #return  float(voltage*current)
    


    #============================================================================================================================            
    #-- funkcija vrne NAPETOST,TOK,MOÄŚ v list formatu (float stevila)
    #============================================================================================================================            
    def get_measure(self) -> list:
        voltage:float = float(self.query(f':MEAS:VOLT?')[:-1])
        current:float=  float(self.query(f':MEAS:CURR?')[:-1])
        power:float =float(self.query(':MEAS:POW?')[:-1])
        return(voltage,current,power)

    #============================================================================================================================            
#-- funkcija vrne NAPETOST,TOK,MOÄŚ v list formatu (float stevila)
#============================================================================================================================            
    def get_measure(self) -> list:
        voltage:float = float(self.query(f':MEAS:VOLT?')[:-1])
        current:float=  float(self.query(f':MEAS:CURR?')[:-1])
        power:float =float(self.query(':MEAS:POW?')[:-1])
        return(voltage,current,power)



    #============================================================================================================================            
#============================================================================================================================            
    def KEL103_set_current(self, set_current:float):
        write_string = (f':CURR {str(set_current)}A')  
        self.write(write_string)

    def set_current(self, set_current:float):
        write_string = (f':CURR {str(set_current)}A')  
        self.write(write_string)
  
    def get_set_current(self):
        return  float(self.query(f':CURR?')[:-1])
        #write_string = (f':CURR {str(set_current)}A')  
        #self.write(write_string)
        #set_current_value = int (set_current * 1000)
        #packet_crc= modbus_class.modbus_rtu_fun_6(self,1,KP184_config_value.set_address_current,set_current_value)
        #self.serialPort.write(packet_crc)
        #receive =  self.serialPort.read(8)
    #============================================================================================================================            
    #============================================================================================================================            
    def set_voltage(self, set_value:float):
        write_string = (f':VOLT {str(set_value)}V')  
        self.write(write_string)
  
    def get_set_voltage(self):
        return  float(self.query(f':VOLT?')[:-1])
    #============================================================================================================================            
    #============================================================================================================================            
    def set_power(self, set_value:float):
        write_string = (f':POW {str(set_value)}W')  
        self.write(write_string)
  
    def get_set_power(self):
        return  float(self.query(f':POW?')[:-1])
    #============================================================================================================================            
    #============================================================================================================================            
    def set_resistance(self, set_value:float):
        write_string = (f':POW {str(set_value)}W')  
        self.write(write_string)
  
    def get_set_resistance(self):
        return  float(self.query(f':RES?')[:-3])




    #============================================================================================================================            
#============================================================================================================================            
    def get_set_function(self) ->str: 
        return  self.query(f':FUNC?')













    #============================================================================================================================            
#============================================================================================================================            
#def get_RCL_LIST(self): 
#    return  self.query(f':DYN?')
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
  def __init__(self, device_config):
    super(DC_LOAD_KEL_103_SERIAL_plug, self).__init__(DC_LOAD_KEL_103_SERIAL, device_config)


'''

Commands    Parameter   Description                 Setup           Query
1 ô€€ŠIDNďĽź    no          Return product information  no              *IDN?   Return product  information
2 *SAV      <NR1>       1-100                       Store to unit   The current value is saved in   20      no
3 *RCL      <NR1>       1-100                       Recall the storage unit *RCL 20 Recall 20 units no
4 *TRG      no          Simulate an external trigger command, only valid in the pulse mode and the flip mode. *TRG  Simulate trigger once   no
5   :SYSTem :SYST   BEEP|BAUD   Set system parameters such as buzzer, baud  rate setting query etc. :SYSTem:BEEP ON Beep ON :SYSTem:BEEP?   >ON Query the beep ON
6   :STATus?    :STAT?  Baud rateďĽš 0,9600  1,19200 2,38400 3,57600 4,115200    Query the device status The first byte is the buzzer status and the second byte is the baud rate; other bytes are to be determined.
    no  :STATus?    >0,4,0,0,0,0








from openhtf.plugs.visa_tools import VisaSerial, VisaComError
from openhtf.core.base_plugs import DevicePlug
from serial.tools.list_ports import comports
from openhtf.util import conf
from dataclasses import dataclass
from re import compile

class OperatingMode:
  constant_current = 'CURR'
  constant_voltage = 'VOLT'
  constant_resistance = 'RES'
  constant_power = 'POW'
  short = 'SHORT'


@dataclass
class Identification:
  model: str = ''
  version: str = ''
  serial: str = ''


class Tenma72_13210(VisaSerial):
  __identity_regex = compile((r'^(?P<model>(TENMA \d+-\d+|KORAD-KEL\d+)) '
                              r'(?P<version>V\d+.\w+) '
                              r'(?P<serial>SN:\d+)'))
  __units = {'CURR': 'A', 'VOLT': 'V', 'RES': 'OHM', 'POW': 'W'}

  def __init__(self, serial):
    serial_device = None
    ports = comports()
    for port in ports:
      if port.serial_number == serial:
        serial_device = port.device
    super().__init__(serial_device,
                     baud=115200,
                     read_termination='\n',
write_termination='\r\n',
                     timeout=2500)

  def __identify(self):
    #Extracts Instrument information and returns its serial number
    try:
      if res := self.__identity_regex.search(self.idn()):
        return Identification(model=res.group('model'),
                              serial=res.group('serial'),
                              version=res.group('version'))
      else:
        return Identification()
    except VisaComError:
      return Identification()

  @ property
  def model(self):
    #Provides the model number of the instrument.
    return self.__identify().model

  @ property
  def version(self):
    #Provides the firmware version of the instrument.
    return self.__identify().version

  @ property
  def serial_number(self):
    #Provides the serial number of the instrument.
    return self.__identify().serial

  @ property
  def is_available(self) -> bool:
    #Returns True if device identification is successfull. 
    return True if self.serial_number else False

  def __str__(self) -> str:
    return f'{self.model} {self.serial_number}' if self.is_available else type(self).__name__

  def set_input(self, value):
    if value in [1, True, 'On', 'ON', 'on']:
      self.write(':INPut ON')
    if value in [0, False, 'Off', 'OFF', 'off']:
      self.write(':INPut OFF')

  def set_operating_mode(self, mode: OperatingMode, value):
    self.write(f':FUNC {mode}')
    if mode != OperatingMode.short:
      unit = self.__units.get(mode)
      self.write(f':{mode} {value}{unit}')

class Tenma72_13210Plug(DevicePlug):
  @ conf.inject_positional_args
  def __init__(self, tenma_config):
    super(Tenma72_13210Plug, self).__init__(Tenma72_13210, tenma_config)

'''

'''
from dataclasses import dataclass
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

class DC_LOAD_KEL_103_SERIAL(VisaSerial):

#-- OWON,XDM3051,2303195,V3.7.2,2
#__identity_regex = compile((r'^(?P<model>(XDM3051)) '
#                            r'(?P<version>V\d+.\w+) '
#                            r'(?P<serial>,\d+)'))
#__units = {'CURR': 'A', 'VOLT': 'V', 'RES': 'OHM', 'POW': 'W'}

    def __init__(self,serial):
        self.serial_device = None

        self.serial_device = None
        if serial[0:5] == '/dev/':
            #print ("FIND  KEL 103. COM port serial number =  ", serial)
            self.serial_device = serial
            self.search_type_port =  True
            super().__init__(self.serial_device, baud=115200, read_termination='\n', write_termination='\r\n', timeout=100)
        else:
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
    def KEL103_measure_current(self) -> float:
        return  float(self.query(f':MEAS:CURR?')[:-1])
  



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
'''from dataclasses import dataclass
from openhtf.util import conf
from serial.tools.list_ports import comports
from openhtf.plugs.visa_tools import VisaSerial, VisaComError
from openhtf.core.base_plugs import DevicePlug
from openhtf.core.base_plugs import DevicePlug
from re import compile


@dataclass
class Identification:
    model: str = ''
    version: str = ''
    serial: str = ''

class DC_LOAD_KEL_103_SERIAL(VisaSerial):

    def __init__(self,serial):
        self.serial_device = None

        self.serial_device = None
        if serial[0:5] == '/dev/':
            #print ("FIND  KEL 103. AA COM port serial number =  ", serial)
            self.serial_device = serial
            #self.search_type_port =  True
            super().__init__(self.serial_device, baud=115200, read_termination='\n', write_termination='\r\n', timeout=100)
            #print ("FIND  KEL 103. BB COM port serial number =  ", serial)

        else:
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
            #print ('IDN string for KEL 103 = ',self.serial_device)  
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


    #============================================================================================================================            
#============================================================================================================================            
    def device_com_port(self) ->str:
        try:
            return self.serial_device
        except Exception:
            pass 
 

    #============================================================================================================================            
    #============================================================================================================================            
    def KEL103_input_ON(self):
        self.write(f':INP 1')
    def set_input_on(self):
        self.write(f':INP 1')
  
    #============================================================================================================================            
    #============================================================================================================================            
    def KEL103_input_OFF(self):
        self.write(f':INP 0')
    def set_input_off(self):
        self.write(f':INP 0')
    #============================================================================================================================            
    #============================================================================================================================            
    def KEL103_measure_voltage(self) -> float:
        return  float(self.query(f':MEAS:VOLT?')[:-1])
    def get_voltage(self) -> float:
        return  float(self.query(f':MEAS:VOLT?')[:-1])
    #def measure_voltage(self):
    #return self.query(':MEAS:VOLT?')[:-1]
    #============================================================================================================================            
    #============================================================================================================================            
    def KEL103_measure_current(self) -> float:
        return  float(self.query(f':MEAS:CURR?')[:-1])
    def get_current(self) -> float:
        return  float(self.query(f':MEAS:CURR?')[:-1])

    #def measure_current(self):
    #return self.query(':MEAS:CURR?')[:-1]
    #============================================================================================================================            
    #============================================================================================================================            
    def get_power(self) -> float:
        return float(self.query(':MEAS:POW?')[:-1])
        #voltage:float = float(self.query(f':MEAS:VOLT?')[:-1])
        #current:float=  float(self.query(f':MEAS:CURR?')[:-1])
        #return  float(voltage*current)
    #============================================================================================================================            
    #============================================================================================================================            
    #def get_resistence(self) -> float:
    #    print (self.query(':MEAS:RES?'))
    #    return float(self.query(':MEAS:RES?')[:-3])
        #voltage:float = float(self.query(f':MEAS:VOLT?')[:-1])
        #current:float=  float(self.query(f':MEAS:CURR?')[:-1])
        #return  float(voltage*current)
    


    #============================================================================================================================            
    #-- funkcija vrne NAPETOST,TOK,MOÄŚ v list formatu (float stevila)
    #============================================================================================================================            
    def get_measure(self) -> list:
        voltage:float = float(self.query(f':MEAS:VOLT?')[:-1])
        current:float=  float(self.query(f':MEAS:CURR?')[:-1])
        power:float =float(self.query(':MEAS:POW?')[:-1])
        return(voltage,current,power)

    #============================================================================================================================            
#-- funkcija vrne NAPETOST,TOK,MOÄŚ v list formatu (float stevila)
#============================================================================================================================            
    def get_measure(self) -> list:
        voltage:float = float(self.query(f':MEAS:VOLT?')[:-1])
        current:float=  float(self.query(f':MEAS:CURR?')[:-1])
        power:float =float(self.query(':MEAS:POW?')[:-1])
        return(voltage,current,power)



    #============================================================================================================================            
#============================================================================================================================            
    def KEL103_set_current(self, set_current:float):
        write_string = (f':CURR {str(set_current)}A')  
        self.write(write_string)

    def set_current(self, set_current:float):
        write_string = (f':CURR {str(set_current)}A')  
        self.write(write_string)
  
    def get_set_current(self):
        return  float(self.query(f':CURR?')[:-1])
        #write_string = (f':CURR {str(set_current)}A')  
        #self.write(write_string)
        #set_current_value = int (set_current * 1000)
        #packet_crc= modbus_class.modbus_rtu_fun_6(self,1,KP184_config_value.set_address_current,set_current_value)
        #self.serialPort.write(packet_crc)
        #receive =  self.serialPort.read(8)
    #============================================================================================================================            
    #============================================================================================================================            
    def set_voltage(self, set_value:float):
        write_string = (f':VOLT {str(set_value)}V')  
        self.write(write_string)
  
    def get_set_voltage(self):
        return  float(self.query(f':VOLT?')[:-1])
    #============================================================================================================================            
    #============================================================================================================================            
    def set_power(self, set_value:float):
        write_string = (f':POW {str(set_value)}W')  
        self.write(write_string)
  
    def get_set_power(self):
        return  float(self.query(f':POW?')[:-1])
    #============================================================================================================================            
    #============================================================================================================================            
    def set_resistance(self, set_value:float):
        write_string = (f':POW {str(set_value)}W')  
        self.write(write_string)
  
    def get_set_resistance(self):
        return  float(self.query(f':RES?')[:-3])




    #============================================================================================================================            
#============================================================================================================================            
    def get_set_function(self) ->str: 
        return  self.query(f':FUNC?')













    #============================================================================================================================            
#============================================================================================================================            
#def get_RCL_LIST(self): 
#    return  self.query(f':DYN?')
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
  def __init__(self, device_config):
    super(DC_LOAD_KEL_103_SERIAL_plug, self).__init__(DC_LOAD_KEL_103_SERIAL, device_config)


'''

Commands    Parameter   Description                 Setup           Query
1 ô€€ŠIDNďĽź    no          Return product information  no              *IDN?   Return product  information
2 *SAV      <NR1>       1-100                       Store to unit   The current value is saved in   20      no
3 *RCL      <NR1>       1-100                       Recall the storage unit *RCL 20 Recall 20 units no
4 *TRG      no          Simulate an external trigger command, only valid in the pulse mode and the flip mode. *TRG  Simulate trigger once   no
5   :SYSTem :SYST   BEEP|BAUD   Set system parameters such as buzzer, baud  rate setting query etc. :SYSTem:BEEP ON Beep ON :SYSTem:BEEP?   >ON Query the beep ON
6   :STATus?    :STAT?  Baud rateďĽš 0,9600  1,19200 2,38400 3,57600 4,115200    Query the device status The first byte is the buzzer status and the second byte is the baud rate; other bytes are to be determined.
    no  :STATus?    >0,4,0,0,0,0








from openhtf.plugs.visa_tools import VisaSerial, VisaComError
from openhtf.core.base_plugs import DevicePlug
from serial.tools.list_ports import comports
from openhtf.util import conf
from dataclasses import dataclass
from re import compile

class OperatingMode:
constant_current = 'CURR'
  constant_voltage = 'VOLT'
  constant_resistance = 'RES'
  constant_power = 'POW'
  short = 'SHORT'


@dataclass
class Identification:
model: str = ''
  version: str = ''
  serial: str = ''


class Tenma72_13210(VisaSerial):
  __identity_regex = compile((r'^(?P<model>(TENMA \d+-\d+|KORAD-KEL\d+)) '
                              r'(?P<version>V\d+.\w+) '
                              r'(?P<serial>SN:\d+)'))
  __units = {'CURR': 'A', 'VOLT': 'V', 'RES': 'OHM', 'POW': 'W'}

  def __init__(self, serial):
    serial_device = None
    ports = comports()
    for port in ports:
      if port.serial_number == serial:
        serial_device = port.device
    super().__init__(serial_device,
                     baud=115200,
                     read_termination='\n',
                     write_termination='\r\n',
                     timeout=2500)

  def __identify(self):
    #Extracts Instrument information and returns its serial number
    try:
      if res := self.__identity_regex.search(self.idn()):
        return Identification(model=res.group('model'),
                              serial=res.group('serial'),
                              version=res.group('version'))
      else:
        return Identification()
    except VisaComError:
      return Identification()

  @ property
  def model(self):
    #Provides the model number of the instrument.
    return self.__identify().model

  @ property
  def version(self):
    #Provides the firmware version of the instrument.
    return self.__identify().version

  @ property
  def serial_number(self):
    #Provides the serial number of the instrument.
    return self.__identify().serial

  @ property
  def is_available(self) -> bool:
    #Returns True if device identification is successfull. 
    return True if self.serial_number else False

  def __str__(self) -> str:
    return f'{self.model} {self.serial_number}' if self.is_available else type(self).__name__

  def set_input(self, value):
    if value in [1, True, 'On', 'ON', 'on']:
      self.write(':INPut ON')
    if value in [0, False, 'Off', 'OFF', 'off']:
      self.write(':INPut OFF')

  def set_operating_mode(self, mode: OperatingMode, value):
    self.write(f':FUNC {mode}')
    if mode != OperatingMode.short:
      unit = self.__units.get(mode)
      self.write(f':{mode} {value}{unit}')

class Tenma72_13210Plug(DevicePlug):
  @ conf.inject_positional_args
  def __init__(self, tenma_config):
    super(Tenma72_13210Plug, self).__init__(Tenma72_13210, tenma_config)

'''

'''
from dataclasses import dataclass
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

class DC_LOAD_KEL_103_SERIAL(VisaSerial):
    #-- OWON,XDM3051,2303195,V3.7.2,2
    #__identity_regex = compile((r'^(?P<model>(XDM3051)) '
    #                            r'(?P<version>V\d+.\w+) '
    #                            r'(?P<serial>,\d+)'))
    #__units = {'CURR': 'A', 'VOLT': 'V', 'RES': 'OHM', 'POW': 'W'}

    def __init__(self,serial):
        self.serial_device = None

        self.serial_device = None
        if serial[0:5] == '/dev/':
            #print ("FIND  KEL 103. COM port serial number =  ", serial)
            self.serial_device = serial
            self.search_type_port =  True
            super().__init__(self.serial_device, baud=115200, read_termination='\n', write_termination='\r\n', timeout=100)
        else:
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
    def KEL103_measure_current(self) -> float:
        return  float(self.query(f':MEAS:CURR?')[:-1])
  



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
