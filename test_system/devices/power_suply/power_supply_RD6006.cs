﻿using System;
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



        modbus_functions modbus_functions = new modbus_functions();

        public void funRD6006_on()
        {
            modbus_functions.funModbusRTU_send_set_single_register_function_6(1, 18, 1, COMport_SELECT_SUPPLY_RD6006);
        }

        public void funRD6006_off()
        {
            modbus_functions.funModbusRTU_send_set_single_register_function_6(1, 18, 0, COMport_SELECT_SUPPLY_RD6006);
        }





    }
}
