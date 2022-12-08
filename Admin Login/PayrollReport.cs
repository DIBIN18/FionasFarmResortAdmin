using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Syncfusion.XlsIO;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Font = System.Drawing.Font;

namespace Admin_Login
{
    public partial class PayrollReport : Form
    {
        Login login = new Login();
        SSSRangeClass sssclass = new SSSRangeClass();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        static string filepath = null, employeeid, employeename, department, position, datefrom,dateto;
        int i = 1;
        bool setdateFrom = true;
        string PayrollID;

        public PayrollReport(/*string name*/)
        {
            InitializeComponent();       
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
        private void dtp_From_ValueChanged(object sender, EventArgs e)
        {
            dgvDatechangeLoad();
            dtp_From.MaxDate = dtp_To.Value;
            dtp_To.MaxDate = DateTime.Now;
        }
        private void dtp_To_ValueChanged(object sender, EventArgs e)
        {
            
            dtp_From.MaxDate = dtp_To.Value;
            dtp_To.MaxDate = DateTime.Now;
            string date = dtp_To.Text;
            string day_To = "0";
            
            for (int i = 0; i < date.Length; i++)
            {
                if (date[i] == ' ')
                {
                    day_To = date.Substring(i + 1, 2);
                    i = i + 10;
                }
            }
            if (day_To == "15")
            {
                cbSSS.Checked = true;
                cbPAGIBIG.Checked = false;
                cbPHILHEALTH.Checked = false;
                dtp_From.Value = dtp_To.Value.AddDays(-14);
                sssclass.dateTo = dtp_To.Text;
            }
            else if (day_To == "30")
            {
                cbSSS.Checked = false;
                cbPAGIBIG.Checked = true;
                cbPHILHEALTH.Checked = true;
                dtp_From.Value = dtp_To.Value.AddDays(-14);
            }
            else if (day_To == "31")
            {
                cbSSS.Checked = false;
                cbPAGIBIG.Checked = true;
                cbPHILHEALTH.Checked = true;
                dtp_From.Value = dtp_To.Value.AddDays(-15);
            }
            dgvDatechangeLoad();           
        }
        private void PayrollReport_Load(object sender, EventArgs e)
        {
            dtp_From.MaxDate = dtp_To.Value;
            dtp_To.MaxDate = DateTime.Now;
            try
            {
                dtp_To.Value = DateTime.Now;
            }
            catch (Exception ex) { }
            if (setdateFrom == true)
            {
                try
                {
                    dtp_From.Value = dtp_To.Value.AddDays(-15);
                    setdateFrom = false;
                }
                catch (Exception ex) { }
            }
            try
            {
                string date = dtp_To.Text;
                string day_To = "0";
                for (int i = 0; i < date.Length; i++)
                {
                    if (date[i] == ' ')
                    {
                        day_To = date.Substring(i + 1, 2);
                        i = i + 10;
                    }
                }
                if (day_To == "15")
                {
                    cbSSS.Checked = true;
                    cbPAGIBIG.Checked = false;
                    cbPHILHEALTH.Checked = false;
                }
                else if (day_To == "30" || day_To == "31")
                {
                    cbSSS.Checked = false;
                    cbPAGIBIG.Checked = true;
                    cbPHILHEALTH.Checked = true;
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void dgvDatechangeLoad()
        {
            sssclass.dateFrom = dtp_From.Text;
            sssclass.dateTo = dtp_To.Text;
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
            //SqlConnection connection = new SqlConnection(login.connectionString);
            //connection.Open();
            //SqlCommand cmd = new SqlCommand(getQuery(), connection);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //DataTable dts = new DataTable();
            //sqlDataAdapter.Fill(dts);

            // Column font
            this.dgv_DailyPayrollReport.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            // Row font
            this.dgv_DailyPayrollReport.DefaultCellStyle.Font = new Font("Century Gothic", 10);

            dgv_DailyPayrollReport.DataSource = dt;
        }
        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            if (string.IsNullOrEmpty(tb_Search.Text))
            {
                SqlCommand cmd = new SqlCommand("select * from PayrollReport ", connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dts = new DataTable();
                sqlDataAdapter.Fill(dts);
                dgv_DailyPayrollReport.DataSource = dts;
            }
            else if (tb_Search.Focused)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PayrollReport where EmployeeID like '" + tb_Search.Text + "%'" + "OR EmployeeName like'" + tb_Search.Text + "%'", connection);
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
            dgvDatechangeLoad();
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
            dgvDatechangeLoad();
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
            dgvDatechangeLoad();
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            datefrom = dtp_From.Text;
            dateto = dtp_To.Text;
            PaySlipForm paySlipForm = new PaySlipForm(datefrom , dateto);
            paySlipForm.ShowDialog();
        }
        public void moveToHistory()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "Insert into PayrollReportHistory " +
                            "select "+ Convert.ToInt32(PayrollID) +", EmployeeID,EmployeeName,Position,BasicPay,TotalHours,BasicPay,OverTimePay,LegalHollidayPay,SpecialHollidayPay,TotalWorkDays, " +
                            "PaidLeaveDays,GrossSalary,TotalLateMinutes,TotalUnderTimeMinutes,SSSContribution,PAGIBIGContribution,PHILHEALTHContribution, " +
                            "TAX,OtherDeduction,NetSalary,'" + dtp_From.Text + "','" + dtp_To.Text + "' from PayrollReport ";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        private void btn_Records(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Payroll History";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        private void ThMonth(object sender, EventArgs e)
        {
            THMonthPay tHMonthPay = new THMonthPay();
            tHMonthPay.get13month();
            THMonthView tHMonthView = new THMonthView();
            tHMonthView.Show();
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
            sssclass.dateFrom = dtp_From.Text;
            sssclass.dateTo = dtp_To.Text;
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sssclass.ComputeGrossPay(), connection);
            command.ExecuteNonQuery();
            sssclass.getSSSRange();

        }
        public void InsertDeductionTable()
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
                            " select A.EmployeeID, A.SSSContribution, A.PAGIBIGContribution, A.PHILHEALTHContribution, A.OtherDeduction , A.SSSContribution + A.PAGIBIGContribution + A.PHILHEALTHContribution,'" + dtp_From.Text + " - " + dtp_To.Text + "' from PayrollReport as A ";
            SqlCommand cmd = new SqlCommand(query2, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void addToPayrollHistory()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "insert into PayrollHistoryID " +
                               "select '" + dtp_From.Text + "','"+ dtp_To.Text +"'";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                string query2 = "select max(PayRollID) from PayrollHistoryID";
                SqlCommand cmd2 = new SqlCommand(query2,connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd2);
                DataTable dts = new DataTable();
                sqlDataAdapter.Fill(dts);
                PayrollID = dts.Rows[0][0].ToString();
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            sssclass.dateFrom = dtp_From.Text;
            sssclass.dateTo = dtp_To.Text;
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
                InsertDeductionTable();
                sssclass.dateTo = dtp_To.Text;
                sssclass.UpdateOtherDeduction();
                addToPayrollHistory();
                moveToHistory();
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
                    Worksheet.Range["I2"].Text = "Payroll Covered Date : "+ dtp_From.Text + " - " + dtp_To.Text;
                    Worksheet.Range["I3"].Text = "Payroll ID : " + PayrollID;
                    Worksheet.ImportDataTable(dt, true, 4, 1, true);
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
                            catch (Exception ex)
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
            SSSRangeClass.from = dtp_From.Text;
            SSSRangeClass.to = dtp_To.Text;
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Payroll";
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            string query = "select A.EmployeeID , A.EmployeeFullName, C.DepartmentName , B.PositionName " +
                           " from EmployeeInfo as A " +
                           " join Position as B on A.PositionID = B.PositionID " +
                           " join Department as C on A.DepartmentID = C.DepartmentID " +
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
                dateto = dtp_To.Text;
                menu.PayrollReport_ValueHolder(employeeid, employeename, department, position, datefrom,dateto);
                menu.Menu_Load(menu, EventArgs.Empty);
            }
        }
    }
}