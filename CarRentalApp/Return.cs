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
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\61491\Dropbox\My PC (DESKTOP-C3OQ4T8)\Documents\CarRentalApp.mdf;Integrated Security=True;User Instance=False;Connect Timeout=30");


        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            MainForm frm = new MainForm();
            frm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();

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

        private void loadReturnTable()
        {
            Con.Open();
            string query = "select * from ReturnTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ReturnDataGridView.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void DeleteOnReturn()
        {
            int rentId;
            rentId = Convert.ToInt32(RentDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            Con.Open();

            string query = "delete RentalTbl where RentId =" + IdTb.Text + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Rental Deleted Successfully");
            Con.Close();

            load();
            // UpdateonRentDelete();

           /* IdTb.Clear();
            CustNameTb.Clear();
            FeesTb.Clear();
            RentDate.ResetText();
            ReturnDate.ResetText(); */

        }
        private void UpdateonRentDelete()
        {
            /* Con.Open();
            string query = "update CarTbl set  Available='" + "YES" + "' where RegNum ='" + CarIdTb.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            Con.Close();*/
            // MessageBox.Show("Car details Successfully Updated");


        }
        private void Return_Load(object sender, EventArgs e)
        {
            load();
            loadReturnTable();
        }

        private void RentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = RentDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            CarIdTb.Text = RentDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            CustNameTb.Text = RentDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            ReturnDate.Text = RentDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            DateTime d1 = ReturnDate.Value.Date;
            DateTime d2 = DateTime.Now;
            TimeSpan t = d2 - d1;
            int delay = Convert.ToInt32(t.TotalDays);
            if(delay <= 0)
            {
                DelayTb.Text = "No Delay";
                FineTb.Text = "0";
            }
            else
            {
                delay = delay - 1;
                DelayTb.Text = "" + delay + " days";
                FineTb.Text = "$"+ (delay*250);


            }






        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == " " || CustNameTb.Text == "" || FineTb.Text == ""||DelayTb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {


                try
                {
                    Con.Open();
                    
                   
                     string query = "insert into ReturnTbl values(" + IdTb.Text + ",'" + CarIdTb.Text + "','" + CustNameTb.Text + "','" + ReturnDate.Text + "','" + DelayTb.Text + "','" + FineTb.Text + "')"; 
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Duly Returned");
                    Con.Close();
                    // UpdateonRent();
                    loadReturnTable();
                    DeleteOnReturn();



                        IdTb.Clear();
                    CustNameTb.Clear();
                    CustNameTb.Clear();
                    FineTb.Clear();
                    ReturnDate.ResetText();

                }

                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lgn = new Login();
            lgn.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (rtnIdDelTxtbox.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Returntbl where ReturnId=" + rtnIdDelTxtbox.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Return History Deleted");
                    Con.Close();
                    loadReturnTable();

                    rtnIdDelTxtbox.Clear();


                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);


                }
            }

        }

        private void ReturnDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rtnIdDelTxtbox.Text = ReturnDataGridView.SelectedRows[0].Cells[0].Value.ToString();
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



                    string query = "update Returntbl set custName='" + CustNameTb.Text + "',RentDate='" + RentDate.Text + "',ReturnDate='" + ReturnDate.Text + "',Fees='" + FeesTb.Text + "';";
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
    }
}
