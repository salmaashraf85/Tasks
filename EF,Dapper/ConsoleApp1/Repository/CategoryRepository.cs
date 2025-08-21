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
    public class CategoryRepository
    {
        private readonly AppDBcontext _context;

        public CategoryRepository(AppDBcontext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
           _context.Database.ExecuteSqlRaw("exec AddCategory @p0", category.Name);
        }


        public Category? GetById(int id)
        {
             return
            _context.Categories.FromSqlRaw("exec GetCategory @p0", id).AsEnumerable().FirstOrDefault();
        }

        public void Update(Category category)
        {
            _context.Database.ExecuteSqlRaw("exec UpdateCategory @p0 @p1", category.Id, category.Name);
        }

        public void DeleteById(int id)
        {
           _context.Database.ExecuteSqlRaw("exec DeleteCategory @p0 ", id);
        }

}
}
