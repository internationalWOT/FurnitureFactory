using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.DbContext;
using FurnitureFactory.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureFactory.Interfaces
{
    public interface IProduct : IModel
    {
        string Name { get; set; }
        double Amount { get; set; }
        public IEnumerable<ProductTemplate>? Templates { get; set; }

    }
}
