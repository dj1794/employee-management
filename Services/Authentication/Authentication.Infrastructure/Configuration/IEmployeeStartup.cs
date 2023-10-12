using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Configuration
{
    public interface IEmployeeStartup
    {
         IServiceCollection RegisterService(IServiceCollection services);
    }
}
