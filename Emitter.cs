using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Coursework
{
    public class Emitter : OverlapableObject
    {
        List<Particle> particles = new List<Particle>();

        public int Direction = 0;
        public int spreading = 360;
        public int speedMin = 1;
        public int speedMax = 10;
        public int radiusMin = 2;
        public int radiusMax = 10;
        public int lifeMin = 20;
        public int lifeMax = 100;

        public int health = 100;

        public int particlesPerTick = 1;

        public Color colorFrom = Color.DarkViolet;
        public Color colorTo = Color.FromArgb(0, Color.Maroon);

        public int mousePositionX;
        public int mousePositionY;

        public Enemy enemy;

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
                    particle.x += particle.speedX;
                    particle.y += particle.speedY;

                    particle.life -= 1;
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.speedX += gravitationX;
                    particle.speedY += gravitationY;                  
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

        public void checkHitEnemy(Graphics g, Enemy enemy)
        {
            foreach (var particle in particles.ToArray())
            {
                if (particle.Overlaps(enemy, g))
                {
                    enemy.applyDamage(particle.damage);
                    particles.Remove(particle);
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

            DrawHouse(g);
        }

        private void DrawHouse(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Red), new Rectangle((int)x - 25, (int)y - 25, 50, 50));
            g.FillEllipse(new SolidBrush(Color.Red), x - 10, y - 10, 20, 20);
            g.FillRectangle(new SolidBrush(Color.Green), x - 25, y - 30, health/2, 4);
        }

        protected override GraphicsPath GetGraphicsPath()
        {
            var path = new GraphicsPath();

            path.AddRectangle(new Rectangle(-25, -25, 50, 50));

            return path;
        }
    }
}