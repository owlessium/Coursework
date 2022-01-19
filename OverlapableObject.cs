using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Coursework
{
    public abstract class OverlapableObject
    {
        public float x;
        public float y;

        protected abstract GraphicsPath GetGraphicsPath();

        private Matrix GetTMatrix()
        {
            var matrix = new Matrix();

            matrix.Translate(x, y);

            return matrix;
        }

        public bool Overlaps(OverlapableObject obj, Graphics g)
        {
            var path1 = this.GetGraphicsPath();
            var path2 = obj.GetGraphicsPath();

            path1.Transform(this.GetTMatrix());
            path2.Transform(obj.GetTMatrix());

            var region = new Region(path1);
            region.Intersect(path2);

            return !region.IsEmpty(g);
        }
    }
}
