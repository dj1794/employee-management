using BuildingBlock.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Configuration.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeDb _dbContext;
        public UnitOfWork(EmployeeDb dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task StartTransaction()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }
        public async Task CommitTransaction()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }
        public async Task RollbackTransaction()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
