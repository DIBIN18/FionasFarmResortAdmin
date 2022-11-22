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
    public partial class OvertimeDates : Form
    {
        Login login = new Login();
        string selectedEmployee = " ";

        public OvertimeDates()
        {
            InitializeComponent();
        }

        private void OvertimeDates_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT " +
                    "EmployeeSchedule.ScheduleID, " +
                    "EmployeeInfo.EmployeeID, " +
                    "EmployeeInfo.EmployeeFullName, " +
                    "EmployeeSchedule.ScheduleIn, " +
                    "EmployeeSchedule.ScheduleOut " +
                    "FROM EmployeeSchedule " +
                    "INNER JOIN EmployeeInfo " +
                    "ON EmployeeSchedule.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Status='Active'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                this.dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvEmployees.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvEmployees.DataSource = data;
                dgvEmployees.Columns["ScheduleID"].Visible = false;
                dgvEmployees.Columns["EmployeeID"].Visible = false;
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedEmployee = dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();
            lbl_EmployeeName.Text = dgvEmployees.Rows[e.RowIndex].Cells[2].Value.ToString();

            dtpDateFrom.Enabled = true;
            dtpDateTo.Enabled = true;
        }

        // Insert Dates from given range
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DateTime StartDate = DateTime.Parse(dtpDateFrom.Text.ToString());
            DateTime EndDate = DateTime.Parse(dtpDateTo.Text.ToString());

            foreach (DateTime day in EachDay(StartDate, EndDate))
            {
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();
                    string query =
                        "INSERT INTO OvertimeDates (" +
                        "EmployeeID," +
                        "Date) " +
                        "VALUES(" +
                        "@EmployeeID," +
                        "@Date)";

                    SqlCommand command2 = new SqlCommand(query, connection);
                    command2.Parameters.AddWithValue("@EmployeeID", Convert.ToInt64(selectedEmployee));
                    command2.Parameters.AddWithValue("@Date", day.ToString("MMMM dd, yyyy"));
                    command2.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Overtime Dates added");
        }

        private void btnBackEdit_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Schedules";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }

        private void btnAddMode_Click_1(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Overtime Lists";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }
    }
}
