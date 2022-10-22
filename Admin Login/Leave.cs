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
    public partial class Leave : Form
    {
        Login login = new Login();
        LeaveEmployeeList leaveEmployeeList = new LeaveEmployeeList();
        public Leave()
        {
            InitializeComponent();
        }
        string selectedGender = "";
        string selectedMaritalStatus = "";
        //private void Tb_Search_Enter(object sender, EventArgs e)
        //{
        //    if (tb_Search.Text == " Search")
        //    {
        //        tb_Search.Text = "";
        //        tb_Search.ForeColor = Color.Black;
        //    }
        //}
        //private void Tb_Search_Leave(object sender, EventArgs e)
        //{
        //    if (tb_Search.Text == "")
        //    {
        //        tb_Search.Text = " Search";
        //        tb_Search.ForeColor = Color.Silver;
        //    }
        //}


        private void cmbLeaveType_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT Gender FROM EmployeeInfo WHERE EmployeeId='" + leaveEmployeeList.dgvLeave.CurrentRow.Cells[0].Value + "'";

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
               "SELECT EmployeeMaritalStatus FROM EmployeeInfo WHERE EmployeeId='" + leaveEmployeeList.dgvLeave.CurrentRow.Cells[0].Value + "'";

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
                cmbLeaveType.Items.AddRange(new String[] { "Sick Leave", "Vacation Leave" });
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
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
                command.Parameters.AddWithValue("@EmployeeID", leaveEmployeeList.dgvLeave.CurrentRow.Cells[0].Value);
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
                int totalLeaveDays = (int)(dtpEndDate.Value - dtpStartDate.Value).TotalDays;
                int employeeLeaveCredits = (int)leaveEmployeeList.dgvLeave.CurrentRow.Cells[2].Value;
                int remainingCredits = employeeLeaveCredits - totalLeaveDays;

                string query =
                    "UPDATE EmployeeInfo " +
                    "SET LeaveCredits = " + remainingCredits +
                    "WHERE EmployeeID = " + leaveEmployeeList.dgvLeave.CurrentRow.Cells[0].Value;
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
        private void Search_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Leave Employee List";
            menu.Menu_Load(menu, EventArgs.Empty);
        }
    }
}