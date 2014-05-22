using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void onUpdateTick()
        {
            this.controller.Update();

            if ((int) controller.RightStick.Position.Y != powerR || (int) controller.LeftStick.Position.Y != powerL)
            {
                powerL = (int) controller.LeftStick.Position.Y;
                powerR = (int) controller.RightStick.Position.Y;
                this.updateDrive();
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
