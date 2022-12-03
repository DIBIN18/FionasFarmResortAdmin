using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Admin_Login
{
    public partial class EditUser : Form
    {
        Login login = new Login();

        string dashboard, employee_list, leave, dept_pos, deductions, attendance_record, payroll_report, holiday_setting, settings, schedules;

        public EditUser()
        {
            InitializeComponent();
        }

        //Dropshadow
        private const int CS_DropShadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }

        private void Btn_Back(object sender, EventArgs e)
        {
                this.Close();
        }

        private void BtnSave(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();

                if (DashBoard.Checked)
                {
                    dashboard = "1";
                }
                else
                {
                    dashboard = "0";
                }

                if (EmployeeList.Checked)
                {
                    employee_list = "1";
                }
                else
                {
                    employee_list = "0";
                }

                if (Leave.Checked)
                {
                    leave = "1";
                }
                else
                {
                    leave = "0";
                }

                if (DepartmentPosition.Checked)
                {
                    dept_pos = "1";
                }
                else
                {
                    dept_pos = "0";
                }

                if (Deductions.Checked)
                {
                    deductions = "1";
                }
                else
                {
                    deductions = "0";
                }

                if (AttendanceRecord.Checked)
                {
                    attendance_record = "1";
                }
                else
                {
                    attendance_record = "0";
                }

                if (PayrollReport.Checked)
                {
                    payroll_report = "1";
                }
                else
                {
                    payroll_report = "0";
                }

                if (HolidaySetting.Checked)
                {
                    holiday_setting = "1";
                }
                else
                {
                    holiday_setting = "0";
                }

                if (Setting.Checked)
                {
                    settings = "1";
                }
                else
                {
                    settings = "0";
                }

                if (Schedules.Checked)
                {
                    schedules = "1";
                }
                else
                {
                    schedules = "0";
                }

                string query = 
                    "UPDATE Users " +
                    "SET " +
                    "User_ = '" + cmbUserName.Text.ToString() + "', " +
                    "Username_ = '" + txtUser.Text.ToString() + "', " + 
                    "Password_ = '" + txtPass.Text.ToString() + "', " + 
                    "Dashboard = " + dashboard + ", " + 
                    "EmployeeList = " + employee_list + ", " + 
                    "Leave = " + leave + ", " + 
                    "DepartmentPosition = " + dept_pos + ", " +
                    "Deductions = " + deductions + ", " +
                    "AttendanceRecord = " + attendance_record + ", " +
                    "PayrollReport = " + payroll_report + ", " +
                    "HolidaySetting = " + holiday_setting + ", " +
                    "Settings = " + settings + ", " +
                    "Schedules = " + schedules + " " +
                    "WHERE UserID=" + lblUserID.Text.ToString();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Updated User");

                Settings s = new Settings();
                s.updateTable();

                Menu menu = (Menu)Application.OpenForms["Menu"];
                menu.Text = "Fiona's Farm and Resort - Settings";
                menu.Menu_Load(menu, EventArgs.Empty);

                this.Close();
            }
        }
    }
}
