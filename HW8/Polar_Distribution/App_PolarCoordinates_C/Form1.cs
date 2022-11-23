namespace App_PolarCoordinates_C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeGraphics();
        }

        Bitmap b;
        Graphics g;
        EditableRectangle r1;
        Pen PenTrajectory;

        decimal pointnumber = 1000;

        double minX;
        double maxX;
        double minY;
        double maxY;

        List<RealPoint> points;

        Dictionary<Interval, int> distribution_x;
        Dictionary<Interval, int> distribution_y;

        private void InitializeGraphics()
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            r1 = new EditableRectangle(20, pictureBox1.Bottom/2 -200, pictureBox1.Width/2, pictureBox1.Height/2, pictureBox1, this);
            PenTrajectory = new Pen(Color.OrangeRed, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            minX = -100d;
            maxX = 100d;
            minY = -100d;
            maxY = 100d;
            
            CoordinatesGenerator cg = new CoordinatesGenerator(100);
            points = new List<RealPoint>();

            for (int i = 0; i < pointnumber; i++)
            {
                (double X, double Y) = cg.getNewPair();
                RealPoint punto = new RealPoint(X, Y);
                points.Add(punto);
            }

            compute_distribution_x();
            compute_distribution_y();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            drawPoints();
            drawHistogram_x();
            drawHistogram_y();
            pictureBox1.Image = b;
        }

        private void drawPoints()
        {
            //g.DrawRectangle(Pens.Black, r1.r);
            g.FillRectangle(Brushes.White, r1.r);

            List<Point> punti = new List<Point>();

            foreach(RealPoint p in points)
            {
                int xCord = linearTransformX(p.X, minX, maxX, r1.r.Left, r1.r.Width);
                int yCord = linearTransformY(p.Y, minY, maxY, r1.r.Top, r1.r.Height);

                Point draw_p = new Point(xCord, yCord);
                punti.Add(draw_p);
            }

            foreach(Point dp in punti)
            {
                Rectangle rect = new Rectangle(dp.X , dp.Y , 10, 10);
                g.FillEllipse(Brushes.Green, rect);
            }
        }

        private void compute_distribution_x()
        {

            distribution_x = new Dictionary<Interval, int>();

            int current = (int)Math.Floor(minY);
            int max = (int)Math.Ceiling(maxY);

            int size = 10;

            while (current < max)
            {
                Interval i = new Interval(current, current + size);
                current = current + size;

                distribution_x[i] = 0;
            }

            foreach (RealPoint p in points)
            {
                List<Interval> keys = distribution_x.Keys.ToList();
                bool p_inserted = false;
                foreach (Interval v in keys)
                {
                    if (p.X >= v.down && p.X <= v.up && !p_inserted)
                    {
                        p_inserted = true;
                        distribution_x[v]++;
                    }
                }
            }
        }

        private void compute_distribution_y()
        {

            distribution_y = new Dictionary<Interval, int>();

            int current = (int)Math.Floor(minY);
            int max = (int)Math.Ceiling(maxY);

            int size = 10;

            while (current < max)
            {
                Interval i = new Interval(current, current + size);
                current = current + size;

                distribution_y[i] = 0;
            }

            foreach (RealPoint p in points)
            {
                List<Interval> keys = distribution_y.Keys.ToList();
                bool p_inserted = false;
                foreach (Interval v in keys)
                {
                    if (p.Y >= v.down && p.Y <= v.up && !p_inserted)
                    {
                        p_inserted = true;
                        distribution_y[v]++;
                    }
                }
            }
        }

        private void drawHistogram_y()
        {
            int maxvalue = distribution_y.Values.Max();
            int space_height = (r1.r.Right - r1.r.Left) / 2;

            foreach (KeyValuePair<Interval, int> kv in distribution_y)
            {

                Interval i = kv.Key;

                int rect_height = (int)(((double)kv.Value / (double)maxvalue) * ((double)space_height));

                int down_mod = linearTransformY(i.down, minY, maxY, r1.r.Top, r1.r.Height);
                int up_mod = linearTransformY(i.up, minY, maxY, r1.r.Top, r1.r.Height);

                int size = Math.Abs(down_mod - up_mod);

                Rectangle histrect = new Rectangle(r1.r.Right, up_mod, rect_height, size);
                g.FillRectangle(Brushes.Yellow, histrect);
                g.DrawRectangle(Pens.Green, histrect);
            }
        }

        private void drawHistogram_x()
        {
            int maxvalue = distribution_x.Values.Max();
            int space_height = (r1.r.Bottom - r1.r.Top) / 2;

            foreach (KeyValuePair<Interval, int> kv in distribution_x)
            {

                Interval i = kv.Key;

                int rect_height = (int)(((double)kv.Value / (double)maxvalue) * ((double)space_height));

                int down_mod = linearTransformX(i.down, minY, maxY, r1.r.Left, r1.r.Width);
                int up_mod = linearTransformX(i.up, minY, maxY, r1.r.Left, r1.r.Width);

                int size = Math.Abs(down_mod - up_mod);

                Rectangle histrect = new Rectangle(down_mod, r1.r.Top - rect_height, size, rect_height);
                g.FillRectangle(Brushes.Yellow, histrect);
                g.DrawRectangle(Pens.Green, histrect);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            pointnumber = numericUpDown1.Value;
            label1.Text = "Points Generated --> " + pointnumber.ToString();
        }

        public int linearTransformX(double X, double minX, double maxX, int Left, int W)
        {
            return Left + (int)(W * ((X - minX) / (maxX - minX)));
        }

        public int linearTransformY(double Y, double minY, double maxY, int Top, int H)
        {
            return Top + (int)(H - H * ((Y - minY) / (maxY - minY)));
        }

       
    }
}