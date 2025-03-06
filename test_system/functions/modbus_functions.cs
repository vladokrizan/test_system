using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;



namespace test_system
{
    internal class modbus_functions
    {

        //-----------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------
        public static byte byteSlaveAddress = 1;


        #region "MODBUS RTU function - SEND message  "

        #region "MODBUS RTU function - common function   "

        //=============================================================================================================
        /// <summary>
        /// doda byee en byte v strukturo za oddajanje sporočila 
        /// </summary>
        /// <param name="sendByte"></param>
        /// <param name="SelectComPort"></param>
        /// <returns></returns>
        //=============================================================================================================
        public funErrorCode funModbusRTU_add_byte(byte sendByte, UInt32 SelectComPort)
        {
            COMport_sendByte[SelectComPort, bCOMport_sendLen[SelectComPort]++] = sendByte;
            return (funErrorCode.OK);
        }
        //=============================================================================================================
        /// <summary>
        /// doda se 16 bitno stevilo v paket, ki se poslj e
        /// </summary>
        /// <param name="sendWord"></param>
        /// <param name="SelectComPort"></param>
        /// <returns></returns>
        //=============================================================================================================
        public funErrorCode funModbusRTU_add_uint16(UInt16 sendWord, UInt32 SelectComPort)
        {
            COMport_sendByte[SelectComPort, bCOMport_sendLen[SelectComPort]++] = (byte)(sendWord >> 8);
            COMport_sendByte[SelectComPort, bCOMport_sendLen[SelectComPort]++] = (byte)(sendWord);
            return (funErrorCode.OK);
        }

        #endregion
        #region "MODBUS RTU function - function 3    "
        //=============================================================================================================
        /// <summary>
        /// pripravi se  sporočilo za funkcijo 3 --- branje registrov >
        /// sporočilo se poslje na izbrani COM port in pripravi se sprejem sporočila odgovoa modula 
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="registerAddress"></param>
        /// <param name="numberRegister"></param>
        /// <param name="selectCOMport"></param>
        /// <returns></returns>
        //=============================================================================================================
        public funErrorCode funModbusRTU_send_request_read_function_3(byte slaveAddress, UInt16 registerAddress, UInt16 numberRegister, UInt32 selectCOMport)
        {

            modbus_start_register = registerAddress;
            modbus_register_number = numberRegister;

            mainWindow.COMportSerial[selectCOMport].DiscardInBuffer();

            bCOMport_sendLen[selectCOMport] = 0;
            funModbusRTU_add_byte(slaveAddress, selectCOMport);
            funModbusRTU_add_byte(3, selectCOMport);
            funModbusRTU_add_uint16(registerAddress, selectCOMport);
            funModbusRTU_add_uint16(numberRegister, selectCOMport);
            //-----------------------------------------------------------------------------------------------
            //-- byte se prensejo v enodimenzionalno polje za izracun CRC 
            byte loc_loop;
            byte[] sendByte_local = new byte[100];
            for (loc_loop = 0; loc_loop < 6; loc_loop++) { sendByte_local[loc_loop] = COMport_sendByte[selectCOMport, loc_loop]; }
            ModRTU_send_CRC(sendByte_local, 6, selectCOMport);
            //-------------------------------------------------------------------------------------------
            for (loc_loop = 0; loc_loop < bCOMport_sendLen[selectCOMport]; loc_loop++) { sendByte_local[loc_loop] = COMport_sendByte[selectCOMport, loc_loop]; }
            mainWindow.COMportSerial[selectCOMport].Write(sendByte_local, 0, bCOMport_sendLen[selectCOMport]);
            //-------------------------------------------------------------------------------------------
            //-- prikaz oddanega sporocila 
            // COMports.fun_COMport_send_message_byte_to_string(selectCOMport);

            if (selectCOMport == COMport_SELECT_SUPPLY_RD6006)
            {
                mainWindow.COMportSerial[COMport_SELECT_SUPPLY_RD6006].ReceivedBytesThreshold = numberRegister * 2 + 5;
            }
            else if (selectCOMport == COMport_SELECT_SUPPLY_RD6024)
            {
                mainWindow.COMportSerial[COMport_SELECT_SUPPLY_RD6024].ReceivedBytesThreshold = numberRegister * 2 + 5;
            }
            //-------------------------------------------------------------------------------------------
            return (funErrorCode.OK);
        }

        #endregion
        #region "MODBUS RTU function - function  4  "
        //=============================================================================================================
        //=============================================================================================================

        public funErrorCode funModbusRTU_send_request_read_function_4(byte slaveAddress, UInt16 registerAddress, UInt16 numberRegister, UInt32 selectCOMport)
        {
            byteSlaveAddress = slaveAddress;
            bCOMport_sendLen[selectCOMport] = 0;
            funModbusRTU_add_byte(slaveAddress, selectCOMport);
            funModbusRTU_add_byte(4, selectCOMport);
            funModbusRTU_add_uint16(registerAddress, selectCOMport);
            funModbusRTU_add_uint16(numberRegister, selectCOMport);
            //-------------------------------------------------------------------------------------
            byte loc_loop;
            byte[] sendByte_local = new byte[100];
            for (loc_loop = 0; loc_loop < 6; loc_loop++) { sendByte_local[loc_loop] = COMport_sendByte[selectCOMport, loc_loop]; }
            //-------------------------------------------------------------------------------------
            ModRTU_send_CRC(sendByte_local, 6, selectCOMport).ToString("X");
            //-------------------------------------------------------------------------------------
            //-- prikaz oddanega sporocila 
            //           COMports.fun_COMport_send_message_byte_to_string(selectCOMport);
            return (funErrorCode.OK);
        }

        #endregion
        #region "RTU MODBUS -- function 6 "

        /*
        Preset Single Register(FC= 06)
            Request
                This command is writing the contents of analog output holding register # 40002  to the slave device with address 17.
                11 06 0001 0003 9A9B
                    11: The Slave Address(11 hex = address17)
                    06: The Function Code 6 (Preset Single Register)
                    0001: The Data Address of the register.  ( 0001 hex = 1, + 40001 offset = register #40002 )
                    0003: The value to write
                    9A9B: The CRC (cyclic redundancy check) for error checking.
            Response
                The normal response is an echo of the query, returned after the register contents have been written.
                11 06 0001 0003 9A9B
                    11: The Slave Address (11 hex = address17)
                    06: The Function Code 6 (Preset Single Register)
                    0001: The Data Address of the register. (# 40002 - 40001 = 1 )
                    0003: The value written
                    9A9B: The CRC (cyclic redundancy check) for error checking.
        */

        //=============================================================================================================
        /// <summary>
        ///     MODBUS RTU    
        ///            vpis enega registra ( 16 bit )
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="registerAddress"></param>
        /// <param name="setRegister"></param>
        /// <param name="selectCOMport"></param>
        /// <returns></returns>
        //=============================================================================================================
        public funErrorCode funModbusRTU_send_set_single_register_function_6(byte slaveAddress, UInt16 registerAddress, UInt16 setRegister, UInt32 selectCOMport)
        {

            mainWindow.COMportSerial[selectCOMport].DiscardInBuffer();
            bCOMport_sendLen[selectCOMport] = 0;
            //-------------------------------------------------------------------------------------
            //-- Slave address
            funModbusRTU_add_byte(slaveAddress, selectCOMport);
            //-------------------------------------------------------------------------------------
            //-- function 6
            funModbusRTU_add_byte(6, selectCOMport);
            //-------------------------------------------------------------------------------------
            //-- register address
            funModbusRTU_add_uint16(registerAddress, selectCOMport);
            //-------------------------------------------------------------------------------------
            //-- register value 
            funModbusRTU_add_uint16(setRegister, selectCOMport);
            //-------------------------------------------------------------------------------------
            byte loc_loop;
            byte[] sendByte_local = new byte[100];
            for (loc_loop = 0; loc_loop < 6; loc_loop++) { sendByte_local[loc_loop] = COMport_sendByte[selectCOMport, loc_loop]; }
            //-------------------------------------------------------------------------------------
            ModRTU_send_CRC(sendByte_local, 6, selectCOMport);
            //-------------------------------------------------------------------------------------
            for (loc_loop = 0; loc_loop < bCOMport_sendLen[selectCOMport]; loc_loop++) { sendByte_local[loc_loop] = COMport_sendByte[selectCOMport, loc_loop]; }

            if (COMport_connected[selectCOMport])        // --- pove, če je COM port povezan in delujoc
            {
                mainWindow.COMportSerial[selectCOMport].DiscardInBuffer();
                mainWindow.COMportSerial[selectCOMport].Write(sendByte_local, 0, bCOMport_sendLen[selectCOMport]);
                mainWindow.COMportSerial[selectCOMport].ReceivedBytesThreshold = 8;
                //COMport_bussy[selectCOMport] = true;
            }
            //-------------------------------------------------------------------------------------
            //-- prikaz oddanega sporocila 
            //  COMports.fun_COMport_send_message_byte_to_string(selectCOMport);
            return (funErrorCode.OK);
        }

        //=============================================================================================================
        /// <summary>
        ///     nastavi se en register na KP184 DC load 
        /// </summary>
        /// <param name="slaveAddress"></param>
        /// <param name="registerAddress"></param>
        /// <param name="setRegister"></param>
        /// <param name="selectCOMport"></param>
        /// <returns></returns>
        //=============================================================================================================
        public funErrorCode funModbusRTU_send_set_single_register_function_6_KP184(byte slaveAddress, UInt16 registerAddress, UInt32 setRegister, UInt32 selectCOMport)
        {

            UInt16 high_register;
            UInt16 low_register;

            if (selectCOMport < 200)        // --- pove, če je COM port povezan in delujoc
            {
                if (COMport_connected[selectCOMport])        // --- pove, če je COM port povezan in delujoc
                {
                    mainWindow.COMportSerial[selectCOMport].DiscardInBuffer();
                    bCOMport_sendLen[selectCOMport] = 0;
                    funModbusRTU_add_byte(slaveAddress, selectCOMport);
                    funModbusRTU_add_byte(6, selectCOMport);
                    funModbusRTU_add_uint16(registerAddress, selectCOMport);
                    funModbusRTU_add_uint16(1, selectCOMport);      //-- stevilo registrov
                    funModbusRTU_add_byte(4, selectCOMport);        //-- stevilo bytov
                    low_register = (UInt16)setRegister;
                    high_register = (UInt16)(setRegister >> 16);
                    funModbusRTU_add_uint16(high_register, selectCOMport);      //-- 
                    funModbusRTU_add_uint16(low_register, selectCOMport);      //-- 
                    //-------------------------------------------------------------------------------------
                    byte loc_loop;
                    byte[] sendByte_local = new byte[100];
                    for (loc_loop = 0; loc_loop < 11; loc_loop++) { sendByte_local[loc_loop] = COMport_sendByte[selectCOMport, loc_loop]; }
                    //-------------------------------------------------------------------------------------
                    ModRTU_send_CRC(sendByte_local, 11, selectCOMport);
                    //-------------------------------------------------------------------------------------
                    for (loc_loop = 0; loc_loop < bCOMport_sendLen[selectCOMport]; loc_loop++) { sendByte_local[loc_loop] = COMport_sendByte[selectCOMport, loc_loop]; }

                    if (COMport_connected[selectCOMport])        // --- pove, če je COM port povezan in delujoc
                    {
                        mainWindow.COMportSerial[selectCOMport].DiscardInBuffer();
                        mainWindow.COMportSerial[selectCOMport].Write(sendByte_local, 0, bCOMport_sendLen[selectCOMport]);
                        mainWindow.COMportSerial[selectCOMport].ReceivedBytesThreshold = 8;
                    }
                    //-------------------------------------------------------------------------------------
                    //-- prikaz oddanega sporocila 
                    //COMports.fun_COMport_send_message_byte_to_string(selectCOMport);
                }
            }
            return (funErrorCode.OK);
        }
        #endregion

        #endregion

        #region "MODBUS RTU function - receive message  "
        //=======================================================================================================================
        /// <summary>
        /// obdelava bytov sprejetega MODBUS sporočila 
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================
        public funErrorCode funModbusRTU_receive_mesasage()
        {
            byte selectByte;
            byte loc_loop;
            modbus_register_type = 0;
            intModbusRTUreceiveCRC_calculate = ModRTU_receive_CRC(receiveByte_modbus, receiveByte_modbus_lenght - 2);
            intModbusRTUreceiveCRC_receive = (UInt16)(receiveByte_modbus[receiveByte_modbus_lenght - 1] * 256 + receiveByte_modbus[receiveByte_modbus_lenght - 2]);

            if (intModbusRTUreceiveCRC_calculate == intModbusRTUreceiveCRC_receive)
            {
                modbus_register_type = receiveByte_modbus[1];
                modbus_number_register = receiveByte_modbus[2];
                selectByte = 3;
                for (loc_loop = 0; loc_loop < modbus_number_register; loc_loop++)
                {
                    modbus_register[loc_loop] = (UInt16)(receiveByte_modbus[selectByte++] * 256 + receiveByte_modbus[selectByte++]);
                }
            }
            return (funErrorCode.OK);
        }

        #endregion
        #region "CALCULATE CRC "

        //=============================================================================================================
        //=============================================================================================================

        public UInt16 ModRTU_receive_CRC(byte[] buf, int len)
        {
            UInt16 crc = 0xFFFF;
            for (int pos = 0; pos < len; pos++)
            {
                crc ^= (UInt16)buf[pos];                //-- XOR byte into least sig. byte of crc
                for (int i = 8; i != 0; i--)
                {    // Loop over each bit
                    if ((crc & 0x0001) != 0)
                    {
                        //-- If the LSB is set
                        crc >>= 1;                      //-- Shift right and XOR 0xA001
                        crc ^= 0xA001;
                    }
                    else                                //-- Else LSB is not set
                        crc >>= 1;                      //-- Just shift right
                }
            }
            //----------------------------------------------------------------------------------------------------
            return crc;
        }




        //-- Compute the MODBUS RTU CRC
        public UInt16 ModRTU_send_CRC(byte[] buf, int len, UInt32 selectCOMport)
        {
            UInt16 crc = 0xFFFF;

            for (int pos = 0; pos < len; pos++)
            {
                crc ^= (UInt16)buf[pos];                //-- XOR byte into least sig. byte of crc
                for (int i = 8; i != 0; i--)
                {    // Loop over each bit
                    if ((crc & 0x0001) != 0)
                    {
                        //-- If the LSB is set
                        crc >>= 1;                      //-- Shift right and XOR 0xA001
                        crc ^= 0xA001;
                    }
                    else                                //-- Else LSB is not set
                        crc >>= 1;                      //-- Just shift right
                }
            }
            //----------------------------------------------------------------------------------------------------
            //-- add calculate CRC to send message bytes 
            COMport_sendByte[selectCOMport, bCOMport_sendLen[selectCOMport]++] = (byte)crc;
            COMport_sendByte[selectCOMport, bCOMport_sendLen[selectCOMport]++] = (byte)(crc >> 8);

            return crc;
        }


        public UInt16 ModRTU_send_CRC_LH(byte[] buf, int len, UInt32 selectCOMport)
        {
            UInt16 crc = 0xFFFF;

            for (int pos = 0; pos < len; pos++)
            {
                crc ^= (UInt16)buf[pos];                //-- XOR byte into least sig. byte of crc
                for (int i = 8; i != 0; i--)
                {    // Loop over each bit
                    if ((crc & 0x0001) != 0)
                    {
                        //-- If the LSB is set
                        crc >>= 1;                      //-- Shift right and XOR 0xA001
                        crc ^= 0xA001;
                    }
                    else                                //-- Else LSB is not set
                        crc >>= 1;                      //-- Just shift right
                }
            }
            //----------------------------------------------------------------------------------------------------
            //-- add calculate CRC to send message bytes 
            COMport_sendByte[selectCOMport, bCOMport_sendLen[selectCOMport]++] = (byte)(crc >> 8);
            COMport_sendByte[selectCOMport, bCOMport_sendLen[selectCOMport]++] = (byte)crc;



            //-- Note, this number has low and high bytes swapped, so use it accordingly (or swap bytes)

            return crc;
        }








        #endregion



    }
}
