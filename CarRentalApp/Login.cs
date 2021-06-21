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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\61491\Dropbox\My PC (DESKTOP-C3OQ4T8)\Documents\CarRentalApp.mdf;Integrated Security=True;User Instance=False;Connect Timeout=30");

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select Count(*) from UserTable where Username ='"+Uname.Text+"' and password='"+passwrd.Text+"' " ;


            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString() == "1")
            {
                MainForm main = new MainForm();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            Con.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Uname.Text = "";
            passwrd.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
