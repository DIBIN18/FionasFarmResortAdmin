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
    public partial class EditDepartmentPosition : Form
    {
        Login login = new Login();

        SqlDataAdapter DsqlDataAdapter = new SqlDataAdapter();
        BindingSource DbindingSource = new BindingSource();
        SqlCommandBuilder Dcmbl;

        SqlDataAdapter PsqlDataAdapter = new SqlDataAdapter();
        BindingSource PbindingSource = new BindingSource();
        SqlCommandBuilder Pcmbl;

        public EditDepartmentPosition()
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
            SqlConnection conn = new SqlConnection(login.connectionString);
            
            conn.Open();
            DsqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Department", conn);
            Dcmbl = new SqlCommandBuilder(DsqlDataAdapter);
            DataTable dt = new DataTable();
            DsqlDataAdapter.Fill(dt);
            DbindingSource.DataSource = dt;
            dgvDeparments.DataSource = DbindingSource;
            conn.Close();

            conn.Open();
            PsqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Position", conn);
            Pcmbl = new SqlCommandBuilder(PsqlDataAdapter);
            DataTable pdt = new DataTable();
            PsqlDataAdapter.Fill(pdt);
            PbindingSource.DataSource = pdt;
            dgvPositions.DataSource = PbindingSource;
            conn.Close();

            dgvDeparments.Columns["DepartmentID"].ReadOnly = true;
            dgvPositions.Columns["PositionId"].ReadOnly = true;
            dgvPositions.Columns["DepartmentID"].ReadOnly = true;
        }

        private void btnSaveDepartment_Click(object sender, EventArgs e)
        {
            DsqlDataAdapter.Update((DataTable)DbindingSource.DataSource);
            MessageBox.Show("Department Changes Saced");
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                EditDepartmentPosition_Load(this, null);
            }
        }

        private void btnSavePosition_Click(object sender, EventArgs e)
        {
            PsqlDataAdapter.Update((DataTable)PbindingSource.DataSource);
            MessageBox.Show("Position Changes Saved");
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                EditDepartmentPosition_Load(this, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
