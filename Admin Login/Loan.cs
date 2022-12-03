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
                        SqlConnection auditcon = new SqlConnection(login.connectionString);
                        auditcon.Open();
                        //SqlCommand name = new SqlCommand("Select * from Users Where Username_ = '" + forAudit.Username + "'", auditcon);
                        //SqlDataAdapter sda = new SqlDataAdapter(name);
                        //DataTable dtaudit = new DataTable();
                        //sda.Fill(dtaudit);
                        //string auditName = dt.Rows[0][0].ToString();
                        string auditDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                        string Module = "Deduction";
                        string Description = "Add Loan";
                        SqlCommand auditcommand = new SqlCommand("INSERT INTO AuditTrail(UserName_,Date,Module,Description) VALUES(@UserName_,@Date,@Module,@Description)", auditcon);
                        auditcommand.Parameters.AddWithValue("@UserName_", "Sample");
                        auditcommand.Parameters.AddWithValue("@Date", auditDate);
                        auditcommand.Parameters.AddWithValue("@Module", Module);
                        auditcommand.Parameters.AddWithValue("@Description", Description);
                        auditcommand.ExecuteNonQuery();
                        auditcon.Close();
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
