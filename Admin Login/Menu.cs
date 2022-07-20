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
        string TitleExtension = "Dashboard";
        public Menu(string name)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
            AdminName.Text = name;
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
        }
        private void btn_SignOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
        }
        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            TitleExtension = "Dashboard";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
            Dashboard dashboard = new Dashboard();
            dashboard.TopLevel = false;
            pnl_Content.Controls.Add(dashboard);
            dashboard.BringToFront();
            dashboard.Show();
        }
        private void btn_EmployeeList_Click(object sender, EventArgs e)
        {
            TitleExtension = "Employee List";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
            EmployeeList employeelist = new EmployeeList();
            employeelist.TopLevel = false;
            pnl_Content.Controls.Add(employeelist);
            employeelist.BringToFront();
            employeelist.Show();
        }
        private void btn_AdvancedDayOffs_Click(object sender, EventArgs e)
        {
            TitleExtension = "Advanced Day-Offs";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
            AdvancedDay_Offs advanceddayoffs = new AdvancedDay_Offs();
            advanceddayoffs.TopLevel = false;
            pnl_Content.Controls.Add(advanceddayoffs);
            advanceddayoffs.BringToFront();
            advanceddayoffs.Show();
        }
        private void btn_PositionAndDepartments_Click(object sender, EventArgs e)
        {
            TitleExtension = "Position and Departments";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
            PositionAndDepartments positionanddepartments = new PositionAndDepartments();
            positionanddepartments.TopLevel = false;
            pnl_Content.Controls.Add(positionanddepartments);
            positionanddepartments.BringToFront();
            positionanddepartments.Show();
        }
        private void btn_Deductions_Click(object sender, EventArgs e)
        {
            TitleExtension = "Deductions";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
            Deductions deductions = new Deductions();
            deductions.TopLevel = false;
            pnl_Content.Controls.Add(deductions);
            deductions.BringToFront();
            deductions.Show();
        }
        private void btn_AttendanceRecord_Click(object sender, EventArgs e)
        {
            TitleExtension = "Attendance Record";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
            AttendanceRecord attendancerecord = new AttendanceRecord();
            attendancerecord.TopLevel = false;
            pnl_Content.Controls.Add(attendancerecord);
            attendancerecord.BringToFront();
            attendancerecord.Show();
        }
        private void btn_PayrollReport_Click(object sender, EventArgs e)
        {
            TitleExtension = "Payroll Report";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
            PayrollReport payrollreport = new PayrollReport();
            payrollreport.TopLevel = false;
            pnl_Content.Controls.Add(payrollreport);
            payrollreport.BringToFront();
            payrollreport.Show();
        }
        private void btn_Settings_Click(object sender, EventArgs e)
        {
            TitleExtension = "Settings";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.TopLevel = false;
            pnl_Content.Controls.Add(dashboard);
            dashboard.BringToFront();
            dashboard.Show();
        }
    }
}