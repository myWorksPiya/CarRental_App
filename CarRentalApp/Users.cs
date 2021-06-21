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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            load();
        }
        
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\61491\Dropbox\My PC (DESKTOP-C3OQ4T8)\Documents\CarRentalApp.mdf;Integrated Security=True;User Instance=False;Connect Timeout=30");
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void load()
        {
            Con.Open();
            string query = "select * from UserTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            userDataGridView.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(Uid.Text == " " || Uname.Text == "" ||Upass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into UserTable values("+Uid.Text+",'"+Uname.Text+"','"+Upass.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Added");
                    Con.Close();
                    load();

                    Uid.Clear();
                    Uname.Clear();
                    Upass.Clear();

                }

                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Uid.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from UserTable where id=" + Uid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Deleted");
                    Con.Close();
                    load();

                    Uid.Clear();
                    Uname.Clear();
                    Upass.Clear();


                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);


                }
            }
        }

        private void userDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Uid.Text = userDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            Uname.Text = userDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            Upass.Text = userDataGridView.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Uid.Text == " " || Uname.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string query = "update userTable set Username='" + Uname.Text + "',password='" + Upass.Text + "' where Id=" + Uid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Updated");
                    Con.Close();
                    load();

                    Uid.Clear();
                    Uname.Clear();
                    Upass.Clear();

                }

                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lgn = new Login();
            lgn.Show();
        }
    }
}
