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
    public partial class Settings : Form
    {
        Login login = new Login();
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
            dgvUsers.ReadOnly = false;
            btnSave.Visible = false;

            updateTable();

            cmbUserName.Items.Add("Human Resources");
            cmbUserName.Items.Add("Time Keeper");
            cmbUserName.Items.Add("Accountant");
            cmbUserName.Items.Add("Supervisor");
            cmbUserName.Items.Add("General Manager");
        }

        public void updateTable()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "SELECT User_, Username_,DashBoard,EmployeeList,Leave,DepartmentPosition,Deductions,AttendanceRecord,PayrollReport,HolidaySetting,Settings,Schedules FROM Users";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
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
            btnEdit.Visible = false;
            btnSave.Visible = true;
            dgvUsers.Enabled = true;
            Login login = new Login();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            btnSave.Visible = false;
            btnEdit.Visible = true;
            dgvUsers.Enabled = false;
       
            using (SqlConnection con = new SqlConnection(login.connectionString))
            {
                for(int i = 0; i < dgvUsers.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Update Users SET DashBoard=@DashBoard,EmployeeList=@EmployeeList,Leave=@Leave,DepartmentPosition=@DepartmentPosition,Deductions=@Deductions,AttendanceRecord=@AttendanceRecord,PayrollReport=@PayrollReport,HolidaySetting=@HolidaySetting,Settings=@Settings,Schedules=@Schedules", con);
                    command.Parameters.AddWithValue("@DashBoard", dgvUsers.Rows[i].Cells[2].Value);
                    command.Parameters.AddWithValue("@EmployeeList", dgvUsers.Rows[i].Cells[3].Value);
                    command.Parameters.AddWithValue("@Leave", dgvUsers.Rows[i].Cells[4].Value);
                    command.Parameters.AddWithValue("@DepartmentPosition", dgvUsers.Rows[i].Cells[5].Value);
                    command.Parameters.AddWithValue("@Deductions", dgvUsers.Rows[i].Cells[6].Value);
                    command.Parameters.AddWithValue("@AttendanceRecord", dgvUsers.Rows[i].Cells[7].Value);
                    command.Parameters.AddWithValue("@PayrollReport", dgvUsers.Rows[i].Cells[8].Value);
                    command.Parameters.AddWithValue("@HolidaySetting", dgvUsers.Rows[i].Cells[9].Value);
                    command.Parameters.AddWithValue("@Settings", dgvUsers.Rows[i].Cells[10].Value);
                    command.Parameters.AddWithValue("@Schedules", dgvUsers.Rows[i].Cells[11].Value);
                    command.ExecuteNonQuery();
                    updateTable();
                    con.Close();

                }
                MessageBox.Show("Update Succesful!");
            }
        }

        
    }
}
