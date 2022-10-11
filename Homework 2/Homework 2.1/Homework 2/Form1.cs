using System.Collections.Specialized;
using System.Windows.Forms.VisualStyles;

namespace Homework_2
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int sum;
        int count;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            this.richTextBox1.AppendText("");
            this.timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                int val = random.Next(1, 10);
                sum += val;
                this.richTextBox1.AppendText(val.ToString() + "\n");
                count++;
                double average=sum/count;
                this.richTextBox1.AppendText("La media e' " + average.ToString() + "\n");
        }
    }
}