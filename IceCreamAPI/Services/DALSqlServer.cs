using Dapper;
using IceCreamAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamAPI.Services
{
    public class DALSqlServer : IDAL
    {
        private string connectionString;

        public DALSqlServer(IConfiguration config)
        {
            connectionString = config.GetConnectionString("iceCreamDB");
        }

        public string[] GetProductCategories()
        {
            SqlConnection connection = null;
            string queryString = "SELECT DISTINCT Category FROM Products";
            IEnumerable<Product> Products = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Products = connection.Query<Product>(queryString);
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }
           
            if (Products == null)
            {
                return null;
            }
            else
            {
                string[] categories = new string[Products.Count()];
                int count = 0;

                foreach (Product p in Products)
                {
                    categories[count] = p.Category;
                    count++;
                }

                return categories;
            }

        }

        public IEnumerable<Product> GetProductsAll()
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Products";
            IEnumerable<Product> Products = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Products = connection.Query<Product>(queryString);
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return Products;
        }

        public Product GetProductById(int id)
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Products WHERE Id = @id";
            Product product = null;

            try
            {
                connection = new SqlConnection(connectionString);
                product = connection.QueryFirstOrDefault<Product>(queryString, new { id = id });
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return product;
        }

    }
}
