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