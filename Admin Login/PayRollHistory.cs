using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.XlsIO;
using System.IO;

namespace Admin_Login
{
    public partial class PayRollHistory : Form
    {
        Login login = new Login();
        string dateFrom,dateTo,payrollID;
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        string filepath;
        int i = 1;
        public PayRollHistory()
        {
            InitializeComponent();
        }

        private void btn_Export(object sender, EventArgs e)
        {
            string query = "select EmployeeID,EmployeeName,Position,BasicPay,TotalHours,BasicPay,OverTimePay,LegalHollidayPay,SpecialHollidayPay,TotalWorkDays, " +
                            "PaidLeaveDays,GrossSalary,TotalLateMinutes,TotalUnderTimeMinutes,SSSContribution,PAGIBIGContribution,PHILHEALTHContribution, " +
                            "TAX,OtherDeduction,NetSalary from PayrollReportHistory where PayrollID = " + payrollID;
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

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
                        IStyle style = workbook.Styles.Add("NewStyle");
                        style.Font.Bold = true;
                        style.Color.ToArgb();
                        // Import data from the data table
                        Worksheet.Range["I1"].Text = "FIONA'S FARM AND RESORT";
                        Worksheet.Range["I2"].Text = "Payroll Covered Date : " + dateFrom + " - " + dateTo;
                        Worksheet.Range["I3"].Text = "Payroll ID : " + payrollID;
                        Worksheet.ImportDataTable(data, true, 4, 1, true);
                        //IListObject table = Worksheet.ListObjects.Create("Payroll_Reports", Worksheet.UsedRange);
                        //table.BuiltInTableStyle = TableBuiltInStyles.TableStyleLight11;


                        Worksheet.Range[4, 1].AutofitColumns();
                        Worksheet.Range[4, 2].AutofitColumns();
                        Worksheet.Range[4, 3].AutofitColumns();
                        Worksheet.Range[4, 4].AutofitColumns();
                        Worksheet.Range[4, 5].AutofitColumns();
                        Worksheet.Range[4, 6].AutofitColumns();
                        Worksheet.Range[4, 7].AutofitColumns();
                        Worksheet.Range[4, 8].AutofitColumns();
                        Worksheet.Range[4, 9].AutofitColumns();
                        Worksheet.Range[4, 10].AutofitColumns();
                        Worksheet.Range[4, 11].AutofitColumns();
                        Worksheet.Range[4, 12].AutofitColumns();
                        Worksheet.Range[4, 13].AutofitColumns();
                        Worksheet.Range[4, 14].AutofitColumns();
                        Worksheet.Range[4, 15].AutofitColumns();
                        Worksheet.Range[4, 16].AutofitColumns();
                        Worksheet.Range[4, 17].AutofitColumns();
                        Worksheet.Range[4, 18].AutofitColumns();
                        Worksheet.Range[4, 19].AutofitColumns();
                        Worksheet.Range[4, 20].AutofitColumns();
                        Worksheet.Range[4, 21].AutofitColumns();
                        Worksheet.Range[2, 8].AutofitColumns();


                        Worksheet.Range["I1"].CellStyle = style;
                        Worksheet.Range["A4"].CellStyle = style;
                        Worksheet.Range["B4"].CellStyle = style;
                        Worksheet.Range["C4"].CellStyle = style;
                        Worksheet.Range["D4"].CellStyle = style;
                        Worksheet.Range["E4"].CellStyle = style;
                        Worksheet.Range["F4"].CellStyle = style;
                        Worksheet.Range["G4"].CellStyle = style;
                        Worksheet.Range["H4"].CellStyle = style;
                        Worksheet.Range["I4"].CellStyle = style;
                        Worksheet.Range["J4"].CellStyle = style;
                        Worksheet.Range["K4"].CellStyle = style;
                        Worksheet.Range["L4"].CellStyle = style;
                        Worksheet.Range["M4"].CellStyle = style;
                        Worksheet.Range["N4"].CellStyle = style;
                        Worksheet.Range["O4"].CellStyle = style;
                        Worksheet.Range["P4"].CellStyle = style;
                        Worksheet.Range["Q4"].CellStyle = style;
                        Worksheet.Range["R4"].CellStyle = style;
                        Worksheet.Range["S4"].CellStyle = style;
                        Worksheet.Range["T4"].CellStyle = style;
                        Worksheet.Range["U4"].CellStyle = style;

                        // Save the file
                        if (fbd.ShowDialog() == DialogResult.OK)
                        {
                            filepath = fbd.SelectedPath;
                            FileInfo fi = new FileInfo(Path.GetFullPath(filepath + "\\PayrollReport"+dateFrom+"-"+dateTo+".xlsx "));
                            if (!fi.Exists)
                            {
                                Stream excelStream = File.Create(Path.GetFullPath(filepath + "\\PayrollReport" + dateFrom + "-" + dateTo + ".xlsx "));
                                workbook.SaveAs(excelStream);
                                excelStream.Dispose();
                                //System.Diagnostics.Process.Start(filepath + "\\PayrollReport" + dateFrom + "-" + dateTo + ".xlsx ");
                                i++;
                            }
                            else
                            {
                                try
                                {
                                    Stream excelStream = File.Create(Path.GetFullPath(filepath + "\\PayrollReport" + dateFrom + "-" + dateTo + "(" + i + ").xlsx "));
                                    workbook.SaveAs(excelStream);
                                    excelStream.Dispose();
                                    //System.Diagnostics.Process.Start(filepath + "\\PayrollReport" + dateFrom + "-" + dateTo + "(" + i + ").xlsx ");
                                    i++;
                                }
                                catch (Exception ex)
                                {
                                    i++;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PayRollHistory_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "select * from PayrollReportHistory";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvPayrollRecords.DataSource = data;
            }

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "Select * from PayrollHistoryID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgv_PayrollID.DataSource = data;
            }
        }

        private void dgv_PayrollID_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dateFrom = dgv_PayrollID.Rows[e.RowIndex].Cells[1].Value.ToString();
                dateTo = dgv_PayrollID.Rows[e.RowIndex].Cells[2].Value.ToString();
                payrollID = dgv_PayrollID.Rows[e.RowIndex].Cells[0].Value.ToString();
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();
                    string query = "select * from PayrollReportHistory where PayrollID = " + payrollID;
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dgvPayrollRecords.DataSource = data;
                }
            }
            catch (Exception ex) { }
        }
    }
}
