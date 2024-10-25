using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace help_me_fractals_
{
    public partial class Form3 : Form
    {
        private List<PointF> controlPoints = new List<PointF>();
        private PointF? selectedPoint = null;
        private Panel drawingPanel;
        public Form3()
        {
            this.Size = new Size(800, 600);
            drawingPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            drawingPanel.MouseDown += DrawingPanel_MouseDown;
            drawingPanel.MouseMove += DrawingPanel_MouseMove;
            drawingPanel.MouseUp += DrawingPanel_MouseUp;
            drawingPanel.Paint += DrawingPanel_Paint;

            this.Controls.Add(drawingPanel);
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (var point in controlPoints)
                {
                    if (IsPointSelected(point, e.Location))
                    {
                        selectedPoint = point;
                        return;
                    }
                }
                controlPoints.Add(e.Location);
                drawingPanel.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < controlPoints.Count; i++)
                {
                    if (IsPointSelected(controlPoints[i], e.Location))
                    {
                        controlPoints.RemoveAt(i);
                        drawingPanel.Invalidate();
                        return;
                    }
                }
            }
        }

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedPoint.HasValue && e.Button == MouseButtons.Left)
            {
                int index = controlPoints.IndexOf(selectedPoint.Value);
                controlPoints[index] = e.Location;
                selectedPoint = e.Location;
                drawingPanel.Invalidate();
            }
        }

        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            selectedPoint = null;
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            if (controlPoints.Count < 4)
                return;

            using (Pen pen = new Pen(Color.Black, 2))
            {
                for (int i = 0; i < controlPoints.Count - 3; i += 3)
                {
                    e.Graphics.DrawBezier(pen, controlPoints[i], controlPoints[i + 1], controlPoints[i + 2], controlPoints[i + 3]);
                }
            }

            foreach (var point in controlPoints)
            {
                e.Graphics.FillEllipse(Brushes.Red, point.X - 3, point.Y - 3, 6, 6);
            }
        }

        private bool IsPointSelected(PointF point, PointF location)
        {
            return Math.Abs(point.X - location.X) < 5 && Math.Abs(point.Y - location.Y) < 5;
        }
    }
}
