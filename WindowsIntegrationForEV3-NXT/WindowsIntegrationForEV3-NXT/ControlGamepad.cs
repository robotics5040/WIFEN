using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsIntegrationForEV3_NXT
{
    public class ControlGamepad : ControlInput
    {
        public GamepadState controller;

        private int powerL = 0;
        private int powerR = 0;

        public ControlGamepad(MonoBrick.NXT.Brick<MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor> nxtBrick) :
            base(nxtBrick) { }

        public ControlGamepad(MonoBrick.EV3.Brick<MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor> ev3Brick) :
            base(ev3Brick) { }

        public void onUpdateTick(Label label)
        {
            this.controller.Update();

            if (controller.LeftStick.Position.Y > 0.2)
                powerL = (int)(controller.LeftStick.Position.Y * 100) - 20;
            else if (controller.LeftStick.Position.Y < -0.2)
                powerL = (int)(controller.LeftStick.Position.Y * 100) + 20;
            else
                powerL = 0;

            if (controller.RightStick.Position.Y > 0.2)
                powerR = (int)(controller.RightStick.Position.Y * 100) - 20;
            else if (controller.RightStick.Position.Y < -0.2)
                powerR = (int)(controller.RightStick.Position.Y * 100) + 20;
            else
                powerR = 0;

            if (controller.A)
            {
                powerL = 60;
                powerR = 60;
            }
            else if (controller.B)
            {
                powerL = 0;
                powerR = 0;
            }

            label.Visible = true;
            label.Text = "R" + powerR + "L" + powerL; 

            this.updateDrive();
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
