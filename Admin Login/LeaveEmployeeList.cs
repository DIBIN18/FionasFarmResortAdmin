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

    public partial class LeaveEmployeeList : Form
    {
        public LeaveEmployeeList()
        {
            InitializeComponent();
        }
        Login login = new Login();
        public DataTable dt = new DataTable();
        string employeeid, employeename, department, position;
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

        private void LeaveEmployeeList_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select e.EmployeeID, e.EmployeeFullName, d.DepartmentName, p.PositionName from EmployeeInfo AS e join Department AS d on e.DepartmentID = d.DepartmentID join Position As p on e.PositionID = p.PositionID", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvLeave.DataSource = dt;
            conn.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Leave";
            menu.Menu_Load(menu, EventArgs.Empty);
        }
        private void dgvLeave_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Leave l = new Leave();
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Leave";
            l.btnSubmit.Enabled = true;
            l.btnCancel.Enabled = true;
            if (dgvLeave.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                employeeid = dgvLeave.CurrentRow.Cells[0].Value.ToString();
                employeename = dgvLeave.CurrentRow.Cells[1].Value.ToString();
                department = dgvLeave.CurrentRow.Cells[2].Value.ToString();
                position = dgvLeave.CurrentRow.Cells[3].Value.ToString();
                menu.ValueHolder(employeeid, employeename, department, position);
                menu.Menu_Load(menu, EventArgs.Empty);

           
            }
        }
    }
}