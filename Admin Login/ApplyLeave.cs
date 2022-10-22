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
    public partial class ApplyLeave : Form
    {
        Login login = new Login();

        string selectedGender = "";
        string selectedMaritalStatus = "";

        public ApplyLeave()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Leave";
            menu.Menu_Load(menu, EventArgs.Empty);
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
                string query = "SELECT EmployeeID, EmployeeFullName, LeaveCredits FROM EmployeeInfo WHERE EmploymentType='Regular'";

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

        private void cmbLeaveType_Click(object sender, EventArgs e)
        {
            string query = 
                "SELECT Gender FROM EmployeeInfo WHERE EmployeeId='" + dgvAddLeave.CurrentRow.Cells[0].Value + "'";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        selectedGender = reader.GetString(0);
                        reader.Close();
                    }
                }
            }

            string query2 =
                "SELECT EmployeeMaritalStatus FROM EmployeeInfo WHERE EmployeeId='" + dgvAddLeave.CurrentRow.Cells[0].Value + "'";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        selectedMaritalStatus = reader.GetString(0);
                        reader.Close();
                    }
                }
            }

            Console.WriteLine(selectedGender);
            Console.WriteLine(selectedMaritalStatus);

            if (selectedGender == "Male" && selectedMaritalStatus == "Married")
            {
                cmbLeaveType.Items.Clear();
                cmbLeaveType.Items.AddRange(new String[] { "Sick Leave", "Vacation Leave", "Paternity Leave" });
            }
            else if (selectedGender == "Female" && selectedMaritalStatus == "Married")
            {
                cmbLeaveType.Items.Clear();
                cmbLeaveType.Items.AddRange(new String[] { "Sick Leave", "Vacation Leave", "Maternity Leave" });
            }
            else
            {
                cmbLeaveType.Items.Clear();
                cmbLeaveType.Items.AddRange(new String[] { "Sick Leave", "Vacation Leave"});
            }
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
                    "Reason," +
                    "Type)" +
                    "VALUES(" +
                    "@EmployeeID," +
                    "@StartDate," +
                    "@EndDate," +
                    "@Reason," +
                    "@Type)";

                string startDate = dtpStartDate.Value.ToString("MM/dd/yyyy hh:mm:ss");
                string endDate = dtpEndDate.Value.ToString("MM/dd/yyyy hh:mm:ss");

                

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", dgvAddLeave.CurrentRow.Cells[0].Value);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                command.Parameters.AddWithValue("@Reason", rtxtReason.Text);
                command.Parameters.AddWithValue("@Type", cmbLeaveType.Text);

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

        private void cmbLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
