using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Coursework
{
    public class Enemy : OverlapableObject
    {
        public int radius = 25;

        public float vX = 0;
        public float vY = 0;

        public float angle;

        public float life;

        public int reward;

        public bool isFreez = false;

        public Action OnDead;

        public void MoveTo(Emitter target)
        {
            if (isFreez) return;

            if (target != null)
            {
                float dx = target.x - x;
                float dy = target.y - y;

                float length = (float)Math.Sqrt(dx * dx + dy * dy);

                dx /= length;
                dy /= length;

                vX += dx * 0.15f;
                vY += dy * 0.15f;

                angle = (float)(90 - Math.Atan2(vX, vY) * 180 / Math.PI);
            }


            vX += -vX * 0.1f;
            vY += -vY * 0.1f;

            x += vX;
            y += vY;
        }

        public virtual void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.SkyBlue), x - radius, y - radius, radius * 2, radius * 2);
            g.FillRectangle(new SolidBrush(Color.Green), x - radius, y - radius - 5, life/5, 2);
        }

        public void applyDamage(float damage)
        {
            life -= damage;

            if (life <= 0)
                OnDead?.Invoke();
        }

        protected override GraphicsPath GetGraphicsPath()
        {
            var path = new GraphicsPath();

            path.AddEllipse(0 - radius, 0 - radius, radius * 2, radius * 2);

            return path;
        }
    }
}
