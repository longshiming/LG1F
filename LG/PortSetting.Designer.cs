namespace LG
{
    partial class PortSetting
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
            this.txDataBits = new System.Windows.Forms.TextBox();
            this.txBaudRate = new System.Windows.Forms.TextBox();
            this.txPortName = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txDataBits
            // 
            this.txDataBits.Location = new System.Drawing.Point(126, 99);
            this.txDataBits.Name = "txDataBits";
            this.txDataBits.Size = new System.Drawing.Size(91, 21);
            this.txDataBits.TabIndex = 57;
            // 
            // txBaudRate
            // 
            this.txBaudRate.Location = new System.Drawing.Point(126, 59);
            this.txBaudRate.Name = "txBaudRate";
            this.txBaudRate.Size = new System.Drawing.Size(91, 21);
            this.txBaudRate.TabIndex = 56;
            // 
            // txPortName
            // 
            this.txPortName.Location = new System.Drawing.Point(126, 19);
            this.txPortName.Name = "txPortName";
            this.txPortName.Size = new System.Drawing.Size(91, 21);
            this.txPortName.TabIndex = 55;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(67, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 54;
            this.label21.Text = "串口选择";
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Location = new System.Drawing.Point(157, 219);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(60, 23);
            this.btnConfirm.TabIndex = 53;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cbParity.Location = new System.Drawing.Point(126, 179);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(91, 20);
            this.cbParity.TabIndex = 52;
            // 
            // cbStopBits
            // 
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Items.AddRange(new object[] {
            "None",
            "One",
            "Two",
            "OnePointFive"});
            this.cbStopBits.Location = new System.Drawing.Point(126, 139);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(91, 20);
            this.cbStopBits.TabIndex = 51;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(67, 62);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 47;
            this.label19.Text = "波特率";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(67, 182);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 50;
            this.label16.Text = "奇偶校验";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(67, 102);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 48;
            this.label18.Text = "数据位";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(67, 142);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 49;
            this.label17.Text = "停止位";
            // 
            // PortSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txDataBits);
            this.Controls.Add(this.txBaudRate);
            this.Controls.Add(this.txPortName);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cbParity);
            this.Controls.Add(this.cbStopBits);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Name = "PortSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PortSetting";
            this.Load += new System.EventHandler(this.PortSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txDataBits;
        private System.Windows.Forms.TextBox txBaudRate;
        private System.Windows.Forms.TextBox txPortName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
    }
}