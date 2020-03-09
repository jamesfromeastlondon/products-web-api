using System.Collections.Generic;
using System.Linq;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationContext applicationContext;
        public ProductService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public List<Product> GetAll()
        {
            return applicationContext.Products.ToList();
        }

        public Product GetById(long id)
        {
            return applicationContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateProduct(long id, string description)
        {
            Product product = GetById(id);
            if (product == null)
                return false;
            product.Description = description;
            applicationContext.Update(product);
            applicationContext.SaveChanges();
            return true;
        }
    }
}
