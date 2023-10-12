using BuildingBlock.Infrastructure;
using Employee.Infrastructure.Configuration;
using Employee.Infrastructure.Configuration.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddDbContext<EmployeeDb>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HrmDb"),
                options => options.MigrationsHistoryTable("__EFMigrationsHistory", DbSchema.Employee)
                );

            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(EmployeeModule).Assembly))
               .AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandMidleware<,>));
            return services;
        }
    }
}
