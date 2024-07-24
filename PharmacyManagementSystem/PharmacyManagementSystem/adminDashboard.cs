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

namespace PharmacyManagementSystem
{
    public partial class adminDashboard : UserControl
    {
        string connectionString = @"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=pharmacy1;Integrated Security=True";

        public adminDashboard()
        {
            InitializeComponent();
            displayTotalCashier();
            displayTotalOrder();
            displayTodaysRevenue();
            displayTotalRevenue();
            displayCustomers();
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;

            }
            displayTotalCashier();
            displayTotalOrder();
            displayTodaysRevenue();
            displayTotalRevenue();
            displayCustomers();
        }
        public void displayCustomers()
        {
            adminCustomersData acData = new adminCustomersData();

            dataGridView1.DataSource = acData.customersDatalist();
        }
        public void displayTotalCashier()
        {
            using(SqlConnection cmd = new SqlConnection(connectionString))
            {
                cmd.Open();

                string selectData = "SELECT COUNT(id) as totalCashier FROM usersT WHERE role  = 'Cashier'";

                using(SqlCommand cmd1 = new SqlCommand(selectData,cmd))
                {
                    SqlDataReader reader = cmd1.ExecuteReader();

                    if(reader.Read())
                    {
                        if (reader["totalCashier"] != DBNull.Value)
                        {
                            int totalCash = (int)reader["totalCashier"];

                            totalCashier.Text = totalCash.ToString();
                        }
                    }
                   
                }
            }
        }

        public void displayTotalOrder()
        {
            using (SqlConnection cmd = new SqlConnection(connectionString))
            {
                cmd.Open();

                string selectData = "SELECT COUNT(id) as totalOrders FROM transactions1";

                using (SqlCommand cmd1 = new SqlCommand(selectData, cmd))
                {
                    SqlDataReader reader = cmd1.ExecuteReader();

                    if (reader.Read())
                    {
                        if (reader["totalOrders"] != DBNull.Value)
                        {
                            int totalOrds = (int)reader["totalOrders"];

                            totalOrders.Text = totalOrds.ToString();
                        }
                    }

                }
            }

        }

        public void displayTodaysRevenue()
        {
            using (SqlConnection cmd = new SqlConnection(connectionString))
            {
                cmd.Open();

                DateTime today = DateTime.Today;
                string selectData = "SELECT SUM(total_price) as todaysRevenue FROM transactions1 WHERE date_trans = '"+today+"'";

                using (SqlCommand cmd1 = new SqlCommand(selectData, cmd))
                {
                    SqlDataReader reader = cmd1.ExecuteReader();

                    if (reader.Read())
                    {
                        if (reader["todaysRevenue"] != DBNull.Value)
                        {
                            decimal todayRev = Convert.ToDecimal(reader["todaysRevenue"]);

                            todayRevenue.Text = "$" +todayRev.ToString();
                        }
                    }

                }
            }
        }
        public void displayTotalRevenue()
        {
            using (SqlConnection cmd = new SqlConnection(connectionString))
            {
                cmd.Open();

                DateTime today = DateTime.Today;
                string selectData = "SELECT SUM(total_price) as totalRevenue FROM transactions1";

                using (SqlCommand cmd1 = new SqlCommand(selectData, cmd))
                {
                    SqlDataReader reader = cmd1.ExecuteReader();

                    if (reader.Read())
                    {
                        if (reader["totalRevenue"] != DBNull.Value)
                        {
                            decimal totalRev = Convert.ToDecimal(reader["totalRevenue"]);

                            totalRevenue.Text = "$" + totalRev.ToString();
                        }
                    }

                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
