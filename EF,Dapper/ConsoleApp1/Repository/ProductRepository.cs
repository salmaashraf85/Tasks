using ConsoleApp1.Data;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repository
{
    public class ProductRepository
    {

        private readonly AppDBcontext _context;

        public ProductRepository(AppDBcontext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Database.ExecuteSqlRaw("exec AddProduct @p0 @p1 @p2", product.Name, product.Price, product.CategoryId);
        }


        public Product? GetById(int id)
        {
            return
            _context.Products.FromSqlRaw("exec GetProduct @p0", id).AsEnumerable().FirstOrDefault();
        }

        public void Update(Product product)
        {
            _context.Database.ExecuteSqlRaw("exec UpdateProduct @p0 @p1 @p2 @p3", product.Id, product.Name, product.Price, product.CategoryId);
        }

        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw("exec DeleteProduct @p0 ", id);
        }
    }

}

