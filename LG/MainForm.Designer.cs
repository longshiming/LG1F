namespace LG
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnInspectSetting = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSysSetting = new System.Windows.Forms.ToolStripButton();
            this.tsBtnComSetting = new System.Windows.Forms.ToolStripButton();
            this.tsBtnLogin = new System.Windows.Forms.ToolStripButton();
            this.tsBtnUpdatePwd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnExit = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRegister = new System.Windows.Forms.ToolStripButton();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddFitle = new System.Windows.Forms.Button();
            this.lbFitle = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDeleteFitle = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFitle = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbNum = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOkRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNgCount = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOkCount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStarOrStop = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbData = new System.Windows.Forms.ListBox();
            this.WindowImage = new AxIpeDspCtrlLib.AxIpeDspCtrl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsBtnReadCode = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsReadCodeSinalStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsResetSinalStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsResultLable = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WindowImage)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnInspectSetting,
            this.tsBtnSysSetting,
            this.tsBtnComSetting,
            this.tsBtnLogin,
            this.tsBtnUpdatePwd,
            this.tsBtnExit,
            this.tsBtnRegister});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(943, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnInspectSetting
            // 
            this.tsBtnInspectSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnInspectSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnInspectSetting.Image")));
            this.tsBtnInspectSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnInspectSetting.Name = "tsBtnInspectSetting";
            this.tsBtnInspectSetting.Size = new System.Drawing.Size(83, 22);
            this.tsBtnInspectSetting.Text = "检测参数设置";
            this.tsBtnInspectSetting.Click += new System.EventHandler(this.tsBtnInspectSetting_Click);
            // 
            // tsBtnSysSetting
            // 
            this.tsBtnSysSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnSysSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSysSetting.Image")));
            this.tsBtnSysSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSysSetting.Name = "tsBtnSysSetting";
            this.tsBtnSysSetting.Size = new System.Drawing.Size(59, 22);
            this.tsBtnSysSetting.Text = "系统设置";
            this.tsBtnSysSetting.Click += new System.EventHandler(this.tsBtnSysSetting_Click);
            // 
            // tsBtnComSetting
            // 
            this.tsBtnComSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnComSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnComSetting.Image")));
            this.tsBtnComSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnComSetting.Name = "tsBtnComSetting";
            this.tsBtnComSetting.Size = new System.Drawing.Size(59, 22);
            this.tsBtnComSetting.Text = "串口设置";
            this.tsBtnComSetting.Click += new System.EventHandler(this.tsBtnComSetting_Click);
            // 
            // tsBtnLogin
            // 
            this.tsBtnLogin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnLogin.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnLogin.Image")));
            this.tsBtnLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLogin.Name = "tsBtnLogin";
            this.tsBtnLogin.Size = new System.Drawing.Size(71, 22);
            this.tsBtnLogin.Text = "管理员登录";
            this.tsBtnLogin.Click += new System.EventHandler(this.tsBtnLogin_Click);
            // 
            // tsBtnUpdatePwd
            // 
            this.tsBtnUpdatePwd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnUpdatePwd.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUpdatePwd.Image")));
            this.tsBtnUpdatePwd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUpdatePwd.Name = "tsBtnUpdatePwd";
            this.tsBtnUpdatePwd.Size = new System.Drawing.Size(59, 22);
            this.tsBtnUpdatePwd.Text = "修改密码";
            this.tsBtnUpdatePwd.Click += new System.EventHandler(this.tsBtnUpdatePwd_Click);
            // 
            // tsBtnExit
            // 
            this.tsBtnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnExit.Image")));
            this.tsBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExit.Name = "tsBtnExit";
            this.tsBtnExit.Size = new System.Drawing.Size(59, 22);
            this.tsBtnExit.Text = "退出登录";
            this.tsBtnExit.Click += new System.EventHandler(this.tsBtnExit_Click);
            // 
            // tsBtnRegister
            // 
            this.tsBtnRegister.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnRegister.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRegister.Image")));
            this.tsBtnRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRegister.Name = "tsBtnRegister";
            this.tsBtnRegister.Size = new System.Drawing.Size(59, 22);
            this.tsBtnRegister.Text = "激活软件";
            this.tsBtnRegister.Click += new System.EventHandler(this.tsBtnRegister_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(646, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 630);
            this.panel1.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddFitle);
            this.groupBox2.Controls.Add(this.lbFitle);
            this.groupBox2.Controls.Add(this.tbFitle);
            this.groupBox2.Location = new System.Drawing.Point(9, 370);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 176);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "过滤字符";
            // 
            // btnAddFitle
            // 
            this.btnAddFitle.Location = new System.Drawing.Point(199, 31);
            this.btnAddFitle.Name = "btnAddFitle";
            this.btnAddFitle.Size = new System.Drawing.Size(67, 23);
            this.btnAddFitle.TabIndex = 0;
            this.btnAddFitle.Text = "添加";
            this.btnAddFitle.UseVisualStyleBackColor = true;
            this.btnAddFitle.Click += new System.EventHandler(this.btnAddFitle_Click);
            // 
            // lbFitle
            // 
            this.lbFitle.ContextMenuStrip = this.contextMenuStrip1;
            this.lbFitle.FormattingEnabled = true;
            this.lbFitle.ItemHeight = 12;
            this.lbFitle.Location = new System.Drawing.Point(24, 69);
            this.lbFitle.Name = "lbFitle";
            this.lbFitle.Size = new System.Drawing.Size(242, 88);
            this.lbFitle.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDeleteFitle});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            // 
            // tsmDeleteFitle
            // 
            this.tsmDeleteFitle.Name = "tsmDeleteFitle";
            this.tsmDeleteFitle.Size = new System.Drawing.Size(98, 22);
            this.tsmDeleteFitle.Text = "删除";
            this.tsmDeleteFitle.Click += new System.EventHandler(this.tsmDeleteFitle_Click);
            // 
            // tbFitle
            // 
            this.tbFitle.Location = new System.Drawing.Point(24, 31);
            this.tbFitle.Name = "tbFitle";
            this.tbFitle.Size = new System.Drawing.Size(153, 21);
            this.tbFitle.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbNum);
            this.groupBox5.Location = new System.Drawing.Point(9, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(282, 57);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "请输入码个数";
            // 
            // tbNum
            // 
            this.tbNum.Location = new System.Drawing.Point(69, 23);
            this.tbNum.Name = "tbNum";
            this.tbNum.Size = new System.Drawing.Size(139, 21);
            this.tbNum.TabIndex = 0;
            this.tbNum.TextChanged += new System.EventHandler(this.tbNum_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.tbOkRate);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.tbNgCount);
            this.groupBox4.Controls.Add(this.btnReset);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbOkCount);
            this.groupBox4.Location = new System.Drawing.Point(12, 172);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(282, 179);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "统计";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "良率";
            // 
            // tbOkRate
            // 
            this.tbOkRate.Location = new System.Drawing.Point(92, 104);
            this.tbOkRate.Name = "tbOkRate";
            this.tbOkRate.ReadOnly = true;
            this.tbOkRate.Size = new System.Drawing.Size(152, 21);
            this.tbOkRate.TabIndex = 5;
            this.tbOkRate.Text = "0";
            this.tbOkRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "NG次数";
            // 
            // tbNgCount
            // 
            this.tbNgCount.Location = new System.Drawing.Point(92, 70);
            this.tbNgCount.Name = "tbNgCount";
            this.tbNgCount.ReadOnly = true;
            this.tbNgCount.Size = new System.Drawing.Size(152, 21);
            this.tbNgCount.TabIndex = 3;
            this.tbNgCount.Text = "0";
            this.tbNgCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(92, 133);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(152, 29);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "清零";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "OK次数";
            // 
            // tbOkCount
            // 
            this.tbOkCount.Location = new System.Drawing.Point(92, 35);
            this.tbOkCount.Name = "tbOkCount";
            this.tbOkCount.ReadOnly = true;
            this.tbOkCount.Size = new System.Drawing.Size(152, 21);
            this.tbOkCount.TabIndex = 0;
            this.tbOkCount.Text = "0";
            this.tbOkCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStarOrStop);
            this.groupBox1.Location = new System.Drawing.Point(9, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检测";
            // 
            // btnStarOrStop
            // 
            this.btnStarOrStop.Location = new System.Drawing.Point(6, 30);
            this.btnStarOrStop.Name = "btnStarOrStop";
            this.btnStarOrStop.Size = new System.Drawing.Size(246, 44);
            this.btnStarOrStop.TabIndex = 1;
            this.btnStarOrStop.Text = "开始检测";
            this.btnStarOrStop.UseVisualStyleBackColor = true;
            this.btnStarOrStop.Click += new System.EventHandler(this.btnStarOrStop_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(943, 636);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(637, 630);
            this.panel2.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.Controls.Add(this.lbData, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.WindowImage, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(637, 630);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbData
            // 
            this.lbData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbData.FormattingEnabled = true;
            this.lbData.HorizontalScrollbar = true;
            this.lbData.ItemHeight = 12;
            this.lbData.Location = new System.Drawing.Point(440, 3);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(194, 624);
            this.lbData.TabIndex = 2;
            // 
            // WindowImage
            // 
            this.WindowImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowImage.Enabled = true;
            this.WindowImage.Location = new System.Drawing.Point(3, 3);
            this.WindowImage.Name = "WindowImage";
            this.WindowImage.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WindowImage.OcxState")));
            this.WindowImage.Size = new System.Drawing.Size(431, 624);
            this.WindowImage.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnReadCode,
            this.tsReadCodeSinalStatus,
            this.toolStripDropDownButton2,
            this.tsResetSinalStatus,
            this.toolStripDropDownButton1,
            this.tsResultLable});
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(943, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsBtnReadCode
            // 
            this.tsBtnReadCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnReadCode.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnReadCode.Image")));
            this.tsBtnReadCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnReadCode.Name = "tsBtnReadCode";
            this.tsBtnReadCode.Size = new System.Drawing.Size(68, 20);
            this.tsBtnReadCode.Text = "读码信号";
            // 
            // tsReadCodeSinalStatus
            // 
            this.tsReadCodeSinalStatus.Name = "tsReadCodeSinalStatus";
            this.tsReadCodeSinalStatus.Size = new System.Drawing.Size(31, 17);
            this.tsReadCodeSinalStatus.Text = "未知";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(68, 20);
            this.toolStripDropDownButton2.Text = "复位信号";
            // 
            // tsResetSinalStatus
            // 
            this.tsResetSinalStatus.Name = "tsResetSinalStatus";
            this.tsResetSinalStatus.Size = new System.Drawing.Size(31, 17);
            this.tsResetSinalStatus.Text = "未知";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(44, 20);
            this.toolStripDropDownButton1.Text = "结果";
            // 
            // tsResultLable
            // 
            this.tsResultLable.Name = "tsResultLable";
            this.tsResultLable.Size = new System.Drawing.Size(31, 17);
            this.tsResultLable.Text = "未知";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 661);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WindowImage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnInspectSetting;
        private System.Windows.Forms.ToolStripButton tsBtnSysSetting;
        private System.Windows.Forms.ToolStripButton tsBtnComSetting;
        private System.Windows.Forms.ToolStripButton tsBtnLogin;
        private System.Windows.Forms.ToolStripButton tsBtnUpdatePwd;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbNum;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbOkCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStarOrStop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        //private AxIpeDspCtrlLib.AxIpeDspCtrl WindowImage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton tsBtnReadCode;
        private System.Windows.Forms.ToolStripStatusLabel tsReadCodeSinalStatus;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripStatusLabel tsResetSinalStatus;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripStatusLabel tsResultLable;
        private System.Windows.Forms.ToolStripButton tsBtnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNgCount;
        private System.Windows.Forms.ToolStripButton tsBtnRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOkRate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbFitle;
        private System.Windows.Forms.Button btnAddFitle;
        private System.Windows.Forms.ListBox lbFitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox lbData;
        private AxIpeDspCtrlLib.AxIpeDspCtrl WindowImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteFitle;
    }
}

