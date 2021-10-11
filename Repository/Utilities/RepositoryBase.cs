using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.DbContext;
using FurnitureFactory.Models;
using FurnitureFactory.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace FurnitureFactory.Repository.RepositoryBase
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext RepositoryContext { get; set; }
        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            this.RepositoryContext = applicationDbContext;
        }
        public async Task<IList<T>> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking().ToList();
        }

        public async Task<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToList().FirstOrDefault();
        }
        public async Task<T> Create(T entity)
        {
            var res = await this.RepositoryContext.Set<T>().AddAsync(entity);
            return res.Entity;
        }
        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            Save();
        }
        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            Save();
        }

        private void Save()
        {
            this.RepositoryContext.SaveChanges();
        }
        
    }
}
