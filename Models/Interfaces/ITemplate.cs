using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.DbContext;
using FurnitureFactory.Models;

namespace FurnitureFactory.Interfaces
{
    public interface ITemplate : IModel
    {
        string Name { get; set; }
        public IEnumerable<ProductTemplate>? Products{ get; set; }
    }
}
