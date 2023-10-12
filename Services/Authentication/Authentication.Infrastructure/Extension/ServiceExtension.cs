using Authentication.Application;
using Authentication.Infrastructure.Configuration;
using Authentication.Infrastructure.Configuration.Database;
using Authentication.Infrastructure.Utility;
using BuildingBlock.Infrastructure;
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

namespace Authentication.Infrastructure.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddDbContext<AutenticationDb>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HrmDb"),
                     options => options.MigrationsHistoryTable("__EFMigrationsHistory", DbSchema.Employee));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(AuthenticationModule).Assembly))
               .AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandMidleware<,>));
            return services;
        }
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddScoped<IJwtService, JwtService>();
            return services;
        }
            
    }
}
