﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Coursework
{
    public class Particle
    {
        public int radius; //радиус частицы
        public float x; //координата движения в пространстве
        public float y; //координата движения в пространстве

        public float direction; // направление движения (а-ля угол)
        public float speed; // скорость перемещения
        public float life; //запас здоровья частицы

        public static Random rand = new Random();

        public Particle ()
        {
            direction = rand.Next(360);
            speed = 1 + rand.Next(10);
            radius = 2 + rand.Next(10);
            life = 20 + rand.Next(100);
        }

        public virtual void Draw (Graphics g)
        {
            float k = Math.Min(1f, life / 100); // расчёт коэффициента прозрачности
            int alpha = (int)(k * 255); //канал для задания прозрачности

            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);

            g.FillEllipse(b, x - radius, y - radius, radius * 2, radius * 2);

            b.Dispose();
        }
    }

    public class ParticleColorful : Particle
    {
        public Color fromColor;
        public Color toColor;

        public static Color MixColor (Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
                );
        }

        public override void Draw (Graphics g)
        {
            float k = Math.Min(1f, life / 100);

            var color = MixColor(toColor, fromColor, k);
            var b = new SolidBrush(color);

            g.FillEllipse(b, x - radius, y - radius, radius * 2, radius * 2);

            b.Dispose();
        }
    }
}
