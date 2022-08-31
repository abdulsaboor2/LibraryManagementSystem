using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace LibraryManagementSystem
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please Fill All Field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
            else if (textBox4.Text != textBox5.Text )
            {
                MessageBox.Show("Your Password Are Not Match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                string fname = textBox1.Text;
                string lname = textBox2.Text;
                string email = textBox3.Text;
                string pass = textBox4.Text;
               
                string conS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zains\source\repos\LibraryManagementSystem\LibraryManagementSystem\Database1.mdf;Integrated Security=True";

                SqlConnection con = new SqlConnection(conS);
                
                string query = "INSERT INTO signin(fname,lname,email,pass) VALUES ('"+fname+"','"+lname+"','"+ email+"','"+pass+"')";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("You Are Successfully Register");
                    LoginForm s = new LoginForm();
                    s.Show();
                    this.Hide();

                }
                con.Close(); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm l = new LoginForm();
            l.Show();
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
