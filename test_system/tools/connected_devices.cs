﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static test_system.global_variable;

namespace test_system
{
    public partial class connected_devices : Form
    {
        public connected_devices()
        {
            InitializeComponent();
        }

        private void connected_devices_Load(object sender, EventArgs e)
        {
            dataTable_conneced_device.Rows.Clear();
            dataTable_conneced_device.ClearSelection();
            if (COMport_port[COMport_MPM_1010B] != null)
            {
                if (COMport_port[COMport_MPM_1010B].Length > 0)
                {
                    dataTable_conneced_device.Rows.Add("MATRIX  AC METER MPM-101B ", dev_connected[COMport_MPM_1010B].ToString());
                }
            }
            if (COMport_port[COMport_ET3916] != null)
            {
                if (COMport_port[COMport_ET3916].Length > 0)
                {
                    dataTable_conneced_device.Rows.Add("East Tester Temperature meter ET3916-8 ", dev_connected[COMport_ET3916].ToString());
                }
            }






            dataTable_conneced_device.ClearSelection();


        }




        private void dataTable_conneced_device_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

    }
}
