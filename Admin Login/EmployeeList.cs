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
    public partial class EmployeeList : Form
    {
        string holderEmployeeID = "", holderFirstname = "", holderLastname = "", holderMname = "", holderAddress = "", holderSSSNo = "", holderPagibigNo = "", holderPhilhealthNo = "", holderEmail = "", holderSivilStatus = "", holderContactNo = "", holderGender = "", holderDatheHired = "", holderPosition = "", holderDepartment = "", holderJobDescrip = "";
        string holderDateofBirth = "", holderDateHired = "";
        public EmployeeList()
        {
            
            InitializeComponent();           
        }
        private void Cb_SortBy_Click(object sender, EventArgs e)
        {
            cb_SortBy.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Tb_Search_Leave(object sender, EventArgs e)
        {
            if (tb_Search.Text == "")
            {
                tb_Search.Text = " Search";
                tb_Search.ForeColor = Color.Silver;
            }
        }
        private void Cb_SortBy_Enter(object sender, EventArgs e)
        {
            if (cb_SortBy.Text == "Default")
            {
                cb_SortBy.Text = "Default";
                cb_SortBy.ForeColor = Color.Black;
            }
        }
        private void Cb_SortBy_Leave(object sender, EventArgs e)
        {
            if (cb_SortBy.Text == "Default")
            {
                cb_SortBy.Text = "Default";
                cb_SortBy.ForeColor = Color.Silver;
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
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fFRUsersDataSet12.EmployeeInfo' table. You can move, or remove it, as needed.
            this.employeeInfoTableAdapter.Fill(this.fFRUsersDataSet1.EmployeeInfo);


        }

        private void cb_SortBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnViewArchive(object sender, EventArgs e)
        {
            ArchivedEmployee archivedEmployee = new ArchivedEmployee();
            archivedEmployee.ShowDialog();
        }

        private void btnArchive(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-B80EBU7\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete * from EmployeeInfo where EmployeeID = " +dgvEmployeeList.SelectedCells.ToString());


        }

        private void EmployeeListCellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvEmployeeList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvEmployeeList.CurrentRow.Selected = true;
              
                holderEmployeeID = dgvEmployeeList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                holderFirstname = dgvEmployeeList.SelectedCells[1].Value.ToString();
                holderLastname = dgvEmployeeList.SelectedCells[2].Value.ToString();
                holderMname = dgvEmployeeList.SelectedCells[3].Value.ToString();
                holderAddress = dgvEmployeeList.SelectedCells[4].Value.ToString();
                holderSSSNo = dgvEmployeeList.SelectedCells[5].Value.ToString();
                holderPagibigNo = dgvEmployeeList.SelectedCells[6].Value.ToString();
                holderPhilhealthNo = dgvEmployeeList.SelectedCells[7].Value.ToString();
                holderEmail = dgvEmployeeList.SelectedCells[8].Value.ToString();
                holderSivilStatus = dgvEmployeeList.SelectedCells[9].Value.ToString();
                holderContactNo = dgvEmployeeList.SelectedCells[10].Value.ToString();
                holderDateHired = dgvEmployeeList.SelectedCells[11].Value.ToString();  
                holderGender = dgvEmployeeList.SelectedCells[12].Value.ToString();
                holderDateofBirth = dgvEmployeeList.SelectedCells[13].Value.ToString();
                holderPosition = dgvEmployeeList.SelectedCells[14].Value.ToString();
                holderDepartment = dgvEmployeeList.SelectedCells[15].Value.ToString();
                holderJobDescrip = dgvEmployeeList.SelectedCells[16].Value.ToString();

                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-B80EBU7\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ArchiveEmployee(EmployeeID,FirstName,LastName,MiddleName,Address,SSS_ID,PAGIBIG_NO,PHILHEALTH_NO,Email,EmployeeMaritalStatus,ContactNumber,DateHired,Gender,BirthDate,Position,Department,JobStatus)" +
                    "VALUES(@EmployeeID,@FirstName,@LastName,@MiddleName,@Address,@SSS_ID,@PAGIBIG_NO,@PHILHEALTH_NO,@Email,@EmployeeMaritalStatus,@ContactNumber,@DateHired,@Gender,@BirthDate,@Position,@Department,@JobStatus)", conn);
                cmd.Parameters.AddWithValue("@EmployeeID", holderEmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", holderFirstname);
                cmd.Parameters.AddWithValue("@LastName", holderLastname);
                cmd.Parameters.AddWithValue("@MiddleName", holderMname);
                cmd.Parameters.AddWithValue("@Address", holderAddress);
                cmd.Parameters.AddWithValue("@SSS_ID", holderSSSNo);
                cmd.Parameters.AddWithValue("@PAGIBIG_NO", holderPagibigNo);
                cmd.Parameters.AddWithValue("@PHILHEALTH_NO", holderPhilhealthNo);
                cmd.Parameters.AddWithValue("@Email", holderEmail);
                cmd.Parameters.AddWithValue("@EmployeeMaritalStatus", holderSivilStatus);
                cmd.Parameters.AddWithValue("@ContactNumber", holderContactNo);
                cmd.Parameters.AddWithValue("@DateHired", holderDateHired);
                cmd.Parameters.AddWithValue("@Gender", holderGender);
                cmd.Parameters.AddWithValue("@BirthDate", holderDateofBirth);
                cmd.Parameters.AddWithValue("@Position", holderPosition);
                cmd.Parameters.AddWithValue("@Position", holderDepartment);
                cmd.Parameters.AddWithValue("@Position", holderJobDescrip);


                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Archive Successful");
            }
        }
    }
}