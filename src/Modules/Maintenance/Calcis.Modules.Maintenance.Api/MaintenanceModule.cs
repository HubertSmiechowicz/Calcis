using Calcis.Shared.Abstractions.Modules;
using Calcis.Shared.Infrastructure.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Calcis.Bootstraper")]
namespace Calcis.Modules.Maintenance.Api
{
    public class MaintenanceModule : IModule
    {
        private IList<ILayer> layers;

        public MaintenanceModule()
        {
            layers = LayerLoader.LoadLayers("Maintenance.");
        }

        public void Register(IServiceCollection services, IMvcBuilder mvc, IConfiguration config)
        {
            LayerLoader.RegisterLayers(services, layers, config);
        }

        public void RegisterContexts(IServiceProvider serviceProvider)
        {
            LayerLoader.RegisterContexts(serviceProvider, layers);
        }
    }
}
