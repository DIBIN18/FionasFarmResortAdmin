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
using System.Text.RegularExpressions;
using System.Globalization;

namespace Admin_Login
{
    public partial class Settings : Form
    {
        Login login = new Login();
        EditUser eu = new EditUser();

        string selectedUserId = "";

        public Settings()
        {
            InitializeComponent();
        }

        private void btnUsersClick(object sender, EventArgs e)
        {
            pnlUsers.Visible = true;
            pnlUtils.Visible = false;
            pnlAuditTrail.Visible = false;
        }

        public string getEmailSender()
        {
            string query2 = "SELECT Email FROM Sender";

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
                    return "";
                }
            }
        }

        public string getPasswordSender()
        {
            string query2 = "SELECT Pass FROM Sender";

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
                    return "";
                }
            }
        }

        private void btnUtilsClick(object sender, EventArgs e)
        {
            pnlUsers.Visible = false;
            pnlUtils.Visible = true;
            pnlAuditTrail.Visible = false;

            txtSenderEmail.Text= getEmailSender();
            txtSenderPass.Text= getPasswordSender();
        }

        private void btnAuditTrailClick(object sender, EventArgs e)
        {
            pnlUsers.Visible = false;
            pnlUtils.Visible = false;
            pnlAuditTrail.Visible = true;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            dgvUsers.ReadOnly = true;

            updateTable();

            cmbUserName.Items.Add("Human Resources");
            cmbUserName.Items.Add("Time Keeper");
            cmbUserName.Items.Add("Accountant");
            cmbUserName.Items.Add("Supervisor");
            cmbUserName.Items.Add("General Manager");

            SqlConnection connection = new SqlConnection(login.connectionString);

            SqlCommand cmd = new SqlCommand(
                "Select UserName_, Date, Module, Description from AuditTrail",
            connection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            dgvAuditTrail.DataSource = dt;

            // Column font
            this.dgvAuditTrail.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            // Row font
            this.dgvAuditTrail.DefaultCellStyle.Font = new Font("Century Gothic", 10);
        }

        public void updateTable()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = 
                    "SELECT " +
                    "UserID, " +
                    "User_, " +
                    "Username_," +
                    "EmployeeList," +
                    "Leave," +
                    "DepartmentPosition," +
                    "Deductions," +
                    "AttendanceRecord," +
                    "PayrollReport," +
                    "HolidaySetting," +
                    "Settings," +
                    "Schedules " +
                    "FROM Users";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                // Column font
                this.dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                // Row font
                this.dgvUsers.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvUsers.DataSource = data;
            }
        }

        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();

                var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                DateTime today = DateTime.Today;

                string query =
                    "BACKUP DATABASE FFRUsers " +
                    "TO DISK = '" + path + "\\Database Backups\\Created Backup - "+ 
                    today.ToString("MMMM dd yyyy") + " " + DateTime.Now.ToString("h-mm-ss tt").ToUpper() + ".bak'";

                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Backup Created Successfully", "Backup Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRestoreDatabase_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string sFileName = " ";

                var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                OpenFileDialog ofd = new OpenFileDialog();

                ofd.Filter = "All Files (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.Multiselect = false;
                ofd.InitialDirectory = path + "\\Database Backups";
                

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                   sFileName = ofd.FileName;

                    string query =
                   "USE master " +
                   "\n" +
                   "ALTER DATABASE FFRUsers \n" +
                   "SET SINGLE_USER WITH ROLLBACK IMMEDIATE " +
                   "\n" +
                   "RESTORE DATABASE FFRUsers FROM DISK = '" + sFileName + "' " +
                   "\n";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Database Restored Successfully", "Database Restored", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.ToString() == "")
            {
                MessageBox.Show("Username must not be empty", "Username error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPass.Text.ToString() == "")
            {
                MessageBox.Show("Password must not be empty", "Password error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbUserName.Text.ToString() == "")
            {
                MessageBox.Show("User type must not be empty", "User type error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (SqlConnection con = new SqlConnection(login.connectionString))
                {
                    AddEmployee ad = new AddEmployee();
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(
                            "Insert into Users" +
                            "(User_," +
                            "Username_," +
                            "Password_," +
                            "DashBoard," +
                            "EmployeeList," +
                            "Leave," +
                            "DepartmentPosition," +
                            "Deductions," +
                            "AttendanceRecord," +
                            "PayrollReport," +
                            "HolidaySetting," +
                            "Settings," +
                            "Schedules)" +
                            "Values" +
                            "(@User," +
                            "@Username," +
                            "@Password," +
                            "@DashBoard," +
                            "@EmployeeList," +
                            "@Leave," +
                            "@DepartmentPosition," +
                            "@Deductions," +
                            "@AttendanceRecord," +
                            "@PayrollReport," +
                            "@HolidaySetting," +
                            "@Settings," +
                            "@Schedules) ", con);

                        cmd.Parameters.AddWithValue("@User", cmbUserName.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPass.Text);

                        cmd.Parameters.AddWithValue("@DashBoard", 1);

                        if (EmployeeList.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@EmployeeList", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@EmployeeList", 0);
                        }
                        if (Leave.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@Leave", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Leave", 0);
                        }
                        if (DepartmentPosition.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@DepartmentPosition", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@DepartmentPosition", 0);
                        }
                        if (Deductions.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@Deductions", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Deductions", 0);
                        }
                        if (AttendanceRecord.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@AttendanceRecord", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@AttendanceRecord", 0);
                        }
                        if (PayrollReport.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@PayrollReport", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@PayrollReport", 0);
                        }
                        if (HolidaySetting.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@HolidaySetting", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@HolidaySetting", 0);
                        }
                        if (Setting.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@Settings", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Settings", 0);
                        }
                        if (Schedules.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@Schedules", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Schedules", 0);
                        }
                        cmd.ExecuteNonQuery();
                        DialogResult dialogResult = MessageBox.Show("Successfully Created New User", "Created User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.OK)
                        {
                            cmbUserName.Text = "";
                            txtPass.Text = "";
                            txtUser.Text = "";
                            updateTable();

                            AuditTrail audit = new AuditTrail();
                            audit.AuditAddNewUser(cmbUserName.Text.ToString(), txtUser.Text.ToString());
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        //Some Errors!
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dgvUsers.ReadOnly = false;

            dgvUsers.Enabled = true;

            Login login = new Login();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedUserId = dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvUsers.CurrentRow.Selected = true;
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * FROM Users WHERE UserID =" + dgvUsers.Rows[e.RowIndex].Cells[0].Value, connection);
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);
                    eu.lblUserID.Text = dt.Rows[0][0].ToString();
                    eu.cmbUserName.Text = dt.Rows[0][1].ToString();
                    eu.txtUser.Text = dt.Rows[0][2].ToString();
                    eu.txtPass.Text = dt.Rows[0][3].ToString();

                    using (SqlConnection connection2 = new SqlConnection(login.connectionString))
                    {
                        connection2.Open();
                        SqlCommand cmd2 = new SqlCommand("Select * FROM Users WHERE UserID =" + dgvUsers.Rows[e.RowIndex].Cells[0].Value, connection);
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
                        adapter2.Fill(dt2);

                        if (dt2.Rows[0][4].ToString() == "True")
                        {
                            eu.DashBoard.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][5].ToString() == "True")
                        {
                            eu.EmployeeList.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][6].ToString() == "True")
                        {
                            eu.Leave.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][7].ToString() == "True")
                        {
                            eu.DepartmentPosition.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][8].ToString() == "True")
                        {
                            eu.Deductions.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][9].ToString() == "True")
                        {
                            eu.AttendanceRecord.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][10].ToString() == "True")
                        {
                            eu.PayrollReport.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][11].ToString() == "True")
                        {
                            eu.HolidaySetting.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][12].ToString() == "True")
                        {
                            eu.Setting.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][13].ToString() == "True")
                        {
                            eu.Schedules.CheckState = CheckState.Checked;
                        }
                    }
                }
            }
            eu.ShowDialog();
        }

        private void BtnRemove(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                       " Are you sure you want to remove selected User? ", "Delete User", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Warning
               );

            if (dialogResult == DialogResult.Yes)
            {
                string query =
                "DELETE FROM Users WHERE " +
                "UserID = " + selectedUserId;

                using (SqlConnection conn = new SqlConnection(login.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                updateTable();
                MessageBox.Show("User Deleted", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btn_save(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "UPDATE Sender " +
                    "SET Email='" + txtSenderEmail.Text.ToString() + "'" +
                    ",Pass='" + txtSenderPass.Text.ToString() + "'";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Email Sender Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
