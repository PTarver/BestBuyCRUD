using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace BestBuyInClassProject
{
    class ProductRepository
    {
        private string connectionstring = "Server=localhost;Database=bestbuy;Uid=root;Pwd=password;";

        // create read method

        public List<Product> GetProducts()
        {
            MySqlConnection Conn = new MySqlConnection(connectionstring);

            using (Conn)
            {
                Conn.Open();
                MySqlCommand cmd = Conn.CreateCommand();
                cmd.CommandText = "select productid, name, price, categoryid from products;";
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Product> products = new List<Product>();

                while (reader.Read())
                {
                    Product prod = new Product();
                    prod.Productid = (int)reader["productid"];
                    prod.Name = (string)reader["name"];
                    prod.Price = (decimal)reader["price"];
                    prod.Categoryid = (int)reader["categoryid"];

                    products.Add(prod);
                }
                return products;

            }

        }


        public void CreateProduct(Product prod)
        {
            MySqlConnection conn = new MySqlConnection(connectionstring);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO products (Name, Price, CategoryID) Values (@n , @p , @cID);";
                cmd.Parameters.AddWithValue("n", prod.Name);
                cmd.Parameters.AddWithValue("p", prod.Price);
                cmd.Parameters.AddWithValue("cID", prod.Categoryid);
                cmd.ExecuteNonQuery();
            }
        }
















        public void UpdateProduct(Product prod)
        {
            var conn = new MySqlConnection(connectionstring);

            using (conn)
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE products SET Name = @n, Price = @p, CategoryId = @cID " +
                                    "WHERE ProductId = @pID;";
                cmd.Parameters.AddWithValue("n", prod.Name);
                cmd.Parameters.AddWithValue("p", prod.Price);
                cmd.Parameters.AddWithValue("cID", prod.Categoryid);
                cmd.Parameters.AddWithValue("pID", prod.Productid);
                cmd.ExecuteNonQuery();
            }
        }


        public void DeleteProduct(Product prod)
        {
            var conn = new MySqlConnection(connectionstring);

            using (conn)
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM products WHERE Name = @n;";
                cmd.Parameters.AddWithValue("n", prod.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int id)
        {
            var conn = new MySqlConnection(connectionstring);

            using (conn)
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM products WHERE ProductID = @id;";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
















}






