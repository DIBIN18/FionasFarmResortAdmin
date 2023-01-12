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
        //FolderBrowserDialog fbd = new FolderBrowserDialog();
        SaveFileDialog sfd = new SaveFileDialog();
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
                cbSSS.Checked = false;
                cbPAGIBIG.Checked = true;
                cbPHILHEALTH.Checked = true;
                dtp_From.Value = dtp_To.Value.AddDays(-14);
                sssclass.dateTo = dtp_To.Text;
            }
            else if (day_To == "30")
            {
                cbSSS.Checked = true;
                cbPAGIBIG.Checked = false;
                cbPHILHEALTH.Checked = false;
                dtp_From.Value = dtp_To.Value.AddDays(-14);
            }
            else if (day_To == "31")
            {
                cbSSS.Checked = true;
                cbPAGIBIG.Checked = false;
                cbPHILHEALTH.Checked = false;
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
                    cbSSS.Checked = false;
                    cbPAGIBIG.Checked = true;
                    cbPHILHEALTH.Checked = true;
                }
                else if (day_To == "30" || day_To == "31")
                {
                    cbSSS.Checked = true;
                    cbPAGIBIG.Checked = false;
                    cbPHILHEALTH.Checked = false;
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
            Loading loading = new Loading();
            loading.ShowDialog();
            paySlipForm.ShowDialog();
        }
        public void moveToHistory()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "Insert into PayrollReportHistory " +
                            "select "+ Convert.ToInt32(PayrollID) +", EmployeeID,EmployeeName,Position,BasicRate,TotalHours,BasicPay,OverTimePay,LegalHollidayPay,SpecialHollidayPay,TotalWorkDays, " +
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
            THMonthSlip tHMonthSlip = new THMonthSlip();
          
            Login login = new Login();
            string from = dtp_From.Text;
            string to = dtp_To.Text;
            using (SqlConnection bonus = new SqlConnection(login.connectionString))
            {
                bonus.Open();
                string InsertTHMonthPay = "INSERT INTO THMonthsSalary " +
                    "SELECT H.EmployeeID,H.EmployeeName," +
                    "DATEDIFF(MONTH ,convert(datetime, E.DateHired, 100) ," +
                    "GETDATE()) AS CheckMonth,SUM(BasicPay) AS YearlyBasicPay, " +
                    "SUM(BasicPay/12) AS THMonthSalary,FORMAT(GetDATE(),'yyyy') " +
                    "FROM PayrollReportHistory AS H " +
                    "left JOIN EmployeeInfo AS E ON H.EmployeeID = E.EmployeeID " +
                    "where DateFrom Between CONVERT(DateTime,'"+from+"',100) " +
                    "AND CONVERT(DateTime,'"+to+"',100) and " +
                    "DateTo Between CONVERT(DateTime,'"+from+"',100) " +
                    "AND CONVERT(DateTime,'"+to+"',100) and " +
                    "NOT EXISTS (SELECT THYear FROM THMonthsSalary WHERE THYear = FORMAT(GetDATE(),'yyyy')) " +
                    "GROUP BY H.EmployeeID,H.EmployeeName,E.DateHired";
                SqlCommand sqlCommand = new SqlCommand(InsertTHMonthPay, bonus);
                sqlCommand.ExecuteNonQuery();
                bonus.Close();
            }
            tHMonthSlip.ShowDialog();

        }
        private void btn_SendPayslip_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Mail Payslip";
            menu.Menu_Load(menu, EventArgs.Empty);
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
                    style.ColorIndex = ExcelKnownColors.Custom34;
                    style.HorizontalAlignment = ExcelHAlign.HAlignLeft;
                    

                    IStyle style2 = workbook.Styles.Add("NewStyle2");
                    style2.HorizontalAlignment = ExcelHAlign.HAlignLeft;
                    style2.ColorIndex = ExcelKnownColors.Custom35;


                    IStyle style3 = workbook.Styles.Add("NewStyle3");
                    style3.Font.Bold = true;
                 
                    // Import data from the data table
                    Worksheet.Range["A1"].Text = "FIONA'S FARM AND RESORT";
                    Worksheet.Range["A1"].CellStyle = style3;
                    Worksheet.Range["A2"].Text = "Payroll Covered Date : "+ dtp_From.Text + " - " + dtp_To.Text;
                    Worksheet.Range["A2"].CellStyle = style3;
                    Worksheet.Range["A3"].Text = "Payroll ID : " + PayrollID;
                    Worksheet.Range["A3"].CellStyle = style3;
                    Worksheet.ImportDataTable(dt, true, 4, 1, true);

                    //IListObject table = Worksheet.ListObjects.Create("Payroll_Reports", Worksheet.UsedRange);
                    //table.BuiltInTableStyle = TableBuiltInStyles.TableStyleLight11;

                    int ir = 4, reset = 0 ;
                    Worksheet.Range[4, 1, 4,21 ].AutofitColumns();
                    foreach (DataRow row in dt.Rows)
                    {
                        Worksheet.Rows[ir].CellStyle = style2;
                        Worksheet.Rows[ir].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Medium;
                        Worksheet.Rows[ir].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
                        Worksheet.Rows[ir].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
                        Worksheet.Rows[ir].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;
                        ir++;
                        reset++;
                        if (reset == dt.Rows.Count)
                        {
                            ir = 4;
                        }
                    }
                    Worksheet.Range[2, 8].AutofitColumns();
                    Worksheet.SetColumnWidth(3, 15);
                    Worksheet.SetColumnWidth(18, 10);
                    Worksheet.Rows[3].CellStyle = style;
                    Worksheet.Rows[3].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Medium;
                    Worksheet.Rows[3].CellStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Medium;
                    Worksheet.Rows[3].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Medium;
                    Worksheet.Rows[3].CellStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Medium;


                    // Save the file
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        filepath = sfd.FileName.ToString();
                        FileInfo fi = new FileInfo(Path.GetFullPath(filepath + ".xlsx "));
                        if (!fi.Exists)
                        {
                            Stream excelStream = File.Create(Path.GetFullPath(filepath + ".xlsx "));
                            workbook.SaveAs(excelStream);
                            excelStream.Dispose();
                            System.Diagnostics.Process.Start(filepath + ".xlsx ");
                            i++;
                        }
                        else
                        {
                            try
                            {
                                Stream excelStream = File.Create(Path.GetFullPath(filepath + "(" + i + ").xlsx "));
                                workbook.SaveAs(excelStream);
                                excelStream.Dispose();
                                System.Diagnostics.Process.Start(filepath + "(" + i + ").xlsx ");
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
            try
            {
                //sssclass.getSSSRange();
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
                    menu.PayrollReport_ValueHolder(employeeid, employeename, department, position, datefrom, dateto);
                    menu.Menu_Load(menu, EventArgs.Empty);
                }
            }
            catch (ArgumentOutOfRangeException) 
            {
                // Do nothing
                // Column Headers click catcher
            }
        }
    }
}