using Calcis.Shared.Abstractions.Modules;
using Calcis.Shared.Infrastructure.Modules;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Calcis.Bootstraper")]
namespace Calcis.Modules.Employee.Api
{
    public class EmployeeModule : IModule
    {
        public EmployeeModule() { }

        public void Register(IServiceCollection service, IMvcBuilder mvc)
        {
            LayerLoader.RegisterLayers(service, "Employee.");
        }

        public void RegisterContexts(IServiceProvider serviceProvider)
        {
            LayerLoader.RegisterContexts(serviceProvider, "Employee.");
        }
    }
}
