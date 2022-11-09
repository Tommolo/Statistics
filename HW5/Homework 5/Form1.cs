namespace Homework_5
{
    public partial class Form1 : Form
    {
        Bitmap b;
        Graphics g;
        Rectangle virtualWindow;

        Dictionary<double, long> d = new Dictionary<double, long>();
        bool vertical = false;

        int x_mouse, y_mouse;
        int x_down, y_down;

        int r_width, r_height;

        bool drag = false;
        bool resizing = false;

        bool pictureBox1_MouseWheel_SR;

        Pen penRectangle = new Pen(Color.Green, 0.2f);

        public Form1()
        {
            InitializeComponent();
            d.Add(0, 10);
            d.Add(1, 30);
            d.Add(2, 20);
            d.Add(7, 15);
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            pictureBox1.Image = b;
            virtualWindow = new Rectangle(20, 20, b.Width - 40, b.Height - 40);
            timer1.Enabled = true;
            timer1.Interval = 16;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!virtualWindow.Contains(e.X, e.Y)) return;

            x_mouse = e.X;
            y_mouse = e.Y;

            x_down = virtualWindow.X;
            y_down = virtualWindow.Y;

            r_width = virtualWindow.Width;
            r_height = virtualWindow.Height;

            if (e.Button == MouseButtons.Left)
            {
                drag = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                resizing = true;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            resizing = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (b == null) return;

            int delta_x = e.X - x_mouse;
            int delta_y = e.Y - y_mouse;



            if (drag)
            {
                virtualWindow.X = x_down + delta_x;
                virtualWindow.Y = y_down + delta_y;
                if (virtualWindow.X < 0) virtualWindow.X = 0;
                if (virtualWindow.Y < 0) virtualWindow.Y = 0;
                if (virtualWindow.X > pictureBox1.Width - virtualWindow.Width) virtualWindow.X = pictureBox1.Width - virtualWindow.Width;
                if (virtualWindow.Y > pictureBox1.Height - virtualWindow.Height) virtualWindow.Y = pictureBox1.Height - virtualWindow.Height;
            }
            else if (resizing)
            {

                virtualWindow.Width = r_width + delta_x;
                virtualWindow.Height = r_height + delta_y;
                if (virtualWindow.Width < 100) virtualWindow.Width = 100;
                if (virtualWindow.Height < 100) virtualWindow.Height = 100;
                if (virtualWindow.Width > pictureBox1.Width - 20) virtualWindow.Width = pictureBox1.Width - 20;
                if (virtualWindow.Height > pictureBox1.Height - 20) virtualWindow.Height = pictureBox1.Height - 20;
            }

        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!(ModifierKeys == Keys.Control)) return;
            if (pictureBox1_MouseWheel_SR) return;

            pictureBox1_MouseWheel_SR = true;

            float stepZoom;
            if (ModifierKeys == (Keys.Shift | Keys.Control))
            {
                stepZoom = 0.01F;
            }
            else
            {
                stepZoom = 0.1F;
            }

            virtualWindow.Inflate((int)(e.Delta * stepZoom), (int)(e.Delta * stepZoom));
            
            if (virtualWindow.Width < 100) virtualWindow.Width = 100;
            if (virtualWindow.Height < 100) virtualWindow.Height = 100;
            if (virtualWindow.Width > pictureBox1.Width - 20) virtualWindow.Width = pictureBox1.Width - 20;
            if (virtualWindow.Height > pictureBox1.Height - 20) virtualWindow.Height = pictureBox1.Height - 20;
            pictureBox1_MouseWheel_SR = false;

        }

        private void generateHistogram(Rectangle r, Dictionary<double, long> d, bool vertical = false)
        {
            int n = d.Count;

            double maxKey = d.Keys.Max();
            double maxValue = d.Values.Max();
            for (int i = 0; i < n; i++)
            {
                Rectangle rr;
                int left, top, right, bottom;
                if (vertical)
                {
                    left = fromXRealToXVirtual(0, 0, maxValue, r.Left, r.Width);
                    top = fromYRealToYVirtual(i + 1, 0, n, r.Top, r.Height);
                    right = fromXRealToXVirtual(d.ElementAt(i).Value, 0, maxValue, r.Left, r.Width);
                    bottom = fromYRealToYVirtual(i, 0, n, r.Top, r.Height);
                }
                else
                {
                    left = fromXRealToXVirtual(i, 0, n, r.Left, r.Width);
                    top = fromYRealToYVirtual(d.ElementAt(i).Value, 0, maxValue, r.Top, r.Height);
                    right = fromXRealToXVirtual(i + 1, 0, n, r.Left, r.Width);
                    bottom = fromYRealToYVirtual(0, 0, maxValue, r.Top, r.Height);
                }
                rr = Rectangle.FromLTRB(left, top, right, bottom);

                g.DrawRectangle(penRectangle, rr);
                g.FillRectangle(new SolidBrush(Color.FromArgb(64, 0, 255, 0)), rr);

                g.DrawString(vertical ? d.ElementAt(i).Key.ToString() : d.ElementAt(i).Value.ToString(), DefaultFont, Brushes.Black, r.Right, vertical ? (top + bottom) / 2 : top);
                g.DrawString(vertical ? d.ElementAt(i).Value.ToString() : d.ElementAt(i).Key.ToString(), DefaultFont, Brushes.Black, vertical ? right : (left + right) / 2, r.Bottom);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            redraw();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            vertical = checkBox1.Checked;
        }

        private int fromXRealToXVirtual(double x, double minX, double maxX, int left, int w)
        {
            return left + (int)(w * (x - minX) / (maxX - minX));
        }

        private int fromYRealToYVirtual(double y, double minY, double maxY, int top, int h)
        {
            return top + (int)(h - h * (y - minY) / (maxY - minY));
        }

        private void redraw()
        {

            g.Clear(BackColor);
            generateHistogram(virtualWindow, d, vertical);
            g.DrawRectangle(Pens.DarkSlateGray, virtualWindow);

            pictureBox1.Image = b;
        }
    }
}