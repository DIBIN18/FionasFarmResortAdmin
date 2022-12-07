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
    public partial class AppliedLeaveList : Form
    {
        string SelectedLeaveRecordID = "";

        Login login = new Login();
        public AppliedLeaveList()
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
            SelectedLeaveRecordID = dgvLeaveList.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Returning leave credits are not applied yet

            DialogResult dialogResult = 
                MessageBox.Show("Are you sure you want to remove the applied leave?", 
                                "Remove Applied Leave",MessageBoxButtons.YesNo, MessageBoxIcon.Information);


            if (dialogResult == DialogResult.Yes)
            {
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
            }
        }

        private void tb_Search_Click(object sender, EventArgs e)
        {
            tb_Search.Text = "";
        }

        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
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
    }
}
