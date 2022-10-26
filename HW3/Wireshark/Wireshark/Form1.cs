using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace Wireshark
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> diz = new Dictionary<string, int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextFieldParser parser = new TextFieldParser("C:\Users\pieru\OneDrive - Universita degli Studi Roma Tre\OneDriveRoma3\OneDrive - Universita degli Studi Roma Tre\Desktop\Magistrale\Statistics\Homeworks\Homework 3\analize.csv");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                string[] row = parser.ReadFields();
                string key = row[2];

                if (diz.ContainsKey(key)) diz[key]++;
                else diz.Add(key, 1);

            }
            this.richTextBox1.AppendText("TCP Errors: \n\n");
            foreach (string key in diz.Keys)
            {
                if (key.Equals("Errori TCP")) continue;
                this.richTextBox1.AppendText(key + " : " + diz[key] + "\n");

            }
        }
    }
}
