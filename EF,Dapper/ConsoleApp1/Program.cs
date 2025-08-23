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
            //add category
            using (var context = new AppDBcontext())
            {
                var category = new Category
                {
                    Name="Toys"
                };

                bool exists = context.Categories.Any(c => c.Name == category.Name);
                if (!exists)
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("this is already exists");
                }
            }

            //add product

            using (var context = new AppDBcontext())
            {
                var product = new Product
                {
                    Name = "yoyo",
                    Price=100,
                    CategoryId=1
                };

                  context.Products.Add(product);
                  context.SaveChanges();
              
            }

            //update product 
            using (var context = new AppDBcontext())
            {
                Product product= context.Products.FirstOrDefault(p => p.Id == 1);

                if (product != null)
                {
                    product.Price= 100;
                    context.SaveChanges();
                }
                else
                { Console.WriteLine("this product not exist"); }

            }
            
            //update category 
            using (var context = new AppDBcontext())
            {
                Category category = context.Categories.FirstOrDefault(c => c.Id == 1);

                if (category != null)
                {
                    category.Name = "meat";
                    context.SaveChanges();
                }
                else
                { Console.WriteLine("this category not exist"); }

            }
            //delete product
            using (var context = new AppDBcontext())
            {
                Product product = context.Products.FirstOrDefault(p => p.Id == 1);

                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                else
                { Console.WriteLine("this product not exist"); }

            }

            //delete Categogry

            using (var context = new AppDBcontext())
            {
                Category category = context.Categories.FirstOrDefault(c => c.Id == 1);

                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
                else
                { Console.WriteLine("this category not exist"); }

            }

            //get product by id 
            using (var context = new AppDBcontext())
            {
                Product product = context.Products.FirstOrDefault(p => p.Id == 1);

                if (product == null)
                    Console.WriteLine("this product not exist");
            }

            //get category by id 
            using (var context = new AppDBcontext())
            {
                Category category = context.Categories.FirstOrDefault(c => c.Id == 1);

                if (category == null)
                    Console.WriteLine("this category not exist");
            }



        }
    }
}
