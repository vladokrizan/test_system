using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
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

        public static System.IO.Ports.SerialPort[] COMportSerial =
        {
            COM_PORT_00, COM_PORT_01, COM_PORT_02, COM_PORT_03, COM_PORT_04,
            COM_PORT_05, COM_PORT_06, COM_PORT_07, COM_PORT_08, COM_PORT_09,
            COM_PORT_10, COM_PORT_11, COM_PORT_12, COM_PORT_13, COM_PORT_14
        };
        #endregion




        public mainWindow()
        {
            InitializeComponent();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            //------------------------------------------------------------------------------------
            ini_file.read_device_COMport_identification();

            //-----------------------------------------------------------------------------
            //-- COM port in baudrate iz ini datoteke 
            COMportSerial[COMport_SELECT_AC_METER_MPM_1010B].PortName = COMport_name[COMport_SELECT_AC_METER_MPM_1010B];
            COMportSerial[COMport_SELECT_AC_METER_MPM_1010B].BaudRate = (int)COMport_baudRate[COMport_SELECT_AC_METER_MPM_1010B];
            COMportSerial[COMport_SELECT_AC_METER_MPM_1010B].Open();    


            label1.Text = COMport_name[COMport_SELECT_AC_METER_MPM_1010B] + "    " + COMport_baudRate[COMport_SELECT_AC_METER_MPM_1010B].ToString();








           //             MyIni.Write("COMport_name_LOAD_KEL103", COMport_name[COMport_SELECT_LOAD_KEL103], "Device COMport");
           // MyIni.Write("COMport_baudrate_LOAD_KEL103", COMport_baudRate[COMport_SELECT_LOAD_KEL103].ToString(), "Device COMport");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            test_system_identification test_system_identification = new test_system_identification();
            test_system_identification.Show();  
        }

        private void button2_Click(object sender, EventArgs e)
             {


            ac_meter_MPM_1010B.fun_read_all_MPM_1010B();

            label2.Text = device_MPM1010B_voltage.ToString() + "  " + device_MPM1010B_current.ToString() + "  " + device_MPM1010B_power.ToString() + "  " + device_MPM1010B_power_factor.ToString() + "  " + device_MPM1010B_freguency.ToString();
            label3.Text = strGeneralString;

            //label2.Text = buffer[0].ToString("x") + "  " + buffer[1].ToString("x") + "  " + buffer[2].ToString("x") + "  " + buffer[3].ToString("x");
            //label3.Text = buffer[0].ToString() + "  " + buffer[1].ToString() + "  " + buffer[2].ToString() + "  " + buffer[3].ToString() + "  " + buffer[4].ToString();
            //label4.Text = buffer[0].ToString() + "  " + (buffer[1]&0x0F) .ToString() + "  " + (buffer[2] & 0x0F).ToString() + "  " + (buffer[3] & 0x0F).ToString() + "  " + (buffer[4] & 0x0F).ToString() + "  " + (buffer[5] & 0x0F).ToString();







        }
    }
}
