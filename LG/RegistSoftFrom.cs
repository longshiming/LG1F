using SapAppliary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LG
{
    public partial class RegistSoftFrom : Form
    {
        public RegistSoftFrom()
        {
            InitializeComponent();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbLicense.Text))
            {
                MessageBox.Show("注册码请通过注册机生成！");
                return;
            }
            RegistSoftware.Regedit(tbSerialNumber.Text, tbLicense.Text, 1);
            RegistSoft_Load(null, null);
        }

        //未注册模式
        private void SetUnDrogStatus()
        {
            labStatus.Text = "～未激活";
            tbSerialNumber.Text = RegistSoftware.GetSiteMessage();
            tbLicense.Enabled = true;
            btnActive.Enabled = true;
        }
        //已注册
        private void SetDrogStatus()
        {
            labStatus.Text = "～已激活";
            tbSerialNumber.Text = RegistSoftware.GetSiteMessage();
            tbLicense.Enabled = false;
            btnActive.Enabled = false;
        }

        private void RegistSoft_Load(object sender, EventArgs e)
        {
            if (RegistSoftware.CheckRegeditInfo(1))
            {
                SetDrogStatus();
            }
            else
            {
                SetUnDrogStatus();
            }
        }
    }
}
