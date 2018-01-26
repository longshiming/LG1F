namespace LG
{
    partial class SystemSetting
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
            this.cbDebug = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbComCd = new System.Windows.Forms.TextBox();
            this.tbEndStr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbPmCd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbReadCodeCd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbDebug
            // 
            this.cbDebug.AutoSize = true;
            this.cbDebug.Location = new System.Drawing.Point(100, 31);
            this.cbDebug.Name = "cbDebug";
            this.cbDebug.Size = new System.Drawing.Size(72, 16);
            this.cbDebug.TabIndex = 2;
            this.cbDebug.Text = "调试模式";
            this.cbDebug.UseVisualStyleBackColor = true;
            this.cbDebug.CheckedChanged += new System.EventHandler(this.cbDebug_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "串口CD(ms)";
            // 
            // tbComCd
            // 
            this.tbComCd.Location = new System.Drawing.Point(185, 63);
            this.tbComCd.Name = "tbComCd";
            this.tbComCd.Size = new System.Drawing.Size(100, 21);
            this.tbComCd.TabIndex = 4;
            // 
            // tbEndStr
            // 
            this.tbEndStr.Location = new System.Drawing.Point(185, 99);
            this.tbEndStr.Name = "tbEndStr";
            this.tbEndStr.Size = new System.Drawing.Size(100, 21);
            this.tbEndStr.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "串口结束符";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(141, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 33);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbPmCd
            // 
            this.tbPmCd.Location = new System.Drawing.Point(185, 132);
            this.tbPmCd.Name = "tbPmCd";
            this.tbPmCd.Size = new System.Drawing.Size(100, 21);
            this.tbPmCd.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "误触发CD(ms)";
            // 
            // tbReadCodeCd
            // 
            this.tbReadCodeCd.Location = new System.Drawing.Point(182, 165);
            this.tbReadCodeCd.Name = "tbReadCodeCd";
            this.tbReadCodeCd.Size = new System.Drawing.Size(103, 21);
            this.tbReadCodeCd.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "读码延时(ms)";
            // 
            // SystemSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 304);
            this.Controls.Add(this.tbReadCodeCd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPmCd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbEndStr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbComCd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDebug);
            this.Name = "SystemSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SystemSetting";
            this.Load += new System.EventHandler(this.SystemSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbDebug;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbComCd;
        private System.Windows.Forms.TextBox tbEndStr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbPmCd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbReadCodeCd;
        private System.Windows.Forms.Label label4;
    }
}