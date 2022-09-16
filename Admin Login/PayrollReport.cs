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
    public partial class PayrollReport : Form
    {
        Login login = new Login();
        private new string Name;

        public PayrollReport(string name)
        {
            InitializeComponent();
            Name = name;
        }
        private void PayrollReport_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select Holiday_, To_, Type_ from Holidays where From_ = @From_", connection);
            command.Parameters.AddWithValue("@From_", dtp_Date.Value.ToString("MMMM dd"));
            SqlDataReader Reader;
            Reader = command.ExecuteReader();
            if (Reader.Read())
            {
                lbl_Period.Text = Reader.GetValue(1).ToString() + dtp_Date.Value.ToString(", yyyy");
                lbl_Holiday.Text = Reader.GetValue(0).ToString() + "|" + Reader.GetValue(2).ToString();
            }
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
        private void Dt_Date_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(login.connectionString);
            connection.Open();
            SqlCommand HolidayCommand = new SqlCommand("select Holiday_, To_, Type_ from Holidays where From_ = @From_", connection);
            HolidayCommand.Parameters.AddWithValue("@From_", dtp_Date.Value.ToString("MMMM dd"));
            SqlDataReader Reader;
            Reader = HolidayCommand.ExecuteReader();
            if (Reader.Read())
            {
                lbl_Period.Text = Reader.GetValue(1).ToString() + dtp_Date.Value.ToString(", yyyy");
                lbl_Holiday.Text = Reader.GetValue(0).ToString() + "|" + Reader.GetValue(2).ToString();
            }
            else
            {
                lbl_Period.Text = "";
                lbl_Holiday.Text = "";
            }
        }
        private void Btn_HolidaySettings_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Holiday Settings";
            menu.Menu_Load(menu, EventArgs.Empty);
        }
    }
}