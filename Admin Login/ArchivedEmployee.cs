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
    public partial class ArchivedEmployee : Form
    {
        //PAUL CONNECTION STRING
        public string connectionString = @"Data Source=DESKTOP-0Q352R7\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        public ArchivedEmployee()
        {
            InitializeComponent();
         
        }

        private void btnArchiveBack(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Employee List";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }

        private void ArchivedEmployee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fFRUsersDataSet16.Archive' table. You can move, or remove it, as needed.
            this.archiveTableAdapter1.Fill(this.fFRUsersDataSet16.Archive);
         

        }

        private void btnRestore(object sender, EventArgs e)
        {
            if (dgvArchive.CurrentRow.Selected = true)
            {
                DialogResult dialogResult = MessageBox.Show(" Are you sure you want to Restore Employee? " + dgvArchive.CurrentRow.Cells[1].Value.ToString() + " " + dgvArchive.CurrentRow.Cells[2].Value.ToString(), "Archive", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT Archive ON "
                    + "Insert INTO EmployeeInfo (FirstName,LastName,MiddleName,Address,SSS_ID,PAGIBIG_NO,PHILHEALTH_NO,Email,EmployeeMaritalStatus,ContactNumber,DateHired,Gender,BirthDate,Department,Position,JobStatus )" +
                    "SELECT FirstName,LastName,MiddleName,Address,SSS_ID,PAGIBIG_NO,PHILHEALTH_NO,Email,EmployeeMaritalStatus,ContactNumber,DateHired,Gender,BirthDate,Department,Position,JobStatus " +
                    "FROM Archive WHERE EmployeeID = " + dgvArchive.CurrentRow.Cells[0].Value + " DELETE FROM Archive WHERE EmployeeID = " + dgvArchive.CurrentRow.Cells[0].Value, conn);


                    cmd.ExecuteNonQuery();
                   
                    this.archiveTableAdapter1.Fill(this.fFRUsersDataSet16.Archive);
                    conn.Close();
                }
                
            }
        }

        private void dgvArchiveCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvArchive.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvArchive.CurrentRow.Selected = true;
            }
        }
    }
}