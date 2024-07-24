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
    public partial class adminAddCategories : UserControl
    {
        string connectionString = @"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=pharmacy1;Integrated Security=True";

        public adminAddCategories()
        {
            InitializeComponent();

            displayCategoriesData();
        }

        public void refreshData()
        {
            if(InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;

            }
            displayCategoriesData();
        }
        public void displayCategoriesData()
        {
            adminAddCategoriesData data = new adminAddCategoriesData();
            List<adminAddCategoriesData> listData = data.listAddCategoriesData();

            dataGridView1.DataSource = listData;
        }

        private void addCategory_add_Click(object sender, EventArgs e)
        {
            if(addCategory_category.Text == "" || addCategory_status.SelectedIndex == -1)
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string insertCategory = "INSERT INTO categories(category, status, date_insert) VALUES(@category, @status, @date)";

                    using(SqlCommand cmd = new SqlCommand(insertCategory, conn))
                    {
                        cmd.Parameters.AddWithValue("@category", addCategory_category.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", addCategory_status.Text.Trim());

                        DateTime today = DateTime.Today;
                        cmd.Parameters.AddWithValue("@date", today);

                        cmd.ExecuteNonQuery();
                        clearFields();

                        MessageBox.Show("Added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            displayCategoriesData();
        }
        public void clearFields()
        {
            addCategory_category.Text = "";
            addCategory_status.SelectedIndex = -1;
        }

        private void addCategory_clear_Click(object sender, EventArgs e)
        {
            clearFields();

        }

        private void addCategory_update_Click(object sender, EventArgs e)
        {
            if (addCategory_category.Text == "" ||  addCategory_status.SelectedIndex == -1)
            {
                MessageBox.Show("Please select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to update id:" + getID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string updateData = "UPDATE categories SET category = @category, status = @status where id = @id";

                        using (SqlCommand cmd = new SqlCommand(updateData, conn))
                        {
                            cmd.Parameters.AddWithValue("@category", addCategory_category.Text.Trim());
    
                            cmd.Parameters.AddWithValue("@status", addCategory_status.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@id", getID);


                            cmd.ExecuteNonQuery();
                            clearFields();
                            MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            displayCategoriesData(); 
        }
        private int getID = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) 
            { 
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells[0].Value);
                addCategory_category.Text = row.Cells[1].Value.ToString();
                addCategory_status.Text = row.Cells[2].Value.ToString();
            }

        }

        private void addCategory_delete_Click(object sender, EventArgs e)
        {
            if (addCategory_category.Text == "" || addCategory_status.SelectedIndex == -1 )
            {
                MessageBox.Show("Please select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete id:" + getID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string deleteData = "DELETE FROM categories where id = @id";

                        using (SqlCommand cmd = new SqlCommand(deleteData, conn))
                        {

                            cmd.Parameters.AddWithValue("@id", getID);


                            cmd.ExecuteNonQuery();
                            clearFields();
                            MessageBox.Show("Deleted successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            displayCategoriesData();
        }

        private void addCategory_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
