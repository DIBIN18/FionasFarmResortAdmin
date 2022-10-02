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
    public partial class Leave : Form
    {
        Login login = new Login();

        public Leave()
        {
            InitializeComponent();
        }
        private void Cb_SortBy_Click(object sender, EventArgs e)
        {
            cb_SortBy.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Tb_Search_Enter(object sender, EventArgs e)
        {
            if (tb_Search.Text == " Search")
            {
                tb_Search.Text = "";
                tb_Search.ForeColor = Color.Black;
            }
        }
        private void Tb_Search_Leave(object sender, EventArgs e)
        {
            if (tb_Search.Text == "")
            {
                tb_Search.Text = " Search";
                tb_Search.ForeColor = Color.Silver;
            }
        }
        private void Cb_SortBy_Enter(object sender, EventArgs e)
        {
            if (cb_SortBy.Text == "Default")
            {
                cb_SortBy.Text = "Default";
                cb_SortBy.ForeColor = Color.Black;
            }
        }
        private void Cb_SortBy_Leave(object sender, EventArgs e)
        {
            if (cb_SortBy.Text == "Default")
            {
                cb_SortBy.Text = "Default";
                cb_SortBy.ForeColor = Color.Silver;
            }
        }

        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(login.connectionString);
            //conn.Open();
            //if (tb_Search.Text == null)
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("Select EmployeeID,EmployeeFullName, DepartmentName, PositionName  FROM EmployeeInfo", conn);
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    DataTable dataTable = new DataTable();
            //    adapter.Fill(dataTable);
            //    dgvLeave.DataSource = dataTable;
            //    conn.Close();

            //}
            //else if (tb_Search.Focused)
            //{

            //    SqlCommand cmd = new SqlCommand("Select * from EmployeeInfo Where EmployeeID like '" + tb_Search.Text + "%'" + "OR EmployeeFullName Like'" + tb_Search.Text + "%'", conn);
            //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //    DataTable tb = new DataTable();
            //    sqlDataAdapter.Fill(tb);
            //    dgvLeave.DataSource = tb;
            //    conn.Close();
            //}
        }

        public void AdvancedDay_Offs_Load(object sender, EventArgs e) 
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT L.LeaveID, E.EmployeeID, E.EmployeeFullName, L.StartDate, L.EndDate, L.Reason " +
                    "FROM Leave AS L " +
                    "LEFT JOIN EmployeeInfo AS E " +
                    "ON L.EmployeeID = E.EmployeeID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvLeave.DataSource = data;
            }
        }

        private void btnAdd_Leave_Click(object sender, EventArgs e)
        {
            ApplyLeave leave = new ApplyLeave();
            leave.ShowDialog();
        }
    }
}