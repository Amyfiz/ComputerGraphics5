using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace help_me_fractals_
{
    public partial class Form1b : Form
    {
        public Form1b()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1b_Paint);
        }

        private void Form1b_Paint(object sender, PaintEventArgs e)
        {
            var lSystem = new LSystem("C:/Users/Platon/Downloads/help_me(fractals)/help_me(fractals)/LSystem_Tree3.txt");
            var startPoint = new PointF(this.ClientSize.Width / 2, this.ClientSize.Height);
            var fractal = lSystem.Axiom.ToString();
            float length = 100;
            float thickness = 10;

            for (int i = 0; i < 5; i++)
            {
                fractal = GenerateFractal(lSystem, fractal);
                startPoint = DrawFractal(e.Graphics, fractal, lSystem.Angle, lSystem.InitialDirection, startPoint, length, thickness);
                length *= 0.7f;
                thickness *= 0.7f;
            }
        }

        private void Form1b_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private string GenerateFractal(LSystem lSystem, string current)
        {
            var next = "";
            foreach (var c in current)
            {
                next += lSystem.Rules.ContainsKey(c) ? lSystem.Rules[c] : c.ToString();
            }
            return next;
        }

        private PointF DrawFractal(Graphics g, string fractal, float angle, float initialDirection, PointF startPoint, float length, float thickness)
        {
            var stack = new Stack<(PointF, float, float, Color)>();
            var currentPoint = startPoint;
            var currentAngle = initialDirection;
            var currentThickness = thickness;
            var currentColor = Color.Brown;
            var random = new Random();

            bool flag = false;

            foreach (var c in fractal)
            {
                if (c == '@')
                {
                    flag = true;
                    continue;
                }
                switch (c)
                {
                    case 'F':
                        var newPoint = new PointF(
                            currentPoint.X + (float)(Math.Cos(currentAngle * Math.PI / 180) * length),
                            currentPoint.Y + (float)(Math.Sin(currentAngle * Math.PI / 180) * length)
                        );
                        using (var pen = new Pen(currentColor, currentThickness))
                        {
                            g.DrawLine(pen, currentPoint, newPoint);
                        }
                        currentPoint = newPoint;
                        currentThickness *= 0.7f; // Уменьшение толщины
                        currentColor = Color.FromArgb(
                            (int)(currentColor.R * 0.7 + 0.3 * Color.Green.R),
                            (int)(currentColor.G * 0.7 + 0.3 * Color.Green.G),
                            (int)(currentColor.B * 0.7 + 0.3 * Color.Green.B)
                        );
                        break;
                    case '+':
                        currentAngle += random.Next(45);
                        break;
                    case '-':
                        currentAngle -= random.Next(45);
                        break;
                    case '[':
                        stack.Push((currentPoint, currentAngle, currentThickness, currentColor));
                        break;
                    case ']':
                        var state = stack.Pop();
                        currentPoint = state.Item1;
                        currentAngle = state.Item2;
                        currentThickness = state.Item3;
                        currentColor = state.Item4;
                        break;
                }
            }

            return currentPoint;
        }
    }
}
