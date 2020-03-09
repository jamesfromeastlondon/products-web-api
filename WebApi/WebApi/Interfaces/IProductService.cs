using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(long id);
        bool UpdateProduct(long id, string description);
    }
}
