using Calcis.Modules.Employee.Application.Commands.Handlers;
using Calcis.Shared.Abstractions.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Calcis.Modules.Employee.Infrastructure")]
[assembly: InternalsVisibleTo("Calcis.Bootstraper")]
[assembly: InternalsVisibleTo("MediatR")]
namespace Calcis.Modules.Employee.Application
{
    public class EmployeeApplicationLayer : ILayer

    {
        public void Register(IServiceCollection service, IConfiguration config)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly(),
                    Assembly.GetAssembly(typeof(CreateUserKeycloakHandler))
                ));
        }

        public void RegisterContexts(IServiceProvider serviceProvider)
        {
        }
    }
}
