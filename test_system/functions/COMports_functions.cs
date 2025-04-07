using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static test_system.global_variable;

namespace test_system
{
    class COMports_functions
    {
        modbus modbus_functions = new modbus();
        power_supply_RD6006 power_supply_RD6006 = new power_supply_RD6006();
        power_supply_RD6024 power_supply_RD6024 = new power_supply_RD6024();
        AC_meter_SDM220 AC_meter_SDM220 = new AC_meter_SDM220();

        #region "COMports  "
        //=======================================================================================================================
        /// <summary>
        ///     incializacija COM portov
        ///     določitev interrupt funkcij za določene COM porte
        /// </summary>
        //=======================================================================================================================
        public void fun_mainWindow_load_init_COMports()
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
                //-- RD 6006, RD 6024, SDM 220 -- MODBUS komunikacija 
                mainWindow.COMportSerial[COMport_RD6006].DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(COM_PORT_RD6006_DataReceived);
                mainWindow.COMportSerial[COMport_RD6024].DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(COM_PORT_RD6024_DataReceived);
                mainWindow.COMportSerial[COMport_SDM220].DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(COM_PORT_SDM220_DataReceived);
                mainWindow.COMportSerial[COMport_RD6006].ReceivedBytesThreshold = 100;
                mainWindow.COMportSerial[COMport_RD6024].ReceivedBytesThreshold = 100;
                mainWindow.COMportSerial[COMport_SDM220].ReceivedBytesThreshold = 100;
            }
            catch { }
        }
        #endregion

        #region "Prikaz COM portov  in priključenih instrumentov   "
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedCOMport"></param>
        //=======================================================================================================================
        private void fun_show_one_device(int selectedCOMport)
        {
            try
            {
               mainWindow.device[selectedCOMport].Visible = false;
                if (dev_connected[selectedCOMport]) { mainWindow.device[selectedCOMport].Visible = true; }
                if (dev_active[selectedCOMport]) { mainWindow.device[selectedCOMport].ForeColor = Color.Green; } else mainWindow.device[selectedCOMport].ForeColor = Color.Black;
            }
            catch { }
        }

        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        //=======================================================================================================================
        public void fun_show_connected_device()
        {
            try
            {
                fun_show_one_device(COMport_XDM3051);
                fun_show_one_device(COMport_XDM2041);
                fun_show_one_device(COMport_XDM1041);
                fun_show_one_device(COMport_ET3916);
                fun_show_one_device(COMport_MPM_1010B);
                fun_show_one_device(COMport_KA3305A);
                fun_show_one_device(COMport_HCS_3300);
                fun_show_one_device(COMport_RD6006);
                fun_show_one_device(COMport_RD6024);
                fun_show_one_device(COMport_KEL103);
                fun_show_one_device(COMport_SDM220);
            }
            catch { }
        }
        #endregion
        //=======================================================================================================================
        /// <summary>
        ///     odpre se ne COM port in se določi ime COM porta
        /// </summary>
        /// <param name="select_port"></param>
        /// <returns></returns>
        //=======================================================================================================================
        public funReturnCode fun_select_COMport_open(byte select_port)
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
            //-------------------------------------------------------------------------------------------------------------------
            dev_connected[select_port] = false;
            dev_meas_state[select_port] = funReturnCode.NOT_MEASURE;
            //-------------------------------------------------------------------------------------------------------------------    
            if (COMport_port[select_port] != null)
            {
                if (COMport_port[select_port].Length > 0)
                {
                    try
                    {
                        //-----------------------------------------------------------------------------
                        //-- COM port in baudrate iz ini datoteke 
                        mainWindow.COMportSerial[select_port].PortName = COMport_port[select_port];
                        mainWindow.COMportSerial[select_port].BaudRate = (int)COMport_baudRate[select_port];
                        mainWindow.COMportSerial[select_port].DataBits = 8;
                        mainWindow.COMportSerial[select_port].Parity = Parity.None;
                        mainWindow.COMportSerial[select_port].StopBits = StopBits.One;
                        mainWindow.COMportSerial[select_port].ReadTimeout = 100;
                        mainWindow.COMportSerial[select_port].Open();
                        dev_connected[select_port] = true;
                        return funReturnCode.OK;
                    }
                    catch { return funReturnCode.ERROR; }
                }
                else { return funReturnCode.ERROR; }
            }
            else { return funReturnCode.ERROR; }
        }
        #region "COM port RD6006
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        public void COM_PORT_RD6006_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            //if (dev_active[COMport_RD6006]) { mainWindow.device[COMport_RD6006].ForeColor = Color.Green; } else mainWindow.device[COMport_RD6006].ForeColor = Color.Black;

            //byte receiveByteLocal;
            byte[] receiveByte_modbus_local = new byte[100];
            int loc_loop;
            try
            {
                receiveByte_modbus_lenght[COMport_RD6006] = (byte)mainWindow.COMportSerial[COMport_RD6006].BytesToRead;
                // strGeneralString = "RD6006   "+ receiveByte_modbus_lenght.ToString();
                if (receiveByte_modbus_lenght[COMport_RD6006] > 0)
                {
                    //bCOMport_recLen[COMport_SELECT_SUPPLY_RD6006] = receiveByteLocal;
                    //COMportSerial[COMport_RD6006].Read(receiveByte_modbus, 0, receiveByte_modbus_lenght);
                    mainWindow.COMportSerial[COMport_RD6006].Read(receiveByte_modbus_local, 0, receiveByte_modbus_lenght[COMport_RD6006]);
                    for (loc_loop = 0; loc_loop < receiveByte_modbus_lenght[COMport_RD6006]; loc_loop++) { receiveByte_modbus[COMport_RD6006, loc_loop] = receiveByte_modbus_local[loc_loop]; }
                    modbus_functions.funModbusRTU_receive_mesasage(COMport_RD6006);
                    //-----------------------------------------------------------------------------------------------------------
                    if (modbus_start_register_send == 0)
                    {
                        if (modbus_register_number_send == 4)
                        {
                            if (modbus_register_type_receive == 3)
                            {
                                power_supply_RD6006.funModbusRTU_RD6006_receive_ident();
                            }
                        }
                    }
                    //-----------------------------------------------------------------------------------------------------------
                    if (modbus_start_register_send == 8)
                    {
                        if (modbus_register_number_send == 10)
                        {
                            if (modbus_register_type_receive == 3)
                            {
                                power_supply_RD6006.funModbusRTU_receive_mesasage_RD6006();
                            }
                        }
                    }
                    //-----------------------------------------------------------------------------------------------------------
                    strGeneralString = "RD602  " + receiveByte_modbus_lenght.ToString() + "   start " + modbus_start_register_send.ToString() + "    Reg " + modbus_register_number_send.ToString() + "   Type " + modbus_register_type_receive.ToString();
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
        public void COM_PORT_RD6024_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            byte[] receiveByte_modbus_local = new byte[100];
            int loc_loop;
            try
            {

                receiveByte_modbus_lenght[COMport_RD6024] = (byte)mainWindow.COMportSerial[COMport_RD6024].BytesToRead;
                strGeneralString = "RD6024   " + receiveByte_modbus_lenght.ToString();
                if (receiveByte_modbus_lenght[COMport_RD6024] > 0)
                {
                    //bCOMport_recLen[selectCOMporLocal] = receiveByteLocal;
                    //mainWindow.COMportSerial[COMport_SELECT_SUPPLY_RD6024].Read(receiveByte_modbus, 0, receiveByteLocal);
                    //COMportSerial[COMport_RD6024].Read(receiveByte_modbus, 0, receiveByte_modbus_lenght);
                    mainWindow.COMportSerial[COMport_RD6024].Read(receiveByte_modbus_local, 0, receiveByte_modbus_lenght[COMport_RD6024]);
                    for (loc_loop = 0; loc_loop < receiveByte_modbus_lenght[COMport_RD6024]; loc_loop++) { receiveByte_modbus[COMport_RD6024, loc_loop] = receiveByte_modbus_local[loc_loop]; }
                    modbus_functions.funModbusRTU_receive_mesasage(COMport_RD6024);
                    //-----------------------------------------------------------------------------------------------------------
                    if (modbus_start_register_send == 0)
                    {
                        if (modbus_register_number_send == 4)
                        {
                            if (modbus_register_type_receive == 3)
                            {
                                power_supply_RD6024.funModbusRTU_RD6024_receive_ident();
                            }
                        }
                    }
                    //-----------------------------------------------------------------------------------------------------------
                    if (modbus_register_type_receive == 3)
                    {
                        if (modbus_register_number_send == 2)
                        {
                            if (modbus_start_register_send == 10)
                            {
                                rd6024_OutputVoltag = ((float)(modbus_register[0])) / 100;
                                modbus_functions.funModbusRTU_send_request_read_function_3(1, 12, 2, COMport_RD6024);
                                //power_supply_RD6024.funModbusRTU_receive_mesasage_RD6024();
                            }
                            else if (modbus_start_register_send == 12)
                            {
                                rd6024_OutputCurrent = ((float)(modbus_register[0])) / 100;
                                modbus_functions.funModbusRTU_send_request_read_function_3(1, 14, 2, COMport_RD6024);
                                device_RD6024_show_all_measure = true;
                                //power_supply_RD6024.funModbusRTU_receive_mesasage_RD6024();
                            }
                        }
                    }
                    strGeneralString = "RD6024   " + receiveByte_modbus_lenght.ToString() + "   start " + modbus_start_register_send.ToString() + "    Reg " + modbus_register_number_send.ToString() + "   Type " + modbus_register_type_receive.ToString();
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
        public void COM_PORT_SDM220_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] receiveByte_modbus_local = new byte[100];
            int loc_loop;
            try
            {
                receiveByte_modbus_lenght[COMport_SDM220] = (byte)mainWindow.COMportSerial[COMport_SDM220].BytesToRead;
                if (receiveByte_modbus_lenght[COMport_SDM220] > 0)
                {
                    mainWindow.COMportSerial[COMport_SDM220].Read(receiveByte_modbus_local, 0, receiveByte_modbus_lenght[COMport_SDM220]);
                    for (loc_loop = 0; loc_loop < receiveByte_modbus_lenght[COMport_SDM220]; loc_loop++) { receiveByte_modbus[COMport_SDM220, loc_loop] = receiveByte_modbus_local[loc_loop]; }
                    modbus_functions.funModbusRTU_receive_mesasage(COMport_SDM220);

                    if (modbus_address_receive == 5)
                    {
                        if (modbus_register_type_receive == 4)
                        {
                            if (modbus_register_number_send == 2)
                            {
                                AC_meter_SDM220.funModbusRTU_SDM220_receive_one_data();
                            }
                        }
                    }
                }
            }
            catch { }
        }
        #endregion

    }
}
