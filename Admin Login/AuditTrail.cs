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
        public void AuditAddEmployee()
        {
            
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "EmployeeList";
            string Description = "Add New Employee";
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
        public void AuditApplyLeave()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Leave";
            string Description = "Applied Leave";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditRemoveLeave()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Leave";
            string Description = "Remove Leave";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }

        //DEPARTMENT AND POSITION
        public void AuditAddDepartment()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Department And Position";
            string Description = "Add New DepartmentName";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditAddPosition()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Department And Position";
            string Description = "Add New PositionName";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditEditDepartment()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Department And Position";
            string Description = "Edit DepartmentName";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditEditPosition()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Department And Position";
            string Description = "Edit PositionName";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }

        public void AuditDeleteDepartment()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Department And Position";
            string Description = "Delete DepartmentName";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditDeletePosition()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Department And Position";
            string Description = "Delete PositionName";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }

        //ATTENDANCE RECORD
        public void AuditAddAttendance()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Attendance Record";
            string Description = "Add Manual Attendance";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditEditAttendance()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Attendance Record";
            string Description = "Update Attendance";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        //SCHEDULES
        public void AuditAddOverTime()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Schedules";
            string Description = "Add OverTime";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        public void AuditRemoveOverTime()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Schedules";
            string Description = "Remove OverTime";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
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
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Schedules";
            string Description = "Add Single Schedule";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
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
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Schedules";
            string Description = "Remove Single Schedule";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
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
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Deductions";
            string Description = "Add Deductions";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
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
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Holiday Settings";
            string Description = "add New Holiday";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
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
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Holiday Settings";
            string Description = "Remove Holiday";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
        //SETTINGS
        public void AuditAddNewUser()
        {
            SqlConnection auditcon = new SqlConnection(login.connectionString);
            auditcon.Open();
            string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string Module = "Settings";
            string Description = "add New User";
            SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
            auditcommand.Parameters.AddWithValue("@UserName_", adminname);
            auditcommand.Parameters.AddWithValue("@Date", auditDate);
            auditcommand.Parameters.AddWithValue("@Module", Module);
            auditcommand.Parameters.AddWithValue("@Description", Description);
            auditcommand.ExecuteNonQuery();
            auditcon.Close();
        }
    }
}
