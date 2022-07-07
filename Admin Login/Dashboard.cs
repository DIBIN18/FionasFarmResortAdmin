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
using System.Data.SqlClient;
namespace Admin_Login
{
    public partial class Dashboard : Form
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
        public string connectionString = "Data Source=DESKTOP-EHBRJVA\\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        string TitleExtension = "Dashboard";
        public Dashboard(string name)
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
        }
        private void btn_EmployeeList_Click(object sender, EventArgs e)
        {
            TitleExtension = "Employee List";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
        }
        private void btn_AdvancedDayOffs_Click(object sender, EventArgs e)
        {
            TitleExtension = "Advanced Day-Offs";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
        }
        private void btn_PositionAndDepartments_Click(object sender, EventArgs e)
        {
            TitleExtension = "Position and Departments";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
        }
        private void btn_Deductions_Click(object sender, EventArgs e)
        {
            TitleExtension = "Deductions";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
        }
        private void btn_AttendanceRecord_Click(object sender, EventArgs e)
        {
            TitleExtension = "Attendance Record";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
        }
        private void btn_PayrollReport_Click(object sender, EventArgs e)
        {
            TitleExtension = "Payroll Report";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
        }
        private void btn_Settings_Click(object sender, EventArgs e)
        {
            TitleExtension = "Settings";
            TitleLabel.Text = "Fiona's Farm and Resort - " + TitleExtension;
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            tmr_DateAndTime.Start();
        }
        private void tmr_DateAndTime_Tick(object sender, EventArgs e)
        {
            lbl_Date.Text = DateTime.Now.ToLongDateString();
            lbl_Time.Text = DateTime.Now.ToLongTimeString();
        }
    }
}