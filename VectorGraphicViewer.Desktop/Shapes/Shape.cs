using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace VectorGraphicViewer.Desktop.Shapes
{
    public class Shape
    {
        public Color Color { get; private set; }

        public Shape(Color color)
        {
            Color = color;
        }

        public virtual void Draw(Graphics graphics)
        {
        }
    }
}
