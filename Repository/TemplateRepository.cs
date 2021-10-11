using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.DbContext;
using FurnitureFactory.Interfaces;
using FurnitureFactory.Models;
using FurnitureFactory.Repository.RepositoryBase;
using Microsoft.Extensions.Logging;

namespace FurnitureFactory.Repository
{
    public class TemplateRepository : RepositoryBase<Template>, ITemplateRepository
    {

        private ApplicationDbContext _applicationDbContext;
        private ILogger<ProductRepository> logger;

        public TemplateRepository(ILogger<ProductRepository> logger, ApplicationDbContext applicationDbContext) : base(applicationDbContext)
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
