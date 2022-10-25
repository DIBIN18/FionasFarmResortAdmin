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
    public partial class Payroll : Form
    {
        Login login = new Login();
        SSSRangeClass range = new SSSRangeClass();
        public Payroll()
        {
            InitializeComponent();
            
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {

            Menu menu = (Menu)Application.OpenForms["Menu"];
            menu.Text = "Fiona's Farm and Resort - Payroll Report";
            menu.Menu_Load(menu, EventArgs.Empty);
        }

        public void Payroll_Load(object sender, EventArgs e)
        {
            
        }
    }
}