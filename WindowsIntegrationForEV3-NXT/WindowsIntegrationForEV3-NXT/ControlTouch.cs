using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonoBrick.NXT;
using MonoBrick.EV3;

namespace WindowsIntegrationForEV3_NXT
{

    public class ControlTouch : ControlInput
    {
        private int powerL;
        private int powerR;
        private bool isDown = false;

        public ControlTouch(MonoBrick.NXT.Brick<MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor> nxtBrick) :
            base(nxtBrick) { }

        public ControlTouch(MonoBrick.EV3.Brick<MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor> ev3Brick) :
            base(ev3Brick) { }

        public void onCursorDownEvent(PictureBox sender, MouseEventArgs e)
        {
            isDown = true;
        }

        public void onCursorUpEvent(PictureBox sender, MouseEventArgs e)
        {
            isDown = false;
        }

        public void onCursorMoveEvent(PictureBox sender, MouseEventArgs e, Form1 parent)
        {
            if (isDown)
            {
                string name = "default";

                int x = sender.Bounds.X + e.X;
                int y = sender.Bounds.Y + e.Y;

                if (x >= parent.touchUL.Bounds.X && x <= parent.touchUL.Bounds.X + parent.touchUL.Bounds.Width
                    && y >= parent.touchUL.Bounds.Y && y <= parent.touchUL.Bounds.Y + parent.touchUL.Bounds.Height)
                    name = "touchUL";
                else if (x >= parent.touchUC.Bounds.X && x <= parent.touchUC.Bounds.X + parent.touchUC.Bounds.Width
                    && y >= parent.touchUC.Bounds.Y && y <= parent.touchUC.Bounds.Y + parent.touchUC.Bounds.Height)
                    name = "touchUC";
                else if (x >= parent.touchUR.Bounds.X && x <= parent.touchUR.Bounds.X + parent.touchUR.Bounds.Width
                    && y >= parent.touchUR.Bounds.Y && y <= parent.touchUR.Bounds.Y + parent.touchUR.Bounds.Height)
                    name = "touchUR";
                else if (x >= parent.touchCL.Bounds.X && x <= parent.touchCL.Bounds.X + parent.touchCL.Bounds.Width
                    && y >= parent.touchCL.Bounds.Y && y <= parent.touchCL.Bounds.Y + parent.touchCL.Bounds.Height)
                    name = "touchCL";
                else if (x >= parent.touchCenter.Bounds.X && x <= parent.touchCenter.Bounds.X + parent.touchCenter.Bounds.Width
                    && y >= parent.touchCenter.Bounds.Y && y <= parent.touchCenter.Bounds.Y + parent.touchCenter.Bounds.Height)
                    name = "touchCenter";
                else if (x >= parent.touchCR.Bounds.X && x <= parent.touchCR.Bounds.X + parent.touchCR.Bounds.Width
                    && y >= parent.touchCR.Bounds.Y && y <= parent.touchCR.Bounds.Y + parent.touchCR.Bounds.Height)
                    name = "touchCR";
                else if (x >= parent.touchDL.Bounds.X && x <= parent.touchDL.Bounds.X + parent.touchDL.Bounds.Width
                    && y >= parent.touchDL.Bounds.Y && y <= parent.touchDL.Bounds.Y + parent.touchDL.Bounds.Height)
                    name = "touchDL";
                else if (x >= parent.touchDC.Bounds.X && x <= parent.touchDC.Bounds.X + parent.touchDC.Bounds.Width
                    && y >= parent.touchDC.Bounds.Y && y <= parent.touchDC.Bounds.Y + parent.touchDC.Bounds.Height)
                    name = "touchDC";
                else if (x >= parent.touchDR.Bounds.X && x <= parent.touchDR.Bounds.X + parent.touchDR.Bounds.Width
                    && y >= parent.touchDR.Bounds.Y && y <= parent.touchDR.Bounds.Y + parent.touchDR.Bounds.Height)
                    name = "touchDR";

                switch(name)
                {
                    case "touchUL": //Swing turn L
                        MessageBox.Show("hello");
                        powerL = 30;
                        powerR = 60;
                        break;
                    case "touchUC": //Forwards
                        powerL = 60;
                        powerR = 60;
                        break;
                    case "touchUR": //Swing turn R
                        powerL = 60;
                        powerR = 30;
                        break;
                    case "touchCL": //Point turn L
                        powerL = -50;
                        powerR = 50;
                        break;
                    case "touchCenter": //Breakss
                        powerL = 0;
                        powerR = 0;
                        break;
                    case "touchCR": //Point turn R
                        powerL = 50;
                        powerR = -50;
                        break;
                    case "touchDL": //Swing turn L backwards
                        powerL = -30;
                        powerR = -60;
                        break;
                    case "touchDC": //Backwards
                        powerL = -60;
                        powerR = -60;
                        break;
                    case "touchDR": //Swing turn R backwards
                        powerL = -60;
                        powerR = -30;
                        break;
                    default:
                        powerL = 0;
                        powerR = 0;
                        break;
                }
                updateDrive();
            }
        }

        public override void updateNXT()
        {
            if (powerL != 0)
                this.nxt.MotorB.On((sbyte)powerL);
            else
                this.nxt.MotorB.Off();
            if (powerR != 0)
                this.nxt.MotorC.On((sbyte)powerR);
            else
                this.nxt.MotorC.Off();
        }

        public override void updateEV3()
        {
            if (powerL != 0)
                this.ev3.MotorB.On((sbyte)powerL);
            else
                this.ev3.MotorB.Off();
            if (powerR != 0)
                this.ev3.MotorC.On((sbyte)powerR);
            else
                this.ev3.MotorC.Off();
        }
    }
}
