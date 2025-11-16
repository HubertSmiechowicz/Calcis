using Calcis.Shared.Abstractions.Modules;
using Calcis.Shared.Infrastructure.Modules;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Calcis.Bootstraper")]
namespace Calcis.Modules.Fleet.Api
{
    public class FleetModule : IModule
    {
        private IList<ILayer> layers; 

        public FleetModule() 
        {
            layers = LayerLoader.LoadLayers("Fleet.");
        }

        public void Register(Microsoft.Extensions.DependencyInjection.IServiceCollection services, Microsoft.Extensions.DependencyInjection.IMvcBuilder mvc, IConfiguration config)
        {
            LayerLoader.RegisterLayers(services, layers, config);
        }

        public void RegisterContexts(IServiceProvider serviceProvider)
        {
            LayerLoader.RegisterContexts(serviceProvider, layers);
        }
    }
}
