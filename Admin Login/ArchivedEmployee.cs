using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Login
{
    public partial class ArchivedEmployee : Form
    {
        public ArchivedEmployee()
        {
            InitializeComponent();
        }

        private void ArchivedEmployee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fFRUsersDataSet13.ArchiveEmployee' table. You can move, or remove it, as needed.
            this.archiveEmployeeTableAdapter.Fill(this.fFRUsersDataSet13.ArchiveEmployee);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
