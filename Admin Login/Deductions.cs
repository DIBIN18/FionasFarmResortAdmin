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
        Loan loan = new Loan();
        SSSRangeClass sssclass = new SSSRangeClass();
        SqlCommandBuilder cmbl;
        String ValueHolder,EmpID;
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
        public void getDeductions()
        {

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                checkContrib();
                string query = "select * from PayrollReport " +
                        " where EmployeeName = '" + txtName.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dts = new DataTable();
                adapter.Fill(dts);
                try
                {
                    tbWorkHours.Text = dts.Rows[0][4].ToString();                 
                    tbPLeaveDays.Text = dts.Rows[0][10].ToString();
                    tbBasicGross.Text = dts.Rows[0][5].ToString();
                    tbSSS.Text = dts.Rows[0][14].ToString();
                    tbPAGIBIG.Text = dts.Rows[0][15].ToString();
                    tbPHILHEALTH.Text = dts.Rows[0][16].ToString();
                    tbTAX.Text = dts.Rows[0][17].ToString();
                    tbOtherDeduction.Text = dts.Rows[0][18].ToString();
                    double total = Convert.ToDouble(tbSSS.Text) + Convert.ToDouble(tbPAGIBIG.Text) + Convert.ToDouble(tbPHILHEALTH.Text) + Convert.ToDouble(tbTAX.Text) + Convert.ToDouble(tbOtherDeduction.Text);
                    tbTotal.Text = total.ToString("n2");              
                }
                catch (Exception ex)
                {
                    tbWorkHours.Text = "00";
                    tbPLeaveDays.Text = "00";
                    tbBasicGross.Text = "0.00";
                    tbSSS.Text = "0.00";
                    tbPAGIBIG.Text = "0.00";
                    tbPHILHEALTH.Text = "0.00";
                    tbTAX.Text = "0.00";
                    tbOtherDeduction.Text = "0.00";
                    tbTotal.Text = "0.00";
                }
            }
            
        }
        public void getDescription()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                checkContrib();
                string query = "select Description from OtherDeductions where EmployeeID = " + EmpID+" and StartDate " +
                               "between convert(datetime, '"+dtp_From.Text+"', 100) and convert(datetime, '"+dtp_To.Text+"', 100)";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dts = new DataTable();
                adapter.Fill(dts);
                for (int i = 0; i< dts.Rows.Count; i++)
                {                  
                    tbDescription.AppendText(dts.Rows[i][0].ToString() + Environment.NewLine);
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbDescription.Text = "";
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                //txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tagadelete();
                tagaInsertPayrollReport();
                getDeductions();
                loan.EmpID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                loan.Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                EmpID = loan.EmpID;
                getDescription();
                //tagadelete();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                // Do nothing
                // Column headers click catcher
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
                    string query = "select  format(max(convert(datetime,DateTo,100)), 'MMMM dd, yyyy') from PayrollReportHistory";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    Date = data.Rows[0][0].ToString();
                }
                catch (Exception ex) { }
                return Date;
            }
        }
        private void Deductions_Load(object sender, EventArgs e)
        {
            getLastPayrollDate();
            try
            {
                try
                {   
                    DateTimePicker dtp = new DateTimePicker();
                    dtp.Text = getLastPayrollDate().ToString();
                    dtp_From.Value = dtp.Value.AddDays(1);
                    tbFrom.Text = dtp_From.Text;
                    string date = dtp_From.Value.AddDays(15).ToString("MMMM dd, yyyy");
                    string cdate = "0";
                    for (int i = 0; i < date.Length; i++)
                    {
                        if (date[i] == ' ')
                        {
                            cdate = date.Substring(i + 1, 2);
                            i = i + 10;
                        }
                    }
                    if (cdate == "31")
                    {
                        dtp_To.Value = dtp_From.Value.AddDays(15);
                    }
                    else
                    {
                        dtp_To.Value = dtp_From.Value.AddDays(14);
                    }
                    tbTo.Text = dtp_To.Text; 
                }
                catch (Exception ex) { /*MessageBox.Show(ex.Message);*/ }
                sssclass.dateFrom = dtp_From.Text;
                sssclass.dateTo = dtp_To.Text;
                SqlConnection conn = new SqlConnection(login.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select E.EmployeeID, E.EmployeeFullName, D.DepartmentName , P.PositionName FROM EmployeeInfo AS E " +
                    "JOIN Department AS D ON E.DepartmentID = D.DepartmentID JOIN Position AS P ON E.PositionID = P.PositionID where E.Status = 'Active'", conn);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dts = new DataTable();
                sqlDataAdapter.Fill(dts);
                tagadelete();
                tagaInsertPayrollReport();
                // Column font
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                // Row font
                this.dataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dataGridView1.DataSource = dts;
                txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                loan.Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                EmpID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                loan.EmpID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                getDeductions();
                getDescription();
            }
            catch (Exception ex) { /*MessageBox.Show(ex.Message);*/ }
        }
        public void checkContrib()
        {
            string date = dtp_To.Text;
            string day_To = "0";
            for (int i = 0; i < date.Length; i++)
            {
                if (date[i] == ' ')
                {
                    day_To = date.Substring(i + 1, 2);
                    i = i + 10;
                }
            }
            if (day_To == "15")
            {
                cbSSS.Checked = true;
                cbPAGIBIG.Checked = false;
                cbPHILHEALTH.Checked = false;
            }
            else if (day_To == "30")
            {
                cbSSS.Checked = false;
                cbPAGIBIG.Checked = true;
                cbPHILHEALTH.Checked = true;
            }

        }
 
        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            if (string.IsNullOrEmpty(tb_Search.Text))
            {
                SqlCommand cmd = new SqlCommand(
                "Select E.EmployeeID, E.EmployeeFullName, D.DepartmentName , P.PositionName " +
                "FROM EmployeeInfo AS E " +
                "JOIN Department AS D ON E.DepartmentID = D.DepartmentID " +
                "JOIN Position AS P ON E.PositionID = P.PositionID " +
                "WHERE E.Status='Active'", connection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dts = new DataTable();
                sqlDataAdapter.Fill(dts);
                dataGridView1.DataSource = dts;
            }
            else if (tb_Search.Focused)
            {
                SqlCommand cmd = new SqlCommand(
                "Select E.EmployeeID, E.EmployeeFullName, D.DepartmentName , P.PositionName " +
                "FROM EmployeeInfo AS E JOIN Department AS D ON E.DepartmentID = D.DepartmentID " +
                "JOIN Position AS P ON E.PositionID = P.PositionID " +
                "WHERE E.Status='Active' " +
                "AND E.EmployeeFullName LIKE '%" + tb_Search.Text + "%'", connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dts = new DataTable();
                sqlDataAdapter.Fill(dts);
                dataGridView1.DataSource = dts;
            }
        }
        private void btnAddOtherDeduction(object sender, EventArgs e)
        {
            loan.ShowDialog();
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
            sssclass.dateFrom = dtp_From.Text;
            sssclass.dateTo = dtp_To.Text;
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sssclass.ComputeGrossPay(), connection);
            command.ExecuteNonQuery();
            sssclass.getSSSRange();
        }

        private void cbSSS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSSS.Checked)
            {
                sssclass.SSSON = "ON";
                cbPHILHEALTH.Checked = false;
                cbPAGIBIG.Checked = false;
            }
            else
            {
                sssclass.SSSON = "OFF";
                cbPHILHEALTH.Checked = true;
                cbPAGIBIG.Checked = true;
            }
        }

        private void cbPAGIBIG_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPAGIBIG.Checked)
            {
                sssclass.PAGIBIGON = "ON";
                cbPHILHEALTH.Checked = true;
                cbSSS.Checked = false;
            }
            else
            {
                sssclass.PAGIBIGON = "OFF";
                cbPHILHEALTH.Checked = false;
                cbSSS.Checked = true;
            }
        }

        private void cbPHILHEALTH_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPHILHEALTH.Checked)
            {
                sssclass.PHILHEALTHON = "ON";
                cbPAGIBIG.Checked = true;
                cbSSS.Checked = false;
            }
            else
            {
                sssclass.PHILHEALTHON = "OFF";
                cbPAGIBIG.Checked = false;
                cbSSS.Checked = true;
            }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ValueHolder = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Menu menu = (Menu)Application.OpenForms["Menu"];
                menu.Text = "Fiona's Farm and Resort - Deduction Records";
                menu.Deductions_ValueHolder(ValueHolder);
                menu.Menu_Load(menu, EventArgs.Empty);

                /*using (SqlConnection connection = new SqlConnection(login.connectionString))
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
                }*/
            }
            catch (Exception ex) { }
        }

        private void dtp_From_ValueChanged(object sender, EventArgs e)
        {
            tagadelete();
            tagaInsertPayrollReport();
            getDeductions();
        }

        private void dtp_To_ValueChanged(object sender, EventArgs e)
        {
            tagadelete();
            tagaInsertPayrollReport();
            getDeductions();
        }

        // Clear search text when clicked
        private void tb_Search_Click(object sender, EventArgs e)
        {
            tb_Search.Text = string.Empty;
        }


    }
}