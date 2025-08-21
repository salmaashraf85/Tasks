using WithDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace WithDapper.Data
{
    public class CategoryRepository
    {
        private readonly string _connectionString;

        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Category c)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("AddCategory",c, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Category? GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Category>("GetCategory", new { Id = id }, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();

            }
        }

        public void Update(Category category)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("UpdateCategory", category, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void DeleteById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("DeleteCategory", new { Id = id }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

}
}
