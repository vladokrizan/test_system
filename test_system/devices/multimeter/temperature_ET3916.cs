using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static test_system.global_variable;



namespace test_system
{


    internal class temperature_ET3916
    {

        byte[] read_buffer = new byte[100];


        //=======================================================================================================================
        //=======================================================================================================================
        private UInt16 CalcCrc(IEnumerable<byte> data)
        {
            ushort crc = 0xFFFF;
            //ushort crc = 0;
            foreach (byte pos in data)
            {
                crc ^= pos;
                //--- zanka po bitih enega byta
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 1) != 0) { crc >>= 1; crc ^= 0xA001; }
                    else { crc >>= 1; }
                }
            }
            return crc;
        }


        //=======================================================================================================================
        //=======================================================================================================================

        public void fun_ET3916_send_bytes_command()
        {
            device_ET3916_bytes_command_write = false;
            if (COMport_connected[COMport_SELECT_TEMPERATURE_ET3916])
            {
                mainWindow.COMportSerial[COMport_SELECT_TEMPERATURE_ET3916].Write(device_ET3916_dataArraySend, 0, device_ET3916_bytes_to_send);
                mainWindow.COMportSerial[COMport_SELECT_TEMPERATURE_ET3916].DiscardInBuffer();
                //mainWindow.COMportSerial[COMport_SELECT_TEMPERATURE_ET3916].Read(read_buffer, 0, 10);
                //strGeneralString = ((Char)(read_buffer[4])).ToString() + ((Char)(read_buffer[5])).ToString() + ((Char)(read_buffer[6])).ToString() + ((Char)(read_buffer[7])).ToString() + ((Char)(read_buffer[8])).ToString() + ((Char)(read_buffer[9])).ToString();
            }
        }





        /*
                def send_request(self, command_bytes ):
                    self.sendBytesReguest=bytearray(b'\xFE')
                    CRCNumberBytes = bytearray(command_bytes)
                    #print (CRCNumberBytes , hex (CRCNumberBytes[0]), hex (CRCNumberBytes[1]) , hex (CRCNumberBytes[2])  )
                    crc = self.calc_crc(CRCNumberBytes)
                    my_bytes = crc.to_bytes(2, byteorder = 'little')
                    self.sendBytesReguest.append(CRCNumberBytes[0])
                    self.sendBytesReguest.append(CRCNumberBytes[1])
                    self.sendBytesReguest.append(CRCNumberBytes[2])
                    self.sendBytesReguest.append(my_bytes[0])
                    self.sendBytesReguest.append(my_bytes[1])
                    print(hex (self.sendBytesReguest[0]), hex (self.sendBytesReguest[1]) , hex (self.sendBytesReguest[2]) , hex (self.sendBytesReguest[3]), hex (self.sendBytesReguest[4]), hex (self.sendBytesReguest[5]) )
                    self.serialPort.write(self.sendBytesReguest)
        */



        //=======================================================================================================================
        //=======================================================================================================================

        private void fun_ET3916_send_reguest_bytes(byte[] data)
        {
            byte counter_send_message = 0;
            device_ET3916_dataArraySend[counter_send_message++] = 0xFE;
            byte[] bytes = BitConverter.GetBytes(CalcCrc(data));
            device_ET3916_dataArraySend[counter_send_message++] = data[0];
            device_ET3916_dataArraySend[counter_send_message++] = data[1];
            if (data[1] == 1)
            {
                device_ET3916_bytes_to_send = 6;
                device_ET3916_dataArraySend[counter_send_message++] = data[2];
            }
            if (data[1] == 2)
            {
                device_ET3916_bytes_to_send = 7;
                device_ET3916_dataArraySend[counter_send_message++] = data[2];
                device_ET3916_dataArraySend[counter_send_message++] = data[3];
            }
            device_ET3916_dataArraySend[counter_send_message++] = bytes[0];
            device_ET3916_dataArraySend[counter_send_message++] = bytes[1];
        }
        //=======================================================================================================================
        //=======================================================================================================================
        //-- 2.3.5. Read product model number
        //--            Send(message) : 0x20
        //--    Answer(message) : 0x20 + Product model
        //--    Product Model: 13 bytes in length
        //--            Example
        //--                To read the product model number, send:
        //--                    FE 00 01 20 71 88
        //--                The result returned is "ET3916" :
        //--                    FE 00 0E 20 45 54 33 39 31 36 00 00 00 00 00 00 00 28 E5
        //=======================================================================================================================
        public void fun_ET3916_read_model_nuber()
        {
            var dataArray = new byte[3];
            dataArray[0] = 0;
            dataArray[1] = 1;
            dataArray[2] = 0x20;
            fun_ET3916_send_reguest_bytes(dataArray);
            device_ET3916_bytes_command_write = true;
            device_ET3916_read_model_number = true;
        }

        //=======================================================================================================================
        //=======================================================================================================================
        public void fun_ET3916_read_command_model_number()
        {
            device_ET3916_read_model_number = false;
            if (COMport_connected[COMport_SELECT_TEMPERATURE_ET3916])
            {
                mainWindow.COMportSerial[COMport_SELECT_TEMPERATURE_ET3916].Read(read_buffer, 0, 10);
                strGeneralString = ((Char)(read_buffer[4])).ToString() + ((Char)(read_buffer[5])).ToString() + ((Char)(read_buffer[6])).ToString() + ((Char)(read_buffer[7])).ToString() + ((Char)(read_buffer[8])).ToString() + ((Char)(read_buffer[9])).ToString();
            }
        }


        //=======================================================================================================================
        //=======================================================================================================================
        //--    2.3.6. Read the product serial number
        //--        Send(message) : 0x21
        //--        Answer(message) : 0x21 + product serial number
        //--        Product serial number: 13 bytes long
        //--        Example
        //--              To read the product serial number, send:
        //--                FE 00 01 21 B0 48
        //--            The result returned is "77772153000" :
        //--                FE 00 0E 21 37 37 37 37 32 31 35 33 30 30 30 00 00 1A CA
        public void fun_ET3916_read_serial_number()
        {
            var dataArray = new byte[3];
            dataArray[0] = 0;
            dataArray[1] = 1;
            dataArray[2] = 0x21;
            fun_ET3916_send_reguest_bytes(dataArray);
            device_ET3916_bytes_command_write = true;
            device_ET3916_read_serial_number = true;
        }
       //=======================================================================================================================
        //=======================================================================================================================
        public void fun_ET3916_read_command_serial_number()
        {
            if (COMport_connected[COMport_SELECT_TEMPERATURE_ET3916])
            {
                try
                {
                    device_ET3916_read_serial_number = false;
                    mainWindow.COMportSerial[COMport_SELECT_TEMPERATURE_ET3916].Read(read_buffer, 0, 19);
                    device_ET3916_serial_number = ((Char)(read_buffer[4])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number  +((Char)(read_buffer[5])).ToString(); //+ ((Char)(read_buffer[6])).ToString() + ((Char)(read_buffer[7])).ToString() + ((Char)(read_buffer[8])).ToString() + ((Char)(read_buffer[9])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[6])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[7])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[8])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[9])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[10])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[11])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[12])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[13])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[14])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[14])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[15])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[16])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[17])).ToString();

                    COMport_device_ident[COMport_SELECT_TEMPERATURE_ET3916]= device_ET3916_serial_number;

                }
                catch
                {
                    fun_ET3916_read_serial_number();
                }
                // device_ET3916_serial_number = "Serial number";
            }



        }


        //

        //=======================================================================================================================
        //=======================================================================================================================
        //--        2.3.27. Reading measurements
        //--        Send(message) : 0x60 + Number of read channels range 0x01-0x40
        //--        Reply(message) : 0x60 + Number of channels + measured value
        //--        Measured value: 4 bytes float type, read from ch01 by default, the unit is fixed ° C
        //--        Example
        //--            To read the reference end Settings, send:
        //--                FE 00 02 60 08 88 22
        //--            The return result is, 19.33707 ° C, 19.13878 ° C, 19.27811 ° C, 19.43135 ° C, 19.31111 ° C, 19.44847 ° C, 19.31327 ° C, 19.43354 ° C:
        //--                FE 00 22 60 08 54 B2 9A 41 39 1C 99 41 90 39 9A 41 69 73 9B 41 26 7D 9A 41 78 96 9B 41 93 81 9A 41 E4 77 9B 41 34 3D
        //=======================================================================================================================
        public void fun_ET3916_read_all_temperature()
        {
            var dataArray = new byte[4];
            dataArray[0] = 0;
            dataArray[1] = 2;
            dataArray[2] = 0x60;
            dataArray[3] = 8;
            fun_ET3916_send_reguest_bytes(dataArray);
            device_ET3916_bytes_command_write = true;
            device_ET3916_read_all_temperature = true;
        }
        //=======================================================================================================================
        //=======================================================================================================================
        public void fun_ET3916_read_command_all_temperature()
        {
            device_ET3916_read_all_temperature = false;
            if (COMport_connected[COMport_SELECT_TEMPERATURE_ET3916])
            {
                mainWindow.COMportSerial[COMport_SELECT_TEMPERATURE_ET3916].Read(read_buffer, 0, 37);
                //strGeneralString = (read_buffer[4]).ToString()+"  " + (read_buffer[5]).ToString() +"   " + (read_buffer[6]).ToString() + "   " + (read_buffer[7]).ToString() + "   " + ((Char)(read_buffer[8])).ToString() + "   " + (read_buffer[9]).ToString();

                device_ET3916_temperature[1] = System.BitConverter.ToSingle(read_buffer, 5);
                device_ET3916_temperature[2] = System.BitConverter.ToSingle(read_buffer, 9);
                device_ET3916_temperature[3] = System.BitConverter.ToSingle(read_buffer, 13);
                device_ET3916_temperature[4] = System.BitConverter.ToSingle(read_buffer, 17);
                device_ET3916_temperature[5] = System.BitConverter.ToSingle(read_buffer, 21);
                device_ET3916_temperature[6] = System.BitConverter.ToSingle(read_buffer, 25);
                device_ET3916_temperature[7] = System.BitConverter.ToSingle(read_buffer, 29);
                device_ET3916_temperature[8] = System.BitConverter.ToSingle(read_buffer, 33);
       

            }

            /*
            //--  19.33707 ° C
            read_buffer[4] = 0x54;
            read_buffer[5] = 0xB2;
            read_buffer[6] = 0x9A;
            read_buffer[7] = 0x41;

            device_ET3916_temperature[1] = System.BitConverter.ToSingle(read_buffer, 4);

            read_buffer[8] = 0x39;
            read_buffer[9] = 0x1C;
            read_buffer[10] = 0x99;
            read_buffer[11] = 0x41;

            device_ET3916_temperature[2] = System.BitConverter.ToSingle(read_buffer, 8);
            */


        }






        /*










               private void button3_Click(object sender, EventArgs e)
        {
            temperature_ET3916.fun_ET3916_read_model_nuber();
            label3.Text = strGeneralString;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temperature_ET3916.fun_ET3916_read_model_nuber();
            label7.Text = device_ET3916_dataArraySend[0].ToString("x") + "    " + device_ET3916_dataArraySend[1].ToString("x") + "    " + device_ET3916_dataArraySend[2].ToString("x") + "    " + device_ET3916_dataArraySend[3].ToString("x") + "    " + device_ET3916_dataArraySend[4].ToString("x") + "    " + device_ET3916_dataArraySend[5].ToString("x") + "    ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temperature_ET3916.fun_ET3916_read_serial_number();
            label7.Text = device_ET3916_dataArraySend[0].ToString("x") + "    " + device_ET3916_dataArraySend[1].ToString("x") + "    " + device_ET3916_dataArraySend[2].ToString("x") + "    " + device_ET3916_dataArraySend[3].ToString("x") + "    " + device_ET3916_dataArraySend[4].ToString("x") + "    " + device_ET3916_dataArraySend[5].ToString("x") + "    ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            temperature_ET3916.fun_ET3916_read_all_temperature();
            label7.Text = device_ET3916_dataArraySend[0].ToString("x") + "    " + device_ET3916_dataArraySend[1].ToString("x") + "    " + device_ET3916_dataArraySend[2].ToString("x") + "    " + device_ET3916_dataArraySend[3].ToString("x") + "    " + device_ET3916_dataArraySend[4].ToString("x") + "    " + device_ET3916_dataArraySend[5].ToString("x") + "    " + device_ET3916_dataArraySend[6].ToString("x") + "    ";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // temperature_ET3916.fun_ET3916_read_command_all_temperature();
            label8.Text = device_ET3916_temperature[1].ToString("0.00") + "   " + device_ET3916_temperature[2].ToString("0.00");
        }





    
     *
    Frame composition: Frame header + message length + message + check
    The packet consists of frame header, packet length, packet and check.
    Frame header: 1 byte, used to represent the beginning of the communication data frame, fixed 0xFE
    Message length: 2 bytes, indicating the length of the message, ranging from 1-250 when sending and 1-494 when answering
    Packet: Indicates the specific message to be sent. It consists of command words and content
    The check is CRC. 16 bit cyclic redundancy code, polynomial value 0x8005  



    2.3.5. Read product model number
        Send (message) : 0x20
        Answer (message) : 0x20 + Product model
        Product Model: 13 bytes in length
        Example
            To read the product model number, send:
                FE 00 01 20 71 88
            The result returned is "ET3916" :
                FE 00 0E 20 45 54 33 39 31 36 00 00 00 00 00 00 00 28 E5

    2.3.6. Read the product serial number
        Send (message) : 0x21
        Answer (message) : 0x21 + product serial number
        Product serial number: 13 bytes long
        Example
            To read the product serial number, send:
                FE 00 01 21 B0 48
            The result returned is "77772153000" :
                FE 00 0E 21 37 37 37 37 32 31 35 33 30 30 30 00 00 1A CA



    2.3.27. Reading measurements
        Send (message) : 0x60 + Number of read channels range 0x01-0x40
        Reply (message) : 0x60 + Number of channels + measured value
        Measured value: 4 bytes float type, read from ch01 by default, the unit is fixed ° C
        Example
            To read the reference end Settings, send:
                FE 00 02 60 08 88 22
            The return result is, 19.33707 ° C, 19.13878 ° C, 19.27811 ° C, 19.43135 ° C, 19.31111 ° C, 19.44847 ° C, 19.31327 ° C, 19.43354 ° C:
                FE 00 22 60 08 54 B2 9A 41 39 1C 99 41 90 39 9A 41 69 73 9B 41 26 7D 9A 41 78 96 9B 41 93 81 9A 41 E4 77 9B 41 34 3D



            self.sendBytesReguest=bytearray(b'\xFE')
            Read_product_model_number=b'\x00\x01\x20'


        0xFE , 0x00 , 0x01 , 0x20




    */



        /*
                def calc_crc(self, data):
        crc = 0xFFFF
        for pos in data:
            crc ^= pos 
            #--- zanka po bitih enega byta 
            for i in range(8) :
                if ((crc & 1) != 0):
                    crc >>= 1
                    crc ^= 0xA001
                else:
                    crc >>= 1
        return crc
        */







    }
}







/*

import serial
from openhtf.core.base_plugs import DevicePlug
import time
import errno
import os
import signal
import functools


#-- ET3916

Read_product_model_number=b'\x00\x01\x20'


#>>> import struct
#>>> [x] = struct.unpack('f', b'\xdb\x0fI@')
#>>> x
# [x] = struct.unpack('f', b'\x00\x02\x13\x05@')
#3.1415927410125732


class TimeoutError(Exception):
pass

def timeout(seconds=1, error_message=os.strerror(errno.ETIME)):
def decorator(func):
def _handle_timeout(signum, frame):
    raise TimeoutError(error_message)
@functools.wraps(func)
def wrapper(*args, **kwargs):
    signal.signal(signal.SIGALRM, _handle_timeout)
    signal.alarm(seconds)
    try:
        result = func(*args, **kwargs)
    finally:
        signal.alarm(0)
    return result
return wrapper
return decorator


class TEMPERATURE_METER_ET3916():

#============================================================================================================================
#-- [ 4214.112809] usb 3-3.4.1: Product: FT232R USB UART
#-- [ 4214.112813] usb 3-3.4.1: Manufacturer: FTDI
#-- [ 4214.112816] usb 3-3.4.1: SerialNumber: A10191L7
#-- [ 4214.122023] ftdi_sio 3-3.4.1:1.0: FTDI USB Serial Device converter detected
#-- [ 4214.122073] usb 3-3.4.1: Detected FT232R
#============================================================================================================================
def __init__(self,serial_number):
self.sendBytesReguest=bytearray(b'\xFE')

#print ("Temperature meter ET3916   COM port  =  ", serial_number)
if serial_number != 'None':
    if serial_number[0:5] == '/dev/':
        print ("Temperature meter ET3916   COM port  =  ", serial_number)


        self.serialPort = serial.Serial(
            port=serial_number,
            baudrate=115200,
            parity=serial.PARITY_NONE, 
            stopbits=serial.STOPBITS_ONE, 
            bytesize=serial.EIGHTBITS,
            #xonxoff=serial.PARITY_NONE,
            #rtscts=False, 
            #dsrdtr=False, 
            timeout=500    
        )
        self.serialPort.close()
        self.serialPort.open()
        #self.serialPort.isOpen()



        #self.serial_device =serial_number
        #self.serialPort = serial.Serial(
        #        port=self.serial_device,
        #        #baudrate=115200,
        #        baudrate=9600,
        #        parity=serial.PARITY_NONE, 
        #        #parity=serial.PARITY_SPACE , 
        #        stopbits=serial.STOPBITS_ONE, 
        #        bytesize=serial.EIGHTBITS, 
        #        #xonxoff=serial.XOFF,
        #        #rtscts=False, 
        #3        #dsrdtr=False, 
        #        timeout=100  )
        #self.serialPort.close()
        #self.serialPort.open()
        #self.serialPort.isOpen()



def calc_crc(self,data):
crc = 0xFFFF
for pos in data:
    crc ^= pos 
    #--- zanka po bitih enega byta 
    for i in range(8):
        if ((crc & 1) != 0):
            crc >>= 1
            crc ^= 0xA001
        else:
            crc >>= 1
return crc


def send_request (self, command_bytes ):
self.sendBytesReguest=bytearray(b'\xFE')
CRCNumberBytes = bytearray(command_bytes)
#print (CRCNumberBytes , hex (CRCNumberBytes[0]), hex (CRCNumberBytes[1]) , hex (CRCNumberBytes[2])  )
crc = self.calc_crc(CRCNumberBytes)
my_bytes = crc.to_bytes(2, byteorder='little')
self.sendBytesReguest.append(CRCNumberBytes[0])
self.sendBytesReguest.append(CRCNumberBytes[1])
self.sendBytesReguest.append(CRCNumberBytes[2])
self.sendBytesReguest.append(my_bytes[0])
self.sendBytesReguest.append(my_bytes[1])
print (hex (self.sendBytesReguest[0]), hex (self.sendBytesReguest[1]) , hex (self.sendBytesReguest[2]) , hex (self.sendBytesReguest[3]), hex (self.sendBytesReguest[4]), hex (self.sendBytesReguest[5]) )
self.serialPort.write(self.sendBytesReguest)



#============================================================================================================================
#============================================================================================================================
#@timeout (1)
#@property
def is_available(self) -> bool:
#print ("AC POWER METER   MPM1010B available  ")
#self.serialPort.reset_input_buffer()
#self.serialPort.reset_output_buffer()
#print ("AC POWER METER   MPM1010B available clear send and receive buffer  ")


#send_byte_array = bytearray()
#send_byte_array[0] = 0xFE
#send_byte_array[1] = 0x0
#send_byte_array[2] = 0x1
#send_byte_array[3] = 0x20
#send_byte_array[4] = 0x71
#send_byte_array[5] = 0x88
print ("EXAMPLE CRC ")    
#CRCNumberBytes = bytearray(Read_product_model_number)
##print (CRCNumberBytes , hex (CRCNumberBytes[0]), hex (CRCNumberBytes[1]) , hex (CRCNumberBytes[2])  )
#crc = self.calc_crc(CRCNumberBytes)
#my_bytes = crc.to_bytes(2, byteorder='little')
#self.sendBytesReguest.append(CRCNumberBytes[0])
#"self.sendBytesReguest.append(CRCNumberBytes[1])
#self.sendBytesReguest.append(CRCNumberBytes[2])
#self.sendBytesReguest.append(my_bytes[0])
#self.sendBytesReguest.append(my_bytes[1])
#print (self.sendBytesReguest , hex (self.sendBytesReguest[0]), hex (self.sendBytesReguest[1]) , hex (self.sendBytesReguest[2]) , hex (self.sendBytesReguest[3]), hex (self.sendBytesReguest[4]), hex (self.sendBytesReguest[5]) )
self.send_request(Read_product_model_number)

#----  poslje se ?
#self.serialPort.write(0xFF)
#self.serialPort.write([63])

#self.serialPort.write(send_byte_array,6)
#print ("AC POWER METER   MPM1010B available send ?  ")



#receive =  self.serialPort.read(19)       
#print (f'Receive  by AVAIABLE   {receive} ')
#if receive[0] == 0xFE: 
return True
#else:
#return False    
#============================================================================================================================

#============================================================================================================================
def get_all_measure(self) -> float:
pass

#================================================================================================================================
#================================================================================================================================
class TEMPERATURE_METER_ET3916_plug(DevicePlug):
def __init__(self,config_port):
super(TEMPERATURE_METER_ET3916_plug, self).__init__(TEMPERATURE_METER_ET3916,config_port)



'''


def class_run_app_float_number (self):
print ("EXAMPLE FLOAT NUMBER")    
#-- The return result is, 19.33707 Â°
FloatNumberBytes = bytearray (4)
FloatNumberBytes[0] = 0x54 
FloatNumberBytes[1] = 0xB2 
FloatNumberBytes[2] = 0x9A
FloatNumberBytes[3] = 0x41
print (FloatNumberBytes , hex (FloatNumberBytes[0]), hex (FloatNumberBytes[1]) , hex (FloatNumberBytes[2]) ,  hex (FloatNumberBytes[3]) )
[x] = struct.unpack('f', FloatNumberBytes)
print (x)

*/




