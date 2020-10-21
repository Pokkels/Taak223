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
    public partial class Home : Form
    {
        public Home()
        {
            this.Show();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        
        //Inventory
        private void btnInventory(object sender, EventArgs e)
        {
            this.Hide();
            Inventory f2 = new Inventory();
            f2.Show();
        }
        //Sales order
        private void btnSalesOrder(object sender, EventArgs e)
        {
            this.Hide();
            Place_Order f2 = new Place_Order();
            f2.Show();
        }


        //Purchase
        private void btnPurchaseOrder(object sender, EventArgs e)
        {
            this.Hide();
            Delete_Order f2 = new Delete_Order();
            f2.Show();
        }


        //Reports
        private void btnViewReports(object sender, EventArgs e)
        {
            this.Hide();
            Reports f2 = new Reports();
            f2.Show();
        }

        //Suppliers
        private void btnSuppliers(object sender, EventArgs e)
        {
            this.Hide();
            Suppliers f2 = new Suppliers();
            f2.Show();
        }
        //Exit
        private void btnExit(object sender, EventArgs e)
        {
            this.Hide();
            Login f2 = new Login();
            f2.Show();
        }

        
    }
}
