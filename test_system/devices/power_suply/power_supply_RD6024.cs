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

        public funErrorCode funModbusRTU_receive_mesasage_RD6024()
        {
            // UInt16 uint16Value = 0;
            UInt32 uint32Value = 0;
           //ouble floatValue = 0;

            //floatValue = uint16Value;
            rd6024_setVoltage = ((float)(modbus_register[0])) / 100;
            rd6024_setCurrent = ((float)(modbus_register[1])) / 1000;
            rd6024_OutputVoltag = ((float)(modbus_register[2])) / 100;
            rd6024_OutputCurrent = ((float)(modbus_register[3])) / 1000;

            uint32Value = (UInt32)(modbus_register[4] * 0xFFFF + modbus_register[5]);
            rd6024_OutputPower = uint32Value / 100;
            rd6024_InputVoltage = ((float)(modbus_register[6])) / 100;


            //rd6006_setCurrent = ((float)(modbus_register[1])) / 100;
            //rd6006_setCurrent = ((float)(modbus_register[1])) / 100;


            device_RD6024_show_all_measure = true;
            return (funErrorCode.OK);
        }





        }
    }
