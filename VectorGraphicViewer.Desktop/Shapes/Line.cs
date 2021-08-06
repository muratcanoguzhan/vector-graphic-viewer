using System.Drawing;

namespace VectorGraphicViewer.Desktop.Shapes
{
    public class Line : Shape
    {
        public PointF A { get; private set; }
        public PointF B { get; private set; }

        public Line(Color color, PointF a, PointF b) : base(color)
        {
            A = a;
            B = b;
        }

        public override void Draw(Graphics graphics)
        {
            var pen = new Pen(Color, 3);
            graphics.DrawLine(pen, A, B);
        }
    }
}
