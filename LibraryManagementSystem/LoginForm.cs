using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string pass = textBox2.Text;


            string conS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zains\source\repos\LibraryManagementSystem\LibraryManagementSystem\Database1.mdf;Integrated Security=True";

            SqlConnection con = new SqlConnection(conS);

            string query = "SELECT email, pass FROM signin WHERE email = '" + email + "' AND pass = '" + pass + "'";
            
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            int i = cmd.ExecuteNonQuery();

            DataTable td = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(td);

            if (td.Rows.Count > 0)
            {
                Liblogin s = new Liblogin();
                s.Show();
                this.Hide();
            }
            else
            {
                label4.Text = "You Enter Wronge Email or Password";
                label4.ForeColor = Color.Red;
            }

            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUpForm s = new SignUpForm();
            s.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Library l = new Library();
            l.Show();
            this.Hide();
        }
    }
}
