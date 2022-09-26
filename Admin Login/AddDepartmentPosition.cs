﻿using System;
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
    public partial class AddDepartmentPosition : Form
    {
        AddEmployee ae = new AddEmployee();
        Login login = new Login();
        string selectedDepartmentName = "";
        long selectedDepartmentId = 0;
        public AddDepartmentPosition()
        {
            InitializeComponent();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // MAKE BASIC RATE TEXT BOX ACCEPT ONLY NUMBERS
        private void txtBasicRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(login.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert Into Department(DepartmentName)Values(@DepartmentName)", conn);
            cmd.Parameters.AddWithValue("@DepartmentName", txtDepartmentName.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("New Department Has been Added");
            txtDepartmentName.Text = "";
        }

        private void cmbDepartment_MouseClick(object sender, MouseEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                string query =
                    "SELECT DepartmentName FROM Department";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet data = new DataSet();
                adapter.Fill(data, "DepartmentName");
                cmbDepartment.DisplayMember = "DepartmentName";
                cmbDepartment.DataSource = data.Tables["DepartmentName"];
            }
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedDepartmentName = cmbDepartment.GetItemText(cmbDepartment.SelectedItem);
            string query2 = "SELECT DepartmentID FROM Department WHERE DepartmentName='" + selectedDepartmentName + "'";

            using (SqlConnection connection = new SqlConnection(login.connectionString))
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        selectedDepartmentId = reader.GetInt64(0);
                        reader.Close();
                    }
                }
            }
        }

        private void btnAddPosition_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(login.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Position" +
                    "(PositionName, DepartmentID, BasicRate)" +
                    "VALUES" +
                    "(@PositionName, @DepartmentID, @BasicRate)",
                    connection);

                // CONVERT STRING TO DECIMAL
                decimal string_to_decimal;
                if (Decimal.TryParse(txtBasicRate.Text, out string_to_decimal))
                {
                    Console.WriteLine(string_to_decimal.ToString("0.##"));
                }

                else
                {
                    Console.WriteLine("not a Decimal");
                }

                command.Parameters.AddWithValue("@PositionName", txtPositionName.Text);
                command.Parameters.AddWithValue("@DepartmentID", selectedDepartmentId);
                command.Parameters.AddWithValue("@BasicRate", string_to_decimal);
                command.ExecuteNonQuery();
                MessageBox.Show("New Position Has been Added");

                txtPositionName.Text = "";
                cmbDepartment.SelectedIndex = -1;
                txtBasicRate.Text = "";
            }
        }

    }
}