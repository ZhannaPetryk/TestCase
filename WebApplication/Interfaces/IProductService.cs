using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Data.Entities;

namespace WebApplication.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProduct(int productId);
        List<Product> GetProducts();
        Task<Product> AddProduct(Product product);
        Task<Product> EditProduct(Product product);
        Task DeleteProduct(Product product);
    }
}