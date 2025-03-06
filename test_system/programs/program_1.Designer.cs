namespace test_system
{
    partial class program_1
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
            this.labName = new System.Windows.Forms.Label();
            this.listView_connected = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIdent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(13, 9);
            this.labName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(51, 20);
            this.labName.TabIndex = 0;
            this.labName.Text = "label1";
            // 
            // listView_connected
            // 
            this.listView_connected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colPort,
            this.colIdent});
            this.listView_connected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView_connected.HideSelection = false;
            this.listView_connected.Location = new System.Drawing.Point(17, 52);
            this.listView_connected.Name = "listView_connected";
            this.listView_connected.Size = new System.Drawing.Size(975, 171);
            this.listView_connected.TabIndex = 1;
            this.listView_connected.UseCompatibleStateImageBehavior = false;
            this.listView_connected.View = System.Windows.Forms.View.Details;
            this.listView_connected.SelectedIndexChanged += new System.EventHandler(this.listView_connected_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Device";
            this.colName.Width = 300;
            // 
            // colPort
            // 
            this.colPort.Text = "COMport";
            this.colPort.Width = 100;
            // 
            // colIdent
            // 
            this.colIdent.Text = "Ident";
            this.colIdent.Width = 500;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // program_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 716);
            this.Controls.Add(this.listView_connected);
            this.Controls.Add(this.labName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "program_1";
            this.Text = "program_1";
            this.Load += new System.EventHandler(this.program_1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.ListView listView_connected;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPort;
        private System.Windows.Forms.ColumnHeader colIdent;
        private System.Windows.Forms.Timer timer1;
    }
}