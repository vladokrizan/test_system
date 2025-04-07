using System;
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
using static test_system.app_version_history;

namespace test_system
{
    public partial class mainWindow : Form
    {
        ini_file ini_file = new ini_file();
        ac_meter_MPM_1010B ac_meter_MPM_1010B = new ac_meter_MPM_1010B();
        temperature_ET3916 temperature_ET3916 = new temperature_ET3916();
        power_supply_hcs_3300 power_supply_hcs_3300 = new power_supply_hcs_3300();
        power_supply_RD6006 power_supply_RD6006 = new power_supply_RD6006();
        power_supply_RD6024 power_supply_RD6024 = new power_supply_RD6024();
        AC_meter_SDM220 AC_meter_SDM220 = new AC_meter_SDM220();

        complete_system complete_System = new complete_system();
        all_devices all_devices = new all_devices();
        write_log_files write_log_files = new write_log_files();
        modbus modbus_functions = new modbus();
        applicatiuon_function applicatiuon_function = new applicatiuon_function();
        COMports_functions COMports_functions = new COMports_functions();
        //-----------------------------------------------------------------------------------------------------------------------
        public static System.Windows.Forms.Label[] device = new System.Windows.Forms.Label[20];
        //public static System.Windows.Forms.Label[] device =
        //    {
        //        labDevice_XDM3051, labDevice_XDM2041, labDevice_XDM1041, labDevice_ET3916, labDevice_MPM1010,
        //        labDevice_multimeter_free,labDevice_KA3305P,labDevice_HCS_330, labDevice_RD6006,labDevice_RD6024,
        //        labDevice_supply_free, labDevice_KEL103,labDevice_free_13, labDevice_free_14, labDevice_SDM220
        //        };


        #region "Defined COM ports "
        /// <summary>
        ///   definirani so vsi COM porti za komunikacijo 
        /// </summary>
        static SerialPort COM_PORT_00 = new SerialPort(); static SerialPort COM_PORT_01 = new SerialPort(); static SerialPort COM_PORT_02 = new SerialPort(); static SerialPort COM_PORT_03 = new SerialPort(); static SerialPort COM_PORT_04 = new SerialPort();
        static SerialPort COM_PORT_05 = new SerialPort(); static SerialPort COM_PORT_06 = new SerialPort(); static SerialPort COM_PORT_07 = new SerialPort(); static SerialPort COM_PORT_08 = new SerialPort(); static SerialPort COM_PORT_09 = new SerialPort();
        static SerialPort COM_PORT_10 = new SerialPort(); static SerialPort COM_PORT_11 = new SerialPort(); static SerialPort COM_PORT_12 = new SerialPort(); static SerialPort COM_PORT_13 = new SerialPort(); static SerialPort COM_PORT_14 = new SerialPort();
        static SerialPort COM_PORT_15 = new SerialPort(); static SerialPort COM_PORT_16 = new SerialPort(); static SerialPort COM_PORT_17 = new SerialPort(); static SerialPort COM_PORT_18 = new SerialPort(); static SerialPort COM_PORT_19 = new SerialPort();
        //-----------------------------------------------------------------------------------------------------------------------
        //-- public COMporti, ki se lahko uporabijo v drugih clasih
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
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        //=======================================================================================================================
        private void mainWindow_Load(object sender, EventArgs e)
        {
            strLogFiles_COMports = System.Environment.CurrentDirectory + "\\" + "COMports_selected.csv";
            strLogFiles_Devices_ident = System.Environment.CurrentDirectory + "\\" + "Devices_idents.txt";
            //-------------------------------------------------------------------------------------------------------------------
            ini_file.read_device_COMport_identification();
            //-------------------------------------------------------------------------------------------------------------------
            //-- odprejo se porti za kater je v ini datoteki določen port 
            COMports_functions.fun_mainWindow_load_init_COMports();
            dev_connected_show = true;
            //-------------------------------------------------------------------------------------------------------------------
            //-- zaćetek prenosa podatkov merilnika energije 
            if (dev_connected[COMport_SDM220])
            {
                mainWindow.COMportSerial[COMport_SDM220].DiscardInBuffer();
                modbus_functions.funModbusRTU_send_request_read_function_4(5, 0, 2, COMport_SDM220);
                SDM220_data_start = true;
            }
            //-------------------------------------------------------------------------------------------------------------------
            //-- preverita se poddirektorija za shranjevanje log datotek   log  log_app
            if (!Directory.Exists(strSubFolderLogApplication)) { DirectoryInfo di = Directory.CreateDirectory(strSubFolderLogApplication); }
            if (!Directory.Exists(strSubFolderLog)) { DirectoryInfo di = Directory.CreateDirectory(strSubFolderLog); }
            //-------------------------------------------------------------------------------------------------------------------
            //-- prikaz priključenih in aktivnih instrumentopv 
            device[COMport_XDM3051] = labDevice_XDM3051; device[2] = labDevice_XDM2041; device[3] = labDevice_XDM1041; device[4] = labDevice_ET3916; device[5] = labDevice_MPM1010B;
            device[6] = labDevice_multimeter_free; device[7] = labDevice_KA3305P; device[8] = labDevice_HCS_330; device[9] = labDevice_RD6006; device[10] = labDevice_RD6024;
            device[11] = labDevice_supply_free; device[12] = labDevice_KEL103; device[13] = labDevice_free_13; device[14] = labDevice_free_14; device[COMport_SDM220] = labDevice_SDM220;
            //-------------------------------------------------------------------------------------------------------------------
            device[COMport_XDM3051].Text = "XDM3051"; labDevice_XDM2041.Text = "XDM2041"; labDevice_XDM1041.Text = "XDM1041";
            labDevice_ET3916.Text = "ET3916"; labDevice_MPM1010B.Text = "MPM-1010B"; labDevice_multimeter_free.Text = "";
            labDevice_KA3305P.Text = "KA3305P"; labDevice_HCS_330.Text = "HCS-330"; labDevice_RD6006.Text = "RD6006"; labDevice_RD6024.Text = "RD6024"; labDevice_supply_free.Text = "";
            labDevice_KEL103.Text = "KEL103"; device[13].Text = ""; device[14].Text = "";
            device[COMport_SDM220].Text = "SDM220";
            //-------------------------------------------------------------------------------------------------------------------
            IsMdiContainer = true;
            //-------------------------------------------------------------------------------------------------------------------
            intMainWindow_x = this.Location.X;
            intMainWindow_y = this.Location.Y;
            //-------------------------------------------------------------------------------------------------------------------
            //-- začetek preverjanja pristnosti povezanih naprav 
            program_1 program_1 = new program_1();
            program_1.MdiParent = this;
            program_1.Show();
            //-------------------------------------------------------------------------------------------------------------------
            strLogFiles_application = System.Environment.CurrentDirectory + "\\" + strSubFolderLogApplication + ".\\" + "application_" + DateTime.Now.ToString("yyyy_MM") + ".csv";
            write_log_files.funWriteFile_application_info("Application start  Ver: " + sw_version + "    Date: " + SW_DATE);
            //-------------------------------------------------------------------------------------------------------------------
            strLogFiles_power_consumption = System.Environment.CurrentDirectory + "\\" + strSubFolderLogApplication + ".\\" + "power_consumption_" + DateTime.Now.ToString("yyyy") + ".csv";
           strLogFiles_power_measure_SDM220 = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "power_measure_" + DateTime.Now.ToString("yyyy_MM") + ".csv";
   
        SDM220_voltage_minimal = 500;
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        private void mainWindow_Move(object sender, EventArgs e)
        {
            intMainWindow_x = this.Location.X;
            intMainWindow_y = this.Location.Y;
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        private void mainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                if (dev_connected[i]) mainWindow.COMportSerial[i].Close();
            }
        }

        #endregion
        #region "mainWindow Timer 1  "
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------------------------------
            //-- prikaz prikljucenih COM portov in aktivnih instrumentov 
            if (dev_connected_show) COMports_functions.fun_show_connected_device();
            textBox1.Text = strGeneralString;
            //label3.Text = strGeneralString;
            //label1.Text = COMportSerial[COMport_RD6006].ReceivedBytesThreshold.ToString() + "   " + COMportSerial[COMport_RD6024].ReceivedBytesThreshold.ToString();
            //label2.Text = COMportSerial[COMport_SDM220].ReceivedBytesThreshold.ToString();
            // label13.Text = strGeneralString;
            //label10.Text = COMport_connected[COMport_SELECT_SUPPLY_HCS_330].ToString() + "   " + COMport_connected[COMport_SELECT_TEMPERATURE_ET3916].ToString() + "   " + device_ET3916_serial_number;
            //label10.Text = " XDM 1041 " + COMport_connected[COMport_SELECT_MULTIMETER_XDM1041].ToString();
            // labGlobalString.Text = strGeneralString;
            //-------------------------------------------------------------------------------------------------------------------
            //-- konec aplikacije po zapisu v log datoteko porabe energije 
            if (SDM220_application_stop) { this.Close(); }
            //-------------------------------------------------------------------------------------------------------------------
            //-- izvajanje vsako sekundo             
            timer_mainWindow_new_second = (byte)(DateTime.Now.Second);
            if (timer_mainWindow_new_second != timer_mainWindow_old_second)
            {
                timer_mainWindow_old_second = timer_mainWindow_new_second;


                if (SDM220_data_continue_read)
                {
                   if ( ++ SDM220_data_continue_read_time_run >= SDM220_data_continue_read_time_set )
                    {
                        SDM220_data_continue_read_time_run = 0;
                        mainWindow.COMportSerial[COMport_SDM220].DiscardInBuffer();
                        modbus_functions.funModbusRTU_send_request_read_function_4(5, 0, 2, COMport_SDM220);

                    }

                }

                //label5.Text = timer_mainWindow_old_second.ToString() ;
                //mainWindow.COMportSerial[COMport_SDM220].DiscardInBuffer();
                //modbus_functions.funModbusRTU_send_request_read_function_4(5, 0, 2, COMport_SDM220);
            }
            //-------------------------------------------------------------------------------------------------------------------
            //-- MATRIX AC Meter MPM1010B
            if (device_MPM1010B_read_all_read) { ac_meter_MPM_1010B.fun_read_all_MPM_1010B_read(); }
            if (device_MPM1010B_read_all_write && dev_connected[COMport_MPM_1010B]) ac_meter_MPM_1010B.fun_read_all_MPM_1010B_write();
            //-------------------------------------------------------------------------------------------------------------------
            //-- East Tester ET3916-8   8 x Temperature 
            if (device_ET3916_bytes_command_write) { temperature_ET3916.fun_ET3916_send_bytes_command(); }
            else
            {
                if (device_ET3916_read_serial_number) temperature_ET3916.fun_ET3916_read_command_serial_number();
                if (device_ET3916_read_model_number) temperature_ET3916.fun_ET3916_read_command_model_number();
                if (device_ET3916_read_all_temperature) { temperature_ET3916.fun_ET3916_read_command_all_temperature(); }
            }
            //label2.Text = device_MPM1010B_voltage.ToString() + "  " + device_MPM1010B_current.ToString() + "  " + device_MPM1010B_power.ToString() + "  " + device_MPM1010B_power_factor.ToString() + "  " + device_MPM1010B_freguency.ToString();
            //label5.Text = COMport_connected[COMport_SELECT_AC_METER_MPM_1010B].ToString();

            /*
                if (SDM220_data_show )
                {
                    SDM220_data_show = false;
                    listBox1.Items.Clear();
                    foreach (KeyValuePair<string, string> diagnosisValueLocal in SDM220)              listBox1.Items.Add( diagnosisValueLocal.Value.ToString() );
                }

    */


        }
        #endregion
        #region "buttons"
        //=======================================================================================================================
        /// <summary>
        ///     CLOSE gumb 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (dev_active[COMport_SDM220])
            {
                mainWindow.COMportSerial[COMport_SDM220].DiscardInBuffer();
                modbus_functions.funModbusRTU_send_request_read_function_4(5, 0, 2, COMport_SDM220);
                SDM220_data_stop = true;
                SDM220_data_continue_read_time_run = 0;
            }
            else
            {
                this.Close();
            }
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        private void button8_Click(object sender, EventArgs e)
        {
            complete_System.Show();
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
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
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dev_active[COMport_SDM220])
            {
                mainWindow.COMportSerial[COMport_SDM220].DiscardInBuffer();
                modbus_functions.funModbusRTU_send_request_read_function_4(5, 0, 2, COMport_SDM220);
                SDM220_data_stop = true;
                SDM220_data_continue_read_time_run = 0;
            }
            else
            {
                this.Close();
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        private void program1VerifyConnectedDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fun_close_all_programs();
            program_1 program_1 = new program_1();
            program_1.MdiParent = this;
            program_1.Show();
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        private void program10TestPowerSupplyDigitalMultimeterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fun_close_all_programs();
            program_10_test_device_test program_10_test_supply_multimeeter = new program_10_test_device_test();
            program_10_test_supply_multimeeter.MdiParent = this;
            program_10_test_supply_multimeeter.Show();
        }
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        private void program20MeasureCapacitiyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fun_close_all_programs();
            program_20_battery_test program_20_battery_test = new program_20_battery_test();
            program_20_battery_test.MdiParent = this;
            program_20_battery_test.Show();
        }
        #endregion
        #region "PROGRAMS "
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        //=======================================================================================================================
        private void fun_close_all_programs()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            //BitArray messageBits1 = new BitArray(10);
            //messageBits1 = functions.func_byte_to_bits(1);
            //abel5.Text = messageBits1[0].ToString();
            //mainWindow.COMportSerial[COMport_SDM220].DiscardInBuffer();
            //modbus_functions.funModbusRTU_send_request_read_function_4(5, 0, 2, COMport_SDM220);
            //modbus_functions.funModbusRTU_send_request_read_function_3(5, 22, 2, COMport_SDM220);
            //fun_close_all_programs();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}

