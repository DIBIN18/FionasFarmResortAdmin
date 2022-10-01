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
    }
}
