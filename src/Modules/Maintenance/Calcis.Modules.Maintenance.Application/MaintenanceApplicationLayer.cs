using Calcis.Modules.Maintenance.Application.Commands.Handlers;
using Calcis.Shared.Abstractions.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Calcis.Modules.Maintenance.Infrastructure")]
[assembly: InternalsVisibleTo("Calcis.Bootstraper")]
[assembly: InternalsVisibleTo("MediatR")]
namespace Calcis.Modules.Maintenance.Application
{
    public class MaintenanceApplicationLayer : ILayer
    {
        public void Register(IServiceCollection service, IConfiguration config)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly(),
                    Assembly.GetAssembly(typeof(UserCreatedMaintenanceHandler))
                ));
        }

        public void RegisterContexts(IServiceProvider serviceProvider)
        {
        }
    }
}
