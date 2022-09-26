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
        private new string Name;

        public PayrollReport(string name)
        {
            InitializeComponent();
            Name = name;
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
            SqlCommand cmd = new SqlCommand("Select * from Computation",connection);
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
        private void Btn_HolidaySettings_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Holiday Settings";
            menu.Menu_Load(menu, EventArgs.Empty);
        }
        int i = 1;
        private void btnExportPayroll(object sender, EventArgs e)
        {
            tagadelete();
            tagaInsertPayroll();
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            string filldt = "select * from Payroll ";
            SqlCommand command2 = new SqlCommand(filldt, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command2);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            command2.ExecuteNonQuery();
            //Export
            using (ExcelEngine engine = new ExcelEngine())
            {
                IApplication application = engine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;
                // Create a new workbook
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet Worksheet = workbook.Worksheets[0];
                // Import data from the data table
                Worksheet.ImportDataTable(dt, true, 1, 1, true);
                // Create Excel table or listobject and apply table style
                IListObject table = Worksheet.ListObjects.Create("Payroll_Reports", Worksheet.UsedRange);

                table.BuiltInTableStyle = TableBuiltInStyles.TableStyleLight11;
                // Autofit the columns
                Worksheet.UsedRange.AutofitColumns();
                // Save the file

                Stream excelStream = File.Create(Path.GetFullPath(@" DataTable - to - Excel" + i.ToString() + ".xlsx "));
                i++;

                workbook.SaveAs(excelStream);
                excelStream.Dispose();
            }
        }
        public void tagadelete()
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("delete from Payroll", connection);
            command.ExecuteNonQuery();
        }
        public void tagaInsertPayroll()
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            string ExportAndArchive = " insert into Payroll (EmployeeID,BasicRate,TotalRecordHours,TotalRegularhours,TotalOvertimeHours,GrossSalary) " +
                   "select A.EmployeeID, A.BasicRate, A.TotalHours, A.TotalHours-A.OverTimeHours, A.OverTimeHours, A.GrossSalary from Computation A group by A.EmployeeID , A.BasicRate, A.TotalHours, A.OverTimeHours, A.GrossSalary " +
                   " insert into PayrollArchive select * from Payroll ";
            SqlCommand command = new SqlCommand(ExportAndArchive, connection);
            command.ExecuteNonQuery();
        }

        private void dgvDailyPayrollReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDailyPayrollReport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvDailyPayrollReport.CurrentRow.Selected = true;
            }
        }
    }
}