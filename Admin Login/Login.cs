using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Admin_Login
{
    public partial class Login : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int right,
            int top,
            int bottom,
            int width,
            int height
            );
        //DEVIN CONNECTION STRING
        //public string connectionString = "Data Source=DESKTOP-EHBRJVA\\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        //CUNAN CONNECTION STRING
        //public string connectionString = "Data Source=DESKTOP-N4JRA7K\\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        //JOVS CONNECTION STRING
        // public string connectionString = "Data Source=DESKTOP-2NTMR5E\\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        //PAUL CONNECTION STRING
        public string connectionString = "Data Source=DESKTOP-B80EBU7\\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        new string Name;
        public Login()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
        }
        private void NameText_Enter(object sender, EventArgs e)
        {
            UsernameError.Text = "";
            if (Username.Text == " Username")
            {
                Username.Text = "";
                Username.ForeColor = Color.Black;
            }
        }
        private void NameText_Leave(object sender, EventArgs e)
        {
            if (Username.Text == "")
            {
                Username.Text = " Username";
                Username.ForeColor = Color.Silver;
            }
        }
        private void PassText_Enter(object sender, EventArgs e)
        {
            PasswordError.Text = "";
            Password.PasswordChar = '*';
            if (Password.Text == " Password")
            {
                Password.Text = "";
                Password.ForeColor = Color.Black;
            }
        }
        private void PassText_Leave(object sender, EventArgs e)
        {
            if (Password.Text == "")
            {
                Password.PasswordChar = '\0';
                Password.Text = " Password";
                Password.ForeColor = Color.Silver;
            }
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (Username.Text == " Username" || Username.Text == "")
            {
                UsernameError.Text = "This field is required.";
            }
            else if (Password.Text == " Password" || Password.Text == "")
            {
                PasswordError.Text = "This field is required.";
            }
            else
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand UsernameCommand = new SqlCommand("select Username_, User_ from Users where Username_ = @Username_", connection);
                UsernameCommand.Parameters.AddWithValue("@Username_", Username.Text);
                SqlCommand PasswordCommand = new SqlCommand("select Password_ from Users where Password_ = @Password_", connection);
                PasswordCommand.Parameters.AddWithValue("@Password_", Password.Text);
                SqlDataReader Reader;
                Reader = UsernameCommand.ExecuteReader();
                if (Reader.Read())
                {
                    Name = Reader.GetValue(1).ToString();
                    Reader = PasswordCommand.ExecuteReader();
                    if (Reader.Read())
                    {
                        Menu menu = new Menu(Name);
                        this.Hide();
                        menu.ShowDialog();
                    }
                    else
                    {
                        PasswordError.Text = "Wrong password.";
                        Password.PasswordChar = '\0';
                        Password.Text = " Password";
                        Password.ForeColor = Color.Silver;
                    }
                }
                else
                {
                    UsernameError.Text = "'" + Username.Text + "' does not exist.";
                    Username.Text = " Username";
                    Username.ForeColor = Color.Silver;
                }
            }
        }
        private void ExitIcon_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}