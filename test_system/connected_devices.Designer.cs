namespace test_system
{
    partial class connected_devices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataTable_conneced_device = new System.Windows.Forms.DataGridView();
            this.tabDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDeviceExist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable_conneced_device)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTable_conneced_device
            // 
            this.dataTable_conneced_device.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataTable_conneced_device.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataTable_conneced_device.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable_conneced_device.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tabDeviceName,
            this.tabDeviceExist});
            this.dataTable_conneced_device.Location = new System.Drawing.Point(12, 12);
            this.dataTable_conneced_device.Name = "dataTable_conneced_device";
            this.dataTable_conneced_device.RowHeadersVisible = false;
            this.dataTable_conneced_device.Size = new System.Drawing.Size(788, 290);
            this.dataTable_conneced_device.TabIndex = 0;
            this.dataTable_conneced_device.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTable_conneced_device_CellContentClick);
            // 
            // tabDeviceName
            // 
            this.tabDeviceName.HeaderText = "Device Name";
            this.tabDeviceName.Name = "tabDeviceName";
            this.tabDeviceName.Width = 500;
            // 
            // tabDeviceExist
            // 
            this.tabDeviceExist.HeaderText = "Device Exist";
            this.tabDeviceExist.Name = "tabDeviceExist";
            this.tabDeviceExist.Width = 200;
            // 
            // connected_devices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 432);
            this.Controls.Add(this.dataTable_conneced_device);
            this.Name = "connected_devices";
            this.Text = "connected_devices";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.connected_devices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable_conneced_device)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataTable_conneced_device;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabDeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabDeviceExist;
    }
}