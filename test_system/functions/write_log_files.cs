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

        const int selectCOMport_name = 1;
        const int selectCOMport_ident = 2;



        //=======================================================================================================================
        //=======================================================================================================================
        public void funWriteFile_application_info( string write_text)
        {
            string fileDataLine = "";

            fileDataLine = "";
            using (StreamWriter sw = File.AppendText(strLogFiles_application))
            {
                fileDataLine = DateTime.Now.ToString("dd.MM.yyyy") + strExcelSeparator;
                fileDataLine = fileDataLine + DateTime.Now.ToString("HH:mm:ss") + strExcelSeparator;
                //---------------------------------------------------------------------------------------------------
                fileDataLine = fileDataLine + write_text + strExcelSeparator;
                //---------------------------------------------------------------------------------------------------
                //-- zapis velikosti datoteke 
                long length = new System.IO.FileInfo(strLogFiles_application).Length;
                fileDataLine = fileDataLine + length.ToString() + strExcelSeparator;
                //---------------------------------------------------------------------------------------------------
                sw.WriteLine(fileDataLine);
            }
        }




        #region "write log file"    

        //=======================================================================================================================
        //=======================================================================================================================
        public void funWriteLogFile_program()
        {
            string fileDataLine = "";
            try
            {
                //------   if file exist then don't write anything 
                if (!File.Exists(strLogFiles_program))
                {
                    using (StreamWriter sw = File.AppendText(strLogFiles_program))
                    {
                        fileDataLine = "Date" + strExcelSeparator;
                        fileDataLine = fileDataLine + "Time" + strExcelSeparator;
                        foreach (KeyValuePair<string, string> diagnosisNameLocal in program_result_value)
                            fileDataLine = fileDataLine + diagnosisNameLocal.Key + strExcelSeparator;
                        sw.WriteLine(fileDataLine);
                    }
                }
                using (StreamWriter sw = File.AppendText(strLogFiles_program))
                {
                    fileDataLine = DateTime.Now.ToString("dd.MM.yyyy") + strExcelSeparator;
                    fileDataLine = fileDataLine + DateTime.Now.ToString("HH:mm:ss") + strExcelSeparator;
                    foreach (KeyValuePair<string, string> diagnosisValueLocal in program_result_value)
                        fileDataLine = fileDataLine + diagnosisValueLocal.Value + strExcelSeparator;
                    sw.WriteLine(fileDataLine);
                }
            }
            catch (Exception ex) { string strEx = ex.ToString(); }
        }

        #endregion

        #region "write log file POWER CONSUMPTION "    

        //=======================================================================================================================
        //=======================================================================================================================
        public void funWriteLogFile_power_consumption ()
        {
            string fileDataLine = "";
            try
            {
                //------   if file exist then don't write anything 
                if (!File.Exists(strLogFiles_power_consumption))
                {
                    using (StreamWriter sw = File.AppendText(strLogFiles_power_consumption))
                    {
                        fileDataLine = "";
                        foreach (KeyValuePair<string, string> diagnosisNameLocal in power_consumption)
                            fileDataLine = fileDataLine + diagnosisNameLocal.Key + strExcelSeparator;
                        sw.WriteLine(fileDataLine);
                    }
                }
                using (StreamWriter sw = File.AppendText(strLogFiles_power_consumption))
                {
                    fileDataLine = "";
                    foreach (KeyValuePair<string, string> diagnosisValueLocal in power_consumption)
                        fileDataLine = fileDataLine + diagnosisValueLocal.Value + strExcelSeparator;
                    sw.WriteLine(fileDataLine);
                }
            }
            catch (Exception ex) { string strEx = ex.ToString(); }
        }


        public void funWriteLogFile_SDM220()
        {

            //
            string fileDataLine = "";
            try
            {
                //------   if file exist then don't write anything 
                if (!File.Exists(strLogFiles_power_measure_SDM220))
                {
                    using (StreamWriter sw = File.AppendText(strLogFiles_power_measure_SDM220))
                    {
                        fileDataLine = "Date" + strExcelSeparator;
                        fileDataLine = fileDataLine + "Time" + strExcelSeparator;
                        foreach (KeyValuePair<string, string> diagnosisNameLocal in SDM220)
                            fileDataLine = fileDataLine + diagnosisNameLocal.Key + strExcelSeparator;
                        sw.WriteLine(fileDataLine);
                    }
                }
                using (StreamWriter sw = File.AppendText(strLogFiles_power_measure_SDM220))
                {
                    fileDataLine = DateTime.Now.ToString("dd.MM.yyyy") + strExcelSeparator;
                    fileDataLine = fileDataLine + DateTime.Now.ToString("HH:mm:ss") + strExcelSeparator;
                    foreach (KeyValuePair<string, string> diagnosisValueLocal in SDM220)
                        fileDataLine = fileDataLine + diagnosisValueLocal.Value + strExcelSeparator;
                    sw.WriteLine(fileDataLine);
                }
            }
            catch (Exception ex) { string strEx = ex.ToString(); }


        }


        #endregion


        #region "FILE FOR COM PORTS"
        private string fun_set_com_port_names()
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
            fun_set_com_port_name = fun_set_com_port_name + "SDM220 " + strExcelSeparator;

            return fun_set_com_port_name;
        }


        private string fun_select_variable(int selectVariable, int selectSerialNumber)
        {
            string returnValue = "";
            if (selectVariable == selectCOMport_name) { returnValue = COMport_port[selectSerialNumber] + strExcelSeparator; }
            if (selectVariable == selectCOMport_ident) { returnValue = COMport_device_ident[selectSerialNumber] + strExcelSeparator; }
            return returnValue;
        }

        private string fun_log_file_ComPort_value(int selectValue)
        {
            string fun_set_com_port_selev_value = "";
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + fun_select_variable(selectValue, COMport_XDM3051);
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + fun_select_variable(selectValue, COMport_XDM2041);
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + fun_select_variable(selectValue, COMport_XDM1041);
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + fun_select_variable(selectValue, COMport_ET3916);
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + fun_select_variable(selectValue, COMport_MPM_1010B);
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + fun_select_variable(selectValue, COMport_KA3305A);
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + fun_select_variable(selectValue, COMport_RD6024);
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + fun_select_variable(selectValue, COMport_RD6006);
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + fun_select_variable(selectValue, COMport_HCS_3300);
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + fun_select_variable(selectValue, COMport_KEL103);
            fun_set_com_port_selev_value = fun_set_com_port_selev_value + fun_select_variable(selectValue, COMport_SDM220);
            return fun_set_com_port_selev_value;
        }


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
                    fileDataLine = fileDataLine + fun_set_com_port_names();
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
                fileDataLine = fileDataLine + fun_log_file_ComPort_value(selectCOMport_name);
               sw.WriteLine(fileDataLine);
            }
        }

        public void funWriteLogFile_Devices_idents()
        {
            string fileDataLine = "";
            //-------------------------------------------------------------------------------------------------------------------
            //-- zapis merilnih podatkov 
            using (StreamWriter sw = File.AppendText(strLogFiles_Devices_ident))
            {
                fileDataLine = DateTime.Now.ToString("dd.MM.yyyy") + "      " + DateTime.Now.ToString("HH:mm:ss") + strNewLineSeparator;
                fileDataLine = fileDataLine + "MULTIMETER_XDM3051         " + COMport_device_ident[COMport_XDM3051] + strNewLineSeparator; //sw.WriteLine(fileDataLine);
                fileDataLine = fileDataLine + "MULTIMETER_XDM2041         " + COMport_device_ident[COMport_XDM2041] + strNewLineSeparator; //sw.WriteLine(fileDataLine);
                fileDataLine = fileDataLine + "MULTIMETER_XDM1041         " + COMport_device_ident[COMport_XDM1041] + strNewLineSeparator; //sw.WriteLine(fileDataLine);
                fileDataLine = fileDataLine + "TEMPERATURE_ET3916         " + COMport_device_ident[COMport_ET3916] + strNewLineSeparator; //sw.WriteLine(fileDataLine);
                fileDataLine = fileDataLine + "AC_METER_MPM_1010B         " + COMport_device_ident[COMport_MPM_1010B] + strNewLineSeparator;
                //-------------------------------------------------------------------------------------------------------------------
                fileDataLine = fileDataLine + "SUPPLY_KA3305A             " + COMport_device_ident[COMport_KA3305A] + strNewLineSeparator;
                fileDataLine = fileDataLine + "SUPPLY_HCS_330             " + COMport_device_ident[COMport_HCS_3300] + strNewLineSeparator;
                fileDataLine = fileDataLine + "SUPPLY_RD6006              " + COMport_device_ident[COMport_RD6006] + strNewLineSeparator;
                fileDataLine = fileDataLine + "SUPPLY_RD6024              " + COMport_device_ident[COMport_RD6024] + strNewLineSeparator;
                //-------------------------------------------------------------------------------------------------------------------
                fileDataLine = fileDataLine + "LOAD_KEL103                " + COMport_device_ident[COMport_KEL103] + strNewLineSeparator;
                //-------------------------------------------------------------------------------------------------------------------
                fileDataLine = fileDataLine + "AC meter SDM220            " + COMport_device_ident[COMport_SDM220] + strNewLineSeparator;
                //-------------------------------------------------------------------------------------------------------------------
                fileDataLine = fileDataLine + strNewLineSeparator;
                sw.WriteLine(fileDataLine);
             }
        }


        /*
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
                fileDataLine = fileDataLine + fun_log_file_ComPort_value(selectCOMport_ident);
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

        */


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

        #endregion




    }
}
