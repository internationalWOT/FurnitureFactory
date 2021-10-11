using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.Models;

namespace FurnitureFactory.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(Product product);
        Task<IList<Product>> GetAllProductsAsync();

        Task<Product> GetProductByName(string attributeValue);
    }
}
