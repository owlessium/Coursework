using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Coursework
{
    public abstract class IImpactPoint
    {
        public float x;
        public float y;

        public abstract void ImpactParticle(Particle particle);

        public virtual void Render (Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Yellow), x - 5, y - 5, 10, 10);
        }
    }
}
