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
        int totalLeaveDays;
        string employeeLeaveCredits;
        int remainingCredits;
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
                "SELECT Gender FROM EmployeeInfo WHERE EmployeeId = "+ txtEmployeeID.Text;

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
               "SELECT EmployeeMaritalStatus FROM EmployeeInfo WHERE EmployeeId=" + txtEmployeeID.Text;

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
                cmb_LeaveType.Items.Clear();
                cmb_LeaveType.Items.AddRange(new String[] { "Sick Leave", "Vacation Leave", "Paternity Leave" });
            }
            else if (selectedGender == "Female" && selectedMaritalStatus == "Married")
            {
                cmb_LeaveType.Items.Clear();
                cmb_LeaveType.Items.AddRange(new String[] { "Sick Leave", "Vacation Leave", "Maternity Leave" });
            }
            else
            {
                cmb_LeaveType.Items.Clear();
                cmb_LeaveType.Items.AddRange(new String[] { "Sick Leave", "Vacation Leave" });
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

                string startDate = dtp_StartDate.Value.ToString("MM/dd/yyyy hh:mm:ss");
                string endDate = dtp_EndDate.Value.ToString("MM/dd/yyyy hh:mm:ss");



                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                command.Parameters.AddWithValue("@Reason", rtxtReason.Text);
                command.Parameters.AddWithValue("@Type", cmb_LeaveType.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("Successfully Applied Leave to the employee");
                rtxtReason.Text = " ";
            }
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * from EmployeeInfo where EmployeeID =" + txtEmployeeID.Text, connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                int totalLeaveDays;
                string employeeLeaveCredits;
                int remainingCredits;
                if (cmb_LeaveType.Text.ToString() == "Sick Leave")
                {
                    totalLeaveDays = (int)(dtp_EndDate.Value - dtp_StartDate.Value).TotalDays;
                    employeeLeaveCredits = (string)dt.Rows[0][18].ToString();
                    remainingCredits = Convert.ToInt32(employeeLeaveCredits) - totalLeaveDays;
                    string query =
                    "UPDATE EmployeeInfo " +
                    "SET SickLeaveCredits = " + remainingCredits +
                    "WHERE EmployeeID = " + txtEmployeeID.Text;
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }

                else if(cmb_LeaveType.Text.ToString() == "Vacation Leave")
                {
                    totalLeaveDays = (int)(dtp_EndDate.Value - dtp_StartDate.Value).TotalDays;
                    employeeLeaveCredits = (string)dt.Rows[0][20].ToString();
                    remainingCredits = Convert.ToInt32(employeeLeaveCredits) - totalLeaveDays;
                    string query =
                   "UPDATE EmployeeInfo " +
                   "SET VacationLeaveCredits = " + remainingCredits +
                   "WHERE EmployeeID = " + txtEmployeeID.Text;
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
             

                connection.Close();
            }
           
            cmb_LeaveType.Text = "";
            dtp_StartDate.Text = "";
            dtp_EndDate.Text = "";
            rtxtReason.Text = "";
        }
        private void Search_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Leave Employee List";
            menu.Menu_Load(menu, EventArgs.Empty);
        }
        private void Leave_Load(object sender, EventArgs e)
        {
            if(txtEmployeeID.Text != "")
            {
                cmb_LeaveType.Enabled = true;
                dtp_StartDate.Enabled = true;
                dtp_EndDate.Enabled = true;
                rtxtReason.Enabled = true;
               

            }
            else
            {
                cmb_LeaveType.Enabled = false;
                dtp_StartDate.Enabled = false;
                dtp_EndDate.Enabled = false;
                rtxtReason.Enabled = false;

            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            txtPosition.Text = "";
            txtDepartment.Text = "";
            txtSchedule.Text = "";
            cmb_LeaveType.Text = "";
            dtp_StartDate.Text = "";
            dtp_EndDate.Text = "";
            rtxtReason.Text = "";

            txtEmployeeID.Enabled = false;
            txtEmployeeName.Enabled = false;
            txtPosition.Enabled = false;
            txtDepartment.Enabled = false;
            txtSchedule.Enabled = false;
    
       

        }

        private void rtxtReason_TextChanged(object sender, EventArgs e)
        {
            if (rtxtReason.Text == "")
            {
                btnSubmit.Enabled = false;
                btnCancel.Enabled = false;

            }
            else
            {
                btnSubmit.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

     
    }
}