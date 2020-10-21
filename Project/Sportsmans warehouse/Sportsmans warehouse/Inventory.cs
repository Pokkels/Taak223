using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sportsmans_warehouse
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }

        public string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\heino\OneDrive\Desktop\Project\Sportsmans warehouse\Sportsmans warehouse\Inventory.mdf;Integrated Security=True";
        public SqlConnection conn;
        public SqlCommand cmd;
        public SqlDataAdapter adap;
        public DataSet ds;
        public DataTable dt;


        public void Display()
        {
            string select_All = "SELECT * FROM Inventory";
            try
            {
                conn = new SqlConnection(constr);
                conn.Open();
                cmd = new SqlCommand(select_All, conn);
                ds = new DataSet();
                adap = new SqlDataAdapter();
                adap.SelectCommand = cmd;
                adap.Fill(ds, "stable");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "stable";
                conn.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnHome(object sender, EventArgs e)
        {
            this.Hide();
            Home f2 = new Home();
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

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string Inv_Code = txtINVCode.Text;
            string Supplies_ID = txtSuppliersID.Text;
            string Sales_ID = txtSalesID.Text;
            string Brands_ID = txtBrandsID.Text;
            string Date_IN = txtDateIN.Text;
            string Date_Out = txtDateOut.Text;

            try
            {
                string insert_query = "INSERT INTO Inventory(Inv_Code, Supplies_ID, Sales_ID, Brands_ID,Date_IN,Date_Out) VALUES(@Inv_Code, @Supplies_ID, @Sales_ID, @Brands_ID,@Date_IN,@Date_Out)";
                conn = new SqlConnection(constr);
                conn.Open();
                cmd = new SqlCommand(insert_query, conn);
                cmd.Parameters.AddWithValue("@Inv_Code", Inv_Code.ToString());
                cmd.Parameters.AddWithValue("@Supplies_ID", Supplies_ID.ToString());
                cmd.Parameters.AddWithValue("@Sales_ID", Sales_ID.ToString());
                cmd.Parameters.AddWithValue("@Brands_ID", Brands_ID.ToString());
                cmd.Parameters.AddWithValue("@Date_IN", Date_IN.ToString());
                cmd.Parameters.AddWithValue("@Date_Out", Date_Out.ToString());

                cmd.ExecuteNonQuery();
                txtINVCode.Clear();
                txtSuppliersID.Clear();
                txtSalesID.Clear();
                txtBrandsID.Clear();
                txtDateIN.Clear();
                txtDateOut.Clear();
                Display();
                conn.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Inv_Code = txtINVCode.Text;
            string Supplies_ID = txtSuppliersID.Text;
            string Sales_ID = txtSalesID.Text;
            string Brands_ID = txtBrandsID.Text;
            string Date_IN = txtDateIN.Text;
            string Date_Out = txtDateOut.Text;



            if (Inv_Code == " ")
            {
                MessageBox.Show("Please eneter a valid CODE");
            }
            conn.Open();
            string Update_query = "UPDATE Inventory SET Inv_Code = @Inv_Code, Supplies_ID = @Supplies_ID, Sales_ID = @Sales_ID, Brands_ID= @Brands_ID,Date_IN = @Date_IN ,Date_Out = @Date_Out WHERE Inv_Code = @Inv_Code";
            cmd = new SqlCommand(Update_query, conn);

            cmd.Parameters.AddWithValue("@Inv_Code", Inv_Code.ToString());
            cmd.Parameters.AddWithValue("@Supplies_ID", Supplies_ID.ToString());
            cmd.Parameters.AddWithValue("@Sales_ID", Sales_ID.ToString());
            cmd.Parameters.AddWithValue("@Brands_ID", Brands_ID.ToString());
            cmd.Parameters.AddWithValue("@Date_IN", Date_IN.ToString());
            cmd.Parameters.AddWithValue("@Date_Out", Date_Out.ToString());
            cmd.ExecuteNonQuery();
            conn.Close();
            Display();
            txtINVCode.Clear();
            txtSuppliersID.Clear();
            txtSalesID.Clear();
            txtBrandsID.Clear();
            txtDateIN.Clear();
            txtDateOut.Clear();

            MessageBox.Show(Inv_Code + "has been sucsessfully updated!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtDelete.Text;

            try
            {
                conn.Open();
                string delete_query = "DELETE FROM Inventory WHERE Inv_Code = @id";


                cmd = new SqlCommand(delete_query, conn);
                cmd.Parameters.AddWithValue("@id", id.ToString());
                cmd.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Record deleted");
                Display();

                txtDelete.Clear();

            }
            catch (Exception err)

            {
                MessageBox.Show(err.Message);

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string SearchN = txtSearch.Text;
            conn = new SqlConnection(constr);
            conn.Open();
            adap = new SqlDataAdapter("select * from Inventory where Supplies_ID like '" + txtSearch.Text + "%'", conn);
            dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

    }
    
    
}
