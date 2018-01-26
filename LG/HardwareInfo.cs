using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Management;

namespace SapAppliary
{
    /// <summary>
    /// 硬件信息
    /// </summary>
    public class HardwareInfo
    {
        public static List<string> GetMacByIpConfig()
        {
            List<string> macs=new List<string>();
            ProcessStartInfo startInfo=new ProcessStartInfo("ipconfig","/all");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            Process p = Process.Start(startInfo);
            //截取輸出流
            StreamReader reader = p.StandardOutput;
            string line = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    line = line.Trim();
                    if (line.StartsWith("Physical Address"))
                    {
                        macs.Add(line);
                    }
                }

                line = reader.ReadLine();
            }

            p.WaitForExit();
            p.Close();
            reader.Close();
            return macs;
        }

        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int32 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        /// <summary>
        /// 根據IP地址獲取Mac地址
        /// </summary>
        /// <param name="aStrIp"></param>
        /// <returns></returns>
        public static string GetMacFromIp(string aStrIp)
        {

            string strRet = "";
            const string strIpPattern = @"^\d+\.\d+\.\d+\.\d+$";

            var objRex = new Regex(strIpPattern);

            if (objRex.IsMatch(aStrIp))
            {
                var intDest = inet_addr(aStrIp);
                var arrMac = new Int32[2];
                var intLen = 6;

                int intResult = SendARP(intDest, 0, ref   arrMac[0], ref   intLen);

                if (intResult == 0)
                {
                    var arrbyte = new Byte[8];
                    arrbyte[5] = (Byte)(arrMac[1] >> 8);
                    arrbyte[4] = (Byte)arrMac[1];
                    arrbyte[3] = (Byte)(arrMac[0] >> 24);
                    arrbyte[2] = (Byte)(arrMac[0] >> 16);
                    arrbyte[1] = (Byte)(arrMac[0] >> 8);
                    arrbyte[0] = (Byte)arrMac[0];

                    var strbMac = new StringBuilder();

                    for (int intIndex = 0; intIndex < 6; intIndex++)
                    {
                        if (intIndex > 0) strbMac.Append("-");
                        strbMac.Append(arrbyte[intIndex].ToString("X2"));
                    }
                    strRet = strbMac.ToString();
                }
            }

            return strRet;
        }

        /// <summary>
        /// 获得CUP序列号
        /// </summary>
        /// <returns></returns>
        public static string GetCpuSn()
        {
            string strCpu = null;
            
            var myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();

            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            //Console.WriteLine("strCpu == " + strCpu);
            return strCpu;
        }

        /// <summary>
        /// 取得设备硬盘ID号
        /// </summary>
        /// <returns></returns>
        public static string GetIdHardDiskId()
        {
            string hdId = "";
            var cimobject = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc = cimobject.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                hdId = (string)mo.Properties["Model"].Value;
            }
            return hdId;
        }

        /// <summary>
        /// 取得设备硬盘的卷标号 
        /// </summary>
        /// <returns></returns>
        public static string GetDiskVolumeSerialNumber()
        {
            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");

            disk.Get();

            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        /// <summary>
        /// 获取网卡MacAddress
        /// </summary>
        /// <returns></returns>
        public static string GetIdNetCardId()
        {
            string ncId = "";
            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"])
                    ncId = mo["MacAddress"].ToString();
                mo.Dispose();
            }
            return ncId;
        }


        
    }
}