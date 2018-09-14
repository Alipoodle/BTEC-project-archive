using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tree_Road_School
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSignin_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Username == textUsername.Text.ToLower()) {
                if (Properties.Settings.Default.Password == textPassword.Text) {
                    MessageBox.Show("Password and Username correct, Signing in.");
                    // Show new form
                    Database frmShow = new Database();
                    frmShow.Show();
                    this.Hide();
                } else {
                    MessageBox.Show("Username or Password was incorrect");
                }
            } else {
                MessageBox.Show("Username or Password was incorrect");
            }

        }
    }
}
