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
        public void getSSSRange()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "select BasicRate * (TotalHours - OverTimeHours) from PayrollReport";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                double getGrossPay = 0;
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
                        }

                        //(String.Format("{0:0.00}", GrossPay)
                        //SSS Range Here (SSSTable)
                        if (getGrossPay > 10250 && getGrossPay <= 10749.99)
                        {
                            // Range 10500 EE 472.50	

                        }
                        else if (getGrossPay > 10750 && getGrossPay <= 1124.99)
                        {
                            // Range 11000 EE 495.00

                        }
                        //else if (getGrossPay > 10750 && getGrossPay <= 1124.99)
                        //{
                        //    // Range 11000 EE 495.00

                        //}
                        //else if (getGrossPay > 10750 && getGrossPay <= 1124.99)
                        //{
                        //    // Range 11000 EE 495.00

                        //}
                    }
                }
            }

        }
    }
}
