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
    public partial class HolidaySettings : Form
    {
        Login login = new Login();

        string selectedHoliday = "";

        public HolidaySettings()
        {
            InitializeComponent();
        }

        private void HolidaySettings_Load(object sender, EventArgs e)
        {
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "MMMM dd";

            UpdateTable();
        }

        public void UpdateTable()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT " +
                    "Holiday_ AS Holiday_Name, " +
                    "From_ AS Date, " +
                    "Type_ AS Type" +
                    " FROM Holidays";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                // Column font
                this.dgv_HolidaysTable.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                // Row font
                this.dgv_HolidaysTable.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgv_HolidaysTable.DataSource = data;
            }
        }

        private void dg_HolidaysTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedHoliday = dgv_HolidaysTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            Console.WriteLine(selectedHoliday); 
        }

        private void removeHoliday(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "DELETE FROM Holidays WHERE Holiday_='" + selectedHoliday + "'";


                DialogResult dialogResult = MessageBox.Show(
                        " Are you sure you want to remove the selected holiday?, ", "Delete Holiday", MessageBoxButtons.YesNo
                );

                SqlCommand cmd = new SqlCommand(query, connection);

                if (dialogResult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Holiday Removed");
                    
                    UpdateTable();
                }
            }
        }

        private void addHoliday(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();

                string query =
                    "INSERT INTO " +
                    "Holidays(Holiday_,From_, To_, Type_) " +
                    "VALUES (@Holiday_, @From_, @To_, @Type_)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Holiday_", txtHolidayName.Text.ToString());
                cmd.Parameters.AddWithValue("@From_", dtpDate.Value.ToString("MMMM dd"));
                cmd.Parameters.AddWithValue("@To_", dtpDate.Value.ToString("MMMM dd"));
                cmd.Parameters.AddWithValue("@Type_", cb_Type.Text.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added Holiday");
            }
            UpdateTable();
        }
    }
}