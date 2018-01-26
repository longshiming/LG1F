using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zazaniao;

namespace VisionSystem
{
    class Log
    {
        public  void LogErr(Exception ex)
        {
            if (Controler.Instance().config.isDebug)
            {
                string date = string.Format("{0}", DateTime.Now.ToString("yyyy_MM_dd"));
                string logFilePath = Common.logPath + date + Common.logName;
                string str = string.Format("{0},{1}", " Error StackTrace == " + ex.StackTrace, "Error.tostring == " + ex.ToString());
                Controler.Instance().CreateDirectoryEx(logFilePath);
                ZazaniaoDll.LogEx(logFilePath, str, true, "描述,痕迹");
            }

        }
    }
}
