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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }
        int startPoint = 0;
      
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            startPoint += 1;
            loadingProgress.Value = startPoint;
            percentage.Text = ""+ startPoint + "%";
            if (loadingProgress.Value == 100)
            {
                loadingProgress.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }

        }

        private void Start_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
