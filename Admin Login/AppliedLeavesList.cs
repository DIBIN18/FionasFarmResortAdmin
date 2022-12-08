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
    public partial class AppliedLeavesList : Form
    {
        Login login = new Login();

        public AppliedLeavesList()
        {
            InitializeComponent();
        }

        private void UpdateTable()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();

                string query =
                    "SELECT " +
                    "Leave.LeaveID, " +
                    "Leave.EmployeeID, " +
                    "EmployeeInfo.EmployeeFullName, " +
                    "Leave.Type, Leave.StartDate, " +
                    "Leave.EndDate, " +
                    "Leave.Reason " +
                    "FROM Leave " +
                    "INNER JOIN EmployeeInfo " +
                    "ON Leave.EmployeeID = EmployeeInfo.EmployeeID";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                this.dgvLeaveList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvLeaveList.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvLeaveList.DataSource = dt;

                dgvLeaveList.Columns["LeaveRecordID"].Visible = false;
                dgvLeaveList.Columns["EmployeeID"].Visible = false;
            }
        }

        private void AppliedLeavesList_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}
