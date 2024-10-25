using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace help_me_fractals_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var lSystem = new LSystem("C:/Users/Platon/Downloads/help_me(fractals)/help_me(fractals)/LSystem_Tree3.txt");
            var fractal = GenerateFractal(lSystem, 4);
            var startPoint = new PointF(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            //DrawFractal(e.Graphics, fractal, lSystem.Angle, lSystem.InitialDirection, startPoint, 5);
            //DrawFractal_Classic(e.Graphics, fractal, lSystem.Angle, lSystem.InitialDirection, startPoint, 5);
            DrawFractal_Color(e.Graphics, fractal, lSystem.Angle, lSystem.InitialDirection, startPoint, 5);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private string GenerateFractal(LSystem lSystem, int iterations)
        {
            var current = lSystem.Axiom.ToString();
            for (int i = 0; i < iterations; i++)
            {
                var next = "";
                foreach (var c in current)
                {
                    next += lSystem.Rules.ContainsKey(c) ? lSystem.Rules[c] : c.ToString();
                }
                current = next;
            }
            return current;
        }


        private void DrawFractal(Graphics g, string fractal, float angle, float initialDirection, PointF startPoint, float scale)
        {

            var stack = new Stack<(PointF, float)>();
            var currentPoint = startPoint;
            var currentAngle = initialDirection;
            var random = new Random();

            bool flag = false;

            // Вычисление границ фрактала
            float minX = currentPoint.X, maxX = currentPoint.X, minY = currentPoint.Y, maxY = currentPoint.Y;

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
                            currentPoint.X + (float)(Math.Cos(currentAngle * Math.PI / 180) * scale),
                            currentPoint.Y + (float)(Math.Sin(currentAngle * Math.PI / 180) * scale)
                        );
                        minX = Math.Min(minX, newPoint.X);
                        maxX = Math.Max(maxX, newPoint.X);
                        minY = Math.Min(minY, newPoint.Y);
                        maxY = Math.Max(maxY, newPoint.Y);
                        currentPoint = newPoint;
                        break;
                    case '+':
                        if (flag)
                            angle = random.Next(45);
                        currentAngle += angle;
                        break;
                    case '-':
                        if (flag)
                            angle = random.Next(45);
                        currentAngle -= angle;
                        break;
                    case '[':
                        stack.Push((currentPoint, currentAngle));
                        break;
                    case ']':
                        var state = stack.Pop();
                        currentPoint = state.Item1;
                        currentAngle = state.Item2;
                        break;
                }
            }
            // Масштабирование
            float width = maxX - minX;
            float height = maxY - minY;
            float scaleX = this.ClientSize.Width / width;
            float scaleY = this.ClientSize.Height / height;
            float finalScale = Math.Min(scaleX, scaleY);

            // Сброс текущих значений
            currentPoint = startPoint;
            currentAngle = initialDirection;
            stack.Clear();
            flag = false;

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
                            currentPoint.X + (float)(Math.Cos(currentAngle * Math.PI / 180) * finalScale),
                            currentPoint.Y + (float)(Math.Sin(currentAngle * Math.PI / 180) * finalScale)
                        );
                        g.DrawLine(Pens.Black, currentPoint, newPoint);
                        currentPoint = newPoint;
                        break;
                    case '+':
                        if (flag)
                            angle = random.Next(45);
                        currentAngle += angle;
                        break;
                    case '-':
                        if (flag)
                            angle = random.Next(45);
                        currentAngle -= angle;
                        break;
                    case '[':
                        stack.Push((currentPoint, currentAngle));
                        break;
                    case ']':
                        var state = stack.Pop();
                        currentPoint = state.Item1;
                        currentAngle = state.Item2;
                        break;
                }
            }
        }
        private void DrawFractal_Classic(Graphics g, string fractal, float angle, float initialDirection, PointF startPoint, float scale)
        {
            var stack = new Stack<(PointF, float)>();
            var currentPoint = startPoint;
            var currentAngle = initialDirection;
            var random = new Random();

            bool flag = false;
            //List<char> randomRules = new List<char> {'+', '-', '[', ']' };

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
                            currentPoint.X + (float)(Math.Cos(currentAngle * Math.PI / 180) * scale),
                            currentPoint.Y + (float)(Math.Sin(currentAngle * Math.PI / 180) * scale)
                        );
                        g.DrawLine(Pens.Black, currentPoint, newPoint);
                        currentPoint = newPoint;
                        break;
                    case '+':
                        if (flag)
                            angle = random.Next(45);
                        currentAngle += angle;
                        break;
                    case '-':
                        if (flag)
                            angle = random.Next(45);
                        currentAngle -= angle;
                        break;
                    case '[':
                        stack.Push((currentPoint, currentAngle));
                        break;
                    case ']':
                        var state = stack.Pop();
                        currentPoint = state.Item1;
                        currentAngle = state.Item2;
                        break;
                }
            }
        }

        private void DrawFractal_Color(Graphics g, string fractal, float angle, float initialDirection, PointF startPoint, float scale)
        {
            var stack = new Stack<(PointF, float)>();
            var currentPoint = startPoint;
            var currentAngle = initialDirection;
            var random = new Random();

            bool flag = false;

            // Вычисление границ фрактала
            float minX = currentPoint.X, maxX = currentPoint.X, minY = currentPoint.Y, maxY = currentPoint.Y;

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
                            currentPoint.X + (float)(Math.Cos(currentAngle * Math.PI / 180) * scale),
                            currentPoint.Y + (float)(Math.Sin(currentAngle * Math.PI / 180) * scale)
                        );
                        minX = Math.Min(minX, newPoint.X);
                        maxX = Math.Max(maxX, newPoint.X);
                        minY = Math.Min(minY, newPoint.Y);
                        maxY = Math.Max(maxY, newPoint.Y);
                        currentPoint = newPoint;
                        break;
                    case '+':
                        if (flag)
                            angle = random.Next(45);
                        currentAngle += angle;
                        break;
                    case '-':
                        if (flag)
                            angle = random.Next(45);
                        currentAngle -= angle;
                        break;
                    case '[':
                        stack.Push((currentPoint, currentAngle));
                        break;
                    case ']':
                        var state = stack.Pop();
                        currentPoint = state.Item1;
                        currentAngle = state.Item2;
                        break;
                }
            }

            // Масштабирование
            float width = maxX - minX;
            float height = maxY - minY;
            float scaleX = this.ClientSize.Width / width;
            float scaleY = this.ClientSize.Height / height;
            float finalScale = Math.Min(scaleX, scaleY);

            // Сброс текущих значений
            currentPoint = startPoint;
            currentAngle = initialDirection;
            stack.Clear();
            flag = false;

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
                            currentPoint.X + (float)(Math.Cos(currentAngle * Math.PI / 180) * finalScale),
                            currentPoint.Y + (float)(Math.Sin(currentAngle * Math.PI / 180) * finalScale)
                        );

                        // Вычисление цвета в зависимости от вертикальной позиции
                        float positionRatio = (newPoint.Y - minY) / height;
                        positionRatio = Math.Max(0, Math.Min(1, positionRatio));
                        var color = InterpolateColor(Color.Green, Color.Brown, positionRatio);

                        using (var pen = new Pen(color))
                        {
                            g.DrawLine(pen, currentPoint, newPoint);
                        }
                        currentPoint = newPoint;
                        break;
                    case '+':
                        if (flag)
                            angle = random.Next(45);
                        currentAngle += angle;
                        break;
                    case '-':
                        if (flag)
                            angle = random.Next(45);
                        currentAngle -= angle;
                        break;
                    case '[':
                        stack.Push((currentPoint, currentAngle));
                        break;
                    case ']':
                        var state = stack.Pop();
                        currentPoint = state.Item1;
                        currentAngle = state.Item2;
                        break;
                }
            }

        }
        private Color InterpolateColor(Color color1, Color color2, float ratio)
        {
            ratio = Math.Max(0, Math.Min(1, ratio));
            int r = (int)(color1.R + (color2.R - color1.R) * ratio);
            int g = (int)(color1.G + (color2.G - color1.G) * ratio);
            int b = (int)(color1.B + (color2.B - color1.B) * ratio);
            return Color.FromArgb(r, g, b);
        }
    }

}

        

