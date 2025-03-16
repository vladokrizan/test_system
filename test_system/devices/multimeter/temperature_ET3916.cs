using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static test_system.global_variable;



namespace test_system
{
    internal class temperature_ET3916
    {

        functions functions = new functions();

        //-----------------------------------------------------------------------------------------------------------------------
        //--    Frame composition: Frame header + message length + message + check
        //--    The packet consists of frame header, packet length, packet and check.
        //--    Frame header: 1 byte, used to represent the beginning of the communication data frame, fixed 0xFE
        //--    Message length: 2 bytes, indicating the length of the message,
        //--    ranging from 1 - 250 when sending and 1 - 494 when answering
        //--    Packet: Indicates the specific message to be sent.It consists of command words and content
        //--    The check is CRC. 16 bit cyclic redundancy code, polynomial value 0x8005
        //-----------------------------------------------------------------------------------------------------------------------

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
        public funReturnCodeCOMport fun_ET3916_send_bytes_command()
        {
            device_ET3916_bytes_command_write = false;
            if (dev_connected[COMport_ET3916])
            {
                mainWindow.COMportSerial[COMport_ET3916].Write(device_ET3916_dataArraySend, 0, device_ET3916_bytes_to_send);
                mainWindow.COMportSerial[COMport_ET3916].DiscardInBuffer();
                return (funReturnCodeCOMport.OK);
            }
            else return (funReturnCodeCOMport.NOT_CONNECTED);
        }


        //=======================================================================================================================
        /// <summary>
        ///      pripravi paket, ki ga Timer pošlje na COM port
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //=======================================================================================================================
        private funReturnCodeCOMport fun_ET3916_send_reguest_bytes(byte[] data)
        {
            if (dev_connected[COMport_ET3916])
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
                return (funReturnCodeCOMport.OK);
            }
            else return (funReturnCodeCOMport.NOT_CONNECTED);
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
        public funReturnCodeCOMport fun_ET3916_read_command_model_number()
        {
            device_ET3916_read_model_number = false;
            if (dev_connected[COMport_ET3916])
            {
                mainWindow.COMportSerial[COMport_ET3916].Read(read_buffer, 0, 10);
                //strGeneralString = ((Char)(read_buffer[4])).ToString() + ((Char)(read_buffer[5])).ToString() + ((Char)(read_buffer[6])).ToString() + ((Char)(read_buffer[7])).ToString() + ((Char)(read_buffer[8])).ToString() + ((Char)(read_buffer[9])).ToString();
                return (funReturnCodeCOMport.OK);
            }
            else return (funReturnCodeCOMport.NOT_CONNECTED);
        }


        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
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
        //=======================================================================================================================
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
        //--    065124120022
        //=======================================================================================================================
        public funReturnCodeCOMport fun_ET3916_read_command_serial_number()
        {
            if (dev_connected[COMport_ET3916])
            {
                try
                {
                    device_ET3916_read_serial_number = false;
                    mainWindow.COMportSerial[COMport_ET3916].Read(read_buffer, 0, 19);
                    device_ET3916_serial_number = ((Char)(read_buffer[4])).ToString();
                    device_ET3916_serial_number = device_ET3916_serial_number + ((Char)(read_buffer[5])).ToString(); //+ ((Char)(read_buffer[6])).ToString() + ((Char)(read_buffer[7])).ToString() + ((Char)(read_buffer[8])).ToString() + ((Char)(read_buffer[9])).ToString();
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
                    //-----------------------------------------------------------------------------------------------------------
                    COMport_device_ident[COMport_ET3916] = functions.fun_ascii_only(device_ET3916_serial_number);
                    if (COMport_device_ident[COMport_ET3916].Contains("065124120022")) { dev_active[COMport_ET3916] = true; }
                    else dev_active[COMport_ET3916] = false;
                    //-----------------------------------------------------------------------------------------------------------
                    return (funReturnCodeCOMport.OK);
                }
                catch
                {
                    fun_ET3916_read_serial_number();
                    return (funReturnCodeCOMport.OK);
                }
            }
            else return (funReturnCodeCOMport.NOT_CONNECTED);
        }


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

        public void fun_ET3916_read_all_temperature_by_test()
        {
            var dataArray = new byte[4];
            dataArray[0] = 0;
            dataArray[1] = 2;
            dataArray[2] = 0x60;
            dataArray[3] = 8;
            fun_ET3916_send_reguest_bytes(dataArray);
            device_ET3916_bytes_command_write = true;
            device_ET3916_read_all_temperature = true;
            device_ET3916_read_all_temperature_by_test = true;
        }

        //=======================================================================================================================
        //=======================================================================================================================
        public funReturnCodeCOMport fun_ET3916_read_command_all_temperature()
        {
            device_ET3916_read_all_temperature = false;
            dev_meas_state[COMport_ET3916] = funReturnCodeCOMport.ERROR;

            if (dev_connected[COMport_ET3916])
            {
                if (dev_active[COMport_ET3916])
                {
                    try
                    {
                        mainWindow.COMportSerial[COMport_ET3916].Read(read_buffer, 0, 37);
                        device_ET3916_temperature[1] = System.BitConverter.ToSingle(read_buffer, 5);
                        device_ET3916_temperature[2] = System.BitConverter.ToSingle(read_buffer, 9);
                        device_ET3916_temperature[3] = System.BitConverter.ToSingle(read_buffer, 13);
                        device_ET3916_temperature[4] = System.BitConverter.ToSingle(read_buffer, 17);
                        device_ET3916_temperature[5] = System.BitConverter.ToSingle(read_buffer, 21);
                        device_ET3916_temperature[6] = System.BitConverter.ToSingle(read_buffer, 25);
                        device_ET3916_temperature[7] = System.BitConverter.ToSingle(read_buffer, 29);
                        device_ET3916_temperature[8] = System.BitConverter.ToSingle(read_buffer, 33);

                        dev_meas_state[COMport_ET3916] = funReturnCodeCOMport.OK;
                        return (funReturnCodeCOMport.OK);
                    }
                    catch (Exception) { return (funReturnCodeCOMport.ERROR); }
                }
                else return (funReturnCodeCOMport.NOT_ACTIVE);
            }
            else return (funReturnCodeCOMport.NOT_CONNECTED);
        }


    }
}