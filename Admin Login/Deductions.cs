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
    public partial class Deductions : Form
    {
        Login login = new Login();
        
        SqlCommandBuilder cmbl;

           
        public Deductions()
        {
            InitializeComponent();

           
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
     
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                SqlConnection conn = new SqlConnection(login.connectionString);
                SqlCommand cmd = new SqlCommand("select p.BasicRate From Position AS p JOIN EmployeeInfo AS e ON p.PositionID = e.PositionID Where e.EmployeeID  = " + dataGridView1.Rows[e.RowIndex].Cells[0].Value, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                lblRate.Text = dt.Rows[0][0].ToString();
                lblEmpID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblEmpName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                lblPosition.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;

            }
       
        }
     
        private void Deductions_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select E.EmployeeID, E.EmployeeFullName, D.DepartmentName , P.PositionName FROM EmployeeInfo AS E " +
                "JOIN Department AS D ON E.DepartmentID = D.DepartmentID JOIN Position AS P ON E.PositionID = P.PositionID", conn);
                
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dts = new DataTable();
            sqlDataAdapter.Fill(dts);
            dataGridView1.DataSource = dts;



            txtSSS.Enabled = false;
            txtpagibig.Enabled = false;
            txtphilhealth.Enabled = false;
            txtotherdeduction.Enabled = false;
            txttin.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {       
                txtotherdeduction.Enabled = true;            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                dataGridView1.CurrentRow.Selected = true;

                SqlCommand sqlCommand = new SqlCommand("UPDATE Deductions set  OtherDeduction = @otherdeduction, TotalDeductions = SSSContribution + PagIbigContribution + PhilHealthContribution + @otherdeduction where EmployeeID = " + dataGridView1.CurrentRow.Cells[0].Value, connection);
                
                sqlCommand.Parameters.AddWithValue("@otherdeduction", Convert.ToDecimal(txtotherdeduction.Text));
                sqlCommand.ExecuteNonQuery();
                
                MessageBox.Show("Update Complete");
            
                txtotherdeduction.Text = "";
                txtpagibig.Text = "";
                txtphilhealth.Text = "";
                txtSSS.Text = "";
            }
        }
        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            if (string.IsNullOrEmpty(tb_Search.Text))
            {
                SqlCommand cmd = new SqlCommand("Select E.EmployeeID, E.EmployeeFullName, D.DepartmentName , P.PositionName FROM EmployeeInfo AS E " +
                "JOIN Department AS D ON E.DepartmentID = D.DepartmentID JOIN Position AS P ON E.PositionID = P.PositionID", connection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dts = new DataTable();
                sqlDataAdapter.Fill(dts);
                dataGridView1.DataSource = dts;
            }
            else if (tb_Search.Focused)
            {
                SqlCommand cmd = new SqlCommand("Select E.EmployeeID, E.EmployeeFullName, D.DepartmentName , P.PositionName FROM EmployeeInfo AS E JOIN Department AS D ON E.DepartmentID = D.DepartmentID JOIN Position AS P ON E.PositionID = P.PositionID where E.EmployeeID like '" + tb_Search.Text +"%'" + "OR EmployeeFullName like'"+ tb_Search.Text + "%'" , connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dts = new DataTable();
                sqlDataAdapter.Fill(dts);
                dataGridView1.DataSource = dts;
            }
        }
    }
}