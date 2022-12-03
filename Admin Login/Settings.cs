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

        private void btnUtilsClick(object sender, EventArgs e)
        {
            pnlUsers.Visible = false;
            pnlUtils.Visible = true;
            pnlAuditTrail.Visible = false;
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
            SqlCommand cmd = new SqlCommand("Select * from AuditTrail",connection);
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
                    "DashBoard," +
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
                    "TO DISK = '" + path + "\\Database Backups\\Backup - "+ 
                    today.ToString("MMMM dd yyyy") + " " + DateTime.Now.ToString("h-mm-ss tt").ToUpper() + ".bak'";

                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Backup Created Successfully");
            }
        }

        private void btnRestoreDatabase_Click(object sender, EventArgs e)
        {
            //UNTESTED
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
                }

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
                MessageBox.Show("Database Resotored Successfully");
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
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

                    if (DashBoard.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@DashBoard", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DashBoard", 0);
                    }
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
                    DialogResult dialogResult = MessageBox.Show("New User Has beed Added!", "Successful!", MessageBoxButtons.OK);
                    if (dialogResult == DialogResult.OK)
                    {
                        cmbUserName.Text = "";
                        txtPass.Text = "";
                        txtUser.Text = "";
                        updateTable();

                        SqlConnection auditcon = new SqlConnection(login.connectionString);
                        auditcon.Open();

                        string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                        string Module = "Settings";
                        string Description = "Add New User";

                        SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
                        
                        auditcommand.Parameters.AddWithValue("@UserName_", "Sample");
                        auditcommand.Parameters.AddWithValue("@Date", auditDate);
                        auditcommand.Parameters.AddWithValue("@Module", Module);
                        auditcommand.Parameters.AddWithValue("@Description", Description);
                        auditcommand.ExecuteNonQuery();
                        
                        auditcon.Close();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    //Some Errors!
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
    }
}
