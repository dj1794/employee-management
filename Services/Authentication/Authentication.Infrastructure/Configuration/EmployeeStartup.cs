using BuildingBlock.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Configuration
{
    public class EmployeeStartup : IEmployeeStartup
    {
        public required string ConnectionString { get; set; }
        public required IServiceCollection services {  get; set; }
        public EmployeeStartup()
        {
                 services?
                .AddDbContext<AutenticationDb>(opt =>
                opt.UseSqlServer(ConnectionString));
        }

        public IServiceCollection RegisterService(IServiceCollection services)
        {
            throw new NotImplementedException();
        }
    }
}
