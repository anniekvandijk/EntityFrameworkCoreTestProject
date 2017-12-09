using System.Net.Http.Headers;
using EntityFrameworkCoreTestProject.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityFrameworkCoreTestProject.Test
{
    [TestClass]
    public class Tests

    {
        [TestMethod]
        public void FindProducts()
        {
            var productService = new ProductService();
            var result = productService.GetAllProducts();
            Assert.AreEqual(7, result.Count);
        }
        [TestMethod]
        public void FindProductsBycategory()
        {
            var productService = new ProductService();
            var result = productService.GetProductsByCategory("novel");
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void AddProduct()
        {
            //var productService = new ProductService();
            //var result = productService.AddProduct("test", category);
            //Assert.IsTrue(result.ProductName.Equals("test"));
            //Assert.IsTrue(result.Category.CategoryName.Equals("poetry"));
        }
    }
}
