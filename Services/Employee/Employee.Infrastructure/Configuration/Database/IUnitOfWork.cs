using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Configuration.Database
{
    public interface IUnitOfWork : IDisposable
    {
        public  Task StartTransaction();
        public  Task CommitTransaction();
        public  Task RollbackTransaction();
        Task<bool> SaveChangesAsync();
    }
}
