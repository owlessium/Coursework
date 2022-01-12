using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    public class TopEmitter : Emitter
    {
        public int width;

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);

            particle.x = Particle.rand.Next(width);
            particle.y = 0;

            particle.speedX = 1;
            particle.speedY = Particle.rand.Next(-2, 2);
        }
    }
}
