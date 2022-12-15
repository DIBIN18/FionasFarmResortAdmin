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
        public string name;
        static string datefrom,dateto, employeeid, employeename, department, position, address, sss, pagibig, philhealth, email, maritalstatus, contact, 
            datehired, gender, age, birthdate, employmenttype, allowedot, accumulated, sickleavecredits, vacationleavecredits, sched, deductionsvalueholder;

        private void btn_Schedules_Click(object sender, EventArgs e)
        {
            Text = TitleExtension = "Fiona's Farm and Resort - Schedules";
            TitleLabel.Text = TitleExtension;
            Schedules schedules = new Schedules
            {
                TopLevel = false
            };
            pnl_Content.Controls.Add(schedules);
            schedules.BringToFront();
            schedules.Show();
            lbl_Schedules.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            lbl_Dashboard.Font = new Font("Century Gothic", 14);
            lbl_EmployeeList.Font = new Font("Century Gothic", 14);
            lbl_Leave.Font = new Font("Century Gothic", 14);
            lbl_DepartmentAndPosition.Font = new Font("Century Gothic", 14);
            lbl_Deductions.Font = new Font("Century Gothic", 14);
            lbl_AttendanceRecord.Font = new Font("Century Gothic", 14);
            lbl_PayrollReport.Font = new Font("Century Gothic", 14);
            lbl_Settings.Font = new Font("Century Gothic", 14);
            lbl_HolidaySettings.Font = new Font("Century Gothic", 14);
        
        }
        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        public Menu(string name)
        {
            Login login = new Login();
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
            AdminName.Text = name;
            bool istrue = true;
            SqlConnection con = new SqlConnection(login.connectionString);
            SqlCommand cmd = new SqlCommand("Select * from Users Where User_ = '" + name + "'", con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            AddEmployee ad = new AddEmployee();      
            sqlDataAdapter.Fill(dataTable);
            string dashboard = dataTable.Rows[0][4].ToString();
            string EmployeeList = dataTable.Rows[0][5].ToString();
            string Leave = dataTable.Rows[0][6].ToString();
            string DepartmentAndPosition = dataTable.Rows[0][7].ToString();
            string Deductions = dataTable.Rows[0][8].ToString();
            string AttendanceRecord = dataTable.Rows[0][9].ToString();
            string PayrollReport = dataTable.Rows[0][10].ToString();
            string HolidaySetting = dataTable.Rows[0][11].ToString();
            string Schedule = dataTable.Rows[0][13].ToString();
            string Settings = dataTable.Rows[0][12].ToString();
            
            if (name == dataTable.Rows[0][1].ToString())
            {
                //DASHBOARD
                if (dashboard.ToString() == istrue.ToString())
                {
                    pictureBox4.Enabled = true;
                    lbl_Dashboard.Enabled = true;
                    pictureBox3.Enabled = true;
                }
                else
                {
                    pictureBox4.Enabled = false;
                    lbl_Dashboard.Enabled = false;
                    pictureBox3.Enabled = false;
                }
                //EmployeeList
                if (EmployeeList.ToString() == istrue.ToString())
                {
                    pictureBox6.Enabled = true;
                    lbl_EmployeeList.Enabled = true;
                    pictureBox5.Enabled = true;
                }
                else
                {
                    pictureBox6.Enabled = false;
                    lbl_EmployeeList.Enabled = false;
                    pictureBox5.Enabled = false;
                }
                //Leave
                if (Leave.ToString() == istrue.ToString())
                {
                    pictureBox8.Enabled = true;
                    lbl_Leave.Enabled = true;
                    pictureBox7.Enabled = true;
                }
                else
                {
                    pictureBox8.Enabled = false;
                    lbl_Leave.Enabled = false;
                    pictureBox7.Enabled = false;
                }
                //DepartmentPosition
                if (DepartmentAndPosition.ToString() == istrue.ToString())
                {
                    pictureBox10.Enabled = true;
                    lbl_DepartmentAndPosition.Enabled = true;
                    pictureBox9.Enabled = true;
                }
                else
                {
                    pictureBox10.Enabled = false;
                    lbl_DepartmentAndPosition.Enabled = false;
                    pictureBox9.Enabled = false;
                }
                //Deductions
                if (Deductions.ToString() == istrue.ToString())
                {
                    pictureBox12.Enabled = true;
                    lbl_Deductions.Enabled = true;
                    pictureBox11.Enabled = true;
                }
                else
                {
                    pictureBox12.Enabled = false;
                    lbl_Deductions.Enabled = false;
                    pictureBox11.Enabled = false;
                }
                //AttendanceRecord
                if (AttendanceRecord.ToString() == istrue.ToString())
                {
                    lbl_AttendanceRecord.Enabled = true;
                    pictureBox13.Enabled = true;
                    pictureBox14.Enabled = true;
                }
                else
                {
                    pictureBox13.Enabled = false;
                    pictureBox14.Enabled = false;
                    lbl_AttendanceRecord.Enabled = false;
                
                }
                //PayrolLReport
                if (PayrollReport.ToString() == istrue.ToString())
                {
                    pictureBox16.Enabled = true;
                    lbl_PayrollReport.Enabled = true;
                    pictureBox15.Enabled = true;
                }
                else
                {
                    pictureBox16.Enabled = false;
                    lbl_PayrollReport.Enabled = false;
                    pictureBox15.Enabled = false;

                }
                //HolidaySetting
                if (HolidaySetting.ToString() == istrue.ToString())
                {
                    pictureBox2.Enabled = true;
                    lbl_HolidaySettings.Enabled = true;
                    pictureBox1.Enabled = true;
                }
                else
                {
                    pictureBox2.Enabled = false;
                    lbl_HolidaySettings.Enabled = false;
                    pictureBox1.Enabled = false;

                }
                //Setting
                if (Settings.ToString() == istrue.ToString())
                {
                    pictureBox17.Enabled = true;
                    lbl_Settings.Enabled = true;
                    
                }
                else
                {
                    pictureBox17.Enabled = false;
                    lbl_Settings.Enabled = false;
                }
                //Schedules
                if (Schedule.ToString() == istrue.ToString())
                {
                    pictureBox21.Enabled = true;
                    pictureBox22.Enabled = true;
                    lbl_Schedules.Enabled = true;

                }
                else
                {
                    pictureBox22.Enabled = false;
                    pictureBox21.Enabled = false;
                    lbl_Schedules.Enabled = false;
                }
            }

        }
        public string getAdminName()
        {
            return AdminName.Text;
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
            lbl_Dashboard.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            lbl_EmployeeList.Font = new Font("Century Gothic", 14);
            lbl_Leave.Font = new Font("Century Gothic", 14);
            lbl_DepartmentAndPosition.Font = new Font("Century Gothic", 14);
            lbl_Deductions.Font = new Font("Century Gothic", 14);
            lbl_AttendanceRecord.Font = new Font("Century Gothic", 14);
            lbl_PayrollReport.Font = new Font("Century Gothic", 14);
            lbl_Settings.Font = new Font("Century Gothic", 14);
            lbl_HolidaySettings.Font = new Font("Century Gothic", 14);
            lbl_Schedules.Font = new Font("Century Gothic", 14);
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
            lbl_EmployeeList.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            lbl_Dashboard.Font = new Font("Century Gothic", 14);
            lbl_Leave.Font = new Font("Century Gothic", 14);
            lbl_DepartmentAndPosition.Font = new Font("Century Gothic", 14);
            lbl_Deductions.Font = new Font("Century Gothic", 14);
            lbl_AttendanceRecord.Font = new Font("Century Gothic", 14);
            lbl_PayrollReport.Font = new Font("Century Gothic", 14);
            lbl_Settings.Font = new Font("Century Gothic", 14);
            lbl_HolidaySettings.Font = new Font("Century Gothic", 14);
            lbl_Schedules.Font = new Font("Century Gothic", 14);
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
            lbl_Deductions.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            lbl_Dashboard.Font = new Font("Century Gothic", 14);
            lbl_Leave.Font = new Font("Century Gothic", 14);
            lbl_DepartmentAndPosition.Font = new Font("Century Gothic", 14);
            lbl_EmployeeList.Font = new Font("Century Gothic", 14);
            lbl_AttendanceRecord.Font = new Font("Century Gothic", 14);
            lbl_PayrollReport.Font = new Font("Century Gothic", 14);
            lbl_Settings.Font = new Font("Century Gothic", 14);
            lbl_HolidaySettings.Font = new Font("Century Gothic", 14);
            lbl_Schedules.Font = new Font("Century Gothic", 14);
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
            lbl_AttendanceRecord.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            lbl_Dashboard.Font = new Font("Century Gothic", 14);
            lbl_Leave.Font = new Font("Century Gothic", 14);
            lbl_DepartmentAndPosition.Font = new Font("Century Gothic", 14);
            lbl_Deductions.Font = new Font("Century Gothic", 14);
            lbl_EmployeeList.Font = new Font("Century Gothic", 14);
            lbl_PayrollReport.Font = new Font("Century Gothic", 14);
            lbl_Settings.Font = new Font("Century Gothic", 14);
            lbl_HolidaySettings.Font = new Font("Century Gothic", 14);
            lbl_Schedules.Font = new Font("Century Gothic", 14);
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
            lbl_PayrollReport.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            lbl_Dashboard.Font = new Font("Century Gothic", 14);
            lbl_Leave.Font = new Font("Century Gothic", 14);
            lbl_DepartmentAndPosition.Font = new Font("Century Gothic", 14);
            lbl_Deductions.Font = new Font("Century Gothic", 14);
            lbl_AttendanceRecord.Font = new Font("Century Gothic", 14);
            lbl_EmployeeList.Font = new Font("Century Gothic", 14);
            lbl_Settings.Font = new Font("Century Gothic", 14);
            lbl_HolidaySettings.Font = new Font("Century Gothic", 14);
            lbl_Schedules.Font = new Font("Century Gothic", 14);
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
            lbl_Settings.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            lbl_Dashboard.Font = new Font("Century Gothic", 14);
            lbl_Leave.Font = new Font("Century Gothic", 14);
            lbl_DepartmentAndPosition.Font = new Font("Century Gothic", 14);
            lbl_Deductions.Font = new Font("Century Gothic", 14);
            lbl_AttendanceRecord.Font = new Font("Century Gothic", 14);
            lbl_PayrollReport.Font = new Font("Century Gothic", 14);
            lbl_EmployeeList.Font = new Font("Century Gothic", 14);
            lbl_HolidaySettings.Font = new Font("Century Gothic", 14);
            lbl_Schedules.Font = new Font("Century Gothic", 14);
        }
        public void PayrollReport_ValueHolder(string _EmployeeID, string _EmployeeName, string _Department, string _Position, string _DateFrom, string _DateTo)
        {
            employeeid = _EmployeeID;
            employeename = _EmployeeName;
            department = _Department;
            position = _Position;
            datefrom = _DateFrom;
            dateto = _DateTo;
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
                payroll.lblFrom.Text = datefrom;
                payroll.lblTo.Text = dateto;
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
            else if (Text == "Fiona's Farm and Resort - Leave Dates List")
            {
                TitleExtension = "Fiona's Farm and Resort - Leave Dates List";
                TitleLabel.Text = TitleExtension;
                LeaveListDates appliedLeaveList = new LeaveListDates();
                {
                    appliedLeaveList.TopLevel = false;
                };
                pnl_Content.Controls.Add(appliedLeaveList);
                appliedLeaveList.BringToFront();
                appliedLeaveList.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Schedule Overtime")
            {
                TitleExtension = "Fiona's Farm and Resort - Schedule Overtime";
                TitleLabel.Text = TitleExtension;
                OvertimeDates overtimeDates = new OvertimeDates();
                {
                    overtimeDates.TopLevel = false;
                };
                pnl_Content.Controls.Add(overtimeDates);
                overtimeDates.BringToFront();
                overtimeDates.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Schedules")
            {
                TitleExtension = "Fiona's Farm and Resort - Schedules";
                TitleLabel.Text = TitleExtension;
                Schedules schedules = new Schedules();
                {
                    schedules.TopLevel = false;
                };
                pnl_Content.Controls.Add(schedules);
                schedules.BringToFront();
                schedules.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Overtime Lists")
            {
                TitleExtension = "Fiona's Farm and Resort - Overtime Lists";
                TitleLabel.Text = TitleExtension;
                OvertimeList overtimeList = new OvertimeList();
                {
                    overtimeList.TopLevel = false;
                };
                pnl_Content.Controls.Add(overtimeList);
                overtimeList.BringToFront();
                overtimeList.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Single Schedule")
            {
                TitleExtension = "Fiona's Farm and Resort - Single Schedule";
                TitleLabel.Text = TitleExtension;
                AddSingleSchedule addSingleSchedule = new AddSingleSchedule();
                {
                    addSingleSchedule.TopLevel = false;
                };
                pnl_Content.Controls.Add(addSingleSchedule);
                addSingleSchedule.BringToFront();
                addSingleSchedule.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Single Schedule List")
            {
                TitleExtension = "Fiona's Farm and Resort - Single Schedule List";
                TitleLabel.Text = TitleExtension;
                ViewSingleSchedList viewSingleSchedList = new ViewSingleSchedList();
                {
                    viewSingleSchedList.TopLevel = false;
                };
                pnl_Content.Controls.Add(viewSingleSchedList);
                viewSingleSchedList.BringToFront();
                viewSingleSchedList.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Add Accumulated Day Off")
            {
                TitleExtension = "Fiona's Farm and Resort - Add Accumulated Day Off";
                TitleLabel.Text = TitleExtension;
                AdvanceDayOff advanceDayOff = new AdvanceDayOff();
                {
                    advanceDayOff.TopLevel = false;
                };
                pnl_Content.Controls.Add(advanceDayOff);
                advanceDayOff.BringToFront();
                advanceDayOff.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Accumulated Day Offs Lists")
            {
                TitleExtension = "Fiona's Farm and Resort - Accumulated Day Offs Lists";
                TitleLabel.Text = TitleExtension;
                AccumulatedDayOffsList accumulatedDayOffsList = new AccumulatedDayOffsList();
                {
                    accumulatedDayOffsList.TopLevel = false;
                };
                pnl_Content.Controls.Add(accumulatedDayOffsList);
                accumulatedDayOffsList.BringToFront();
                accumulatedDayOffsList.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Settings")
            {
                TitleExtension = "Fiona's Farm and Resort - Settings";
                TitleLabel.Text = TitleExtension;
                Settings settings = new Settings();
                {
                    settings.TopLevel = false;
                };
                pnl_Content.Controls.Add(settings);
                settings.BringToFront();
                settings.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Payroll History")
            {
                TitleExtension = "Fiona's Farm and Resort - Payroll History";
                TitleLabel.Text = TitleExtension;
                PayRollHistory payRollHistory = new PayRollHistory();
                {
                    payRollHistory.TopLevel = false;
                };
                pnl_Content.Controls.Add(payRollHistory);
                payRollHistory.BringToFront();
                payRollHistory.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Parental Leave List")
            {
                TitleExtension = "Fiona's Farm and Resort - Parental Leave List";
                TitleLabel.Text = TitleExtension;
                ViewParentalLeaveList viewParentalLeaveList = new ViewParentalLeaveList();
                {
                    viewParentalLeaveList.TopLevel = false;
                };
                pnl_Content.Controls.Add(viewParentalLeaveList);
                viewParentalLeaveList.BringToFront();
                viewParentalLeaveList.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Applied Overtimes")
            {
                TitleExtension = "Fiona's Farm and Resort - Applied Overtimes";
                TitleLabel.Text = TitleExtension;
                AppliedOvertimes appliedOvertimes = new AppliedOvertimes();
                {
                    appliedOvertimes.TopLevel = false;
                };
                pnl_Content.Controls.Add(appliedOvertimes);
                appliedOvertimes.BringToFront();
                appliedOvertimes.Show();
            }
            else if (Text == "Fiona's Farm and Resort - Payroll Report")
            {
                TitleExtension = "Fiona's Farm and Resort - Payroll Report";
                TitleLabel.Text = TitleExtension;
                PayrollReport payrollReport = new PayrollReport();
                {
                    payrollReport.TopLevel = false;
                };
                pnl_Content.Controls.Add(payrollReport);
                payrollReport.BringToFront();
                payrollReport.Show();
            }
            else if(Text == "Fiona's Farm and Resort - Leave")
            {
                Btn_Leave_Click(sender, e);
            }
            else if (Text == "Fiona's Farm and Resort - Deductions")
            {
                Btn_Deductions_Click(sender, e);
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
            lbl_Leave.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            lbl_Dashboard.Font = new Font("Century Gothic", 14);
            lbl_EmployeeList.Font = new Font("Century Gothic", 14);
            lbl_DepartmentAndPosition.Font = new Font("Century Gothic", 14);
            lbl_Deductions.Font = new Font("Century Gothic", 14);
            lbl_AttendanceRecord.Font = new Font("Century Gothic", 14);
            lbl_PayrollReport.Font = new Font("Century Gothic", 14);
            lbl_Settings.Font = new Font("Century Gothic", 14);
            lbl_HolidaySettings.Font = new Font("Century Gothic", 14);
            lbl_Schedules.Font = new Font("Century Gothic", 14);
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
            lbl_DepartmentAndPosition.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            lbl_Dashboard.Font = new Font("Century Gothic", 14);
            lbl_Leave.Font = new Font("Century Gothic", 14);
            lbl_EmployeeList.Font = new Font("Century Gothic", 14);
            lbl_Deductions.Font = new Font("Century Gothic", 14);
            lbl_AttendanceRecord.Font = new Font("Century Gothic", 14);
            lbl_PayrollReport.Font = new Font("Century Gothic", 14);
            lbl_Settings.Font = new Font("Century Gothic", 14);
            lbl_HolidaySettings.Font = new Font("Century Gothic", 14);
            lbl_Schedules.Font = new Font("Century Gothic", 14);
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
            lbl_HolidaySettings.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            lbl_Dashboard.Font = new Font("Century Gothic", 14);
            lbl_EmployeeList.Font = new Font("Century Gothic", 14);
            lbl_Leave.Font = new Font("Century Gothic", 14);
            lbl_DepartmentAndPosition.Font = new Font("Century Gothic", 14);
            lbl_Deductions.Font = new Font("Century Gothic", 14);
            lbl_AttendanceRecord.Font = new Font("Century Gothic", 14);
            lbl_PayrollReport.Font = new Font("Century Gothic", 14);
            lbl_Settings.Font = new Font("Century Gothic", 14);
            lbl_Schedules.Font = new Font("Century Gothic", 14);
        }
    }
}