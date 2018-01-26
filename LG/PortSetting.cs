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
    public partial class PortSetting : Form
    {
        Controler controler = Controler.Instance();

        public PortSetting()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //传递串口参数
                //串口号
                controler.config.m_iComPort = Convert.ToInt32(txPortName.Text);
                //波特率
                controler.config.m_iComBaudRate = Convert.ToInt32(txBaudRate.Text);
                //数据位
                controler.config.m_iComDataBits = Convert.ToInt32(txDataBits.Text);
                //校验位
                switch (cbParity.SelectedIndex)
                {
                    case 0:
                        controler.config.m_iComParity = "None";
                        break;
                    case 1:
                        controler.config.m_iComParity = "Odd";
                        break;
                    case 2:
                        controler.config.m_iComParity = "Even";
                        break;
                    case 3:
                        controler.config.m_iComParity = "Mark";
                        break;
                    case 4:
                        controler.config.m_iComParity = "Space";
                        break;
                }
                //停止位
                switch (cbStopBits.SelectedIndex)
                {
                    case 0:
                        controler.config.m_iComStopBits = "None";
                        break;
                    case 1:
                        controler.config.m_iComStopBits = "One";
                        break;
                    case 2:
                        controler.config.m_iComStopBits = "Two";
                        break;
                    case 3:
                        controler.config.m_iComStopBits = "OnePointFive";
                        break;
                }
                controler.CreateDirectoryEx(Common.configFilePath);
                //保存串口参数到ini文件
                ZazaniaoDll.WritePrivateProfileString("COM", "m_iComPort", Convert.ToString(controler.config.m_iComPort), Common.configFilePath);
                ZazaniaoDll.WritePrivateProfileString("COM", "m_iComBaudRate", Convert.ToString(controler.config.m_iComBaudRate), Common.configFilePath);
                ZazaniaoDll.WritePrivateProfileString("COM", "m_iComDataBits", Convert.ToString(controler.config.m_iComDataBits), Common.configFilePath);
                ZazaniaoDll.WritePrivateProfileString("COM", "m_iComParity", controler.config.m_iComParity, Common.configFilePath);
                ZazaniaoDll.WritePrivateProfileString("COM", "m_iComStopBits", controler.config.m_iComStopBits, Common.configFilePath);

                Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("保存出现异常");
                controler.log.LogErr(ex);
            }
        }

        private void PortSetting_Load(object sender, EventArgs e)
        {
            //串口号
            txPortName.Text = controler.config.m_iComPort.ToString();
            //波特率
            txBaudRate.Text = controler.config.m_iComBaudRate.ToString();
            //数据位
            txDataBits.Text = controler.config.m_iComDataBits.ToString();
            //停止位
            switch (controler.config.m_iComStopBits)
            {
                case "None":
                    cbStopBits.SelectedIndex = 0;
                    break;
                case "One":
                    cbStopBits.SelectedIndex = 1;
                    break;
                case "Two":
                    cbStopBits.SelectedIndex = 2;
                    break;
                case "OnePointFive":
                    cbStopBits.SelectedIndex = 3;
                    break;
            }

            //校验位
            switch (controler.config.m_iComParity)
            {
                case "None":
                    cbParity.SelectedIndex = 0;
                    break;
                case "Odd":
                    cbParity.SelectedIndex = 1;
                    break;
                case "Even":
                    cbParity.SelectedIndex = 2;
                    break;
                case "Mark":
                    cbParity.SelectedIndex = 3;
                    break;
                case "Space":
                    cbParity.SelectedIndex = 4;
                    break;
            }
        }
    }
}
