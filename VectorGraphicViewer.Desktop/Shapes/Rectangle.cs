using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace VectorGraphicViewer.Desktop.Shapes
{
    public class Rectangle : Shape
    {
        public bool Filled { get; private set; }
        public SizeF Size { get; private set; }

        public Rectangle(Color color, bool filled, SizeF size) : base(color)
        {
            Filled = filled;
            Size = size;
        }

        public override void Draw(Graphics graphics)
        {
            var rec = new RectangleF(PointFs[0], Size);
            if (Filled)
            {
                var brush = new SolidBrush(Color);
                graphics.FillRectangle(brush, rec);
            }
            else
            {
                var pen = new Pen(Color, 3);
                graphics.DrawRectangles(pen, new RectangleF[] { rec });
            }
        }
    }
}
