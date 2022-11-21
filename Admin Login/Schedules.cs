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
    public partial class Schedules : Form
    {
        Login login = new Login();

        public Schedules()
        {
            InitializeComponent();
        }

        private void Schedules_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();

                string query =
                    "SELECT " +
                    "EmployeeInfo.EmployeeFullName," +
                    "EmployeeSchedule.ScheduleIn," +
                    "EmployeeSchedule.ScheduleOut," +
                    "EmployeeSchedule.BreakPeriod AS BreakTime," +
                    "EmployeeSchedule.Monday AS Mon," +
                    "EmployeeSchedule.Tuesday AS Tue," +
                    "EmployeeSchedule.Wednesday AS Wed," +
                    "EmployeeSchedule.Thursday AS Thu," +
                    "EmployeeSchedule.Friday AS Fri," +
                    "EmployeeSchedule.Saturday AS Sat," +
                    "EmployeeSchedule.Sunday AS Sun " +
                    "FROM EmployeeSchedule " +
                    "INNER JOIN EmployeeInfo " +
                    "ON EmployeeSchedule.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Status='Active'";


                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                // Column font
                this.dgv_Schedules.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                // Row font
                this.dgv_Schedules.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgv_Schedules.DataSource = data;
            }
        }
    }
}
