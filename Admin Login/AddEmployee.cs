using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Admin_Login
{
    public partial class AddEmployee : Form
    {
        public string FullNameFormat = @"^[a-zA-Z]+$";
        public string EmailFormat = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public string NumberDecimal = @"^-?\\d*(\\.\\d+)?$";
        Login login = new Login();
        string selectedDepartmentName = "";
        long selectedDepartmentId = 0;
        string selectedPositionName = "";
        long selectedPositionId = 0;
        string Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday;
        public AddEmployee()
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
        private void AddEmployee_Load(object sender, EventArgs e)
        {
            txtContactNum.Text = "(+63)";
            dtpScheduleIn.Format = DateTimePickerFormat.Time;
            dtpScheduleIn.ShowUpDown = true;

            dtpScheduleOut.Format = DateTimePickerFormat.Time;
            dtpScheduleOut.ShowUpDown = true;

            dtpBreakPeriod.Format = DateTimePickerFormat.Time;
            dtpBreakPeriod.ShowUpDown = true;

            dtpScheduleIn.Format = DateTimePickerFormat.Custom;
            dtpScheduleIn.CustomFormat = "hh:mm:ss tt";

            dtpScheduleOut.Format = DateTimePickerFormat.Custom;
            dtpScheduleOut.CustomFormat = "hh:mm:ss tt";

            dtpBreakPeriod.Format = DateTimePickerFormat.Custom;
            dtpBreakPeriod.CustomFormat = "hh:mm:ss tt";
        }      

        public void insertNewEmployeeSchedule()
        {
            string schedIn = dtpScheduleIn.Value.ToString("hh:mm:ss tt");
            string schedOut = dtpScheduleOut.Value.ToString("hh:mm:ss tt");
            string breakPer = dtpBreakPeriod.Value.ToString("hh:mm:ss tt");

            if (cbMonday.Checked)
            {
                Monday = "1";
            }
            else
            {
                Monday = "0";
            }

            if (cbTuesday.Checked)
            {
                Tuesday = "1";
            }
            else
            {
                Tuesday = "0";
            }

            if (cbWednesday.Checked)
            {
                Wednesday = "1";
            }
            else
            {
                Wednesday = "0";
            }

            if (cbThursday.Checked)
            {
                Thursday = "1";
            }
            else
            {
                Thursday = "0";
            }

            if (cbFriday.Checked)
            {
                Friday = "1";
            }
            else
            {
                Friday = "0";
            }

            if (cbSaturday.Checked)
            {
                Saturday = "1";
            }
            else
            {
                Saturday = "0";
            }

            if (cbSunday.Checked)
            {
                Sunday = "1";
            }
            else
            {
                Sunday = "0";
            }

            using (SqlConnection connection2 = new SqlConnection(login.connectionString))
            {
                connection2.Open();
                string query =
                    "INSERT INTO EmployeeSchedule (EmployeeID) SELECT EmployeeID = MAX(A.EmployeeID) FROM EmployeeInfo as A";

                string query2 =
                    "UPDATE EmployeeSchedule " +
                    "SET ScheduleIn ='" + schedIn.ToUpper() + "', " +
                    "ScheduleOut ='" + schedOut.ToUpper() +"', " +
                    "Monday ='" + Monday + "', " +
                    "Tuesday ='" + Tuesday + "', " +
                    "Wednesday ='" + Wednesday + "', " +
                    "Thursday ='" + Thursday + "', " +
                    "Friday ='" + Friday + "', " +
                    "Saturday ='" + Saturday + "', " +
                    "Sunday ='" + Sunday + "', " +
                    "BreakPeriod='" + breakPer.ToUpper() + "' " +
                    "WHERE EmployeeID = (SELECT MAX(EmployeeID) FROM EmployeeInfo)";

                SqlCommand cmd = new SqlCommand(query, connection2);
                SqlCommand cmd2 = new SqlCommand(query2, connection2);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
            }
        }

        private void txtDepartment_MouseClick(object sender, MouseEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT DepartmentName FROM Department";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet data = new DataSet();
                adapter.Fill(data, "DepartmentName");
                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.DataSource = data.Tables["DepartmentName"];
                cmbDepartment.SelectedIndex = -1;
                cmbPosition.SelectedIndex = -1;
            }
        }

        private void txtSSSID_TextChanged(object sender, EventArgs e)
        {
            if(txtSSSID.TextLength == 3)
            {
                txtSSSID.Text =txtSSSID.Text+ "-";
                txtSSSID.SelectionStart = txtSSSID.TextLength;
             
            }
            if (txtSSSID.TextLength == 6)
            {
                 txtSSSID.Text = txtSSSID.Text+ "-";
                txtSSSID.SelectionStart = txtSSSID.TextLength;
            }
        }

        private void txtPagibigNo_TextChanged(object sender, EventArgs e)
        {
            if (txtPagibigNo.TextLength == 4)
            {
                txtPagibigNo.Text = txtPagibigNo.Text + "-";
                txtPagibigNo.SelectionStart = txtPagibigNo.TextLength;

            }
            if (txtPagibigNo.TextLength == 9)
            {
                txtPagibigNo.Text = txtPagibigNo.Text + "-";
                txtPagibigNo.SelectionStart = txtPagibigNo.TextLength;
            }

        }

        private void txtPhilhealthNo_TextChanged(object sender, EventArgs e)
        {
        
            if (txtPhilhealthNo.TextLength == 2)
            {
                txtPhilhealthNo.Text = txtPhilhealthNo.Text + "-";
                txtPhilhealthNo.SelectionStart = txtPhilhealthNo.TextLength;

            }
            if (txtPhilhealthNo.TextLength == 12)
            {
                txtPhilhealthNo.Text = txtPhilhealthNo.Text + "-";
                txtPhilhealthNo.SelectionStart = txtPhilhealthNo.TextLength;
            }
        }

        private void txtContactNum_TextChanged(object sender, EventArgs e)
        {

            if(txtContactNum.TextLength == 0)
            {
                txtContactNum.Text = "(+63)" + txtContactNum.Text;
                txtContactNum.SelectionStart = txtContactNum.Text.Length;
            }

        }

        private void txtTIN_TextChanged(object sender, EventArgs e)
        {
            if (txtTIN.TextLength == 3)
            {
                txtTIN.Text = txtTIN.Text + "-";
                txtTIN.SelectionStart = txtTIN.TextLength;
            }
            if (txtTIN.TextLength == 7)
            {
                txtTIN.Text = txtTIN.Text + "-";
                txtTIN.SelectionStart = txtTIN.TextLength;
            }
            if (txtTIN.TextLength == 11)
            {
                txtTIN.Text = txtTIN.Text + "-";
                txtTIN.SelectionStart = txtTIN.TextLength;
            }
        }

        private void txtSSSID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPagibigNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPhilhealthNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedDepartmentName = cmbDepartment.GetItemText(cmbDepartment.SelectedItem);
            string query2 = "SELECT DepartmentID FROM Department WHERE DepartmentName='" + selectedDepartmentName + "'";
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        selectedDepartmentId = reader.GetInt64(0);
                        reader.Close();
                    }
                }
            }
            cmbPosition.SelectedIndex = -1;
        }
        private void txtPosition_MouseClick(object sender, MouseEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT PositionName FROM Position WHERE DepartmentID='" + selectedDepartmentId + "' AND Custom=0";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet data = new DataSet();
                adapter.Fill(data, "PositionName");
                cmbPosition.DisplayMember = "PositionName";
                cmbPosition.DataSource = data.Tables["PositionName"];
            }
        }
        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (!(Regex.IsMatch(txtFullName.Text, FullNameFormat)))
            {
                MessageBox.Show("Invalid Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Text = "";
            }
            else if(!(Regex.IsMatch(txtEmailAdd.Text, EmailFormat)))
            {
                MessageBox.Show("Invalid Email", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailAdd.Text = "";
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO EmployeeInfo(" +
                        "EmployeeFullName, " +
                        "Address, " +
                        "SSS_ID, " +
                        "PAGIBIG_NO, " +
                        "PHIL_HEALTH_NO, " +
                        "Email, " +
                        "EmployeeMaritalStatus, " +
                        "ContactNumber, " +
                        "DateHired, " +
                        "Gender, " +
                        "BirthDate, " +
                        "EmploymentType, " +
                        "Age," +
                        "DepartmentID," +
                        "PositionID," +
                        "AccumulatedDayOffs," +
                        "SickLeaveCredits," +
                        "VacationLeaveCredits," +
                        "TIN," +
                        "Status)" +
                        "VALUES(" +
                        "@EmployeeFullName, " +
                        "@Address, " +
                        "@SSS_ID, " +
                        "@PAGIBIG_NO, " +
                        "@PHIL_HEALTH_NO, " +
                        "@Email, " +
                        "@EmployeeMaritalStatus, " +
                        "@ContactNumber, " +
                        "@DateHired, " +
                        "@Gender, " +
                        "@BirthDate, " +
                        "@EmploymentType, " +
                        "@Age," +
                        "@DepartmentID," +
                        "@PositionID," +
                        "@AccumulatedDayOffs," +
                        "@SickLeaveCredits," +
                        "@VacationLeaveCredits," +
                        "@TIN," +
                        "@Status)";
                    string schedIn = dtpScheduleIn.Value.ToString("hh:mm:ss tt");
                    string schedOut = dtpScheduleOut.Value.ToString("hh:mm:ss tt");
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@EmployeeFullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@SSS_ID", txtSSSID.Text);
                    cmd.Parameters.AddWithValue("@PAGIBIG_NO", txtPagibigNo.Text);
                    cmd.Parameters.AddWithValue("@PHIL_HEALTH_NO", txtPhilhealthNo.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmailAdd.Text);
                    cmd.Parameters.AddWithValue("@EmployeeMaritalStatus", txtCivilStatus.Text);
                    cmd.Parameters.AddWithValue("@ContactNumber", txtContactNum.Text); //ginawa kong string nalang kase contact number lang naman 'yan SHEESH - Devs, 11:07pm 2022 - 10 - 17
                    cmd.Parameters.AddWithValue("@DateHired", txtDateHired.Value.ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                    cmd.Parameters.AddWithValue("@BirthDate", txtDateofBirth.Value.ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@DepartmentID", selectedDepartmentId);
                    cmd.Parameters.AddWithValue("@PositionID", selectedPositionId);
                    cmd.Parameters.AddWithValue("@EmploymentType", txtEmploymentType.Text);
                    cmd.Parameters.AddWithValue("@AccumulatedDayOffs", 0);
                    cmd.Parameters.AddWithValue("@SickLeaveCredits", 0);
                    cmd.Parameters.AddWithValue("@VacationLeaveCredits", 0);
                    cmd.Parameters.AddWithValue("@TIN", txtTIN.Text);
                    cmd.Parameters.AddWithValue("@Status", "Active");

                    //Compute Age Using DateTimePicker
                    int currentAge = DateTime.Today.Year - txtDateofBirth.Value.Year;
                    cmd.Parameters.AddWithValue("@Age", currentAge.ToString());
                    cmd.ExecuteNonQuery();

                    insertNewEmployeeSchedule();
                    MessageBox.Show("Successfully Added Employee!");

                    clearAll();
                }
            }
        }
        private void cmbPosition_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedPositionName = cmbPosition.GetItemText(cmbPosition.SelectedItem);
            string query = "SELECT PositionID FROM Position WHERE PositionName='" + selectedPositionName + "'";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        selectedPositionId = reader.GetInt64(0);
                        reader.Close();
                    }
                }
            }
        }
        public void clearAll()
        {
            txtFullName.Text = "";
            txtAddress.Text = "";
            txtSSSID.Text = "";
            txtPagibigNo.Text = "";
            txtPhilhealthNo.Text = "";
            txtEmailAdd.Text = "";
            txtCivilStatus.Text = "";
            txtContactNum.Text = "";
            txtDateHired.Text = "";
            txtGender.Text = "";
            txtEmploymentType.Text = "";
            cmbDepartment.Text = "";
            cmbPosition.Text = "";
            txtTIN.Text = "";
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Employee List";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }
    }
 }