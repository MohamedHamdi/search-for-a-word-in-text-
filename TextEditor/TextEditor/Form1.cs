using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{

    public partial class TEform : Form
    {
        StringBuilder myString;
        string Flag;
        byte[] Asciibytes;
        byte[] Asciibytes2;
        List<int> SpaceIndexes = new List<int>();


        public TEform()
        {
            InitializeComponent();
            myString = new StringBuilder();


        }



        private void button1_Click(object sender, EventArgs e) // Search
        {

            SpaceIndexes.Clear();

            Flag = myString.ToString();
            Asciibytes = Encoding.ASCII.GetBytes(textBox1.Text);
            Asciibytes2 = Encoding.ASCII.GetBytes(Flag);

            for (int i = 0; i < Asciibytes2.Length; i++)
            {
                if (Asciibytes2[i] == 32) SpaceIndexes.Add(i);
                if (i == Asciibytes2.Length - 1) SpaceIndexes.Add(Asciibytes2.Length);
            }

            int sum = 0;
            for (int i = 0; i < Asciibytes.Length; i++)
            {
                sum += (Asciibytes[i] * (i + 1));
            }

            if (SpaceIndexes.Count > 1)
            {
                for (int i = 1; i < SpaceIndexes.Count; i++)
                {
                    if (sum == Search(SpaceIndexes[i - 1], SpaceIndexes[i]))
                    {
                        richTextBox1.Select(SpaceIndexes[i - 1], SpaceIndexes[i] - SpaceIndexes[i - 1]);
                        richTextBox1.SelectionColor = Color.Blue;
                        richTextBox1.SelectionBackColor = Color.Wheat;
                    }
                }
            }
        }

        public int Search(int startIndex, int EndIndex)
        {
            int sum = 0; int k = 0;
            for (int i = startIndex; i < EndIndex; i++)
            {
                sum += (Asciibytes2[i] * (k + 1));
                k++;
            }
            return sum;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            myString.Clear();
            myString.Append(richTextBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.Replace(textBox1.Text, textBox2.Text);
        }

        public static string ReverseString(string word)
        {
            char[] arr = word.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

       
    }
}
