using Calcis.Modules.Fleet.Application.Commands.Handlers;
using Calcis.Shared.Abstractions.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Calcis.Modules.Fleet.Infrastructure")]
[assembly: InternalsVisibleTo("Calcis.Bootstraper")]
[assembly: InternalsVisibleTo("MediatR")]
namespace Calcis.Modules.Fleet.Application
{
    public class FleetApplicationLayer : ILayer
    {
        public void Register(IServiceCollection service, IConfiguration config)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly(),
                    Assembly.GetAssembly(typeof(UserCreatedFleetHandler))
                ));
        }

        public void RegisterContexts(IServiceProvider serviceProvider)
        {
        }
    }
}
