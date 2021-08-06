using System.Drawing;

namespace VectorGraphicViewer.Desktop.Shapes
{
    public class Circle : Shape
    {
        public PointF Center { get; private set; }
        public float Radius { get; private set; }
        public bool Filled { get; private set; }

        public Circle(Color color, PointF center, float radius, bool filled) : base(color)
        {
            Center = center;
            Radius = radius;
            Filled = filled;
        }

        public override void Draw(Graphics graphics)
        {
            if (Filled)
            {
                var pen = new Pen(Color, 3);
                graphics.DrawEllipse(pen, Center.X, Center.Y, Radius * 2, Radius * 2);
            }
            else
            {
                var brush = new SolidBrush(Color);
                graphics.FillEllipse(brush, Center.X, Center.Y, Radius * 2, Radius * 2);
            }
        }
    }

}
