namespace test_system
{
    partial class program_20_battery_test
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labCurrentState = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton_charge = new System.Windows.Forms.RadioButton();
            this.radioButton_discharge = new System.Windows.Forms.RadioButton();
            this.labResult_01 = new System.Windows.Forms.Label();
            this.labResult_02 = new System.Windows.Forms.Label();
            this.labResult_03 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 300);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labCurrentState
            // 
            this.labCurrentState.AutoSize = true;
            this.labCurrentState.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labCurrentState.Location = new System.Drawing.Point(252, 9);
            this.labCurrentState.Name = "labCurrentState";
            this.labCurrentState.Size = new System.Drawing.Size(86, 31);
            this.labCurrentState.TabIndex = 2;
            this.labCurrentState.Text = "label2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(227, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 37);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButton_charge
            // 
            this.radioButton_charge.AutoSize = true;
            this.radioButton_charge.Location = new System.Drawing.Point(24, 59);
            this.radioButton_charge.Name = "radioButton_charge";
            this.radioButton_charge.Size = new System.Drawing.Size(97, 24);
            this.radioButton_charge.TabIndex = 4;
            this.radioButton_charge.TabStop = true;
            this.radioButton_charge.Text = "CHARGE";
            this.radioButton_charge.UseVisualStyleBackColor = true;
            // 
            // radioButton_discharge
            // 
            this.radioButton_discharge.AutoSize = true;
            this.radioButton_discharge.Location = new System.Drawing.Point(24, 90);
            this.radioButton_discharge.Name = "radioButton_discharge";
            this.radioButton_discharge.Size = new System.Drawing.Size(125, 24);
            this.radioButton_discharge.TabIndex = 5;
            this.radioButton_discharge.TabStop = true;
            this.radioButton_discharge.Text = "DISCHARGE";
            this.radioButton_discharge.UseVisualStyleBackColor = true;
            // 
            // labResult_01
            // 
            this.labResult_01.AutoSize = true;
            this.labResult_01.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labResult_01.Location = new System.Drawing.Point(435, 72);
            this.labResult_01.Name = "labResult_01";
            this.labResult_01.Size = new System.Drawing.Size(104, 32);
            this.labResult_01.TabIndex = 6;
            this.labResult_01.Text = "label2";
            // 
            // labResult_02
            // 
            this.labResult_02.AutoSize = true;
            this.labResult_02.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labResult_02.Location = new System.Drawing.Point(435, 107);
            this.labResult_02.Name = "labResult_02";
            this.labResult_02.Size = new System.Drawing.Size(104, 32);
            this.labResult_02.TabIndex = 7;
            this.labResult_02.Text = "label3";
            // 
            // labResult_03
            // 
            this.labResult_03.AutoSize = true;
            this.labResult_03.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labResult_03.Location = new System.Drawing.Point(435, 145);
            this.labResult_03.Name = "labResult_03";
            this.labResult_03.Size = new System.Drawing.Size(104, 32);
            this.labResult_03.TabIndex = 8;
            this.labResult_03.Text = "label4";
            // 
            // program_20_battery_test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 493);
            this.Controls.Add(this.labResult_03);
            this.Controls.Add(this.labResult_02);
            this.Controls.Add(this.labResult_01);
            this.Controls.Add(this.radioButton_discharge);
            this.Controls.Add(this.radioButton_charge);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labCurrentState);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "program_20_battery_test";
            this.Text = "program_20_battery_test";
            this.Load += new System.EventHandler(this.program_20_battery_test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labCurrentState;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton_charge;
        private System.Windows.Forms.RadioButton radioButton_discharge;
        private System.Windows.Forms.Label labResult_01;
        private System.Windows.Forms.Label labResult_02;
        private System.Windows.Forms.Label labResult_03;
    }
}