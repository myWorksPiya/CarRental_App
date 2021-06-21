using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rental rentl = new Rental();
            rentl.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CarDetails car = new CarDetails();
            car.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers cust = new Customers();
            cust.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lgn = new Login();
            lgn.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users user = new Users();
            user.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return rtn = new Return();
            rtn.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashBoard dash = new DashBoard();
            dash.Show();
        }
    }
}
