using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionSystem;

namespace LG
{
    public partial class LoginForm : Form
    {
        Controler controler = Controler.Instance();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            s_Result result = controler.Login(tbPwd.Text);
            if (result.iResultCode!=0)
            {
                MessageBox.Show(result.strResultInfo);
            }
            else
            {
                Close();
            }
            
        }

        private void tbPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.btnLogin_Click(sender, e);//触发button事件  
            }
        }
    }
}
