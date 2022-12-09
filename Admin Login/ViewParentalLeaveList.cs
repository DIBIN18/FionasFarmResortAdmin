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
    public partial class ViewParentalLeaveList : Form
    {
        Login login = new Login();

        string SelectedLeaveID = "", SelectedEmployeeName = "";

        public ViewParentalLeaveList()
        {
            InitializeComponent();
        }

        public void UpdateTable()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();

                string query = 
                    "SELECT " +
                    "Leave.LeaveID, " +
                    "Leave.EmployeeID, " +
                    "EmployeeInfo.EmployeeFullName, " +
                    "Leave.StartDate, " +
                    "Leave.EndDate, " +
                    "Leave.Type, " +
                    "Leave.Reason " +
                    "FROM Leave " +
                    "INNER JOIN EmployeeInfo " +
                    "ON Leave.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Type='Maternity Leave' OR Type='Paternity Leave'";

                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                this.dgvLeaves.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvLeaves.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvLeaves.DataSource = dt;

                dgvLeaves.Columns["LeaveID"].Visible = false;
                dgvLeaves.Columns["EmployeeID"].Visible = false;
            }
        }

        private void ViewParentalLeaveList_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void BtnBackClick(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Leave";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        private void dgvLeaves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedLeaveID = dgvLeaves.Rows[e.RowIndex].Cells[0].Value.ToString();
            SelectedEmployeeName = dgvLeaves.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void tb_Search_Click(object sender, EventArgs e)
        {
            tb_Search.Text = null;
        }

        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                if (string.IsNullOrEmpty(tb_Search.Text))
                {
                    string query =
                    "SELECT " +
                    "Leave.LeaveID, " +
                    "Leave.EmployeeID, " +
                    "EmployeeInfo.EmployeeFullName, " +
                    "Leave.StartDate, " +
                    "Leave.EndDate, " +
                    "Leave.Type, " +
                    "Leave.Reason " +
                    "FROM Leave " +
                    "INNER JOIN EmployeeInfo " +
                    "ON Leave.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Type='Maternity Leave' OR Type='Paternity Leave'";

                    SqlCommand cmd2 = new SqlCommand(query, connection);
                    SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    sqlDataAdapter2.Fill(dt2);
                    dgvLeaves.DataSource = dt2;
                }
                else if (tb_Search.Focused)
                {
                    string query =
                    "SELECT " +
                    "Leave.LeaveID, " +
                    "Leave.EmployeeID, " +
                    "EmployeeInfo.EmployeeFullName, " +
                    "Leave.StartDate, " +
                    "Leave.EndDate, " +
                    "Leave.Type, " +
                    "Leave.Reason " +
                    "FROM Leave " +
                    "INNER JOIN EmployeeInfo " +
                    "ON Leave.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Type='Maternity Leave' OR Type='Paternity Leave' " +
                    "AND EmployeeFullName LIKE '%" + tb_Search.Text + "%'";

                    SqlCommand cmd2 = new SqlCommand(query, connection);

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dgvLeaves.DataSource = dt;
                }
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            using (SqlConnection conn1 = new SqlConnection(login.connectionString))
            {
                conn1.Open();

                DialogResult dialogResult =
                MessageBox.Show("Are you sure you want to cancel the applied leave?\n" +
                                "For " + SelectedEmployeeName,
                                "Remove Applied Leave Date", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    string query = 
                        "DELETE FROM LeavePay WHERE LeaveID=" + SelectedLeaveID + " " +
                        "DELETE FROM Leave WHERE LeaveID=" + SelectedLeaveID;

                    SqlCommand cmd = new SqlCommand(query, conn1);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Applied Leave Successfully Cancelled", "Leave Cancellation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UpdateTable();
                }
            }
        }
    }
}
