using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorGraphicViewer.Desktop.Data;
using VectorGraphicViewer.Desktop.Extensions;
using VectorGraphicViewer.Desktop.Shapes;

namespace VectorGraphicViewer.Desktop
{
    public partial class Form1 : Form
    {
        private readonly IFileDataReader _fileDataReader;

        public Form1()
        {
            _fileDataReader = Program.GetService<IFileDataReader>();

            InitializeComponent();
            //Screen myScreen = Screen.FromControl(this);
            //Rectangle area = myScreen.WorkingArea;
            //this.Size = new Size(area.Width, area.Height);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var filePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Data/initialData.json");
            var data = _fileDataReader.Read(filePath);

            foreach (var item in data)
            {
                if (item.Type == ShapeConts.Line)
                {
                    var pointFA = item.A.ToPointF();
                    var pointFB = item.B.ToPointF();
                    var line = new Line(item.Color.ToColor(), pointFA, pointFB);
                    line.Draw(e.Graphics);
                }
                else if (item.Type == ShapeConts.Circle)
                {
                    var center = item.Center.ToPointF();
                    var circle = new Circle(item.Color.ToColor(), center, item.Radius, item.Filled);
                    circle.Draw(e.Graphics);
                }
                else if (item.Type == ShapeConts.Triangle)
                {
                    var pointFA = item.A.ToPointF();
                    var pointFB = item.B.ToPointF();
                    var pointFC = item.C.ToPointF();
                    var circle = new Triangle(item.Color.ToColor(), pointFA, pointFB, pointFC, item.Filled);
                    circle.Draw(e.Graphics);
                }
            }
        }
    }
}