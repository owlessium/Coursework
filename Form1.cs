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
        Emitter emitter;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

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
                }); 
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
    }
}
