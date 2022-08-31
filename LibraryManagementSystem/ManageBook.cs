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
    public partial class ManageBook : Form
    {
        string conS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zains\source\repos\LibraryManagementSystem\LibraryManagementSystem\Database1.mdf;Integrated Security=True";
        SqlConnection con;

        public ManageBook()
        {
            InitializeComponent();
            con = new SqlConnection(conS);
        }

        private void ManageBook_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        string st;
        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            DialogResult dr = op.ShowDialog();
            if(dr == DialogResult.OK)
            {
                st  = op.FileName;
                pictureBox1.Image = new Bitmap(st);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            pictureBox1 = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string id = textBox7.Text;

            string query = "SELECT * From manageBook where Id = '" + id + "' ";

            DataTable db = new DataTable();
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            

            db.Load(cmd.ExecuteReader());


            con.Close();
            textBox1.Text = db.Rows[0].ItemArray[1].ToString();
            textBox2.Text = db.Rows[0].ItemArray[2].ToString();
            textBox3.Text = db.Rows[0].ItemArray[3].ToString();
            textBox4.Text = db.Rows[0].ItemArray[7].ToString();
            textBox5.Text = db.Rows[0].ItemArray[4].ToString();
            textBox6.Text = db.Rows[0].ItemArray[5].ToString();


        }

        private void button4_Click(object sender, EventArgs e)
        {

            string id = textBox7.Text;
            string title = textBox1.Text;
            string price = textBox2.Text;
            string genre = textBox3.Text;
            string edition = textBox4.Text;
            string author = textBox5.Text;
            string desc = textBox6.Text;

            string query = "INSERT INTO manageBook([Id], [title], [price], [genre], [author], [detail], [imagess], [edition]) VALUES ('" + id + "' , '" + title + "' , '" + price + "' , '" + genre + "' , '" + author + "' ,'" + desc + "' ,'" + st + "' , '" + edition + "' )";

            SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
            int i= cmd.ExecuteNonQuery();

            if (i > 0)
            {
                MessageBox.Show("Record Added Successfully");
            }
                con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id = textBox7.Text;
            string title = textBox1.Text;
            string price = textBox2.Text;
            string genre = textBox3.Text;
            string edition = textBox4.Text;
            string author = textBox5.Text;
            string desc = textBox6.Text;
      

            string query = "UPDATE manageBook  SET title = '" + title + "', price = '" + price + "', genre = '" + genre + "', author = '" + author + "', detail = '" + desc + "', imagess = '" + st + "', edition = '" + edition + "' WHERE Id = '" + id +"' ";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Update Successfully Registered");

            }
            con.Close();
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string id = textBox7.Text;

            string querry = "DELETE FROM manageBook WHERE Id = '" + id + "'";
            SqlCommand cmd = new SqlCommand(querry, con);
            
            con.Open();

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                MessageBox.Show("Record Successfully Deleted");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                pictureBox1.Image = null;
            }

            con.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            LoginForm l = new LoginForm();
            l.Show();
            this.Hide();
        }

        private void viewBookToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Liblogin l = new Liblogin();
            l.Show();
            this.Hide();
        }
    }
}
