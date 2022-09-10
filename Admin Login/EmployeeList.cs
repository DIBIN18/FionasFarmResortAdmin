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
    public partial class EmployeeList : Form
    {
        //PAUL CONNECTION STRING
        public string connectionString = @"Data Source=DESKTOP-0Q352R7\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        public EmployeeList()
        {
            InitializeComponent();           
        }
        private void Cb_SortBy_Click(object sender, EventArgs e)
        {
            cb_SortBy.DropDownStyle = ComboBoxStyle.DropDownList;
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
        private void Tb_Search_Enter(object sender, EventArgs e)
        {
            if (tb_Search.Text == " Search")
            {
                tb_Search.Text = "";
                tb_Search.ForeColor = Color.Black;
            }
        }

        private void btnAddEmployee(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fFRUsersDataSet18.EmployeeInfo' table. You can move, or remove it, as needed.
            this.employeeInfoTableAdapter.Fill(this.fFRUsersDataSet18.EmployeeInfo);
        }

        private void btnArchive(object sender, EventArgs e)
        {   
            if(dgvEmployeeList.CurrentRow.Selected = true)
            {
                
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT Archive ON "
                + "Insert INTO Archive (EmployeeID,FirstName,LastName,MiddleName,Address,SSS_ID,PAGIBIG_NO,PHILHEALTH_NO,Email,EmployeeMaritalStatus,ContactNumber,DateHired,Gender,BirthDate,Department,Position,JobStatus )" +
                "SELECT EmployeeID,FirstName,LastName,MiddleName,Address,SSS_ID,PAGIBIG_NO,PHILHEALTH_NO,Email,EmployeeMaritalStatus,ContactNumber,DateHired,Gender,BirthDate,Department,Position,JobStatus " +
                "FROM EmployeeInfo WHERE EmployeeID = "+ dgvEmployeeList.CurrentRow.Cells[0].Value + " DELETE FROM EmployeeInfo WHERE EmployeeID = " + dgvEmployeeList.CurrentRow.Cells[0].Value, conn);

                DialogResult dialogResult = MessageBox.Show(" Are you sure you want to Archive Employee? "+ dgvEmployeeList.CurrentRow.Cells[1].Value.ToString() + " " + dgvEmployeeList.CurrentRow.Cells[2].Value.ToString(), "Archive", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    this.employeeInfoTableAdapter.Fill(this.fFRUsersDataSet18.EmployeeInfo);
                }      

            }

        }

        private void dgvCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmployeeList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvEmployeeList.CurrentRow.Selected = true;               
            }
        }

        private void bntViewArchive(object sender, EventArgs e)
        {
            ArchivedEmployee archivedEmployee = new ArchivedEmployee();
            archivedEmployee.ShowDialog();
        }

        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[EmployeeInfo] WHERE FirstName = '" + tb_Search.Text+"'",conn);
            cmd.ExecuteNonQuery();
            this.employeeInfoTableAdapter.Fill(this.fFRUsersDataSet18.EmployeeInfo);
            conn.Close();
        }
    }
}