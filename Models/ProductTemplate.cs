using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.Models.Interfaces;

namespace FurnitureFactory.Models
{
    public class ProductTemplate: IProductTemplate
    { 
        public int Id { get; set; }
        public int PostId { get; set; }
        public Product Product { get; set; }
        public int TagId { get; set; }
        public Template Template { get; set; }
        public int Amount { get; set; }
    }
}
