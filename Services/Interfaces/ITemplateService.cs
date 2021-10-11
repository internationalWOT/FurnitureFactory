using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.Models;

namespace FurnitureFactory.Services.Interfaces
{
    public interface ITemplateService
    {
        Task<Template> AddTemplateAsync(Template template);
        Task<IList<Template>> GetAllTemplatesAsync();

        Task<Template> GetTemplateByName(string attributeValue);
    }
}
