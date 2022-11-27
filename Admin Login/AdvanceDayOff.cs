using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Login
{
    public partial class AdvanceDayOff : Form
    {
        Login login = new Login();
        string selectedEmployee = "";
        int accDayOff = 0;

        public AdvanceDayOff()
        {
            InitializeComponent();
        }

        private void btn_BackClick(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Schedules";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }

        public void UpdateTable()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT " +
                    "EmployeeID, " +
                    "EmployeeFullName," +
                    "AccumulatedDayOffs " +
                    "FROM EmployeeInfo " +
                    "WHERE Status='Active'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                this.dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvEmployees.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvEmployees.DataSource = data;
                dgvEmployees.Columns["EmployeeID"].Visible = false;
            }
        }

        private void AdvanceDayOff_Load(object sender, EventArgs e)
        {
            dtpDateFrom.MaxDate = dtpDateTo.Value;

            UpdateTable();
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedEmployee = dgvEmployees.Rows[e.RowIndex].Cells[0].Value.ToString();
            lbl_EmployeeName.Text = dgvEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();
            accDayOff = Convert.ToInt32(dgvEmployees.Rows[e.RowIndex].Cells[2].Value);

            dtpDateFrom.Enabled = true;
            dtpDateTo.Enabled = true;
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpDateFrom.MaxDate = dtpDateTo.Value;
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            dtpDateFrom.MaxDate = dtpDateTo.Value;
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public int GetEmployeeAccDayOffs(string emp_id)
        {
            string query2 = "SELECT AccumulatedDayOffs FROM EmployeeInfo WHERE EmployeeID=" + emp_id;

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetInt32(0);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        private void btn_AddClick(object sender, EventArgs e)
        {
            DateTime StartDate = DateTime.Parse(dtpDateFrom.Text.ToString());
            DateTime EndDate = DateTime.Parse(dtpDateTo.Text.ToString());

            int totalDays = 0;
            int accDayOffsCount = GetEmployeeAccDayOffs(selectedEmployee);

            // Get total days of accumulated day offs to be given
            foreach (DateTime day in EachDay(StartDate, EndDate))
            {
                totalDays++;
            }

            if (totalDays > accDayOffsCount)
            {
                MessageBox.Show("Selected Employee does not have enough accumulated day offs for the given dates");
            }
            else
            {
                foreach (DateTime day in EachDay(StartDate, EndDate))
                {
                    using (SqlConnection connection = new SqlConnection(login.connectionString))
                    {
                        connection.Open();
                        string query =
                            "INSERT INTO AccDayOffsDate (" +
                            "EmployeeID," +
                            "Date) " +
                            "VALUES(" +
                            "@EmployeeID," +
                            "@Date)";

                        SqlCommand command2 = new SqlCommand(query, connection);
                        command2.Parameters.AddWithValue("@EmployeeID", Convert.ToInt64(selectedEmployee));
                        command2.Parameters.AddWithValue("@Date", day.ToString("MMMM dd, yyyy"));
                        command2.ExecuteNonQuery();
                    }
                }

                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();

                    int accDayOffsLeft = accDayOffsCount - totalDays;

                    string query = 
                        "UPDATE EmployeeInfo " +
                        "SET AccumulatedDayOffs =" + accDayOffsLeft.ToString() + " " +
                        "WHERE EmployeeID=" + selectedEmployee;

                    SqlCommand command2 = new SqlCommand(query, connection);
                    command2.ExecuteNonQuery();
                }

                MessageBox.Show("Accumulated Day Offs Applied");
                UpdateTable();

            }            
        }

        private void btnViewAccDayOffList(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Accumulated Day Offs Lists";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }
    }   
}
