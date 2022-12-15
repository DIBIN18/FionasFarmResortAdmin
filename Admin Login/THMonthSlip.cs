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
    public partial class THMonthSlip : Form
    {       
        SaveFileDialog sfd = new SaveFileDialog();
        Login login = new Login();
        string EmpID = "", filepath, filename;
        ArrayList getImage = new ArrayList();

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
                    string query = "SELECT EmployeeID,EmployeeName,YearlyBasicPay,THMonthSalary FROM THMonthsSalary";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    //txtEmployeeID.Text = data.Rows[0][1].ToString();
                    //txtEmployeeName.Text = data.Rows[0][2].ToString();
                    //txtTotalBasic.Text = data.Rows[0][4].ToString();
                    //txtTotal.Text = data.Rows[0][5].ToString();

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            getMonthPay();
            this.Close();
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
