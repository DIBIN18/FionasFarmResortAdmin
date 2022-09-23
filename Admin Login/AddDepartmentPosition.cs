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
        public AddDepartmentPosition()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection();
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("Insert Into Department(DepartmentName)Values(@DepartmentName)",conn);
            //SqlCommand cmd2 = new SqlCommand("Insert Into Position(PositionName)Values(@PositionName)", conn);
            //cmd.Parameters.AddWithValue("@DepartmentName", txtAddDepartment.Text);
            //cmd2.Parameters.AddWithValue("@PositionName", txtAddPosition.Text);

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
