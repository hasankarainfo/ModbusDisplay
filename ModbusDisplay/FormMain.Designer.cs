namespace ModbusDisplay
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnConnect = new System.Windows.Forms.Button();
            this.btnDisplayNew = new System.Windows.Forms.Button();
            this.numBaud = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cboxStop = new System.Windows.Forms.ComboBox();
            this.cboxParity = new System.Windows.Forms.ComboBox();
            this.numMbTout = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblParity = new System.Windows.Forms.Label();
            this.lstPorts = new System.Windows.Forms.ListBox();
            this.btnDisplayOpen = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numBaud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMbTout)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnConnect
            // 
            this.BtnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnConnect.Location = new System.Drawing.Point(5, 29);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(78, 184);
            this.BtnConnect.TabIndex = 1;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btnDisplayNew
            // 
            this.btnDisplayNew.BackColor = System.Drawing.Color.Aquamarine;
            this.btnDisplayNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDisplayNew.Location = new System.Drawing.Point(3, 29);
            this.btnDisplayNew.Name = "btnDisplayNew";
            this.btnDisplayNew.Size = new System.Drawing.Size(154, 83);
            this.btnDisplayNew.TabIndex = 0;
            this.btnDisplayNew.Text = "Display";
            this.btnDisplayNew.UseVisualStyleBackColor = false;
            this.btnDisplayNew.Click += new System.EventHandler(this.btnDisplayNew_Click);
            // 
            // numBaud
            // 
            this.numBaud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numBaud.Location = new System.Drawing.Point(201, 31);
            this.numBaud.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numBaud.Name = "numBaud";
            this.numBaud.Size = new System.Drawing.Size(101, 26);
            this.numBaud.TabIndex = 2;
            this.numBaud.Value = new decimal(new int[] {
            115200,
            0,
            0,
            0});
            this.numBaud.ValueChanged += new System.EventHandler(this.numBaud_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(197, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Baud:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(89, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Port:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cboxStop);
            this.splitContainer1.Panel1.Controls.Add(this.cboxParity);
            this.splitContainer1.Panel1.Controls.Add(this.numMbTout);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblParity);
            this.splitContainer1.Panel1.Controls.Add(this.lstPorts);
            this.splitContainer1.Panel1.Controls.Add(this.numBaud);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.BtnConnect);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnDisplayOpen);
            this.splitContainer1.Panel2.Controls.Add(this.btnDisplayNew);
            this.splitContainer1.Panel2.Controls.Add(this.linkLabel1);
            this.splitContainer1.Size = new System.Drawing.Size(506, 222);
            this.splitContainer1.SplitterDistance = 332;
            this.splitContainer1.TabIndex = 29;
            // 
            // cboxStop
            // 
            this.cboxStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cboxStop.FormattingEnabled = true;
            this.cboxStop.Location = new System.Drawing.Point(201, 136);
            this.cboxStop.Name = "cboxStop";
            this.cboxStop.Size = new System.Drawing.Size(101, 28);
            this.cboxStop.TabIndex = 33;
            // 
            // cboxParity
            // 
            this.cboxParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cboxParity.FormattingEnabled = true;
            this.cboxParity.Location = new System.Drawing.Point(201, 84);
            this.cboxParity.Name = "cboxParity";
            this.cboxParity.Size = new System.Drawing.Size(101, 28);
            this.cboxParity.TabIndex = 32;
            // 
            // numMbTout
            // 
            this.numMbTout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numMbTout.Location = new System.Drawing.Point(201, 187);
            this.numMbTout.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMbTout.Name = "numMbTout";
            this.numMbTout.Size = new System.Drawing.Size(101, 26);
            this.numMbTout.TabIndex = 31;
            this.numMbTout.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(197, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Modbus Timeout:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(197, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Stop Bits:";
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblParity.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblParity.Location = new System.Drawing.Point(197, 61);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(52, 20);
            this.lblParity.TabIndex = 12;
            this.lblParity.Text = "Parity:";
            // 
            // lstPorts
            // 
            this.lstPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstPorts.FormattingEnabled = true;
            this.lstPorts.ItemHeight = 20;
            this.lstPorts.Location = new System.Drawing.Point(89, 29);
            this.lstPorts.Name = "lstPorts";
            this.lstPorts.Size = new System.Drawing.Size(106, 184);
            this.lstPorts.TabIndex = 10;
            this.lstPorts.SelectedIndexChanged += new System.EventHandler(this.lstPorts_SelectedIndexChanged);
            this.lstPorts.DoubleClick += new System.EventHandler(this.lstPorts_DoubleClick);
            // 
            // btnDisplayOpen
            // 
            this.btnDisplayOpen.BackColor = System.Drawing.Color.Turquoise;
            this.btnDisplayOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDisplayOpen.Location = new System.Drawing.Point(3, 118);
            this.btnDisplayOpen.Name = "btnDisplayOpen";
            this.btnDisplayOpen.Size = new System.Drawing.Size(154, 83);
            this.btnDisplayOpen.TabIndex = 12;
            this.btnDisplayOpen.Text = "Display Open";
            this.btnDisplayOpen.UseVisualStyleBackColor = false;
            this.btnDisplayOpen.Click += new System.EventHandler(this.btnDisplayOpen_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel1.Location = new System.Drawing.Point(19, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(151, 20);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.hasankara.info";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(506, 222);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Modbus Display";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numBaud)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMbTout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Button btnDisplayNew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numBaud;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstPorts;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.NumericUpDown numMbTout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.ComboBox cboxStop;
        private System.Windows.Forms.ComboBox cboxParity;
        private System.Windows.Forms.Button btnDisplayOpen;
    }
}

