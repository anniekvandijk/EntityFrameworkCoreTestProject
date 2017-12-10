using System.Linq;
using System.Net.Http.Headers;
using EntityFrameworkCoreTestProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityFrameworkCoreTestProject.Test
{
    [TestClass]
    public class Tests

    {
        [TestMethod]
        public void GetProducts()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var result = unitOfWork.ProductRepository.Get(product => product.ProductName != "test");
            unitOfWork.Dispose();
            Assert.AreEqual(7, result.Count());
        }
        [TestMethod]
        public void GetProductById()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var result = unitOfWork.ProductRepository.GetById(5L);
            unitOfWork.Dispose();
            Assert.AreEqual("King Stephen. 'Salem's Lot", result.ProductName);
        }

        [TestMethod]
        public void AddProduct()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var productCategory = unitOfWork.ProductCategoryRepository.GetById(9L);

            var product = new Product
            {
                ProductName = "test",
                Category = productCategory
            };
            var result = unitOfWork.ProductRepository.Insert(product);
            unitOfWork.Save();
            unitOfWork.Dispose();
            Assert.IsTrue(result.ProductName.Equals("test"));
            Assert.IsTrue(result.Category.CategoryName.Equals("poetry"));
        }

        [TestMethod]
        public void DeleteProduct()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var productCategory = unitOfWork.ProductCategoryRepository.GetById(9L);

            var productAdd = new Product
            {
                ProductName = "deltest",
                Category = productCategory
            };
            unitOfWork.ProductRepository.Insert(productAdd);
            unitOfWork.Save();
            unitOfWork.Dispose();

            UnitOfWork unitOfWork2 = new UnitOfWork();
            var result2 = unitOfWork2.ProductRepository.Get(product => product.ProductName == "deltest");
            Assert.IsTrue(result2.Count().Equals(1));
            foreach (var product in result2)
            {
                unitOfWork2.ProductRepository.Delete(product.Id);    
            }
            unitOfWork2.Save();
            unitOfWork2.Dispose();
            UnitOfWork unitOfWork3 = new UnitOfWork();
            var result3 = unitOfWork3.ProductRepository.Get(product => product.ProductName == "deltest");
            Assert.IsTrue(result3.Count().Equals(0));
        }
    }
}
