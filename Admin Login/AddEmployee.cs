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
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-B80EBU7\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeInfo(FirstName,LastName,MiddleName,Address,SSS_ID,PAGIBIG_NO,PHILHEALTH_NO,Email,EmployeeMaritalStatus,ContactNumber,DateHired,Gender,BirthDate,Position,Department,JobStatus)" +
                "VALUES(@FirstName,@LastName,@MiddleName,@Address,@SSS_ID,@PAGIBIG_NO,@PHILHEALTH_NO,@Email,@EmployeeMaritalStatus,@ContactNumber,@DateHired,@Gender,@BirthDate,@Position,@Department,@JobStatus)", conn);
=======
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2NTMR5E\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeInfo(FirstName,LastName,MiddleName,Address,SSS_ID,PAGIBIG_NO,PHILHEALTH_NO,Email,EmployeeMaritalStatus,ContactNumber,DateHired,Gender)" +
                "VALUES(@FirstName,@LastName,@MiddleName,@Address,@SSS_ID,@PAGIBIG_NO,@PHILHEALTH_NO,@Email,@EmployeeMaritalStatus,@ContactNumber,@DateHired,@Gender)", conn);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            cmd.Parameters.AddWithValue("@BirthDate", txtBirthDate.Value.ToString("mm/dd/yy"));
            cmd.Parameters.AddWithValue("@Position", txtPosition.Text);
            cmd.Parameters.AddWithValue("@Position", txtDepartment.Text);
            cmd.Parameters.AddWithValue("@Position", txtJobDescription.Text);


=======
>>>>>>> Stashed changes
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


