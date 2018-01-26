namespace LG
{
    partial class RegistSoftFrom
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
            this.labStatus = new System.Windows.Forms.Label();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.tbLicense = new System.Windows.Forms.TextBox();
            this.btnActive = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Location = new System.Drawing.Point(201, 38);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(53, 12);
            this.labStatus.TabIndex = 0;
            this.labStatus.Text = "～未激活";
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Location = new System.Drawing.Point(153, 84);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.ReadOnly = true;
            this.tbSerialNumber.Size = new System.Drawing.Size(220, 21);
            this.tbSerialNumber.TabIndex = 1;
            // 
            // tbLicense
            // 
            this.tbLicense.Location = new System.Drawing.Point(153, 135);
            this.tbLicense.Name = "tbLicense";
            this.tbLicense.Size = new System.Drawing.Size(220, 21);
            this.tbLicense.TabIndex = 2;
            // 
            // btnActive
            // 
            this.btnActive.Location = new System.Drawing.Point(98, 182);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(275, 27);
            this.btnActive.TabIndex = 3;
            this.btnActive.Text = "激活";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "激活码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "序列号";
            // 
            // RegistSoftFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.tbLicense);
            this.Controls.Add(this.tbSerialNumber);
            this.Controls.Add(this.labStatus);
            this.Name = "RegistSoftFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RegistSoft";
            this.Load += new System.EventHandler(this.RegistSoft_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.TextBox tbLicense;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}