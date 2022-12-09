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

namespace Admin_Login
{
    public partial class THMonthView : Form
    {
        public THMonthView()
        {
            InitializeComponent();
        }

        //Dropshadow
        private const int CS_DropShadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }

        private void THMonthView_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM dd, yyyy";

            Login login = new Login();
            using (SqlConnection con = new SqlConnection(login.connectionString))
            {
                string query = 
                    "SELECT " +
                    "THMonthsSalary.THMonthID, " +
                    "THMonthsSalary.EmployeeID, " +
                    "EmployeeInfo.EmployeeFullName, " +
                    "THMonthsSalary.THMonthSalary, " +
                    "THMonthsSalary.Description " +
                    "FROM THMonthsSalary  " +
                    "INNER JOIN EmployeeInfo " +
                    "ON THMonthsSalary.EmployeeID = EmployeeInfo.EmployeeID " +
                    "WHERE CheckMonth > 1";

                SqlCommand cmd = new SqlCommand(
                    query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                // Column font
                this.dgvTHMonthPayView.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                // Row font
                this.dgvTHMonthPayView.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvTHMonthPayView.DataSource = dt;
                dgvTHMonthPayView.Columns["THMonthID"].Visible = false;

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
