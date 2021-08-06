using System;
using System.Drawing;

namespace VectorGraphicViewer.Desktop.Shapes
{
    public class Line : Shape
    {

        public Line(Color color) : base(color)
        {
        }

        public override void Draw(Graphics graphics)
        {
            var pen = new Pen(Color, 3);
            graphics.DrawLine(pen, PointFs[0], PointFs[1]);
        }
    }
}
