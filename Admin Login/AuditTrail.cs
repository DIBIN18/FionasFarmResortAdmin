using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Login
{
    internal class AuditTrail
    {

        Login login = new Login();
        public string adminname;
        Menu menu = (Menu)Application.OpenForms["Menu"];
       
        //EMPLOYEELIST
        public void AuditAddEmployee(string employeeId, string employee_name)
        {
            
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "EmployeeList";
            string Description = "Add New Employee, " + employee_name + " (" + employeeId + ")";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        //LEAVE
        public void AuditApplyLeave(string employee_name, string employee_id, string leave_type, string start_date, string end_date)
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Leave";
            string Description = 
                "Applied " + leave_type + " to " + employee_name + " (" + employee_id + ") from " + start_date + " to " + end_date;
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditRemoveLeave(string leave_type, string employee_name, string employee_id, string date)
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Leave";
            string Description = 
                "Cancelled " + leave_type + " for " + employee_name + " (" + employee_id + ") on " + date;
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }

        //DEPARTMENT AND POSITION
        public void AuditAddDepartment(string department_name)
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Department And Position";
            string Description = 
                "Add New Department, " + department_name;
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditAddPosition(string position_name, string basic_rate, string department)
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Department And Position";
            string Description = 
                "Add New Position, " + position_name + " with a Basic Rate of " + basic_rate + "/hour on the Department, " + department;
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditEditDepartment(string old_dept, string new_dept)
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Department And Position";
            string Description = 
                "Edited Department name of " + old_dept + " to " + new_dept;
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditEditPosition(string old_pos, string old_rate, string new_pos, string new_rate)
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Department And Position";
            string Description = 
                "Edited Position, " + old_pos + " with a Basic Rate of" + old_rate + "/hour " +
                "to " + new_pos + " with a basic rate of " + new_rate + " /hour";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }

        public void AuditDeleteDepartment(string dept)
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Department And Position";
            string Description = "Delete Department, " + dept;
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditDeletePosition(string pos)
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Department And Position";
            string Description = "Delete Position " + pos;
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }

        //ATTENDANCE RECORD
        public void AuditAddAttendance(string emp, string start, string end, string date)
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Attendance Record";
            string Description = 
                "Add Manual Attendance for " + emp + " on " + date + ", Time in: " + start + ", Time Out: " + end;
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditEditAttendance(string emp, string olddate, string oldstart, string oldend, string new_date, string new_start, string new_end)
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Attendance Record";
            string Description = 
                "Edited Attendance of " + emp + " on " + olddate + " Time In: " + oldstart + " Time Out: " + oldend +
                ", To Date: " + new_date + " Time In: " + new_start + " Time Out: " + new_end;
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        //SCHEDULES
        public void AuditAddOverTime(string selected, string start, string end)
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Schedules";
            string Description = 
                "Added OverTime to " + selected + ", from " + start + ", to " + end;
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditRemoveOverTime(string selected, string start, string end)
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Schedules";
            string Description =
                "Removed OverTime to " + selected + ", from " + start + ", to " + end;
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditAddSingleSchedule()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Schedules";
            string Description = "Add Single Schedule";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditRemoveSingleSchedule()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Schedules";
            string Description = "Remove Single Schedule";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }

        //DEDUCTIONS

        public void AuditAddDeduction()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Deductions";
            string Description = "Add Deductions";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }

        //HOLIDAY SETTINGS
        public void AuditAddHoliday()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Holiday Settings";
            string Description = "add New Holiday";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditRemoveHoliday()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Holiday Settings";
            string Description = "Remove Holiday";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        //SETTINGS
        public void AuditAddNewUser(string user_type, string user_name)
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");
            string Module = "Settings";
            string Description = 
                "Added a new User named, '" + user_type + "' and a username of '" + user_name + "'";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            adminname = menu.getAdminName();
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
    }
}
