using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static test_system.global_variable;

namespace test_system
{
    internal class ac_meter_MPM_1010B
    {
        byte[] read_buffer = new byte[100];


        //=======================================================================================================================            
        //=======================================================================================================================            

        private string get_MPM_1010B_one_value(byte start)
        {
            string Receive_value = "";

            Receive_value = (read_buffer[start] & 0x0F).ToString();
            if (read_buffer[start] > 10) Receive_value = Receive_value + ",";
            Receive_value = Receive_value + (read_buffer[start + 1] & 0x0F).ToString();
            if (read_buffer[start + 1] > 10) Receive_value = Receive_value + ",";
            Receive_value = Receive_value + (read_buffer[start + 2] & 0x0F).ToString();
            if (read_buffer[start + 2] > 10) Receive_value = Receive_value + ",";
            Receive_value = Receive_value + (read_buffer[start + 3] & 0x0F).ToString();
            if (read_buffer[start + 3] > 10) Receive_value = Receive_value + ",";
            strGeneralString = Receive_value;

            return Receive_value;

        }

        //=======================================================================================================================            
        //=======================================================================================================================            

        public void fun_read_all_MPM_1010B_write()
        {


            device_MPM1010B_read_all_write = false;
            var dataArray = new byte[10];
            dataArray[0] = 63;
            mainWindow.COMportSerial[COMport_SELECT_AC_METER_MPM_1010B].Write(dataArray, 0, 1);
            device_MPM1010B_read_all_read = true;
            mainWindow.COMportSerial[COMport_SELECT_AC_METER_MPM_1010B].DiscardInBuffer();

        }

        //=======================================================================================================================            
        //=======================================================================================================================            

        public void fun_read_all_MPM_1010B_read()
        {
            
            device_MPM1010B_read_all_read = false;

            int number_bytes_to_read= mainWindow.COMportSerial[COMport_SELECT_AC_METER_MPM_1010B].BytesToRead;

            if (number_bytes_to_read == 21)
            {
                mainWindow.COMportSerial[COMport_SELECT_AC_METER_MPM_1010B].Read(read_buffer, 0, 21);
                device_MPM1010B_voltage = Convert.ToDouble(get_MPM_1010B_one_value(1));
                device_MPM1010B_current = Convert.ToDouble(get_MPM_1010B_one_value(5));
                device_MPM1010B_power = Convert.ToDouble(get_MPM_1010B_one_value(9));
                device_MPM1010B_power_factor = Convert.ToDouble(get_MPM_1010B_one_value(13));
                device_MPM1010B_freguency = Convert.ToDouble(get_MPM_1010B_one_value(17));
            }
            device_MPM1010B_show_data = true;

            if (number_bytes_to_read == 21) COMport_active[COMport_SELECT_AC_METER_MPM_1010B] = true;
            else COMport_active[COMport_SELECT_AC_METER_MPM_1010B] = false;


            //strGeneralString = number_bytes_to_read.ToString();



        }







        //mainWindow.COMportSerial[selectCOMport].Write(sendByte_local, 0, bCOMport_sendLen[selectCOMport]);


        /*
        self.serialPort.write([63])
        # print ("AC POWER METER   MPM1010B available send ?  ")
        receive = self.serialPort.read(21)       
        #print (f'Receive  by AVAIABLE   {receive} ')
        if receive[0] == 0x21: 


        def get_all_measure(self) -> float:

        def get_one_measure_value (start_byte):
            try:
                value_string = None
                #print ("TO FLOAT   " ,hex( receive[start_byte]) ,"  ",hex( receive[start_byte+1]) ,"  ",hex( receive[start_byte+2]) ,"  ",hex( receive[start_byte+3]))                
                value_string =str( receive[start_byte] & 0x0F)
                if (receive[start_byte]>10):
                    value_string = value_string+ "."
                value_string =value_string + str( receive[start_byte+1] & 0x0F)
                if (receive[start_byte+1]>10):
                    value_string =value_string+  "."
                value_string =value_string + str( receive[start_byte+2] & 0x0F)
                if (receive[start_byte+2]>10):
                    value_string =value_string+  "."
                value_string =value_string + str( receive[start_byte+3] & 0x0F)
                if (receive[start_byte+3]>10):
                    value_string =value_string+  "."
                float_value = float (value_string)        
                #print (f'measure string   {start_byte}   {value_string}   {float_value}  ')
                return float_value
            except Exception:
                pass

        #------------------------------------------------------------------------------------------------------------------------          
        #------------------------------------------------------------------------------------------------------------------------          
        try:
            self.serialPort.reset_input_buffer()
            self.serialPort.reset_output_buffer()
            time.sleep(0.1)

            self.serialPort.write([63])
            time.sleep(0.1)
            receive =  self.serialPort.read(21)     
            #print (f'Receive Lenght   {len (receive)}')
            #print ("Receive   ", hex(receive[0]) , " ", hex(receive[1]), " ", hex(receive[2])  , " ", hex(receive[3]) , " ", hex(receive[4]), " ", hex(receive[5])  , " ", hex(receive[6]) , " ", hex(receive[7]), " ", hex(receive[8])  , " ", hex(receive[9]) , " ", hex(receive[10]), " ", hex(receive[11])  , " ", hex(receive[12]) , " ", hex(receive[13]), " ", hex(receive[14])  , " ", hex(receive[15])  , " ", hex(receive[16]), " ", hex(receive[17])  , " ", hex(receive[18]) , " ", hex(receive[19]), " ", hex(receive[20])    ) #, " ", hex(receive[7]), " ", hex(receive[8]), " ", hex(receive[9]))    
            #print (f'Receive MPM-1010B   {receive} ')
            if receive[0] == 0x21: 
                voltage = get_one_measure_value (1)
                current = get_one_measure_value (5)
                power = get_one_measure_value (9)
                power_factor = get_one_measure_value (13)
                #freguency = 0
                freguency = get_one_measure_value (17)
                return [voltage,current,power,power_factor,freguency]
            else: 
                print (f'NOT CORRECT RECIVE MPM-1010B   {receive} ')

                return [0,0,0,0,0]
        except Exception:
            print (f'ERROR Receive MPM-1010B  ')
            self.serialPort.close()
            self.serialPort.open()
            self.serialPort.reset_input_buffer()
            print (f'ERROR Receive MPM-1010B   reset input buffer   ')

            self.serialPort.reset_output_buffer()
            print (f'ERROR Receive MPM-1010B   reset output buffer   ')
            time.sleep(0.5)
            print (f'ERROR Receive MPM-1010B   sleep  100 miliseconds  ')
            self.serialPort.write([63])
            print (f'ERROR Receive MPM-1010B   send ?  ')
            time.sleep(0.5)
            print (f'ERROR Receive MPM-1010B   sleep  100 miliseconds  ')
            receive =  self.serialPort.read(20)     
            print (f'ERROR Receive MPM-1010B   receive  ')
            print (f'ERROR Receive MPM-1010B   {receive}  ')

            #print ("Receive SECOND TIME   ", hex(receive[0]) , " ", hex(receive[1]), " ", hex(receive[2])  , " ", hex(receive[3]) , " ", hex(receive[4]), " ", hex(receive[5])  , " ", hex(receive[6]) , " ", hex(receive[7]), " ", hex(receive[8])  , " ", hex(receive[9]) , " ", hex(receive[10]), " ", hex(receive[11])  , " ", hex(receive[12]) , " ", hex(receive[13]), " ", hex(receive[14])  , " ", hex(receive[15])  , " ", hex(receive[16]), " ", hex(receive[17])  , " ", hex(receive[18])     ) #, " ", hex(receive[7]), " ", hex(receive[8]), " ", hex(receive[9]))    
            if receive[0] == 0x21: 
                voltage = get_one_measure_value (1)
                current = get_one_measure_value (5)
                power = get_one_measure_value (9)
                power_factor = get_one_measure_value (13)
                freguency = 0
                return [voltage,current,power,power_factor,freguency]
            else: 
                return [0,0,0,0,0]



        */




    }
}
