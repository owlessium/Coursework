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

        public int x;
        public int y;
        public int Direction = 0;
        public int spreading = 360;
        public int speedMin = 1;
        public int speedMax = 10;
        public int radiusMin = 2;
        public int radiusMax = 10;
        public int lifeMin = 20;
        public int lifeMax = 100;

        public int particlesPerTick = 1;

        public Color colorFrom = Color.DarkViolet;
        public Color colorTo = Color.FromArgb(0, Color.Maroon);

        public int mousePositionX;
        public int mousePositionY;

        public float gravitationX = 0;
        public float gravitationY = 0;

        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        public int particlesCount = 500;

        public virtual void ResetParticle (Particle particle)
        {
            particle.life = Particle.rand.Next(lifeMin, lifeMax);
            particle.x = x;
            particle.y = y;

            var direction = Direction + (double)Particle.rand.Next(spreading) - spreading / 2;
            var speed = Particle.rand.Next(speedMin, speedMax);

            particle.speedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.speedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.radius = Particle.rand.Next(radiusMin, radiusMax);
        }

        public virtual Particle CreateParticle ()
        {
            var particle = new ParticleColorful();
            particle.fromColor = colorFrom;
            particle.toColor = colorTo;
            return particle;
        }

        public void UpdateState ()
        {
            int particlesToCreate = particlesPerTick;

            foreach (var particle in particles)
            {
                if (particle.life <= 0)
                {
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1;
                        ResetParticle(particle);
                    }
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

            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
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