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

        int grace_minutes = 0;
        bool grace_on = false;

        public AddAttendance()
        {
            InitializeComponent();
        }

        // Attendance Constaraints (not implemented yet)
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
            dtp_Date.MaxDate = DateTime.Now.Date;

            //Load Add Attendance DGV
            dtpTimeInAdd.Format = DateTimePickerFormat.Time;
            dtpTimeInAdd.ShowUpDown = true;

            dtpTimeOutAdd.Format = DateTimePickerFormat.Time;
            dtpTimeOutAdd.ShowUpDown = true;

            dtpTimeInAdd.Format = DateTimePickerFormat.Custom;
            dtpTimeInAdd.CustomFormat = "hh:mm:ss tt";

            dtpTimeOutAdd.Format = DateTimePickerFormat.Custom;
            dtpTimeOutAdd.CustomFormat = "hh:mm:ss tt";

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
            dtpTimeInAdd.Enabled = true;
            dtpTimeOutAdd.Enabled = true;
            dtp_Date.Enabled = true;
            cbAllowOT.Enabled= true;

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
            DateTime sched_in_24 = DateTime.Parse("08:00");
            DateTime sched_out_24 = DateTime.Parse("17:00");
            DateTime time_in_24 = DateTime.Parse(dtpTimeInAdd.Text.ToString().ToUpper());
            DateTime time_out_24 = DateTime.Parse(dtpTimeOutAdd.Text.ToString().ToUpper());

            dtp_Date.Format = DateTimePickerFormat.Custom;
            dtp_Date.CustomFormat = "MMMM dd, yyyy";
            string date = dtp_Date.Value.ToString("MMMM dd, yyyy");


            if (CheckHoliday(date) == "Regular Holiday")
            {
                lblRegH.Text = "Yes";
                lblSpecH.Text = "No";

                lblHours.Text =
                    GetHours(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lblSpecHHours.Text = "0";
                lblSpecHMins.Text = "0";
            }
            else if (CheckHoliday(date) == "Special Non-Working Holiday")
            {
                lblRegH.Text = "No";
                lblSpecH.Text = "Yes";

                lblSpecHHours.Text =
                        GetHours(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lblRegHHours.Text = "0";
                lblRegHMins.Text = "0";
            }
            else if (CheckHoliday(date) == "Special Working Holiday")
            {
                lblRegH.Text = "No";
                lblSpecH.Text = "Yes";

                lblSpecHHours.Text =
                        GetHours(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lblRegHHours.Text = "0";
                lblRegHMins.Text = "0";
            }
            else
            {
                lblRegH.Text = "No";
                lblSpecH.Text = "No";
                lblRegHHours.Text = "0";
                lblRegHMins.Text = "0";
                lblSpecHHours.Text = "0";
                lblSpecHMins.Text = "0";
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

            if (mins_late < 0 || mins_late <= 10)
            {
                grace_minutes = mins_late;
                grace_on = true;
                mins_late= 0;
            }
            else
            {
                grace_on= false;
                grace_minutes = mins_late + 1;
            }

            return mins_late;
        }

        public int GetHours(string sched_in, string sched_out)
        {
            DateTime sched_in_24 = DateTime.Parse(sched_in);
            DateTime sched_out_24 = DateTime.Parse(sched_out);
            DateTime time_in_24 = DateTime.Parse(dtpTimeInAdd.Text.ToString().ToUpper());
            DateTime time_out_24 = DateTime.Parse(dtpTimeOutAdd.Text.ToString().ToUpper());

            // Trigger Employee Break
            string break_time = getEmployeeBreakTime(employee_id);

            DateTime gBreak = DateTime.ParseExact(break_time,
                                    "hh:mm:ss tt", CultureInfo.InvariantCulture);
            TimeSpan bBreak = gBreak.TimeOfDay;


            if (sched_in_24 > time_in_24 && sched_out_24 >= time_out_24)
            {
                Console.WriteLine("Trigger 1");
                // Early time in but not early time out
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);
                int hour = Convert.ToInt32(time.Hour);

                //if (grace_on == true)
                //{
                //    return 8;
                //}

                // Break time trigger
                if ((bBreak > time_in_24.TimeOfDay) && (bBreak < time_out_24.TimeOfDay))
                {
                    hour = hour - 1;
                }

                // 8 Hour Limiter
                if (hour > 8)
                {
                    hour = 8;
                }

                return hour;
            }
            else if (sched_in_24 < time_in_24 && sched_out_24 <= time_out_24)
            {
                Console.WriteLine("Trigger 2");
                // Late time in but not early time out
                string time_interval = (sched_out_24 - time_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);
                int hour = Convert.ToInt32(time.Hour);

                if (grace_on == true)
                {
                    return 8;
                }

                // Break time trigger
                if ((bBreak > time_in_24.TimeOfDay) && (bBreak < time_out_24.TimeOfDay))
                {
                    hour = hour - 1;
                }

                // 8 Hour Limiter
                if (hour > 8)
                {
                    hour = 8;
                }

                return hour;
            }
            else if (sched_out_24 > time_out_24 && sched_in_24 >= time_in_24)
            {
                Console.WriteLine("Trigger 3");
                // Early time out but not late
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);
                int hour = Convert.ToInt32(time.Hour);

                //if (grace_on == true)
                //{
                //    return 8;
                //}

                // Break time trigger
                if ((bBreak > time_in_24.TimeOfDay) && (bBreak < time_out_24.TimeOfDay))
                {
                    hour = hour - 1;
                }

                // 8 Hour limiter
                if (hour > 8)
                {
                    hour = 8;
                }

                return hour;
            }
            else if (sched_in_24 > time_in_24 || sched_out_24 > time_out_24)
            {
                Console.WriteLine("Trigger 4");
                // Late time in and early time out
                string time_interval = (time_out_24 - time_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);
                int hour = Convert.ToInt32(time.Hour);

                if (grace_on == true)
                {
                    if (hour > 8)
                    {
                        hour = 8;
                    }

                    return hour;
                }

                // Break time trigger
                if ((bBreak > time_in_24.TimeOfDay) && (bBreak < time_out_24.TimeOfDay))
                {
                    hour = hour - 1;
                }

                // 8 Hour limiter
                if (hour > 8)
                {
                    hour = 8;
                }

                return hour;
            }
            else if (sched_in_24 > time_in_24 && time_out_24 > sched_out_24)
            {
                Console.WriteLine("Trigger 5");
                // Early time in and late time out
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);
                int hour = Convert.ToInt32(time.Hour);

                if (grace_on == true)
                {
                    return 8;
                }

                // Break time trigger
                if ((bBreak > time_in_24.TimeOfDay) && (bBreak < time_out_24.TimeOfDay))
                {
                    hour = hour - 1;
                }

                // 8 Hour limiter
                if (hour > 8)
                {
                    hour = 8;
                }

                return hour;
            }
            else
            {
                Console.WriteLine("Trigger 6");
                // Time in and time out are okay, limiter can be triggered
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);
                int hour = Convert.ToInt32(time.Hour);

                if (grace_on == true)
                {
                    return 8;
                }

                // Break time trigger
                if ((bBreak > time_in_24.TimeOfDay) && (bBreak < time_out_24.TimeOfDay))
                {
                    hour = hour - 1;
                }

                // 8 Hour limiter
                if (hour > 8)
                {
                    hour = 8;
                }

                return hour;
            }
        }

        public int GetMinutes(string sched_in, string sched_out)
        {
            DateTime sched_in_24 = DateTime.Parse(sched_in);
            DateTime sched_out_24 = DateTime.Parse(sched_out);
            DateTime time_in_24 = DateTime.Parse(dtpTimeInAdd.Text.ToString().ToUpper());
            DateTime time_out_24 = DateTime.Parse(dtpTimeOutAdd.Text.ToString().ToUpper());

            if (sched_in_24 > time_in_24 && sched_out_24 >= time_out_24)
            {
                // Early time in but not early time out
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);

                if (grace_minutes <= 10)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(time.Minute);
                }
            }
            else if (sched_in_24 < time_in_24 && sched_out_24 <= time_out_24)
            {
                // Late time in but not early time out
                string time_interval = (sched_out_24 - time_in_24).ToString();

                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);

                if (grace_minutes <= 10)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(time.Minute);
                }
            }
            else if (sched_out_24 > time_out_24 && sched_in_24 >= time_in_24)
            {
                // Early time out but not late
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);

                //if (grace_minutes <= 10)
                //{
                //    return 0;
                //}
                //else
                //{
                    
                //}
                return Convert.ToInt32(time.Minute);
            }
            else if (sched_in_24 > time_in_24 || sched_out_24 > time_out_24)
            {
                // Late time in and early time out
                string time_interval = (time_out_24 - time_in_24).ToString();

                DateTime time = DateTime.Parse(time_interval);

                if (grace_minutes <= 10)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(time.Minute);
                }
            }
            else if (sched_in_24 > time_in_24 && time_out_24 > sched_out_24)
            {
                // Early time in and late time out
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);

                if (grace_minutes <= 10)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(time.Minute);
                }
            }
            else
            {
                // Time in and time out are okay, limiter can be triggered
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);

                if (grace_minutes <= 10)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(time.Minute);
                }
            }
        }

        private void cbAllowOT_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllowOT.Checked)
            {
                Update();
            }
            else
            {
                lblOTHours.Text = "0";
            }
        }

        public string GetOTHours(string schedOut, string timeOut)
        {
            TimeSpan ts = new TimeSpan();
            ts = DateTime.Parse(timeOut).Subtract(DateTime.Parse(schedOut));

            // 24 Hour format to decimal
            int ot_hours = Convert.ToInt32(Convert.ToInt32(ts.Hours));

            if (ot_hours >= Convert.ToInt32("4"))
            {
                ot_hours = Convert.ToInt32("4");

                if (ot_hours < Convert.ToInt32("0"))
                {
                    ot_hours = Convert.ToInt32("0");
                }
            }

            if (ot_hours < 0)
            {
                ot_hours= 0;
            }

            return ot_hours.ToString();
        }

        public int GetUndertimeHours(string schedOut)
        {
            DateTime sched_out_24 = DateTime.Parse(schedOut);
            DateTime time_out_24 = DateTime.Parse(dtpTimeOutAdd.Text.ToString().ToUpper());

            string time_interval = (sched_out_24 - time_out_24).ToString();

            // Outside of schedule time in/out buffer
            if (time_interval.Contains("-"))
            {
                return 0;
            }

            DateTime time = DateTime.Parse(time_interval);

            return Convert.ToInt32(time.Hour);
        }

        public int GetUndertimeMinutes(string schedOut)
        {
            DateTime sched_out_24 = DateTime.Parse(schedOut);
            DateTime time_out_24 = DateTime.Parse(dtpTimeOutAdd.Text.ToString().ToUpper());

            string time_interval = (sched_out_24 - time_out_24).ToString();

            // Outside of schedule time in/out buffer
            if (time_interval.Contains("-"))
            {
                return 0;
            }

            DateTime time = DateTime.Parse(time_interval);

            return Convert.ToInt32(time.Minute);
        }

        public string getEmployeeBreakTime(string emp_id)
        {
            string query2 = "SELECT BreakPeriod FROM EmployeeSchedule WHERE EmployeeID=" + emp_id;

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();

                try
                {
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
                catch (Exception e)
                {
                    return "12:00:00 AM";
                }
            }
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

        public void Update()
        {
            DateTime sched_in_24 = DateTime.Parse(schedule_in);
            DateTime sched_out_24 = DateTime.Parse(schedule_out);
            DateTime time_in_24 = DateTime.Parse(dtpTimeInAdd.Text.ToString().ToUpper());
            DateTime time_out_24 = DateTime.Parse(dtpTimeOutAdd.Text.ToString().ToUpper());

            dtp_Date.Format = DateTimePickerFormat.Custom;
            dtp_Date.CustomFormat = "MMMM dd, yyyy";
            string date = dtp_Date.Value.ToString("MMMM dd, yyyy");


            lblMinsLate.Text =
                getMinutesLate(
                    sched_in_24.ToString("HH:mm"),
                    time_in_24.ToString("HH:mm")
                ).ToString();

            lblHours.Text =
                GetHours(
                    sched_in_24.ToString("HH:mm"),
                    sched_out_24.ToString("HH:mm")
                ).ToString();

            lblMins.Text =
                GetMinutes(
                    sched_in_24.ToString("HH:mm"),
                    sched_out_24.ToString("HH:mm")
                ).ToString();

            if (cbAllowOT.Checked)
            {
                lblOTHours.Text =
                GetOTHours(
                    schedule_out,
                    dtpTimeOutAdd.Text.ToString().ToUpper()
                ).ToString();
            }

            lblUhours.Text =
                GetUndertimeHours(sched_out_24.ToString("HH:mm")).ToString();

            lblUmins.Text =
                GetUndertimeMinutes(sched_out_24.ToString("HH:mm")).ToString();



            if (CheckHoliday(date) == "Regular Holiday")
            {
                lblRegH.Text = "Yes";
                lblSpecH.Text = "No";

                lblRegHHours.Text = 
                    GetHours(sched_in_24.ToString("HH:mm"),sched_out_24.ToString("HH:mm")).ToString();

                lblRegHMins.Text =
                    GetMinutes(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lblSpecHHours.Text = "0";
                lblSpecHMins.Text = "0";
            }
            else if (CheckHoliday(date) == "Special Non-Working Holiday")
            {
                lblRegH.Text = "No";
                lblSpecH.Text = "Yes";

                lblSpecHHours.Text =
                        GetHours(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lblSpecHMins.Text =
                    GetMinutes(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lblRegHHours.Text = "0";
                lblRegHMins.Text = "0"; 
            }
            else if (CheckHoliday(date) == "Special Working Holiday")
            {
                lblRegH.Text = "No";
                lblSpecH.Text = "Yes";

                lblSpecHHours.Text =
                        GetHours(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lblSpecHMins.Text =
                    GetMinutes(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lblRegHHours.Text = "0";
                lblRegHMins.Text = "0";
            }
            else
            {
                lblRegH.Text = "No";
                lblSpecH.Text = "No";
                lblRegHHours.Text = "0";
                lblSpecHHours.Text = "0";
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

        private void Add_Click(object sender, EventArgs e)
        {
            string sDate = dtp_Date.Text.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            string dy = datevalue.Day.ToString();
            string mn = datevalue.Month.ToString();
            string yy = datevalue.Year.ToString();

            string aid = yy + mn + dy + employee_id;

            if (checkAllowedDay(employee_id) == true)
            {
                if (CheckLeave(dtp_Date.Text.ToString(), employee_id) == false)
                {
                    using (SqlConnection connection = new SqlConnection(login.connectionString))
                    {
                        connection.Open();
                        string query =
                            "INSERT INTO AttendanceRecord(" +
                            "AttendanceID," +
                            "EmployeeID," +
                            "PositionID," +
                            "Date," +
                            "TimeIn," +
                            "TimeOut," +
                            "Hours," +
                            "Minutes," +
                            "OT_Hours," +
                            "Late_Minutes," +
                            "Undertime_Hours," +
                            "Undertime_Minutes," +
                            "RegularHoliday," +
                            "RH_Hours," +
                            "RH_Minutes," +
                            "SpecialHoliday," +
                            "SH_Hours," +
                            "SH_Minutes)" +
                            "VALUES (" +
                            "@AttendanceID," +
                            "@EmployeeID," +
                            "@PositionID," +
                            "@Date," +
                            "@TimeIn," +
                            "@TimeOut," +
                            "@Hours," +
                            "@Minutes," +
                            "@OT_Hours," +
                            "@Late_Minutes," +
                            "@Undertime_Hours," +
                            "@Undertime_Minutes," +
                            "@RegularHoliday," +
                            "@RH_Hours," +
                            "@RH_Minutes," +
                            "@SpecialHoliday," +
                            "@SH_Hours," +
                            "@SH_Minutes) ";

                        string schedIn = dtpTimeInAdd.Value.ToString("hh:mm:ss tt");
                        string schedOut = dtpTimeOutAdd.Value.ToString("hh:mm:ss tt");

                        SqlCommand cmd = new SqlCommand(query, connection);

                        cmd.Parameters.AddWithValue("@AttendanceID", Convert.ToInt64(aid));
                        cmd.Parameters.AddWithValue("@EmployeeID", Convert.ToInt64(employee_id));
                        cmd.Parameters.AddWithValue("@PositionID", getPositionID(employee_id));
                        cmd.Parameters.AddWithValue("@Date", dtp_Date.Text.ToString());
                        cmd.Parameters.AddWithValue("@TimeIn", schedIn.ToUpper());
                        cmd.Parameters.AddWithValue("@TimeOut", schedOut.ToUpper());
                        cmd.Parameters.AddWithValue("@Hours", Convert.ToInt32(lblHours.Text.ToString()));
                        cmd.Parameters.AddWithValue("@Minutes", Convert.ToInt32(lblMins.Text.ToString()));
                        cmd.Parameters.AddWithValue("@OT_hours", Convert.ToInt32(lblOTHours.Text.ToString()));
                        cmd.Parameters.AddWithValue("@Late_Minutes", Convert.ToInt32(lblMinsLate.Text.ToString()));
                        cmd.Parameters.AddWithValue("@Undertime_Hours", Convert.ToInt32(lblUhours.Text.ToString()));
                        cmd.Parameters.AddWithValue("@Undertime_Minutes", Convert.ToInt32(lblUmins.Text.ToString()));
                        cmd.Parameters.AddWithValue("@RegularHoliday", yntoboolean(lblRegH.Text.ToString()));
                        cmd.Parameters.AddWithValue("@RH_Hours", Convert.ToInt32(lblRegHHours.Text.ToString()));
                        cmd.Parameters.AddWithValue("@RH_Minutes", Convert.ToInt32(lblRegHMins.Text.ToString()));
                        cmd.Parameters.AddWithValue("@SpecialHoliday", yntoboolean(lblSpecH.Text.ToString()));
                        cmd.Parameters.AddWithValue("@SH_Hours", Convert.ToInt32(lblSpecHHours.Text.ToString()));
                        cmd.Parameters.AddWithValue("@SH_Minutes", Convert.ToInt32(lblSpecHMins.Text.ToString()));

                        try
                        {
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Attendance Successfuly Added", "Attendance Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (System.Data.SqlClient.SqlException) {
                            MessageBox.Show("Employee already had an attendance on " + dtp_Date.Text.ToString() + 
                                " , Attendance will not be recorded", "Add Attendance Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        
                        SqlConnection auditcon = new SqlConnection(login.connectionString);
                        auditcon.Open();
                        //SqlCommand name = new SqlCommand("Select * from Users Where Username_ = '" + forAudit.Username + "'", auditcon);
                        //SqlDataAdapter sda = new SqlDataAdapter(name);
                        //DataTable dtaudit = new DataTable();
                        //sda.Fill(dtaudit);
                        //string auditName = dt.Rows[0][0].ToString();
                        string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                        string Module = "Attendance Record";
                        string Description = "Add Manual Attendance";
                        SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
                        auditcommand.Parameters.AddWithValue("@UserName_", "Sample");
                        auditcommand.Parameters.AddWithValue("@Date", auditDate);
                        auditcommand.Parameters.AddWithValue("@Module", Module);
                        auditcommand.Parameters.AddWithValue("@Description", Description);
                        auditcommand.ExecuteNonQuery();
                        auditcon.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Employee is scheduled for a leave on the selected date, attendance will not be recorded",
                        "Attendance Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DateTime weekday = Convert.ToDateTime(dtp_Date.Value.ToString());
                MessageBox.Show("Employee is not scheduled to time in on " + weekday.ToString("dddd") + "s, attendance will not be recorded",
                    "Add Attendnace Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }



        //
        // BUTTONS FOR EDIT AND ADD
        //
        private void btnAddMode_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = true;
            pnlEdit.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = false;
            pnlEdit.Visible = true;

            RefreshEditDgvTable();
        }



        //
        //  EDITING MODE CODE
        //
        public void RefreshEditDgvTable()
        {
            //Load Edit Attendance DGV
            dtpTimeInEdit.Format = DateTimePickerFormat.Time;
            dtpTimeInEdit.ShowUpDown = true;

            dtpTimeOutEdit.Format = DateTimePickerFormat.Time;
            dtpTimeOutEdit.ShowUpDown = true;

            dtpTimeInEdit.Format = DateTimePickerFormat.Custom;
            dtpTimeInEdit.CustomFormat = "hh:mm:ss tt";

            dtpTimeOutEdit.Format = DateTimePickerFormat.Custom;
            dtpTimeOutEdit.CustomFormat = "hh:mm:ss tt";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                dtpDgvDate.Format = DateTimePickerFormat.Custom;
                dtpDgvDate.CustomFormat = "MMMM dd, yyyy";
                string date = dtpDgvDate.Value.ToString("MMMM dd, yyyy");

                connection.Open();
                string query =
                    "SELECT " +
                    "AttendanceRecord.AttendanceID, " +
                    "EmployeeInfo.EmployeeID, " +
                    "EmployeeInfo.EmployeeFullName, " +
                    "AttendanceRecord.Date, " +
                    "AttendanceRecord.TimeIn, " +
                    "AttendanceRecord.TimeOut " +
                    "FROM AttendanceRecord " +
                    "INNER JOIN EmployeeInfo " +
                    "ON AttendanceRecord.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Date='" + date + "' " +
                    "ORDER BY Date";

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
            dtpTimeInEdit.Enabled = true;
            dtpTimeOutEdit.Enabled = true;
            dtp_EditDate.Enabled = true;
            cb_EditAllowOT.Enabled = true;   

            Attendance_ID = dgvEditAttendance.Rows[e.RowIndex].Cells[0].Value.ToString();
            EDIT_employee_id = dgvEditAttendance.Rows[e.RowIndex].Cells[1].Value.ToString();
            lbl_EditEmployeeName.Text = dgvEditAttendance.Rows[e.RowIndex].Cells[2].Value.ToString();
            EDIT_time_in = dgvEditAttendance.Rows[e.RowIndex].Cells[4].Value.ToString();
            EDIT_time_out = dgvEditAttendance.Rows[e.RowIndex].Cells[5].Value.ToString();
            lbl_EditBreakPeriod.Text = GetEmployeeBreakTimeEdit(EDIT_employee_id);

            dtpTimeInEdit.Value = DateTime.Parse(dgvEditAttendance.Rows[e.RowIndex].Cells[4].Value.ToString());

            string timeOut = dgvEditAttendance.Rows[e.RowIndex].Cells[5].Value.ToString();

            if (dgvEditAttendance.Rows[e.RowIndex].Cells[5].Value.ToString().Equals(""))
            {
                timeOut = "05:00:00 PM";
            }

            dtpTimeOutEdit.Value = DateTime.Parse(timeOut);
            dtp_EditDate.Value = DateTime.Parse(dgvEditAttendance.Rows[e.RowIndex].Cells[3].Value.ToString());

            UpdateEditMode();
        }

        private void cbEditAllowOT_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_EditAllowOT.Checked)
            {
                UpdateEditMode();
            }
            else
            {
                lbl_EditOTHours.Text = "0";
            }
        }


        // ADD Employee schedule here
        public string GetEmployeeSchedIn(string emp_id)
        {
            string query2 =
                "SELECT ScheduleIn FROM EmployeeSchedule " +
                "WHERE EmployeeID = " + emp_id;

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
                        return " ";
                    }
                }
            }
        }

        public string GetEmployeeSchedOut(string emp_id)
        {
            string query2 =
                "SELECT ScheduleOut FROM EmployeeSchedule " +
                "WHERE EmployeeID = " + emp_id;

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
                        return " ";
                    }
                }
            }
        }

        public string GetEmployeeBreakTimeEdit(string emp_id)
        {
            
            string query2 = "SELECT BreakPeriod FROM EmployeeSchedule WHERE EmployeeID=" + emp_id;

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


        // TIME VALUES EDIT MODE
        public int GetHoursEDIT(string sched_in, string sched_out)
        {
            DateTime sched_in_24 = DateTime.Parse(GetEmployeeSchedIn(EDIT_employee_id));
            DateTime sched_out_24 = DateTime.Parse(GetEmployeeSchedOut(EDIT_employee_id));
            DateTime time_in_24 = DateTime.Parse(dtpTimeInEdit.Text.ToString().ToUpper());
            DateTime time_out_24 = DateTime.Parse(dtpTimeOutEdit.Text.ToString().ToUpper());

            // Trigger Employee Break
            string break_time = GetEmployeeBreakTimeEdit(EDIT_employee_id);

            DateTime gBreak = DateTime.ParseExact(break_time,
                                    "hh:mm:ss tt", CultureInfo.InvariantCulture);
            TimeSpan bBreak = gBreak.TimeOfDay;


            if (sched_in_24 > time_in_24 && sched_out_24 >= time_out_24)
            {
                // Early time in but not early time out
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);
                int hour = Convert.ToInt32(time.Hour);

                //if (grace_on == true)
                //{
                //    return 8;
                //}

                // Break time trigger
                if ((bBreak > time_in_24.TimeOfDay) && (bBreak < time_out_24.TimeOfDay))
                {
                    hour = hour - 1;
                }

                // 8 Hour Limiter
                if (hour > 8)
                {
                    hour = 8;
                }

                return hour;
            }
            else if (sched_in_24 < time_in_24 && sched_out_24 <= time_out_24)
            {
                // Late time in but not early time out
                string time_interval = (sched_out_24 - time_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);
                int hour = Convert.ToInt32(time.Hour);

                if (grace_on == true)
                {
                    return 8;
                }

                // Break time trigger
                if ((bBreak > time_in_24.TimeOfDay) && (bBreak < time_out_24.TimeOfDay))
                {
                    hour = hour - 1;
                }

                // 8 Hour Limiter
                if (hour > 8)
                {
                    hour = 8;
                }

                return hour;
            }
            else if (sched_out_24 > time_out_24 && sched_in_24 >= time_in_24)
            {
                // Early time out but not late
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);
                int hour = Convert.ToInt32(time.Hour);

                //if (grace_on == true)
                //{
                //    return 8;
                //}

                // Break time trigger
                if ((bBreak > time_in_24.TimeOfDay) && (bBreak < time_out_24.TimeOfDay))
                {
                    hour = hour - 1;
                }

                // 8 Hour limiter
                if (hour > 8)
                {
                    hour = 8;
                }

                return hour;
            }
            else if (sched_in_24 > time_in_24 || sched_out_24 > time_out_24)
            {
                // Late time in and early time out
                string time_interval = (time_out_24 - time_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);
                int hour = Convert.ToInt32(time.Hour);

                if (grace_on == true)
                {
                    if (hour > 8)
                    {
                        hour = 8;
                    }

                    return hour;
                }

                // Break time trigger
                if ((bBreak > time_in_24.TimeOfDay) && (bBreak < time_out_24.TimeOfDay))
                {
                    hour = hour - 1;
                }

                // 8 Hour limiter
                if (hour > 8)
                {
                    hour = 8;
                }

                return hour;
            }
            else if (sched_in_24 > time_in_24 && time_out_24 > sched_out_24)
            {
                // Early time in and late time out
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);
                int hour = Convert.ToInt32(time.Hour);

                if (grace_on == true)
                {
                    return 8;
                }

                // Break time trigger
                if ((bBreak > time_in_24.TimeOfDay) && (bBreak < time_out_24.TimeOfDay))
                {
                    hour = hour - 1;
                }

                // 8 Hour limiter
                if (hour > 8)
                {
                    hour = 8;
                }

                return hour;
            }
            else
            {
                // Time in and time out are okay, limiter can be triggered
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);
                int hour = Convert.ToInt32(time.Hour);

                if (grace_on == true)
                {
                    return 8;
                }

                // Break time trigger
                if ((bBreak > time_in_24.TimeOfDay) && (bBreak < time_out_24.TimeOfDay))
                {
                    hour = hour - 1;
                }

                // 8 Hour limiter
                if (hour > 8)
                {
                    hour = 8;
                }

                return hour;
            }
        }

        public int GetMinutesEDIT(string sched_in, string sched_out)
        {
            DateTime sched_in_24 = DateTime.Parse(GetEmployeeSchedIn(EDIT_employee_id));
            DateTime sched_out_24 = DateTime.Parse(GetEmployeeSchedOut(EDIT_employee_id));
            DateTime time_in_24 = DateTime.Parse(dtpTimeInEdit.Text.ToString().ToUpper());
            DateTime time_out_24 = DateTime.Parse(dtpTimeOutEdit.Text.ToString().ToUpper());

            if (sched_in_24 > time_in_24 && sched_out_24 >= time_out_24)
            {
                // Early time in but not early time out
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);

                if (grace_minutes <= 10)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(time.Minute);
                }
            }
            else if (sched_in_24 < time_in_24 && sched_out_24 <= time_out_24)
            {
                // Late time in but not early time out
                string time_interval = (sched_out_24 - time_in_24).ToString();

                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);

                if (grace_minutes <= 10)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(time.Minute);
                }
            }
            else if (sched_out_24 > time_out_24 && sched_in_24 >= time_in_24)
            {
                // Early time out but not late
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);

                //if (grace_minutes <= 10)
                //{
                //    return 0;
                //}
                //else
                //{
                //    return Convert.ToInt32(time.Minute);
                //}
                return Convert.ToInt32(time.Minute);
            }
            else if (sched_in_24 > time_in_24 || sched_out_24 > time_out_24)
            {
                // Late time in and early time out
                string time_interval = (time_out_24 - time_in_24).ToString();

                DateTime time = DateTime.Parse(time_interval);

                if (grace_minutes <= 10)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(time.Minute);
                }
            }
            else if (sched_in_24 > time_in_24 && time_out_24 > sched_out_24)
            {
                // Early time in and late time out
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);

                if (grace_minutes <= 10)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(time.Minute);
                }
            }
            else
            {
                // Time in and time out are okay, limiter can be triggered
                string time_interval = (time_out_24 - sched_in_24).ToString();

                // Outside of schedule time in/out buffer
                if (time_interval.Contains("-"))
                {
                    return 0;
                }

                DateTime time = DateTime.Parse(time_interval);

                if (grace_minutes <= 10)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(time.Minute);
                }
            }
        }

        public int GetUndertimeHoursEDIT(string schedOut)
        {
            DateTime sched_out_24 = DateTime.Parse(schedOut);
            DateTime time_out_24 = DateTime.Parse(dtpTimeOutEdit.Text.ToString().ToUpper());

            string time_interval = (sched_out_24 - time_out_24).ToString();

            // Outside of schedule time in/out buffer
            if (time_interval.Contains("-"))
            {
                return 0;
            }

            DateTime time = DateTime.Parse(time_interval);

            return Convert.ToInt32(time.Hour);
        }

        public int GetUndertimeMinutesEDIT(string schedOut)
        {
            DateTime sched_out_24 = DateTime.Parse(schedOut);
            DateTime time_out_24 = DateTime.Parse(dtpTimeOutEdit.Text.ToString().ToUpper());

            string time_interval = (sched_out_24 - time_out_24).ToString();

            // Outside of schedule time in/out buffer
            if (time_interval.Contains("-"))
            {
                return 0;
            }

            DateTime time = DateTime.Parse(time_interval);

            return Convert.ToInt32(time.Minute);
        }
        

        public void UpdateEditMode()
        {
            // Time in from Python and Time out in C#
            if (EDIT_time_out.Equals(""))
            {
                EDIT_time_out = "05:00:00 PM";
            }


            DateTime sched_in_24 = DateTime.Parse(GetEmployeeSchedIn(EDIT_employee_id));
            DateTime sched_out_24 = DateTime.Parse(EDIT_time_out);
            DateTime time_in_24 = DateTime.Parse(dtpTimeInEdit.Text.ToString().ToUpper());

            dtp_EditDate.Format = DateTimePickerFormat.Custom;
            dtp_EditDate.CustomFormat = "MMMM dd, yyyy";
            string date = dtp_EditDate.Value.ToString("MMMM dd, yyyy");

            lbl_EditLateMinutes.Text =
                getMinutesLate(
                    sched_in_24.ToString("HH:mm"),
                    time_in_24.ToString("HH:mm")
                ).ToString();

            lbl_EditHours.Text =
                GetHoursEDIT(
                    sched_in_24.ToString("HH:mm"),
                    sched_out_24.ToString("HH:mm")
                ).ToString();

            lbl_EditMinutes.Text =
                GetMinutesEDIT(
                    sched_in_24.ToString("HH:mm"),
                    sched_out_24.ToString("HH:mm")
                ).ToString();

            if (cb_EditAllowOT.Checked)
            {
                lbl_EditOTHours.Text =
                GetOTHours(
                    GetEmployeeSchedOut(EDIT_employee_id),
                    dtpTimeOutEdit.Text.ToString().ToUpper()
                ).ToString();
            }

            lbl_EditUhours.Text =
                GetUndertimeHoursEDIT(sched_out_24.ToString("HH:mm")).ToString();

            lbl_EditUMins.Text =
                GetUndertimeMinutesEDIT(sched_out_24.ToString("HH:mm")).ToString();



            if (CheckHoliday(date) == "Regular Holiday")
            {
                lbl_EditRegH.Text = "Yes";
                lbl_EditSpecH.Text = "No";

                lbl_EditRegHHours.Text =
                    GetHoursEDIT(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lbl_EditRegHMins.Text =
                    GetMinutesEDIT(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lbl_EditSpecHHours.Text = "0";
                lbl_EditSpecHMins.Text = "0";
            }
            else if (CheckHoliday(date) == "Special Non-Working Holiday")
            {
                lbl_EditRegH.Text = "No";
                lbl_EditSpecH.Text = "Yes";

                lbl_EditSpecHHours.Text =
                    GetHoursEDIT(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lbl_EditSpecHMins.Text =
                    GetMinutesEDIT(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lbl_EditRegHHours.Text = "0";
                lbl_EditRegHMins.Text = "0";
            }
            else if (CheckHoliday(date) == "Special Working Holiday")
            {
                lbl_EditRegH.Text = "No";
                lbl_EditSpecH.Text = "Yes";

                lbl_EditSpecHHours.Text =
                    GetHoursEDIT(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lbl_EditSpecHMins.Text =
                    GetMinutesEDIT(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lbl_EditRegHHours.Text = "0";
                lbl_EditRegHMins.Text = "0";
            }
            else
            {
                lbl_EditRegH.Text = "No";
                lbl_EditSpecH.Text = "No";
                lbl_EditRegHHours.Text = "0";
                lbl_EditRegHMins.Text = "0";
                lbl_EditSpecHHours.Text = "0";
                lbl_EditSpecHMins.Text = "0";
            }
        }

        

        //
        //  DTP FUNCTIONS
        //

        private void dtpEditTimeIn_ValueChanged(object sender, EventArgs e)
        {
            UpdateEditMode();
        }

        private void dtpDgvDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshEditDgvTable();
        }

        private void dtpEditTimeOut_ValueChanged(object sender, EventArgs e)
        {
            UpdateEditMode();
        }

        private void dtpEditDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime sched_in_24 = DateTime.Parse(EDIT_time_in);
            DateTime sched_out_24 = DateTime.Parse(EDIT_time_out);
            DateTime time_in_24 = DateTime.Parse(dtpTimeInEdit.Text.ToString().ToUpper());

            dtp_EditDate.Format = DateTimePickerFormat.Custom;
            dtp_EditDate.CustomFormat = "MMMM dd, yyyy";
            string date = dtp_EditDate.Value.ToString("MMMM dd, yyyy");

            if (CheckHoliday(date) == "Regular Holiday")
            {
                lbl_EditRegH.Text = "Yes";
                lbl_EditSpecH.Text = "No";

                lbl_EditRegHHours.Text =
                    GetHoursEDIT(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lbl_EditRegHMins.Text =
                    GetMinutesEDIT(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lbl_EditSpecHHours.Text = "0";
                lbl_EditSpecHMins.Text = "0";
            }
            else if (CheckHoliday(date) == "Special Non-Working Holiday")
            {
                lbl_EditRegH.Text = "No";
                lbl_EditSpecH.Text = "Yes";

                lbl_EditSpecHHours.Text =
                    GetHoursEDIT(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lbl_EditSpecHMins.Text =
                    GetMinutesEDIT(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lbl_EditRegHHours.Text = "0";
                lbl_EditRegHMins.Text = "0";
            }
            else if (CheckHoliday(date) == "Special Working Holiday")
            {
                lbl_EditRegH.Text = "No";
                lbl_EditSpecH.Text = "Yes";

                lbl_EditSpecHHours.Text =
                    GetHoursEDIT(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lbl_EditSpecHMins.Text =
                    GetMinutesEDIT(sched_in_24.ToString("HH:mm"), sched_out_24.ToString("HH:mm")).ToString();

                lbl_EditRegHHours.Text = "0";
                lbl_EditRegHMins.Text = "0";
            }
            else
            {
                lbl_EditRegH.Text = "No";
                lbl_EditSpecH.Text = "No";
                lbl_EditRegHHours.Text = "0";
                lbl_EditRegHMins.Text = "0";
                lbl_EditSpecHHours.Text = "0";
                lbl_EditSpecHMins.Text = "0";
            }
        }

        private void btn_UpdateEdit_Click(object sender, EventArgs e)
        {
            string sDate = dtp_EditDate.Text.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            string dy = datevalue.Day.ToString();
            string mn = datevalue.Month.ToString();
            string yy = datevalue.Year.ToString();

            string aid = yy + mn + dy + EDIT_employee_id;

            string schedIn = dtpTimeInEdit.Value.ToString("hh:mm:ss tt");
            string schedOut = dtpTimeOutEdit.Value.ToString("hh:mm:ss tt");

            if (checkAllowedDay(EDIT_employee_id) == true)
            {
                if (CheckLeave(dtp_EditDate.Text.ToString(), EDIT_employee_id) == false)
                {
                    using (SqlConnection connection = new SqlConnection(login.connectionString))
                    {
                        connection.Open();

                        string query =
                            "UPDATE AttendanceRecord " +
                            "SET " +
                            "AttendanceID= " + aid + ", " +
                            "EmployeeID= " + EDIT_employee_id + ", " +
                            "PositionID= " + getPositionID(EDIT_employee_id) + ", " +
                            "Date= '" + dtp_EditDate.Text.ToString() + "', " +
                            "TimeIn= '" + schedIn.ToUpper() + "', " +
                            "TimeOut= '" + schedOut.ToUpper() + "', " +
                            "Hours= " + lbl_EditHours.Text.ToString() + ", " +
                            "Minutes= " + lbl_EditMinutes.Text.ToString() + ", " +
                            "OT_Hours= " + lbl_EditOTHours.Text.ToString() + ", " +
                            "Late_Minutes= " + lbl_EditLateMinutes.Text.ToString() + ", " +
                            "Undertime_Hours= " + lbl_EditUhours.Text.ToString() + ", " +
                            "Undertime_Minutes= " + lbl_EditUMins.Text.ToString() + ", " +
                            "RegularHoliday= " + yntoboolean(lbl_EditRegH.Text.ToString()).ToString() + ", " +
                            "RH_Hours= " + lbl_EditRegHHours.Text.ToString() + ", " +
                            "RH_Minutes= " + lbl_EditRegHMins.Text.ToString() + ", " +
                            "SpecialHoliday=" + yntoboolean(lbl_EditSpecH.Text.ToString()).ToString() + ", " +
                            "SH_Hours=" + lbl_EditSpecHHours.Text.ToString() + ", " +
                            "SH_Minutes=" + lbl_EditSpecHMins.Text.ToString() + " " +
                            "WHERE AttendanceID=" + Attendance_ID;

                        SqlCommand cmd = new SqlCommand(query, connection);

                        try
                        {
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Attendance Record Successfully Updated", "Attendance Record Edit",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshEditDgvTable();
                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                            MessageBox.Show("Employee already had an attendance on " + dtp_EditDate.Text.ToString() +
                                " , Attendance will not be recorded", "Add Attendance Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        SqlConnection auditcon = new SqlConnection(login.connectionString);
                        auditcon.Open();
                        //SqlCommand name = new SqlCommand("Select * from Users Where Username_ = '" + forAudit.Username + "'", auditcon);
                        //SqlDataAdapter sda = new SqlDataAdapter(name);
                        //DataTable dtaudit = new DataTable();
                        //sda.Fill(dtaudit);
                        //string auditName = dt.Rows[0][0].ToString();
                        string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                        string Module = "Attendance Record";
                        string Description = "Update AttendanceRecord";
                        SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
                        auditcommand.Parameters.AddWithValue("@UserName_", "Sample");
                        auditcommand.Parameters.AddWithValue("@Date", auditDate);
                        auditcommand.Parameters.AddWithValue("@Module", Module);
                        auditcommand.Parameters.AddWithValue("@Description", Description);
                        auditcommand.ExecuteNonQuery();
                        auditcon.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Employee is scheduled for a leave on the selected date, attendance will not be recorded",
                        "Employee on a Leave", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                DateTime weekday = Convert.ToDateTime(dtp_EditDate.Value.ToString());
                MessageBox.Show("Employee is not scheduled to time in on " + weekday.ToString("dddd") + "s, attendance will not be recorded");
            }
        }


        //
        //  SEARCH FUNCTIONS
        //
        private void tb_Search_Click(object sender, EventArgs e)
        {
            tb_Search.Text = null;
        }

        private void tb_Search_TextChanged_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                if (string.IsNullOrEmpty(tb_Search.Text))
                {
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

                    SqlCommand cmd2 = new SqlCommand(query, connection);
                    SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    sqlDataAdapter2.Fill(dt2);
                    dgvEmployees.DataSource = dt2;
                }
                else if (tb_Search.Focused)
                {
                    string query2 =
                    "SELECT " +
                    "EmployeeSchedule.ScheduleID, " +
                    "EmployeeInfo.EmployeeID, " +
                    "EmployeeInfo.EmployeeFullName, " +
                    "EmployeeSchedule.ScheduleIn, " +
                    "EmployeeSchedule.ScheduleOut " +
                    "FROM EmployeeSchedule " +
                    "INNER JOIN EmployeeInfo " +
                    "ON EmployeeSchedule.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Status='Active' AND " +
                    "EmployeeInfo.EmployeeFullName like '%" + tb_Search.Text + "%'" +
                    "OR EmployeeInfo.EmployeeID Like '" + tb_Search.Text + "%'";

                    SqlCommand cmd = new SqlCommand(query2, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dgvEmployees.DataSource = dt;
                }
            }
        }

    }
}
