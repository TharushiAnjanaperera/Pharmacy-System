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
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=pharmacy1;Integrated Security=True";


        public Form1()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void logshowpass_CheckedChanged(object sender, EventArgs e)
        {
            logpass.PasswordChar = logshowpass.Checked ? '\0' : '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void signin_Click(object sender, EventArgs e)
        {
            if (loguname.Text == "" || logpass.Text == "")
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string selectData = "SELECT * FROM usersT WHERE username = @usern AND password = @pass AND status = 'Active'";

                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        cmd.Parameters.AddWithValue("@usern", loguname.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", logpass.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            DataRow row = dt.Rows[0];
                            string role = row["role"].ToString();

                            if(role == "Admin")
                            {

                                MainForm mainForm = new MainForm();
                                mainForm.Show();
                            }
                            else if(role == "Cashier")
                            {
                                CashierMainForm cmForm = new CashierMainForm();
                                cmForm.Show();
                            }


                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username/Password or you need Admin's approval", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void register_Click(object sender, EventArgs e)
        {
            registerForm regfrom = new registerForm();
            regfrom.Show();

            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
