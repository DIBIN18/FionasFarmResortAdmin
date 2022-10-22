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
            this.Close();
        }
        public void Confirm()
        {

            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select e.EmployeeID, e.EmployeeFullName, d.DepartmentName, p.PositionName from EmployeeInfo AS e join Department AS d on e.DepartmentID = d.DepartmentID join Position As p on e.PositionID = p.PositionID where EmployeeID = " + dgvLeave.CurrentRow.Cells[0].Value, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
       
            adapter.Fill(dt);
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Leave leavess = new Leave();
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select e.EmployeeID, e.EmployeeFullName, d.DepartmentName, p.PositionName from EmployeeInfo AS e join Department AS d on e.DepartmentID = d.DepartmentID join Position As p on e.PositionID = p.PositionID where EmployeeID = " + dgvLeave.CurrentRow.Cells[0].Value, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            leavess.txtID.Text = dt.Rows[0][0].ToString(); ;
            leavess.txtName.Text = dt.Rows[0][1].ToString();
            leavess.txtDepartment.Text = dt.Rows[0][2].ToString();
            leavess.txtPosition.Text = dt.Rows[0][3].ToString();
            conn.Close();
            leavess.cmbLeaveType.Enabled = true;
            leavess.rtxtReason.Enabled = true;
            leavess.dtpStartDate.Enabled = true;
            leavess.dtpEndDate.Enabled = true;
            leavess.btnCancel.Enabled = true;
            leavess.btnSubmit.Enabled = true;  
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Leave";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        private void dgvLeave_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLeave.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvLeave.CurrentRow.Selected = true;

            }
        }
    }
}
