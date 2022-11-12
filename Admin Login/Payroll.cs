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
    public partial class Payroll : Form
    {
        Login login = new Login();
        SSSRangeClass sssclass = new SSSRangeClass();
        static string datefrom;
        bool setdateFrom = true;
        public Payroll()
        {
            InitializeComponent();
            sssclass.SSSON = "OFF";
            sssclass.PAGIBIGON = "OFF";
            sssclass.PHILHEALTHON = "OFF";
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Payroll Report";
            menu.Payroll_ValueHolder(datefrom);
            menu.Menu_Load(menu, EventArgs.Empty);
        }
        
        public void Payroll_Load(object sender, EventArgs e)
        {        
            dtpI_From.MaxDate = dtpI_To.Value;
            dtpI_To.MaxDate = DateTime.Now;
            try
            {
                dtpI_To.Value = DateTime.Now;
            }
            catch (Exception ex) { }
            if (setdateFrom == true)
            {
                try
                {                  
                    dtpI_From.Value = dtpI_To.Value.AddDays(-15);
                    setdateFrom = false;
                }
                catch (Exception ex) { }
            }
            sssclass.dateFrom = dtpI_From.Text;
            sssclass.dateTo = dtpI_To.Text;
            tagadelete();
            tagaInsertPayrollReport();
            getInfo();
        }
        private void dtpI_From_ValueChanged(object sender, EventArgs e)
        {
            sssclass.dateFrom = dtpI_From.Text;
            sssclass.dateTo = dtpI_To.Text;
            checkContrib();
            tagadelete();
            tagaInsertPayrollReport();
            getInfo();
            dtpI_From.MaxDate = dtpI_To.Value;
            dtpI_To.MaxDate = DateTime.Now;
        }
        private void dtpI_To_ValueChanged(object sender, EventArgs e)
        {
            sssclass.dateFrom = dtpI_From.Text;
            sssclass.dateTo = dtpI_To.Text;
            checkContrib();
            tagadelete();
            tagaInsertPayrollReport();
            getInfo();
            dtpI_From.MaxDate = dtpI_To.Value;
            dtpI_To.MaxDate = DateTime.Now;
        }
        public void checkContrib()
        {
            string date = dtpI_To.Text;
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
        public void getInfo()
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            {
                connection.Open();
                string query = "select * from PayrollReport where EmployeeID = " + txtEmployeeID.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                try
                {                   
                    double regularhrs = Convert.ToDouble(data.Rows[0][4].ToString());
                    double regulaypay = regularhrs * Convert.ToDouble(data.Rows[0][3].ToString());
                    double overtimepay = Convert.ToDouble(data.Rows[0][5]) * (Convert.ToDouble(data.Rows[0][3]) * 1.30);
                    double regularholiday = Convert.ToDouble(data.Rows[0][6]);
                    double regularholidaypay = (Convert.ToDouble(data.Rows[0][3]) * Convert.ToDouble(data.Rows[0][6])) ;
                    double specialholidaypay = (Convert.ToDouble(data.Rows[0][3]) * Convert.ToDouble(data.Rows[0][7])) * 0.30;                                      
                    double tax = Convert.ToDouble(data.Rows[0][16]);
                    double netpay = Convert.ToDouble(data.Rows[0][18]);
                    double grosspay = Convert.ToDouble(data.Rows[0][10]);
                    double leavepay = (Convert.ToDouble(data.Rows[0][9]) * 8) * Convert.ToDouble(data.Rows[0][3]);

                    txtRegularHours.Text = regularhrs.ToString();
                    txtOvertimeMins.Text = Convert.ToString(Convert.ToInt32(data.Rows[0][5]) * 60);
                    txtOvertimePay.Text = overtimepay.ToString("n2");
                    txtRegularPay.Text = regulaypay.ToString("n2");
                    txtRegularHoliday.Text = data.Rows[0][6].ToString();
                    txtRHolidayPay.Text = regularholidaypay.ToString("n2");
                    txtSpecialHoliday.Text = data.Rows[0][7].ToString();
                    txtSpHolidayPay.Text = specialholidaypay.ToString("n2");
                    txtGrossPay.Text = grosspay.ToString("n2");
                    if (string.IsNullOrEmpty(txtLeavedays.Text))
                    {
                        txtLeavedays.Text = "0";
                        txtLeavePay.Text = "0.00";
                    }
                    else
                    {
                        txtLeavedays.Text = data.Rows[0][9].ToString();
                        txtLeavePay.Text = leavepay.ToString("n2");
                    }
                    try
                    {
                        double sss = Convert.ToDouble(data.Rows[0][13]);
                        txtSSS.Text = sss.ToString("n2");
                        txtTotalDeduction.Text = Convert.ToString(sss + tax);
                    }
                    catch (Exception ex) { txtSSS.Text = "0.00"; }
                    try
                    {                     
                        double pagibig = Convert.ToDouble(data.Rows[0][14]);
                        txtPagIbig.Text = pagibig.ToString("n2");
                        double philhealth = Convert.ToDouble(data.Rows[0][15]);
                        txtPhilHealth.Text = philhealth.ToString("n2");
                        txtTotalDeduction.Text = Convert.ToString(pagibig + philhealth + tax);
                    }
                    catch (Exception ex) { txtPagIbig.Text = "0.00"; txtPhilHealth.Text = "0.00"; }
                    txtTardinessMins.Text = Convert.ToString(Convert.ToInt32(data.Rows[0][11]) * 60);
                    txtUnderTimeMin.Text = Convert.ToString(Convert.ToInt32(data.Rows[0][12]) * 60);                   
                    txtTaxAmount.Text = tax.ToString("n2");
                    
                    txtNetPay.Text = netpay.ToString("n2");
                }
                catch (Exception ex)
                {
                    txtRegularHours.Text = "";
                    txtOvertimeMins.Text = "";
                    txtOvertimePay.Text = "";
                    txtRegularPay.Text = "";
                    txtRegularHoliday.Text = "";
                    txtRHolidayPay.Text = "";
                    txtSpecialHoliday.Text = "";
                    txtSpHolidayPay.Text = "";
                    txtGrossPay.Text = "";
                    txtTardinessMins.Text = "";
                    txtUnderTimeMin.Text = "";
                    txtSSS.Text = "";
                    txtPagIbig.Text = "";
                    txtPhilHealth.Text = "";
                    txtTaxAmount.Text = "";
                    txtTotalDeduction.Text = "";
                    txtNetPay.Text = "";
                }
            }
        }
        public void tagaInsertPayrollReport()
        {
            string insert = "Insert into PayrollReport (EmployeeID,EmployeeName,Position,BasicRate,TotalHours,OverTimeHours,LegalHollidayHours,SpecialHollidayHours,TotalWorkDays,PaidLeaveDays,GrossSalary,TotalLate,TotalUnderTime ) ";
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(insert + getQuery(), connection);
            command.ExecuteNonQuery();
            sssclass.getSSSRange();
        }
        public void tagadelete()
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("delete from PayrollReport", connection);
            command.ExecuteNonQuery();
        }
        public string getQuery()
        {
            string command = "select A.EmployeeID, B.EmployeeFullName, C.PositionName, C.BasicRate , sum(A.RegularHours) + sum(A.OvertimeHours) as TotalHours," +
                " sum(A.OvertimeHours) as OverTime, sum(RegularHolidayHours) as LegalHolidayHours, sum(SpecialHolidayHours) as SpecialHolidayHours," +
                " count(A.EmployeeID) as TotalDays, 0 as PaidLeaveDays," +
                " (sum(A.RegularHours)*C.BasicRate)+((sum(A.OvertimeHours)*C.BasicRate)+((sum(A.OvertimeHours)*C.BasicRate)*0.30)) + ((sum(A.RegularHolidayHours)* C.BasicRate)+ ((sum(A.SpecialHolidayHours) * C.BasicRate) * 0.30)) as GrossPay, " +
                " sum(Late) as TotalLate, sum(UndertimeHours) as TotalUnderTimeHours " +
                " from AttendanceSheet as A inner join EmployeeInfo as B on A.EmployeeID = B.EmployeeID" +
                " inner join Position as C on B.PositionID = C.PositionID" +
                " where Date Between CONVERT(datetime, '" + dtpI_From.Text + "', 100) and CONVERT(datetime, '" + dtpI_To.Text + "', 100)" +
                " group by A.EmployeeID,B.EmployeeFullName,C.PositionName,C.BasicRate";
            return command;
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
            tagadelete();
            tagaInsertPayrollReport();
            getInfo();
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
            tagadelete();
            tagaInsertPayrollReport();
            getInfo();
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
            tagadelete();
            tagaInsertPayrollReport();
            getInfo();
        }
    }
}