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
using Syncfusion.XlsIO;
using WordToPDF;


namespace Admin_Login
{
    public partial class THMonthSlip : Form
    {       
        SaveFileDialog sfd = new SaveFileDialog();
        Login login = new Login();
        string EmpID = "", filepath, filename;
        ArrayList getImage = new ArrayList();
        DataTable dt = new DataTable();
        FileInfo fi;
        int i = 1;

        public THMonthSlip()
        {
            InitializeComponent();
        }

        public void getMonthPay()
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            {
                try
                {
                    connection.Open();
                    string query = "SELECT EmployeeID,EmployeeName,YearlyBasicPay,THMonthSalary,THYear FROM THMonthsSalary where THMonthID = " + EmpID;
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    txtEmployeeID.Text = data.Rows[0][0].ToString();
                    txtEmployeeName.Text = data.Rows[0][1].ToString();
                    txtTotalBasic.Text = data.Rows[0][2].ToString();
                    txtTotal.Text = data.Rows[0][3].ToString();
                    lblDatefrom.Text = data.Rows[0][4].ToString();

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        public void getPaySlip()
        {
            try
            {
                using (var bmp = new Bitmap(panel1.Width, panel1.Height))
                {
                    panel1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save(@filepath + "\\" + txtEmployeeName.Text + ".jpeg");
                    getImage.Add(@filepath + "\\" + txtEmployeeName.Text + ".jpeg");
                }
            }
            catch (Exception ex) { }
        }
        public void get13MPReport()
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            {
                connection.Open();
                string query = "SELECT EmployeeID,EmployeeName,YearlyBasicPay as AnualBasic,THMonthSalary as ThMonthPay,THYear as Year FROM THMonthsSalary where THYear = FORMAT(GetDATE(),'yyyy')";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(dt);

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
                    Worksheet.Range["A2"].Text = "13th Month Pay ";
                    Worksheet.Range["A2"].CellStyle = style3;
                    Worksheet.Range["A3"].Text = "Year : " + dt.Rows[0][4].ToString(); ;
                    Worksheet.Range["A3"].CellStyle = style3;
                    Worksheet.ImportDataTable(dt, true, 4, 1, true);

                    //IListObject table = Worksheet.ListObjects.Create("Payroll_Reports", Worksheet.UsedRange);
                    //table.BuiltInTableStyle = TableBuiltInStyles.TableStyleLight11;

                    int ir = 4, reset = 0;
                    Worksheet.Range[4, 1, 4, 21].AutofitColumns();
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

                    filepath = sfd.FileName.ToString();
                    fi = new FileInfo(Path.GetFullPath(filepath + ".xlsx "));
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
        private void THMonthSlip_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            {
                    connection.Open();
                    string query = "select * FROM THMonthsSalary WHERE THYear = FORMAT(GetDATE(),'yyyy')";
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
                    else
                {
                    this.Close();
                }
                    foreach (DataRow row in data.Rows)
                    {
                        count++;
                        if (count <= data.Rows.Count)
                        {
                            EmpID = row.ItemArray[0].ToString();
                        Console.WriteLine(EmpID);
                            getMonthPay();
                            getPaySlip();

                        }
                        if (count == data.Rows.Count)
                        {
                            createDocs();
                            get13MPReport();
                            this.Close();
                        }
                    }
            }
            
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
                    File.Delete(item.ToString());
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
            string strFileName = filename + ".docx";
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
    }
}
