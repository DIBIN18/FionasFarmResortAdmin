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
    public partial class AccumulatedDayOffsList : Form
    {
        Login login = new Login();
        string selectedAccDayOffID = "";  

        public AccumulatedDayOffsList()
        {
            InitializeComponent();
        }

        private void btn_back(object sender, EventArgs e)
        {
            // ????
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Add Accumulated Day Off";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        private void btnBack(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Add Accumulated Day Off";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        public void UpdateTable()
        {
            string date = dtp_Date.Value.ToString("MMMM dd, yyyy");

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT " +
                    "AccDayOffsDate.AccDayOffID, " +
                    "EmployeeInfo.EmployeeFullName," +
                    "AccDayOffsDate.Date FROM AccDayOffsDate " +
                    "INNER JOIN EmployeeInfo " +
                    "ON AccDayOffsDate.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE Date='" + date + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                this.dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvEmployees.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvEmployees.DataSource = data;
                dgvEmployees.Columns["AccDayOffID"].Visible = false;
            }
        }

        private void AccumulatedDayOffsList_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedAccDayOffID = dgvEmployees.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnRemoveClick(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "DELETE FROM AccDayOffsDate WHERE AccDayOffID=" + selectedAccDayOffID;


                DialogResult dialogResult = MessageBox.Show(
                        " Are you sure you want to remove the accumulated day off schedule? ", "Delete Accumulated Day Off Schedule", MessageBoxButtons.YesNo
                );

                SqlCommand cmd = new SqlCommand(query, connection);

                if (dialogResult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accumulated Day Off Schedule Removed");
                    UpdateTable();
                }
            }
        }

        private void dtp_Date_ValueChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}
