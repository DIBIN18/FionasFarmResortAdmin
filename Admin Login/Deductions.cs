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
            if(cb_SortBy.Text == "Default")
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

                //txtRate.Text = dt.Rows[0][0].ToString();
                lblRate.Text = dt.Rows[0][0].ToString();
                lblEmpID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
              lblEmpName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
              lblDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
              lblPosition.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            
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
        private void btnSaveDeduction(object sender, EventArgs e)// after ma edit sesave nya sa Database and matic compute ng TotalDeduction/reload
        {
            //sqlDataAdapter.Update((DataTable)bindingSource.DataSource);
            //MessageBox.Show("SAVED");
            //using (SqlConnection connection = new SqlConnection(login.connectionString))
            //{
            //    connection.Open();
            //    SqlCommand cmd = new SqlCommand("UPDATE Deductions set TotalDeductions = SSSContribution+PagIbigContribution+PhilHealthContribution+OtherDeduction", connection);
            //    cmd.ExecuteNonQuery();
            //    Deductions_Load(this, null);
            //}
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




    }
}