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
        string filepath = null, employeeid, employeename, department, position;
        int i = 1;
        public PayrollReport(/*string name*/)
        {
            InitializeComponent();
            //Name = name;
        }
        private void PayrollReport_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select Holiday_, To_, Type_ from Holidays where From_ = @From_", connection);
            command.Parameters.AddWithValue("@From_", dtp_Date.Value.ToString("MMMM dd"));
            SqlDataReader Reader;
            Reader = command.ExecuteReader();
            if (Reader.Read())
            {
                lbl_Period.Text = Reader.GetValue(1).ToString() + dtp_Date.Value.ToString(", yyyy");
                lbl_Holiday.Text = Reader.GetValue(0).ToString() + "|" + Reader.GetValue(2).ToString();
            }
            string query = "select A.EmployeeID, EmployeeFullName, DepartmentName, PositionName, sum(TotalHours) as RegularWorkHours, C.BasicRate as HourlyRate, sum(OverTimeHours) as OverTime, sum(Late) as Tardiness, sum(UnderTimeHours) as UnderTime"+
                " from EmployeeInfo as A "+
                " left join Department as B "+
                " on A.DepartmentID = B.DepartmentID "+
                " left join Position as C "+
                " on A.PositionID = C.PositionID "+
                " left join AttendanceSheet as D "+
                " on A.EmployeeID = D.EmployeeID "+
                " group by A.EmployeeID, A.EmployeeFullName, B.DepartmentName, C.PositionName, C.BasicRate";
            SqlCommand cmd = new SqlCommand(query,connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvDailyPayrollReport.DataSource = dt;
        }
        private void Cb_SortBy_Click(object sender, EventArgs e)
        {
            cb_SortBy.DropDownStyle = ComboBoxStyle.DropDownList;
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
        private void Cb_SortBy_Enter(object sender, EventArgs e)
        {
            if (cb_SortBy.Text == "Default")
            {
                cb_SortBy.Text = "Default";
                cb_SortBy.ForeColor = Color.Black;
            }
        }
        private void Cb_SortBy_Leave(object sender, EventArgs e)
        {
            if (cb_SortBy.Text == "Default")
            {
                cb_SortBy.Text = "Default";
                cb_SortBy.ForeColor = Color.Silver;
            }
        }
        private void Dt_Date_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand HolidayCommand = new SqlCommand("select Holiday_, To_, Type_ from Holidays where From_ = @From_", connection);
            HolidayCommand.Parameters.AddWithValue("@From_", dtp_Date.Value.ToString("MMMM dd"));
            SqlDataReader Reader;
            Reader = HolidayCommand.ExecuteReader();
            if (Reader.Read())
            {
                lbl_Period.Text = Reader.GetValue(1).ToString() + dtp_Date.Value.ToString(", yyyy");
                lbl_Holiday.Text = Reader.GetValue(0).ToString() + "|" + Reader.GetValue(2).ToString();
            }
            else
            {
                lbl_Period.Text = "";
                lbl_Holiday.Text = "";
            }
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
                "sum(TotalHours) as TotalHours , "+
                "sum(C.OvertimeHours) as OverTimeHours , "+
                "sum(C.RegularHolidayHours) as LegalHollidayHours, "+
                "sum(C.SpecialHolidayHours) as SpeciallHollidayHours, "+
                "count(C.EmployeeID) as TotalWorkDays, "+
                "((sum(TotalHours)-sum(C.OvertimeHours))*B.BasicRate)+((sum(C.OvertimeHours)*B.BasicRate)+((sum(C.OvertimeHours)*B.BasicRate)*0.30)) + ((sum(C.RegularHolidayHours)* B.BasicRate)+ ((sum(C.SpecialHolidayHours) * B.BasicRate) * 0.30)) as GrossPay , "+
                "sum(C.Late) as TotalLateHours , sum(C.UndertimeHours) as TotalUnderTime , "+
                "0 as SSSContribution , "+
                "0 as PAGIBIGContribution , "+
                "0 as PHILHEALTHContribution , "+
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
                            Stream excelStream = File.Create(Path.GetFullPath(filepath + "\\PayrollReport" + i + ".xlsx "));
                            workbook.SaveAs(excelStream);
                            excelStream.Dispose();
                            //System.Diagnostics.Process.Start(filepath + "\\PayrollReport" + i + ".xlsx ");
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
            if (dgvDailyPayrollReport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                employeeid = dgvDailyPayrollReport.CurrentRow.Cells[0].Value.ToString();
                employeename = dgvDailyPayrollReport.CurrentRow.Cells[1].Value.ToString();
                department = dgvDailyPayrollReport.CurrentRow.Cells[2].Value.ToString();
                position = dgvDailyPayrollReport.CurrentRow.Cells[3].Value.ToString();
                menu.ValueHolder(employeeid, employeename, department, position);
                menu.Menu_Load(menu, EventArgs.Empty);
            }   
        }
    }
}