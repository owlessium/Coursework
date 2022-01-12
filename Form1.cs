using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        GravityPoint point1;
        GravityPoint point2;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter
            {
                Direction = 0,
                spreading = 10,
                speedMin = 10,
                speedMax = 10,
                colorFrom = Color.DarkViolet,
                colorTo = Color.FromArgb(0, Color.Maroon),
                particlesPerTick = 10,
                x = picDisplay.Width / 2,
                y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter);

            /*emitter = new TopEmitter
            {
                width = picDisplay.Width,
                gravitationY = 0.25f
            };*/

            point1 = new GravityPoint
            {
                x = picDisplay.Width / 2 + 150,
                y = picDisplay.Height / 2,
            };
            point2 = new GravityPoint
            {
                x = picDisplay.Width / 2 - 150,
                y = picDisplay.Height / 2,
            };

            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
        }
        
       private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.mousePositionX = e.X;
            emitter.mousePositionY = e.Y;
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°";
        }

        private void tbGravitol_Scroll(object sender, EventArgs e)
        {
            point1.power = tbGraviton.Value;
        }

        private void tbGraviton1_Scroll(object sender, EventArgs e)
        {
            point2.power = tbGraviton1.Value;
        }
    }
}
