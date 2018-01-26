using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisionSystem
{
    public class SerialPort
    {
        /// <summary>
        /// 串口接收到新数据事件
        /// </summary>
        public event EventHandler<DataEventArgs> NewDataReceived;
        /// <summary>
        /// 声明一个串口
        /// </summary>
        private System.IO.Ports.SerialPort _SerialPort;

        private System.Threading.AutoResetEvent _ent;

        Controler controler = Controler.Instance();

        public SerialPort(string comName)
        {
            try
            {
                this._ent = new System.Threading.AutoResetEvent(true);
                this._SerialPort = new System.IO.Ports.SerialPort();
                //注册串口数据接收事件
                this._SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(_SerialPort_DataReceived);

                if (this._SerialPort.IsOpen)
                {
                    this._SerialPort.Close();
                }
                //设置串口
                SetSeriaPort(comName);
               
                //打开串口
                this._SerialPort.Open();
            }
            catch (Exception ex)
            {
                controler.log.LogErr(ex);
            }
        }

        private void SetSeriaPort(string comName)
        {
            //波特率
            this._SerialPort.BaudRate = controler.config.m_iComBaudRate;
            //数据位
            this._SerialPort.DataBits = controler.config.m_iComDataBits;
            //停止位
            switch (controler.config.m_iComStopBits)
            {
                case "None":
                    this._SerialPort.StopBits = System.IO.Ports.StopBits.None;
                    break;
                case "One":
                    this._SerialPort.StopBits = System.IO.Ports.StopBits.One;
                    break;
                case "Two":
                    this._SerialPort.StopBits = System.IO.Ports.StopBits.Two;
                    break;
                case "OnePointFive":
                    this._SerialPort.StopBits = System.IO.Ports.StopBits.OnePointFive;
                    break;
            }

            //校验
            switch (controler.config.m_iComParity)
            {
                case "None":
                    this._SerialPort.Parity = System.IO.Ports.Parity.None;
                    break;
                case "Odd":
                    this._SerialPort.Parity = System.IO.Ports.Parity.Odd;
                    break;
                case "Even":
                    this._SerialPort.Parity = System.IO.Ports.Parity.Even;
                    break;
                case "Mark":
                    this._SerialPort.Parity = System.IO.Ports.Parity.Mark;
                    break;
                case "Space":
                    this._SerialPort.Parity = System.IO.Ports.Parity.Space;
                    break;
            }
            this._SerialPort.PortName = comName;
        }

        /// <summary>
        /// 向串口写数据
        /// </summary>
        /// <param name="msg"></param>
        public void sendMessage(string msg)
        {
            if (this._SerialPort.IsOpen)
            {
                this._SerialPort.Write(msg);
            }
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        public void close()
        {
            if (this._SerialPort.IsOpen)
            {
                this._SerialPort.Close();
            }
        }

        //串口接收数据事件
        void _SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (this._ent.WaitOne(0))
            {
                //获取缓冲区字节数
                int bytesToRead = this._SerialPort.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                //读取缓冲区数据
                this._SerialPort.Read(buffer, 0, bytesToRead);
                //数据格式转换
                string cmd = Encoding.ASCII.GetString(buffer);

                OnNewDataEvent(new DataEventArgs(cmd));
            }
        }

        protected virtual void OnNewDataEvent(DataEventArgs e)
        {
            EventHandler<DataEventArgs> handler = this.NewDataReceived;

            if (handler != null)
            {
                AsyncCallback nn = new AsyncCallback(eventCallback);

                handler.BeginInvoke(handler, e, nn, e);
            }
        }

        void eventCallback(IAsyncResult ar)
        {
            this._ent.Set();
        }
    }
}
