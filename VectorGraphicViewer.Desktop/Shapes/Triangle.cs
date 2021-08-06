using System.Drawing;
using System.Linq;

namespace VectorGraphicViewer.Desktop.Shapes
{
    public class Triangle : Shape
    {
        public bool Filled { get; private set; }

        public Triangle(Color color, bool filled) : base(color)
        {
            Filled = filled;
        }

        public override void Draw(Graphics graphics)
        {
            if (Filled)
            {
                var brush = new SolidBrush(Color);
                graphics.FillPolygon(brush, PointFs.ToArray());
            }
            else
            {
                var pen = new Pen(Color, 3);
                graphics.DrawPolygon(pen, PointFs.ToArray());
            }
        }
    }

}
