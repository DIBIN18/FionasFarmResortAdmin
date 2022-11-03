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
        SSSRangeClass sssclass = new SSSRangeClass();
        SqlCommandBuilder cmbl;
        bool addOtherDucution = false;
           
        public Deductions()
        {
            InitializeComponent();
            //cbSSS.Checked = true;
            //cbPAGIBIG.Checked = true;
            //cbPHILHEALTH.Checked = true;
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
            //SqlConnection conn = new SqlConnection(login.connectionString);
            //SqlCommand cmd = new SqlCommand("select p.BasicRate From Position AS p JOIN EmployeeInfo AS e ON p.PositionID = e.PositionID Where e.EmployeeID  = " + dataGridView1.Rows[e.RowIndex].Cells[0].Value, conn);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);

            //lblRate.Text = dt.Rows[0][0].ToString();
            try
            {
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();
                    string query = "select * from Deductions where EmployeeID = " + dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                    SqlCommand cmd2 = new SqlCommand(query, connection);
                    SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                    cmd2.ExecuteNonQuery();
                    DataTable dts2 = new DataTable();
                    sqlDataAdapter2.Fill(dts2);

                    // Column font
                    this.dgvDeductions.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                    // Row font
                    this.dgvDeductions.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                    dgvDeductions.DataSource = dts2;

                    lblName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    tagadelete();
                    tagaInsertPayrollReport();                  
                    getDeductions();
                }
            }
            catch(Exception ex) { }
        }
        public void getDeductions()
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            string query = "select EmployeeName, (TotalHours-OverTimeHours) * BasicRate as BasicGrossPay, TotalWorkDays, SSSContribution, PAGIBIGContribution, PHILHEALTHContribution, Tax, OtherDeduction from PayrollReport " +
                    " where EmployeeName = '" + lblName.Text + "'";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dts = new DataTable();
            sqlDataAdapter.Fill(dts);
            try
            {
                double basicgross = Convert.ToDouble(dts.Rows[0][1].ToString());

                lblworkDays.Text = dts.Rows[0][2].ToString();
                lblBasicGross.Text = basicgross.ToString("n2");
                lblSSS.Text = dts.Rows[0][3].ToString();
                lblPAGIBIG.Text = dts.Rows[0][4].ToString();
                lblPHILHEALTH.Text = dts.Rows[0][5].ToString();
                lblTax.Text = dts.Rows[0][6].ToString();

            }
            catch (Exception ex)
            {
                lblworkDays.Text = "";
                lblBasicGross.Text = "";
                lblSSS.Text = "";
                lblPAGIBIG.Text = "";
                lblPHILHEALTH.Text = "";
                lblTax.Text = "";
            }
        }
        private void Deductions_Load(object sender, EventArgs e)
        {
            try
            {
                dtp_From.Text = getLastPayrollDate().ToString();
                dtp_From.Value = dtp_From.Value.AddDays(1);
                SqlConnection conn = new SqlConnection(login.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select E.EmployeeID, E.EmployeeFullName, D.DepartmentName , P.PositionName FROM EmployeeInfo AS E " +
                    "JOIN Department AS D ON E.DepartmentID = D.DepartmentID JOIN Position AS P ON E.PositionID = P.PositionID", conn);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dts = new DataTable();
                sqlDataAdapter.Fill(dts);

                // Column font
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                // Row font
                this.dataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dataGridView1.DataSource = dts;
            }
            catch(Exception ex) { }
           
        }
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                //connection.Open();
                //dataGridView1.CurrentRow.Selected = true;

                //SqlCommand sqlCommand = new SqlCommand("UPDATE Deductions set  OtherDeduction = @otherdeduction, TotalDeductions = SSSContribution + PagIbigContribution + PhilHealthContribution + @otherdeduction where EmployeeID = " + dataGridView1.CurrentRow.Cells[0].Value, connection);
                
                //sqlCommand.Parameters.AddWithValue("@otherdeduction", Convert.ToDecimal(txtotherdeduction.Text));
                //sqlCommand.ExecuteNonQuery();
                
                //MessageBox.Show("Update Complete");
            
                //txtotherdeduction.Text = "";
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

        private void btnAddOtherDeduction_Click(object sender, EventArgs e)
        {
            if(addOtherDucution == false)
            {
                btnAddOtherDeduction.Text = "save";
                tbAddOtherDeduction.Visible = true;
                tbDescription.Enabled = true;
                addOtherDucution = true;
            }
            else
            {
                tbAddOtherDeduction.Visible = false;
                tbDescription.Enabled = false;
                addOtherDucution = false;
                btnAddOtherDeduction.Text = "add";
            }
        }
        public string getLastPayrollDate()
        {
            string Date = "0";
            Login login = new Login();
            SqlConnection connection = new SqlConnection(login.connectionString);
            {
                try
                {
                    connection.Open();
                    string query = "select  max(PayrollCoveredDate) from Deductions";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    Date = data.Rows[0][0].ToString().Substring(21);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return Date;
            }
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
                "0 as TAX, " +
                "D.OtherDeduction as OtherDeduction , " +
                "0 as NetPay, null " +
                "from EmployeeInfo as A " +
                "left join Position as B " +
                "on A.PositionID = B.PositionID " +
                "left join AttendanceSheet as C " +
                "on A.EmployeeID = C.EmployeeID " +
                "left join Deductions as D " +
                "on A.EmployeeID = D.EmployeeID " +
                "where Date Between CONVERT(datetime, '" + dtp_From.Text + "', 100) and CONVERT(datetime, '" + dtp_To.Text + "', 100)" +
                " group by A.EmployeeID,A.EmployeeFullName, B.PositionName,B.BasicRate,D.SSSContribution,D.PagIbigContribution,D.PhilHealthContribution,D.OtherDeduction,D.TotalDeductions";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            sssclass.getSSSRange();
        }

        private void cbSSS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSSS.Checked)
            {
                sssclass.SSSON = "ON";
            }
            else
            {
                sssclass.SSSON = "OFF";
            }
            tagadelete();
            tagaInsertPayrollReport();
            getDeductions();
            tagadelete();
        }

        private void cbPAGIBIG_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPAGIBIG.Checked)
            {
                sssclass.PAGIBIGON = "ON";
            }
            else
            {
                sssclass.PAGIBIGON = "OFF";
            }
            tagadelete();
            tagaInsertPayrollReport();
            getDeductions();
            tagadelete();
        }

        private void cbPHILHEALTH_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPHILHEALTH.Checked)
            {
                sssclass.PHILHEALTHON = "ON";
            }
            else
            {
                sssclass.PHILHEALTHON = "OFF";
            }
            tagadelete();
            tagaInsertPayrollReport();
            getDeductions();
            tagadelete();
        }
    }
}