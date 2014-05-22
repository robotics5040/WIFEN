using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonoBrick.NXT;
using MonoBrick.EV3;

namespace WindowsIntegrationForEV3_NXT
{
    public partial class FormConnect : Form
    {
        private Form1 parent;
        private ControlInput.Type input;
        private ControlInput control;

        public FormConnect(Form1 form, ControlInput.Type type)
        {
            InitializeComponent();
            this.parent = form;
            this.input = type;
        }

        public FormConnect(Form1 form, ControlInput.Type type, ControlInput ctrl)
        {
            InitializeComponent();
            this.parent = form;
            this.input = type;
            this.control = ctrl;

            if (!control.isNXT)
            {
                this.trackBar1.Value = 1;
                this.pictureIconEV3.BackgroundImage = Properties.Resources.ev3_green;
                this.pictureIconNXT.BackgroundImage = Properties.Resources.nxt_red;

                if (control.ev3.Connection.IsConnected)
                    this.button2.Text = "Disconnect";
            }
            else
            {
                if (control.nxt.Connection.IsConnected)
                    this.button2.Text = "Disconnect";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string com;

            if (radioButton1.Checked)
                com = "COM" + textBox1.Text;
            else if (radioButton2.Checked)
                com = "wifi";
            else if (radioButton3.Checked)
                com = "usb";
            else
                com = "How did you manage to select nothing? What did you break to do that?";

            if (this.input == ControlInput.Type.Keyboard)
            {
                if (trackBar1.Value == 0)
                {
                    this.button2.Text = "Connecting...";
                    this.button2.Update();
                    parent.p1 = new ControlKeyboard(new MonoBrick.NXT.Brick<MonoBrick.NXT.Sensor, 
                        MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor>(com));
                    try
                    {
                        parent.p1.nxt.Connection.Open();
                        this.button2.Text = "Disconnect";
                    }
                    catch (Exception eP1_NXT)
                    {
                        this.button2.Text = "Connect";
                        MessageBox.Show(eP1_NXT.Message);
                        parent.p1 = null;
                    }
                }
                else
                {
                    this.button2.Text = "Connecting...";
                    this.button2.Update();
                    parent.p1 = new ControlKeyboard(new MonoBrick.EV3.Brick<MonoBrick.EV3.Sensor,
                        MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor>(com));
                    try
                    {
                        parent.p1.nxt.Connection.Open();
                        this.button2.Text = "Disconnect";
                    }
                    catch (Exception eP1_EV3)
                    {
                        this.button2.Text = "Connect";
                        MessageBox.Show(eP1_EV3.Message);
                        parent.p1 = null;
                    }
                }
            }
            else if (this.input == ControlInput.Type.Touch)
            {
                if (trackBar1.Value == 0)
                {
                    this.button2.Text = "Connecting...";
                    this.button2.Update();
                    parent.p2 = new ControlTouch(new MonoBrick.NXT.Brick<MonoBrick.NXT.Sensor,
                        MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor>(com));
                    try
                    {
                        parent.p2.nxt.Connection.Open();
                        this.button2.Text = "Disconnect";
                    }
                    catch (Exception ep2_NXT)
                    {
                        this.button2.Text = "Connect";
                        MessageBox.Show(ep2_NXT.Message);
                        parent.p2 = null;
                    }
                }
                else
                {
                    this.button2.Text = "Connecting...";
                    this.button2.Update();
                    parent.p2 = new ControlTouch(new MonoBrick.EV3.Brick<MonoBrick.EV3.Sensor,
                        MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor>(com));
                    try
                    {
                        parent.p2.nxt.Connection.Open();
                        this.button2.Text = "Disconnect";
                    }
                    catch (Exception ep2_EV3)
                    {
                        this.button2.Text = "Connect";
                        MessageBox.Show(ep2_EV3.Message);
                        parent.p2 = null;
                    }
                }
            }
            else if (this.input == ControlInput.Type.Gamepad)
            {
                if (trackBar1.Value == 0)
                {
                    this.button2.Text = "Connecting...";
                    this.button2.Update();
                    parent.p3 = new ControlGamepad(new MonoBrick.NXT.Brick<MonoBrick.NXT.Sensor,
                        MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor, MonoBrick.NXT.Sensor>(com));
                    try
                    {
                        parent.p3.nxt.Connection.Open();
                        this.button2.Text = "Disconnect";
                    }
                    catch (Exception ep3_NXT)
                    {
                        this.button2.Text = "Connect";
                        MessageBox.Show(ep3_NXT.Message);
                        parent.p3 = null;
                    }
                }
                else
                {
                    this.button2.Text = "Connecting...";
                    this.button2.Update();
                    parent.p3 = new ControlGamepad(new MonoBrick.EV3.Brick<MonoBrick.EV3.Sensor,
                        MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor>(com));
                    try
                    {
                        parent.p3.nxt.Connection.Open();
                        this.button2.Text = "Disconnect";
                    }
                    catch (Exception ep3_EV3)
                    {
                        this.button2.Text = "Connect";
                        MessageBox.Show(ep3_EV3.Message);
                        parent.p3 = null;
                    }
                }
            }
            else
            {
                parent.p4 = new ControlKinect(new MonoBrick.EV3.Brick<MonoBrick.EV3.Sensor,
                        MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor, MonoBrick.EV3.Sensor>(com));
                this.button2.Text = "Connecting...";
                this.button2.Update();
                if (trackBar1.Value == 1)
                    this.parent.p4.isNXT = false;
                else
                    this.parent.p4.isNXT = true;

                this.parent.buttonBluetooth_Click(this.textBox1.Text);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar1.Value == 1)
            {
                this.pictureIconEV3.BackgroundImage = Properties.Resources.ev3_green;
                this.pictureIconNXT.BackgroundImage = Properties.Resources.nxt_red;
            }
            else
            {
                this.pictureIconEV3.BackgroundImage = Properties.Resources.ev3_red;
                this.pictureIconNXT.BackgroundImage = Properties.Resources.nxt_green;
            }
        }
    }
}
