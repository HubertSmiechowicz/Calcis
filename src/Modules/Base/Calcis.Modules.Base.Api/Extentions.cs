using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Base.Api
{
    public static class Extentions
    {
        public static IServiceCollection AddBaseModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
