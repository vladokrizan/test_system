﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static test_system.global_variable;


namespace test_system
{
    internal class ini_file
    {
        #region "Variable: File Name "



        string file_name_device_ident = "com_port_ident.ini";

        #endregion

        #region "COMMON FUNCTION FOR READ AND WRITE SETTINGS.INI FILE "
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
        public ini_file(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }
        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }
        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }
        #endregion

        //=======================================================================================================================
        //=======================================================================================================================
        public void write_device_COMport_identification()
        {
            try
            {
                var MyIni = new ini_file(file_name_device_ident);
                //---------------------------------------------------------------------------------------------------------------
                //---------------------------------------------------------------------------------------------------------------
                MyIni.Write("COMport_name_SUPPLY_KA3305A", COMport_name[COMport_SELECT_SUPPLY_KA3305A], "Device COMport");
                MyIni.Write("COMport_baudrate_SUPPLY_KA3305A", COMport_baudRate[COMport_SELECT_SUPPLY_KA3305A].ToString(), "Device COMport");
                //---------------------------------------------------------------------------------------------------------------
                MyIni.Write("COMport_name_SUPPLY_RD6024", COMport_name[COMport_SELECT_SUPPLY_RD6024], "Device COMport");
                MyIni.Write("COMport_baudrate_SUPPLY_RD6024", COMport_baudRate[COMport_SELECT_SUPPLY_RD6024].ToString(), "Device COMport");
                //---------------------------------------------------------------------------------------------------------------
                MyIni.Write("COMport_name_SUPPLY_RD6006", COMport_name[COMport_SELECT_SUPPLY_RD6006], "Device COMport");
                MyIni.Write("COMport_baudrate_SUPPLY_RD6006", COMport_baudRate[COMport_SELECT_SUPPLY_RD6006].ToString(), "Device COMport");
                //---------------------------------------------------------------------------------------------------------------
                MyIni.Write("COMport_name_SUPPLY_HCS_330", COMport_name[COMport_SELECT_SUPPLY_HCS_330], "Device COMport");
                MyIni.Write("COMport_baudrate_SUPPLY_HCS_330", COMport_baudRate[COMport_SELECT_SUPPLY_HCS_330].ToString(), "Device COMport");
                //---------------------------------------------------------------------------------------------------------------
                //---------------------------------------------------------------------------------------------------------------
                MyIni.Write("COMport_name_LOAD_KEL103", COMport_name[COMport_SELECT_LOAD_KEL103], "Device COMport");
                MyIni.Write("COMport_baudrate_LOAD_KEL103", COMport_baudRate[COMport_SELECT_LOAD_KEL103].ToString(), "Device COMport");
                //---------------------------------------------------------------------------------------------------------------
                MyIni.Write("COMport_name_temperature_ET3916", COMport_name[COMport_SELECT_TEMPERATURE_ET3916], "Device COMport");
                MyIni.Write("COMport_baudrate_temperature_ET3916", COMport_baudRate[COMport_SELECT_TEMPERATURE_ET3916].ToString(), "Device COMport");
                //---------------------------------------------------------------------------------------------------------------
                MyIni.Write("COMport_name_ACmeter_MPM_1010B", COMport_name[COMport_SELECT_AC_METER_MPM_1010B], "Device COMport");
                MyIni.Write("COMport_baudrate_ACmeter_MPM_1010B", COMport_baudRate[COMport_SELECT_AC_METER_MPM_1010B].ToString(), "Device COMport");
                 }
            catch { }
        }


        //=======================================================================================================================
        //=======================================================================================================================
        public void read_device_COMport_identification()
        {
            try
            {
                string retVal = string.Empty;
                string basePath = System.Environment.CurrentDirectory;
                ini_file ini = new ini_file(basePath + "\\com_port_ident.ini");
                string iniFileExist = basePath + "\\com_port_ident.ini";
                if (!File.Exists(iniFileExist))
                {
                   COMport_name[COMport_SELECT_SUPPLY_KA3305A] = "";
                    COMport_name[COMport_SELECT_SUPPLY_RD6024] = "";
                    COMport_name[COMport_SELECT_SUPPLY_RD6006] = "";
                    COMport_name[COMport_SELECT_LOAD_KEL103] = "";
                    COMport_name[COMport_SELECT_TEMPERATURE_ET3916] = "";
                    COMport_name[COMport_SELECT_AC_METER_MPM_1010B] = "";

                    MessageBox.Show(iniFileExist + "  file doesnt' exist. Make default file ");
                    write_device_COMport_identification();
                }
                COMport_name[COMport_SELECT_SUPPLY_KA3305A] = ini.Read("COMport_name_SUPPLY_KA3305A", "Device COMport");
                COMport_baudRate[COMport_SELECT_SUPPLY_KA3305A] = Convert.ToUInt32(ini.Read("COMport_baudrate_SUPPLY_KA3305A", "Device COMport"));
                //---------------------------------------------------------------------------------------------------------------
                COMport_name[COMport_SELECT_SUPPLY_RD6024] = ini.Read("COMport_name_SUPPLY_RD6024", "Device COMport");
                COMport_baudRate[COMport_SELECT_SUPPLY_RD6024] = Convert.ToUInt32(ini.Read("COMport_baudrate_SUPPLY_RD6024", "Device COMport"));
                //---------------------------------------------------------------------------------------------------------------
                COMport_name[COMport_SELECT_SUPPLY_RD6006] = ini.Read("COMport_name_SUPPLY_RD6006", "Device COMport");
                COMport_baudRate[COMport_SELECT_SUPPLY_RD6006] = Convert.ToUInt32(ini.Read("COMport_baudrate_SUPPLY_RD6006", "Device COMport"));
                //---------------------------------------------------------------------------------------------------------------
                COMport_name[COMport_SELECT_SUPPLY_HCS_330] = ini.Read("COMport_name_SUPPLY_HCS_330", "Device COMport");
                COMport_baudRate[COMport_SELECT_SUPPLY_HCS_330] = Convert.ToUInt32(ini.Read("COMport_baudrate_SUPPLY_HCS_330", "Device COMport"));
                //---------------------------------------------------------------------------------------------------------------
                COMport_name[COMport_SELECT_LOAD_KEL103] = ini.Read("COMport_name_LOAD_KEL103", "Device COMport");
                COMport_baudRate[COMport_SELECT_LOAD_KEL103] = Convert.ToUInt32(ini.Read("COMport_baudrate_LOAD_KEL103", "Device COMport"));

        

                //---------------------------------------------------------------------------------------------------------------
                COMport_name[COMport_SELECT_TEMPERATURE_ET3916] = ini.Read("COMport_name_temperature_ET3916", "Device COMport");
                COMport_baudRate[COMport_SELECT_TEMPERATURE_ET3916] = Convert.ToUInt32(ini.Read("COMport_baudrate_temperature_ET3916", "Device COMport"));
                //---------------------------------------------------------------------------------------------------------------
                COMport_name[COMport_SELECT_AC_METER_MPM_1010B] = ini.Read("COMport_name_ACmeter_MPM_1010B", "Device COMport");
                COMport_baudRate[COMport_SELECT_AC_METER_MPM_1010B] = Convert.ToUInt32(ini.Read("COMport_baudrate_ACmeter_MPM_1010B", "Device COMport"));
                //---------------------------------------------------------------------------------------------------------------

            }
            catch { }
        }



    }
}
