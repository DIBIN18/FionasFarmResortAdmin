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
    
    public partial class EmployeeProfile: Form
    {
        Login login = new Login();
        double GrossSalary, TotalWorkHoursIncome, RegularHollidayIncome, SpecialNonWorkingHollidayIncome, TotalNightDifferentialIncome, TotalOverTimeIncome;
        public EmployeeProfile()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
        private void EmployeeProfile_Load(object sender, EventArgs e)
        {

        }
        

        public void getGrossSalary()
        {
            GrossSalary = TotalWorkHoursIncome + RegularHollidayIncome + SpecialNonWorkingHollidayIncome + TotalNightDifferentialIncome + TotalOverTimeIncome;
            Console.WriteLine(GrossSalary);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getWorkHoursIncome();
            getRegularHollidayIncome();
            getSpecialNonWorkingHollidayIncome();
            getNightDifferentialIncome();
            getGrossSalary();
            Console.WriteLine(GrossSalary);
        }

        public void getWorkHoursIncome()
        {
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            //Compute the total Work hours - the hollidays work hours * BasicRate
            SqlCommand cmd = new SqlCommand("Select  TotalRecordHours * BasicRate from Payroll", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            TotalWorkHoursIncome = Convert.ToInt32(dt.Rows[0][0]);
            conn.Open();
        }
        public void getRegularHollidayIncome()
        {
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            //compute the total income of regular hollidays
            SqlCommand cmd2 = new SqlCommand("Select  (TotalRegularHollidayHours * 2) * BasicRate  from Payroll", conn);
            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
            conn.Close();
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            RegularHollidayIncome = Convert.ToInt32(dt2.Rows[0][0]);
            conn.Open();
        }
        public void getSpecialNonWorkingHollidayIncome()
        {
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            //compute the total income of Special Non-working hollidays
            SqlCommand cmd3 = new SqlCommand("Select  (TotalSpecialNonWorkingHollidayHours * BasicRate) * 0.3  from Payroll", conn);
            SqlDataAdapter adapter3 = new SqlDataAdapter(cmd3);
            cmd3.ExecuteNonQuery();
            conn.Close();
            DataTable dt3 = new DataTable();
            adapter3.Fill(dt3);
            SpecialNonWorkingHollidayIncome = Convert.ToInt32(dt3.Rows[0][0]);
            conn.Open();
        }
        public void getNightDifferentialIncome()
        {
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            //compute the total income of Night Differential
            SqlCommand cmd4 = new SqlCommand("Select  BasicRate * 0.1 * TotalNightDifferentialHours  from Payroll", conn);
            SqlDataAdapter adapter4 = new SqlDataAdapter(cmd4);
            cmd4.ExecuteNonQuery();
            conn.Close();
            DataTable dt4 = new DataTable();
            adapter4.Fill(dt4);
            TotalNightDifferentialIncome = Convert.ToInt32(dt4.Rows[0][0]);
        }
        public void getOverTimeIncome()
        {
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            //compute the total income Overtime
            //if (regularWorkDays = true)
            SqlCommand cmd5 = new SqlCommand("Select  TotalOvertimeHours * ((BasicRate * 0.25) + BasicRate)  from Payroll", conn);
            SqlDataAdapter adapter5 = new SqlDataAdapter(cmd5);
            cmd5.ExecuteNonQuery();
            conn.Close();
            DataTable dt5 = new DataTable();
            adapter5.Fill(dt5);
            TotalOverTimeIncome = Convert.ToInt32(dt5.Rows[0][0]);
        }


    }
}
