using System.Collections.Generic;
using System.Linq;
using EntityFrameworkCoreTestProject.Context;
using EntityFrameworkCoreTestProject.Models;

namespace EntityFrameworkCoreTestProject.Services
{
    public class ProductService : MyDbContext
    {
        public List<Product> GetAllProducts()
        {
            return Products
                .Select(x =>
                    new Product
                    {
                        Id = x.Id,
                        ProductName = x.ProductName,
                        Price = x.Price,
                    })
                .ToList();
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return Products
                .Where(x => x.Category.CategoryName == category)
                .Select(x =>
                    new Product
                    {
                        Id = x.Id,
                        ProductName = x.ProductName,
                        Price = x.Price,
                    })
                .ToList();
        }

        public Product AddProduct(string productName, ProductCategory category)
        {
            var product = new Product
            {
                ProductName = productName,
                Category = category
            };
            Context.Add(product);
            Context.SaveChanges();
            return product;
        }
    }
}
