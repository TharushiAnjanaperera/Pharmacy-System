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
using System.Windows.Markup;

namespace PharmacyManagementSystem
{
    public partial class registerForm : Form
    {
        string connectionString = @"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=pharmacy1;Integrated Security=True";
        public registerForm()
        {
            InitializeComponent();
        }

        private void registershowpass_CheckedChanged(object sender, EventArgs e)
        {
            regpass.PasswordChar = registershowpass.Checked ? '\0' : '*';
            regconfirmpass.PasswordChar = registershowpass.Checked ? '\0' : '*';

        }

        private void login_Click(object sender, EventArgs e)
        {
            Form1 loginFrom = new Form1();
            loginFrom.Show();

            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_Click(object sender, EventArgs e)
        {
            if(reguname.Text == "" || regpass.Text == "" || regconfirmpass.Text == "")
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string checkUsernQuery = "SELECT * FROM usersT WHERE username = @usern";

                    using(SqlCommand cmd = new SqlCommand(checkUsernQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@usern", reguname.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        if(dt.Rows.Count != 0)
                        {
                            string tempUsern = reguname.Text.Substring(0,1).ToUpper() + reguname.Text.Substring(1);
                            MessageBox.Show(tempUsern + "is existing already", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }else if(regpass.Text.Length < 6)
                        {
                            MessageBox.Show("Invalid Password, at least 6 characters are needed", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }else if(regpass.Text != regconfirmpass.Text)
                        {
                            MessageBox.Show("Password does not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            string insertData = "INSERT INTO usersT (username, password, role, status, date_register)" + "VALUES(@usern, @pass, @role,@status, @date)";

                            using(SqlCommand cmda = new SqlCommand(@insertData, conn))
                            {
                                cmda.Parameters.AddWithValue("@usern", reguname.Text.Trim());
                                cmda.Parameters.AddWithValue("@pass", regpass.Text.Trim());
                                cmda.Parameters.AddWithValue("@role", "Cashier");
                                cmda.Parameters.AddWithValue("@status", "Approval");


                                DateTime today = DateTime.Today;
                                cmda.Parameters.AddWithValue("@date", today);

                                cmda.ExecuteNonQuery();

                                MessageBox.Show("Registered successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Form1 login = new Form1();
                                login.Show();

                                this.Hide();
                            }
                        }
                    }
                }
            }
        }
    }
}
