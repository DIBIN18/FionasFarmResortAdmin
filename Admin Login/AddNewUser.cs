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
    public partial class AddNewUser : Form
    {
        public AddNewUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            Settings settings = new Settings();
            using (SqlConnection con = new SqlConnection(login.connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Users(User_,Username_,Password_)Values(@User,@Username,@Password) ", con);
                    cmd.Parameters.AddWithValue("@User", cmbUserName.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                    cmd.ExecuteNonQuery();
                    DialogResult dr = MessageBox.Show("New User Has beed Added!", "New User: " + settings.dgvUsers.Rows[0].Cells[0].Value, MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        cmbUserName.Text = "";
                        txtPass.Text = "";
                        txtUser.Text = "";
                    }
                    con.Close();
                }catch(Exception ex)
                {
                   //Some Errors!
                }
            }

        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {
            cmbUserName.Items.Add("HR");
            cmbUserName.Items.Add("timekeeper");
        }
    }
}
