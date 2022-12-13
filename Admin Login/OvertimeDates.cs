using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Admin_Login
{
    public partial class OvertimeDates : Form
    {
        Login login = new Login();
        string selectedEmployee = " ";
        string selectedDept = " ";
        string selectedPos = " ";

        bool onTableEmp = true;
        bool onTableDept = false;
        bool onTablePos = false;

        public OvertimeDates()
        {
            InitializeComponent();
        }

        private void OvertimeDates_Load(object sender, EventArgs e)
        {
            dtpDateFrom.MaxDate = dtpDateTo.Value;

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
                    "WHERE Status='Active' AND " +
                    "((SELECT Manegerial FROM Position WHERE PositionID = (EmployeeInfo.PositionID)) = 0)";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                this.dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvEmployees.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvEmployees.DataSource = data;
                dgvEmployees.Columns["ScheduleID"].Visible = false;
                dgvEmployees.Columns["EmployeeID"].Visible = false;

                lblDetail.Text = "Employee ID:";
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (onTableEmp == true)
                {
                    selectedEmployee = dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();
                    lblSelectedFromDGV.Text = dgvEmployees.Rows[e.RowIndex].Cells[2].Value.ToString();
                    lblDetailContent.Text = selectedEmployee;
                }
                else if (onTableDept == true)
                {
                    selectedDept = dgvEmployees.Rows[e.RowIndex].Cells[0].Value.ToString();
                    lblSelectedFromDGV.Text = dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();
                    lblDetailContent.Text = selectedDept;
                }
                else if (onTablePos == true)
                {
                    selectedPos = dgvEmployees.Rows[e.RowIndex].Cells[0].Value.ToString();
                    lblSelectedFromDGV.Text = dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();
                    lblDetailContent.Text = selectedPos;
                }


                dtpDateFrom.Enabled = true;
                dtpDateTo.Enabled = true;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                // Do nothing
                // Column header click catcher
            }
        }

        private Int64 GetLatestOvertimeID()
        {
            string query2 =
                "SELECT MAX(OvertimeAppID) FROM Overtime";

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

        private bool GetManegerial(string emp_id)
        {
            string query = 
                "SELECT Manegerial " +
                "FROM Position " +
                "WHERE PositionID = " +
                "(SELECT EmployeeInfo.PositionID FROM EmployeeInfo WHERE EmployeeID = " + emp_id + ")";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
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

        private void InsertOvertime(string AppType)
        {
            string query =
                "INSERT INTO Overtime (StartDate, EndDate, ApplicationType) " +
                "VALUES (@StartDate, @EndDate, @ApplicationType)";

            using (SqlConnection conn = new SqlConnection(login.connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", dtpDateFrom.Text.ToString());
                cmd.Parameters.AddWithValue("@EndDate", dtpDateTo.Text.ToString());
                cmd.Parameters.AddWithValue("@ApplicationType", AppType);
                cmd.ExecuteNonQuery();
            }
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

            if (onTableEmp == true)
            {
                InsertOvertime(lblSelectedFromDGV.Text.ToString());
                foreach (DateTime day in EachDay(StartDate, EndDate))
                {
                    string ot_date = check_OT_Date(day.ToString("MMMM dd, yyyy"), selectedEmployee);

                    if (ot_date == day.ToString("MMMM dd, yyyy"))
                    {
                        MessageBox.Show("Employee; " + getEmployeeName(selectedEmployee) + " Already has a scheduled overtime on " +
                            day.ToString("MMMM dd, yyyy") + ", Duplicate date will not be added.");
                    }
                    else
                    {
                        using (SqlConnection connection = new SqlConnection(login.connectionString))
                        {
                            connection.Open();
                            string query =
                                "INSERT INTO OvertimeDates (" +
                                "EmployeeID," +
                                "Date," +
                                "OvertimeAppID) " +
                                "VALUES(" +
                                "@EmployeeID," +
                                "@Date," +
                                "@OvertimeAppID)";

                            SqlCommand command2 = new SqlCommand(query, connection);
                            command2.Parameters.AddWithValue("@EmployeeID", Convert.ToInt64(selectedEmployee));
                            command2.Parameters.AddWithValue("@Date", day.ToString("MMMM dd, yyyy"));
                            command2.Parameters.AddWithValue("@OvertimeAppID", GetLatestOvertimeID());
                            command2.ExecuteNonQuery();

                            //
                            //  ADD AUDIT
                            //
                            AuditTrail audit = new AuditTrail();
                            audit.AuditAddOverTime(
                                lblSelectedFromDGV.Text.ToString(),
                                dtpDateFrom.Text.ToString(),
                                dtpDateTo.Text.ToString());
                        }
                    }
                }
                MessageBox.Show("Overtime Dates added", "Overtime", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (onTableDept == true)
            {
                InsertOvertime(lblSelectedFromDGV.Text.ToString());
                bool duplicateDetect = false;

                string query2 = "SELECT EmployeeID FROM EmployeeInfo WHERE DepartmentID=" + selectedDept;

                using (SqlConnection connection = new SqlConnection(login.connectionString))
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int count = 0;
                            //Console.WriteLine(reader.GetInt64(count));

                            foreach (DateTime day in EachDay(StartDate, EndDate))
                            {
                                string ot_date = check_OT_Date(day.ToString("MMMM dd, yyyy"), reader.GetInt64(count).ToString());

                                if (ot_date == day.ToString("MMMM dd, yyyy"))
                                {
                                    duplicateDetect= true;
                                }
                                else
                                {
                                    if (CheckEmployeeStatus(reader.GetInt64(count)) == "Active")
                                    {
                                        Console.WriteLine(GetManegerial(reader.GetInt64(count).ToString()));
                                        if (!GetManegerial(reader.GetInt64(count).ToString()) == true)
                                        {
                                            using (SqlConnection connection2 = new SqlConnection(login.connectionString))
                                            {
                                                connection2.Open();
                                                string query =
                                                    "INSERT INTO OvertimeDates (" +
                                                    "EmployeeID," +
                                                    "Date," +
                                                    "OvertimeAppID) " +
                                                    "VALUES(" +
                                                    "@EmployeeID," +
                                                    "@Date," +
                                                    "@OvertimeAppID)";

                                                SqlCommand command2 = new SqlCommand(query, connection2);
                                                command2.Parameters.AddWithValue("@EmployeeID", reader.GetInt64(count));
                                                command2.Parameters.AddWithValue("@Date", day.ToString("MMMM dd, yyyy"));
                                                command2.Parameters.AddWithValue("@OvertimeAppID", GetLatestOvertimeID());
                                                command2.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }
                            }
                            count++;
                        }
                        AuditTrail audit = new AuditTrail();
                        audit.AuditAddOverTime(
                                lblSelectedFromDGV.Text.ToString(),
                                dtpDateFrom.Text.ToString(),
                                dtpDateTo.Text.ToString());
                    }
                }
                if (duplicateDetect == true)
                {
                    MessageBox.Show("There were duplicate dates on selected dates, duplicate dates were not added.", 
                        "Duplicate Dates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MessageBox.Show("Overtime Dates added", "Overtime", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (onTablePos == true)
            {
                InsertOvertime(lblSelectedFromDGV.Text.ToString());
                bool duplicateDetect = false;

                string query2 = "SELECT EmployeeID FROM EmployeeInfo WHERE PositionID=" + selectedPos;

                using (SqlConnection connection = new SqlConnection(login.connectionString))
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int count = 0;
                            Console.WriteLine(reader.GetInt64(count));

                            foreach (DateTime day in EachDay(StartDate, EndDate))
                            {
                                string ot_date = check_OT_Date(day.ToString("MMMM dd, yyyy"), reader.GetInt64(count).ToString());

                                if (ot_date == day.ToString("MMMM dd, yyyy"))
                                {
                                    duplicateDetect= true;
                                }
                                else
                                {
                                    if (CheckEmployeeStatus(reader.GetInt64(count)) == "Active")
                                    {
                                        using (SqlConnection connection2 = new SqlConnection(login.connectionString))
                                        {
                                            connection2.Open();
                                            string query =
                                                "INSERT INTO OvertimeDates (" +
                                                "EmployeeID," +
                                                "Date," +
                                                "OvertimeAppID) " +
                                                "VALUES(" +
                                                "@EmployeeID," +
                                                "@Date," +
                                                "@OvertimeAppID)";

                                            SqlCommand command2 = new SqlCommand(query, connection2);
                                            command2.Parameters.AddWithValue("@EmployeeID", reader.GetInt64(count));
                                            command2.Parameters.AddWithValue("@Date", day.ToString("MMMM dd, yyyy"));
                                            command2.Parameters.AddWithValue("@OvertimeAppID", GetLatestOvertimeID());
                                            command2.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            count++;
                        }
                        AuditTrail audit = new AuditTrail();
                        audit.AuditAddOverTime(
                                lblSelectedFromDGV.Text.ToString(),
                                dtpDateFrom.Text.ToString(),
                                dtpDateTo.Text.ToString());
                    }
                }
                if (duplicateDetect == true)
                {
                    MessageBox.Show("There were duplicate dates on selected dates, duplicate dates were not added.",
                        "Duplicate Dates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MessageBox.Show("Overtime Dates added", "Overtime", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string CheckEmployeeStatus(Int64 emp_id)
        {
            string query2 =
                "SELECT Status FROM EmployeeInfo WHERE EmployeeID=" + emp_id.ToString();

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

        private void clickViewEmployeesDGV(object sender, EventArgs e)
        {
            onTableEmp = true;
            onTableDept= false;
            onTablePos= false;

            this.ActiveControl = null;

            tb_Search.Text = "Search for employee name";
            lblDetail.Text = "Employee ID:";
            lblDetailContent.Text = "---";

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
                    "WHERE Status='Active' AND " +
                    "((SELECT Manegerial FROM Position WHERE PositionID = (EmployeeInfo.PositionID)) = 0)";

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

        private void clickViewDeptDGV(object sender, EventArgs e)
        {
            onTableEmp = false;
            onTableDept = true;
            onTablePos = false;

            this.ActiveControl = null;

            tb_Search.Text = "Search for department name";
            lblDetail.Text = "Dept. ID: ";
            lblDetailContent.Text = "---";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT * FROM Department";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                this.dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvEmployees.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvEmployees.DataSource = data;
                dgvEmployees.Columns["DepartmentID"].Visible = false;
            }
        }

        private void clickViewPosDGV(object sender, EventArgs e)
        {
            onTableEmp = false;
            onTableDept = false;
            onTablePos = true;

            this.ActiveControl = null;

            tb_Search.Text = "Search for position name";
            lblDetail.Text = "Position: ";
            lblDetailContent.Text = "---";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT PositionID, PositionName FROM Position WHERE Custom = 0 AND Manegerial = 0";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                this.dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvEmployees.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvEmployees.DataSource = data;
                dgvEmployees.Columns["PositionID"].Visible = false;
            }
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpDateFrom.MaxDate = dtpDateTo.Value;
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            dtpDateFrom.MaxDate = dtpDateTo.Value;
        }

        public string check_OT_Date(string date, string employee_id)
        {
            string query2 =
                "SELECT Date FROM OvertimeDates WHERE Date='" + date + "' AND EmployeeID=" + employee_id;

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

        public string getEmployeeName(string employee_id)
        {
            string query2 =
                "SELECT EmployeeFullName FROM EmployeeInfo WHERE EmployeeID=" + employee_id;

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

        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            if (onTableEmp == true)
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
                        "EmployeeInfo.EmployeeFullName like '%" + tb_Search.Text + "%' ";
                        
                        SqlCommand cmd = new SqlCommand(query2, connection);
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sqlDataAdapter.Fill(dt);
                        dgvEmployees.DataSource = dt;
                    }
                }
            }
            else if (onTableDept == true)
            {
                using (SqlConnection conn = new SqlConnection(login.connectionString))
                {
                    if (string.IsNullOrEmpty(tb_Search.Text))
                    {
                        string query =
                        "SELECT * FROM Department";

                        SqlCommand cmd2 = new SqlCommand(query, conn);
                        SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        sqlDataAdapter2.Fill(dt2);
                        dgvEmployees.DataSource = dt2;
                        dgvEmployees.Columns["DepartmentID"].Visible = false;
                    }
                    else if (tb_Search.Focused)
                    {
                        string query =
                        "SELECT * FROM Department " +
                        "WHERE DepartmentName LIKE '%" + tb_Search.Text + "%'";

                        SqlCommand cmd2 = new SqlCommand(query, conn);
                        SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        sqlDataAdapter2.Fill(dt2);
                        dgvEmployees.DataSource = dt2;
                        dgvEmployees.Columns["DepartmentID"].Visible = false;
                    }
                }
            }
            else if (onTablePos == true)
            {
                using (SqlConnection conn = new SqlConnection(login.connectionString))
                {
                    if (string.IsNullOrEmpty(tb_Search.Text))
                    {
                        string query =
                        "SELECT PositionID, PositionName FROM Position WHERE Custom=0";

                        SqlCommand cmd2 = new SqlCommand(query, conn);
                        SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        sqlDataAdapter2.Fill(dt2);
                        dgvEmployees.DataSource = dt2;
                        dgvEmployees.Columns["PositionID"].Visible = false;
                    }
                    else if (tb_Search.Focused)
                    {
                        string query =
                        "SELECT PositionID, PositionName FROM Position WHERE Custom=0 " +
                        "AND PositionName LIKE '%" + tb_Search.Text + "%'";

                        SqlCommand cmd2 = new SqlCommand(query, conn);
                        SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                        DataTable dt2 = new DataTable();
                        sqlDataAdapter2.Fill(dt2);
                        dgvEmployees.DataSource = dt2;
                        dgvEmployees.Columns["PositionID"].Visible = false;
                    }
                }
            }
        }

        private void tb_Search_Click(object sender, EventArgs e)
        {
            tb_Search.Text = null;
        }

        private void ViewAppliedOvertimes(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Applied Overtimes";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }
    }
}
