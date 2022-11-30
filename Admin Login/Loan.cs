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
    public partial class Loan : Form
    {
        Login login = new Login();
        public string EmpID, Name;
        public Loan()
        {
            InitializeComponent();
        }

        private void Loan_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Add Deduction to " +Name+ " ?", " ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    SqlConnection connection = new SqlConnection(login.connectionString);
                    {
                        connection.Open();
                        double quotient = Convert.ToDouble(tbAddOtherDeduction.Text) / Convert.ToDouble(tbScrollNum.Value);
                        string query = "Insert into OtherDeductions (EmployeeID,TotalOtherDeductions,DeductionPerCompensation,Iterations,Description,StartDate)" +
                                       "Values(" + EmpID + "," + Convert.ToDouble(tbAddOtherDeduction.Text) + "," + quotient + "," + tbScrollNum.Value + ",'" + tbDescription.Text + "','" + dtStart.Text + "')";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        this.Close();
                        resetForm();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else if (dialogResult == DialogResult.No)
            {
                resetForm();
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            resetForm();
            this.Close();
        }
        public void resetForm()
        {
            tbAddOtherDeduction.Text = "";
            tbScrollNum.Value = 0;
            tbDescription.Text = "";
        }
    }
}
