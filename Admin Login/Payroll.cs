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
            dtpI_From.Text = sssclass.dateFrom;
            dtpI_To.Text = sssclass.dateTo;
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
                    string position = data.Rows[0][2].ToString() + " ₱" + data.Rows[0][3].ToString() + "/Hour";
                    txtPosition.Text = position;
                    txtRegularHours.Text = data.Rows[0][4].ToString();
                    txtRegularPay.Text = data.Rows[0][5].ToString();
                    double otmin =  (Convert.ToDouble(data.Rows[0][6].ToString())/1.30)/Convert.ToDouble(data.Rows[0][3].ToString());
                    txtOvertimeHrs.Text = otmin.ToString();
                    txtOvertimePay.Text = data.Rows[0][6].ToString();
                    double rhHrs = (Convert.ToDouble(data.Rows[0][7].ToString())/(Convert.ToDouble(data.Rows[0][3].ToString())/60))/60;
                    txtRegularHolidayHrs.Text= rhHrs.ToString();
                    double Rholidaypay = Convert.ToDouble(data.Rows[0][7].ToString());
                    txtRHolidayPay.Text = Rholidaypay.ToString("n2");
                    double S_holiday = (Convert.ToDouble(data.Rows[0][8].ToString())/ Convert.ToDouble(data.Rows[0][3].ToString())/0.30);
                    txtSpecialHoliday.Text = S_holiday.ToString("n2");
                    double S_holidaypay = Convert.ToDouble(data.Rows[0][8].ToString());
                    txtSpHolidayPay.Text = S_holidaypay.ToString("n2");
                    txtLeavedays.Text = data.Rows[0][10].ToString();
                    double leavepay = (Convert.ToDouble(data.Rows[0][10].ToString())*8)* Convert.ToDouble(data.Rows[0][3].ToString());
                    txtLeavePay.Text = leavepay.ToString("n2");
                    txtGrossPay.Text = "₱" + data.Rows[0][11].ToString();
                    txtTardinessMins.Text = data.Rows[0][12].ToString();
                    double tardiness = Convert.ToDouble(data.Rows[0][12].ToString()) * (Convert.ToDouble(data.Rows[0][3].ToString()) / 60);
                    txtLateAmount.Text = tardiness.ToString("n2");
                    txtUnderTimeMin.Text = data.Rows[0][13].ToString();
                    double undertime = Convert.ToDouble(data.Rows[0][13].ToString()) * (Convert.ToDouble(data.Rows[0][3].ToString()) / 60);
                    txtUndertimeAmount.Text = undertime.ToString("n2");
                    txtSSS.Text = data.Rows[0][14].ToString();
                    txtPagIbig.Text = data.Rows[0][15].ToString();
                    txtPhilHealth.Text = data.Rows[0][16].ToString();
                    txtTaxAmount.Text = data.Rows[0][17].ToString();
                    txtOtherDeductions.Text = data.Rows[0][18].ToString();
                    txtNetPay.Text = "₱" + data.Rows[0][19].ToString();
                    double totaldeduct = Convert.ToDouble(data.Rows[0][14].ToString()) + Convert.ToDouble(data.Rows[0][15].ToString()) + Convert.ToDouble(data.Rows[0][16].ToString()) + Convert.ToDouble(data.Rows[0][17].ToString()) + Convert.ToDouble(data.Rows[0][18].ToString());
                    txtTotalDeduction.Text = totaldeduct.ToString("n2");
                }
                catch (Exception ex)
                {
                    txtRegularHours.Text = "";
                    txtOvertimeHrs.Text = "";
                    txtOvertimePay.Text = "";
                    txtRegularPay.Text = "";
                    txtRegularHolidayHrs.Text = "";
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
                    //Console.WriteLine("something wrong!");
                }
            }
        }
        public void tagaInsertPayrollReport()
        {
            sssclass.dateFrom = dtpI_From.Text;
            sssclass.dateTo = dtpI_To.Text;
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sssclass.ComputeGrossPay(), connection);
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