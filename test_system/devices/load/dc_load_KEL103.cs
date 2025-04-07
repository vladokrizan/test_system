using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static test_system.global_variable;


namespace test_system
{
    internal class dc_load_KEL103
    {
        functions functions = new functions();

        //=======================================================================================================================
        /// <summary>
        ///   
        /// </summary>
        //--    KORAD-KEL103 V3.30 SN:00022116
        //--#-- KORAD-KEL103 V1.10 SN:07740976
        //=======================================================================================================================
        public funReturnCode fun_KEL103_identifaction()
        {
            if (dev_connected[COMport_KEL103])
            {
                mainWindow.COMportSerial[COMport_KEL103].WriteLine("*IDN?");
                string ident_readRaw = mainWindow.COMportSerial[COMport_KEL103].ReadLine();
                COMport_device_ident[COMport_KEL103] = functions.fun_ascii_only(ident_readRaw);
                //-------------------------------------------------------------------------------------------------------------------
                if (ident_readRaw.Contains("KORAD-KEL103 V3.30 SN:00022116")) { dev_active[COMport_KEL103] = true; }
                else dev_active[COMport_KEL103] = false;
                return (funReturnCode.OK);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }

        //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        /// def KEL103_input_ON(self):     self.write(f':INP 1')    def set_input_on(self):    self.write(f':INP 1')
        /// </summary>
        //=======================================================================================================================
        public funReturnCode fun_KEL103_on()
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    mainWindow.COMportSerial[COMport_KEL103].WriteLine(":INP 1");
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);

            }
            else return (funReturnCode.NOT_CONNECTED);
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        /// 
        /// 
        ///            def KEL103_input_OFF(self):    self.write(f':INP 0')  def set_input_off(self):         self.write(f':INP 0')
        ///            
        /// 
        /// </summary>
        //=======================================================================================================================
        public funReturnCode fun_KEL103_off()
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    mainWindow.COMportSerial[COMport_KEL103].WriteLine(":INP 0");
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }

        //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        /// def KEL103_measure_voltage(self) -> float:  return  float (self.query(f':MEAS:VOLT?')[:-1])
        /// def get_voltage(self) -> float:       return  float (self.query(f':MEAS:VOLT?')[:-1])
        /// </summary>
        //=======================================================================================================================
        public funReturnCode fun_KEL103_get_voltage()
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    mainWindow.COMportSerial[COMport_KEL103].WriteLine(":MEAS:VOLT?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_KEL103].ReadLine();
                    string read_raw_value = read_raw_value_raw.Replace("V", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_voltage = Convert.ToDouble(read_raw_value_float);
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }

        //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        /// 
        ///      def KEL103_measure_current(self) -> float:       return  float (self.query(f':MEAS:CURR?')[:-1])
        ///       def get_current(self) -> float:      return  float (self.query(f':MEAS:CURR?')[:-1])
        /// 
        /// </summary>
        //=======================================================================================================================
        public funReturnCode fun_KEL103_get_current()
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    mainWindow.COMportSerial[COMport_KEL103].WriteLine(":MEAS:CURR?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_KEL103].ReadLine();
                    string read_raw_value = read_raw_value_raw.Replace("A", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_current = Convert.ToDouble(read_raw_value_float);
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        ///            def get_power(self) -> float:  return float (self.query(':MEAS:POW?')[:-1])
        /// 
        /// </summary>
        //=======================================================================================================================
        public funReturnCode fun_KEL103_get_power()
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    mainWindow.COMportSerial[COMport_KEL103].WriteLine(":MEAS:POW?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_KEL103].ReadLine();
                   // strGeneralString = read_raw_value_raw;
                    string read_raw_value = read_raw_value_raw.Replace("W", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_power = Convert.ToDouble(read_raw_value_float);
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// 
        ///      #    return float(self.query(':MEAS:RES?')[:-3])
        /// </summary>
        //=======================================================================================================================
        public funReturnCode fun_KEL103_get_resistance()
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    mainWindow.COMportSerial[COMport_KEL103].WriteLine(":MEAS:RES?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_KEL103].ReadLine();
                     strGeneralString = read_raw_value_raw;
                     string read_raw_value = read_raw_value_raw.Replace("A", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_current = Convert.ToDouble(read_raw_value_float);
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }

        //=======================================================================================================================
        //=======================================================================================================================
        //--    :CURRent:CURR   <NR2>MAX|MIN    Set the CC current and query it 
        //--    :CURRent 2ASet the CC voltage as 2A :CURRent?>2AThe CC current is 2A
        public funReturnCode fun_KEL103_get_set_curernt()
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    mainWindow.COMportSerial[COMport_KEL103].WriteLine(":CURR?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_KEL103].ReadLine();
                    string read_raw_value = read_raw_value_raw.Replace("A", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_get_set_current = Convert.ToDouble(read_raw_value_float);
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }
        public funReturnCode fun_KEL103_set_current(double setValue)
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    string setValueString = setValue.ToString("");
                    string setValueString_pika = setValueString.Replace(",", ".");
                    mainWindow.COMportSerial[COMport_KEL103].WriteLine(":CURR " + setValueString_pika+"A");
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }

        //=======================================================================================================================
        //=======================================================================================================================
        //--    :VOLTage:VOLT   <NR2>MAX|MIN    Set CV voltage and query CV voltage
        //--    :VOLTage 20VSet the CV voltage as 20V   :VOLTage?>20VThe CV voltage is 20V
        public funReturnCode fun_KEL103_get_set_voltage()
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    mainWindow.COMportSerial[COMport_KEL103].WriteLine(":VOLT?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_KEL103].ReadLine();
                    string read_raw_value = read_raw_value_raw.Replace("V", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_get_set_voltage = Convert.ToDouble(read_raw_value_float);
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }
        public funReturnCode fun_KEL103_set_voltage(double setValue)
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    //  mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":INP 0");
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }


        //=======================================================================================================================
        //=======================================================================================================================
        //--    :RESistance:    RES <NR2>MAX|MIN    Set the CR resistor and query it
        //--    :RESistance 20OHMSet the CR resistor as 20Ω     :RESistance?>20OOHMThe CR resistor is 20Ω
        public funReturnCode fun_KEL103_set_resistance(double setValue)
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    return (funReturnCode.OK);
                    // mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":INP 0");
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }


        //=======================================================================================================================
        //=======================================================================================================================
        //--    :POWer:POW  <NR2>MAX|MIN    Set the CW power and query it
        //--    :POWer 20WSet the CW power as 20W   :POWer?>20WThe CW power is 20W
        public funReturnCode fun_KEL103_get_set_power()
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    mainWindow.COMportSerial[COMport_KEL103].WriteLine(":POW?");
                    string read_raw_value_raw = mainWindow.COMportSerial[COMport_KEL103].ReadLine();
                    // strGeneralString = read_raw_value_raw;
                    string read_raw_value = read_raw_value_raw.Replace("W", "");
                    string read_raw_value_float = read_raw_value.Replace(".", ",");
                    KEL103_get_set_power = Convert.ToDouble(read_raw_value_float);
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }
        public funReturnCode fun_KEL103_set_power(double setValue)
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    //mainWindow.COMportSerial[COMport_SELECT_LOAD_KEL103].WriteLine(":INP 0");
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }



        //=======================================================================================================================
        //=======================================================================================================================
        //--    FUNCtion:FUNC
        //--    VOLT|CURR|RES|POW|SHORTDefine the functions:voltage, current,resistor and power
        //--    Only can switch CV, CC, CR, CWCan query CV, CC, CR, CW, that incontinuous mode, pulse, flip, battery andall the other modes.
        //--    :FUNCtion VOLT      Set the constant voltage mode
        //--    :FUNCtion？>VOLTThe current mode isconstant voltage

        //=======================================================================================================================
        //=======================================================================================================================
        public funReturnCode fun_KEL103_set_function(string set_function)
        {
            if (dev_connected[COMport_KEL103])
            {
                if (dev_active[COMport_KEL103])
                {
                    string send_string = ":FUN " + set_function; 
                    mainWindow.COMportSerial[COMport_KEL103].WriteLine(send_string);
                    return (funReturnCode.OK);
                }
                else return (funReturnCode.NOT_ACTIVE);
            }
            else return (funReturnCode.NOT_CONNECTED);
        }
        //=======================================================================================================================
        //=======================================================================================================================



    }
}


