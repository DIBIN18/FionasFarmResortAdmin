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

        private void Settings_Load(object sender, EventArgs e)
        {
            dgvUsers.ReadOnly = false;
            btnSave.Visible = false;
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "SELECT User_, Username_,DashBoard,EmployeeList,Leave,DepartmentPosition,Deductions,AttendanceRecord,PayrollReport,HolidaySetting,Settings FROM Users";
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
                    "TO DISK = '" + path + "\\Database Backups\\Backup.bak'";

                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Backup Created Successfully");
            }
        }

        private void btnRestoreDatabase_Click(object sender, EventArgs e)
        {
            //UNTESTED
            //using (SqlConnection connection = new SqlConnection(login.connectionString))
            //{
            //    connection.Open();

            //    var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

            //    DateTime today = DateTime.Today;

            //    string query =
            //        "RESTORE DATABASE FFRUsers " +
            //        "FROM DISK = '" + path + "\\Database Backups\\FFRUsers.bak";

            //    SqlCommand command = new SqlCommand(query, connection);
            //    command.ExecuteNonQuery();
            //    MessageBox.Show("Database Resotored Successfully");
            //}
        }

        private void btnSSSRate_Click(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddNewUser addNewUser = new AddNewUser();
            addNewUser.ShowDialog();
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//edit
        {
            dgvUsers.ReadOnly = false;
            btnEdit.Visible = false;
            btnSave.Visible = true;
            Login login = new Login();
         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            btnSave.Visible = false;
            btnEdit.Visible = true;
            dgvUsers.ReadOnly = true;
            using (SqlConnection con = new SqlConnection(login.connectionString))
            {
                for(int i = 0; i < dgvUsers.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Update Users SET DashBoard=@DashBoard,EmployeeList=@EmployeeList,Leave=@Leave,DepartmentPosition=@DepartmentPosition,Deductions=@Deductions,AttendanceRecord=@AttendanceRecord,PayrollReport=@PayrollReport,HolidaySetting=@HolidaySetting,Settings=@Settings", con);
                    command.Parameters.AddWithValue("@DashBoard", dgvUsers.Rows[i].Cells[2].Value);
                    command.Parameters.AddWithValue("@EmployeeList", dgvUsers.Rows[i].Cells[3].Value);
                    command.Parameters.AddWithValue("@Leave", dgvUsers.Rows[i].Cells[4].Value);
                    command.Parameters.AddWithValue("@DepartmentPosition", dgvUsers.Rows[i].Cells[5].Value);
                    command.Parameters.AddWithValue("@Deductions", dgvUsers.Rows[i].Cells[6].Value);
                    command.Parameters.AddWithValue("@AttendanceRecord", dgvUsers.Rows[i].Cells[7].Value);
                    command.Parameters.AddWithValue("@PayrollReport", dgvUsers.Rows[i].Cells[8].Value);
                    command.Parameters.AddWithValue("@HolidaySetting", dgvUsers.Rows[i].Cells[9].Value);
                    command.Parameters.AddWithValue("@Settings", dgvUsers.Rows[i].Cells[10].Value);
                    command.ExecuteNonQuery();
                    con.Close();

                }
                MessageBox.Show("Update Succesful!");
            }
        }
    }
}
