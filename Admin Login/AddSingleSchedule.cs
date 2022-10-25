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
    public partial class AddSingleSchedule : Form
    {
        EmployeeProfile ep = new EmployeeProfile();
        Login login = new Login();
       
        public AddSingleSchedule()
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
            this.Close();
        }

        private void AddSingleSchedule_Load(object sender, EventArgs e)
        {
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "MMMM dd, yyyy";

            dtpScheduleIn.Format = DateTimePickerFormat.Time;
            dtpScheduleIn.ShowUpDown = true;

            dtpSchedOut.Format = DateTimePickerFormat.Time;
            dtpSchedOut.ShowUpDown = true;

            dtpScheduleIn.Format = DateTimePickerFormat.Custom;
            dtpScheduleIn.CustomFormat = "hh:mm:ss tt";

            dtpSchedOut.Format = DateTimePickerFormat.Custom;
            dtpSchedOut.CustomFormat = "hh:mm:ss tt";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string schedIn = dtpScheduleIn.Value.ToString("hh:mm:ss tt");
            string schedOut = dtpSchedOut.Value.ToString("hh:mm:ss tt");
            string date = dtpDate.Value.ToString("MMMM dd, yyyy");

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();

                string query =
                    "INSERT INTO SingleSchedule(EmployeeID,ScheduleIn, ScheduleOut, Date) VALUES (@EmployeeID, @ScheduleIn, @ScheduleOut, @Date)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ScheduleIn", schedIn);
                cmd.Parameters.AddWithValue("@ScheduleOut", schedOut);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@EmployeeID", lblSingleSchedID.Text.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added Single Schedule");
            }
        }
    }
}
