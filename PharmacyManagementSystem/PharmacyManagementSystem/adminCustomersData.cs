using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PharmacyManagementSystem
{

    internal class adminCustomersData
    {
        string connectionString = @"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=pharmacy1;Integrated Security=True";

        public int ID { set; get; }
        public int CustomerID { set; get; }
        public string TotalPrice {  set; get; }
        public string Status { set; get; }
        public string DateTransaction { set; get; }

        public List<adminCustomersData> customersDatalist()
        {
            List<adminCustomersData> listData = new List<adminCustomersData>();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                 conn.Open();

                string selectData = "SELECT * FROM transactions1";

                using(SqlCommand cmd = new SqlCommand(selectData, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        adminCustomersData data = new adminCustomersData(); 

                        data.ID = (int)reader["id"];
                        data.CustomerID = (int)reader["customer_id"];
                        data.TotalPrice = reader["total_price"].ToString();
                        data.Status = reader["status"].ToString();
                        data.DateTransaction = ((DateTime)reader["date_trans"]).ToString("MM-dd-yyyy");

                        listData.Add(data);

                    }
                }
            }
            return listData;
        }
    }
}
