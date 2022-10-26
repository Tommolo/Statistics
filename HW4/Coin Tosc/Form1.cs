namespace Coin_Tosc
{
    
    public partial class Form1 : Form
    {
        public Bitmap b;
        public Graphics g;
        public Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            this.g=Graphics.FromImage(this.b);
            this.g.DrawRectangle(Pens.Black, 10, 10, 200, 150);
            this.g.FillRectangle(Brushes.Orange, 10, 10, 200, 150);
            this.pictureBox1.Image = b;

         /*-------------------------------------------------------------------------*/

            int trialsCount = 100;
            double y = 0; // false
            for (int j = 0; j < trialsCount; j++)
            {
                double uniform = r.NextDouble();
                if (uniform < 0.5)
                {
                    y = 1; // true
                }
                this.richTextBox1.AppendText("X = " + j  + " Y= " + y + "\n");
                y = 0;
            }
                
        }
        public int FromXrealToXVirtual(double x, double minX, double maxX, int w)
        {
            return ((int)(w * (x - minX) / (maxX - minX)));
        }
    }
}