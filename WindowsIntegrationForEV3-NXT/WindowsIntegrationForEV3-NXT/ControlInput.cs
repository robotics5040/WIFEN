using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoBrick.EV3;
using MonoBrick.NXT;

namespace WindowsIntegrationForEV3_NXT
{
    public abstract class ControlInput
    {
        public enum Type { Keyboard, Touch, Gamepad, Kinect };

        public MonoBrick.NXT.Brick<MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor> nxt;
        public MonoBrick.EV3.Brick<MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor> ev3;

        public bool isNXT = true;

        public ControlInput(MonoBrick.NXT.Brick<MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor> nxtBrick)
        {
            this.nxt = nxtBrick;
        }

        public ControlInput(MonoBrick.EV3.Brick<MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor> ev3Brick)
        {
            this.ev3 = ev3Brick;
            this.isNXT = false;
        }

        public void updateDrive()
        {
            if (isNXT)
                updateNXT();
            else
                updateEV3();
        }

        public abstract void updateNXT();
        public abstract void updateEV3();
    }
}
