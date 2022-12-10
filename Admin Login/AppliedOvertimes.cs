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
    public partial class AppliedOvertimes : Form
    {
        Login login = new Login();

        string SelectedOvertimeID = "";

        public AppliedOvertimes()
        {
            InitializeComponent();
        }

        private void BtnBack(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Schedule Overtime";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        private void UpdateTable()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();

                string query =
                    "SELECT * FROM Overtime";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                this.dgvOTList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgvOTList.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvOTList.DataSource = data;
                dgvOTList.Columns["OvertimeAppID"].Visible = false;
            }
        }

        private void AppliedOvertimes_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void dgvOTList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedOvertimeID = dgvOTList.Rows[e.RowIndex].Cells[0].Value.ToString();
            Console.WriteLine(SelectedOvertimeID);
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();

                string query =
                    "DELETE FROM OvertimeDates WHERE OvertimeAppID=" + SelectedOvertimeID + " " +
                    "DELETE FROM Overtime WHERE OvertimeAppID=" + SelectedOvertimeID;
                    
                DialogResult dialogResult = MessageBox.Show(
                        " Are you sure you want to cancel the applied overtime? ", "Delete Applied Overtime", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

                SqlCommand cmd = new SqlCommand(query, connection);

                if (dialogResult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Applied Overtime Cancelled", "Cancel Overtime", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    AuditTrail audit = new AuditTrail();
                    audit.AuditRemoveOverTime();
                    UpdateTable();
                }
            }
        }
    }
}
