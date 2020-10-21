using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sportsmans_warehouse
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btnClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin(object sender, EventArgs e)
        {
            this.Hide();
            Home f2 = new Home();
            f2.Show();
            
            
        }

        private void btnAddUser(object sender, EventArgs e)
        {

        }
    }
}
