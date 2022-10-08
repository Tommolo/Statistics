using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Homework1_
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int addend1;
        int addend2;
        int addend3;
        int addend4;
        int result1; // result1 is result of second sum
        int result2; // result2 is result of third sum
        int timeLeft; // This integer variable keeps track of the remaing time

        public Form1()
        {
            InitializeComponent();
            
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // If CheckTheAnswer() returns false, keep counting
                // down. Decrease the time left by one second and 
                // display the new time left by updating the 
                // Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                
            }

            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                answer1.Width = 100;
                answer1.Height = 50;
                answer2.Width = 100;
                answer2.Height = 50;
                answer3.Width = 100;
                answer3.Height = 50;

                answer1.Text = (addend1 + addend2).ToString();
                answer1.ForeColor = Color.Red;

                
                answer2.Text = (result1 - addend3).ToString();
                answer2.ForeColor = Color.Red;

                answer3.Text = (result2 - addend4).ToString();
                answer3.ForeColor = Color.Red;

                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                startButton.Enabled = true;
            }

        }

        /// <summary>
        /// Start the quiz by filling in all of the problems
        /// and starting the timer.
        /// </summary>
        public void startQuiz()
        {
            // set size answer to 0
            answer1.Width = 0;
            answer1.Height = 0;
            answer2.Width = 0;
            answer2.Height = 0;
            answer3.Width = 0;
            answer3.Height = 0;


            timeLeft = 15;
            timeLabel.Text = "15 Seconds";
            timer1.Start();

            addend1 = random.Next(51);
            addend2 = random.Next(51);
            plusLeftLabel1.Text = addend1.ToString();
            plusRightLabel1.Text = addend2.ToString();

            addend3 = random.Next(51);
            result1 = random.Next(52,100);
            plusLeftLabel2.Text = addend3.ToString();
            sum2.Text = result1.ToString();

            addend4 = random.Next(51);
            result2 = random.Next(52,100);
            plusRighLabel2.Text = addend4.ToString();
            sum3.Text = result2.ToString();

         

        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum1.Value) && (result1 - addend3 == plusRightNumeric1.Value)
                && (result2 - addend4 == plusLeftNumeric1.Value))
                return true;
            else
                return false;
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            startQuiz();
            startButton.Enabled = true;

        }
      
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        
        private void plusRightLabel_Click(object sender, EventArgs e)
        {

        }

        private void plusLeftLabel_Click(object sender, EventArgs e)
        {

        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}