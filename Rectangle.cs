using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapesCourseWork
{
    class Rectangle: Shape
    {
        public Rectangle(Point position, int width, int height, Color colorBorder, Color colorFill)
           : base(position, width, height, colorBorder, colorFill) { }


        public override void DrawShape(Graphics graphics)
        {
            if (ColorFill.HasValue)
            {
                using (var brush = new SolidBrush(ColorFill.Value))
                {
                    graphics.FillRectangle(brush, Position.X, Position.Y, Width, Height);
                }
            }
            using (Pen pen = new Pen(ColorBorder, 2))
            {
                graphics.DrawRectangle(pen, Position.X, Position.Y, Width, Height);
            }
        }

        public override bool Contains(Point point)
        {
            return
                (point.X > Position.X && point.X < Position.X + Width) &&
                (point.Y > Position.Y && point.Y < Position.Y + Height);
        }
    }
}
