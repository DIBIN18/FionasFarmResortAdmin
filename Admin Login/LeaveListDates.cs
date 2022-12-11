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
    public partial class LeaveListDates : Form
    {
        string SelectedLeaveRecordID = "";
        string SelectedEmployeeID = "";
        string SelectedDate = "";
        string SelectedEmployeeName = "";

        Login login = new Login();
        public LeaveListDates()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Leave";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        public void UpdateTable()
        {
            dtp_Date.Format = DateTimePickerFormat.Custom;
            dtp_Date.CustomFormat = "MMMM dd, yyyy";
            string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

            string query =
                "SELECT " +
                "LeavePay.LeaveRecordID, " + 
                "LeavePay.EmployeeID," +
                "EmployeeInfo.EmployeeFullName, " +
                "Leave.Type, Leave.Reason, " +
                "LeavePay.Date " +
                "FROM LeavePay " +
                "INNER JOIN EmployeeInfo " +
                "ON LeavePay.EmployeeID = EmployeeInfo.EmployeeID " +
                "INNER JOIN Leave " +
                "ON LeavePay.LeaveID = Leave.LeaveID " +
                "WHERE Date = '" + date + "'";

            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            this.dgvLeaveList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.dgvLeaveList.DefaultCellStyle.Font = new Font("Century Gothic", 10);

            dgvLeaveList.DataSource = dt;

            dgvLeaveList.Columns["LeaveRecordID"].Visible = false;
            dgvLeaveList.Columns["EmployeeID"].Visible = false;
            conn.Close();
        }

        private void AppliedLeaveList_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void dtp_Date_ValueChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void dgvLeaveList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SelectedLeaveRecordID = dgvLeaveList.Rows[e.RowIndex].Cells[0].Value.ToString();
                SelectedEmployeeID = dgvLeaveList.Rows[e.RowIndex].Cells[1].Value.ToString();
                SelectedDate = dgvLeaveList.Rows[e.RowIndex].Cells[5].Value.ToString();
                SelectedEmployeeName = dgvLeaveList.Rows[e.RowIndex].Cells[2].Value.ToString();

            }
            catch (System.ArgumentOutOfRangeException)
            {
                // Do nothing
                // Column header click catcher
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = 
                MessageBox.Show("Are you sure you want to cancel the applied leave date?\n" +
                                "For " + SelectedEmployeeName + " on " + SelectedDate, 
                                "Remove Applied Leave Date",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                ReturnLeaveCredits();

                string query =
                "DELETE FROM LeavePay WHERE LeaveRecordID=" + SelectedLeaveRecordID;
                
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    UpdateTable();

                    AuditTrail audit = new AuditTrail();
                    audit.AuditRemoveLeave();
                }

                MessageBox.Show("Applied Leave Successfully Cancelled", "Leave Cancellation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tb_Search_Click(object sender, EventArgs e)
        {
            tb_Search.Text = "";
        }

        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            tb_Search.ForeColor = System.Drawing.Color.Black;

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                if (string.IsNullOrEmpty(tb_Search.Text))
                {
                    dtp_Date.Format = DateTimePickerFormat.Custom;
                    dtp_Date.CustomFormat = "MMMM dd, yyyy";
                    string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

                    string query =
                        "SELECT " +
                        "LeavePay.LeaveRecordID, " +
                        "EmployeeInfo.EmployeeFullName, " +
                        "Leave.Type, Leave.Reason, " +
                        "LeavePay.Date " +
                        "FROM LeavePay " +
                        "INNER JOIN EmployeeInfo " +
                        "ON LeavePay.EmployeeID = EmployeeInfo.EmployeeID " +
                        "INNER JOIN Leave " +
                        "ON LeavePay.LeaveID = Leave.LeaveID " +
                        "WHERE Date = '" + date + "'";

                    SqlCommand cmd2 = new SqlCommand(query, connection);
                    SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    sqlDataAdapter2.Fill(dt2);
                    dgvLeaveList.DataSource = dt2;
                }
                else if (tb_Search.Focused)
                {
                    dtp_Date.Format = DateTimePickerFormat.Custom;
                    dtp_Date.CustomFormat = "MMMM dd, yyyy";
                    string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

                    string query =
                        "SELECT " +
                        "LeavePay.LeaveRecordID, " +
                        "EmployeeInfo.EmployeeFullName, " +
                        "Leave.Type, Leave.Reason, " +
                        "LeavePay.Date " +
                        "FROM LeavePay " +
                        "INNER JOIN EmployeeInfo " +
                        "ON LeavePay.EmployeeID = EmployeeInfo.EmployeeID " +
                        "INNER JOIN Leave " +
                        "ON LeavePay.LeaveID = Leave.LeaveID " +
                        "WHERE Date = '" + date + "' AND " +
                        "EmployeeFullName like '%" + tb_Search.Text + "%'";

                    SqlCommand cmd2 = new SqlCommand(query, connection);

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dgvLeaveList.DataSource = dt;
                }
            }
        }

        private string GetLeaveType(string emp_id, string date)
        {
            string query2 =
                "select Leave.Type " +
                "from LeavePay " +
                "inner join Leave " +
                "on LeavePay.LeaveID = Leave.LeaveID " +
                "where LeavePay.EmployeeID = " + emp_id + " " +
                "and Date='" + date + "'";


            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
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
                        return "";
                    }
                }
            }
        }

        private void ReturnLeaveCredits()
        {
            if (GetLeaveType(SelectedEmployeeID, SelectedDate) == "Sick Leave")
            {
                using (SqlConnection conn = new SqlConnection(login.connectionString))
                {
                    conn.Open();

                    string query = 
                        "UPDATE EmployeeInfo " +
                        "SET SickLeaveCredits = SickLeaveCredits + 1 " +
                        "WHERE EmployeeID=" + SelectedEmployeeID;
                    Console.WriteLine(query);
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            else if (GetLeaveType(SelectedEmployeeID, SelectedDate) == "Vacation Leave")
            {
                using (SqlConnection conn = new SqlConnection(login.connectionString))
                {
                    conn.Open();

                    string query =
                        "UPDATE EmployeeInfo " +
                        "SET VacationLeaveCredits = VacationLeaveCredits + 1 " +
                        "WHERE EmployeeID=" + SelectedEmployeeID;

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
