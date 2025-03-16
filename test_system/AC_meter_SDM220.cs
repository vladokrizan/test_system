using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using test_system;

namespace test_system
{
    class AC_meter_SDM220
    {




    }
}


/*

from dataclasses import dataclass
from queue import Empty
#from openhtf.util import conf
#from serial.tools.list_ports import comports
#from openhtf.plugs.visa_tools import VisaSerial, VisaComError
from openhtf.core.base_plugs import DevicePlug
#from re import compile
import serial
import time
import errno
import os
import signal
import functools
import struct

from modbus_function import modbus_class


#-- ( 'V', 0x00, '%6.2f' ), # Voltage [V]
#-- ( 'Curr', 0x06, '%6.2f' ), # Current [A]
#-- ( 'P[act]', 0x0c, '%6.0f' ), # Active Power ("Wirkleistung") [W]
#-- ( 'P[app]', 0x12, '%6.0f' ), # Apparent Power ("Scheinl.") [W]
#-- ( 'P[rea]', 0x18, '%6.0f' ), # Reactive Power ("Blindl.") [W]
#-- ( 'PF', 0x1e, '%6.3f' ), # Power Factor [1]
#-- ( 'Phi', 0x24, '%6.1f' ), # cos(Phi)? [1]
#-- ( 'Freq', 0x46, '%6.2f' ), # Line Frequency [Hz]
#-- ( 'W[act]', 0x0156, '%6.2f' ), # Energy [kWh]
#-- ( 'W[rea]', 0x0158, '%6.2f' ) # Energy react [kvarh]




class AC_METER_SDM220(modbus_class) :

#============================================================================================================================
#============================================================================================================================
    def __init__(self, serial_number):
        
        print("AC METER SDM220-MODBUS  COM port  =  ", serial_number)
        if serial_number != 'None':
            #self.serialPort.close()
        
            self.serial_device = serial_number
            self.serialPort = serial.Serial(
port = self.serial_device,
                        baudrate = 9600,
                        parity = serial.PARITY_NONE,
                        stopbits = serial.STOPBITS_ONE,
                        bytesize = serial.EIGHTBITS,
# xonxoff=serial.PARITY_NONE,
# rtscts=False, 
# dsrdtr=False, 
                        timeout = 100)
            self.serialPort.close()
            self.serialPort.open()
            #self.serialPort.isOpen()


    #============================================================================================================================
    #============================================================================================================================
    @property
    def is_available(self) -> bool:
        try:
            packet_crc = modbus_class.modbus_rtu_fun_3(self, 5, 0, 2)
            self.serialPort.reset_input_buffer()
            self.serialPort.reset_output_buffer()
            self.serialPort.write(packet_crc)
            #print (f'packet_crc {packet_crc}')
            #% //print ("SEND   ",packet_crc[0], " ", packet_crc[1], " ", packet_crc[2], " ", hex(packet_crc[3]), " ", hex(packet_crc[4]), " ", hex(packet_crc[5]), " ", hex(packet_crc[6]), " ", hex(packet_crc[7]) , " ", hex(receive[8]) )# , " ", hex(receive[9]))    
            #time.sleep(RD60XX_modbus.RD60XX_TIME_RECEIVE_SEND)
            receive = self.serialPort.read(9)
            self.serialPort.reset_input_buffer()
            #print ("RECEIVE  ",  receive)
            print("Available receive   ", receive[0], " ", receive[1], " ", receive[2], " ", hex(receive[3]), " ", hex(receive[4]), " ", hex(receive[5]), " ", hex(receive[6]), " ", hex(receive[7]), " ", hex(receive[8]))#  , " ", hex(receive[9]))    
            #signature = receive[3] * 0x100 + receive[4]
            #print (f'Received signature  {hex(signature) }   ')
            #if receive[0] == 1 and receive[1] ==3 and receive[2] ==2: 
                #if signature ==RD60XX_modbus_register_value.RD6006_signature_value: 
                #    return True
                #elif signature == RD60XX_modbus_register_value.RD6024_signature_value: 
            #        return True
            #    else:      
            #        return False    
            #else: 
            #    return False    
        except Exception:
            print("ERROR SDM220 is_available function")

            return False



    def read_register_return_float_value(self, register_address ) -> float:
        #print ("RD6006 READ ALL register")
        self.serialPort.reset_input_buffer()
        #packet_crc= modbus_class.modbus_rtu_fun_6(self,RD6006.modbus_address,RD6006_modbus_register_address.RD6006_on_off,0)
        packet_crc = modbus_class.modbus_rtu_fun_4(self, 5, register_address, 2)
        #packet_crc= modbus_class.modbus_rtu_fun_4(self,5,0,2)
        #print (packet_crc)
        self.serialPort.write(packet_crc)
        #$time.sleep(RD60XX_modbus.RD60XX_TIME_RECEIVE_SEND)
        rec = self.serialPort.read(9)
        #print ("receive " , rec)
        #print ("receive   ",rec[0], " ", rec[1], " ", rec[2], " ", hex(rec[3])  , " ", hex(rec[4]), " ", hex(rec[5]) , " ", hex(rec[6])  , " ", hex(rec[7]), " ", hex(rec[8]) )#  , " ", hex(receive[9]))    

        data_bytes = [0, 0, 0, 0]
        data_bytes[0] = rec[6]
        data_bytes[1] = rec[5]
        data_bytes[2] = rec[4]
        data_bytes[3] = rec[3]
        #data_bytes =rec[3:7]
        #print (hex(data_bytes[0]), " ", hex(data_bytes[1]), " ",hex(data_bytes[2]), " ", hex(data_bytes[3]))
        byte_array = bytearray(data_bytes)
        float_number =struct.unpack('f', byte_array)
        #print ("float number ",float_number[0])
        #float_number_retutn = float (float_number)
        #print (f'Float number   {float_number}')
        return float_number[0]






    #-- ( 'V', 0x00, '%6.2f' ), # Voltage [V]
    def read_SDM220_voltage(self)->float: 
        try:
            return self.read_register_return_float_value(0)
        except Exception:
            print("ERROR read_SDM220_voltage ")
            self.serialPort.reset_input_buffer()

    #-- ( 'Curr', 0x06, '%6.2f' ), # Current [A]
    def read_SDM220_current(self)->float: 
        try:
            return self.read_register_return_float_value(0x06)
        except Exception:
            print("ERROR read_SDM220_current ")
            self.serialPort.reset_input_buffer()

    #-- ( 'P[act]', 0x0c, '%6.0f' ), # Active Power ("Wirkleistung") [W]
    def read_SDM220_ActivePower(self)->float: 
        try:
            return self.read_register_return_float_value(0x0C)
        except Exception:
            print("ERROR read_SDM220_current_1 ")
            self.serialPort.reset_input_buffer()


    #-- ( 'P[app]', 0x12, '%6.0f' ), # Apparent Power ("Scheinl.") [W]
    def read_SDM220_ApparentPower(self)->float: 
        try:
            return self.read_register_return_float_value(0x12)
        except Exception:
            print("ERROR read_SDM220_current_1 ")
            self.serialPort.reset_input_buffer()

    #-- ( 'P[rea]', 0x18, '%6.0f' ), # Reactive Power ("Blindl.") [W]
    def read_SDM220_ReactivePower(self)->float: 
        try:
            return self.read_register_return_float_value(0x18)
        except Exception:
            print("ERROR read_SDM220_ReactivePower ")
            self.serialPort.reset_input_buffer()

    #-- ( 'PF', 0x1e, '%6.3f' ), # Power Factor [1]
    def read_SDM220_PowerFactor(self)->float: 
        try:
            return self.read_register_return_float_value(0x1E)
        except Exception:
            print("ERROR read_SDM220_Power Factor ")
            self.serialPort.reset_input_buffer()


    #-- ( 'Phi', 0x24, '%6.1f' ), # cos(Phi)? [1]
    def read_SDM220_cosFi(self)->float: 
        try:
            return self.read_register_return_float_value(0x24)
        except Exception:
            print("ERROR read_SDM220_cosFi ")
            self.serialPort.reset_input_buffer()

    #-- ( 'Freq', 0x46, '%6.2f' ), # Line Frequency [Hz]
    def read_SDM220_LineFrequency(self)->float: 
        try:
            return self.read_register_return_float_value(0x46)
        except Exception:
            print("ERROR read_SDM220_Line Frequency ")
            self.serialPort.reset_input_buffer()

    #-- ( 'W[act]', 0x0156, '%6.2f' ), # Energy [kWh]
    def read_SDM220_Energy(self)->float: 
        try:
            return self.read_register_return_float_value(0x156)
        except Exception:
            print("ERROR read_SDM220_Energy ")
            self.serialPort.reset_input_buffer()


    #-- ( 'W[rea]', 0x0158, '%6.2f' ) # Energy react [kvarh]
    def read_SDM220_EnergyReact(self)->float: 
        try:
            return self.read_register_return_float_value(0x158)
        except Exception:
            print("ERROR read_SDM220_EnergyReact ")
            self.serialPort.reset_input_buffer()



    def read_register_SDM220(self): 
        try:
            #print ("RD6006 READ ALL register")
            self.serialPort.reset_input_buffer()
            #packet_crc= modbus_class.modbus_rtu_fun_6(self,RD6006.modbus_address,RD6006_modbus_register_address.RD6006_on_off,0)
            packet_crc = modbus_class.modbus_rtu_fun_4(self, 5, 0, 30)
            #packet_crc= modbus_class.modbus_rtu_fun_4(self,5,0,2)
            #print (packet_crc)
            self.serialPort.write(packet_crc)
            #$time.sleep(RD60XX_modbus.RD60XX_TIME_RECEIVE_SEND)
            rec = self.serialPort.read(65)
            print("receive ", rec)


        except Exception:
            print("ERROR SDM220 READ ALL REGISTER ")
            self.serialPort.reset_input_buffer()














class AC_METER_SDM220_plug(DevicePlug) :
    def __init__(self, config_port):
        super(AC_METER_SDM220_plug, self).__init__(AC_METER_SDM220, config_port)

*/