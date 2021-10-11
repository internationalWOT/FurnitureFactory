using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactory.Models;

namespace FurnitureFactory.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IList<T>> FindAll();
        Task<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
