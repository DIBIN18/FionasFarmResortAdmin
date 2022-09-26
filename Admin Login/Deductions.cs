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
    public partial class Deductions : Form
    {
        Login login = new Login();
      
        public Deductions()
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
            if(cb_SortBy.Text == "Default")
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
     
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //{
            //    if (dataGridView1.CurrentRow.Selected == true) { 
            //    using (SqlConnection conn = new SqlConnection(login.connectionString))
            //      {
            //        conn.Open();
            //        SqlCommand cmd = new SqlCommand("Select EmployeeID from Deductions", conn);
            //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //        DataTable dt = new DataTable();
            //        sqlDataAdapter.Fill(dt);
                     

            //        }
            //   }
            //}
        }
     
        private void Deductions_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Deductions", conn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
                if (dataGridView1.CurrentRow.Selected == true)
                {
                    using (SqlConnection conn = new SqlConnection(login.connectionString))
                    {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Deductions(OtherDeduction) VALUES(@OtherDeduction)");
                    cmd.Parameters.AddWithValue("@OtherDeduction",txtAdd.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Other Deductions Has been Added to" + dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    txtAdd.Text = "";

                    }
                }
            

        }
    }
}