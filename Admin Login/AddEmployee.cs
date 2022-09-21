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
        int rate, EmployeeIDholder;
        Login login = new Login();
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
           
            SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeInfo(FirstName,LastName,MiddleName,Address,SSS_ID,PAGIBIG_NO,PHILHEALTH_NO,Email,EmployeeMaritalStatus,ContactNumber,DateHired,Gender,BirthDate,DepartmentName,PositionName,EmploymentType,Age)" +
                "VALUES(@FirstName,@LastName,@MiddleName,@Address,@SSS_ID,@PAGIBIG_NO,@PHILHEALTH_NO,@Email,@EmployeeMaritalStatus,@ContactNumber,@DateHired,@Gender,@BirthDate,@DepartmentName,@PositionName,@EmploymentType,@Age)", conn);
            cmd.Parameters.AddWithValue("@FirstName", txtfname.Text);
            cmd.Parameters.AddWithValue("@LastName", txtlname.Text);
            cmd.Parameters.AddWithValue("@MiddleName", txtmname.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@SSS_ID", txtSSSID.Text);
            cmd.Parameters.AddWithValue("@PAGIBIG_NO", txtPagibigNo.Text);
            cmd.Parameters.AddWithValue("@PHILHEALTH_NO", txtPhilhealthNo.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmailAdd.Text);
            cmd.Parameters.AddWithValue("@EmployeeMaritalStatus", txtCivilStatus.Text);
            cmd.Parameters.AddWithValue("@ContactNumber", txtContactNum.Text);
            cmd.Parameters.AddWithValue("@DateHired", txtDateHired.Value.ToString("MM/dd/yyyy"));
            cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
            cmd.Parameters.AddWithValue("@BirthDate", txtDateofBirth.Value.ToString("MM/dd/yyyy"));
            cmd.Parameters.AddWithValue("@DepartmentName", txtDepartment.Text);
            cmd.Parameters.AddWithValue("@PositionName", txtPosition.Text);
            cmd.Parameters.AddWithValue("@EmploymentType", txtJobStatus.Text);
        
            //Compute Age Using DateTimePicker
            int currentAge = DateTime.Today.Year - txtDateofBirth.Value.Year;
            cmd.Parameters.AddWithValue("@Age", currentAge.ToString());
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully failed!");
            clearAll();
            Fill_Position_Tablesql();
        }

        public void Fill_Position_Tablesql()
        {
            if (txtPosition.SelectedItem.Equals("MANAGER"))
            {
                rate = 90;
            }
            else if (txtPosition.SelectedItem.Equals("CASHIER"))
            {
                rate = 63;
            }
            else if (txtPosition.SelectedItem.Equals("HOUSEKEEPING"))
            {
                rate = 56;
            }
            else if (txtPosition.SelectedItem.Equals("SECURITY GUARD"))
            {
                rate = 57;
            }
            else if (txtPosition.SelectedItem.Equals("LANDSCAPE ARTIST"))
            {
                rate = 55;
            }
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT MAX(EmployeeID) FROM EmployeeInfo; ", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
            adapter.Fill(dt);
            cmd2.ExecuteNonQuery();
            EmployeeIDholder = Convert.ToInt32(dt.Rows[0][0]);

            SqlCommand cmd = new SqlCommand("INSERT INTO Position(PositionName,DepartmentName,BasicRate,EmployeeID)" +
                "VALUES(@PositionName,@DepartmentName,@BasicRate,@EmployeeID)", conn);
            cmd.Parameters.AddWithValue("@PositionName", txtPosition.Text);
            cmd.Parameters.AddWithValue("@DepartmentName", txtDepartment.Text);
            cmd.Parameters.AddWithValue("@BasicRate", rate);
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeIDholder);
            cmd.ExecuteNonQuery();
            conn.Close();
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
            txtCivilStatus.Text = "";
            txtContactNum.Text = "";
            txtDateHired.Text = "";
            txtGender.Text = "";
        }
    }

 }

