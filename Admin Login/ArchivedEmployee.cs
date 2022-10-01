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
    public partial class ArchivedEmployee : Form
    {
        Login login = new Login();
        public ArchivedEmployee()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnArchiveBack(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Employee List";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }

        private void ArchivedEmployee_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "SELECT EmployeeID, EmployeeFullName, Email, ContactNumber FROM Archive";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvArchive.DataSource = data;
            }
        }

        private void btnRestore(object sender, EventArgs e)
        {
            if (dgvArchive.CurrentRow.Selected == true)
            {
                DialogResult dialogResult = MessageBox.Show(
                    " Are you sure you want to Restore Employee? " 
                    + dgvArchive.CurrentRow.Cells[1].Value.ToString() + " " 
                    + dgvArchive.CurrentRow.Cells[2].Value.ToString(), 
                    "Archive", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(login.connectionString))
                    {
                        connection.Open();
                        
                        SqlCommand cmd = new SqlCommand(//"SET IDENTITY_INSERT Archive ON"
                        "Insert INTO EmployeeInfo (" +
                        "EmployeeFullName, " +
                        "Address, " +
                        "SSS_ID, " +
                        "PAGIBIG_NO, " +
                        "PHIL_HEALTH_NO, " +
                        "Email, " +
                        "EmployeeMaritalStatus," +
                        "ContactNumber," +
                        "DateHired," +
                        "Gender," +
                        "BirthDate )" +
                        "SELECT " +
                        "EmployeeFullName," +
                        "Address," +
                        "SSS_ID," +
                        "PAGIBIG_NO," +
                        "PHIL_HEALTH_NO," +
                        "Email," +
                        "EmployeeMaritalStatus," +
                        "ContactNumber," +
                        "DateHired," +
                        "Gender," +
                        "BirthDate " +
                        "FROM Archive WHERE EmployeeID = " + dgvArchive.CurrentRow.Cells[0].Value + 
                        " DELETE FROM Archive WHERE EmployeeID = " + dgvArchive.CurrentRow.Cells[0].Value, 
                        connection);
                        
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Successfully Resored Employee");
                    insertNewEmployeeToDeductionTable();
                }
            }
        }

        public void insertNewEmployeeToDeductionTable()
        {
            string query = "insert into Deductions " +
                           "(EmployeeID, " +
                           "SSSContribution, " +
                           "PagIbigContribution, " +
                           "PhilHealthContribution, " +
                           "OtherDeduction, " +
                           "TotalDeductions)" +
                           "select EmployeeID = MAX(A.EmployeeID) ,0.00, 0.00, 0.00, 0.00, 0.00 from EmployeeInfo as A";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }

        private void dgvArchiveCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvArchive.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvArchive.CurrentRow.Selected = true;
            }
        }

        private void tbSearchArchive(object sender, EventArgs e)
        {
          
        }
    }
}