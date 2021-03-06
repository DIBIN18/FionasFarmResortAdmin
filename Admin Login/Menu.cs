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
        public Menu(string name)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
            AdminName.Text = name;
            timer1.Start();
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
        private void Btn_AdvancedDayOffs_Click(object sender, EventArgs e)
        {
            Text = TitleExtension = "Fiona's Farm and Resort - Advanced Day-Offs";
            TitleLabel.Text = TitleExtension;
            AdvancedDay_Offs advanceddayoffs = new AdvancedDay_Offs
            {
                TopLevel = false
            };
            pnl_Content.Controls.Add(advanceddayoffs);
            advanceddayoffs.BringToFront();
            advanceddayoffs.Show();
        }
        private void Btn_PositionAndDepartments_Click(object sender, EventArgs e)
        {
            Text = TitleExtension = "Fiona's Farm and Resort - Position and Departments";
            TitleLabel.Text = TitleExtension;
            PositionAndDepartments positionanddepartments = new PositionAndDepartments 
            { 
                TopLevel = false 
            };
            pnl_Content.Controls.Add(positionanddepartments);
            positionanddepartments.BringToFront();
            positionanddepartments.Show();
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
            PayrollReport payrollreport = new PayrollReport(AdminName.Text)
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
        }
        internal void Menu_Load(object sender, EventArgs e)
        {
            if (Text == "Fiona's Farm and Resort - Holiday Settings")
            {
                TitleExtension = "Fiona's Farm and Resort - Holiday Settings";
                TitleLabel.Text = TitleExtension;
                HolidaySettings holidaysettings = new HolidaySettings()
                {
                    TopLevel = false
                };
                pnl_Content.Controls.Add(holidaysettings);
                holidaysettings.BringToFront();
                holidaysettings.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Payroll Report")
            {
                Btn_PayrollReport_Click(sender, e);
            }
            else
            {
                Btn_Dashboard_Click(sender, e);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.Text == "Fiona's Farm and Resort - Employee List")
            {
                this.label3.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                this.label1.Font = new Font("Century Gothic", 14);
                this.label4.Font = new Font("Century Gothic", 14);
                this.label5.Font = new Font("Century Gothic", 14);
                this.label7.Font = new Font("Century Gothic", 14);
                this.label8.Font = new Font("Century Gothic", 14);
                this.label9.Font = new Font("Century Gothic", 14);
                this.label10.Font = new Font("Century Gothic", 14);
            }
            else if(this.Text == "Fiona's Farm and Resort - Advanced Day-Offs")
            {
                this.label4.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                this.label1.Font = new Font("Century Gothic", 14);
                this.label3.Font = new Font("Century Gothic", 14);
                this.label5.Font = new Font("Century Gothic", 14);
                this.label7.Font = new Font("Century Gothic", 14);
                this.label8.Font = new Font("Century Gothic", 14);
                this.label9.Font = new Font("Century Gothic", 14);
                this.label10.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Fiona's Farm and Resort - Position and Departments")
            {
                this.label5.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                this.label1.Font = new Font("Century Gothic", 14);
                this.label4.Font = new Font("Century Gothic", 14);
                this.label3.Font = new Font("Century Gothic", 14);
                this.label7.Font = new Font("Century Gothic", 14);
                this.label8.Font = new Font("Century Gothic", 14);
                this.label9.Font = new Font("Century Gothic", 14);
                this.label10.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Fiona's Farm and Resort - Deductions")
            {
                this.label7.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                this.label1.Font = new Font("Century Gothic", 14);
                this.label4.Font = new Font("Century Gothic", 14);
                this.label5.Font = new Font("Century Gothic", 14);
                this.label3.Font = new Font("Century Gothic", 14);
                this.label8.Font = new Font("Century Gothic", 14);
                this.label9.Font = new Font("Century Gothic", 14);
                this.label10.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Fiona's Farm and Resort - Attendance Record")
            {
                this.label8.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                this.label1.Font = new Font("Century Gothic", 14);
                this.label4.Font = new Font("Century Gothic", 14);
                this.label5.Font = new Font("Century Gothic", 14);
                this.label7.Font = new Font("Century Gothic", 14);
                this.label3.Font = new Font("Century Gothic", 14);
                this.label9.Font = new Font("Century Gothic", 14);
                this.label10.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Fiona's Farm and Resort - Payroll Report")
            {
                this.label9.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                this.label1.Font = new Font("Century Gothic", 14);
                this.label4.Font = new Font("Century Gothic", 14);
                this.label5.Font = new Font("Century Gothic", 14);
                this.label7.Font = new Font("Century Gothic", 14);
                this.label8.Font = new Font("Century Gothic", 14);
                this.label3.Font = new Font("Century Gothic", 14);
                this.label10.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Settings")
            {
                this.label10.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                this.label1.Font = new Font("Century Gothic", 14);
                this.label4.Font = new Font("Century Gothic", 14);
                this.label5.Font = new Font("Century Gothic", 14);
                this.label7.Font = new Font("Century Gothic", 14);
                this.label8.Font = new Font("Century Gothic", 14);
                this.label9.Font = new Font("Century Gothic", 14);
                this.label3.Font = new Font("Century Gothic", 14);
            }
            else if (this.Text == "Fiona's Farm and Resort - Dashboard")
            {
                this.label1.Font = new Font("Century Gothic", 14, FontStyle.Bold);
                this.label3.Font = new Font("Century Gothic", 14);
                this.label4.Font = new Font("Century Gothic", 14);
                this.label5.Font = new Font("Century Gothic", 14);
                this.label7.Font = new Font("Century Gothic", 14);
                this.label8.Font = new Font("Century Gothic", 14);
                this.label9.Font = new Font("Century Gothic", 14);
                this.label10.Font = new Font("Century Gothic", 14);
            }
        }
    }
}