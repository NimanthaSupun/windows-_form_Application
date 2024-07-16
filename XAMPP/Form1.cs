using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using MySql.Data.MySqlClient; 

namespace XAMPP
{
    public partial class LoginForm : Form
    {

        public static string name;

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;

        public LoginForm()
        {
            InitializeComponent();
            this.panel1.Paint += new PaintEventHandler(panel1_Paint);

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAccountForm frm3 = new CreateAccountForm();
            frm3.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please input Username and Password", "Error");
            }

            else
            {
                connection.Open();
                string selectQuery = "SELECT * FROM loginform.userinfo WHERE Username = '" + txtUsername.Text + "' AND Password = '" + txtPassword.Text + "';";
                command = new MySqlCommand(selectQuery, connection);
                mdr = command.ExecuteReader();

                if (mdr.Read())
                {

                     name = mdr.GetString("FirstName");

                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=";
                    string Query = "update loginform.userinfo set LastLogin='" + dateTimePicker1.Value + "' where Username='" + this.txtUsername.Text + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();

                  // MessageBox.Show("Login Successful!");
                    this.Hide();
                    LoginSuccessForm frm2 = new LoginSuccessForm();
                    frm2.ShowDialog();

                }
                else
                {

                    MessageBox.Show("Incorrect Login Information! Try again.");
                }

                connection.Close();
            }
        }
        private void lblCut_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {


            Graphics g = e.Graphics;

            Rectangle rect = this.panel1.ClientRectangle;


           // Color color1 = Color.FromArgb(0, 255, 255); // equivalent to #00ffff (Cyan)
            //Color color2 = Color.FromArgb(255, 255, 0); // equivalent to #ffff00 (Yellow)


            Color color1 = Color.White;
            Color color2 = Color.White;


            using (LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, 90F))
            {
                g.FillRectangle(brush, rect);
            }



        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form9 f6 = new Form9();
            f6.Show();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
