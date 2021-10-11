using System;
using System.Collections.Generic;
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
    class TemplateService: ITemplateService
    {
        private ITemplateRepository _productRepository;
        private ILogger<TemplateService> _iLogger;

        public TemplateService(ILogger<TemplateService> iLogger, ITemplateRepository templateRepository)
        {
            _productRepository = templateRepository;
            _iLogger = iLogger;
        }

        public async Task<Template> AddTemplateAsync(Template template)
        {
            var res = await _productRepository.Create(template);
            return res;
        }

        public async Task<IList<Template>> GetAllTemplatesAsync()
        {
            return await _productRepository.FindAll();
        }

        public async Task<Template> GetTemplateByName(string attributeValue)
        {
            return await _productRepository.FindByCondition(x => x.Name == attributeValue);
        }
    }
}
