using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>();

            using (var conn =
                new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;"))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Products";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var prod = new Product() { Name = reader["Name"].ToString() };
                    products.Add(prod);
                }
            }

            Console.WriteLine("Products Loaded!");
            
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
