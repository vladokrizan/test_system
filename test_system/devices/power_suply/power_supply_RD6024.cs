using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;

namespace test_system
{
    internal class power_supply_RD6024
    {
        modbus modbus_functions = new modbus();


        public funReturnCode funRD6024_ident()
        {
            if (dev_connected[COMport_RD6024])
            {
                mainWindow.COMportSerial[COMport_RD6006].DiscardInBuffer();
                modbus_functions.funModbusRTU_send_request_read_function_3(1, 0, 4, COMport_RD6024);
                return (funReturnCode.OK);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }



        //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        ///         EB51   36F8   8A
        /// 
        /// </summary>
        /// <returns></returns>
        //=======================================================================================================================    
        public funReturnCode funModbusRTU_RD6024_receive_ident()
        {
            rd6024_Signature = modbus_register[0];
            rd6024_Serial_number = modbus_register[2];
            rd6024_Firmware_version = modbus_register[3];
            device_RD6024_all_device_ident = true;
            strGeneralString = rd6024_Signature.ToString("X") + "   " + rd6024_Serial_number.ToString("X") + "   " + rd6024_Firmware_version.ToString("X");
            //    36F8   8A
            if (rd6024_Signature == 0xEB51) { dev_active[COMport_RD6024] = true; }
            else dev_active[COMport_RD6024] = false;


            return (funReturnCode.OK);

        }


        public funReturnCode funModbusRTU_RD6024_receive_set()
        {
            // UInt16 uint16Value = 0;
            //UInt32 uint32Value = 0;
            //ouble floatValue = 0;

            //floatValue = uint16Value;
            rd6024_setVoltage = ((float)(modbus_register[0])) / 100;
            rd6024_setCurrent = ((float)(modbus_register[1])) / 1000;
            //rd6024_OutputVoltag = ((float)(modbus_register[2])) / 100;
            //rd6024_OutputCurrent = ((float)(modbus_register[3])) / 1000;
            //uint32Value = (UInt32)(modbus_register[4] * 0xFFFF + modbus_register[5]);
            //rd6024_OutputPower = uint32Value / 100;
            //rd6024_InputVoltage = ((float)(modbus_register[6])) / 100;
            //rd6006_setCurrent = ((float)(modbus_register[1])) / 100;
            //rd6006_setCurrent = ((float)(modbus_register[1])) / 100;


            device_RD6024_show_all_measure = true;
            return (funReturnCode.OK);
        }


        public funReturnCode funModbusRTU_receive_mesasage_RD6024()
        {
            // UInt16 uint16Value = 0;
            //  UInt32 uint32Value = 0;
            //ouble floatValue = 0;
            //floatValue = uint16Value;
            //rd6024_setVoltage = ((float)(modbus_register[0])) / 100;
            //rd6024_setCurrent = ((float)(modbus_register[1])) / 1000;
            rd6024_OutputVoltag = ((float)(modbus_register[0])) / 100;
            rd6024_OutputCurrent = ((float)(modbus_register[1])) / 1000;
            //  uint32Value = (UInt32)(modbus_register[2] * 0xFFFF + modbus_register[3]);
            //  rd6024_OutputPower = uint32Value / 100;
            // rd6024_InputVoltage = ((float)(modbus_register[4])) / 100;
            //rd6006_setCurrent = ((float)(modbus_register[1])) / 100;
            //rd6006_setCurrent = ((float)(modbus_register[1])) / 100;

            device_RD6024_show_all_measure = true;
            return (funReturnCode.OK);
        }





    }
}
