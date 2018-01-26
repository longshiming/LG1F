namespace LG
{
    partial class InspectSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectSetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnInspectContinue = new System.Windows.Forms.Button();
            this.btnInspectOne = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.HS_Resize = new System.Windows.Forms.HScrollBar();
            this.VS_Resize = new System.Windows.Forms.VScrollBar();
            this.VS_Move = new System.Windows.Forms.VScrollBar();
            this.HS_Move = new System.Windows.Forms.HScrollBar();
            this.imageWindow = new AxIpeDspCtrlLib.AxIpeDspCtrl();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnInspectContinue);
            this.groupBox1.Controls.Add(this.btnInspectOne);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 84);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检测";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(201, 30);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 30);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止检测";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnInspectContinue
            // 
            this.btnInspectContinue.Location = new System.Drawing.Point(109, 30);
            this.btnInspectContinue.Name = "btnInspectContinue";
            this.btnInspectContinue.Size = new System.Drawing.Size(75, 30);
            this.btnInspectContinue.TabIndex = 1;
            this.btnInspectContinue.Text = "连续检测";
            this.btnInspectContinue.UseVisualStyleBackColor = true;
            this.btnInspectContinue.Click += new System.EventHandler(this.btnInspectContinue_Click);
            // 
            // btnInspectOne
            // 
            this.btnInspectOne.Location = new System.Drawing.Point(17, 30);
            this.btnInspectOne.Name = "btnInspectOne";
            this.btnInspectOne.Size = new System.Drawing.Size(75, 30);
            this.btnInspectOne.TabIndex = 0;
            this.btnInspectOne.Text = "检测一次";
            this.btnInspectOne.UseVisualStyleBackColor = true;
            this.btnInspectOne.Click += new System.EventHandler(this.btnInspectOne_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.Label7);
            this.groupBox3.Controls.Add(this.Label6);
            this.groupBox3.Controls.Add(this.HS_Resize);
            this.groupBox3.Controls.Add(this.VS_Resize);
            this.groupBox3.Controls.Add(this.VS_Move);
            this.groupBox3.Controls.Add(this.HS_Move);
            this.groupBox3.Location = new System.Drawing.Point(12, 172);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 165);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "修改检测参数";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(94, 113);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(182, 32);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(81, 15);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "调整ROI尺寸";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(24, 32);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(68, 15);
            this.Label6.TabIndex = 10;
            this.Label6.Text = "移动ROI";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HS_Resize
            // 
            this.HS_Resize.Location = new System.Drawing.Point(206, 81);
            this.HS_Resize.Maximum = 10000;
            this.HS_Resize.Name = "HS_Resize";
            this.HS_Resize.Size = new System.Drawing.Size(44, 12);
            this.HS_Resize.TabIndex = 9;
            this.HS_Resize.Value = 5000;
            this.HS_Resize.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HS_Resize_Scroll);
            // 
            // VS_Resize
            // 
            this.VS_Resize.Location = new System.Drawing.Point(222, 66);
            this.VS_Resize.Maximum = 10000;
            this.VS_Resize.Name = "VS_Resize";
            this.VS_Resize.Size = new System.Drawing.Size(12, 41);
            this.VS_Resize.TabIndex = 8;
            this.VS_Resize.Value = 5000;
            this.VS_Resize.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VS_Resize_Scroll);
            // 
            // VS_Move
            // 
            this.VS_Move.Location = new System.Drawing.Point(51, 66);
            this.VS_Move.Maximum = 10000;
            this.VS_Move.Name = "VS_Move";
            this.VS_Move.Size = new System.Drawing.Size(12, 41);
            this.VS_Move.TabIndex = 7;
            this.VS_Move.Value = 5000;
            this.VS_Move.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VS_Move_Scroll);
            // 
            // HS_Move
            // 
            this.HS_Move.Location = new System.Drawing.Point(35, 81);
            this.HS_Move.Maximum = 10000;
            this.HS_Move.Name = "HS_Move";
            this.HS_Move.Size = new System.Drawing.Size(44, 12);
            this.HS_Move.TabIndex = 6;
            this.HS_Move.Value = 5000;
            this.HS_Move.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HS_Move_Scroll);
            // 
            // imageWindow
            // 
            this.imageWindow.Enabled = true;
            this.imageWindow.Location = new System.Drawing.Point(325, 12);
            this.imageWindow.Name = "imageWindow";
            this.imageWindow.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("imageWindow.OcxState")));
            this.imageWindow.Size = new System.Drawing.Size(656, 527);
            this.imageWindow.TabIndex = 8;
            // 
            // InspectSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 601);
            this.Controls.Add(this.imageWindow);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "InspectSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InspectSetting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InspectSetting_FormClosing);
            this.Load += new System.EventHandler(this.InspectSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageWindow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnInspectContinue;
        private System.Windows.Forms.Button btnInspectOne;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.HScrollBar HS_Resize;
        internal System.Windows.Forms.VScrollBar VS_Resize;
        internal System.Windows.Forms.VScrollBar VS_Move;
        internal System.Windows.Forms.HScrollBar HS_Move;
        private AxIpeDspCtrlLib.AxIpeDspCtrl imageWindow;
    }
}