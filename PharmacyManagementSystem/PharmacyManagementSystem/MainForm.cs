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
    public partial class MainForm : Form
    {
        public MainForm()
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
            if(MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminDashboard1.Visible = false;
            adminAddProducts1.Visible = false;
            adminAddCategories1.Visible = false;
            adminAddUsers1.Visible = false;
            adminCustomers1.Visible = true;


            adminCustomers aCustomer = adminCustomers1 as adminCustomers;

            if (aCustomer != null)
            {
                aCustomer.refreshData();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            adminDashboard1.Visible = false;
            adminAddProducts1.Visible = false;
            adminAddCategories1.Visible = true;
            adminAddUsers1.Visible = false;
            adminCustomers1.Visible = false;

            adminAddCategories aaCategory = adminAddCategories1 as adminAddCategories;

            if (aaCategory != null)
            {
                aaCategory.refreshData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adminDashboard1.Visible = false;
            adminAddProducts1.Visible = true;
            adminAddCategories1.Visible = false;
            adminAddUsers1.Visible = false;
            adminCustomers1.Visible = false;

            adminAddProducts aaProduct = adminAddProducts1 as adminAddProducts;

            if (aaProduct != null)
            {
                aaProduct.refreshData();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminDashboard1.Visible = false;
            adminAddProducts1.Visible = false;
            adminAddCategories1.Visible = false;
            adminAddUsers1.Visible = true;
            adminCustomers1.Visible = false;


            adminAddUsers asUsers = adminAddUsers1 as adminAddUsers;

            if (asUsers != null)
            {
                asUsers.refreshData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminDashboard1.Visible = true;
            adminAddProducts1.Visible = false;
            adminAddCategories1.Visible = false;
            adminAddUsers1.Visible = false;
            adminCustomers1.Visible = false;

            adminDashboard aDashbord = adminDashboard1 as adminDashboard;

            if (aDashbord != null)
            {
                aDashbord.refreshData();
            }

        }
    }
}
