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
            //SqlConnection conn = new SqlConnection(login.connectionString);

            //conn.Open();
            //DsqlDataAdapter.SelectCommand = new SqlCommand("SELECT DepartmentName FROM Department", conn);
            //Dcmbl = new SqlCommandBuilder(DsqlDataAdapter);
            //DataTable dt = new DataTable();
            //DsqlDataAdapter.Fill(dt);
            //DbindingSource.DataSource = dt;
            //dgvDeparments.DataSource = DbindingSource;
            //conn.Close();

            //conn.Open();
            //PsqlDataAdapter.SelectCommand = new SqlCommand("SELECT PositionName, BasicRate FROM Position", conn);
            //Pcmbl = new SqlCommandBuilder(PsqlDataAdapter);
            //DataTable pdt = new DataTable();
            //PsqlDataAdapter.Fill(pdt);
            //PbindingSource.DataSource = pdt;
            //dgvPositions.DataSource = PbindingSource;
            //conn.Close();
            //dgvDeparments.Columns["DepartmentID"].ReadOnly = true;
            //dgvPositions.Columns["PositionId"].ReadOnly = true;
            //dgvPositions.Columns["DepartmentID"].ReadOnly = true;

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "SELECT DepartmentName FROM Department";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dgvDeparments.DataSource = data;
            }

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query2 = "SELECT PositionName, BasicRate FROM Position";
                SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
                DataTable data2 = new DataTable();
                adapter2.Fill(data2);
                dgvPositions.DataSource = data2;
            }

        }
        private void btn_SaveDepartmentChanges_Click(object sender, EventArgs e)
        {
            //DsqlDataAdapter.Update((DataTable)DbindingSource.DataSource);
            //MessageBox.Show("Department Changes Saced");
            //using (SqlConnection connection = new SqlConnection(login.connectionString))
            //{
            //    connection.Open();
            //    EditDepartmentPosition_Load(this, null);
            //}
        }
        private void btn_SavePositionChanges_Click(object sender, EventArgs e)
        {
            //PsqlDataAdapter.Update((DataTable)PbindingSource.DataSource);
            //MessageBox.Show("Position Changes Saved");
            //using (SqlConnection connection = new SqlConnection(login.connectionString))
            //{
            //    connection.Open();
            //    EditDepartmentPosition_Load(this, null);
            //}
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Department and Position";
            menu.Menu_Load(menu, EventArgs.Empty);
            Dispose();
        }
    }
}