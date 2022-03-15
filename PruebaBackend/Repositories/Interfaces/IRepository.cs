using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PruebaBackend.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<ICollection<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task<int> Count();
        Task<T> GetByIdAsync(int id);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
