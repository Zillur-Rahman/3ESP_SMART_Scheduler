namespace SMART_Scheduler
{
    partial class SMART_Scheduler_HourInterval
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
            this.btnON = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDownloadIDNType = new System.Windows.Forms.Label();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNextUpdate2 = new System.Windows.Forms.Label();
            this.lblTickNo2 = new System.Windows.Forms.Label();
            this.lblLastUpdate2 = new System.Windows.Forms.Label();
            this.lblNextUpdate1 = new System.Windows.Forms.Label();
            this.lblTickNo1 = new System.Windows.Forms.Label();
            this.lblLastUpdate1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.NumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.lblProgress2 = new System.Windows.Forms.Label();
            this.ProgressBar2 = new System.Windows.Forms.ProgressBar();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnON
            // 
            this.btnON.Location = new System.Drawing.Point(1081, 314);
            this.btnON.Margin = new System.Windows.Forms.Padding(4);
            this.btnON.Name = "btnON";
            this.btnON.Size = new System.Drawing.Size(228, 28);
            this.btnON.TabIndex = 0;
            this.btnON.Text = "ON";
            this.btnON.UseVisualStyleBackColor = true;
            this.btnON.Click += new System.EventHandler(this.btnON_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 624);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1332, 29);
            this.statusStrip1.TabIndex = 57;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(133, 23);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(22, 24);
            this.toolStripStatusLabel1.Text = "...";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(22, 24);
            this.toolStripStatusLabel2.Text = "...";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(22, 24);
            this.toolStripStatusLabel3.Text = "...";
            // 
            // lblDownloadIDNType
            // 
            this.lblDownloadIDNType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDownloadIDNType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadIDNType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDownloadIDNType.Location = new System.Drawing.Point(664, -20);
            this.lblDownloadIDNType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDownloadIDNType.Name = "lblDownloadIDNType";
            this.lblDownloadIDNType.Size = new System.Drawing.Size(366, 22);
            this.lblDownloadIDNType.TabIndex = 60;
            this.lblDownloadIDNType.Text = "...";
            this.lblDownloadIDNType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(16, 11);
            this.chkAuto.Margin = new System.Windows.Forms.Padding(4);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(133, 21);
            this.chkAuto.TabIndex = 62;
            this.chkAuto.Text = "Download Auto?";
            this.chkAuto.UseVisualStyleBackColor = true;
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblNextUpdate2);
            this.groupBox2.Controls.Add(this.lblTickNo2);
            this.groupBox2.Controls.Add(this.lblLastUpdate2);
            this.groupBox2.Controls.Add(this.lblNextUpdate1);
            this.groupBox2.Controls.Add(this.lblTickNo1);
            this.groupBox2.Controls.Add(this.lblLastUpdate1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.NumericUpDown1);
            this.groupBox2.Location = new System.Drawing.Point(16, 26);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(657, 142);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            // 
            // lblNextUpdate2
            // 
            this.lblNextUpdate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNextUpdate2.Location = new System.Drawing.Point(210, 103);
            this.lblNextUpdate2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNextUpdate2.Name = "lblNextUpdate2";
            this.lblNextUpdate2.Size = new System.Drawing.Size(267, 22);
            this.lblNextUpdate2.TabIndex = 66;
            this.lblNextUpdate2.Text = "...";
            // 
            // lblTickNo2
            // 
            this.lblTickNo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTickNo2.Location = new System.Drawing.Point(210, 54);
            this.lblTickNo2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTickNo2.Name = "lblTickNo2";
            this.lblTickNo2.Size = new System.Drawing.Size(267, 22);
            this.lblTickNo2.TabIndex = 65;
            this.lblTickNo2.Text = "...";
            // 
            // lblLastUpdate2
            // 
            this.lblLastUpdate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblLastUpdate2.Location = new System.Drawing.Point(210, 78);
            this.lblLastUpdate2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastUpdate2.Name = "lblLastUpdate2";
            this.lblLastUpdate2.Size = new System.Drawing.Size(267, 22);
            this.lblLastUpdate2.TabIndex = 64;
            this.lblLastUpdate2.Text = "...";
            // 
            // lblNextUpdate1
            // 
            this.lblNextUpdate1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNextUpdate1.Location = new System.Drawing.Point(8, 103);
            this.lblNextUpdate1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNextUpdate1.Name = "lblNextUpdate1";
            this.lblNextUpdate1.Size = new System.Drawing.Size(194, 22);
            this.lblNextUpdate1.TabIndex = 63;
            this.lblNextUpdate1.Text = "Next update (approx.):";
            this.lblNextUpdate1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTickNo1
            // 
            this.lblTickNo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTickNo1.Location = new System.Drawing.Point(8, 54);
            this.lblTickNo1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTickNo1.Name = "lblTickNo1";
            this.lblTickNo1.Size = new System.Drawing.Size(194, 22);
            this.lblTickNo1.TabIndex = 62;
            this.lblTickNo1.Text = "TickNo:";
            this.lblTickNo1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblLastUpdate1
            // 
            this.lblLastUpdate1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblLastUpdate1.Location = new System.Drawing.Point(8, 78);
            this.lblLastUpdate1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastUpdate1.Name = "lblLastUpdate1";
            this.lblLastUpdate1.Size = new System.Drawing.Size(194, 22);
            this.lblLastUpdate1.TabIndex = 61;
            this.lblLastUpdate1.Text = "Last update:";
            this.lblLastUpdate1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(23, 21);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 17);
            this.label9.TabIndex = 55;
            this.label9.Text = "Time Interval (in hours):";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NumericUpDown1
            // 
            this.NumericUpDown1.Enabled = false;
            this.NumericUpDown1.Location = new System.Drawing.Point(210, 18);
            this.NumericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.NumericUpDown1.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.NumericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown1.Name = "NumericUpDown1";
            this.NumericUpDown1.Size = new System.Drawing.Size(57, 22);
            this.NumericUpDown1.TabIndex = 54;
            this.NumericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(847, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 22);
            this.label2.TabIndex = 60;
            this.label2.Text = "...";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(16, 372);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1293, 242);
            this.listBox1.TabIndex = 56;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(943, 102);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(366, 30);
            this.label13.TabIndex = 60;
            this.label13.Text = "...";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(1197, 350);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 15);
            this.label15.TabIndex = 63;
            this.label15.Text = "Version: 1.06.00.00";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1184, 37);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 34);
            this.button1.TabIndex = 65;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(702, 236);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(359, 22);
            this.lblStatus.TabIndex = 61;
            this.lblStatus.Text = "...";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.Location = new System.Drawing.Point(559, 337);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(359, 22);
            this.label14.TabIndex = 61;
            this.label14.Text = "...";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.NumericUpDown2);
            this.groupBox3.Controls.Add(this.lblProgress2);
            this.groupBox3.Controls.Add(this.ProgressBar2);
            this.groupBox3.Location = new System.Drawing.Point(16, 184);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(657, 156);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(14, 34);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 17);
            this.label11.TabIndex = 57;
            this.label11.Text = "Download from day back:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NumericUpDown2
            // 
            this.NumericUpDown2.Location = new System.Drawing.Point(210, 32);
            this.NumericUpDown2.Margin = new System.Windows.Forms.Padding(4);
            this.NumericUpDown2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown2.Name = "NumericUpDown2";
            this.NumericUpDown2.Size = new System.Drawing.Size(57, 22);
            this.NumericUpDown2.TabIndex = 56;
            this.NumericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblProgress2
            // 
            this.lblProgress2.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblProgress2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProgress2.Location = new System.Drawing.Point(282, 108);
            this.lblProgress2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgress2.Name = "lblProgress2";
            this.lblProgress2.Size = new System.Drawing.Size(371, 22);
            this.lblProgress2.TabIndex = 52;
            this.lblProgress2.Text = "...";
            this.lblProgress2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ProgressBar2
            // 
            this.ProgressBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgressBar2.Location = new System.Drawing.Point(4, 134);
            this.ProgressBar2.Margin = new System.Windows.Forms.Padding(4);
            this.ProgressBar2.Name = "ProgressBar2";
            this.ProgressBar2.Size = new System.Drawing.Size(649, 18);
            this.ProgressBar2.TabIndex = 45;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(681, 100);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(42, 21);
            this.checkBox4.TabIndex = 84;
            this.checkBox4.Text = "...";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(681, 71);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(151, 21);
            this.checkBox3.TabIndex = 83;
            this.checkBox3.Text = "Creating Alarm Log";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(681, 42);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(383, 21);
            this.checkBox2.TabIndex = 82;
            this.checkBox2.Text = "Sending Scheduled SMS (Currently No SMS Scheduled)";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(681, 13);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(182, 21);
            this.checkBox1.TabIndex = 81;
            this.checkBox1.Text = "Sending Scheduled Mail";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SMART_Scheduler_HourInterval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 653);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblDownloadIDNType);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnON);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SMART_Scheduler_HourInterval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3ESP Scheduler (Interval 1 Hour)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnON;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Label lblDownloadIDNType;
        private System.Windows.Forms.CheckBox chkAuto;
        internal System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.NumericUpDown NumericUpDown1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.NumericUpDown NumericUpDown2;
        internal System.Windows.Forms.Label lblProgress2;
        internal System.Windows.Forms.ProgressBar ProgressBar2;
        private System.Windows.Forms.Label lblNextUpdate2;
        private System.Windows.Forms.Label lblTickNo2;
        private System.Windows.Forms.Label lblLastUpdate2;
        private System.Windows.Forms.Label lblNextUpdate1;
        private System.Windows.Forms.Label lblTickNo1;
        private System.Windows.Forms.Label lblLastUpdate1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

