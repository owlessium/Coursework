using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Coursework
{
    public class Emitter
    {
        List<Particle> particles = new List<Particle>();
        public int mousePositionX;
        public int mousePositionY;

        public float gravitationX = 0;
        public float gravitationY = 0;

        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        public int particlesCount = 500;

        public virtual void ResetParticle (Particle particle)
        {
            particle.life = 20 + Particle.rand.Next(100);
            particle.x = mousePositionX;
            particle.y = mousePositionY;

            var direction = (double)Particle.rand.Next(360);
            var speed = 1 + Particle.rand.Next(10);

            particle.speedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.speedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.radius = 2 + Particle.rand.Next(10);
        }
        public void UpdateState ()
        {

            foreach (var particle in particles)
            {
                particle.life -= 1;
                if (particle.life < 0)
                {
                    ResetParticle(particle);
                }
                else
                {

                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }
                    
                    particle.speedX += gravitationX;
                    particle.speedY += gravitationY;

                    particle.x += particle.speedX;
                    particle.y += particle.speedY;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                if (particles.Count < particlesCount)
                {
                    var particle = new ParticleColorful();
                    particle.fromColor = Color.BlueViolet;
                    particle.toColor = Color.FromArgb(0, Color.Maroon);
                    ResetParticle(particle);
                    particles.Add(particle);
                }
                else
                {
                    break;
                }
            }
        }

        public void Render (Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }
    }
}