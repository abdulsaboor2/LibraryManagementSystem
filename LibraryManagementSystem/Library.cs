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
    public partial class Library : Form
    {
        int i=0,chk=0;

        public Library()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string conS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zains\source\repos\LibraryManagementSystem\LibraryManagementSystem\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(conS);
            string query = "SELECT * FROM manageBook";
            DataTable db = new DataTable();
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            cmd.ExecuteNonQuery();

            db.Load(cmd.ExecuteReader());
            chk = db.Rows.Count;

            if (chk > i)
            {
                label18.Visible = false;
                groupBox1.Visible = true;

                lbid.Text = "Book ID: " + db.Rows[i].ItemArray[0].ToString();
                lbtitle.Text = "Title: " + db.Rows[i].ItemArray[1].ToString();
                lbprice.Text = "Price: " + db.Rows[i].ItemArray[2].ToString();
                lbgenre.Text = "Genre: " + db.Rows[i].ItemArray[3].ToString();
                lbauthor.Text = "Author: " + db.Rows[i].ItemArray[4].ToString();
                lbd.Text = "Description " + db.Rows[i].ItemArray[5].ToString();
                lbed.Text = "Edition: " + db.Rows[i].ItemArray[0].ToString();

                if (db.Rows[i].ItemArray[6].ToString() != null)
                {
                   pictureBox1.Image = new Bitmap(db.Rows[i].ItemArray[6].ToString());
                }
                else
                {
                    pictureBox1.Image = new Bitmap(@"C: \Users\zains\source\repos\LibraryManagementSystem\LibraryManagementSystem\images\download.jpg");
                }
            }
            else
            {
                groupBox1.Visible = false;
                label18.Text = "There Is No Data";
                label18.Visible = true;
            }
            if (chk > i + 1)
            {
                groupBox2.Visible = true;

                label8.Text = "Book ID: " + db.Rows[i].ItemArray[0].ToString();
                label7.Text = "Title: " + db.Rows[i].ItemArray[1].ToString();
                label3.Text = "Price: " + db.Rows[i].ItemArray[2].ToString();
                label6.Text = "Genre: " + db.Rows[i].ItemArray[3].ToString();
                label2.Text = "Author: " + db.Rows[i].ItemArray[4].ToString();
                label1.Text = "Description " + db.Rows[i].ItemArray[5].ToString();
                label5.Text = "Edition: " + db.Rows[i].ItemArray[0].ToString();

                if (db.Rows[i + 1].ItemArray[6].ToString() != null)
                {
                    pictureBox2.Image = new Bitmap(db.Rows[i + 1].ItemArray[6].ToString());
                }
                else
                {
                    
                    pictureBox2.Image = new Bitmap(@"C: \Users\zains\source\repos\LibraryManagementSystem\LibraryManagementSystem\images\download.jpg");
                }
            }
            else
            {
                groupBox2.Visible = false;
            }
            

            con.Close();
            }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i != 0) {
                if (i == 1)
                {
                    i = i - 1;
                }
                else
                {
                    i = i - 2;
                }
                
            }
            LoadData();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm s = new LoginForm();
            s.Show();
            this.Hide();
        }

        private void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SignUpForm s = new SignUpForm();
            s.Show();
            this.Hide();
        }

        private void viewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Library s = new Library();
            s.Show();
            this.Hide();
        }

        private void Library_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void libraryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(i<=chk)
            i = i + 2;
            LoadData();
        }
    }
}
