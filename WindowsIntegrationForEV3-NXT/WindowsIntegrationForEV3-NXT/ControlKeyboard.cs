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
    public class ControlKeyboard : ControlInput
    {
        private bool isUp = false;
        private bool isDown = false;
        private bool isLeft = false;
        private bool isRight = false;

        public ControlKeyboard(MonoBrick.NXT.Brick<MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor> nxtBrick) :
            base(nxtBrick) { }

        public ControlKeyboard(MonoBrick.EV3.Brick<MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor> ev3Brick) :
            base(ev3Brick) { }

        public void onKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
                isUp = true;
            if (e.KeyData == Keys.S)
                isDown = true;
            if (e.KeyData == Keys.A)
                isLeft = true;
            if (e.KeyData == Keys.D)
                isRight = true;

            updateDrive();
        }

        public void onKeyUpEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
                isUp = false;
            if (e.KeyData == Keys.S)
                isDown = false;
            if (e.KeyData == Keys.A)
                isLeft = false;
            if (e.KeyData == Keys.D)
                isRight = false;

            updateDrive();
        }

        public override void updateNXT()
        {
            if (isUp && isLeft)
            {
                nxt.MotorB.On(30);
                nxt.MotorC.On(60);
            }
            else if (isUp && isRight)
            {
                nxt.MotorB.On(60);
                nxt.MotorC.On(30);
            }
            else if (isUp)
            {
                nxt.MotorB.On(60);
                nxt.MotorC.On(60);
            }
            else if (isDown && isLeft)
            {
                nxt.MotorB.On(-30);
                nxt.MotorC.On(-60);
            }
            else if (isDown && isRight)
            {
                nxt.MotorB.On(-60);
                nxt.MotorC.On(-30);
            }
            else if (isDown)
            {
                nxt.MotorB.On(-60);
                nxt.MotorC.On(-60);
            }
            else if (isLeft)
            {
                nxt.MotorB.On(-60);
                nxt.MotorC.On(60);
            }
            else if (isRight)
            {
                nxt.MotorB.On(60);
                nxt.MotorC.On(-60);
            }
            else
            {
                nxt.MotorB.Off();
                nxt.MotorC.Off();
            }
        }

        public override void updateEV3()
        {
            if (isUp && isLeft)
            {
                ev3.MotorB.On(30);
                ev3.MotorC.On(60);
            }
            else if (isUp && isRight)
            {
                ev3.MotorB.On(60);
                ev3.MotorC.On(30);
            }
            else if (isUp)
            {
                ev3.MotorB.On(60);
                ev3.MotorC.On(60);
            }
            else if (isDown && isLeft)
            {
                ev3.MotorB.On(-30);
                ev3.MotorC.On(-60);
            }
            else if (isDown && isRight)
            {
                ev3.MotorB.On(-60);
                ev3.MotorC.On(-30);
            }
            else if (isDown)
            {
                ev3.MotorB.On(-60);
                ev3.MotorC.On(-60);
            }
            else if (isLeft)
            {
                ev3.MotorB.On(-60);
                ev3.MotorC.On(60);
            }
            else if (isRight)
            {
                ev3.MotorB.On(60);
                ev3.MotorC.On(-60);
            }
            else
            {
                ev3.MotorB.Off();
                ev3.MotorC.Off();
            }
        }
    }
}
