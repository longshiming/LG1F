using System;
using System.Globalization;

namespace SapAppliary
{
    public class RegistSoftware
    {
        /// <summary>
        /// MDC密鑰
        /// </summary>
        private const string MdcKey =
            "808276244152765344361350184675668582811376658723627142453717146747227243307368126104752602710213071058437464407457004108552433";
        /// <summary>
        /// DNC密鑰
        /// </summary>
        private const string DncKey =
    "718128607581831175526526018074845015175386841164780377418100851264472408023866583417445758687432457657228035344150544371762370";

        /// <summary>
        /// 密鑰數組
        /// </summary>
        private static int[] _intCode;

        /// <summary>
        /// 用于存机器码的Ascii值 
        /// </summary>
        private static readonly int[] IntNumber = new int[25];

        /// <summary>
        /// 存储机器码字
        /// </summary>
        private static readonly char[] Charcode = new char[25];

        /// <summary>
        /// 獲取機器碼
        /// </summary>
        /// <returns></returns>
        public static string GetSiteMessage()
        {
            string s = HardwareInfo.GetCpuSn() + HardwareInfo.GetDiskVolumeSerialNumber();
            //Console.WriteLine(" s =========== " + s);
            //var strid = new string[24];

            //for (int i = 0; i < 24; i++) //把字符赋给数组        
            //{
            //    strid[i] = s.Substring(i, 1);
            //}

            //s = "";
            //var rdid = new Random();
            //for (int i = 0; i < 24; i++) //从数组随机抽取24个字符组成新的字符生成机器碼       
            //{
            //    s += strid[rdid.Next(0, 24)];
            //}

            return s;
        }

        /// <summary>
        /// 根據機器碼生成注冊碼
        /// </summary>
        /// <param name="siteMessage">機器碼</param>
        /// <param name="prtType">產品類型</param>
        /// <returns></returns>
        public static string GetRegeditKey(string siteMessage, int prtType)
        {
            if (siteMessage != "")
            {
                switch (prtType)
                {
                    case 1:
                        _intCode = new int[MdcKey.Length];

                        for (int i = 0; i < MdcKey.Length; i++)
                        {
                            _intCode[i] = Convert.ToInt16(MdcKey.Substring(i, 1));
                        }
                        break;
                    case 2:
                        _intCode = new int[DncKey.Length];

                        for (int i = 0; i < DncKey.Length; i++)
                        {
                            _intCode[i] = Convert.ToInt16(DncKey.Substring(i, 1));
                        }
                        break;
                }

                if (siteMessage.Trim().Length == 24)
                {
                    for (int i = 1; i < Charcode.Length; i++) //把机器码存入数组中            
                    {
                        Charcode[i] = Convert.ToChar(siteMessage.Substring(i - 1, 1));
                    }

                    for (int j = 1; j < IntNumber.Length; j++) //把字符的ASCII值存入一个整数组中。       
                    {
                        IntNumber[j] = _intCode[Convert.ToInt32(Charcode[j])] + Convert.ToInt32(Charcode[j]);
                    }

                    string strAsciiName = null; //用于存储机器码  

                    for (int j = 1; j < IntNumber.Length; j++)
                    {
                        if (IntNumber[j] >= 48 && IntNumber[j] <= 57) //判断字符ASCII值是否0－9之间  
                        {
                            strAsciiName += Convert.ToChar(IntNumber[j]).ToString(CultureInfo.InvariantCulture);
                        }
                        else if (IntNumber[j] >= 65 && IntNumber[j] <= 90) //判断字符ASCII值是否A－Z之间                 
                        {
                            strAsciiName += Convert.ToChar(IntNumber[j]).ToString(CultureInfo.InvariantCulture);
                        }
                        else if (IntNumber[j] >= 97 && IntNumber[j] <= 122) //判断字符ASCII值是否a－z之间                 
                        {
                            strAsciiName += Convert.ToChar(IntNumber[j]).ToString(CultureInfo.InvariantCulture);
                        }
                        else //判断字符ASCII值不在以上范围内                 
                        {
                            if (IntNumber[j] > 122) //判断字符ASCII值是否大于z                
                            {
                                strAsciiName += Convert.ToChar(IntNumber[j] - 10).ToString(CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                strAsciiName += Convert.ToChar(IntNumber[j] - 9).ToString(CultureInfo.InvariantCulture);
                            }
                        }
                    }

                    return strAsciiName; //得到注册码  
                }
            }
            return "";
        }

        /// <summary>
        /// 軟件注冊
        /// </summary>
        /// <param name="sitemessage">機器碼</param>
        /// <param name="key">注冊碼</param>
        /// <param name="prtType">產品類型</param>
        public static void Regedit(string sitemessage, string key, int prtType)
        {
            var openSubKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true);
            if (openSubKey != null)
            {
                var registryKey = openSubKey.CreateSubKey("Sapient");
                if (registryKey != null)
                {
                    switch (prtType)
                    {
                        case 1:
                            var subKey1 = registryKey.CreateSubKey("Sapient MDC");

                            if (subKey1 != null)
                            {
                                subKey1.SetValue(sitemessage, key);
                            }
                            break;
                        case 2:
                            var subKey2 = registryKey.CreateSubKey("Sapient DNC");

                            if (subKey2 != null)
                            {
                                subKey2.SetValue(sitemessage, key);
                            }
                            break;
                    }

                    openSubKey.Close();
                    openSubKey.Dispose();
                }
            }
        }

        /// <summary>
        /// 查看軟件授權
        /// </summary>
        /// <returns></returns>
        public static bool CheckRegeditInfo(int prtType)
        {
            var openSubKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true);
            if (openSubKey != null)
            {
                var registryKey = openSubKey.OpenSubKey("Sapient");
                if (registryKey != null)
                {
                    switch (prtType)
                    {
                        case 1:
                            var subKey1 = registryKey.OpenSubKey("Sapient MDC");

                            if (subKey1 != null)
                            {
                                string[] valuename = subKey1.GetValueNames();
                                if (valuename.Length>0)
                                {
                                    for (int i = 0; i < valuename.Length; i++)
                                    {
                                        //if (GetRegeditKey(valuename[i], prtType) == (string)subKey1.GetValue(valuename[i]))
                                        if (GetRegeditKey(GetSiteMessage(), prtType) == (string)subKey1.GetValue(valuename[i]))
                                        {
                                            openSubKey.Close();
                                            openSubKey.Dispose();
                                            return true;
                                        }
                                    }
                                      
                                }
                            }
                            break;
                        case 2:
                            var subKey2 = registryKey.OpenSubKey("Sapient DNC");

                            if (subKey2 != null)
                            {
                                string[] valuename = subKey2.GetValueNames();
                                if (valuename.Length > 0)
                                {
                                    for (int i = 0; i < valuename.Length; i++)
                                    {
                                        //if (GetRegeditKey(valuename[i], prtType) == (string)subKey2.GetValue(valuename[i]))
                                        if (GetRegeditKey(GetSiteMessage(), prtType) == (string)subKey2.GetValue(valuename[i]))
                                        {
                                            openSubKey.Close();
                                            openSubKey.Dispose();

                                            return true;
                                        }
                                    }
                                    
                                }
                            }
                            break;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 獲取127位密鑰
        /// </summary>
        /// <returns></returns>
        public static string InitialKey()
        {
            var intCode = new int[127];

            string s = "";
            var ra = new Random();

            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = ra.Next(0, 9);
                s = s + intCode[i].ToString(CultureInfo.InvariantCulture);
            }

            return s;
        }
    }
}
