using WithDapper.Models;
using WithDapper.Data;
namespace WithDapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=localhost;Database=Ecommerce_DB;Trusted_Connection=True;TrustServerCertificate=True;";
            var repo = new ProductRepository(connectionString);

            // CREATE
            Product product = new Product();
            product.Name = "Chips";
            product.Price = 100;
            product.CategoryId = 2;
            repo.Add(product);
            //// READ
            //var category1 = repo.GetById(1);
            //Console.WriteLine(category1.Name);


            // DELETE
            repo.DeleteById(1);

        }
    }
}
