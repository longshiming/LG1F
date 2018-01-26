
using IpeEngCtrlLib;
using System;
using System.Text;
using Zazaniao;
using System.IO;
using System.Windows.Forms;
using IpeDspCtrlLib;
using csIOC0640;
using System.Collections;
using System.Security.Cryptography;
using System.Threading;
using System.Collections.Generic;

namespace VisionSystem
{

    public delegate void RunCompleted();
    public delegate void EnableBtn(bool b);
    public delegate void ShowResult(string str);
    public delegate void ShowReadCodeSinal(string str);
    public delegate void ShowResetSinal(string str);
    public delegate void ShowCount();
    public delegate void ShowDataList(List<string> strList);


    public struct s_Result
    {
        public int iResultCode;					// 结果代码
        public string strResultInfo;				// 结果描述
    }

    class Controler
    {
        private static Controler instance = null;
        public Engine visionSystem = new Engine();
        public Config config = new Config();
        public Log log = new Log();
        public event RunCompleted RunCompleted;
        public event EnableBtn EnableBtn;
        public event ShowResult ShowResult;
        public event ShowCount ShowCount;
        public event ShowDataList ShowDataList;
        public event ShowReadCodeSinal ShowReadCodeSinal;
        public event ShowResetSinal ShowResetSinal;
        IpeEngCtrlLib.I_MODE iCurrMode;
        public bool isContinuous = true;

        //public bool bSensor1T2F = false;
        //public bool bSensor2F2T = false;
        public bool bSensor1 = false, bOldSensor1 = false, bSensor2 = false;
        public int expectCount = 0;
        public int okCount = 0,ngCount=0;
        //public ArrayList strList = new ArrayList();
        public List<string> strList = new List<string>();
        //public List<string> strListLast = new List<string>();

        public List<string> strFitle = new List<string>();

        //public List<string> strListSend = new List<string>();
        public SerialPort m_Com;
        public bool bFirst = true;
        TimeSpan t1, t2;

        bool is_ReadCodeThreadRun = true;
        bool is_SendDataThreadRun = true;

        Array strs;

        bool bChangeSetShutter = true;

        bool bSend = true;


        //备用
        public Queue<string> strQueue = new Queue<string>();

        private Controler()
        {
        }

        public static Controler Instance()
        {
            if (instance == null)
            {
                instance = new Controler();
            }

            return instance;
        }

        /// <summary>
        /// 初始化引擎
        /// </summary>
        /// <returns></returns>
        public s_Result EngInitialize()
        {
            s_Result result;
            I_ENG_ERROR iReturn;
            iReturn = visionSystem.EngInitialize();

            if (iReturn == I_ENG_ERROR.I_OK)
            {

                result.iResultCode = 0;
                result.strResultInfo = "引擎初始化成功";
            }
            else
            {
                result.iResultCode = (int)iReturn;
                result.strResultInfo = "引擎初始化失败";
            }
            return result;
        }


        /// <summary>
        /// 关闭io卡
        /// </summary>
        public void CloseIoCard()
        {
            IOC0640.ioc_board_close();
        }

        /// <summary>
        /// 初始化控制卡
        /// </summary>
        /// <returns></returns>
        public s_Result InitIoCard()
        {

            s_Result result;
            try
            {
                int nCard = 0;
                nCard = IOC0640.ioc_board_init();
                if (nCard <= 0)//控制卡初始化
                {
                    result.iResultCode = 1;
                    result.strResultInfo = "未找到IOC0640控制卡!";
                }
                else
                {
                    result.iResultCode = 0;
                    result.strResultInfo = "控制卡初始化正常";
                }

            }
            catch (Exception ex)
            {
                result.iResultCode = -1;
                result.strResultInfo = "控制卡初始化过程异常";
                log.LogErr(ex);
            }


            return result;
        }

        /// <summary>
        /// 注册回掉
        /// </summary>
        public void RegistVisionSystemCallBack()
        {
            visionSystem.RunCompleted +=
                new IpeEngCtrlLib._IEngineEvents_RunCompletedEventHandler(VisionSystem_RunCompleted);

        }

        public void UnRegistVisionSystemCallBack()
        {
            visionSystem.RunCompleted -=
                new IpeEngCtrlLib._IEngineEvents_RunCompletedEventHandler(VisionSystem_RunCompleted);
        }

        private void VisionSystem_RunCompleted()
        {
            if (RunCompleted != null)
            {
                RunCompleted();
            }
        }

        /// <summary>
        /// 加载ivs
        /// </summary>
        /// <returns></returns>
        public s_Result InvLoad(string path)
        {
            s_Result result;
            I_ENG_ERROR iReturn;
            iReturn = visionSystem.InvLoad(path);//load investigation
            if (iReturn == I_ENG_ERROR.I_OK)
            {
                result.iResultCode = 0;
                result.strResultInfo = "加载ivs成功";
            }
            else
            {
                result.iResultCode = (int)iReturn;
                result.strResultInfo = "加载ivs失败";
            }
            return result;
        }

        /// <summary>
        /// 连接引擎
        /// </summary>
        /// <param name="imageWindow"></param>
        public void ConnectEngine(AxIpeDspCtrlLib.AxIpeDspCtrl imageWindow,string str)
        {
            imageWindow.ConnectEngine(visionSystem.GetEngineObj());// connect display object to the VisionSystem object
            //imageWindow.ConnectImgWindow("imgA");// connect display to VisionSystem image window
            imageWindow.ConnectImgWindow(str);// connect display to VisionSystem image window
            imageWindow.SetZoom((-1));// set display zoom to stretch

        }

        //备用 =====================

        public void startSendDataThread()
        {
            Thread thread = new Thread(new ThreadStart(DoSendDataThread));
            thread.IsBackground = true;
            thread.Start();
        }

        private void DoSendDataThread()
        {

            string str = null;
            try
            {
                while (is_SendDataThreadRun)
                {

                    if (strQueue.Count > 0)
                    {
                        str = strQueue.Dequeue();
                        if (str != null)
                        {
                            Console.WriteLine("item send == " + str);
                            m_Com.sendMessage(str+"\r\n");
                            Thread.Sleep(config.comCd);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DoSendDataThread ex.ToString ==" + ex.ToString());
                Console.WriteLine("DoSendDataThread ex.StackTrace==" + ex.StackTrace);
                log.LogErr(ex);
                
            }

        }




        //======================

        public void startReadCodeThread()
        {
            Thread thread = new Thread(new ThreadStart(DoReadCoeThread));
            thread.IsBackground = true;
            thread.Start();
        }

        public void SetThreadIsRun(bool isRun)
        {
            is_ReadCodeThreadRun = isRun;
            is_SendDataThreadRun = isRun;
        }

        private void DoReadCoeThread()
        {
            try
            {
                while (is_ReadCodeThreadRun)
                {
                    bOldSensor1 = bSensor1;
                    //从io卡获取感应器1是否有信号
                    bSensor1 = GetSensor1();
                    

                    if (bSensor1)
                    {
                        if (strList.Count < expectCount)
                        {
                            if (bFirst)
                            {
                                Console.WriteLine("cccccccc");
                                t1 = new TimeSpan(DateTime.Now.Ticks);
                                bFirst = false;

                            }
                            ShowReadCodeSinal("有");


                            InspectOne();

                            if (bChangeSetShutter)
                            {
                                visionSystem.VarSetBool("bSetShutter", false);
                                bChangeSetShutter = false;
                            }

                            //Thread.Sleep(200);
                            Thread.Sleep(config.readCodeCd);

                            visionSystem.VarGetStringArray("codeDatas", out strs);



                            foreach (string item in strs)
                            {

                                if (!strList.Contains(item))
                                {

                                    if (strFitle.Count>0)
                                    {
                                        for (int i = 0; i < strFitle.Count; i++)
                                        {
                                            if (item.Contains(strFitle[i]))
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                if (i == strFitle.Count - 1)
                                                {
                                                    strList.Add(item);
                                                }
                                            }

                                        }
                                    }
                                    else
                                    {
                                        strList.Add(item);
                                    }
                                }

                            }
                        }

                        if (strList.Count == expectCount)
                        {
                            if (bSend)
                            {
                                AddToQueue();
                            }
                            
                            bSend = false;
                        }

                    }
                    else
                    {
                        ShowReadCodeSinal("无");
                        if (bOldSensor1)  //信号从有变无的那一下
                        {
                            Console.WriteLine("qqqqqqq");
                            //InspectOne();

                            bFirst = true;
                            t2 = new TimeSpan(DateTime.Now.Ticks);
                            double i = t2.Subtract(t1).Duration().TotalMilliseconds;


                            if (i > config.pmCd)
                            {

                                //ShowDataList(strList);

                                Console.WriteLine("expectCount == " + expectCount);
                                Console.WriteLine("num == " + strList.Count);
                                if (strList.Count == expectCount)
                                {
                                    Console.WriteLine("ggggggggggg");

                                    if (bSend)
                                    {
                                        AddToQueue();
                                    }
                                }
                                else
                                {
                                    foreach (string item in strList)
                                    {
                                        Console.WriteLine("fail == " + item);
                                    }

                                    //NG
                                    SetRedLampOn(true);
                                    SetProductionLineOn(false);
                                    ShowResult("NG--读码失败");
                                    ngCount++;
                                }
                               
                                ShowCount();
                                Console.WriteLine("========ShowCount()========");
                            }
                            strList.Clear();
                        }
                        else
                        {
                            bSend = true;
                        }
                        //strList.Clear();
                    }
                    
                }
               

            }
            catch (Exception ex)
            {
                log.LogErr(ex);
                strList.Clear();
                //strListSend.Clear();
                SetRedLampOn(true);
                SetProductionLineOn(false);
                ShowResult("NG--读码异常");
                ShowReadCodeSinal("未知");
                Console.WriteLine("异常 == "+ ex.ToString());
                Console.WriteLine("异常 == " + ex.StackTrace);
            }
        }

        private void AddToQueue()
        {
            foreach (string item in strList)
            {
                string[] strs = item.Split('-');
                if (strs.Length > 1)
                {

                    strQueue.Enqueue(item);

                    Console.WriteLine("add to queue == " + item);
                    break;
                }

            }
            foreach (string item in strList)
            {
                string[] strs = item.Split('-');
                if (strs.Length == 1)
                {

                    strQueue.Enqueue(item);
                    Console.WriteLine("add to queue  == " + item);
                }
            }

            //OK
            SetGreenLampOn(true);
            Thread.Sleep(5);
            SetGreenLampOn(false);
            ShowResult("OK--读码成功");
            okCount++;
        }



        /// <summary>
        /// 报警器红灯开关
        /// </summary>
        /// <param name="b"></param>
        public void SetRedLampOn(bool b)
        {
            if (b)
            {
                IOC0640.ioc_write_outbit(0, 2, 0);
            }
            else
            {
                IOC0640.ioc_write_outbit(0, 2, 1);
            }

        }

        /// <summary>
        /// 报警器绿灯开关
        /// </summary>
        /// <param name="b"></param>
        public void SetGreenLampOn(bool b)
        {
            if (b)
            {
                IOC0640.ioc_write_outbit(0, 3, 0);
            }
            else
            {
                IOC0640.ioc_write_outbit(0, 3, 1);
            }
        }


        /// <summary>
        /// 产线开关
        /// </summary>
        /// <param name="b"></param>
        public void SetProductionLineOn(bool b)
        {
            if (b)
            {
                IOC0640.ioc_write_outbit(0, 1, 1);
            }
            else
            {
                IOC0640.ioc_write_outbit(0, 1, 0);
            }
        }

        public bool GetSensor1()
        {
            return IOC0640.ioc_read_inbit(0, 1) == 0 ? true : false;
        }
        public bool GetSensor2()
        {
            return IOC0640.ioc_read_inbit(0, 2) == 0 ? true : false;
        }
        public void DoTimer2()
        {
            try
            {
                bSensor2 = GetSensor2();
                if (bSensor2)
                {
                    SetRedLampOn(false);
                    SetProductionLineOn(true);
                    ShowResult("未知");
                    ShowResetSinal("有");
                }
                else
                {
                    ShowResetSinal("无");
                }
            }
            catch (Exception ex)
            {
                log.LogErr(ex);
                ShowResetSinal("未知");
            }
        }


        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="oldPwdStr"></param>
        /// <param name="newPwdStr"></param>
        /// <param name="surePwdStr"></param>
        /// <returns></returns>
        public s_Result UpdatePwd(string oldPwdStr,string newPwdStr,string surePwdStr)
        {
            s_Result sResult;
            try
            {
                CreateDirectoryEx(Common.configFilePath);
                string pwdConfig = GetPrivateProfileString("LOGIN", "PWD", "", Common.configFilePath);
                //string str = tbOldPwd.Text;
                byte[] result = Encoding.Default.GetBytes(oldPwdStr.Trim());    //tbPass为输入密码的文本框  
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(result);
                string pwd = BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文本的文本框  
                if (pwd != pwdConfig)
                {
                    sResult.iResultCode = 1;
                    sResult.strResultInfo = "原始密码输入错误";
                    return sResult;
                    //MessageBox.Show("原始密码输入错误");
                    //return;
                }
                //string newPwdStr = tbNewPwd.Text;
                //string surePwdStr = tbSurePwd.Text;
                if (newPwdStr != surePwdStr)
                {
                    sResult.iResultCode = 2;
                    sResult.strResultInfo = "新密码和确认密码不相同";
                    return sResult;
                    //MessageBox.Show("新密码和确认密码不相同");
                    //return;
                }

                byte[] newResult = Encoding.Default.GetBytes(newPwdStr.Trim());    //tbPass为输入密码的文本框  
                byte[] newOutput = md5.ComputeHash(newResult);
                string newPwd = BitConverter.ToString(newOutput).Replace("-", "");  //tbMd5pass为输出加密文本的文本框  
                ZazaniaoDll.WritePrivateProfileString("LOGIN", "PWD", newPwd, Common.configFilePath);
                sResult.iResultCode = 0;
                sResult.strResultInfo = "修改密码成功";
                return sResult;
                //Close();
            }
            catch (System.Exception ex)
            {
                
                log.LogErr(ex);
                sResult.iResultCode = -1;
                sResult.strResultInfo = "修改密码异常";
                return sResult;
            }
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="pwdStr"></param>
        /// <returns></returns>
        public s_Result Login(string pwdStr)
        {
            s_Result sResult;
            try
            {
                CreateDirectoryEx(Common.configFilePath);
                string pwdConfig = GetPrivateProfileString("LOGIN", "PWD", "", Common.configFilePath);
                //string str = tbPwd.Text;
                byte[] result = Encoding.Default.GetBytes(pwdStr.Trim());    //tbPass为输入密码的文本框  
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(result);
                string pwd = BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文本的文本框  
                if (pwd == pwdConfig)
                {
                    config.isLogin = true;
                    sResult.iResultCode = 0;
                    sResult.strResultInfo = "登录成功";
                }
                else
                {
                    sResult.iResultCode = 1;
                    sResult.strResultInfo = "密码错误";
                }
            }
            catch (System.Exception ex)
            {
                sResult.iResultCode = -1;
                sResult.strResultInfo = "登录异常";
                log.LogErr(ex);
            }
            return sResult;
        }

        /// <summary>
        /// 单次执行
        /// </summary>
        /// <returns></returns>
        public s_Result InspectOne()
        {
            s_Result result;
            I_ENG_ERROR iReturn;
            iReturn = visionSystem.InvModeSet(IpeEngCtrlLib.I_MODE.I_EXE_MODE_ONCE);
            if (iReturn == I_ENG_ERROR.I_OK)
            {
                result.iResultCode = 0;
                result.strResultInfo = "检测成功";
            }
            else
            {
                result.iResultCode = (int)iReturn;
                result.strResultInfo = "检测失败";
            }

            return result;
        }

        /// <summary>
        /// 连续执行
        /// </summary>
        /// <returns></returns>
        public s_Result InspectContinue(bool isCallBack)
        {
            s_Result result;
            I_ENG_ERROR iReturn;
            iReturn = visionSystem.InvModeSet(IpeEngCtrlLib.I_MODE.I_EXE_MODE_CONT);
            if (iReturn == I_ENG_ERROR.I_OK)
            {
                result.iResultCode = 0;
                result.strResultInfo = "连续检测执行成功";
            }
            else
            {
                result.iResultCode = (int)iReturn;
                result.strResultInfo = "连续检测执行失败";
            }
            if (isCallBack)
            {
                OnEnableBtn(false);
            }
           

            return result;
        }

        /// <summary>
        /// 停止执行
        /// </summary>
        public void StopInspect(bool isCallBack)
        {
            HaltInv();
            if (isCallBack)
            {
                OnEnableBtn(true);
            }
            
        }

        /// <summary>
        /// 保存ivs
        /// </summary>
        /// <returns></returns>
        public s_Result InvSave(string path)
        {
            s_Result result;
            try
            {
                
                I_ENG_ERROR iReturn;
                iReturn = visionSystem.InvSave(path);
                if (iReturn == I_ENG_ERROR.I_OK)
                {
                    result.iResultCode = 0;
                    result.strResultInfo = "保存成功";
                }
                else
                {
                    result.iResultCode = (int)iReturn;
                    result.strResultInfo = "保存失败";
                }
            }
            catch (System.Exception ex)
            {
                result.iResultCode = -1;
                result.strResultInfo = "保存过程异常";
                log.LogErr(ex);
            }
            
            return result;

        }


        /// <summary>
        /// 使能按钮
        /// </summary>
        /// <param name="usable"></param>
        private void OnEnableBtn(bool usable)
        {
            EnableBtn(usable);
        }

        public void HaltInv()
        {
            try
            {
                I_ENG_ERROR iReturn;
                iReturn = visionSystem.InvModeSet(IpeEngCtrlLib.I_MODE.I_EXE_MODE_HALT); // halt inspection after current inspection is finished
                while (iCurrMode != IpeEngCtrlLib.I_MODE.I_EXE_MODE_HALT) //stay in loop until Halt is complete
                {
                    Application.DoEvents();
                    iReturn = visionSystem.InvModeGet(out iCurrMode);
                }
            }
            catch (System.Exception ex)
            {
                log.LogErr(ex);
            }
            
        }

        /// <summary>
        /// 竖向移动ROI
        /// </summary>
        /// <param name="num"></param>
        /// <param name="currentNum"></param>
        /// <param name="imageWindow"></param>
        public void VS_Move_Scroll(int num,int currentNum, AxIpeDspCtrlLib.AxIpeDspCtrl imageWindow)
        {
            try
            {
                if (num > currentNum)  // Move down 
                {
                    visionSystem.RoiMove("RectA", 0, 1);
                }
                else if (num < currentNum) // Move up
                {
                    visionSystem.RoiMove("RectA", 0, -1);
                }
                imageWindow.UpdateDisplay();
            }
            catch (System.Exception ex)
            {
                log.LogErr(ex);
            }
            
        }

        /// <summary>
        /// 横向移动ROI
        /// </summary>
        /// <param name="num"></param>
        /// <param name="currentNum"></param>
        /// <param name="imageWindow"></param>
        public void HS_Move_Scroll(int num, int currentNum, AxIpeDspCtrlLib.AxIpeDspCtrl imageWindow)
        {

            try
            {
                if (num > currentNum) //Move Right
                {
                    visionSystem.RoiMove("RectA", 1, 0);
                }
                else if (num < currentNum) //Move Left
                {
                    visionSystem.RoiMove("RectA", -1, 0);
                }
                imageWindow.UpdateDisplay();
            }
            catch (System.Exception ex)
            {
                log.LogErr(ex);
            }
            
        }

        /// <summary>
        /// 竖向改变ROI的尺寸
        /// </summary>
        /// <param name="num"></param>
        /// <param name="currentNum"></param>
        /// <param name="imageWindow"></param>
        public void VS_Resize_Scroll(int num, int currentNum, AxIpeDspCtrlLib.AxIpeDspCtrl imageWindow)
        {
            try
            {
                if (num > currentNum)// Larger Vertically
                {
                    visionSystem.RoiCoordMove("RectA", 0, 0, 1);
                    visionSystem.RoiCoordMove("RectA", 1, 0, -1);
                }
                else if (num < currentNum)// Smaller Vertically
                {
                    visionSystem.RoiCoordMove("RectA", 0, 0, -1);
                    visionSystem.RoiCoordMove("RectA", 1, 0, 1);
                }
                imageWindow.UpdateDisplay();
            }
            catch (System.Exception ex)
            {
                log.LogErr(ex);
            }
        }

        /// <summary>
        /// 横向改变ROI的尺寸
        /// </summary>
        /// <param name="num"></param>
        /// <param name="currentNum"></param>
        /// <param name="imageWindow"></param>
        public void HS_Resize_Scroll(int num, int currentNum, AxIpeDspCtrlLib.AxIpeDspCtrl imageWindow)
        {
            try
            {
                if (num > currentNum) // Larger Horizontally
                {
                    visionSystem.RoiCoordMove("RectA", 0, -1, 0);
                    visionSystem.RoiCoordMove("RectA", 1, 1, 0);
                }
                else if (num < currentNum)// Smaller Horizontally
                {
                    visionSystem.RoiCoordMove("RectA", 0, 1, 0);
                    visionSystem.RoiCoordMove("RectA", 1, -1, 0);
                }
                imageWindow.UpdateDisplay();
            }
            catch (System.Exception ex)
            {
                log.LogErr(ex);
            }
        }

        public double GetPrivateProfileDouble(string lpAppName, string lpKeyName, double Default, string lpFileName)
        {
            // char[] lpReturnedString = new char[1024];
            StringBuilder lpReturnedString = new StringBuilder(1024);
            ZazaniaoDll.GetPrivateProfileString(lpAppName, lpKeyName, Convert.ToString(Default), lpReturnedString, 1024, lpFileName);
            return Convert.ToDouble(lpReturnedString.ToString());


        }
        public int GetPrivateProfileInt(string lpAppName, string lpKeyName, int Default, string lpFileName)
        {
            //char[] lpReturnedString = new char[1024];
            StringBuilder lpReturnedString = new StringBuilder(1024);
            ZazaniaoDll.GetPrivateProfileString(lpAppName, lpKeyName, Convert.ToString(Default), lpReturnedString, 1024, lpFileName);

            return Convert.ToInt32(lpReturnedString.ToString());
        }

        public string GetPrivateProfileString(string lpAppName, string lpKeyName, string Default, string lpFileName)
        {
            StringBuilder lpReturnedString = new StringBuilder(1024);
            ZazaniaoDll.GetPrivateProfileString(lpAppName, lpKeyName, Default, lpReturnedString, 1024, lpFileName);
            return lpReturnedString.ToString();
        }

        public bool GetPrivateProfileBool(string lpAppName, string lpKeyName, bool Default, string lpFileName)
        {
            StringBuilder lpReturnedString = new StringBuilder(1024);
            ZazaniaoDll.GetPrivateProfileString(lpAppName, lpKeyName, Convert.ToString(Default), lpReturnedString, 1024, lpFileName);

            return Convert.ToBoolean(lpReturnedString.ToString());
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        public s_Result loadConfig()
        {
            s_Result result;
            try
            {
                if (!File.Exists(Common.configFilePath))
                {
                    result.iResultCode = 1;
                    result.strResultInfo = "配置文件不存在";
                    return result;
                }
                config.isDebug = GetPrivateProfileBool("SYS", "isDebug", false, Common.configFilePath);
                config.comCd = GetPrivateProfileInt("SYS", "comCd", 15, Common.configFilePath);
                config.pmCd = GetPrivateProfileInt("SYS", "pmCd", 500, Common.configFilePath);
                config.readCodeCd = GetPrivateProfileInt("SYS", "readCodeCd", 200, Common.configFilePath);
                config.comEndStr = GetPrivateProfileString("SYS", "comEndStr", "\r\n", Common.configFilePath);

                config.m_iComPort = GetPrivateProfileInt("COM", "m_iComPort", 2, Common.configFilePath);
                config.m_iComBaudRate = GetPrivateProfileInt("COM", "m_iComBaudRate", 9600, Common.configFilePath);
                config.m_iComDataBits = GetPrivateProfileInt("COM", "m_iComDataBits", 8, Common.configFilePath);
                config.m_iComStopBits = GetPrivateProfileString("COM", "m_iComStopBits", "One", Common.configFilePath);
                config.m_iComParity = GetPrivateProfileString("COM", "m_iComParity", "None", Common.configFilePath);
                result.iResultCode = 0;
                result.strResultInfo = "配置文件加载成功";
                return result;
            }
            catch (System.Exception ex)
            {
                log.LogErr(ex);
                result.iResultCode = -1;
                result.strResultInfo = "配置文件加载异常";
                return result;
            }
        }

        /// <summary>
        /// Path必须为完整路径+文件名，如：c://aa//1.bmp，会自动创建完整路径
        /// </summary>
        /// <param name="Path"></param>
        public void CreateDirectoryEx(string Path)
        {
            int nPos;
            string PathTemp;
            nPos = Path.LastIndexOf('\\');
            if (nPos < 0)
                nPos = Path.LastIndexOf('/');

            if (nPos < 0)
            {
                return;
            }
            nPos = Path.LastIndexOf('\\');
            if (nPos > -1)
            {
                PathTemp = Path.Substring(0, nPos);
            }
            else
            {
                nPos = Path.LastIndexOf('/');
                PathTemp = Path.Substring(0, nPos);
            }

            if (!Directory.Exists(PathTemp))
            {
                Directory.CreateDirectory(PathTemp);
            }
            
        }
    }
}
