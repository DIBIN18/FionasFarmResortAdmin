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
    public partial class AddSingleSchedule : Form
    {
        Login login = new Login();
        string selectedEmployee = " ";

        public AddSingleSchedule()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Schedules";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }

        private void AddSingleSchedule_Load(object sender, EventArgs e)
        {
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "MMMM dd, yyyy";

            dtpScheduleIn.Format = DateTimePickerFormat.Time;
            dtpScheduleIn.ShowUpDown = true;

            dtpSchedOut.Format = DateTimePickerFormat.Time;
            dtpSchedOut.ShowUpDown = true;

            dtpScheduleIn.Format = DateTimePickerFormat.Custom;
            dtpScheduleIn.CustomFormat = "hh:mm:ss tt";

            dtpSchedOut.Format = DateTimePickerFormat.Custom;
            dtpSchedOut.CustomFormat = "hh:mm:ss tt";

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

            dtpDate.Enabled = true;
            dtpSchedOut.Enabled = true;
            dtpScheduleIn.Enabled = true; 
        }

        public bool CheckLeave(string date, string employee_id)
        {
            string query2 =
                "SELECT Date FROM LeavePay WHERE Date='" + date + "' AND EmployeeID=" + employee_id;

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool CheckAccDayOff(string date, string employee_id)
        {
            string query2 =
                "SELECT Date FROM AccDayOffsDate WHERE Date='" + date + "' AND EmployeeID=" + employee_id;

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string schedIn = dtpScheduleIn.Value.ToString("hh:mm:ss tt");
            string schedOut = dtpSchedOut.Value.ToString("hh:mm:ss tt");
            string date = dtpDate.Value.ToString("MMMM dd, yyyy");

            if (CheckLeave(date, selectedEmployee) == false && CheckAccDayOff(date, selectedEmployee) == false)
            {
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();

                    string query =
                        "INSERT INTO " +
                        "SingleSchedule(EmployeeID,ScheduleIn, ScheduleOut, Date) " +
                        "VALUES (@EmployeeID, @ScheduleIn, @ScheduleOut, @Date)";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ScheduleIn", schedIn.ToUpper());
                    cmd.Parameters.AddWithValue("@ScheduleOut", schedOut.ToUpper());
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@EmployeeID", Convert.ToInt64(selectedEmployee));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Added Single Schedule");
                }
            }
            else
            {
                MessageBox.Show("Employee is scheduled for a leave or advanced day off on the selected date, single schedule can not be added");
            }
        }

        private void view_single_schedlist(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Single Schedule List";
            menu.Menu_Load(menu, EventArgs.Empty);
        }
    }
}
