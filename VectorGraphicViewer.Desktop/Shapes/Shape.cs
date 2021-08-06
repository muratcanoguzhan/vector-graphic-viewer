using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace VectorGraphicViewer.Desktop.Shapes
{
    public class Shape
    {
        public List<PointF> PointFs { get; private set; }
        public Color Color { get; private set; }

        public Shape(Color color)
        {
            Color = color;
            PointFs = new List<PointF>();
        }

        public virtual void Draw(Graphics graphics)
        {
        }

        public virtual float GetWidth()
        {
            var min = PointFs.Min(x => x.X);
            var max = PointFs.Max(x => x.X);

            return max - min;
        }

        public virtual float GetHeight()
        {
            var min = PointFs.Min(x => x.Y);
            var max = PointFs.Max(x => x.Y);

            return max - min;
        }

        public void AddPointF(PointF pointF)
        {
            PointFs.Add(pointF);
        }
    }
}
