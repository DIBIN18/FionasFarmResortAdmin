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
            datefrom = dtpI_From.Text;
            tagadelete();
            tagaInsertPayrollReport();
            try
            {
                dtpI_To.Value = dtpI_From.Value.AddDays(14);
            }
            catch (Exception ex) { }
            getInfo();
        }

        private void dtpI_To_ValueChanged(object sender, EventArgs e)
        {
            tagadelete();
            tagaInsertPayrollReport();
            getInfo();
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
                    double regularhrs = Convert.ToDouble(data.Rows[0][4].ToString()) - Convert.ToDouble(data.Rows[0][5].ToString()) - Convert.ToDouble(data.Rows[0][6].ToString()) - Convert.ToDouble(data.Rows[0][7].ToString());
                    double regulaypay = regularhrs * Convert.ToDouble(data.Rows[0][3].ToString());
                    double overtimepay = Convert.ToDouble(data.Rows[0][5]) * (Convert.ToDouble(data.Rows[0][3]) * 1.30);
                    double regularholiday = Convert.ToDouble(data.Rows[0][6]);
                    double regularholidaypay = (Convert.ToDouble(data.Rows[0][3]) * Convert.ToDouble(data.Rows[0][6])) * 2;
                    double specialholidaypay = (Convert.ToDouble(data.Rows[0][3]) * Convert.ToDouble(data.Rows[0][6])) * 1.30;
                    double sss = Convert.ToDouble(data.Rows[0][12]);
                    double pagibig = Convert.ToDouble(data.Rows[0][13]);
                    double philhealth = Convert.ToDouble(data.Rows[0][14]);
                    double tax = Convert.ToDouble(data.Rows[0][15]);
                    double netpay = Convert.ToDouble(data.Rows[0][17]);
                    double totaldeduction = sss + pagibig + philhealth + tax;
                    double grosspay = Convert.ToDouble(data.Rows[0][9]);

                    txtRegularHours.Text = regularhrs.ToString();
                    txtOvertimeMins.Text = Convert.ToString(Convert.ToInt32(data.Rows[0][5]) * 60);
                    txtOvertimePay.Text = overtimepay.ToString("n2");
                    txtRegularPay.Text = regulaypay.ToString("n2");
                    txtRegularHoliday.Text = data.Rows[0][6].ToString();
                    txtRHolidayPay.Text = regularholidaypay.ToString("n2");
                    txtSpecialHoliday.Text = data.Rows[0][7].ToString();
                    txtSpHolidayPay.Text = specialholidaypay.ToString("n2");
                    txtGrossPay.Text = grosspay.ToString("n2");
                    txtTardinessMins.Text = Convert.ToString(Convert.ToInt32(data.Rows[0][10]) * 60);
                    txtUnderTimeMin.Text = Convert.ToString(Convert.ToInt32(data.Rows[0][11]) * 60);
                    txtSSS.Text = sss.ToString("n2");
                    txtPagIbig.Text = pagibig.ToString("n2");
                    txtPhilHealth.Text = philhealth.ToString("n2");
                    txtTaxAmount.Text = tax.ToString("n2");
                    txtTotalDeduction.Text = totaldeduction.ToString("n2");
                    txtNetPay.Text = netpay.ToString("n2");
                }catch (Exception ex)
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
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            string query = "insert into PayrollReport " +
                "select A.EmployeeID, A.EmployeeFullName as Employee, B.PositionName as Position, B.BasicRate , " +
                "sum(RegularHours) + sum(OvertimeHours) as TotalHours , " +
                "sum(C.OvertimeHours) as OverTimeHours , " +
                "sum(C.RegularHolidayHours) as LegalHollidayHours, " +
                "sum(C.SpecialHolidayHours) as SpeciallHollidayHours, " +
                "count(C.EmployeeID) as TotalWorkDays, " +
                "(sum(RegularHours)*B.BasicRate)+((sum(C.OvertimeHours)*B.BasicRate)+((sum(C.OvertimeHours)*B.BasicRate)*0.30)) + ((sum(C.RegularHolidayHours)* B.BasicRate)+ ((sum(C.SpecialHolidayHours) * B.BasicRate) * 0.30)) as GrossPay , " +
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
                "where Date Between CONVERT(datetime, '" + dtpI_From.Text + "', 100) and CONVERT(datetime, '" + dtpI_To.Text + "', 100)" +
                " group by A.EmployeeID,A.EmployeeFullName, B.PositionName,B.BasicRate,D.SSSContribution,D.PagIbigContribution,D.PhilHealthContribution,D.OtherDeduction,D.TotalDeductions";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            sssclass.getSSSRange();
            Console.WriteLine();
        }
        public void tagadelete()
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("delete from PayrollReport", connection);
            command.ExecuteNonQuery();
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
            getInfo();
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
            getInfo();
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
            getInfo();
        }
        private void dtpI_From_ValueChanged(object sender, EventArgs e)
        {
            tagadelete();
            tagaInsertPayrollReport();
            try
            {
                dtpI_To.Value = dtpI_From.Value.AddDays(14);
                dtpI_To.MinDate = dtpI_From.Value;
            }
            catch (Exception ex) { }
            getInfo();
        }
    }
}
