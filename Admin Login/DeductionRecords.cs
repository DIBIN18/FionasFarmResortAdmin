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
    public partial class DeductionRecords : Form
    {
        Login login = new Login();
        String ValueHolder;
        public DeductionRecords()
        {
            InitializeComponent();
            dgvDeductions.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            dgvDeductions.DefaultCellStyle.Font = new Font("Century Gothic", 10);
        }

        private void DeductionRecords_Load(object sender, EventArgs e)
        {
            ValueHolder = lblValueHolder.Text;
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "select * from Deductions where EmployeeID = '" + ValueHolder + "';";
                SqlCommand cmd2 = new SqlCommand(query, connection);
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                cmd2.ExecuteNonQuery();
                DataTable dts2 = new DataTable();
                sqlDataAdapter2.Fill(dts2);
                dgvDeductions.DataSource = dts2;
            }
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "select * from OtherDeductions where EmployeeID = '" + ValueHolder + "';";
                SqlCommand cmd2 = new SqlCommand(query, connection);
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                DataTable dts2 = new DataTable();
                sqlDataAdapter2.Fill(dts2);

                // Add font styles to dgv
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                dataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dataGridView1.DataSource = dts2;

            }
        }
    }
}
