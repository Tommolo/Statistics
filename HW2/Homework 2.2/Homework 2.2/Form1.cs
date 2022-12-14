using System.Data;
using System.Windows.Forms;

namespace Homework_2._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public DataTable ReadCsvFile(string file)
        {
            DataTable dt = new DataTable();
            using (StreamReader streamReader = new StreamReader(file))
            {
                while (!streamReader.EndOfStream)
                {
                    string text = streamReader.ReadToEnd();
                    string[] rows = text.Split('\n');
                    if (rows.Length > 0)
                    {
                        //Add columns
                        string[] columns = rows[0].Split(';');
                        for (int j = 0; j < columns.Count(); j++)
                            dt.Columns.Add(columns[j]);
                        //Add rows
                        for (int i = 1; i < rows.Count() - 1; i++)
                        {
                            string[] data = rows[i].Split(';');
                            DataRow dr = dt.NewRow();
                            for (int k = 0; k < data.Count(); k++)
                                dr[k] = data[k];
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV file|*.csv" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.textBox2.Text = ofd.FileName;
                    dataGridView1.DataSource = ReadCsvFile(ofd.FileName);
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /**
         * This method count the number of female and male
         */
        private void button2_Click(object sender, EventArgs e)
        {
                int countFemale = 0;
                int countMale = 0;
             
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    if (string.Compare(this.dataGridView1[3, i].Value.ToString(),"male")==1)
                    {
                        countMale++;
                    
                    }
                    else if (string.Compare(this.dataGridView1[3, i].Value.ToString(),"female")==1)
                    {
                        countFemale++;  
                    }
                }
            this.richTextBox1.AppendText("Male: " + countMale + "\n");
            this.richTextBox1.AppendText("Female: " + countFemale + "\n");
        }

        }
    }
