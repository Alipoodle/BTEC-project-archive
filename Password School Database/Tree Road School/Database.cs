using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.IO;

namespace Tree_Road_School
{
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
            
        }
        public int StudentID;
        public string StudentSurname;
        public string StudentForname;
        public string StudentDoB;
        public string StudentHome;
        public string StudentHomePhone;
        public string StudentGender;

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Form1 frmShow = new Form1();
            frmShow.Show();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int StudentID = Int32.Parse(Interaction.InputBox("Please provide the Student's Unique ID Number.", "Student ID Number", "ID Number"));
            using (StreamReader r = new StreamReader("Student.json"))
            {
                string json = r.ReadToEnd();
                string response = "";
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    if (item.id == StudentID)
                    {
                        response = $"Student ID: {item.id}\nStudent name: {item.surname}, {item.forname}\nStudent Gender: {item.gender}\nStudent DoB: {item.dob}\nHome Address: {item.homeAddress}\nHome Phone Num: {item.phone}";
                    }
                    
                }
                if (response == "")
                {
                    response = "Seems like there's not a student with that Unique ID. Try again!";
                }
                MessageBox.Show(response);
            }

            
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            

            bool check = false;
            do {
                StudentID = Int32.Parse(Interaction.InputBox("Please provide the Student's Unique ID Number.", "Student ID Number", "ID Number"));
                StudentSurname = Interaction.InputBox("Please provide the Student's Surname.", "Student Surname", "Surname");
                StudentForname = Interaction.InputBox("Please provide the Student's Forname.", "Student Forname", "Forname");
                StudentDoB = Interaction.InputBox("Please provide the Student's Date of Birth.", "Student Date of Birth", "Date of Birth");
                StudentHome = Interaction.InputBox("Please provide the Student's Home Address.", "Student Home Address", "Home Address");
                StudentHomePhone = Interaction.InputBox("Please provide the Student's Home Phone Number.", "Student Home Phone Number", "Home Phone Number");
                StudentGender = Interaction.InputBox("Please provide the Student's Gender.", "Student Gender", "Gender");

                check = true;
            } while (check == false);

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;
                
                    writer.WriteStartObject();
                    writer.WritePropertyName("id");
                    writer.WriteValue(StudentID);
                    writer.WritePropertyName("surname");
                    writer.WriteValue(StudentSurname);
                    /*writer.WritePropertyName("Drives");
                    writer.WriteStartArray();
                    writer.WriteValue("DVD read/writer");
                    writer.WriteComment("(broken)");
                    writer.WriteValue("500 gigabyte hard drive");
                    writer.WriteValue("200 gigabype hard drive");
                    writer.WriteEnd();*/
                    writer.WriteEndObject();
                }
            
        }
    }
}
