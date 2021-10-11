using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.DbContext;
using FurnitureFactory.Interfaces;
using FurnitureFactory.Models;
using FurnitureFactory.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FurnitureFactory.Repository
{
    public class ProductRepository: RepositoryBase<Product>, IProductRepository
    {

        private ApplicationDbContext _applicationDbContext;
        private ILogger<ProductRepository> logger;

        public ProductRepository(ILogger<ProductRepository> logger, ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            try
            {
                this.logger = logger;
                this._applicationDbContext = applicationDbContext;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
