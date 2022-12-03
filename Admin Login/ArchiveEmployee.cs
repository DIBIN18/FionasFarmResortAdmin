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
    public partial class ArchiveEmployee : Form
    {
        Login login = new Login();
        public ArchiveEmployee()
        {
            InitializeComponent();
        }
        private void ArchivedEmployee_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "SELECT EmployeeID, EmployeeFullName, Email, ContactNumber FROM EmployeeInfo WHERE Status='Inactive'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                // Column font
                this.dgv_Archive.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                // Row font
                this.dgv_Archive.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgv_Archive.DataSource = data;
            }
        }
        private void btnRestore(object sender, EventArgs e)
        {
            if (dgv_Archive.CurrentRow.Selected == true)
            {
                DialogResult dialogResult = MessageBox.Show(" Are you sure you want to Restore Employee? " 
                    + dgv_Archive.CurrentRow.Cells[1].Value.ToString() + " " + dgv_Archive.CurrentRow.Cells[2].Value.ToString(), 
                    "Archive", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(login.connectionString))
                    {
                        connection.Open();
                        string query =
                        "UPDATE EmployeeInfo SET Status='Active' WHERE EmployeeID=" + dgv_Archive.CurrentRow.Cells[0].Value;
                        SqlCommand cmd = new SqlCommand(query,connection);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Successfully Restored Employee");
                    insertNewEmployeeToDeductionTable();
                    RefreshTable();
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
        private void Tb_Search_TextChange(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                if (string.IsNullOrEmpty(tb_Search.Text))
                {
                    SqlCommand cmd2 = new SqlCommand("Select EmployeeID, EmployeeFullName, Email, ContactNumber " +
                        "from EmployeeInfo where Status = 'Inactive'", connection);
                    SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    sqlDataAdapter2.Fill(dt2);
                    dgv_Archive.DataSource = dt2;
                }
                else if (tb_Search.Focused)
                {
                    SqlCommand cmd = new SqlCommand(
                        "Select EmployeeID, EmployeeFullName, Email, ContactNumber from EmployeeInfo WHERE Status='Inactive' AND " +
                        "EmployeeFullName like '%" + tb_Search.Text + "%'" +
                        "OR EmployeeID Like '" + tb_Search.Text + "%'", connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dgv_Archive.DataSource = dt;
                }
            }
        }
        private void tb_Search_Enter(object sender, EventArgs e)
        {
            if (tb_Search.Text == " Search")
            {
                tb_Search.Text = "";
                tb_Search.ForeColor = Color.Black;
            }
        }
        private void tb_Search_Leave(object sender, EventArgs e)
        {
            if (tb_Search.Text == "")
            {
                tb_Search.Text = " Search";
                tb_Search.ForeColor = Color.Silver;
            }
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Employee List";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }
        public void RefreshTable()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "SELECT EmployeeID, EmployeeFullName, Email, ContactNumber FROM EmployeeInfo WHERE Status='Inactive'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                this.dgv_Archive.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                this.dgv_Archive.DefaultCellStyle.Font = new Font("Century Gothic", 10);
                dgv_Archive.DataSource = data;
            }
        }
    }
}