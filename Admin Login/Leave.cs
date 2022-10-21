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
    public partial class Leave : Form
    {
        Login login = new Login();
        public Leave()
        {
            InitializeComponent();
        }
       
        //private void Tb_Search_Enter(object sender, EventArgs e)
        //{
        //    if (tb_Search.Text == " Search")
        //    {
        //        tb_Search.Text = "";
        //        tb_Search.ForeColor = Color.Black;
        //    }
        //}
        //private void Tb_Search_Leave(object sender, EventArgs e)
        //{
        //    if (tb_Search.Text == "")
        //    {
        //        tb_Search.Text = " Search";
        //        tb_Search.ForeColor = Color.Silver;
        //    }
        //}
     
    
        public void AdvancedDay_Offs_Load(object sender, EventArgs e) 
        {
            //using (SqlConnection connection = new SqlConnection(login.connectionString))
            //{
            //    connection.Open();
            //    string query =
            //        "SELECT L.LeaveID, E.EmployeeID, E.EmployeeFullName, L.StartDate, L.EndDate, L.Reason " +
            //        "FROM Leave AS L " +
            //        "LEFT JOIN EmployeeInfo AS E " +
            //        "ON L.EmployeeID = E.EmployeeID";   
            //    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            //    DataTable data = new DataTable();
            //    adapter.Fill(data);
            //    dgvLeave.DataSource = data;
            //}
        }
        private void btn_ApplyLeave_Click(object sender, EventArgs e)
        {
            //Menu menu = (Menu)Application.OpenForms["Menu"];
            //menu.Text = "Fiona's Farm and Resort - Apply Leave";
            //menu.Menu_Load(menu, EventArgs.Empty);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LeaveEmployeeList leaveEmployeeList = new LeaveEmployeeList();
            leaveEmployeeList.ShowDialog();
        }
    }
}