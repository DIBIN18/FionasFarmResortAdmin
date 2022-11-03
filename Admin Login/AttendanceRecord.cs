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
    public partial class AttendanceRecord : Form
    {
        Login login = new Login();
        public AttendanceRecord()
        {
            InitializeComponent();
        }

        private void Tb_Search_Enter(object sender, EventArgs e)
        {
            if (tb_Search.Text == " Search")
            {
                tb_Search.Text = "";
                tb_Search.ForeColor = Color.Black;
            }
        }
        private void Tb_Search_Leave(object sender, EventArgs e)
        {
            if (tb_Search.Text == "")
            {
                tb_Search.Text = " Search";
                tb_Search.ForeColor = Color.Silver;
            }
        }

        private void AttendanceRecord_Load(object sender, EventArgs e)
        {
            dtp_Date.Format = DateTimePickerFormat.Custom;
            dtp_Date.CustomFormat = "MMMM dd, yyyy";
            string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT EmployeeInfo.EmployeeFullName, AttendanceSheet.* " +
                    "FROM AttendanceSheet " +
                    "INNER JOIN EmployeeInfo " +
                    "ON EmployeeInfo.EmployeeID = AttendanceSheet.EmployeeID " +
                    "WHERE Date='" + date + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                // Column font
                this.dgvAttendanceRecord.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                // Row font
                this.dgvAttendanceRecord.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvAttendanceRecord.DataSource = data;
            }

        }

        private void dtp_Date_ValueChanged(object sender, EventArgs e)
        {
            dtp_Date.Format = DateTimePickerFormat.Custom;
            dtp_Date.CustomFormat = "MMMM dd, yyyy";
            string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT EmployeeInfo.EmployeeFullName, AttendanceSheet.* " +
                    "FROM AttendanceSheet " +
                    "INNER JOIN EmployeeInfo " +
                    "ON EmployeeInfo.EmployeeID = AttendanceSheet.EmployeeID " +
                    "WHERE Date='" + date + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvAttendanceRecord.DataSource = data;
            }
        }

        private void btn_addAttendance(object sender, EventArgs e)
        {
            //open add attendance window
            //AddAttendance aa = new AddAttendance();
            //aa.ShowDialog();
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Add Attendance";
            menu.Menu_Load(menu, EventArgs.Empty);
        }
    }
}