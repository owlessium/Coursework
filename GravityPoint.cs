using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Coursework
{
    public class GravityPoint : IImpactPoint
    {
        public int power = 100;
        public override void ImpactParticle(Particle particle)
        {
            float gX = x - particle.x;
            float gY = y - particle.y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);
           
            particle.speedX += gX * power / r2;
            particle.speedY += gY * power / r2;
        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Yellow), x - power / 2, y - power / 2, power, power);
        }
    }
}
