using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ConsoleApp1.Repository
{
    internal class CategoryRepoDapper
    {
        private readonly string _connectionString;

        public CategoryRepoDapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(string name, int age)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("AddStudent", new { Name = name, Age = age }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
