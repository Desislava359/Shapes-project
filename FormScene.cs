using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawShapesCourseWork
{
    public partial class FormScene : Form
    {
        private char? Letter { get; set; }

        private Point? _ptFrom { get; set; }

        private List<Shape> _shapes = new List<Shape>();

        private List<Shape> _selectedShapes = new List<Shape>();

        public FormScene()
        {
            InitializeComponent();
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true
                );
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var shape in _shapes)
            {
                shape.DrawShape(e.Graphics);
            }
        }

        private List<Shape> WhereContains(Point point)
        {
            var shapeResult = new List<Shape>();

            foreach (var shape in _shapes)
            {
                if (shape.Contains(point))
                {
                    shapeResult.Add(shape);
                }
            }

            return shapeResult;
        }

        private void FormScene_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _ptFrom = e.Location;
            }

            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _selectedShapes = WhereContains(e.Location);
                using (var graphics = this.CreateGraphics())
                {
                    foreach (var shape in _selectedShapes)
                    {
                        shape.ColorBorder = Color.Aqua;
                        shape.ColorFill = Color.Aqua;
                        shape.DrawShape(graphics);
                    }
                }


            }
        }

        private void FormScene_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (_ptFrom != null && Letter != null)
                {
                    switch (Letter)
                    {
                        case 'r':

                            var rectangle = new Rectangle(
                                 _ptFrom.Value,
                                 e.Location.X - _ptFrom.Value.X,
                                 e.Location.Y - _ptFrom.Value.Y,
                                 Color.FromArgb(0, 0, 255),
                                 Color.FromArgb(255, 255, 255)
                                 );

                            Invalidate();
                            Application.DoEvents();

                            using (var graphics = CreateGraphics())
                            {
                                rectangle.DrawShape(graphics);
                            }
                            break;

              

                        case 'c':

                            var circle = new Circle(
                                _ptFrom.Value,
                                (e.Location.X - _ptFrom.Value.X) / 2,
                                Color.FromArgb(255, 0, 0),
                                Color.FromArgb(255, 255, 255)
                                );
                            Invalidate();
                            Application.DoEvents();

                            using (var graphics = CreateGraphics())
                            {
                                circle.DrawShape(graphics);
                            }
                            break;
                    }
                }
            }
        }

        private void FormScene_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var top = 0;
                foreach (var shape in _shapes)
                {
                    if (shape.Order > top)
                    {
                        top = shape.Order;
                    }
                }

                switch (Letter)
                {
                    case 'r':
                        var rectangle = new Rectangle(
                            _ptFrom.Value,
                            e.Location.X - _ptFrom.Value.X,
                            e.Location.Y - _ptFrom.Value.Y,
                            Color.FromArgb(0, 0, 255),
                            Color.FromArgb(0, 0, 255)
                            );
                        rectangle.Order = top + 1;
                        _shapes.Add(rectangle);
                        _ptFrom = null;
                        Invalidate();
                        break;

                    case 'c':
                        var circle = new Circle(
                            _ptFrom.Value,
                            (e.Location.X - _ptFrom.Value.X) / 2,
                            Color.FromArgb(255, 0, 0),
                            Color.FromArgb(255, 0, 0)
                            );
                        circle.Order = top + 1;
                        _shapes.Add(circle);
                        _ptFrom = null;
                        Invalidate();
                        break;
                }
            }
        }

        private void FormScene_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'r' || e.KeyChar == 'c')
            {
                Letter = e.KeyChar;
            }
        }

        private void FormScene_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (var shape in _selectedShapes)
                {
                    _selectedShapes.Remove(shape);
                }

                _selectedShapes.Clear();

                Invalidate();
            }
        }

        private void FormScene_DoubleClick(object sender, EventArgs e)
        {

        }

        private void FormScene_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                foreach (var shape in _selectedShapes)
                {
                    double area = shape.Area();
                    string sArea = area.ToString();
                    MessageBox.Show($"The area is: {sArea}");
                }

            }
        }
    }
}
