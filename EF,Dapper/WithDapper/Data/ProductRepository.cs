using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WithDapper.Models;

 namespace WithDapper.Data
{
    public class ProductRepository
    {

        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Product p)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("AddProduct", new
                {
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId

                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Product? GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Product>("GetProduct", new { Id = id }, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();

            }
        }

        public void Update(Product p)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("UpdateProduct", new
                {
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId

                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void DeleteById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("DeleteProduct", new { Id = id }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }

    }

