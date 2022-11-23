using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Homework4
{
    
    public partial class Form1 : Form
    {
        internal class Interval
        {
            public int up;
            public int down;

            public Interval(int down, int up)
            {
                this.up = up;
                this.down = down;
            }

            public override string ToString()
            {
                return down.ToString() + " - " + up.ToString();
            }
        }
        Bitmap b;
        Graphics g;
        Random random = new Random();
        Pen PenTrajectory = new Pen(Color.OrangeRed, 1);
        double successProbability = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            successProbability = (double)numericUpDown3.Value;
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.White);

            int TrialsCount = (int)numericUpDown1.Value;
            int TrajectoryNumber = (int)numericUpDown2.Value;

            double minX = 0;
            double maxX = (double)TrialsCount;
            double minY = 0;
            double maxY = 0;
            if (checkBox3.Checked == true) maxY = (double)TrialsCount;
            if (checkBox1.Checked == true) maxY = 1;
            if (checkBox2.Checked == true) maxY = ((double)TrialsCount) / Math.Sqrt((double)TrialsCount);
            double Y = 0;

            Rectangle r = new Rectangle(20, 20, b.Width - 300, b.Height - 40);
            g.FillRectangle(Brushes.Black, r);
            g.DrawRectangle(Pens.Black, r);
            List<Point> lastpoints = new List<Point>();
            for (int t = 0; t < TrajectoryNumber; t++)
            {
                List<Point> points = new List<Point>();
                double Y1 = 0;
                for (int X = 0; X < TrialsCount; X++)
                {
                    random.NextDouble();

                    if (random.NextDouble() < successProbability) Y1 = Y1 + 1;
                    if (checkBox3.Checked == true) Y = Y1;
                    if (checkBox1.Checked == true) Y = Y1 / (X + 1);
                    if (checkBox2.Checked == true) Y = Y1 / Math.Sqrt(X + 1);
                    int xCord = linearTransformX(X, minX, maxX, r.Left, r.Width);
                    int yCord = linearTransformY(Y, minY, maxY, r.Top, r.Height);

                    Point p = new Point(xCord, yCord);
                    points.Add(p);

                    if (X == TrialsCount - 1)
                    {
                        lastpoints.Add(p);
                    }
                }
                g.DrawLines(PenTrajectory, points.ToArray());
            }
            int min_y = lastpoints.Min(p => p.Y);
            int max_y = lastpoints.Max(p => p.Y);

            Rectangle r2 = new Rectangle(r.Right + 10, 20, 260, b.Height - 40);
            g.FillRectangle(Brushes.Black, r2);
            g.DrawRectangle(Pens.Black, r2);
            if (TrajectoryNumber == 1)
            {
                foreach (Point p in lastpoints)
                {
                    Rectangle re = new Rectangle(r2.Left + 10, p.Y - 10, r2.Right - r2.Left - 20, 20);
                    g.FillRectangle(Brushes.Orange, re);
                    g.DrawRectangle(Pens.White, re);
                }
            }
            else
            {
                int intervals_number = TrajectoryNumber / 2;
                if (intervals_number > 15)
                {
                    intervals_number = 15;
                }
                else if (intervals_number <= 0)
                {
                    intervals_number = 1;
                }

                int span = max_y - min_y;
                int interval_size = (max_y - min_y) / intervals_number;

                while (min_y + interval_size * intervals_number < max_y + 1)
                {
                    intervals_number++;
                }

                int minimo = min_y;

                Dictionary<Interval, int> intervalli = new Dictionary<Interval, int>();

                for (int j = 0; j < intervals_number; j++)
                {
                    Interval intervallo = new Interval(minimo, minimo + interval_size);
                    minimo = minimo + interval_size;
                    intervalli[intervallo] = 0;
                }
                foreach (Point p in lastpoints)
                {
                    List<Interval> inter = intervalli.Keys.ToList();
                    int intY = (int)p.Y;

                    foreach (Interval i in inter)
                    {
                        if (intY >= i.down && intY < i.up)
                        {
                            intervalli[i]++;
                        }
                    }
                }
                List<Rectangle> chart = new List<Rectangle>();

                int dimdisp = r2.Right - r2.Left - 20; 
                int maxValue = intervalli.Values.Max();

                foreach (var v in intervalli)
                {
                    double intensity = ((double)v.Value / (double)maxValue) * dimdisp;
                    Rectangle rect = new Rectangle(r2.Left + 10, v.Key.down, (int)intensity, interval_size);
                    chart.Add(rect);
                }

                foreach (Rectangle re in chart)
                {
                    g.FillRectangle(Brushes.Orange, re);
                    g.DrawRectangle(Pens.White, re);
                }
                pictureBox1.Image = b;
            }
            pictureBox1.Image = b;
        }
            public int linearTransformX(double X, double minX, double maxX, int Left, int W)
            {
                return Left + (int)(W * ((X - minX) / (maxX - minX)));
            }

            public int linearTransformY(double Y, double minY, double maxY, int Top, int H)
            {
                return Top + (int)(H - H * ((Y - minY) / (maxY - minY)));
            }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox3.Checked = false;
            checkBox1.Checked = false;
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox3.Checked = false;
            checkBox2.Checked = false;
        }
    }
    
     
}
