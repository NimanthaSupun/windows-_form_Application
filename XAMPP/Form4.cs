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
    public partial class Form4 : Form
    {

        public static string Condition = Form3.condition;
        public static string Registerdate = Form3.date;
        public static  string reginumber = Form3.number;

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");


        public static string opdpatientname;
        public static string opdpatientage;


        public Form4()
        {
            InitializeComponent();
            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
            this.panel2.Paint += new PaintEventHandler(panel2_Paint);
        
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm frm1 = new LoginForm();
            frm1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics; 

            Rectangle rect = this.panel1.ClientRectangle;
            Color color1 = Color.White;
            Color color2 = Color.SkyBlue;



            using(LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, 90F))
            {

                g.FillRectangle(brush, rect);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
             Graphics graphics = e.Graphics;

            Rectangle rect = this.panel2.ClientRectangle;
            Color color1 = Color.White;
            Color color2 = Color.LightSkyBlue;


            using (LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, 90F))
            {

                graphics.FillRectangle(brush, rect);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            string ginput = "";
            string sinput = "";

            if(rdoOMale.Checked == true)
            {
                ginput = rdoOMale.Text;
            }
            if(rdoOFemale.Checked == true)
            {
                ginput = rdoOFemale.Text;
            }
            if(rdoOother.Checked == true)
            {
                ginput = rdoOother.Text;
            }


            if(rdoOMrid.Checked == true)
            {
                sinput = rdoOMrid.Text;
            }
            if(rdoOum.Checked == true)
            {
                sinput = rdoOum.Text;
            }
            if(rdoOMo.Checked == true)
            {
                sinput = rdoOMo.Text;    
            }

            opdpatientname = txtOName.Text;
            opdpatientage = txtOAge.Text;
           
            if(string.IsNullOrEmpty(txtOName.Text) || string.IsNullOrEmpty(txtONo.Text) || string.IsNullOrEmpty(txtOAge.Text) || string.IsNullOrEmpty(txtOAddress.Text) ||
                string.IsNullOrEmpty(ginput) || string.IsNullOrEmpty(sinput) || string.IsNullOrEmpty(txtOC.Text) || string.IsNullOrEmpty(txtOT.Text))
            {
                MessageBox.Show("Please fill out all information!", "Error");
                return;

            }
            else
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO loginform.opdinfo(Registerno, Name, No, Age, Address, Gender, Status, Complaint, Treadment) " +
                                   "VALUES (@Registerno, @Name, @No, @Age, @Address, @Gender, @Status, @Complaint, @Treadment)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {

                        cmd.Parameters.AddWithValue("@Registerno", reginumber);
                        cmd.Parameters.AddWithValue("@Name", txtOName.Text);
                        cmd.Parameters.AddWithValue("@No", txtONo.Text);
                        cmd.Parameters.AddWithValue("@Age", txtOAge.Text);
                        cmd.Parameters.AddWithValue("@Address", txtOAddress.Text);
                        cmd.Parameters.AddWithValue("@Gender", ginput);
                        cmd.Parameters.AddWithValue("@Status", sinput);
                        cmd.Parameters.AddWithValue("@Complaint", txtOC.Text);
                        cmd.Parameters.AddWithValue("@Treadment", txtOT.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data inserted successfully!", "Success");

                }
                catch(Exception ex)
                {

                    MessageBox.Show("Error: " + ex.Message, "Error");
                }
                finally
                {
                    connection.Close();
                }

                try
                {
                    connection.Open();
                    string option = "OPD Patient";

                    string query = "INSERT INTO loginform.registerinfo(Registerno, Name, Option, Situation, Registerdate)" + "VALUES(@Registerno, @Name, @Option, @Situation, @Registerdate)";

                    using(MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Registerno",reginumber);
                        cmd.Parameters.AddWithValue("@Name",txtOName.Text);
                        cmd.Parameters.AddWithValue("@Option",option);
                        cmd.Parameters.AddWithValue("@Situation", Condition);
                        cmd.Parameters.AddWithValue("@Registerdate", Registerdate);    

                        cmd.ExecuteNonQuery ();

                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");   
                }
                finally
                {
                    connection.Close();
                }
              

            }
            this.Hide();    
            Form7 f7 = new Form7();
            f7.Show();
            
        }
    }
}
