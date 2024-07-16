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

namespace XAMPP
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
            this.panel2.Paint += new PaintEventHandler(panel2_Paint);


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            Rectangle rect = this.panel1.ClientRectangle;


            Color color1 = Color.White;
            Color color2 = Color.LightSkyBlue;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, 90F))
            {
                g.FillRectangle(brush, rect);
            }

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
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            Rectangle rect = this.panel2.ClientRectangle;


            Color color1 = Color.White;
            Color color2 = Color.LightSkyBlue;

            using (LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, 90F))
            {
                g.FillRectangle(brush, rect);
            }


        }

        private void lblpatientName_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {

            lblpatientName.Text = Form5.wardpatientname;
            lblpatientAge.Text = Form5.wardpatientage;  

        }
    }
}
