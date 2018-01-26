using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisionSystem
{
    public class DataEventArgs:EventArgs
    {
        public string Message { get; private set; }

        public DataEventArgs(string msg)
        {
            this.Message = msg;
        }
    }
}
