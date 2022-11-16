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

    public partial class LeaveEmployeeList : Form
    {
        public LeaveEmployeeList()
        {
            InitializeComponent();
        }
        Login login = new Login();
        public DataTable dt = new DataTable();
        string employeeid, employeename, department, position, schedule, sick_leave_credits, vacation_leave_credits;
        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(login.connectionString);
            //conn.Open();
            //if (tb_Search.Text == null)
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("Select EmployeeID,EmployeeFullName, DepartmentName, PositionName  FROM EmployeeInfo", conn);
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    DataTable dataTable = new DataTable();
            //    adapter.Fill(dataTable);
            //    dgvLeave.DataSource = dataTable;
            //    conn.Close();

            //}
            //else if (tb_Search.Focused)
            //{

            //    SqlCommand cmd = new SqlCommand("Select * from EmployeeInfo Where EmployeeID like '" + tb_Search.Text + "%'" + "OR EmployeeFullName Like'" + tb_Search.Text + "%'", conn);
            //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //    DataTable tb = new DataTable();
            //    sqlDataAdapter.Fill(tb);
            //    dgvLeave.DataSource = tb;
            //    conn.Close();
            //}
        }

        private void LeaveEmployeeList_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "select e.EmployeeID, e.EmployeeFullName, d.DepartmentName, p.PositionName, e.SickLeaveCredits, e.VacationLeaveCredits " +
                "from EmployeeInfo AS e " +
                "join Department AS d " +
                "on e.DepartmentID = d.DepartmentID " +
                "join Position As p " +
                "on e.PositionID = p.PositionID " +
                "where Status='Active' and EmploymentType='Regular'"
                , conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            //dgvLeave.Columns["SickLeaveCredits"].Visible = false;
            //dgvLeave.Columns["VacationLeaveCredits"].Visible = false;

            dgvLeave.DataSource = dt;

            // Column font
            this.dgvLeave.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            // Row font
            this.dgvLeave.DefaultCellStyle.Font = new Font("Century Gothic", 10);

            conn.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Leave";
            menu.Menu_Load(menu, EventArgs.Empty);
        }
        private void dgvLeave_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Leave l = new Leave();

            if (dgvLeave.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                employeeid = dgvLeave.CurrentRow.Cells[0].Value.ToString();
                employeename = dgvLeave.CurrentRow.Cells[1].Value.ToString();
                department = dgvLeave.CurrentRow.Cells[2].Value.ToString();
                position = dgvLeave.CurrentRow.Cells[3].Value.ToString();
                sick_leave_credits = dgvLeave.CurrentRow.Cells[4].Value.ToString();
                vacation_leave_credits = dgvLeave.CurrentRow.Cells[5].Value.ToString();
                schedule = getSchedIn(employeeid) + " - " + getSchedOut(employeeid);

                //Didisplay ang schedule kapag nakapili na ng employee
                using (SqlConnection connection = new SqlConnection(login.connectionString))
                {
                    connection.Open();

                    string query =
                        "SELECT * FROM EmployeeSchedule WHERE EmployeeID=" + employeeid;

                    SqlCommand cmd = new SqlCommand(query, connection);
                    DataTable dts = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dts);

                    //Laman ng schedule kapag i didisplay sa leave
                    //pakilagay nalang, natangal ko yung textbox
                    schedule = dts.Rows[0][2].ToString() + " - " + dts.Rows[0][3].ToString();
                }

                Menu menu = (Menu)Application.OpenForms["Menu"];
                menu.Text = "Fiona's Farm and Resort - Leave";
                menu.Leave_ValueHolder(employeeid, employeename, department, position, schedule, sick_leave_credits, vacation_leave_credits);
                menu.Menu_Load(menu, EventArgs.Empty);
            }
        }

        public string getSchedIn(string emp_id)
        {
            string query2 =
                "SELECT ScheduleIn FROM EmployeeSchedule WHERE EmployeeID=" + emp_id;
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
                        return "No Schedule in yet";
                    }
                }
            }
        }

        public string getSchedOut(string emp_id)
        {
            string query2 =
                "SELECT ScheduleOut FROM EmployeeSchedule WHERE EmployeeID=" + emp_id;
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
                        return "No Schedule out yet";
                    }
                }
            }
        }



    }
}