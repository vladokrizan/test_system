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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static test_system.global_variable;
using static test_system.program_10;



namespace test_system
{
    public partial class program_10_test_supply_multimeter: Form
    {
        public program_10_test_supply_multimeter()
        {
            InitializeComponent();
        }

        #region "window load "

        //=======================================================================================================================
        //=======================================================================================================================
        private void program_10_test_supply_multimeeter_Load(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------------------------------
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(intMainWindow_x_MDI_window, intMainWindow_y_MDI_window);
            this.ControlBox = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(intMDIwindow_x_size, intMDIwindow_y_size);
            //-------------------------------------------------------------------------------------------------------------------


            comboBox_select_program.Items.Add(program10_01);
            comboBox_select_program.Items.Add(program10_02);
            comboBox_select_program.Items.Add(program10_03);
            comboBox_select_program.Items.Add(program10_04);
            comboBox_select_program.Items.Add(program10_05);
            comboBox_select_program.Items.Add(program10_06);

            //-------------------------------------------------------------------------------------------------------------------
            //-- prikaz prve izbire v comboBoxu 
            int comboNumber = comboBox_select_program.Items.Count;
            //comboBox_select_program.SelectedIndex = comboBox_select_program.Items.Count - comboNumber;
            comboBox_select_program.SelectedIndex = 0;

            fun_set_log_file_name();

        }




        #endregion
        //=======================================================================================================================
        //=======================================================================================================================

        private void button1_Click(object sender, EventArgs e)
        {
            double voltage_XDM3051 = 10.51241;
            double voltage_supply_set = 10.5;

            program10_value.Clear();


            program10_value.Add("SUPPLY KA3305P part 1 SET (V) ", voltage_supply_set.ToString("0.000"));
            program10_value.Add("SUPPLY KA3305P part 1 GET (V) ", "10,1");
            program10_value.Add("Multimeter XDM3051 (V) ", voltage_XDM3051.ToString("0.000"));
            program10_value.Add("Multimeter XDM2041 (V) ", "10,11");
            //program10_value.Add("Multimeter XDM1041 (V) ", "10,12");

            program10_value["Multimeter XDM1041 (V)"] = "100,5555";




            funWriteLogFile_program10();

        }

        #region "TIMER  .. izvajanje programa  "


        private void timer1_Tick(object sender, EventArgs e)
        {
            labCurrentProgram.Text = program10_current_selected_program;
        }

        #endregion

        #region "izbira programa  "

        //=======================================================================================================================
        //=======================================================================================================================

        private void comboBox_select_program_SelectedIndexChanged(object sender, EventArgs e)
        {
            fun_set_log_file_name();
        }

        private void comboBox_select_program_Click(object sender, EventArgs e)
        {
     
        }
        #endregion


        #region "zapis v log datoteko "

        //=======================================================================================================================
        //=======================================================================================================================
        private void fun_set_log_file_name ()
        {
            program10_current_selected_program = comboBox_select_program.Text;
             string[] comboBoxParts = program10_current_selected_program.Split(':');
             strLogFiles_program10 = System.Environment.CurrentDirectory + "\\" + strSubFolderLog + ".\\"  + "program_10_"+ comboBoxParts[0] +  "_delay_" + program10_delay_after_set_supply.ToString() +"_"+ DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") +".csv";

        }


        //=======================================================================================================================
        //=======================================================================================================================
        public void funWriteLogFile_program10()
        {
            string fileDataLine = "";
            try
            {
                //------   if file exist then don't write anything 
                if (!File.Exists(strLogFiles_program10))
                {
                    using (StreamWriter sw = File.AppendText(strLogFiles_program10))
                    {
                        fileDataLine = "Date" + strExcelSeparator;
                        fileDataLine = fileDataLine + "Time" + strExcelSeparator;
                        foreach (KeyValuePair<string, string> diagnosisNameLocal in program10_value)
                            fileDataLine = fileDataLine + diagnosisNameLocal.Key + strExcelSeparator;
                        sw.WriteLine(fileDataLine);
                    }
                }
                using (StreamWriter sw = File.AppendText(strLogFiles_program10))
                {
                    fileDataLine = DateTime.Now.ToString("dd.MM.yyyy") + strExcelSeparator;
                    fileDataLine = fileDataLine + DateTime.Now.ToString("HH:mm:ss") + strExcelSeparator;
                    foreach (KeyValuePair<string, string> diagnosisValueLocal in program10_value)
                        fileDataLine = fileDataLine + diagnosisValueLocal.Value + strExcelSeparator;
                    sw.WriteLine(fileDataLine);
                }
             }
            catch (Exception ex) {  }
        }





        #endregion


    }
}
