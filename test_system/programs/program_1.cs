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

        multimeter_XDM3051 multimeter_XDM3051 = new multimeter_XDM3051();
        multimeter_XDM2041 multimeter_XDM2041 = new multimeter_XDM2041();
        multimeter_XDM1041 multimeter_XDM1041 = new multimeter_XDM1041();

        ac_meter_MPM_1010B ac_meter_MPM_1010B = new ac_meter_MPM_1010B();
        temperature_ET3916 temperature_ET3916 = new temperature_ET3916();
        power_supply_KA3305P power_supply_KA3305P = new power_supply_KA3305P();
        power_supply_hcs_3300 power_supply_hcs_3300 = new power_supply_hcs_3300();
        power_supply_RD6006 power_supply_RD6006 = new power_supply_RD6006();

        dc_load_KEL103 dc_load_KEL103 = new dc_load_KEL103();

        modbus_functions modbus_functions = new modbus_functions();
        write_log_files write_log_files = new write_log_files();

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
            //listView_connected.ItemChecked -= listView_connected;
            //var selectedNet = (listView_connected.SelectedIndices.Count > 0 ? listView_connected.SelectedItems[0].Tag as PCanNet : PCanNet.NONE);
            listView_connected.Groups.Clear();
            listView_connected.Items.Clear();

            //listView_connected.Items.Add("AAAA", "BBBB", ".CCCCCC");
            // listView_connected.Items.Add(new ListViewItem(new string[] { "John dsfsfsdfs ", "1", "100" }));
            //listView_connected.Columns.Add("Column1Name");
            //listView_connected.Columns.Add("Column2Name");
            //listView_connected.Columns.Add("Column3Name");



            listView_connected.EndUpdate();


        }

        private void listView_connected_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion
        #region " TIMER "



        private void timer1_Tick(object sender, EventArgs e)
        {

            if (program_counter < 10)
            {

                if (program_counter == 0)
                {
                    multimeter_XDM3051.fun_XDM3051_identifaction();
                    strDevice_name = COMport_name[COMport_SELECT_MULTIMETER_XDM3051];
                    strDevice_port = COMport_port[COMport_SELECT_MULTIMETER_XDM3051];
                    strDevice_ident = COMport_device_ident[COMport_SELECT_MULTIMETER_XDM3051];
                    program_counter++;
                }
                else if (program_counter == 1)
                {
                    multimeter_XDM2041.fun_XDM2041_identifaction();
                    strDevice_name = COMport_name[COMport_SELECT_MULTIMETER_XDM2041];
                    strDevice_port = COMport_port[COMport_SELECT_MULTIMETER_XDM2041];
                    strDevice_ident = COMport_device_ident[COMport_SELECT_MULTIMETER_XDM2041];
                    program_counter++;
                }
                else if (program_counter == 2)
                {
                    multimeter_XDM1041.fun_XDM1041_identifaction();
                    strDevice_name = COMport_name[COMport_SELECT_MULTIMETER_XDM1041];
                    strDevice_port = COMport_port[COMport_SELECT_MULTIMETER_XDM1041];
                    strDevice_ident = COMport_device_ident[COMport_SELECT_MULTIMETER_XDM1041];
                    program_counter++;
                }


/*
        public const byte COMport_SELECT_TEMPERATURE_ET3916 = 4;
        public const byte COMport_SELECT_AC_METER_MPM_1010B = 5;
        public const byte COMport_SELECT_METER_FREE = 6;
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_SELECT_SUPPLY_KA3305A = 7;
        public const byte COMport_SELECT_SUPPLY_HCS_3300 = 8;
        //-----------------------------------------------------------------------------------------------------------------------
        //-- NE SME SE SPREMENITI ZARADI RX INTERRUPT FUNKCIJE 
        public const byte COMport_SELECT_SUPPLY_RD6006 = 9;
        public const byte COMport_SELECT_SUPPLY_RD6024 = 10;
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_SELECT_SUPPLY_FREE = 11;
        //-----------------------------------------------------------------------------------------------------------------------
        public const byte COMport_SELECT_LOAD_KEL103 = 12;
*/

                // listView_connected.Items.Add(new ListViewItem(new string[] { "John dsfsfsdfs ", "1", "100" }));

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
