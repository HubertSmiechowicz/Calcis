using Calcis.Shared.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Shared.Infrastructure
{
    public static class Extention
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton(typeof(Logger<>));

            return services;
        }
    }
}
