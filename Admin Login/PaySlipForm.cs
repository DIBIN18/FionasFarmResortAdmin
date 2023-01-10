using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
        String sfd = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Payslips\\";
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
            DateTime now = DateTime.Now;
            filename = now.ToString("MMMM dd, yyyy");

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

                document.SaveToFile(@sfd + filename + " - Payslip.docx", FileFormat.Docx);

                convertToPDF();

                File.Delete(@sfd + filename + " - Payslip.docx");
                System.Diagnostics.Process.Start(@sfd + ".pdf");
            }
            catch (Exception ex) { }
        }
        public void convertToPDF()
        {
            DateTime now = DateTime.Now;
            filename = now.ToString("MMMM dd, yyyy");

            Word2Pdf objWorPdf = new Word2Pdf();
            string backfolder1 = filepath;
            string strFileName = filename + " - Payslip.docx";
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

                //if (sfd.ShowDialog() == DialogResult.OK)
                //{
                //    FileInfo fi = new FileInfo(sfd.FileName);
                //    filepath = Path.GetFullPath(fi.DirectoryName);
                //    filename = fi.Name;
                //}

                FileInfo fi = new FileInfo(sfd);
                filepath = Path.GetFullPath(fi.DirectoryName);
                filename = fi.Name;

                foreach (DataRow row in data.Rows)
                {          
                    count++;
                    if (count <= data.Rows.Count)
                    {
                        EmpID = row.ItemArray[0].ToString();
                        getInfo();
                        getPaySlip(EmpID);
                        
                    }
                    if(count == data.Rows.Count)
                    {
                        createDocs();

                        MessageBox.Show("Payslips Generated", "Payslips", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
            }
        }
        public void getPaySlip(string emp_id)
        {
            DateTime now = DateTime.Now;
            try
            {
                using (var bmp = new Bitmap(panel1.Width, panel1.Height))
                {
                    panel1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save(@filepath + "\\" + txtEmployeeName.Text +" "+ now.ToString("MMMM dd, yyyy") +".jpeg");
                    getImage.Add(@filepath + "\\" + txtEmployeeName.Text +" "+ now.ToString("MMMM dd, yyyy") + ".jpeg");

                    string attatchment_loc = @filepath + "\\" + txtEmployeeName.Text + " " + now.ToString("MMMM dd, yyyy") + ".jpeg";

                    sendEmail(getEmail(emp_id), getEmailSender(), attatchment_loc, emp_id, getPasswordSender());

                    Console.WriteLine(emp_id);
                }
            }
            catch(Exception ex) { }
        }


        //
        // SEND EMAIL
        //
        public void sendEmail(string receiver_email, string sender_email, string attatchment, string employ_id, string pw)
        {
            try
            {
                MailMessage mm = new MailMessage(sender_email, receiver_email);
                //if (txt_Subject.Text.Equals(" (no subject)")) txt_Subject.Text = "";
                mm.Subject = "Payslip Salary";
                mm.Body = "Payslip";
                mm.Attachments.Add(new Attachment(attatchment));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                System.Net.NetworkCredential nc = new NetworkCredential(sender_email, pw);
                smtp.EnableSsl = true;
                smtp.Credentials = nc;
                smtp.Send(mm);
                //MessageBox.Show("Mail has been sent successfully!");
            }
            catch (Exception ex)
            {
                //if (txt_Password.Text.Equals(" password") || txt_Password.Text.Equals("")) MessageBox.Show("Wrong password.");
                //else if (cb_To.Text.Equals(" sample@gmail.com")) MessageBox.Show("A recipient must be specified.");
                //else if (lbl_FileLocation.Text.Equals("")) MessageBox.Show("File attachment cannot be empty.");
                //else MessageBox.Show(ex.Message);
                MessageBox.Show("Error");
            }
        }

        public string getEmail(string emp_id)
        {
            string query2 = "SELECT Email FROM EmployeeInfo WHERE EmployeeID=" + emp_id;

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetString(0);
                        }
                        else
                        {
                            return "";
                        }

                    }
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        //
        //  SENDER INFO
        //
        public string getEmailSender()
        {
            string query2 = "SELECT Email FROM Sender";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetString(0);
                        }
                        else
                        {
                            return "";
                        }

                    }
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        public string getPasswordSender()
        {
            string query2 = "SELECT Pass FROM Sender";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetString(0);
                        }
                        else
                        {
                            return "";
                        }

                    }
                }
                catch (Exception e)
                {
                    return "";
                }
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
