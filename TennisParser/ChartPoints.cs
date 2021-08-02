using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace ChartPoints
{
    public class ChartPoints
    {
        private Bitmap chartBitmap;

        private Graphics chartGraphics;

        private int height;

        private int width;

        public ChartPoints(int width, int height)
        {
            this.height = height;

            this.width = width;

            chartBitmap = new Bitmap(width, height);

            chartGraphics = Graphics.FromImage(chartBitmap);
        }

        public Bitmap GetChart(List<int> values)
        {
            /*int maxAbs = Math.Abs(values.Max()) > Math.Abs(values.Min()) ? Math.Abs(values.Max()) : Math.Abs(values.Min());


            DrawHorizontalLines(maxAbs);

            DrawVerticalLines(values.Count, maxAbs);

            */

            DrawGrid(values);

            DrawChart(values);

            return chartBitmap;
        }

        private void DrawGrid(List<int> values)
        {
            int maxAbs = Math.Abs(values.Max()) > Math.Abs(values.Min()) ? Math.Abs(values.Max()) : Math.Abs(values.Min());

            DrawHorizontalLines(maxAbs);

            DrawVerticalLines(values.Count, maxAbs);
        }

        private void DrawChart(List<int> values)
        {
            int maxAbs = Math.Abs(values.Max()) > Math.Abs(values.Min()) ? Math.Abs(values.Max()) : Math.Abs(values.Min());

            float stepX = width / values.Count;

            float stepY = height / (maxAbs * 2 + 1);

            List<PointF> pointValues = new List<PointF>();

            for (int i = 0; i < values.Count; ++i)
            {
                /*PointF p1 = new PointF(stepX * (i), 0);

                PointF p2 = new PointF(stepX * (i), height);

                PointF p3 = new PointF(stepX * (i), stepY * maxAbs);

                chartGraphics.DrawLine(new Pen(new SolidBrush(Color.Black), 0.1f), p1, p2);

                chartGraphics.DrawString(i.ToString(), new Font("Microsft Sans Serif", 6), new SolidBrush(Color.Black), p3);*/

                PointF point = new PointF(stepX * i, stepY * (maxAbs - values[i]));

                pointValues.Add(point);
            }

            chartGraphics.DrawLines(new Pen(new SolidBrush(Color.Blue), 2), pointValues.ToArray());
        }


        private void DrawHorizontalLines(int maxAbs)
        {
            float stepY = height / (maxAbs * 2 + 1);

            for (int i = 0; i <= maxAbs * 2 + 1; ++i)
            {
                PointF p1 = new PointF(0, stepY * i);

                PointF p2 = new PointF(width, stepY * i);

                PointF p3 = new PointF(0, stepY * i);

                Color color = maxAbs - i == 0 ? Color.Red : Color.Black;

                chartGraphics.DrawLine(new Pen(new SolidBrush(color), 0.1f), p1, p2);

                chartGraphics.DrawString((maxAbs - i).ToString(), new Font("Microsft Sans Serif", 6), new SolidBrush(Color.Black), p3);

            }

        }

        private void DrawVerticalLines(int countValues, int maxAbs)
        {
            float stepX = width / countValues;

            float stepY = height / (maxAbs * 2 + 1);

            for (int i = 0; i <= countValues; ++i)
            {
                PointF p1 = new PointF(stepX * (i), 0);

                PointF p2 = new PointF(stepX * (i), height);

                PointF p3 = new PointF(stepX * (i), stepY * maxAbs);

                chartGraphics.DrawLine(new Pen(new SolidBrush(Color.Black), 0.1f), p1, p2);

                chartGraphics.DrawString(i.ToString(), new Font("Microsft Sans Serif", 6), new SolidBrush(Color.Black), p3);
            }
        }
    }
}
