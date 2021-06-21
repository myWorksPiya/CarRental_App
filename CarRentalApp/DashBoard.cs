using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CarRentalApp
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\61491\Dropbox\My PC (DESKTOP-C3OQ4T8)\Documents\CarRentalApp.mdf;Integrated Security=True;User Instance=False;Connect Timeout=30");
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            carCount();
            customerCount();
            userCount();
        }

        private void carCount()
        {
            string querycar = "select Count(*) from CarTbl";
            SqlDataAdapter sda = new SqlDataAdapter(querycar, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            carlbl.Text = dt.Rows[0][0].ToString();
        }
        private void customerCount()
        {
            string querycustomer = "select Count(*) from CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(querycustomer, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            customerlbl.Text = dt.Rows[0][0].ToString();
        }
        private void userCount()
        {
            string queryuser = "select Count(*) from UserTable";
            SqlDataAdapter sda = new SqlDataAdapter(queryuser, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            userlbl.Text = dt.Rows[0][0].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}
