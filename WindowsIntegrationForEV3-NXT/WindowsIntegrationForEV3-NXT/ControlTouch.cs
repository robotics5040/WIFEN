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

        public void onCursorMoveEvent(PictureBox sender)
        {
            if (isDown)
            {
                switch(sender.Name)
                {
                    case "touchUL": //Swing turn L
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
