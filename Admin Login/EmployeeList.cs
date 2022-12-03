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
using System.Globalization;
namespace Admin_Login
{
    public partial class EmployeeList : Form
    {
        Login login = new Login();
        EmployeeProfile ep = new EmployeeProfile();
        static string employeeid, employeename, department, position, address, sss, pagibig, philhealth, email, maritalstatus, contact,
            datehired, gender, age, birthdate, employmenttype, allowedot, accumulated, sickleavecredits, vacationleavecredits;

        private void dgv_EmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public EmployeeList()
        {
            InitializeComponent();
        }
        private void btn_ArchivedList_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Archive Employee";
            menu.Menu_Load(menu, EventArgs.Empty);
        }
        private void Tb_Search_Leave(object sender, EventArgs e)
        {
            if (tb_Search.Text == "")
            {
                tb_Search.Text = " Search";
                tb_Search.ForeColor = Color.Silver;
            }
        }
        private void Tb_Search_Enter(object sender, EventArgs e)
        {
            if (tb_Search.Text == " Search")
            {
                tb_Search.Text = "";
                tb_Search.ForeColor = Color.Black;
            }
        }
        private void btnAddEmployee(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Add Employee";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM EmployeeInfo WHERE Status='Active'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                // Column font
                this.dgv_EmployeeList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                // Row font
                this.dgv_EmployeeList.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgv_EmployeeList.DataSource = data;
            }
        }

        private void btnArchive(object sender, EventArgs e)
        {
            if (dgv_EmployeeList.CurrentRow.Selected == true)
            {
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();

                    string query =
                        "UPDATE EmployeeInfo SET Status='Inactive' WHERE EmployeeID=" + dgv_EmployeeList.CurrentRow.Cells[0].Value;

                    SqlCommand cmd = new SqlCommand(query, connection);
                    DialogResult dialogResult = MessageBox.Show(
                        " Are you sure you want to Archive Employee? " +
                        dgv_EmployeeList.CurrentRow.Cells[1].Value.ToString() + " " +
                        dgv_EmployeeList.CurrentRow.Cells[2].Value.ToString(), "Archive", MessageBoxButtons.YesNo
                    );
                    if (dialogResult == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        Menu menu = (Menu)Application.OpenForms["Menu"];
                        menu.Text = "Fiona's Farm and Resort - Employee List";
                        menu.Menu_Load(menu, EventArgs.Empty);
                    }
                }
            }
        }

        public string getDepartmentName(string selectedID)
        {
            string query = "SELECT DepartmentName FROM Department WHERE DepartmentID='" + selectedID + "'";
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
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
                        return "No department yet";
                    }
                    reader.Close();
                }
            }
        }

        public string getPositionName(string selectedID)
        {
            string query = "SELECT PositionName FROM Position WHERE PositionID='" + selectedID + "'";
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
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
                        return "No position yet";
                    }
                    reader.Close();
                }
            }
        }

        public void dgvCellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgv_EmployeeList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //{
            //    dgv_EmployeeList.CurrentRow.Selected = true;
            //    using (SqlConnection connection = new SqlConnection(login.connectionString))
            //    {
            //        connection.Open();
            //        SqlCommand cmd = new SqlCommand("Select * FROM EmployeeInfo WHERE EmployeeID =" + dgv_EmployeeList.Rows[e.RowIndex].Cells[0].Value, connection);
            //        DataTable dt = new DataTable();
            //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //        adapter.Fill(dt);
            //        ep.lblEmployeeID.Text = dt.Rows[0][0].ToString();
            //        ep.lblName.Text = dt.Rows[0][1].ToString();
            //        ep.lblAddress.Text = dt.Rows[0][2].ToString();
            //        ep.lblSSS.Text = dt.Rows[0][3].ToString();
            //        ep.lblPagIbig.Text = dt.Rows[0][4].ToString();
            //        ep.lblPhilHealth.Text = dt.Rows[0][5].ToString();
            //        ep.lblEmail.Text = dt.Rows[0][6].ToString();
            //        ep.lblMaritalStatus.Text = dt.Rows[0][7].ToString();
            //        ep.lblContact.Text = dt.Rows[0][8].ToString();
            //        ep.lblDateHired.Text = dt.Rows[0][9].ToString();
            //        ep.lblGender.Text = dt.Rows[0][10].ToString();
            //        ep.lblAge.Text = dt.Rows[0][12].ToString();
            //        ep.lblBirthDate.Text = dt.Rows[0][11].ToString();
            //        ep.lblDepartment.Text = getDepartmentName(dt.Rows[0][13].ToString());
            //        ep.lblPosition.Text = getPositionName(dt.Rows[0][14].ToString());
            //        ep.lblEmploymentType.Text = dt.Rows[0][15].ToString();
            //        ep.lblAllowedOT.Text = Get_Allowed_OT(dt.Rows[0][16].ToString());
            //        ep.lblAccumulated.Text = dt.Rows[0][17].ToString();
            //        ep.lblSickLeaveCredits.Text = dt.Rows[0][18].ToString();
            //        ep.lblVacationLeaveCredits.Text = dt.Rows[0][20].ToString();


            //        ep.txtNameEdit.Text = dt.Rows[0][1].ToString();
            //        ep.txtAddressEdit.Text = dt.Rows[0][2].ToString();
            //        ep.txtSSSEdit.Text = dt.Rows[0][3].ToString();
            //        ep.txtPagIbigEdit.Text = dt.Rows[0][4].ToString();
            //        ep.txtPhilHealthEdit.Text = dt.Rows[0][5].ToString();
            //        ep.txtEmailEdit.Text = dt.Rows[0][6].ToString();
            //        ep.cmbMaritalStatusEdit.Text = dt.Rows[0][7].ToString();
            //        ep.txtContactNoEdit.Text = dt.Rows[0][8].ToString();
            //        ep.dtpDateHiredEdit.Value = DateTime.ParseExact(dt.Rows[0][9].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //        ep.cmbGenderEdit.Text = dt.Rows[0][10].ToString();
            //        ep.dtpDateOfBirth.Value = DateTime.Parse(dt.Rows[0][11].ToString());
            //        ep.cmbDepartmentEdit.Text = getDepartmentName(dt.Rows[0][13].ToString());
            //        ep.cmbPositionEdit.Text = getPositionName(dt.Rows[0][14].ToString());
            //        ep.cmbEmploymentTypeEdit.Text = dt.Rows[0][15].ToString();
            //        ep.cmbOtAllowed.Text = Get_Allowed_OT(dt.Rows[0][16].ToString());
            //        ep.txtAccumulatedDayOffEdit.Text = dt.Rows[0][17].ToString();
            //        ep.txtSickLeaveCreditsEdit.Text = dt.Rows[0][18].ToString();
            //        ep.txtVacationLeaveCreditsEdit.Text = dt.Rows[0][20].ToString();

            //        using (SqlConnection connection2 = new SqlConnection(login.connectionString))
            //        {
            //            connection2.Open();
            //            SqlCommand cmd2 = new SqlCommand("SELECT * FROM EmployeeSchedule WHERE EmployeeID =" + dgv_EmployeeList.Rows[e.RowIndex].Cells[0].Value, connection);
            //            DataTable dt2 = new DataTable();
            //            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
            //            adapter2.Fill(dt2);

            //            ep.lblScheduleIn.Text = dt2.Rows[0][2].ToString();
            //            ep.lblScheduleOut.Text = dt2.Rows[0][3].ToString();

            //            try
            //            {
            //                ep.dtpScheduleInEdit.Value = DateTime.Parse(dt2.Rows[0][2].ToString());
            //                ep.dtpSchedOutEdit.Value = DateTime.Parse(dt2.Rows[0][3].ToString());
            //            }
            //            catch (FormatException)
            //            {
            //                //If wala pang sched blank muna
            //                ep.dtpScheduleInEdit.Text = (dt2.Rows[0][2].ToString());
            //                ep.dtpSchedOutEdit.Text = (dt2.Rows[0][3].ToString());
            //            }

            //            if (dt2.Rows[0][4].ToString() == "True")
            //            {
            //                ep.cbMonday.CheckState = CheckState.Checked;
            //            }
            //            if (dt2.Rows[0][5].ToString() == "True")
            //            {
            //                ep.cbTuesday.CheckState = CheckState.Checked;
            //            }
            //            if (dt2.Rows[0][6].ToString() == "True")
            //            {
            //                ep.cbWednesday.CheckState = CheckState.Checked;
            //            }
            //            if (dt2.Rows[0][7].ToString() == "True")
            //            {
            //                ep.cbThursday.CheckState = CheckState.Checked;
            //            }
            //            if (dt2.Rows[0][8].ToString() == "True")
            //            {
            //                ep.cbFriday.CheckState = CheckState.Checked;
            //            }
            //            if (dt2.Rows[0][9].ToString() == "True")
            //            {
            //                ep.cbSaturday.CheckState = CheckState.Checked;
            //            }
            //            if (dt2.Rows[0][10].ToString() == "True")
            //            {
            //                ep.cbSunday.CheckState = CheckState.Checked;
            //            }
            //        }
            //    }
            //}
        }

        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                if (string.IsNullOrEmpty(tb_Search.Text))
                {
                    SqlCommand cmd2 = new SqlCommand("Select * from EmployeeInfo where Status='Active'", connection);
                    SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    sqlDataAdapter2.Fill(dt2);
                    dgv_EmployeeList.DataSource = dt2;
                }
                else if (tb_Search.Focused)
                {
                    SqlCommand cmd = new SqlCommand(
                        "Select * from EmployeeInfo WHERE Status='Active' AND " +
                        "EmployeeFullName like '%" + tb_Search.Text + "%'" +
                        "OR EmployeeID Like '%" + tb_Search.Text + "%'", connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dgv_EmployeeList.DataSource = dt;
                }
            }
        }
        private void dgvEmployeeList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {          
            //ep.ShowDialog();
        }

        private void dgv_EmployeeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Payroll";
            if (dgv_EmployeeList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                employeeid = dgvDailyPayrollReport.CurrentRow.Cells[0].Value.ToString();
                employeename = dgvDailyPayrollReport.CurrentRow.Cells[1].Value.ToString();
                department = dgvDailyPayrollReport.CurrentRow.Cells[2].Value.ToString();
                position = dgvDailyPayrollReport.CurrentRow.Cells[3].Value.ToString();



                menu.PayrollReport_ValueHolder(employeeid, employeename, department, position);
                menu.Menu_Load(menu, EventArgs.Empty);
            }*/

            //using (SqlConnection connection = new SqlConnection(login.connectionString))
            //{
            //    connection.Open();
            //    SqlCommand cmd = new SqlCommand("Select * FROM EmployeeInfo WHERE EmployeeID =" + dgv_EmployeeList.Rows[e.RowIndex].Cells[0].Value, connection);
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    adapter.Fill(dt);
            //    employeeprofile.lblEmployeeID.Text = dt.Rows[0][0].ToString();
            //    employeeprofile.lblName.Text = dt.Rows[0][1].ToString();
            //    employeeprofile.lblAddress.Text = dt.Rows[0][2].ToString();
            //    employeeprofile.lblSSS.Text = dt.Rows[0][3].ToString();
            //    employeeprofile.lblPagIbig.Text = dt.Rows[0][4].ToString();
            //    employeeprofile.lblPhilHealth.Text = dt.Rows[0][5].ToString();
            //    employeeprofile.lblEmail.Text = dt.Rows[0][6].ToString();
            //    employeeprofile.lblMaritalStatus.Text = dt.Rows[0][7].ToString();
            //    employeeprofile.lblContact.Text = dt.Rows[0][8].ToString();
            //    employeeprofile.lblDateHired.Text = dt.Rows[0][9].ToString();
            //    employeeprofile.lblGender.Text = dt.Rows[0][10].ToString();
            //    employeeprofile.lblAge.Text = dt.Rows[0][12].ToString();
            //    employeeprofile.lblBirthDate.Text = dt.Rows[0][11].ToString();
            //    employeeprofile.lblDepartment.Text = getDepartmentName(dt.Rows[0][13].ToString());
            //    employeeprofile.lblPosition.Text = getPositionName(dt.Rows[0][14].ToString());
            //    employeeprofile.lblEmploymentType.Text = dt.Rows[0][15].ToString();
            //    employeeprofile.lblAllowedOT.Text = Get_Allowed_OT(dt.Rows[0][16].ToString());
            //    employeeprofile.lblAccumulated.Text = dt.Rows[0][17].ToString();
            //    employeeprofile.lblSickLeaveCredits.Text = dt.Rows[0][18].ToString();
            //    employeeprofile.lblVacationLeaveCredits.Text = dt.Rows[0][20].ToString();
            //    employeeprofile.txtNameEdit.Text = dt.Rows[0][1].ToString();
            //    employeeprofile.txtAddressEdit.Text = dt.Rows[0][2].ToString();
            //    employeeprofile.txtSSSEdit.Text = dt.Rows[0][3].ToString();
            //    employeeprofile.txtPagIbigEdit.Text = dt.Rows[0][4].ToString();
            //    employeeprofile.txtPhilHealthEdit.Text = dt.Rows[0][5].ToString();
            //    employeeprofile.txtEmailEdit.Text = dt.Rows[0][6].ToString();
            //    employeeprofile.cmbMaritalStatusEdit.Text = dt.Rows[0][7].ToString();
            //    employeeprofile.txtContactNoEdit.Text = dt.Rows[0][8].ToString();
            //    employeeprofile.dtpDateHiredEdit.Value = DateTime.ParseExact(dt.Rows[0][9].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //    employeeprofile.cmbGenderEdit.Text = dt.Rows[0][10].ToString();
            //    employeeprofile.dtpDateOfBirth.Value = DateTime.Parse(dt.Rows[0][11].ToString());
            //    employeeprofile.cmbDepartmentEdit.Text = getDepartmentName(dt.Rows[0][13].ToString());
            //    employeeprofile.cmbPositionEdit.Text = getPositionName(dt.Rows[0][14].ToString());
            //    employeeprofile.cmbEmploymentTypeEdit.Text = dt.Rows[0][15].ToString();
            //    employeeprofile.cmbOtAllowed.Text = Get_Allowed_OT(dt.Rows[0][16].ToString());
            //    employeeprofile.txtAccumulatedDayOffEdit.Text = dt.Rows[0][17].ToString();
            //    employeeprofile.txtSickLeaveCreditsEdit.Text = dt.Rows[0][18].ToString();
            //    employeeprofile.txtVacationLeaveCreditsEdit.Text = dt.Rows[0][20].ToString();
            //}
            //employeeprofile.ShowDialog();


            // MAKA COMMENT YAPA ING KEKA BAP
            // LAGE KEPA ITANG LUMA PARA KENG PRESENTATION KAYBAT KANITA TULUY MUNE ING GAGAWAN MU

            if (dgv_EmployeeList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgv_EmployeeList.CurrentRow.Selected = true;
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * FROM EmployeeInfo WHERE EmployeeID =" + dgv_EmployeeList.Rows[e.RowIndex].Cells[0].Value, connection);
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    ep.lblEmployeeID.Text = dt.Rows[0][0].ToString();
                    ep.lblName.Text = dt.Rows[0][1].ToString();
                    ep.lblAddress.Text = dt.Rows[0][2].ToString();
                    ep.lblSSS.Text = dt.Rows[0][3].ToString();
                    ep.lblPagIbig.Text = dt.Rows[0][4].ToString();
                    ep.lblPhilHealth.Text = dt.Rows[0][5].ToString();
                    ep.lblEmail.Text = dt.Rows[0][6].ToString();
                    ep.lblMaritalStatus.Text = dt.Rows[0][7].ToString();
                    ep.lblContact.Text = dt.Rows[0][8].ToString();
                    ep.lblDateHired.Text = dt.Rows[0][9].ToString();
                    ep.lblGender.Text = dt.Rows[0][10].ToString();
                    ep.lblAge.Text = dt.Rows[0][12].ToString();

                    DateTime bDate = Convert.ToDateTime(dt.Rows[0][11].ToString());

                    ep.lblBirthDate.Text = bDate.ToString("MMMM dd, yyyy");

                    ep.lblDepartment.Text = getDepartmentName(dt.Rows[0][13].ToString());
                    ep.lblPosition.Text = getPositionName(dt.Rows[0][14].ToString());
                    ep.lblEmploymentType.Text = dt.Rows[0][15].ToString();
                    //ep.lblAllowedOT.Text = Get_Allowed_OT(dt.Rows[0][16].ToString());
                    ep.lblAccumulated.Text = dt.Rows[0][17].ToString();
                    ep.lblSickLeaveCredits.Text = dt.Rows[0][18].ToString();
                    ep.lblVacationLeaveCredits.Text = dt.Rows[0][20].ToString();
                    ep.lblTIN.Text= dt.Rows[0][21].ToString();


                    ep.txtNameEdit.Text = dt.Rows[0][1].ToString();
                    ep.txtAddressEdit.Text = dt.Rows[0][2].ToString();
                    ep.txtSSSEdit.Text = dt.Rows[0][3].ToString();
                    ep.txtPagIbigEdit.Text = dt.Rows[0][4].ToString();
                    ep.txtPhilHealthEdit.Text = dt.Rows[0][5].ToString();
                    ep.txtEmailEdit.Text = dt.Rows[0][6].ToString();
                    ep.cmbMaritalStatusEdit.Text = dt.Rows[0][7].ToString();
                    ep.txtContactNoEdit.Text = dt.Rows[0][8].ToString();
                    ep.dtpDateHiredEdit.Value = DateTime.ParseExact(dt.Rows[0][9].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    ep.cmbGenderEdit.Text = dt.Rows[0][10].ToString();
                    ep.dtpDateOfBirth.Value = DateTime.Parse(dt.Rows[0][11].ToString());
                    ep.cmbDepartmentEdit.Text = getDepartmentName(dt.Rows[0][13].ToString());
                    ep.cmbPositionEdit.Text = getPositionName(dt.Rows[0][14].ToString());
                    ep.cmbEmploymentTypeEdit.Text = dt.Rows[0][15].ToString();
                    //ep.cmbOtAllowed.Text = Get_Allowed_OT(dt.Rows[0][16].ToString());
                    ep.txtAccumulatedDayOffEdit.Text = dt.Rows[0][17].ToString();
                    ep.txtSickLeaveCreditsEdit.Text = dt.Rows[0][18].ToString();
                    ep.txtVacationLeaveCreditsEdit.Text = dt.Rows[0][20].ToString();
                    ep.txtTINEdit.Text = dt.Rows[0][21].ToString();

                    using (SqlConnection connection2 = new SqlConnection(login.connectionString))
                    {
                        connection2.Open();
                        SqlCommand cmd2 = new SqlCommand("SELECT * FROM EmployeeSchedule WHERE EmployeeID =" + dgv_EmployeeList.Rows[e.RowIndex].Cells[0].Value, connection);
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
                        adapter2.Fill(dt2);

                        ep.lblScheduleIn.Text = dt2.Rows[0][2].ToString();
                        ep.lblScheduleOut.Text = dt2.Rows[0][3].ToString();
                        ep.lblBreakPeriod.Text = dt2.Rows[0][11].ToString();

                        try
                        {
                            ep.dtpScheduleInEdit.Value = DateTime.Parse(dt2.Rows[0][2].ToString());
                            ep.dtpSchedOutEdit.Value = DateTime.Parse(dt2.Rows[0][3].ToString());
                        }
                        catch (FormatException)
                        {
                            //If wala pang sched blank muna
                            ep.dtpScheduleInEdit.Text = (dt2.Rows[0][2].ToString());
                            ep.dtpSchedOutEdit.Text = (dt2.Rows[0][3].ToString());
                        }

                        if (dt2.Rows[0][4].ToString() == "True")
                        {
                            ep.cbMonday.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][5].ToString() == "True")
                        {
                            ep.cbTuesday.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][6].ToString() == "True")
                        {
                            ep.cbWednesday.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][7].ToString() == "True")
                        {
                            ep.cbThursday.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][8].ToString() == "True")
                        {
                            ep.cbFriday.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][9].ToString() == "True")
                        {
                            ep.cbSaturday.CheckState = CheckState.Checked;
                        }
                        if (dt2.Rows[0][10].ToString() == "True")
                        {
                            ep.cbSunday.CheckState = CheckState.Checked;
                        }
                    }

                    using (SqlConnection connection3 = new SqlConnection(login.connectionString))
                    {
                        connection3.Open();

                        string query = "SELECT BasicRate, Custom FROM Position WHERE PositionID=" + getPosID(dgv_EmployeeList.Rows[e.RowIndex].Cells[0].Value.ToString());

                        SqlCommand cmd3 = new SqlCommand(query, connection3);
                        DataTable dt3 = new DataTable();
                        SqlDataAdapter adapter3 = new SqlDataAdapter(cmd3);
                        adapter3.Fill(dt3);

                        if (dt3.Rows[0][1].ToString() == "True")
                        {
                            ep.lblCustomRate.Text = dt3.Rows[0][0].ToString();
                        }
                        else
                        {
                            ep.lblCustomRate.Text = "None";
                        }
                    }
                }
            }
            ep.ShowDialog();

        }

        public Int64 getPosID(string emp_id)
        {
            string query = "SELECT PositionID FROM EmployeeInfo WHERE EmployeeID=" + emp_id;

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
                    }
                    else
                    {
                        MessageBox.Show("No Position");
                        return 0;
                    }
                }
            }
        }
    }
}