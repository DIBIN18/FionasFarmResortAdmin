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
using System.Threading;

namespace Admin_Login
{
    public partial class AddAttendance : Form
    {
        Login login = new Login();
        string employee_id = "", schedule_in = "", schedule_out = "";
        string EDIT_employee_id = "", EDIT_time_in = "", EDIT_time_out = "", Attendance_ID = "";

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
            //Load Add Attendance DGV
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
            dtpScheduleInEdit.Enabled = true;
            dtpSchedOutEdit.Enabled = true;
            dtp_Date.Enabled = true;

            employee_id = dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();
            lblEmployeeName.Text = dgvEmployees.Rows[e.RowIndex].Cells[2].Value.ToString();
            schedule_in = dgvEmployees.Rows[e.RowIndex].Cells[3].Value.ToString();
            schedule_out = dgvEmployees.Rows[e.RowIndex].Cells[4].Value.ToString();
            lblBreakPeriod.Text = getEmployeeBreakTime(employee_id);
            
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
                    dtpSchedOutEdit.Text.ToString().ToUpper()
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
                    dtpSchedOutEdit.Text.ToString().ToUpper()
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
                    dtpSchedOutEdit.Text.ToString().ToUpper()
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
        // add weekdays allowed constraints
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

        public int getMinutesLate(string schedIn, string timeIn)
        {
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Parse(timeIn).Subtract(DateTime.Parse(schedIn));

            int mins_late = Convert.ToInt32(ts.TotalMinutes);

            if (mins_late > 480)
            {
                mins_late = 480;
            }

            return mins_late;
        }

        public string getTotalHours(string timeIn, string timeOut)
        {
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Parse(timeOut).Subtract(DateTime.Parse(timeIn));

                   // 24 Hour format to decimal
            return Convert.ToDecimal(ts.TotalHours).ToString("#.000");
        }

        public string getRegularHours(string timeIn, string timeOut)
        {
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Parse(timeOut).Subtract(DateTime.Parse(timeIn));

            // 24 Hour format to decimal
            decimal reg_hours = Convert.ToDecimal(Convert.ToDecimal(ts.TotalHours).ToString("#.000"));

            // Trigger Employee Break
            string break_time = getEmployeeBreakTime(employee_id);

            DateTime gtimein = DateTime.ParseExact(timeIn,
                                    "hh:mm:ss tt", CultureInfo.InvariantCulture);
            TimeSpan Btimein = gtimein.TimeOfDay;

            DateTime gsout = DateTime.ParseExact(timeOut,
                                    "hh:mm:ss tt", CultureInfo.InvariantCulture);
            TimeSpan Bsout = gsout.TimeOfDay;

            DateTime gBreak = DateTime.ParseExact(break_time,
                                    "hh:mm:ss tt", CultureInfo.InvariantCulture);
            TimeSpan bBreak = gBreak.TimeOfDay;

            if ((bBreak > Btimein) && (bBreak < Bsout))
            {
                reg_hours = reg_hours - 1.00m;
            }

            // Limit Regular Hours to 8.00
            decimal max_reg_hours = 08.00m;

            if (reg_hours >= max_reg_hours)
            {
                reg_hours = Convert.ToDecimal("08.00");
            }

            return reg_hours.ToString();
        }

        public string getEmployeeBreakTime(string employee_id)
        {
            string query2 = "SELECT BreakPeriod FROM EmployeeSchedule WHERE EmployeeID=" + employee_id;
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
                        return "";
                    }

                }
            }
        }

        public string getOverTimeHours(string schedOut, string timeOut)
        {
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Parse(timeOut).Subtract(DateTime.Parse(schedOut));

            // 24 Hour format to decimal
            decimal ot_hours = Convert.ToDecimal(Convert.ToDecimal(ts.TotalHours).ToString("#.000"));

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

        public string getUndertimeHours(string schedOut, string timeOut)
        {
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Parse(schedOut).Subtract(DateTime.Parse(timeOut));

            // 24 Hour format to decimal
            decimal u_hours = Convert.ToDecimal(Convert.ToDecimal(ts.TotalHours).ToString("#.000"));

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
                    dtpSchedOutEdit.Text.ToString().ToUpper()
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
                    dtpSchedOutEdit.Text.ToString().ToUpper()
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
                    dtpSchedOutEdit.Text.ToString().ToUpper()
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
                    dtpSchedOutEdit.Text.ToString().ToUpper()
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

        public decimal getBasicRate(string employee_id)
        {
            string query2 = 
                "SELECT BasicRate FROM Position " +
                "WHERE PositionID = " +
                "(SELECT PositionID " +
                "FROM EmployeeInfo " +
                "WHERE EmployeeID=" + employee_id + ")";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetDecimal(0);
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

            DateTime sched_in_24 = DateTime.Parse(schedule_in);
            DateTime time_in_24 = DateTime.Parse(dtpScheduleInEdit.Text.ToString().ToUpper());

            int minutes_late = getMinutesLate(sched_in_24.ToString("HH:mm"), time_in_24.ToString("HH:mm"));
            decimal RateLoss = (getBasicRate(employee_id) / 60.00m) * getMinutesLate(sched_in_24.ToString("HH:mm"), time_in_24.ToString("HH:mm"));

            string dy = datevalue.Day.ToString();
            string mn = datevalue.Month.ToString();
            string yy = datevalue.Year.ToString();

            string aid = yy + mn + dy + employee_id;

            if (CheckLeave(dtp_Date.Text.ToString(), employee_id) == false)
            {
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
                        "PositionID," +
                        "MinutesLate," +
                        "MinuteRateLoss) " +
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
                        "@PositionID," +
                        "@MinutesLate," +
                        "@MinuteRateLoss) ";

                    string schedIn = dtpScheduleInEdit.Value.ToString("hh:mm:ss tt");
                    string schedOut = dtpSchedOutEdit.Value.ToString("hh:mm:ss tt");

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@AttendanceID", Convert.ToInt64(aid));
                    cmd.Parameters.AddWithValue("@EmployeeID", Convert.ToInt64(employee_id));
                    cmd.Parameters.AddWithValue("@TimeIn", schedIn.ToUpper());
                    cmd.Parameters.AddWithValue("@TimeOut", schedOut.ToUpper());
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
                    cmd.Parameters.AddWithValue("@MinutesLate", minutes_late);
                    cmd.Parameters.AddWithValue("@MinuteRateLoss", RateLoss);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Attendance Added");
                }
            }
            else
            {
                MessageBox.Show("Employee is scheduled for a leave on the selected date, attendance will not be recorded");
            }
        }

        private void btnAddMode_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible= true;
            pnlEdit.Visible = false;
        }




        //
        //  EDITING MODE CODE
        //

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = false;
            pnlEdit.Visible = true;

            RefreshEditDgvTable();
        }

        public void RefreshEditDgvTable()
        {
            //Load Edit Attendance DGV
            dtpEditTimeIn.Format = DateTimePickerFormat.Time;
            dtpEditTimeIn.ShowUpDown = true;

            dtpEditTimeOut.Format = DateTimePickerFormat.Time;
            dtpEditTimeOut.ShowUpDown = true;

            dtpEditTimeIn.Format = DateTimePickerFormat.Custom;
            dtpEditTimeIn.CustomFormat = "hh:mm:ss tt";

            dtpEditTimeOut.Format = DateTimePickerFormat.Custom;
            dtpEditTimeOut.CustomFormat = "hh:mm:ss tt";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT " +
                    "AttendanceSheet.AttendanceID, " +
                    "EmployeeInfo.EmployeeID, " +
                    "EmployeeInfo.EmployeeFullName, " +
                    "AttendanceSheet.TimeIn, " +
                    "AttendanceSheet.TimeOut, " +
                    "AttendanceSheet.Date " +
                    "FROM AttendanceSheet " +
                    "INNER JOIN EmployeeInfo " +
                    "ON AttendanceSheet.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Status='Active'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                this.dgvEditAttendance.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvEditAttendance.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvEditAttendance.DataSource = data;
                dgvEditAttendance.Columns["AttendanceID"].Visible = false;
                dgvEditAttendance.Columns["EmployeeID"].Visible = false;
            }
        }

        private void btnBackEdit_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Attendance Record";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }

        private void dgvEditAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtpEditTimeIn.Enabled = true;
            dtpEditTimeOut.Enabled = true;
            dtpEditDate.Enabled = true;

            Attendance_ID = dgvEditAttendance.Rows[e.RowIndex].Cells[0].Value.ToString();
            EDIT_employee_id = dgvEditAttendance.Rows[e.RowIndex].Cells[1].Value.ToString();
            lblEditEmployeeName.Text = dgvEditAttendance.Rows[e.RowIndex].Cells[2].Value.ToString();
            EDIT_time_in = dgvEditAttendance.Rows[e.RowIndex].Cells[3].Value.ToString();
            EDIT_time_out = dgvEditAttendance.Rows[e.RowIndex].Cells[4].Value.ToString();
            lblEditBreakPeriod.Text = getEmployeeBreakTime(EDIT_employee_id);

            dtpEditTimeIn.Value = DateTime.Parse(dgvEditAttendance.Rows[e.RowIndex].Cells[3].Value.ToString());
            dtpEditTimeOut.Value = DateTime.Parse(dgvEditAttendance.Rows[e.RowIndex].Cells[4].Value.ToString());
            dtpEditDate.Value = DateTime.Parse(dgvEditAttendance.Rows[e.RowIndex].Cells[5].Value.ToString());
        }

        public string getRegularHoursEdit(string timeIn, string timeOut)
        {
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Parse(timeOut).Subtract(DateTime.Parse(timeIn));

            // 24 Hour format to decimal
            decimal reg_hours = Convert.ToDecimal(Convert.ToDecimal(ts.TotalHours).ToString("#.000"));

            // Trigger Employee Break
            string break_time = getEmployeeBreakTime(EDIT_employee_id);

            DateTime gtimein = DateTime.ParseExact(timeIn,
                                    "hh:mm:ss tt", CultureInfo.InvariantCulture);
            TimeSpan Btimein = gtimein.TimeOfDay;

            DateTime gsout = DateTime.ParseExact(timeOut,
                                    "hh:mm:ss tt", CultureInfo.InvariantCulture);
            TimeSpan Bsout = gsout.TimeOfDay;

            DateTime gBreak = DateTime.ParseExact(break_time,
                                    "hh:mm:ss tt", CultureInfo.InvariantCulture);
            TimeSpan bBreak = gBreak.TimeOfDay;

            if ((bBreak > Btimein) && (bBreak < Bsout))
            {
                reg_hours = reg_hours - 1.00m;
            }

            // Limit Regular Hours to 8.00
            decimal max_reg_hours = 08.00m;

            if (reg_hours >= max_reg_hours)
            {
                reg_hours = Convert.ToDecimal("08.00");
            }

            return reg_hours.ToString();
        }

        
        public void UpdateEditMode()
        {
            DateTime sched_in_24 = DateTime.Parse(EDIT_time_in);
            DateTime sched_out_24 = DateTime.Parse(EDIT_time_out);
            DateTime time_in_24 = DateTime.Parse(dtpEditTimeIn.Text.ToString().ToUpper());

            lblEditLate.Text =
                getLate(
                    sched_in_24.ToString("HH:mm"),
                    sched_out_24.ToString("HH:mm"),
                    time_in_24.ToString("HH:mm")
                );

            lblEditTotalHours.Text =
                getTotalHours(
                    dtpEditTimeIn.Text.ToString().ToUpper(),
                    dtpEditTimeOut.Text.ToString().ToUpper()
                );

            lblEditRegHours.Text =
                getRegularHoursEdit(
                    dtpEditTimeIn.Text.ToString().ToUpper(),
                    dtpEditTimeOut.Text.ToString().ToUpper()
                );

            lblEditOTHours.Text =
                getOverTimeHours(
                    EDIT_time_out,
                    dtpEditTimeOut.Text.ToString().ToUpper()
                );

            lblEditUndertimeHours.Text =
                getUndertimeHours(
                    EDIT_time_out,
                    dtpEditTimeOut.Text.ToString().ToUpper()
                );

            if (lblEditOTHours.Text.Contains("-"))
            {
                lblEditOTHours.Text = "0.00";
            }

            if (lblEditUndertimeHours.Text.Contains("-"))
            {
                lblEditUndertimeHours.Text = "0.00";
            }

            dtpEditDate.Format = DateTimePickerFormat.Custom;
            dtpEditDate.CustomFormat = "MMMM dd, yyyy";
            string date = dtpEditDate.Value.ToString("MMMM dd, yyyy");


            if (CheckHoliday(date) == "Regular Holiday")
            {
                lblEditRegHol.Text = "Yes";
                lblEditSpecHol.Text = "No";

                lblEditRegHolHours.Text =
                    getRegularHoursEdit(
                    dtpEditTimeIn.Text.ToString().ToUpper(),
                    dtpEditTimeOut.Text.ToString().ToUpper()
                );

                lblEditSpecHolHours.Text = "0.00";
            }
            else if (CheckHoliday(date) == "Special Non-Working Holiday")
            {
                lblEditRegHol.Text = "No";
                lblEditSpecHol.Text = "Yes";

                lblEditSpecHolHours.Text =
                    getRegularHoursEdit(
                    dtpEditTimeIn.Text.ToString().ToUpper(),
                    dtpEditTimeOut.Text.ToString().ToUpper()
                );

                lblEditRegHolHours.Text = "0.00";
            }
            else if (CheckHoliday(date) == "Special Working Holiday")
            {
                lblEditRegHol.Text = "No";
                lblEditSpecHol.Text = "Yes";

                lblEditSpecHolHours.Text =
                    getRegularHoursEdit(
                    dtpEditTimeIn.Text.ToString().ToUpper(),
                    dtpEditTimeOut.Text.ToString().ToUpper()
                );

                lblEditRegHolHours.Text = "0.00";
            }
            else
            {
                lblEditRegHol.Text = "No";
                lblEditSpecHol.Text = "No";
                lblEditRegHolHours.Text = "0.00";
                lblEditSpecHolHours.Text = "0.00";
            }
        }

        //
        //  DTP FUNCTIONS
        //

        private void dtpEditTimeIn_ValueChanged(object sender, EventArgs e)
        {
            UpdateEditMode();
        }

        private void dtpEditTimeOut_ValueChanged(object sender, EventArgs e)
        {
            UpdateEditMode();
        }

        private void dtpEditDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEditDate.Format = DateTimePickerFormat.Custom;
            dtpEditDate.CustomFormat = "MMMM dd, yyyy";
            string date = dtpEditDate.Value.ToString("MMMM dd, yyyy");

            if (CheckHoliday(date) == "Regular Holiday")
            {
                lblEditRegHol.Text = "Yes";
                lblEditSpecHol.Text = "No";

                lblEditRegHolHours.Text =
                    getRegularHoursEdit(
                    dtpEditTimeIn.Text.ToString().ToUpper(),
                    dtpEditTimeOut.Text.ToString().ToUpper()
                );

                lblEditSpecHolHours.Text = "0.00";
            }
            else if (CheckHoliday(date) == "Special Non-Working Holiday")
            {
                lblEditRegHol.Text = "No";
                lblEditSpecHol.Text = "Yes";

                lblEditSpecHolHours.Text =
                    getRegularHoursEdit(
                    dtpEditTimeIn.Text.ToString().ToUpper(),
                    dtpEditTimeOut.Text.ToString().ToUpper()
                );

                lblEditRegHolHours.Text = "0.00";
            }
            else if (CheckHoliday(date) == "Special Working Holiday")
            {
                lblEditRegHol.Text = "No";
                lblEditSpecHol.Text = "Yes";

                lblEditSpecHolHours.Text =
                    getRegularHoursEdit(
                    dtpEditTimeIn.Text.ToString().ToUpper(),
                    dtpEditTimeOut.Text.ToString().ToUpper()
                );

                lblEditRegHolHours.Text = "0.00";
            }
            else
            {
                lblEditRegHol.Text = "No";
                lblEditSpecHol.Text = "No";
                lblEditRegHolHours.Text = "0.00";
                lblEditSpecHolHours.Text = "0.00";
            }
        }

        private void btn_UpdateEdit_Click(object sender, EventArgs e)
        {
            string sDate = dtpEditDate.Text.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            string dy = datevalue.Day.ToString();
            string mn = datevalue.Month.ToString();
            string yy = datevalue.Year.ToString();

            string aid = yy + mn + dy + EDIT_employee_id;

            string schedIn = dtpEditTimeIn.Value.ToString("hh:mm:ss tt");
            string schedOut = dtpEditTimeOut.Value.ToString("hh:mm:ss tt");

            DateTime sched_in_24 = DateTime.Parse(EDIT_time_in);
            DateTime time_in_24 = DateTime.Parse(dtpEditTimeIn.Text.ToString().ToUpper());

            string minutes_late = getMinutesLate(sched_in_24.ToString("HH:mm"), time_in_24.ToString("HH:mm")).ToString();
            decimal RateLoss = (getBasicRate(EDIT_employee_id) / 60.00m) * getMinutesLate(sched_in_24.ToString("HH:mm"), time_in_24.ToString("HH:mm"));

            if(CheckLeave(dtpEditDate.Text.ToString(), EDIT_employee_id) == false)
            {
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();

                    string query =
                        "UPDATE AttendanceSheet " +
                        "SET " +
                        "AttendanceID= " + aid + ", " +
                        "EmployeeID= " + EDIT_employee_id + ", " +
                        "TimeIn= '" + schedIn.ToUpper() + "', " +
                        "TimeOut= '" + schedOut.ToUpper() + "', " +
                        "Date= '" + dtpEditDate.Text.ToString() + "', " +
                        "TotalHours= " + lblEditTotalHours.Text.ToString() + ", " +
                        "RegularHours= " + lblEditRegHours.Text.ToString() + ", " +
                        "OvertimeHours= " + lblEditOTHours.Text.ToString() + ", " +
                        "Late= " + yntoboolean(lblEditLate.Text.ToString()).ToString() + ", " +
                        "RegularHoliday= " + yntoboolean(lblEditRegHol.Text.ToString()).ToString() + ", " +
                        "SpecialHoliday= " + yntoboolean(lblEditSpecHol.Text.ToString()).ToString() + ", " +
                        "RegularHolidayHours= " + lblEditRegHolHours.Text.ToString() + ", " +
                        "SpecialHolidayHours= " + lblEditSpecHolHours.Text.ToString() + ", " +
                        "UndertimeHours= " + lblEditUndertimeHours.Text.ToString() + ", " +
                        "PositionID= " + getPositionID(EDIT_employee_id).ToString() + ", " +
                        "MinutesLate=" + minutes_late + ", " +
                        "MinuteRateLoss=" + RateLoss.ToString() + " " +
                        "WHERE AttendanceID=" + Attendance_ID;

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Attendance Record Successfully Updated");
                    RefreshEditDgvTable();
                }
            }
            else
            {
                MessageBox.Show("Employee is scheduled for a leave on the selected date, attendance will not be recorded");
            }
        }
    }
}
