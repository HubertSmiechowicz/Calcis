using Calcis.Shared.Abstractions.Modules;
using Calcis.Shared.Infrastructure.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Calcis.Bootstraper")]
namespace Calcis.Modules.Employee.Api
{
    public class EmployeeModule : IModule
    {
        private IList<ILayer> layers;

        public EmployeeModule() 
        {
            layers = LayerLoader.LoadLayers("Employee.");
        }

        public void Register(IServiceCollection service, IMvcBuilder mvc, IConfiguration config)
        {
            LayerLoader.RegisterLayers(service, layers, config);
        }

        public void RegisterContexts(IServiceProvider serviceProvider)
        {
            LayerLoader.RegisterContexts(serviceProvider, layers);
        }
    }
}
