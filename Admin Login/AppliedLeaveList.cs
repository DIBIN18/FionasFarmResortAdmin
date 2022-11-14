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

        private void AppliedLeaveList_Load(object sender, EventArgs e)
        {
            string query = 
                "SELECT " +
                "EmployeeInfo.EmployeeFullName, " +
                "Leave.Type, Leave.Reason, " +
                "LeavePay.Date " +
                "FROM LeavePay " +
                "INNER JOIN EmployeeInfo " +
                "ON LeavePay.EmployeeID = EmployeeInfo.EmployeeID " +
                "INNER JOIN Leave " +
                "ON LeavePay.LeaveID = Leave.LeaveID";

            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Column font
            this.dgvLeaveList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            // Row font
            this.dgvLeaveList.DefaultCellStyle.Font = new Font("Century Gothic", 10);

            dgvLeaveList.DataSource = dt;  
        }


    }
}
