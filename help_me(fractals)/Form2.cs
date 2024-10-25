using System;
using System.Drawing;
using System.Windows.Forms;

namespace help_me_fractals_
{
    public partial class Form2 : Form
    {
        private Bitmap bitmap;
        private Random random = new Random();

        public Form2()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(roughnessTextBox.Text, out float roughness))
            {
                return;
            }

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                PointF startPoint = new PointF(0, pictureBox1.Height / 2);
                PointF endPoint = new PointF(pictureBox1.Width, pictureBox1.Height / 2);

                MidpointDisplacement(g, startPoint, endPoint, roughness, detailLevelBar.Value);
                //FillBeforeBlackLine(bitmap);
            }

            pictureBox1.Image = bitmap;
            pictureBox1.Invalidate();
        }

        private void MidpointDisplacement(Graphics g, PointF start, PointF end, float roughness, int detailLevel)
        {
            if (detailLevel <= 0)
            {
                g.DrawLine(Pens.Black, start, end);
            }
            else
            {
                float midX = (start.X + end.X) / 2;
                float midY = (start.Y + end.Y) / 2;
                float length = (end.X - start.X) / pictureBox1.Width;
                float randomOffset = (float)(random.NextDouble() * (roughness * length * 2)) - (roughness * length);
                midY += randomOffset;

                PointF midPoint = new PointF(midX, midY);

                MidpointDisplacement(g, start, midPoint, roughness, detailLevel - 1);
                MidpointDisplacement(g, midPoint, end, roughness, detailLevel - 1);
            }
        }

        private void DrawStars(Graphics g, PointF start, PointF end)
        {
            int starCount = 100;
            Brush brush = new SolidBrush(Color.Purple);
            float lineY = (start.Y + end.Y) / 2;
            float starHeightOffset = 100;

            for (int i = 0; i < starCount; i++)
            {
                float x = (float)random.NextDouble() * pictureBox1.Width;
                float y = (float)random.NextDouble() * (lineY - starHeightOffset);
                g.FillRectangle(brush, x, y, 2, 2);
            }
        }

        private void FillBeforeBlackLine(Bitmap img)
        {
            Color fillColor = Color.CornflowerBlue;

            for (int x = 0; x < img.Width; x++)
            {
                bool foundBlackPixel = false;

                for (int y = 0; y < img.Height; y++)
                {
                    Color pixelColor = img.GetPixel(x, y);

                    if (pixelColor.ToArgb() == Color.Black.ToArgb())
                    {
                        foundBlackPixel = true;
                        break;
                    }

                    img.SetPixel(x, y, fillColor);
                }

                if (!foundBlackPixel)
                {
                    continue;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(roughnessTextBox.Text, out float roughness))
            {
                return;
            }

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                PointF startPoint = new PointF(0, pictureBox1.Height / 2);
                PointF endPoint = new PointF(pictureBox1.Width, pictureBox1.Height / 2);

                DrawStars(g, startPoint, endPoint);
            }

            pictureBox1.Image = bitmap;
            pictureBox1.Invalidate();
        }
    }
}
