using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        static string datefrom, employeeid, employeename, department, position, address, sss, pagibig, philhealth, email, maritalstatus, contact, 
            datehired, gender, age, birthdate, employmenttype, allowedot, accumulated, sickleavecredits, vacationleavecredits, sched, deductionsvalueholder;
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
            Login login = new Login();
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
            AdminName.Text = name;
            t_Highlighter.Start();
            bool istrue = true;
            bool isFalse = false;
            SqlConnection con = new SqlConnection(login.connectionString);
            SqlCommand cmd = new SqlCommand("Select * from Users Where User_ = '" + name + "'", con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string dashboard = dataTable.Rows[0][4].ToString();
            string EmployeeList = dataTable.Rows[0][5].ToString();
            string Leave = dataTable.Rows[0][6].ToString();
            string DepartmentAndPosition = dataTable.Rows[0][7].ToString();
            string Deductions = dataTable.Rows[0][8].ToString();
            string AttendanceRecord = dataTable.Rows[0][9].ToString();
            string PayrollReport = dataTable.Rows[0][10].ToString();
            string HolidaySetting = dataTable.Rows[0][11].ToString();
            string Settings = dataTable.Rows[0][12].ToString();
            if (name == dataTable.Rows[0][1].ToString())
            {
                label3.Enabled = false;
                label1.Enabled = false;
                pictureBox3.Enabled = false;
                pictureBox7.Enabled = false;
                pictureBox9.Enabled = false;
                pictureBox11.Enabled = false;
                pictureBox13.Enabled = false;
                pictureBox15.Enabled = false;
                pictureBox1.Enabled = false;
                label4.Enabled = false;
                label5.Enabled = false;
                label7.Enabled = false;
                label8.Enabled = false;
                label9.Enabled = false;
                label13.Enabled = false;
                label10.Enabled = false; //settings
                //DASHBOARD
                if (dashboard.ToString() == istrue.ToString())
                {
                    label1.Enabled = true;
                    pictureBox3.Enabled = true;
                }
                else
                {
                    label1.Enabled = false;
                    pictureBox3.Enabled = false;
                }
                //EmployeeList
                if (EmployeeList.ToString() == istrue.ToString())
                {
                    label3.Enabled = true;
                    pictureBox5.Enabled = true;
                }
                else
                {
                    label3.Enabled = false;
                    pictureBox5.Enabled = false;
                }
                //Leave
                if (Leave.ToString() == istrue.ToString())
                {
                    label4.Enabled = true;
                    pictureBox7.Enabled = true;
                }
                else
                {
                    label4.Enabled = false;
                    pictureBox7.Enabled = false;
                }
                //DepartmentPosition
                if (DepartmentAndPosition.ToString() == istrue.ToString())
                {
                    label5.Enabled = true;
                    pictureBox9.Enabled = true;
                }
                else
                {
                    label5.Enabled = false;
                    pictureBox9.Enabled = false;
                }
                //Deductions
                if (Deductions.ToString() == istrue.ToString())
                {
                    label7.Enabled = true;
                    pictureBox11.Enabled = true;
                }
                else
                {

                    label7.Enabled = false;
                    pictureBox11.Enabled = false;
                }
                //AttendanceRecord
                if (AttendanceRecord.ToString() == istrue.ToString())
                {
                    label8.Enabled = true;
                 
                }
                else
                {

                    label8.Enabled = false;
                
                }
                //PayrolLReport
                if (PayrollReport.ToString() == istrue.ToString())
                {
                    label9.Enabled = true;
                    pictureBox15.Enabled = true;
                }
                else
                {

                    label9.Enabled = false;
                    pictureBox15.Enabled = false;

                }
                //HolidaySetting
                if (HolidaySetting.ToString() == istrue.ToString())
                {
                    label13.Enabled = true;
                    pictureBox1.Enabled = true;
                }
                else
                {

                    label13.Enabled = false;
                    pictureBox1.Enabled = false;

                }
                //HolidaySetting
                if (Settings.ToString() == istrue.ToString())
                {
                    label10.Enabled = true;
                    
                }
                else
                {

                    label10.Enabled = false;
                }
            }

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
            payrollreport.dtp_From.Text = datefrom;
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
        public void PayrollReport_ValueHolder(string _EmployeeID, string _EmployeeName, string _Department, string _Position, string _DateFrom)
        {
            employeeid = _EmployeeID;
            employeename = _EmployeeName;
            department = _Department;
            position = _Position;
            datefrom = _DateFrom;
            //typeofleave = _TypeofLeave;
        }
        public void Leave_ValueHolder(string _EmployeeID, string _EmployeeName, string _Department, string _Position, string _DateFrom, string _SickLeaveCredits, string _VacationLeaveCredits)
        {
            employeeid = _EmployeeID;
            employeename = _EmployeeName;
            department = _Department;
            position = _Position;
            sched = _DateFrom;
            sickleavecredits = _SickLeaveCredits;
            vacationleavecredits = _VacationLeaveCredits;
        }
        public void Payroll_ValueHolder(string _DateFrom)
        {
            datefrom = _DateFrom;
        }
        public void EmployeeList_ValueHolder(string _EmployeeID, string _EmployeeName, string _Address, string _SSS, 
            string _PagIbig, string _PhilHealth, string _Email, string _MarialStatus, string _Contact, string _DateHired, 
            string _Gender, string _Age, string _BirthDate, string _Department, string _Position, string _EmploymentType, 
            string _AllowedOT, string _Accumulated, string _SickLeaveCredits, string _VacationLeaveCredits)
        {
            employeeid = _EmployeeID;
            employeename = _EmployeeName;
            address = _Address;
            sss = _SSS;
            pagibig = _PagIbig;
            philhealth = _PhilHealth;
            email = _Email;
            maritalstatus = _MarialStatus;
            contact = _Contact;
            datehired = _DateHired;
            gender = _Gender;
            age = _Age;
            birthdate = _BirthDate;
            department = _Department;
            position = _Position;
            employmenttype = _EmploymentType;
            allowedot = _AllowedOT;
            accumulated = _Accumulated;
            sickleavecredits = _SickLeaveCredits;
            vacationleavecredits = _VacationLeaveCredits;
        }
        public void Deductions_ValueHolder(string _DeductionsValueHolder)
        {
            deductionsvalueholder = _DeductionsValueHolder;
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
                payroll.dtpI_From.Text = datefrom;
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
                leave.txtSchedule.Text = sched;
                leave.txtSLeaveCredits.Text = sickleavecredits;
                leave.txtVLeaveCredits.Text = vacationleavecredits;
                pnl_Content.Controls.Add(leave);
                leave.BringToFront();
                leave.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Add Attendance")
            {
                TitleExtension = "Fiona's Farm and Resort - Add Attendance";
                TitleLabel.Text = TitleExtension;
                AddAttendance addAttendance = new AddAttendance();
                {
                    addAttendance.TopLevel = false;
                };
                pnl_Content.Controls.Add(addAttendance);
                addAttendance.BringToFront();
                addAttendance.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Attendance Record")
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
            else if (Text == "Fiona's Farm and Resort - Deduction Records")
            {
                Text = TitleExtension = "Fiona's Farm and Resort - Deduction Records";
                TitleLabel.Text = TitleExtension;
                DeductionRecords deductionrecords = new DeductionRecords
                {
                    TopLevel = false
                };
                pnl_Content.Controls.Add(deductionrecords);
                deductionrecords.lblValueHolder.Text = deductionsvalueholder;
                deductionrecords.BringToFront();
                deductionrecords.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Applied Leave List")
            {
                TitleExtension = "Fiona's Farm and Resort - Applied Leave List";
                TitleLabel.Text = TitleExtension;
                AppliedLeaveList appliedLeaveList = new AppliedLeaveList();
                {
                    appliedLeaveList.TopLevel = false;
                };
                pnl_Content.Controls.Add(appliedLeaveList);
                appliedLeaveList.BringToFront();
                appliedLeaveList.Show();
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
            /*Text = TitleExtension = "Fiona's Farm and Resort - Loan";
            TitleLabel.Text = TitleExtension;
            Loan loan = new Loan
            {
                TopLevel = false
            };
            pnl_Content.Controls.Add(loan);
            loan.BringToFront();
            loan.Show();*/
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
                //label14.Font = new Font("Century Gothic", 14);
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
                //label14.Font = new Font("Century Gothic", 14);
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
                //label14.Font = new Font("Century Gothic", 14);
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
                //label14.Font = new Font("Century Gothic", 14);
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
                //label14.Font = new Font("Century Gothic", 14);
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
                //label14.Font = new Font("Century Gothic", 14);
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
                //label14.Font = new Font("Century Gothic", 14);
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
                //label14.Font = new Font("Century Gothic", 14);
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
                //label14.Font = new Font("Century Gothic", 14);
            }
            /*else if (this.Text == "Fiona's Farm and Resort - Loan")
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
            }*/
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