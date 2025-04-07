using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static test_system.global_variable;
using static test_system.program_20;
using static test_system.program_20_batery_USB_pack;

namespace test_system
{
    public partial class program_20_battery_test : Form
    {

        public static System.Windows.Forms.Label[] write_label = new System.Windows.Forms.Label[20];

        program_20_batery_USB_pack program_20_batery_pack = new program_20_batery_USB_pack();

        #region "window load"

        //=======================================================================================================================
        //=======================================================================================================================
        public program_20_battery_test()
        {
            InitializeComponent();
        }
        //=======================================================================================================================
        //=======================================================================================================================

        private void program_20_battery_test_Load(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------------------------------
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(intMainWindow_x_MDI_window, intMainWindow_y_MDI_window);
            this.ControlBox = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(intMDIwindow_x_size, intMDIwindow_y_size);
            //-------------------------------------------------------------------------------------------------------------------
            //-- labele za izpis iz drugih clasov
            write_label[PROG20_LABEL_STATUS] = labCurrentState;
            write_label[PROG20_LABEL_1] = labResult_01;
            write_label[PROG20_LABEL_2] = labResult_02;
            write_label[PROG20_LABEL_3] = labResult_03;
            //-------------------------------------------------------------------------------------------------------------------
            program20_name_current = program20_01;
            fun_select_program_log_file_name(program20_name_current);
            //-------------------------------------------------------------------------------------------------------------------
            write_label[PROG20_LABEL_STATUS].Text = "";
            labResult_01.Text = "";
            labResult_02.Text = "";
            labResult_03.Text = "";

            radioButton_discharge.Checked = true;

        }

        #endregion
        #region "SELECT TEST --- izbira programa "


        //=======================================================================================================================
        //=======================================================================================================================

        public void fun_select_program_log_file_name(string select_program)
        {
            program_select = 0;

            //--    public const string program20_01 = "USB battery pack";
            if (select_program.Equals(program20_01, StringComparison.Ordinal))
            {
                program_select = program20_USB_PACK;
            }

            //-------------------------------------------------------------------------------------------------------------------   
            //-- ime log datoteke   
            //string[] comboBoxParts = program10_current_selected_program.Split(':');
            //if (radioButton_charge.Checked) strLogFiles_program = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_20_" + select_program + "_charge_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
            //if (radioButton_discharge.Checked) strLogFiles_program = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\" + "program_20_" + select_program + "_discharge_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
        }



        #endregion
        #region "TIMER -- časovno izvajanje programa "
        //=======================================================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //=======================================================================================================================
        private void timer1_Tick(object sender, EventArgs e)
        {

            //label1.Text =" STATE   " + program_state.ToString()+ "    "+ floatDuration_part_program_run.ToString()+"    " + intDischarge_start_wait_time_set.ToString();    

            /*
            if (blnChangeWindow_program_20_USB_battery_pack_labCurrentState)
            {
                blnChangeWindow_program_20_USB_battery_pack_labCurrentState = false;
                labCurrentState.Text = USB_battery_pack_labCurrentState;
            }
            */
            /*
            if (blnChangeWindow_program_20_USB_battery_pack_measure_label)
            {
                blnChangeWindow_program_20_USB_battery_pack_measure_label = false;
                labResult_01.Text = USB_battery_pack_measure_label_1;
                labResult_02.Text = USB_battery_pack_measure_label_2;
                labResult_03.Text = USB_battery_pack_measure_label_3;
            }
            */

            if (program_select == program20_USB_PACK) program_20_batery_pack.fun_program20_01_usb_pack();

        }

        #endregion


 
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton_charge.Checked) 
            {
                blnCharge = true;
                program_state = PRG20_USB_PACK_CHARGE_INIT;
             }
            if (radioButton_discharge.Checked)
            {
                blnDischarge = true;
                program_state = PRG20_USB_PACK_DISCHARGE_INIT;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (radioButton_charge.Checked) program_state = PRG20_USB_PACK_CHARGE_STOP;
            if (radioButton_discharge.Checked) program_state = PRG20_USB_PACK_DISCHARGE_STOP;   
        }





    }
}


