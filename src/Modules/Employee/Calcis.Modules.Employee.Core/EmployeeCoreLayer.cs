using Calcis.Shared.Abstractions.Modules;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Calcis.Modules.Employee.Application")]
[assembly: InternalsVisibleTo("Calcis.Modules.Employee.Infrastructure")]
namespace Calcis.Modules.Employee.Core
{
    public class EmployeeCoreLayer : ILayer
    {
        public void Register(IServiceCollection service)
        {
        }

        public void RegisterContexts(IServiceProvider serviceProvider)
        {
        }
    }
}
