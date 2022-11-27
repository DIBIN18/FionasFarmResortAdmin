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
    public partial class OvertimeList : Form
    {
        Login login = new Login();

        string selectedOtId = "";

        public OvertimeList()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Schedule Overtime";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        private void OvertimeList_Load(object sender, EventArgs e)
        {
            string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT " +
                    "OvertimeDates.OvertimeID, " +
                    "EmployeeInfo.EmployeeFullName," +
                    "OvertimeDates.Date FROM OvertimeDates " +
                    "INNER JOIN EmployeeInfo " +
                    "ON OvertimeDates.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Date='" + date + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                this.dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvEmployees.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvEmployees.DataSource = data;
                dgvEmployees.Columns["OvertimeID"].Visible = false;
            }
        }

        private void dtp_Date_ValueChanged(object sender, EventArgs e)
        {
            string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT " +
                    "OvertimeDates.OvertimeID, " +
                    "EmployeeInfo.EmployeeFullName," +
                    "OvertimeDates.Date FROM OvertimeDates " +
                    "INNER JOIN EmployeeInfo " +
                    "ON OvertimeDates.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Date='" + date + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                this.dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvEmployees.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvEmployees.DataSource = data;
                dgvEmployees.Columns["OvertimeID"].Visible = false;
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedOtId = dgvEmployees.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "DELETE FROM OvertimeDates WHERE OvertimeID=" + selectedOtId;


                DialogResult dialogResult = MessageBox.Show(
                        " Are you sure you want to remove the overtime schedule? ", "Delete Overtime Schedule", MessageBoxButtons.YesNo
                );

                SqlCommand cmd = new SqlCommand(query, connection);

                if (dialogResult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Overtime Schedule Removed");
                }
            }
        }
    }
}
