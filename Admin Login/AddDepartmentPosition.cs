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
    public partial class AddDepartmentPosition : Form
    {
        AddEmployee ae = new AddEmployee();
        Login login = new Login();
        public AddDepartmentPosition()
        {
            InitializeComponent();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Department(DepartmentName)Values(@DepartmentName)", conn);
            cmd.Parameters.AddWithValue("@DepartmentName", txtDepartmentName.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("New Department Has been Added");
            txtDepartmentName.Text = "";
        }
    }
}
