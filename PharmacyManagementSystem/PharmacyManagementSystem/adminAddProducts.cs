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
using System.IO;

namespace PharmacyManagementSystem
{
    public partial class adminAddProducts : UserControl
    {
        string connectionString = @"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=pharmacy1;Integrated Security=True";

        public adminAddProducts()
        {
            InitializeComponent();

            displayCategories();

            displayProducts();
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;

            }
            displayCategories();

            displayProducts();
        }

        public void displayProducts()
        {
            adminAddProductsData aapData = new adminAddProductsData();
            List<adminAddProductsData> listData = aapData.addProductsList();

            dataGridView1.DataSource = listData;
        }

        public void displayCategories()
        {

            addproduct_category.Items.Clear();
           
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string selectCategories = "SELECT * FROM categories WHERE status = 'Active'";

                using (SqlCommand cmd = new SqlCommand(selectCategories, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        addproduct_category.Items.Add(reader["category"]);
                        addproduct_status.Items.Add(reader["status"]);


                    }
                }
            }
        }

        private void adminAddProducts_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void import_btn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image File(*.jpg; *.png|*.jpg;*.png)";

                string imagePath = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    pictureBox1.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void product_add_Click(object sender, EventArgs e)
        {
            if (addproduct_pid.Text == "" | addproduct_pname.Text == "" || addproduct_price.Text == "" || addproduct_stock.Text == "" || addproduct_category.SelectedIndex == -1 || addproduct_status.SelectedIndex == -1 || pictureBox1.Image == null)
            {

                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string checkprodID = "SELECT * FROM products WHERE prod_id = @prodID";

                    using (SqlCommand checkPID = new SqlCommand(checkprodID, conn))
                    {
                        checkPID.Parameters.AddWithValue("@prodID", addproduct_pid.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(checkPID);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show(addproduct_pid.Text.Trim() + "is taken already", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                            string insertData = "INSERT INTO products(prod_id, prod_name, category, price, stock, image,status,date_insert) " +
                                "VALUES(@prodID, @prodName,@category, @price, @stock, @image, @status, @date)";

                            string relativePath = Path.Combine("products_directory", addproduct_pid.Text.Trim() + ".jpg");
                            string path = Path.Combine(baseDirectory, relativePath);

                            string directoryPath = Path.GetDirectoryName(path);
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            File.Copy(pictureBox1.ImageLocation, path, true);

                            using (SqlCommand cmd = new SqlCommand(insertData, conn))
                            {
                                cmd.Parameters.AddWithValue("@prodID", addproduct_pid.Text.Trim());
                                cmd.Parameters.AddWithValue("@prodName", addproduct_pname.Text.Trim());
                                cmd.Parameters.AddWithValue("@category", addproduct_category.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@price", addproduct_price.Text.Trim());
                                cmd.Parameters.AddWithValue("@stock", addproduct_stock.Text.Trim());
                                cmd.Parameters.AddWithValue("@image", path);

                                cmd.Parameters.AddWithValue("@status", addproduct_status.SelectedItem.ToString());




                                DateTime today = DateTime.Today;
                                cmd.Parameters.AddWithValue("@date", today);

                                cmd.ExecuteNonQuery();
                                clearFields();

                                MessageBox.Show("Added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    conn.Close();
                }
                displayProducts();

            }
        }
        public void clearFields()
        {
            addproduct_pid.Text = "";
            addproduct_pname.Text = "";
            addproduct_price.Text = "";
            addproduct_stock.Text = "";
            addproduct_category.SelectedIndex = -1;
            addproduct_status.SelectedIndex = -1;
            pictureBox1.Image = null;
        }
        private int getID = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;
                addproduct_pid.Text = row.Cells[1].Value.ToString();
                addproduct_pname.Text = row.Cells[2].Value.ToString();
                addproduct_category.SelectedItem = row.Cells[3].Value.ToString();
                addproduct_price.Text = row.Cells[4].Value.ToString();
                addproduct_stock.Text = row.Cells[5].Value.ToString();
                addproduct_status.SelectedItem = row.Cells[7].Value.ToString();

                string imagePath = row.Cells[6].Value.ToString();
                try
                {
                    if(imagePath != null)
                    {
                        pictureBox1.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show("Error:" +ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void product_update_Click(object sender, EventArgs e)
        {
            if (addproduct_pid.Text == "" | addproduct_pname.Text == "" || addproduct_price.Text == "" || addproduct_stock.Text == "" || addproduct_category.SelectedIndex == -1 || addproduct_status.SelectedIndex == -1 || pictureBox1.Image == null)
            
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

                            string updateData = "UPDATE products SET prod_id = @prodID, prod_name = @prodName, category = @category, price =@price, stock = @stock, status = @status  WHERE id = @id";

                            using (SqlCommand cmd = new SqlCommand(updateData, conn))
                            {
                                cmd.Parameters.AddWithValue("@prodID", addproduct_pid.Text.Trim());
                                cmd.Parameters.AddWithValue("@prodName", addproduct_pname.Text.Trim());

                                cmd.Parameters.AddWithValue("@category", addproduct_category.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@price", addproduct_price.Text.Trim());
                                cmd.Parameters.AddWithValue("@stock", addproduct_stock.Text.Trim());
                                cmd.Parameters.AddWithValue("@status", addproduct_status.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@id", getID);


                                cmd.ExecuteNonQuery();
                                clearFields();
                                MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            displayProducts();

            }

        private void product_delete_Click(object sender, EventArgs e)
        {
            if (addproduct_pid.Text == "" | addproduct_pname.Text == "" || addproduct_price.Text == "" || addproduct_stock.Text == "" || addproduct_category.SelectedIndex == -1 || addproduct_status.SelectedIndex == -1 || pictureBox1.Image == null)
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

                        string deleteData = "DELETE FROM products where id = @id";

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
            displayProducts();
        }

        private void product_clear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void addproduct_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

