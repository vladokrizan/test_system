using System;
using System.Collections.Generic;
using System.ComponentModel;
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


        ini_file ini_file = new ini_file();
        ac_meter_MPM_1010B ac_meter_MPM_1010B = new ac_meter_MPM_1010B();
        temperature_ET3916 temperature_ET3916 = new temperature_ET3916();

        connected_devices connected_devices = new connected_devices();
   complete_system complete_System = new complete_system(); 

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
            //------------------------------------------------------------------------------------
            ini_file.read_device_COMport_identification();
            //------------------------------------------------------------------------------------

            fun_mainWindow_load_init_COMports();


            connected_devices.Show();


            label1.Text = COMport_name[COMport_SELECT_AC_METER_MPM_1010B] + "    " + COMport_baudRate[COMport_SELECT_AC_METER_MPM_1010B].ToString();


            //MyIni.Write("COMport_name_LOAD_KEL103", COMport_name[COMport_SELECT_LOAD_KEL103], "Device COMport");
            //MyIni.Write("COMport_baudrate_LOAD_KEL103", COMport_baudRate[COMport_SELECT_LOAD_KEL103].ToString(), "Device COMport");

        }



        private int fun_select_COMport_open(byte select_port)
        {
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

                        return 0;
                        //device_MPM1010B_connected = true;

                    }
                    catch
                    {
                        return -3;
                        //device_MPM1010B_connected = false; 
                    }
                }
                {  return -2; }
            }
            else { return -1; }

        }


        private void fun_mainWindow_load_init_COMports()
        {

            try
            {
                device_MPM1010B_connected = false;
                device_ET3916_connected = false;
                device_MPM1010B_connected = false;
                device_MPM1010B_connected = false;
                device_MPM1010B_connected = false;
                device_MPM1010B_connected = false;
                if (fun_select_COMport_open(COMport_SELECT_AC_METER_MPM_1010B) == 0) device_MPM1010B_connected = true;
                if (fun_select_COMport_open(COMport_SELECT_TEMPERATURE_ET3916) == 0) device_ET3916_connected = true;

                /*
                if (COMport_name[COMport_SELECT_AC_METER_MPM_1010B] != null)
                {
                    if (COMport_name[COMport_SELECT_AC_METER_MPM_1010B].Length > 0)
                    {
                        try
                        {
                            //-----------------------------------------------------------------------------
                            //-- COM port in baudrate iz ini datoteke 
                            COMportSerial[COMport_SELECT_AC_METER_MPM_1010B].PortName = COMport_name[COMport_SELECT_AC_METER_MPM_1010B];
                            COMportSerial[COMport_SELECT_AC_METER_MPM_1010B].BaudRate = (int)COMport_baudRate[COMport_SELECT_AC_METER_MPM_1010B];
                            COMportSerial[COMport_SELECT_AC_METER_MPM_1010B].Open();
                            device_MPM1010B_connected = true;

                        }
                        catch { device_MPM1010B_connected = false; }
                    }
                }
                
                if (COMport_name[COMport_SELECT_TEMPERATURE_ET3916] != null)
                {
                    if (COMport_name[COMport_SELECT_TEMPERATURE_ET3916].Length > 0)
                    {
                        try
                        {
                            //-----------------------------------------------------------------------------
                            //-- COM port in baudrate iz ini datoteke 
                            COMportSerial[COMport_SELECT_TEMPERATURE_ET3916].PortName = COMport_name[COMport_SELECT_TEMPERATURE_ET3916];
                            COMportSerial[COMport_SELECT_TEMPERATURE_ET3916].BaudRate = (int)COMport_baudRate[COMport_SELECT_TEMPERATURE_ET3916];
                            COMportSerial[COMport_SELECT_TEMPERATURE_ET3916].Open();
                            device_ET3916_connected = true;

                        }
                        catch { device_ET3916_connected = false; }
                    }
                }
                */
            }
            catch { }

        }




        #endregion
        #region "mainWindow Timer 1  "
        private void timer1_Tick(object sender, EventArgs e)
        {

            labGlobalString.Text = strGeneralString;

            //-------------------------------------------------------------------------------------------------------------------
            //-- MATRIX AC Meter MPM1010B
            if (device_MPM1010B_read_all_read)
            {
                ac_meter_MPM_1010B.fun_read_all_MPM_1010B_read();
                label2.Text = device_MPM1010B_voltage.ToString() + "  " + device_MPM1010B_current.ToString() + "  " + device_MPM1010B_power.ToString() + "  " + device_MPM1010B_power_factor.ToString() + "  " + device_MPM1010B_freguency.ToString();
                label3.Text = strGeneralString;
            }
            if (device_MPM1010B_read_all_write && device_MPM1010B_connected) ac_meter_MPM_1010B.fun_read_all_MPM_1010B_write();
            //-------------------------------------------------------------------------------------------------------------------
            //-- East Tester ET3916-8   8 x Temperature 
            if (device_ET3916_bytes_command_write) { temperature_ET3916.fun_ET3916_send_bytes_command(); }
            else
            {
                if (device_ET3916_read_model_number) temperature_ET3916.fun_ET3916_read_command_model_number();
                if (device_ET3916_read_all_temperature)
                {
                    temperature_ET3916.fun_ET3916_read_command_all_temperature();

                    label8.Text = device_ET3916_temperature[1].ToString("0.00") + "   " + device_ET3916_temperature[2].ToString("0.00");
                }
            }

            /*
             * 
                public static bool device_ET3916_3bytes_command_write = false;
                public static bool device_ET3916_read_model_number = false;
                public static bool device_ET3916_read_serial_number = false;
            */
            label5.Text = device_MPM1010B_connected.ToString();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            test_system_identification test_system_identification = new test_system_identification();
            test_system_identification.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            device_MPM1010B_read_all_write = true;
            //ac_meter_MPM_1010B.fun_read_all_MPM_1010B();
            // label2.Text = device_MPM1010B_voltage.ToString() + "  " + device_MPM1010B_current.ToString() + "  " + device_MPM1010B_power.ToString() + "  " + device_MPM1010B_power_factor.ToString() + "  " + device_MPM1010B_freguency.ToString();
            // label3.Text = strGeneralString;
            //label2.Text = buffer[0].ToString("x") + "  " + buffer[1].ToString("x") + "  " + buffer[2].ToString("x") + "  " + buffer[3].ToString("x");
            //label3.Text = buffer[0].ToString() + "  " + buffer[1].ToString() + "  " + buffer[2].ToString() + "  " + buffer[3].ToString() + "  " + buffer[4].ToString();
            //label4.Text = buffer[0].ToString() + "  " + (buffer[1]&0x0F) .ToString() + "  " + (buffer[2] & 0x0F).ToString() + "  " + (buffer[3] & 0x0F).ToString() + "  " + (buffer[4] & 0x0F).ToString() + "  " + (buffer[5] & 0x0F).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            temperature_ET3916.fun_ET3916_read_model_nuber();
            label3.Text = strGeneralString;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temperature_ET3916.fun_ET3916_read_model_nuber();
            label7.Text = device_ET3916_dataArraySend[0].ToString("x") + "    " + device_ET3916_dataArraySend[1].ToString("x") + "    " + device_ET3916_dataArraySend[2].ToString("x") + "    " + device_ET3916_dataArraySend[3].ToString("x") + "    " + device_ET3916_dataArraySend[4].ToString("x") + "    " + device_ET3916_dataArraySend[5].ToString("x") + "    ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temperature_ET3916.fun_ET3916_read_serial_number();
            label7.Text = device_ET3916_dataArraySend[0].ToString("x") + "    " + device_ET3916_dataArraySend[1].ToString("x") + "    " + device_ET3916_dataArraySend[2].ToString("x") + "    " + device_ET3916_dataArraySend[3].ToString("x") + "    " + device_ET3916_dataArraySend[4].ToString("x") + "    " + device_ET3916_dataArraySend[5].ToString("x") + "    ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            temperature_ET3916.fun_ET3916_read_all_temperature();
            label7.Text = device_ET3916_dataArraySend[0].ToString("x") + "    " + device_ET3916_dataArraySend[1].ToString("x") + "    " + device_ET3916_dataArraySend[2].ToString("x") + "    " + device_ET3916_dataArraySend[3].ToString("x") + "    " + device_ET3916_dataArraySend[4].ToString("x") + "    " + device_ET3916_dataArraySend[5].ToString("x") + "    " + device_ET3916_dataArraySend[6].ToString("x") + "    ";
        }

        private void button7_Click(object sender, EventArgs e)
        {
           // temperature_ET3916.fun_ET3916_read_command_all_temperature();
            label8.Text = device_ET3916_temperature[1].ToString("0.00") + "   " + device_ET3916_temperature[2].ToString("0.00");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            complete_System.Show();
        }




        /*
        
        Example
                To read the product model number, send:
                    FE 00 01 20 71 88
                The result returned is "ET3916" :
                    FE 00 0E 20 45 54 33 39 31 36 00 00 00 00 00 00 00 28 E5

    */












    }
}
