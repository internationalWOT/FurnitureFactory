using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.Interfaces;

namespace FurnitureFactory.Models.Interfaces
{
    public interface IProductTemplate : IModel
    {
        public int PostId { get; set; }
        public Product Product { get; set; }

        public int TagId { get; set; }
        public Template Template { get; set; }

        public int Amount { get; set; }
    }
}
