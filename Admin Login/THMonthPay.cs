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
                string getInfo = "SELECT DateHired FROM EmployeeInfo";
                SqlCommand THmonth = new SqlCommand(getInfo, bonus);
                SqlDataAdapter THadapter = new SqlDataAdapter(THmonth);
                DataTable THtable = new DataTable();
                THadapter.Fill(THtable);

                string InsertTHMonthPay = "INSERT INTO THMonthsSalary SELECT E.EmployeeID" +
                        ",SUM((P.GrossSalary)/12) AS THMonthSalary FROM PayrollReport AS P " +
                        "INNER JOIN EmployeeInfo AS E ON E.EmployeeID = P.EmployeeID " +
                        "WHERE NOT EXISTS (SELECT * FROM THMonthsSalary) GROUP BY E.EmployeeID";
                SqlCommand sqlCommand = new SqlCommand(InsertTHMonthPay, bonus);
                sqlCommand.ExecuteNonQuery();

                //foreach (DataRow row in THtable.Rows)
                //{
                //    //int DateNow = Convert.ToInt32(DateTime.Now.ToString("MMMM dd,yyyy"));
                //    //int DateHired = Convert.ToInt32(row[0].ToString());
                //    //int result = DateHired - DateNow;

                //    //if (result > 1)
                //    //{
                //        string InsertTHMonthPay = "INSERT INTO THMonthsSalary SELECT E.EmployeeID" +
                //        ",SUM((P.GrossSalary)/12) AS THMonthSalary FROM PayrollReport AS P " +
                //        "INNER JOIN EmployeeInfo AS E ON E.EmployeeID = P.EmployeeID " +
                //        "WHERE NOT EXISTS (SELECT * FROM THMonthsSalary) GROUP BY E.EmployeeID";
                //        SqlCommand sqlCommand = new SqlCommand(InsertTHMonthPay, bonus);
                //        sqlCommand.ExecuteNonQuery();
                //    //}
                //    //else
                //    //{
                //    //    SqlCommand noTHmonth = new SqlCommand("INSERT INTO THMonthsSalary SELECT E.EmployeeID,0 AS THMonthSalary FROM PayrollReport AS P INNER JOIN EmployeeInfo AS E ON E.EmployeeID = P.EmployeeID WHERE NOT EXISTS (SELECT * FROM THMonthsSalary) GROUP BY E.EmployeeID;", bonus);
                //    //    noTHmonth.ExecuteNonQuery();
                //    //}
                //    //MessageBox.Show(DateHired);
                //}


                bonus.Close();
            }

        }
    }
}
