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
            this.button2 = new System.Windows.Forms.Button();
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
            this.button3 = new System.Windows.Forms.Button();
            this.btnProgram_01 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.groupBox_connected_device.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 58);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 30);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.button8.Location = new System.Drawing.Point(20, 102);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(150, 30);
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
            this.button13.Location = new System.Drawing.Point(20, 139);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(150, 30);
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
            this.groupBox_connected_device.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox_connected_device.Location = new System.Drawing.Point(1230, 38);
            this.groupBox_connected_device.Name = "groupBox_connected_device";
            this.groupBox_connected_device.Size = new System.Drawing.Size(115, 618);
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
            this.labDevice_supply_free.Location = new System.Drawing.Point(16, 303);
            this.labDevice_supply_free.Name = "labDevice_supply_free";
            this.labDevice_supply_free.Size = new System.Drawing.Size(60, 20);
            this.labDevice_supply_free.TabIndex = 0;
            this.labDevice_supply_free.Text = "label14";
            // 
            // labDevice_RD6024
            // 
            this.labDevice_RD6024.AutoSize = true;
            this.labDevice_RD6024.Location = new System.Drawing.Point(16, 278);
            this.labDevice_RD6024.Name = "labDevice_RD6024";
            this.labDevice_RD6024.Size = new System.Drawing.Size(60, 20);
            this.labDevice_RD6024.TabIndex = 0;
            this.labDevice_RD6024.Text = "label14";
            // 
            // labDevice_RD6006
            // 
            this.labDevice_RD6006.AutoSize = true;
            this.labDevice_RD6006.Location = new System.Drawing.Point(16, 258);
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(20, 230);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 30);
            this.button3.TabIndex = 22;
            this.button3.Text = "program 10";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // btnProgram_01
            // 
            this.btnProgram_01.Location = new System.Drawing.Point(20, 194);
            this.btnProgram_01.Name = "btnProgram_01";
            this.btnProgram_01.Size = new System.Drawing.Size(150, 30);
            this.btnProgram_01.TabIndex = 23;
            this.btnProgram_01.Text = "Program 1";
            this.btnProgram_01.UseVisualStyleBackColor = true;
            this.btnProgram_01.Click += new System.EventHandler(this.btnProgram_01_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1357, 32);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(70, 28);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 28);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(70, 28);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(140, 28);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 692);
            this.Controls.Add(this.btnProgram_01);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox_connected_device);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
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
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnProgram_01;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

