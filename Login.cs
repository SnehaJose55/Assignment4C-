using Assignment4.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{

    public partial class Login : Form
    {
        private string email;
        private string password;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            email = textBox1.Text;
            password = textBox2.Text;

            using (var dbContext = new MMABooksContext())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

                // Check if a user with the provided email and password exists
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        // Authentication successful
                        MessageBox.Show("Login successful.");
                        Form2 form2 = new Form2(); 
                        Form1 form1 = new Form1(form2); 
                        form1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid email or password.");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
