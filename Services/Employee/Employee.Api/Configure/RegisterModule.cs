using Employee.Infrastructure;
using MediatR;
namespace Employee.Api.Configure
{
    public static class RegisterModule
    {
        public static IServiceCollection ConfigureMediator(this IServiceCollection services)
        {
            
            services.AddScoped<EmployeeModule>();
            return services;
        }
    }
 
}
