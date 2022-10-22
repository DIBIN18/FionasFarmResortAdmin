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

                //txtRate.Text = dt.Rows[0][0].ToString();
                lblRate.Text = dt.Rows[0][0].ToString();
                lblEmpID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblEmpName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                lblPosition.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                kuninSiKabawasan();
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
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            tagadelete();
            tagaInsertPayrollReport();
            kuninSiKabawasan();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            tagadelete();
            tagaInsertPayrollReport();
            kuninSiKabawasan();
        }
        public void kuninSiKabawasan()
        {
            SqlConnection sql = new SqlConnection(login.connectionString);
            string command = "Select * from PayrollReport where EmployeeID = " + dataGridView1.CurrentRow.Cells[0].Value;
            SqlCommand cmd = new SqlCommand(command, sql);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            txtSSS.Text = dt.Rows[0][12].ToString();
            txtpagibig.Text = dt.Rows[0][13].ToString();
            txtphilhealth.Text = dt.Rows[0][14].ToString();

        }
        public void tagadelete()
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("delete from PayrollReport", connection);
            command.ExecuteNonQuery();
        }
        public void tagaInsertPayrollReport()
        {
            SSSRangeClass sssclass = new SSSRangeClass();
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            string query = "insert into PayrollReport " +
                "select A.EmployeeID, A.EmployeeFullName as Employee, B.PositionName as Position, B.BasicRate , " +
                "sum(TotalHours) as TotalHours , " +
                "sum(C.OvertimeHours) as OverTimeHours , " +
                "sum(C.RegularHolidayHours) as LegalHollidayHours, " +
                "sum(C.SpecialHolidayHours) as SpeciallHollidayHours, " +
                "count(C.EmployeeID) as TotalWorkDays, " +
                "((sum(TotalHours)-sum(C.OvertimeHours))*B.BasicRate)+((sum(C.OvertimeHours)*B.BasicRate)+((sum(C.OvertimeHours)*B.BasicRate)*0.30)) + ((sum(C.RegularHolidayHours)* B.BasicRate)+ ((sum(C.SpecialHolidayHours) * B.BasicRate) * 0.30)) as GrossPay , " +
                "sum(C.Late) as TotalLateHours , sum(C.UndertimeHours) as TotalUnderTime , " +
                "0 as SSSContribution , " +
                "0 as PAGIBIGContribution , " +
                "0 as PHILHEALTHContribution , " +
                "D.OtherDeduction as OtherDeduction , " +
                "0 as NetPay, null " +
                "from EmployeeInfo as A " +
                "left join Position as B " +
                "on A.PositionID = B.PositionID " +
                "left join AttendanceSheet as C " +
                "on A.EmployeeID = C.EmployeeID " +
                "left join Deductions as D " +
                "on A.EmployeeID = D.EmployeeID " +
                "where Date Between CONVERT(datetime, '" + dtpFrom.Text + "', 100) and CONVERT(datetime, '" + dtpTo.Text + "', 100)" +
                " group by A.EmployeeID,A.EmployeeFullName, B.PositionName,B.BasicRate,D.SSSContribution,D.PagIbigContribution,D.PhilHealthContribution,D.OtherDeduction,D.TotalDeductions";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            sssclass.getSSSRange();
        }
    }
}