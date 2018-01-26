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

namespace LG
{
    public partial class InspectSetting : Form
    {

        private Controler controler = Controler.Instance();

        private int iVSResize;
        private int iHSResize;
        private int iVSMove;
        private int iHSMove;
        bool bContinuous = false;
        public InspectSetting()
        {
            InitializeComponent();
            controler.EnableBtn += new EnableBtn(OnEnableBtnCallBack);
            controler.RunCompleted += new RunCompleted(OnRunCompletedCallBack);
        }

        /// <summary>
        /// 按钮使能回调
        /// </summary>
        /// <param name="usable"></param>
        private void OnEnableBtnCallBack(bool usable)
        {
            btnInspectOne.Enabled = usable;
            btnInspectContinue.Enabled = usable;
            btnSave.Enabled = usable;
        }

        private void OnRunCompletedCallBack()
        {

            //Console.WriteLine("asdfgh");
            //try
            //{
            //    string data;
            //    controler.visionSystem.VarGetString("data", out data);
            //    tbResult.Text = data;
            //}
            //catch (System.Exception ex)
            //{
            //    controler.log.LogErr(ex);
            //}

        }

        private void InspectSetting_Load(object sender, EventArgs e)
        {
            controler.ConnectEngine(imageWindow, "imgA");
            btnStop.Enabled = false;
            
        }

        private void btnInspectOne_Click(object sender, EventArgs e)
        {
            try
            {
                controler.InspectOne();
            }
            catch (System.Exception ex)
            {
                controler.log.LogErr(ex);
            }
        }

        private void btnInspectContinue_Click(object sender, EventArgs e)
        {
            try
            {
                controler.InspectContinue(true);
                ControlBox = false;
                bContinuous = true;
                btnStop.Enabled = true;
                btnInspectContinue.Enabled = false;
            }
            catch (System.Exception ex)
            {
                controler.log.LogErr(ex);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                controler.StopInspect(true);
                ControlBox = true;
                bContinuous = false;
                btnStop.Enabled = false;
                btnInspectContinue.Enabled = true;
            }
            catch (System.Exception ex)
            {
                ControlBox = true;
            }
        }

        private void VS_Move_Scroll(object sender, ScrollEventArgs e)
        {
            controler.VS_Move_Scroll(VS_Move.Value, iVSMove, imageWindow);
            iVSMove = VS_Move.Value; // Save Vert. Scroll value to container
        }

        private void HS_Move_Scroll(object sender, ScrollEventArgs e)
        {
            controler.HS_Move_Scroll(HS_Move.Value, iHSMove, imageWindow);
            iHSMove = HS_Move.Value; //Save Vert. Scroll value to container
        }

        private void VS_Resize_Scroll(object sender, ScrollEventArgs e)
        {
            controler.VS_Resize_Scroll(VS_Resize.Value, iVSResize, imageWindow);
            iVSResize = VS_Resize.Value; //Save Vert. Scroll value to container
        }

        private void HS_Resize_Scroll(object sender, ScrollEventArgs e)
        {
            controler.HS_Resize_Scroll(HS_Resize.Value, iHSResize, imageWindow);
            iHSResize = HS_Resize.Value;//Save Vert. Scroll value to container
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            s_Result result = controler.InvSave(Common.ivsPath);
            MessageBox.Show(result.strResultInfo);
            if (result.iResultCode==0)
            {
                Close();
            }
            
        }

        private void InspectSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bContinuous == true)//if Investigating Continuous, Halt Inspection
            {
                controler.HaltInv();
            }
            controler.EnableBtn -= new EnableBtn(OnEnableBtnCallBack);
            controler.RunCompleted -= new RunCompleted(OnRunCompletedCallBack);
            imageWindow.DisconnectImgWindow();//disconnect display window
        }
    }
}
