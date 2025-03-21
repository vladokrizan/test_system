﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static test_system.global_variable;

namespace test_system
{
    public partial class mainWindow : Form
    {
        //byte[] dataArray = new byte[1024];

        ini_file ini_file = new ini_file();
        ac_meter_MPM_1010B ac_meter_MPM_1010B = new ac_meter_MPM_1010B();
        temperature_ET3916 temperature_ET3916 = new temperature_ET3916();
        power_supply_hcs_3300 power_supply_hcs_3300 = new power_supply_hcs_3300();
        modbus_functions modbus_functions = new modbus_functions();
        power_supply_RD6006 power_supply_RD6006 = new power_supply_RD6006();
        power_supply_RD6024 power_supply_RD6024 = new power_supply_RD6024();
        AC_meter_SDM220 AC_meter_SDM220 = new AC_meter_SDM220();
        complete_system complete_System = new complete_system();
        all_devices all_devices = new all_devices();
        //modbus_functions modbus_functions = new modbus_functions();
        write_log_files write_log_files = new write_log_files();
        //-----------------------------------------------------------------------------------------------------------------------
        System.Windows.Forms.Label[] device = new System.Windows.Forms.Label[20];

        #region "Defined COM ports "
        /// <summary>
        ///   definirani so vsi COM porti za komunikacijo 
        /// </summary>
        static SerialPort COM_PORT_00 = new SerialPort(); static SerialPort COM_PORT_01 = new SerialPort(); static SerialPort COM_PORT_02 = new SerialPort(); static SerialPort COM_PORT_03 = new SerialPort(); static SerialPort COM_PORT_04 = new SerialPort();
        static SerialPort COM_PORT_05 = new SerialPort(); static SerialPort COM_PORT_06 = new SerialPort(); static SerialPort COM_PORT_07 = new SerialPort(); static SerialPort COM_PORT_08 = new SerialPort(); static SerialPort COM_PORT_09 = new SerialPort();
        static SerialPort COM_PORT_10 = new SerialPort(); static SerialPort COM_PORT_11 = new SerialPort(); static SerialPort COM_PORT_12 = new SerialPort(); static SerialPort COM_PORT_13 = new SerialPort(); static SerialPort COM_PORT_14 = new SerialPort();
        static SerialPort COM_PORT_15 = new SerialPort(); static SerialPort COM_PORT_16 = new SerialPort(); static SerialPort COM_PORT_17 = new SerialPort(); static SerialPort COM_PORT_18 = new SerialPort(); static SerialPort COM_PORT_19 = new SerialPort();

        public static System.IO.Ports.SerialPort[] COMportSerial =
        {
            COM_PORT_00, COM_PORT_01, COM_PORT_02, COM_PORT_03, COM_PORT_04,
            COM_PORT_05, COM_PORT_06, COM_PORT_07, COM_PORT_08, COM_PORT_09,
            COM_PORT_10, COM_PORT_11, COM_PORT_12, COM_PORT_13, COM_PORT_14,
            COM_PORT_15, COM_PORT_16, COM_PORT_17, COM_PORT_18, COM_PORT_19
        };
        #endregion
        #region "mainWindow load , close "
        public mainWindow()
        {
            InitializeComponent();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {

            strLogFiles_COMports = System.Environment.CurrentDirectory + "\\" + "COMports_selected.csv";
            strLogFiles_Devices_ident = System.Environment.CurrentDirectory + "\\" + "Devices_idents.txt";
            //-------------------------------------------------------------------------------------------------------------------
            ini_file.read_device_COMport_identification();
            //-------------------------------------------------------------------------------------------------------------------
            fun_mainWindow_load_init_COMports();
            //-------------------------------------------------------------------------------------------------------------------
           if (!Directory.Exists(strSubFolderLogApplication)) { DirectoryInfo di = Directory.CreateDirectory(strSubFolderLogApplication); }
            if (!Directory.Exists(strSubFolderLog)) { DirectoryInfo di = Directory.CreateDirectory(strSubFolderLog); }
            //-------------------------------------------------------------------------------------------------------------------
            device[1] = labDevice_XDM3051;
            device[2] = labDevice_XDM2041;
            device[3] = labDevice_XDM1041;
            device[4] = labDevice_ET3916;
            device[5] = labDevice_MPM1010B;
            device[6] = labDevice_multimeter_free;
            device[7] = labDevice_KA3305P;
            device[8] = labDevice_HCS_330;
            device[9] = labDevice_RD6006;
            device[10] = labDevice_RD6024;
            device[11] = labDevice_supply_free;
            device[12] = labDevice_KEL103;
            //-------------------------------------------------------------------------------------------------------------------
            labDevice_XDM3051.Text = "XDM3051";
            labDevice_XDM2041.Text = "XDM2041";
            labDevice_XDM1041.Text = "XDM1041";
            labDevice_ET3916.Text = "ET3916";
            labDevice_MPM1010B.Text = "MPM-1010B";
            labDevice_multimeter_free.Text = "";
            labDevice_KA3305P.Text = "KA3305P";
            labDevice_HCS_330.Text = "HCS-330";
            labDevice_RD6006.Text = "RD6006";
            labDevice_RD6024.Text = "RD6024";
            labDevice_supply_free.Text = "";
            labDevice_KEL103.Text = "KEL103";
            //-------------------------------------------------------------------------------------------------------------------
            IsMdiContainer = true;
            //-------------------------------------------------------------------------------------------------------------------
            intMainWindow_x = this.Location.X;
            intMainWindow_y = this.Location.Y;
            //-------------------------------------------------------------------------------------------------------------------
            program_1 program_1 = new program_1();
            program_1.MdiParent = this;
            program_1.Show();





        }

        private void mainWindow_Move(object sender, EventArgs e)
        {
            intMainWindow_x = this.Location.X;
            intMainWindow_y = this.Location.Y;
        }


        #endregion
        #region "COMports  "
        private int fun_select_COMport_open(byte select_port)
        {
            if (select_port == COMport_XDM3051) COMport_name[select_port] = strCOMport_multimeter_name_XDM3051;
            else if (select_port == COMport_XDM2041) COMport_name[select_port] = strCOMport_multimeter_name_XDM2041;
            else if (select_port == COMport_XDM1041) COMport_name[select_port] = strCOMport_multimeter_name_XDM1041;
            else if (select_port == COMport_ET3916) COMport_name[select_port] = strCOMport_name_ET3916;
            else if (select_port == COMport_MPM_1010B) COMport_name[select_port] = strCOMport_name_MPM_1010B;

            else if (select_port == COMport_KA3305A) COMport_name[select_port] = strCOMport_supply_name_KA3305A;
            else if (select_port == COMport_HCS_3300) COMport_name[select_port] = strCOMport_supply_name_HCS_330;
            else if (select_port == COMport_RD6006) COMport_name[select_port] = strCOMport_supply_name_RD6006;
            else if (select_port == COMport_RD6024) COMport_name[select_port] = strCOMport_supply_PID_RD6024;
            else if (select_port == COMport_KEL103) COMport_name[select_port] = strCOMport_load_name_KEL103;
            else if (select_port == COMport_SDM220) COMport_name[select_port] = strCOMport_name_SDM220;

            dev_connected[select_port] = false;
            dev_meas_state[select_port] = funReturnCodeCOMport.NOT_MEAS;

            if (COMport_port[select_port] != null)
            {
                if (COMport_port[select_port].Length > 0)
                {
                    try
                    {
                        //-----------------------------------------------------------------------------
                        //-- COM port in baudrate iz ini datoteke 
                        COMportSerial[select_port].PortName = COMport_port[select_port];
                        COMportSerial[select_port].BaudRate = (int)COMport_baudRate[select_port];

                        COMportSerial[select_port].DataBits = 8;

                        COMportSerial[select_port].Parity = Parity.None;
                        COMportSerial[select_port].StopBits = StopBits.One;

                        COMportSerial[select_port].ReadTimeout = 100;

                        COMportSerial[select_port].Open();
                        dev_connected[select_port] = true;

                        return 0;
                    }
                    catch { return -3; }
                }
                else { return -2; }
            }
            else { return -1; }
        }

        private void fun_mainWindow_load_init_COMports()
        {
            try
            {
                if (fun_select_COMport_open(COMport_XDM1041) == 0) { }
                if (fun_select_COMport_open(COMport_XDM2041) == 0) { }
                if (fun_select_COMport_open(COMport_XDM3051) == 0) { }
                if (fun_select_COMport_open(COMport_KA3305A) == 0) { }
                if (fun_select_COMport_open(COMport_HCS_3300) == 0) { }
                if (fun_select_COMport_open(COMport_MPM_1010B) == 0) { }
                if (fun_select_COMport_open(COMport_ET3916) == 0) { }
                if (fun_select_COMport_open(COMport_KEL103) == 0) { }
                if (fun_select_COMport_open(COMport_RD6006) == 0) { }
                if (fun_select_COMport_open(COMport_RD6024) == 0) { }
                if (fun_select_COMport_open(COMport_SDM220) == 0) { }
                //---------------------------------------------------------------------------------------------------------------
                //-- RD6006 in RD6024 -- MODBUS komunikacija
                COM_PORT_09.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(COM_PORT_RD6006_DataReceived);
                COM_PORT_10.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(COM_PORT_RD6024_DataReceived);
                COM_PORT_15.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(COM_PORT_SDM220_DataReceived);
                COMportSerial[COMport_RD6006].ReceivedBytesThreshold = 100;
                COMportSerial[COMport_RD6024].ReceivedBytesThreshold = 100;
                COMportSerial[COMport_SDM220].ReceivedBytesThreshold = 100;
            }
            catch { }
        }
        #region "COM port RD6006
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        private void COM_PORT_RD6006_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //byte receiveByteLocal;
            byte[] receiveByte_modbus_local = new byte[100];
            int loc_loop;
            try
            {
                receiveByte_modbus_lenght[COMport_RD6006] = (byte)COMportSerial[COMport_RD6006].BytesToRead;
                // strGeneralString = "RD6006   "+ receiveByte_modbus_lenght.ToString();
                if (receiveByte_modbus_lenght[COMport_RD6006] > 0)
                {
                    //bCOMport_recLen[COMport_SELECT_SUPPLY_RD6006] = receiveByteLocal;
                    //COMportSerial[COMport_RD6006].Read(receiveByte_modbus, 0, receiveByte_modbus_lenght);
                    COMportSerial[COMport_RD6006].Read(receiveByte_modbus_local, 0, receiveByte_modbus_lenght[COMport_RD6006]);
                    for (loc_loop = 0; loc_loop < receiveByte_modbus_lenght[COMport_RD6006]; loc_loop++) { receiveByte_modbus[COMport_RD6006, loc_loop] = receiveByte_modbus_local[loc_loop]; }
                    modbus_functions.funModbusRTU_receive_mesasage(COMport_RD6006);
                    //-----------------------------------------------------------------------------------------------------------
                    if (modbus_start_register == 0)
                    {
                        if (modbus_register_number == 4)
                        {
                            if (modbus_register_type == 3)
                            {
                                power_supply_RD6006.funModbusRTU_RD6006_receive_ident();
                            }
                        }
                    }
                    //-----------------------------------------------------------------------------------------------------------
                    if (modbus_start_register == 8)
                    {
                        if (modbus_register_number == 10)
                        {
                            if (modbus_register_type == 3)
                            {
                                power_supply_RD6006.funModbusRTU_receive_mesasage_RD6006();
                            }
                        }
                    }
                    //-----------------------------------------------------------------------------------------------------------
                    strGeneralString = "RD602  " + receiveByte_modbus_lenght.ToString() + "   start " + modbus_start_register.ToString() + "    Reg " + modbus_register_number.ToString() + "   Type " + modbus_register_type.ToString();
                    // power_supply_RD6006.funModbusRTU_receive_mesasage_RD6006(COMport_SELECT_SUPPLY_RD6006);
                    //  strGeneralString = receiveByteLocal.ToString() +"    "+ receiveByte_RD6006[0].ToString()+"   "+ receiveByte_RD6006[1].ToString() + "   " + receiveByte_RD6006[2].ToString() + "   " + receiveByte_RD6006[3].ToString() + "   " + receiveByte_RD6006[4].ToString() + "   " + receiveByte_RD6006[5].ToString();
                    //-----------------------------------------------------------------------------
                    //for (loc_loop = 0; loc_loop < receiveByteLocal; loc_loop++) { COMport_recByte[COMport_SELECT_SUPPLY_RD6006, loc_loop] = receiveByte_local[loc_loop]; }
                    //-----------------------------------------------------------------------------
                    //funCOMports_receive_parse_received_byte(selectCOMporLocal);
                }


            }
            catch { }
        }
        #endregion
        #region "COM port RD6024"
        //=======================================================================================================================
        //=======================================================================================================================
        private void COM_PORT_RD6024_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            byte[] receiveByte_modbus_local = new byte[100];
            int loc_loop;


            //te receiveByteLocal;
            try
            {


                receiveByte_modbus_lenght[COMport_RD6024] = (byte)mainWindow.COMportSerial[COMport_RD6024].BytesToRead;

                strGeneralString = "RD6024   " + receiveByte_modbus_lenght.ToString();

                if (receiveByte_modbus_lenght[COMport_RD6024] > 0)
                {
                    //bCOMport_recLen[selectCOMporLocal] = receiveByteLocal;
                    //mainWindow.COMportSerial[COMport_SELECT_SUPPLY_RD6024].Read(receiveByte_modbus, 0, receiveByteLocal);
                    //COMportSerial[COMport_RD6024].Read(receiveByte_modbus, 0, receiveByte_modbus_lenght);
                    COMportSerial[COMport_RD6024].Read(receiveByte_modbus_local, 0, receiveByte_modbus_lenght[COMport_RD6024]);
                    for (loc_loop = 0; loc_loop < receiveByte_modbus_lenght[COMport_RD6024]; loc_loop++) { receiveByte_modbus[COMport_RD6024, loc_loop] = receiveByte_modbus_local[loc_loop]; }
                    modbus_functions.funModbusRTU_receive_mesasage(COMport_RD6024);
                    //-----------------------------------------------------------------------------------------------------------
                    if (modbus_start_register == 0)
                    {
                        if (modbus_register_number == 4)
                        {
                            if (modbus_register_type == 3)
                            { 
                                power_supply_RD6024.funModbusRTU_RD6024_receive_ident();         
                            }
                        }
                    }
                    //-----------------------------------------------------------------------------------------------------------
                    if (modbus_register_type == 3)
                    {
                        if (modbus_register_number == 2)
                        {
                            if (modbus_start_register == 10)
                            {
                                rd6024_OutputVoltag = ((float)(modbus_register[0])) / 100;
                                modbus_functions.funModbusRTU_send_request_read_function_3(1, 12, 2, COMport_RD6024);
                                //power_supply_RD6024.funModbusRTU_receive_mesasage_RD6024();
                            }
                            else if (modbus_start_register == 12)
                            {
                                rd6024_OutputCurrent = ((float)(modbus_register[0])) / 100;
                                modbus_functions.funModbusRTU_send_request_read_function_3(1, 14, 2, COMport_RD6024);
                                device_RD6024_show_all_measure = true;
                                //power_supply_RD6024.funModbusRTU_receive_mesasage_RD6024();
                            }
                        }
                    }
                    strGeneralString = "RD6024   " + receiveByte_modbus_lenght.ToString() + "   start " + modbus_start_register.ToString() + "    Reg " + modbus_register_number.ToString() + "   Type " + modbus_register_type.ToString();
                    //strGeneralString = receiveByteLocal.ToString() + "  " + receiveByte_RD6024[0].ToString() + "  " + receiveByte_RD6024[1].ToString() + "  " + receiveByte_RD6024[2].ToString();
                    //-----------------------------------------------------------------------------
                    ///for (loc_loop = 0; loc_loop < receiveByteLocal; loc_loop++) { COMport_recByte[selectCOMporLocal, loc_loop] = receiveByte_local[loc_loop]; }
                    //-----------------------------------------------------------------------------
                    //funCOMports_receive_parse_received_byte(selectCOMporLocal);
                    //COMports.fun_COMport_received_string(selectCOMporLocal);
                }
            }
            catch { }
        }

        #endregion

        #region "COM port SDM220
        //=======================================================================================================================
        /// <summary>
        ///     sprejem modbus paketa iz SDM220
        ///     prenos podatkov iz AC_meter_SDM220
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        private void COM_PORT_SDM220_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] receiveByte_modbus_local = new byte[100];
           int loc_loop;
            try
            {
                receiveByte_modbus_lenght[COMport_SDM220] = (byte)COMportSerial[COMport_SDM220].BytesToRead;
                if (receiveByte_modbus_lenght[COMport_SDM220] > 0)
                {
                    COMportSerial[COMport_SDM220].Read(receiveByte_modbus_local, 0, receiveByte_modbus_lenght[COMport_SDM220]);
                    for (loc_loop = 0; loc_loop < receiveByte_modbus_lenght[COMport_SDM220]; loc_loop++) { receiveByte_modbus[COMport_SDM220, loc_loop] = receiveByte_modbus_local[loc_loop]; }
                    modbus_functions.funModbusRTU_receive_mesasage(COMport_SDM220);

                    //strGeneralString = "SDM2200  " + receiveByte_modbus_lenght.ToString() + "   start " + modbus_start_register.ToString() + "    Reg " + modbus_register_number.ToString() + "   Type " + modbus_register_type.ToString() + "    " + modbus_register[0].ToString("X") + " " + modbus_register[0].ToString() + " " + modbus_register[1].ToString("X");


                    if (modbus_address == 5)
                    {
     

                        if (modbus_register_type == 4)
                        {

     

                            if (modbus_register_number == 2)


                            {


                                AC_meter_SDM220.funModbusRTU_SDM220_receive_one_data();

                               // strGeneralString = "SDM2200  " + receiveByte_modbus_lenght.ToString() + "   start " + modbus_start_register.ToString() + "    Reg " + modbus_register_number.ToString() + "   Type " + modbus_register_type.ToString() + "    " + modbus_register[0].ToString("X") + " " + modbus_register[0].ToString() + " " + modbus_register[1].ToString("X");


                                //listBox1.Items.Add("strGeneralString");
                            }
                        }
                    }
                }
            }
            catch { }
        }
        #endregion



        #endregion
        #region "Prikaz COM portov  in priključenih instrumentov   "

        private void fun_show_one_device(int selectedCOMport)
        {
            try
            {
                device[selectedCOMport].Visible = false;
                if (dev_connected[selectedCOMport]) { device[selectedCOMport].Visible = true; }
                if (dev_active[selectedCOMport]) { device[selectedCOMport].ForeColor = Color.Green; } else device[selectedCOMport].ForeColor = Color.Black;
            }
            catch { }
        }

        public void fun_show_connected_device()
        {
            fun_show_one_device(COMport_XDM3051);
            fun_show_one_device(COMport_XDM2041);
            fun_show_one_device(COMport_XDM1041);
            fun_show_one_device(COMport_ET3916);
            fun_show_one_device(COMport_MPM_1010B);
            fun_show_one_device(COMport_SELECT_METER_FREE);
            fun_show_one_device(COMport_KA3305A);
            fun_show_one_device(COMport_HCS_3300);
            fun_show_one_device(COMport_RD6006);
            fun_show_one_device(COMport_RD6024);
            fun_show_one_device(COMport_SELECT_SUPPLY_FREE);
            fun_show_one_device(COMport_KEL103);
            //fun_show_one_device(COMport_SDM220);
        }

        #endregion


        #region "mainWindow Timer 1  "
        private void timer1_Tick(object sender, EventArgs e)
        {

            //listBox1.Items.Add("strGeneralString");
            listBox1.Items.Clear();

            listBox1.Items.Add(SDM220_voltage.ToString());
            listBox1.Items.Add(SDM220_Current.ToString());
            listBox1.Items.Add(SDM220_Active_power.ToString());
            listBox1.Items.Add(SDM220_Apparent_power.ToString());
            listBox1.Items.Add(SDM220_Reactive_power.ToString());
            listBox1.Items.Add(SDM220_Power_factor.ToString());
            listBox1.Items.Add(SDM220_Phase_angle.ToString());
            listBox1.Items.Add(SDM220_Frequency.ToString());
            listBox1.Items.Add(SDM220_Import_active_energy.ToString());
            listBox1.Items.Add(SDM220_Export_active_energy.ToString());
            listBox1.Items.Add(SDM220_Import_reactive_energy.ToString());
            listBox1.Items.Add(SDM220_Export_reactive_energy.ToString());
            listBox1.Items.Add(SDM220_Total_active_energy.ToString());
            listBox1.Items.Add(SDM220_Total_reactive_energy.ToString());


   
            //-------------------------------------------------------------------------------------------------------------------
            //-- prikaz prikljucenih COM portov in aktivnih instrumentov 
            fun_show_connected_device();
            textBox1.Text = strGeneralString;
            label3.Text = strGeneralString;

            label1.Text = COMportSerial[COMport_RD6006].ReceivedBytesThreshold.ToString() + "   " + COMportSerial[COMport_RD6024].ReceivedBytesThreshold.ToString();

            label2.Text = COMportSerial[COMport_SDM220].ReceivedBytesThreshold.ToString();

            // label13.Text = strGeneralString;
            //label10.Text = COMport_connected[COMport_SELECT_SUPPLY_HCS_330].ToString() + "   " + COMport_connected[COMport_SELECT_TEMPERATURE_ET3916].ToString() + "   " + device_ET3916_serial_number;
            //label10.Text = " XDM 1041 " + COMport_connected[COMport_SELECT_MULTIMETER_XDM1041].ToString();
            // labGlobalString.Text = strGeneralString;
            //-------------------------------------------------------------------------------------------------------------------
            //-- MATRIX AC Meter MPM1010B
            if (device_MPM1010B_read_all_read)
            {
                ac_meter_MPM_1010B.fun_read_all_MPM_1010B_read();
                label2.Text = device_MPM1010B_voltage.ToString() + "  " + device_MPM1010B_current.ToString() + "  " + device_MPM1010B_power.ToString() + "  " + device_MPM1010B_power_factor.ToString() + "  " + device_MPM1010B_freguency.ToString();
            }
            if (device_MPM1010B_read_all_write && dev_connected[COMport_MPM_1010B]) ac_meter_MPM_1010B.fun_read_all_MPM_1010B_write();
            //-------------------------------------------------------------------------------------------------------------------
            //-- East Tester ET3916-8   8 x Temperature 
            if (device_ET3916_bytes_command_write) { temperature_ET3916.fun_ET3916_send_bytes_command(); }
            else
            {
                if (device_ET3916_read_serial_number) temperature_ET3916.fun_ET3916_read_command_serial_number();
                if (device_ET3916_read_model_number) temperature_ET3916.fun_ET3916_read_command_model_number();
                if (device_ET3916_read_all_temperature)
                {
                    temperature_ET3916.fun_ET3916_read_command_all_temperature();
                    //label8.Text = device_ET3916_temperature[1].ToString("0.00") + "   " + device_ET3916_temperature[2].ToString("0.00");
                }
            }
            //label5.Text = COMport_connected[COMport_SELECT_AC_METER_MPM_1010B].ToString();
        }

        #endregion

        #region "buttons"

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            complete_System.Show();
        }


        private void button13_Click(object sender, EventArgs e)
        {
            all_devices.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test_system_identification test_system_identification = new test_system_identification();
            test_system_identification.Show();
        }

        #endregion

        #region "MENU LINE "

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void program1VerifyConnectedDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fun_close_all_programs();
            program_1 program_1 = new program_1();
            program_1.MdiParent = this;
            program_1.Show();
        }
        private void program10TestPowerSupplyDigitalMultimeterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fun_close_all_programs();
            program_10_test_supply_multimeter program_10_test_supply_multimeeter = new program_10_test_supply_multimeter();
            program_10_test_supply_multimeeter.MdiParent = this;
            program_10_test_supply_multimeeter.Show();
        }

        private void program20MeasureCapacitiyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fun_close_all_programs();
            program_20_battery_test program_20_battery_test = new program_20_battery_test();
            program_20_battery_test.MdiParent = this;
            program_20_battery_test.Show();
        }

        #endregion
        #region "PROGRAMS "
        private void fun_close_all_programs()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }



        #endregion



        //multimeter_XDM3051.fun_XDM3051_measure();

        //power_supply_RD6006.funRD6006_measure();
        //COMport_device_ident[COMport_SELECT_MULTIMETER_XDM3051] = "OWON, XDM3051,2303195,V3.7.2,2";
        //COMport_device_ident[COMport_SELECT_MULTIMETER_XDM1041] = "XDM1041,23120418,V4.1.0,3";
        //COMport_device_ident[COMport_SELECT_SUPPLY_KA3305A] = "KORAD KA3305P V7.0 SN: 30057214";
        //COMport_device_ident[COMport_SELECT_LOAD_KEL103] = "KORAD-KEL103 V3.30 SN: 00022116";
        //write_log_files.funWriteLogFile_Devices_idents();
        // modbus_functions.funModbusRTU_send_set_single_register_function_6(1, 18, 0, COMport_SELECT_SUPPLY_RD6006);
        //mainWindow.COMportSerial[selComPort_supply_RD6006].DiscardInBuffer();
        //modbus_function.funModbusRTU_send_request_read_function_3(1, 0, 20, selComPort_supply_RD6006);
        //COMportSerial[COMport_SELECT_SUPPLY_RD6006].DiscardInBuffer();
        //modbus_functions.funModbusRTU_send_request_read_function_3(1, 0, 20, COMport_SELECT_SUPPLY_RD6006);
        //mainWindow.COMportSerial[COMport_SELECT_MULTIMETER_XDM3051].WriteLine("*IDN?");
        //textBox1.Text = COMportSerial[COMport_SELECT_MULTIMETER_XDM3051].ReadLine();
        //dataArray = Encoding.ASCII.GetBytes("GMArX\r");
        //label1.Text = dataArray[0].ToString() + " " + dataArray[1].ToString() + " " + dataArray[2].ToString() + " " + dataArray[3].ToString() + " " + dataArray[4].ToString() + " " + dataArray[5].ToString();
        //label1.Text = dataArray[0].ToString() + " " + dataArray[1].ToString() + " " + dataArray[2].ToString() + " " + dataArray[3].ToString() + " " + dataArray[4].ToString();
        //label2.Text = dataArray.Length.ToString();
        //device_MPM1010B_read_all_write = true;
        //ac_meter_MPM_1010B.fun_read_all_MPM_1010B();
        // label2.Text = device_MPM1010B_voltage.ToString() + "  " + device_MPM1010B_current.ToString() + "  " + device_MPM1010B_power.ToString() + "  " + device_MPM1010B_power_factor.ToString() + "  " + device_MPM1010B_freguency.ToString();
        // label3.Text = strGeneralString;
        //label2.Text = buffer[0].ToString("x") + "  " + buffer[1].ToString("x") + "  " + buffer[2].ToString("x") + "  " + buffer[3].ToString("x");
        //label3.Text = buffer[0].ToString() + "  " + buffer[1].ToString() + "  " + buffer[2].ToString() + "  " + buffer[3].ToString() + "  " + buffer[4].ToString();
        //label4.Text = buffer[0].ToString() + "  " + (buffer[1]&0x0F) .ToString() + "  " + (buffer[2] & 0x0F).ToString() + "  " + (buffer[3] & 0x0F).ToString() + "  " + (buffer[4] & 0x0F).ToString() + "  " + (buffer[5] & 0x0F).ToString();


        private void button2_Click(object sender, EventArgs e)
        {
            mainWindow.COMportSerial[COMport_SDM220].DiscardInBuffer();
            modbus_functions.funModbusRTU_send_request_read_function_4(5, 0, 2, COMport_SDM220);
            //modbus_functions.funModbusRTU_send_request_read_function_3(5, 22, 2, COMport_SDM220);



            //fun_close_all_programs();
        }


    }
}
