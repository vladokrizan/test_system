﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Management;
//-------------------------------------------------------------------------------------------------------------------------------
using static test_system.global_variable;

namespace test_system
{
    public partial class test_system_identification : Form
    {

        ini_file ini_file = new ini_file();


        public test_system_identification()
        {
            InitializeComponent();
        }

        private void test_system_identification_Load(object sender, EventArgs e)
        {





        }






        #region "dolocitev COMport iz VIP, PID in serial  "


        private void btnSelectDevices_Click(object sender, EventArgs e)
        {
            funSelect_COMport_modules();
        }



        private void fun_search_device(int select_device, UInt32 baudrate,
                                        string search_serial, string search_VIP, string search_PID,
                                        string current_ID, string current_COMport)
        {
            if (current_ID.Contains(search_serial))
            {
                if (current_ID.Contains(search_VIP))
                {
                    if (current_ID.Contains(search_PID))
                    {
                        COMport_name[select_device] = current_COMport;
                        COMport_baudRate[select_device] = baudrate;
                        listBox1.Items.Add(COMport_name[select_device] + "      " + COMport_baudRate[select_device].ToString());
                    }
                }
            }

        }






        private void funSelect_COMport_modules()
        {

            COMport_name[COMport_SELECT_SUPPLY_KA3305A] = "";
            COMport_name[COMport_SELECT_SUPPLY_RD6024] = "";
            COMport_name[COMport_SELECT_SUPPLY_RD6006] = "";
            COMport_name[COMport_SELECT_LOAD_KEL103] = "";

            using (ManagementClass i_Entity = new ManagementClass("Win32_PnPEntity"))
            {
                foreach (ManagementObject i_Inst in i_Entity.GetInstances())
                {
                    Object o_Guid = i_Inst.GetPropertyValue("ClassGuid");
                    //-- Skip all devices except device class "PORTS"
                    if (o_Guid == null || o_Guid.ToString().ToUpper() != "{4D36E978-E325-11CE-BFC1-08002BE10318}") continue;
                    String s_DeviceID = i_Inst.GetPropertyValue("PnpDeviceID").ToString();
                    String s_RegPath = "HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Enum\\" + s_DeviceID + "\\Device Parameters";
                    String s_PortName = Registry.GetValue(s_RegPath, "PortName", "").ToString();

                    fun_search_device(COMport_SELECT_SUPPLY_KA3305A, 115200, strCOMport_supply_serial_KA3305A, strCOMport_supply_VID_KA3305A, strCOMport_supply_PID_KA3305A, s_DeviceID, s_PortName);
                    fun_search_device(COMport_SELECT_SUPPLY_HCS_330, 115200, strCOMport_supply_serial_HCS_330, strCOMport_supply_VID_HCS_330, strCOMport_supply_PID_HCS_330, s_DeviceID, s_PortName);
                    fun_search_device(COMport_SELECT_LOAD_KEL103, 115200, strCOMport_load_serial_KEL103, strCOMport_load_VID_KEL103, strCOMport_load_PID_KEL103, s_DeviceID, s_PortName);
                    fun_search_device(COMport_SELECT_AC_METER_MPM_1010B, 9600, strCOMport_load_serial_MPM_1010B, strCOMport_load_VID_MPM_1010B, strCOMport_load_PID_MPM_1010B, s_DeviceID, s_PortName);



                }
            }

            if (COMport_name[COMport_SELECT_SUPPLY_KA3305A].Length > 0) { listBox1.Items.Add("KA3305A:    " + COMport_name[COMport_SELECT_SUPPLY_KA3305A]); }
            if (COMport_name[COMport_SELECT_SUPPLY_RD6024].Length > 0) { listBox1.Items.Add("RD6024:    " + COMport_name[COMport_SELECT_SUPPLY_RD6024]); }
            if (COMport_name[COMport_SELECT_SUPPLY_RD6006].Length > 0) { listBox1.Items.Add("RD6006:    " + COMport_name[COMport_SELECT_SUPPLY_RD6006]); }
            if (COMport_name[COMport_SELECT_SUPPLY_HCS_330].Length > 0) { listBox1.Items.Add("MANSON: HCS-330:    " + COMport_name[COMport_SELECT_SUPPLY_HCS_330]); }
            if (COMport_name[COMport_SELECT_LOAD_KEL103].Length > 0) { listBox1.Items.Add("KEL103:    " + COMport_name[COMport_SELECT_LOAD_KEL103]); }
            if (COMport_name[COMport_SELECT_AC_METER_MPM_1010B].Length > 0) { listBox1.Items.Add("MATRIX MPM-1010B:    " + COMport_name[COMport_SELECT_AC_METER_MPM_1010B]); }


            //------------------------------------------------------------------------------------
            ini_file.write_device_COMport_identification();


        }



   

        #endregion








        #region "Najde se vse povezane  COM porte "


        private void btnFindAllCOMports_Click(object sender, EventArgs e)
        {
            int textBoxCounter = 1;
            string strShowString = "";
            /*
            //-------------------------------------------------------------------------------------------------------------------
            //--   show list of valid com ports
            foreach (string s in SerialPort.GetPortNames())
            {
                // listBox1.Items.Add(s);
            }

            try
            {
                listBox1.Items.Add("-----------------------------------------------------------------");
                serial_nuber_for_search = fun_read_file_serial_number();
                listBox1.Items.Add(serial_nuber_for_search);
                listBox1.Items.Add("-----------------------------------------------------------------");
            }
            catch { ErrorExist = true; }
            */


 
                using (ManagementClass i_Entity = new ManagementClass("Win32_PnPEntity"))
                {
                    foreach (ManagementObject i_Inst in i_Entity.GetInstances())
                    {
                        Object o_Guid = i_Inst.GetPropertyValue("ClassGuid");
                        if (o_Guid == null || o_Guid.ToString().ToUpper() != "{4D36E978-E325-11CE-BFC1-08002BE10318}")
                            continue; // Skip all devices except device class "PORTS"

                        //String s_Caption = i_Inst.GetPropertyValue("Caption").ToString();
                        //String s_Manufact = i_Inst.GetPropertyValue("Manufacturer").ToString();
                        String s_DeviceID = i_Inst.GetPropertyValue("PnpDeviceID").ToString();
                        String s_RegPath = "HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Enum\\" + s_DeviceID + "\\Device Parameters";
                        String s_PortName = Registry.GetValue(s_RegPath, "PortName", "").ToString();
                    //int s32_Pos = s_Caption.IndexOf(" (COM");
                    //if (s32_Pos > 0) // remove COM port from description
                    //s_Caption = s_Caption.Substring(0, s32_Pos);
                    //listBox1.Items.Add("Port Name:    " + s_PortName);
                    //listBox1.Items.Add("Description:  " + s_Caption);
                    //listBox1.Items.Add("Manufacturer: " + s_Manufact);
                    //listBox1.Items.Add("Device ID:    " + s_DeviceID);

                    strShowString = s_PortName + "     " + s_DeviceID;

                        if (textBoxCounter == 1) textBoxIdent_01.Text = strShowString;
                        else if (textBoxCounter == 2) textBoxIdent_02.Text = strShowString;
                        else if (textBoxCounter == 3) textBoxIdent_03.Text = strShowString;
                        else if (textBoxCounter == 4) textBoxIdent_04.Text = strShowString;
                        else if (textBoxCounter == 5) textBoxIdent_05.Text = strShowString;
                        else if (textBoxCounter == 6) textBoxIdent_06.Text = strShowString;
                        else if (textBoxCounter == 7) textBoxIdent_07.Text = strShowString;
                        else if (textBoxCounter == 8) textBoxIdent_08.Text = strShowString;
                        else if (textBoxCounter == 9) textBoxIdent_09.Text = strShowString;
                        else if (textBoxCounter == 10) textBoxIdent_10.Text = strShowString;


                        /*
                        if (s_DeviceID.Contains(serial_nuber_for_search))
                        {
                            listBox1.Items.Add("-----------------------------------------------------------------");
                            listBox1.Items.Add("FOUND     " + s_PortName);
                            listBox1.Items.Add("-----------------------------------------------------------------");
                            fun_write_file(s_PortName);
                        }
                        */
                        textBoxCounter++;

                    }
                }
   
        }




        #endregion

    
    }
}
