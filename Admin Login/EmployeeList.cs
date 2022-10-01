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
        Login login = new Login();
        EmployeeProfile ep = new EmployeeProfile();

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
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM EmployeeInfo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvEmployeeList.DataSource = data;
            }
        }

        private void btnArchive(object sender, EventArgs e)
        {
            if (dgvEmployeeList.CurrentRow.Selected == true)
            {
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();

                    string query = //"SET IDENTITY_INSERT Archive ON " +
                    "Insert INTO Archive (" +
                    "EmployeeID , " +
                    "EmployeeFullName, " +
                    "Address , " +
                    "SSS_ID , " +
                    "PAGIBIG_NO, " +
                    "PHIL_HEALTH_NO, " +
                    "Email, " +
                    "EmployeeMaritalStatus, " +
                    "ContactNumber, " +
                    "DateHired, " +
                    "Gender, " +
                    "BirthDate, " +
                    "DepartmentID, " +
                    "PositionID)" +
                    "SELECT " +
                    "EmployeeID, " +
                    "EmployeeFullName , " +
                    "Address , " +
                    "SSS_ID, " +
                    "PAGIBIG_NO, " +
                    "PHIL_HEALTH_NO, " +
                    "Email, " +
                    "EmployeeMaritalStatus, " +
                    "ContactNumber, " +
                    "DateHired, " +
                    "Gender, " +
                    "BirthDate, " +
                    "DepartmentID, " +
                    "PositionID " +
                    "FROM EmployeeInfo WHERE EmployeeID = " + dgvEmployeeList.CurrentRow.Cells[0].Value + 
                    "DELETE FROM Deductions WHERE EmployeeID = " + dgvEmployeeList.CurrentRow.Cells[0].Value +
                    "DELETE FROM EmployeeInfo WHERE EmployeeID = " + dgvEmployeeList.CurrentRow.Cells[0].Value;

                    SqlCommand cmd = new SqlCommand(query, connection);

                    DialogResult dialogResult = MessageBox.Show(
                        " Are you sure you want to Archive Employee? " + 
                        dgvEmployeeList.CurrentRow.Cells[1].Value.ToString() + " " + 
                        dgvEmployeeList.CurrentRow.Cells[2].Value.ToString(), "Archive", MessageBoxButtons.YesNo
                    );

                    if (dialogResult == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();

                        connection.Close();
                        Menu menu = (Menu)Application.OpenForms["Menu"];
                        menu.Text = "Fiona's Farm and Resort - Employee List";
                        menu.Menu_Load(menu, EventArgs.Empty);
                    }
                }
            }
        }

        private void dgvCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmployeeList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvEmployeeList.CurrentRow.Selected = true;

                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * FROM EmployeeInfo WHERE EmployeeID =" +
                        dgvEmployeeList.Rows[e.RowIndex].Cells[0].Value, connection);
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    ep.lblEmployeeID.Text = dt.Rows[0][0].ToString();
                    ep.lblName.Text = dt.Rows[0][1].ToString();
                    ep.lblAge.Text = dt.Rows[0][17].ToString();
                    ep.lblMaritalStatus.Text = dt.Rows[0][9].ToString();
                    ep.lblContact.Text = dt.Rows[0][10].ToString();
                    ep.lblEmail.Text = dt.Rows[0][8].ToString();
                    ep.lblDateHired.Text = dt.Rows[0][11].ToString();
                    ep.lblGender.Text = dt.Rows[0][12].ToString();
                    ep.lblAddress.Text = dt.Rows[0][4].ToString();
                    // ep.lblEmploymentType.Text = dt.Rows[][].ToString();
                    ep.lblPosition.Text = dt.Rows[0][15].ToString();
                    ep.lblDepartment.Text = dt.Rows[0][14].ToString();
                    //ep.lblAccumulated.Text = dt.Rows[][].ToString();
                    // ep.lblStatus.Text = dt.Rows[][].ToString();
                    // ep.lblSchedule.Text = dt.Rows[][].ToString();
                }

            }
        }

        private void bntViewArchive(object sender, EventArgs e)
        {
            ArchivedEmployee archivedEmployee = new ArchivedEmployee();
            archivedEmployee.ShowDialog();
        }


        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                if (string.IsNullOrEmpty(tb_Search.Text))
                {
                    SqlCommand cmd2 = new SqlCommand("Select * from EmployeeInfo", connection);
                    SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    sqlDataAdapter2.Fill(dt2);
                    dgvEmployeeList.DataSource = dt2;
                }
                else if (tb_Search.Focused)
                {
                    SqlCommand cmd = new SqlCommand(
                        "Select * from EmployeeInfo WHERE " +
                        "EmployeeFullName like '" + tb_Search.Text + "%'" +
                        "OR EmployeeID Like '" + tb_Search.Text + "%'", connection);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dgvEmployeeList.DataSource = dt;
                }
            }
        }

        private void dgvEmployeeList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {          
            ep.ShowDialog();
        }

        private void dgvEmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}