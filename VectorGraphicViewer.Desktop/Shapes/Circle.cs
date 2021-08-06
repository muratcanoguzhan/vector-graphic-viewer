using System.Drawing;

namespace VectorGraphicViewer.Desktop.Shapes
{
    public class Circle : Shape
    {
        public float Radius { get; set; }
        public bool Filled { get; private set; }

        public Circle(Color color, float radius, bool filled) : base(color)
        {
            Radius = radius;
            Filled = filled;
        }

        public override void Draw(Graphics graphics)
        {
            var center = PointFs[0];
            var rec = new RectangleF(center.X - Radius, center.Y + Radius, Radius * 2, Radius * 2);

            if (Filled)
            {
                var brush = new SolidBrush(Color);
                graphics.FillEllipse(brush, rec);
            }
            else
            {
                var pen = new Pen(Color, 3);
                graphics.DrawEllipse(pen, rec);
            }
        }

        public override float GetWidth()
        {
            return Radius * 2;
        }
        public override float GetHeight()
        {
            return Radius * 2;
        }
    }

}
