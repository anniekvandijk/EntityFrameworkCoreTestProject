using System;
using System.Linq;
using EntityFrameworkCoreTestProject.Context;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MyDbContext();

            Console.WriteLine("Entity Framework Core (EF7) Code-First sample");
            Console.WriteLine();

            MyDbContextSeeder.Seed(context);

            Console.WriteLine("Products with categories");
            Console.WriteLine();

            var query = context.Products.Include(p => p.Category)
                .Where(p => p.Price > 20.0)
                .ToList();

            Console.WriteLine("{0,-10} | {1,-50} | {2}", "ProductID", "ProductName", "CategoryName");
            Console.WriteLine();
            foreach (var product in query)
                Console.WriteLine("{0,-10} | {1,-50} | {2}", product.Id, product.ProductName, product.Category.CategoryName);

            Console.ReadKey();
        }
    }
}
