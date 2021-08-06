using System.Drawing;

namespace VectorGraphicViewer.Desktop.Shapes
{
    public class Triangle : Shape
    {
        public PointF A { get; private set; }
        public PointF B { get; private set; }
        public PointF C { get; private set; }
        public bool Filled { get; private set; }

        public Triangle(Color color, PointF a, PointF b, PointF c, bool filled) : base(color)
        {
            A = a;
            B = b;
            C = c;
            Filled = filled;
        }

        public override void Draw(Graphics graphics)
        {
            if (Filled)
            {
                var pen = new Pen(Color, 3);
                graphics.DrawPolygon(pen, new PointF[] { A, B, C });
            }
            else
            {
                var brush = new SolidBrush(Color);
                graphics.FillPolygon(brush, new PointF[] { A, B, C });
            }
        }
    }

}
