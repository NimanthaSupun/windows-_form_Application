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
    public partial class Form5 : Form
    {
        public static string Condition = Form3.condition;
        public static string Registerdate = Form3.date;
        public static string reginumber = Form3.number;



        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");



        public static string wardpatientname;
        public static string wardpatientage;


        public Form5()
        {
            InitializeComponent();
            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
            this.panel2.Paint += new PaintEventHandler(panel2_Paint_1);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            LoginForm frm1 = new LoginForm();
            frm1.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


            Graphics g = e.Graphics;

            Rectangle rect = this.ClientRectangle;

            Color color1 = Color.White;
            Color color2 = Color.LightSkyBlue;


            using(LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, 90F))
            {
                g.FillRectangle(brush, rect);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            Rectangle rect = this.panel2.ClientRectangle;

             Color color1 = Color.White;
             Color color2 = Color.LightSkyBlue;

           // Color color1 = Color.FromArgb(255, 255, 0); // equivalent to #ffff00 (Yellow)
            //Color color2 = Color.FromArgb(255, 0, 255); // equivalent to #ff00ff (Magenta)

            using (LinearGradientBrush brush = new LinearGradientBrush(rect,color1,color2, 90F))
            {
                g.FillRectangle(brush, rect);   
            }



        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            string title = "";
            string gender = "";
            string status = "";



            if(rdoRev.Checked == true)
            {
                title = rdoRev.Text;
            }
            if(rdoMis.Checked == true)
            {
                title = rdoMis.Text;
            }
            if(rdoMr.Checked == true)
            {
                title = rdoMr.Text;
            }
            if(rdoMs.Checked == true)
            {
                title = rdoMs.Text;
            }

            if(rdoMale.Checked == true)
            {
                gender = rdoMale.Text;  
            }
            if(rdoFemale.Checked == true)
            {
                gender = rdoFemale.Text;
            }
            if(rdoOther.Checked == true)
            {
                gender = rdoOther.Text; 
            }
            

            if(rdoMarri.Checked == true)
            {
                status = rdoMarri.Text;
            }
            if(rdoUnmarri.Checked == true)
            {
                status = rdoUnmarri.Text;
            }
            if(rdoMrriother.Checked == true)
            {
                status = rdoMrriother.Text;
            }


            wardpatientname = txtName.Text; 
            wardpatientage  = txtAge.Text;

            

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtNIC.Text) 
                 || string.IsNullOrEmpty(txtAge.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(txtMobileno.Text))
            {
                MessageBox.Show("Please fill out all information!", "Error");
                return;
            }

            try
            {
                connection.Open();
                string option = "Ward Patient";

                string query = "INSERT INTO loginform.registerinfo(Registerno, Name, Option, Situation, Registerdate)" + "VALUES(@Registerno, @Name, @Option, @Situation, @Registerdate)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Registerno", reginumber);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Option", option);
                    cmd.Parameters.AddWithValue("@Situation", Condition);
                    cmd.Parameters.AddWithValue("@Registerdate", Registerdate);

                    cmd.ExecuteNonQuery();

                }

                MessageBox.Show("Data inserted successfully!", "Success");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                connection.Close();
            }

            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();

        }

        private void Form5_Load(object sender, EventArgs e)
        {
        }
    }
}
