namespace NM_CongNghePhanMem
{
    partial class Main
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
            this.bt_Read = new System.Windows.Forms.Button();
            this.tb_Conference = new System.Windows.Forms.TextBox();
            this.bt_Stop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Link = new System.Windows.Forms.TextBox();
            this.bt_Save = new System.Windows.Forms.Button();
            this.SETTING = new System.Windows.Forms.GroupBox();
            this.lb_Count = new System.Windows.Forms.Label();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_Modify = new System.Windows.Forms.Button();
            this.lb_PageID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Second = new System.Windows.Forms.TextBox();
            this.lb_Minute = new System.Windows.Forms.Label();
            this.lb_TimeInterval = new System.Windows.Forms.Label();
            this.lb_Link = new System.Windows.Forms.Label();
            this.tb_Minute = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SETTING.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_Read
            // 
            this.bt_Read.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Read.Location = new System.Drawing.Point(14, 507);
            this.bt_Read.Name = "bt_Read";
            this.bt_Read.Size = new System.Drawing.Size(250, 52);
            this.bt_Read.TabIndex = 0;
            this.bt_Read.Text = "Start";
            this.bt_Read.UseVisualStyleBackColor = true;
            this.bt_Read.Click += new System.EventHandler(this.bt_Read_Click);
            // 
            // tb_Conference
            // 
            this.tb_Conference.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Conference.Location = new System.Drawing.Point(14, 25);
            this.tb_Conference.Multiline = true;
            this.tb_Conference.Name = "tb_Conference";
            this.tb_Conference.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Conference.Size = new System.Drawing.Size(1220, 476);
            this.tb_Conference.TabIndex = 1;
            // 
            // bt_Stop
            // 
            this.bt_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Stop.Enabled = false;
            this.bt_Stop.Location = new System.Drawing.Point(270, 507);
            this.bt_Stop.Name = "bt_Stop";
            this.bt_Stop.Size = new System.Drawing.Size(250, 52);
            this.bt_Stop.TabIndex = 2;
            this.bt_Stop.Text = "Stop";
            this.bt_Stop.UseVisualStyleBackColor = true;
            this.bt_Stop.Click += new System.EventHandler(this.bt_Stop_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(526, 507);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(708, 52);
            this.progressBar1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "0";
            // 
            // tb_Link
            // 
            this.tb_Link.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Link.Enabled = false;
            this.tb_Link.Location = new System.Drawing.Point(15, 55);
            this.tb_Link.Multiline = true;
            this.tb_Link.Name = "tb_Link";
            this.tb_Link.Size = new System.Drawing.Size(1220, 37);
            this.tb_Link.TabIndex = 0;
            // 
            // bt_Save
            // 
            this.bt_Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Save.Location = new System.Drawing.Point(437, 129);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(188, 42);
            this.bt_Save.TabIndex = 1;
            this.bt_Save.Text = "Save";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Visible = false;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // SETTING
            // 
            this.SETTING.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SETTING.Controls.Add(this.label5);
            this.SETTING.Controls.Add(this.label4);
            this.SETTING.Controls.Add(this.lb_Count);
            this.SETTING.Controls.Add(this.bt_Cancel);
            this.SETTING.Controls.Add(this.bt_Modify);
            this.SETTING.Controls.Add(this.lb_PageID);
            this.SETTING.Controls.Add(this.label3);
            this.SETTING.Controls.Add(this.tb_Second);
            this.SETTING.Controls.Add(this.lb_Minute);
            this.SETTING.Controls.Add(this.lb_TimeInterval);
            this.SETTING.Controls.Add(this.label2);
            this.SETTING.Controls.Add(this.label1);
            this.SETTING.Controls.Add(this.lb_Link);
            this.SETTING.Controls.Add(this.tb_Minute);
            this.SETTING.Controls.Add(this.tb_Link);
            this.SETTING.Controls.Add(this.bt_Save);
            this.SETTING.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SETTING.ForeColor = System.Drawing.Color.Blue;
            this.SETTING.Location = new System.Drawing.Point(12, 12);
            this.SETTING.Name = "SETTING";
            this.SETTING.Size = new System.Drawing.Size(1253, 186);
            this.SETTING.TabIndex = 6;
            this.SETTING.TabStop = false;
            this.SETTING.Text = "SETTINGS";
            // 
            // lb_Count
            // 
            this.lb_Count.AutoSize = true;
            this.lb_Count.Location = new System.Drawing.Point(962, 101);
            this.lb_Count.Name = "lb_Count";
            this.lb_Count.Size = new System.Drawing.Size(0, 20);
            this.lb_Count.TabIndex = 12;
            this.lb_Count.Visible = false;
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Cancel.Location = new System.Drawing.Point(639, 129);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(188, 42);
            this.bt_Cancel.TabIndex = 11;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Visible = false;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_Modify
            // 
            this.bt_Modify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Modify.Location = new System.Drawing.Point(437, 129);
            this.bt_Modify.Name = "bt_Modify";
            this.bt_Modify.Size = new System.Drawing.Size(188, 42);
            this.bt_Modify.TabIndex = 10;
            this.bt_Modify.Text = "Config";
            this.bt_Modify.UseVisualStyleBackColor = true;
            this.bt_Modify.Click += new System.EventHandler(this.bt_Modify_Click);
            // 
            // lb_PageID
            // 
            this.lb_PageID.AutoSize = true;
            this.lb_PageID.Location = new System.Drawing.Point(214, 101);
            this.lb_PageID.Name = "lb_PageID";
            this.lb_PageID.Size = new System.Drawing.Size(0, 20);
            this.lb_PageID.TabIndex = 9;
            this.lb_PageID.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Second: ";
            // 
            // tb_Second
            // 
            this.tb_Second.Enabled = false;
            this.tb_Second.Location = new System.Drawing.Point(289, 131);
            this.tb_Second.Multiline = true;
            this.tb_Second.Name = "tb_Second";
            this.tb_Second.Size = new System.Drawing.Size(117, 37);
            this.tb_Second.TabIndex = 7;
            this.tb_Second.Text = "0";
            // 
            // lb_Minute
            // 
            this.lb_Minute.AutoSize = true;
            this.lb_Minute.Location = new System.Drawing.Point(11, 140);
            this.lb_Minute.Name = "lb_Minute";
            this.lb_Minute.Size = new System.Drawing.Size(65, 20);
            this.lb_Minute.TabIndex = 6;
            this.lb_Minute.Text = "Minute: ";
            // 
            // lb_TimeInterval
            // 
            this.lb_TimeInterval.AutoSize = true;
            this.lb_TimeInterval.ForeColor = System.Drawing.Color.Blue;
            this.lb_TimeInterval.Location = new System.Drawing.Point(14, 101);
            this.lb_TimeInterval.Name = "lb_TimeInterval";
            this.lb_TimeInterval.Size = new System.Drawing.Size(179, 20);
            this.lb_TimeInterval.TabIndex = 4;
            this.lb_TimeInterval.Text = "Time interval (Minutes) : ";
            // 
            // lb_Link
            // 
            this.lb_Link.AutoSize = true;
            this.lb_Link.ForeColor = System.Drawing.Color.Blue;
            this.lb_Link.Location = new System.Drawing.Point(14, 26);
            this.lb_Link.Name = "lb_Link";
            this.lb_Link.Size = new System.Drawing.Size(50, 20);
            this.lb_Link.TabIndex = 3;
            this.lb_Link.Text = "Link : ";
            // 
            // tb_Minute
            // 
            this.tb_Minute.Enabled = false;
            this.tb_Minute.Location = new System.Drawing.Point(79, 131);
            this.tb_Minute.Multiline = true;
            this.tb_Minute.Name = "tb_Minute";
            this.tb_Minute.Size = new System.Drawing.Size(117, 37);
            this.tb_Minute.TabIndex = 2;
            this.tb_Minute.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tb_Conference);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.bt_Read);
            this.groupBox1.Controls.Add(this.bt_Stop);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(13, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1252, 566);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CONFERENCE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1035, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 13;
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "-";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 792);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SETTING);
            this.Name = "Main";
            this.Text = "Crawler System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.SETTING.ResumeLayout(false);
            this.SETTING.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_Read;
        private System.Windows.Forms.TextBox tb_Conference;
        private System.Windows.Forms.Button bt_Stop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Link;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.GroupBox SETTING;
        private System.Windows.Forms.Label lb_Link;
        private System.Windows.Forms.TextBox tb_Minute;
        private System.Windows.Forms.Label lb_TimeInterval;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_Minute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Second;
        private System.Windows.Forms.Label lb_PageID;
        private System.Windows.Forms.Button bt_Modify;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Label lb_Count;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}