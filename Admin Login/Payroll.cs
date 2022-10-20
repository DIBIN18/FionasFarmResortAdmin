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
    public partial class Payroll : Form
    {
        Login login = new Login();
        SSSRangeClass range = new SSSRangeClass();
        public Payroll()
        {
            InitializeComponent();
            
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {

            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Payroll Report";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        public void Payroll_Load(object sender, EventArgs e)
        {
            /*PayrollReport payrollReport = new PayrollReport();
            //txtEmployeeID.Text dito mo ilalagay 'yung select, reference mo 'yung text ni txtEmployeeID
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            string filldt = "select A.EmployeeID, EmployeeFullname,DepartmentName, PositionName " +
                " from EmployeeInfo as A " +
                " left join Department as B " +
                " on A.DepartmentID = B.DepartmentID " +
                " left join Position as C " +
                " on A.PositionID = C.PositionID " +
                " where A.EmployeeID = " + txtEmployeeID.Text +
                " group by A.EmployeeID, A.EmployeeFullName, B.DepartmentName, C.PositionName ";
            SqlCommand command = new SqlCommand(filldt, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            range.hold1 = datatable.Rows[0][1].ToString();*/


        }
    }
}