using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.DbContext;
using FurnitureFactory.Interfaces;

namespace FurnitureFactory.Models
{
    public class Product: IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public IEnumerable<ProductTemplate> Templates { get; set; }
    }
}
