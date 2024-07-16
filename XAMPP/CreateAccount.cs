using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace XAMPP
{
    public partial class CreateAccountForm : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");



        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {

            cboGender.Items.Add("Female");
            cboGender.Items.Add("Male");


        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains('.'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCPassword.Text != txtCPassword.Text)
            {
                MessageBox.Show("Password doesn't match!", "Error");
                return;
            }

            if (string.IsNullOrEmpty(txtFName.Text) || string.IsNullOrEmpty(txtLName.Text) || string.IsNullOrEmpty(cboGender.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtCPassword.Text) || string.IsNullOrEmpty(txtCPassword.Text))
            {
                MessageBox.Show("Please fill out all information!", "Error");
                return;
            }

            else
            {
                connection.Open();

                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM loginform.userinfo WHERE Username = @UserName", connection),
                cmd2 = new MySqlCommand("SELECT * FROM loginform.userinfo WHERE Email = @UserEmail", connection);


                cmd1.Parameters.AddWithValue("@UserName", txtUsername.Text);
                cmd2.Parameters.AddWithValue("@UserEmail", txtEmail.Text);

                bool userExists = false, mailExists = false;

                using (var dr1 = cmd1.ExecuteReader())
                    if (userExists = dr1.HasRows) MessageBox.Show("Username not available!");

                using (var dr2 = cmd2.ExecuteReader())
                    if (mailExists = dr2.HasRows) MessageBox.Show("Email not available!");


                if (!(userExists || mailExists))
                {

                    string iquery = "INSERT INTO loginform.userinfo(`ID`,`FirstName`,`LastName`,`Gender`,`Birthday`,`Email`,`Username`, `Password`) VALUES (NULL, '" + txtFName.Text + "', '" + txtLName.Text + "', '" + cboGender.Text + "', '" + dateTimePicker1.Value.Date + "', '" + txtEmail.Text + "', '" + txtUsername.Text + "', '" + txtCPassword.Text + "')";
                    MySqlCommand commandDatabase = new MySqlCommand(iquery, connection);
                    commandDatabase.CommandTimeout = 60;


                    try
                    {
                        MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        // Show any error message.
                        MessageBox.Show(ex.Message);
                    }

                    MessageBox.Show("Account Successfully Created!");

                }

                connection.Close();
            }


        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            this.Hide();
            LoginForm frm4 = new LoginForm();
            frm4.ShowDialog();

        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
