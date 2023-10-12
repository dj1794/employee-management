using Authentication.Infrastructure;
namespace Employee.Api.Configure
{
    public static class RegisterModule
    {
        public static IServiceCollection ConfigureModule(this IServiceCollection services)
        {            
            services.AddScoped<AuthenticationModule>();
            return services;
        }
    }
 
}
