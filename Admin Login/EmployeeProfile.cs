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
using System.Diagnostics;
using System.IO;

namespace Admin_Login
{
    
    public partial class EmployeeProfile: Form
    {
        Login login = new Login();

        string selectedDepartmentName = "";
        long selectedDepartmentId = 0;

        string selectedPositionName = "";
        long selectedPositionId = 0;

        string Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday;
        

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
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Employee List";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();

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

            try
            {
                var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                pbProfilePic.Image = Image.FromFile(path + "\\Profile\\" + lblEmployeeID.Text.ToString() + ".png");
                btnChangePfp.Visible = true;
            }
            catch (System.IO.FileNotFoundException)
            {
                var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                pbProfilePic.Image = Image.FromFile(path + "\\Profile\\NoPic.png");
                btnAddPfp.Visible = true;
            }

            cbMonday.Enabled = false;
            cbTuesday.Enabled = false;
            cbWednesday.Enabled = false;
            cbThursday.Enabled = false;
            cbFriday.Enabled = false;
            cbSaturday.Enabled = false;
            cbSunday.Enabled = false;
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
            txtSickLeaveCreditsEdit.Visible = true;
            txtVacationLeaveCreditsEdit.Visible = true;
            dtpDateOfBirth.Visible = true;
            cmbOtAllowed.Visible = true;

            cbMonday.Enabled = true;
            cbTuesday.Enabled = true;
            cbWednesday.Enabled = true;
            cbThursday.Enabled = true;
            cbFriday.Enabled = true;
            cbSaturday.Enabled = true;
            cbSunday.Enabled = true;
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
            txtSickLeaveCreditsEdit.Visible = false;
            txtVacationLeaveCreditsEdit.Visible = false;
            dtpDateOfBirth.Visible = false;
            cmbOtAllowed.Visible = false;

            //cmbDepartmentEdit.SelectedIndex = -1;
            //cmbEmploymentTypeEdit.SelectedIndex = -1;
            //cmbGenderEdit.SelectedIndex = -1;
            //cmbOtAllowed.SelectedIndex = -1;
            //cmbPositionEdit.SelectedIndex = -1;

            cbMonday.Enabled = false;
            cbTuesday.Enabled = false;
            cbWednesday.Enabled = false;
            cbThursday.Enabled = false;
            cbFriday.Enabled = false;
            cbSaturday.Enabled = false;
            cbSunday.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit_Mode();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int currentAge = DateTime.Today.Year - dtpDateOfBirth.Value.Year;

            string schedIn = dtpScheduleInEdit.Value.ToString("hh:mm:ss tt");
            string schedOut = dtpSchedOutEdit.Value.ToString("hh:mm:ss tt");

            string deptId = Get_DepartmentID().ToString();
            string posId = Get_PositionID().ToString();

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
                "AllowedOvertime = " + Set_Allowed_OT(cmbOtAllowed.Text.ToString()) + ", " +
                "AccumulatedDayOffs = " + txtAccumulatedDayOffEdit.Text.ToString() + ", " +
                "SickLeaveCredits = " + txtSickLeaveCreditsEdit.Text.ToString() + ", " +
                "VacationLeaveCredits = " + txtVacationLeaveCreditsEdit.Text.ToString() +
                "WHERE EmployeeID = " + lblEmployeeID.Text.ToString();

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

            string scheduleQuery =
                "UPDATE EmployeeSchedule " +
                "SET " +
                "ScheduleIn = '" + schedIn.ToUpper() + "', " +
                "ScheduleOut = '" + schedOut.ToUpper() + "', " +
                "Monday ='" + Monday + "', " +
                "Tuesday ='" + Tuesday + "', " +
                "Wednesday ='" + Wednesday + "', " +
                "Thursday ='" + Thursday + "', " +
                "Friday ='" + Friday + "', " +
                "Saturday ='" + Saturday + "', " +
                "Sunday ='" + Sunday + "' " +
                "WHERE EmployeeID = " + lblEmployeeID.Text.ToString();

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlCommand cmd2 = new SqlCommand(scheduleQuery, connection);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
            }

            btnSave.Visible = false;
            btnEdit.Visible = true;

            Edit_Mode_Off();
            Reload_Profile(lblEmployeeID.Text.ToString());

            //this.Close();

            //EmployeeProfile ep = new EmployeeProfile();
            //ep.ShowDialog();

            //EmployeeList el = new EmployeeList();
            //el.dgvCellClick(el.sender, e);

        }

        private void btnAddFace_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblEmployeeID.Text.ToString());
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
            if (ot_stat == "Yes")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void Reload_Profile(string profile_Id)
        {
            string currentProfile = lblEmployeeID.Text;

            string query = "SELECT * FROM EmployeeInfo WHERE EmployeeID=" + currentProfile;

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using(SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    lblName.Text = reader.GetString(1);
                    lblAddress.Text = reader.GetString(2);
                    lblSSS.Text = reader.GetString(3);
                    lblPagIbig.Text = reader.GetString(4);
                    lblPhilHealth.Text = reader.GetString(5);
                    lblEmail.Text = reader.GetString(6);
                    lblMaritalStatus.Text = reader.GetString(7);
                    lblContact.Text = reader.GetString(8);
                    lblDateHired.Text = reader.GetString(9);
                    lblGender.Text = reader.GetString(10);
                    lblBirthDate.Text = reader.GetDateTime(11).ToString();
                    lblAge.Text = reader.GetInt32(12).ToString();
                    lblDepartment.Text = Get_DepartmentName(reader.GetInt64(13).ToString());
                    lblPosition.Text = Get_PositionName(reader.GetInt64(14).ToString());
                    lblEmploymentType.Text = reader.GetString(15);
                    //lblScheduleIn.Text = reader.GetString(16);
                    //lblScheduleOut.Text = reader.GetString(17);
                    lblAllowedOT.Text = Display_OT(currentProfile, reader.GetBoolean(16));
                    lblAccumulated.Text = reader.GetInt32(17).ToString();
                    lblSickLeaveCredits.Text = reader.GetInt32(18).ToString();
                    lblVacationLeaveCredits.Text = reader.GetInt32(20).ToString();
                }
            }

            string query2 = "SELECT * FROM EmployeeSchedule WHERE EmployeeID=" + currentProfile;

            using (SqlConnection connection2 = new SqlConnection(login.connectionString))
            using (SqlCommand command2 = new SqlCommand(query2, connection2))
            {
                connection2.Open();

                using (SqlDataReader reader = command2.ExecuteReader())
                {
                    reader.Read();

                    lblScheduleIn.Text = reader.GetString(2);
                    lblScheduleOut.Text = reader.GetString(3);
                }
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


        public string Get_DepartmentName(string id)
        {
            string query2 = "SELECT DepartmentName FROM Department WHERE DepartmentID='" + id + "'";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetString(0);
                    }
                    else
                    {
                        return " ";
                    }
                }
            }
        }

        public string Display_OT(string id, Boolean emp_ota)
        {
            string query2 = "SELECT AllowedOvertime FROM EmployeeInfo WHERE EmployeeID='" + id + "'";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    if (reader.GetBoolean(0) == true)
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }
                }
            }
        }


        public string Get_PositionName(string id)
        {
            string query2 = "SELECT PositionName FROM Position WHERE PositionID='" + id + "'";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetString(0);
                    }
                    else
                    {
                        return " ";
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
            //e.Handled = true;
        }

        public void btnAddSingleSched_Click(object sender, EventArgs e)
        {
            AddSingleSchedule ss = new AddSingleSchedule();
            ss.lblSingleSchedID.Text = lblEmployeeID.Text.ToString();
            ss.ShowDialog();
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

        private void cmbOtAllowed_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnAddPfp_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files | *.jpg;*.jpeg;*.png";
                ofd.FilterIndex = 1;
                ofd.Multiselect = false;

                var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                string sourceFile = string.Empty;
                string targetPath = path + "\\Profile\\" + lblEmployeeID.Text.ToString() + ".png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    sourceFile = ofd.FileName;
                }

                try
                {
                    System.IO.File.Copy(sourceFile, targetPath);
                }
                catch (ArgumentException)
                {
                    //Do nothing
                }

                //Load profile pic
                try
                {
                    pbProfilePic.Image = Image.FromFile(path + "\\Profile\\" + lblEmployeeID.Text.ToString() + ".png");
                    btnChangePfp.Visible = true;
                }
                catch (System.IO.FileNotFoundException)
                {
                    pbProfilePic.Image = Image.FromFile(path + "\\Profile\\NoPic.png");
                    btnAddPfp.Visible = true;
                }
            }
        }

        private void btnChangePfp_Click(object sender, EventArgs e)
        {
            // NEED TO FIX
            //pbProfilePic.Image = null;

            //var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

            ////var image = Image.FromFile(path + "\\Profile\\" + lblEmployeeID.Text.ToString() + ".png");
            //pbProfilePic.Dispose();

            //pbProfilePic.Image = Image.FromFile(path + "\\Profile\\NoPic.png");
            //btnAddPfp.Visible = true;

            ////System.IO.File.Delete(path + "\\Profile\\" + lblEmployeeID.Text.ToString() + ".png");

            pbProfilePic.Image = null;
            //pbProfilePic.Dispose();
            
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                string sourceFile = string.Empty;
                string targetPath = path + "\\Profile\\" + lblEmployeeID.Text.ToString() + ".png";

                ofd.Filter = "Image Files | *.jpg;*.jpeg;*.png";
                ofd.FilterIndex = 1;
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    sourceFile = ofd.FileName;

                    //delete here
                    using (FileStream stream = new FileStream(targetPath, FileMode.Open, FileAccess.Read))
                    {
                        pbProfilePic.Image = Image.FromStream(stream);
                        stream.Dispose();
                    }
                    //File.Delete(targetPath);
                }

                Console.WriteLine(sourceFile);
                Console.WriteLine(targetPath);

                //create file
                try
                {
                    System.IO.File.Copy(sourceFile, targetPath);
                }
                catch (ArgumentException)
                {
                    //Do nothing
                }
            }
        }
    }
}
