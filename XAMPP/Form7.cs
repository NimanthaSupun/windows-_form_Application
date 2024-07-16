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
    public partial class Form7 : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");



        public Form7()
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
            Form4 f4 = new Form4();
            f4.Show();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle rect = this.panel2.ClientRectangle;


            Color color1 = Color.White;
            Color color2 = Color.SkyBlue;

            using(LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, 90F))
            {
                g.FillRectangle(brush, rect);   
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtsearch.Text))
            {
                MessageBox.Show("Enter Number");
                return;
            }

            try
            {
                connection.Open();
                string query = "SELECT Name, Age, Complaint, Treadment FROM loginform.opdinfo WHERE No = @No";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@No", txtsearch.Text);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Enabled = false;  

                    // Add columns manually
                    foreach (DataColumn column in dt.Columns)
                    {
                        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = column.ColumnName,
                            HeaderText = column.ColumnName,
                            Name = column.ColumnName,
                            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                           
                        });
                    }

                    dataGridView1.DataSource = dt;


                }
                else
                {
                    MessageBox.Show("No data found for the entered number.", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();





        }
    }
}
