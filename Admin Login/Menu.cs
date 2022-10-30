using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Admin_Login
{
    public partial class Menu : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int right,
            int top,
            int bottom,
            int width,
            int height
            );
        string TitleExtension;
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
        public Menu(string name)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
            AdminName.Text = name;
            t_Highlighter.Start();
        }
        private void Btn_SignOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            Dispose();
            login.ShowDialog();
        }
        private void Btn_Dashboard_Click(object sender, EventArgs e)
        {
            Text = TitleExtension = "Fiona's Farm and Resort - Dashboard";
            TitleLabel.Text = TitleExtension;
            Dashboard dashboard = new Dashboard
            {
                TopLevel = false
            };
            pnl_Content.Controls.Add(dashboard);
            dashboard.BringToFront();
            dashboard.Show();
        }
        private void Btn_EmployeeList_Click(object sender, EventArgs e)
        {
            Text = TitleExtension = "Fiona's Farm and Resort - Employee List";
            TitleLabel.Text = TitleExtension;
            EmployeeList employeelist = new EmployeeList
            {
                TopLevel = false
            };
            pnl_Content.Controls.Add(employeelist);
            employeelist.BringToFront();
            employeelist.Show();
        }
        private void Btn_Deductions_Click(object sender, EventArgs e)
        {
            Text = TitleExtension = "Fiona's Farm and Resort - Deductions";
            TitleLabel.Text = TitleExtension;
            Deductions deductions = new Deductions 
            { 
                TopLevel = false 
            };
            pnl_Content.Controls.Add(deductions);
            deductions.BringToFront();
            deductions.Show();
        }
        private void Btn_AttendanceRecord_Click(object sender, EventArgs e)
        {
            Text = TitleExtension = "Fiona's Farm and Resort - Attendance Record";
            TitleLabel.Text = TitleExtension;
            AttendanceRecord attendancerecord = new AttendanceRecord 
            { 
                TopLevel = false 
            };
            pnl_Content.Controls.Add(attendancerecord);
            attendancerecord.BringToFront();
            attendancerecord.Show();
        }
        private void Btn_PayrollReport_Click(object sender, EventArgs e)
        {
            Text = TitleExtension = "Fiona's Farm and Resort - Payroll Report";
            TitleLabel.Text = TitleExtension;
            PayrollReport payrollreport = new PayrollReport
            {
                TopLevel = false
            };
            pnl_Content.Controls.Add(payrollreport);
            payrollreport.BringToFront();
            payrollreport.Show();
        }
        private void Btn_Settings_Click(object sender, EventArgs e)
        {
            Text = TitleExtension = "Fiona's Farm and Resort - Settings";
            TitleLabel.Text = TitleExtension;
            Settings settings = new Settings
            {
                TopLevel = false
            };
            pnl_Content.Controls.Add(settings);
            settings.BringToFront();
            settings.Show();
        }
        static string employeeid, employeename, department, position;
        public void ValueHolder(string _EmployeeID, string _EmployeeName, string _Department, string _Position)
        {
            employeeid = _EmployeeID;
            employeename = _EmployeeName;
            department = _Department;
            position = _Position;
            //typeofleave = _TypeofLeave;
        }
        internal void Menu_Load(object sender, EventArgs e)
        {
            if (Text == "Fiona's Farm and Resort - Payroll")
            {
                TitleExtension = "Fiona's Farm and Resort - Payroll";
                TitleLabel.Text = TitleExtension;
                Payroll payroll = new Payroll()
                {
                    TopLevel = false
                };
                payroll.txtEmployeeID.Text = employeeid;
                payroll.txtEmployeeName.Text = employeename;
                payroll.txtDepartment.Text = department;
                payroll.txtPosition.Text = position;
                pnl_Content.Controls.Add(payroll);
                payroll.BringToFront();
                payroll.Show();
            }
            else if(Text == "Fiona's Farm and Resort - Add Employee")
            {
                TitleExtension = "Fiona's Farm and Resort - Add Employee";
                TitleLabel.Text = TitleExtension;
                AddEmployee addemployee = new AddEmployee()
                {
                    TopLevel = false
                };
                pnl_Content.Controls.Add(addemployee);
                addemployee.BringToFront();
                addemployee.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Archive Employee")
            {
                TitleExtension = "Fiona's Farm and Resort - Archive Employee";
                TitleLabel.Text = TitleExtension;
                ArchiveEmployee archiveemployee = new ArchiveEmployee()
                {
                    TopLevel = false
                };
                pnl_Content.Controls.Add(archiveemployee);
                archiveemployee.BringToFront();
                archiveemployee.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Add Department And Position")
            {
                TitleExtension = "Fiona's Farm and Resort - Add Department And Position";
                TitleLabel.Text = TitleExtension;
                AddDepartmentAndPosition adddepartmentandposition = new AddDepartmentAndPosition()
                {
                    TopLevel = false
                };
                pnl_Content.Controls.Add(adddepartmentandposition);
                adddepartmentandposition.BringToFront();
                adddepartmentandposition.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Edit Department And Position")
            {
                TitleExtension = "Fiona's Farm and Resort - Edit Department And Position";
                TitleLabel.Text = TitleExtension;
                EditDepartmentAndPosition editdepartmentandposition = new EditDepartmentAndPosition()
                {
                    TopLevel = false
                };
                pnl_Content.Controls.Add(editdepartmentandposition);
                editdepartmentandposition.BringToFront();
                editdepartmentandposition.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Leave Employee List")
            {
                TitleExtension = "Fiona's Farm and Resort - Leave Employee List";
                TitleLabel.Text = TitleExtension;
                LeaveEmployeeList leaveemployeelist = new LeaveEmployeeList()
                {
                    TopLevel = false
                };
                pnl_Content.Controls.Add(leaveemployeelist);
                leaveemployeelist.BringToFront();
                leaveemployeelist.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Leave")
            {
                TitleExtension = "Fiona's Farm and Resort - Leave";
                TitleLabel.Text = TitleExtension;
                Leave leave = new Leave()
                {
                    TopLevel = false
                };
                leave.txtEmployeeID.Text = employeeid;
                leave.txtEmployeeName.Text = employeename;
                leave.txtDepartment.Text = department;
                leave.txtPosition.Text = position;
                pnl_Content.Controls.Add(leave);
                leave.BringToFront();
                leave.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Payroll Report")
            {
                Btn_PayrollReport_Click(sender, e);
            }
            else if (Text == "Fiona's Farm and Resort - Employee List")
            {
                Btn_EmployeeList_Click(sender, e);
            }
            else if(Text == "Fiona's Farm and Resort - Department and Position")
            {
                Btn_DepartmentAndPosition_Click(sender, e);
            }
            else
            {
                Btn_Dashboard_Click(sender, e);
            }
        }
        private void btn_Loan_Click(object sender, EventArgs e)
        {
            Text = TitleExtension = "Fiona's Farm and Resort - Loan";
            TitleLabel.Text = TitleExtension;
            Loan loan = new Loan
            {
                TopLevel = false
            };
            pnl_Content.Controls.Add(loan);
            loan.BringToFront();
            loan.Show();
        }
        private void t_Highlighter_Tick(object sender, EventArgs e)
        {
            if (this.Text == "Fiona's Farm and Resort - Employee List")
            {
                label3.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                label1.Font = new Font("Century Gothic", 14);
                label4.Font = new Font("Century Gothic", 14);
                label5.Font = new Font("Century Gothic", 14);
                label7.Font = new Font("Century Gothic", 14);
                label8.Font = new Font("Century Gothic", 14);
                label9.Font = new Font("Century Gothic", 14);
                label10.Font = new Font("Century Gothic", 14);
                label13.Font = new Font("Century Gothic", 14);
                label14.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Fiona's Farm and Resort - Leave")
            {
                label4.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                label1.Font = new Font("Century Gothic", 14);
                label3.Font = new Font("Century Gothic", 14);
                label5.Font = new Font("Century Gothic", 14);
                label7.Font = new Font("Century Gothic", 14);
                label8.Font = new Font("Century Gothic", 14);
                label9.Font = new Font("Century Gothic", 14);
                label10.Font = new Font("Century Gothic", 14);
                label13.Font = new Font("Century Gothic", 14);
                label14.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Fiona's Farm and Resort - Department and Position")
            {
                label5.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                label1.Font = new Font("Century Gothic", 14);
                label4.Font = new Font("Century Gothic", 14);
                label3.Font = new Font("Century Gothic", 14);
                label7.Font = new Font("Century Gothic", 14);
                label8.Font = new Font("Century Gothic", 14);
                label9.Font = new Font("Century Gothic", 14);
                label10.Font = new Font("Century Gothic", 14);
                label13.Font = new Font("Century Gothic", 14);
                label14.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Fiona's Farm and Resort - Deductions")
            {
                label7.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                label1.Font = new Font("Century Gothic", 14);
                label4.Font = new Font("Century Gothic", 14);
                label5.Font = new Font("Century Gothic", 14);
                label3.Font = new Font("Century Gothic", 14);
                label8.Font = new Font("Century Gothic", 14);
                label9.Font = new Font("Century Gothic", 14);
                label10.Font = new Font("Century Gothic", 14);
                label13.Font = new Font("Century Gothic", 14);
                label14.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Fiona's Farm and Resort - Attendance Record")
            {
                label8.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                label1.Font = new Font("Century Gothic", 14);
                label4.Font = new Font("Century Gothic", 14);
                label5.Font = new Font("Century Gothic", 14);
                label7.Font = new Font("Century Gothic", 14);
                label3.Font = new Font("Century Gothic", 14);
                label9.Font = new Font("Century Gothic", 14);
                label10.Font = new Font("Century Gothic", 14);
                label13.Font = new Font("Century Gothic", 14);
                label14.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Fiona's Farm and Resort - Payroll Report")
            {
                label9.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                label1.Font = new Font("Century Gothic", 14);
                label4.Font = new Font("Century Gothic", 14);
                label5.Font = new Font("Century Gothic", 14);
                label7.Font = new Font("Century Gothic", 14);
                label8.Font = new Font("Century Gothic", 14);
                label3.Font = new Font("Century Gothic", 14);
                label10.Font = new Font("Century Gothic", 14);
                label13.Font = new Font("Century Gothic", 14);
                label14.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Settings")
            {
                label10.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                label1.Font = new Font("Century Gothic", 14);
                label4.Font = new Font("Century Gothic", 14);
                label5.Font = new Font("Century Gothic", 14);
                label7.Font = new Font("Century Gothic", 14);
                label8.Font = new Font("Century Gothic", 14);
                label9.Font = new Font("Century Gothic", 14);
                label3.Font = new Font("Century Gothic", 14);
                label13.Font = new Font("Century Gothic", 14);
                label14.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Fiona's Farm and Resort - Dashboard")
            {
                label1.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                label3.Font = new Font("Century Gothic", 14);
                label4.Font = new Font("Century Gothic", 14);
                label5.Font = new Font("Century Gothic", 14);
                label7.Font = new Font("Century Gothic", 14);
                label8.Font = new Font("Century Gothic", 14);
                label9.Font = new Font("Century Gothic", 14);
                label10.Font = new Font("Century Gothic", 14);
                label13.Font = new Font("Century Gothic", 14);
                label14.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Fiona's Farm and Resort - Holiday Settings")
            {
                label13.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                label1.Font = new Font("Century Gothic", 14);
                label3.Font = new Font("Century Gothic", 14);
                label4.Font = new Font("Century Gothic", 14);
                label5.Font = new Font("Century Gothic", 14);
                label7.Font = new Font("Century Gothic", 14);
                label8.Font = new Font("Century Gothic", 14);
                label9.Font = new Font("Century Gothic", 14);
                label10.Font = new Font("Century Gothic", 14);
                label14.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Fiona's Farm and Resort - Loan")
            {
                label14.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                label1.Font = new Font("Century Gothic", 14);
                label3.Font = new Font("Century Gothic", 14);
                label4.Font = new Font("Century Gothic", 14);
                label5.Font = new Font("Century Gothic", 14);
                label7.Font = new Font("Century Gothic", 14);
                label8.Font = new Font("Century Gothic", 14);
                label9.Font = new Font("Century Gothic", 14);
                label10.Font = new Font("Century Gothic", 14);
                label13.Font = new Font("Century Gothic", 14);
            }
        }
        private void Btn_Leave_Click(object sender, EventArgs e)
        {
            Text = TitleExtension = "Fiona's Farm and Resort - Leave";
            TitleLabel.Text = TitleExtension;
            Leave leave = new Leave
            {
                TopLevel = false
            };
            pnl_Content.Controls.Add(leave);
            leave.BringToFront();
            leave.Show();
        }
        private void Btn_DepartmentAndPosition_Click(object sender, EventArgs e)
        {
            Text = TitleExtension = "Fiona's Farm and Resort - Department and Position";
            TitleLabel.Text = TitleExtension;
            DepartmentAndPosition departmentandposition = new DepartmentAndPosition
            {
                TopLevel = false
            };
            pnl_Content.Controls.Add(departmentandposition);
            departmentandposition.BringToFront();
            departmentandposition.Show();
        }
        private void btn_HolidaySettings_Click(object sender, EventArgs e)
        {
            Text = TitleExtension = "Fiona's Farm and Resort - Holiday Settings";
            TitleLabel.Text = TitleExtension;
            HolidaySettings holidaysettings = new HolidaySettings
            {
                TopLevel = false
            };
            pnl_Content.Controls.Add(holidaysettings);
            holidaysettings.BringToFront();
            holidaysettings.Show();
        }
    }
}