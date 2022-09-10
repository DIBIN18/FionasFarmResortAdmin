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
    public partial class AddEmployee : Form
    {
        //PAUL CONNECTION STRING
        public string connectionString = @"Data Source=DESKTOP-0Q352R7\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeInfo(FirstName,LastName,MiddleName,Address,SSS_ID,PAGIBIG_NO,PHILHEALTH_NO,Email,EmployeeMaritalStatus,ContactNumber,DateHired,Gender,BirthDate,Department,Position,JobStatus)" +
                "VALUES(@FirstName,@LastName,@MiddleName,@Address,@SSS_ID,@PAGIBIG_NO,@PHILHEALTH_NO,@Email,@EmployeeMaritalStatus,@ContactNumber,@DateHired,@Gender,@BirthDate,@Department,@Position,@JobStatus)", conn);
            cmd.Parameters.AddWithValue("@FirstName", txtfname.Text);
            cmd.Parameters.AddWithValue("@LastName", txtlname.Text);
            cmd.Parameters.AddWithValue("@MiddleName", txtmname.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@SSS_ID", txtSSSID.Text);
            cmd.Parameters.AddWithValue("@PAGIBIG_NO", txtPagibigNo.Text);
            cmd.Parameters.AddWithValue("@PHILHEALTH_NO", txtPhilhealthNo.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmailAdd.Text);
            cmd.Parameters.AddWithValue("@EmployeeMaritalStatus", txtMarriageStatus.Text);
            cmd.Parameters.AddWithValue("@ContactNumber", txtContactNum.Text);
            cmd.Parameters.AddWithValue("@DateHired", txtDateHired.Text);
            cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
            cmd.Parameters.AddWithValue("@BirthDate", txtBirthDate.Value.ToString("dd-mm-yyyy"));
            cmd.Parameters.AddWithValue("@Department",txtDepartment.Text);
            cmd.Parameters.AddWithValue("@Position", txtPosition.Text);
            cmd.Parameters.AddWithValue("@JobStatus", txtJobStatus.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully failed!");
            clearAll();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];           
            menu.Text = "Fiona's Farm and Resort - Employee List";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }
        public void clearAll()
        {
            txtfname.Text = "";
            txtlname.Text = "";
            txtmname.Text = "";
            txtAddress.Text = "";
            txtSSSID.Text = "";
            txtPagibigNo.Text = "";
            txtPhilhealthNo.Text = "";
            txtEmailAdd.Text = "";
            txtMarriageStatus.Text = "";
            txtContactNum.Text = "";
            txtDateHired.Text = "";
            txtGender.Text = "";
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }
    }

 }


