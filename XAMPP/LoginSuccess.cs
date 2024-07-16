using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace XAMPP
{
    public partial class LoginSuccessForm : Form
    {
        public LoginSuccessForm()
        {
            InitializeComponent();
        }

        private void LoginSuccessForm_Load(object sender, EventArgs e)
        {

            string name = LoginForm.name;
            lblsname.Text = name;

        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void lbllog_Click(object sender, EventArgs e)
        {
          
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm frm1 = new LoginForm();
            frm1.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
