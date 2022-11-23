namespace App_NormalDistributions_C
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
        EditableRectangle r2;
        EditableRectangle r3;
        EditableRectangle r4;
        EditableRectangle r5;

        List<double> normal;
        Dictionary<Interval, int> normal_distribution;

        List<double> chisquared;
        Dictionary<Interval, int> chisquared_distribution;

        List<double> cauchy;
        Dictionary<Interval, int> cauchy_distribution;

        List<double> Ffisher;
        Dictionary<Interval, int> Ffisher_distribution;

        List<double> Tstudent;
        Dictionary<Interval, int> Tstudent_distribution;

        int numbersamples = 100000;

        private void InitializeGraphics()
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            r1 = new EditableRectangle(20, pictureBox1.Bottom / 2 + 40, b.Width / 4 -200, b.Height / 2 -200, pictureBox1, this);
            r2 = new EditableRectangle(b.Width/4, pictureBox1.Bottom / 2 - 40, b.Width / 4 - 200, b.Height / 2 - 200, pictureBox1, this);
            r3 = new EditableRectangle(20, 100, b.Width / 4 - 100, b.Height / 2 - 300, pictureBox1, this);
            r4 = new EditableRectangle(b.Width / 4 + 700, pictureBox1.Bottom / 2 + 40, b.Width / 4 - 100, b.Height / 2 - 100, pictureBox1, this);
            r5 = new EditableRectangle(b.Width / 2, 100, b.Width / 4 - 100, b.Height / 2 - 300, pictureBox1, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            NormalRVGenerator RVgen = new NormalRVGenerator();

            normal = new List<double>();
            chisquared = new List<double>();
            cauchy = new List<double>();
            Ffisher = new List<double>();
            Tstudent = new List<double>();

            for (int i = 0; i < numbersamples; i++)
            {
                (double X, double Y) = RVgen.getNewPair();

                normal.Add(X);
                chisquared.Add(X*X);
                cauchy.Add(X/Y);
                Ffisher.Add((X*X)/(Y*Y));
                Tstudent.Add(X/ Math.Sqrt((Y*Y)));
            }

            double cauchy_average = cauchy.Average();
            cauchy = cauchy.Where(x => (x >= cauchy_average - 50 && x <= cauchy_average + 50)).ToList();

            Ffisher = Ffisher.Where(x => (x <= 50)).ToList();
            Tstudent = Tstudent.Where(x => (x >= -50 && x <= 50)).ToList();

            normal_distribution = compute_distribution(normal, 0.2d);
            chisquared_distribution = compute_distribution(chisquared, 0.6d);
            cauchy_distribution = compute_distribution(cauchy, 5);
            Ffisher_distribution = compute_distribution(Ffisher, 1);
            Tstudent_distribution = compute_distribution(Tstudent, 1);

            timer1.Start();
        }

        private Dictionary<Interval, int> compute_distribution(List<double> lista, double interval_size)
        {
            Dictionary <Interval, int> distribution = new Dictionary<Interval, int>();
            double next = Math.Floor(lista.Min());

            foreach (double inter in lista)
            {
                bool inserted = false;

                List<Interval> keys = distribution.Keys.ToList();
                foreach (Interval v in keys)
                {
                    if (inter >= v.down && inter < v.up)
                    {
                        inserted = true;
                        distribution[v]++;
                    }
                }
                while (!inserted)
                {
                    Interval newint = new Interval(next, next + interval_size);
                    next = next + interval_size;
                    distribution[newint] = 0;

                    if (inter >= newint.down && inter < newint.up)
                    {
                        distribution[newint]++;
                        inserted = true;
                    }
                }
            }

            return distribution;
        }

        private void drawHistogram(Dictionary<Interval, int> distribution, EditableRectangle r, Graphics g, string text)
        {
            g.DrawRectangle(Pens.Transparent, r.r);
            g.FillRectangle(Brushes.Transparent, r.r);

            int maxvalue = distribution.Values.Max();
            int space_height = (r.r.Bottom - r.r.Top) - 20;

            int size = r.r.Width / distribution.Count;
            int X = r.r.Left;

            foreach (KeyValuePair<Interval, int> kv in distribution)
            {

                Interval i = kv.Key;

                int rect_height = (int)(((double)kv.Value / (double)maxvalue) * ((double)space_height));

                Rectangle histrect = new Rectangle(X, r.r.Bottom - rect_height, size, rect_height);
                g.FillRectangle(Brushes.Yellow, histrect);
                g.DrawRectangle(Pens.Green, histrect);

                X = X + size;
            }

            Rectangle stringPos = new Rectangle(r.r.Left, r.r.Top - 2*(r.r.Height/5), r.r.Width, r.r.Height / 5);
            Font font1 = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Pixel);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            Font goodFont = findFont(g, text, stringPos.Size, font1);

            g.DrawString(text, goodFont, Brushes.Black, stringPos, stringFormat);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            drawHistogram(normal_distribution, r1, g, "1");
            drawHistogram(chisquared_distribution, r2, g, "2");
            drawHistogram(cauchy_distribution, r3, g, "3");
            drawHistogram(Ffisher_distribution, r4, g, "4");
            drawHistogram(Tstudent_distribution, r5, g, "5");
            pictureBox1.Image = b;
        }

        private Font findFont(Graphics g, string myString, Size Room, Font PreferedFont)
        {
            SizeF RealSize = g.MeasureString(myString, PreferedFont);
            float HeightScaleRatio = Room.Height / RealSize.Height;
            float WidthScaleRatio = Room.Width / RealSize.Width;

            float ScaleRatio = (HeightScaleRatio < WidthScaleRatio) ? ScaleRatio = HeightScaleRatio : ScaleRatio = WidthScaleRatio;

            float ScaleFontSize = PreferedFont.Size * ScaleRatio;

            if (ScaleFontSize <= 0)
            {
                ScaleFontSize = 0.0000001f;
            }

            return new Font(PreferedFont.FontFamily, ScaleFontSize);
        }
    }
}