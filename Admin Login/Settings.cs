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
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "SELECT User_, Username_ FROM Users";
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
                    "TO DISK = '" + path + "\\Backup.bak'";

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
    }
}
