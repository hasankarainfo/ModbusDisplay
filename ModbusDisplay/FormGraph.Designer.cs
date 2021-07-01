namespace ModbusDisplay
{
    partial class FormGraph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraph));
            this.splitC1 = new System.Windows.Forms.SplitContainer();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.lblFail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOk = new System.Windows.Forms.Label();
            this.numTime = new System.Windows.Forms.NumericUpDown();
            this.cbAsciiEn = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMbAutoSend = new System.Windows.Forms.CheckBox();
            this.cbGraphEn = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbBinEn = new System.Windows.Forms.CheckBox();
            this.cbHexEn = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStreamEn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxRegOrder = new System.Windows.Forms.ComboBox();
            this.numAddr = new System.Windows.Forms.NumericUpDown();
            this.splitC2 = new System.Windows.Forms.SplitContainer();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitC1)).BeginInit();
            this.splitC1.Panel1.SuspendLayout();
            this.splitC1.Panel2.SuspendLayout();
            this.splitC1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAddr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitC2)).BeginInit();
            this.splitC2.Panel2.SuspendLayout();
            this.splitC2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitC1
            // 
            this.splitC1.BackColor = System.Drawing.Color.Transparent;
            this.splitC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitC1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitC1.Location = new System.Drawing.Point(0, 24);
            this.splitC1.Name = "splitC1";
            this.splitC1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitC1.Panel1
            // 
            this.splitC1.Panel1.AllowDrop = true;
            this.splitC1.Panel1.AutoScroll = true;
            this.splitC1.Panel1.Controls.Add(this.numDelay);
            this.splitC1.Panel1.Controls.Add(this.lblFail);
            this.splitC1.Panel1.Controls.Add(this.label1);
            this.splitC1.Panel1.Controls.Add(this.lblOk);
            this.splitC1.Panel1.Controls.Add(this.numTime);
            this.splitC1.Panel1.Controls.Add(this.cbAsciiEn);
            this.splitC1.Panel1.Controls.Add(this.label3);
            this.splitC1.Panel1.Controls.Add(this.cbMbAutoSend);
            this.splitC1.Panel1.Controls.Add(this.cbGraphEn);
            this.splitC1.Panel1.Controls.Add(this.linkLabel1);
            this.splitC1.Panel1.Controls.Add(this.cbBinEn);
            this.splitC1.Panel1.Controls.Add(this.cbHexEn);
            this.splitC1.Panel1.Controls.Add(this.label2);
            this.splitC1.Panel1.Controls.Add(this.btnStreamEn);
            this.splitC1.Panel1.Controls.Add(this.label4);
            this.splitC1.Panel1.Controls.Add(this.cboxRegOrder);
            this.splitC1.Panel1.Controls.Add(this.numAddr);
            this.splitC1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitC1.Panel2
            // 
            this.splitC1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitC1.Panel2.Controls.Add(this.splitC2);
            this.splitC1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitC1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitC1.Size = new System.Drawing.Size(1270, 515);
            this.splitC1.SplitterDistance = 55;
            this.splitC1.TabIndex = 35;
            // 
            // numDelay
            // 
            this.numDelay.Location = new System.Drawing.Point(780, 7);
            this.numDelay.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(61, 20);
            this.numDelay.TabIndex = 32;
            this.numDelay.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblFail
            // 
            this.lblFail.AutoSize = true;
            this.lblFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFail.Location = new System.Drawing.Point(985, 29);
            this.lblFail.Name = "lblFail";
            this.lblFail.Size = new System.Drawing.Size(38, 20);
            this.lblFail.TabIndex = 45;
            this.lblFail.Text = "Fail:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(659, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Time(sec):";
            // 
            // lblOk
            // 
            this.lblOk.AutoSize = true;
            this.lblOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOk.Location = new System.Drawing.Point(985, 6);
            this.lblOk.Name = "lblOk";
            this.lblOk.Size = new System.Drawing.Size(35, 20);
            this.lblOk.TabIndex = 44;
            this.lblOk.Text = "OK:";
            // 
            // numTime
            // 
            this.numTime.Location = new System.Drawing.Point(680, 7);
            this.numTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTime.Name = "numTime";
            this.numTime.Size = new System.Drawing.Size(61, 20);
            this.numTime.TabIndex = 32;
            this.numTime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numTime.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // cbAsciiEn
            // 
            this.cbAsciiEn.AutoSize = true;
            this.cbAsciiEn.Checked = true;
            this.cbAsciiEn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAsciiEn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbAsciiEn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbAsciiEn.Location = new System.Drawing.Point(459, 3);
            this.cbAsciiEn.Name = "cbAsciiEn";
            this.cbAsciiEn.Size = new System.Drawing.Size(85, 24);
            this.cbAsciiEn.TabIndex = 43;
            this.cbAsciiEn.Text = "Ascii En";
            this.cbAsciiEn.UseVisualStyleBackColor = true;
            this.cbAsciiEn.CheckedChanged += new System.EventHandler(this.cbAsciiEn_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(757, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Delay(ms):";
            // 
            // cbMbAutoSend
            // 
            this.cbMbAutoSend.AutoSize = true;
            this.cbMbAutoSend.Checked = true;
            this.cbMbAutoSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMbAutoSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbMbAutoSend.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbMbAutoSend.Location = new System.Drawing.Point(110, 2);
            this.cbMbAutoSend.Name = "cbMbAutoSend";
            this.cbMbAutoSend.Size = new System.Drawing.Size(104, 24);
            this.cbMbAutoSend.TabIndex = 42;
            this.cbMbAutoSend.Text = "Auto Send";
            this.cbMbAutoSend.UseVisualStyleBackColor = true;
            // 
            // cbGraphEn
            // 
            this.cbGraphEn.AutoSize = true;
            this.cbGraphEn.Checked = true;
            this.cbGraphEn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGraphEn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbGraphEn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbGraphEn.Location = new System.Drawing.Point(562, 3);
            this.cbGraphEn.Name = "cbGraphEn";
            this.cbGraphEn.Size = new System.Drawing.Size(97, 24);
            this.cbGraphEn.TabIndex = 38;
            this.cbGraphEn.Text = "Graph En";
            this.cbGraphEn.UseVisualStyleBackColor = true;
            this.cbGraphEn.CheckedChanged += new System.EventHandler(this.cbGraphEn_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel1.Location = new System.Drawing.Point(1119, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(151, 20);
            this.linkLabel1.TabIndex = 41;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.hasankara.info";
            // 
            // cbBinEn
            // 
            this.cbBinEn.AutoSize = true;
            this.cbBinEn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbBinEn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbBinEn.Location = new System.Drawing.Point(373, 28);
            this.cbBinEn.Name = "cbBinEn";
            this.cbBinEn.Size = new System.Drawing.Size(75, 24);
            this.cbBinEn.TabIndex = 40;
            this.cbBinEn.Text = "Bin En";
            this.cbBinEn.UseVisualStyleBackColor = true;
            this.cbBinEn.CheckedChanged += new System.EventHandler(this.cbBinEn_CheckedChanged);
            // 
            // cbHexEn
            // 
            this.cbHexEn.AutoSize = true;
            this.cbHexEn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbHexEn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbHexEn.Location = new System.Drawing.Point(373, 3);
            this.cbHexEn.Name = "cbHexEn";
            this.cbHexEn.Size = new System.Drawing.Size(80, 24);
            this.cbHexEn.TabIndex = 39;
            this.cbHexEn.Text = "Hex En";
            this.cbHexEn.UseVisualStyleBackColor = true;
            this.cbHexEn.CheckedChanged += new System.EventHandler(this.cbHexEn_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(270, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Reg Order :";
            // 
            // btnStreamEn
            // 
            this.btnStreamEn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStreamEn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnStreamEn.Location = new System.Drawing.Point(5, 3);
            this.btnStreamEn.Name = "btnStreamEn";
            this.btnStreamEn.Size = new System.Drawing.Size(99, 52);
            this.btnStreamEn.TabIndex = 30;
            this.btnStreamEn.Text = "Stream";
            this.btnStreamEn.UseVisualStyleBackColor = true;
            this.btnStreamEn.Click += new System.EventHandler(this.btnStreamEn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(231, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "ID:";
            // 
            // cboxRegOrder
            // 
            this.cboxRegOrder.FormattingEnabled = true;
            this.cboxRegOrder.Location = new System.Drawing.Point(267, 6);
            this.cboxRegOrder.Name = "cboxRegOrder";
            this.cboxRegOrder.Size = new System.Drawing.Size(94, 21);
            this.cboxRegOrder.TabIndex = 36;
            this.cboxRegOrder.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // numAddr
            // 
            this.numAddr.Location = new System.Drawing.Point(220, 6);
            this.numAddr.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numAddr.Name = "numAddr";
            this.numAddr.Size = new System.Drawing.Size(41, 20);
            this.numAddr.TabIndex = 35;
            this.numAddr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAddr.ValueChanged += new System.EventHandler(this.numAddr_ValueChanged);
            // 
            // splitC2
            // 
            this.splitC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitC2.Location = new System.Drawing.Point(0, 0);
            this.splitC2.Name = "splitC2";
            // 
            // splitC2.Panel2
            // 
            this.splitC2.Panel2.Controls.Add(this.zg1);
            this.splitC2.Size = new System.Drawing.Size(1270, 456);
            this.splitC2.SplitterDistance = 421;
            this.splitC2.TabIndex = 1;
            // 
            // zg1
            // 
            this.zg1.AutoSize = true;
            this.zg1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.zg1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zg1.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zg1.IsAntiAlias = true;
            this.zg1.IsAutoScrollRange = true;
            this.zg1.Location = new System.Drawing.Point(0, 0);
            this.zg1.Name = "zg1";
            this.zg1.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(845, 456);
            this.zg1.TabIndex = 0;
            this.zg1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1270, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // FormGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1270, 539);
            this.Controls.Add(this.splitC1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGraph";
            this.Text = "FormGraph";
            this.Load += new System.EventHandler(this.FormGraph_Load);
            this.splitC1.Panel1.ResumeLayout(false);
            this.splitC1.Panel1.PerformLayout();
            this.splitC1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitC1)).EndInit();
            this.splitC1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAddr)).EndInit();
            this.splitC2.Panel2.ResumeLayout(false);
            this.splitC2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitC2)).EndInit();
            this.splitC2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitC1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStreamEn;
        private System.Windows.Forms.NumericUpDown numDelay;
        public ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numAddr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numTime;
        private System.Windows.Forms.ComboBox cboxRegOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitC2;
        private System.Windows.Forms.CheckBox cbGraphEn;
        private System.Windows.Forms.CheckBox cbHexEn;
        private System.Windows.Forms.CheckBox cbBinEn;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox cbMbAutoSend;
        private System.Windows.Forms.CheckBox cbAsciiEn;
        private System.Windows.Forms.Label lblFail;
        private System.Windows.Forms.Label lblOk;
    }
}