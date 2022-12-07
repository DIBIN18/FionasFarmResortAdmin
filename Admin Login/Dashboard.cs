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
using System.IO;

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
                "SELECT COUNT(*) FROM AttendanceRecord WHERE Date='" + DateTime.Now.ToString("MMMM dd, yyyy") + "'";

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
                "SELECT COUNT(*) FROM AttendanceRecord " +
                "WHERE Late_Minutes > 1 " +
                "AND Date='" + DateTime.Now.ToString("MMMM dd, yyyy") + "'";

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
                "SELECT COUNT(*) FROM EmployeeInfo WHERE Status='Active'";

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
                    "SELECT E.EmployeeFullName, " +
                    "E.EmployeeID, " +
                    "A.TimeIn," +
                    "A.Late_Minutes " +
                    "FROM AttendanceRecord AS A " +
                    "LEFT JOIN EmployeeInfo AS E " +
                    "ON A.EmployeeID = E.EmployeeID " +
                    "WHERE Date='" + DateTime.Now.ToString("MMMM dd, yyyy") + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                // Column font
                this.dgv_AttendanceToday.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                // Row font
                this.dgv_AttendanceToday.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgv_AttendanceToday.DataSource = data;
            }

            lbl_TimedInToday.Text = getNumberOfTimedIn().ToString();
            lbl_LateToday.Text = getNumberOfLate().ToString();
            lbl_AbsentToday.Text = getNumberOfAbsent().ToString();

            CreateBackup();
        }
        private void Tmr_DateAndTime_Tick(object sender, EventArgs e)
        {
            lbl_Date.Text = DateTime.Now.ToLongDateString();
            lbl_Time.Text = DateTime.Now.ToLongTimeString();
        }

        private void CreateBackup()
        {
            //var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            //DateTime today = DateTime.Today;

            //if (!File.Exists(path + "\\Database Backups\\Backup - " +
            //            today.ToString("MMMM dd yyyy") + ".bak'"))
            //{
            //    using (SqlConnection connection = new SqlConnection(login.connectionString))
            //    {
            //        connection.Open();

            //        string query =
            //            "BACKUP DATABASE FFRUsers " +
            //            "TO DISK = '" + path + "\\Database Backups\\Backup - " +
            //            today.ToString("MMMM dd yyyy") + ".bak'";

            //        SqlCommand command = new SqlCommand(query, connection);
            //        command.ExecuteNonQuery();
            //    }
            //}
        }
    }
}