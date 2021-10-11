using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.Interfaces;
using FurnitureFactory.Models;
using FurnitureFactory.Repository;
using FurnitureFactory.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace FurnitureFactory.Services
{
    class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private ILogger<ProductService> _iLogger;

        public ProductService(ILogger<ProductService> iLogger, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _iLogger = iLogger;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            var res = await _productRepository.Create(product);
            return res;
        }

        public async Task<IList<Product>> GetAllProductsAsync()
        {
            return await _productRepository.FindAll();
        }

        public async Task<Product> GetProductByName(string attributeValue)
        {
            return await _productRepository.FindByCondition(x => x.Name == attributeValue);
        }
    }
}
