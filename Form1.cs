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
            /*
            emitter = new TopEmitter
            {
                width = picDisplay.Width,
                gravitationY = 0.25f
            };

            emitter.impactPoints.Add(new GravityPoint 
                {
                    x = (float)(picDisplay.Width * 0.25),
                    y = picDisplay.Height / 2
                });
            emitter.impactPoints.Add(new AntiGravityPoint
            {
                x = picDisplay.Width / 2,
                y = picDisplay.Height / 2
            });
            emitter.impactPoints.Add(new GravityPoint
                {
                    x = (float)(picDisplay.Width * 0.75),
                    y = picDisplay.Height / 2
                }); */
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
    }
}
