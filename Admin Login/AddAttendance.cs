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
using System.Globalization;

namespace Admin_Login
{
    public partial class AddAttendance : Form
    {
        Login login = new Login();
        string employee_id = "", schedule_in = "", schedule_out = "";

        public AddAttendance()
        {
            InitializeComponent();
        }

        // Attendance Constaraints (not implemented yet)
        public Boolean checkAllowedOT(string emp_id)
        {
            string query2 = "SELECT AllowedOvertime FROM EmployeeInfo WHERE EmployeeID=" + emp_id;
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetBoolean(0);
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }

        public Boolean checkAllowedDay(string emp_id)
        {
            string sDate = dtp_Date.Text.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            int dy = datevalue.Day;
            int mn = datevalue.Month;
            int yy = datevalue.Year;

            DateTime findWeek = new DateTime(yy, mn, dy);
            string dayofweek = findWeek.ToString("dddd");

            string query2 = "SELECT " + dayofweek + " FROM EmployeeSchedule WHERE EmployeeID=" + emp_id;
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetBoolean(0);
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }

        public Boolean checkSingleSched(string emp_id, string date)
        {
            string singleSchedDate = "";
            string query2 = "SELECT Date FROM SingleSchedule WHERE Date='" + date + "' AND EmployeeID=" + emp_id;
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        singleSchedDate = reader.GetString(0);

                        if (singleSchedDate == date)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Attendance Record";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }

        private void AddAttendance_Load(object sender, EventArgs e)
        {
            dtpScheduleInEdit.Format = DateTimePickerFormat.Time;
            dtpScheduleInEdit.ShowUpDown = true;

            dtpSchedOutEdit.Format = DateTimePickerFormat.Time;
            dtpSchedOutEdit.ShowUpDown = true;

            dtpScheduleInEdit.Format = DateTimePickerFormat.Custom;
            dtpScheduleInEdit.CustomFormat = "hh:mm:ss tt";

            dtpSchedOutEdit.Format = DateTimePickerFormat.Custom;
            dtpSchedOutEdit.CustomFormat = "hh:mm:ss tt";

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
                    "ON EmployeeSchedule.EmployeeID = EmployeeInfo.EmployeeID";

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
            dtpScheduleInEdit.Enabled = true;
            dtpSchedOutEdit.Enabled = true;
            dtp_Date.Enabled = true;

            employee_id = dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();
            lblEmployeeName.Text = dgvEmployees.Rows[e.RowIndex].Cells[2].Value.ToString();
            schedule_in = dgvEmployees.Rows[e.RowIndex].Cells[3].Value.ToString();
            schedule_out = dgvEmployees.Rows[e.RowIndex].Cells[4].Value.ToString();

            Update();
        }

        private void dtpScheduleInEdit_ValueChanged(object sender, EventArgs e)
        {
            Update();
        }

        private void dtpSchedOutEdit_ValueChanged(object sender, EventArgs e)
        {
            Update();
        }

        private void dtp_Date_ValueChanged(object sender, EventArgs e)
        {
            dtp_Date.Format = DateTimePickerFormat.Custom;
            dtp_Date.CustomFormat = "MMMM dd, yyyy";
            string date = dtp_Date.Value.ToString("MMMM dd, yyyy");


            if (CheckHoliday(date) == "Regular Holiday")
            {
                lblRegHol.Text = "Yes";
                lblSpecHol.Text = "No";

                lblRegHolHours.Text =
                    getRegularHours(
                    dtpScheduleInEdit.Text.ToString().ToUpper(),
                    schedule_out.ToUpper()
                );

                lblSpecHolHours.Text = "0.00";
            }
            else if (CheckHoliday(date) == "Special Non-Working Holiday")
            {
                lblRegHol.Text = "No";
                lblSpecHol.Text = "Yes";

                lblSpecHolHours.Text =
                    getRegularHours(
                    dtpScheduleInEdit.Text.ToString().ToUpper(),
                    schedule_out.ToUpper()
                );

                lblRegHolHours.Text = "0.00";
            }
            else if (CheckHoliday(date) == "Special Working Holiday")
            {
                lblRegHol.Text = "No";
                lblSpecHol.Text = "Yes";

                lblSpecHolHours.Text =
                    getRegularHours(
                    dtpScheduleInEdit.Text.ToString().ToUpper(),
                    schedule_out.ToUpper()
                );

                lblRegHolHours.Text = "0.00";
            }
            else
            {
                lblRegHol.Text = "No";
                lblSpecHol.Text = "No";
                lblRegHolHours.Text = "0.00";
                lblSpecHolHours.Text = "0.00";
            }
        }


        // ATTENDANCE DATA
        public string getLate(string schedIn, string schedOut, string timeIn)
        {
            TimeSpan start = TimeSpan.Parse(schedIn);
            TimeSpan end = TimeSpan.Parse(schedOut);
            TimeSpan time_in = TimeSpan.Parse(timeIn);


            if ((time_in > start) && (time_in < end))
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        public string getTotalHours(string timeIn, string timeOut)
        {
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Parse(timeOut).Subtract(DateTime.Parse(timeIn));

                   // 24 Hour format to decimal
            return Convert.ToDecimal(ts.TotalHours).ToString("#.00");
        }

        public string getRegularHours(string timeIn, string schedOut)
        {
            // BREAK HOURS NOT SUBTRACTED YET
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Parse(schedOut).Subtract(DateTime.Parse(timeIn));

            // 24 Hour format to decimal
            decimal reg_hours = Convert.ToDecimal(Convert.ToDecimal(ts.TotalHours).ToString("#.00"));

            if (reg_hours >= Convert.ToDecimal("08.00"))
            {
                reg_hours = Convert.ToDecimal("08.00");
            }

            return reg_hours.ToString();
        }

        public string getOverTimeHours(string schedOut, string timeOut)
        {
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Parse(timeOut).Subtract(DateTime.Parse(schedOut));

            // 24 Hour format to decimal
            decimal ot_hours = Convert.ToDecimal(Convert.ToDecimal(ts.TotalHours).ToString("#.00"));

            if (ot_hours >= Convert.ToDecimal("04.00"))
            {
                ot_hours = Convert.ToDecimal("04.00");

                if (ot_hours < Convert.ToDecimal("0.00"))
                {
                    ot_hours = Convert.ToDecimal("0.00");
                }
            }

            return ot_hours.ToString();
        }

        public string CheckHoliday(string date)
        {
            date = date.Substring(0, date.Length - 6);
            string query2 = "SELECT Type_ FROM Holidays WHERE From_ ='" + date + "'";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetString(0);
                    }
                    else
                    {
                        return "None";
                    }
                }
            }
        }

        public string getUndertimeHours(string schedOut, string timeOut)
        {
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Parse(schedOut).Subtract(DateTime.Parse(timeOut));

            // 24 Hour format to decimal
            decimal u_hours = Convert.ToDecimal(Convert.ToDecimal(ts.TotalHours).ToString("#.00"));

            return u_hours.ToString();
        }

        public void Update()
        {
            DateTime sched_in_24 = DateTime.Parse(schedule_in);
            DateTime sched_out_24 = DateTime.Parse(schedule_out);
            DateTime time_in_24 = DateTime.Parse(dtpScheduleInEdit.Text.ToString().ToUpper());

            lblLate.Text =
                getLate(
                    sched_in_24.ToString("HH:mm"),
                    sched_out_24.ToString("HH:mm"),
                    time_in_24.ToString("HH:mm")
                );

            lblTotalHours.Text =
                getTotalHours(
                    dtpScheduleInEdit.Text.ToString().ToUpper(),
                    dtpSchedOutEdit.Text.ToString().ToUpper()
                );

            lblRegHours.Text =
                getRegularHours(
                    dtpScheduleInEdit.Text.ToString().ToUpper(),
                    schedule_out.ToUpper()
                );

            lblOTHours.Text =
                getOverTimeHours(
                    schedule_out,
                    dtpSchedOutEdit.Text.ToString().ToUpper()
                );

            lblUndertimeHours.Text =
                getUndertimeHours(
                    schedule_out,
                    dtpSchedOutEdit.Text.ToString().ToUpper()
                );

            if (lblOTHours.Text.Contains("-"))
            {
                lblOTHours.Text = "0.00";
            }

            if (lblUndertimeHours.Text.Contains("-"))
            {
                lblUndertimeHours.Text = "0.00";
            }

            dtp_Date.Format = DateTimePickerFormat.Custom;
            dtp_Date.CustomFormat = "MMMM dd, yyyy";
            string date = dtp_Date.Value.ToString("MMMM dd, yyyy");


            if (CheckHoliday(date) == "Regular Holiday")
            {
                lblRegHol.Text = "Yes";
                lblSpecHol.Text = "No";

                lblRegHolHours.Text =
                    getRegularHours(
                    dtpScheduleInEdit.Text.ToString().ToUpper(),
                    schedule_out.ToUpper()
                );

                lblSpecHolHours.Text = "0.00";
            }
            else if (CheckHoliday(date) == "Special Non-Working Holiday")
            {
                lblRegHol.Text = "No";
                lblSpecHol.Text = "Yes";

                lblSpecHolHours.Text =
                    getRegularHours(
                    dtpScheduleInEdit.Text.ToString().ToUpper(),
                    schedule_out.ToUpper()
                );

                lblRegHolHours.Text = "0.00";
            }
            else if (CheckHoliday(date) == "Special Working Holiday")
            {
                lblRegHol.Text = "No";
                lblSpecHol.Text = "Yes";

                lblSpecHolHours.Text =
                    getRegularHours(
                    dtpScheduleInEdit.Text.ToString().ToUpper(),
                    schedule_out.ToUpper()
                );

                lblRegHolHours.Text = "0.00";
            }
            else
            {
                lblRegHol.Text = "No";
                lblSpecHol.Text = "No";
                lblRegHolHours.Text = "0.00";
                lblSpecHolHours.Text = "0.00";
            }
        }

        public Int64 getPositionID(string employee_id)
        {
            string query2 = "SELECT PositionID FROM EmployeeInfo WHERE EmployeeID=" + employee_id;
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetInt64(0);
                    }
                    else
                    {
                        return 0;
                    }

                }
            }
        }

        public int yntoboolean(string yn)
        {
            if (yn == "Yes")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string sDate = dtp_Date.Text.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            string dy = datevalue.Day.ToString();
            string mn = datevalue.Month.ToString();
            string yy = datevalue.Year.ToString();

            string aid = yy + mn + dy + employee_id;

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "INSERT INTO AttendanceSheet(" +
                    "AttendanceID," +
                    "EmployeeID," +
                    "TimeIn," +
                    "TimeOut," +
                    "Date," +
                    "TotalHours," +
                    "RegularHours," +
                    "OvertimeHours," +
                    "Late," +
                    "RegularHoliday," +
                    "SpecialHoliday," +
                    "RegularHolidayHours," +
                    "SpecialHolidayHours," +
                    "UndertimeHours," +
                    "PositionID) " +
                    "VALUES (" +
                    "@AttendanceID," +
                    "@EmployeeID," +
                    "@TimeIn," +
                    "@TimeOut," +
                    "@Date," +
                    "@TotalHours," +
                    "@RegularHours," +
                    "@OvertimeHours," +
                    "@Late," +
                    "@RegularHoliday," +
                    "@SpecialHoliday," +
                    "@RegularHolidayHours," +
                    "@SpecialHolidayHours," +
                    "@UndertimeHours," +
                    "@PositionID) ";

                string schedIn = dtpScheduleInEdit.Value.ToString("hh:mm:ss tt");
                string schedOut = dtpSchedOutEdit.Value.ToString("hh:mm:ss tt");

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@AttendanceID", Convert.ToInt64(aid));
                cmd.Parameters.AddWithValue("@EmployeeID", Convert.ToInt64(employee_id));
                cmd.Parameters.AddWithValue("@TimeIn", schedIn);
                cmd.Parameters.AddWithValue("@TimeOut", schedOut);
                cmd.Parameters.AddWithValue("@Date", dtp_Date.Text.ToString());
                cmd.Parameters.AddWithValue("@TotalHours", Convert.ToDecimal(lblTotalHours.Text.ToString()));
                cmd.Parameters.AddWithValue("@RegularHours", Convert.ToDecimal(lblRegHours.Text.ToString()));
                cmd.Parameters.AddWithValue("@Overtimehours", Convert.ToDecimal(lblOTHours.Text.ToString()));
                cmd.Parameters.AddWithValue("@Late", yntoboolean(lblLate.Text.ToString()));
                cmd.Parameters.AddWithValue("@RegularHoliday", yntoboolean(lblRegHol.Text.ToString()));
                cmd.Parameters.AddWithValue("@SpecialHoliday", yntoboolean(lblSpecHol.Text.ToString()));
                cmd.Parameters.AddWithValue("@RegularHolidayHours", Convert.ToDecimal(lblRegHolHours.Text.ToString()));
                cmd.Parameters.AddWithValue("@SpecialHolidayHours", Convert.ToDecimal(lblSpecHolHours.Text.ToString()));
                cmd.Parameters.AddWithValue("@UndertimeHours", Convert.ToDecimal(lblUndertimeHours.Text.ToString()));
                cmd.Parameters.AddWithValue("@PositionID", getPositionID(employee_id));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Attendance Added");
            }
        }

    }
}
