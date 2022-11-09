using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Syncfusion.XlsIO;
using System.IO;

namespace Admin_Login
{
    public partial class PayrollReport : Form
    {
        Login login = new Login();
        SSSRangeClass sssclass = new SSSRangeClass();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        static string filepath = null, employeeid, employeename, department, position, datefrom;
        int i = 1;
        bool setdateFrom = true;

        public PayrollReport(/*string name*/)
        {
            InitializeComponent();
            cbSSS.Checked = true;
            cbPAGIBIG.Checked = true;
            cbPHILHEALTH.Checked = true;
        }
        private void Tb_Search_Enter(object sender, EventArgs e)
        {
            if (tb_Search.Text == " Search")
            {
                tb_Search.Text = "";
                tb_Search.ForeColor = Color.Black;
            }
        }
        private void Tb_Search_Leave(object sender, EventArgs e)
        {
            if (tb_Search.Text == "")
            {
                tb_Search.Text = " Search";
                tb_Search.ForeColor = Color.Silver;
            }
        }
        public string getLastPayrollDate()
        {
            string Date = "0";
            Login login = new Login();
            SqlConnection connection = new SqlConnection(login.connectionString);
            {
                try
                {
                    connection.Open();
                    string query = "select  max(PayrollCoveredDate) from Deductions";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    Date = data.Rows[0][0].ToString().Substring(21);
                }
                catch (Exception ex)
                {
                    
                }
                return Date;
            }
        }
        public string getQuery()
        {
            string command = " select A.EmployeeID, A.EmployeeFullName as Employee, B.PositionName as Position, B.BasicRate , " +
                          " sum(RegularHours) + sum(OvertimeHours) as TotalHours , " +
                          " sum(C.OvertimeHours) as OverTimeHours , " +
                          " sum(C.RegularHolidayHours) as LegalHollidayHours, " +
                          " sum(C.SpecialHolidayHours) as SpeciallHollidayHours , " +
                          " count(C.EmployeeID) as TotalWorkDays, " +
                          " (sum(RegularHours)*B.BasicRate)+((sum(C.OvertimeHours)*B.BasicRate)+((sum(C.OvertimeHours)*B.BasicRate)*0.30)) + ((sum(C.RegularHolidayHours)* B.BasicRate)+ ((sum(C.SpecialHolidayHours) * B.BasicRate) * 0.30)) as GrossPay , " +
                          " sum(C.Late) as TotalLateHours , sum(C.UndertimeHours) as TotalUnderTime " +
                          " from EmployeeInfo as A " +
                          " left join Position as B " +
                          " on A.PositionID = B.PositionID " +
                          " left join AttendanceSheet as C " +
                          " on A.EmployeeID = C.EmployeeID " +
                          " left join Deductions as D " +
                          " on A.EmployeeID = D.EmployeeID " +
                          "where Date Between CONVERT(datetime, '" + dtp_From.Text + "', 100) and CONVERT(datetime, '" + dtp_To.Text + "', 100)" +
                          " group by A.EmployeeID,A.EmployeeFullName, B.PositionName,B.BasicRate,D.SSSContribution,D.PagIbigContribution,D.PhilHealthContribution,D.OtherDeduction,D.TotalDeductions";
            return command;
        }
        private void dtp_To_ValueChanged(object sender, EventArgs e)
        {
            PayrollReport_Load(this, null);
        }
        private void PayrollReport_Load(object sender, EventArgs e)
        {
            if (setdateFrom == true) 
            {
                try
                {
                    dtp_From.Text = getLastPayrollDate().ToString();
                    dtp_From.Value = dtp_From.Value.AddDays(1);
                    setdateFrom = false;
                }
                catch(Exception ex) { }
            } 
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(getQuery(), connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dts = new DataTable();
            sqlDataAdapter.Fill(dts);

            // Column font
            this.dgv_DailyPayrollReport.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            // Row font
            this.dgv_DailyPayrollReport.DefaultCellStyle.Font = new Font("Century Gothic", 10);

            dgv_DailyPayrollReport.DataSource = dts;
        }
        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            if (string.IsNullOrEmpty(tb_Search.Text))
            {
                SqlCommand cmd = new SqlCommand(getQuery(), connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dts = new DataTable();
                sqlDataAdapter.Fill(dts);
                dgv_DailyPayrollReport.DataSource = dts;
            }
            else if (tb_Search.Focused)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(" select A.EmployeeID, A.EmployeeFullName as Employee, B.PositionName as Position, B.BasicRate , " +
                          " sum(RegularHours) + sum(OvertimeHours) as TotalHours , " +
                          " sum(C.OvertimeHours) as OverTimeHours , " +
                          " sum(C.RegularHolidayHours) as LegalHollidayHours, " +
                          " sum(C.SpecialHolidayHours) as SpeciallHollidayHours , " +
                          " count(C.EmployeeID) as TotalWorkDays, " +
                          " (sum(RegularHours)*B.BasicRate)+((sum(C.OvertimeHours)*B.BasicRate)+((sum(C.OvertimeHours)*B.BasicRate)*0.30)) + ((sum(C.RegularHolidayHours)* B.BasicRate)+ ((sum(C.SpecialHolidayHours) * B.BasicRate) * 0.30)) as GrossPay , " +
                          " sum(C.Late) as TotalLateHours , sum(C.UndertimeHours) as TotalUnderTime " +
                          " from EmployeeInfo as A " +
                          " left join Position as B " +
                          " on A.PositionID = B.PositionID " +
                          " left join AttendanceSheet as C " +
                          " on A.EmployeeID = C.EmployeeID " +
                          " left join Deductions as D " +
                          " on A.EmployeeID = D.EmployeeID " +
                          " where Date Between CONVERT(datetime, '" + dtp_From.Text + "', 100) and CONVERT(datetime, '" + dtp_To.Text + "', 100) " +
                          " AND A.EmployeeID like '" + tb_Search.Text + "%'" + "OR EmployeeFullName like'" + tb_Search.Text + "%'" +
                          " group by A.EmployeeID,A.EmployeeFullName, B.PositionName,B.BasicRate,D.SSSContribution,D.PagIbigContribution,D.PhilHealthContribution,D.OtherDeduction,D.TotalDeductions", connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dts = new DataTable();
                    sqlDataAdapter.Fill(dts);
                    dgv_DailyPayrollReport.DataSource = dts;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
        }
        private void cbSSS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSSS.Checked)
            {
                sssclass.SSSON = "ON";
            }
            else
            {
                sssclass.SSSON = "OFF";
            }
        }
        private void cbPAGIBIG_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPAGIBIG.Checked)
            {
                sssclass.PAGIBIGON = "ON";
            }
            else
            {
                sssclass.PAGIBIGON = "OFF";
            }
        }
        private void cbPHILHEALTH_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPHILHEALTH.Checked)
            {
                sssclass.PHILHEALTHON = "ON";
            }
            else
            {
                sssclass.PHILHEALTHON = "OFF";
            }
        }
        private void dtp_From_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //dtp_To.MinDate = dtp_From.Value;
                dtp_To.Enabled = true;
            }
            catch(Exception ex) { }
        }

        public void tagadelete()
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("delete from PayrollReport", connection);
            command.ExecuteNonQuery();
        }
        public void tagaInsertPayrollReport()
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            string query = "insert into PayrollReport "+
                "select A.EmployeeID, A.EmployeeFullName as Employee, B.PositionName as Position, B.BasicRate , "+
                "sum(RegularHours) as TotalHours , "+
                "sum(C.OvertimeHours) as OverTimeHours , "+
                "sum(C.RegularHolidayHours) as LegalHollidayHours, "+
                "sum(C.SpecialHolidayHours) as SpeciallHollidayHours, "+
                "count(C.EmployeeID) as TotalWorkDays, "+
                "((sum(RegularHours)-sum(C.OvertimeHours))*B.BasicRate)+((sum(C.OvertimeHours)*B.BasicRate)+((sum(C.OvertimeHours)*B.BasicRate)*0.30)) + ((sum(C.RegularHolidayHours)* B.BasicRate)+ ((sum(C.SpecialHolidayHours) * B.BasicRate) * 0.30)) as GrossPay , " +
                "sum(C.Late) as TotalLateHours , sum(C.UndertimeHours) as TotalUnderTime , "+
                "0 as SSSContribution , "+
                "0 as PAGIBIGContribution , "+
                "0 as PHILHEALTHContribution , "+
                "0 as TAX, "+
                "D.OtherDeduction as OtherDeduction , "+
                "0 as NetPay, null "+
                "from EmployeeInfo as A "+
                "left join Position as B "+
                "on A.PositionID = B.PositionID "+
                "left join AttendanceSheet as C "+
                "on A.EmployeeID = C.EmployeeID "+
                "left join Deductions as D "+
                "on A.EmployeeID = D.EmployeeID "+
                "where Date Between CONVERT(datetime, '"+ dtp_From.Text +"', 100) and CONVERT(datetime, '"+ dtp_To.Text +"', 100)"+
                " group by A.EmployeeID,A.EmployeeFullName, B.PositionName,B.BasicRate,D.SSSContribution,D.PagIbigContribution,D.PhilHealthContribution,D.OtherDeduction,D.TotalDeductions";         
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            sssclass.getSSSRange();
            InserDeductionTable();
        }
        public void InserDeductionTable()
        {
            string systemdate = "";
            string dbsdate = "";
            SqlConnection connection = new SqlConnection(login.connectionString);
            
                connection.Open();
                string query = "select * from Deductions";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                try
                {
                    systemdate = dtp_From.Text + " - " + dtp_To.Text;
                    dbsdate = data.Rows[0][7].ToString();

                }
                catch (Exception ex)
                {
                    
                }

                string query2 = "insert into Deductions (EmployeeID,SSSContribution,PagIbigContribution,PhilHealthContribution,OtherDeduction,TotalDeductions,PayrollCoveredDate)" +
                                " select A.EmployeeID, A.SSSContribution, A.PAGIBIGContribution, A.PHILHEALTHContribution, 0 , A.SSSContribution + A.PAGIBIGContribution + A.PHILHEALTHContribution,'" + dtp_From.Text + " - " + dtp_To.Text + "' from PayrollReport as A ";
                SqlCommand cmd = new SqlCommand(query2, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
        }      
        private void btn_Export_Click(object sender, EventArgs e)
        {
            tagadelete();
            tagaInsertPayrollReport();
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            string filldt = "select * from PayrollReport";
            SqlCommand command2 = new SqlCommand(filldt, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command2);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            command2.ExecuteNonQuery();
            //Export
            DialogResult dialogResult = MessageBox.Show("Export as Excel file?", "PayrollReport", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {              
                using (ExcelEngine engine = new ExcelEngine())
                {
                    IApplication application = engine.Excel;
                    application.DefaultVersion = ExcelVersion.Xlsx;
                    // Create a new workbook
                    IWorkbook workbook = application.Workbooks.Create(1);
                    IWorksheet Worksheet = workbook.Worksheets[0];
                    // Import data from the data table
                    //Worksheet.Range["I1"].Text = "FIONA'S FARM AND RESORT";
                    Worksheet.ImportDataTable(dt, true, 2, 1, true);
                    // Create Excel table or listobject and apply table style
                    IListObject table = Worksheet.ListObjects.Create("Payroll_Reports", Worksheet.UsedRange);
                    table.BuiltInTableStyle = TableBuiltInStyles.TableStyleLight11;
                    // Autofit the columns
                    Worksheet.UsedRange.AutofitColumns();
                    // Save the file
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        filepath = fbd.SelectedPath;
                        FileInfo fi = new FileInfo(Path.GetFullPath(filepath + "\\PayrollReport.xlsx "));
                        if (!fi.Exists)
                        {
                            Stream excelStream = File.Create(Path.GetFullPath(filepath + "\\PayrollReport.xlsx "));
                            workbook.SaveAs(excelStream);
                            excelStream.Dispose();
                            System.Diagnostics.Process.Start(filepath + "\\PayrollReport.xlsx ");
                            i++;
                        }
                        else
                        {
                            try
                            {
                                Stream excelStream = File.Create(Path.GetFullPath(filepath + "\\PayrollReport(" + i + ").xlsx "));
                                workbook.SaveAs(excelStream);
                                excelStream.Dispose();
                                System.Diagnostics.Process.Start(filepath + "\\PayrollReport(" + i + ").xlsx ");
                                i++;
                            }
                            catch(Exception ex)
                            {
                                i++;
                            }   
                        }
                    }
                }
            }
        }
        private void dgvDailyPayrollReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sssclass.getSSSRange();         
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Payroll";
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            string query = "select A.EmployeeID , A.EmployeeFullName, C.DepartmentName , B.PositionName "+
                           " from EmployeeInfo as A "+
                           " join Position as B on A.PositionID = B.PositionID "+
                           " join Department as C on A.DepartmentID = C.DepartmentID "+
                           " where A.EmployeeID = " + dgv_DailyPayrollReport.Rows[e.RowIndex].Cells[0].Value;
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            if (dgv_DailyPayrollReport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                employeeid = dgv_DailyPayrollReport.CurrentRow.Cells[0].Value.ToString();
                employeename = dgv_DailyPayrollReport.CurrentRow.Cells[1].Value.ToString();
                department = data.Rows[0][2].ToString();
                position = data.Rows[0][3].ToString();
                datefrom = dtp_From.Text;
                menu.PayrollReport_ValueHolder(employeeid, employeename, department, position, datefrom);
                menu.Menu_Load(menu, EventArgs.Empty);
            }   
        }
    }
}