using Microsoft.EntityFrameworkCore;
using PruebaBackend.DbContextData;
using PruebaBackend.Entities;
using PruebaBackend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PruebaBackend.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected Context RepositoryContext { get; set; }
        protected DbSet<T> dbSet;

        public Repository(Context repositoryContext)
        {
            RepositoryContext = repositoryContext;
            dbSet = repositoryContext.Set<T>();
        }

        public async Task<ICollection<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();
        }
        public async Task<int> Count()
        {
            return await dbSet.CountAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task Create(T entity)
        {
            await dbSet.AddAsync(entity);
        }
        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
