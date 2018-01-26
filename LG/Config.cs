using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionSystem
{
    class Config
    {
        public bool isDebug = false;
        //public bool isSaveImg = true;
        public bool isLogin = false;

        public int comCd = 15;
        public int pmCd = 500;
        public int readCodeCd = 200;

        public string comEndStr = "\r\n";

        public int m_iComPort = 2;
        public int  m_iComBaudRate = 9600;
        public string  m_iComParity = "None";
        public int m_iComDataBits = 8;
        public string m_iComStopBits = "One";
    }
}
