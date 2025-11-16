using Calcis.Shared.Abstractions.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Calcis.Modules.Employee.Application")]
[assembly: InternalsVisibleTo("Calcis.Modules.Employee.Infrastructure")]
namespace Calcis.Modules.Employee.Core
{
    public class EmployeeCoreLayer : ILayer
    {
        public void Register(IServiceCollection service, IConfiguration config)
        {
        }

        public void RegisterContexts(IServiceProvider serviceProvider)
        {
        }
    }
}
