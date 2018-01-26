using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionSystem;

namespace LG
{
    public partial class UpdatePwdForm : Form
    {
        Controler controler = Controler.Instance();

        public UpdatePwdForm()
        {
            InitializeComponent();
        }

        private void tbSurePwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.btnLogin_Click(sender, e);//触发button事件  
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            s_Result result = controler.UpdatePwd(tbOldPwd.Text, tbNewPwd.Text, tbSurePwd.Text);
            if (result.iResultCode != 0)
            {
                MessageBox.Show(result.strResultInfo);
            }
            else
            {
                Close();
            }
        }
    }
}
