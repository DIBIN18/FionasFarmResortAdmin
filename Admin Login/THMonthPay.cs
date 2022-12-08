using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Login
{
    internal class THMonthPay
    {
        public void get13month()
        {
            Login login = new Login();
            using (SqlConnection bonus = new SqlConnection(login.connectionString))
            {
                bonus.Open();
                 string InsertTHMonthPay = "INSERT INTO THMonthsSalary SELECT E.EmployeeID " +
                       ",DATEDIFF(MONTH ,convert(datetime, E.DateHired, 100),GETDATE()) AS CheckMonth" +
                        ",SUM((P.GrossSalary)/12) AS THMonthSalary" +
                        ", 'Allowed For 13month Pay' AS Description " +
                        "FROM PayrollReport AS P INNER JOIN EmployeeInfo AS E " +
                        "ON E.EmployeeID = P.EmployeeID " +
                        "WHERE NOT EXISTS (SELECT * FROM THMonthsSalary) " +
                        "GROUP BY E.EmployeeID,DateHired";
                    SqlCommand sqlCommand = new SqlCommand(InsertTHMonthPay, bonus);
                    sqlCommand.ExecuteNonQuery();
                
                bonus.Close();
            }

        }
    }
}
