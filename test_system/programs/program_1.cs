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
using static test_system.global_variable;


namespace test_system
{
    public partial class program_1 : Form
    {

  
        ac_meter_MPM_1010B ac_meter_MPM_1010B = new ac_meter_MPM_1010B();
        temperature_ET3916 temperature_ET3916 = new temperature_ET3916();
        power_supply_KA3305P power_supply_KA3305P = new power_supply_KA3305P();
        power_supply_hcs_3300 power_supply_hcs_3300 = new power_supply_hcs_3300();
        power_supply_RD6006 power_supply_RD6006 = new power_supply_RD6006();

        dc_load_KEL103 dc_load_KEL103 = new dc_load_KEL103();

        modbus_functions modbus_functions = new modbus_functions();
        write_log_files write_log_files = new write_log_files();
        owon_multimeter owon_multimeter = new owon_multimeter();

        int program_counter;

        string strDevice_name = "";
        string strDevice_port = "";
        string strDevice_ident = "";




        #region "window load "

        public program_1()
        {
            InitializeComponent();
        }

        private void program_1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(intMainWindow_x_MDI_window, intMainWindow_y_MDI_window);

            this.ControlBox = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(intMDIwindow_x_size, intMDIwindow_y_size);

            labName.Text = "Find all connected devices, test measured";
            listView_connected.BeginUpdate();
            listView_connected.Groups.Clear();
            listView_connected.Items.Clear();

            listView_connected.EndUpdate();

        }

        private void listView_connected_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion
        #region " TIMER "

        private void fun_increase_device_counter(int select_device)
        {
            try
            {
                if (COMport_device_ident[select_device] != null)
                {
                    if (COMport_device_ident[select_device].Length > 2)
                    {
                        program_counter++;
                    }
                }
            }
            catch { }
        }

        private void fun_set_one_device(int select_device)
        {
            strDevice_name = COMport_name[select_device];
            strDevice_port = COMport_port[select_device];
            strDevice_ident = COMport_device_ident[select_device];
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            labProgramCounter.Text = "Current test   " + program_counter.ToString();

            if (program_counter < 15)
            {
                if (program_counter == 0)
                {
                    if (dev_connected[COMport_XDM3051])
                    {
                        //multimeter_XDM3051.fun_XDM3051_identifaction();
                        owon_multimeter.fun_owon_multimeter_identification(COMport_XDM3051, "XDM3051,2303195");

                        fun_set_one_device(COMport_XDM3051);
                        fun_increase_device_counter(COMport_XDM3051);
                    }
                    else program_counter++;
                }
                else if (program_counter == 1)
                {
                    if (dev_connected[COMport_XDM2041])
                    {
                        //multimeter_XDM2041.fun_XDM2041_identifaction();
                        owon_multimeter.fun_owon_multimeter_identification(COMport_XDM2041, "XDM2041,24470254");
                        fun_set_one_device(COMport_XDM2041);
                        fun_increase_device_counter(COMport_XDM2041);
                    }
                    else program_counter++;
                }
                else if (program_counter == 2)
                {
                    if (dev_connected[COMport_XDM1041])
                    {
                        //multimeter_XDM1041.fun_XDM1041_identifaction();
                        if (owon_multimeter.fun_owon_multimeter_identification(COMport_XDM1041, "XDM1041,23120418") != funReturnCodeCOMport.OK)
                        {
                            if (owon_multimeter.fun_owon_multimeter_identification(COMport_XDM1041, "XDM1041,23120418") != funReturnCodeCOMport.OK)
                            {
                                owon_multimeter.fun_owon_multimeter_identification(COMport_XDM1041, "XDM1041,23120418");
                            }
                        }



                        fun_set_one_device(COMport_XDM1041);
                        fun_increase_device_counter(COMport_XDM1041);
                    }
                    else program_counter++;
                }
                //---------------------------------------------------------------------------------------------------------------
                //-- NE DELUJE 
                else if (program_counter == 3)
                {
                    if (dev_connected[COMport_MPM_1010B])
                    {
                        device_MPM1010B_read_all_write = true;
                        device_MPM1010B_read_all_read = true;
                    }
                    program_counter++;
                }
                else if (program_counter == 4)
                {
                    if (dev_connected[COMport_MPM_1010B])
                    {
                        program_counter++;
                    }
                    else program_counter++;
                }
                //---------------------------------------------------------------------------------------------------------------
                else if (program_counter == 5)
                {
                    if (dev_connected[COMport_ET3916])
                    {
                        temperature_ET3916.fun_ET3916_read_serial_number();
                    }
                    program_counter++;
                }
                else if (program_counter == 6)
                {
                    if (dev_connected[COMport_ET3916])
                    {



                        /*
                        if (COMport_device_ident[COMport_SELECT_TEMPERATURE_ET3916].Length > 5)
                        {
                            fun_set_one_device(COMport_SELECT_TEMPERATURE_ET3916);
                        }
                        else
                        {
                            program_counter = 5;
                        }
                        */
                        program_counter++;

                    }
                    else program_counter++;
                }

                else if (program_counter == 7)
                {
                    if (dev_connected[COMport_KA3305A])
                    {
                        power_supply_KA3305P.fun_KA3305P_identifaction();
                        fun_set_one_device(COMport_KA3305A);
                        fun_increase_device_counter(COMport_KA3305A);

                    }
                    else program_counter++;
                }
                //---------------------------------------------------------------------------------------------------------------
                //     public const byte COMport_SELECT_SUPPLY_HCS_3300 = 8;
                else if (program_counter == 8)
                {
                    if (dev_connected[COMport_HCS_3300])
                    {
                        power_supply_hcs_3300.fun_HCS_330_identifaction();
                        fun_set_one_device(COMport_HCS_3300);
                        fun_increase_device_counter(COMport_HCS_3300);
                    }
                    else program_counter++;
                }
                //---------------------------------------------------------------------------------------------------------------
                //-- public const byte COMport_SELECT_LOAD_KEL103 = 12;
                else if (program_counter == 9)
                {
                    if (dev_connected[COMport_KEL103])
                    {
                        dc_load_KEL103.fun_KEL103_identifaction();
                        fun_set_one_device(COMport_KEL103);
                        fun_increase_device_counter(COMport_KEL103);

                    }
                    else program_counter++;
                }
                else if (program_counter == 10)
                {
                    this.Close();
                }

                if (strDevice_name.Length > 4)
                {
                    listView_connected.Items.Add(new ListViewItem(new string[] { strDevice_name, strDevice_port, strDevice_ident }));
                    listView_connected.EndUpdate();
                    strDevice_name = "";
                }

                // if (program_counter > 6) listView_connected.Items[5].BackColor = Color.Yellow;


            }




        }
        #endregion




    }
}
