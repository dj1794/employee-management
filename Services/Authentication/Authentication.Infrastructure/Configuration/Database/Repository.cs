using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Configuration.Database
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AutenticationDb _dbContext;
        public  IQueryable<T> Table { get; set; }

        public Repository(AutenticationDb context)
        {
            _dbContext = context;
            Table = _dbContext.Set<T>().AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return  _dbContext.Set<T>().AsNoTracking();
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
