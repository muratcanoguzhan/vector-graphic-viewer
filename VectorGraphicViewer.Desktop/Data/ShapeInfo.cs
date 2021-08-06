using System;
using System.Collections.Generic;
using System.Text;

namespace VectorGraphicViewer.Desktop.Data
{
    public class ShapeInfo
    {
        public string Type { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string Color { get; set; }
        public string Center { get; set; }
        public double? Radius { get; set; }
        public bool? Filled { get; set; }
    }
}
