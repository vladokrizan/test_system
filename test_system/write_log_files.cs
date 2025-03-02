﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;
namespace test_system
{
    internal class write_log_files
    {


        private string fun_set_com_port_names ()
        {
            string fun_set_com_port_name = "";
            fun_set_com_port_name = fun_set_com_port_name + "XDM3051 " + strExcelSeparator;
            fun_set_com_port_name = fun_set_com_port_name + "XDM2041 " + strExcelSeparator;
            fun_set_com_port_name = fun_set_com_port_name + "XDM1041 " + strExcelSeparator;
            fun_set_com_port_name = fun_set_com_port_name + "TEMPERATURE_ET3916 " + strExcelSeparator;
            fun_set_com_port_name = fun_set_com_port_name + "AC_METER_MPM_1010B " + strExcelSeparator;
            fun_set_com_port_name = fun_set_com_port_name + "SUPPLY_KA3305A " + strExcelSeparator;
            fun_set_com_port_name = fun_set_com_port_name + "SUPPLY_RD6024 " + strExcelSeparator;
            fun_set_com_port_name = fun_set_com_port_name + "SUPPLY_RD6006 " + strExcelSeparator;
            fun_set_com_port_name = fun_set_com_port_name + "SUPPLY_HCS_330 " + strExcelSeparator;
            fun_set_com_port_name = fun_set_com_port_name + "LOAD_KEL103 " + strExcelSeparator;

            return fun_set_com_port_name;
        }

        /*
        private string fun_set_com_port_selev_value( object  selectValue )
        {
            string fun_set_com_port_selev_value = "";
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + selectValue[COMport_SELECT_MULTIMETER_XDM3051] + strExcelSeparator;
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + selectValue[COMport_SELECT_MULTIMETER_XDM2041] + strExcelSeparator;
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + selectValue[COMport_SELECT_MULTIMETER_XDM1041] + strExcelSeparator;
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + selectValue[COMport_SELECT_TEMPERATURE_ET3916] + strExcelSeparator;
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + selectValue[COMport_SELECT_AC_METER_MPM_1010B] + strExcelSeparator;
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + selectValue[COMport_SELECT_SUPPLY_KA3305A] + strExcelSeparator;
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + selectValue[COMport_SELECT_SUPPLY_RD6024] + strExcelSeparator;
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + selectValue[COMport_SELECT_SUPPLY_RD6006] + strExcelSeparator;
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + selectValue[COMport_SELECT_SUPPLY_HCS_330] + strExcelSeparator;
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + selectValue[COMport_SELECT_LOAD_KEL103] + strExcelSeparator;

            return fun_set_com_port_selev_value;
        }

        */
        public void funWriteLogFile_COMports()
        {
            string fileDataLine = "";


            //-----------------------------------------------------------------------------
            //-- preveri se, ce datoteka se ne obstaja, da se zapise naslovna vrstica 
            if (!File.Exists(strLogFiles_COMports))
            {
                using (StreamWriter sw = File.AppendText(strLogFiles_COMports))
                {
                    fileDataLine = "Data" + strExcelSeparator;
                    fileDataLine = fileDataLine + "Time" + strExcelSeparator;
                    fileDataLine = fileDataLine+ fun_set_com_port_names();
                      //---------------------------------------------------------------------------------------------
                    sw.WriteLine(fileDataLine);
                }
            }
            //-----------------------------------------------------------------------------
            //-- zapis merilnih podatkov 
            using (StreamWriter sw = File.AppendText(strLogFiles_COMports))
            {
                fileDataLine = DateTime.Now.ToString("dd.MM.yyyy") + strExcelSeparator;
                fileDataLine = fileDataLine + DateTime.Now.ToString("HH:mm:ss") + strExcelSeparator;

                //fileDataLine = fileDataLine + fun_set_com_port_selev_value(COMport_name );
                fileDataLine = fileDataLine + COMport_name[COMport_SELECT_MULTIMETER_XDM3051] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_name[COMport_SELECT_MULTIMETER_XDM2041] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_name[COMport_SELECT_MULTIMETER_XDM1041] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_name[COMport_SELECT_TEMPERATURE_ET3916] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_name[COMport_SELECT_AC_METER_MPM_1010B] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_name[COMport_SELECT_SUPPLY_KA3305A] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_name[COMport_SELECT_SUPPLY_RD6024] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_name[COMport_SELECT_SUPPLY_RD6006] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_name[COMport_SELECT_SUPPLY_HCS_330] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_name[COMport_SELECT_LOAD_KEL103] + strExcelSeparator;

                sw.WriteLine(fileDataLine);
            }


        }


        public void funWriteLogFile_Devices_idents()
        {
            string fileDataLine = "";


            //-----------------------------------------------------------------------------
            //-- preveri se, ce datoteka se ne obstaja, da se zapise naslovna vrstica 
            if (!File.Exists(strLogFiles_Devices_ident))
            {
                using (StreamWriter sw = File.AppendText(strLogFiles_Devices_ident))
                {
                    fileDataLine = "Data" + strExcelSeparator;
                    fileDataLine = fileDataLine + "Time" + strExcelSeparator;
                    fileDataLine = fileDataLine + fun_set_com_port_names();
                    //---------------------------------------------------------------------------------------------
                    sw.WriteLine(fileDataLine);
                }
            }
            //-----------------------------------------------------------------------------
            //-- zapis merilnih podatkov 
            using (StreamWriter sw = File.AppendText(strLogFiles_Devices_ident))
            {
                fileDataLine = DateTime.Now.ToString("dd.MM.yyyy") + strExcelSeparator;
                fileDataLine = fileDataLine + DateTime.Now.ToString("HH:mm:ss") + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_device_ident[COMport_SELECT_MULTIMETER_XDM3051] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_device_ident[COMport_SELECT_MULTIMETER_XDM2041] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_device_ident[COMport_SELECT_MULTIMETER_XDM1041] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_device_ident[COMport_SELECT_TEMPERATURE_ET3916] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_device_ident[COMport_SELECT_AC_METER_MPM_1010B] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_device_ident[COMport_SELECT_SUPPLY_KA3305A] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_device_ident[COMport_SELECT_SUPPLY_RD6024] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_device_ident[COMport_SELECT_SUPPLY_RD6006] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_device_ident[COMport_SELECT_SUPPLY_HCS_330] + strExcelSeparator;
                fileDataLine = fileDataLine + COMport_device_ident[COMport_SELECT_LOAD_KEL103] + strExcelSeparator;

                sw.WriteLine(fileDataLine);
            }


        }




        /*
        private funErrorCode funWriteFile_INR21700M58_gauge(string filename)
        {
            string fileDataLine = "";
            try
            {
                //-----------------------------------------------------------------------------
                //-- preveri se, ce datoteka se ne obstaja, da se zapise naslovna vrstica 
                if (!File.Exists(filename))
                {
                    using (StreamWriter sw = File.AppendText(filename))
                    {
                        fileDataLine = "Time(sec) ";
                        fileDataLine = fileDataLine + "Voltage(mV) ";
                        fileDataLine = fileDataLine + "Current(mA) ";
                        fileDataLine = fileDataLine + "Temperature(degC) ";
                        //---------------------------------------------------------------------------------------------
                        sw.WriteLine(fileDataLine);
                    }
                }
                //-----------------------------------------------------------------------------------------------------
                //-- zapis merilnih podatkov 
                using (StreamWriter sw = File.AppendText(filename))
                {
                    fileDataLine = loc_run_duration_seconds.ToString() + " ";
                    fileDataLine = fileDataLine + (measureValue_multimeter_XDM3051 * 1000).ToString("0.0") + " ";
                    fileDataLine = fileDataLine + (charge_discharge_current * 1000).ToString("0.0") + " ";
                    fileDataLine = fileDataLine + temperature_now.ToString("0.0") + " ";
                    //-----------------------------------------------------------------------------
                    sw.WriteLine(fileDataLine);
                }
            }
            catch (Exception ex)
            {
                strFunctionErrorString = ex.ToString();
            }
            return (funErrorCode.OK);
        }


        */



    }
}
