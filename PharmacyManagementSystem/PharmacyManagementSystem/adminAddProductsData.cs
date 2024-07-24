using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PharmacyManagementSystem
{
    internal class adminAddProductsData

    {
        string connectionString = @"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=pharmacy1;Integrated Security=True";

        public int ID { set; get; }
        public string ProductID { set; get; }
        public string ProductName { set; get; }
        public string Category { set; get; }
        public string price { set; get; }
        public string Stock { set; get; }
        public string image { set; get; }
        public string Status { set; get; }
        public string Date { set; get; }

        public List<adminAddProductsData> addProductsList()
        {
            List<adminAddProductsData> listData = new List<adminAddProductsData>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string selectData = "SELECT * FROM products";

                using (SqlCommand cmd = new SqlCommand(selectData, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        adminAddProductsData data = new adminAddProductsData();
                        data.ID = (int)reader["id"];
                        data.ProductID = reader["prod_id"].ToString();
                        data.ProductName = reader["prod_name"].ToString();
                        data.Category = reader["category"].ToString();
                        data.price = reader["price"].ToString();
                        data.Stock = reader["stock"].ToString();
                        data.image = reader["image"].ToString();
                        data.Status = reader["status"].ToString();
                        data.Date = ((DateTime)reader["date_insert"]).ToString("MM-dd-yyyy");

                        listData.Add(data);

                    }
                }
            }
            return listData;
        }
        
        
    }
}


