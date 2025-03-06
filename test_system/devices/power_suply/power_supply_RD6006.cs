using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_system.Properties;
using static test_system.global_variable;

namespace test_system
{

    /*
    #region "Description"   
    #0001 0 RO
    #0002 0x19 0x40 RO Serial number (6464)
    #0003 0x00 0x80 RO Firmware version (1.28) x 100
    #000D WATT RO W value x 100
    #000F LOCK R/W 0 = OPEN, 1 = LOCKED
    #0010 ERROR RO 0 = OK, 1 = OVP, 2 = OCP
    #0013 DATA USE R/W memory ID 0..9
    #0020 BATTERY MODE RO 0 = OFF, 1 = ON
    #0021 V-BATT RO V value x 100
    #0026 AMPEREH HI ? RO Ah value x 1000
    #0027 AMPEREH LO RO
    #0028 WATTH HI ? RO Wh value x 1000
    #0029 WATTH LO RO


    #0000 0xEA 0x9E RO Signature = 60062
    #0001 0 RO
    #0002 0x19 0x40 RO Serial number (6464)
    #0003 0x00 0x80 RO Firmware version (1.28) x 100
    #0005 TEMP SYS C RO
    #0007 TEMP SYS F RO
    #0008 V-SET R/W V value x 100
    #0009 I-SET R/W I value x 1000
    #000A V-OUT RO V value x 100
    #000B I-OUT RO I value x 1000
    #000D WATT RO W value x 100
    #000E V-INPUT RO V value x 100
    #000F LOCK R/W 0 = OPEN, 1 = LOCKED
    #0010 ERROR RO 0 = OK, 1 = OVP, 2 = OCP
    #0012 OUTPUT ON/OFF R/W 0 = OFF, 1 = ON
    #0013 DATA USE R/W memory ID 0..9
    #0020 BATTERY MODE RO 0 = OFF, 1 = ON
    #0021 V-BATT RO V value x 100
    #0023 TEMP PROBE C RO
    #0025 TEMP PROBE F RO
    #0026 AMPEREH HI ? RO Ah value x 1000
    #0027 AMPEREH LO RO
    #0028 WATTH HI ? RO Wh value x 1000
    #0029 WATTH LO RO
'''
Reg ID   Description	
0	ID	
1	Serial number high bytes
2	Serial number low bytes
3	Firmware version
4	Temperature °c sign(0=+, 1=-)
5	Temperature °c	
6	Temperature F sign(0=+, 1=-)
7	Temperature F
8	Voltage set value	
9	Current set value	
10	Voltage display value	
11	Current display value	
12	AH display value	
13	Power display value	
14	Voltage input
15	Keypad lock	
16	Protection status(1=OVP, 2=OCP)
17	CV/CC(0=CV, 1=CC)
18	Output enable
19	Change preset
20	Current range(On RD6012p 0=6A, 1=12A)
32	Battery mode active	
33	Battery voltage
34	External temperature °c sign(0=+, 1=-)
35	External temperature °c	
36	External temperature F sign(0=+, 1=-)
37	External temperature F	
38	Ah high bytes	
39	Ah low bytes	
40	Wh high bytes	
41	Wh low bytes	
48	Year	
49	Month	
50	Day	
51	Hour	
52	Minute	
53	Second	
55	Output Voltage Zero	
56	Output Voltage Scale	
57	Back Voltage Zero	
58	Back Voltage Scale	
59	Output Current Zero	
60	Output Current Scale	
61	Back Current Zero	
62	Back Current Scale	
66	Settings Take ok	
67	Settings Take out	
68	Settings Boot pow	
69	Settings Buzzer
70	Settings Logo
71	Settings Language
72	Settings Backlight
80	M0 V
81	M0 A
82	M0 OVP
83	M1 OCP
84	M1 V
85	M1 A
86	M1 OVP
87	M1 OCP
88	M2 V
89	M2 A
90	M2 OVP
91	M2 OCP
92	M3 V
93	M3 A
94	M3 OVP
95	M3 OCP
96	M4 V
97	M4 A
98	M4 OVP
99	M4 OCP
100	M5 V
101	M5 A
102	M5 OVP
103	M5 OCP
104	M6 V
105	M6 A
106	M6 OVP
107	M6 OCP
108	M7 V
109	M7 A
110	M7 OVP
111	M7 OCP
112	M8 V
113	M8 A
114	M8 OVP
115	M8 OCP
116	M9 V
117	M9 A
118	M9 OVP
119	M9 OCP
256	SYSTEM	
'''
    */


    internal class power_supply_RD6006
    {

        // byte[] receiveByte_local = new byte[100];


        modbus_functions modbus_functions = new modbus_functions();

        public void funRD6006_on()
        {
            modbus_functions.funModbusRTU_send_set_single_register_function_6(1, 18, 1, COMport_SELECT_SUPPLY_RD6006);
        }

        public void funRD6006_off()
        {
            modbus_functions.funModbusRTU_send_set_single_register_function_6(1, 18, 0, COMport_SELECT_SUPPLY_RD6006);
        }




        #region "GET measure "


        public funErrorCode funRD6006_measure()
        {
            if (COMport_connected[COMport_SELECT_SUPPLY_RD6006])
            {
                mainWindow.COMportSerial[COMport_SELECT_SUPPLY_RD6006].DiscardInBuffer();
                modbus_functions.funModbusRTU_send_request_read_function_3(1, 8, 10, COMport_SELECT_SUPPLY_RD6006);
            }
            return (funErrorCode.OK);
        }

        //--    #0008 V-SET R/W V value x 100
        //--    #0009 I-SET R/W I value x 1000
        //--    #000A V-OUT RO V value x 100
        //--    #000B I-OUT RO I value x 1000
        //--    #000D WATT RO W value x 100
        //--    #000E V-INPUT RO V value x 100
        //--    #000F LOCK R/W 0 = OPEN, 1 = LOCKED
        //--    #0010 ERROR RO 0 = OK, 1 = OVP, 2 = OCP
        //--    #0012 OUTPUT ON/OFF R/W 0 = OFF, 1 = ON

        public funErrorCode funModbusRTU_receive_mesasage_RD6006()
        {
            UInt32 uint32Value = 0;
            rd6006_setVoltage = ((float)(modbus_register[0])) / 100;
            rd6006_setCurrent = ((float)(modbus_register[1])) / 1000;
            rd6006_OutputVoltag = ((float)(modbus_register[2])) / 100;
            rd6006_OutputCurrent = ((float)(modbus_register[3])) / 1000;
            uint32Value = (UInt32)(modbus_register[4] * 0xFFFF + modbus_register[5]);
            rd6006_OutputPower = ((float)uint32Value) / 100;
            rd6006_InputVoltage = ((float)(modbus_register[6])) / 100;
            device_RD6006_show_all_measure = true;
            return (funErrorCode.OK);
        }





        public funErrorCode funRD6006_ident()
        {
            mainWindow.COMportSerial[COMport_SELECT_SUPPLY_RD6006].DiscardInBuffer();
            modbus_functions.funModbusRTU_send_request_read_function_3(1, 0, 20, COMport_SELECT_SUPPLY_RD6006);

            return (funErrorCode.OK);
        }

        //--#0000 0xEA 0x9E RO Signature = 60062
        //--#0001 0 RO
        //--#0002 0x19 0x40 RO Serial number (6464)
        //--#0003 0x00 0x80 RO Firmware version (1.28) x 100
        //--#0005 TEMP SYS C RO
        //--#0007 TEMP SYS F RO
        //-- Reg ID   Description	
        //--    0	ID	
        //--    1	Serial number high bytes
        //--    2	Serial number low bytes
        //--    3	Firmware version
        //--    4	Temperature °c sign(0=+, 1=-)
        //--    5	Temperature °c	
        //--    6	Temperature F sign(0=+, 1=-)
        //--    7	Temperature F

        public funErrorCode funModbusRTU_receive_ident_RD6006(byte SelectCOMport)
        {
            // UInt16 uint16Value = 0;
            //UInt32 uint32Value = 0;
            //double floatValue = 0;


            /*
            byte selectByte;
            byte loc_loop;
           // for (loc_loop = 0; loc_loop < bCOMport_recLen[SelectCOMport]; loc_loop++) { receiveByte_local[loc_loop] = receiveByte_RD6006[loc_loop]; }




            intModbusRTUreceiveCRC_calculate = modbus_functions.ModRTU_receive_CRC(receiveByte_local, bCOMport_recLen[SelectCOMport] - 2);
            intModbusRTUreceiveCRC_receive = (UInt16)(receiveByte_local[bCOMport_recLen[SelectCOMport] - 1] * 256 + receiveByte_local[bCOMport_recLen[SelectCOMport] - 2]);


            if (intModbusRTUreceiveCRC_calculate == intModbusRTUreceiveCRC_receive)
            {
                if (receiveByte_local[1] == 3)
                {
                    intModbusRTUreceiveCRC_numberBytes = receiveByte_local[2];

                    selectByte = 3;



                }
            }

            */


            return (funErrorCode.OK);
        }








        // strGeneralString = bCOMport_recLen[SelectCOMport].ToString()+"   "+  receiveByte_local[0].ToString()+"   "+ receiveByte_local[1].ToString() + "   " + receiveByte_local[2].ToString() + "   " + receiveByte_local[3].ToString() + "   " + receiveByte_local[4].ToString() + "   " + receiveByte_RD6006[5].ToString();
        //strGeneralString = intModbusRTUreceiveCRC_calculate.ToString()+"    "+ intModbusRTUreceiveCRC_receive.ToString () ;

        /*
                    if (intModbusRTUreceiveCRC_calculate == intModbusRTUreceiveCRC_receive)
                    {
                        if (receiveByte_local[1] == 3)
                        {
                            intModbusRTUreceiveCRC_numberBytes = receiveByte_local[2];

                            // globalStringDebug[0] = "receive   " + intModbusRTUreceiveCRC_calculate.ToString() + "   " + intModbusRTUreceiveCRC_receive.ToString() + "   " + intModbusRTUreceiveCRC_numberBytes.ToString();

                            selectByte = 3;
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            floatValue = uint16Value;
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            floatValue = uint16Value;
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            floatValue = uint16Value;
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            floatValue = uint16Value;
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            floatValue = uint16Value;
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            floatValue = uint16Value;
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            floatValue = uint16Value;
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            floatValue = uint16Value;

                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            floatValue = uint16Value;
                            rd6006_setVoltage = floatValue / 100;

                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            floatValue = uint16Value;
                            rd6006_setCurrent = floatValue / 1000;

                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            floatValue = uint16Value;
                            rd6006_OutputVoltag = floatValue / 100;
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            floatValue = uint16Value;
                            rd6006_OutputCurrent = floatValue / 1000;

                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            uint32Value = uint16Value;
                            uint32Value = uint32Value * 0xFFFF;
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            uint32Value = uint32Value + uint16Value;
                            floatValue = uint32Value;
                            rd6006_OutputPower = uint32Value / 100;


                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            floatValue = uint16Value;
                            rd6006_InputVoltage = floatValue / 100;

                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            // uint16Value = (UInt16)(byteCOMport_receiveByte[SelectCOMport, selectByte++] * 256 + byteCOMport_receiveByte[SelectCOMport, selectByte++]);
                            // uint16Value = (UInt16)(byteCOMport_receiveByte[SelectCOMport, selectByte++] * 256 + byteCOMport_receiveByte[SelectCOMport, selectByte++]);
                            // uint16Value = (UInt16)(byteCOMport_receiveByte[SelectCOMport, selectByte++] * 256 + byteCOMport_receiveByte[SelectCOMport, selectByte++]);
                            // uint16Value = (UInt16)(byteCOMport_receiveByte[SelectCOMport, selectByte++] * 256 + byteCOMport_receiveByte[SelectCOMport, selectByte++]);
                            // uint16Value = (UInt16)(byteCOMport_receiveByte[SelectCOMport, selectByte++] * 256 + byteCOMport_receiveByte[SelectCOMport, selectByte++]);
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 256 + receiveByte_local[selectByte++]);

                            //globalStringDebug[1] = "ON / OFF    " + uint16Value.ToString();
                            uint16Value = (UInt16)(receiveByte_local[selectByte++] * 255 + receiveByte_local[selectByte++]);
                            //globalStringDebug[2] = "memory    " + uint16Value.ToString();


                            // globalStringDebug[1] = "measure   " + rd6006_setVoltage.ToString() + "   " + rd6006_setCurrent.ToString() + "   " + rd6006_OutputVoltag.ToString();
                            // globalStringDebug[2] = "measure   " + rd6006_OutputCurrent.ToString() + "   " + rd6006_OutputPower.ToString() + "   " + rd6006_InputVoltage.ToString();

                           // strGeneralString = rd6006_setVoltage.ToString() + "    " + rd6006_InputVoltage.ToString(); ;
                            device_RD6006_show_all_measure = true;
                        }
                    }




                    return (funErrorCode.OK);
                }


                    */

        /*
        Public Function fun_get_dpsXXXX_measure() As Boolean
        Dim tmpDouble As Double
        tmpDouble = modbus_RTU.register_03(0)
        dps_setVoltage(dps_receive_module) = tmpDouble / 100
        tmpDouble = modbus_RTU.register_03(1)
        dps_setCurrent(var.dps_receive_module) = tmpDouble / 1000


        tmpDouble = modbus_RTU.register_03(2)
        dps_Voltage(var.dps_receive_module) = tmpDouble / 100



        tmpDouble = modbus_RTU.register_03(3)
        dps_Current(var.dps_receive_module) = tmpDouble / 1000

        tmpDouble = modbus_RTU.register_03(4)
        dps_Power(var.dps_receive_module) = tmpDouble / 100

        tmpDouble = modbus_RTU.register_03(5)
        dps_inpVolt(dps_receive_module) = tmpDouble / 100


        dps_Key_lock(dps_receive_module) = modbus_RTU.register_03(6)
        dps_Protection_status(dps_receive_module) = modbus_RTU.register_03(7)
        dps_CV_CC(dps_receive_module) = modbus_RTU.register_03(8)
        dps_Switch_output_state(dps_receive_module) = modbus_RTU.register_03(9)
        dps_Backlight_brightness(dps_receive_module) = modbus_RTU.register_03(10)
        dps_model(dps_receive_module) = modbus_RTU.register_03(11)
        dps_version(dps_receive_module) = modbus_RTU.register_03(12)
        fun_get_dpsXXXX_measure = True
    End Function

        */
        #endregion










    }
}
