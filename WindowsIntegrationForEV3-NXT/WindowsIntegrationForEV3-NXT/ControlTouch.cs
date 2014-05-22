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

        public ControlTouch(MonoBrick.NXT.Brick<MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor> nxtBrick) :
            base(nxtBrick) { }

        public ControlTouch(MonoBrick.EV3.Brick<MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor> ev3Brick) :
            base(ev3Brick) { }

        public void onCursorDownEvent(PictureBox sender, MouseEventArgs e)
        {

        }

        public void onCursorUpEvent(PictureBox sender, MouseEventArgs e)
        {
            
        }

        public void onCursorMoveEvent(PictureBox sender, MouseEventArgs e, Label l)
        {
            int centerx = sender.Bounds.X + (sender.Bounds.Width / 2);
            int centery = sender.Bounds.Y + (sender.Bounds.Height / 2);
            int x = e.X - centerx;
            int y = e.Y - centery;

            int distance = (int) Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            powerL = x + y;
            powerR = (x * -1) + y;

            l.Text = "L: " + powerL + " R: " + powerR;
        }

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
