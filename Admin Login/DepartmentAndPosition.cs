using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Admin_Login
{
    public partial class DepartmentAndPosition : Form
    {
        Login login = new Login();
        public DepartmentAndPosition()
        {
            InitializeComponent();
        }
        private void Cb_SortBy_Click(object sender, EventArgs e)
        {
            cb_SortBy.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Tb_Search_Enter(object sender, EventArgs e)
        {
            if (tb_Search.Text == " Search")
            {
                tb_Search.Text = "";
                tb_Search.ForeColor = Color.Black;
            }
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
        public void PositionAndDepartments_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = 
                    "SELECT Position.PositionID, Department.DepartmentName, Position.PositionName, Position.BasicRate " +
                    "FROM Position " +
                    "INNER JOIN Department ON Position.DepartmentID=Department.DepartmentID;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                // Column font
                this.dgvPosAndDept.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
                // Row font
                this.dgvPosAndDept.DefaultCellStyle.Font = new Font("Century Gothic", 10);

                dgvPosAndDept.DataSource = data;
            }
        }
        private void dgvPosAndDept_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvPosAndDept.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //{
            //    dgvPosAndDept.CurrentRow.Selected = true;
            //}
        }
        private void btn_EditPositionAndDepartment_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Edit Department And Position";
            menu.Menu_Load(menu, EventArgs.Empty);
        }
        private void btn_AddDepPos_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Add Department And Position";
            menu.Menu_Load(menu, EventArgs.Empty);
        }
    }
}