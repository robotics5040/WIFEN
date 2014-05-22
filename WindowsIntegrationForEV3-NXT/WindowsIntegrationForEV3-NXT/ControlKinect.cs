using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace WindowsIntegrationForEV3_NXT
{
    public class ControlKinect : ControlInput
    {
        public ControlKinect(MonoBrick.NXT.Brick<MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor> nxtBrick) :
            base(nxtBrick) { }

        public ControlKinect(MonoBrick.EV3.Brick<MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor> ev3Brick) :
            base(ev3Brick) { }

        public override void updateNXT()
        {
            throw new NotImplementedException();
        }

        public override void updateEV3()
        {
            throw new NotImplementedException();
        }
    }
}
