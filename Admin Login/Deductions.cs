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
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        BindingSource bindingSource = new BindingSource();
        SqlCommandBuilder cmbl;
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
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                
            }
        }
     
        private void Deductions_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            sqlDataAdapter.SelectCommand = new SqlCommand("select * from Deductions", conn);
            cmbl = new SqlCommandBuilder(sqlDataAdapter);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            bindingSource.DataSource = dt;
            dataGridView1.DataSource = bindingSource;
        }
        private void btnSaveDeduction(object sender, EventArgs e)// after ma edit sesave nya sa Database and matic compute ng TotalDeduction/reload
        {
            sqlDataAdapter.Update((DataTable)bindingSource.DataSource);
            MessageBox.Show("SAVED");
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Deductions set TotalDeductions = SSSContribution+PagIbigContribution+PhilHealthContribution+OtherDeduction", connection);
                cmd.ExecuteNonQuery();
                Deductions_Load(this, null);
            }
        }
        //private void btnAdd_Click(object sender, EventArgs e)
        //{

        //    //if (dataGridView1.CurrentRow.Selected == true)
        //    //{
        //    //    using (SqlConnection conn = new SqlConnection(login.connectionString))
        //    //    {
        //    //        conn.Open();
        //    //        SqlCommand cmd = new SqlCommand("UPDATE Deductions SET OtherDeduction = OtherDeduction + " + txtAdd.Text + " WHERE EmployeeID = " + dataGridView1.CurrentRow.Cells[0].Value, conn);
        //    //        cmd.ExecuteNonQuery();

        //    //        DialogResult dialogResult = MessageBox.Show(
        //    //        "Deduction Added to " + dataGridView1.CurrentRow.Cells[0].Value);

        //    //        if (dialogResult == DialogResult.OK)
        //    //        {
        //    //            SqlCommand cmd2 = new SqlCommand("Select * from Deductions", conn);
        //    //            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd2);
        //    //            DataTable dt = new DataTable();
        //    //            sqlDataAdapter.Fill(dt);
        //    //            dataGridView1.DataSource = dt;
        //    //            txtAdd.Text = "";
        //    //            conn.Close();
        //    //        }


        //    //    }
        //    //}
        //}


    }
}