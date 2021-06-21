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
    public partial class Rental : Form
    {
        public Rental()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\61491\Dropbox\My PC (DESKTOP-C3OQ4T8)\Documents\CarRentalApp.mdf;Integrated Security=True;User Instance=False;Connect Timeout=30");
        private void fillcombo()
        {
            Con.Open();
            string query = "select RegNum from CarTbl where Available='"+"YES"+"'";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNum", typeof(string));
            dt.Load(rdr);
            CarRegCb.ValueMember = "RegNum";
            CarRegCb.DataSource = dt;
            Con.Close();
        }
        private void fillCustomerId()
        {
            Con.Open();
            string query = "select Custid from CustomerTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Custid", typeof(string));
            dt.Load(rdr);
            CustCb.ValueMember = "Custid";
            CustCb.DataSource = dt;
            Con.Close();
        }
        private void fetchCustName()
        {
            Con.Open();
            string query = "select * from CustomerTbl where Custid=" + CustCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                CustNameTb.Text = dr["CustName"].ToString();
            }
            Con.Close();
        }

        private void load()
        {
            Con.Open();
            string query = "select * from RentalTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentDataGridView.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void UpdateonRent()
        {
            Con.Open();
            string query = "update CarTbl set  Available='"+"NO"+"' where RegNum ='" + CarRegCb.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            Con.Close();
            
            // MessageBox.Show("Car details Successfully Updated");


        }
        private void UpdateonRentDelete()
        {
            Con.Open();
            string query = "update CarTbl set  Available='"+"YES" +"' where RegNum ='" + CarRegCb.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            Con.Close();
            // MessageBox.Show("Car details Successfully Updated");


        }


        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void Rental_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillCustomerId();
            load();
           

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void PhoneTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void CarRegCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
          
        }

        private void CustCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (IdTb.Text == " " || CustNameTb.Text == "" || FeesTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                

                try
                {
                    Con.Open();
                    
                  
                    string query = "insert into RentalTbl values(" + IdTb.Text + ",'" +CarRegCb.SelectedValue.ToString() + "','" + CustNameTb.Text + "','" + RentDate.Text + "','" +ReturnDate.Text + "','" + FeesTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Successfully Rented");
                    Con.Close();
                    UpdateonRent();
                    load();

                    IdTb.Clear();
                    CustNameTb.ResetText();
                    FeesTb.Clear();
                    RentDate.ResetText();
                    ReturnDate.ResetText();
                  
                }

                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }

        private void RentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = RentDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            CarRegCb.Text = RentDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            carNameSelected.Visible = true;
            carNameSelected.Text = RentDataGridView.SelectedRows[0].Cells[1].Value.ToString() + " ïs Selected";
            //CustCb.Text = RentDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            CustNameTb.Text = RentDataGridView.SelectedRows[0].Cells[2].Value.ToString();
             RentDate.Text = RentDataGridView.SelectedRows[0].Cells[3].Value.ToString();
             ReturnDate.Text = RentDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            FeesTb.Text = RentDataGridView.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == " " || CustCb.Text == "" || CustNameTb.Text == "" || RentDate.Text == "" || ReturnDate.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                  

                   
                    string query = "update RentalTbl set custName='" + CustNameTb.Text + "',RentDate='" + RentDate.Text + "',ReturnDate='" + ReturnDate.Text + "',Fees='" + FeesTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Updated");
                    Con.Close();
                    load();

                    IdTb.Clear();
                    CustNameTb.ResetText();
                    FeesTb.Clear();
                    RentDate.ResetText();
                    ReturnDate.ResetText();
                    carNameSelected.Visible = false;


                }

                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }

       /* private void button2_Click(object sender, EventArgs e)
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
                    string query = "delete RentalTbl where RentId =" + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rental Deleted Successfully");
                    Con.Close();
                   
                    load();
                    UpdateonRentDelete();

                    IdTb.Clear();
                    CustNameTb.Clear();
                    FeesTb.Clear();
                    RentDate.ResetText();
                    ReturnDate.ResetText();


                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);


                }
            }
        }
       */

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lgn = new Login();
            lgn.Show();
        }
    }
}
