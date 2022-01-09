using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapesCourseWork
{
    class Circle: Shape
    {
        protected int Radius { get; set; }
        public Circle(Point position, int radius, Color colorBorder, Color colorFill)
            : base(position, radius, radius, colorBorder, colorFill)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
        }

        public override void DrawShape(Graphics graphics)
        {
            if (ColorFill.HasValue)
            {
                using (var brush = new SolidBrush(ColorFill.Value))
                {
                    graphics.FillEllipse(brush, Position.X, Position.Y, Width, Height);
                }
            }
            using (Pen pen = new Pen(ColorBorder, 2))
            {
                graphics.DrawEllipse(pen, Position.X, Position.Y, Width, Height);
            }
        }

        public override bool Contains(Point point)
        {
            return
                (point.X > Position.X && point.X < Position.X + Radius) &&
                (point.Y > Position.Y && point.Y < Position.Y + Radius);
        }
    }
}
