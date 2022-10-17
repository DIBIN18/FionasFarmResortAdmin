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
    public partial class HolidaySettings : Form
    {
        Login login = new Login();
        string ClickedButton, cb_HolidayName_Holder;
        //DEVIN CONNECTION STRING
        //static readonly string connectionString = "Data Source=DESKTOP-EHBRJVA\\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        //CUNAN CONNECTION STRING
        //static readonly string connectionString = "Data Source=DESKTOP-N4JRA7K\\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        //JOVS CONNECTION STRING
        static readonly string connectionString = "Data Source=DESKTOP-2NTMR5E\\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        //PAUL CONNECTION STRING
        //static readonly string connectionString = "Data Source=DESKTOP-B80EBU7\\SQLEXPRESS;Initial Catalog=FFRUsers;Integrated Security=True;MultipleActiveResultSets=True";
        static readonly SqlConnection connection = new SqlConnection(connectionString);
        static readonly SqlCommand command = new SqlCommand("select Holiday_ from Holidays", connection);
        static readonly SqlDataAdapter dataadapter = new SqlDataAdapter
        {
            SelectCommand = command
        };
        readonly DataTable datatable = new DataTable();
        public HolidaySettings()
        {
            InitializeComponent();
        }
        private void HolidaySettings_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Holidays";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dg_HolidaysTable.DataSource = data;
            }


            cb_HolidayName.DataSource = null;
            Btn_Add_Click(sender, e);
            t_Done.Start();
        }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            tb_HolidayName.Clear();
            cb_HolidayName.Enabled = false;
            cb_HolidayName.Visible = false;
            tb_HolidayName.Enabled = true;
            tb_HolidayName.Enabled = true;
            ClickedButton = "Add";
            lbl_Add.Font = new Font("Century Gothic", 17, FontStyle.Bold);
            lbl_Edit.Font = new Font("Century Gothic", 16);
            lbl_Delete.Font = new Font("Century Gothic", 16);
            dtp_From.Value = DateTime.Today;
            dtp_To.Value = DateTime.Today;
            cb_Type.SelectedItem = null;
            cb_Type.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            Cb_HolidayName_SelectedValueChanged(sender, e);
            tb_HolidayName.Enabled = false;
            tb_HolidayName.Enabled = false;
            cb_HolidayName.Enabled = true;
            cb_HolidayName.Visible = true;
            ClickedButton = "Edit";
            lbl_Edit.Font = new Font("Century Gothic", 17, FontStyle.Bold);
            lbl_Add.Font = new Font("Century Gothic", 16);
            lbl_Delete.Font = new Font("Century Gothic", 16);
            if (cb_HolidayName.DataSource == null)
            {
                dataadapter.Fill(datatable);
                cb_HolidayName.DataSource = datatable;
                cb_HolidayName.DisplayMember = "Holiday_";
            }
            cb_HolidayName.DropDownStyle = ComboBoxStyle.DropDown;
            cb_Type.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            Cb_HolidayName_SelectedValueChanged(sender, e);
            tb_HolidayName.Enabled = false;
            tb_HolidayName.Enabled = false;
            cb_HolidayName.Enabled = true;
            cb_HolidayName.Visible = true;
            ClickedButton = "Delete";
            lbl_Delete.Font = new Font("Century Gothic", 17, FontStyle.Bold);
            lbl_Add.Font = new Font("Century Gothic", 16);
            lbl_Edit.Font = new Font("Century Gothic", 16);
            if (cb_HolidayName.DataSource == null)
            {
                dataadapter.Fill(datatable);
                cb_HolidayName.DataSource = datatable;
                cb_HolidayName.DisplayMember = "Holiday_";
            }
            cb_HolidayName.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Type.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Cb_HolidayName_SelectedValueChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select From_, To_, Type_ from Holidays where Holiday_ = @Holiday_", connection);
            command.Parameters.AddWithValue("@Holiday_", cb_HolidayName.Text);
            SqlDataReader Reader;
            Reader = command.ExecuteReader();
            if (Reader.Read())
            {
                dtp_From.Text = Reader.GetValue(0).ToString();
                dtp_To.Text = Reader.GetValue(1).ToString();
                cb_Type.Text = Reader.GetValue(2).ToString();
            }
            cb_HolidayName_Holder = cb_HolidayName.Text;
        }
        private void Dtp_From_ValueChanged(object sender, EventArgs e)
        {
            if (ClickedButton == "Delete") 
            {
                SqlCommand command = new SqlCommand("select Holiday_, To_, Type_ from Holidays where From_ = @From_", connection);
                command.Parameters.AddWithValue("@From_", dtp_From.Value.ToString("MMMM dd"));
                SqlDataReader Reader;
                Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    cb_HolidayName.Text = Reader.GetValue(0).ToString();
                    dtp_To.Text = Reader.GetValue(1).ToString();
                    cb_Type.Text = Reader.GetValue(2).ToString();
                }
                else
                {
                    cb_HolidayName.SelectedItem = null;
                    dtp_To.Value = dtp_From.Value;
                    cb_Type.SelectedItem = null;
                }
            }
        }
        private void Dtp_To_ValueChanged(object sender, EventArgs e)
        {
            if (ClickedButton == "Delete")
            {
                SqlCommand command = new SqlCommand("select Holiday_, From_, Type_ from Holidays where To_ = @To_", connection);
                command.Parameters.AddWithValue("@To_", dtp_To.Value.ToString("MMMM dd"));
                SqlDataReader Reader;
                Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    cb_HolidayName.Text = Reader.GetValue(0).ToString();
                    dtp_From.Text = Reader.GetValue(1).ToString();
                    cb_Type.Text = Reader.GetValue(2).ToString();
                }
                else
                {
                    cb_HolidayName.SelectedItem = null;
                    dtp_From.Value = dtp_To.Value;
                    cb_Type.SelectedItem = null;
                }
            }
        }
        private void Dg_HolidaysTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ClickedButton == "Add")
                {
                    if (dg_HolidaysTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        dg_HolidaysTable.CurrentRow.Selected = true;
                        Btn_Edit_Click(sender, e);
                        cb_HolidayName.Text = dg_HolidaysTable.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    }
                }
                else if (ClickedButton == "Edit" || ClickedButton == "Delete")
                {
                    if (dg_HolidaysTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        dg_HolidaysTable.CurrentRow.Selected = true;
                        cb_HolidayName.Text = dg_HolidaysTable.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    }
                }
            }catch (Exception) { }
        }
        private void Cb_Type_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ClickedButton == "Delete")
            {
                SqlCommand command = new SqlCommand("select From_, To_, Holiday_ from Holidays where Type_ = @Type_", connection);
                command.Parameters.AddWithValue("@Type_", cb_Type.Text);
                SqlDataReader Reader;
                Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    dtp_From.Text = Reader.GetValue(0).ToString();
                    dtp_To.Text = Reader.GetValue(1).ToString();
                    cb_HolidayName.Text = Reader.GetValue(2).ToString();
                }
            }
        }
        private void Done_Tick(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (ClickedButton == "Add") 
                {
                    if (tb_HolidayName.Text != "" && cb_Type.Text != "" && dtp_From.Value <= dtp_To.Value)
                    {
                        if (control is PictureBox || control is Label && (string)control.Tag == "btn_Done" || (string)control.Tag == "btn_Clear")
                        {
                            lbl_Done.Font = new Font("Century Gothic", 17, FontStyle.Bold);
                            control.Enabled = true;
                        }
                    }
                    else
                    {
                        if (control is PictureBox || control is Label && (string)control.Tag == "btn_Done" || (string)control.Tag == "btn_Clear")
                        {
                            lbl_Done.Font = new Font("Century Gothic", 16);
                            control.Enabled = false;
                        }
                    }
                }
                else if (ClickedButton == "Edit")
                {
                    SqlCommand command = new SqlCommand("select Holiday_, From_, To_, Type_ from Holidays where Holiday_ = @Holiday_", connection);
                    command.Parameters.AddWithValue("@Holiday_", cb_HolidayName_Holder);
                    SqlDataReader Reader;
                    Reader = command.ExecuteReader();
                    if (Reader.Read())
                    {
                        if (cb_HolidayName.Text != Reader.GetValue(0).ToString() && cb_HolidayName.Text != "" || 
                            cb_Type.Text != Reader.GetValue(3).ToString() && cb_Type.Text != "" ||
                            dtp_From.Value.ToString("MMMM dd") != Reader.GetValue(1).ToString() ||
                            dtp_To.Value.ToString("MMMM dd") != Reader.GetValue(2).ToString())
                        {
                            if (control is PictureBox || control is Label && (string)control.Tag == "btn_Done")
                            {
                                lbl_Done.Font = new Font("Century Gothic", 17, FontStyle.Bold);
                                control.Enabled = true;
                            }
                        }
                        else
                        {
                            if (control is PictureBox || control is Label && (string)control.Tag == "btn_Done")
                            {
                                lbl_Done.Font = new Font("Century Gothic", 16);
                                control.Enabled = false;
                            }
                        }
                    }
                }
                else
                {
                    if (control is PictureBox || control is Label && (string)control.Tag == "btn_Done")
                    {
                        lbl_Done.Font = new Font("Century Gothic", 17, FontStyle.Bold);
                        control.Enabled = true;
                    }
                }
            }
        }
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Payroll Report";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        private void Btn_Done_Click(object sender, EventArgs e)
        {
            switch (ClickedButton)
            {
                case "Add":
                    SqlCommand command = new SqlCommand("insert into Holidays values (@Holiday_, @From_, @To_, @Type_)", connection);
                    command.Parameters.AddWithValue("@Holiday_", tb_HolidayName.Text);
                    command.Parameters.AddWithValue("@From_", dtp_From.Value.ToString("MMMM dd"));
                    command.Parameters.AddWithValue("@To_", dtp_To.Value.ToString("MMMM dd"));
                    command.Parameters.AddWithValue("@Type_", cb_Type.Text);
                    command.ExecuteNonQuery();
                    HolidaySettings_Load(sender, e);
                    break;
                case "Edit":
                    command = new SqlCommand("update Holidays set Holiday_ = @Holiday_, From_ = @From_, To_ = @To_, Type_ = @Type_ where Holiday_ = '" + cb_HolidayName_Holder + "'", connection);
                    command.Parameters.AddWithValue("@Holiday_", cb_HolidayName.Text);
                    command.Parameters.AddWithValue("@From_", dtp_From.Value.ToString("MMMM dd"));
                    command.Parameters.AddWithValue("@To_", dtp_To.Value.ToString("MMMM dd"));
                    command.Parameters.AddWithValue("@Type_", cb_Type.Text);
                    command.ExecuteNonQuery();
                    HolidaySettings_Load(sender, e);
                    break;
                case "Delete":
                    command = new SqlCommand("delete from Holidays where Holiday_ = @Holiday_", connection);
                    command.Parameters.AddWithValue("@Holiday_", cb_HolidayName.Text);
                    command.ExecuteNonQuery();
                    HolidaySettings_Load(sender, e);
                    break;
            }
        }
    }
}