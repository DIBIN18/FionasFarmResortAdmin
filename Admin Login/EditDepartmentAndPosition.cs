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
    public partial class EditDepartmentAndPosition : Form
    {
        Login login = new Login();

        SqlDataAdapter DsqlDataAdapter = new SqlDataAdapter();
        BindingSource DbindingSource = new BindingSource();
        SqlCommandBuilder Dcmbl;

        SqlDataAdapter PsqlDataAdapter = new SqlDataAdapter();
        BindingSource PbindingSource = new BindingSource();
        SqlCommandBuilder Pcmbl;

        public EditDepartmentAndPosition()
        {
            InitializeComponent();
        }

        //DROP SHADOW
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

        private void EditDepartmentPosition_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = 
                    "SELECT * FROM Department";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvDeparments.DataSource = data;
                dgvDeparments.Columns["DepartmentID"].Visible = false;
            }

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query2 = 
                    "SELECT * FROM Position";
                SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
                DataTable data2 = new DataTable();
                adapter2.Fill(data2);
                dgvPositions.DataSource = data2;
                dgvPositions.Columns["PositionID"].Visible = false;
                dgvPositions.Columns["DepartmentID"].Visible = false;
            }
        }
        private void btn_SaveDepartmentChanges_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                if (dgvDeparments.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dgvDeparments.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvDeparments.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["DepartmentID"].Value);

                    connection.Open();
                    string query = 
                        "UPDATE Department " +
                        "SET DepartmentName='" + txtEditDepartmentName.Text + "'" +
                        "WHERE DepartmentID=" + cellValue;

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Department Name Successfully Changed");
                    txtEditDepartmentName.Clear();
                    loadDgvDept();
                }
            }
        }
        private void btn_SavePositionChanges_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                if (dgvPositions.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dgvPositions.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvPositions.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["PositionID"].Value);

                    connection.Open();
                    string query =
                        "UPDATE Position " +
                        "SET " +
                        "PositionName='" + txtEditPositionName.Text + "', " +
                        "BasicRate=" + txtEditBasicRate.Text + " " +
                        "WHERE PositionID=" + cellValue;

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Position Changes Successfully Changed");
                    txtEditPositionName.Clear();
                    txtEditBasicRate.Clear();
                    loadDgvPos();
                }
            }
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Department and Position";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }

        private void dgvDeparments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Department WHERE DepartmentID=" + dgvDeparments.Rows[e.RowIndex].Cells[0].Value;

                SqlCommand cmd = new SqlCommand(query, connection);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                txtEditDepartmentName.Text = dt.Rows[0][1].ToString();
            }
        }

        private void dgvPositions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Position WHERE PositionID=" + dgvPositions.Rows[e.RowIndex].Cells[0].Value;

                SqlCommand cmd = new SqlCommand(query, connection);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                txtEditPositionName.Text = dt.Rows[0][1].ToString();
                txtEditBasicRate.Text = dt.Rows[0][3].ToString();
            }
        }

        public void loadDgvDept()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT * FROM Department";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvDeparments.DataSource = data;
                dgvDeparments.Columns["DepartmentID"].Visible = false;
            }
        }

        public void loadDgvPos()
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query2 =
                    "SELECT * FROM Position";
                SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
                DataTable data2 = new DataTable();
                adapter2.Fill(data2);
                dgvPositions.DataSource = data2;
                dgvPositions.Columns["PositionID"].Visible = false;
                dgvPositions.Columns["DepartmentID"].Visible = false;
            }
        }
    }
}