using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCoreTestProject.Context;
using EntityFrameworkCoreTestProject.Models;

namespace EntityFrameworkCoreTestProject
{
    public class UnitOfWork : IDisposable
    {
        private readonly MyDbContext _context = new MyDbContext();
        private GenericRepository<Product> _productRepository;
        private GenericRepository<ProductCategory> _productCategoryRepository;

        public GenericRepository<Product> ProductRepository =>
            _productRepository ?? new GenericRepository<Product>(_context);
        public GenericRepository<ProductCategory> ProductCategoryRepository =>
            _productCategoryRepository ?? new GenericRepository<ProductCategory>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
