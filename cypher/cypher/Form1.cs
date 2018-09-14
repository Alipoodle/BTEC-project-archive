using System;
using System.Windows.Forms;

namespace cypher
{
    public partial class Form1 : Form
    {
        string[] letterArray = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
        int offset = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] orignalText = textBox1.Text.ToCharArray();

            textBox3.Text = "";
            for (int i = 0; i < orignalText.Length; i++)
            {
                var pos = Array.IndexOf(letterArray, orignalText[i].ToString().ToLower());

                if (pos != -1)
                {
                    if (pos > ((letterArray.Length - 1) - offset))
                    {
                        pos -= letterArray.Length;
                    }
                    if (pos < (0 - offset))
                    {
                        pos += letterArray.Length;
                    }
                    textBox3.Text += letterArray[pos + offset].ToString();
                }
                else
                {
                    textBox3.Text += orignalText[i].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char[] orignalText = textBox1.Text.ToCharArray();

            textBox3.Text = "";
            for (int i = 0; i < orignalText.Length; i++)
            {
                var pos = Array.IndexOf(letterArray, orignalText[i].ToString().ToLower());

                if (pos != -1)
                {
                    if (pos < offset)
                    {
                        pos += letterArray.Length;
                    }
                    if (pos > ((letterArray.Length - 1) + offset))
                    {
                        pos -= letterArray.Length;
                    }
                    textBox3.Text += letterArray[pos - offset].ToString();
                }
                else
                {
                    textBox3.Text += orignalText[i].ToString();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {
                    offset = Int32.Parse(textBox2.Text);
                }
                catch
                {
                    MessageBox.Show("Please use a valid Number for offset!");
                }
            } else
            {
                offset = 0;
            }
        }
    }
}
