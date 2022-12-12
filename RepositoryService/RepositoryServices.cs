using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpworkAssessment.Model;

namespace UpworkAssessment.RepositoryService
{
    public class RepositoryServices: IRepositoryServices
    {
        private readonly ApplicationDbContext _dbContext;
        public RepositoryServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product GetProduct(Guid productId)
        {
            var product = _dbContext.Products.Find(productId);
            if(product is null)
            {
                throw new Exception("Not Found");
            }
            return product;
        }
        public void DeleteProduct(Guid productId)
        {
            var product = _dbContext.Products.Find(productId);
            if (product is not null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
            return;
            
        }
        public void UpdateProduct(Product newProduct)
        {
            var product = _dbContext.Products.AsNoTracking().FirstOrDefault(prod => prod.ProductId == newProduct.ProductId);
            Console.WriteLine("updating");
            if (product is null)
            {
                throw new Exception("Invalid Update");
            }
            _dbContext.Products.Update(newProduct);
            Console.WriteLine("updating 1");
            _dbContext.SaveChanges();
        }

        public void CreateProduct(Product product)
        {
            if (_dbContext.Products.Find(product.ProductId) is not null)
            {
                throw new Exception("Invalid Action");
            }

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }
    }
}
