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
using System.Drawing.Printing;

namespace PharmacyManagementSystem
{
    public partial class CashierOder : UserControl
    {
        string connectionString = @"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=pharmacy1;Integrated Security=True";

        public CashierOder()
        {
            InitializeComponent();

            displayCategories();
            displayAvailableProducts();
            displayAllorders();
            displayTotal();
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;

            }
            displayCategories();
            displayAvailableProducts();
            displayAllorders();
            displayTotal();
        }

        public void displayAvailableProducts()
        {
            adminAddProductsData productsData = new adminAddProductsData();
            dataGridView1.DataSource = productsData.addProductsList();
        }

        public void displayAllorders()
        {
            cashierOrderData coData = new cashierOrderData();
            dataGridView2.DataSource = coData.cashierOrdersList();
        }
        public void displayCategories()
        {
            order_category.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string selectData = "SELECT * FROM categories WHERE status = 'Active'";
                using (SqlCommand cmd = new SqlCommand(selectData, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        order_category.Items.Add(reader["category"].ToString());
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void order_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            order_prodName.Text = "";
            Order_prodid.SelectedIndex = -1;
            Order_prodid.Items.Clear();
            order_regprice.Text = "";
            order_quantity.Value = 0;

            string selectedValue = order_category.SelectedItem as string;

            if (selectedValue != null)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string selectData = $"SELECT * FROM products WHERE category = @category AND status = 'Active'";

                    using (SqlCommand cmd = new SqlCommand(selectData, con))
                    {
                        cmd.Parameters.AddWithValue("@category", selectedValue);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string value = reader["prod_id"].ToString();

                                Order_prodid.Items.Add(value);
                            }
                        }
                    }
                }
            }
        }

        private void Order_prodid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = Order_prodid.SelectedItem as string;

            if (selectedValue != null)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string selectData = "SELECT * FROM products WHERE prod_id = @prodID AND status = 'Active'";

                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        cmd.Parameters.AddWithValue("@prodID", selectedValue);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string prodName = reader["prod_name"].ToString();
                                string prodPrice = reader["price"].ToString();

                                order_prodName.Text = prodName;
                                order_regprice.Text = prodPrice;

                            }
                        }
                    }
                }
            }

        }

        private void order_prodName_Click(object sender, EventArgs e)
        {

        }

        private void order_addbtn_Click(object sender, EventArgs e)
        {
            if (order_category.SelectedIndex == -1 || Order_prodid.SelectedIndex == -1 || order_prodName.Text == "" || order_regprice.Text == "" || order_quantity.Value == 0)
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertData = "INSERT INTO orders (customer_id, prod_id,prod_name, category, regular_price, quantity, status, date_order) VALUES(@cid, @pid, @prodName, @cat, @regprice, @qty, @status, @date)";

                    using(SqlCommand cmd = new SqlCommand(insertData, connection))
                    {
                        cmd.Parameters.AddWithValue("@cid", generateID());
                        cmd.Parameters.AddWithValue("@pID",Order_prodid.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@prodName", order_prodName.Text.Trim());
                        cmd.Parameters.AddWithValue("@cat", order_category.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@regPrice", order_regprice.Text.Trim());
                        cmd.Parameters.AddWithValue("@qty", order_quantity.Value);
                        cmd.Parameters.AddWithValue("@status", "Pending");
                        DateTime today = DateTime.Today;
                        cmd.Parameters.AddWithValue("@date", today);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Added successfully!", "Information Message", MessageBoxButtons.OK,MessageBoxIcon.Information);

                    }
                }

            }
            displayAllorders();
            displayTotal();
        }

        public int generateID()
        {
            int getID = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string selectData = "SELECT MAX(id) as getID FROM transactions1";

                using (SqlCommand cmd = new SqlCommand(selectData, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["getID"]!= DBNull.Value)
                            {
                                getID = Convert.ToInt32(reader["getID"]);
                            }
                           

                            if (getID == 0)
                            {
                                getID = 1;
                            }
                        }
                    }
                }
            }

            if (getID == 0)
            {
                return 1;
            }
            else
            {
                return getID += 1;
            }
        }

        public void displayTotal()
        {
            order_totalPrice.Text ="$"+ getTotal().ToString() + ".00";
        }

        public float getTotal()
        {
            float totalprice = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string selectData = "SELECT regular_price as price, quantity as qty FROM orders WHERE customer_id = "+ generateID();

                using(SqlCommand cmd = new SqlCommand( selectData, conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("price")) && !reader.IsDBNull(reader.GetOrdinal("qty")))
                            {
                                float price;
                                int qty;
                                if (float.TryParse(reader["price"].ToString(), out price) && int.TryParse(reader["qty"].ToString().ToString(), out qty))
                                {
                                    totalprice += price * qty;
                                }

                            }
                                                    
                        }

                    }
                }


            }
            return totalprice;

        }
        public void clearFields()
        {
            order_category.SelectedIndex = -1;
            Order_prodid.SelectedIndex = -1;
            order_prodName.Text = "-------";
            order_regprice.Text = "-------";
            order_quantity.Value = 0;
        }
        private void order_clearbtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void order_amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void order_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                try
                {
                    float getAmount = Convert.ToSingle(order_amount.Text);
                    float getChange = (getAmount - getTotal());

                    if(getChange <= -1)
                    {
                        order_amount.Text = "";
                        order_change.Text = "";
                    }
                    else
                    {
                        order_change.Text = getChange.ToString();
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Invalid", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    order_amount.Text = "";
                    order_change.Text = "";
                }
            }
        }

        private void order_paybtn_Click(object sender, EventArgs e)
        {
            if(order_amount.Text == "" || dataGridView2.Rows.Count < 0)
            {
                MessageBox.Show("Something went wrong", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (MessageBox.Show("Are you sure for paying?", "Confirm Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using(SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertData = "INSERT INTO transactions1(customer_id, total_price, status, date_trans)" + "VALUES(@cid, @totalP, @status, @date )";

                        using(SqlCommand command = new SqlCommand(insertData, connection))
                        {
                            command.Parameters.AddWithValue("@cid", generateID());
                           
                            command.Parameters.AddWithValue("@totalP", getTotal());

                            command.Parameters.AddWithValue("@status","Completed");
                            DateTime today = DateTime.Today;

                            command.Parameters.AddWithValue("@date", today);

                            command.ExecuteNonQuery();



                        }
                        string updateData = "UPDATE orders SET status = 'Completed' WHERE customer_id = " + (generateID() +1);

                        using(SqlCommand updateD = new SqlCommand(updateData, connection))
                        {
                            updateD.ExecuteNonQuery();
                            MessageBox.Show("Successful!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
                displayTotal();
            }
        }

        private void order_removebtn_Click(object sender, EventArgs e)
        {


            if (getOrderID != 0)    
            {
                if(MessageBox.Show("Are you sure you want to Delete ID:" + getOrderID+ "?", "Confirm Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string deleteData = "DELETE FROM orders WHERE id = " + getOrderID;

                        using (SqlCommand cmd = new SqlCommand(deleteData, conn))
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Removed successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }


                }


            }
            else
            {
                MessageBox.Show("Select item first", "Error Message", MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            displayAllorders();
            displayTotal();

        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {

        }
        private int getOrderID = 0;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                getOrderID = (int)row.Cells[0].Value;
            }

        }

        private void order_receiptbtn_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.BeginPrint += new PrintEventHandler(printDocument1_BeginPrint);

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }
        private int rowIndex = 0;
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            float totalPrice = getTotal();

            float y = 0;
            int count = 0;
            int colWidth = 120;
            int headerMargin = 10;
            int tableMargin = 20;

            Font font = new Font("Arial", 12);
            Font bold = new Font("Arial", 12, FontStyle.Bold);
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font lableFont = new Font("Arial", 14, FontStyle.Bold);

            float margin = e.MarginBounds.Top;

            StringFormat alignCenter = new StringFormat();
            alignCenter.Alignment = StringAlignment.Center;
            alignCenter.LineAlignment = StringAlignment.Center;

            string headerText = "Tharushi's Pharmacy system";
            y = (margin + count * headerFont.GetHeight(e.Graphics) + headerMargin);
            e.Graphics.DrawString(headerText, headerFont, Brushes.Black, e.MarginBounds.Left + (dataGridView2.Columns.Count / 2) * colWidth, y, alignCenter);

            count++;
            y += tableMargin;

            string[] header = {"ID" ,"CID","ProdID", "ProdName", "Category", "Qty", "RegPrice" };

            for(int i = 0; i < header.Length; i++)
            {
                y = margin + count * bold.GetHeight(e.Graphics) + tableMargin;
                e.Graphics.DrawString(header[i], bold, Brushes.Black, e.MarginBounds.Left + i * colWidth, y, alignCenter);
            }

            count++;

            float rSpace = e.MarginBounds.Bottom - y;

            while(rowIndex < dataGridView2.Rows.Count)
            {
                DataGridViewRow row = dataGridView2.Rows[rowIndex];

                for(int i = 0; i< dataGridView2.Columns.Count; i++)
                {
                    object cellValue = row.Cells[i].Value;
                    string cell = (cellValue != null) ? cellValue.ToString() : string.Empty;

                    y = margin + count * font.GetHeight(e.Graphics) + tableMargin;
                    e.Graphics.DrawString(cell, font, Brushes.Black, e.MarginBounds.Left + i*colWidth, y, alignCenter);
                }
                count++;
                rowIndex++;

                if(y + font.GetHeight(e.Graphics) > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                int lableMargin = (int)Math.Min(rSpace, 200);

                    DateTime today = DateTime.Now;
                float lableX = e.MarginBounds.Right - e.Graphics.MeasureString("------------------------", lableFont).Width;

                y = e.MarginBounds.Bottom - lableMargin - lableFont.GetHeight(e.Graphics);
                e.Graphics.DrawString("Total Price: \t$" + totalPrice + "\nAmount: \n$" + order_amount.Text + "\n\t\t----------------\nChange: \t$ " + order_change.Text, lableFont, Brushes.Black, lableX,y);

                lableMargin = (int)Math.Min(rSpace, -40);

                string lableText = today.ToString();
                y = e.MarginBounds.Bottom - lableMargin - lableFont.GetHeight(e.Graphics);
                e.Graphics.DrawString(lableText, lableFont, Brushes.Black, e.MarginBounds.Right - e.Graphics.MeasureString("------------------------", lableFont).Width,y);
            }
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            rowIndex = 0;
        }
    }
}