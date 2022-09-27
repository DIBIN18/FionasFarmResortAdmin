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

        string selectedDepartmentName = "";
        long selectedDepartmentId = 0;

        string selectedPositionName = "";
        long selectedPositionId = 0;

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
            dtpScheduleIn.Format = DateTimePickerFormat.Time;
            dtpScheduleIn.ShowUpDown = true;

            dtpScheduleOut.Format = DateTimePickerFormat.Time;
            dtpScheduleOut.ShowUpDown = true;

            dtpScheduleIn.Format = DateTimePickerFormat.Custom;
            dtpScheduleIn.CustomFormat = "hh:mm:ss tt";

            dtpScheduleOut.Format = DateTimePickerFormat.Custom;
            dtpScheduleOut.CustomFormat = "hh:mm:ss tt";
        }

        private void btnRegister_Click(object sender, EventArgs e)
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
                    "ScheduleIn," +
                    "ScheduleOut)" + //Tinangal ko muna yung DepartmentID, PositionID,
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
                    "@ScheduleIn," +
                    "@ScheduleOut)";

                string schedIn = dtpScheduleIn.Value.ToString("hh:mm:ss tt");
                string schedOut = dtpScheduleOut.Value.ToString("hh:mm:ss tt");

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EmployeeFullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@SSS_ID", Int32.Parse(txtSSSID.Text));
                cmd.Parameters.AddWithValue("@PAGIBIG_NO", Int32.Parse(txtPagibigNo.Text));
                cmd.Parameters.AddWithValue("@PHIL_HEALTH_NO", Int32.Parse(txtPhilhealthNo.Text));
                cmd.Parameters.AddWithValue("@Email", txtEmailAdd.Text);
                cmd.Parameters.AddWithValue("@EmployeeMaritalStatus", txtCivilStatus.Text);
                cmd.Parameters.AddWithValue("@ContactNumber", Int32.Parse(txtContactNum.Text));
                cmd.Parameters.AddWithValue("@DateHired", txtDateHired.Value.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                cmd.Parameters.AddWithValue("@BirthDate", txtDateofBirth.Value.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@DepartmentID", selectedDepartmentId);
                cmd.Parameters.AddWithValue("@PositionID", selectedPositionId);
                cmd.Parameters.AddWithValue("@EmploymentType", txtEmploymentType.Text);
                cmd.Parameters.AddWithValue("@ScheduleIn", schedIn.ToUpper());
                cmd.Parameters.AddWithValue("@ScheduleOut", schedOut.ToUpper());
                

                //Compute Age Using DateTimePicker
                int currentAge = DateTime.Today.Year - txtDateofBirth.Value.Year;

                cmd.Parameters.AddWithValue("@Age", currentAge.ToString());
                cmd.ExecuteNonQuery();
                insertNewEmployeeToDeductionTable();
                MessageBox.Show("Successfully failed!");
                clearAll();
            }
        }
        public void insertNewEmployeeToDeductionTable()
        {
            string query = "insert into Deductions " +
                           "(EmployeeID, " +
                           "SSSContribution, " +
                           "PagIbigContribution, " +
                           "PhilHealthContribution, " +
                           "OtherDeduction, " +
                           "TotalDeductions)" +
                           "select EmployeeID = MAX(A.EmployeeID) ,0.00, 0.00, 0.00, 0.00, 0.00 from EmployeeInfo as A";
            
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];           
            menu.Text = "Fiona's Farm and Resort - Employee List";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
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
                    "SELECT PositionName FROM Position WHERE DepartmentID='" + selectedDepartmentId + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet data = new DataSet();
                adapter.Fill(data, "PositionName");
                cmbPosition.DisplayMember = "PositionName";
                cmbPosition.DataSource = data.Tables["PositionName"];
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
        }
    }
 }

