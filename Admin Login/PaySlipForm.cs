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
using WordToPDF;




namespace Admin_Login
{
    public partial class PaySlipForm : Form
    {
        Login login = new Login();
        PayrollReport pr = new PayrollReport();
        SaveFileDialog sfd = new SaveFileDialog();
        string EmpID = "", filepath,filename ;       
        ArrayList getImage = new ArrayList();
        string _datefrom, _dateto;
        
        public PaySlipForm(string datefrom, string dateto)
        {
            InitializeComponent();
            _datefrom = datefrom;
            _dateto = dateto;
        }
        public void createDocs()
        {
            try
            {
                Document document = new Document();
                PageOrientation po = new PageOrientation();
                Section section = document.AddSection();
                section.PageSetup.Orientation = PageOrientation.Landscape;
                Paragraph add = section.AddParagraph();
                foreach (string item in getImage)
                {
                    add.AppendPicture(item.ToString());
                    //File.Delete(item.ToString());
                }
                document.SaveToFile(@sfd.FileName.ToString() + ".docx", FileFormat.Docx);
                convertToPDF();
                File.Delete(@sfd.FileName.ToString() + ".docx");
                System.Diagnostics.Process.Start(@sfd.FileName.ToString() + ".pdf");
            }
            catch (Exception ex) { }
        }
        public void convertToPDF()
        {
            Word2Pdf objWorPdf = new Word2Pdf();
            string backfolder1 = filepath;
            string strFileName = filename+".docx";
            object FromLocation = backfolder1 + "\\" + strFileName;
            string FileExtension = Path.GetExtension(strFileName);
            string ChangeExtension = strFileName.Replace(FileExtension, ".pdf");
            if (FileExtension == ".doc" || FileExtension == ".docx")
            {
                object ToLocation = backfolder1 + "\\" + ChangeExtension;
                objWorPdf.InputLocation = FromLocation;
                objWorPdf.OutputLocation = ToLocation;
                objWorPdf.Word2PdfCOnversion();
            }
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

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(sfd.FileName);
                    filepath = Path.GetFullPath(fi.DirectoryName);
                    filename = fi.Name;
                }
                foreach (DataRow row in data.Rows)
                {          
                    count++;
                    if (count <= data.Rows.Count)
                    {
                        EmpID = row.ItemArray[0].ToString();
                        getInfo();
                        getPaySlip();
                        
                    }
                    if(count == data.Rows.Count)
                    {
                        createDocs();
                        this.Close();
                    }
                }
            }
        }
        public void getPaySlip()
        {
            DateTime now = DateTime.Now;
            try
            {
                using (var bmp = new Bitmap(panel1.Width, panel1.Height))
                {
                    panel1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save(@filepath + "\\" + txtEmployeeName.Text +" "+ now.ToString("MMMM dd, yyyy") +".jpeg");
                    getImage.Add(@filepath + "\\" + txtEmployeeName.Text +" "+ now.ToString("MMMM dd, yyyy") + ".jpeg");
                }
            }
            catch(Exception ex) { }
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
                    
                    lblDatefrom.Text = _datefrom;
                    lblDateto.Text = _dateto;

                    txtEmployeeID.Text = data.Rows[0][0].ToString();
                    txtEmployeeName.Text = data.Rows[0][1].ToString();
                    string position = data.Rows[0][2].ToString() + " ₱" + data.Rows[0][3].ToString() + "/Hour";
                    txtPosition.Text = position;
                    txtRegularHours.Text = data.Rows[0][4].ToString();
                    txtRegularPay.Text = data.Rows[0][5].ToString();
                    double otmin = (Convert.ToDouble(data.Rows[0][6].ToString()) / 1.30) / Convert.ToDouble(data.Rows[0][3].ToString());
                    //------OverTimeHours convertion to 0:0----
                    int x = otmin.ToString().Length;
                    string decimalNumbers = "";
                    StringBuilder wholeNumber = new StringBuilder();
                    for (int i = 0; i < x; i++)
                    {
                        if (otmin.ToString()[i] == '.')
                        {
                            decimalNumbers = "0." + otmin.ToString().Substring(i + 1, x - i - 1);
                            i = 0;
                            break;
                        }
                        wholeNumber.Append(otmin.ToString()[i]);
                    }
                    decimal y;
                    try
                    {
                        y = Convert.ToDecimal(decimalNumbers) * 60;
                    }
                    catch (Exception e)
                    {
                        y = 0;
                    }
                    var g = Math.Round(y, 0);
                    txtOvertimeHrs.Text = wholeNumber.ToString() + ":" + g;
                    //---------------------------------------
                    txtOvertimePay.Text = data.Rows[0][6].ToString();
                    double rhHrs = (Convert.ToDouble(data.Rows[0][7].ToString()) / (Convert.ToDouble(data.Rows[0][3].ToString()) / 60)) / 60;
                    //------LegalHolidayHours convertion to 0:0----
                    int r = rhHrs.ToString().Length;
                    string decimalNumbersR = "";
                    StringBuilder wholeNumberR = new StringBuilder();
                    for (int i = 0; i < r; i++)
                    {
                        if (rhHrs.ToString()[i] == '.')
                        {
                            decimalNumbersR = "0." + rhHrs.ToString().Substring(i + 1, r - i - 1);
                            i = 0;
                            break;
                        }
                        wholeNumberR.Append(rhHrs.ToString()[i]);
                    }
                    decimal h;
                    try
                    {
                        h = Convert.ToDecimal(decimalNumbersR) * 60;
                    }
                    catch (Exception e)
                    {
                        h = 0;
                    }
                    var m = Math.Round(h, 0);
                    txtRegularHolidayHrs.Text = wholeNumberR + ":" + m;
                    //---------------------------------------
                    double Rholidaypay = Convert.ToDouble(data.Rows[0][7].ToString());
                    txtRHolidayPay.Text = Rholidaypay.ToString("n2");
                    double S_holiday = (Convert.ToDouble(data.Rows[0][8].ToString()) / Convert.ToDouble(data.Rows[0][3].ToString()) / 0.30);
                    //------SpecialHolidayHours convertion to 0:0----
                    int s = S_holiday.ToString().Length;
                    string decimalNumbersS = "";
                    StringBuilder wholeNumberS = new StringBuilder();
                    for (int i = 0; i < s; i++)
                    {
                        if (S_holiday.ToString()[i] == '.')
                        {
                            decimalNumbersS = "0." + S_holiday.ToString().Substring(i + 1, r - i - 1);
                            i = 0;
                            break;
                        }
                        wholeNumberS.Append(S_holiday.ToString()[i]);
                    }
                    decimal c;
                    try
                    {
                        c = Convert.ToDecimal(decimalNumbersS) * 60;
                    }
                    catch (Exception e)
                    {
                        c = 0;
                    }
                    var q = Math.Round(h, 0);
                    txtSpecialHoliday.Text = wholeNumberS + ":" + q;
                    //---------------------------------------
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
                    txtTotalDeduction.Text = "₱" + totaldeduct.ToString("n2");
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
