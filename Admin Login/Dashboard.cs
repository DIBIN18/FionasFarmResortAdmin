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
    public partial class Dashboard : Form
    {
        Login login = new Login();

        public Dashboard()
        {
            InitializeComponent();
        }

        private int getNumberOfTimedIn()
        {
            string query =
                "SELECT COUNT(*) FROM AttendanceSheet WHERE Date='" + DateTime.Now.ToString("MMMM d, yyyy") + "'";

            int count = 0;

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
            }
            return count;
        }

        private int getNumberOfLate()
        {
            string query =
                "SELECT COUNT(*) FROM AttendanceSheet WHERE Late=1";

            int count = 0;

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
            }
            return count;
        }

        private int getNumberOfAbsent()
        {
            string query =
                "SELECT COUNT(*) FROM EmployeeInfo";

            int count = 0;

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
            }
            return count - getNumberOfTimedIn();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            tmr_DateAndTime.Start();

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = 
                    "SELECT EmployeeInfo.EmployeeID, AttendanceSheet.TimeIn, AttendanceSheet.Late " +
                    "FROM AttendanceSheet " +
                    "INNER JOIN EmployeeInfo ON AttendanceSheet.EmployeeID=EmployeeInfo.EmployeeID " +
                    "WHERE Date='" + DateTime.Now.ToString("MMMM d, yyyy") + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvAttendanceToday.DataSource = data;
            }

            lbl_TimedInToday.Text = getNumberOfTimedIn().ToString();
            lbl_LateToday.Text = getNumberOfLate().ToString();
            lbl_AbsentToday.Text = getNumberOfAbsent().ToString();
        }
        private void Tmr_DateAndTime_Tick(object sender, EventArgs e)
        {
            lbl_Date.Text = DateTime.Now.ToLongDateString();
            lbl_Time.Text = DateTime.Now.ToLongTimeString();
        }
    }
}