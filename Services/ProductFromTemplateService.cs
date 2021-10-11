using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.Interfaces;
using FurnitureFactory.Models;
using FurnitureFactory.Repository;
using FurnitureFactory.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace FurnitureFactory.Services
{
    public class ProductFromTemplateService: IProductFromTemplateService
    {
        private IProductRepository _productRepository;
        private readonly ILogger<ProductFromTemplateService> _iLogger;
        private TemplateRepository _templateRepository;

        public ProductFromTemplateService(ILogger<ProductFromTemplateService> iLogger, IProductRepository productRepository,
            TemplateRepository templateRepository)
        {
            _productRepository = productRepository;
            _iLogger = iLogger;
            _templateRepository = templateRepository;
        }

        public async Task<Product> BuildOneProduct(string templateName)
        {
            Template template = _templateRepository.FindByCondition(x => x.Name == templateName).Result;

            if (template == null)
            {
                throw new ObjectNotFoundException();
            }

            var products = template.Products;

            foreach (var relationProduct in products)
            {
                int amountRequired = relationProduct.Amount;
                var product = _productRepository.FindByCondition(x => x.Id == relationProduct.Id).Result;

                if (product.Amount ! <= amountRequired)
                {
                    product.Amount -= amountRequired;
                    _productRepository.Update(product);
                    return product;
                }
            }

            return null;
        }

        public Task<IList<Product>> BuildMultipleProductsBasedOnTemplate(string templateName, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
