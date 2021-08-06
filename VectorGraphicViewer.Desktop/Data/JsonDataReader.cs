using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace VectorGraphicViewer.Desktop.Data
{
    public class JsonDataReader : IFileDataReader
    {
        public List<ShapeInfo> Read(string path)
        {
            return JsonConvert.DeserializeObject<List<ShapeInfo>>(File.ReadAllText(path));
        }
    }
}
