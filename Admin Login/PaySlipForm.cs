using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Documents;


namespace Admin_Login
{
    public partial class PaySlipForm : Form
    {
        Login login = new Login();
        SSSRangeClass sssclass = new SSSRangeClass();
        PayrollReport pr = new PayrollReport();
        FolderBrowserDialog selectedfile = new FolderBrowserDialog();
        string EmpID = "", filepath ;       
        ArrayList getImage = new ArrayList();
        public PaySlipForm()
        {
            InitializeComponent();
        }
        public void createDocs()
        {
            Document document = new Document();
            Section section = document.AddSection();
            Paragraph add = section.AddParagraph();
            foreach(string item in getImage)
            {
                add.AppendPicture(item.ToString());
                Console.WriteLine(item.ToString() + "qwe");
            }
            document.SaveToFile(@filepath +"\\mydocs.docx", FileFormat.Docx);
        }
        private void PaySlipForm_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            {
                connection.Open();
                string query = "select EmployeeID from PayrollReport";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                int count = 0;

                if (selectedfile.ShowDialog() == DialogResult.OK)
                {
                    filepath = selectedfile.SelectedPath;
                    Console.WriteLine(filepath);
                }
                    foreach (DataRow row in data.Rows)
                {          
                    count++;
                    if (count <= data.Rows.Count)
                    {
                        EmpID = row.ItemArray[0].ToString();
                        getInfo();
                        ExportPaySlip();
                        
                    }
                    if(count == data.Rows.Count)
                    {
                        createDocs();
                        this.Close();
                    }
                }
            }
        }
        public void ExportPaySlip()
        {
            using (var bmp = new Bitmap(panel1.Width, panel1.Height))
            {
                panel1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));             
                bmp.Save(@filepath + "\\" +txtEmployeeName.Text + ".jpeg");
                getImage.Add(@filepath + "\\" + txtEmployeeName.Text + ".jpeg");
            }
        }
        public void getInfo()
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            {
                connection.Open();
                string query = "select * from PayrollReport where EmployeeID = " + EmpID;
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                try
                {
                    lblDatefrom.Text = pr.dtp_From.Value.ToString("MMMM dd, yyyy");
                    lblDateto.Text = pr.dtp_To.Value.ToString("MMMM dd, yyyy");
                    txtEmployeeID.Text = data.Rows[0][0].ToString();
                    txtEmployeeName.Text = data.Rows[0][1].ToString();
                    string position = data.Rows[0][2].ToString() + " ₱" + data.Rows[0][3].ToString() + "/Hour";
                    txtPosition.Text = position;
                    txtRegularHours.Text = data.Rows[0][4].ToString();
                    txtRegularPay.Text = data.Rows[0][5].ToString();
                    double otmin = (Convert.ToDouble(data.Rows[0][6].ToString()) / 1.30) / Convert.ToDouble(data.Rows[0][3].ToString());
                    txtOvertimeHrs.Text = otmin.ToString();
                    txtOvertimePay.Text = data.Rows[0][6].ToString();
                    double rhHrs = (Convert.ToDouble(data.Rows[0][7].ToString()) / (Convert.ToDouble(data.Rows[0][3].ToString()) / 60)) / 60;
                    txtRegularHolidayHrs.Text = rhHrs.ToString();
                    double Rholidaypay = Convert.ToDouble(data.Rows[0][7].ToString());
                    txtRHolidayPay.Text = Rholidaypay.ToString("n2");
                    double S_holiday = (Convert.ToDouble(data.Rows[0][8].ToString()) / Convert.ToDouble(data.Rows[0][3].ToString()) / 0.30);
                    txtSpecialHoliday.Text = S_holiday.ToString("n2");
                    double S_holidaypay = Convert.ToDouble(data.Rows[0][8].ToString());
                    txtSpHolidayPay.Text = S_holidaypay.ToString("n2");
                    txtLeavedays.Text = data.Rows[0][10].ToString();
                    double leavepay = (Convert.ToDouble(data.Rows[0][10].ToString()) * 8) * Convert.ToDouble(data.Rows[0][3].ToString());
                    txtLeavePay.Text = leavepay.ToString("n2");
                    txtGrossPay.Text = "₱" + data.Rows[0][11].ToString();
                    txtTardinessMins.Text = data.Rows[0][12].ToString();
                    double tardiness = Convert.ToDouble(data.Rows[0][12].ToString()) * (Convert.ToDouble(data.Rows[0][3].ToString()) / 60);
                    txtLateAmount.Text = tardiness.ToString("n2");
                    txtUnderTimeMin.Text = data.Rows[0][13].ToString();
                    double undertime = Convert.ToDouble(data.Rows[0][13].ToString()) * (Convert.ToDouble(data.Rows[0][3].ToString()) / 60);
                    txtUndertimeAmount.Text = undertime.ToString("n2");
                    txtSSS.Text = data.Rows[0][14].ToString();
                    txtPagIbig.Text = data.Rows[0][15].ToString();
                    txtPhilHealth.Text = data.Rows[0][16].ToString();
                    txtTaxAmount.Text = data.Rows[0][17].ToString();
                    txtOtherDeductions.Text = data.Rows[0][18].ToString();
                    txtNetPay.Text = "₱" + data.Rows[0][19].ToString();
                    double totaldeduct = Convert.ToDouble(data.Rows[0][14].ToString()) + Convert.ToDouble(data.Rows[0][15].ToString()) + Convert.ToDouble(data.Rows[0][16].ToString()) + Convert.ToDouble(data.Rows[0][17].ToString()) + Convert.ToDouble(data.Rows[0][18].ToString());
                    txtTotalDeduction.Text = totaldeduct.ToString("n2");
                }
                catch (Exception ex)
                {
                    txtRegularHours.Text = "";
                    txtOvertimeHrs.Text = "";
                    txtOvertimePay.Text = "";
                    txtRegularPay.Text = "";
                    txtRegularHolidayHrs.Text = "";
                    txtRHolidayPay.Text = "";
                    txtSpecialHoliday.Text = "";
                    txtSpHolidayPay.Text = "";
                    txtGrossPay.Text = "";
                    txtTardinessMins.Text = "";
                    txtUnderTimeMin.Text = "";
                    txtSSS.Text = "";
                    txtPagIbig.Text = "";
                    txtPhilHealth.Text = "";
                    txtTaxAmount.Text = "";
                    txtTotalDeduction.Text = "";
                    txtNetPay.Text = "";
                }
            }
        }
    }
}
