﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Admin_Login
{
    
    public partial class EmployeeProfile: Form
    {
        Login login = new Login();

        string selectedDepartmentName = "";
        long selectedDepartmentId = 0;

        string selectedPositionName = "";
        long selectedPositionId = 0;

        public EmployeeProfile()
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Edit_Mode_Off();
            this.Close();
        }

        private void EmployeeProfile_Load(object sender, EventArgs e)
        {
            dtpScheduleInEdit.Format = DateTimePickerFormat.Time;
            dtpScheduleInEdit.ShowUpDown = true;

            dtpSchedOutEdit.Format = DateTimePickerFormat.Time;
            dtpSchedOutEdit.ShowUpDown = true;

            dtpScheduleInEdit.Format = DateTimePickerFormat.Custom;
            dtpScheduleInEdit.CustomFormat = "hh:mm:ss tt";

            dtpSchedOutEdit.Format = DateTimePickerFormat.Custom;
            dtpSchedOutEdit.CustomFormat = "hh:mm:ss tt";
        }

        public void Edit_Mode()
        {
            btnEdit.Visible = false;
            btnSave.Visible = true;

            lblName.Visible = false;
            lblMaritalStatus.Visible = false;
            lblContact.Visible = false;
            lblEmail.Visible = false;
            lblDateHired.Visible = false;
            lblGender.Visible = false;
            lblAddress.Visible = false;
            lblEmploymentType.Visible = false;
            lblPosition.Visible = false;
            lblDepartment.Visible = false;
            lblAccumulated.Visible = false;
            lblStatus.Visible = false;
            lblScheduleIn.Visible = false;
            lblScheduleOut.Visible = false;
            lblSSS.Visible = false;
            lblPhilHealth.Visible = false;
            lblPagIbig.Visible = false;

            txtNameEdit.Visible = true;
            cmbMaritalStatusEdit.Visible = true;
            txtContactNoEdit.Visible = true;
            txtEmailEdit.Visible = true;
            dtpDateHiredEdit.Visible = true;
            cmbGenderEdit.Visible = true;
            txtAddressEdit.Visible = true;
            cmbEmploymentTypeEdit.Visible = true;
            cmbPositionEdit.Visible = true;
            cmbDepartmentEdit.Visible = true;
            txtAccumulatedDayOffEdit.Visible = true;
            dtpScheduleInEdit.Visible = true;
            dtpSchedOutEdit.Visible = true;
            txtSSSEdit.Visible = true;
            txtPhilHealthEdit.Visible = true;
            txtPagIbigEdit.Visible = true;
            txtLeaveCreditsEdit.Visible = true;
            dtpDateOfBirth.Visible = true;
            cmbOtAllowed.Visible = true;
        }
        
        public void Edit_Mode_Off()
        {
            btnEdit.Visible = true;
            btnSave.Visible = false;

            lblName.Visible = true;
            lblMaritalStatus.Visible = true;
            lblContact.Visible = true;
            lblEmail.Visible = true;
            lblDateHired.Visible = true;
            lblGender.Visible = true;
            lblAddress.Visible = true;
            lblEmploymentType.Visible = true;
            lblPosition.Visible = true;
            lblDepartment.Visible = true;
            lblAccumulated.Visible = true;
            lblStatus.Visible = true;
            lblScheduleIn.Visible = true;
            lblScheduleOut.Visible = true;
            lblSSS.Visible = true;
            lblPhilHealth.Visible = true;
            lblPagIbig.Visible = true;

            txtNameEdit.Visible = false;
            cmbMaritalStatusEdit.Visible = false;
            txtContactNoEdit.Visible = false;
            txtEmailEdit.Visible = false;
            dtpDateHiredEdit.Visible = false;
            cmbGenderEdit.Visible = false;
            txtAddressEdit.Visible = false;
            cmbEmploymentTypeEdit.Visible = false;
            cmbPositionEdit.Visible = false;
            cmbDepartmentEdit.Visible = false;
            txtAccumulatedDayOffEdit.Visible = false;
            dtpScheduleInEdit.Visible = false;
            dtpSchedOutEdit.Visible = false;
            txtSSSEdit.Visible = false;
            txtPhilHealthEdit.Visible = false;
            txtPagIbigEdit.Visible = false;
            txtLeaveCreditsEdit.Visible = false;
            dtpDateOfBirth.Visible = false;
            cmbOtAllowed.Visible = false;

            cmbDepartmentEdit.SelectedIndex = -1;
            cmbEmploymentTypeEdit.SelectedIndex = -1;
            cmbGenderEdit.SelectedIndex = -1;
            cmbOtAllowed.SelectedIndex = -1;
            cmbPositionEdit.SelectedIndex = -1;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit_Mode();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int currentAge = DateTime.Today.Year - dtpDateOfBirth.Value.Year;

            string schedIn = dtpScheduleInEdit.Value.ToString("hh:mm:ss tt");
            string schedOut = dtpScheduleInEdit.Value.ToString("hh:mm:ss tt");

            string deptId = Get_DepartmentID().ToString();
            string posId = Get_PositionID().ToString();

            Console.WriteLine("Dept id: " + deptId);
            Console.WriteLine("Pos id: " + posId);

            string query =
                "UPDATE EmployeeInfo " +
                "SET " +
                "EmployeeFullName = '" + txtNameEdit.Text.ToString() + "', " +
                "Address = '" + txtAddressEdit.Text.ToString() + "', " +
                "SSS_ID = '" + txtSSSEdit.Text.ToString() + "', " +
                "PAGIBIG_NO = '" + txtPagIbigEdit.Text.ToString() + "', " +
                "PHIL_HEALTH_NO = '" + txtPhilHealthEdit.Text.ToString() + "', " +
                "Email = '" + txtEmailEdit.Text.ToString() + "', " +
                "EmployeeMaritalStatus = '" + cmbMaritalStatusEdit.Text.ToString() + "', " +
                "ContactNumber = '" + txtContactNoEdit.Text.ToString() + "', " +
                "DateHired = '" + dtpDateHiredEdit.Value.ToString("MM/dd/yyyy") + "', " +
                "Gender = '" + cmbGenderEdit.Text.ToString() + "', " +
                "BirthDate = '" + dtpDateOfBirth.Value.ToString("MM/dd/yyyy") + "', " +
                "Age = " + currentAge.ToString() + ", " +
                "DepartmentID = " + deptId.ToString() + ", " + 
                "PositionID = " + posId.ToString() + ", " + 
                "EmploymentType = '" + cmbEmploymentTypeEdit.Text.ToString() + "', " +
                "ScheduleIn = '" + schedIn.ToUpper() + "', " +
                "ScheduleOut = '" + schedOut.ToUpper() + "', " +
                "AllowedOvertime = " + Set_Allowed_OT(cmbOtAllowed.Text.ToString()) + ", " +
                "AccumulatedDayOffs = " + txtAccumulatedDayOffEdit.Text.ToString() + ", " +
                "LeaveCredits = " + txtLeaveCreditsEdit.Text.ToString() + " " +
                "WHERE EmployeeID = " + lblEmployeeID.Text.ToString();

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }

            btnSave.Visible = false;
            btnEdit.Visible = true;

            Edit_Mode_Off();
            this.Close();

            //EmployeeProfile ep = new EmployeeProfile();
            //ep.ShowDialog();

            //EmployeeList el = new EmployeeList();
            //el.dgvCellClick(el.sender, e);

        }

        private void btnAddFace_Click(object sender, EventArgs e)
        {
            var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            Process.Start(path + "\\Collect Employee Dataset\\main.exe");
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            Process.Start(path + "\\Train Employee Module\\train.exe");
        }

        private void cmbDepartmentEdit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedDepartmentName = cmbDepartmentEdit.GetItemText(cmbDepartmentEdit.SelectedItem);
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
            cmbPositionEdit.SelectedIndex = -1;
        }

        private void cmbDepartmentEdit_MouseClick(object sender, MouseEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT DepartmentName FROM Department";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet data = new DataSet();
                adapter.Fill(data, "DepartmentName");
                cmbDepartmentEdit.DisplayMember = "DepartmentName";
                cmbDepartmentEdit.DataSource = data.Tables["DepartmentName"];
                //cmbDepartmentEdit.SelectedIndex = -1;
                //cmbPositionEdit.SelectedIndex = -1;
                cmbPositionEdit.Text = "";
            }
        }

        private void cmbPositionEdit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedPositionName = cmbPositionEdit.GetItemText(cmbPositionEdit.SelectedItem);
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

        private void cmbPositionEdit_MouseClick(object sender, MouseEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT PositionName FROM Position WHERE DepartmentID='" + selectedDepartmentId + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet data = new DataSet();
                adapter.Fill(data, "PositionName");
                cmbPositionEdit.DisplayMember = "PositionName";
                cmbPositionEdit.DataSource = data.Tables["PositionName"];
            }
        }

        public int Set_Allowed_OT(string ot_stat)
        {
            if (ot_stat == "Yex")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public long Get_DepartmentID()
        {
            string deptId = "";
            selectedDepartmentName = cmbDepartmentEdit.Text;
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
                        return reader.GetInt64(0);
                    }
                    else
                    {
                        MessageBox.Show("No department");
                        return 0;
                    }
                }
            }
        }

        public long Get_PositionID()
        {
            selectedPositionName = cmbPositionEdit.Text;
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
                        return reader.GetInt64(0);
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Position");
                        return 0;
                    }
                }
            }
        }

        private void cmbEmploymentTypeEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbDepartmentEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbDepartmentEdit_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbPositionEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    }
}
