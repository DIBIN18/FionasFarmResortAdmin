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

namespace Admin_Login
{
    public partial class AddLeave : Form
    {
        Login login = new Login();
        public AddLeave()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private const int CS_DropShadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }

        private void AddLeave_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "SELECT EmployeeID, EmployeeFullName, LeaveCredits FROM EmployeeInfo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvAddLeave.DataSource = data;
            }
        }

        private void dgvAddLeave_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAddLeave.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAddLeave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();

                string query =
                    "INSERT INTO Leave (" +
                    "EmployeeID," +
                    "StartDate," +
                    "EndDate," +
                    "Reason)" +
                    "VALUES(" +
                    "@EmployeeID," +
                    "@StartDate," +
                    "@EndDate," +
                    "@Reason)";

                string startDate = dtpStartDate.Value.ToString("MMMM dd, yyyy");
                string endDate = dtpEndDate.Value.ToString("MMMM dd, yyyy");

                

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", dgvAddLeave.CurrentRow.Cells[0].Value);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                command.Parameters.AddWithValue("@Reason", rtxtReason.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("Successfully Applied Leave to the employee");
                rtxtReason.Text = " ";
            }

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                int totalLeaveDays = (int) (dtpEndDate.Value - dtpStartDate.Value).TotalDays;
                int employeeLeaveCredits = (int) dgvAddLeave.CurrentRow.Cells[2].Value;
                int remainingCredits = employeeLeaveCredits - totalLeaveDays;

                string query =
                    "UPDATE EmployeeInfo " +
                    "SET LeaveCredits = " + remainingCredits +
                    "WHERE EmployeeID = " + dgvAddLeave.CurrentRow.Cells[0].Value;
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }

        }
    }
}
