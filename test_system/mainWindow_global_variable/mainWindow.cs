using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
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


        byte[] dataArray = new byte[1024];

        ini_file ini_file = new ini_file();
        ac_meter_MPM_1010B ac_meter_MPM_1010B = new ac_meter_MPM_1010B();
        temperature_ET3916 temperature_ET3916 = new temperature_ET3916();
        power_supply_hcs_3300 power_supply_hcs_3300 = new power_supply_hcs_3300();
        modbus_functions modbus_functions = new modbus_functions(); 


        connected_devices connected_devices = new connected_devices();
        complete_system complete_System = new complete_system();
        all_devices all_devices = new all_devices();

        write_log_files write_log_files = new write_log_files();

        #region "Defined COM ports "
        /// <summary>
        ///   definirani so vsi COM porti za komunikacijo 
        /// </summary>
        public static SerialPort COM_PORT_00 = new SerialPort();
        static SerialPort COM_PORT_01 = new SerialPort();
        static SerialPort COM_PORT_02 = new SerialPort();
        static SerialPort COM_PORT_03 = new SerialPort();
        static SerialPort COM_PORT_04 = new SerialPort();
        static SerialPort COM_PORT_05 = new SerialPort();
        static SerialPort COM_PORT_06 = new SerialPort();
        static SerialPort COM_PORT_07 = new SerialPort();
        static SerialPort COM_PORT_08 = new SerialPort();
        static SerialPort COM_PORT_09 = new SerialPort();
        static SerialPort COM_PORT_10 = new SerialPort();
        static SerialPort COM_PORT_11 = new SerialPort();
        static SerialPort COM_PORT_12 = new SerialPort();
        static SerialPort COM_PORT_13 = new SerialPort();
        static SerialPort COM_PORT_14 = new SerialPort();
        static SerialPort COM_PORT_15 = new SerialPort();
        static SerialPort COM_PORT_16 = new SerialPort();
        static SerialPort COM_PORT_17 = new SerialPort();
        static SerialPort COM_PORT_18 = new SerialPort();
        static SerialPort COM_PORT_19 = new SerialPort();
        static SerialPort COM_PORT_20 = new SerialPort();

        public static System.IO.Ports.SerialPort[] COMportSerial =
        {
            COM_PORT_00, COM_PORT_01, COM_PORT_02, COM_PORT_03, COM_PORT_04,
            COM_PORT_05, COM_PORT_06, COM_PORT_07, COM_PORT_08, COM_PORT_09,
            COM_PORT_10, COM_PORT_11, COM_PORT_12, COM_PORT_13, COM_PORT_14,
            COM_PORT_15, COM_PORT_16, COM_PORT_17, COM_PORT_18, COM_PORT_19, COM_PORT_20
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
            strLogFiles_Devices_ident = System.Environment.CurrentDirectory + "\\" + "Devices_idents.csv";
            //------------------------------------------------------------------------------------
            ini_file.read_device_COMport_identification();
            //------------------------------------------------------------------------------------
            fun_mainWindow_load_init_COMports();

        }



        private int fun_select_COMport_open(byte select_port)
        {
            COMport_connected[select_port] = false;
            if (COMport_name[select_port] != null)
            {
                if (COMport_name[select_port].Length > 0)
                {
                    try
                    {
                        //-----------------------------------------------------------------------------
                        //-- COM port in baudrate iz ini datoteke 
                        COMportSerial[select_port].PortName = COMport_name[select_port];
                        COMportSerial[select_port].BaudRate = (int)COMport_baudRate[select_port];
                        COMportSerial[select_port].Open();
                        COMport_connected[select_port] = true;
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

                if (fun_select_COMport_open(COMport_SELECT_MULTIMETER_XDM1041) == 0) { }
                if (fun_select_COMport_open(COMport_SELECT_MULTIMETER_XDM3051) == 0) { }
                if (fun_select_COMport_open(COMport_SELECT_SUPPLY_KA3305A) == 0) { }
                if (fun_select_COMport_open(COMport_SELECT_SUPPLY_HCS_330) == 0) { }
                if (fun_select_COMport_open(COMport_SELECT_AC_METER_MPM_1010B) == 0) { }
                if (fun_select_COMport_open(COMport_SELECT_TEMPERATURE_ET3916) == 0) { }
                if (fun_select_COMport_open(COMport_SELECT_LOAD_KEL103) == 0) { }
                if (fun_select_COMport_open(COMport_SELECT_SUPPLY_RD6006) == 0) { }
                if (fun_select_COMport_open(COMport_SELECT_SUPPLY_RD6024) == 0) { }


                COM_PORT_05.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(COM_PORT_05_DataReceived);
                COM_PORT_01.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(COM_PORT_01_DataReceived);



                string show_connected = "";
                show_connected = "XDM1041: " + COMport_connected[COMport_SELECT_MULTIMETER_XDM1041].ToString();
                show_connected = show_connected + "  XDM3051:" + COMport_connected[COMport_SELECT_MULTIMETER_XDM3051].ToString();
                show_connected = show_connected + "  HCS_330:" + COMport_connected[COMport_SELECT_SUPPLY_HCS_330].ToString();
                show_connected = show_connected + "  MPM_1010B:" + COMport_connected[COMport_SELECT_AC_METER_MPM_1010B].ToString();
                show_connected = show_connected + "  ET3916:" + COMport_connected[COMport_SELECT_TEMPERATURE_ET3916].ToString();
                show_connected = show_connected + "  KA3305A:" + COMport_connected[COMport_SELECT_SUPPLY_KA3305A].ToString();
                show_connected = show_connected + "  KEL103:" + COMport_connected[COMport_SELECT_LOAD_KEL103].ToString();
                show_connected = show_connected + "  RD6006:" + COMport_connected[COMport_SELECT_SUPPLY_RD6006].ToString();
                show_connected = show_connected + "  RD6024:" + COMport_connected[COMport_SELECT_SUPPLY_RD6024].ToString();
                label12.Text = show_connected;
            }
            catch { }
        }


        #region "COM port 00
        //=============================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=============================================================================================================
        private  void COM_PORT_05_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //byte selectCOMporLocal = 0;
            byte receiveByteLocal;
            // byte loc_loop;

            try
            {
                receiveByteLocal = (byte)COMportSerial[COMport_SELECT_SUPPLY_RD6006].BytesToRead;


                label3.Text = "Receive";


                if (receiveByteLocal > 0)
                {
                    //bCOMport_recLen[selectCOMporLocal] = receiveByteLocal;
                    COMportSerial[COMport_SELECT_SUPPLY_RD6006].Read(receiveByte_RD6006, 0, receiveByteLocal);

                    //COMport_SELECT_SUPPLY_RD6006

     
                    //-----------------------------------------------------------------------------
                    //for (loc_loop = 0; loc_loop < receiveByteLocal; loc_loop++) { COMport_recByte[COMport_SELECT_SUPPLY_RD6006, loc_loop] = receiveByte_local[loc_loop]; }
                    //-----------------------------------------------------------------------------
                    //funCOMports_receive_parse_received_byte(selectCOMporLocal);
                }
            }
            catch { }
        }

        //public const byte COMport_SELECT_SUPPLY_RD6024 = 5;
        //public const byte COMport_SELECT_SUPPLY_RD6006 = 6;
       // public static byte[] receiveByte_RD6006 = new byte[100];
       // public static byte[] receiveByte_RD6024 = new byte[100];


        #endregion
        #region "COM port 01"
        //=============================================================================================================
        //=============================================================================================================
        private void COM_PORT_01_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //byte selectCOMporLocal = 1;
            byte receiveByteLocal;
            //byte[] receiveByte_local = new byte[100];
            //byte loc_loop;
            try
            {
                receiveByteLocal = (byte)mainWindow.COMportSerial[COMport_SELECT_SUPPLY_RD6024].BytesToRead;
                if (receiveByteLocal > 0)
                {
                    //bCOMport_recLen[selectCOMporLocal] = receiveByteLocal;
                    mainWindow.COMportSerial[COMport_SELECT_SUPPLY_RD6024].Read(receiveByte_RD6024, 0, receiveByteLocal);
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



        #endregion
        #region "mainWindow Timer 1  "
        private void timer1_Tick(object sender, EventArgs e)
        {

            label10.Text = COMport_connected[COMport_SELECT_SUPPLY_HCS_330].ToString() + "   " + COMport_connected[COMport_SELECT_TEMPERATURE_ET3916].ToString() + "   " + device_ET3916_serial_number;
            //label10.Text = " XDM 1041 " + COMport_connected[COMport_SELECT_MULTIMETER_XDM1041].ToString();
            labGlobalString.Text = strGeneralString;
            //-------------------------------------------------------------------------------------------------------------------
            //-- MATRIX AC Meter MPM1010B
            if (device_MPM1010B_read_all_read)
            {
                ac_meter_MPM_1010B.fun_read_all_MPM_1010B_read();
                label2.Text = device_MPM1010B_voltage.ToString() + "  " + device_MPM1010B_current.ToString() + "  " + device_MPM1010B_power.ToString() + "  " + device_MPM1010B_power_factor.ToString() + "  " + device_MPM1010B_freguency.ToString();
                label3.Text = strGeneralString;
            }
            if (device_MPM1010B_read_all_write && COMport_connected[COMport_SELECT_AC_METER_MPM_1010B]) ac_meter_MPM_1010B.fun_read_all_MPM_1010B_write();
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
                    label8.Text = device_ET3916_temperature[1].ToString("0.00") + "   " + device_ET3916_temperature[2].ToString("0.00");
                }
            }

            //label5.Text = COMport_connected[COMport_SELECT_AC_METER_MPM_1010B].ToString();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            test_system_identification test_system_identification = new test_system_identification();
            test_system_identification.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // modbus_functions.funModbusRTU_send_set_single_register_function_6(1, 18, 0, COMport_SELECT_SUPPLY_RD6006);

            //mainWindow.COMportSerial[selComPort_supply_RD6006].DiscardInBuffer();
            //modbus_function.funModbusRTU_send_request_read_function_3(1, 0, 20, selComPort_supply_RD6006);

            COMportSerial[COMport_SELECT_SUPPLY_RD6006].DiscardInBuffer();
            modbus_functions.funModbusRTU_send_request_read_function_3(1, 0, 20, COMport_SELECT_SUPPLY_RD6006);



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
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            complete_System.Show();
        }


        private void button13_Click(object sender, EventArgs e)
        {
            all_devices.Show();
        }










    }
}
