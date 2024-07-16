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
    public partial class Form3 : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");


        public static string condition;
        public static string date;
        public static string number;
        public static string registernumber;

    
        public Form3()
        {
            InitializeComponent();
            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
            this.panel2.Paint += new PaintEventHandler(panel2_Paint);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginSuccessForm ls = new LoginSuccessForm();
            ls.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm frm1 = new LoginForm();
            frm1.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            int previousRegNo = 0;
            int nextregi;

            
                try
                {
                    connection.Open();

                    string query = "SELECT MAX(Registerno) FROM loginform.registerinfo";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            previousRegNo = Convert.ToInt32(result);
                            lblrv.Text = previousRegNo.ToString() + " person are Registerd";
                             nextregi = Convert.ToInt32(result) + 1;
                             registernumber = nextregi.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    connection.Close();
                }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            Rectangle rect = this.panel1.ClientRectangle;

            Color color1 = Color.White;
            Color color2 = Color.LightSkyBlue;


            using(LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, 90F))
            {
                g.FillRectangle(brush, rect);   
            }



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCondition.Text) || string.IsNullOrEmpty(txtno.Text))
            {
                MessageBox.Show("Please fill out all information!", "Error");

                return;
            }
            else
            {
                if(txtno.Text != registernumber)
                {
                    MessageBox.Show($"Your next register number must be {registernumber}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; 
                }
            }


            if (radioButton1.Checked== true)
            {
                MessageBox.Show("Patient Preference", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton2.Checked== true)
            {
                MessageBox.Show("No Patient Preference", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            condition = txtCondition.Text;
            date = dateTimePicker1.Value.ToString();
            number = txtno.Text;    
           

            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(txtCondition.Text) || string.IsNullOrEmpty(txtno.Text)) {

                MessageBox.Show("Please fill out all information!", "Error");

                return; 
            }
            else
            {
                if (txtno.Text != registernumber)
                {
                    MessageBox.Show($"Your next register number must be {registernumber}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (radioButton1.Checked == true)
            {
                MessageBox.Show("Patient Preference", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (radioButton2.Checked == true)
            {
                MessageBox.Show("No Patient Preference", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            condition = txtCondition.Text;
            date = dateTimePicker1.Value.ToString();
            number = txtno.Text;    

            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 f10 = new Form10();
            f10.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {


            Graphics g = e.Graphics; 

            Rectangle rect = this.panel2.ClientRectangle;

            Color color1 = Color.White;
            Color color2 = Color.LightSkyBlue;


            using(LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, 90F)) {


                g.FillRectangle(brush, rect);   


            }
        }
    }
}
