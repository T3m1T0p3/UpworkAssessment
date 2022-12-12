using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpworkAssessment.Model;

namespace UpworkAssessment.RepositoryService
{
    public interface IRepositoryServices
    {
        public Product GetProduct(Guid id);
        public void CreateProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Guid id);
    }
}
