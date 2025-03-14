namespace test_system
{
    partial class mainWindow
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button8 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox_connected_device = new System.Windows.Forms.GroupBox();
            this.labDevice_KEL103 = new System.Windows.Forms.Label();
            this.labDevice_supply_free = new System.Windows.Forms.Label();
            this.labDevice_RD6024 = new System.Windows.Forms.Label();
            this.labDevice_RD6006 = new System.Windows.Forms.Label();
            this.labDevice_HCS_330 = new System.Windows.Forms.Label();
            this.labDevice_KA3305P = new System.Windows.Forms.Label();
            this.labDevice_multimeter_free = new System.Windows.Forms.Label();
            this.labDevice_MPM1010B = new System.Windows.Forms.Label();
            this.labDevice_ET3916 = new System.Windows.Forms.Label();
            this.labDevice_XDM1041 = new System.Windows.Forms.Label();
            this.labDevice_XDM2041 = new System.Windows.Forms.Label();
            this.labDevice_XDM3051 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.program1VerifyConnectedDevicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.program10TestPowerSupplyDigitalMultimeterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.program20MeasureCapacitiyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox_connected_device.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 84);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Identification";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(16, 376);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(16, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(6, 121);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(130, 30);
            this.button8.TabIndex = 10;
            this.button8.Text = "System";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(12, 427);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(818, 31);
            this.textBox1.TabIndex = 16;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(6, 157);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(130, 30);
            this.button13.TabIndex = 17;
            this.button13.Text = "All Devices";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 668);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1357, 24);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(198, 19);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // groupBox_connected_device
            // 
            this.groupBox_connected_device.Controls.Add(this.labDevice_KEL103);
            this.groupBox_connected_device.Controls.Add(this.labDevice_supply_free);
            this.groupBox_connected_device.Controls.Add(this.labDevice_RD6024);
            this.groupBox_connected_device.Controls.Add(this.labDevice_RD6006);
            this.groupBox_connected_device.Controls.Add(this.labDevice_HCS_330);
            this.groupBox_connected_device.Controls.Add(this.labDevice_KA3305P);
            this.groupBox_connected_device.Controls.Add(this.labDevice_multimeter_free);
            this.groupBox_connected_device.Controls.Add(this.labDevice_MPM1010B);
            this.groupBox_connected_device.Controls.Add(this.labDevice_ET3916);
            this.groupBox_connected_device.Controls.Add(this.labDevice_XDM1041);
            this.groupBox_connected_device.Controls.Add(this.labDevice_XDM2041);
            this.groupBox_connected_device.Controls.Add(this.labDevice_XDM3051);
            this.groupBox_connected_device.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox_connected_device.Location = new System.Drawing.Point(1242, 30);
            this.groupBox_connected_device.Name = "groupBox_connected_device";
            this.groupBox_connected_device.Size = new System.Drawing.Size(115, 638);
            this.groupBox_connected_device.TabIndex = 21;
            this.groupBox_connected_device.TabStop = false;
            // 
            // labDevice_KEL103
            // 
            this.labDevice_KEL103.AutoSize = true;
            this.labDevice_KEL103.Location = new System.Drawing.Point(16, 341);
            this.labDevice_KEL103.Name = "labDevice_KEL103";
            this.labDevice_KEL103.Size = new System.Drawing.Size(60, 20);
            this.labDevice_KEL103.TabIndex = 0;
            this.labDevice_KEL103.Text = "label14";
            // 
            // labDevice_supply_free
            // 
            this.labDevice_supply_free.AutoSize = true;
            this.labDevice_supply_free.Location = new System.Drawing.Point(16, 307);
            this.labDevice_supply_free.Name = "labDevice_supply_free";
            this.labDevice_supply_free.Size = new System.Drawing.Size(60, 20);
            this.labDevice_supply_free.TabIndex = 0;
            this.labDevice_supply_free.Text = "label14";
            // 
            // labDevice_RD6024
            // 
            this.labDevice_RD6024.AutoSize = true;
            this.labDevice_RD6024.Location = new System.Drawing.Point(16, 284);
            this.labDevice_RD6024.Name = "labDevice_RD6024";
            this.labDevice_RD6024.Size = new System.Drawing.Size(60, 20);
            this.labDevice_RD6024.TabIndex = 0;
            this.labDevice_RD6024.Text = "label14";
            // 
            // labDevice_RD6006
            // 
            this.labDevice_RD6006.AutoSize = true;
            this.labDevice_RD6006.Location = new System.Drawing.Point(16, 261);
            this.labDevice_RD6006.Name = "labDevice_RD6006";
            this.labDevice_RD6006.Size = new System.Drawing.Size(60, 20);
            this.labDevice_RD6006.TabIndex = 0;
            this.labDevice_RD6006.Text = "label14";
            // 
            // labDevice_HCS_330
            // 
            this.labDevice_HCS_330.AutoSize = true;
            this.labDevice_HCS_330.Location = new System.Drawing.Point(16, 237);
            this.labDevice_HCS_330.Name = "labDevice_HCS_330";
            this.labDevice_HCS_330.Size = new System.Drawing.Size(60, 20);
            this.labDevice_HCS_330.TabIndex = 0;
            this.labDevice_HCS_330.Text = "label14";
            // 
            // labDevice_KA3305P
            // 
            this.labDevice_KA3305P.AutoSize = true;
            this.labDevice_KA3305P.Location = new System.Drawing.Point(16, 213);
            this.labDevice_KA3305P.Name = "labDevice_KA3305P";
            this.labDevice_KA3305P.Size = new System.Drawing.Size(60, 20);
            this.labDevice_KA3305P.TabIndex = 0;
            this.labDevice_KA3305P.Text = "label14";
            // 
            // labDevice_multimeter_free
            // 
            this.labDevice_multimeter_free.AutoSize = true;
            this.labDevice_multimeter_free.Location = new System.Drawing.Point(16, 166);
            this.labDevice_multimeter_free.Name = "labDevice_multimeter_free";
            this.labDevice_multimeter_free.Size = new System.Drawing.Size(60, 20);
            this.labDevice_multimeter_free.TabIndex = 0;
            this.labDevice_multimeter_free.Text = "label14";
            // 
            // labDevice_MPM1010B
            // 
            this.labDevice_MPM1010B.AutoSize = true;
            this.labDevice_MPM1010B.Location = new System.Drawing.Point(16, 137);
            this.labDevice_MPM1010B.Name = "labDevice_MPM1010B";
            this.labDevice_MPM1010B.Size = new System.Drawing.Size(60, 20);
            this.labDevice_MPM1010B.TabIndex = 0;
            this.labDevice_MPM1010B.Text = "label14";
            // 
            // labDevice_ET3916
            // 
            this.labDevice_ET3916.AutoSize = true;
            this.labDevice_ET3916.Location = new System.Drawing.Point(16, 113);
            this.labDevice_ET3916.Name = "labDevice_ET3916";
            this.labDevice_ET3916.Size = new System.Drawing.Size(60, 20);
            this.labDevice_ET3916.TabIndex = 0;
            this.labDevice_ET3916.Text = "label14";
            // 
            // labDevice_XDM1041
            // 
            this.labDevice_XDM1041.AutoSize = true;
            this.labDevice_XDM1041.Location = new System.Drawing.Point(16, 84);
            this.labDevice_XDM1041.Name = "labDevice_XDM1041";
            this.labDevice_XDM1041.Size = new System.Drawing.Size(60, 20);
            this.labDevice_XDM1041.TabIndex = 0;
            this.labDevice_XDM1041.Text = "label14";
            // 
            // labDevice_XDM2041
            // 
            this.labDevice_XDM2041.AutoSize = true;
            this.labDevice_XDM2041.Location = new System.Drawing.Point(16, 54);
            this.labDevice_XDM2041.Name = "labDevice_XDM2041";
            this.labDevice_XDM2041.Size = new System.Drawing.Size(60, 20);
            this.labDevice_XDM2041.TabIndex = 0;
            this.labDevice_XDM2041.Text = "label14";
            // 
            // labDevice_XDM3051
            // 
            this.labDevice_XDM3051.AutoSize = true;
            this.labDevice_XDM3051.Location = new System.Drawing.Point(16, 26);
            this.labDevice_XDM3051.Name = "labDevice_XDM3051";
            this.labDevice_XDM3051.Size = new System.Drawing.Size(60, 20);
            this.labDevice_XDM3051.TabIndex = 0;
            this.labDevice_XDM3051.Text = "label14";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.programToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1357, 30);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(62, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.program1VerifyConnectedDevicesToolStripMenuItem,
            this.program10TestPowerSupplyDigitalMultimeterToolStripMenuItem,
            this.program20MeasureCapacitiyToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(102, 26);
            this.programToolStripMenuItem.Text = "Program ";
            // 
            // program1VerifyConnectedDevicesToolStripMenuItem
            // 
            this.program1VerifyConnectedDevicesToolStripMenuItem.Name = "program1VerifyConnectedDevicesToolStripMenuItem";
            this.program1VerifyConnectedDevicesToolStripMenuItem.Size = new System.Drawing.Size(610, 26);
            this.program1VerifyConnectedDevicesToolStripMenuItem.Text = "Program 1 - verify connected devices";
            this.program1VerifyConnectedDevicesToolStripMenuItem.Click += new System.EventHandler(this.program1VerifyConnectedDevicesToolStripMenuItem_Click);
            // 
            // program10TestPowerSupplyDigitalMultimeterToolStripMenuItem
            // 
            this.program10TestPowerSupplyDigitalMultimeterToolStripMenuItem.Name = "program10TestPowerSupplyDigitalMultimeterToolStripMenuItem";
            this.program10TestPowerSupplyDigitalMultimeterToolStripMenuItem.Size = new System.Drawing.Size(610, 26);
            this.program10TestPowerSupplyDigitalMultimeterToolStripMenuItem.Text = "Program 10 - test power supply and digital multimeter";
            this.program10TestPowerSupplyDigitalMultimeterToolStripMenuItem.Click += new System.EventHandler(this.program10TestPowerSupplyDigitalMultimeterToolStripMenuItem_Click);
            // 
            // program20MeasureCapacitiyToolStripMenuItem
            // 
            this.program20MeasureCapacitiyToolStripMenuItem.Name = "program20MeasureCapacitiyToolStripMenuItem";
            this.program20MeasureCapacitiyToolStripMenuItem.Size = new System.Drawing.Size(610, 26);
            this.program20MeasureCapacitiyToolStripMenuItem.Text = "Program 20 - measure capacitiy";
            this.program20MeasureCapacitiyToolStripMenuItem.Click += new System.EventHandler(this.program20MeasureCapacitiyToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(62, 26);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 477);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "label3";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 238);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 34);
            this.button2.TabIndex = 26;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(7, 48);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 30);
            this.btnExit.TabIndex = 27;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 692);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox_connected_device);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "mainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.Move += new System.EventHandler(this.mainWindow_Move);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox_connected_device.ResumeLayout(false);
            this.groupBox_connected_device.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox_connected_device;
        private System.Windows.Forms.Label labDevice_XDM3051;
        private System.Windows.Forms.Label labDevice_multimeter_free;
        private System.Windows.Forms.Label labDevice_MPM1010B;
        private System.Windows.Forms.Label labDevice_ET3916;
        private System.Windows.Forms.Label labDevice_XDM1041;
        private System.Windows.Forms.Label labDevice_XDM2041;
        private System.Windows.Forms.Label labDevice_supply_free;
        private System.Windows.Forms.Label labDevice_RD6024;
        private System.Windows.Forms.Label labDevice_RD6006;
        private System.Windows.Forms.Label labDevice_HCS_330;
        private System.Windows.Forms.Label labDevice_KA3305P;
        private System.Windows.Forms.Label labDevice_KEL103;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem program10TestPowerSupplyDigitalMultimeterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem program20MeasureCapacitiyToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem program1VerifyConnectedDevicesToolStripMenuItem;
        private System.Windows.Forms.Button btnExit;
    }
}

