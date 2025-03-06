namespace test_system
{
    partial class program_10_test_supply_multimeter
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
            this.comboBox_select_program = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labCurrentProgram = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // comboBox_select_program
            // 
            this.comboBox_select_program.FormattingEnabled = true;
            this.comboBox_select_program.Location = new System.Drawing.Point(13, 4);
            this.comboBox_select_program.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_select_program.Name = "comboBox_select_program";
            this.comboBox_select_program.Size = new System.Drawing.Size(471, 28);
            this.comboBox_select_program.TabIndex = 0;
            this.comboBox_select_program.SelectedIndexChanged += new System.EventHandler(this.comboBox_select_program_SelectedIndexChanged);
            this.comboBox_select_program.Click += new System.EventHandler(this.comboBox_select_program_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // labCurrentProgram
            // 
            this.labCurrentProgram.AutoSize = true;
            this.labCurrentProgram.Location = new System.Drawing.Point(521, 13);
            this.labCurrentProgram.Name = "labCurrentProgram";
            this.labCurrentProgram.Size = new System.Drawing.Size(51, 20);
            this.labCurrentProgram.TabIndex = 4;
            this.labCurrentProgram.Text = "label3";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // program_10_test_supply_multimeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.labCurrentProgram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_select_program);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "program_10_test_supply_multimeter";
            this.Text = "program_10_test_supply_multimeeter";
            this.Load += new System.EventHandler(this.program_10_test_supply_multimeeter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_select_program;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labCurrentProgram;
        private System.Windows.Forms.Timer timer1;
    }
}