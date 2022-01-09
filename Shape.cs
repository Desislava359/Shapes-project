using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapesCourseWork
{
    abstract class Shape
    {
        public Point Position { get; set; }

        protected int Width { get; set; }

        protected int Height { get; set; }

        public Color ColorBorder { get; set; }

        public Color? ColorFill { get; set; }
        public int Order { get; internal set; }

        public Shape(Point position, int width, int height, Color colorBorder, Color colorFill)
        {
            Position = position;
            Width = width;
            Height = height;
            ColorBorder = colorBorder;
            ColorFill = colorFill;
        }

        public virtual double Area()
        {
            return (Width * Height);
        }

        public abstract void DrawShape(Graphics graphics);

        public abstract bool Contains(Point point);
    }
}
