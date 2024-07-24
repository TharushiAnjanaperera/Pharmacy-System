using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PharmacyManagementSystem
{
    internal class adminAddCategoriesData
    {
        string connectionString = @"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=pharmacy1;Integrated Security=True";
        public int ID { set; get; }
        public string Category { set; get; }
        public string Status { set; get; }
        public string Date { set; get; }
        public List<adminAddCategoriesData> listAddCategoriesData()
        { 
            List<adminAddCategoriesData> listData = new List<adminAddCategoriesData>();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string selectData = "SELECT * FROM categories";

                using(SqlCommand cmd = new SqlCommand(selectData, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        adminAddCategoriesData data = new adminAddCategoriesData();
                        data.ID = (int)reader["id"];
                        data.Category = reader["category"].ToString();
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
