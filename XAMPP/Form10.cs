using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace XAMPP
{
    public partial class Form10 : Form
    {


        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");


        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

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
                string query = "SELECT Name, Option, Situation, Registerdate FROM loginform.registerinfo  WHERE Registerno = @Registerno";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Registerno", txtsearch.Text);

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
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

        private void Histry_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
