using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.Models;

namespace FurnitureFactory.Services.Interfaces
{
    public interface IProductFromTemplateService
    {
        Task<Product> BuildOneProduct(string templateName);
        Task<IList<Product>> BuildMultipleProductsBasedOnTemplate(string templateName, int amount);
    }
}
