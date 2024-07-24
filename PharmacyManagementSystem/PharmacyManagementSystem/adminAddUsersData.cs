using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PharmacyManagementSystem
{
    internal class adminAddUsersData
    {
        string connectionString = @"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=pharmacy1;Integrated Security=True";

        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }

        public List<adminAddUsersData> listAddUsersData()
        {
            List<adminAddUsersData> listData = new List<adminAddUsersData>();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string selectData = "SELECT * FROM usersT";

                using(SqlCommand cmd = new SqlCommand(selectData, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        adminAddUsersData aauData = new adminAddUsersData();
                        aauData.ID = (int)reader["id"];
                        aauData.Username = reader["username"].ToString();
                        aauData.Password = reader["password"].ToString();
                        aauData.Role = reader["role"].ToString();
                        aauData.Status = reader["status"].ToString();
                        if(reader["date_register"] != null) 
                        {
                            aauData.Date = ((DateTime)reader["date_register"]).ToString("MM-dd-yyyy");
                        }
                       

                        listData.Add(aauData);

                    }


                }
            }
            return listData;
        }

    }
}
