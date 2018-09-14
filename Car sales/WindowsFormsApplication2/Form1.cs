using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        string[] lines;
        string fileName = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\carsales.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!File.Exists(fileName))
            {
                fileLoad();
                return;
            } else
            {
                fileLoad();
            }
            if (lines.Length != 0)
            {
                var mode = lines.GroupBy(v => v).OrderByDescending(g => g.Count()).First();

                lblSoldCars.Text = mode.Key;
                lblNumberSold.Text = mode.Count().ToString();
                lblTotalSales.Text = lines.Length.ToString();
            } else
            {
                MessageBox.Show("Error it seems like there's no content in the file");
            }
        }

        public void fileLoad()
        {
            if (File.Exists(fileName))
            {
                lines = File.ReadAllLines(fileName);
            }
            else {
                MessageBox.Show("Failed to find file! Creating file at location: " + fileName);
                File.Create(fileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(cbCarNames.Text);
            }
            MessageBox.Show($"Successfully added {cbCarNames.Text} to list");
        }
    }
}
