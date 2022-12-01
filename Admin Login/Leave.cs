using Syncfusion.XlsIO;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private void cmbLeaveType_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT Gender FROM EmployeeInfo WHERE EmployeeId = " + txtEmployeeID.Text;

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
                SqlCommand cmd = new SqlCommand("Select * from EmployeeInfo where EmployeeID =" + txtEmployeeID.Text, connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                int totalLeaveDays;
                string employeeLeaveCredits;
                int remainingCredits;

                if (cmb_LeaveType.Text.ToString() == "Sick Leave")
                {
                    if (dtp_StartDate.Text.ToString() == dtp_EndDate.Text.ToString())
                    {
                        totalLeaveDays = 1;
                    }
                    else
                    {
                        totalLeaveDays = (int)((dtp_EndDate.Value - dtp_StartDate.Value).TotalDays) + 1;
                    }

                    employeeLeaveCredits = dt.Rows[0][18].ToString();
                    remainingCredits = Convert.ToInt32(employeeLeaveCredits) - totalLeaveDays;

                    int ZeroRemaining = 0;

                    if (totalLeaveDays > Convert.ToInt32(employeeLeaveCredits) || remainingCredits < ZeroRemaining)
                    {
                        DialogResult d = MessageBox.Show("Not Enough Leave Credits", "Your Total Credits = " + employeeLeaveCredits, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //----------INSERTING DETAILS--------
                        string query2 =
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

                        SqlCommand command2 = new SqlCommand(query2, connection);
                        command2.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                        command2.Parameters.AddWithValue("@StartDate", dtp_StartDate.Text.ToString());
                        command2.Parameters.AddWithValue("@EndDate", dtp_EndDate.Text.ToString());
                        command2.Parameters.AddWithValue("@Reason", rtxtReason.Text);
                        command2.Parameters.AddWithValue("@Type", cmb_LeaveType.Text);

                        command2.ExecuteNonQuery();

                        addLeavePayDetails(totalLeaveDays, txtEmployeeID.Text.ToString());

                        rtxtReason.Text = " ";
                        cmb_LeaveType.Text = " ";
                        //dtp_StartDate.Value = DateTime.Now;
                        //dtp_EndDate.Value = DateTime.Now;

                        Menu menu = (Menu)Application.OpenForms["Menu"];
                        menu.Text = "Fiona's Farm and Resort - Leave";
                        menu.Menu_Load(menu, EventArgs.Empty);

                        MessageBox.Show("Successfully applied leave");
                        //DialogResult d = MessageBox.Show("SuccessFul", "Your Total SickLeaveCredits: " + remainingCredits.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (d == DialogResult.OK)
                        //{
                            
                        //}
                    }
                }

                else if (cmb_LeaveType.Text.ToString() == "Vacation Leave")
                {
                    if (dtp_StartDate.Text.ToString() == dtp_EndDate.Text.ToString())
                    {
                        totalLeaveDays = 1;
                    }
                    else
                    {
                        totalLeaveDays = (int)((dtp_EndDate.Value - dtp_StartDate.Value).TotalDays) + 1;
                    }

                    employeeLeaveCredits = dt.Rows[0][20].ToString();
                    remainingCredits = Convert.ToInt32(employeeLeaveCredits) - totalLeaveDays;
                    int ZeroRemaining = 0;
                    if (totalLeaveDays > Convert.ToInt32(employeeLeaveCredits) || remainingCredits < ZeroRemaining)
                    {
                        DialogResult d = MessageBox.Show("Not Enough Leave Credits", "Your Total Credits = " + employeeLeaveCredits, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        //string query =
                        //   "UPDATE EmployeeInfo " +
                        //   "SET VacationLeaveCredits = " + remainingCredits +
                        //   "WHERE EmployeeID = " + txtEmployeeID.Text;
                        //SqlCommand command = new SqlCommand(query, connection);
                        //command.ExecuteNonQuery();
                        //----------INSERTING DETAILS--------
                        string query2 =
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


                        SqlCommand command2 = new SqlCommand(query2, connection);
                        command2.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                        command2.Parameters.AddWithValue("@StartDate", dtp_StartDate.Text.ToString());
                        command2.Parameters.AddWithValue("@EndDate", dtp_EndDate.Text.ToString());
                        command2.Parameters.AddWithValue("@Reason", rtxtReason.Text);
                        command2.Parameters.AddWithValue("@Type", cmb_LeaveType.Text);

                        command2.ExecuteNonQuery();


                        addLeavePayDetails(totalLeaveDays, txtEmployeeID.Text.ToString());
                        rtxtReason.Text = " ";
                        cmb_LeaveType.Text = " ";

                        //dtp_StartDate.Value = DateTime.Now;
                        //dtp_EndDate.Value = DateTime.Now;

                        Menu menu = (Menu)Application.OpenForms["Menu"];
                        menu.Text = "Fiona's Farm and Resort - Leave";
                        menu.Menu_Load(menu, EventArgs.Empty);

                        MessageBox.Show("Successfully applied leave");

                        //DialogResult d = MessageBox.Show("SuccessFul", "Your Total VacationLeaveCredits: " + remainingCredits.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (d == DialogResult.OK)
                        //{

                        //}
                    }
                }

                connection.Close();
            }
        }

        private void btnViewLeaveList_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Applied Leave List";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Leave Employee List";
            menu.Menu_Load(menu, EventArgs.Empty);
        }
        private void Leave_Load(object sender, EventArgs e)
        {
            dtp_StartDate.MaxDate = dtp_EndDate.Value;

            dtp_StartDate.Format = DateTimePickerFormat.Custom;
            dtp_StartDate.CustomFormat = "MMMM dd, yyyy";

            dtp_EndDate.Format = DateTimePickerFormat.Custom;
            dtp_EndDate.CustomFormat = "MMMM dd, yyyy";

            if (txtEmployeeID.Text != "")
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
        public void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            txtPosition.Text = "";
            txtDepartment.Text = "";
            txtSLeaveCredits.Text = "";
            txtVLeaveCredits.Text = "";
            txtSchedule.Text = "";
            cmb_LeaveType.Text = "";
            dtp_StartDate.Text = "";
            dtp_EndDate.Text = "";
            rtxtReason.Text = "";

            txtEmployeeID.Enabled = false;
            txtEmployeeName.Enabled = false;
            txtPosition.Enabled = false;
            txtDepartment.Enabled = false;
            //txtSchedule.Enabled = false;
        }
        private void rtxtReason_TextChanged(object sender, EventArgs e)
        {
            if (rtxtReason.Text == "")
            {
                lblCancel.Enabled = false;
                pbCancel.Enabled = false;
                pbCancelShape.Enabled = false;

                lblApplyLeave.Enabled = false;
                pbApplyLeave.Enabled = false;
                pbApplyLeaveShape.Enabled = false;  
            }
            else
            {
                lblCancel.Enabled = true;
                pbCancel.Enabled = true;
                pbCancelShape.Enabled = true;

                lblApplyLeave.Enabled = true;
                pbApplyLeave.Enabled = true;
                pbApplyLeaveShape.Enabled = true;
            }
        }

        public string checkAttendanceDate(string employee_id, string date)
        {
            string query =
                    "SELECT Date " +
                    "FROM AttendanceRecord " +
                    "WHERE EmployeeID=" + employee_id + " AND " +
                    "Date='" + date + "'";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetString(0);
                    }
                    else
                    {
                        return "None ";
                    }

                }
            }
        }

        public string checkLeaveDate(string employee_id, string date)
        {
            string query =
                    "SELECT Date " +
                    "FROM LeavePay " +
                    "WHERE EmployeeID=" + employee_id + " AND " +
                    "Date='" + date + "'";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetString(0);
                    }
                    else
                    {
                        return "None";
                    }

                }
            }
        }

        //
        // Leave Payment Codes
        //

        // Insert Dates from given range
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public Int64 getLatestLeaveID()
        {
            string query2 =
                "SELECT MAX(LeaveID) FROM Leave";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetInt64(0);
                    }
                    else
                    {
                        return 0;
                    }

                }
            }
        }

        public void addLeavePayDetails(int num_of_days, string emp_id)
        {
            DateTime StartDate = DateTime.Parse(dtp_StartDate.Text.ToString());
            DateTime EndDate = DateTime.Parse(dtp_EndDate.Text.ToString());

            int totaldays = 0;

            foreach (DateTime day in EachDay(StartDate, EndDate))
            {
                string attendance_date = checkAttendanceDate(emp_id, day.ToString("MMMM dd, yyyy"));
                string leave_date = checkLeaveDate(emp_id, day.ToString("MMMM dd, yyyy"));

                if (attendance_date == day.ToString("MMMM dd, yyyy"))
                {
                    MessageBox.Show("Employee had an attendance record on " + day.ToString("MMMM dd, yyyy") + 
                        "\nLeave will not be applied on this date");
                }
                else if (leave_date == day.ToString("MMMM dd, yyyy"))
                {
                    MessageBox.Show("Employee already applied for a leave on " + day.ToString("MMMM dd, yyyy") +
                        "\nLeave will not be applied on this date");
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(login.connectionString))
                    {
                        connection.Open();
                        string query =
                            "INSERT INTO LeavePay (" +
                            "LeaveID," +
                            "EmployeeID," +
                            "Date) " +
                            "VALUES(" +
                            "@LeaveID," +
                            "@EmployeeID," +
                            "@Date)";

                        SqlCommand command2 = new SqlCommand(query, connection);
                        command2.Parameters.AddWithValue("@LeaveID", getLatestLeaveID());
                        command2.Parameters.AddWithValue("@EmployeeID", Convert.ToInt64(emp_id));
                        command2.Parameters.AddWithValue("@Date", day.ToString("MMMM dd, yyyy"));
                        command2.ExecuteNonQuery();

                        totaldays = totaldays + 1;
                    }
                }
            }

            using (SqlConnection connection2 = new SqlConnection(login.connectionString))
            {
                connection2.Open();

                SqlCommand cmd = new SqlCommand("Select * from EmployeeInfo where EmployeeID =" + txtEmployeeID.Text, connection2);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                string employeeLeaveCredits;
                int remainingCredits;

                employeeLeaveCredits = dt.Rows[0][18].ToString();
                remainingCredits = Convert.ToInt32(employeeLeaveCredits) - totaldays;

                string query =
                           "UPDATE EmployeeInfo " +
                           "SET SickLeaveCredits = " + remainingCredits +
                           "WHERE EmployeeID = " + txtEmployeeID.Text;
                SqlCommand command = new SqlCommand(query, connection2);
                command.ExecuteNonQuery();
            }
        }

        private void dtp_StartDate_ValueChanged(object sender, EventArgs e)
        {
            dtp_StartDate.MaxDate = dtp_EndDate.Value;
        }

        private void dtp_EndDate_ValueChanged(object sender, EventArgs e)
        {
            dtp_StartDate.MaxDate = dtp_EndDate.Value;
        }
    }
}