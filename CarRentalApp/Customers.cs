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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            load();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\61491\Dropbox\My PC (DESKTOP-C3OQ4T8)\Documents\CarRentalApp.mdf;Integrated Security=True;User Instance=False;Connect Timeout=30");
        private void load()
        {
            Con.Open();
            string query = "select * from CustomerTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            userDataGridView.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == " " || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into CustomerTbl values(" + IdTb.Text + ",'" + NameTb.Text + "','" + AddressTb.Text + "','" + PhoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Added");
                    Con.Close();
                    load();

                    IdTb.Clear();
                    NameTb.Clear();
                    AddressTb.Clear();
                    PhoneTb.Clear();


                }

                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }

        private void userDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = userDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            NameTb.Text = userDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            AddressTb.Text = userDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = userDataGridView.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from CustomerTbl where Custid=" + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Deleted");
                    Con.Close();
                    load();

                    IdTb.Clear();
                    NameTb.Clear();
                    AddressTb.Clear();
                    PhoneTb.Clear();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == " " || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string query = "update CustomerTbl set CustName ='" + NameTb.Text + "',CustAddr='" + AddressTb.Text + "',Phone ='" + PhoneTb.Text + "' where Custid=" + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Updated");
                    Con.Close();
                    load();

                    IdTb.Clear();
                    NameTb.Clear();
                    AddressTb.Clear();
                    PhoneTb.Clear();


                }

                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lgn = new Login();
            lgn.Show();
        }
    }
}
