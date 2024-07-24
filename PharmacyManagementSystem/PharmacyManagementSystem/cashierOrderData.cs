using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace PharmacyManagementSystem
{
    internal class cashierOrderData
    {
        string connectionString = @"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=pharmacy1;Integrated Security=True";

        public int ID { set; get; }
        public int customerID { set; get; }
        public string prodID { set; get; }
        public string prodName { set; get; }
        public string category { set; get; }
        public string RegPrice { set; get; }
        public string Quantity { set; get; }

        public List<cashierOrderData> cashierOrdersList()
        {
            List<cashierOrderData> listData = new List<cashierOrderData>();
            int getCIDData = 0;

            using(SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                string getCID = "SELECT MAX(customer_id) as cID FROM orders";

                using (SqlCommand getCustomerID = new SqlCommand(getCID, connect))
                {
                    using(SqlDataReader readCID = getCustomerID.ExecuteReader())
                    {
                        if (readCID.Read())
                        {
                            if (readCID["cID"] != DBNull.Value)
                            {
                                getCIDData = (int)readCID["cID"];
                            }

                        }
                        
                    }
                }
                string getOrders = "SELECT * FROM orders WHERE customer_id = " + getCIDData;

                using(SqlCommand cmd = new SqlCommand(getOrders,connect)) 
                { 
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cashierOrderData coData = new cashierOrderData();

                            coData.ID = (int)reader["id"];
                            coData.customerID = (int)reader["customer_id"];
                            coData.prodID = reader["prod_id"].ToString();
                            coData.prodName = reader["prod_name"].ToString();
                            coData.category = reader["category"].ToString();
                            coData.RegPrice = reader["regular_price"].ToString();
                            coData.Quantity = reader["quantity"].ToString();

                            listData.Add(coData);

                        }
                    }
                }
            }
            return listData;
        }



    }
}
