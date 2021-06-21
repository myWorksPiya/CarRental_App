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
    public partial class CarDetails : Form
    {
        public CarDetails()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\61491\Dropbox\My PC (DESKTOP-C3OQ4T8)\Documents\CarRentalApp.mdf;Integrated Security=True;User Instance=False;Connect Timeout=30"); 
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void load()
        {
            Con.Open();
            string query = "select * from CarTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarsDataGridView.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void CarDetails_Load(object sender, EventArgs e)
        {
            load();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RegNumTb.Text == " " || ModelTb.Text == "" || MakeTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into CarTbl values('"+RegNumTb.Text+"','" + MakeTb.Text + "','" + ModelTb.Text + "','" + PriceTb.Text + "','" + AvailableCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Successfully Added");
                    Con.Close();
                    load();

                    RegNumTb.Clear();
                    MakeTb.Clear();
                    ModelTb.Clear();
                    PriceTb.Clear();
                }


                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            if (RegNumTb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from CarTbl where RegNum = '" + RegNumTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Successfully Deleted");
                    Con.Close();
                    load();

                    RegNumTb.Clear();
                    MakeTb.Clear();
                    ModelTb.Clear();
                    PriceTb.Clear();
                   
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);


                }
            }
        }

        private void CarsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RegNumTb.Text = CarsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            MakeTb.Text = CarsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            ModelTb.Text = CarsDataGridView.SelectedRows[0].Cells[2].Value.ToString();   
            PriceTb.Text = CarsDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            AvailableCb.SelectedItem = CarsDataGridView.SelectedRows[0].Cells[4].Value.ToString();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(RegNumTb.Text == " " || ModelTb.Text == "" || MakeTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();

                    string query = "update CarTbl set Make='" + MakeTb.Text + "',  Model='" + ModelTb.Text + "', Available='" + AvailableCb.SelectedItem.ToString() + "',Price='" + PriceTb.Text + "'  where RegNum ='" +RegNumTb.Text+ "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car details Successfully Updated");
                    Con.Close();
                    load();

                    RegNumTb.Clear();
                    MakeTb.Clear();
                    ModelTb.Clear();
                    PriceTb.Clear();
                    

                }

                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            load();
        }

        private void Search_SelectionChangeCommitted(object sender, EventArgs e)
        {

            String flag = "";
            if (Search.SelectedItem.ToString() == "Available")
            {
                flag = "YES";
            }
            else
            {
                flag = "NO";
            }
            Con.Open();
            string query = "select * from CarTbl where Available = '"+flag+"'";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarsDataGridView.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lgn = new Login();
            //lgn.Show();
        }
    }
}
