using ConsoleApp1.Data;
using ConsoleApp1.Repository;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            using (var context = new AppDBcontext())
            {
                var repo = new CategoryRepository(context);

                //// CREATE
                //Category category = new Category();
                //category.Name = "Snacks";
                //repo.Add(category);
                //// READ
                //var category1 = repo.GetById(1);
                //Console.WriteLine(category1.Name);

         
                // DELETE
                repo.DeleteById(1);
                   
            }
        }
    }
}
