using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cow_and_Bell
{
    public partial class Form1 : Form
    {
        int[] pubNumbers;
        int guessCount = 0;
        

        public Form1()
        {
            InitializeComponent();
        }

        public int[] genNumber()
        {

            Random random = new Random();
            int d1 = random.Next(0, 9);
            int d2 = random.Next(0, 9);
            int d3 = random.Next(0, 9);
            int d4 = random.Next(0, 9);

            int[] numbers = new int[4];
            if (d1 != d2 && d1 != d3 && d1 != d4 && d2 != d3 && d2 != d4 && d3 != d4)
            {
                
                numbers[0] = d1;
                numbers[1] = d2;
                numbers[2] = d3;
                numbers[3] = d4;
                return numbers;
            }
            else
            {
                return genNumber();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pubNumbers = genNumber();
            string result = string.Join("", pubNumbers);
            label1.Text = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guessCount++;
            int[] guessNum = new int[4];
            try
            {
                guessNum[0] = Int32.Parse(textBox1.Text);
                guessNum[1] = Int32.Parse(textBox2.Text);
                guessNum[2] = Int32.Parse(textBox3.Text);
                guessNum[3] = Int32.Parse(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("Please only use numbers!");
            }

            int cow = 0;
            int bell = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int o = 0; o < 4; o++)
                {
                    if (pubNumbers[i] == guessNum[o])
                    {
                        if (i == o)
                        {
                            cow++;
                        }
                        else
                        {
                            bell++;
                        }
                    }
                    
                }
            }
            lblCowBell.Text = string.Format("{0} Cow, {1} Bells", cow, bell);
            lblGuess.Text = string.Format("Guess: {0}", guessCount);
            if (cow == 4)
            {
                MessageBox.Show("You Won!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                lblGuess.Text = "Guess: 0";
                guessCount = 0;
                lblCowBell.Text = "0 Cow, 0 Bells";
                cow = 0;
                bell = 0;

                pubNumbers = genNumber();
                string result = string.Join("", pubNumbers);
                label1.Text = result;
            }

        }
    }
}
