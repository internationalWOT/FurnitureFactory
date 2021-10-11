using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.DbContext;
using FurnitureFactory.Interfaces;

namespace FurnitureFactory.Models
{
    public class Template: ITemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductTemplate> Products { get; set; }
    }
}
