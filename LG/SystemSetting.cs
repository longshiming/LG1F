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
using Zazaniao;

namespace LG
{
    public partial class SystemSetting : Form
    {
        Controler controler = Controler.Instance();
        public SystemSetting()
        {
            InitializeComponent();
        }

        private void SystemSetting_Load(object sender, EventArgs e)
        {
            cbDebug.Checked = controler.config.isDebug;
            tbComCd.Text = Convert.ToString(controler.config.comCd);
            tbPmCd.Text = Convert.ToString(controler.config.pmCd);
            tbReadCodeCd.Text = Convert.ToString(controler.config.readCodeCd);
            tbEndStr.Text = controler.config.comEndStr;
        }

        private void cbDebug_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                controler.config.isDebug = cbDebug.Checked;
                //controler.CreateDirectoryEx(Common.configFilePath);
                //ZazaniaoDll.WritePrivateProfileString("SYS", "isDebug", Convert.ToString(controler.config.isDebug), Common.configFilePath);
            }
            catch (System.Exception ex)
            {
                controler.log.LogErr(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                controler.config.comCd = Convert.ToInt32(tbComCd.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确格式的串口CD");
                return;
            }

            try
            {
                controler.config.pmCd = Convert.ToInt32(tbPmCd.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确格式的产品CD");
                return;
            }

            try
            {
                controler.config.readCodeCd = Convert.ToInt32(tbReadCodeCd.Text);
                if (controler.config.readCodeCd < 200)
                {
                    MessageBox.Show("读码延时必须大于等于200");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确格式的读码延时");
                return;
            }

            try
            {
                //controler.config.isDebug = cbDebug.Checked;
                controler.config.comEndStr = tbEndStr.Text;
                if (controler.config.comEndStr == string.Empty)
                {
                    MessageBox.Show("请输入串口结束符");
                    return;
                }
                
                controler.CreateDirectoryEx(Common.configFilePath);
                ZazaniaoDll.WritePrivateProfileString("SYS", "isDebug", Convert.ToString(controler.config.isDebug), Common.configFilePath);

                ZazaniaoDll.WritePrivateProfileString("SYS", "comCd", Convert.ToString(controler.config.comCd), Common.configFilePath);
                ZazaniaoDll.WritePrivateProfileString("SYS", "comEndStr", Convert.ToString(controler.config.comEndStr), Common.configFilePath);
                ZazaniaoDll.WritePrivateProfileString("SYS", "pmCd", Convert.ToString(controler.config.pmCd), Common.configFilePath);
                Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("保存异常");
                controler.log.LogErr(ex);
            }
        }
    }
}
