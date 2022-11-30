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
    public partial class PayRollHistory : Form
    {
        Login login = new Login();
        public PayRollHistory()
        {
            InitializeComponent();
        }

        private void PayRollHistory_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "select * from PayrollReportHistory";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvPayrollRecords.DataSource = data;
            }
        }

        private void dtp_From_ValueChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "select * from PayrollReportHistory where DateFrom  = '" + dtp_From.Text + "' and DateTo = '" + dtp_To.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvPayrollRecords.DataSource = data;
            }
        }

        private void dtp_To_ValueChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "select * from PayrollReportHistory where DateFrom  = '" + dtp_From.Text + "' and DateTo = '" + dtp_To.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvPayrollRecords.DataSource = data;
            }
        }
    }
}
