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
    public partial class AddNewUser : Form
    {
        public AddNewUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            Settings settings = new Settings();
            using (SqlConnection con = new SqlConnection(login.connectionString))
            {

                try
                {
                    con.Open();
                    if(cmbUserName.Items.Count == 0)
                    {
                        button1.Enabled = false;
                    }
                    else
                    {
                        button1.Enabled = true;

                        SqlCommand cmd = new SqlCommand("Insert into Users(User_,Username_,Password_,DashBoard,EmployeeList,Leave,DepartmentPosition,Deductions,AttendanceRecord,PayrollReport,HolidaySetting,Settings)Values(@User,@Username,@Password,@DashBoard,@EmployeeList,@Leave,@DepartmentPosition,@Deductions,@AttendanceRecord,@PayrollReport,@HolidaySetting,@Settings) ", con);
                        cmd.Parameters.AddWithValue("@User", cmbUserName.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPass.Text);

                        if (DashBoard.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@DashBoard", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@DashBoard", 0);
                        }
                        if (EmployeeList.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@EmployeeList", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@EmployeeList", 0);
                        }
                        if (Leave.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@Leave", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Leave", 0);
                        }
                        if (DepartmentPosition.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@DepartmentPosition", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@DepartmentPosition", 0);
                        }
                        if (Deductions.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@Deductions", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Deductions", 0);
                        }
                        if (AttendanceRecord.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@AttendanceRecord", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@AttendanceRecord", 0);
                        }
                        if (PayrollReport.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@PayrollReport", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@PayrollReport", 0);
                        }
                        if (HolidaySetting.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@HolidaySetting", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@HolidaySetting", 0);
                        }
                        if (Settings.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@Settings", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Settings", 0);
                        }
                        cmd.ExecuteNonQuery();
                        DialogResult dialogResult = MessageBox.Show("New User Has beed Added!", "Successful!", MessageBoxButtons.OK);
                        if (dialogResult == DialogResult.OK)
                        {
                            cmbUserName.Text = "";
                            txtPass.Text = "";
                            txtUser.Text = "";

                        }
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    //Some Errors!
                }
               
            }

        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {
            
            cmbUserName.Items.Add("HR");
            cmbUserName.Items.Add("timekeeper");
            
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            Font font = new Font(lblCancel.Font, FontStyle.Underline);
            lblCancel.Font = font;
            this.Close();
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            txtPass.Text = "";
            txtPass.PasswordChar = '*';
        }
    }
}
