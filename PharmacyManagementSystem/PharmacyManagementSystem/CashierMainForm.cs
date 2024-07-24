using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    public partial class CashierMainForm : Form
    {
        public CashierMainForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }

        private void cashierOder1_Load(object sender, EventArgs e)
        {

        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            adminDashboard1.Visible = true;
            cashierOder1.Visible = false;
            adminCustomers1.Visible = false;

            adminDashboard aDashboard = adminDashboard1 as adminDashboard;

            if(aDashboard != null)
            {
                aDashboard.refreshData();
            }
        }

        private void orders_btn_Click(object sender, EventArgs e)
        {
            adminDashboard1.Visible = false;
            cashierOder1.Visible = true;
            adminCustomers1.Visible = false;

            CashierOder cOrders = cashierOder1 as CashierOder;

            if (cOrders != null)
            {
                cOrders.refreshData();
            }
        }

        private void customers_btn_Click(object sender, EventArgs e)
        {
            adminDashboard1.Visible = false;
            cashierOder1.Visible = false;
            adminCustomers1.Visible = true;

            adminCustomers aCustomer = adminCustomers1 as adminCustomers;

            if (aCustomer != null)
            {
                aCustomer.refreshData();
            }
        }
    }
}
