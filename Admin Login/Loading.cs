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
namespace Admin_Login
{
    public partial class Loading : Form
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
        readonly Random random = new Random();
        string[] process = {"mscorlib.dll.", 
            "Admin Login.exe symbols loaded.",
            "System.Windows.Forms.dll.",
            "System.dll.",
            "System.Drawing.dll.",
            "System.Configuration.dll.",
            "System.Core.dll.",
            "System.Xml.dll.",
            "System.Data.dll.",
            "System.Transactions.dll.",
            "System.EnterpriseServices.dll.",
            "System.EnterpriseServices.Wrapper.dll.",
            "System.Runtime.Caching.dll.",
            "System.Numerics.dll."};
        public Loading()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
        }
        private void Loading_Load(object sender, EventArgs e)
        {
            t_Loading.Start();
        }
        private void Loading_Tick(object sender, EventArgs e)
        {
            int num = random.Next(1, process.Length - 1);
            lbl_Status.Text = process[num];
            pnl_LoadingBar.Width += 5;
            if (pnl_LoadingBar.Width == 300)
            {
                lbl_Status.Text = "Payslip successfully generated!";
                t_Loading.Stop();
                Hide();
            }
        }
    }
}