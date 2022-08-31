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
    public partial class BookDetail : Form
    {
        public BookDetail()
        {
            InitializeComponent();
           
        }

        private void lbauthor_Click(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            BookDetail b = new BookDetail();
            b.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void manageBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageBook m = new ManageBook();
            m.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||textBox4.Text == ""){
                MessageBox.Show("Please Fill All The Filed It's Required");
            }
           
        }
    }
}
