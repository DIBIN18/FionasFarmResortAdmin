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
                    // Nilagay ko yung +1 sa totalLeaveDays, di tama kasi yung bilang
                    //totalLeaveDays = (int)(dtp_EndDate.Value - dtp_StartDate.Value).TotalDays;

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
                        DialogResult d = MessageBox.Show("Not Enough Leave Credits", "Hello :-) Your Total Credits = " + employeeLeaveCredits, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string query =
                           "UPDATE EmployeeInfo " +
                           "SET SickLeaveCredits = " + remainingCredits +
                           "WHERE EmployeeID = " + txtEmployeeID.Text;
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
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

                        DialogResult d = MessageBox.Show("SuccessFul", "Your Total SickLeaveCredits: " + remainingCredits.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (d == DialogResult.OK)
                        {
                            addLeavePayDetails(totalLeaveDays, txtEmployeeID.Text.ToString());
                            rtxtReason.Text = " ";
                            cmb_LeaveType.Text = " ";
                            dtp_StartDate.Value = DateTime.Now;
                            dtp_EndDate.Value = DateTime.Now;
                            Menu menu = (Menu)Application.OpenForms["Menu"];
                            menu.Text = "Fiona's Farm and Resort - Leave";
                            menu.Menu_Load(menu, EventArgs.Empty);
                        }
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
                        DialogResult d = MessageBox.Show("Not Enough Leave Credits", "Hello :-) Your Total Credits = " + employeeLeaveCredits, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        string query =
                           "UPDATE EmployeeInfo " +
                           "SET VacationLeaveCredits = " + remainingCredits +
                           "WHERE EmployeeID = " + txtEmployeeID.Text;
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
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


                        DialogResult d = MessageBox.Show("SuccessFul", "Your Total VacationLeaveCredits: " + remainingCredits.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (d == DialogResult.OK)
                        {
                            addLeavePayDetails(totalLeaveDays, txtEmployeeID.Text.ToString());
                            rtxtReason.Text = " ";
                            cmb_LeaveType.Text = " ";
                            dtp_StartDate.Value = DateTime.Now;
                            dtp_EndDate.Value = DateTime.Now;
                            Menu menu = (Menu)Application.OpenForms["Menu"];
                            menu.Text = "Fiona's Farm and Resort - Leave";
                            menu.Menu_Load(menu, EventArgs.Empty);
                        }
                    }
                }
                connection.Close();
            }
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Leave Employee List";
            menu.Menu_Load(menu, EventArgs.Empty);
        }
        private void Leave_Load(object sender, EventArgs e)
        {
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

        private void btnCancel_Click(object sender, EventArgs e)
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
                btnSubmit.Enabled = false;
                btnCancel.Enabled = false;
            }
            else
            {
                btnSubmit.Enabled = true;
                btnCancel.Enabled = true;
            }
        }


        // Leave Payment Codes
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
            // Add duplicate date constraint
            DateTime StartDate = DateTime.Parse(dtp_StartDate.Text.ToString());
            DateTime EndDate = DateTime.Parse(dtp_EndDate.Text.ToString());

            foreach (DateTime day in EachDay(StartDate, EndDate))
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
                }
            }
        }
    }
}