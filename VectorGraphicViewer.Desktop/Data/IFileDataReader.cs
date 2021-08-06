using System;
using System.Collections.Generic;
using System.Text;

namespace VectorGraphicViewer.Desktop.Data
{
    public interface IFileDataReader
    {
        List<ShapeInfo> Read(string path);
    }
}
