using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Assignments
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Csvreader()
        {
            //Get the Number of Lines from the File

            string[] lines = File.ReadAllLines(@"Scores.csv");

           




            string[] Score = null;
            string[] first;
            string[] last;

            float result1=0;

            string result2;
            string result3;

            int linenumberMin = 0;
            int linenumberMax = 0;
            var l = new List<float>();

            var min = 0.0;
            var max = 0.0;
            var avg = 0.0;
   

            for (int j = 1; j<lines.Length;j++)
            {
                Score = lines[j].Split(new char[] { ',' });
                
                result1 =float.Parse(Score[2]);
                result2 = Score[0];
                result2 = Score[1];

                l.Add(result1);

                min = l.Min();
                max = l.Max();
                avg = l.Average();
               
               linenumberMin = l.IndexOf(l.Min());
                linenumberMax= l.IndexOf(l.Max());

                result2 = Score[1];
                result3 = Score[0];

            }
 
     

            textBox1.Text = lines[linenumberMin + 1];
            textBox2.Text = lines[linenumberMax + 1];
            textBox3.Text = avg.ToString();

            
            GetMedian(l);

           

        }
        public void GetMedian(IEnumerable<float> source)
        {
            // Create a copy of the input, and sort the copy
            float[] temp = source.ToArray();
            Array.Sort(temp);
            int count = temp.Length;
            if (count % 2 == 0)
            {
                // count is even, average two middle elements
                float a = temp[count / 2 - 1];
                float b = temp[count / 2];
                textBox4.Text = ((a + b) / 2).ToString();
            }
            else
            {
                // count is odd, return the middle element
                textBox4.Text = temp[count / 2].ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Csvreader();
        }
    }
}
