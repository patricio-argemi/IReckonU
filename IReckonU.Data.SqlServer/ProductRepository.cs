using System;
using System.Collections.Generic;
using IReckonU.Data.Models;
using IReckonU.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace IReckonU.Data.SqlServer
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext dbContext;

        public ProductRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Product> Get()
        {
            return this.dbContext.Products;
        }

        public Product Find(string key)
        {
            var product = this.dbContext.Products.Find(key);

            if (product == null)
                throw new KeyNotFoundException("Product not found in the database.");

            return product;
        }

        public void Add(IEnumerable<Product> products)
        {
            try
            {
                this.dbContext.AddRange(products);
                this.dbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
