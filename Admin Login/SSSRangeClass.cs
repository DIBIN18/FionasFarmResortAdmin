using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Login
{
    internal class SSSRangeClass
    {
        Login login = new Login();
        double sssContributionEmployee = 0, sssContributionEmployer, pagibicontribEmployee = 0, pagibicontribEmployer = 0, PhilhealthContrib = 0, tax;
        public DataTable datatable = new DataTable();
        public string EmployeeID, SSSON, PAGIBIGON, PHILHEALTHON, dateFrom, dateTo, EmployeeIDComp;
        double getGrossPay = 0;
        public void getTAX()
        {
            //-------------------------------
            if(getGrossPay <= 10416.99)
            {
                tax = 0;
            }
            else if (getGrossPay > 10417 && getGrossPay < 16666)
            {
                tax = (getGrossPay - 10417) * 0.2;
            }
            else if (getGrossPay > 16667 && getGrossPay < 33332)
            {
                tax = ((getGrossPay - 16667) * 0.25) + 1250;
            }
            else if (getGrossPay > 33333 && getGrossPay < 83332)
            {
                tax = ((getGrossPay - 33333) * 0.30) + 5416.67;
            }
            else if (getGrossPay > 83333 && getGrossPay < 333332)
            {
                tax = ((getGrossPay - 83333) * 0.32) + 20416.67;
            }
            else if (getGrossPay > 333333)
            {
                tax = ((getGrossPay - 333333) * 0.35) + 100416.67;
            }
            //------------------------------
            //if (getGrossPay * 24 <= 250000)
            //{
            //    tax = 0;
            //}
            //else if(getGrossPay * 24 >= 250000.1 && getGrossPay * 24 <= 400000)
            //{
            //    tax = (((getGrossPay * 24) - 250000) * 0.2) / 24;
            //}
            //else if (getGrossPay * 24 >= 400000.1 && getGrossPay * 24 <= 800000)
            //{
            //    tax = (((getGrossPay * 24) - 400000) * 0.25) / 24;
            //}
            //else if (getGrossPay * 24 >= 800000.1 && getGrossPay * 24 <= 2000000)
            //{
            //    tax = (((getGrossPay * 24) - 800000) * 0.30) / 24;
            //}
            //else if (getGrossPay * 24 >= 2000000.1 && getGrossPay * 24 <= 8000000)
            //{
            //    tax = (((getGrossPay * 24) - 2000000) * 0.32) / 24;
            //}
            //else if (getGrossPay > 8000000)
            //{
            //    tax = (((getGrossPay * 24) - 8000000) * 0.35) / 24;
            //}
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "update PayrollReport set TAX = " + tax +
                    " where EmployeeID = " + EmployeeID;
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateEmployeeSSSColumn()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "UPDATE PayrollReport " +
                                "SET SSSContribution = " + sssContributionEmployee +
                                "where EmployeeID = " + EmployeeID;
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdatePagibigContributionColumn()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                if (getGrossPay >= 5000)
                {
                    pagibicontribEmployee = 100;
                    pagibicontribEmployer = 100;
                }
                else
                {
                    pagibicontribEmployee = getGrossPay * 0.02;
                    pagibicontribEmployer = getGrossPay * 0.02;                  
                }
                connection.Open();
                string query = "UPDATE PayrollReport " +
                                "SET PAGIBIGContribution = " + pagibicontribEmployee +
                                "where EmployeeID = " + EmployeeID;
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdatePhilhealthContributionColumn()
        {
            PhilhealthContrib = getGrossPay * 0.04;           
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "UPDATE PayrollReport " +
                                "SET PhilHealthContribution = " + PhilhealthContrib +
                                "where EmployeeID = " + EmployeeID;
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        public void getOtherDeduction()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "update PayrollReport " +
                               "set OtherDeduction = (select sum(DeductionPerCompensation) from OtherDeductions where EmployeeID = " + EmployeeID + ")" +
                               "where EmployeeID = " + EmployeeID;
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        public void getNetPay()
        {
            getOtherDeduction();
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "update PayrollReport "+
                               "set NetSalary = GrossSalary - (Coalesce(SSSContribution,0) + Coalesce(PAGIBIGContribution,0) + Coalesce(PHILHEALTHContribution,0) + Coalesce(TAX,0) + Coalesce(OtherDeduction,0)) from PayrollReport " +
                               "where EmployeeID = " + EmployeeID;
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        public void getPaidLeave()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();
                    string query = "Declare @i decimal (8,2) " +
                        " SELECT @i = (count(A.EmployeeID)*8)*B.BasicRate from LeavePay as A join EmployeeInfo as C on A.EmployeeID = C.EmployeeID left join Position as B on C.PositionID = B.PositionID " +
                        "where Date between CONVERT(datetime, '" + dateFrom + "', 100) and CONVERT(datetime, '" + dateTo + "', 100) and A.EmployeeID =" + EmployeeIDComp +
                        "group by B.BasicRate " +
                        " select Coalesce (@i + (sum(A.RegularHours)*C.BasicRate)+((sum(A.OvertimeHours)*C.BasicRate)+((sum(A.OvertimeHours)*C.BasicRate)*0.30)) + ((sum(A.RegularHolidayHours)* C.BasicRate)+ ((sum(A.SpecialHolidayHours) * C.BasicRate) * 0.30)), " +
                        " (sum(A.RegularHours)*C.BasicRate)+((sum(A.OvertimeHours)*C.BasicRate)+((sum(A.OvertimeHours)*C.BasicRate)*0.30)) + ((sum(A.RegularHolidayHours)* C.BasicRate)+ ((sum(A.SpecialHolidayHours) * C.BasicRate) * 0.30))) " +
                        " from AttendanceSheet as A inner join Position as C on A.PositionID = C.PositionID where EmployeeID = " + EmployeeIDComp +
                        " and Date between CONVERT(datetime, '" + dateFrom + "', 100) and CONVERT(datetime, '" + dateTo + "', 100) group by C.BasicRate";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    double update = Convert.ToDouble(data.Rows[0][0].ToString());
                    string query2 = "update PayrollReport " +
                                   "set GrossSalary = " + update +
                                   "where EmployeeID = " + EmployeeIDComp;
                    SqlCommand cmd = new SqlCommand(query2, connection);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex) { }
        }
        public void getLeaveDays()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = " update PayrollReport " +
                            " set PaidLeaveDays = (select coalesce (count(EmployeeID), 0) from LeavePay as B " +
                            " where Date between CONVERT(datetime, '" + dateFrom + "', 100) and CONVERT(datetime, '" + dateTo + "', 100) and " +
                            " PayrollReport.EmployeeID = B.EmployeeID group by EmployeeID)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        public void addleavePayToGrosspay()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "select EmployeeID, BasicRate * (TotalHours - OverTimeHours) from PayrollReport";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                foreach (DataRow dataRow in data.Rows)
                {
                    foreach (var GrossPay in dataRow.ItemArray)
                    {
                        if (GrossPay is DBNull)
                        {
                            getGrossPay = 0;
                        }
                        else
                        {
                            getGrossPay = Convert.ToDouble(GrossPay);
                            EmployeeID = dataRow.ItemArray[0].ToString();
                            if (string.IsNullOrEmpty(EmployeeIDComp))
                            {
                                EmployeeIDComp = EmployeeID;
                                getPaidLeave();
                            }
                            else if (EmployeeIDComp != EmployeeID)
                            {
                                EmployeeIDComp = EmployeeID;
                                getPaidLeave();
                            }
                            else
                            {
                                getPaidLeave();
                            }
                        }
                    }
                }
            }
                
        }
        public void getSSSRange()
        {
            getLeaveDays();
            addleavePayToGrosspay();
            PayrollReport payrollReport = new PayrollReport();
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "select EmployeeID, BasicRate * coalesce(((TotalHours-OverTimeHours)+(PaidLeaveDays*8)), TotalHours) from PayrollReport";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
               
                foreach (DataRow dataRow in data.Rows)
                {
                    foreach (var GrossPay in dataRow.ItemArray)
                    {
                        if (GrossPay is DBNull)
                        {
                            getGrossPay = 0;
                        }
                        else
                        {
                            getGrossPay = Convert.ToDouble(GrossPay);
                            EmployeeID = dataRow.ItemArray[0].ToString();                                                
                        }
                        //(String.Format("{0:0.00}", GrossPay)
                        if (getGrossPay >= 1000 && getGrossPay <= 3249.99)
                        {
                            sssContributionEmployee = 135.00;
                            sssContributionEmployer = 255.00;

                        }
                        else if (getGrossPay >= 3250 && getGrossPay <= 3749.99)
                        {
                            sssContributionEmployee = 157.00;
                            sssContributionEmployer = 297.50;

                        }
                        else if (getGrossPay >= 3750 && getGrossPay <= 4249.99)
                        {
                            sssContributionEmployee = 180.00;
                            sssContributionEmployer = 340.00;

                        }
                        else if (getGrossPay >= 4250 && getGrossPay <= 4749.99)
                        {
                            sssContributionEmployee = 202.50;
                            sssContributionEmployer = 382.50;

                        }
                        else if (getGrossPay >= 4750 && getGrossPay <= 5249.99)
                        {
                            sssContributionEmployee = 225.00;
                            sssContributionEmployer = 425.00;

                        }
                        else if (getGrossPay >= 5250 && getGrossPay <= 5749.99)
                        {
                            sssContributionEmployee = 247.50;
                            sssContributionEmployer = 467.50;

                        }
                        else if (getGrossPay >= 5750 && getGrossPay <= 6249.99)
                        {
                            sssContributionEmployee = 270.00;
                            sssContributionEmployer = 510.00;

                        }
                        else if (getGrossPay >= 6250 && getGrossPay <= 6749.99)
                        {
                            sssContributionEmployee = 292.50;
                            sssContributionEmployer = 552.50;

                        }
                        else if (getGrossPay >= 6750 && getGrossPay <= 7249.99)
                        {
                            sssContributionEmployee = 315.00;
                            sssContributionEmployer = 595.00;

                        }
                        else if (getGrossPay >= 7250 && getGrossPay <= 7749.99)
                        {
                            sssContributionEmployee = 337.50;
                            sssContributionEmployer = 637.50;

                        }
                        else if (getGrossPay >= 7750 && getGrossPay <= 8249.99)
                        {
                            sssContributionEmployee = 360.00;
                            sssContributionEmployer = 680.00;

                        }
                        else if (getGrossPay >= 8250 && getGrossPay <= 8749.99)
                        {
                            sssContributionEmployee = 382.50;
                            sssContributionEmployer = 722.50;

                        }
                        else if (getGrossPay >= 8750 && getGrossPay <= 9249.99)
                        {
                            sssContributionEmployee = 405.00;
                            sssContributionEmployer = 765.00;

                        }
                        else if (getGrossPay >= 9250 && getGrossPay <= 9749.99)
                        {
                            sssContributionEmployee = 427.50;
                            sssContributionEmployer = 807.50;

                        }
                        else if (getGrossPay >= 9750 && getGrossPay <= 10249.99)
                        {
                            sssContributionEmployee = 450.00;
                            sssContributionEmployer = 850.00;

                        }
                        else if (getGrossPay >= 10250 && getGrossPay <= 10749.99)
                        {
                            sssContributionEmployee = 472.50;
                            sssContributionEmployer = 892.50;

                        }
                        else if (getGrossPay >= 10750 && getGrossPay <= 11249.99)
                        {
                            sssContributionEmployee = 495.00;
                            sssContributionEmployer = 935.00;

                        }
                        else if (getGrossPay >= 11250 && getGrossPay <= 11749.99)
                        {
                            sssContributionEmployee = 517.50;
                            sssContributionEmployer = 977.50;

                        }
                        else if (getGrossPay >= 11750 && getGrossPay <= 12249.99)
                        {
                            sssContributionEmployee = 540.00;
                            sssContributionEmployer = 1020.00;

                        }
                        else if (getGrossPay >= 12250 && getGrossPay <= 12749.99)
                        {
                            sssContributionEmployee = 562.50;
                            sssContributionEmployer = 1062.50;

                        }
                        else if (getGrossPay >= 12750 && getGrossPay <= 13249.99)
                        {
                            sssContributionEmployee = 585.00;
                            sssContributionEmployer = 1105.00;

                        }
                        else if (getGrossPay >= 13250 && getGrossPay <= 13749.99)
                        {
                            sssContributionEmployee = 607.50;
                            sssContributionEmployer = 1147.50;

                        }
                        else if (getGrossPay >= 13750 && getGrossPay <= 14249.99)
                        {
                            sssContributionEmployee = 630.00;
                            sssContributionEmployer = 1190.00;

                        }
                        else if (getGrossPay >= 14250 && getGrossPay <= 14749.99)
                        {
                            sssContributionEmployee = 652.50;
                            sssContributionEmployer = 1232.50;

                        }
                        else if (getGrossPay >= 14750 && getGrossPay <= 15249.99)
                        {
                            sssContributionEmployee = 675.00;
                            sssContributionEmployer = 1275.00;

                        }
                        else if (getGrossPay >= 15250 && getGrossPay <= 15749.99)
                        {
                            sssContributionEmployee = 697.50;
                            sssContributionEmployer = 1317.50;

                        }
                        else if (getGrossPay >= 15750 && getGrossPay <= 16249.99)
                        {
                            sssContributionEmployee = 720.00;
                            sssContributionEmployer = 1360.00;

                        }
                        else if (getGrossPay >= 16250 && getGrossPay <= 16749.99)
                        {
                            sssContributionEmployee = 742.50;
                            sssContributionEmployer = 1402.50;

                        }
                        else if (getGrossPay >= 16750 && getGrossPay <= 17249.99)
                        {
                            sssContributionEmployee = 765.00;
                            sssContributionEmployer = 1445.00;

                        }
                        else if (getGrossPay >= 17250 && getGrossPay <= 17749.99)
                        {
                            sssContributionEmployee = 787.50;
                            sssContributionEmployer = 1487.50;

                        }
                        else if (getGrossPay >= 17750 && getGrossPay <= 18249.99)
                        {
                            sssContributionEmployee = 810.00;
                            sssContributionEmployer = 1530.00;

                        }
                        else if (getGrossPay >= 18250 && getGrossPay <= 18749.99)
                        {
                            sssContributionEmployee = 832.50;
                            sssContributionEmployer = 1572.50;

                        }
                        else if (getGrossPay >= 18750 && getGrossPay <= 19249.99)
                        {
                            sssContributionEmployee = 855.00;
                            sssContributionEmployer = 1615.00;

                        }
                        else if (getGrossPay >= 19250 && getGrossPay <= 19749.99)
                        {
                            sssContributionEmployee = 877.50;
                            sssContributionEmployer = 1657.50;

                        }
                        else if (getGrossPay >= 19750 && getGrossPay <= 20249.99)
                        {
                            sssContributionEmployee = 900.00;
                            sssContributionEmployer = 1700.00;

                        }
                        else if (getGrossPay >= 20250 && getGrossPay <= 20749.99)
                        {
                            sssContributionEmployee = 900.00;
                            sssContributionEmployer = 1700.00;

                        }
                        else if (getGrossPay >= 20750 && getGrossPay <= 21249.99)
                        {
                            sssContributionEmployee = 900.00;
                            sssContributionEmployer = 1700.00;

                        }
                        else if (getGrossPay >= 21250 && getGrossPay <= 21749.99)
                        {
                            sssContributionEmployee = 900.00;
                            sssContributionEmployer = 1700.00;

                        }
                        else if (getGrossPay >= 21750 && getGrossPay <= 22249.99)
                        {
                            sssContributionEmployee = 900.00;
                            sssContributionEmployer = 1700.00;

                        }
                        else if (getGrossPay >= 22250 && getGrossPay <= 22749.99)
                        {
                            sssContributionEmployee = 900.00;
                            sssContributionEmployer = 1700.00;

                        }
                        else if (getGrossPay >= 22750 && getGrossPay <= 23249.99)
                        {
                            sssContributionEmployee = 900.00;
                            sssContributionEmployer = 1700.00;

                        }
                        else if (getGrossPay >= 23250 && getGrossPay <= 23749.99)
                        {
                            sssContributionEmployee = 900.00;
                            sssContributionEmployer = 1700.00;

                        }
                        else if (getGrossPay >= 23750 && getGrossPay <= 24249.99)
                        {
                            sssContributionEmployee = 900.00;
                            sssContributionEmployer = 1700.00;

                        }
                        else if (getGrossPay >= 24250 && getGrossPay <= 24749.99)
                        {
                            sssContributionEmployee = 900.00;
                            sssContributionEmployer = 1700.00;

                        }
                        else if (getGrossPay >= 24750)
                        {
                            sssContributionEmployee = 900.00;
                            sssContributionEmployer = 1700.00;

                        }
                        else
                        {
                            sssContributionEmployee = 0;
                            sssContributionEmployer = 0;
                        }
                    }
                    if (SSSON == "ON")
                    {
                        UpdateEmployeeSSSColumn();
                    }
                    if (PAGIBIGON == "ON")
                    {
                        UpdatePagibigContributionColumn();
                    }
                    if (PHILHEALTHON == "ON")
                    {
                        UpdatePhilhealthContributionColumn();
                    }
                    getTAX();
                    getNetPay();
                }
            }
        }  
    }
}
