using iTextSharp.text.pdf.codec;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Admin_Login
{
    public partial class THMonthSlip : Form
    {
        SaveFileDialog filepath = new SaveFileDialog();
        Login login = new Login();
        
        public THMonthSlip()
        {
            InitializeComponent();
        }

        public void getMonthPay()
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
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
        }
        public void getPaySlip()
        {
            try
            {
                using (var bmp = new Bitmap(panel1.Width, panel1.Height))
                {
                    panel1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save(@filepath + "\\" + txtEmployeeName.Text + ".jpeg");
                    //getImage.Add(@filepath + "\\" + txtEmployeeName.Text + ".jpeg");
                }
            }
            catch (Exception ex) { }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            getMonthPay();
        }
    }
}
