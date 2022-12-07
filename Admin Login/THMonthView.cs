using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Login
{
    public partial class THMonthView : Form
    {
        public THMonthView()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
         
        }

        private void THMonthView_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            using (SqlConnection con = new SqlConnection(login.connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from THMonthsSalary", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvTHMonthPayView.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
