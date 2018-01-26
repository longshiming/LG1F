using csIOC0640;
using SapAppliary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionSystem;

namespace LG
{
    public partial class MainForm : Form
    {

        private Controler controler = Controler.Instance();

        //private SerialPort m_Com;
        bool bContinuous = false;
        List<string> strTempList = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            s_Result result;
            result = controler.InitIoCard();
            if (result.iResultCode != 0)
            {
                MessageBox.Show(result.strResultInfo);
                return;
            }
            result = controler.EngInitialize();
            if (result.iResultCode != 0)
            {
                MessageBox.Show(result.strResultInfo);
                return;
            }
            controler.RunCompleted += new RunCompleted(OnRunCompletedCallBack);
            controler.RegistVisionSystemCallBack();
            controler.ShowResult += new ShowResult(ShowResultCallBack);
            controler.ShowReadCodeSinal += new ShowReadCodeSinal(ShowReadCodeSinalCallBack);
            controler.ShowResetSinal += new ShowResetSinal(ShowResetSinalCallBack);
            controler.ShowCount += new ShowCount(ShowCountCallBack);
            controler.ShowDataList += new ShowDataList(ShowDataListCallBack);

            controler.m_Com = new SerialPort("COM" + Convert.ToString(controler.config.m_iComPort));
            // m_Com.NewDataReceived += new EventHandler<DataEventArgs>(Com_NewDataReceived);

        }

        private void ShowDataListCallBack(List<string> strList)
        {
            try
            {


                //this.BeginInvoke(new MethodInvoker(delegate
                //{
                //    lbData.Items.Clear();
                //    //strTempList.Clear();
                //    //strTempList.AddRange(strList);
                //    Console.WriteLine("strList.Count == " + strList.Count);
                //    foreach (string item in strList)
                //    {
                //        Console.WriteLine("=====sdffg== " + item);
                //        lbData.Items.Add(item);
                //    }
                //    //    //lbData.Items.AddRange(strList.ToArray());
                //}));
            }
            catch (Exception ex)
            {
                controler.log.LogErr(ex);
                Console.WriteLine("ShowDataListCallBack ex == " + ex.ToString());
            }
        }

        private void ShowCountCallBack()
        {
            try
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    tbOkCount.Text = Convert.ToString(controler.okCount);
                    tbNgCount.Text = Convert.ToString(controler.ngCount);
                    if (controler.okCount + controler.ngCount == 0)
                    {
                        tbOkRate.Text = "0%";
                    }
                    else
                    {
                        tbOkRate.Text = Math.Round(controler.okCount * 100.0 / (controler.okCount + controler.ngCount), 2) + "%";
                    }
                }));
                
            }
            catch (Exception ex)
            {
                controler.log.LogErr(ex);
            }
            
        }

        //private void Com_NewDataReceived(object sender, DataEventArgs e)
        //{

        //}

        private void ShowResetSinalCallBack(string str)
        {
            try
            {
                this.BeginInvoke(new MethodInvoker(delegate {
                    tsResetSinalStatus.Text = str;
                }));
            }
            catch (Exception ex)
            {
                controler.log.LogErr(ex);
            }
            
            
        }

        private void ShowReadCodeSinalCallBack(string str)
        {
            try
            {
                this.BeginInvoke(new MethodInvoker(delegate {
                    tsReadCodeSinalStatus.Text = str;
                }));
            }
            catch (Exception ex)
            {
                controler.log.LogErr(ex);
            }

            
        }

        private void ShowResultCallBack(string str)
        {
            
            try
            {
                this.BeginInvoke(new MethodInvoker(delegate {
                    tsResultLable.Text = str;
                }));
            }
            catch (Exception ex)
            {
                controler.log.LogErr(ex);
            }
        }

        private void OnRunCompletedCallBack()
        {
            try
            {
                //Array strs;
                // controler.visionSystem.VarGetStringArray("codeDatas", out strs);

               
            }
            catch (System.Exception ex)
            {
                controler.log.LogErr(ex);
            }


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (RegistSoftware.CheckRegeditInfo(1))
            {
                tsBtnInspectSetting.Enabled = false;
                tsBtnSysSetting.Enabled = false;
                tsBtnComSetting.Enabled = false;
                tbOkCount.Text = Convert.ToString(controler.okCount);
                tbNgCount.Text = Convert.ToString(controler.ngCount);
                if (controler.okCount+controler.ngCount==0)
                {
                    tbOkRate.Text = "0%";
                }
                else
                {
                    tbOkRate.Text = Math.Round(controler.okCount * 100.0 / (controler.okCount + controler.ngCount), 2) + "%";
                }
                s_Result result;
                result = controler.loadConfig();
                if (result.iResultCode != 0)
                {
                    MessageBox.Show(result.strResultInfo);
                    return;
                }

                result = controler.InvLoad(Common.ivsPath);
                if (result.iResultCode != 0)
                {
                    MessageBox.Show(result.strResultInfo);
                    tsBtnLogin.Enabled = false;
                    btnStarOrStop.Enabled = false;
                    return;
                }
                controler.ConnectEngine(WindowImage, "imgA");

                controler.visionSystem.VarSetBool("bSetShutter", true);
                //bool b;
                //controler.visionSystem.VarGetBool("bSetShutter",out b);
                //Console.WriteLine("======== b ========= " + b);

            }
            else
            {
                tableLayoutPanel1.Enabled = false;

                tsBtnInspectSetting.Enabled = false;
                tsBtnSysSetting.Enabled = false;
                tsBtnComSetting.Enabled = false;
                tsBtnLogin.Enabled = false;
                tsBtnUpdatePwd.Enabled = false;
                tsBtnExit.Enabled = false;
                MessageBox.Show("软件未授权,请尽快联系厂商！");
            }
            
        }

        /// <summary>
        /// 窗口关闭回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bContinuous == true)//if Investigating Continuous, Halt Inspection
            {
                controler.HaltInv();
            }
            controler.CloseIoCard();

            controler.RunCompleted -= new RunCompleted(OnRunCompletedCallBack);
            controler.UnRegistVisionSystemCallBack();
            controler.ShowResult -= new ShowResult(ShowResultCallBack);
            controler.ShowReadCodeSinal -= new ShowReadCodeSinal(ShowReadCodeSinalCallBack);
            controler.ShowResetSinal -= new ShowResetSinal(ShowResetSinalCallBack);
            controler.ShowCount -= new ShowCount(ShowCountCallBack);
            WindowImage.DisconnectImgWindow();//disconnect display window
        }

        /// <summary>
        /// 开始或停止检测回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStarOrStop_Click(object sender, EventArgs e)
        {

            try
            {
                controler.expectCount = Convert.ToInt32(tbNum.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请先输入正确格式的码个数");
                return;
            }
            try
            {
                if (btnStarOrStop.Text == "开始检测")
                {
                    controler.strList.Clear();
                    ControlBox = false;
                    controler.SetThreadIsRun(true);
                    controler.startSendDataThread();
                    controler.startReadCodeThread();
                    timer2.Enabled = true;
                    btnStarOrStop.Text = "停止检测";
                    toolStrip1.Enabled = false;
                }
                else
                {
                    if (controler.strQueue.Count>0)
                    {
                        MessageBox.Show("数据正在传输中，请稍候再停！");
                        return;
                    }
                    controler.SetThreadIsRun(false);
                    timer2.Enabled = false;
                    btnStarOrStop.Text = "开始检测";
                    toolStrip1.Enabled = true;
                    controler.strList.Clear();
                    ControlBox = true;
                }


            }
            catch (System.Exception ex)
            {
                controler.log.LogErr(ex);
            }
        }

       

        /// <summary>
        /// 时钟2回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            controler.DoTimer2();
        }

        private void tsBtnInspectSetting_Click(object sender, EventArgs e)
        {
            controler.RunCompleted -= new RunCompleted(OnRunCompletedCallBack);
            InspectSetting inspectSetting = new InspectSetting();
            inspectSetting.ShowDialog();
            controler.ConnectEngine(WindowImage, "imgA");
            controler.RunCompleted += new RunCompleted(OnRunCompletedCallBack);
        }

        private void tsBtnUpdatePwd_Click(object sender, EventArgs e)
        {
            UpdatePwdForm updatePwdForm = new UpdatePwdForm();
            updatePwdForm.ShowDialog();
            
        }

        private void tsBtnLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (controler.config.isLogin)
            {
                tsBtnInspectSetting.Enabled = true;
                tsBtnSysSetting.Enabled = true;
                tsBtnComSetting.Enabled = true;
            }
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            tsBtnInspectSetting.Enabled = false;
            tsBtnSysSetting.Enabled = false;
            tsBtnComSetting.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            controler.okCount = 0;
            controler.ngCount = 0;
            tbOkCount.Text = Convert.ToString(controler.okCount);
            tbNgCount.Text= Convert.ToString(controler.ngCount);
            tbOkRate.Text = "0%";
        }

        private void tsBtnComSetting_Click(object sender, EventArgs e)
        {
            try
            {
                PortSetting portSetting = new PortSetting();
                portSetting.ShowDialog();

                controler.m_Com.close();
                controler.m_Com = new SerialPort("COM" + Convert.ToString(controler.config.m_iComPort));
                //m_Com.NewDataReceived += new EventHandler<DataEventArgs>(Com_NewDataReceived);

            }
            catch (System.Exception ex)
            {
                controler.log.LogErr(ex);
            }
        }

        private void tsBtnRegister_Click(object sender, EventArgs e)
        {
            RegistSoftFrom rsf = new RegistSoftFrom();
            rsf.ShowDialog();

            if (RegistSoftware.CheckRegeditInfo(1))
            {
                tableLayoutPanel1.Enabled = true;
                
                tsBtnLogin.Enabled = true;
                tsBtnUpdatePwd.Enabled = true;
                tsBtnExit.Enabled = true;
            }

        }

        private void tsBtnSysSetting_Click(object sender, EventArgs e)
        {
            SystemSetting sys = new SystemSetting();
            sys.ShowDialog();
        }

       

        private void tbNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                controler.expectCount = Convert.ToInt32(tbNum.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请先输入正确格式的码个数");
            }
        }

        private void btnAddFitle_Click(object sender, EventArgs e)
        {
            try
            {
                string temp = tbFitle.Text;
                if (string.IsNullOrEmpty(temp))
                {
                    MessageBox.Show("请先输入过滤字符！");
                }
                else
                {
                    lbFitle.Items.Add(temp);
                    controler.strFitle.Add(temp);
                }
                
            }
            catch (Exception ex)
            {
                controler.log.LogErr(ex);
            }
            
        }

        

        private void tsmDeleteFitle_Click(object sender, EventArgs e)
        {
            try
            {
                string temp = lbFitle.SelectedItem.ToString();
                if (string.IsNullOrEmpty(temp))
                {
                    MessageBox.Show("请先选中需要删除的过滤字符！");
                }
                else
                {
                    lbFitle.Items.Remove(temp);
                    controler.strFitle.Remove(temp);
                }

            }
            catch (Exception ex)
            {
                controler.log.LogErr(ex);
            }
        }
    }
}
