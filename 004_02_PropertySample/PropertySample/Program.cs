using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PropertySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 连接mysql
            string connectionString = "server=localhost;user=root;database=AdventureWorks;port=3306;password=mysql";
            FetchProducts(connectionString);
            Console.WriteLine("-----------------------------------------");

            // 了解以方法为侧重点的类
            double x = Math.Sqrt(4);
            Console.WriteLine(x);
            x = Math.Pow(2,3);
            Console.WriteLine(x);
        }

        static void FetchProducts(string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Successfully connected to the database.");

                    string query = "SELECT * FROM Product";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming Product table has columns: ProductID, Name
                            int id = reader.GetInt32("ProductID");
                            string name = reader.GetString("Name");
                            Console.WriteLine($"Id: {id}, Name: {name}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
