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
using MyRectangle = VectorGraphicViewer.Desktop.Shapes.Rectangle;
using Rectangle = System.Drawing.Rectangle;

namespace VectorGraphicViewer.Desktop
{
    public partial class Form1 : Form
    {
        private readonly IFileDataReader _fileDataReader;
        List<ShapeInfo> ShapeInfos = null;
        public Form1()
        {
            _fileDataReader = Program.GetService<IFileDataReader>();

            InitializeComponent();
            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;
            MaximumSize = new Size(area.Width, area.Height);

            var filePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Data/initialData.json");
            ShapeInfos = _fileDataReader.Read(filePath);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var width = (float)ClientSize.Width;
            var height = (float)ClientSize.Height;

            var shapes = new List<Shape>();
            foreach (var item in ShapeInfos)
            {
                if (item.Type == ShapeConts.Line)
                {
                    var pointFA = item.A.ToPointF() + new SizeF(width / 2, height / 2);
                    var pointFB = item.B.ToPointF() + new SizeF(width / 2, height / 2);

                    var graphic = new Line(item.Color.ToColor());
                    graphic.AddPointF(pointFA);
                    graphic.AddPointF(pointFB);
                    shapes.Add(graphic);
                }
                else if (item.Type == ShapeConts.Circle)
                {
                    var center = item.Center.ToPointF() + new SizeF(width / 2, height / 2);

                    var graphic = new Circle(item.Color.ToColor(), item.Radius, item.Filled);
                    graphic.AddPointF(center);
                    shapes.Add(graphic);
                }
                else if (item.Type == ShapeConts.Triangle)
                {
                    var pointFA = item.A.ToPointF() + new SizeF(width / 2, height / 2);
                    var pointFB = item.B.ToPointF() + new SizeF(width / 2, height / 2);
                    var pointFC = item.C.ToPointF() + new SizeF(width / 2, height / 2);

                    var graphic = new Triangle(item.Color.ToColor(), item.Filled);
                    graphic.AddPointF(pointFA);
                    graphic.AddPointF(pointFB);
                    graphic.AddPointF(pointFC);
                    shapes.Add(graphic);
                }
                else if (item.Type == ShapeConts.Rectangle)
                {
                    var location = item.A.ToPointF() + new SizeF(width / 2, height / 2);
                    var size = item.Size.ToSizeF();
                    var graphic = new MyRectangle(item.Color.ToColor(), item.Filled, size);
                    graphic.AddPointF(location);
                    shapes.Add(graphic);
                }
            }

            var shapesWidth = shapes.Sum(x => x.GetWidth());
            var shapesHeight = shapes.Sum(x => x.GetHeight());

            var scaleX = width / 2 / shapesWidth;
            var scaleY = height / 2 / shapesHeight;
            foreach (var shape in shapes)
            {
                if (shape is Line)
                {
                    var item = shape.PointFs[1];
                    //shape.PointFs[1] = PointF.Empty + new SizeF(item.X * scaleX, item.Y);
                }
                //else if (shape is Circle)
                //{
                //    ((Circle)shape).Radius = ((Circle)shape).Radius * scaleX;
                //    shape.PointFs[0] = PointF.Empty + new SizeF(shape.PointFs[0].X * scaleX, shape.PointFs[0].Y * scaleY); ;
                //}
                else if (shape is Triangle)
                {
                    //var item = shape.PointFs[1];
                    //shape.PointFs[1] = PointF.Empty + new SizeF(item.X * scaleX, item.Y);
                    //var item2 = shape.PointFs[2];
                    //shape.PointFs[2] = PointF.Empty + new SizeF(item2.X * scaleX, item.Y);
                }

                shape.Draw(e.Graphics);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = $"{e.X} {e.Y}";
        }
    }
}