using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionSystem
{
    class Common
    {
        public static string rootpath = Application.StartupPath;
        public static string logPath = rootpath + "\\log\\";
        public static string dataPath = rootpath + "\\data\\";
        public static string configFilePath = dataPath + "Config.ini";
        public static string logName = "ErrorLog.csv";
        public static string ivsPath = "E:\\MD\\LG.ivs";
    }
}
