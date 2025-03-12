using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_system.Properties;
using static test_system.global_variable;


namespace test_system
{
    internal class power_supply_KA3305P
    {

        functions functions = new functions();


        //=======================================================================================================================
        /// <summary>
        /// 
        ///--   6. VOUT<X>?     Description：Returns the actual output voltage.Example VOUT1?
        ///    5. IOUT<X>?      Description：Returns the actual output current.  Example IOUT1?  Returns the CH1 output current
        /// 
        /// </summary>
        //=======================================================================================================================

        public funReturnCodeCOMport fun_KA3305P_get_voltage_current(int select_channel)
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

                    switch (select_channel)
                    {
                        case 1: KA3305P_out_voltage_1 = Convert.ToDouble(read_answer); break;
                        case 2: KA3305P_out_voltage_2 = Convert.ToDouble(read_answer); break;
                    }
                    send_command = "IOUT" + select_channel.ToString() + "?";
                    mainWindow.COMportSerial[COMport_KA3305A].WriteLine(send_command);
                    read_answer = mainWindow.COMportSerial[COMport_KA3305A].ReadLine();

                    switch (select_channel)
                    {
                        case 1: KA3305P_out_current_1 = Convert.ToDouble(read_answer); break;
                        case 2: KA3305P_out_current_2 = Convert.ToDouble(read_answer); break;
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
        public funReturnCodeCOMport fun_KA3305P_set_voltage(int select_channel, double set_voltage)
        {
            //string send_command;
            //string read_answer;
            if (dev_connected[COMport_KA3305A])
            {
                if (dev_active[COMport_KA3305A])
                {

                    return (funReturnCodeCOMport.OK);
                }
                return (funReturnCodeCOMport.NOT_ACTIVE);
            }
            return (funReturnCodeCOMport.NOT_CONNECTED);
        }





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
        //=======================================================================================================================
        //=======================================================================================================================
        //=======================================================================================================================
        //=======================================================================================================================
        //=======================================================================================================================
        //=======================================================================================================================



        public void fun_KA3305P_on(int selectChannel)
        {



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
